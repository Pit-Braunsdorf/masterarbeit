using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Masterarbeit.Frontend.App;
using Masterarbeit.Frontend.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Masterarbeit.Frontend.Controllers
{
    public class UploadImageController : Controller
    {
        private readonly ImageInteractor _imageInteractor;

        public UploadImageController(ImageInteractor imageInteractor)
        {
            _imageInteractor = imageInteractor;
        }

        // GET: /<controller>/
        public IActionResult Index()
        {
            return View();
        }
        
        [HttpPost]
        public async void UploadFiles(List<IFormFile> files)
        {
            var result = new List<UploadViewModel>();
            // full path to file in temp location

            foreach (var formFile in files)
            {
                var filePath = Path.GetTempFileName();
                if (formFile.Length > 0)
                {
                    using (var stream = new MemoryStream())
                    {
                        try
                        {
                            
                            formFile.CopyTo(stream);
                        }
                        catch (Exception e)
                        {
                            throw e;
                        }
                        var image = _imageInteractor.CreateImage(stream.ToArray());
                        var ocrResult = _imageInteractor.SendToOcr(stream.ToArray());
                        _imageInteractor.SaveOCRResult(image, ocrResult);
                    }
                }

                result.Add( new UploadViewModel
                {
                    FilePath = filePath
                });
            }

            // process uploaded files
            // Don't rely on or trust the FileName property without validation.
        }
    }
}
