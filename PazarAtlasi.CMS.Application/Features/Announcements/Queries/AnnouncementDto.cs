namespace PazarAtlasi.CMS.Application.Features.Announcements.Queries;

public class AnnouncementDto
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Content { get; set; }
    public DateTime PublishDate { get; set; }
    public bool IsActive { get; set; }
} 