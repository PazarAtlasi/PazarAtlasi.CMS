using PazarAtlasi.CMS.Application.Models;
using PazarAtlasi.Core.Application.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

namespace PazarAtlasi.CMS.Infrastructure.MicroserviceBase
{
    /// <summary>
    /// Base class for all microservice clients that support discovery
    /// </summary>
    public abstract class BaseDiscoveryService
    {
        protected readonly HttpClient _httpClient;
        protected ServiceDiscoveryResponse _discoveryCache;
        protected readonly JsonSerializerOptions _jsonOptions;
        protected readonly SemaphoreSlim _discoveryLock = new SemaphoreSlim(1, 1);
        protected DateTime _discoveryCacheExpiration = DateTime.MinValue;
        protected const int CACHE_MINUTES = 15;

        protected BaseDiscoveryService(HttpClient httpClient)
        {
            _httpClient = httpClient;
            _jsonOptions = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };
        }

        /// <summary>
        /// Discovers the service endpoints
        /// </summary>
        public async Task<ServiceDiscoveryResponse> DiscoverEndpointsAsync()
        {
            await _discoveryLock.WaitAsync();
            try
            {
                // Check if cache is still valid
                if (_discoveryCache != null && DateTime.UtcNow < _discoveryCacheExpiration)
                {
                    return _discoveryCache;
                }

                // Call discovery endpoint
                var response = await _httpClient.GetAsync("");
                response.EnsureSuccessStatusCode();

                var discoveryResponse = await response.Content.ReadFromJsonAsync<ServiceDiscoveryResponse>(_jsonOptions);

                // Cache results
                _discoveryCache = discoveryResponse;
                _discoveryCacheExpiration = DateTime.UtcNow.AddMinutes(CACHE_MINUTES);

                return discoveryResponse;
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException($"Failed to discover endpoints: {ex.Message}", ex);
            }
            finally
            {
                _discoveryLock.Release();
            }
        }

        /// <summary>
        /// Gets a list of entities with pagination
        /// </summary>
        protected async Task<GetListResponse<T>> GetListInternalAsync<T>(string controllerName, object pageRequest) where T : class
        {
            // Get discovery info if not already cached
            var discovery = await GetEndpointInfoAsync(controllerName, "GetList", "GET");
            if (discovery == null)
            {
                throw new InvalidOperationException($"No GetList endpoint found for controller {controllerName}");
            }

            // Build query string from pageRequest properties
            var queryString = BuildQueryString(pageRequest);
            var url = $"{discovery.Path}{queryString}";

            // Make the API call
            var response = await _httpClient.GetAsync(url);
            response.EnsureSuccessStatusCode();

            return await response.Content.ReadFromJsonAsync<GetListResponse<T>>(_jsonOptions);
        }

        /// <summary>
        /// Gets an entity by id
        /// </summary>
        protected async Task<T> GetByIdInternalAsync<T>(string controllerName, int id) where T : class
        {
            // Get discovery info
            var discovery = await GetEndpointInfoAsync(controllerName, "GetById", "GET");
            if (discovery == null)
            {
                throw new InvalidOperationException($"No GetById endpoint found for controller {controllerName}");
            }

            // Replace {id} placeholder in path
            var url = discovery.Path.Replace("{id}", id.ToString());

            // Make the API call
            var response = await _httpClient.GetAsync(url);
            response.EnsureSuccessStatusCode();

            return await response.Content.ReadFromJsonAsync<T>(_jsonOptions);
        }

        /// <summary>
        /// Creates a new entity
        /// </summary>
        protected async Task<T> CreateInternalAsync<T>(string controllerName, object createCommand) where T : class
        {
            // Get discovery info
            var discovery = await GetEndpointInfoAsync(controllerName, "Add", "POST");
            if (discovery == null)
            {
                throw new InvalidOperationException($"No Add endpoint found for controller {controllerName}");
            }

            // Make the API call
            var response = await _httpClient.PostAsJsonAsync(discovery.Path, createCommand, _jsonOptions);
            response.EnsureSuccessStatusCode();

            return await response.Content.ReadFromJsonAsync<T>(_jsonOptions);
        }

        /// <summary>
        /// Updates an existing entity
        /// </summary>
        protected async Task<T> UpdateInternalAsync<T>(string controllerName, object updateCommand) where T : class
        {
            // Get discovery info
            var discovery = await GetEndpointInfoAsync(controllerName, "Update", "PUT");
            if (discovery == null)
            {
                throw new InvalidOperationException($"No Update endpoint found for controller {controllerName}");
            }

            // Make the API call
            var response = await _httpClient.PutAsJsonAsync(discovery.Path, updateCommand, _jsonOptions);
            response.EnsureSuccessStatusCode();

            return await response.Content.ReadFromJsonAsync<T>(_jsonOptions);
        }

        /// <summary>
        /// Deletes an entity by id
        /// </summary>
        protected async Task DeleteInternalAsync(string controllerName, int id)
        {
            // Get discovery info
            var discovery = await GetEndpointInfoAsync(controllerName, "Delete", "DELETE");
            if (discovery == null)
            {
                throw new InvalidOperationException($"No Delete endpoint found for controller {controllerName}");
            }

            // Replace {id} placeholder in path
            var url = discovery.Path.Replace("{id}", id.ToString());

            // Make the API call
            var response = await _httpClient.DeleteAsync(url);
            response.EnsureSuccessStatusCode();
        }

        /// <summary>
        /// Gets endpoint information by controller name, action name, and HTTP method
        /// </summary>
        protected async Task<ApiEndpoint> GetEndpointInfoAsync(string controllerName, string actionName, string httpMethod)
        {
            var discovery = await DiscoverEndpointsAsync();

            return discovery.Endpoints.FirstOrDefault(e =>
                e.ControllerName.Equals(controllerName, StringComparison.OrdinalIgnoreCase) &&
                e.ActionName.Equals(actionName, StringComparison.OrdinalIgnoreCase) &&
                e.HttpMethod.Equals(httpMethod, StringComparison.OrdinalIgnoreCase));
        }

        /// <summary>
        /// Builds a query string from an object's properties
        /// </summary>
        protected string BuildQueryString(object obj)
        {
            if (obj == null) return string.Empty;

            var properties = obj.GetType().GetProperties()
                .Where(p => p.GetValue(obj) != null)
                .Select(p => $"{p.Name.ToLower()}={Uri.EscapeDataString(p.GetValue(obj).ToString())}");

            var queryString = string.Join("&", properties);
            return queryString.Length > 0 ? $"?{queryString}" : string.Empty;
        }
    }
}