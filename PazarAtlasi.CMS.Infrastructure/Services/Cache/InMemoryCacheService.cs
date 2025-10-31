using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Logging;
using PazarAtlasi.CMS.Application.Interfaces.Infrastructure;
using System.Text.Json;
using System.Text.RegularExpressions;

namespace PazarAtlasi.CMS.Infrastructure.Services.Cache
{
    public class InMemoryCacheService : ICacheService
    {
        private readonly IMemoryCache _memoryCache;
        private readonly ILogger<InMemoryCacheService> _logger;
        private readonly HashSet<string> _cacheKeys;
        private readonly object _lockObject = new object();

        public InMemoryCacheService(IMemoryCache memoryCache, ILogger<InMemoryCacheService> logger)
        {
            _memoryCache = memoryCache;
            _logger = logger;
            _cacheKeys = new HashSet<string>();
        }

        public Task<T?> GetAsync<T>(string key, CancellationToken cancellationToken = default) where T : class
        {
            try
            {
                var result = _memoryCache.Get<T>(key);
                _logger.LogDebug($"Cache GET -> Key: {key}, Found: {result != null}");
                return Task.FromResult(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error getting cache key: {key}");
                return Task.FromResult<T?>(null);
            }
        }

        public Task<T?> GetValueAsync<T>(string key, CancellationToken cancellationToken = default) where T : struct
        {
            try
            {
                var result = _memoryCache.Get<T?>(key);
                _logger.LogDebug($"Cache GET VALUE -> Key: {key}, Found: {result.HasValue}");
                return Task.FromResult(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error getting cache value key: {key}");
                return Task.FromResult<T?>(null);
            }
        }

        public Task<string?> GetStringAsync(string key, CancellationToken cancellationToken = default)
        {
            try
            {
                var result = _memoryCache.Get<string>(key);
                _logger.LogDebug($"Cache GET STRING -> Key: {key}, Found: {!string.IsNullOrEmpty(result)}");
                return Task.FromResult(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error getting cache string key: {key}");
                return Task.FromResult<string?>(null);
            }
        }

        public Task SetAsync<T>(string key, T value, TimeSpan? expiration = null, CancellationToken cancellationToken = default) where T : class
        {
            try
            {
                var options = new MemoryCacheEntryOptions();
                
                if (expiration.HasValue)
                {
                    options.SlidingExpiration = expiration.Value;
                }
                else
                {
                    options.SlidingExpiration = TimeSpan.FromMinutes(30); // Default 30 minutes
                }

                _memoryCache.Set(key, value, options);
                
                lock (_lockObject)
                {
                    _cacheKeys.Add(key);
                }

                _logger.LogDebug($"Cache SET -> Key: {key}, Expiration: {expiration?.TotalMinutes ?? 30} minutes");
                return Task.CompletedTask;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error setting cache key: {key}");
                return Task.CompletedTask;
            }
        }

        public Task SetValueAsync<T>(string key, T value, TimeSpan? expiration = null, CancellationToken cancellationToken = default) where T : struct
        {
            try
            {
                var options = new MemoryCacheEntryOptions();
                
                if (expiration.HasValue)
                {
                    options.SlidingExpiration = expiration.Value;
                }
                else
                {
                    options.SlidingExpiration = TimeSpan.FromMinutes(30);
                }

                _memoryCache.Set(key, value, options);
                
                lock (_lockObject)
                {
                    _cacheKeys.Add(key);
                }

                _logger.LogDebug($"Cache SET VALUE -> Key: {key}, Expiration: {expiration?.TotalMinutes ?? 30} minutes");
                return Task.CompletedTask;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error setting cache value key: {key}");
                return Task.CompletedTask;
            }
        }

        public Task SetStringAsync(string key, string value, TimeSpan? expiration = null, CancellationToken cancellationToken = default)
        {
            try
            {
                var options = new MemoryCacheEntryOptions();
                
                if (expiration.HasValue)
                {
                    options.SlidingExpiration = expiration.Value;
                }
                else
                {
                    options.SlidingExpiration = TimeSpan.FromMinutes(30);
                }

                _memoryCache.Set(key, value, options);
                
                lock (_lockObject)
                {
                    _cacheKeys.Add(key);
                }

                _logger.LogDebug($"Cache SET STRING -> Key: {key}");
                return Task.CompletedTask;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error setting cache string key: {key}");
                return Task.CompletedTask;
            }
        }

        public Task RemoveAsync(string key, CancellationToken cancellationToken = default)
        {
            try
            {
                _memoryCache.Remove(key);
                
                lock (_lockObject)
                {
                    _cacheKeys.Remove(key);
                }

                _logger.LogDebug($"Cache REMOVE -> Key: {key}");
                return Task.CompletedTask;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error removing cache key: {key}");
                return Task.CompletedTask;
            }
        }

        public Task RemoveByPatternAsync(string pattern, CancellationToken cancellationToken = default)
        {
            try
            {
                var regex = new Regex(pattern, RegexOptions.IgnoreCase);
                var keysToRemove = new List<string>();

                lock (_lockObject)
                {
                    keysToRemove.AddRange(_cacheKeys.Where(key => regex.IsMatch(key)));
                }

                foreach (var key in keysToRemove)
                {
                    _memoryCache.Remove(key);
                    lock (_lockObject)
                    {
                        _cacheKeys.Remove(key);
                    }
                }

                _logger.LogDebug($"Cache REMOVE BY PATTERN -> Pattern: {pattern}, Removed: {keysToRemove.Count} keys");
                return Task.CompletedTask;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error removing cache by pattern: {pattern}");
                return Task.CompletedTask;
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

                _logger.LogDebug($"Cache SET WITH GROUP -> Key: {key}, Group: {groupKey}");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error setting cache with group - Key: {key}, Group: {groupKey}");
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

                _logger.LogDebug($"Cache SET VALUE WITH GROUP -> Key: {key}, Group: {groupKey}");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error setting cache value with group - Key: {key}, Group: {groupKey}");
            }
        }

        public async Task RemoveGroupAsync(string groupKey, CancellationToken cancellationToken = default)
        {
            try
            {
                var groupKeys = await GetGroupKeysAsync(groupKey, cancellationToken);
                
                foreach (var key in groupKeys)
                {
                    await RemoveAsync(key, cancellationToken);
                }

                // Remove group metadata
                await RemoveAsync(groupKey, cancellationToken);
                await RemoveAsync($"{groupKey}SlidingExpiration", cancellationToken);

                _logger.LogDebug($"Cache REMOVE GROUP -> Group: {groupKey}, Removed: {groupKeys.Count} keys");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error removing cache group: {groupKey}");
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
                _logger.LogError(ex, $"Error getting group keys: {groupKey}");
                return new List<string>();
            }
        }

        public Task<bool> ExistsAsync(string key, CancellationToken cancellationToken = default)
        {
            try
            {
                var exists = _memoryCache.TryGetValue(key, out _);
                return Task.FromResult(exists);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error checking cache key existence: {key}");
                return Task.FromResult(false);
            }
        }

        public Task<long> GetCacheSizeAsync(CancellationToken cancellationToken = default)
        {
            lock (_lockObject)
            {
                return Task.FromResult((long)_cacheKeys.Count);
            }
        }

        public Task FlushAllAsync(CancellationToken cancellationToken = default)
        {
            try
            {
                var keysToRemove = new List<string>();
                
                lock (_lockObject)
                {
                    keysToRemove.AddRange(_cacheKeys);
                    _cacheKeys.Clear();
                }

                foreach (var key in keysToRemove)
                {
                    _memoryCache.Remove(key);
                }

                _logger.LogInformation($"Cache FLUSH ALL -> Removed: {keysToRemove.Count} keys");
                return Task.CompletedTask;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error flushing all cache");
                return Task.CompletedTask;
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

                _logger.LogDebug($"Added to Cache Group -> Group: {groupKey}, Key: {cacheKey}");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error adding cache key to group - Key: {cacheKey}, Group: {groupKey}");
            }
        }
    }
}