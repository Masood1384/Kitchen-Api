
using Kitchen.Framework;
using Kitchen.Service.Catalog.FoodService;
using Kitchen.Service.Catalog.GroupService;
using Kitchen.Service.Catalog.PictureService;
using Kitchen.Service.DTOs.FoodDTO;
using Kitchen.Service.DTOs.FoodPictureDTO;
using Kitchen.Service.DTOs.GroupFoodDTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration.UserSecrets;
using shop.Service.Extension;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace Kitchen.Web.Controllers
{
    public class FoodController:KitchenController
    {
        #region Field 
        private readonly IFoodService _foodService;
        private readonly IGroupService _groupService;
        private readonly IPictureService _pictureService;
        
        public FoodController(IFoodService foodService,IGroupService groupService,IPictureService pictureService)
        {
            _foodService = foodService;
            _groupService = groupService;
            _pictureService = pictureService;
        }
        #endregion

        #region Food
       
        [HttpGet]
        public async Task<IActionResult> GetallFood()
        {
            var lis = await _foodService.GetAllFood();
            if (lis.Count() == 0)
            {
                return NotFound();
            }
            else
            {
                return Ok(lis);
            }

        }
        [HttpGet("GetDeletedFood"), Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetDeletedFood()
        {
                return Ok(await _foodService.GetDeletedFoods());

        }
        [HttpGet("GetAvailable")]
        public async Task<IActionResult> GetAvailable()
        {
                return Ok(await _foodService.GetAvailablesFood());
        }
        [HttpGet("find/{Id}")]
        public async Task<IActionResult> Getbyid(int Id)
        {
                return Ok(await _foodService.GetFoodById(Id));
        }
        [HttpPost , Authorize(Roles = "Admin")]
        public async Task<IActionResult> AddFood(FoodDTO foodDTO)
        {
            if (foodDTO.ID != 0)
            {
                return BadRequest();
            }
            else
            {
                await _foodService.AddFood(foodDTO);
                return CreatedAtAction("Getbyid", new {Id = foodDTO.ID},foodDTO);
            }
        }
        [HttpPut , Authorize(Roles = "Admin")]
        public async Task<IActionResult> UpdateFood(FoodDTO foodDTO)
        {
            if(!_foodService.IsExists(foodDTO.ID))
            {
                return NotFound();
            }
            else
            {
                await _foodService.UpdateFood(foodDTO);
                return Ok(foodDTO);
            }
        }
        [HttpDelete , Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteFood(int Id)
        {
            if (!_foodService.IsExists(Id))
            {
                return NotFound();
            }

            await _foodService.DeleteFood(Id);

            return Ok("Product Removed");
        }
        [HttpPut("Available"), Authorize(Roles = "Admin")] 
        public async Task<IActionResult> Available (FoodAvailableDTO foodAvailableDTO)
        {
            if (!_foodService.IsExists(foodAvailableDTO.ID))
            {
                return NotFound();
            }
            else
            {
                await _foodService.AvailableFood(foodAvailableDTO);
                return NoContent();
            }
        }
        #endregion
        #region GroupFood
        [HttpPost("AddGroupFood") , Authorize]
        public async Task<IActionResult> AddGroupFood(GroupFoodDTO groupFoodDTO)
        {
            if(!_groupService.IsExists(groupFoodDTO.GroupID))
            {
                return NotFound("دسته مورد نظر یافت نشد");
            }
            if (!_foodService.IsExists(groupFoodDTO.FoodID))
            {
                return NotFound("غذای مورد نظر یافت نشد");
            }
            await _foodService.AddGroupFood(groupFoodDTO);
            return Ok();
        }
        [HttpDelete("DeleteGroupFood"), Authorize]
        public async Task<IActionResult> DeleteGroupFood(GroupFoodDTO groupFoodDTO)
        {
            if (!_groupService.IsExists(groupFoodDTO.GroupID))
            {
                return NotFound("دسته مورد نظر یافت نشد");
            }
            if (!_foodService.IsExists(groupFoodDTO.FoodID))
            {
                return NotFound("غذای مورد نظر یافت نشد");
            }
            await _foodService.DeleteGroupFood(groupFoodDTO);
            return Ok();
        }
        [HttpGet("GetFoodForGroup/{Id}") , Authorize]
        public async Task<IActionResult> GetFoodForGroup(int Id)
        {
            return Ok(await _foodService.GetFoodForGroup(Id));
        }
        #endregion
        #region FoodPicture
        [HttpPost("AddFoodPicture"), Authorize(Roles = "Admin")]
        public async Task<IActionResult> AddFoodPicture(PictureFoodDTO pictureFood)
        {
            if(!_foodService.IsExists(pictureFood.PictureID))
            {
                return NotFound();
            }
            if(! await _pictureService.CheckExists(pictureFood.PictureID))
            {
                return NotFound();
            }
            await _foodService.AddPictureFromFood(pictureFood);
            return Ok();
        }
        [HttpDelete("DeleteFoodPicture") , Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteFoodPicture(PictureFoodDTO pictureFood)
        {
            if (!_foodService.IsExists(pictureFood.PictureID))
            {
                return NotFound();
            }
            if (!await _pictureService.CheckExists(pictureFood.PictureID))
            {
                return NotFound();
            }
            await _foodService.DeletePictureFromFood(pictureFood);
            return Ok();
        }
        [HttpGet("GetPictureForFood/{Id}")]
        public async Task<IActionResult> GetPictureForFood(int Id)
        {
            return Ok(await _foodService.GetPictureForFood(Id));
        }

        #endregion
    }
}
