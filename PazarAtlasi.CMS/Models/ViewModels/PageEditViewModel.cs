using PazarAtlasi.CMS.Domain.Common;

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
        
        // SEO Parameters
        public PageSEOParameterEditViewModel? SEOParameter { get; set; }
        
        // Sections grouped by template type
        public List<SectionEditViewModel> Sections { get; set; } = new();
        
        // Available languages for translations
        public List<LanguageViewModel> AvailableLanguages { get; set; } = new();
        
        // Page translations
        public List<PageTranslationEditViewModel> Translations { get; set; } = new();
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
        public string? Code { get; set; }
        public SectionType Type { get; set; }
        public TemplateType TemplateType { get; set; }
        public string? Attributes { get; set; }
        public int SortOrder { get; set; }
        public string? Configure { get; set; }
        public Status Status { get; set; }
        
        // Section Items grouped by template
        public List<SectionItemEditViewModel> SectionItems { get; set; } = new();
        
        // Section translations
        public List<SectionTranslationEditViewModel> Translations { get; set; } = new();
        
        // Helper properties for rendering
        public bool IsCarousel => TemplateType == TemplateType.Carousel;
        public bool IsSingleItem => TemplateType == TemplateType.SingleItem;
        public bool IsGrid => TemplateType == TemplateType.Grid;
        public bool IsList => TemplateType == TemplateType.List;
        public bool IsMasonry => TemplateType == TemplateType.Masonry;
        
        public string TemplateClass => TemplateType switch
        {
            TemplateType.Carousel => "carousel-section",
            TemplateType.Grid => "grid-section",
            TemplateType.List => "list-section",
            TemplateType.Masonry => "masonry-section",
            TemplateType.SingleItem => "single-item-section",
            _ => "default-section"
        };
    }

    public class SectionItemEditViewModel
    {
        public int Id { get; set; }
        public string? Code { get; set; }
        public SectionItemType Type { get; set; }
        public MediaType MediaType { get; set; }
        public string? PictureUrl { get; set; }
        public string? VideoUrl { get; set; }
        public string? RedirectUrl { get; set; }
        public string? Icon { get; set; }
        public int SortOrder { get; set; }
        public string? MediaAttributes { get; set; }
        public Status Status { get; set; }
        
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
        public string Name { get; set; } = string.Empty;
        public string? Title { get; set; }
        public string? Description { get; set; }
    }

    public class LanguageViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string? Code { get; set; }
        public bool IsDefault { get; set; }
    }
}
