using PazarAtlasi.CMS.Domain.Common;

namespace PazarAtlasi.CMS.Models.ViewModels
{
    public class PageListViewModel
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Code { get; set; }
        public PageType PageType { get; set; }
        public string? Description { get; set; }
        public Status Status { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        
        // Hierarchical properties
        public int? ParentPageId { get; set; }
        public string? ParentPageName { get; set; }
        public int Level { get; set; } = 0; // For display indentation
        public bool HasChildren { get; set; } = false;
        public List<PageListViewModel> ChildPages { get; set; } = new();
        
        // Helper properties
        public string PageTypeName => PageType.ToString();
        public string StatusName => Status.ToString();
        public string StatusBadgeClass => Status switch
        {
            Status.Active => "bg-green-100 text-green-800",
            Status.Draft => "bg-yellow-100 text-yellow-800",
            Status.Pending => "bg-blue-100 text-blue-800",
            Status.Archived => "bg-gray-100 text-gray-800",
            _ => "bg-red-100 text-red-800"
        };
        
        public string IndentClass => Level switch
        {
            0 => "",
            1 => "ml-6",
            2 => "ml-12",
            3 => "ml-18",
            _ => "ml-24"
        };
        
        public string HierarchyIcon => Level switch
        {
            0 => "fas fa-home",
            1 => "fas fa-folder",
            2 => "fas fa-file",
            _ => "fas fa-file-alt"
        };
    }

    public class PageListResponse
    {
        public List<PageListViewModel> Pages { get; set; } = new();
        public int TotalCount { get; set; }
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public int TotalPages => (int)Math.Ceiling((double)TotalCount / PageSize);
        public bool HasPreviousPage => PageNumber > 1;
        public bool HasNextPage => PageNumber < TotalPages;
    }
}
