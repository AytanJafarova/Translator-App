using TranslatorApp.DTO;

namespace TranslatorApp.BusinessLogicLayer.Abstract
{
    public interface IWordService
    {
        List<WordToListDTO> Get();
        WordToListDTO Get(int id);
        int GetintByAze(string word);
        string GetTranslationResult(string fromL, string toL, string word);
        void Add(WordToAddDTO dto);
        void Update(int id, WordToUpdateDTO dto);
        void Delete(int id);
    }
}
