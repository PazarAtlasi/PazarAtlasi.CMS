using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using PazarAtlasi.CMS.Application.Common.Exceptions;
using PazarAtlasi.CMS.Application.Features.WebUrls.Constants;
using PazarAtlasi.CMS.Application.Features.WebUrls.Rules;
using PazarAtlasi.CMS.Domain.Entities;
using PazarAtlasi.CMS.Domain.Interfaces;

namespace PazarAtlasi.CMS.Application.Features.WebUrls.Queries.GetWebUrlById
{
    public class GetWebUrlByIdHandler : IRequestHandler<GetWebUrlByIdQuery, WebUrlDto>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly WebUrlBusinessRules _webUrlBusinessRules;

        public GetWebUrlByIdHandler(IUnitOfWork unitOfWork, IMapper mapper, WebUrlBusinessRules webUrlBusinessRules)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _webUrlBusinessRules = webUrlBusinessRules;
        }

        public async Task<WebUrlDto> Handle(GetWebUrlByIdQuery request, CancellationToken cancellationToken)
        {
            await _webUrlBusinessRules.WebUrlMustExist(request.Id);

            var webUrl = await _unitOfWork.Repository<WebUrl>().GetByIdAsync(request.Id);

            return _mapper.Map<WebUrlDto>(webUrl);
        }
    }
}