using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Logging;
using PazarAtlasi.CMS.Application.Interfaces.Infrastructure;
using StackExchange.Redis;
using System.Text;
using System.Text.Json;

namespace PazarAtlasi.CMS.Infrastructure.Services.Cache
{
    public class RedisCacheService : ICacheService
    {
        private readonly IDistributedCache _distributedCache;
        private readonly IConnectionMultiplexer _connectionMultiplexer;
        private readonly IDatabase _database;
        private readonly ILogger<RedisCacheService> _logger;

        public RedisCacheService(
            IDistributedCache distributedCache,
            IConnectionMultiplexer connectionMultiplexer,
            ILogger<RedisCacheService> logger)
        {
            _distributedCache = distributedCache;
            _connectionMultiplexer = connectionMultiplexer;
            _database = _connectionMultiplexer.GetDatabase();
            _logger = logger;
        }

        public async Task<T?> GetAsync<T>(string key, CancellationToken cancellationToken = default) where T : class
        {
            try
            {
                var cachedValue = await _distributedCache.GetAsync(key, cancellationToken);
                
                if (cachedValue == null)
                {
                    _logger.LogDebug($"Redis Cache MISS -> Key: {key}");
                    return null;
                }

                var jsonString = Encoding.UTF8.GetString(cachedValue);
                var result = JsonSerializer.Deserialize<T>(jsonString);
                
                _logger.LogDebug($"Redis Cache HIT -> Key: {key}");
                return result;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error getting Redis cache key: {key}");
                return null;
            }
        }

        public async Task<T?> GetValueAsync<T>(string key, CancellationToken cancellationToken = default) where T : struct
        {
            try
            {
                var cachedValue = await _distributedCache.GetAsync(key, cancellationToken);
                
                if (cachedValue == null)
                {
                    _logger.LogDebug($"Redis Cache VALUE MISS -> Key: {key}");
                    return null;
                }

                var jsonString = Encoding.UTF8.GetString(cachedValue);
                var result = JsonSerializer.Deserialize<T?>(jsonString);
                
                _logger.LogDebug($"Redis Cache VALUE HIT -> Key: {key}");
                return result;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error getting Redis cache value key: {key}");
                return null;
            }
        }

        public async Task<string?> GetStringAsync(string key, CancellationToken cancellationToken = default)
        {
            try
            {
                var result = await _distributedCache.GetStringAsync(key, cancellationToken);
                _logger.LogDebug($"Redis Cache GET STRING -> Key: {key}, Found: {!string.IsNullOrEmpty(result)}");
                return result;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error getting Redis cache string key: {key}");
                return null;
            }
        }

        public async Task SetAsync<T>(string key, T value, TimeSpan? expiration = null, CancellationToken cancellationToken = default) where T : class
        {
            try
            {
                var jsonString = JsonSerializer.Serialize(value);
                var encodedValue = Encoding.UTF8.GetBytes(jsonString);

                var options = new DistributedCacheEntryOptions();
                
                if (expiration.HasValue)
                {
                    options.SlidingExpiration = expiration.Value;
                }
                else
                {
                    options.SlidingExpiration = TimeSpan.FromMinutes(30); // Default 30 minutes
                }

                await _distributedCache.SetAsync(key, encodedValue, options, cancellationToken);
                
                _logger.LogDebug($"Redis Cache SET -> Key: {key}, Expiration: {expiration?.TotalMinutes ?? 30} minutes");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error setting Redis cache key: {key}");
            }
        }

        public async Task SetValueAsync<T>(string key, T value, TimeSpan? expiration = null, CancellationToken cancellationToken = default) where T : struct
        {
            try
            {
                var jsonString = JsonSerializer.Serialize(value);
                var encodedValue = Encoding.UTF8.GetBytes(jsonString);

                var options = new DistributedCacheEntryOptions();
                
                if (expiration.HasValue)
                {
                    options.SlidingExpiration = expiration.Value;
                }
                else
                {
                    options.SlidingExpiration = TimeSpan.FromMinutes(30);
                }

                await _distributedCache.SetAsync(key, encodedValue, options, cancellationToken);
                
                _logger.LogDebug($"Redis Cache SET VALUE -> Key: {key}, Expiration: {expiration?.TotalMinutes ?? 30} minutes");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error setting Redis cache value key: {key}");
            }
        }

        public async Task SetStringAsync(string key, string value, TimeSpan? expiration = null, CancellationToken cancellationToken = default)
        {
            try
            {
                var options = new DistributedCacheEntryOptions();
                
                if (expiration.HasValue)
                {
                    options.SlidingExpiration = expiration.Value;
                }
                else
                {
                    options.SlidingExpiration = TimeSpan.FromMinutes(30);
                }

                await _distributedCache.SetStringAsync(key, value, options, cancellationToken);
                
                _logger.LogDebug($"Redis Cache SET STRING -> Key: {key}");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error setting Redis cache string key: {key}");
            }
        }

        public async Task RemoveAsync(string key, CancellationToken cancellationToken = default)
        {
            try
            {
                await _distributedCache.RemoveAsync(key, cancellationToken);
                _logger.LogDebug($"Redis Cache REMOVE -> Key: {key}");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error removing Redis cache key: {key}");
            }
        }

