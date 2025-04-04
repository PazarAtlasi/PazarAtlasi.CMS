using AutoMapper;
using MediatR;
using PazarAtlasi.CMS.Application.Features.Announcements.Resources;
using PazarAtlasi.CMS.Application.Interfaces.Repositories;

namespace PazarAtlasi.CMS.Application.Features.Announcements.Queries;

public class GetAnnouncementsQueryHandler : IRequestHandler<GetAnnouncementsQuery, List<AnnouncementResource>>
{
    private readonly IAnnouncementRepository _announcementRepository;
    private readonly IMapper _mapper;

    public GetAnnouncementsQueryHandler(IAnnouncementRepository announcementRepository, IMapper mapper)
    {
        _announcementRepository = announcementRepository;
        _mapper = mapper;
    }

    public async Task<List<AnnouncementResource>> Handle(GetAnnouncementsQuery request, CancellationToken cancellationToken)
    {
        var announcements = await _announcementRepository.GetAllAsync();
        return _mapper.Map<List<AnnouncementResource>>(announcements);
    }
} 