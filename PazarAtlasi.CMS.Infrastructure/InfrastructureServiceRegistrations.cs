using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using PazarAtlasi.CMS.Application.Interfaces.Infrastructure;
using PazarAtlasi.CMS.Application.Interfaces.Services;
using PazarAtlasi.CMS.Application.Services;
using PazarAtlasi.CMS.Infrastructure.Configuration;
using PazarAtlasi.CMS.Infrastructure.Services;
using PazarAtlasi.CMS.Infrastructure.Services.Cache;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PazarAtlasi.CMS.Infrastructure
{
    public static class InfrastructureServiceRegistrations
    {
        public static IServiceCollection AddInfrastructureServiceRegistrations(this IServiceCollection services, IConfiguration configuration)
        {
            // Cache Configuration
            var cacheSection = configuration.GetSection("Cache");
            var cacheConfig = new CacheConfiguration
            {
                Type = Enum.TryParse<CacheType>(cacheSection["Type"], out var cacheType) ? cacheType : CacheType.InMemory,
                ConnectionString = cacheSection["ConnectionString"],
                DefaultExpirationMinutes = int.TryParse(cacheSection["DefaultExpirationMinutes"], out var defaultExp) ? defaultExp : 30,
                MemoryCacheExpirationMinutes = int.TryParse(cacheSection["MemoryCacheExpirationMinutes"], out var memoryExp) ? memoryExp : 5,
                EnableCompression = bool.TryParse(cacheSection["EnableCompression"], out var compression) && compression,
                EnableLogging = bool.TryParse(cacheSection["EnableLogging"], out var logging) && logging
            };
            services.AddSingleton(cacheConfig);

            // Register cache services based on configuration
            switch (cacheConfig.Type)
            {
                case CacheType.InMemory:
                    services.AddMemoryCache();
                    services.AddSingleton<ICacheService, InMemoryCacheService>();
                    break;

                case CacheType.Redis:
                    // Redis configuration
                    if (string.IsNullOrEmpty(cacheConfig.ConnectionString))
                    {
                        throw new InvalidOperationException("Redis connection string is required when using Redis cache.");
                    }

                    services.AddSingleton<IConnectionMultiplexer>(provider =>
                    {
                        var logger = provider.GetRequiredService<ILogger<IConnectionMultiplexer>>();
                        try
                        {
                            var connection = ConnectionMultiplexer.Connect(cacheConfig.ConnectionString);
                            logger.LogInformation("Redis connection established successfully");
                            return connection;
                        }
                        catch (Exception ex)
                        {
                            logger.LogError(ex, "Failed to connect to Redis. Falling back to InMemory cache.");
                            throw;
                        }
                    });

                    services.AddStackExchangeRedisCache(options =>
                    {
                        options.Configuration = cacheConfig.ConnectionString;
                        options.InstanceName = "PazarAtlasiCMS";
                    });

                    services.AddSingleton<ICacheService, RedisCacheService>();
                    break;

                case CacheType.Hybrid:
                    // Hybrid cache requires both InMemory and Redis
                    if (string.IsNullOrEmpty(cacheConfig.ConnectionString))
                    {
                        throw new InvalidOperationException("Redis connection string is required when using Hybrid cache.");
                    }

                    services.AddMemoryCache();

                    services.AddSingleton<IConnectionMultiplexer>(provider =>
                    {
                        var logger = provider.GetRequiredService<ILogger<IConnectionMultiplexer>>();
                        try
                        {
                            var connection = ConnectionMultiplexer.Connect(cacheConfig.ConnectionString);
                            logger.LogInformation("Redis connection established successfully for Hybrid cache");
                            return connection;
                        }
                        catch (Exception ex)
                        {
                            logger.LogError(ex, "Failed to connect to Redis for Hybrid cache. Falling back to InMemory cache.");
                            throw;
                        }
                    });

                    services.AddStackExchangeRedisCache(options =>
                    {
                        options.Configuration = cacheConfig.ConnectionString;
                        options.InstanceName = "PazarAtlasiCMS";
                    });

                    // Register individual cache services
                    services.AddSingleton<InMemoryCacheService>();
                    services.AddSingleton<RedisCacheService>();

                    // Register hybrid cache as the main ICacheService
                    services.AddSingleton<ICacheService, HybridCacheService>();
                    break;

                default:
                    services.AddMemoryCache();
                    services.AddSingleton<ICacheService, InMemoryCacheService>();
                    break;
            }

            // Register Language Service
            services.AddScoped<ILanguageService, LanguageService>();
            services.AddScoped<IMediaUploadService, MediaUploadService>();

            return services;
        }
    }
}
