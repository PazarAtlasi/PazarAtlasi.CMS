using MediatR;
using Microsoft.EntityFrameworkCore;
using PazarAtlasi.CMS.Persistence.Context;

namespace PazarAtlasi.CMS.Application.Features.SectionItems.Commands.Delete
{
    public class DeleteSectionItemCommandHandler : IRequestHandler<DeleteSectionItemCommand, DeleteSectionItemCommandResponse>
    {
        private readonly PazarAtlasiDbContext _context;

        public DeleteSectionItemCommandHandler(PazarAtlasiDbContext context)
        {
            _context = context;
        }

        public async Task<DeleteSectionItemCommandResponse> Handle(DeleteSectionItemCommand request, CancellationToken cancellationToken)
        {
            var response = new DeleteSectionItemCommandResponse();

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

                // Remove translations
                if (sectionItem.Translations != null && sectionItem.Translations.Any())
                {
                    _context.SectionItemTranslations.RemoveRange(sectionItem.Translations);
                }

                // Remove section item
                _context.SectionItems.Remove(sectionItem);
                await _context.SaveChangesAsync(cancellationToken);

                response.Success = true;
                response.Message = "Section item deleted successfully.";

                return response;
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = "An error occurred while deleting section item.";
                response.Errors.Add(ex.Message);
                return response;
            }
        }
    }
}

