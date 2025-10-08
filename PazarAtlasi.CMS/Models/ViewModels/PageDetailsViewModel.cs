using PazarAtlasi.CMS.Domain.Common;

namespace PazarAtlasi.CMS.Models.ViewModels
{
    public class PageDetailsViewModel
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Code { get; set; }
        public PageType PageType { get; set; }
        public string? Description { get; set; }
        public Status Status { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        
        // SEO Parameters
        public PageSEOParameterViewModel? SEOParameter { get; set; }
        
        // Sections
        public List<SectionViewModel> Sections { get; set; } = new();
        
        // Translations
        public List<PageTranslationViewModel> Translations { get; set; } = new();
    }

    public class PageSEOParameterViewModel
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

    public class SectionViewModel
    {
        public int Id { get; set; }
        public string? Code { get; set; }
        public SectionType Type { get; set; }
        public TemplateType TemplateType { get; set; }
        public string? Attributes { get; set; }
        public int SortOrder { get; set; }
        public string? Configure { get; set; }
        public Status Status { get; set; }
        
        // Section Items
        public List<SectionItemViewModel> SectionItems { get; set; } = new();
        
        // Translations
        public List<SectionTranslationViewModel> Translations { get; set; } = new();
    }

    public class SectionItemViewModel
    {
        public int Id { get; set; }
        public string? Code { get; set; }
        public SectionItemType Type { get; set; }
        public string? PictureUrl { get; set; }
        public string? RedirectUrl { get; set; }
        public string? Icon { get; set; }
        public int SortOrder { get; set; }
        public Status Status { get; set; }
        
        // Translations
        public List<SectionItemTranslationViewModel> Translations { get; set; } = new();
    }

    public class PageTranslationViewModel
    {
        public int Id { get; set; }
        public int LanguageId { get; set; }
        public string? LanguageName { get; set; }
        public string? LanguageCode { get; set; }
        public string Value { get; set; } = string.Empty;
    }

    public class SectionTranslationViewModel
    {
        public int Id { get; set; }
        public int LanguageId { get; set; }
        public string? LanguageName { get; set; }
        public string? LanguageCode { get; set; }
        public string Name { get; set; } = string.Empty;
        public string? Title { get; set; }
        public string? Description { get; set; }
    }

    public class SectionItemTranslationViewModel
    {
        public int Id { get; set; }
        public int LanguageId { get; set; }
        public string? LanguageName { get; set; }
        public string? LanguageCode { get; set; }
        public string Name { get; set; } = string.Empty;
        public string? Title { get; set; }
        public string? Description { get; set; }
    }
}
