using System.Collections.Generic;
using Masterarbeit.DatabaseService.App;
using Masterarbeit.Shared.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace Masterarbeit.DatabaseService.Controllers
{
    [Produces("application/json")]
    [Route("api/Word")]
    public class WordController : Controller
    {
        private readonly WordInteractor _wordInteractor;

        public WordController(WordInteractor wordInteractor)
        {
            _wordInteractor = wordInteractor;
        }

        [HttpGet("{id}")]
        public ActionResult Get(int id)
        {
            var result = _wordInteractor.Get(id);
            return new JsonResult(result);
        }

        [HttpGet]
        public ActionResult Get()
        {
            var result = _wordInteractor.Get();
            return new JsonResult(result);
        }

        [HttpPost]
        public ActionResult Post([FromBody] Word word)
        {
            _wordInteractor.Create(word);
            return new CreatedResult("Word:", word);
        }

        [HttpPost]
        public ActionResult Post([FromBody] IEnumerable<Word> word)
        {
            _wordInteractor.Create(word);
            return new CreatedResult("Word:", word);
        }

        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] Word word)
        {
            word.Id = id;
            _wordInteractor.Update(word);
            return new AcceptedResult();
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            _wordInteractor.Delete(id);
            return new NoContentResult();
        }

        [HttpDelete]
        public ActionResult Delete([FromBody] Word word)
        {
            _wordInteractor.Delete(word);
            return new NoContentResult();
        }

        [HttpDelete]
        public ActionResult Delete([FromBody] IEnumerable<Word> words)
        {
            _wordInteractor.Delete(words);
            return new NoContentResult();
        }
    }
}