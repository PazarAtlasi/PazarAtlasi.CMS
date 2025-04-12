using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PazarAtlasi.CMS.Application.Common.Exceptions;
using PazarAtlasi.CMS.Application.Interfaces;
using PazarAtlasi.CMS.Domain.Entities;

namespace PazarAtlasi.CMS.Application.Features.Blogs.Rules
{
    public class BlogBusinessRules
    {
        private readonly IUnitOfWork _unitOfWork;
        
        public BlogBusinessRules(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        
        public async Task<Blog> BlogMustExist(int id)
        {
            var blog = await _unitOfWork.Repository<Blog>().GetByIdAsync(id);
            if (blog == null)
            {
                throw new NotFoundException(nameof(Blog), id);
            }
            
            return blog;
        }
        
        public async Task BlogTitleMustBeUnique(string title, int? excludeId = null)
        {
            var blogRepository = _unitOfWork.Repository<Blog>();
            var query = blogRepository.GetQueryable()
                .Where(b => b.Title.ToLower() == title.ToLower());
                
            if (excludeId.HasValue)
            {
                query = query.Where(b => b.Id != excludeId.Value);
            }
            
            var exists = await query.AnyAsync();
            
            if (exists)
            {
                throw new BusinessRuleException("A blog with this title already exists.");
            }
        }
        
        public async Task BlogSlugMustBeUnique(string slug, int? blogId = null)
        {
            var blogs = await _unitOfWork.Repository<Blog>().GetAsync(b => b.Slug == slug);
            if (blogId.HasValue)
            {
                blogs = blogs.Where(b => b.Id != blogId.Value).ToList();
            }
            
            if (blogs.Any())
                throw new BusinessRuleException("A blog with this slug already exists");
        }
        
        public async Task CategoryMustExistIfProvided(int? categoryId)
        {
            if (categoryId.HasValue)
            {
                var category = await _unitOfWork.Repository<Category>().GetByIdAsync(categoryId.Value);
                if (category == null)
                {
                    throw new NotFoundException(nameof(Category), categoryId.Value);
                }
            }
        }
        
        public async Task AuthorMustExistIfProvided(int? authorId)
        {
            if (authorId.HasValue)
            {
                var author = await _unitOfWork.Repository<Author>().GetByIdAsync(authorId.Value);
                if (author == null)
                {
                    throw new NotFoundException(nameof(Author), authorId.Value);
                }
            }
        }
        
        public async Task TagsMustExist(int[] tagIds)
        {
            if (tagIds == null || tagIds.Length == 0)
            {
                return;
            }
            
            var tagRepository = _unitOfWork.Repository<Tag>();
            var existingTagIds = await tagRepository.GetQueryable()
                .Where(t => tagIds.Contains(t.Id))
                .Select(t => t.Id)
                .ToListAsync();
                
            var missingTagIds = tagIds.Except(existingTagIds).ToList();
            
            if (missingTagIds.Any())
            {
                throw new NotFoundException(nameof(Tag), string.Join(", ", missingTagIds));
            }
        }
    }
} 