using System;
using System.ComponentModel.DataAnnotations;
using PazarAtlasi.CMS.Domain.Common;
using PazarAtlasi.CMS.Domain.Identity;

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

        [MaxLength(200)]
        public string ImageUrl { get; set; }

        [MaxLength(100)]
        public string Topic { get; set; }

        public DateTime PublishDate { get; set; }

        public bool IsActive { get; set; }

        public string AuthorId { get; set; }
        public string AuthorName { get; set; }
        public ApplicationUser Author { get; set; }
    }
} 