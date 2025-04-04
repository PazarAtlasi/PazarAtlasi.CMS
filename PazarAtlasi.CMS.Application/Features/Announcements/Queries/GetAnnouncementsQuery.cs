using MediatR;
using PazarAtlasi.CMS.Application.Features.Announcements.Resources;

namespace PazarAtlasi.CMS.Application.Features.Announcements.Queries;

public class GetAnnouncementsQuery : IRequest<List<AnnouncementResource>>
{
} 