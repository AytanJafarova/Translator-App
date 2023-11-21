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
                Azerbaycan = word.wordtoadd.Azerbaycan?.ToLower(),
                Turk = word.wordtoadd.Turk?.ToLower(),
                Ozbek = word.wordtoadd.Ozbek?.ToLower(),
                Qazax = word.wordtoadd.Qazax?.ToLower(),
                Latin = word.wordtoadd.Latin?.ToLower(),
                Rus = word.wordtoadd.Rus?.ToLower(),

            };

            int countInvalid = 0;
            bool existence = false;
            foreach (var item in wordToLists)
            {
                if (wordToAdd.Azerbaycan != null)
                {
                    if (item.Azerbaycan.ToLower() == wordToAdd.Azerbaycan.ToLower())
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
                Azerbaycan = word.WordAzeSelected,
                Turk = word.wordtoupdate.Turk?.ToLower(),
                Ozbek = word.wordtoupdate.Ozbek?.ToLower(),
                Qazax = word.wordtoupdate.Qazax?.ToLower(),
                Latin = word.wordtoupdate.Latin?.ToLower(),
                Rus = word.wordtoupdate.Rus?.ToLower(),
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
