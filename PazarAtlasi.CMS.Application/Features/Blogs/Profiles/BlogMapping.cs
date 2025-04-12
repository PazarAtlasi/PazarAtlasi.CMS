using System.Linq;
using AutoMapper;
using PazarAtlasi.CMS.Application.Features.Blogs.Commands;
using PazarAtlasi.CMS.Application.Features.Blogs.Queries;
using PazarAtlasi.CMS.Domain.Entities;

namespace PazarAtlasi.CMS.Application.Features.Blogs.Profiles
{
    public class BlogMapping : Profile
    {
        public BlogMapping()
        {
            // Entity to DTO
            CreateMap<Blog, BlogDto>()
                .ForMember(dest => dest.CategoryName, opt => opt.MapFrom(src => src.Category != null ? src.Category.Name : null))
                .ForMember(dest => dest.AuthorName, opt => opt.MapFrom(src => src.Author != null ? src.Author.FirstName : null))
                .ForMember(dest => dest.AuthorImageUrl, opt => opt.MapFrom(src => src.Author != null ? src.Author.ImageUrl : null))
                .ForMember(dest => dest.Tags, opt => opt.MapFrom(src => 
                    src.BlogTags.Select(bt => new BlogTagDto
                    {
                        Id = bt.Tag.Id,
                        Name = bt.Tag.Name,
                        Slug = bt.Tag.Slug
                    }).ToList()));
                    
            // CreateBlogCommand to Entity
            CreateMap<CreateBlogCommand, Blog>()
                .ForMember(dest => dest.BlogTags, opt => opt.Ignore())
                .ForMember(dest => dest.CreatedAt, opt => opt.MapFrom(src => System.DateTime.UtcNow));
                
            // UpdateBlogCommand to Entity
            CreateMap<UpdateBlogCommand, Blog>()
                .ForMember(dest => dest.BlogTags, opt => opt.Ignore())
                .ForMember(dest => dest.UpdatedAt, opt => opt.MapFrom(src => System.DateTime.UtcNow));
        }
    }
} 