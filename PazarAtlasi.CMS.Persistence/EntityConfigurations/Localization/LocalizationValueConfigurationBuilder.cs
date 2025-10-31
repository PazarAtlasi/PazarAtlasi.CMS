using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PazarAtlasi.CMS.Domain.Entities.Localization;

namespace PazarAtlasi.CMS.Persistence.EntityConfigurations.Localization
{
    public class LocalizationValueConfigurationBuilder : IEntityTypeConfiguration<LocalizationValue>
    {
        public void Configure(EntityTypeBuilder<LocalizationValue> builder)
        {
            // Table configuration
            builder.ToTable("LocalizationValues").HasKey(lv => lv.Id);

            // Property configurations
            builder.Property(lv => lv.Id)
                .HasColumnName("Id")
                .IsRequired();

            builder.Property(lv => lv.LanguageId)
                .HasColumnName("LanguageId")
                .IsRequired();

            builder.Property(lv => lv.Key)
                .HasColumnName("Key")
                .HasMaxLength(500)
                .IsRequired();

            builder.Property(lv => lv.Value)
                .HasColumnName("Value")
                .HasMaxLength(4000)
                .IsRequired();

            builder.Property(lv => lv.Description)
                .HasColumnName("Description")
                .HasMaxLength(1000);

            builder.Property(lv => lv.Category)
                .HasColumnName("Category")
                .HasMaxLength(100);

            builder.Property(lv => lv.IsActive)
                .HasColumnName("IsActive")
                .HasDefaultValue(true)
                .IsRequired();

            builder.Property(lv => lv.CreatedAt)
                .HasColumnName("CreatedAt")
                .HasDefaultValueSql("GETUTCDATE()")
                .IsRequired();

            builder.Property(lv => lv.UpdatedAt)
                .HasColumnName("UpdatedAt");

            builder.Property(lv => lv.IsDeleted)
                .HasColumnName("IsDeleted")
                .HasDefaultValue(false)
                .IsRequired();

            // Relationships
            builder.HasOne(lv => lv.Language)
                .WithMany(l => l.LocalizationValues)
                .HasForeignKey(lv => lv.LanguageId)
                .OnDelete(DeleteBehavior.Restrict);

            // Indexes
            builder.HasIndex(lv => new { lv.Key, lv.LanguageId })
                .HasDatabaseName("IX_LocalizationValues_Key_LanguageId")
                .IsUnique();

            builder.HasIndex(lv => lv.Key)
                .HasDatabaseName("IX_LocalizationValues_Key");

            builder.HasIndex(lv => lv.LanguageId)
                .HasDatabaseName("IX_LocalizationValues_LanguageId");

            builder.HasIndex(lv => lv.Category)
                .HasDatabaseName("IX_LocalizationValues_Category");

            builder.HasIndex(lv => lv.IsActive)
                .HasDatabaseName("IX_LocalizationValues_IsActive");

            builder.HasIndex(lv => lv.IsDeleted)
                .HasDatabaseName("IX_LocalizationValues_IsDeleted");

            // Query filter for soft delete
            builder.HasQueryFilter(lv => !lv.IsDeleted);

            // Seed data - Comprehensive localization keys
            var seedData = new List<LocalizationValue>();
            var currentId = 1;

            // Common keys - Turkish
            var commonKeysTr = new Dictionary<string, string>
            {
                { "Common.Save", "Kaydet" },
                { "Common.Cancel", "İptal" },
                { "Common.Delete", "Sil" },
                { "Common.Edit", "Düzenle" },
                { "Common.Add", "Ekle" },
                { "Common.Update", "Güncelle" },
                { "Common.Create", "Oluştur" },
                { "Common.Remove", "Kaldır" },
                { "Common.Search", "Ara" },
                { "Common.Filter", "Filtrele" },
                { "Common.Export", "Dışa Aktar" },
                { "Common.Import", "İçe Aktar" },
                { "Common.Upload", "Yükle" },
                { "Common.Download", "İndir" },
                { "Common.Preview", "Önizle" },
                { "Common.Publish", "Yayınla" },
                { "Common.Draft", "Taslak" },
                { "Common.Active", "Aktif" },
                { "Common.Inactive", "Pasif" },
                { "Common.Yes", "Evet" },
                { "Common.No", "Hayır" },
                { "Common.OK", "Tamam" },
                { "Common.Close", "Kapat" },
                { "Common.Back", "Geri" },
                { "Common.Next", "İleri" },
                { "Common.Previous", "Önceki" },
                { "Common.Loading", "Yükleniyor..." },
                { "Common.Success", "Başarılı" },
                { "Common.Error", "Hata" },
                { "Common.Warning", "Uyarı" },
                { "Common.Info", "Bilgi" },
                { "Common.Refresh", "Yenile" },
                { "Common.Settings", "Ayarlar" },
                { "Common.ViewAll", "Tümünü Gör" }
            };

            // Common keys - English
            var commonKeysEn = new Dictionary<string, string>
            {
                { "Common.Save", "Save" },
                { "Common.Cancel", "Cancel" },
                { "Common.Delete", "Delete" },
                { "Common.Edit", "Edit" },
                { "Common.Add", "Add" },
                { "Common.Update", "Update" },
                { "Common.Create", "Create" },
                { "Common.Remove", "Remove" },
                { "Common.Search", "Search" },
                { "Common.Filter", "Filter" },
                { "Common.Export", "Export" },
                { "Common.Import", "Import" },
                { "Common.Upload", "Upload" },
                { "Common.Download", "Download" },
                { "Common.Preview", "Preview" },
                { "Common.Publish", "Publish" },
                { "Common.Draft", "Draft" },
                { "Common.Active", "Active" },
                { "Common.Inactive", "Inactive" },
                { "Common.Yes", "Yes" },
                { "Common.No", "No" },
                { "Common.OK", "OK" },
                { "Common.Close", "Close" },
                { "Common.Back", "Back" },
                { "Common.Next", "Next" },
                { "Common.Previous", "Previous" },
                { "Common.Loading", "Loading..." },
                { "Common.Success", "Success" },
                { "Common.Error", "Error" },
                { "Common.Warning", "Warning" },
                { "Common.Info", "Info" },
                { "Common.Refresh", "Refresh" },
                { "Common.Settings", "Settings" },
                { "Common.ViewAll", "View All" }
            };

            // Page keys - Turkish
            var pageKeysTr = new Dictionary<string, string>
            {
                { "Page.Title", "Sayfa Başlığı" },
                { "Page.Content", "Sayfa İçeriği" },
                { "Page.Description", "Sayfa Açıklaması" },
                { "Page.Keywords", "Anahtar Kelimeler" },
                { "Page.Author", "Yazar" },
                { "Page.CreatedAt", "Oluşturulma Tarihi" },
                { "Page.UpdatedAt", "Güncellenme Tarihi" },
                { "Page.Status", "Durum" },
                { "Page.Type", "Sayfa Tipi" },
                { "Page.Layout", "Düzen" },
                { "Page.Template", "Şablon" },
                { "Page.SEO", "SEO Ayarları" },
                { "Page.Sections", "Bölümler" },
                { "Page.Items", "Öğeler" },
                { "Page.Fields", "Alanlar" }
            };

            // Page keys - English
            var pageKeysEn = new Dictionary<string, string>
            {
                { "Page.Title", "Page Title" },
                { "Page.Content", "Page Content" },
                { "Page.Description", "Page Description" },
                { "Page.Keywords", "Keywords" },
                { "Page.Author", "Author" },
                { "Page.CreatedAt", "Created At" },
                { "Page.UpdatedAt", "Updated At" },
                { "Page.Status", "Status" },
                { "Page.Type", "Page Type" },
                { "Page.Layout", "Layout" },
                { "Page.Template", "Template" },
                { "Page.SEO", "SEO Settings" },
                { "Page.Sections", "Sections" },
                { "Page.Items", "Items" },
                { "Page.Fields", "Fields" }
            };

            // Section keys - Turkish
            var sectionKeysTr = new Dictionary<string, string>
            {
                { "Section.Name", "Bölüm Adı" },
                { "Section.Type", "Bölüm Tipi" },
                { "Section.Key", "Bölüm Anahtarı" },
                { "Section.Order", "Sıralama" },
                { "Section.Settings", "Ayarlar" },
                { "Section.Items", "Öğeler" },
                { "Section.AddItem", "Öğe Ekle" },
                { "Section.EditItems", "Öğeleri Düzenle" },
                { "Section.Duplicate", "Kopyala" },
                { "Section.Remove", "Kaldır" },
                { "Section.Hero", "Ana Bölüm" },
                { "Section.Navbar", "Navigasyon" },
                { "Section.Footer", "Alt Bilgi" },
                { "Section.Content", "İçerik" },
                { "Section.Gallery", "Galeri" },
                { "Section.Contact", "İletişim" }
            };

            // Section keys - English
            var sectionKeysEn = new Dictionary<string, string>
            {
                { "Section.Name", "Section Name" },
                { "Section.Type", "Section Type" },
                { "Section.Key", "Section Key" },
                { "Section.Order", "Order" },
                { "Section.Settings", "Settings" },
                { "Section.Items", "Items" },
                { "Section.AddItem", "Add Item" },
                { "Section.EditItems", "Edit Items" },
                { "Section.Duplicate", "Duplicate" },
                { "Section.Remove", "Remove" },
                { "Section.Hero", "Hero Section" },
                { "Section.Navbar", "Navigation" },
                { "Section.Footer", "Footer" },
                { "Section.Content", "Content" },
                { "Section.Gallery", "Gallery" },
                { "Section.Contact", "Contact" }
            };

            // Validation keys - Turkish
            var validationKeysTr = new Dictionary<string, string>
            {
                { "Validation.Required", "Bu alan zorunludur" },
                { "Validation.Email", "Geçerli bir e-posta adresi giriniz" },
                { "Validation.MinLength", "En az {0} karakter olmalıdır" },
                { "Validation.MaxLength", "En fazla {0} karakter olmalıdır" },
                { "Validation.Range", "{0} ile {1} arasında olmalıdır" },
                { "Validation.Numeric", "Sayısal bir değer giriniz" },
                { "Validation.Date", "Geçerli bir tarih giriniz" },
                { "Validation.Url", "Geçerli bir URL giriniz" },
                { "Validation.Phone", "Geçerli bir telefon numarası giriniz" },
                { "Validation.Password", "Şifre en az 8 karakter olmalıdır" }
            };

            // Validation keys - English
            var validationKeysEn = new Dictionary<string, string>
            {
                { "Validation.Required", "This field is required" },
                { "Validation.Email", "Please enter a valid email address" },
                { "Validation.MinLength", "Must be at least {0} characters" },
                { "Validation.MaxLength", "Must be at most {0} characters" },
                { "Validation.Range", "Must be between {0} and {1}" },
                { "Validation.Numeric", "Please enter a numeric value" },
                { "Validation.Date", "Please enter a valid date" },
                { "Validation.Url", "Please enter a valid URL" },
                { "Validation.Phone", "Please enter a valid phone number" },
                { "Validation.Password", "Password must be at least 8 characters" }
            };

            // Navigation keys - Turkish
            var navigationKeysTr = new Dictionary<string, string>
            {
                { "Navigation.Dashboard", "Dashboard" },
                { "Navigation.Announcements", "Duyurular" },
                { "Navigation.Campaigns", "Kampanyalar" },
                { "Navigation.Content", "İçerik" },
                { "Navigation.Pages", "Sayfalar" },
                { "Navigation.Sections", "Bölümler" },
                { "Navigation.Layouts", "Düzenler" },
                { "Navigation.WebUrlManagement", "Web URL Yönetimi" },
                { "Navigation.News", "Haberler" },
                { "Navigation.Blog", "Blog" },
                { "Navigation.Templates", "Şablonlar" },
                { "Navigation.SectionItems", "Bölüm Öğeleri" },
                { "Navigation.ECommerce", "E-Ticaret" },
                { "Navigation.Products", "Ürünler" },
                { "Navigation.Categories", "Kategoriler" },
                { "Navigation.Orders", "Siparişler" },
                { "Navigation.Users", "Kullanıcılar" },
                { "Navigation.ManageUsers", "Kullanıcı Yönetimi" },
                { "Navigation.ManageRoles", "Rol Yönetimi" },
                { "Navigation.ManagePermissions", "İzin Yönetimi" },
                { "Navigation.Analytics", "Analitik" },
                { "Navigation.Settings", "Ayarlar" },
                { "Navigation.GeneralSettings", "Genel Ayarlar" },
                { "Navigation.Countries", "Ülkeler" },
                { "Navigation.Languages", "Diller" },
                { "Navigation.Profile", "Profil" },
                { "Navigation.Help", "Yardım" },
                { "Navigation.Logout", "Çıkış" }
            };

            // Navigation keys - English
            var navigationKeysEn = new Dictionary<string, string>
            {
                { "Navigation.Dashboard", "Dashboard" },
                { "Navigation.Announcements", "Announcements" },
                { "Navigation.Campaigns", "Campaigns" },
                { "Navigation.Content", "Content" },
                { "Navigation.Pages", "Pages" },
                { "Navigation.Sections", "Sections" },
                { "Navigation.Layouts", "Layouts" },
                { "Navigation.WebUrlManagement", "Web URL Management" },
                { "Navigation.News", "News" },
                { "Navigation.Blog", "Blog" },
                { "Navigation.Templates", "Templates" },
                { "Navigation.SectionItems", "Section Items" },
                { "Navigation.ECommerce", "E-Commerce" },
                { "Navigation.Products", "Products" },
                { "Navigation.Categories", "Categories" },
                { "Navigation.Orders", "Orders" },
                { "Navigation.Users", "Users" },
                { "Navigation.ManageUsers", "Manage Users" },
                { "Navigation.ManageRoles", "Manage Roles" },
                { "Navigation.ManagePermissions", "Manage Permissions" },
                { "Navigation.Analytics", "Analytics" },
                { "Navigation.Settings", "Settings" },
                { "Navigation.GeneralSettings", "General Settings" },
                { "Navigation.Countries", "Countries" },
                { "Navigation.Languages", "Languages" },
                { "Navigation.Profile", "Profile" },
                { "Navigation.Help", "Help" },
                { "Navigation.Logout", "Logout" }
            };

            // Language keys - Turkish
            var languageKeysTr = new Dictionary<string, string>
            {
                { "Language.English", "İngilizce" },
                { "Language.Turkish", "Türkçe" }
            };

            // Language keys - English
            var languageKeysEn = new Dictionary<string, string>
            {
                { "Language.English", "English" },
                { "Language.Turkish", "Turkish" }
            };

            // Dashboard keys - Turkish
            var dashboardKeysTr = new Dictionary<string, string>
            {
                { "Dashboard.Title", "Dashboard" },
                { "Dashboard.WelcomeMessage", "Hoş geldin! CMS analitiklerin ve son aktivitelerin özeti burada." },
                { "Dashboard.Last7Days", "Son 7 gün" },
                { "Dashboard.Last30Days", "Son 30 gün" },
                { "Dashboard.Last90Days", "Son 90 gün" },
                { "Dashboard.TotalUsers", "Toplam Kullanıcı" },
                { "Dashboard.TotalRevenue", "Toplam Gelir" },
                { "Dashboard.Products", "Ürünler" },
                { "Dashboard.SupportTickets", "Destek Biletleri" },
                { "Dashboard.FromLastMonth", "geçen aydan" },
                { "Dashboard.SalesOverview", "Satış Genel Bakış" },
                { "Dashboard.Monthly", "Aylık" },
                { "Dashboard.ChartVisualization", "Grafik görselleştirmesi burada olacak" },
                { "Dashboard.ThisYear", "Bu Yıl" },
                { "Dashboard.LastYear", "Geçen Yıl" },
                { "Dashboard.RecentActivities", "Son Aktiviteler" },
                { "Dashboard.TopProducts", "En İyi Ürünler" },
                { "Dashboard.Product", "Ürün" },
                { "Dashboard.Category", "Kategori" },
                { "Dashboard.Sales", "Satışlar" },
                { "Dashboard.Status", "Durum" },
                { "Dashboard.LatestOrders", "Son Siparişler" },
                { "Dashboard.Today", "Bugün" },
                { "Dashboard.Yesterday", "Dün" },
                { "Dashboard.OrderId", "Sipariş ID" },
                { "Dashboard.Customer", "Müşteri" },
                { "Dashboard.Date", "Tarih" },
                { "Dashboard.Amount", "Tutar" }
            };

            // Dashboard keys - English
            var dashboardKeysEn = new Dictionary<string, string>
            {
                { "Dashboard.Title", "Dashboard" },
                { "Dashboard.WelcomeMessage", "Welcome back! Here's a summary of your CMS analytics and recent activity." },
                { "Dashboard.Last7Days", "Last 7 days" },
                { "Dashboard.Last30Days", "Last 30 days" },
                { "Dashboard.Last90Days", "Last 90 days" },
                { "Dashboard.TotalUsers", "Total Users" },
                { "Dashboard.TotalRevenue", "Total Revenue" },
                { "Dashboard.Products", "Products" },
                { "Dashboard.SupportTickets", "Support Tickets" },
                { "Dashboard.FromLastMonth", "from last month" },
                { "Dashboard.SalesOverview", "Sales Overview" },
                { "Dashboard.Monthly", "Monthly" },
                { "Dashboard.ChartVisualization", "Chart visualization goes here" },
                { "Dashboard.ThisYear", "This Year" },
                { "Dashboard.LastYear", "Last Year" },
                { "Dashboard.RecentActivities", "Recent Activities" },
                { "Dashboard.TopProducts", "Top Products" },
                { "Dashboard.Product", "Product" },
                { "Dashboard.Category", "Category" },
                { "Dashboard.Sales", "Sales" },
                { "Dashboard.Status", "Status" },
                { "Dashboard.LatestOrders", "Latest Orders" },
                { "Dashboard.Today", "Today" },
                { "Dashboard.Yesterday", "Yesterday" },
                { "Dashboard.OrderId", "Order ID" },
                { "Dashboard.Customer", "Customer" },
                { "Dashboard.Date", "Date" },
                { "Dashboard.Amount", "Amount" }
            };

            // Add Turkish keys
            foreach (var kvp in commonKeysTr)
            {
                seedData.Add(new LocalizationValue
                {
                    Id = currentId++,
                    LanguageId = 1, // Turkish
                    Key = kvp.Key,
                    Value = kvp.Value,
                    Description = $"Turkish translation for {kvp.Key}",
                    Category = "Common",
                    IsActive = true,
                    CreatedAt = DateTime.UtcNow,
                    IsDeleted = false
                });
            }

            foreach (var kvp in pageKeysTr)
            {
                seedData.Add(new LocalizationValue
                {
                    Id = currentId++,
                    LanguageId = 1, // Turkish
                    Key = kvp.Key,
                    Value = kvp.Value,
                    Description = $"Turkish translation for {kvp.Key}",
                    Category = "Page",
                    IsActive = true,
                    CreatedAt = DateTime.UtcNow,
                    IsDeleted = false
                });
            }

            foreach (var kvp in sectionKeysTr)
            {
                seedData.Add(new LocalizationValue
                {
                    Id = currentId++,
                    LanguageId = 1, // Turkish
                    Key = kvp.Key,
                    Value = kvp.Value,
                    Description = $"Turkish translation for {kvp.Key}",
                    Category = "Section",
                    IsActive = true,
                    CreatedAt = DateTime.UtcNow,
                    IsDeleted = false
                });
            }

            foreach (var kvp in validationKeysTr)
            {
                seedData.Add(new LocalizationValue
                {
                    Id = currentId++,
                    LanguageId = 1, // Turkish
                    Key = kvp.Key,
                    Value = kvp.Value,
                    Description = $"Turkish translation for {kvp.Key}",
                    Category = "Validation",
                    IsActive = true,
                    CreatedAt = DateTime.UtcNow,
                    IsDeleted = false
                });
            }

            foreach (var kvp in navigationKeysTr)
            {
                seedData.Add(new LocalizationValue
                {
                    Id = currentId++,
                    LanguageId = 1, // Turkish
                    Key = kvp.Key,
                    Value = kvp.Value,
                    Description = $"Turkish translation for {kvp.Key}",
                    Category = "Navigation",
                    IsActive = true,
                    CreatedAt = DateTime.UtcNow,
                    IsDeleted = false
                });
            }

            foreach (var kvp in languageKeysTr)
            {
                seedData.Add(new LocalizationValue
                {
                    Id = currentId++,
                    LanguageId = 1, // Turkish
                    Key = kvp.Key,
                    Value = kvp.Value,
                    Description = $"Turkish translation for {kvp.Key}",
                    Category = "Language",
                    IsActive = true,
                    CreatedAt = DateTime.UtcNow,
                    IsDeleted = false
                });
            }

            foreach (var kvp in dashboardKeysTr)
            {
                seedData.Add(new LocalizationValue
                {
                    Id = currentId++,
                    LanguageId = 1, // Turkish
                    Key = kvp.Key,
                    Value = kvp.Value,
                    Description = $"Turkish translation for {kvp.Key}",
                    Category = "Dashboard",
                    IsActive = true,
                    CreatedAt = DateTime.UtcNow,
                    IsDeleted = false
                });
            }

            // Add English keys
            foreach (var kvp in commonKeysEn)
            {
                seedData.Add(new LocalizationValue
                {
                    Id = currentId++,
                    LanguageId = 2, // English
                    Key = kvp.Key,
                    Value = kvp.Value,
                    Description = $"English translation for {kvp.Key}",
                    Category = "Common",
                    IsActive = true,
                    CreatedAt = DateTime.UtcNow,
                    IsDeleted = false
                });
            }

            foreach (var kvp in pageKeysEn)
            {
                seedData.Add(new LocalizationValue
                {
                    Id = currentId++,
                    LanguageId = 2, // English
                    Key = kvp.Key,
                    Value = kvp.Value,
                    Description = $"English translation for {kvp.Key}",
                    Category = "Page",
                    IsActive = true,
                    CreatedAt = DateTime.UtcNow,
                    IsDeleted = false
                });
            }

            foreach (var kvp in sectionKeysEn)
            {
                seedData.Add(new LocalizationValue
                {
                    Id = currentId++,
                    LanguageId = 2, // English
                    Key = kvp.Key,
                    Value = kvp.Value,
                    Description = $"English translation for {kvp.Key}",
                    Category = "Section",
                    IsActive = true,
                    CreatedAt = DateTime.UtcNow,
                    IsDeleted = false
                });
            }

            foreach (var kvp in validationKeysEn)
            {
                seedData.Add(new LocalizationValue
                {
                    Id = currentId++,
                    LanguageId = 2, // English
                    Key = kvp.Key,
                    Value = kvp.Value,
                    Description = $"English translation for {kvp.Key}",
                    Category = "Validation",
                    IsActive = true,
                    CreatedAt = DateTime.UtcNow,
                    IsDeleted = false
                });
            }

            foreach (var kvp in navigationKeysEn)
            {
                seedData.Add(new LocalizationValue
                {
                    Id = currentId++,
                    LanguageId = 2, // English
                    Key = kvp.Key,
                    Value = kvp.Value,
                    Description = $"English translation for {kvp.Key}",
                    Category = "Navigation",
                    IsActive = true,
                    CreatedAt = DateTime.UtcNow,
                    IsDeleted = false
                });
            }

            foreach (var kvp in languageKeysEn)
            {
                seedData.Add(new LocalizationValue
                {
                    Id = currentId++,
                    LanguageId = 2, // English
                    Key = kvp.Key,
                    Value = kvp.Value,
                    Description = $"English translation for {kvp.Key}",
                    Category = "Language",
                    IsActive = true,
                    CreatedAt = DateTime.UtcNow,
                    IsDeleted = false
                });
            }

            foreach (var kvp in dashboardKeysEn)
            {
                seedData.Add(new LocalizationValue
                {
                    Id = currentId++,
                    LanguageId = 2, // English
                    Key = kvp.Key,
                    Value = kvp.Value,
                    Description = $"English translation for {kvp.Key}",
                    Category = "Dashboard",
                    IsActive = true,
                    CreatedAt = DateTime.UtcNow,
                    IsDeleted = false
                });
            }

            builder.HasData(seedData);
            // Seed data will be added via data seeder service instead of migration
            // This prevents conflicts with existing data
        }
    }
}