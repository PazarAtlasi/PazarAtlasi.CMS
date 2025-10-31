using Microsoft.Extensions.Logging;
using PazarAtlasi.CMS.Application.Interfaces.Infrastructure;

namespace PazarAtlasi.CMS.Infrastructure.Services.Cache
{
    public class HybridCacheService : ICacheService
    {
        private readonly InMemoryCacheService _memoryCache;
        private readonly RedisCacheService _redisCache;
        private readonly ILogger<HybridCacheService> _logger;
        private readonly TimeSpan _memoryExpiration = TimeSpan.FromMinutes(5); // Memory cache for 5 minutes

        public HybridCacheService(
            InMemoryCacheService memoryCache,
            RedisCacheService redisCache,
            ILogger<HybridCacheService> logger)
        {
            _memoryCache = memoryCache;
            _redisCache = redisCache;
            _logger = logger;
        }

        public async Task<T?> GetAsync<T>(string key, CancellationToken cancellationToken = default) where T : class
        {
            try
            {
                // First try memory cache (L1)
                var memoryResult = await _memoryCache.GetAsync<T>(key, cancellationToken);
                if (memoryResult != null)
                {
                    _logger.LogDebug($"Hybrid Cache L1 HIT -> Key: {key}");
                    return memoryResult;
                }

                // Then try Redis cache (L2)
                var redisResult = await _redisCache.GetAsync<T>(key, cancellationToken);
                if (redisResult != null)
                {
                    // Store in memory cache for faster access next time
                    await _memoryCache.SetAsync(key, redisResult, _memoryExpiration, cancellationToken);
                    _logger.LogDebug($"Hybrid Cache L2 HIT -> Key: {key} (promoted to L1)");
                    return redisResult;
                }

                _logger.LogDebug($"Hybrid Cache MISS -> Key: {key}");
                return null;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error getting hybrid cache key: {key}");
                return null;
            }
        }

        public async Task<T?> GetValueAsync<T>(string key, CancellationToken cancellationToken = default) where T : struct
        {
            try
            {
                // First try memory cache (L1)
                var memoryResult = await _memoryCache.GetValueAsync<T>(key, cancellationToken);
                if (memoryResult.HasValue)
                {
                    _logger.LogDebug($"Hybrid Cache L1 VALUE HIT -> Key: {key}");
                    return memoryResult;
                }

                // Then try Redis cache (L2)
                var redisResult = await _redisCache.GetValueAsync<T>(key, cancellationToken);
                if (redisResult.HasValue)
                {
                    // Store in memory cache for faster access next time
                    await _memoryCache.SetValueAsync(key, redisResult.Value, _memoryExpiration, cancellationToken);
                    _logger.LogDebug($"Hybrid Cache L2 VALUE HIT -> Key: {key} (promoted to L1)");
                    return redisResult;
                }

                _logger.LogDebug($"Hybrid Cache VALUE MISS -> Key: {key}");
                return null;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error getting hybrid cache value key: {key}");
                return null;
            }
        }

        public async Task<string?> GetStringAsync(string key, CancellationToken cancellationToken = default)
        {
            try
            {
                // First try memory cache (L1)
                var memoryResult = await _memoryCache.GetStringAsync(key, cancellationToken);
                if (!string.IsNullOrEmpty(memoryResult))
                {
                    _logger.LogDebug($"Hybrid Cache L1 STRING HIT -> Key: {key}");
                    return memoryResult;
                }

                // Then try Redis cache (L2)
                var redisResult = await _redisCache.GetStringAsync(key, cancellationToken);
                if (!string.IsNullOrEmpty(redisResult))
                {
                    // Store in memory cache for faster access next time
                    await _memoryCache.SetStringAsync(key, redisResult, _memoryExpiration, cancellationToken);
                    _logger.LogDebug($"Hybrid Cache L2 STRING HIT -> Key: {key} (promoted to L1)");
                    return redisResult;
                }

                _logger.LogDebug($"Hybrid Cache STRING MISS -> Key: {key}");
                return null;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error getting hybrid cache string key: {key}");
                return null;
            }
        }

        public async Task SetAsync<T>(string key, T value, TimeSpan? expiration = null, CancellationToken cancellationToken = default) where T : class
        {
            try
            {
                // Set in both caches
                var memoryExpiration = expiration.HasValue && expiration.Value < _memoryExpiration 
                    ? expiration.Value 
                    : _memoryExpiration;

                await Task.WhenAll(
                    _memoryCache.SetAsync(key, value, memoryExpiration, cancellationToken),
                    _redisCache.SetAsync(key, value, expiration, cancellationToken)
                );

                _logger.LogDebug($"Hybrid Cache SET -> Key: {key}, Expiration: {expiration?.TotalMinutes ?? 30} minutes");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error setting hybrid cache key: {key}");
            }
        }

        public async Task SetValueAsync<T>(string key, T value, TimeSpan? expiration = null, CancellationToken cancellationToken = default) where T : struct
        {
            try
            {
                // Set in both caches
                var memoryExpiration = expiration.HasValue && expiration.Value < _memoryExpiration 
                    ? expiration.Value 
                    : _memoryExpiration;

                await Task.WhenAll(
                    _memoryCache.SetValueAsync(key, value, memoryExpiration, cancellationToken),
                    _redisCache.SetValueAsync(key, value, expiration, cancellationToken)
                );

                _logger.LogDebug($"Hybrid Cache SET VALUE -> Key: {key}, Expiration: {expiration?.TotalMinutes ?? 30} minutes");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error setting hybrid cache value key: {key}");
            }
        }

