namespace PazarAtlasi.CMS.Models.ViewModels
{
    public class SectionItemTranslationViewModel
    {
        public int Id { get; set; }
        public int LanguageId { get; set; }
        public string? LanguageCode { get; set; }
        public string? LanguageName { get; set; }
        public string? Name { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
    }
}
