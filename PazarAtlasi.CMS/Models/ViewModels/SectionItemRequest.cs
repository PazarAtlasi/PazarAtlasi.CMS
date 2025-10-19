using PazarAtlasi.CMS.Domain.Common;

namespace PazarAtlasi.CMS.Models.ViewModels
{
    /// <summary>
    /// Request model for creating/updating section items via AJAX
    /// </summary>
    public class SectionItemRequest
    {
        public int Id { get; set; }
        public int SectionId { get; set; }
        public string? TempId { get; set; }
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
        public List<SectionItemFieldViewModel>? Fields { get; set; } = new();
        public List<SectionItemRequest> NestedItems { get; set; } = new();
        public List<SectionItemTranslationRequest> Translations { get; set; } = new();
    }
}

