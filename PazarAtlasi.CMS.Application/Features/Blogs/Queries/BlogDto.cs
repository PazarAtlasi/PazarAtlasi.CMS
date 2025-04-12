using System;
using System.Collections.Generic;

namespace PazarAtlasi.CMS.Application.Features.Blogs.Queries
{
    public class BlogDto
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
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        
        public int? CategoryId { get; set; }
        public string CategoryName { get; set; }
        
        public int? AuthorId { get; set; }
        public string AuthorName { get; set; }
        public string AuthorImageUrl { get; set; }
        
        public List<BlogTagDto> Tags { get; set; } = new List<BlogTagDto>();
    }
    
    public class BlogTagDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Slug { get; set; }
    }
} 