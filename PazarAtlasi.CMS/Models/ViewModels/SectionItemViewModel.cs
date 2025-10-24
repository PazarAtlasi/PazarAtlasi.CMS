using PazarAtlasi.CMS.Application.Dtos;
using PazarAtlasi.CMS.Domain.Common;

namespace PazarAtlasi.CMS.Models.ViewModels
{
    /// <summary>
    /// ViewModel for Section Item editing modal
    /// </summary>
    public class SectionItemViewModel
    {
        public int Id { get; set; }
        
        public int SectionId { get; set; }

        public int? ParentId { get; set; }

        public int? TemplateId { get; set; }

        public SectionType SectionType { get; set; }
        
        public SectionItemType Type { get; set; }
        
        public MediaType MediaType { get; set; }
        
        public int? LinkedPageId { get; set; }
        
        public int SortOrder { get; set; }
        
        public Status Status { get; set; }

        public List<SectionItemFieldViewModel> Fields { get; set; } = new();
        
        public List<SectionItemViewModel> ChildItems { get; set; } = new();

        public SectionItemSettingDto SectionItemConfiguration { get; set; } = new();

        // Translations
        public List<SectionItemTranslationViewModel> Translations { get; set; } = new();

        // Available languages
        public List<LanguageViewModel> AvailableLanguages { get; set; } = new();

        // Helper properties
        public bool IsNew => Id == 0;

        public bool IsNested => ParentId.HasValue;
    }
}
