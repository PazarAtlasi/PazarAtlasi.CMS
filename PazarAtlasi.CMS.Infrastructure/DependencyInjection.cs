using Microsoft.Extensions.DependencyInjection;
using PazarAtlasi.CMS.Application.Common.Interfaces;

namespace PazarAtlasi.CMS.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            // Add your infrastructure services here
            // Example:
            // services.AddTransient<IDateTime, DateTimeService>();
            // services.AddTransient<IEmailService, EmailService>();

            return services;
        }
    }
}