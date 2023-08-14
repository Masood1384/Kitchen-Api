using Kitchen.Service.DTOs;
using Kitchen.Service.DTOs.FoodDTO;
using Kitchen.Service.DTOs.FoodPictureDTO;
using Kitchen.Service.DTOs.GroupFoodDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kitchen.Service.Catalog.FoodService
{
    public interface IFoodService
    {
        //Food
        Task<IEnumerable<FoodListItemDTO>> GetAllFood();
        Task<IEnumerable<FoodListItemDTO>> GetDeletedFoods();
        Task<IEnumerable<FoodListItemDTO>> GetAvailablesFood();
        Task<FoodListItemDTO> GetFoodById(int id);
        Task<FoodDTO> AddFood(FoodDTO food);
        Task<FoodDTO> UpdateFood(FoodDTO food);
        Task DeleteFood(int id);
        Task AvailableFood(FoodAvailableDTO foodAvailable);
        bool IsExists(int Id);

        //GroupFood
        Task AddGroupFood(GroupFoodDTO groupFood);
        Task DeleteGroupFood(GroupFoodDTO groupFood);
        Task<IList<int>> GetFoodForGroup(int ID);
        //Picture
        Task AddPictureFromFood(PictureFoodDTO FoodPictureDTO);
        Task DeletePictureFromFood(PictureFoodDTO FoodPictureDTO);
        Task<IList<int>> GetPictureForFood(int ID);


    }
}
