using System;

namespace PazarAtlasi.CMS.Application.Features.WebUrls.Queries.GetWebUrlById
{
    public class WebUrlDto
    {
        public int Id { get; set; }
        public required string Slug { get; set; }
        public required string OriginalUrl { get; set; }
        public required string TargetUrl { get; set; }
        public bool IsActive { get; set; }
        public bool IsPermanent { get; set; }
        public DateTime? ExpiryDate { get; set; }
        public required string Notes { get; set; }
        public required string Category { get; set; }
        public int Priority { get; set; }
        public int RedirectCount { get; set; }
        public DateTime CreatedAt { get; set; }
        public required string CreatedBy { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public required string UpdatedBy { get; set; }
    }
}