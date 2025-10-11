using MediatR;
using PazarAtlasi.CMS.Application.Features.SectionItems.Dtos;
using PazarAtlasi.CMS.Domain.Common;

namespace PazarAtlasi.CMS.Application.Features.SectionItems.Commands.Create
{
    public class CreateSectionItemCommand : IRequest<CreateSectionItemCommandResponse>
    {
        public int SectionId { get; set; }
        public string? Code { get; set; }
        public SectionItemType Type { get; set; }
        public MediaType MediaType { get; set; }
        public string? PictureUrl { get; set; }
        public string? VideoUrl { get; set; }
        public string? RedirectUrl { get; set; }
        public string? Icon { get; set; }
        public int SortOrder { get; set; }
        public string? MediaAttributes { get; set; }
        public Status Status { get; set; }
        public List<CreateSectionItemTranslationDto> Translations { get; set; } = new();
    }

    public class CreateSectionItemTranslationDto
    {
        public int LanguageId { get; set; }
        public string Name { get; set; } = string.Empty;
        public string? Title { get; set; }
        public string? Description { get; set; }
    }

    public class CreateSectionItemCommandResponse
    {
        public bool Success { get; set; }
        public string Message { get; set; } = string.Empty;
        public SectionItemDto? Data { get; set; }
        public List<string> Errors { get; set; } = new();
    }
}

