using System;
using System.Collections.Generic;

namespace PazarAtlasi.CMS.Domain.Entities
{
    public class WebUrl : BaseEntity
    {
        public string Slug { get; set; }
        public string OriginalUrl { get; set; }
        public string TargetUrl { get; set; }
        public bool IsActive { get; set; } = true;
        public bool IsPermanent { get; set; } = false;
        public DateTime? ExpiryDate { get; set; }
        public int RedirectCount { get; set; } = 0;
        public string Notes { get; set; }
        public string Category { get; set; }
        public int Priority { get; set; } = 1;
    }
}