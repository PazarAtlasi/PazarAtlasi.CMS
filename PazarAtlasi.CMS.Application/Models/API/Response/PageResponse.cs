using PazarAtlasi.CMS.Domain.Common;

namespace PazarAtlasi.CMS.Application.Models.API.Response
{
    public class PageResponse
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Slug { get; set; } = string.Empty;
        public PageType PageType { get; set; }
        public string? Description { get; set; }
        public Status Status { get; set; }
        public List<BreadcrumbItem> Breadcrumbs { get; set; } = new List<BreadcrumbItem>();
        public List<SectionResponse> Sections { get; set; } = new List<SectionResponse>();
        public PageSEOResponse? SEO { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }

    public class BreadcrumbItem
    {
        public string Name { get; set; } = string.Empty;
        public string Href { get; set; } = string.Empty;
        public bool IsActive { get; set; }
    }

    public class SectionResponse
    {
        public int Id { get; set; }
        public SectionType Type { get; set; }
        public string Key { get; set; } = string.Empty;
        public string? Attributes { get; set; }
        public string? Configure { get; set; }
        public int SortOrder { get; set; }
        public Status Status { get; set; }
        public string? Name { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public List<SectionItemResponse> Items { get; set; } = new List<SectionItemResponse>();
    }

    public class SectionItemResponse
    {
        public int Id { get; set; }
        public SectionItemType Type { get; set; }
        public MediaType MediaType { get; set; }
        public int SortOrder { get; set; }
        public Status Status { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public string? Key { get; set; }
        public bool AllowReorder { get; set; }
        public bool AllowRemove { get; set; }
        public string? IconClass { get; set; }
        public List<SectionItemFieldResponse> Fields { get; set; } = new List<SectionItemFieldResponse>();
        public List<SectionItemResponse> Children { get; set; } = new List<SectionItemResponse>();
    }

    public class SectionItemFieldResponse
    {
        public int Id { get; set; }
        public string FieldKey { get; set; } = string.Empty;
        public string FieldName { get; set; } = string.Empty;
        public SectionItemFieldType Type { get; set; }
        public bool Required { get; set; }
        public bool IsTranslatable { get; set; }
        public string Value { get; set; } = string.Empty;
        public string? JsonValue { get; set; }
        public int SortOrder { get; set; }
    }

    public class PageSEOResponse
    {
        public int Id { get; set; }
        public string? MetaTitle { get; set; }
        public string? MetaDescription { get; set; }
        public string? MetaKeywords { get; set; }
        public string? Title { get; set; }
        public string? CanonicalURL { get; set; }
        public string? Author { get; set; }
        public string? Description { get; set; }
    }
}