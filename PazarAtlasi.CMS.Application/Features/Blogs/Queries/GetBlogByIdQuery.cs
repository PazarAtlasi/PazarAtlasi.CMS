using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using PazarAtlasi.CMS.Application.Common.Exceptions;
using PazarAtlasi.CMS.Application.Features.Blogs.Rules;
using PazarAtlasi.CMS.Application.Interfaces;
using PazarAtlasi.CMS.Domain.Entities;

namespace PazarAtlasi.CMS.Application.Features.Blogs.Queries
{
    public class GetBlogByIdQuery : IRequest<BlogDto>
    {
        public int Id { get; set; }
    }
    
    public class GetBlogByIdQueryHandler : IRequestHandler<GetBlogByIdQuery, BlogDto>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly BlogBusinessRules _blogBusinessRules;
        
        public GetBlogByIdQueryHandler(
            IUnitOfWork unitOfWork,
            IMapper mapper,
            BlogBusinessRules blogBusinessRules)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _blogBusinessRules = blogBusinessRules;
        }
        
        public async Task<BlogDto> Handle(GetBlogByIdQuery request, CancellationToken cancellationToken)
        {
            var blog = await _unitOfWork.Repository<Blog>().GetQueryable()
                .Include(b => b.Category)
                .Include(b => b.Author)
                .Include(b => b.BlogTags)
                .ThenInclude(bt => bt.Tag)
                .FirstOrDefaultAsync(b => b.Id == request.Id);
                
            if (blog == null)
            {
                throw new NotFoundException(nameof(Blog), request.Id);
            }
            
            return _mapper.Map<BlogDto>(blog);
        }
    }
} 