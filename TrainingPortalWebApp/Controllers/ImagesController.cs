using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using TrainingPortal.WebPL.Helpers;
using TrainingPortal.WebPL.Interfaces;

namespace ImageResizeWebApp.Controllers
{
    [Route("api/[controller]")]
    public class ImagesController : Controller
    {
        // make sure that appsettings.json is filled with the necessary details of the azure storage
        private readonly IAzureService azureService;

        public ImagesController(IAzureService azureService)
        {
            this.azureService = azureService;
        }

        // GET Images/Index
        [Authorize(Roles = "admin, editor")]
        public IActionResult Index()
        {
            return View();
        }

        // POST /api/images/upload
        [HttpPost]
        public async Task<IActionResult> Upload(ICollection<IFormFile> files)
        {
            bool isUploaded = false;

            try
            {
                foreach (var formFile in files)
                {
                    if (FileValidator.IsImage(formFile))
                    {
                        if (formFile.Length > 0)
                        {
                            using (Stream stream = formFile.OpenReadStream())
                            {
                                isUploaded = await azureService.UploadFileToStorage(stream, formFile.FileName);
                            }
                        }
                    }
                    else
                    {
                        return new UnsupportedMediaTypeResult();
                    }
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            if (!isUploaded)
            {
                return BadRequest();
            }

            return new AcceptedResult();
        }

        // GET /image/GetImageUrls
        [HttpGet("GetImageUrls")]
        public async Task<IActionResult> GetImageUrls()
        {
            try
            {
                List<string> imagesUrls = await azureService.GetImagesUrls();

                return new ObjectResult(imagesUrls);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}