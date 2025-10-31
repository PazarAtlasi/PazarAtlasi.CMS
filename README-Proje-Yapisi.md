# PazarAtlasi CMS - Proje Yapısı ve Geliştirme Rehberi

## 📋 Genel Bakış

Bu proje Clean Architecture prensiplerine göre tasarlanmış bir CMS sistemidir. Section, SectionItem ve Field yapıları ile esnek içerik yönetimi sağlar.

## 🏗️ Katman Yapısı

### 1. Domain Katmanı (`PazarAtlasi.CMS.Domain`)

İş mantığının ve entity'lerin bulunduğu katman.

```
PazarAtlasi.CMS.Domain/
├── Common/
│   ├── Entity.cs           # Base entity sınıfı
│   └── Enums.cs           # Genel enum'lar
├── Entities/
│   ├── Content/           # İçerik entity'leri
│   ├── Identity/          # Kullanıcı entity'leri
│   └── Metadata/          # Meta veri entity'leri
├── Enums/                 # Domain enum'ları
├── Exceptions/            # Domain exception'ları
└── ValueObjects/          # Value object'ler
```

### 2. Persistence Katmanı (`PazarAtlasi.CMS.Persistence`)

Veritabanı işlemlerinin yapıldığı katman.

```
PazarAtlasi.CMS.Persistence/
├── Context/
│   └── ApplicationDbContext.cs
├── EntityConfigurations/
│   └── Content/           # Entity configuration'ları
├── Migrations/            # EF Core migration'ları
└── Interceptors/          # EF Core interceptor'ları
```

## 🎯 Entity Geliştirme Kuralları

### Entity Oluşturma

**✅ Doğru Kullanım:**

```csharp
// Domain katmanında: PazarAtlasi.CMS.Domain/Entities/Content/
public class Section : Entity<int>
{
    public SectionType Type { get; set; } = SectionType.None;
    public string? Attributes { get; set; }
    public int SortOrder { get; set; } = 0;

    // Navigation Properties
    public virtual ICollection<SectionItemValue> SectionItemValues { get; set; } = new List<SectionItemValue>();
}
```

**❌ Yanlış Kullanım:**

```csharp
// Base class kullanmamak
public class Section
{
    public int Id { get; set; }
    // Diğer özellikler...
}

// Yanlış generic tip
public class Section : Entity<string> // int olmalı
```

### Entity Configuration

**✅ Doğru Kullanım:**

```csharp
// Persistence katmanında: PazarAtlasi.CMS.Persistence/EntityConfigurations/Content/
public class SectionConfigurationBuilder : IEntityTypeConfiguration<Section>
{
    public void Configure(EntityTypeBuilder<Section> builder)
    {
        // Tablo adı ve primary key
        builder.ToTable("Sections").HasKey(s => s.Id);

        // Özellik konfigürasyonları
        builder.Property(s => s.Id).HasColumnName("Id").IsRequired();
        builder.Property(s => s.Type).HasColumnName("Type").HasDefaultValue(SectionType.None);

        // İlişkiler
        builder.HasMany(s => s.SectionItemValues)
               .WithOne(siv => siv.Section)
               .HasForeignKey(siv => siv.SectionId)
               .OnDelete(DeleteBehavior.Cascade);

        // İndeksler
        builder.HasIndex(s => s.Type).HasDatabaseName("IX_Sections_Type");

        // Query Filter (Soft Delete)
        builder.HasQueryFilter(s => !s.IsDeleted);

        // Seed Data (opsiyonel)
        builder.HasData(/* seed data */);
    }
}
```

## 📊 Section-SectionItem-Field Yapısı

### Hiyerarşi

```
Section (Ana bölüm)
├── SectionItemValue (Hangi item'ların bu section'da olduğu)
│   └── SectionItem (İçerik öğesi)
│       ├── SectionItemField (Alan tanımları)
│       └── SectionItemFieldValue (Alan değerleri)
```

### 1. Section Entity

Ana içerik bölümlerini temsil eder (Hero, Featured, Newsletter vb.)

```csharp
public class Section : Entity<int>
{
    public SectionType Type { get; set; }           // Bölüm tipi
    public string? Attributes { get; set; }         // JSON attributes
    public int SortOrder { get; set; }              // Sıralama
    public string? Configure { get; set; }          // JSON konfigürasyon

    // İlişkiler
    public virtual ICollection<SectionItemValue> SectionItemValues { get; set; }
    public virtual ICollection<SectionTranslation> Translations { get; set; }
}
```

