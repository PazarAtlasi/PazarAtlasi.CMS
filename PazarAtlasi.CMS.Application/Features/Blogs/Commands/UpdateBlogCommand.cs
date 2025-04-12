using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using PazarAtlasi.CMS.Application.Features.Blogs.Rules;
using PazarAtlasi.CMS.Application.Interfaces;
using PazarAtlasi.CMS.Domain.Entities;

namespace PazarAtlasi.CMS.Application.Features.Blogs.Commands
{
    public class UpdateBlogCommand : IRequest<Unit>
    {
        public int Id { get; set; }
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
    
    public class UpdateBlogCommandHandler : IRequestHandler<UpdateBlogCommand, Unit>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly BlogBusinessRules _blogBusinessRules;
        
        public UpdateBlogCommandHandler(
            IUnitOfWork unitOfWork,
            IMapper mapper,
            BlogBusinessRules blogBusinessRules)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _blogBusinessRules = blogBusinessRules;
        }
        
        public async Task<Unit> Handle(UpdateBlogCommand request, CancellationToken cancellationToken)
        {
            // Apply business rules
            var blog = await _blogBusinessRules.BlogMustExist(request.Id);
            await _blogBusinessRules.BlogTitleMustBeUnique(request.Title, request.Id);
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
            
            // Update published date if needed
            if (request.IsPublished && !blog.IsPublished)
            {
                request.PublishedDate = DateTime.UtcNow;
            }
            else if (!request.IsPublished)
            {
                request.PublishedDate = null;
            }
            
            // Update blog entity
            _mapper.Map(request, blog);
            blog.UpdatedAt = DateTime.UtcNow;
            
            var blogRepository = _unitOfWork.Repository<Blog>();
            blogRepository.Update(blog);
            
            // Update blog tags
            await UpdateBlogTags(blog.Id, request.TagIds);
            
            await _unitOfWork.SaveChangesAsync();
            
            return Unit.Value;
        }
        
        private async Task UpdateBlogTags(int blogId, int[] tagIds)
        {
            var blogTagRepository = _unitOfWork.Repository<BlogTag>();
            
            // Get existing blog tags
            var existingBlogTags = await blogTagRepository
                .GetQueryable()
                .Where(bt => bt.BlogId == blogId)
                .ToListAsync();
                
            // Remove tags that are no longer associated
            var tagsToRemove = existingBlogTags
                .Where(bt => tagIds == null || !tagIds.Contains(bt.TagId))
                .ToList();
                
            foreach (var tagToRemove in tagsToRemove)
            {
                blogTagRepository.Delete(tagToRemove);
            }
            
            // Add new tags
            if (tagIds != null)
            {
                var existingTagIds = existingBlogTags.Select(bt => bt.TagId).ToList();
                var newTagIds = tagIds.Except(existingTagIds).ToList();
                
                foreach (var tagId in newTagIds)
                {
                    await blogTagRepository.AddAsync(new BlogTag
                    {
                        BlogId = blogId,
                        TagId = tagId
                    });
                }
            }
        }
    }
} 