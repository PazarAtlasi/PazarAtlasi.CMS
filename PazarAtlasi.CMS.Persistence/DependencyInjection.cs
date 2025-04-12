using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PazarAtlasi.CMS.Application.Common.Interfaces;
using PazarAtlasi.CMS.Application.Interfaces;
using PazarAtlasi.CMS.Application.Interfaces.Repositories;
using PazarAtlasi.CMS.Domain.Interfaces;
using PazarAtlasi.CMS.Persistence.Context;
using PazarAtlasi.CMS.Persistence.Repositories;

namespace PazarAtlasi.CMS.Persistence
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(
                    configuration.GetConnectionString("DefaultConnection"),
                    b => b.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName)));

            services.AddScoped<IApplicationDbContext>(provider => provider.GetRequiredService<ApplicationDbContext>());
            services.AddScoped(typeof(Domain.Interfaces.IRepository<>), typeof(Repository<>));
            services.AddScoped<UnitOfWork>();
            services.AddScoped<Domain.Interfaces.IUnitOfWork>(provider => (Domain.Interfaces.IUnitOfWork)provider.GetRequiredService<UnitOfWork>());
            services.AddScoped<Application.Interfaces.IUnitOfWork>(provider => provider.GetRequiredService<UnitOfWork>());
            services.AddScoped<IAnnouncementRepository, AnnouncementRepository>();

            return services;
        }
    }
}