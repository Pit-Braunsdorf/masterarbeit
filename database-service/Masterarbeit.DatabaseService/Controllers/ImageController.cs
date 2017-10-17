using System.Collections.Generic;
using Masterarbeit.DatabaseService.App;
using Masterarbeit.Shared.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace Masterarbeit.DatabaseService.Controllers
{
    [Produces("application/json")]
    [Route("api/Image")]
    public class ImageController : Controller
    {
        private readonly ImageInteractor _imageInteractor;

        public ImageController(ImageInteractor imageInteractor)
        {
            _imageInteractor = imageInteractor;
        }

        [HttpGet]

        public ActionResult Get([FromQuery] int? id = null)
        {
            if (!id.HasValue)
            {
                var result = _imageInteractor.Get();
                return new JsonResult(result);
            }
            else
            {
                var result = _imageInteractor.Get(id.Value);
                return new JsonResult(result);
            }
        }

        //[HttpGet]
        //public ActionResult Get()
        //{
        //    var result = _imageInteractor.Get();
        //    return new JsonResult(result);
        //}

        [HttpPost]
        public ActionResult Post([FromBody] Image image)
        {
            image = _imageInteractor.Create(image);
            return new CreatedResult("Image:", image);
        }

        //[HttpPost]
        //public ActionResult Post([FromBody] IEnumerable<Image> images)
        //{
        //    _imageInteractor.Create(images);
        //    return new CreatedResult("Image:", images);
        //}

        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] Image image)
        {
            image.Id = id;
            _imageInteractor.Update(image);
            return new AcceptedResult();
        }

        [HttpPut]
        public ActionResult Put([FromBody] Image image)
        {
            _imageInteractor.Update(image);
            return new AcceptedResult();
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            _imageInteractor.Delete(id);
            return new NoContentResult();
        }

        [HttpDelete]
        public ActionResult Delete([FromBody] Image image)
        {
            _imageInteractor.Delete(image);
            return new NoContentResult();
        }

        [HttpDelete]
        public ActionResult Delete([FromBody] IEnumerable<Image> images)
        {
            _imageInteractor.Delete(images);
            return new NoContentResult();
        }
    }
}