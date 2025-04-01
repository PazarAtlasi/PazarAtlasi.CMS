using System;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using PazarAtlasi.CMS.Application.Common.Exceptions;
using PazarAtlasi.CMS.Application.Features.WebUrls.Constants;
using PazarAtlasi.CMS.Domain.Entities;
using PazarAtlasi.CMS.Domain.Interfaces;

namespace PazarAtlasi.CMS.Application.Features.WebUrls.Rules
{
    public class WebUrlBusinessRules
    {
        private readonly IUnitOfWork _unitOfWork;

        public WebUrlBusinessRules(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task WebUrlMustExist(int id)
        {
            var webUrl = await _unitOfWork.Repository<WebUrl>().GetByIdAsync(id);
            if (webUrl == null || webUrl.IsDeleted)
                throw new NotFoundException(WebUrlMessages.WebUrlNotFound);
        }

        public async Task SlugCannotBeDuplicated(string slug, int? excludeId = null)
        {
            var webUrls = await _unitOfWork.Repository<WebUrl>().GetAsync(w => w.Slug == slug && !w.IsDeleted);

            if (excludeId.HasValue)
                webUrls = webUrls.Where(w => w.Id != excludeId.Value).ToList();

            if (webUrls.Any())
                throw new BusinessRuleException(WebUrlMessages.SlugAlreadyExists);
        }

        public void SlugMustBeValid(string slug)
        {
            if (string.IsNullOrWhiteSpace(slug))
                throw new BusinessRuleException(WebUrlMessages.SlugRequired);

            // Slug should contain only lowercase letters, numbers, and hyphens
            var regex = new Regex("^[a-z0-9-]+$");
            if (!regex.IsMatch(slug))
                throw new BusinessRuleException(WebUrlMessages.InvalidSlugFormat);
        }

        public void TargetUrlMustBeValid(string targetUrl)
        {
            if (string.IsNullOrWhiteSpace(targetUrl))
                throw new BusinessRuleException(WebUrlMessages.TargetUrlRequired);
        }
    }
}