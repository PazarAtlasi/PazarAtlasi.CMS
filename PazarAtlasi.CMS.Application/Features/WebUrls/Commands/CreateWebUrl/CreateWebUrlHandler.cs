using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using PazarAtlasi.CMS.Application.Features.WebUrls.Constants;
using PazarAtlasi.CMS.Application.Features.WebUrls.Rules;
using PazarAtlasi.CMS.Domain.Entities;
using PazarAtlasi.CMS.Domain.Interfaces;

namespace PazarAtlasi.CMS.Application.Features.WebUrls.Commands.CreateWebUrl
{
    public class CreateWebUrlHandler : IRequestHandler<CreateWebUrlCommand, CreateWebUrlResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly WebUrlBusinessRules _webUrlBusinessRules;

        public CreateWebUrlHandler(IUnitOfWork unitOfWork, IMapper mapper, WebUrlBusinessRules webUrlBusinessRules)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _webUrlBusinessRules = webUrlBusinessRules;
        }

        public async Task<CreateWebUrlResponse> Handle(CreateWebUrlCommand request, CancellationToken cancellationToken)
        {
            // Apply business rules
            _webUrlBusinessRules.SlugMustBeValid(request.Slug);
            _webUrlBusinessRules.TargetUrlMustBeValid(request.TargetUrl);
            await _webUrlBusinessRules.SlugCannotBeDuplicated(request.Slug);

            // Map command to entity
            var webUrlToCreate = _mapper.Map<WebUrl>(request);

            // Add to repository
            await _unitOfWork.Repository<WebUrl>().AddAsync(webUrlToCreate);
            await _unitOfWork.SaveChangesAsync();

            // Create response
            return new CreateWebUrlResponse
            {
                Id = webUrlToCreate.Id,
                Slug = webUrlToCreate.Slug,
                TargetUrl = webUrlToCreate.TargetUrl,
                IsSuccess = true,
                Message = WebUrlMessages.WebUrlCreated
            };
        }
    }
}