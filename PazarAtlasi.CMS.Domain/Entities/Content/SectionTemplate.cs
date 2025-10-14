using PazarAtlasi.CMS.Domain.Common;

namespace PazarAtlasi.CMS.Domain.Entities.Content
{
    public class SectionTemplate : Entity<int>
    {
        public int SectionId { get; set; }
        public int TemplateId { get; set; }
        public string? CustomConfiguration { get; set; } // JSON configuration specific to this section-template combination

        // Navigation properties
        public virtual Section Section { get; set; } = null!;
        public virtual Template Template { get; set; } = null!;
    }
}
