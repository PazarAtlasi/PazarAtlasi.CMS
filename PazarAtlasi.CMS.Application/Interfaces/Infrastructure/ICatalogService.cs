using PazarAtlasi.CMS.Application.Features.Categories.Queries;
using PazarAtlasi.Core.Application.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PazarAtlasi.CMS.Application.Interfaces.Infrastructure
{
    public interface ICatalogService
    {
        public Task<GetListResponse<CategoryDto>> GetCategoriesAsync();
    }
}
