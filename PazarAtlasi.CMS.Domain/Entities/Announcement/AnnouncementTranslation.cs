using PazarAtlasi.CMS.Domain.Common;
using PazarAtlasi.CMS.Domain.Entities.Content;

namespace PazarAtlasi.CMS.Domain.Entities.Announcement
{
    public class AnnouncementTranslation : Entity<int>
    {
        public AnnouncementTranslation()
        {
            CreatedAt = DateTime.UtcNow;
        }

        public int AnnouncementId { get; set; }
        
        public int LanguageId { get; set; }
        
        public string Title { get; set; } = string.Empty;
        
        public string Content { get; set; } = string.Empty;
        
        public string? Summary { get; set; }

        // Navigation properties
        public virtual Announcement Announcement { get; set; }
        
        public virtual Language Language { get; set; }
    }
}