        public async Task SetStringAsync(string key, string value, TimeSpan? expiration = null, CancellationToken cancellationToken = default)
        {
            try
            {
                // Set in both caches
                var memoryExpiration = expiration.HasValue && expiration.Value < _memoryExpiration 
                    ? expiration.Value 
                    : _memoryExpiration;

                await Task.WhenAll(
                    _memoryCache.SetStringAsync(key, value, memoryExpiration, cancellationToken),
                    _redisCache.SetStringAsync(key, value, expiration, cancellationToken)
                );

                _logger.LogDebug($"Hybrid Cache SET STRING -> Key: {key}");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error setting hybrid cache string key: {key}");
            }
        }

        public async Task RemoveAsync(string key, CancellationToken cancellationToken = default)
        {
            try
            {
                // Remove from both caches
                await Task.WhenAll(
                    _memoryCache.RemoveAsync(key, cancellationToken),
                    _redisCache.RemoveAsync(key, cancellationToken)
                );

                _logger.LogDebug($"Hybrid Cache REMOVE -> Key: {key}");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error removing hybrid cache key: {key}");
            }
        }

        public async Task RemoveByPatternAsync(string pattern, CancellationToken cancellationToken = default)
        {
            try
            {
                // Remove from both caches
                await Task.WhenAll(
                    _memoryCache.RemoveByPatternAsync(pattern, cancellationToken),
                    _redisCache.RemoveByPatternAsync(pattern, cancellationToken)
                );

                _logger.LogDebug($"Hybrid Cache REMOVE BY PATTERN -> Pattern: {pattern}");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error removing hybrid cache by pattern: {pattern}");
            }
        }

        public async Task SetWithGroupAsync<T>(string key, T value, string groupKey, TimeSpan? expiration = null, CancellationToken cancellationToken = default) where T : class
        {
            try
            {
                // Set in both caches with group
                var memoryExpiration = expiration.HasValue && expiration.Value < _memoryExpiration 
                    ? expiration.Value 
                    : _memoryExpiration;

                await Task.WhenAll(
                    _memoryCache.SetWithGroupAsync(key, value, groupKey, memoryExpiration, cancellationToken),
                    _redisCache.SetWithGroupAsync(key, value, groupKey, expiration, cancellationToken)
                );

                _logger.LogDebug($"Hybrid Cache SET WITH GROUP -> Key: {key}, Group: {groupKey}");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error setting hybrid cache with group - Key: {key}, Group: {groupKey}");
            }
        }

        public async Task SetValueWithGroupAsync<T>(string key, T value, string groupKey, TimeSpan? expiration = null, CancellationToken cancellationToken = default) where T : struct
        {
            try
            {
                // Set in both caches with group
                var memoryExpiration = expiration.HasValue && expiration.Value < _memoryExpiration 
                    ? expiration.Value 
                    : _memoryExpiration;

                await Task.WhenAll(
                    _memoryCache.SetValueWithGroupAsync(key, value, groupKey, memoryExpiration, cancellationToken),
                    _redisCache.SetValueWithGroupAsync(key, value, groupKey, expiration, cancellationToken)
                );

                _logger.LogDebug($"Hybrid Cache SET VALUE WITH GROUP -> Key: {key}, Group: {groupKey}");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error setting hybrid cache value with group - Key: {key}, Group: {groupKey}");
            }
        }

        public async Task RemoveGroupAsync(string groupKey, CancellationToken cancellationToken = default)
        {
            try
            {
                // Remove group from both caches
                await Task.WhenAll(
                    _memoryCache.RemoveGroupAsync(groupKey, cancellationToken),
                    _redisCache.RemoveGroupAsync(groupKey, cancellationToken)
                );

                _logger.LogDebug($"Hybrid Cache REMOVE GROUP -> Group: {groupKey}");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error removing hybrid cache group: {groupKey}");
            }
        }

        public async Task<List<string>> GetGroupKeysAsync(string groupKey, CancellationToken cancellationToken = default)
        {
            try
            {
                // Try memory first, then Redis
                var memoryKeys = await _memoryCache.GetGroupKeysAsync(groupKey, cancellationToken);
                if (memoryKeys.Any())
                {
                    return memoryKeys;
                }

                var redisKeys = await _redisCache.GetGroupKeysAsync(groupKey, cancellationToken);
                return redisKeys;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error getting hybrid cache group keys: {groupKey}");
                return new List<string>();
            }
        }

        public async Task<bool> ExistsAsync(string key, CancellationToken cancellationToken = default)
        {
            try
            {
                // Check memory first, then Redis
                var memoryExists = await _memoryCache.ExistsAsync(key, cancellationToken);
                if (memoryExists)
                {
                    return true;
                }

                var redisExists = await _redisCache.ExistsAsync(key, cancellationToken);
                return redisExists;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error checking hybrid cache key existence: {key}");
                return false;
            }
        }

        public async Task<long> GetCacheSizeAsync(CancellationToken cancellationToken = default)
        {
            try
            {
                // Return Redis size as it's the primary store
                return await _redisCache.GetCacheSizeAsync(cancellationToken);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error getting hybrid cache size");
                return 0;
            }
        }

        public async Task FlushAllAsync(CancellationToken cancellationToken = default)
        {
            try
            {
                // Flush both caches
                await Task.WhenAll(
                    _memoryCache.FlushAllAsync(cancellationToken),
                    _redisCache.FlushAllAsync(cancellationToken)
                );

                _logger.LogInformation("Hybrid Cache FLUSH ALL -> Both L1 and L2 caches cleared");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error flushing hybrid cache");
            }
        }
    }
}