using MediatR;

namespace PazarAtlasi.CMS.Application.Features.SectionItems.Commands.Delete
{
    public class DeleteSectionItemCommand : IRequest<DeleteSectionItemCommandResponse>
    {
        public int Id { get; set; }
    }

    public class DeleteSectionItemCommandResponse
    {
        public bool Success { get; set; }
        public string Message { get; set; } = string.Empty;
        public List<string> Errors { get; set; } = new();
    }
}