### 2. SectionItem Entity

Yeniden kullanılabilir içerik öğelerini temsil eder.

```csharp
public class SectionItem : Entity<int>
{
    public int? ParentSectionItemId { get; set; }   // Hiyerarşik yapı
    public int? TemplateId { get; set; }            // Template referansı
    public SectionItemType Type { get; set; }       // Item tipi
    public string? Title { get; set; }              // Başlık
    public string? Key { get; set; }                // Benzersiz anahtar
    public bool AllowReorder { get; set; }          // Yeniden sıralanabilir mi?
    public bool AllowRemove { get; set; }           // Silinebilir mi?

    // İlişkiler
    public virtual ICollection<SectionItemField> SectionItemFields { get; set; }
    public virtual ICollection<SectionItemFieldValue> SectionItemFieldValues { get; set; }
    public virtual ICollection<SectionItemValue> SectionItemValues { get; set; }
}
```

### 3. SectionItemValue Entity

Section ve SectionItem arasındaki bağlantıyı sağlar.

```csharp
public class SectionItemValue : Entity<int>
{
    public int SectionId { get; set; }              // Hangi section
    public int SectionItemId { get; set; }          // Hangi item

    // Navigation Properties
    public virtual Section Section { get; set; }
    public virtual SectionItem SectionItem { get; set; }
}
```

### 4. SectionItemField Entity

Alan tanımlarını (metadata) tutar.

```csharp
public class SectionItemField : Entity<int>
{
    public int SectionItemId { get; set; }          // Hangi item'a ait
    public string FieldKey { get; set; }            // Alan anahtarı (title, image vb.)
    public string FieldName { get; set; }           // Görünen ad
    public SectionItemFieldType Type { get; set; }  // Alan tipi
    public bool Required { get; set; }              // Zorunlu mu?
    public bool IsTranslatable { get; set; }        // Çevrilebilir mi?
    public int SortOrder { get; set; }              // Sıralama
}
```

### 5. SectionItemFieldValue Entity

Gerçek alan değerlerini tutar.

```csharp
public class SectionItemFieldValue : Entity<int>
{
    public int SectionId { get; set; }              // Hangi section
    public int SectionItemId { get; set; }          // Hangi item
    public int SectionItemFieldId { get; set; }     // Hangi field
    public string Value { get; set; }               // Değer
    public string? JsonValue { get; set; }          // Kompleks değerler için JSON
}
```

## 🔧 Geliştirme Kuralları

### Entity Kuralları

1. **Base Class**: Tüm entity'ler `Entity<int>` sınıfından türemeli
2. **Konum**: Domain katmanında `/Entities/` klasöründe organize edilmeli
3. **Navigation Properties**: `virtual` olarak tanımlanmalı
4. **Collections**: `ICollection<T>` kullanılmalı ve `new List<T>()` ile initialize edilmeli

### Configuration Kuralları

1. **Konum**: Persistence katmanında `/EntityConfigurations/` klasöründe
2. **Naming**: `{EntityName}ConfigurationBuilder` şeklinde adlandırılmalı
3. **Interface**: `IEntityTypeConfiguration<T>` implement etmeli
4. **Tablo Adı**: `ToTable()` ile açıkça belirtilmeli
5. **Primary Key**: `HasKey()` ile tanımlanmalı
6. **Column Names**: `HasColumnName()` ile açıkça belirtilmeli
7. **Default Values**: `HasDefaultValue()` ile tanımlanmalı
8. **Indexes**: Performance için gerekli indeksler oluşturulmalı
9. **Query Filter**: Soft delete için `HasQueryFilter()` kullanılmalı

### İlişki Kuralları

1. **Foreign Keys**: `HasForeignKey()` ile açıkça belirtilmeli
2. **Delete Behavior**: İlişki tipine göre uygun `DeleteBehavior` seçilmeli
   - `Cascade`: Bağımlı veriler silinebilir
   - `Restrict`: Bağımlı veri varsa silme engellenmeli
   - `SetNull`: Foreign key null yapılabilir

### Index Kuralları

1. **Naming**: `IX_{TableName}_{ColumnName}` formatında
2. **Composite**: Birden fazla sütun için `IX_{TableName}_{Column1}_{Column2}`
3. **Performance**: Sık sorgulanan alanlar için mutlaka index oluşturulmalı

## 📝 Örnek Kullanım Senaryoları

### Yeni Entity Ekleme

1. Domain katmanında entity oluştur
2. Persistence katmanında configuration ekle
3. DbContext'e DbSet ekle
4. Migration oluştur ve çalıştır

