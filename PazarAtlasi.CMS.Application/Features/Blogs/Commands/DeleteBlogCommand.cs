using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using PazarAtlasi.CMS.Application.Features.Blogs.Rules;
using PazarAtlasi.CMS.Application.Interfaces;
using PazarAtlasi.CMS.Domain.Entities;

namespace PazarAtlasi.CMS.Application.Features.Blogs.Commands
{
    public class DeleteBlogCommand : IRequest<Unit>
    {
        public int Id { get; set; }
    }
    
    public class DeleteBlogCommandHandler : IRequestHandler<DeleteBlogCommand, Unit>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly BlogBusinessRules _blogBusinessRules;
        
        public DeleteBlogCommandHandler(
            IUnitOfWork unitOfWork,
            BlogBusinessRules blogBusinessRules)
        {
            _unitOfWork = unitOfWork;
            _blogBusinessRules = blogBusinessRules;
        }
        
        public async Task<Unit> Handle(DeleteBlogCommand request, CancellationToken cancellationToken)
        {
            // Verify blog exists
            var blog = await _blogBusinessRules.BlogMustExist(request.Id);
            
            // Delete associated blog tags first
            var blogTagRepository = _unitOfWork.Repository<BlogTag>();
            var blogTags = await blogTagRepository
                .GetQueryable()
                .Where(bt => bt.BlogId == request.Id)
                .ToListAsync();
                
            foreach (var blogTag in blogTags)
            {
                blogTagRepository.Delete(blogTag);
            }
            
            // Delete the blog
            var blogRepository = _unitOfWork.Repository<Blog>();
            blogRepository.Delete(blog);
            
            await _unitOfWork.SaveChangesAsync();
            
            return Unit.Value;
        }
    }
} 