using AutoMapper;
using MediatR;
using PazarAtlasi.CMS.Application.Interfaces.Repositories;
using PazarAtlasi.CMS.Domain.Entities;

namespace PazarAtlasi.CMS.Application.Features.Announcements.Commands;

public class CreateAnnouncementCommandHandler : IRequestHandler<CreateAnnouncementCommand, CreateAnnouncementResponse>
{
    private readonly IAnnouncementRepository _announcementRepository;
    private readonly IMapper _mapper;

    public CreateAnnouncementCommandHandler(IAnnouncementRepository announcementRepository, IMapper mapper)
    {
        _announcementRepository = announcementRepository;
        _mapper = mapper;
    }

    public async Task<CreateAnnouncementResponse> Handle(CreateAnnouncementCommand request, CancellationToken cancellationToken)
    {
        var announcement = new Announcement
        {
            Title = request.Title,
            Content = request.Content,
            PublishDate = request.PublishDate,
            IsActive = request.IsActive,
            CreatedAt = DateTime.UtcNow,
            CreatedBy = "System", // TODO: Get from current user
            UpdatedAt = DateTime.UtcNow,
            UpdatedBy = "System" // TODO: Get from current user
        };

        await _announcementRepository.AddAsync(announcement);

        return new CreateAnnouncementResponse
        {
            Id = announcement.Id,
            Title = announcement.Title,
            Content = announcement.Content,
            PublishDate = announcement.PublishDate,
            IsActive = announcement.IsActive,
            IsSuccess = true,
            Message = "Duyuru başarıyla oluşturuldu."
        };
    }
} 