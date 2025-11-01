using PazarAtlasi.CMS.Domain.Common;
using PazarAtlasi.CMS.Models.ViewModels;

namespace PazarAtlasi.CMS.Models.ViewModels
{
    public class PageEditViewModel
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Code { get; set; }
        public PageType PageType { get; set; }
        public string? Description { get; set; }
        public Status Status { get; set; }

        // Hierarchical properties
        public int? ParentPageId { get; set; }
        public string? ParentPageName { get; set; }
        public List<AvailableParentPageViewModel> AvailableParentPages { get; set; } = new();

        // Layout properties
        public int? LayoutId { get; set; }
        public string? LayoutName { get; set; }
        public List<AvailableLayoutViewModel> AvailableLayouts { get; set; } = new();
        public LayoutSectionsViewModel? LayoutSections { get; set; }

        // SEO Parameters
        public PageSEOParameterEditViewModel? SEOParameter { get; set; }

        // Sections grouped by template type
        public List<SectionEditViewModel> Sections { get; set; } = new();

        // Available languages for translations
        public List<LanguageViewModel> AvailableLanguages { get; set; } = new();

        // Page translations
        public List<PageTranslationEditViewModel> Translations { get; set; } = new();
    }

    public class AvailableParentPageViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Code { get; set; } = string.Empty;
        public PageType PageType { get; set; }
        public int Level { get; set; } = 0;
        public string DisplayName => $"{new string('-', Level * 2)} {Name}";
    }

    public class PageSEOParameterEditViewModel
    {
        public int Id { get; set; }
        public string? MetaTitle { get; set; }
        public string? MetaDescription { get; set; }
        public string? MetaKeywords { get; set; }
        public string? Title { get; set; }
        public string? CanonicalURL { get; set; }
        public string? Author { get; set; }
        public string? Description { get; set; }
    }

    public class SectionEditViewModel
    {
        public int Id { get; set; }
        public SectionType Type { get; set; }
        public string Key { get; set; } = string.Empty;
        public string? Attributes { get; set; }
        public int SortOrder { get; set; }
        public string? Configure { get; set; }
        public Status Status { get; set; }

        // Section Items grouped by template
        public List<SectionItemEditViewModel> SectionItems { get; set; } = new();

        // Section translations
        public List<SectionTranslationEditViewModel> Translations { get; set; } = new();

        // Helper properties for rendering - will be updated with template system
        public bool IsCarousel => false;

        public bool IsSingleItem => false;

        public bool IsGrid => false;

        public bool IsList => false;

        public bool IsMasonry => false;

        public string TemplateClass => "default-section"; // Will be determined by template
    }

    public class SectionItemEditViewModel
    {
        public int Id { get; set; }

        public int? ParentSectionItemId { get; set; }

        public SectionItemType Type { get; set; }

        public MediaType MediaType { get; set; }

        public int SortOrder { get; set; }

        public string? MediaAttributes { get; set; }

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
        /// Icon class for UI display
        /// </summary>
        public string? IconClass { get; set; }

        // Nested structure support
        public List<SectionItemEditViewModel> ChildItems { get; set; } = new();

        // Fields for this section item
        public List<SectionItemFieldViewModel> Fields { get; set; } = new();

        // Section item translations
        public List<SectionItemTranslationEditViewModel> Translations { get; set; } = new();

        // Helper properties
        public string TypeIcon => Type switch
        {
            SectionItemType.Text => "fas fa-font",
            SectionItemType.Image => "fas fa-image",
            SectionItemType.Video => "fas fa-video",
            SectionItemType.Button => "fas fa-mouse-pointer",
            SectionItemType.Link => "fas fa-link",
            SectionItemType.Gallery => "fas fa-images",
            SectionItemType.Form => "fas fa-wpforms",
            SectionItemType.Map => "fas fa-map-marker-alt",
            _ => "fas fa-cube"
        };

        public string MediaTypeDisplay => MediaType switch
        {
            MediaType.Image => "Single Image",
            MediaType.Video => "Video",
            MediaType.ImageSlider => "Image Slider",
            MediaType.Audio => "Audio",
            MediaType.Document => "Document",
            _ => "None"
        };

        // Helper properties for nested structure
        public bool IsNested => ParentSectionItemId.HasValue;

        public bool HasChildren => ChildItems.Any();
    }

    public class PageTranslationEditViewModel
    {
        public int Id { get; set; }

        public int LanguageId { get; set; }

        public string? LanguageName { get; set; }

        public string? LanguageCode { get; set; }

        public string Value { get; set; } = string.Empty;
    }

    public class SectionTranslationEditViewModel
    {
        public int Id { get; set; }

        public int LanguageId { get; set; }

        public string? LanguageName { get; set; }

        public string? LanguageCode { get; set; }

        public string Name { get; set; } = string.Empty;

        public string? Title { get; set; }

        public string? Description { get; set; }
    }

    public class SectionItemTranslationEditViewModel
    {
        public int Id { get; set; }

        public int LanguageId { get; set; }

        public string? LanguageName { get; set; }

        public string? LanguageCode { get; set; }

        public string? Title { get; set; }

        public string? Description { get; set; }
    }
}
