using MediatR;
using PazarAtlasi.CMS.Application.Features.SectionItems.Dtos;

namespace PazarAtlasi.CMS.Application.Features.SectionItems.Queries.GetById
{
    public class GetSectionItemByIdQuery : IRequest<GetSectionItemByIdQueryResponse>
    {
        public int Id { get; set; }
    }

    public class GetSectionItemByIdQueryResponse
    {
        public bool Success { get; set; }
        public string Message { get; set; } = string.Empty;
        public SectionItemDto? Data { get; set; }
        public List<string> Errors { get; set; } = new();
    }
}

