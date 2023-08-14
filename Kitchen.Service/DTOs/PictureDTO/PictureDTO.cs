using Kitchen.Service.DTOs.CommonsDTO;
using Kitchen.Service.MyValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kitchen.Service.DTOs.PictureDTO
{
    public class PictureDTO: BaseEntityDTO
    {
        [ImageValidation(ErrorMessage = "فرمت عکس صحیح نمی باشد.")]
        public string VirtualPath { get; set; }
        public string MimeType { get; set; }
    }
}
