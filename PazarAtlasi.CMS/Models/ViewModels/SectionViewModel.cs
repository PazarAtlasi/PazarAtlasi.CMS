using PazarAtlasi.CMS.Domain.Common;

namespace PazarAtlasi.CMS.Models.ViewModels
{
    /// <summary>
    /// ViewModel for combined Section and Section Items editing modal
    /// </summary>
    public class SectionViewModel
    {
        public int Id { get; set; }
        public int PageId { get; set; }
        public SectionType Type { get; set; }
        public string Key { get; set; } = string.Empty;
        public string? Attributes { get; set; }
        public int SortOrder { get; set; }
        public string? Configure { get; set; }
        public Status Status { get; set; }

        // Section Items for this section
        public List<SectionItemViewModel> SectionItems { get; set; } = new();

        // Available languages
        public List<LanguageViewModel> AvailableLanguages { get; set; } = new();

        // Section translations
        public List<SectionTranslationViewModel> Translations { get; set; } = new();

        // Helper properties
        public bool IsNew => Id == 0;
        // Template type will be determined by associated Template entity
        public bool IsCarousel => false; // Will be updated when template system is implemented
        public bool IsGrid => false;
        public bool IsList => false;
        public bool IsSingleItem => false;
        public bool RequiresMultipleItems => IsCarousel || IsGrid || IsList;
        public int RequiredItemsCount => IsCarousel ? 3 : (IsGrid ? 6 : (IsList ? 4 : 1));
    }
}
