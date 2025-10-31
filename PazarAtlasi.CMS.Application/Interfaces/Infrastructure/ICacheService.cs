namespace PazarAtlasi.CMS.Application.Interfaces.Infrastructure
{
    public interface ICacheService
    {
        // Reference types
        Task<T?> GetAsync<T>(string key, CancellationToken cancellationToken = default) where T : class;
        Task SetAsync<T>(string key, T value, TimeSpan? expiration = null, CancellationToken cancellationToken = default) where T : class;
        Task SetWithGroupAsync<T>(string key, T value, string groupKey, TimeSpan? expiration = null, CancellationToken cancellationToken = default) where T : class;
        
        // Value types
        Task<T?> GetValueAsync<T>(string key, CancellationToken cancellationToken = default) where T : struct;
        Task SetValueAsync<T>(string key, T value, TimeSpan? expiration = null, CancellationToken cancellationToken = default) where T : struct;
        Task SetValueWithGroupAsync<T>(string key, T value, string groupKey, TimeSpan? expiration = null, CancellationToken cancellationToken = default) where T : struct;
        
        // String methods
        Task<string?> GetStringAsync(string key, CancellationToken cancellationToken = default);
        Task SetStringAsync(string key, string value, TimeSpan? expiration = null, CancellationToken cancellationToken = default);
        
        // Management methods
        Task RemoveAsync(string key, CancellationToken cancellationToken = default);
        Task RemoveByPatternAsync(string pattern, CancellationToken cancellationToken = default);
        Task RemoveGroupAsync(string groupKey, CancellationToken cancellationToken = default);
        Task<List<string>> GetGroupKeysAsync(string groupKey, CancellationToken cancellationToken = default);
        
        // Cache Statistics
        Task<bool> ExistsAsync(string key, CancellationToken cancellationToken = default);
        Task<long> GetCacheSizeAsync(CancellationToken cancellationToken = default);
        Task FlushAllAsync(CancellationToken cancellationToken = default);
    }
}