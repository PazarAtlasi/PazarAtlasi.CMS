using PazarAtlasi.CMS.Application.Features.Categories.Queries;
using PazarAtlasi.CMS.Application.Models;
using PazarAtlasi.Core.Application.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PazarAtlasi.CMS.Application.Interfaces.Infrastructure
{
    public interface IContentService
    {
        Task<GetListResponse<CategoryDto>> GetCategoriesAsync();

        /// <summary>
        /// Discovers the available endpoints from the service
        /// </summary>
        Task<ServiceDiscoveryResponse> DiscoverEndpointsAsync();

        /// <summary>
        /// Calls a GET endpoint with pagination
        /// </summary>
        Task<GetListResponse<T>> GetListAsync<T>(string controllerName, object pageRequest) where T : class;

        /// <summary>
        /// Gets an entity by id
        /// </summary>
        Task<T> GetByIdAsync<T>(string controllerName, int id) where T : class;

        /// <summary>
        /// Creates a new entity
        /// </summary>
        Task<T> CreateAsync<T>(string controllerName, object createCommand) where T : class;

        /// <summary>
        /// Updates an existing entity
        /// </summary>
        Task<T> UpdateAsync<T>(string controllerName, object updateCommand) where T : class;

        /// <summary>
        /// Deletes an entity by id
        /// </summary>
        Task DeleteAsync(string controllerName, int id);
    }
}
