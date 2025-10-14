namespace PazarAtlasi.CMS.Models.ViewModels
{
    public class PageTranslationViewModel
    {
        public int Id { get; set; }
        public int LanguageId { get; set; }
        public string? LanguageName { get; set; }
        public string? LanguageCode { get; set; }
        public string Value { get; set; } = string.Empty;
    }
}
