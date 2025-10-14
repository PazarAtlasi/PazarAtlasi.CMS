using PazarAtlasi.CMS.Domain.Common;

namespace PazarAtlasi.CMS.Models.ViewModels
{
    /// <summary>
    /// ViewModel for combined Section and Section Items editing modal
    /// </summary>
    public class SectionModalViewModel
    {
        public int Id { get; set; }
        public int PageId { get; set; }
        public SectionType Type { get; set; }
        public SectionTemplateType SectionTemplateType { get; set; }
        public string? Attributes { get; set; }
        public int SortOrder { get; set; }
        public string? Configure { get; set; }
        public Status Status { get; set; }
        
        // Section Items for this section
        public List<SectionItemModalViewModel> SectionItems { get; set; } = new();
        
        // Available languages
        public List<LanguageViewModel> AvailableLanguages { get; set; } = new();
        
        // Section translations
        public List<SectionTranslationModalViewModel> Translations { get; set; } = new();
        
        // Helper properties
        public bool IsNew => Id == 0;
        public bool IsCarousel => SectionTemplateType == SectionTemplateType.Carousel;
        public bool IsGrid => SectionTemplateType == SectionTemplateType.Grid;
        public bool IsList => SectionTemplateType == SectionTemplateType.List;
        public bool IsSingleItem => SectionTemplateType == SectionTemplateType.SingleItem;
        public bool RequiresMultipleItems => IsCarousel || IsGrid || IsList;
        public int RequiredItemsCount => IsCarousel ? 3 : (IsGrid ? 6 : (IsList ? 4 : 1));
    }

    public class SectionTranslationModalViewModel
    {
        public int Id { get; set; }
        public int SectionId { get; set; }
        public int LanguageId { get; set; }
        public string? LanguageName { get; set; }
        public string? LanguageCode { get; set; }
        public string Name { get; set; } = string.Empty;
        public string? Title { get; set; }
        public string? Description { get; set; }
    }

    /// <summary>
    /// Request model for creating/updating sections with items via AJAX
    /// </summary>
    public class SectionRequest
    {
        public int Id { get; set; }
        public int PageId { get; set; }
        public SectionType Type { get; set; }
        public SectionTemplateType SectionTemplateType { get; set; }
        public string? Attributes { get; set; }
        public int SortOrder { get; set; }
        public string? Configure { get; set; }
        public Status Status { get; set; }
        public List<SectionItemRequest> SectionItems { get; set; } = new();
        public List<SectionTranslationRequest> Translations { get; set; } = new();
    }

    public class SectionTranslationRequest
    {
        public int Id { get; set; }
        public int LanguageId { get; set; }
        public string Name { get; set; } = string.Empty;
        public string? Title { get; set; }
        public string? Description { get; set; }
    }
}
