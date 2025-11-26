# Article API Endpoints

PazarAtlasi.API projesi için Article (Makale/Haber) yönetimi endpoint'leri.

> **Not:** Article endpoint'leri **ContentController** içinde yer alır çünkü Article bir content türüdür.

## 🚀 Endpoint'ler

### 1. **GET /api/content/article** - Tek Makale Getir

Slug ile makale detaylarını getirir. View count otomatik artar.

**Query Parameters:**

- `slug` (required): Makale slug'ı (örn: "welcome-to-cms")
- `culture` (required): Dil kodu (örn: "tr-TR", "en-US")

**Örnek Kullanım:**

```bash
GET /api/content/article?slug=welcome-to-cms&culture=tr-TR
```

---

### 2. **GET /api/content/articles** - Makale Listesi

Filtreleme ve sayfalama ile makale listesi getirir.

**Query Parameters:**

- `culture` (required): Dil kodu (örn: "tr-TR")
- `page` (optional, default: 1): Sayfa numarası
- `pageSize` (optional, default: 12, max: 100): Sayfa başına makale sayısı
- `categoryId` (optional): Kategori ID'si ile filtrele
- `isFeatured` (optional): Sadece öne çıkan makaleler (true/false)
- `isTrending` (optional): Sadece trend makaleler (true/false)
- `searchTerm` (optional): Başlık ve içerikte arama
- `sortBy` (optional, default: "latest"): Sıralama ("latest", "popular", "trending", "oldest")

**Örnek Kullanımlar:**

```bash
# Tüm makaleler (ilk sayfa)
GET /api/content/articles?culture=tr-TR

# Kategori filtreli
GET /api/content/articles?culture=tr-TR&categoryId=1

# Öne çıkan makaleler
GET /api/content/articles?culture=tr-TR&isFeatured=true

# Arama
GET /api/content/articles?culture=tr-TR&searchTerm=cms

# Popüler makaleler
GET /api/content/articles?culture=tr-TR&sortBy=popular&pageSize=20

# Sayfalama
GET /api/content/articles?culture=tr-TR&page=2&pageSize=10
```

---

### 3. **GET /api/content/articles/featured** - Öne Çıkan Makaleler

Öne çıkan makaleleri getirir.

**Query Parameters:**

- `culture` (optional, default: "tr-TR"): Dil kodu
- `count` (optional, default: 5): Getirilecek makale sayısı

**Örnek Kullanım:**

```bash
GET /api/content/articles/featured?culture=tr-TR&count=3
```

---

### 4. **GET /api/content/articles/trending** - Trend Makaleler

