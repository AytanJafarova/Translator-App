using TranslatorApp.DataAccessLayer.Abstract;
using TranslatorApp.DataAccessLayer.TranslatorDbContext;
using TranslatorApp.Entities;
using Microsoft.EntityFrameworkCore;

namespace TranslatorApp.DataAccessLayer.Concrete
{
    public class WordRepository : IWordRepository
    {
        private readonly TranslateDbContext _translateDbContext;
        public WordRepository(TranslateDbContext translateDbContext)
        {
            _translateDbContext = translateDbContext;
        }
        public void Add(Word word)
        {
            _translateDbContext.Add(word);
            _translateDbContext.SaveChanges();
        }

        public void Delete(int id)
        {
            var word = _translateDbContext.Words.Find(id);
            if(word != null)
            {
                _translateDbContext.Words.Remove(word);
            }
            _translateDbContext.SaveChanges();
        }

        public List<Word> Get()
        {
            return _translateDbContext.Words.ToList();
        }

        public Word Get(int id)
        {
            return _translateDbContext.Words.Where(w=>w.WordId == id).FirstOrDefault();
        }

        public int GetintByAze(string word)
        {
            return _translateDbContext.Words
               .AsNoTracking() 
               .Where(w => w.Azerbaycan == word)
               .Select(w => w.WordId)
               .FirstOrDefault();
        }
        public string GetTranslationResult(string fromL, string toL, string word)
        {
            Word queryFrom = null;
            string translation = "";
            switch (fromL)
            {
                case "Azərbaycan":
                    queryFrom = _translateDbContext.Words.AsNoTracking().Where(w => w.Azerbaycan == word).FirstOrDefault();
                    break;
                case "Türk":
                    queryFrom = _translateDbContext.Words.AsNoTracking().Where(w => w.Turk == word).FirstOrDefault();
                    break;
                case "Özbək":
                    queryFrom = _translateDbContext.Words.AsNoTracking().Where(w => w.Ozbek == word).FirstOrDefault();
                    break;
                case "Qazax":
                    queryFrom = _translateDbContext.Words.AsNoTracking().Where(w => w.Qazax == word).FirstOrDefault();
                    break;
                case "Latın":
                    queryFrom = _translateDbContext.Words.AsNoTracking().Where(w => w.Latin == word).FirstOrDefault();
                    break;
                case "Rus":
                    queryFrom = _translateDbContext.Words.AsNoTracking().Where(w => w.Rus == word).FirstOrDefault();
                    break;
                case "emp":
                    return "Dili seçin!";
                default:
                    break;
            }
            if (queryFrom == null)
            {
                return "Məlumat yoxdur!";
            }

            switch (toL)
            {
                case "Azərbaycan":
                    translation = queryFrom.Azerbaycan;
                    break;
                case "Türk":
                    translation = queryFrom.Turk;
                    break;
                case "Özbək":
                    translation = queryFrom.Ozbek;
                    break;
                case "Qazax":
                    translation = queryFrom.Qazax;
                    break;
                case "Latın":
                    translation = queryFrom.Latin;
                    break;
                case "Rus":
                    translation = queryFrom.Rus;
                    break;
                case "emp":
                    return "Dili seçin!";
                default:
                    return "Məlumat yoxdur!";

            }
            return translation;
          }
        public void Update(Word word)
        {
            _translateDbContext.Words.Update(word);
            _translateDbContext.SaveChanges();
        }
    }
}