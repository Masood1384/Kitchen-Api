using Kitchen.Core.Domain.Food;
using Kitchen.Core.Extension;
using Kitchen.Data.Repository;
using Kitchen.Service.DTOs;
using Kitchen.Service.DTOs.FoodDTO;
using Kitchen.Service.DTOs.FoodPictureDTO;
using Kitchen.Service.DTOs.GroupFoodDTO;
using Microsoft.EntityFrameworkCore;
using shop.Service.Extension;
using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kitchen.Service.Catalog.FoodService
{
    public class FoodService : IFoodService
    {
        #region Field
        private readonly IRepository<Food> _foodrepository;
        private readonly IRepository<GroupFood> _groupfoodrepository;
        private readonly IRepository<FoodPicture> _foodpicturerepository;
        public FoodService(IRepository<Food> Foodrepository, IRepository<GroupFood> groupfoodrepository, IRepository<FoodPicture> foodpicturerepository)
        {
            _foodrepository = Foodrepository;
            _groupfoodrepository = groupfoodrepository;
            _foodpicturerepository = foodpicturerepository;
        }
        #endregion
        #region Food
        public async Task<IEnumerable<FoodListItemDTO>> GetAllFood()
        {
            var list =await _foodrepository.GetAllAsNotraking.Where(p=>p.Deleted == false).Select(p => new FoodListItemDTO
            {
                ID = p.ID,
                Name = p.Name,
                Price = p.Price,
                Description = p.Description,
                Available = p.Available,
                CreateON = p.CreateON,
                UpdateON = p.UpdateON,
                LocalCreate = p.CreateON.ToPersian(),
                LocalUpdate = p.UpdateON.ToPersian(),
                
            }).ToListAsync();
            return list;
        }
        public async Task<IEnumerable<FoodListItemDTO>> GetDeletedFoods()
        {
            var list = await _foodrepository.GetAllAsNotraking.Where(p => p.Deleted == true).Select(p => new FoodListItemDTO
            {
                ID = p.ID,
                Name = p.Name,
                Price = p.Price,
                Description = p.Description,
                Available = p.Available,
                CreateON = p.CreateON,
                UpdateON = p.UpdateON,
                LocalCreate = p.CreateON.ToPersian(),
                LocalUpdate = p.UpdateON.ToPersian(),

            }).ToListAsync();
            return list;
        }
        public async Task<IEnumerable<FoodListItemDTO>> GetAvailablesFood()
        {
            var list = await _foodrepository.GetAllAsNotraking.Where(p=> p.Deleted == false).Where(p => p.Available == true).Select(p => new FoodListItemDTO
            {
                ID = p.ID,
                Name = p.Name,
                Price = p.Price,
                Description = p.Description,
                Available = p.Available,
                CreateON = p.CreateON,
                UpdateON = p.UpdateON,
                LocalCreate = p.CreateON.ToPersian(),
                LocalUpdate = p.UpdateON.ToPersian(),

            }).ToListAsync();
            return list;
        }
        public async Task AvailableFood(FoodAvailableDTO foodAvailable)
        {
            var food =await _foodrepository.GetbyId(foodAvailable.ID);
            food.Available = foodAvailable.Available;
            await _foodrepository.Update(food);
        }
        public async Task<FoodDTO> AddFood(FoodDTO food)
        {
            var foodd = food.ToEntity<Food>();
            foodd.CreateON = DateTime.Now;
            foodd.UpdateON = DateTime.Now;
            await _foodrepository.Add(foodd);
            foodd.ID = food.ID;
            return food;
        }
        public async Task DeleteFood(int id)
        {
            var lis = await _foodrepository.GetbyId(id);
            lis.Deleted = true;
            await _foodrepository.Update(lis);
        }
        public async Task<FoodListItemDTO> GetFoodById(int id)
        {
            var lis = _foodrepository.GetbyIdAznotraking(id);
            if(!lis.Deleted == true)
            {
                var dt = lis.ToDTO<FoodListItemDTO>();
                return dt;
            }
            else
            {
                var li = new FoodListItemDTO();
                return li;
            }
        }
        public async Task<FoodDTO> UpdateFood(FoodDTO food)
        {
            var foodd =await _foodrepository.GetbyId(food.ID);
            foodd.Name = food.Name;
            foodd.Description = food.Description;
            foodd.Price = food.Price;
            foodd.Available = food.Available;
            foodd.UpdateON = DateTime.Now;
            await _foodrepository.Update(foodd);
            return food;
            
        }
        public bool IsExists(int Id)
        {
            var prod = _foodrepository.GetbyIdAznotraking(Id);
            if (prod == null) return false;
            return true;
        }
        #endregion
        #region GroupFood
        public async Task AddGroupFood(GroupFoodDTO groupFood)
        {
            var productCategory = groupFood.ToEntity<GroupFood>();
            await _groupfoodrepository.Add(productCategory);
        }

        public async Task DeleteGroupFood(GroupFoodDTO groupFood)
        {
            var productCategory = groupFood.ToEntity<GroupFood>();
            await _groupfoodrepository.Delete(productCategory);
        }
        public async Task<IList<int>> GetFoodForGroup(int ID)
        {
            return await _groupfoodrepository.GetAllAsNotraking.Where(p => p.GroupID== ID).Select(p => p.FoodID)
                .ToListAsync();
        }
        #endregion
        #region PictureFood
        public async Task AddPictureFromFood(PictureFoodDTO FoodPictureDTO)
        {
            var FoodPicture = FoodPictureDTO.ToEntity<FoodPicture>();
            await _foodpicturerepository.Add(FoodPicture);

        }
        public async Task DeletePictureFromFood(PictureFoodDTO FoodPictureDTO)
        {
            var FoodPicture = FoodPictureDTO.ToEntity<FoodPicture>();
            await _foodpicturerepository.Delete(FoodPicture);

        }
        public async Task<IList<int>> GetPictureForFood(int ID)
        {
            return await _foodpicturerepository.GetAllAsNotraking.Where(p => p.FoodID == ID).Select(p => p.PictureID)
                .ToListAsync();
        }
        #endregion
    }
}
