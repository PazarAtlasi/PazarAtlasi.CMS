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

## 🚀 Best Practices

1. **Naming Convention**: PascalCase kullan
2. **Nullable Properties**: Opsiyonel alanlar için `?` kullan
3. **Default Values**: Enum'lar için default değer belirle
4. **Validation**: Domain seviyesinde validation ekle
5. **Performance**: Lazy loading yerine explicit loading tercih et
6. **Translations**: Çoklu dil desteği için ayrı translation entity'leri kullan

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

Bu rehber, projenin tutarlı ve sürdürülebilir şekilde geliştirilmesi için temel kuralları içermektedir.
