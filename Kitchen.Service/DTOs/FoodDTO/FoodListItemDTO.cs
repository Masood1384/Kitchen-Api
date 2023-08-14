using Kitchen.Core.Domain.Food;
using Kitchen.Service.DTOs.CommonsDTO;

namespace Kitchen.Service.DTOs
{
    public class FoodListItemDTO:BaseItemDTO
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int Price { get; set; }
        public bool Deleted { get; set; }
        public bool Available { get; set; }

    }
}