using Kitchen.Service.DTOs.CommonsDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kitchen.Service.DTOs.FoodPictureDTO
{
    public class PictureFoodDTO:BaseDTO
    {
        public int PictureID { get; set; }
        public int FoodID { get; set; }
    }
}
