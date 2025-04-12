using System;
using System.Collections.Generic;

namespace PazarAtlasi.CMS.Domain.Entities
{
    public class Blog : BaseEntity
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public string Summary { get; set; }
        public string FeaturedImageUrl { get; set; }
        public bool IsPublished { get; set; }
        public DateTime? PublishedDate { get; set; }
        public string Slug { get; set; }
        public string MetaTitle { get; set; }
        public string MetaDescription { get; set; }
        public string MetaKeywords { get; set; }
        
        public int? CategoryId { get; set; }
        public Category Category { get; set; }
        
        public int? AuthorId { get; set; }
        public User Author { get; set; }
        
        public ICollection<BlogTag> BlogTags { get; set; }
        
        public Blog()
        {
            BlogTags = new HashSet<BlogTag>();
            IsPublished = false;
        }
    }
} 