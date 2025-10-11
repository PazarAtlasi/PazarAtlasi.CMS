using MediatR;
using Microsoft.EntityFrameworkCore;
using PazarAtlasi.CMS.Application.Features.SectionItems.Dtos;
using PazarAtlasi.CMS.Domain.Entities.Content;
using PazarAtlasi.CMS.Persistence.Context;

namespace PazarAtlasi.CMS.Application.Features.SectionItems.Commands.Create
{
    public class CreateSectionItemCommandHandler : IRequestHandler<CreateSectionItemCommand, CreateSectionItemCommandResponse>
    {
        private readonly PazarAtlasiDbContext _context;

        public CreateSectionItemCommandHandler(PazarAtlasiDbContext context)
        {
            _context = context;
        }

        public async Task<CreateSectionItemCommandResponse> Handle(CreateSectionItemCommand request, CancellationToken cancellationToken)
        {
            var response = new CreateSectionItemCommandResponse();

            try
            {
                // Check if section exists
                var sectionExists = await _context.Sections.AnyAsync(s => s.Id == request.SectionId, cancellationToken);
                if (!sectionExists)
                {
                    response.Success = false;
                    response.Message = "Section not found.";
                    response.Errors.Add("SECTION_NOT_FOUND");
                    return response;
                }

                // Create section item
                var sectionItem = new SectionItem
                {
                    Id = 0,
                    SectionId = request.SectionId,
                    Code = request.Code ?? $"item_{DateTime.UtcNow.Ticks}",
                    Type = request.Type,
                    MediaType = request.MediaType,
                    PictureUrl = request.PictureUrl,
                    VideoUrl = request.VideoUrl,
                    RedirectUrl = request.RedirectUrl,
                    Icon = request.Icon,
                    SortOrder = request.SortOrder,
                    MediaAttributes = request.MediaAttributes,
                    Status = request.Status,
                    CreatedAt = DateTime.UtcNow,
                    IsDeleted = false
                };

                _context.SectionItems.Add(sectionItem);
                await _context.SaveChangesAsync(cancellationToken);

                // Add translations
                if (request.Translations != null && request.Translations.Any())
                {
                    var translations = request.Translations.Select(t => new SectionItemTranslation
                    {
                        Id = 0,
                        SectionItemId = sectionItem.Id,
                        LanguageId = t.LanguageId,
                        Name = t.Name,
                        Title = t.Title,
                        Description = t.Description,
                        CreatedAt = DateTime.UtcNow,
                        IsDeleted = false
                    }).ToList();

                    _context.SectionItemTranslations.AddRange(translations);
                    await _context.SaveChangesAsync(cancellationToken);
                }

                // Load item with translations
                var createdItem = await _context.SectionItems
                    .Include(si => si.Translations)
                    .FirstOrDefaultAsync(si => si.Id == sectionItem.Id, cancellationToken);

                response.Success = true;
                response.Message = "Section item created successfully.";
                response.Data = MapToDto(createdItem!);

                return response;
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = "An error occurred while creating section item.";
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

