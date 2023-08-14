using Kitchen.Service.DTOs.PictureDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kitchen.Service.Catalog.PictureService
{
    public interface IPictureService
    {
        Task<bool> CheckExists(int ID);
        Task<PictureDTO> RegisterPictureAsync(PictureUploadDTO image);
        Task<PictureDTO> SearchPictureByIdAsync(int id);
        Task RemovePictureAsync(int Id);
    }
}
