using PazarAtlasi.CMS.Domain.Common;

namespace PazarAtlasi.CMS.Models.ViewModels
{
    public class SectionItemViewModel
    {
        public int Id { get; set; }
        public SectionItemType Type { get; set; }
        public string? PictureUrl { get; set; }
        public string? RedirectUrl { get; set; }
        public string? Icon { get; set; }
        public int SortOrder { get; set; }
        public Status Status { get; set; }
        
        // Translations
        public List<SectionItemTranslationViewModel> Translations { get; set; } = new();
    }
}
