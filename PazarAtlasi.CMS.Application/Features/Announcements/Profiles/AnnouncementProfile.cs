using AutoMapper;
using PazarAtlasi.CMS.Application.Features.Announcements.Resources;
using PazarAtlasi.CMS.Domain.Entities;

namespace PazarAtlasi.CMS.Application.Features.Announcements.Profiles;

public class AnnouncementProfile : Profile
{
    public AnnouncementProfile()
    {
        CreateMap<Announcement, AnnouncementResource>();
    }
} 