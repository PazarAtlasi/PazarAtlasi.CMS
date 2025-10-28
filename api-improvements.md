# API Geliştirme Önerileri

## 1. GraphQL Entegrasyonu

### Neden GraphQL?

- Client'ın sadece ihtiyacı olan veriyi çekmesi
- Over-fetching ve under-fetching problemlerinin çözümü
- Tek endpoint ile tüm veri ihtiyaçları

### Implementation

```csharp
public class PageType : ObjectGraphType<Page>
{
    public PageType()
    {
        Field(x => x.Id);
        Field(x => x.Name);
        Field(x => x.Slug);

        Field<ListGraphType<SectionType>>("sections")
            .ResolveAsync(async context =>
            {
                var dataLoader = context.RequestServices.GetRequiredService<ISectionDataLoader>();
                return await dataLoader.LoadAsync(context.Source.Id);
            });
    }
}
```

## 2. API Versioning

### Semantic Versioning

```csharp
[ApiVersion("1.0")]
[ApiVersion("2.0")]
[Route("api/v{version:apiVersion}/[controller]")]
public class ContentController : ControllerBase
{
    [HttpGet("page")]
    [MapToApiVersion("1.0")]
    public async Task<PageResponseV1> GetPageV1([FromQuery] PageQuery query)
    {
        // V1 implementation
    }

    [HttpGet("page")]
    [MapToApiVersion("2.0")]
    public async Task<PageResponseV2> GetPageV2([FromQuery] PageQueryV2 query)
    {
        // V2 implementation with new features
    }
}
```

## 3. Response Compression

### Gzip Compression

```csharp
public void ConfigureServices(IServiceCollection services)
{
    services.AddResponseCompression(options =>
    {
        options.EnableForHttps = true;
        options.Providers.Add<GzipCompressionProvider>();
    });

    services.Configure<GzipCompressionProviderOptions>(options =>
    {
        options.Level = CompressionLevel.Optimal;
    });
}
```

## 4. Rate Limiting

### AspNetCoreRateLimit

```csharp
public void ConfigureServices(IServiceCollection services)
{
    services.AddMemoryCache();
    services.Configure<IpRateLimitOptions>(Configuration.GetSection("IpRateLimiting"));
    services.AddSingleton<IIpPolicyStore, MemoryCacheIpPolicyStore>();
    services.AddSingleton<IRateLimitCounterStore, MemoryCacheRateLimitCounterStore>();
    services.AddSingleton<IRateLimitConfiguration, RateLimitConfiguration>();
}
```

## 5. Health Checks

### Database Health Check

```csharp
public void ConfigureServices(IServiceCollection services)
{
    services.AddHealthChecks()
        .AddDbContextCheck<PazarAtlasiDbContext>()
        .AddRedis(Configuration.GetConnectionString("Redis"));
}

public void Configure(IApplicationBuilder app)
{
    app.UseHealthChecks("/health", new HealthCheckOptions
    {
        ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse
    });
}
```