        public async Task RemoveByPatternAsync(string pattern, CancellationToken cancellationToken = default)
        {
            try
            {
                var server = _connectionMultiplexer.GetServer(_connectionMultiplexer.GetEndPoints().First());
                var keys = server.Keys(pattern: pattern).ToArray();

                if (keys.Length > 0)
                {
                    await _database.KeyDeleteAsync(keys);
                    _logger.LogDebug($"Redis Cache REMOVE BY PATTERN -> Pattern: {pattern}, Removed: {keys.Length} keys");
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error removing Redis cache by pattern: {pattern}");
            }
        }

        public async Task SetWithGroupAsync<T>(string key, T value, string groupKey, TimeSpan? expiration = null, CancellationToken cancellationToken = default) where T : class
        {
            try
            {
                // Set the actual cache value
                await SetAsync(key, value, expiration, cancellationToken);

                // Add key to group
                await AddCacheKeyToGroupAsync(key, groupKey, expiration ?? TimeSpan.FromMinutes(30), cancellationToken);

                _logger.LogDebug($"Redis Cache SET WITH GROUP -> Key: {key}, Group: {groupKey}");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error setting Redis cache with group - Key: {key}, Group: {groupKey}");
            }
        }

        public async Task SetValueWithGroupAsync<T>(string key, T value, string groupKey, TimeSpan? expiration = null, CancellationToken cancellationToken = default) where T : struct
        {
            try
            {
                // Set the actual cache value
                await SetValueAsync(key, value, expiration, cancellationToken);

                // Add key to group
                await AddCacheKeyToGroupAsync(key, groupKey, expiration ?? TimeSpan.FromMinutes(30), cancellationToken);

                _logger.LogDebug($"Redis Cache SET VALUE WITH GROUP -> Key: {key}, Group: {groupKey}");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error setting Redis cache value with group - Key: {key}, Group: {groupKey}");
            }
        }

        public async Task RemoveGroupAsync(string groupKey, CancellationToken cancellationToken = default)
        {
            try
            {
                var groupKeys = await GetGroupKeysAsync(groupKey, cancellationToken);
                
                if (groupKeys.Any())
                {
                    var redisKeys = groupKeys.Select(k => (RedisKey)k).ToArray();
                    await _database.KeyDeleteAsync(redisKeys);
                }

                // Remove group metadata
                await RemoveAsync(groupKey, cancellationToken);
                await RemoveAsync($"{groupKey}SlidingExpiration", cancellationToken);

                _logger.LogDebug($"Redis Cache REMOVE GROUP -> Group: {groupKey}, Removed: {groupKeys.Count} keys");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error removing Redis cache group: {groupKey}");
            }
        }

        public async Task<List<string>> GetGroupKeysAsync(string groupKey, CancellationToken cancellationToken = default)
        {
            try
            {
                var groupCache = await GetAsync<HashSet<string>>(groupKey, cancellationToken);
                return groupCache?.ToList() ?? new List<string>();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error getting Redis group keys: {groupKey}");
                return new List<string>();
            }
        }

        public async Task<bool> ExistsAsync(string key, CancellationToken cancellationToken = default)
        {
            try
            {
                var exists = await _database.KeyExistsAsync(key);
                return exists;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error checking Redis cache key existence: {key}");
                return false;
            }
        }

        public async Task<long> GetCacheSizeAsync(CancellationToken cancellationToken = default)
        {
            try
            {
                var server = _connectionMultiplexer.GetServer(_connectionMultiplexer.GetEndPoints().First());
                var keyCount = await server.DatabaseSizeAsync();
                return keyCount;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error getting Redis cache size");
                return 0;
            }
        }

        public async Task FlushAllAsync(CancellationToken cancellationToken = default)
        {
            try
            {
                var server = _connectionMultiplexer.GetServer(_connectionMultiplexer.GetEndPoints().First());
                await server.FlushDatabaseAsync();
                _logger.LogInformation("Redis Cache FLUSH ALL -> All keys removed");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error flushing Redis cache");
            }
        }

        private async Task AddCacheKeyToGroupAsync(string cacheKey, string groupKey, TimeSpan slidingExpiration, CancellationToken cancellationToken)
        {
            try
            {
                var cacheKeysInGroup = await GetAsync<HashSet<string>>(groupKey, cancellationToken) ?? new HashSet<string>();
                
                if (!cacheKeysInGroup.Contains(cacheKey))
                {
                    cacheKeysInGroup.Add(cacheKey);
                }

                await SetAsync(groupKey, cacheKeysInGroup, slidingExpiration, cancellationToken);

                // Store group expiration info
                var currentExpiration = await GetValueAsync<int>($"{groupKey}SlidingExpiration", cancellationToken);
                var newExpirationSeconds = (int)slidingExpiration.TotalSeconds;

                if (currentExpiration == null || newExpirationSeconds > currentExpiration.Value)
                {
                    await SetValueAsync($"{groupKey}SlidingExpiration", newExpirationSeconds, slidingExpiration, cancellationToken);
                }

                _logger.LogDebug($"Added to Redis Cache Group -> Group: {groupKey}, Key: {cacheKey}");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error adding cache key to Redis group - Key: {cacheKey}, Group: {groupKey}");
            }
        }
    }
}