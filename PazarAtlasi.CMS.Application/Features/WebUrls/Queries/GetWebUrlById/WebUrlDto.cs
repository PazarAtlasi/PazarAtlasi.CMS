using System;

namespace PazarAtlasi.CMS.Application.Features.WebUrls.Queries.GetWebUrlById
{
    public class WebUrlDto
    {
        public int Id { get; set; }
        public string Slug { get; set; }
        public string OriginalUrl { get; set; }
        public string TargetUrl { get; set; }
        public bool IsActive { get; set; }
        public bool IsPermanent { get; set; }
        public DateTime? ExpiryDate { get; set; }
        public int RedirectCount { get; set; }
        public string Notes { get; set; }
        public string Category { get; set; }
        public int Priority { get; set; }
        public DateTime CreatedAt { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public string UpdatedBy { get; set; }
    }
}