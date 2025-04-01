using AutoMapper;
using PazarAtlasi.CMS.Application.Features.WebUrls.Commands.CreateWebUrl;
using PazarAtlasi.CMS.Application.Features.WebUrls.Commands.UpdateWebUrl;
using PazarAtlasi.CMS.Application.Features.WebUrls.Queries.GetAllWebUrls;
using PazarAtlasi.CMS.Application.Features.WebUrls.Queries.GetWebUrlById;
using PazarAtlasi.CMS.Domain.Entities;

namespace PazarAtlasi.CMS.Application.Features.WebUrls.Profiles
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            // Entity to DTO mappings
            CreateMap<WebUrl, WebUrlDto>();
            CreateMap<WebUrl, WebUrlListDto>();

            // Command to Entity mappings
            CreateMap<CreateWebUrlCommand, WebUrl>();
            CreateMap<UpdateWebUrlCommand, WebUrl>();
        }
    }
}