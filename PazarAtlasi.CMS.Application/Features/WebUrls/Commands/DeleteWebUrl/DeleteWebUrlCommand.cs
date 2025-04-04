using MediatR;

namespace PazarAtlasi.CMS.Application.Features.WebUrls.Commands.DeleteWebUrl
{
    public class DeleteWebUrlCommand : IRequest<DeleteWebUrlResponse>
    {
        public int Id { get; set; }
    }
}