using PazarAtlasi.CMS.Application.Features.Categories.Queries;
using PazarAtlasi.CMS.Application.Interfaces.Infrastructure;
using PazarAtlasi.CMS.Application.Models;
using PazarAtlasi.CMS.Infrastructure.MicroserviceBase;
using PazarAtlasi.Core.Application.Responses;
using System.Net.Http;
using System.Threading.Tasks;

namespace PazarAtlasi.CMS.Infrastructure.Content
{
    public class ContentService : BaseDiscoveryService, IContentService
    {
        public ContentService(HttpClient httpClient) : base(httpClient)
        {
        }

        public async Task<GetListResponse<CategoryDto>> GetCategoriesAsync()
        {
            return await GetListAsync<CategoryDto>("Categories", new PageRequest { PageIndex = 0, PageSize = 10 });
        }

        public async Task<GetListResponse<T>> GetListAsync<T>(string controllerName, object pageRequest) where T : class
        {
            return await GetListInternalAsync<T>(controllerName, pageRequest);
        }

        public async Task<T> GetByIdAsync<T>(string controllerName, int id) where T : class
        {
            return await GetByIdInternalAsync<T>(controllerName, id);
        }

        public async Task<T> CreateAsync<T>(string controllerName, object createCommand) where T : class
        {
            return await CreateInternalAsync<T>(controllerName, createCommand);
        }

        public async Task<T> UpdateAsync<T>(string controllerName, object updateCommand) where T : class
        {
            return await UpdateInternalAsync<T>(controllerName, updateCommand);
        }

        public async Task DeleteAsync(string controllerName, int id)
        {
            await DeleteInternalAsync(controllerName, id);
        }
    }
}
