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
            _translateDbContext.Words.Remove(word);
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
               .Where(w => w.Azerbaycanca == word)
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
                    queryFrom = _translateDbContext.Words.AsNoTracking().Where(w => w.Azerbaycanca == word).FirstOrDefault();
                    break;
                case "Türk":
                    queryFrom = _translateDbContext.Words.AsNoTracking().Where(w => w.Turkce == word).FirstOrDefault();
                    break;
                case "Özbək":
                    queryFrom = _translateDbContext.Words.AsNoTracking().Where(w => w.Ozbekce == word).FirstOrDefault();
                    break;
                case "Qırğız":
                    queryFrom = _translateDbContext.Words.AsNoTracking().Where(w => w.Qirgizca == word).FirstOrDefault();
                    break;
                case "Tatar":
                    queryFrom = _translateDbContext.Words.AsNoTracking().Where(w => w.Tatarca == word).FirstOrDefault();
                    break;
                case "Türkmən":
                    queryFrom = _translateDbContext.Words.AsNoTracking().Where(w => w.Turkmence == word).FirstOrDefault();
                    break;
                case "Qazax":
                    queryFrom = _translateDbContext.Words.AsNoTracking().Where(w => w.Qazaxca == word).FirstOrDefault();
                    break;
                case "Uyğur":
                    queryFrom = _translateDbContext.Words.AsNoTracking().Where(w => w.Uygurca == word).FirstOrDefault();
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
                    translation = queryFrom.Azerbaycanca;
                    break;
                case "Türk":
                    translation = queryFrom.Turkce;
                    break;
                case "Özbək":
                    translation = queryFrom.Ozbekce;
                    break;
                case "Qırğız":
                    translation = queryFrom.Qirgizca;
                    break;
                case "Tatar":
                    translation = queryFrom.Tatarca;
                    break;
                case "Türkmən":
                    translation = queryFrom.Turkmence;
                    break;
                case "Qazax":
                    translation = queryFrom.Qazaxca;
                    break;
                case "Uyğur":
                    translation = queryFrom.Uygurca;
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