
using Kitchen.Core.Domain.User;
using Kitchen.Core.Extension;
using Kitchen.Data.Repository;
using Kitchen.Service.DTOs.UserDTO;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using shop.Service.Extension;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Kitchen.Service.Catalog.UserService
{
    public class UserService : IUserService
    {
        #region Feild
        private readonly IRepository<User> _userrepository;
        private readonly IConfiguration _configuration;
        public UserService(IRepository<User> userrepository, IConfiguration configuration)
        {
            _userrepository = userrepository;
            _configuration = configuration;
        }
        #endregion

        public async Task Delete(int id)
        {
            var lis = await _userrepository.GetbyId(id);
            await _userrepository.Delete(lis);
            
        }

        public async Task<UserListItmeDTO> GetById(int Id)
        {
            var user =_userrepository.GetbyIdAznotraking(Id);
            var dto = user.ToDTO<UserListItmeDTO>();
            return dto;
        }

        public async Task<IEnumerable<UserListItmeDTO>> GettAll()
        {
            var lis =await _userrepository.GetAllAsNotraking.Select(p=>new UserListItmeDTO
            {
                ID = p.ID,
                Name = p.Name,
                Family = p.Family,
                Email = p.Email,
                UserName = p.Name,
                ConiformEmail = p.ConiformEmail,
                CreateON = p.CreateON,
                UpdateON = p.UpdateON,
                LocalCreate = p.CreateON.ToPersian(),
                LocalUpdate = p.UpdateON.ToPersian(),
            }).ToListAsync();
            return lis;
        }
        public bool IsExist(int Id)
        {
            var prod = _userrepository.GetbyIdAznotraking(Id);
            if (prod == null) return false;
            return true;
        }

        public async Task<string> Login(User user)
        {
            List<Claim> claims = new List<Claim> {
                new Claim(ClaimTypes.Name, user.UserName.ToLower()),
                new Claim(ClaimTypes.Role, user.Role),
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(
                _configuration.GetSection("AppSettings:Token").Value!));

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);
            var token = new JwtSecurityToken(
                    claims: claims,
                    expires: DateTime.Now.AddDays(1),
                    signingCredentials: creds
                );

            var jwt = new JwtSecurityTokenHandler().WriteToken(token);

            return jwt;
        }

        public async Task<UserRigesterDTO> RigesterUser(UserRigesterDTO userrigester)
        {
            string passwordhash = BCrypt.Net.BCrypt.HashPassword(userrigester.Password);
            User user = new User();
            user.Name = userrigester.Name;
            user.Family = userrigester.Family;
            user.Email = userrigester.Email;
            user.ConiformEmail = false;
            user.UserName = userrigester.UserName.ToLower().Trim();
            user.Password = passwordhash;
            user.CreateON = DateTime.Now;
            user.UpdateON = DateTime.Now;
            user.RefreshToken = "Defualt";
            user.Expires = DateTime.Now;
            user.Created = DateTime.Now;
            user.Role = "User";
            await _userrepository.Add(user);
            userrigester.ID = user.ID;
            return userrigester;


        }

        public async Task<IEnumerable<UserLoginDTO>> searchbuUsername(UserLoginDTO userLogin)
        {
            var user =await _userrepository.GetAllAsNotraking.Where(p => p.UserName == userLogin.UserName.ToLower()).Select(p=> new UserLoginDTO
            {
                 UserName = p.UserName,
                 Password = p.Password
                 
            }).ToListAsync();
            return user;
        }

        public async Task<UserUpdateDTO> UpdateUser(UserUpdateDTO userrigester)
        {
            var user = await _userrepository.GetbyId(userrigester.ID);
            user.Name = userrigester.Name;
            user.Family = userrigester.Family;
            user.Email = userrigester.Email;
            user.UserName = userrigester.UserName;
            user.Password = userrigester.Password;
            user.UpdateON = DateTime.Now;
            await _userrepository.Update(user);
            return userrigester;
        }

        public async Task UpdateUserRole(UpdateUserRoleDTO userRole)
        {
            var user =await _userrepository.GetbyId(userRole.ID);
            user.Role = userRole.Role;
            await _userrepository.Update(user);

        }
    }
}
