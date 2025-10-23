using PazarAtlasi.CMS.Domain.Common;

namespace PazarAtlasi.CMS.Models.ViewModels
{
    /// <summary>
    /// ViewModel for Section Item Field
    /// </summary>
    public class SectionItemFieldViewModel
    {
        public int Id { get; set; }
        
        public int SectionItemId { get; set; }
        
        public SectionItemFieldType FieldType { get; set; }
        
        public string FieldKey { get; set; } = string.Empty;
        
        public string FieldValue { get; set; } = string.Empty;
        
        // Translations (for translatable fields)
        public List<SectionItemFieldTranslationViewModel> Translations { get; set; } = new();
        
        // Helper properties
        public bool IsNew => Id == 0;
    }
}

