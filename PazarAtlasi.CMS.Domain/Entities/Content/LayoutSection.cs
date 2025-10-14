using PazarAtlasi.CMS.Domain.Common;

namespace PazarAtlasi.CMS.Domain.Entities.Content
{
    public class LayoutSection : Entity<int>
    {
        public int LayoutId { get; set; }
        public int SectionId { get; set; }
        public int SortOrder { get; set; } = 0;
        public bool IsRequired { get; set; } = false;
        public string Position { get; set; } = string.Empty; // "header", "content", "footer", "sidebar"
        
        // Navigation properties
        public virtual Layout Layout { get; set; } = null!;
        public virtual Section Section { get; set; } = null!;
    }
}