### İlişkili Entity'ler

```csharp
// One-to-Many ilişki
builder.HasMany(s => s.SectionItemValues)
       .WithOne(siv => siv.Section)
       .HasForeignKey(siv => siv.SectionId)
       .OnDelete(DeleteBehavior.Cascade);

// Many-to-Many ilişki (junction table ile)
// SectionItemValue entity'si Section ve SectionItem arasında köprü görevi görür
```

### Soft Delete

```csharp
// Entity'de
public bool IsDeleted { get; set; } = false;

// Configuration'da
builder.HasQueryFilter(entity => !entity.IsDeleted);
```

## � Gelişmiş Field Management Sistemi

### Smart Field Update Algoritması

`UpdateSectionItemFields` metodunda field'ları güncellerken veri kaybını önleyen akıllı algoritma:

#### 🛡️ Veri Koruma Stratejisi

**Sorun**: Eski sistemde field'lar güncellenirken tüm mevcut field'lar silinip yeniden oluşturuluyordu. Bu, diğer sayfalardaki field value'ların kaybolmasına neden oluyordu.

**Çözüm**: Smart Update algoritması ile:

```csharp
// 1. Mevcut field'ları güncelle (value'ları koru)
foreach (var fieldDto in fieldDtos)
{
    var existingField = existingFields.FirstOrDefault(f => f.FieldKey == fieldDto.FieldKey);
    if (existingField != null)
    {
        // Field properties'ini güncelle, value'ları koru
        existingField.FieldName = fieldDto.FieldName;
        existingField.Type = fieldDto.Type;
        // ... diğer properties
    }
}

// 2. Kaldırılan field'ları kontrol et
foreach (var fieldToRemove in fieldsToRemove)
{
    var hasFieldValues = await _pazarAtlasiDbContext.SectionItemFieldValues
        .AnyAsync(fv => fv.SectionItemFieldId == fieldToRemove.Id);

    if (hasFieldValues)
    {
        // Value'ları olan field'ları sil değil, gizle
        fieldToRemove.ShowInUI = false;
        fieldToRemove.FieldName += " [DEPRECATED]";
    }
    else
    {
        // Güvenli silme - hiç value yok
        _pazarAtlasiDbContext.SectionItemFields.Remove(fieldToRemove);
    }
}
```

#### ✅ Avantajları

1. **Veri Kaybı Önleme**: Mevcut field value'ları korunur
2. **Güvenli Silme**: Sadece kullanılmayan field'lar silinir
3. **Backward Compatibility**: Eski field'lar deprecated olarak işaretlenir
4. **Performance**: Gereksiz silme/ekleme işlemleri azalır

## 🚀 Best Practices

1. **Naming Convention**: PascalCase kullan
2. **Nullable Properties**: Opsiyonel alanlar için `?` kullan
3. **Default Values**: Enum'lar için default değer belirle
4. **Validation**: Domain seviyesinde validation ekle
5. **Performance**: Lazy loading yerine explicit loading tercih et
6. **Translations**: Çoklu dil desteği için ayrı translation entity'leri kullan
7. **Field Management**: Smart update algoritması ile veri kaybını önle

## 🔍 Debugging ve Troubleshooting

### Yaygın Hatalar

1. **Missing Configuration**: Entity configuration unutulması
2. **Circular Reference**: JSON serialization'da döngüsel referans
3. **N+1 Problem**: İlişkili verileri tek sorguda çekmemek
4. **Missing Index**: Performance sorunları

### Çözümler

1. Configuration'ları kontrol et
2. `[JsonIgnore]` attribute'u kullan
3. `Include()` ve `ThenInclude()` kullan
4. Gerekli indeksleri ekle

5. Migration OLUŞTURMADAN ÖNCE SOR! BUNU KULLANICIYA BIRAK.

## � Gelişmimş Section Preview Sistemi

### Section Preview Geliştirmeleri

PageEdit sayfasında (`/Content/PageEdit/{id}`) section'ların görsel preview'ları önemli ölçüde geliştirildi:

#### 🔧 Yeni Özellikler

**1. Gelişmiş Section Header**

- Section type'a göre dinamik ikonlar
- Status badge'leri (Active/Draft/Pending)
- Section key gösterimi (`hero`, `navbar`, `footer` vb.)
- Hierarchical bilgi gösterimi (Order, Status, Item Count)

**2. Zengin Field Preview Sistemi**

