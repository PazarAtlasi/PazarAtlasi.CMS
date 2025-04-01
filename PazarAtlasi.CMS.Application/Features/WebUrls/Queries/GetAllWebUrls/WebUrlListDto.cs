using System;

namespace PazarAtlasi.CMS.Application.Features.WebUrls.Queries.GetAllWebUrls
{
    public class WebUrlListDto
    {
        public int Id { get; set; }
        public string Slug { get; set; }
        public string TargetUrl { get; set; }
        public bool IsActive { get; set; }
        public bool IsPermanent { get; set; }
        public DateTime? ExpiryDate { get; set; }
        public int RedirectCount { get; set; }
        public string Category { get; set; }
        public int Priority { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}