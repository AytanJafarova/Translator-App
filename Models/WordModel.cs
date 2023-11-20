using TranslatorApp.DTO;

namespace TranslatorApp.Models
{
    public class WordModel
    {
        public WordToListDTO word { get; set; }
        public List<WordToListDTO> wordtolist { get; set; }
        public WordToAddDTO wordtoadd { get; set; }
        public WordToUpdateDTO wordtoupdate { get; set; }
        public string WordAzeSelected { get; set; }
        public string fromL { get; set; }
        public string toL { get; set; }
        public string wordTranslate { get; set; }
        public string wordResult { get; set; }
        public bool translated { get; set; }
    }
}
