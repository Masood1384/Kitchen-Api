using Kitchen.Service.DTOs.CommonsDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kitchen.Service.DTOs.GroupFoodDTO
{
    public class GroupFoodDTO:BaseDTO
    {
        public int GroupID { get; set; }
        public int FoodID { get; set; }
    }
}
