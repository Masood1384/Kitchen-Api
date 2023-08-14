using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Kitchen.Core.Domain.Food;
using Kitchen.Data.Repository;
using Kitchen.Service.DTOs.PictureDTO;
using shop.Service.Extension;

namespace Kitchen.Service.Catalog.PictureService
{
    public class PictureService : IPictureService
    {
        #region Filed
        private readonly IRepository<Picture> _pictureRepository;

        public PictureService(IRepository<Picture> PictureRepository)
        {
            _pictureRepository = PictureRepository;
        }

        #endregion

        public async Task<bool> CheckExists(int ID)
        {
            return await _pictureRepository.GetbyId(ID) != null;
        }

        public async Task<PictureDTO> RegisterPictureAsync(PictureUploadDTO image)
        {
            Picture picture = new Picture();
            picture.CreateON = DateTime.Now;
            picture.UpdateON = DateTime.Now;
            picture.MimeType = image.File.ContentType;
            picture.VirtualPath = "test";
            await _pictureRepository.Add(picture);

            var fileName = $"{picture.ID:0000000}_0{image.FileExtension}";


            //Photo Convert to Array Byte
            byte[] pictureBinary = null;
            using (var fileStream = image.File.OpenReadStream())
            {
                using (var ms = new MemoryStream())
                {
                    fileStream.CopyTo(ms);
                    pictureBinary = ms.ToArray();
                }
            }


            var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "FoodImage", fileName);

            await File.WriteAllBytesAsync(filePath, pictureBinary);


            picture.VirtualPath = filePath;

            await _pictureRepository.Update(picture);

            PictureDTO pictureDTO = picture.ToDTO<PictureDTO>();

            return pictureDTO;
        }

        public async Task<PictureDTO> SearchPictureByIdAsync(int id)
        {
            var picture = await _pictureRepository.GetbyId(id);
            PictureDTO pictureDTO = picture.ToDTO<PictureDTO>();

            return pictureDTO;
        }

        public async Task RemovePictureAsync(int Id)
        {
            var pic = await _pictureRepository.GetbyId(Id);
            await _pictureRepository.Delete(pic);
        }
    }
}
