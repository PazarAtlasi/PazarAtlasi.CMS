# Announcement API Endpoints

PazarAtlasi.API projesi için Announcement (Duyuru) yönetimi endpoint'leri.

> **Not:** Announcement endpoint'leri **AnnouncementController** içinde yer alır.

## 🚀 Endpoint'ler

### 1. **GET /api/announcement** - Tek Duyuru Getir

ID ile duyuru detaylarını getirir.

**Query Parameters:**

- `id` (required): Duyuru ID'si
- `culture` (required): Dil kodu (örn: "tr-TR", "en-US")

**Örnek Kullanım:**

```bash
GET /api/announcement?id=1&culture=tr-TR
```

---

### 2. **GET /api/announcement/list** - Duyuru Listesi

Filtreleme ve sayfalama ile duyuru listesi getirir.

**Query Parameters:**

- `culture` (required): Dil kodu (örn: "tr-TR")
- `page` (optional, default: 1): Sayfa numarası
- `pageSize` (optional, default: 10, max: 100): Sayfa başına duyuru sayısı
- `onlyActive` (optional): Sadece aktif duyurular (yayın tarihleri içinde)
- `searchTerm` (optional): Başlık ve içerikte arama

**Örnek Kullanımlar:**

```bash
# Tüm duyurular
GET /api/announcement/list?culture=tr-TR

# Sadece aktif duyurular
GET /api/announcement/list?culture=tr-TR&onlyActive=true

# Arama
GET /api/announcement/list?culture=tr-TR&searchTerm=bakım

# Sayfalama
GET /api/announcement/list?culture=tr-TR&page=2&pageSize=20
```

---

### 3. **GET /api/announcement/active** - Aktif Duyurular

Şu anda yayında olan duyuruları getirir (publishStart <= now <= publishEnd).

**Query Parameters:**

- `culture` (optional, default: "tr-TR"): Dil kodu
- `count` (optional, default: 5): Getirilecek duyuru sayısı

**Örnek Kullanım:**

```bash
GET /api/announcement/active?culture=tr-TR&count=3
```

---

## 🎯 Özellikler

### ✅ Yayın Tarihi Yönetimi

- `publishStart` ve `publishEnd` ile otomatik yayın kontrolü
- `isActive` field'ı ile şu anda yayında olup olmadığını gösterir
- `daysRemaining` ile yayın bitimine kalan gün sayısı

### ✅ Çoklu Dil Desteği

- Tüm endpoint'ler culture parametresi ile çoklu dil destekler
- Translation'lar otomatik filtrelenir
- Fallback: Translation yoksa ana dil kullanılır

### ✅ Gelişmiş Filtreleme

- Aktif/pasif duyuru filtreleme
- Arama (başlık ve içerikte)
- Tarih bazlı sıralama (en yeni önce)

### ✅ Sayfalama

- Performanslı sayfalama desteği
- Toplam sayfa, önceki/sonraki sayfa bilgileri

### ✅ Status Yönetimi

- Draft: Taslak (henüz yayınlanmamış)
- Active: Aktif (yayında veya yayın bekliyor)
- Otomatik durum hesaplama (tarih bazlı)

---

## 📝 Örnek Frontend Kullanımı

### React/Next.js Örneği

```typescript
// Aktif duyuruları getir
const fetchActiveAnnouncements = async () => {
  const response = await fetch(
    "/api/announcement/active?culture=tr-TR&count=5"
  );
  return await response.json();
};

// Duyuru listesi
const fetchAnnouncements = async (page = 1, onlyActive = true) => {
  const params = new URLSearchParams({
    culture: "tr-TR",
    page: page.toString(),
    pageSize: "10",
    onlyActive: onlyActive.toString(),
  });

  const response = await fetch(`/api/announcement/list?${params}`);
  return await response.json();
};

// Duyuru detayı
const fetchAnnouncement = async (id: number) => {
  const response = await fetch(
    `/api/announcement?id=${id}&culture=tr-TR`
  );
  return await response.json();
};

// Duyuru bileşeni
function AnnouncementBanner() {
  const [announcements, setAnnouncements] = useState([]);

  useEffect(() => {
    fetchActiveAnnouncements().then(setAnnouncements);
  }, []);

  return (
    <div className="announcement-banner">
      {announcements.map((announcement) => (
        <div key={announcement.id} className="announcement-item">
          <h3>{announcement.title}</h3>
          <p>{announcement.summary}</p>
          {announcement.daysRemaining > 0 && (
            <span className="badge">
              {announcement.daysRemaining} gün kaldı
            </span>
          )}
        </div>
      ))}
    </div>
  );
}
```

---

## 🧪 Test

API'yi test etmek için Swagger UI kullanabilirsiniz:

```
http://localhost:5095/swagger
```

veya Postman/cURL ile:

```bash
# Duyuru listesi
GET http://localhost:5095/api/announcement?culture=tr-TR

# Aktif duyurular
GET http://localhost:5095/api/announcement/active?culture=tr-TR&count=5

# Duyuru detayı
GET http://localhost:5095/api/announcement/1?culture=tr-TR

# Sadece aktif duyurular (yayın tarihleri içinde)
GET http://localhost:5095/api/announcement?culture=tr-TR&onlyActive=true

# Arama
GET http://localhost:5095/api/announcement?culture=tr-TR&searchTerm=bakım
```

---

## 📚 İlgili Dosyalar

**Request Models:**

- `PazarAtlasi.CMS.Application/Models/API/Request/AnnouncementQuery.cs`
- `PazarAtlasi.CMS.Application/Models/API/Request/AnnouncementListQuery.cs`

**Response Models:**

- `PazarAtlasi.CMS.Application/Models/API/Response/AnnouncementResponse.cs`

**Controller:**

- `PazarAtlasi.API/Controllers/AnnouncementController.cs`

**Entities:**

- `PazarAtlasi.CMS.Domain/Entities/Announcement/Announcement.cs`
- `PazarAtlasi.CMS.Domain/Entities/Announcement/AnnouncementTranslation.cs`

**Configurations:**

- `PazarAtlasi.CMS.Persistence/EntityConfigurations/Announcement/AnnouncementConfiguration.cs`
- `PazarAtlasi.CMS.Persistence/EntityConfigurations/Announcement/AnnouncementTranslationConfiguration.cs`

---

## 🏗️ Mimari Kararlar

### Neden Ayrı Controller?

Announcement endpoint'leri **AnnouncementController** içinde yer alır çünkü:

1. **Bağımsız Yönetim**: Duyurular kendi başına bir modül
2. **Kod Organizasyonu**: Her domain kendi controller'ında
3. **Bakım Kolaylığı**: Duyuru işlemleri tek bir yerde
4. **RESTful Yapı**: `/api/announcement/*` altında tüm duyuru işlemleri

### Endpoint Yapısı

```
/api/announcement/
├── GET /                      # Duyuru listesi (filtreleme, sayfalama)
├── GET /{id}                  # Duyuru detayı (ID ile)
└── GET /active                # Aktif duyurular (şu anda yayında)
```

Bu yapı, API'nin tutarlı ve anlaşılır olmasını sağlar.
