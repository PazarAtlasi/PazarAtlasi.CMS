using PazarAtlasi.CMS.Domain.Common;

namespace PazarAtlasi.CMS.Domain.Entities.Announcement
{
    public class Announcement : Entity<int>
    {
        public string Title { get; set; } = string.Empty;
        
        public string Content { get; set; } = string.Empty;
        
        public string? Summary { get; set; }
        
        public string? CoverImage { get; set; }
        
        public DateTime PublishStart { get; set; }
        
        public DateTime PublishEnd { get; set; }
    }
}