using System.Reflection;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using PazarAtlasi.CMS.Application.Features.Blogs.Rules;
using PazarAtlasi.CMS.Application.Features.WebUrls.Rules;

namespace PazarAtlasi.CMS.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
            services.AddAutoMapper(Assembly.GetExecutingAssembly());

            // Register business rules
            services.AddScoped<WebUrlBusinessRules>();
            services.AddScoped<BlogBusinessRules>();

            return services;
        }
    }
}