using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PazarAtlasi.CMS.Domain.Entities.Content;

namespace PazarAtlasi.CMS.Persistence.EntityConfigurations.Content.SeedData
{
    public static class SectionItemFieldTranslationSeedData
    {
        public static void SeedCommonFieldTranslations(this EntityTypeBuilder<SectionItemFieldTranslation> builder)
        {
            var baseDate = new DateTime(2024, 10, 25, 10, 0, 0);
            int id = 1;
            
            builder.HasData(
                // ============================================
                // Title Field Translations (Field ID: 1)
                // ============================================
                new SectionItemFieldTranslation
                {
                    Id = id++,
                    SectionItemFieldId = 1,
                    LanguageId = 1, // Turkish
                    Label = "Label çevirisi giriniz.",
                    Description = "Label açıklaması.",
                    Placeholder = "Label giriniz.",
                    CreatedAt = baseDate,
                    IsDeleted = false
                },
                new SectionItemFieldTranslation
                {
                    Id = id++,
                    SectionItemFieldId = 1,
                    LanguageId = 2, // English
                    Label = "Title",
                    Description = "Menu title",
                    Placeholder = "Enter menu title",
                    CreatedAt = baseDate,
                    IsDeleted = false
                },
                
                // ============================================
                // URL Field Translations (Field ID: 2)
                // ============================================
                new SectionItemFieldTranslation
                {
                    Id = id++,
                    SectionItemFieldId = 2,
                    LanguageId = 1,
                    Label = "URL",
                    Description = "Menü URL'si",
                    Placeholder = "URL girin (dropdown'lar için opsiyonel)",
                    CreatedAt = baseDate,
                    IsDeleted = false
                },
                new SectionItemFieldTranslation
                {
                    Id = id++,
                    SectionItemFieldId = 2,
                    LanguageId = 2,
                    Label = "URL",
                    Description = "Menu URL",
                    Placeholder = "Enter URL (optional for dropdowns)",
                    CreatedAt = baseDate,
                    IsDeleted = false
                },
                
                // ============================================
                // Description Title Translations (Field ID: 3)
                // ============================================
                new SectionItemFieldTranslation
                {
                    Id = id++,
                    SectionItemFieldId = 3,
                    LanguageId = 1,
                    Label = "Açıklama Başlığı",
                    Description = "Açıklama bölümü başlığı",
                    Placeholder = "Açıklama başlığını girin",
                    CreatedAt = baseDate,
                    IsDeleted = false
                },
                new SectionItemFieldTranslation
                {
                    Id = id++,
                    SectionItemFieldId = 3,
                    LanguageId = 2,
                    Label = "Description Title",
                    Description = "Description section title",
                    Placeholder = "Enter description title",
                    CreatedAt = baseDate,
                    IsDeleted = false
                },
                
                // ============================================
                // Description Text Translations (Field ID: 4)
                // ============================================
                new SectionItemFieldTranslation
                {
                    Id = id++,
                    SectionItemFieldId = 4,
                    LanguageId = 1,
                    Label = "Açıklama Metni",
                    Description = "Açıklama içeriği",
                    Placeholder = "Açıklama metnini girin",
                    CreatedAt = baseDate,
                    IsDeleted = false
                },
                new SectionItemFieldTranslation
                {
                    Id = id++,
                    SectionItemFieldId = 4,
                    LanguageId = 2,
                    Label = "Description Text",
                    Description = "Description content",
                    Placeholder = "Enter description text",
                    CreatedAt = baseDate,
                    IsDeleted = false
                },
                
                // ============================================
                // Link Text Translations (Field ID: 5)
                // ============================================
                new SectionItemFieldTranslation
                {
                    Id = id++,
                    SectionItemFieldId = 5,
                    LanguageId = 1,
                    Label = "Link Metni",
                    Description = "Link buton metni",
                    Placeholder = "Link metnini girin",
                    CreatedAt = baseDate,
                    IsDeleted = false
                },
                new SectionItemFieldTranslation
                {
                    Id = id++,
                    SectionItemFieldId = 5,
                    LanguageId = 2,
                    Label = "Link Text",
                    Description = "Link button text",
                    Placeholder = "Enter link text",
                    CreatedAt = baseDate,
                    IsDeleted = false
                },
                
                // ============================================
                // Link URL Translations (Field ID: 6)
                // ============================================
                new SectionItemFieldTranslation
                {
                    Id = id++,
                    SectionItemFieldId = 6,
                    LanguageId = 1,
                    Label = "Link URL'si",
                    Description = "Link hedef URL'si",
                    Placeholder = "Link URL'sini girin",
                    CreatedAt = baseDate,
                    IsDeleted = false
                },
                new SectionItemFieldTranslation
                {
                    Id = id++,
                    SectionItemFieldId = 6,
                    LanguageId = 2,
                    Label = "Link URL",
                    Description = "Link target URL",
                    Placeholder = "Enter link URL",
                    CreatedAt = baseDate,
                    IsDeleted = false
                },
                
                // ============================================
                // Section Title Translations (Field ID: 7)
                // ============================================
                new SectionItemFieldTranslation
                {
                    Id = id++,
                    SectionItemFieldId = 7,
                    LanguageId = 1,
                    Label = "Bölüm Başlığı",
                    Description = "Bölüm başlığı",
                    Placeholder = "Bölüm başlığını girin",
                    CreatedAt = baseDate,
                    IsDeleted = false
                },
                new SectionItemFieldTranslation
                {
                    Id = id++,
                    SectionItemFieldId = 7,
                    LanguageId = 2,
                    Label = "Section Title",
                    Description = "Section title",
                    Placeholder = "Enter section title",
                    CreatedAt = baseDate,
                    IsDeleted = false
                },
                
                // ============================================
                // Link Text for Items Translations (Field ID: 8)
                // ============================================
                new SectionItemFieldTranslation
                {
                    Id = id++,
                    SectionItemFieldId = 8,
                    LanguageId = 1,
                    Label = "Link Metni",
                    Description = "Link öğesi metni",
                    Placeholder = "Link metnini girin",
                    CreatedAt = baseDate,
                    IsDeleted = false
                },
                new SectionItemFieldTranslation
                {
                    Id = id++,
                    SectionItemFieldId = 8,
                    LanguageId = 2,
                    Label = "Link Text",
                    Description = "Link item text",
                    Placeholder = "Enter link text",
                    CreatedAt = baseDate,
                    IsDeleted = false
                },
                
                // ============================================
                // Link URL for Items Translations (Field ID: 9)
                // ============================================
                new SectionItemFieldTranslation
                {
                    Id = id++,
                    SectionItemFieldId = 9,
                    LanguageId = 1,
                    Label = "Link URL'si",
                    Description = "Link hedef adresi",
                    Placeholder = "Link URL'sini girin",
                    CreatedAt = baseDate,
                    IsDeleted = false
                },
                new SectionItemFieldTranslation
                {
                    Id = id++,
                    SectionItemFieldId = 9,
                    LanguageId = 2,
                    Label = "Link URL",
                    Description = "Link target address",
                    Placeholder = "Enter link URL",
                    CreatedAt = baseDate,
                    IsDeleted = false
                },
                
                // ============================================
                // Feature Title Translations (Field ID: 10)
                // ============================================
                new SectionItemFieldTranslation
                {
                    Id = id++,
                    SectionItemFieldId = 10,
                    LanguageId = 1,
                    Label = "Özellik Başlığı",
                    Description = "Özellik kartı başlığı",
                    Placeholder = "Özellik başlığını girin",
                    CreatedAt = baseDate,
                    IsDeleted = false
                },
                new SectionItemFieldTranslation
                {
                    Id = id++,
                    SectionItemFieldId = 10,
                    LanguageId = 2,
                    Label = "Feature Title",
                    Description = "Feature card title",
                    Placeholder = "Enter feature title",
                    CreatedAt = baseDate,
                    IsDeleted = false
                },
                
                // ============================================
                // Feature Description Translations (Field ID: 11)
                // ============================================
                new SectionItemFieldTranslation
                {
                    Id = id++,
                    SectionItemFieldId = 11,
                    LanguageId = 1,
                    Label = "Özellik Açıklaması",
                    Description = "Özellik kartı açıklaması",
                    Placeholder = "Özellik açıklamasını girin",
                    CreatedAt = baseDate,
                    IsDeleted = false
                },
                new SectionItemFieldTranslation
                {
                    Id = id++,
                    SectionItemFieldId = 11,
                    LanguageId = 2,
                    Label = "Feature Description",
                    Description = "Feature card description",
                    Placeholder = "Enter feature description",
                    CreatedAt = baseDate,
                    IsDeleted = false
                }
            );
        }
    }
}
