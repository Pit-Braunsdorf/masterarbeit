using System.Collections.Generic;
using Masterarbeit.DatabaseService.App;
using Masterarbeit.Shared.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace Masterarbeit.DatabaseService.Controllers
{
    [Produces("application/json")]
    [Route("api/categroy")]
    public class CategoryController : Controller
    {
        private readonly CategoryInteractor _categoryInteractor;

        public CategoryController(CategoryInteractor categoryInteractor)
        {
            _categoryInteractor = categoryInteractor;
        }

        [HttpGet("{id}")]
        public ActionResult Get(int id)
        {
            var result = _categoryInteractor.Get(id);
            return new JsonResult(result);
        }

        [HttpGet]
        public ActionResult Get()
        {
            var result = _categoryInteractor.Get();
            return new JsonResult(result);
        }

        [HttpPost]
        public ActionResult Post([FromBody] Category category)
        {
            _categoryInteractor.Create(category);
            return new CreatedResult("Category:", category);
        }

        [HttpPost]
        public ActionResult Post([FromBody] IEnumerable<Category> category)
        {
            _categoryInteractor.Create(category);
            return new CreatedResult("Category:", category);
        }

        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] Category category)
        {
            category.Id = id;
            _categoryInteractor.Update(category);
            return new AcceptedResult();
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            _categoryInteractor.Delete(id);
            return new NoContentResult();
        }

        [HttpDelete]
        public ActionResult Delete([FromBody] Category category)
        {
            _categoryInteractor.Delete(category);
            return new NoContentResult();
        }

        [HttpDelete]
        public ActionResult Delete([FromBody] IEnumerable<Category> categorys)
        {
            _categoryInteractor.Delete(categorys);
            return new NoContentResult();
        }
    }
}