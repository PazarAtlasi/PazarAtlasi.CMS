using MediatR;
using Microsoft.EntityFrameworkCore;
using PazarAtlasi.CMS.Application.Features.SectionItems.Dtos;
using PazarAtlasi.CMS.Domain.Entities.Content;
using PazarAtlasi.CMS.Persistence.Context;

namespace PazarAtlasi.CMS.Application.Features.SectionItems.Queries.GetById
{
    public class GetSectionItemByIdQueryHandler : IRequestHandler<GetSectionItemByIdQuery, GetSectionItemByIdQueryResponse>
    {
        private readonly PazarAtlasiDbContext _context;

        public GetSectionItemByIdQueryHandler(PazarAtlasiDbContext context)
        {
            _context = context;
        }

        public async Task<GetSectionItemByIdQueryResponse> Handle(GetSectionItemByIdQuery request, CancellationToken cancellationToken)
        {
            var response = new GetSectionItemByIdQueryResponse();

            try
            {
                var sectionItem = await _context.SectionItems
                    .Include(si => si.Translations)
                    .FirstOrDefaultAsync(si => si.Id == request.Id && !si.IsDeleted, cancellationToken);

                if (sectionItem == null)
                {
                    response.Success = false;
                    response.Message = "Section item not found.";
                    response.Errors.Add("SECTION_ITEM_NOT_FOUND");
                    return response;
                }

                response.Success = true;
                response.Message = "Section item retrieved successfully.";
                response.Data = MapToDto(sectionItem);

                return response;
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = "An error occurred while retrieving section item.";
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