- **Image Preview**: Tıklanabilir thumbnail'ler, modal preview
- **Video Preview**: Play button ile video önizleme
- **URL Preview**: Tıklanabilir linkler
- **Color Preview**: Renk kutuları ile görsel gösterim
- **Boolean/Checkbox**: Yeşil/kırmızı status göstergeleri
- **Icon Preview**: Gerçek ikon gösterimi
- **File Preview**: Download linkleri
- **Date/Number**: Formatlanmış gösterim

**3. İnteraktif Section Items Preview**

- Her item için type-specific ikonlar
- Field preview'ları responsive grid layout'ta
- Child items göstergesi
- Hover efektleri ve smooth animasyonlar

**4. Gelişmiş Section Settings Panel**

- Animasyonlu açılır/kapanır panel
- Gelişmiş form kontrolleri
- JSON editörleri (Attributes, Configure)
- Quick action butonları (Edit, Duplicate, Delete)

#### 📁 Yeni Dosyalar

```
PazarAtlasi.CMS/Views/Content/
├── _FieldPreview.cshtml        # Field preview partial view
├── _PageSectionsPartial.cshtml # Geliştirilmiş section preview
└── _SectionItemCard.cshtml     # Section item card component

PazarAtlasi.CMS/wwwroot/css/
└── page-edit.css              # Geliştirilmiş CSS stilleri

PazarAtlasi.CMS/wwwroot/js/Content/
└── Content.Page.js            # Preview JavaScript fonksiyonları
```

#### 🎨 CSS & JavaScript Geliştirmeleri

**CSS Özellikleri:**

- Smooth animasyonlar ve transitions
- Hover efektleri ve shadow'lar
- Responsive grid layouts
- Field-specific styling
- Modal preview stilleri

**JavaScript Fonksiyonları:**

- `previewImage()` - Image modal preview
- `previewVideo()` - Video modal preview
- `editSectionItems()` - Section item editor
- `toggleSectionSettings()` - Settings panel toggle
- Enhanced notification sistemi

#### 🔄 Field Preview Mapping

```csharp
// _FieldPreview.cshtml - Field type'a göre preview
switch (fieldType)
{
    case "image":
        // Thumbnail + modal preview + filename
        break;
    case "video":
        // Video thumbnail + play button + modal
        break;
    case "url":
        // Clickable link with external icon
        break;
    case "color":
        // Color box + hex value
        break;
    case "boolean":
        // Green/red status indicators
        break;
    // ... diğer field tipleri
}
```

## 🌐 API Katmanı (`PazarAtlasi.API`)

RESTful API servisleri ve endpoint'lerin bulunduğu katman.

```
PazarAtlasi.API/
├── Controllers/
│   └── ContentController.cs    # Content domain API endpoint'leri
├── Models/                     # API-specific modeller (opsiyonel)
├── Program.cs                  # API konfigürasyonu
└── Properties/
    └── launchSettings.json     # Geliştirme ayarları
```

### API Geliştirme Kuralları

#### Request/Response Model Yapısı

**✅ Doğru Kullanım:**

```csharp
// Request modelleri: PazarAtlasi.CMS.Application/Models/API/Request/
public class PageQuery
{
    [Required]
    public string Slug { get; set; } = string.Empty;

    [Required]
    public string Culture { get; set; } = "tr-TR";
}

// Response modelleri: PazarAtlasi.CMS.Application/Models/API/Response/
public class PageResponse
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Slug { get; set; } = string.Empty;
    public List<BreadcrumbItem> Breadcrumbs { get; set; } = new List<BreadcrumbItem>();
    public List<SectionResponse> Sections { get; set; } = new List<SectionResponse>();
}
```

#### Endpoint Naming Convention

- **Endpoint**: `PageQuery` → **HTTP Method**: `GET /api/content/page`
- **Request Model**: `{EndpointName}Query` (GET) veya `{EndpointName}Command` (POST/PUT)
- **Response Model**: `{EndpointName}Response`

#### Controller Yapısı

```csharp
[Route("api/[controller]")]
[ApiController]
public class ContentController : ControllerBase
{
    private readonly PazarAtlasiDbContext _pazarAtlasiDbContext;

    /// <summary>
    /// Get page by slug with all sections, items, fields and values
    /// </summary>
    /// <param name="query">Page query with slug and culture</param>
    /// <returns>Complete page data with breadcrumbs</returns>
    [HttpGet("page")]
    public async Task<ActionResult<PageResponse>> GetPage([FromQuery] PageQuery query)
    {
        // Implementation...
    }
}
```

