using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PazarAtlasi.CMS.Domain.Entities.Content;

namespace PazarAtlasi.CMS.Persistence.EntityConfigurations.Content.SeedData
{
    public static class SectionItemFieldTranslationSeedData
    {
        public static void SeedCommonFieldTranslations(this EntityTypeBuilder<SectionItemFieldTranslation> builder)
        {
            var baseDate = new DateTime(2024, 10, 25, 10, 0, 0);
            int translationId = 1;
            
            builder.HasData(
                // ============================================
                // MAIN MENU FIELDS TRANSLATIONS
                // ============================================
                
                // About Menu Fields (Field ID: 1-3)
                new SectionItemFieldTranslation
                {
                    Id = translationId++,
                    SectionItemFieldId = 1, // About Menu Label
                    LanguageId = 1, // Turkish
                    Label = "Menü Etiketi",
                    Description = "Ana menü etiketi",
                    Placeholder = "Menü etiketini girin",
                    CreatedAt = baseDate,
                    IsDeleted = false
                },
                new SectionItemFieldTranslation
                {
                    Id = translationId++,
                    SectionItemFieldId = 1,
                    LanguageId = 2, // English
                    Label = "Menu Label",
                    Description = "Main menu label",
                    Placeholder = "Enter menu label",
                    CreatedAt = baseDate,
                    IsDeleted = false
                },
                
                new SectionItemFieldTranslation
                {
                    Id = translationId++,
                    SectionItemFieldId = 2, // About Menu Type
                    LanguageId = 1,
                    Label = "Menü Tipi",
                    Description = "Menü türü (megamenu, dropdown, vb.)",
                    Placeholder = "Menü tipini girin",
                    CreatedAt = baseDate,
                    IsDeleted = false
                },
                new SectionItemFieldTranslation
                {
                    Id = translationId++,
                    SectionItemFieldId = 2,
                    LanguageId = 2,
                    Label = "Menu Type",
                    Description = "Menu type (megamenu, dropdown, etc.)",
                    Placeholder = "Enter menu type",
                    CreatedAt = baseDate,
                    IsDeleted = false
                },
                
                new SectionItemFieldTranslation
                {
                    Id = translationId++,
                    SectionItemFieldId = 3, // About Menu URL
                    LanguageId = 1,
                    Label = "Menü URL'si",
                    Description = "Menü URL'si (dropdown'lar için opsiyonel)",
                    Placeholder = "Menü URL'sini girin",
                    CreatedAt = baseDate,
                    IsDeleted = false
                },
                new SectionItemFieldTranslation
                {
                    Id = translationId++,
                    SectionItemFieldId = 3,
                    LanguageId = 2,
                    Label = "Menu URL",
                    Description = "Menu URL (optional for dropdowns)",
                    Placeholder = "Enter menu URL",
                    CreatedAt = baseDate,
                    IsDeleted = false
                },

                // About Description Section Fields (Field ID: 4-7)
                new SectionItemFieldTranslation
                {
                    Id = translationId++,
                    SectionItemFieldId = 4, // Description Title
                    LanguageId = 1,
                    Label = "Açıklama Başlığı",
                    Description = "Açıklama bölümü başlığı",
                    Placeholder = "Açıklama başlığını girin",
                    CreatedAt = baseDate,
                    IsDeleted = false
                },
                new SectionItemFieldTranslation
                {
                    Id = translationId++,
                    SectionItemFieldId = 4,
                    LanguageId = 2,
                    Label = "Description Title",
                    Description = "Description section title",
                    Placeholder = "Enter description title",
                    CreatedAt = baseDate,
                    IsDeleted = false
                },
                
                new SectionItemFieldTranslation
                {
                    Id = translationId++,
                    SectionItemFieldId = 5, // Description Text
                    LanguageId = 1,
                    Label = "Açıklama Metni",
                    Description = "Açıklama içeriği",
                    Placeholder = "Açıklama metnini girin",
                    CreatedAt = baseDate,
                    IsDeleted = false
                },
                new SectionItemFieldTranslation
                {
                    Id = translationId++,
                    SectionItemFieldId = 5,
                    LanguageId = 2,
                    Label = "Description Text",
                    Description = "Description content",
                    Placeholder = "Enter description text",
                    CreatedAt = baseDate,
                    IsDeleted = false
                },
                
                new SectionItemFieldTranslation
                {
                    Id = translationId++,
                    SectionItemFieldId = 6, // Link Text
                    LanguageId = 1,
                    Label = "Link Metni",
                    Description = "Link buton metni",
                    Placeholder = "Link metnini girin",
                    CreatedAt = baseDate,
                    IsDeleted = false
                },
                new SectionItemFieldTranslation
                {
                    Id = translationId++,
                    SectionItemFieldId = 6,
                    LanguageId = 2,
                    Label = "Link Text",
                    Description = "Link button text",
                    Placeholder = "Enter link text",
                    CreatedAt = baseDate,
                    IsDeleted = false
                },
                
                new SectionItemFieldTranslation
                {
                    Id = translationId++,
                    SectionItemFieldId = 7, // Link URL
                    LanguageId = 1,
                    Label = "Link URL'si",
                    Description = "Link hedef URL'si",
                    Placeholder = "Link URL'sini girin",
                    CreatedAt = baseDate,
                    IsDeleted = false
                },
                new SectionItemFieldTranslation
                {
                    Id = translationId++,
                    SectionItemFieldId = 7,
                    LanguageId = 2,
                    Label = "Link URL",
                    Description = "Link target URL",
                    Placeholder = "Enter link URL",
                    CreatedAt = baseDate,
                    IsDeleted = false
                },

                // Quick Links Section Fields (Field ID: 8)
                new SectionItemFieldTranslation
                {
                    Id = translationId++,
                    SectionItemFieldId = 8, // Quick Links Title
                    LanguageId = 1,
                    Label = "Bölüm Başlığı",
                    Description = "Hızlı linkler bölümü başlığı",
                    Placeholder = "Bölüm başlığını girin",
                    CreatedAt = baseDate,
                    IsDeleted = false
                },
                new SectionItemFieldTranslation
                {
                    Id = translationId++,
                    SectionItemFieldId = 8,
                    LanguageId = 2,
                    Label = "Section Title",
                    Description = "Quick links section title",
                    Placeholder = "Enter section title",
                    CreatedAt = baseDate,
                    IsDeleted = false
                },

                // Quick Link Items Fields (Field ID: 9-16)
                new SectionItemFieldTranslation
                {
                    Id = translationId++,
                    SectionItemFieldId = 9, // Mission & Vision Text
                    LanguageId = 1,
                    Label = "Link Metni",
                    Description = "Misyon ve vizyon link metni",
                    Placeholder = "Link metnini girin",
                    CreatedAt = baseDate,
                    IsDeleted = false
                },
                new SectionItemFieldTranslation
                {
                    Id = translationId++,
                    SectionItemFieldId = 9,
                    LanguageId = 2,
                    Label = "Link Text",
                    Description = "Mission and vision link text",
                    Placeholder = "Enter link text",
                    CreatedAt = baseDate,
                    IsDeleted = false
                },
                
                new SectionItemFieldTranslation
                {
                    Id = translationId++,
                    SectionItemFieldId = 10, // Mission & Vision URL
                    LanguageId = 1,
                    Label = "Link URL'si",
                    Description = "Misyon ve vizyon link URL'si",
                    Placeholder = "Link URL'sini girin",
                    CreatedAt = baseDate,
                    IsDeleted = false
                },
                new SectionItemFieldTranslation
                {
                    Id = translationId++,
                    SectionItemFieldId = 10,
                    LanguageId = 2,
                    Label = "Link URL",
                    Description = "Mission and vision link URL",
                    Placeholder = "Enter link URL",
                    CreatedAt = baseDate,
                    IsDeleted = false
                },

                new SectionItemFieldTranslation
                {
                    Id = translationId++,
                    SectionItemFieldId = 11, // Team Text
                    LanguageId = 1,
                    Label = "Link Metni",
                    Description = "Takım link metni",
                    Placeholder = "Link metnini girin",
                    CreatedAt = baseDate,
                    IsDeleted = false
                },
                new SectionItemFieldTranslation
                {
                    Id = translationId++,
                    SectionItemFieldId = 11,
                    LanguageId = 2,
                    Label = "Link Text",
                    Description = "Team link text",
                    Placeholder = "Enter link text",
                    CreatedAt = baseDate,
                    IsDeleted = false
                },
                
                new SectionItemFieldTranslation
                {
                    Id = translationId++,
                    SectionItemFieldId = 12, // Team URL
                    LanguageId = 1,
                    Label = "Link URL'si",
                    Description = "Takım link URL'si",
                    Placeholder = "Link URL'sini girin",
                    CreatedAt = baseDate,
                    IsDeleted = false
                },
                new SectionItemFieldTranslation
                {
                    Id = translationId++,
                    SectionItemFieldId = 12,
                    LanguageId = 2,
                    Label = "Link URL",
                    Description = "Team link URL",
                    Placeholder = "Enter link URL",
                    CreatedAt = baseDate,
                    IsDeleted = false
                },

                new SectionItemFieldTranslation
                {
                    Id = translationId++,
                    SectionItemFieldId = 13, // Careers Text
                    LanguageId = 1,
                    Label = "Link Metni",
                    Description = "Kariyer link metni",
                    Placeholder = "Link metnini girin",
                    CreatedAt = baseDate,
                    IsDeleted = false
                },
                new SectionItemFieldTranslation
                {
                    Id = translationId++,
                    SectionItemFieldId = 13,
                    LanguageId = 2,
                    Label = "Link Text",
                    Description = "Careers link text",
                    Placeholder = "Enter link text",
                    CreatedAt = baseDate,
                    IsDeleted = false
                },
                
                new SectionItemFieldTranslation
                {
                    Id = translationId++,
                    SectionItemFieldId = 14, // Careers URL
                    LanguageId = 1,
                    Label = "Link URL'si",
                    Description = "Kariyer link URL'si",
                    Placeholder = "Link URL'sini girin",
                    CreatedAt = baseDate,
                    IsDeleted = false
                },
                new SectionItemFieldTranslation
                {
                    Id = translationId++,
                    SectionItemFieldId = 14,
                    LanguageId = 2,
                    Label = "Link URL",
                    Description = "Careers link URL",
                    Placeholder = "Enter link URL",
                    CreatedAt = baseDate,
                    IsDeleted = false
                },

                new SectionItemFieldTranslation
                {
                    Id = translationId++,
                    SectionItemFieldId = 15, // Press Text
                    LanguageId = 1,
                    Label = "Link Metni",
                    Description = "Basın link metni",
                    Placeholder = "Link metnini girin",
                    CreatedAt = baseDate,
                    IsDeleted = false
                },
                new SectionItemFieldTranslation
                {
                    Id = translationId++,
                    SectionItemFieldId = 15,
                    LanguageId = 2,
                    Label = "Link Text",
                    Description = "Press link text",
                    Placeholder = "Enter link text",
                    CreatedAt = baseDate,
                    IsDeleted = false
                },
                
                new SectionItemFieldTranslation
                {
                    Id = translationId++,
                    SectionItemFieldId = 16, // Press URL
                    LanguageId = 1,
                    Label = "Link URL'si",
                    Description = "Basın link URL'si",
                    Placeholder = "Link URL'sini girin",
                    CreatedAt = baseDate,
                    IsDeleted = false
                },
                new SectionItemFieldTranslation
                {
                    Id = translationId++,
                    SectionItemFieldId = 16,
                    LanguageId = 2,
                    Label = "Link URL",
                    Description = "Press link URL",
                    Placeholder = "Enter link URL",
                    CreatedAt = baseDate,
                    IsDeleted = false
                },

                // Features Section Fields (Field ID: 17)
                new SectionItemFieldTranslation
                {
                    Id = translationId++,
                    SectionItemFieldId = 17, // Features Title
                    LanguageId = 1,
                    Label = "Bölüm Başlığı",
                    Description = "Özellikler bölümü başlığı",
                    Placeholder = "Bölüm başlığını girin",
                    CreatedAt = baseDate,
                    IsDeleted = false
                },
                new SectionItemFieldTranslation
                {
                    Id = translationId++,
                    SectionItemFieldId = 17,
                    LanguageId = 2,
                    Label = "Section Title",
                    Description = "Features section title",
                    Placeholder = "Enter section title",
                    CreatedAt = baseDate,
                    IsDeleted = false
                },

                // Feature Items Fields (Field ID: 18-23)
                new SectionItemFieldTranslation
                {
                    Id = translationId++,
                    SectionItemFieldId = 18, // Experience Title
                    LanguageId = 1,
                    Label = "Özellik Başlığı",
                    Description = "Deneyim özellik başlığı",
                    Placeholder = "Özellik başlığını girin",
                    CreatedAt = baseDate,
                    IsDeleted = false
                },
                new SectionItemFieldTranslation
                {
                    Id = translationId++,
                    SectionItemFieldId = 18,
                    LanguageId = 2,
                    Label = "Feature Title",
                    Description = "Experience feature title",
                    Placeholder = "Enter feature title",
                    CreatedAt = baseDate,
                    IsDeleted = false
                },
                
                new SectionItemFieldTranslation
                {
                    Id = translationId++,
                    SectionItemFieldId = 19, // Experience Description
                    LanguageId = 1,
                    Label = "Özellik Açıklaması",
                    Description = "Deneyim özellik açıklaması",
                    Placeholder = "Özellik açıklamasını girin",
                    CreatedAt = baseDate,
                    IsDeleted = false
                },
                new SectionItemFieldTranslation
                {
                    Id = translationId++,
                    SectionItemFieldId = 19,
                    LanguageId = 2,
                    Label = "Feature Description",
                    Description = "Experience feature description",
                    Placeholder = "Enter feature description",
                    CreatedAt = baseDate,
                    IsDeleted = false
                },

                new SectionItemFieldTranslation
                {
                    Id = translationId++,
                    SectionItemFieldId = 20, // Certified Team Title
                    LanguageId = 1,
                    Label = "Özellik Başlığı",
                    Description = "Sertifikalı takım özellik başlığı",
                    Placeholder = "Özellik başlığını girin",
                    CreatedAt = baseDate,
                    IsDeleted = false
                },
                new SectionItemFieldTranslation
                {
                    Id = translationId++,
                    SectionItemFieldId = 20,
                    LanguageId = 2,
                    Label = "Feature Title",
                    Description = "Certified team feature title",
                    Placeholder = "Enter feature title",
                    CreatedAt = baseDate,
                    IsDeleted = false
                },
                
                new SectionItemFieldTranslation
                {
                    Id = translationId++,
                    SectionItemFieldId = 21, // Certified Team Description
                    LanguageId = 1,
                    Label = "Özellik Açıklaması",
                    Description = "Sertifikalı takım özellik açıklaması",
                    Placeholder = "Özellik açıklamasını girin",
                    CreatedAt = baseDate,
                    IsDeleted = false
                },
                new SectionItemFieldTranslation
                {
                    Id = translationId++,
                    SectionItemFieldId = 21,
                    LanguageId = 2,
                    Label = "Feature Description",
                    Description = "Certified team feature description",
                    Placeholder = "Enter feature description",
                    CreatedAt = baseDate,
                    IsDeleted = false
                },

                new SectionItemFieldTranslation
                {
                    Id = translationId++,
                    SectionItemFieldId = 22, // Projects Title
                    LanguageId = 1,
                    Label = "Özellik Başlığı",
                    Description = "Projeler özellik başlığı",
                    Placeholder = "Özellik başlığını girin",
                    CreatedAt = baseDate,
                    IsDeleted = false
                },
                new SectionItemFieldTranslation
                {
                    Id = translationId++,
                    SectionItemFieldId = 22,
                    LanguageId = 2,
                    Label = "Feature Title",
                    Description = "Projects feature title",
                    Placeholder = "Enter feature title",
                    CreatedAt = baseDate,
                    IsDeleted = false
                },
                
                new SectionItemFieldTranslation
                {
                    Id = translationId++,
                    SectionItemFieldId = 23, // Projects Description
                    LanguageId = 1,
                    Label = "Özellik Açıklaması",
                    Description = "Projeler özellik açıklaması",
                    Placeholder = "Özellik açıklamasını girin",
                    CreatedAt = baseDate,
                    IsDeleted = false
                },
                new SectionItemFieldTranslation
                {
                    Id = translationId++,
                    SectionItemFieldId = 23,
                    LanguageId = 2,
                    Label = "Feature Description",
                    Description = "Projects feature description",
                    Placeholder = "Enter feature description",
                    CreatedAt = baseDate,
                    IsDeleted = false
                },

                // ============================================
                // SERVICES MENU FIELDS TRANSLATIONS
                // ============================================
                
                // Services Menu Fields (Field ID: 24-25)
                new SectionItemFieldTranslation
                {
                    Id = translationId++,
                    SectionItemFieldId = 24, // Services Menu Label
                    LanguageId = 1,
                    Label = "Menü Etiketi",
                    Description = "Hizmetler menü etiketi",
                    Placeholder = "Menü etiketini girin",
                    CreatedAt = baseDate,
                    IsDeleted = false
                },
                new SectionItemFieldTranslation
                {
                    Id = translationId++,
                    SectionItemFieldId = 24,
                    LanguageId = 2,
                    Label = "Menu Label",
                    Description = "Services menu label",
                    Placeholder = "Enter menu label",
                    CreatedAt = baseDate,
                    IsDeleted = false
                },
                
                new SectionItemFieldTranslation
                {
                    Id = translationId++,
                    SectionItemFieldId = 25, // Services Menu Type
                    LanguageId = 1,
                    Label = "Menü Tipi",
                    Description = "Hizmetler menü türü",
                    Placeholder = "Menü tipini girin",
                    CreatedAt = baseDate,
                    IsDeleted = false
                },
                new SectionItemFieldTranslation
                {
                    Id = translationId++,
                    SectionItemFieldId = 25,
                    LanguageId = 2,
                    Label = "Menu Type",
                    Description = "Services menu type",
                    Placeholder = "Enter menu type",
                    CreatedAt = baseDate,
                    IsDeleted = false
                },

                // Service Tab Fields (Field ID: 26-37)
                new SectionItemFieldTranslation
                {
                    Id = translationId++,
                    SectionItemFieldId = 26, // Managed Tab Label
                    LanguageId = 1,
                    Label = "Sekme Etiketi",
                    Description = "Yönetilen hizmetler sekme etiketi",
                    Placeholder = "Sekme etiketini girin",
                    CreatedAt = baseDate,
                    IsDeleted = false
                },
                new SectionItemFieldTranslation
                {
                    Id = translationId++,
                    SectionItemFieldId = 26,
                    LanguageId = 2,
                    Label = "Tab Label",
                    Description = "Managed services tab label",
                    Placeholder = "Enter tab label",
                    CreatedAt = baseDate,
                    IsDeleted = false
                },
                
                new SectionItemFieldTranslation
                {
                    Id = translationId++,
                    SectionItemFieldId = 27, // Managed Tab Icon
                    LanguageId = 1,
                    Label = "Sekme İkonu",
                    Description = "Yönetilen hizmetler sekme ikonu",
                    Placeholder = "İkon sınıfını girin",
                    CreatedAt = baseDate,
                    IsDeleted = false
                },
                new SectionItemFieldTranslation
                {
                    Id = translationId++,
                    SectionItemFieldId = 27,
                    LanguageId = 2,
                    Label = "Tab Icon",
                    Description = "Managed services tab icon",
                    Placeholder = "Enter icon class",
                    CreatedAt = baseDate,
                    IsDeleted = false
                },

                new SectionItemFieldTranslation
                {
                    Id = translationId++,
                    SectionItemFieldId = 28, // Cloud Tab Label
                    LanguageId = 1,
                    Label = "Sekme Etiketi",
                    Description = "Bulut hizmetleri sekme etiketi",
                    Placeholder = "Sekme etiketini girin",
                    CreatedAt = baseDate,
                    IsDeleted = false
                },
                new SectionItemFieldTranslation
                {
                    Id = translationId++,
                    SectionItemFieldId = 28,
                    LanguageId = 2,
                    Label = "Tab Label",
                    Description = "Cloud services tab label",
                    Placeholder = "Enter tab label",
                    CreatedAt = baseDate,
                    IsDeleted = false
                },
                
                new SectionItemFieldTranslation
                {
                    Id = translationId++,
                    SectionItemFieldId = 29, // Cloud Tab Icon
                    LanguageId = 1,
                    Label = "Sekme İkonu",
                    Description = "Bulut hizmetleri sekme ikonu",
                    Placeholder = "İkon sınıfını girin",
                    CreatedAt = baseDate,
                    IsDeleted = false
                },
                new SectionItemFieldTranslation
                {
                    Id = translationId++,
                    SectionItemFieldId = 29,
                    LanguageId = 2,
                    Label = "Tab Icon",
                    Description = "Cloud services tab icon",
                    Placeholder = "Enter icon class",
                    CreatedAt = baseDate,
                    IsDeleted = false
                },

                new SectionItemFieldTranslation
                {
                    Id = translationId++,
                    SectionItemFieldId = 30, // Security Tab Label
                    LanguageId = 1,
                    Label = "Sekme Etiketi",
                    Description = "Güvenlik hizmetleri sekme etiketi",
                    Placeholder = "Sekme etiketini girin",
                    CreatedAt = baseDate,
                    IsDeleted = false
                },
                new SectionItemFieldTranslation
                {
                    Id = translationId++,
                    SectionItemFieldId = 30,
                    LanguageId = 2,
                    Label = "Tab Label",
                    Description = "Security services tab label",
                    Placeholder = "Enter tab label",
                    CreatedAt = baseDate,
                    IsDeleted = false
                },
                
                new SectionItemFieldTranslation
                {
                    Id = translationId++,
                    SectionItemFieldId = 31, // Security Tab Icon
                    LanguageId = 1,
                    Label = "Sekme İkonu",
                    Description = "Güvenlik hizmetleri sekme ikonu",
                    Placeholder = "İkon sınıfını girin",
                    CreatedAt = baseDate,
                    IsDeleted = false
                },
                new SectionItemFieldTranslation
                {
                    Id = translationId++,
                    SectionItemFieldId = 31,
                    LanguageId = 2,
                    Label = "Tab Icon",
                    Description = "Security services tab icon",
                    Placeholder = "Enter icon class",
                    CreatedAt = baseDate,
                    IsDeleted = false
                },

                new SectionItemFieldTranslation
                {
                    Id = translationId++,
                    SectionItemFieldId = 32, // Database Tab Label
                    LanguageId = 1,
                    Label = "Sekme Etiketi",
                    Description = "Veritabanı hizmetleri sekme etiketi",
                    Placeholder = "Sekme etiketini girin",
                    CreatedAt = baseDate,
                    IsDeleted = false
                },
                new SectionItemFieldTranslation
                {
                    Id = translationId++,
                    SectionItemFieldId = 32,
                    LanguageId = 2,
                    Label = "Tab Label",
                    Description = "Database services tab label",
                    Placeholder = "Enter tab label",
                    CreatedAt = baseDate,
                    IsDeleted = false
                },
                
                new SectionItemFieldTranslation
                {
                    Id = translationId++,
                    SectionItemFieldId = 33, // Database Tab Icon
                    LanguageId = 1,
                    Label = "Sekme İkonu",
                    Description = "Veritabanı hizmetleri sekme ikonu",
                    Placeholder = "İkon sınıfını girin",
                    CreatedAt = baseDate,
                    IsDeleted = false
                },
                new SectionItemFieldTranslation
                {
                    Id = translationId++,
                    SectionItemFieldId = 33,
                    LanguageId = 2,
                    Label = "Tab Icon",
                    Description = "Database services tab icon",
                    Placeholder = "Enter icon class",
                    CreatedAt = baseDate,
                    IsDeleted = false
                },

                new SectionItemFieldTranslation
                {
                    Id = translationId++,
                    SectionItemFieldId = 34, // Monitoring Tab Label
                    LanguageId = 1,
                    Label = "Sekme Etiketi",
                    Description = "İzleme hizmetleri sekme etiketi",
                    Placeholder = "Sekme etiketini girin",
                    CreatedAt = baseDate,
                    IsDeleted = false
                },
                new SectionItemFieldTranslation
                {
                    Id = translationId++,
                    SectionItemFieldId = 34,
                    LanguageId = 2,
                    Label = "Tab Label",
                    Description = "Monitoring services tab label",
                    Placeholder = "Enter tab label",
                    CreatedAt = baseDate,
                    IsDeleted = false
                },
                
                new SectionItemFieldTranslation
                {
                    Id = translationId++,
                    SectionItemFieldId = 35, // Monitoring Tab Icon
                    LanguageId = 1,
                    Label = "Sekme İkonu",
                    Description = "İzleme hizmetleri sekme ikonu",
                    Placeholder = "İkon sınıfını girin",
                    CreatedAt = baseDate,
                    IsDeleted = false
                },
                new SectionItemFieldTranslation
                {
                    Id = translationId++,
                    SectionItemFieldId = 35,
                    LanguageId = 2,
                    Label = "Tab Icon",
                    Description = "Monitoring services tab icon",
                    Placeholder = "Enter icon class",
                    CreatedAt = baseDate,
                    IsDeleted = false
                },

                new SectionItemFieldTranslation
                {
                    Id = translationId++,
                    SectionItemFieldId = 36, // Premium Tab Label
                    LanguageId = 1,
                    Label = "Sekme Etiketi",
                    Description = "Premium hizmetler sekme etiketi",
                    Placeholder = "Sekme etiketini girin",
                    CreatedAt = baseDate,
                    IsDeleted = false
                },
                new SectionItemFieldTranslation
                {
                    Id = translationId++,
                    SectionItemFieldId = 36,
                    LanguageId = 2,
                    Label = "Tab Label",
                    Description = "Premium services tab label",
                    Placeholder = "Enter tab label",
                    CreatedAt = baseDate,
                    IsDeleted = false
                },
                
                new SectionItemFieldTranslation
                {
                    Id = translationId++,
                    SectionItemFieldId = 37, // Premium Tab Icon
                    LanguageId = 1,
                    Label = "Sekme İkonu",
                    Description = "Premium hizmetler sekme ikonu",
                    Placeholder = "İkon sınıfını girin",
                    CreatedAt = baseDate,
                    IsDeleted = false
                },
                new SectionItemFieldTranslation
                {
                    Id = translationId++,
                    SectionItemFieldId = 37,
                    LanguageId = 2,
                    Label = "Tab Icon",
                    Description = "Premium services tab icon",
                    Placeholder = "Enter icon class",
                    CreatedAt = baseDate,
                    IsDeleted = false
                },

                // Service Content Fields (Field ID: 38-40)
                new SectionItemFieldTranslation
                {
                    Id = translationId++,
                    SectionItemFieldId = 38, // Multi-Cloud Service Title
                    LanguageId = 1,
                    Label = "Hizmet Başlığı",
                    Description = "Multi-cloud hizmet başlığı",
                    Placeholder = "Hizmet başlığını girin",
                    CreatedAt = baseDate,
                    IsDeleted = false
                },
                new SectionItemFieldTranslation
                {
                    Id = translationId++,
                    SectionItemFieldId = 38,
                    LanguageId = 2,
                    Label = "Service Title",
                    Description = "Multi-cloud service title",
                    Placeholder = "Enter service title",
                    CreatedAt = baseDate,
                    IsDeleted = false
                },
                
                new SectionItemFieldTranslation
                {
                    Id = translationId++,
                    SectionItemFieldId = 39, // Multi-Cloud Service Description
                    LanguageId = 1,
                    Label = "Hizmet Açıklaması",
                    Description = "Multi-cloud hizmet açıklaması",
                    Placeholder = "Hizmet açıklamasını girin",
                    CreatedAt = baseDate,
                    IsDeleted = false
                },
                new SectionItemFieldTranslation
                {
                    Id = translationId++,
                    SectionItemFieldId = 39,
                    LanguageId = 2,
                    Label = "Service Description",
                    Description = "Multi-cloud service description",
                    Placeholder = "Enter service description",
                    CreatedAt = baseDate,
                    IsDeleted = false
                },
                
                new SectionItemFieldTranslation
                {
                    Id = translationId++,
                    SectionItemFieldId = 40, // Multi-Cloud Service Icon
                    LanguageId = 1,
                    Label = "Hizmet İkonu",
                    Description = "Multi-cloud hizmet ikonu",
                    Placeholder = "İkon sınıfını girin",
                    CreatedAt = baseDate,
                    IsDeleted = false
                },
                new SectionItemFieldTranslation
                {
                    Id = translationId++,
                    SectionItemFieldId = 40,
                    LanguageId = 2,
                    Label = "Service Icon",
                    Description = "Multi-cloud service icon",
                    Placeholder = "Enter icon class",
                    CreatedAt = baseDate,
                    IsDeleted = false
                },

                // ============================================
                // SOLUTIONS MENU FIELDS TRANSLATIONS
                // ============================================
                
                // Solutions Menu Fields (Field ID: 41-42)
                new SectionItemFieldTranslation
                {
                    Id = translationId++,
                    SectionItemFieldId = 41, // Solutions Menu Label
                    LanguageId = 1,
                    Label = "Menü Etiketi",
                    Description = "Çözümler menü etiketi",
                    Placeholder = "Menü etiketini girin",
                    CreatedAt = baseDate,
                    IsDeleted = false
                },
                new SectionItemFieldTranslation
                {
                    Id = translationId++,
                    SectionItemFieldId = 41,
                    LanguageId = 2,
                    Label = "Menu Label",
                    Description = "Solutions menu label",
                    Placeholder = "Enter menu label",
                    CreatedAt = baseDate,
                    IsDeleted = false
                },
                
                new SectionItemFieldTranslation
                {
                    Id = translationId++,
                    SectionItemFieldId = 42, // Solutions Menu Type
                    LanguageId = 1,
                    Label = "Menü Tipi",
                    Description = "Çözümler menü türü",
                    Placeholder = "Menü tipini girin",
                    CreatedAt = baseDate,
                    IsDeleted = false
                },
                new SectionItemFieldTranslation
                {
                    Id = translationId++,
                    SectionItemFieldId = 42,
                    LanguageId = 2,
                    Label = "Menu Type",
                    Description = "Solutions menu type",
                    Placeholder = "Enter menu type",
                    CreatedAt = baseDate,
                    IsDeleted = false
                },

                // Solution Category Fields (Field ID: 43-44)
                new SectionItemFieldTranslation
                {
                    Id = translationId++,
                    SectionItemFieldId = 43, // Software Category Label
                    LanguageId = 1,
                    Label = "Kategori Etiketi",
                    Description = "Yazılım çözümleri kategori etiketi",
                    Placeholder = "Kategori etiketini girin",
                    CreatedAt = baseDate,
                    IsDeleted = false
                },
                new SectionItemFieldTranslation
                {
                    Id = translationId++,
                    SectionItemFieldId = 43,
                    LanguageId = 2,
                    Label = "Category Label",
                    Description = "Software solutions category label",
                    Placeholder = "Enter category label",
                    CreatedAt = baseDate,
                    IsDeleted = false
                },
                
                new SectionItemFieldTranslation
                {
                    Id = translationId++,
                    SectionItemFieldId = 44, // Software Category Icon
                    LanguageId = 1,
                    Label = "Kategori İkonu",
                    Description = "Yazılım çözümleri kategori ikonu",
                    Placeholder = "İkon sınıfını girin",
                    CreatedAt = baseDate,
                    IsDeleted = false
                },
                new SectionItemFieldTranslation
                {
                    Id = translationId++,
                    SectionItemFieldId = 44,
                    LanguageId = 2,
                    Label = "Category Icon",
                    Description = "Software solutions category icon",
                    Placeholder = "Enter icon class",
                    CreatedAt = baseDate,
                    IsDeleted = false
                },

                // ============================================
                // BLOG MENU FIELDS TRANSLATIONS
                // ============================================
                
                // Blog Menu Fields (Field ID: 45-46)
                new SectionItemFieldTranslation
                {
                    Id = translationId++,
                    SectionItemFieldId = 45, // Blog Menu Label
                    LanguageId = 1,
                    Label = "Menü Etiketi",
                    Description = "Blog menü etiketi",
                    Placeholder = "Menü etiketini girin",
                    CreatedAt = baseDate,
                    IsDeleted = false
                },
                new SectionItemFieldTranslation
                {
                    Id = translationId++,
                    SectionItemFieldId = 45,
                    LanguageId = 2,
                    Label = "Menu Label",
                    Description = "Blog menu label",
                    Placeholder = "Enter menu label",
                    CreatedAt = baseDate,
                    IsDeleted = false
                },
                
                new SectionItemFieldTranslation
                {
                    Id = translationId++,
                    SectionItemFieldId = 46, // Blog Menu Type
                    LanguageId = 1,
                    Label = "Menü Tipi",
                    Description = "Blog menü türü",
                    Placeholder = "Menü tipini girin",
                    CreatedAt = baseDate,
                    IsDeleted = false
                },
                new SectionItemFieldTranslation
                {
                    Id = translationId++,
                    SectionItemFieldId = 46,
                    LanguageId = 2,
                    Label = "Menu Type",
                    Description = "Blog menu type",
                    Placeholder = "Enter menu type",
                    CreatedAt = baseDate,
                    IsDeleted = false
                },

                // Blog Description Fields (Field ID: 47-50)
                new SectionItemFieldTranslation
                {
                    Id = translationId++,
                    SectionItemFieldId = 47, // Blog Description Title
                    LanguageId = 1,
                    Label = "Açıklama Başlığı",
                    Description = "Blog açıklama başlığı",
                    Placeholder = "Açıklama başlığını girin",
                    CreatedAt = baseDate,
                    IsDeleted = false
                },
                new SectionItemFieldTranslation
                {
                    Id = translationId++,
                    SectionItemFieldId = 47,
                    LanguageId = 2,
                    Label = "Description Title",
                    Description = "Blog description title",
                    Placeholder = "Enter description title",
                    CreatedAt = baseDate,
                    IsDeleted = false
                },
                
                new SectionItemFieldTranslation
                {
                    Id = translationId++,
                    SectionItemFieldId = 48, // Blog Description Text
                    LanguageId = 1,
                    Label = "Açıklama Metni",
                    Description = "Blog açıklama metni",
                    Placeholder = "Açıklama metnini girin",
                    CreatedAt = baseDate,
                    IsDeleted = false
                },
                new SectionItemFieldTranslation
                {
                    Id = translationId++,
                    SectionItemFieldId = 48,
                    LanguageId = 2,
                    Label = "Description Text",
                    Description = "Blog description text",
                    Placeholder = "Enter description text",
                    CreatedAt = baseDate,
                    IsDeleted = false
                },
                
                new SectionItemFieldTranslation
                {
                    Id = translationId++,
                    SectionItemFieldId = 49, // Blog Link Text
                    LanguageId = 1,
                    Label = "Link Metni",
                    Description = "Blog link metni",
                    Placeholder = "Link metnini girin",
                    CreatedAt = baseDate,
                    IsDeleted = false
                },
                new SectionItemFieldTranslation
                {
                    Id = translationId++,
                    SectionItemFieldId = 49,
                    LanguageId = 2,
                    Label = "Link Text",
                    Description = "Blog link text",
                    Placeholder = "Enter link text",
                    CreatedAt = baseDate,
                    IsDeleted = false
                },
                
                new SectionItemFieldTranslation
                {
                    Id = translationId++,
                    SectionItemFieldId = 50, // Blog Link URL
                    LanguageId = 1,
                    Label = "Link URL'si",
                    Description = "Blog link URL'si",
                    Placeholder = "Link URL'sini girin",
                    CreatedAt = baseDate,
                    IsDeleted = false
                },
                new SectionItemFieldTranslation
                {
                    Id = translationId++,
                    SectionItemFieldId = 50,
                    LanguageId = 2,
                    Label = "Link URL",
                    Description = "Blog link URL",
                    Placeholder = "Enter link URL",
                    CreatedAt = baseDate,
                    IsDeleted = false
                },

                // Blog Post Fields (Field ID: 51-54)
                new SectionItemFieldTranslation
                {
                    Id = translationId++,
                    SectionItemFieldId = 51, // Kubernetes Post Title
                    LanguageId = 1,
                    Label = "Yazı Başlığı",
                    Description = "Kubernetes yazı başlığı",
                    Placeholder = "Yazı başlığını girin",
                    CreatedAt = baseDate,
                    IsDeleted = false
                },
                new SectionItemFieldTranslation
                {
                    Id = translationId++,
                    SectionItemFieldId = 51,
                    LanguageId = 2,
                    Label = "Post Title",
                    Description = "Kubernetes post title",
                    Placeholder = "Enter post title",
                    CreatedAt = baseDate,
                    IsDeleted = false
                },
                
                new SectionItemFieldTranslation
                {
                    Id = translationId++,
                    SectionItemFieldId = 52, // Kubernetes Post Image
                    LanguageId = 1,
                    Label = "Yazı Resmi",
                    Description = "Kubernetes yazı resmi",
                    Placeholder = "Resim URL'sini girin",
                    CreatedAt = baseDate,
                    IsDeleted = false
                },
                new SectionItemFieldTranslation
                {
                    Id = translationId++,
                    SectionItemFieldId = 52,
                    LanguageId = 2,
                    Label = "Post Image",
                    Description = "Kubernetes post image",
                    Placeholder = "Enter image URL",
                    CreatedAt = baseDate,
                    IsDeleted = false
                },
                
                new SectionItemFieldTranslation
                {
                    Id = translationId++,
                    SectionItemFieldId = 53, // Kubernetes Post Date
                    LanguageId = 1,
                    Label = "Yazı Tarihi",
                    Description = "Kubernetes yazı tarihi",
                    Placeholder = "Yazı tarihini girin",
                    CreatedAt = baseDate,
                    IsDeleted = false
                },
                new SectionItemFieldTranslation
                {
                    Id = translationId++,
                    SectionItemFieldId = 53,
                    LanguageId = 2,
                    Label = "Post Date",
                    Description = "Kubernetes post date",
                    Placeholder = "Enter post date",
                    CreatedAt = baseDate,
                    IsDeleted = false
                },
                
                new SectionItemFieldTranslation
                {
                    Id = translationId++,
                    SectionItemFieldId = 54, // Kubernetes Read Time
                    LanguageId = 1,
                    Label = "Okuma Süresi",
                    Description = "Kubernetes yazı okuma süresi",
                    Placeholder = "Okuma süresini girin",
                    CreatedAt = baseDate,
                    IsDeleted = false
                },
                new SectionItemFieldTranslation
                {
                    Id = translationId++,
                    SectionItemFieldId = 54,
                    LanguageId = 2,
                    Label = "Read Time",
                    Description = "Kubernetes post read time",
                    Placeholder = "Enter read time",
                    CreatedAt = baseDate,
                    IsDeleted = false
                },

                // ============================================
                // SIMPLE LINK MENU FIELDS TRANSLATIONS
                // ============================================
                
                // Careers Link Fields (Field ID: 55-56)
                new SectionItemFieldTranslation
                {
                    Id = translationId++,
                    SectionItemFieldId = 55, // Careers Label
                    LanguageId = 1,
                    Label = "Link Etiketi",
                    Description = "Kariyer link etiketi",
                    Placeholder = "Link etiketini girin",
                    CreatedAt = baseDate,
                    IsDeleted = false
                },
                new SectionItemFieldTranslation
                {
                    Id = translationId++,
                    SectionItemFieldId = 55,
                    LanguageId = 2,
                    Label = "Link Label",
                    Description = "Careers link label",
                    Placeholder = "Enter link label",
                    CreatedAt = baseDate,
                    IsDeleted = false
                },
                
                new SectionItemFieldTranslation
                {
                    Id = translationId++,
                    SectionItemFieldId = 56, // Careers URL
                    LanguageId = 1,
                    Label = "Link URL'si",
                    Description = "Kariyer link URL'si",
                    Placeholder = "Link URL'sini girin",
                    CreatedAt = baseDate,
                    IsDeleted = false
                },
                new SectionItemFieldTranslation
                {
                    Id = translationId++,
                    SectionItemFieldId = 56,
                    LanguageId = 2,
                    Label = "Link URL",
                    Description = "Careers link URL",
                    Placeholder = "Enter link URL",
                    CreatedAt = baseDate,
                    IsDeleted = false
                },

                // Data Center Link Fields (Field ID: 57-60)
                new SectionItemFieldTranslation
                {
                    Id = translationId++,
                    SectionItemFieldId = 57, // Data Center Label
                    LanguageId = 1,
                    Label = "Link Etiketi",
                    Description = "Veri merkezi link etiketi",
                    Placeholder = "Link etiketini girin",
                    CreatedAt = baseDate,
                    IsDeleted = false
                },
                new SectionItemFieldTranslation
                {
                    Id = translationId++,
                    SectionItemFieldId = 57,
                    LanguageId = 2,
                    Label = "Link Label",
                    Description = "Data center link label",
                    Placeholder = "Enter link label",
                    CreatedAt = baseDate,
                    IsDeleted = false
                },
                
                new SectionItemFieldTranslation
                {
                    Id = translationId++,
                    SectionItemFieldId = 58, // Data Center URL
                    LanguageId = 1,
                    Label = "Link URL'si",
                    Description = "Veri merkezi link URL'si",
                    Placeholder = "Link URL'sini girin",
                    CreatedAt = baseDate,
                    IsDeleted = false
                },
                new SectionItemFieldTranslation
                {
                    Id = translationId++,
                    SectionItemFieldId = 58,
                    LanguageId = 2,
                    Label = "Link URL",
                    Description = "Data center link URL",
                    Placeholder = "Enter link URL",
                    CreatedAt = baseDate,
                    IsDeleted = false
                },
                
                new SectionItemFieldTranslation
                {
                    Id = translationId++,
                    SectionItemFieldId = 59, // Data Center Show Status
                    LanguageId = 1,
                    Label = "Durum Göster",
                    Description = "Sistem durumunu göster",
                    Placeholder = "Durum gösterimini ayarla",
                    CreatedAt = baseDate,
                    IsDeleted = false
                },
                new SectionItemFieldTranslation
                {
                    Id = translationId++,
                    SectionItemFieldId = 59,
                    LanguageId = 2,
                    Label = "Show Status",
                    Description = "Show system status",
                    Placeholder = "Set status display",
                    CreatedAt = baseDate,
                    IsDeleted = false
                },
                
                new SectionItemFieldTranslation
                {
                    Id = translationId++,
                    SectionItemFieldId = 60, // Data Center Status
                    LanguageId = 1,
                    Label = "Durum",
                    Description = "Sistem durumu",
                    Placeholder = "Durumu girin",
                    CreatedAt = baseDate,
                    IsDeleted = false
                },
                new SectionItemFieldTranslation
                {
                    Id = translationId++,
                    SectionItemFieldId = 60,
                    LanguageId = 2,
                    Label = "Status",
                    Description = "System status",
                    Placeholder = "Enter status",
                    CreatedAt = baseDate,
                    IsDeleted = false
                },

                // References Link Fields (Field ID: 61-62)
                new SectionItemFieldTranslation
                {
                    Id = translationId++,
                    SectionItemFieldId = 61, // References Label
                    LanguageId = 1,
                    Label = "Link Etiketi",
                    Description = "Referanslar link etiketi",
                    Placeholder = "Link etiketini girin",
                    CreatedAt = baseDate,
                    IsDeleted = false
                },
                new SectionItemFieldTranslation
                {
                    Id = translationId++,
                    SectionItemFieldId = 61,
                    LanguageId = 2,
                    Label = "Link Label",
                    Description = "References link label",
                    Placeholder = "Enter link label",
                    CreatedAt = baseDate,
                    IsDeleted = false
                },
                
                new SectionItemFieldTranslation
                {
                    Id = translationId++,
                    SectionItemFieldId = 62, // References URL
                    LanguageId = 1,
                    Label = "Link URL'si",
                    Description = "Referanslar link URL'si",
                    Placeholder = "Link URL'sini girin",
                    CreatedAt = baseDate,
                    IsDeleted = false
                },
                new SectionItemFieldTranslation
                {
                    Id = translationId++,
                    SectionItemFieldId = 62,
                    LanguageId = 2,
                    Label = "Link URL",
                    Description = "References link URL",
                    Placeholder = "Enter link URL",
                    CreatedAt = baseDate,
                    IsDeleted = false
                },

                // ============================================
                // CONTACT MENU FIELDS TRANSLATIONS
                // ============================================
                
                // Contact Menu Fields (Field ID: 63-64)
                new SectionItemFieldTranslation
                {
                    Id = translationId++,
                    SectionItemFieldId = 63, // Contact Menu Label
                    LanguageId = 1,
                    Label = "Menü Etiketi",
                    Description = "İletişim menü etiketi",
                    Placeholder = "Menü etiketini girin",
                    CreatedAt = baseDate,
                    IsDeleted = false
                },
                new SectionItemFieldTranslation
                {
                    Id = translationId++,
                    SectionItemFieldId = 63,
                    LanguageId = 2,
                    Label = "Menu Label",
                    Description = "Contact menu label",
                    Placeholder = "Enter menu label",
                    CreatedAt = baseDate,
                    IsDeleted = false
                },
                
                new SectionItemFieldTranslation
                {
                    Id = translationId++,
                    SectionItemFieldId = 64, // Contact Menu Type
                    LanguageId = 1,
                    Label = "Menü Tipi",
                    Description = "İletişim menü türü",
                    Placeholder = "Menü tipini girin",
                    CreatedAt = baseDate,
                    IsDeleted = false
                },
                new SectionItemFieldTranslation
                {
                    Id = translationId++,
                    SectionItemFieldId = 64,
                    LanguageId = 2,
                    Label = "Menu Type",
                    Description = "Contact menu type",
                    Placeholder = "Enter menu type",
                    CreatedAt = baseDate,
                    IsDeleted = false
                },

                // Contact Info Fields (Field ID: 65-72)
                new SectionItemFieldTranslation
                {
                    Id = translationId++,
                    SectionItemFieldId = 65, // Email Label
                    LanguageId = 1,
                    Label = "İletişim Etiketi",
                    Description = "E-posta iletişim etiketi",
                    Placeholder = "İletişim etiketini girin",
                    CreatedAt = baseDate,
                    IsDeleted = false
                },
                new SectionItemFieldTranslation
                {
                    Id = translationId++,
                    SectionItemFieldId = 65,
                    LanguageId = 2,
                    Label = "Contact Label",
                    Description = "Email contact label",
                    Placeholder = "Enter contact label",
                    CreatedAt = baseDate,
                    IsDeleted = false
                },
                
                new SectionItemFieldTranslation
                {
                    Id = translationId++,
                    SectionItemFieldId = 66, // Email Value
                    LanguageId = 1,
                    Label = "İletişim Değeri",
                    Description = "E-posta iletişim değeri",
                    Placeholder = "İletişim değerini girin",
                    CreatedAt = baseDate,
                    IsDeleted = false
                },
                new SectionItemFieldTranslation
                {
                    Id = translationId++,
                    SectionItemFieldId = 66,
                    LanguageId = 2,
                    Label = "Contact Value",
                    Description = "Email contact value",
                    Placeholder = "Enter contact value",
                    CreatedAt = baseDate,
                    IsDeleted = false
                },
                
                new SectionItemFieldTranslation
                {
                    Id = translationId++,
                    SectionItemFieldId = 67, // Email Type
                    LanguageId = 1,
                    Label = "İletişim Tipi",
                    Description = "E-posta iletişim tipi",
                    Placeholder = "İletişim tipini girin",
                    CreatedAt = baseDate,
                    IsDeleted = false
                },
                new SectionItemFieldTranslation
                {
                    Id = translationId++,
                    SectionItemFieldId = 67,
                    LanguageId = 2,
                    Label = "Contact Type",
                    Description = "Email contact type",
                    Placeholder = "Enter contact type",
                    CreatedAt = baseDate,
                    IsDeleted = false
                },
                
                new SectionItemFieldTranslation
                {
                    Id = translationId++,
                    SectionItemFieldId = 68, // Email Icon
                    LanguageId = 1,
                    Label = "İletişim İkonu",
                    Description = "E-posta iletişim ikonu",
                    Placeholder = "İkon sınıfını girin",
                    CreatedAt = baseDate,
                    IsDeleted = false
                },
                new SectionItemFieldTranslation
                {
                    Id = translationId++,
                    SectionItemFieldId = 68,
                    LanguageId = 2,
                    Label = "Contact Icon",
                    Description = "Email contact icon",
                    Placeholder = "Enter icon class",
                    CreatedAt = baseDate,
                    IsDeleted = false
                },

                new SectionItemFieldTranslation
                {
                    Id = translationId++,
                    SectionItemFieldId = 69, // Address Label
                    LanguageId = 1,
                    Label = "İletişim Etiketi",
                    Description = "Adres iletişim etiketi",
                    Placeholder = "İletişim etiketini girin",
                    CreatedAt = baseDate,
                    IsDeleted = false
                },
                new SectionItemFieldTranslation
                {
                    Id = translationId++,
                    SectionItemFieldId = 69,
                    LanguageId = 2,
                    Label = "Contact Label",
                    Description = "Address contact label",
                    Placeholder = "Enter contact label",
                    CreatedAt = baseDate,
                    IsDeleted = false
                },
                
                new SectionItemFieldTranslation
                {
                    Id = translationId++,
                    SectionItemFieldId = 70, // Address Value
                    LanguageId = 1,
                    Label = "İletişim Değeri",
                    Description = "Adres iletişim değeri",
                    Placeholder = "İletişim değerini girin",
                    CreatedAt = baseDate,
                    IsDeleted = false
                },
                new SectionItemFieldTranslation
                {
                    Id = translationId++,
                    SectionItemFieldId = 70,
                    LanguageId = 2,
                    Label = "Contact Value",
                    Description = "Address contact value",
                    Placeholder = "Enter contact value",
                    CreatedAt = baseDate,
                    IsDeleted = false
                },
                
                new SectionItemFieldTranslation
                {
                    Id = translationId++,
                    SectionItemFieldId = 71, // Address Type
                    LanguageId = 1,
                    Label = "İletişim Tipi",
                    Description = "Adres iletişim tipi",
                    Placeholder = "İletişim tipini girin",
                    CreatedAt = baseDate,
                    IsDeleted = false
                },
                new SectionItemFieldTranslation
                {
                    Id = translationId++,
                    SectionItemFieldId = 71,
                    LanguageId = 2,
                    Label = "Contact Type",
                    Description = "Address contact type",
                    Placeholder = "Enter contact type",
                    CreatedAt = baseDate,
                    IsDeleted = false
                },
                
                new SectionItemFieldTranslation
                {
                    Id = translationId++,
                    SectionItemFieldId = 72, // Address Icon
                    LanguageId = 1,
                    Label = "İletişim İkonu",
                    Description = "Adres iletişim ikonu",
                    Placeholder = "İkon sınıfını girin",
                    CreatedAt = baseDate,
                    IsDeleted = false
                },
                new SectionItemFieldTranslation
                {
                    Id = translationId++,
                    SectionItemFieldId = 72,
                    LanguageId = 2,
                    Label = "Contact Icon",
                    Description = "Address contact icon",
                    Placeholder = "Enter icon class",
                    CreatedAt = baseDate,
                    IsDeleted = false
                }
            );
        }
    }
}
