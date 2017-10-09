using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Masterarbeit.MAML.DatabaseService.App;
using Masterarbeit.Shared.Contracts;

namespace Masterarbeit.MAML.DatabaseService.Controllers
{
    [Route("api/[controller]")]
    public class FixedWordController : Controller
    {
        private readonly FixedWordInteractor _fixedWordInteractor;

        public FixedWordController(FixedWordInteractor fixedWordInteractor)
        {
            _fixedWordInteractor = fixedWordInteractor;
        }

        /// <summary>
        /// GET api/fixedword
        /// </summary>
        /// <returns>Statuscode 200 on success</returns>
        [HttpGet]
        public IEnumerable<FixedWord> Get()
        {
            return _fixedWordInteractor.GetFixedWords();
        }

        /// <summary>
        /// GET api/fixedword?id={id}
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Statuscode 200 on success</returns>
        [HttpGet]
        public FixedWord Get(int id)
        {
            return _fixedWordInteractor.GetFixedWord(id);
        }

        /// <summary>
        /// POST api/fixedWord
        /// </summary>
        /// <param name="fixedWord"></param>
        /// <returns>Statuscode 201 on success</returns>
        [HttpPost]
        public ActionResult Post(FixedWord fixedWord)
        {
            var result = _fixedWordInteractor.CreateFixedWord(fixedWord);
            return new CreatedResult("", result);
        }

        /// <summary>
        /// POST api/fixedWord
        /// </summary>
        /// <param name="fixedWords"></param>
        /// <returns>Statuscode 201 on success</returns>
        [HttpPost]
        public ActionResult Post(IEnumerable<FixedWord> fixedWords)
        {
            var result = _fixedWordInteractor.CreateFixedWords(fixedWords);
            return new CreatedResult("", result);
        }

        /// <summary>
        /// PUT api/fixedWord
        /// </summary>
        /// <param name="fixedWord"></param>
        /// <returns>Statuscode 202 on success</returns>
        [HttpPut]
        public ActionResult Put(FixedWord fixedWord)
        {
            var result = _fixedWordInteractor.UpdateFixedWord(fixedWord);
            return new AcceptedResult("", result);
        }

        /// <summary>
        /// PUT api/fixedWord
        /// </summary>
        /// <param name="fixedWords"></param>
        /// <returns>Statuscode 202 on success</returns>
        [HttpPut]
        public ActionResult Put(IEnumerable<FixedWord> fixedWords)
        {
            var result = _fixedWordInteractor.UpdateFixedWords(fixedWords);
            return new AcceptedResult("", result);
        }

        /// <summary>
        /// DELETE api/fixedWord?id={id}
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Statuscode: 204 on success</returns>
        [HttpDelete]
        public ActionResult Delete(int id)
        {
            _fixedWordInteractor.DeleteFixedWord(id);
            return new NoContentResult();
        }

        /// <summary>
        /// DELETE api/fixedWord?ids={ids}
        /// </summary>
        /// <param name="ids"></param>
        /// <returns>Statuscode: 204 on success</returns>
        [HttpDelete]
        public ActionResult Delete(IEnumerable<int> ids)
        {
            _fixedWordInteractor.DeleteFixedWords(ids);
            return new NoContentResult();
        }

        /// <summary>
        /// DELETE api/fixedWord
        /// </summary>
        /// <param name="fixedWord"></param>
        /// <returns>Statuscode: 204 on success</returns>
        [HttpDelete]
        public ActionResult Delete(FixedWord fixedWord)
        {
            _fixedWordInteractor.DeleteFixedWord(fixedWord);
            return new NoContentResult();
        }

        /// <summary>
        /// DELETE api/fixedWord?ids={ids}
        /// </summary>
        /// <param name="fixedWords"></param>
        /// <returns>Statuscode: 204 on success</returns>
        [HttpDelete]
        public ActionResult Delete(IEnumerable<FixedWord> fixedWords)
        {
            _fixedWordInteractor.DeleteFixedWords(fixedWords);
            return new NoContentResult();
        }
    }
}
