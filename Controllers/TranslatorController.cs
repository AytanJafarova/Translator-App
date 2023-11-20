using Microsoft.AspNetCore.Mvc;
using TranslatorApp.BusinessLogicLayer.Abstract;
using TranslatorApp.Models;

namespace TranslatorApp.Controllers
{ 
    public class TranslatorController : Controller
    {
        private readonly IWordService _wordService;
        public TranslatorController(IWordService wordService)
        {
            _wordService = wordService;
        }
        public IActionResult Translating()
        {
            return View();
        }
        public JsonResult TranslateWord(WordModel wordModel)
        {
            wordModel.wordResult = _wordService.GetTranslationResult(wordModel.fromL, wordModel.toL, wordModel.wordTranslate);
            if (wordModel.wordResult == "Məlumat yoxdur!" || wordModel.wordResult == "Dili seçin!")
            {
                wordModel.translated = false;
                return new JsonResult(Ok(wordModel));
            }
            wordModel.translated = true;
            return new JsonResult(Ok(wordModel));
        }
       }
    }
