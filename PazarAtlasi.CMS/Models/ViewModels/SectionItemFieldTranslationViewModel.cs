namespace PazarAtlasi.CMS.Models.ViewModels
{
    /// <summary>
    /// ViewModel for Section Item Field Definition Translation (labels, descriptions, etc.)
    /// </summary>
    public class SectionItemFieldTranslationViewModel
    {
        public int Id { get; set; }
        public int SectionItemFieldId { get; set; }
        public int LanguageId { get; set; }
        public string LanguageCode { get; set; } = string.Empty;
        public string LanguageName { get; set; } = string.Empty;
        public string Label { get; set; } = string.Empty;
        public string? Description { get; set; }
        public string? Placeholder { get; set; }
    }
}