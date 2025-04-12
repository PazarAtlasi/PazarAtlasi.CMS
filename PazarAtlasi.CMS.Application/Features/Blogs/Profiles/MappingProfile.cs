using AutoMapper;
using PazarAtlasi.CMS.Application.Features.Blogs.Commands;
using PazarAtlasi.CMS.Application.Features.Blogs.Queries;
using PazarAtlasi.CMS.Domain.Entities;
using System.Linq;

namespace PazarAtlasi.CMS.Application.Features.Blogs.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Entity to DTO
            CreateMap<Blog, BlogDto>()
                .ForMember(dest => dest.CategoryName, opt => opt.MapFrom(src => src.Category != null ? src.Category.Name : null))
                .ForMember(dest => dest.AuthorName, opt => opt.MapFrom(src => src.Author != null ? src.Author.FirstName : null))
                .ForMember(dest => dest.Tags, opt => opt.MapFrom(src => src.BlogTags.Select(bt => bt.Tag)));
                
            //CreateMap<Tag, TagDto>();
            
            // Command to Entity
            CreateMap<CreateBlogCommand, Blog>()
                .ForMember(dest => dest.BlogTags, opt => opt.Ignore());
                
            CreateMap<UpdateBlogCommand, Blog>()
                .ForMember(dest => dest.BlogTags, opt => opt.Ignore())
                .ForMember(dest => dest.CreatedAt, opt => opt.Ignore());
        }
    }
} 