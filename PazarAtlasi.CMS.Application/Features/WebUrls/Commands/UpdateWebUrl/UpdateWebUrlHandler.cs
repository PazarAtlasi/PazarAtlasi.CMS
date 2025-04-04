using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using PazarAtlasi.CMS.Application.Features.WebUrls.Constants;
using PazarAtlasi.CMS.Application.Features.WebUrls.Rules;
using PazarAtlasi.CMS.Domain.Entities;
using PazarAtlasi.CMS.Domain.Interfaces;

namespace PazarAtlasi.CMS.Application.Features.WebUrls.Commands.UpdateWebUrl
{
    public class UpdateWebUrlHandler : IRequestHandler<UpdateWebUrlCommand, UpdateWebUrlResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly WebUrlBusinessRules _webUrlBusinessRules;

        public UpdateWebUrlHandler(IUnitOfWork unitOfWork, IMapper mapper, WebUrlBusinessRules webUrlBusinessRules)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _webUrlBusinessRules = webUrlBusinessRules;
        }

        public async Task<UpdateWebUrlResponse> Handle(UpdateWebUrlCommand request, CancellationToken cancellationToken)
        {
            // Apply business rules
            await _webUrlBusinessRules.WebUrlMustExist(request.Id);
            _webUrlBusinessRules.SlugMustBeValid(request.Slug);
            _webUrlBusinessRules.TargetUrlMustBeValid(request.TargetUrl);
            await _webUrlBusinessRules.SlugCannotBeDuplicated(request.Slug, request.Id);

            // Get the existing entity
            var existingWebUrl = await _unitOfWork.Repository<WebUrl>().GetByIdAsync(request.Id);

            // Update properties
            _mapper.Map(request, existingWebUrl);

            // Update in repository
            await _unitOfWork.Repository<WebUrl>().UpdateAsync(existingWebUrl);
            await _unitOfWork.SaveChangesAsync();

            // Create response
            return new UpdateWebUrlResponse
            {
                Id = existingWebUrl.Id,
                Slug = existingWebUrl.Slug,
                TargetUrl = existingWebUrl.TargetUrl,
                IsSuccess = true,
                Message = WebUrlMessages.WebUrlUpdated
            };
        }
    }
}