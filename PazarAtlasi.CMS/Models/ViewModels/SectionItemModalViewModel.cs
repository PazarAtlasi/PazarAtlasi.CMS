using PazarAtlasi.CMS.Domain.Common;

namespace PazarAtlasi.CMS.Models.ViewModels
{
    /// <summary>
    /// ViewModel for Section Item editing modal
    /// </summary>
    public class SectionItemModalViewModel
    {
        public int Id { get; set; }
        public int SectionId { get; set; }
        public string? SectionCode { get; set; }
        public SectionType SectionType { get; set; }
        public SectionItemType Type { get; set; }
        public MediaType MediaType { get; set; }
        public string? PictureUrl { get; set; }
        public string? VideoUrl { get; set; }
        public string? RedirectUrl { get; set; }
        public string? Icon { get; set; }
        public int SortOrder { get; set; }
        public string? MediaAttributes { get; set; }
        public Status Status { get; set; }
        
        // For slider - multiple images
        public List<string> SliderImages { get; set; } = new();
        
        // Translations
        public List<SectionItemTranslationModalViewModel> Translations { get; set; } = new();
        
        // Available languages
        public List<LanguageViewModel> AvailableLanguages { get; set; } = new();
        
        // Helper properties
        public bool IsNew => Id == 0;
        public bool IsHeroSection => SectionType == SectionType.Hero;
        public bool HasImage => !string.IsNullOrEmpty(PictureUrl);
        public bool HasVideo => !string.IsNullOrEmpty(VideoUrl);
        public bool IsSlider => MediaType == MediaType.ImageSlider;
    }

    public class SectionItemTranslationModalViewModel
    {
        public int Id { get; set; }
        public int SectionItemId { get; set; }
        public int LanguageId { get; set; }
        public string? LanguageName { get; set; }
        public string? LanguageCode { get; set; }
        public string Name { get; set; } = string.Empty;
        public string? Title { get; set; }
        public string? Description { get; set; }
        public string? ButtonText { get; set; }
        public string? ButtonUrl { get; set; }
    }

    /// <summary>
    /// Request model for creating/updating section items via AJAX
    /// </summary>
    public class SectionItemRequest
    {
        public int Id { get; set; }
        public int SectionId { get; set; }
        public SectionItemType Type { get; set; }
        public MediaType MediaType { get; set; }
        public string? PictureUrl { get; set; }
        public string? VideoUrl { get; set; }
        public string? RedirectUrl { get; set; }
        public string? Icon { get; set; }
        public int SortOrder { get; set; }
        public string? MediaAttributes { get; set; }
        public Status Status { get; set; }
        public List<SectionItemTranslationRequest> Translations { get; set; } = new();
    }

    public class SectionItemTranslationRequest
    {
        public int Id { get; set; }
        public int LanguageId { get; set; }
        public string Name { get; set; } = string.Empty;
        public string? Title { get; set; }
        public string? Description { get; set; }
    }
}

