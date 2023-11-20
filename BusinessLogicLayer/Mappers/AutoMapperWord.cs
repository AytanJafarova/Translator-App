using AutoMapper;
using TranslatorApp.DTO;
using TranslatorApp.Entities;

namespace TranslatorApp.BusinessLogicLayer.Mappers
{
    public class AutoMapperWord:Profile
    {
        public AutoMapperWord()
        {
            CreateMap<WordToAddDTO, Word>();
            CreateMap<Word, WordToListDTO>();
            CreateMap<WordToUpdateDTO, Word>();
        }
    }
}
