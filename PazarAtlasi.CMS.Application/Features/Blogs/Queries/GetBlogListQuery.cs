using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using PazarAtlasi.CMS.Application.Interfaces;
using PazarAtlasi.CMS.Domain.Entities;

namespace PazarAtlasi.CMS.Application.Features.Blogs.Queries
{
    public class GetBlogListQuery : IRequest<List<BlogDto>>
    {
        // Add pagination or filtering properties if needed
        public bool IncludeUnpublished { get; set; } = false;
    }
    
    public class GetBlogListQueryHandler : IRequestHandler<GetBlogListQuery, List<BlogDto>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        
        public GetBlogListQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        
        public async Task<List<BlogDto>> Handle(GetBlogListQuery request, CancellationToken cancellationToken)
        {
            var blogRepository = _unitOfWork.Repository<Blog>();
            var query = await blogRepository.GetAsync(b => !request.IncludeUnpublished || b.IsPublished);
            
            var blogs = query.OrderByDescending(b => b.CreatedAt).ToList();
            
            return _mapper.Map<List<BlogDto>>(blogs);
        }
    }
} 