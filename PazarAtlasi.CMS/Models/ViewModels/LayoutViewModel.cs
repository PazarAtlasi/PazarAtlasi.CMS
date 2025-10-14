using PazarAtlasi.CMS.Domain.Common;

namespace PazarAtlasi.CMS.Models.ViewModels
{
    public class LayoutViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public Status Status { get; set; }
        public bool IsDefault { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public List<LayoutSectionViewModel> LayoutSections { get; set; } = new();
    }

    public class LayoutSectionViewModel
    {
        public int Id { get; set; }
        public int LayoutId { get; set; }
        public int SectionId { get; set; }
        public string SectionName { get; set; } = string.Empty;
        public SectionType SectionType { get; set; }
        public int SortOrder { get; set; }
        public bool IsRequired { get; set; } // e.g., navbar and footer might be required
        public string Position { get; set; } = string.Empty; // "header", "content", "footer", "sidebar"
    }

    public class LayoutListViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public Status Status { get; set; }
        public bool IsDefault { get; set; }
        public int SectionsCount { get; set; }
        public int PagesUsingCount { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }

    public class LayoutListResponse
    {
        public List<LayoutListViewModel> Layouts { get; set; } = new();
        public int TotalCount { get; set; }
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public bool HasNextPage => PageNumber * PageSize < TotalCount;
        public bool HasPreviousPage => PageNumber > 1;
    }

    public class CreateLayoutViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public Status Status { get; set; } = Status.Draft;
        public bool IsDefault { get; set; }
        public List<LayoutSectionCreateViewModel> Sections { get; set; } = new();
    }

    public class LayoutSectionCreateViewModel
    {
        public int SectionId { get; set; }
        public string Position { get; set; } = string.Empty;
        public int SortOrder { get; set; }
        public bool IsRequired { get; set; }
    }
}
