using MediatR;

namespace PazarAtlasi.CMS.Application.Features.Announcements.Commands;

public class CreateAnnouncementCommand : IRequest<CreateAnnouncementResponse>
{
    public required string Title { get; set; }
    public required string Content { get; set; }
    public DateTime PublishDate { get; set; }
    public bool IsActive { get; set; }
} 