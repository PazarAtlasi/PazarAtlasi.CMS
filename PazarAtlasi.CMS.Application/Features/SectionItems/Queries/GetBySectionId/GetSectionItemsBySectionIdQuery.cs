using MediatR;
using PazarAtlasi.CMS.Application.Features.SectionItems.Dtos;

namespace PazarAtlasi.CMS.Application.Features.SectionItems.Queries.GetBySectionId
{
    public class GetSectionItemsBySectionIdQuery : IRequest<GetSectionItemsBySectionIdQueryResponse>
    {
        public int SectionId { get; set; }
    }

    public class GetSectionItemsBySectionIdQueryResponse
    {
        public bool Success { get; set; }
        public string Message { get; set; } = string.Empty;
        public List<SectionItemDto> Data { get; set; } = new();
        public List<string> Errors { get; set; } = new();
    }
}

