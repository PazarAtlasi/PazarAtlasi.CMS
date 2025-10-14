using PazarAtlasi.CMS.Domain.Common;

namespace PazarAtlasi.CMS.Models.ViewModels
{
    public class SectionViewModel
    {
        public int Id { get; set; }
        public SectionType Type { get; set; }
        public SectionTemplateType SectionTemplateType { get; set; }
        public string? Attributes { get; set; }
        public int SortOrder { get; set; }
        public string? Configure { get; set; }
        public Status Status { get; set; }
        
        // Section Items
        public List<SectionItemViewModel> SectionItems { get; set; } = new();
        
        // Translations
        public List<SectionTranslationViewModel> Translations { get; set; } = new();
    }
}
