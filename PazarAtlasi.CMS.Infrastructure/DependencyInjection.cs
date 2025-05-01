using IdentityServer.Extensions;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PazarAtlasi.CMS.Application.Common.Interfaces;
using PazarAtlasi.CMS.Application.Interfaces.Infrastructure;
using PazarAtlasi.CMS.Application.Models.Configuration;
using PazarAtlasi.CMS.Infrastructure.Catalog;
using PazarAtlasi.CMS.Infrastructure.Content;
using PazarAtlasi.CMS.Infrastructure.HttpHandlers;
using PazarAtlasi.CMS.Infrastructure.Identity;

namespace PazarAtlasi.CMS.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfigurationManager configuration)
        {
            services.AddScoped<ClientCredentialTokenHandler>();

            services.Configure<ServiceApiSettings>(configuration.GetSection("ServiceApiSettings"));

            services.Configure<ClientSettings>(configuration.GetSection("ClientSettings"));

            services.AddHttpContextAccessor();

            services.AddExternalServices();
            services.AddInternalServices();
            services.AddHttpClientServices(configuration);

            return services;
        }
        public static void AddExternalServices(this IServiceCollection services)
        {
            services.AddIdentityServer();
        }

        public static void AddInternalServices(this IServiceCollection services)
        {
            services.AddHttpClient<IIdentityService, IdentityService>();
        }

        public static void AddHttpClientServices(this IServiceCollection services, IConfiguration configuration)
        {
            var serviceApiSettings = configuration.GetSection("ServiceApiSettings").Get<ServiceApiSettings>();

            #region [ Client ]

            #region [ Identity and TokenService ]

            //services.AddHttpClient<IIdentityService, IdentityService>();

            services.AddHttpClient<IClientCredentialTokenService, ClientCredentialTokenService>();

            #endregion

            #region ResourceOwner

            //services.AddHttpClient<IUserService, UserService>(opt =>
            //{
            //    opt.BaseAddress = new Uri(serviceApiSettings.IdentityBaseUri);
            //}).AddHttpMessageHandler<ResourceOwnerPasswordTokenHandler>();

            //services.AddHttpClient<IBasketService, BasketService>(opt =>
            //{
            //    opt.BaseAddress = new Uri($"{serviceApiSettings.GatewayBaseUri}/{serviceApiSettings.Basket.Path}");
            //}).AddHttpMessageHandler<ResourceOwnerPasswordTokenHandler>();

            //services.AddHttpClient<IDiscountService, DiscountService>(opt =>
            //{
            //    opt.BaseAddress = new Uri($"{serviceApiSettings.GatewayBaseUri}/{serviceApiSettings.Discount.Path}");
            //}).AddHttpMessageHandler<ResourceOwnerPasswordTokenHandler>();

            //services.AddHttpClient<IPaymentService, PaymentService>(opt =>
            //{
            //    opt.BaseAddress = new Uri($"{serviceApiSettings.GatewayBaseUri}/{serviceApiSettings.Payment.Path}");
            //}).AddHttpMessageHandler<ResourceOwnerPasswordTokenHandler>();

            //services.AddHttpClient<IOrderService, OrderService>(opt =>
            //{
            //    opt.BaseAddress = new Uri($"{serviceApiSettings.GatewayBaseUri}/{serviceApiSettings.Order.Path}");
            //}).AddHttpMessageHandler<ResourceOwnerPasswordTokenHandler>();

            #endregion

            #region ClientCredential

            // whenever httpclient object is used in catalog service, its base address will be defined, and handler will add to its header the accessToken before the request.
            services.AddHttpClient<ICatalogService, CatalogService>(opt =>
            {
                opt.BaseAddress = new Uri($"http://localhost:5003");
            }).AddHttpMessageHandler<ClientCredentialTokenHandler>();

            services.AddHttpClient<IContentService, ContentService>(opt =>
            {
                opt.BaseAddress = new Uri($"http://localhost:5278");
            }).AddHttpMessageHandler<ClientCredentialTokenHandler>();

            #endregion

            #endregion [ Client ]
        }
    }
}