using System;
using MediatR;

namespace PazarAtlasi.CMS.Application.Features.WebUrls.Commands.CreateWebUrl
{
    public class CreateWebUrlCommand : IRequest<CreateWebUrlResponse>
    {
        public required string Slug { get; set; }
        public required string OriginalUrl { get; set; }
        public required string TargetUrl { get; set; }
        public bool IsActive { get; set; } = true;
        public bool IsPermanent { get; set; }
        public DateTime? ExpiryDate { get; set; }
        public required string Notes { get; set; }
        public required string Category { get; set; }
        public int Priority { get; set; } = 1;
    }
}