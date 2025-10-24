namespace PazarAtlasi.CMS.Models.ViewModels
{
    /// <summary>
    /// ViewModel for Section Item Field Value Translation
    /// </summary>
    public class SectionItemFieldValueTranslationViewModel
    {
        public int Id { get; set; }
        
        public int SectionItemFieldValueId { get; set; }
        
        public int LanguageId { get; set; }
        
        public string LanguageCode { get; set; } = string.Empty;
        
        public string LanguageName { get; set; } = string.Empty;
        
        public string Value { get; set; } = string.Empty;
        
        // Helper properties
        public bool IsNew => Id == 0;
    }
}