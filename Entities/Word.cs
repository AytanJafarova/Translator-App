using System.ComponentModel.DataAnnotations;

namespace TranslatorApp.Entities
{
    public class Word
    {
        [Key]
        public int WordId { get; set; }
        public string Azerbaycanca { get; set; }
        public string? Turkce { get; set; }
        public string? Ozbekce { get; set; }
        public string? Qirgizca { get; set; }
        public string? Tatarca { get; set; }
        public string? Qazaxca { get; set; }
        public string? Uygurca { get; set; }
        public string? Turkmence { get; set; }
        public string? UnSelected { get; set; }

    }
}
