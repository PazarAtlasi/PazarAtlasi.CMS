using AutoMapper;
using PazarAtlasi.CMS.Application.Features.MenuItems.Commands.CreateMenuItem;
using PazarAtlasi.CMS.Domain.Entities.Content;

namespace PazarAtlasi.CMS.Application.Features.MenuItems.Profiles
{
    public class MenuItemMappingProfile : Profile
    {
        public MenuItemMappingProfile()
        {
            CreateMap<MenuItem, CreateMenuItemResponse>()
                .ForMember(dest => dest.Type, opt => opt.MapFrom(src => src.Type.ToString()));
            
            // Add more mappings for other DTOs as needed
        }
    }
} 