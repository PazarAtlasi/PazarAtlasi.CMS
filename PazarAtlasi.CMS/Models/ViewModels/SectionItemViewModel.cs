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
        public string? SectionCode { get; set; }
        public SectionType SectionType { get; set; }
        public SectionItemType Type { get; set; }
        public MediaType MediaType { get; set; }
        public string? PictureUrl { get; set; }
        public string? VideoUrl { get; set; }
        public string? RedirectUrl { get; set; }
        public int? LinkedPageId { get; set; }
        public string? Icon { get; set; }
        public int SortOrder { get; set; }
        public string? MediaAttributes { get; set; }
        public Status Status { get; set; }

        // For slider - multiple images
        public List<string> SliderImages { get; set; } = new();

        // Translations
        public List<SectionItemTranslationViewModel> Translations { get; set; } = new();

        // Available languages
        public List<LanguageViewModel> AvailableLanguages { get; set; } = new();

        // Helper properties
        public bool IsNew => Id == 0;
        public bool IsHeroSection => SectionType == SectionType.Hero;
        public bool HasImage => !string.IsNullOrEmpty(PictureUrl);
        public bool HasVideo => !string.IsNullOrEmpty(VideoUrl);
        public bool IsSlider => MediaType == MediaType.ImageSlider;
    }
}
