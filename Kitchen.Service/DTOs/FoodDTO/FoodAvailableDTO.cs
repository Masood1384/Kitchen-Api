using Kitchen.Service.DTOs.CommonsDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kitchen.Service.DTOs.FoodDTO
{
    public class FoodAvailableDTO:BaseEntityDTO
    {
        public bool Available { get; set; }
    }
}
