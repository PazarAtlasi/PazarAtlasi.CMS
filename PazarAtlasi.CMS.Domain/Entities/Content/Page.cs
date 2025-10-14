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

        public PageType PageType { get; set; } = PageType.None;

        public string? Slug { get; set; }

        public string? Name { get; set; }

        public string? Code { get; set; }

        public string? Description { get; set; }

        public virtual Content Content { get; set; }

        public virtual PageSEOParameter PageSEOParameter { get; set; }

        public virtual Layout Layout { get; set; }

        public virtual ICollection<Section> Sections { get; set; }

        public virtual ICollection<PageTranslation> PageTranslations { get; set; }
    }
}
