using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PazarAtlasi.CMS.Application.Interfaces.Infrastructure;
using PazarAtlasi.CMS.Infrastructure.Catalog;
using PazarAtlasi.CMS.Infrastructure.Content;
using PazarAtlasi.CMS.Infrastructure.MicroserviceBase;
using System;

namespace PazarAtlasi.CMS.Infrastructure
{
    public static class ServiceExtensions
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            // Register Content Microservice
            services.AddHttpClient<IContentService, ContentService>(client =>
            {
                var baseUrl = configuration["MicroserviceUrls:Content"] ?? "http://localhost:5278";
                client.BaseAddress = new Uri(baseUrl);
                client.DefaultRequestHeaders.Add("Accept", "application/json");
            });

            // Register Catalog Microservice
            services.AddHttpClient<ICatalogService, CatalogService>(client =>
            {
                var baseUrl = configuration["MicroserviceUrls:Catalog"] ?? "http://localhost:5000";
                client.BaseAddress = new Uri(baseUrl);
                client.DefaultRequestHeaders.Add("Accept", "application/json");
            });

            return services;
        }

        /// <summary>
        /// Registers a generic microservice client for any API with a discovery endpoint
        /// </summary>
        public static IServiceCollection AddGenericMicroservice(this IServiceCollection services,
            string serviceName, string baseUrl)
        {
            services.AddHttpClient<IMicroserviceService, GenericMicroserviceService>(serviceName, client =>
            {
                client.BaseAddress = new Uri(baseUrl);
                client.DefaultRequestHeaders.Add("Accept", "application/json");
            });

            return services;
        }
    }
}