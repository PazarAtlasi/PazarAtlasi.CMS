namespace PazarAtlasi.CMS.Models.ViewModels
{
    /// <summary>
    /// ViewModel for Section Item Field Translation
    /// </summary>
    public class SectionItemFieldTranslationViewModel
    {
        public int Id { get; set; }
        
        public int SectionItemFieldId { get; set; }
        
        public int LanguageId { get; set; }
        
        public string? LanguageCode { get; set; }
        
        public string? LanguageName { get; set; }
        
        public string Name { get; set; } = string.Empty;
        
        public string Description { get; set; } = string.Empty;
        
        // Helper properties
        public bool IsNew => Id == 0;
    }
}

