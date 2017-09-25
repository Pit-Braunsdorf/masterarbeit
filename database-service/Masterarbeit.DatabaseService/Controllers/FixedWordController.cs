using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Masterarbeit.DatabaseService.App;
using Masterarbeit.DatabaseService.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace Masterarbeit.DatabaseService.Controllers
{
    [Route("api/[controller]")]
    public class FixedWordController : Controller
    {
        private readonly FixedWordInteractor _fixedWordInteractor;

        public FixedWordController(FixedWordInteractor fixedWordInteractor)
        {
            _fixedWordInteractor = fixedWordInteractor;
        }
        // GET api/fixedword
        [HttpGet]
        public ActionResult Get()
        {
            var result = _fixedWordInteractor.Get();
            return new JsonResult(result);
        }

        // GET api/fixedword/{id}
        [HttpGet("{id}")]
        public ActionResult Get(int id)
        {
            var result = _fixedWordInteractor.Get(id);
            return new JsonResult(result);
        }

        // POST api/fixedword
        [HttpPost]
        public ActionResult Post([FromBody]FixedWord fixedWord)
        {
            _fixedWordInteractor.Create(fixedWord);
            return new CreatedResult("FixedWord:", fixedWord);
        }

        // PUT api/fixedword/{id}
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody]FixedWord fixedWord)
        {
            fixedWord.Id = id;
            _fixedWordInteractor.Update(fixedWord);
            return new AcceptedResult();
        }

        // DELETE api/fixedword/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            _fixedWordInteractor.Delete(id);
            return new NoContentResult();
        }
    }
}
