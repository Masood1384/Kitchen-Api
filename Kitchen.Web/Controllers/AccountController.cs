using Kitchen.Core.Domain.User;
using Kitchen.Data.Repository;
using Kitchen.Framework;
using Kitchen.Service.Catalog;
using Kitchen.Service.Catalog.UserService;
using Kitchen.Service.DTOs.UserDTO;
using Kitchen.Service.Tools.Emailsender;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.ComponentModel.DataAnnotations;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace Kitchen.Web.Controllers
{
    public class AccountController : KitchenController
    {
        #region Feild
        private readonly IConfiguration _configuration;
        private readonly IUserService _userService;
        private readonly IRepository<User> _userRepository;
        private readonly IEmailSenderService _emailSender;
        public AccountController(IUserService userService, IRepository<User> userrepository, IConfiguration configuration, IEmailSenderService emailSender)
        {
            _userService = userService;
            _userRepository = userrepository;
            _configuration = configuration;
            _emailSender = emailSender;
        }
        #endregion
        [HttpGet , Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetAlLUser()
        {
            var li =await _userService.GettAll();
            if(li.Count() == 0)
            {
                return NotFound();
            }
            return Ok(li);
        }
        [HttpGet("finduser/{Id}") , Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetbyIdUser(int Id)
        {
            if (!_userService.IsExist(Id))
            {
                return NotFound();
            }

            var list =await _userRepository.GetbyId(Id);
           
            return Ok(list);
        }

        [HttpPost("RigesterUser"), AllowAnonymous]
        public async Task<IActionResult> RigesterUser(UserRigesterDTO userRigesterDTO)
        {
            var list =await _userRepository.GetbyUsername(userRigesterDTO.UserName);
            if(userRigesterDTO.ID != 0)
            {
                return BadRequest();
            }
            if(list != null)
            {
                return BadRequest("کاربری با این یوزر وجود دارد");
            }
            
            await _userService.RigesterUser(userRigesterDTO);
            #region SendConiform Email
            UserLoginDTO u = new UserLoginDTO { Password = userRigesterDTO.Password, UserName = userRigesterDTO.UserName };
            var refreshtoken = await GnerateRefreshToken();
            await SetRefreshToken(refreshtoken, u);
            var lis = await _userRepository.GetbyUserEmail(userRigesterDTO.Email);
            var coniformlink = Url.Action(nameof(EmailConiform), "Account", new { Token = lis.RefreshToken }, Request.Scheme);
            var body = $"<div style=\"text-align: center; padding: 18px;direction: rtl; width: 95%;background-color: aqua;height: auto;left: 0px;border-radius: 15px;\">\r\n    <h1 style=\"margin-top: 20px;text-align: center;\">ممنون از ثبت نام شما</h1>\r\n    <h3 style=\"color: red;\">لطفا حساب خود را تایید کنید</h3>\r\n    <a id=\"btn\" type=\"button\" style=\"text-align: center;text-decoration: none;font-size: 30px;font-weight: bold;padding: 15px;background-color: blue;color: white;border-radius: 15px;\" href=\"{coniformlink}\" >تایید حساب</a>\r\n    </div>";
            await _emailSender.SendEmail(lis.Email, "تایید حساب", body);
            #endregion
            return CreatedAtAction("GetbyIdUser", new { Id = userRigesterDTO.ID }, userRigesterDTO);
        }

        [HttpPost("Login") , AllowAnonymous]
        public async Task<IActionResult> Login(UserLoginDTO user)
        {
            var li =await _userService.searchbuUsername(user);
            var list = await _userRepository.GetbyUsername(user.UserName);
            
            if (li.Count() == 0)
            {
                return NotFound("کاربری با این یوزر نیم ثبت نشده است");
            }
            if(!BCrypt.Net.BCrypt.Verify(user.Password,list.Password))
            {
                return BadRequest("پسورد وارد شده اشتباه است");
            }
            if (list.ConiformEmail == false)
            {
                return BadRequest("لطفا حساب خود را تایید کنید");
            }

            string Token =await _userService.Login(list);
            var refreshtoken = await GnerateRefreshToken();
            await SetRefreshToken(refreshtoken, user);
            
            return Ok(Token);

        }
        [HttpPost("RefreshToken"), Authorize]
        public async Task<IActionResult> RefreshToken(UserLoginDTO userr)
        {
            var user =await _userRepository.GetbyUsername(userr.UserName);
            var refreshToken = Request.Cookies["refreshToken"];
            if (!user.RefreshToken.Equals(refreshToken))
            {
                return Unauthorized("Invalid RefreshToken");
            }
            else if (user.Expires < DateTime.UtcNow)
            {
                return Unauthorized("Token expired.");
            }
            string token =await _userService.Login(user);
            var refreshtoken = await GnerateRefreshToken();
            await SetRefreshToken(refreshtoken, userr);
            return Ok(token);


        }
        #region TokenRefrsh
        private async Task<RefreshToken> GnerateRefreshToken()
        {
            var refreshtoken = new RefreshToken
            {
                Token = Convert.ToBase64String(RandomNumberGenerator.GetBytes(64)),
                Expires = DateTime.Now.AddDays(1),
                Created = DateTime.Now
            };
            return refreshtoken;
        }
        private async Task SetRefreshToken(RefreshToken newrefreshtoken,UserLoginDTO userr)
        {
            var cookieOption = new CookieOptions
            {
                HttpOnly = true,
                Expires = newrefreshtoken.Expires,
            };
            Response.Cookies.Append("refreshToken", newrefreshtoken.Token, cookieOption);
            var lis = await _userRepository.GetbyUsername(userr.UserName);
            lis.RefreshToken = newrefreshtoken.Token;
            lis.Expires = newrefreshtoken.Expires;
            lis.Created = newrefreshtoken.Created;
            await _userRepository.Update(lis);
            
        }
        #endregion

        [HttpPut("UpdateUser") , Authorize]
        public async Task<IActionResult> UpdateUser(UserUpdateDTO userupdateDTO)
        {
            if(! _userService.IsExist(userupdateDTO.ID))
            {
                return NotFound();
            }
            await _userService.UpdateUser(userupdateDTO);
            return Ok(userupdateDTO);

        }
        [HttpPut("UpdateUserRole"), Authorize(Roles = "Admin")]
        public async Task<IActionResult> UpdateUserRole(UpdateUserRoleDTO userRoleDto)
        {
            if(!_userService.IsExist(userRoleDto.ID))
            {
                return NotFound();
            }
            await _userService.UpdateUserRole(userRoleDto);
            return Ok("Role Changed");
        }
        [HttpPost("SendEmailConiform"),AllowAnonymous]
        public async Task<IActionResult> SendEmailConiform(SendEmailConiformDTO user)
        {
            var lis =await _userRepository.GetbyUserEmail(user.Email);
            if (lis == null)
            {
                return BadRequest("حساب شما ثبت نشده است");
            }
            UserLoginDTO u = new UserLoginDTO { Password = user.Password,UserName = user.UserName};
            var refreshtoken = await GnerateRefreshToken();
            await SetRefreshToken(refreshtoken, u);
            var list = await _userRepository.GetbyUserEmail(user.Email);
            var li = _userRepository.GetbyUsername(u.UserName);
            if (li == null)
            {
                return NotFound("کاربری با این یوزر نیم ثبت نشده است");
            }
            if (!BCrypt.Net.BCrypt.Verify(u.Password, list.Password))
            {
                return BadRequest("پسورد وارد شده اشتباه است");
            }
            var coniformlink = Url.Action(nameof(EmailConiform), "Account", new {Token = list.RefreshToken}, Request.Scheme);
            var body = $"<div style=\"text-align: center; padding: 18px;direction: rtl; width: 95%;background-color: aqua;height: auto;left: 0px;border-radius: 15px;\">\r\n    <h1 style=\"margin-top: 20px;text-align: center;\">تایید ایمیل</h1>\r\n    <h3 style=\"color: red;\">لطفا حساب خود را تایید کنید</h3>\r\n    <a id=\"btn\" type=\"button\" style=\"text-align: center;text-decoration: none;font-size: 30px;font-weight: bold;padding: 15px;background-color: blue;color: white;border-radius: 15px;\" href=\"{coniformlink}\" >تایید حساب</a>\r\n    </div>";
            await _emailSender.SendEmail(user.Email, "تایید حساب", body);
            
            return Ok(list.RefreshToken);
        }
        [HttpGet("EmailConiform")]
        public async Task<IActionResult> EmailConiform([FromQuery]string Token)
        {
             var lis =  await _userRepository.GetbyUseToken(Token);
            if (lis == null)
            {
                return NotFound();
            }
            else
            {
                lis.ConiformEmail = true;
                await _userRepository.Update(lis);
                var html = "<meta charset=\"UTF-8\">\r\n<div  style=\"background-color: aqua;width: 100%;height: 100px;text-align: center;padding: 14px 0px;\">\r\n    <h1 style=\"color: rgb(42, 63, 146);\">حساب شما با موفقیت تایید شد هم اکنون میتوانید وارد حساب کاربری خود شوید</h1>\r\n</div>";
                return new ContentResult
                {
                    Content = html,
                    ContentType = "text/html"
                    
                };

            }
        }
        [HttpPost("emailsendAll"), Authorize(Roles = "Owner"), Authorize(Roles = "Owner")]
        public async Task<IActionResult> emailsendAll(EmailDTO email)
        {
            var users =await _userRepository.GetAllAsNotraking.ToListAsync();
            users.ForEach(u =>
            {
                _emailSender.SendEmail(u.Email, email.Subject, email.message);
            });
            return Ok("Sended");
            
        }
    }
}
