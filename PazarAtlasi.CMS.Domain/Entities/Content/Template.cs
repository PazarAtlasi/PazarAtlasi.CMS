using PazarAtlasi.CMS.Domain.Common;

namespace PazarAtlasi.CMS.Domain.Entities.Content
{
    public class Template : Entity<int>
    {
        public string Name { get; set; } = string.Empty;
        
        public string? Description { get; set; }
        
        public TemplateType TemplateType { get; set; } // Template type for rendering behavior
        
        public string TemplateKey { get; set; } = string.Empty; // Unique identifier for template (e.g., "navbar-megamenu", "navbar-simple")
        
        public string? ConfigurationSchema { get; set; } // JSON schema for template configuration
        
        public bool IsActive { get; set; } = true;
        
        public int SortOrder { get; set; } = 0;
        
        // Navigation properties
        public virtual ICollection<SectionItem> SectionItems { get; set; } = new List<SectionItem>();
        
        public virtual ICollection<SectionTypeTemplate> SectionTypeTemplates { get; set; } = new List<SectionTypeTemplate>();

        public virtual ICollection<SectionItemTypeTemplate> SectionItemTypeTemplates { get; set; } = new List<SectionItemTypeTemplate>();
    }
}
