using PazarAtlasi.CMS.Domain.Common;

namespace PazarAtlasi.CMS.Models.ViewModels
{
    /// <summary>
    /// ViewModel for Section Item Field Value (represents the actual value of a field for a specific section item)
    /// </summary>
    public class SectionItemFieldViewModel
    {
        /// <summary>
        /// Field Value ID (SectionItemFieldValue.Id)
        /// </summary>
        public int Id { get; set; }
        
        /// <summary>
        /// Section Item ID this field value belongs to
        /// </summary>
        public int SectionItemId { get; set; }
        
        /// <summary>
        /// Field type (from SectionItemFieldSetting)
        /// </summary>
        public SectionItemFieldType FieldType { get; set; }
        
        /// <summary>
        /// Field key (from SectionItemFieldSetting)
        /// </summary>
        public string FieldKey { get; set; } = string.Empty;
        
        /// <summary>
        /// The actual field value
        /// </summary>
        public string FieldValue { get; set; } = string.Empty;
        
        /// <summary>
        /// Whether this field supports multiple languages for values
        /// </summary>
        public bool IsTranslatable { get; set; } = false;
        
        // Value translations (for translatable field values)
        public List<SectionItemFieldTranslationViewModel> Translations { get; set; } = new();
        
        // Helper properties
        public bool IsNew => Id == 0;
    }
}

