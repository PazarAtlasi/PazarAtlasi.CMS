using System;

namespace PazarAtlasi.CMS.Domain.Entities
{
    public class Blog : BaseEntity
    {
        [Required]
        [MaxLength(200)]
        public string Title { get; set; }

        [Required]
        public string Content { get; set; }

        [MaxLength(500)]
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
        [MaxLength(200)]
        public string ImageUrl { get; set; }

        [MaxLength(100)]
        public string Topic { get; set; }

        public int? AuthorId { get; set; }
        public User Author { get; set; }
        public DateTime PublishDate { get; set; }

        public ICollection<BlogTag> BlogTags { get; set; }
        public bool IsActive { get; set; }

        public Blog()
        {
            BlogTags = new HashSet<BlogTag>();
            IsPublished = false;
        }
        public string AuthorId { get; set; }
        public string AuthorName { get; set; }
        public ApplicationUser Author { get; set; }
    }
} 