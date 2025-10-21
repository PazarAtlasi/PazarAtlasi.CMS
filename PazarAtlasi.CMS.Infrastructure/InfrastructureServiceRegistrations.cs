using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PazarAtlasi.CMS.Application.Interfaces.Infrastructure;
using PazarAtlasi.CMS.Infrastructure.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PazarAtlasi.CMS.Infrastructure
{
    public static class InfrastructureServiceRegistrations
    {
        public static IServiceCollection AddInfrastructureServiceRegistrations(this IServiceCollection services)
        {
            services.AddScoped<IMediaUploadService, MediaUploadService>();
            services.AddScoped<ITemplateConfigurationProvider, TemplateConfigurationProvider>();
            return services;
        }
    }
}
