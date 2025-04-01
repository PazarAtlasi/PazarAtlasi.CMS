using System.Collections.Generic;
using MediatR;

namespace PazarAtlasi.CMS.Application.Features.WebUrls.Queries.GetAllWebUrls
{
    public class GetAllWebUrlsQuery : IRequest<List<WebUrlListDto>>
    {
        public string Category { get; set; }
        public bool? IsActive { get; set; }
    }
}