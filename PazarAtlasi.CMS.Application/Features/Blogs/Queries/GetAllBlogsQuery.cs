using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using PazarAtlasi.CMS.Application.Common.Models;
using PazarAtlasi.CMS.Application.Interfaces;
using PazarAtlasi.CMS.Domain.Entities;

namespace PazarAtlasi.CMS.Application.Features.Blogs.Queries
{
    public class GetAllBlogsQuery : IRequest<PaginatedList<BlogDto>>
    {
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 10;
        public string SearchTerm { get; set; }
        public int? CategoryId { get; set; }
        public int? AuthorId { get; set; }
        public bool? IsPublished { get; set; }
        public DateTime? FromDate { get; set; }
        public DateTime? ToDate { get; set; }
        public string SortBy { get; set; } = "CreatedAt";
        public bool SortDesc { get; set; } = true;
    }
    
    public class GetAllBlogsQueryHandler : IRequestHandler<GetAllBlogsQuery, PaginatedList<BlogDto>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        
        public GetAllBlogsQueryHandler(
            IUnitOfWork unitOfWork,
            IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        
        public async Task<PaginatedList<BlogDto>> Handle(GetAllBlogsQuery request, CancellationToken cancellationToken)
        {
            var blogRepository = _unitOfWork.Repository<Blog>();
            var query = blogRepository.GetQueryable()
                .Include(b => b.Category)
                .Include(b => b.Author)
                .Include(b => b.BlogTags)
                .ThenInclude(bt => bt.Tag)
                .AsQueryable();
                
            // Apply filters
            if (!string.IsNullOrEmpty(request.SearchTerm))
            {
                var searchTerm = request.SearchTerm.ToLower();
                query = query.Where(b => 
                    b.Title.ToLower().Contains(searchTerm) ||
                    b.Content.ToLower().Contains(searchTerm) ||
                    b.Summary.ToLower().Contains(searchTerm) ||
                    b.MetaKeywords.ToLower().Contains(searchTerm));
            }
            
            if (request.CategoryId.HasValue)
            {
                query = query.Where(b => b.CategoryId == request.CategoryId.Value);
            }
            
            if (request.AuthorId.HasValue)
            {
                query = query.Where(b => b.AuthorId == request.AuthorId.Value);
            }
            
            if (request.IsPublished.HasValue)
            {
                query = query.Where(b => b.IsPublished == request.IsPublished.Value);
            }
            
            if (request.FromDate.HasValue)
            {
                query = query.Where(b => b.CreatedAt >= request.FromDate.Value);
            }
            
            if (request.ToDate.HasValue)
            {
                query = query.Where(b => b.CreatedAt <= request.ToDate.Value);
            }
            
            // Apply sorting
            query = ApplySorting(query, request.SortBy, request.SortDesc);
            
            // Get total count
            var totalCount = await query.CountAsync();
            
            // Apply pagination
            var blogs = await query
                .Skip((request.PageNumber - 1) * request.PageSize)
                .Take(request.PageSize)
                .ToListAsync();
            
            // Map to DTOs
            var blogDtos = _mapper.Map<List<BlogDto>>(blogs);
            
            return new PaginatedList<BlogDto>(
                blogDtos,
                totalCount,
                request.PageNumber,
                request.PageSize);
        }
        
        private IQueryable<Blog> ApplySorting(IQueryable<Blog> query, string sortBy, bool sortDesc)
        {
            return sortBy.ToLower() switch
            {
                "title" => sortDesc 
                    ? query.OrderByDescending(b => b.Title) 
                    : query.OrderBy(b => b.Title),
                    
                "publisheddate" => sortDesc 
                    ? query.OrderByDescending(b => b.PublishedDate) 
                    : query.OrderBy(b => b.PublishedDate),
                    
                "updatedat" => sortDesc 
                    ? query.OrderByDescending(b => b.UpdatedAt) 
                    : query.OrderBy(b => b.UpdatedAt),
                    
                _ => sortDesc 
                    ? query.OrderByDescending(b => b.CreatedAt) 
                    : query.OrderBy(b => b.CreatedAt)
            };
        }
    }
} 