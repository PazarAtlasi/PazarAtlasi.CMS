using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using PazarAtlasi.CMS.Domain.Entities;
using PazarAtlasi.CMS.Domain.Interfaces;

namespace PazarAtlasi.CMS.Application.Features.WebUrls.Queries.GetAllWebUrls
{
    public class GetAllWebUrlsHandler : IRequestHandler<GetAllWebUrlsQuery, List<WebUrlListDto>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetAllWebUrlsHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<List<WebUrlListDto>> Handle(GetAllWebUrlsQuery request, CancellationToken cancellationToken)
        {
            var allWebUrls = await _unitOfWork.Repository<WebUrl>().GetAllAsync();

            // Apply filters if provided
            var filteredWebUrls = allWebUrls.AsEnumerable();

            if (!string.IsNullOrEmpty(request.Category))
                filteredWebUrls = filteredWebUrls.Where(w => w.Category == request.Category);

            if (request.IsActive.HasValue)
                filteredWebUrls = filteredWebUrls.Where(w => w.IsActive == request.IsActive.Value);

            return _mapper.Map<List<WebUrlListDto>>(filteredWebUrls.OrderByDescending(w => w.CreatedAt).ToList());
        }
    }
}