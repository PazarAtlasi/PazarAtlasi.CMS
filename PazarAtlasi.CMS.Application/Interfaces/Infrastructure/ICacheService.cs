namespace PazarAtlasi.CMS.Application.Interfaces.Infrastructure
{
    public interface ICacheService
    {
        Task<T?> GetAsync<T>(string key, CancellationToken cancellationToken = default) where T : class;
        Task<string?> GetStringAsync(string key, CancellationToken cancellationToken = default);
        Task SetAsync<T>(string key, T value, TimeSpan? expiration = null, CancellationToken cancellationToken = default) where T : class;
        Task SetStringAsync(string key, string value, TimeSpan? expiration = null, CancellationToken cancellationToken = default);
        Task RemoveAsync(string key, CancellationToken cancellationToken = default);
        Task RemoveByPatternAsync(string pattern, CancellationToken cancellationToken = default);
        
        // Group Cache Management
        Task SetWithGroupAsync<T>(string key, T value, string groupKey, TimeSpan? expiration = null, CancellationToken cancellationToken = default) where T : class;
        Task RemoveGroupAsync(string groupKey, CancellationToken cancellationToken = default);
        Task<List<string>> GetGroupKeysAsync(string groupKey, CancellationToken cancellationToken = default);
        
        // Cache Statistics
        Task<bool> ExistsAsync(string key, CancellationToken cancellationToken = default);
        Task<long> GetCacheSizeAsync(CancellationToken cancellationToken = default);
        Task FlushAllAsync(CancellationToken cancellationToken = default);
    }
}