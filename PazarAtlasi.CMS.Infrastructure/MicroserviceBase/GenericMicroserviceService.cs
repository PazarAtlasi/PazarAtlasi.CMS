using PazarAtlasi.CMS.Application.Models;
using PazarAtlasi.Core.Application.Responses;
using System.Net.Http;
using System.Threading.Tasks;

namespace PazarAtlasi.CMS.Infrastructure.MicroserviceBase
{
    /// <summary>
    /// Generic implementation of a microservice client
    /// Can be used to quickly create clients for new microservices
    /// </summary>
    public class GenericMicroserviceService : BaseDiscoveryService, IMicroserviceService
    {
        public GenericMicroserviceService(HttpClient httpClient) : base(httpClient)
        {
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

    /// <summary>
    /// Generic interface for microservice clients
    /// </summary>
    public interface IMicroserviceService
    {
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