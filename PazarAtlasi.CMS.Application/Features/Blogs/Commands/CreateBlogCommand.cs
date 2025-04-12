using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using PazarAtlasi.CMS.Application.Features.Blogs.Rules;
using PazarAtlasi.CMS.Application.Interfaces;
using PazarAtlasi.CMS.Domain.Entities;

namespace PazarAtlasi.CMS.Application.Features.Blogs.Commands
{
    public class CreateBlogCommand : IRequest<int>
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public string Summary { get; set; }
        public string Slug { get; set; }
        public string FeaturedImageUrl { get; set; }
        public bool IsPublished { get; set; }
        public DateTime? PublishedDate { get; set; }
        public string MetaTitle { get; set; }
        public string MetaDescription { get; set; }
        public string MetaKeywords { get; set; }
        public int? CategoryId { get; set; }
        public int? AuthorId { get; set; }
        public int[] TagIds { get; set; }
    }
    
    public class CreateBlogCommandHandler : IRequestHandler<CreateBlogCommand, int>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly BlogBusinessRules _blogBusinessRules;
        
        public CreateBlogCommandHandler(
            IUnitOfWork unitOfWork,
            IMapper mapper,
            BlogBusinessRules blogBusinessRules)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _blogBusinessRules = blogBusinessRules;
        }
        
        public async Task<int> Handle(CreateBlogCommand request, CancellationToken cancellationToken)
        {
            // Apply business rules
            await _blogBusinessRules.BlogTitleMustBeUnique(request.Title);
            await _blogBusinessRules.CategoryMustExistIfProvided(request.CategoryId);
            await _blogBusinessRules.AuthorMustExistIfProvided(request.AuthorId);
            await _blogBusinessRules.TagsMustExist(request.TagIds);
            
            // Generate slug if not provided
            if (string.IsNullOrWhiteSpace(request.Slug))
            {
                request.Slug = request.Title.ToLower()
                    .Replace(" ", "-")
                    .Replace(".", "")
                    .Replace(",", "")
                    .Replace("!", "")
                    .Replace("?", "")
                    .Replace(":", "")
                    .Replace(";", "")
                    .Replace("'", "")
                    .Replace("\"", "");
            }
            
            // Set published date if published
            if (request.IsPublished && !request.PublishedDate.HasValue)
            {
                request.PublishedDate = DateTime.UtcNow;
            }
            
            // Create blog entity
            var blog = _mapper.Map<Blog>(request);
            await _unitOfWork.Repository<Blog>().AddAsync(blog);
            await _unitOfWork.SaveChangesAsync();
            
            // Add blog tags
            if (request.TagIds != null && request.TagIds.Any())
            {
                var blogTagRepository = _unitOfWork.Repository<BlogTag>();
                
                foreach (var tagId in request.TagIds)
                {
                    var blogTag = new BlogTag
                    {
                        BlogId = blog.Id,
                        TagId = tagId
                    };
                    
                    await blogTagRepository.AddAsync(blogTag);
                }
                
                await _unitOfWork.SaveChangesAsync();
            }
            
            return blog.Id;
        }
    }
} 