# Performance Optimizasyonları

## 1. Query Optimizasyonları

### Mevcut Sorun

ContentController'da çok fazla Include() kullanımı N+1 problemine yol açabilir.

### Çözüm Önerisi

```csharp
// Projection kullanarak sadece gerekli alanları çek
var pageData = await _pazarAtlasiDbContext.Pages
    .Where(p => p.Slug == query.Slug)
    .Select(p => new PageResponse
    {
        Id = p.Id,
        Name = p.Name,
        Slug = p.Slug,
        Sections = p.PageSections
            .OrderBy(ps => ps.SortOrder)
            .Select(ps => new SectionResponse
            {
                Id = ps.Section.Id,
                Type = ps.Section.Type,
                Name = ps.Section.Translations
                    .Where(st => st.LanguageId == languageId)
                    .Select(st => st.Name)
                    .FirstOrDefault()
            })
    })
    .FirstOrDefaultAsync();
```

## 2. Caching Stratejisi

### Redis Cache Implementation

```csharp
public class CachedContentService : IContentService
{
    private readonly IDistributedCache _cache;
    private readonly ContentService _contentService;

    public async Task<PageResponse> GetPageAsync(string slug, string culture)
    {
        var cacheKey = $"page:{slug}:{culture}";
        var cached = await _cache.GetStringAsync(cacheKey);

        if (cached != null)
        {
            return JsonSerializer.Deserialize<PageResponse>(cached);
        }

        var page = await _contentService.GetPageAsync(slug, culture);

        await _cache.SetStringAsync(cacheKey,
            JsonSerializer.Serialize(page),
            new DistributedCacheEntryOptions
            {
                AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(30)
            });

        return page;
    }
}
```

## 3. Database Indexing

### Önerilen İndeksler

```sql
-- Page slug için composite index
CREATE INDEX IX_Pages_Slug_Status_IsDeleted
ON Pages (Slug, Status, IsDeleted);

-- Section key için index
CREATE INDEX IX_Sections_Key_Status_IsDeleted
ON Sections ([Key], Status, IsDeleted);

-- SectionItemFieldValue için composite index
CREATE INDEX IX_SectionItemFieldValues_SectionId_SectionItemId_FieldId
ON SectionItemFieldValues (SectionId, SectionItemId, SectionItemFieldId);
```
