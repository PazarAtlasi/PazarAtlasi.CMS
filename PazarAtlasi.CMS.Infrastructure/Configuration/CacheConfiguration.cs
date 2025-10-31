namespace PazarAtlasi.CMS.Infrastructure.Configuration
{
    public class CacheConfiguration
    {
        public CacheType Type { get; set; } = CacheType.InMemory;
        public string? ConnectionString { get; set; }
        public int DefaultExpirationMinutes { get; set; } = 30;
        public int MemoryCacheExpirationMinutes { get; set; } = 5; // For hybrid cache L1
        public bool EnableCompression { get; set; } = true;
        public bool EnableLogging { get; set; } = true;
    }

    public enum CacheType
    {
        InMemory,
        Redis,
        Hybrid
    }
}