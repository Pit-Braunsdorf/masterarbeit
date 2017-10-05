using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Masterarbeit.Frontend.App;
using Masterarbeit.Frontend.Helper;
using Masterarbeit.Shared.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace Masterarbeit.Frontend.Controllers
{
    public class FixedWordController : Controller
    {
        private readonly FixedWordInteractor _fixedWordInteractor;
        
        public FixedWordController(FixedWordInteractor fixedWordInteractor)
        {
            _fixedWordInteractor = fixedWordInteractor;
        }

        public IActionResult Index()
        {
            var fixedWords = _fixedWordInteractor.GetFixedWords();
            var result = MappingHelper.Map(fixedWords);

            return View(result);
        }

        [HttpGet]
        public ActionResult GetFixedWords(int? id = null)
        {
            var result = _fixedWordInteractor.GetFixedWords();
            return new JsonResult(result);
        }
        
        public ActionResult Create(FixedWord fixedWord)
        {
            var result = _fixedWordInteractor.CreateFixedWord(fixedWord);
            return new JsonResult(result);
        }

        public void Delete(int id)
        {
            _fixedWordInteractor.DeleteFixedWord(id);
        }

        public ActionResult Update(FixedWord fixedWord)
        {
            var result = _fixedWordInteractor.UpdateFixedWord(fixedWord);
            return new JsonResult(result);
        }
    }
}