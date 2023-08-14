using Kitchen.Service.DTOs.CommonsDTO;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kitchen.Service.DTOs.FoodDTO
{
    public class FoodDTO: BaseEntityDTO
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int Price { get; set; }
        public bool Deleted { get; set; }
        public bool Available { get; set; }
    }
}
