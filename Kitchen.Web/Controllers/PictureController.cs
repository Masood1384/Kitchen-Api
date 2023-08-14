using Kitchen.Framework;
using Kitchen.Service.Catalog.PictureService;
using Kitchen.Service.DTOs.PictureDTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Kitchen.Web.Controllers
{
    public class PictureController:KitchenController
    {
        #region Field
        private readonly IPictureService _pictureService;

        public PictureController(IPictureService PictureService)
        {
            _pictureService = PictureService;
        }

        #endregion
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int? id)
        {
            if (!await _pictureService.CheckExists(id.Value))
            {
                return NotFound();
            }
            var image = await _pictureService.SearchPictureByIdAsync(id.Value);

            return PhysicalFile(image.VirtualPath, image.MimeType);
        }
        [HttpPost, Authorize(Roles = "Admin")]
        public async Task<IActionResult> UploadPicture([FromForm] PictureUploadDTO image)
        {
            // Upload Photo & Register
            image.ContentType = image.File.ContentType;
            image.FileExtension = Path.GetExtension(image.File.FileName);

            var pictureDTO = await _pictureService.RegisterPictureAsync(image);

            return CreatedAtAction("Get", new { id = pictureDTO.ID }, pictureDTO);
        }
        [HttpDelete]
        public async Task<IActionResult> DeletePicture(int Id)
        {
            if(! await _pictureService.CheckExists(Id))
            {
                return NotFound();
            }
            await _pictureService.RemovePictureAsync(Id);
            return Ok("Remocve Succsed");
        }
    }
}
