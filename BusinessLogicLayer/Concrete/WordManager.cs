using AutoMapper;
using TranslatorApp.BusinessLogicLayer.Abstract;
using TranslatorApp.DataAccessLayer.Abstract;
using TranslatorApp.DTO;
using TranslatorApp.Entities;

namespace TranslatorApp.BusinessLogicLayer.Concrete
{
    public class WordManager : IWordService
    {
        private readonly IWordRepository _wordRepository;
        private readonly IMapper _mapper;
        public WordManager(IWordRepository wordRepository, IMapper mapper)
        {
            _mapper = mapper;
            _wordRepository = wordRepository;
        }
        public void Add(WordToAddDTO dto)
        {
            _wordRepository.Add(_mapper.Map<Word>(dto));
        }

        public void Delete(int id)
        {
            _wordRepository.Delete(id);
        }

        public List<WordToListDTO> Get()
        {
            return _mapper.Map<List<WordToListDTO>>(_wordRepository.Get());
        }

        public WordToListDTO Get(int id)
        {
           return _mapper.Map<WordToListDTO>(_wordRepository.Get(id));
        }

        public int GetintByAze(string word)
        {
            return _wordRepository.GetintByAze(word);
        }

        public string GetTranslationResult(string fromL, string toL, string word)
        {
            return _wordRepository.GetTranslationResult(fromL, toL, word);
        }

        public void Update(int id, WordToUpdateDTO dto)
        {
            Word word = _mapper.Map<Word>(dto);
            word.WordId = id;
            _wordRepository.Update(word);
        }
    }
}
