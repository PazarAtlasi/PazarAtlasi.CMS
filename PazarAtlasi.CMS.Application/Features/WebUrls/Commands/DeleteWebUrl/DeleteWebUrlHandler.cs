using System.Threading;
using System.Threading.Tasks;
using MediatR;
using PazarAtlasi.CMS.Application.Features.WebUrls.Constants;
using PazarAtlasi.CMS.Application.Features.WebUrls.Rules;
using PazarAtlasi.CMS.Domain.Entities;
using PazarAtlasi.CMS.Domain.Interfaces;

namespace PazarAtlasi.CMS.Application.Features.WebUrls.Commands.DeleteWebUrl
{
    public class DeleteWebUrlHandler : IRequestHandler<DeleteWebUrlCommand, DeleteWebUrlResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly WebUrlBusinessRules _webUrlBusinessRules;

        public DeleteWebUrlHandler(IUnitOfWork unitOfWork, WebUrlBusinessRules webUrlBusinessRules)
        {
            _unitOfWork = unitOfWork;
            _webUrlBusinessRules = webUrlBusinessRules;
        }

        public async Task<DeleteWebUrlResponse> Handle(DeleteWebUrlCommand request, CancellationToken cancellationToken)
        {
            // Apply business rules
            await _webUrlBusinessRules.WebUrlMustExist(request.Id);

            // Get the existing entity
            var webUrlToDelete = await _unitOfWork.Repository<WebUrl>().GetByIdAsync(request.Id);

            // Delete from repository
            await _unitOfWork.Repository<WebUrl>().DeleteAsync(webUrlToDelete);
            await _unitOfWork.SaveChangesAsync();

            // Create response
            return new DeleteWebUrlResponse
            {
                Id = request.Id,
                IsSuccess = true,
                Message = WebUrlMessages.WebUrlDeleted
            };
        }
    }
}