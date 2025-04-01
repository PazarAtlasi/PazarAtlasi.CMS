using MediatR;

namespace PazarAtlasi.CMS.Application.Features.WebUrls.Queries.GetWebUrlById
{
    public class GetWebUrlByIdQuery : IRequest<WebUrlDto>
    {
        public int Id { get; set; }
    }
}