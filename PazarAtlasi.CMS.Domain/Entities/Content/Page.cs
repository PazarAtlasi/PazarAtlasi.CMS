using PazarAtlasi.CMS.Domain.Common;

namespace PazarAtlasi.CMS.Domain.Entities.Content
{
    public class Page : Entity<int>
    {
        public Page(string name, string code)
        {
            Name = name;
            Code = code;
        }

        public Page()
        {
        }

        public int? ContentId { get; set; }

        public int? PageSEOParameterId { get; set; }

        public int? LayoutId { get; set; }

        /// <summary>
        /// Parent page ID for hierarchical structure
        /// </summary>
        public int? ParentPageId { get; set; }

        public PageType PageType { get; set; } = PageType.None;

        public string? Name { get; set; }

        public string? Code { get; set; }

        public string? Description { get; set; }

        public virtual Content Content { get; set; }

        public virtual PageSEOParameter PageSEOParameter { get; set; }

        public virtual Layout Layout { get; set; }

        /// <summary>
        /// Parent page navigation property
        /// </summary>
        public virtual Page? ParentPage { get; set; }

        /// <summary>
        /// Child pages collection
        /// </summary>
        public virtual ICollection<Page> ChildPages { get; set; } = new List<Page>();

        public virtual ICollection<PageSection> PageSections { get; set; }

        public virtual ICollection<PageTranslation> PageTranslations { get; set; }
    }
}
