using PazarAtlasi.CMS.Domain.Common;

namespace PazarAtlasi.CMS.Models.ViewModels
{
    public class SectionDetailsViewModel
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public SectionType Type { get; set; }
        public string Key { get; set; } = string.Empty;
        public Status Status { get; set; }
        public int SortOrder { get; set; }
        public string? Attributes { get; set; }
        public string? Configure { get; set; }
        public bool IsReusable { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }

        // Related data
        public string? PageName { get; set; }
        public int? PageId { get; set; }
        public List<SectionItemDetailsViewModel> SectionItems { get; set; } = new();
        public List<SectionTranslationViewModel> Translations { get; set; } = new();
        public List<PageUsageViewModel> UsedInPages { get; set; } = new(); // For reusable sections
    }
}
