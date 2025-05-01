using PazarAtlasi.CMS.Application.Features.Categories.Queries;
using PazarAtlasi.CMS.Application.Interfaces.Infrastructure;
using PazarAtlasi.Core.Application.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace PazarAtlasi.CMS.Infrastructure.Content
{
    public class ContentService : IContentService
    {
        private readonly HttpClient _httpClient;
        public ContentService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<GetListResponse<CategoryDto>> GetCategoriesAsync()
        {
            // https:localhost:5000/services/catalog/course
            var categoryTestResponse = await _httpClient.GetAsync("api/TestCategories?pageIndex=0&pageSize=10");
            var categoryResponse = await categoryTestResponse.Content.ReadFromJsonAsync<GetListResponse<CategoryDto>>();

            return categoryResponse;
        }
    }
}