Trend makaleleri getirir (view count'a göre sıralı).

**Query Parameters:**

- `culture` (optional, default: "tr-TR"): Dil kodu
- `count` (optional, default: 5): Getirilecek makale sayısı

**Örnek Kullanım:**

```bash
GET /api/content/articles/trending?culture=tr-TR&count=5
```

---

### 5. **GET /api/content/article-categories** - Kategori Listesi

Hiyerarşik kategori listesi getirir.

**Query Parameters:**

- `culture` (required): Dil kodu
- `includeArticleCount` (optional, default: true): Her kategorideki makale sayısını dahil et
- `includeChildren` (optional, default: true): Alt kategorileri dahil et

**Örnek Kullanım:**

```bash
GET /api/content/article-categories?culture=tr-TR&includeArticleCount=true
```

---

### 6. **POST /api/content/article/{id}/like** - Makale Beğen

Makaleyi beğenir ve güncel beğeni sayısını döner.

**Path Parameters:**

- `id` (required): Makale ID'si

**Örnek Kullanım:**

```bash
POST /api/content/article/1/like
```

---

## 🎯 Özellikler

### ✅ Otomatik View Count

- Makale detayı her görüntülendiğinde view count otomatik artar

### ✅ İlgili Makaleler

- Makale detayında aynı kategoriden ilgili makaleler otomatik önerilir

### ✅ Çoklu Dil Desteği

- Tüm endpoint'ler culture parametresi ile çoklu dil destekler
- Translation'lar otomatik filtrelenir

### ✅ Gelişmiş Filtreleme

- Kategori, featured, trending, arama terimine göre filtreleme
- Popülerlik, tarih bazlı sıralama

### ✅ Sayfalama

- Performanslı sayfalama desteği
- Toplam sayfa, önceki/sonraki sayfa bilgileri

### ✅ Hiyerarşik Kategoriler

- Parent-child kategori yapısı
- Kategori başına makale sayısı

### ✅ SEO Optimizasyonu

- Meta title, description, keywords
- Slug-based URL'ler

### ✅ Tag Sistemi

- JSON array olarak tag desteği
- Makale etiketleme

---

## 📝 Örnek Frontend Kullanımı

### React/Next.js Örneği

```typescript
// Makale listesi
const fetchArticles = async (page = 1, categoryId?: number) => {
  const params = new URLSearchParams({
    culture: "tr-TR",
    page: page.toString(),
    pageSize: "12",
    sortBy: "latest",
  });

  if (categoryId) {
    params.append("categoryId", categoryId.toString());
  }

  const response = await fetch(`/api/content/articles?${params}`);
  return await response.json();
};

// Makale detayı
const fetchArticle = async (slug: string) => {
  const response = await fetch(
    `/api/content/article?slug=${slug}&culture=tr-TR`
  );
  return await response.json();
};

// Öne çıkan makaleler
const fetchFeaturedArticles = async () => {
  const response = await fetch(
    "/api/content/articles/featured?culture=tr-TR&count=5"
  );
  return await response.json();
};

// Makale beğen
const likeArticle = async (id: number) => {
  const response = await fetch(`/api/content/article/${id}/like`, {
    method: "POST",
  });
  return await response.json();
};
```

---

## 🧪 Test

API'yi test etmek için Swagger UI kullanabilirsiniz:

```
http://localhost:5095/swagger
```

veya Postman/cURL ile:

```bash
# Makale listesi
GET http://localhost:5095/api/content/articles?culture=tr-TR&page=1&pageSize=12

# Makale detayı
GET http://localhost:5095/api/content/articles/welcome-to-cms?culture=tr-TR

# Öne çıkan makaleler
GET http://localhost:5095/api/content/articles/featured?culture=tr-TR&count=5

# Kategoriler
GET http://localhost:5095/api/content/article-categories?culture=tr-TR

# Makale beğen
curl -X POST "http://localhost:5095/api/content/articles/welcome-to-cms/like"
```

---

## 📚 İlgili Dosyalar

**Request Models:**

- `PazarAtlasi.CMS.Application/Models/API/Request/ArticleQuery.cs`
- `PazarAtlasi.CMS.Application/Models/API/Request/ArticleListQuery.cs`
- `PazarAtlasi.CMS.Application/Models/API/Request/ArticleCategoryQuery.cs`

**Response Models:**

- `PazarAtlasi.CMS.Application/Models/API/Response/ArticleResponse.cs`

**Controller:**

- `PazarAtlasi.API/Controllers/ContentController.cs` (Article endpoints içinde)

**Entities:**

- `PazarAtlasi.CMS.Domain/Entities/Content/Article.cs`
- `PazarAtlasi.CMS.Domain/Entities/Content/ArticleCategory.cs`
- `PazarAtlasi.CMS.Domain/Entities/Content/ArticleTranslation.cs`

**Configurations:**

- `PazarAtlasi.CMS.Persistence/EntityConfigurations/Content/ArticleConfiguration.cs`
- `PazarAtlasi.CMS.Persistence/EntityConfigurations/Content/ArticleCategoryConfiguration.cs`

---

## 🏗️ Mimari Kararlar

### Neden ContentController?

Article endpoint'leri ayrı bir controller yerine **ContentController** içinde yer alır çünkü:

1. **Semantik Tutarlılık**: Article bir content türüdür (Page, Section gibi)
2. **Kod Organizasyonu**: Tüm content-related endpoint'ler tek yerde
3. **Bakım Kolaylığı**: Content yönetimi tek bir controller'da
4. **RESTful Yapı**: `/api/content/*` altında tüm content türleri

### Endpoint Yapısı

```
/api/content/
├── page                    # Sayfa detayı
├── page-sections          # Sayfa section'ları
├── section                # Section detayı
├── section-item           # Section item detayı
├── section-item-field     # Field detayı
├── layout-sections        # Layout section'ları
├── article                # Makale detayı (YENİ)
├── articles               # Makale listesi (YENİ)
├── articles/featured      # Öne çıkan makaleler (YENİ)
├── articles/trending      # Trend makaleler (YENİ)
└── article-categories     # Makale kategorileri (YENİ)
```

Bu yapı, API'nin tutarlı ve anlaşılır olmasını sağlar.
