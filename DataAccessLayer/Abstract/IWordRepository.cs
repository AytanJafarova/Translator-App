using TranslatorApp.Entities;

namespace TranslatorApp.DataAccessLayer.Abstract
{
    public interface IWordRepository
    {
        List<Word> Get();
        Word Get(int id);
        int GetintByAze(string word);
        string GetTranslationResult(string fromL, string toL, string word);
        void Add(Word word);
        void Update(Word word);
        void Delete(int id); // Hard Delete
    }
}
