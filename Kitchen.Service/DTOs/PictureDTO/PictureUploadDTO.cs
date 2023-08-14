using Kitchen.Service.DTOs.CommonsDTO;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kitchen.Service.DTOs.PictureDTO
{
    public class PictureUploadDTO:BaseDTO
    {
        public IFormFile File { get; set; }
        public string ContentType { get; set; }
        public string FileExtension { get; set; }
    }
}