### 🎯 Content API Endpoint'leri

#### 1. **GET /api/content/page**

- **Request**: `PageQuery` (slug, culture)
- **Response**: `PageResponse` (tam sayfa verisi + breadcrumbs)
- **Özellik**: Slug üzerinden sayfayı bulur, parent page'lerden breadcrumb oluşturur

#### 2. **GET /api/content/page-sections**

- **Request**: `PageSectionQuery` (pageId, culture)
- **Response**: `PageSectionResponse` (sayfa section'ları)
- **Özellik**: Belirli bir sayfanın tüm section'larını getirir

#### 3. **GET /api/content/section**

- **Request**: `SectionQuery` (key, culture)
- **Response**: `SectionResponse` (section detayları)
- **Özellik**: Section Key ile sorgulanır, tüm item'ları ile birlikte detayları getirir

#### 4. **GET /api/content/section-item**

- **Request**: `SectionItemQuery` (sectionItemId, culture)
- **Response**: `SectionItemResponse` (section item detayları)
- **Özellik**: Tek bir section item'ının tüm field'ları ile birlikte detaylarını getirir

#### 5. **GET /api/content/section-item-field**

- **Request**: `SectionItemFieldQuery` (sectionItemFieldId, culture)
- **Response**: `SectionItemFieldResponse` (field detayları)
- **Özellik**: Tek bir field'ın değerini ve meta bilgilerini getirir

### 🌍 Çoklu Dil Desteği

#### Culture Parameter Kuralları

```csharp
// Her endpoint culture parametresi almalı
[Required]
public string Culture { get; set; } = "tr-TR";

// Language entity'si üzerinden culture kontrolü
var language = await _pazarAtlasiDbContext.Languages
    .FirstOrDefaultAsync(l => l.Code == query.Culture && !l.IsDeleted);
```

#### Translation Handling

```csharp
// Include'larda language filtreleme
.Include(s => s.Translations.Where(st => st.LanguageId == language.Id))

// Response'da translation değerlerini kullanma
var sectionTranslation = section.Translations.FirstOrDefault();
Name = sectionTranslation?.Name,
Title = sectionTranslation?.Title,
```

### 🏗️ Hiyerarşik Yapı Yönetimi

#### Breadcrumb Oluşturma

```csharp
private async Task<List<BreadcrumbItem>> BuildBreadcrumbs(Page page, int languageId)
{
    var breadcrumbs = new List<BreadcrumbItem>();
    var pageHierarchy = new List<Page>();

    // Parent'lardan root'a kadar hiyerarşi oluştur
    while (currentPage != null)
    {
        pageHierarchy.Insert(0, currentPage);
        currentPage = await GetParentPage(currentPage.ParentPageId);
    }

    // Breadcrumb item'larına çevir
    return pageHierarchy.Select((page, index) => new BreadcrumbItem
    {
        Name = page.Name ?? string.Empty,
        Href = page.Slug ?? string.Empty,
        IsActive = index == pageHierarchy.Count - 1
    }).ToList();
}
```

#### Parent-Child İlişkileri

```csharp
// Root item'ları bul
var rootItems = sectionItemValues
    .Where(siv => siv.SectionItem.ParentSectionItemId == null)
    .OrderBy(siv => siv.SectionItem.SortOrder);

// Recursive olarak child'ları ekle
foreach (var rootItem in rootItems)
{
    var itemResponse = await BuildSectionItemResponse(rootItem.SectionItem, allItems, languageId);
    responses.Add(itemResponse);
}
```

### ⚡ Performance Optimizasyonları

#### Include Stratejileri

```csharp
// ✅ Doğru: Gerekli include'ları tek sorguda
var page = await _pazarAtlasiDbContext.Pages
    .Include(p => p.PageSections.OrderBy(ps => ps.SortOrder))
        .ThenInclude(ps => ps.Section)
        .ThenInclude(s => s.Translations.Where(st => st.LanguageId == language.Id))
    .Include(p => p.PageSections)
        .ThenInclude(ps => ps.Section)
        .ThenInclude(s => s.SectionItemValues.OrderBy(siv => siv.SectionItem.SortOrder))
    .FirstOrDefaultAsync(p => p.Slug == query.Slug);

// ❌ Yanlış: N+1 problem yaratacak lazy loading
foreach (var section in page.PageSections)
{
    var items = section.Section.SectionItemValues; // Her iterasyonda DB sorgusu
}
```

#### Filtering at Database Level

```csharp
// ✅ Doğru: Veritabanı seviyesinde filtreleme
.Include(s => s.Translations.Where(st => st.LanguageId == language.Id))

// ❌ Yanlış: Memory'de filtreleme
.Include(s => s.Translations)
// Sonra memory'de: translations.Where(t => t.LanguageId == language.Id)
```

### 🛡️ Hata Yönetimi

#### Standart Hata Responses

```csharp
// Model validation hatası
if (!ModelState.IsValid)
{
    return BadRequest(ModelState);
}

// Business logic hatası
if (language == null)
{
    return BadRequest($"Language with culture '{query.Culture}' not found.");
}

// Not found hatası
if (page == null)
{
    return NotFound($"Page with slug '{query.Slug}' not found.");
}

// Server hatası
catch (Exception ex)
{
    return StatusCode(500, $"Internal server error: {ex.Message}");
}
```

### 🔧 API Konfigürasyonu

#### Program.cs Setup

```csharp
var builder = WebApplication.CreateBuilder(args);

// Services
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Custom services
builder.Services.AddPersistenceServiceRegistrations(builder.Configuration);
builder.Services.AddInfrastructureServiceRegistrations();

var app = builder.Build();

// Pipeline
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
```

#### Package Versiyonları (.NET 8.0)

```xml
<PackageReference Include="Microsoft.EntityFrameworkCore.Tools" Version="8.0.0" />
<PackageReference Include="Swashbuckle.AspNetCore" Version="6.5.0" />
```

### 📋 API Best Practices

1. **Async/Await**: Tüm database işlemleri async olmalı
2. **Model Validation**: `[Required]` attribute'ları kullan
3. **Culture Support**: Her endpoint culture parametresi almalı
4. **Performance**: Include'ları optimize et, N+1 probleminden kaçın
5. **Error Handling**: Standart HTTP status kodları kullan
6. **Documentation**: XML comments ile API dokümantasyonu yap
7. **Naming**: RESTful naming convention'larını takip et
8. **Versioning**: API versiyonlama stratejisi belirle

### 🧪 Test Stratejileri

```bash
# Test endpoint'i
GET /api/content/test

# Swagger UI
http://localhost:5095/swagger

# Örnek API çağrıları
GET /api/content/page?slug=home&culture=tr-TR
GET /api/content/section?key=hero&culture=tr-TR
GET /api/content/page-sections?pageId=1&culture=tr-TR
```

## 🌐 Gelişmiş Localization ve Cache Sistemi

### Localization Entity Yapısı

Çoklu dil desteği için gelişmiş localization sistemi kuruldu:

#### 1. LocalizationValue Entity

```csharp
public class LocalizationValue : Entity<int>
{
    public int LanguageId { get; set; }
    public string Key { get; set; } = string.Empty;
    public string Value { get; set; } = string.Empty;
    public string? Description { get; set; }
    public string? Category { get; set; }
    public bool IsActive { get; set; } = true;

    // Navigation Properties
    public virtual Language Language { get; set; } = null!;
}
```

#### 2. Language Entity

```csharp
public class Language : Entity<int>
{
    public string Name { get; set; } = string.Empty;
    public string Code { get; set; } = string.Empty;
    public string? NativeName { get; set; }
    public string? Flag { get; set; }
    public bool IsDefault { get; set; } = false;
    public bool IsActive { get; set; } = true;
    public int SortOrder { get; set; } = 0;

    // Navigation Properties
    public virtual ICollection<LocalizationValue> LocalizationValues { get; set; }
}
```

### Gelişmiş Cache Management Sistemi

#### Cache Interface Yapısı

```csharp
public interface ICacheService
{
    // Reference types
    Task<T?> GetAsync<T>(string key, CancellationToken cancellationToken = default) where T : class;
    Task SetAsync<T>(string key, T value, TimeSpan? expiration = null, CancellationToken cancellationToken = default) where T : class;

    // Value types
    Task<T?> GetValueAsync<T>(string key, CancellationToken cancellationToken = default) where T : struct;
    Task SetValueAsync<T>(string key, T value, TimeSpan? expiration = null, CancellationToken cancellationToken = default) where T : struct;

    // Group Cache Management
    Task SetWithGroupAsync<T>(string key, T value, string groupKey, TimeSpan? expiration = null, CancellationToken cancellationToken = default) where T : class;
    Task SetValueWithGroupAsync<T>(string key, T value, string groupKey, TimeSpan? expiration = null, CancellationToken cancellationToken = default) where T : struct;
    Task RemoveGroupAsync(string groupKey, CancellationToken cancellationToken = default);
}
```

#### Cache Implementations

1. **InMemoryCacheService**: Tek sunucu için hızlı cache
2. **RedisCacheService**: Dağıtık sistemler için Redis cache
3. **HybridCacheService**: L1 (Memory) + L2 (Redis) katmanlı cache

#### Cache Configuration

```json
{
  "Cache": {
    "Type": "Hybrid", // InMemory, Redis, Hybrid
    "ConnectionString": "localhost:6379",
    "DefaultExpirationMinutes": 30,
    "MemoryCacheExpirationMinutes": 5,
    "EnableCompression": true,
    "EnableLogging": true
  }
}
```

#### Grup Cache Kullanımı

```csharp
// Cache'e grup ile ekleme
await _cacheService.SetWithGroupAsync("Navbar.GetMenus", menuData, "Navbar", TimeSpan.FromHours(1));
await _cacheService.SetValueWithGroupAsync("Navbar.ItemCount", 5, "Navbar", TimeSpan.FromHours(1));

// Grup cache'ini temizleme
await _cacheService.RemoveGroupAsync("Navbar"); // Navbar grubundaki tüm cache'ler silinir

// Grup anahtarlarını alma
var groupKeys = await _cacheService.GetGroupKeysAsync("Navbar");
```

### Language Service Kullanımı

#### Temel Kullanım

```csharp
// Constructor injection
private readonly ILanguageService _languageService;

// Mevcut dil ile değer alma
string saveText = _languageService.GetLangValue("Common.Save");

// Belirli dil ile değer alma
string saveTextEn = _languageService.GetLangValue("Common.Save", "en-US");

// Async kullanım
string saveTextAsync = await _languageService.GetLangValueAsync("Common.Save");
```

#### Gelişmiş Özellikler

```csharp
// Arama
var searchResults = await _languageService.SearchAsync("Common");

// Yeni değer ekleme
bool added = await _languageService.AddLangValueAsync(
    "Common.NewButton",
    "Yeni",
    "New button text",
    "tr-TR"
);

// Değer güncelleme
bool updated = await _languageService.UpdateLangValueAsync(
    "Common.Save",
    "Kaydet Et",
    "tr-TR"
);

// Cache yenileme
await _languageService.RefreshCacheAsync();

// Dil sözlüğü alma
var dictionary = await _languageService.GetLanguageDictionaryAsync("tr-TR");
```

### View'larda Kullanım

#### HTML Helper ile

```html
<!-- Temel kullanım -->
<button>@Html.L("Common.Save")</button>

<!-- Belirli dil ile -->
<button>@Html.L("Common.Save", "en-US")</button>

<!-- Formatlanmış metin -->
<p>@Html.LFormat("Common.WelcomeMessage", Model.UserName)</p>

<!-- Fallback ile -->
<span>@Html.LOrDefault("Common.OptionalText", "Default Text")</span>

<!-- Mevcut dil kodu -->
<div data-lang="@Html.GetCurrentLanguage()">Content</div>

<!-- Key kontrolü -->
@if (Html.HasKey("Common.AdvancedFeature")) {
<div>@Html.L("Common.AdvancedFeature")</div>
}
```

#### Static Helper ile

```html
@using PazarAtlasi.CMS.Helpers

<h1>
  @LocalizationHelper.L(ViewContext.HttpContext.RequestServices,
  "Page.Title")
</h1>
```

### Cache Management Sistemi

#### Cache Tipleri

1. **InMemory Cache**: Tek sunucu için hızlı cache
2. **Redis Cache**: Dağıtık sistemler için
3. **Hybrid Cache**: L1 (Memory) + L2 (Redis) kombinasyonu

#### Configuration

```json
{
  "Cache": {
    "Type": "Hybrid", // InMemory, Redis, Hybrid
    "ConnectionString": "localhost:6379",
    "DefaultExpirationMinutes": 30,
    "MemoryCacheExpirationMinutes": 5,
    "EnableCompression": true,
    "EnableLogging": true
  }
}
```

#### Grup Cache Kullanımı

```csharp
// Cache'e grup ile ekleme
await _cacheService.SetWithGroupAsync("Navbar.GetMenus", menuData, "Navbar", TimeSpan.FromHours(1));
await _cacheService.SetWithGroupAsync("Navbar.GetTemplate", templateData, "Navbar", TimeSpan.FromHours(1));

// Grup cache'ini temizleme
await _cacheService.RemoveGroupAsync("Navbar"); // Navbar grubundaki tüm cache'ler silinir

// Grup anahtarlarını alma
var groupKeys = await _cacheService.GetGroupKeysAsync("Navbar");
```

### Middleware Kullanımı

Language detection middleware otomatik olarak:

1. Query parameter'dan dil algılar (`?lang=en-US`)
2. Accept-Language header'ından dil algılar
3. Cookie'den dil algılar
4. Default dili kullanır

```csharp
// Program.cs veya Startup.cs
app.UseLanguageMiddleware();
```

### Desteklenen Diller

```csharp
public static class LanguageList
{
    public const string DefaultLang = "tr-TR";
    public const string English = "en-US";
    public const string Turkish = "tr-TR";
    public const string German = "de-DE";
    public const string French = "fr-FR";
    public const string Spanish = "es-ES";
    // ...
}
```

### Cache Grup Örnekleri

```
Navbar: {
    Navbar.GetMenus,
    Navbar.GetTemplate,
    Navbar.GetSettings
}

Hero: {
    Hero.GetContent,
    Hero.GetTemplate,
    Hero.GetImages
}

Localization: {
    LocalizationValues,
    LanguageDictionary_tr-TR,
    LanguageDictionary_en-US
}
```

### Performance Optimizasyonları

1. **Smart Caching**: 24 saat cache süresi
2. **Grup Cache**: İlgili cache'leri toplu temizleme
3. **Hybrid Cache**: L1 (5dk) + L2 (30dk) katmanlı cache
4. **Lazy Loading**: İhtiyaç duyulduğunda cache yükleme
5. **Compression**: Redis'te veri sıkıştırma

### Localization Best Practices

1. **Key Naming**: `Category.SpecificKey` formatı kullan
2. **Categories**: Common, Page, Section, Error, Validation vb.
3. **Fallback**: Key bulunamazsa key'in kendisini döndür
4. **Cache**: Grup cache ile ilgili verileri toplu yönet
5. **Async**: Mümkün olduğunca async metodları kullan

## 🚀 Build ve Migration İşlemleri

### Proje Build Etme

```bash
# Tüm projeyi build et
dotnet build

# Sadece belirli projeyi build et
dotnet build PazarAtlasi.CMS
```

### Migration İşlemleri

```bash
# Yeni migration oluştur
dotnet ef migrations add AddLocalizationEntities -p PazarAtlasi.CMS.Persistence -s PazarAtlasi.CMS

# Database güncelle
dotnet ef database update -p PazarAtlasi.CMS.Persistence -s PazarAtlasi.CMS

# Migration geri al
dotnet ef database update PreviousMigrationName -p PazarAtlasi.CMS.Persistence -s PazarAtlasi.CMS
```

### Seed Data

Localization sistemi otomatik olarak temel dil verilerini ve localization key'lerini seed eder:

- **Languages**: Türkçe (default), İngilizce, Almanca, Fransızca, İspanyolca
- **LocalizationValues**: Common.Save, Common.Cancel, Common.Delete vb. temel key'ler

### Cache Test Etme

```csharp
// InMemory Cache Test
services.Configure<CacheConfiguration>(config => config.Type = CacheType.InMemory);

// Redis Cache Test (Redis server gerekli)
services.Configure<CacheConfiguration>(config => {
    config.Type = CacheType.Redis;
    config.ConnectionString = "localhost:6379";
});

// Hybrid Cache Test (En performanslı)
services.Configure<CacheConfiguration>(config => {
    config.Type = CacheType.Hybrid;
    config.ConnectionString = "localhost:6379";
});
```

### Localization Test Etme

```bash
# Localization controller'ı test et
GET /Localization

# API endpoint'lerini test et
GET /Localization/GetValue?key=Common.Save
GET /Localization/GetDictionary?language=tr-TR
POST /Localization/RefreshCache
```

## 📋 Troubleshooting

### Yaygın Hatalar ve Çözümleri

1. **Redis Connection Error**: Redis server'ın çalıştığından emin ol
2. **Migration Error**: Database connection string'ini kontrol et
3. **Cache Error**: Cache configuration'ını kontrol et
4. **Localization Key Not Found**: Seed data'nın çalıştığından emin ol

### Performance İpuçları

1. **Hybrid Cache** kullan (L1 + L2)
2. **Group Cache** ile ilgili cache'leri toplu yönet
3. **Async metodları** tercih et
4. **Cache expiration** sürelerini optimize et

Bu rehber, projenin tutarlı ve sürdürülebilir şekilde geliştirilmesi için temel kuralları içermektedir.
