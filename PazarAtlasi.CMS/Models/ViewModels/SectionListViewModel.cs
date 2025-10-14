using PazarAtlasi.CMS.Domain.Common;

namespace PazarAtlasi.CMS.Models.ViewModels
{
    public class SectionListViewModel
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public SectionType Type { get; set; }
        public SectionTemplateType SectionTemplateType { get; set; }
        public Status Status { get; set; }
        public int ItemsCount { get; set; }
        public string? PageName { get; set; }
        public int? PageId { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public bool IsReusable { get; set; } // Indicates if this section can be reused across pages
    }

    public class SectionListResponse
    {
        public List<SectionListViewModel> Sections { get; set; } = new();
        public int TotalCount { get; set; }
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public bool HasNextPage => PageNumber * PageSize < TotalCount;
        public bool HasPreviousPage => PageNumber > 1;
    }
}
