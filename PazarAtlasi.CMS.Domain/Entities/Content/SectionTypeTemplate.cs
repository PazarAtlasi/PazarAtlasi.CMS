using PazarAtlasi.CMS.Domain.Common;

namespace PazarAtlasi.CMS.Domain.Entities.Content
{
    public class SectionTypeTemplate : Entity<int>
    {
        public SectionType SectionType { get; set; }

        public int TemplateId { get; set; }
        
        public string? CustomConfiguration { get; set; } // JSON configuration specific to this section-template combination
        
        public virtual Template Template { get; set; } = null!;
    }
}
