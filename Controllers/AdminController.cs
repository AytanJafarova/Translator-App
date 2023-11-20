using Microsoft.AspNetCore.Mvc;
using TranslatorApp.BusinessLogicLayer.Abstract;
using TranslatorApp.DTO;
using TranslatorApp.Entities;
using TranslatorApp.Models;

namespace TranslatorApp.Controllers
{
    public class AdminController : Controller
    {
        private readonly IWordService _wordService;
        public AdminController(IWordService wordService)
        {
            _wordService = wordService;
        }
        public IActionResult AdminPage()
        {
            var wordToList = _wordService.Get(); 
            var wordModel = new WordModel
            {
                wordtolist = wordToList,
            };
            return View(wordModel);
        }

        public IActionResult AddWord(WordModel word)
        {
            List<WordToListDTO> wordToLists = _wordService.Get();
            WordToAddDTO wordToAdd = new WordToAddDTO
            {
                Azerbaycanca = word.wordtoadd.Azerbaycanca?.ToLower(),
                Turkce = word.wordtoadd.Turkce?.ToLower(),
                Tatarca = word.wordtoadd.Tatarca?.ToLower(),
                Turkmence = word.wordtoadd.Turkmence?.ToLower(),
                Ozbekce = word.wordtoadd.Ozbekce?.ToLower(),
                Uygurca = word.wordtoadd.Uygurca?.ToLower(),
                Qazaxca = word.wordtoadd.Qazaxca?.ToLower(),
                Qirgizca = word.wordtoadd.Qirgizca?.ToLower()
            };

            int countInvalid = 0;
            bool existence = false;
            foreach (var item in wordToLists)
            {
                if (wordToAdd.Azerbaycanca != null)
                {
                    if (item.Azerbaycanca.ToLower() == wordToAdd.Azerbaycanca.ToLower())
                    {
                        existence = true;
                    }
                }
            }
            foreach (var language in wordToAdd.GetType().GetProperties())
            {
                var value = language.GetValue(wordToAdd) as string;
                if (string.IsNullOrWhiteSpace(value))
                {
                    countInvalid++;
                }
            }
            if (!existence)
            {
                if (countInvalid < 7)
                {
                    _wordService.Add(wordToAdd);
                }
            }
            return RedirectToAction("AdminPage");

        }
        public IActionResult UpdateWord(WordModel word)
        {
            int wordID = _wordService.GetintByAze(word.WordAzeSelected);
            WordToUpdateDTO wordToUpdate = new WordToUpdateDTO
            {
                Azerbaycanca = word.WordAzeSelected,
                Turkce = word.wordtoupdate.Turkce?.ToLower(),
                Tatarca = word.wordtoupdate.Tatarca?.ToLower(),
                Turkmence = word.wordtoupdate.Turkmence?.ToLower(),
                Ozbekce = word.wordtoupdate.Ozbekce?.ToLower(),
                Uygurca = word.wordtoupdate.Uygurca?.ToLower(),
                Qazaxca = word.wordtoupdate.Qazaxca?.ToLower(),
                Qirgizca = word.wordtoupdate.Qirgizca?.ToLower()
            };
            _wordService.Update(wordID, wordToUpdate);
            return RedirectToAction("AdminPage");
        }
        public IActionResult DeleteWord(WordModel word)
        {
            int wordId = _wordService.GetintByAze(word.WordAzeSelected);
            if (word != null)
            {
                _wordService.Delete(wordId);
            }
                 return RedirectToAction("AdminPage");            
        }
    }
}
