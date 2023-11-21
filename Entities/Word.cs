using System.ComponentModel.DataAnnotations;

namespace TranslatorApp.Entities
{
    public class Word
    {
        [Key]
        public int WordId { get; set; }
        public string Azerbaycan { get; set; }
        public string? Turk { get; set; }
        public string? Latin { get; set; }
        public string? Ozbek { get; set; }
        public string? Qazax { get; set; }
        public string? Rus { get; set; }
        public string? UnSelected { get; set; }

    }
}
