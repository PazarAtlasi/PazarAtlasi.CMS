using System;
using MediatR;

namespace PazarAtlasi.CMS.Application.Features.WebUrls.Commands.CreateWebUrl
{
    public class CreateWebUrlCommand : IRequest<CreateWebUrlResponse>
    {
        public string Slug { get; set; }
        public string OriginalUrl { get; set; }
        public string TargetUrl { get; set; }
        public bool IsActive { get; set; } = true;
        public bool IsPermanent { get; set; }
        public DateTime? ExpiryDate { get; set; }
        public string Notes { get; set; }
        public string Category { get; set; }
        public int Priority { get; set; } = 1;
    }
}