using PazarAtlasi.CMS.Domain.Common;

namespace PazarAtlasi.CMS.Models.ViewModels
{
    /// <summary>
    /// ViewModel for layout editing page
    /// </summary>
    public class LayoutEditViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public Status Status { get; set; }
        public bool IsDefault { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }

        // Layout sections with full section data
        public List<LayoutSectionEditViewModel> Sections { get; set; } = new();

        // Available languages for translations
        public List<LanguageViewModel> AvailableLanguages { get; set; } = new();
    }

    /// <summary>
    /// ViewModel for layout section editing
    /// </summary>
    public class LayoutSectionEditViewModel
    {
        public int Id { get; set; }
        public int LayoutId { get; set; }
        public int SectionId { get; set; }
        public int SortOrder { get; set; }
        public string Position { get; set; } = string.Empty;
        public bool IsRequired { get; set; }

        // Section details
        public SectionType Type { get; set; }
        public string Key { get; set; } = string.Empty;
        public string? Attributes { get; set; }
        public string? Configure { get; set; }
        public Status Status { get; set; }

        // Section items for preview
        public List<SectionItemViewModel> SectionItems { get; set; } = new();

        // Section translations
        public List<SectionTranslationViewModel> Translations { get; set; } = new();
    }
}