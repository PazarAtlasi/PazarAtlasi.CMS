using MediatR;
using Microsoft.EntityFrameworkCore;
using PazarAtlasi.CMS.Application.Features.SectionItems.Dtos;
using PazarAtlasi.CMS.Domain.Entities.Content;
using PazarAtlasi.CMS.Persistence.Context;

namespace PazarAtlasi.CMS.Application.Features.SectionItems.Commands.Update
{
    public class UpdateSectionItemCommandHandler : IRequestHandler<UpdateSectionItemCommand, UpdateSectionItemCommandResponse>
    {
        private readonly PazarAtlasiDbContext _context;

        public UpdateSectionItemCommandHandler(PazarAtlasiDbContext context)
        {
            _context = context;
        }

        public async Task<UpdateSectionItemCommandResponse> Handle(UpdateSectionItemCommand request, CancellationToken cancellationToken)
        {
            var response = new UpdateSectionItemCommandResponse();

            try
            {
                var sectionItem = await _context.SectionItems
                    .Include(si => si.Translations)
                    .FirstOrDefaultAsync(si => si.Id == request.Id, cancellationToken);

                if (sectionItem == null)
                {
                    response.Success = false;
                    response.Message = "Section item not found.";
                    response.Errors.Add("SECTION_ITEM_NOT_FOUND");
                    return response;
                }

                // Update section item properties
                sectionItem.Code = request.Code;
                sectionItem.Type = request.Type;
                sectionItem.MediaType = request.MediaType;
                sectionItem.PictureUrl = request.PictureUrl;
                sectionItem.VideoUrl = request.VideoUrl;
                sectionItem.RedirectUrl = request.RedirectUrl;
                sectionItem.Icon = request.Icon;
                sectionItem.SortOrder = request.SortOrder;
                sectionItem.MediaAttributes = request.MediaAttributes;
                sectionItem.Status = request.Status;
                sectionItem.UpdatedAt = DateTime.UtcNow;

                // Update translations
                if (request.Translations != null && request.Translations.Any())
                {
                    foreach (var translationDto in request.Translations)
                    {
                        var existingTranslation = sectionItem.Translations?
                            .FirstOrDefault(t => t.Id == translationDto.Id || t.LanguageId == translationDto.LanguageId);

                        if (existingTranslation != null)
                        {
                            // Update existing translation
                            existingTranslation.Name = translationDto.Name;
                            existingTranslation.Title = translationDto.Title;
                            existingTranslation.Description = translationDto.Description;
                            existingTranslation.UpdatedAt = DateTime.UtcNow;
                        }
                        else
                        {
                            // Add new translation
                            var newTranslation = new SectionItemTranslation
                            {
                                Id = 0,
                                SectionItemId = sectionItem.Id,
                                LanguageId = translationDto.LanguageId,
                                Name = translationDto.Name,
                                Title = translationDto.Title,
                                Description = translationDto.Description,
                                CreatedAt = DateTime.UtcNow,
                                IsDeleted = false
                            };
                            _context.SectionItemTranslations.Add(newTranslation);
                        }
                    }
                }

                await _context.SaveChangesAsync(cancellationToken);

                // Reload with translations
                var updatedItem = await _context.SectionItems
                    .Include(si => si.Translations)
                    .FirstOrDefaultAsync(si => si.Id == sectionItem.Id, cancellationToken);

                response.Success = true;
                response.Message = "Section item updated successfully.";
                response.Data = MapToDto(updatedItem!);

                return response;
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = "An error occurred while updating section item.";
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

