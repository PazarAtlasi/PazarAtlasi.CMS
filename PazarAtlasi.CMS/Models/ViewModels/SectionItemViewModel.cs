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

        public TemplateType TemplateType { get; set; } // Template type for rendering behavior

        public string TemplateKey { get; set; } = string.Empty; // Unique identifier for template (e.g., "navbar-megamenu", "navbar-simple")

        public int? TemplateId { get; set; }

        public SectionType SectionType { get; set; }
        
        public SectionItemType Type { get; set; }
        
        public MediaType MediaType { get; set; }
        
        public int? LinkedPageId { get; set; }
        
        public int SortOrder { get; set; }
        
        public Status Status { get; set; }

        /// <summary>
        /// Display title for this item
        /// </summary>
        public string? Title { get; set; }

        /// <summary>
        /// Description for this item
        /// </summary>
        public string? Description { get; set; }

        /// <summary>
        /// Whether this item can be reordered
        /// </summary>
        public bool AllowReorder { get; set; } = true;

        /// <summary>
        /// Whether this item can be removed dynamically
        /// </summary>
        public bool AllowRemove { get; set; } = true;

        /// <summary>
        /// Icon class for UI display
        /// </summary>
        public string? IconClass { get; set; }

        public List<SectionItemFieldViewModel> Fields { get; set; } = new();
        
        public List<SectionItemViewModel> ChildItems { get; set; } = new();

        // Translations
        public List<SectionItemTranslationViewModel> Translations { get; set; } = new();

        // Available languages
        public List<LanguageViewModel> AvailableLanguages { get; set; } = new();

        // Helper properties
        public bool IsNew => Id == 0;

        public bool IsNested => ParentId.HasValue;
    }
}
