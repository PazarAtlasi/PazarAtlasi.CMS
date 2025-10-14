using PazarAtlasi.CMS.Domain.Common;

namespace PazarAtlasi.CMS.Domain.Entities.Content
{
    public class Layout : Entity<int>
    {
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public bool IsDefault { get; set; } = false;
        
        // Navigation properties
        public virtual ICollection<LayoutSection> LayoutSections { get; set; } = new List<LayoutSection>();
        public virtual ICollection<Page> Pages { get; set; } = new List<Page>();
    }
}
