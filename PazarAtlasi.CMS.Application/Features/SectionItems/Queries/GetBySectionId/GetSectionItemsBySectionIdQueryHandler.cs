using MediatR;
using Microsoft.EntityFrameworkCore;
using PazarAtlasi.CMS.Application.Features.SectionItems.Dtos;
using PazarAtlasi.CMS.Domain.Entities.Content;
using PazarAtlasi.CMS.Persistence.Context;

namespace PazarAtlasi.CMS.Application.Features.SectionItems.Queries.GetBySectionId
{
    public class GetSectionItemsBySectionIdQueryHandler : IRequestHandler<GetSectionItemsBySectionIdQuery, GetSectionItemsBySectionIdQueryResponse>
    {
        private readonly PazarAtlasiDbContext _context;

        public GetSectionItemsBySectionIdQueryHandler(PazarAtlasiDbContext context)
        {
            _context = context;
        }

        public async Task<GetSectionItemsBySectionIdQueryResponse> Handle(GetSectionItemsBySectionIdQuery request, CancellationToken cancellationToken)
        {
            var response = new GetSectionItemsBySectionIdQueryResponse();

            try
            {
                var sectionItems = await _context.SectionItems
                    .Include(si => si.Translations)
                    .Where(si => si.SectionId == request.SectionId && !si.IsDeleted)
                    .OrderBy(si => si.SortOrder)
                    .ToListAsync(cancellationToken);

                response.Success = true;
                response.Message = "Section items retrieved successfully.";
                response.Data = sectionItems.Select(MapToDto).ToList();

                return response;
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = "An error occurred while retrieving section items.";
                response.Errors.Add(ex.Message);
                return response;
            }
        }

        private SectionItemDto MapToDto(SectionItem item)
        {
            return new SectionItemDto
            {
                Id = item.Id,
                SectionId = item.SectionId,
                Code = item.Code,
                Type = item.Type,
                MediaType = item.MediaType,
                PictureUrl = item.PictureUrl,
                VideoUrl = item.VideoUrl,
                RedirectUrl = item.RedirectUrl,
                Icon = item.Icon,
                SortOrder = item.SortOrder,
                MediaAttributes = item.MediaAttributes,
                Status = item.Status,
                Translations = item.Translations?.Select(t => new SectionItemTranslationDto
                {
                    Id = t.Id,
                    SectionItemId = t.SectionItemId,
                    LanguageId = t.LanguageId,
                    Name = t.Name,
                    Title = t.Title,
                    Description = t.Description
                }).ToList() ?? new List<SectionItemTranslationDto>()
            };
        }
    }
}

