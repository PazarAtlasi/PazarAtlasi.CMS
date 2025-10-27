using PazarAtlasi.CMS.Domain.Common;
using PazarAtlasi.CMS.Domain.Entities.Content;

namespace PazarAtlasi.CMS.Domain.Entities.Announcement
{
    public class Announcement : Entity<int>
    {
        public Announcement()
        {
            CreatedAt = DateTime.UtcNow;
            Translations = new HashSet<AnnouncementTranslation>();
        }

        public string Title { get; set; } = string.Empty;
        
        public string Content { get; set; } = string.Empty;
        
        public string? Summary { get; set; }
        
        public string? CoverImage { get; set; }
        
        public DateTime PublishStart { get; set; }
        
        public DateTime PublishEnd { get; set; }
        
        public string? CreatedByName { get; set; }

        // Navigation properties
        public virtual ICollection<AnnouncementTranslation> Translations { get; set; }
    }
}