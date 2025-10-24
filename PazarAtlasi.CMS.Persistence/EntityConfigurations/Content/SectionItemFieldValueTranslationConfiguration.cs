using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PazarAtlasi.CMS.Domain.Entities.Content;

namespace PazarAtlasi.CMS.Persistence.EntityConfigurations.Content
{
    public class SectionItemFieldValueTranslationConfiguration : IEntityTypeConfiguration<SectionItemFieldValueTranslation>
    {
        public void Configure(EntityTypeBuilder<SectionItemFieldValueTranslation> builder)
        {
            builder.ToTable("SectionItemFieldValueTranslations");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Value)
                .HasMaxLength(4000)
                .IsRequired();

            builder.Property(x => x.JsonValue)
                .HasColumnType("nvarchar(max)");

            // Relationships
            builder.HasOne(x => x.SectionItemFieldValue)
                .WithMany(x => x.Translations)
                .HasForeignKey(x => x.SectionItemFieldValueId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(x => x.Language)
                .WithMany()
                .HasForeignKey(x => x.LanguageId)
                .OnDelete(DeleteBehavior.Restrict);

            // Indexes
            builder.HasIndex(x => new { x.SectionItemFieldValueId, x.LanguageId })
                .IsUnique()
                .HasDatabaseName("IX_SectionItemFieldValueTranslations_ValueId_LanguageId");

            builder.HasIndex(x => x.LanguageId)
                .HasDatabaseName("IX_SectionItemFieldValueTranslations_LanguageId");

            // Base entity configuration
            builder.Property(x => x.CreatedAt)
                .IsRequired();

            builder.Property(x => x.UpdatedAt);

            builder.Property(x => x.IsDeleted)
                .HasDefaultValue(false);

            builder.HasQueryFilter(x => !x.IsDeleted);

            // Seed Data - Value Translations for Translatable Fields
            builder.HasData(
                // LOGO TEXT TRANSLATIONS (SectionItemFieldValue ID: 2)
                new SectionItemFieldValueTranslation
                {
                    Id = 1,
                    SectionItemFieldValueId = 2,
                    LanguageId = 1, // Turkish
                    Value = "PazarAtlası",
                    CreatedAt = new DateTime(2024, 10, 14, 10, 0, 0),
                    IsDeleted = false
                },
                new SectionItemFieldValueTranslation
                {
                    Id = 2,
                    SectionItemFieldValueId = 2,
                    LanguageId = 2, // English
                    Value = "MarketAtlas",
                    CreatedAt = new DateTime(2024, 10, 14, 10, 0, 0),
                    IsDeleted = false
                },

                // ANA SAYFA MENU TITLE TRANSLATIONS (SectionItemFieldValue ID: 3)
                new SectionItemFieldValueTranslation
                {
                    Id = 3,
                    SectionItemFieldValueId = 3,
                    LanguageId = 1, // Turkish
                    Value = "Ana Sayfa",
                    CreatedAt = new DateTime(2024, 10, 14, 10, 0, 0),
                    IsDeleted = false
                },
                new SectionItemFieldValueTranslation
                {
                    Id = 4,
                    SectionItemFieldValueId = 3,
                    LanguageId = 2, // English
                    Value = "Home",
                    CreatedAt = new DateTime(2024, 10, 14, 10, 0, 0),
                    IsDeleted = false
                },

                // ÜRÜNLER MENU TITLE TRANSLATIONS (SectionItemFieldValue ID: 6)
                new SectionItemFieldValueTranslation
                {
                    Id = 5,
                    SectionItemFieldValueId = 6,
                    LanguageId = 1, // Turkish
                    Value = "Ürünler",
                    CreatedAt = new DateTime(2024, 10, 14, 10, 0, 0),
                    IsDeleted = false
                },
                new SectionItemFieldValueTranslation
                {
                    Id = 6,
                    SectionItemFieldValueId = 6,
                    LanguageId = 2, // English
                    Value = "Products",
                    CreatedAt = new DateTime(2024, 10, 14, 10, 0, 0),
                    IsDeleted = false
                },

                // ÜRÜNLER MENU DESCRIPTION TRANSLATIONS (SectionItemFieldValue ID: 9)
                new SectionItemFieldValueTranslation
                {
                    Id = 7,
                    SectionItemFieldValueId = 9,
                    LanguageId = 1, // Turkish
                    Value = "Geniş ürün yelpazemizi keşfedin",
                    CreatedAt = new DateTime(2024, 10, 14, 10, 0, 0),
                    IsDeleted = false
                },
                new SectionItemFieldValueTranslation
                {
                    Id = 8,
                    SectionItemFieldValueId = 9,
                    LanguageId = 2, // English
                    Value = "Discover our wide range of products",
                    CreatedAt = new DateTime(2024, 10, 14, 10, 0, 0),
                    IsDeleted = false
                },

                // HİZMETLER MENU TITLE TRANSLATIONS (SectionItemFieldValue ID: 11)
                new SectionItemFieldValueTranslation
                {
                    Id = 9,
                    SectionItemFieldValueId = 11,
                    LanguageId = 1, // Turkish
                    Value = "Hizmetler",
                    CreatedAt = new DateTime(2024, 10, 14, 10, 0, 0),
                    IsDeleted = false
                },
                new SectionItemFieldValueTranslation
                {
                    Id = 10,
                    SectionItemFieldValueId = 11,
                    LanguageId = 2, // English
                    Value = "Services",
                    CreatedAt = new DateTime(2024, 10, 14, 10, 0, 0),
                    IsDeleted = false
                },

                // HİZMETLER MENU DESCRIPTION TRANSLATIONS (SectionItemFieldValue ID: 14)
                new SectionItemFieldValueTranslation
                {
                    Id = 11,
                    SectionItemFieldValueId = 14,
                    LanguageId = 1, // Turkish
                    Value = "Profesyonel hizmetlerimiz",
                    CreatedAt = new DateTime(2024, 10, 14, 10, 0, 0),
                    IsDeleted = false
                },
                new SectionItemFieldValueTranslation
                {
                    Id = 12,
                    SectionItemFieldValueId = 14,
                    LanguageId = 2, // English
                    Value = "Our professional services",
                    CreatedAt = new DateTime(2024, 10, 14, 10, 0, 0),
                    IsDeleted = false
                },

                // ELEKTRONİK CATEGORY TITLE TRANSLATIONS (SectionItemFieldValue ID: 15)
                new SectionItemFieldValueTranslation
                {
                    Id = 13,
                    SectionItemFieldValueId = 15,
                    LanguageId = 1, // Turkish
                    Value = "Elektronik",
                    CreatedAt = new DateTime(2024, 10, 14, 10, 0, 0),
                    IsDeleted = false
                },
                new SectionItemFieldValueTranslation
                {
                    Id = 14,
                    SectionItemFieldValueId = 15,
                    LanguageId = 2, // English
                    Value = "Electronics",
                    CreatedAt = new DateTime(2024, 10, 14, 10, 0, 0),
                    IsDeleted = false
                },

                // ELEKTRONİK CATEGORY DESCRIPTION TRANSLATIONS (SectionItemFieldValue ID: 18)
                new SectionItemFieldValueTranslation
                {
                    Id = 15,
                    SectionItemFieldValueId = 18,
                    LanguageId = 1, // Turkish
                    Value = "En son teknoloji ürünleri",
                    CreatedAt = new DateTime(2024, 10, 14, 10, 0, 0),
                    IsDeleted = false
                },
                new SectionItemFieldValueTranslation
                {
                    Id = 16,
                    SectionItemFieldValueId = 18,
                    LanguageId = 2, // English
                    Value = "Latest technology products",
                    CreatedAt = new DateTime(2024, 10, 14, 10, 0, 0),
                    IsDeleted = false
                },

                // ELEKTRONİK BADGE TEXT TRANSLATIONS (SectionItemFieldValue ID: 21)
                new SectionItemFieldValueTranslation
                {
                    Id = 17,
                    SectionItemFieldValueId = 21,
                    LanguageId = 1, // Turkish
                    Value = "YENİ",
                    CreatedAt = new DateTime(2024, 10, 14, 10, 0, 0),
                    IsDeleted = false
                },
                new SectionItemFieldValueTranslation
                {
                    Id = 18,
                    SectionItemFieldValueId = 21,
                    LanguageId = 2, // English
                    Value = "NEW",
                    CreatedAt = new DateTime(2024, 10, 14, 10, 0, 0),
                    IsDeleted = false
                },

                // BİLGİSAYARLAR SUBCATEGORY TITLE TRANSLATIONS (SectionItemFieldValue ID: 23)
                new SectionItemFieldValueTranslation
                {
                    Id = 19,
                    SectionItemFieldValueId = 23,
                    LanguageId = 1, // Turkish
                    Value = "Bilgisayarlar",
                    CreatedAt = new DateTime(2024, 10, 14, 10, 0, 0),
                    IsDeleted = false
                },
                new SectionItemFieldValueTranslation
                {
                    Id = 20,
                    SectionItemFieldValueId = 23,
                    LanguageId = 2, // English
                    Value = "Computers",
                    CreatedAt = new DateTime(2024, 10, 14, 10, 0, 0),
                    IsDeleted = false
                },

                // BİLGİSAYARLAR SUBCATEGORY DESCRIPTION TRANSLATIONS (SectionItemFieldValue ID: 26)
                new SectionItemFieldValueTranslation
                {
                    Id = 21,
                    SectionItemFieldValueId = 26,
                    LanguageId = 1, // Turkish
                    Value = "Masaüstü ve dizüstü bilgisayarlar",
                    CreatedAt = new DateTime(2024, 10, 14, 10, 0, 0),
                    IsDeleted = false
                },
                new SectionItemFieldValueTranslation
                {
                    Id = 22,
                    SectionItemFieldValueId = 26,
                    LanguageId = 2, // English
                    Value = "Desktop and laptop computers",
                    CreatedAt = new DateTime(2024, 10, 14, 10, 0, 0),
                    IsDeleted = false
                },

                // WEB TASARIM SERVICE TITLE TRANSLATIONS (SectionItemFieldValue ID: 27)
                new SectionItemFieldValueTranslation
                {
                    Id = 23,
                    SectionItemFieldValueId = 27,
                    LanguageId = 1, // Turkish
                    Value = "Web Tasarım",
                    CreatedAt = new DateTime(2024, 10, 14, 10, 0, 0),
                    IsDeleted = false
                },
                new SectionItemFieldValueTranslation
                {
                    Id = 24,
                    SectionItemFieldValueId = 27,
                    LanguageId = 2, // English
                    Value = "Web Design",
                    CreatedAt = new DateTime(2024, 10, 14, 10, 0, 0),
                    IsDeleted = false
                },

                // WEB TASARIM SERVICE DESCRIPTION TRANSLATIONS (SectionItemFieldValue ID: 30)
                new SectionItemFieldValueTranslation
                {
                    Id = 25,
                    SectionItemFieldValueId = 30,
                    LanguageId = 1, // Turkish
                    Value = "Modern ve kullanıcı dostu web siteleri",
                    CreatedAt = new DateTime(2024, 10, 14, 10, 0, 0),
                    IsDeleted = false
                },
                new SectionItemFieldValueTranslation
                {
                    Id = 26,
                    SectionItemFieldValueId = 30,
                    LanguageId = 2, // English
                    Value = "Modern and user-friendly websites",
                    CreatedAt = new DateTime(2024, 10, 14, 10, 0, 0),
                    IsDeleted = false
                },

                // ÖZEL KAMPANYA TITLE TRANSLATIONS (SectionItemFieldValue ID: 31)
                new SectionItemFieldValueTranslation
                {
                    Id = 27,
                    SectionItemFieldValueId = 31,
                    LanguageId = 1, // Turkish
                    Value = "Özel Kampanya",
                    CreatedAt = new DateTime(2024, 10, 14, 10, 0, 0),
                    IsDeleted = false
                },
                new SectionItemFieldValueTranslation
                {
                    Id = 28,
                    SectionItemFieldValueId = 31,
                    LanguageId = 2, // English
                    Value = "Special Campaign",
                    CreatedAt = new DateTime(2024, 10, 14, 10, 0, 0),
                    IsDeleted = false
                },

                // ÖZEL KAMPANYA DESCRIPTION TRANSLATIONS (SectionItemFieldValue ID: 34)
                new SectionItemFieldValueTranslation
                {
                    Id = 29,
                    SectionItemFieldValueId = 34,
                    LanguageId = 1, // Turkish
                    Value = "Sınırlı süre özel fırsatlar",
                    CreatedAt = new DateTime(2024, 10, 14, 10, 0, 0),
                    IsDeleted = false
                },
                new SectionItemFieldValueTranslation
                {
                    Id = 30,
                    SectionItemFieldValueId = 34,
                    LanguageId = 2, // English
                    Value = "Limited time special offers",
                    CreatedAt = new DateTime(2024, 10, 14, 10, 0, 0),
                    IsDeleted = false
                },

                // ÖZEL KAMPANYA BADGE TEXT TRANSLATIONS (SectionItemFieldValue ID: 37)
                new SectionItemFieldValueTranslation
                {
                    Id = 31,
                    SectionItemFieldValueId = 37,
                    LanguageId = 1, // Turkish
                    Value = "SICAK",
                    CreatedAt = new DateTime(2024, 10, 14, 10, 0, 0),
                    IsDeleted = false
                },
                new SectionItemFieldValueTranslation
                {
                    Id = 32,
                    SectionItemFieldValueId = 37,
                    LanguageId = 2, // English
                    Value = "HOT",
                    CreatedAt = new DateTime(2024, 10, 14, 10, 0, 0),
                    IsDeleted = false
                },

                // ANA SAYFA NESTED MENU TRANSLATIONS
                // YENİ ÜRÜNLER TITLE TRANSLATIONS (SectionItemFieldValue ID: 39)
                new SectionItemFieldValueTranslation
                {
                    Id = 33,
                    SectionItemFieldValueId = 39,
                    LanguageId = 1, // Turkish
                    Value = "Yeni Ürünler",
                    CreatedAt = new DateTime(2024, 10, 14, 10, 0, 0),
                    IsDeleted = false
                },
                new SectionItemFieldValueTranslation
                {
                    Id = 34,
                    SectionItemFieldValueId = 39,
                    LanguageId = 2, // English
                    Value = "New Products",
                    CreatedAt = new DateTime(2024, 10, 14, 10, 0, 0),
                    IsDeleted = false
                },

                // YENİ ÜRÜNLER DESCRIPTION TRANSLATIONS (SectionItemFieldValue ID: 42)
                new SectionItemFieldValueTranslation
                {
                    Id = 35,
                    SectionItemFieldValueId = 42,
                    LanguageId = 1, // Turkish
                    Value = "En yeni ürün koleksiyonları",
                    CreatedAt = new DateTime(2024, 10, 14, 10, 0, 0),
                    IsDeleted = false
                },
                new SectionItemFieldValueTranslation
                {
                    Id = 36,
                    SectionItemFieldValueId = 42,
                    LanguageId = 2, // English
                    Value = "Latest product collections",
                    CreatedAt = new DateTime(2024, 10, 14, 10, 0, 0),
                    IsDeleted = false
                },

                // YENİ ÜRÜNLER BADGE TRANSLATIONS (SectionItemFieldValue ID: 43)
                new SectionItemFieldValueTranslation
                {
                    Id = 37,
                    SectionItemFieldValueId = 43,
                    LanguageId = 1, // Turkish
                    Value = "YENİ",
                    CreatedAt = new DateTime(2024, 10, 14, 10, 0, 0),
                    IsDeleted = false
                },
                new SectionItemFieldValueTranslation
                {
                    Id = 38,
                    SectionItemFieldValueId = 43,
                    LanguageId = 2, // English
                    Value = "NEW",
                    CreatedAt = new DateTime(2024, 10, 14, 10, 0, 0),
                    IsDeleted = false
                },

                // POPÜLER KATEGORİLER TITLE TRANSLATIONS (SectionItemFieldValue ID: 45)
                new SectionItemFieldValueTranslation
                {
                    Id = 39,
                    SectionItemFieldValueId = 45,
                    LanguageId = 1, // Turkish
                    Value = "Popüler Kategoriler",
                    CreatedAt = new DateTime(2024, 10, 14, 10, 0, 0),
                    IsDeleted = false
                },
                new SectionItemFieldValueTranslation
                {
                    Id = 40,
                    SectionItemFieldValueId = 45,
                    LanguageId = 2, // English
                    Value = "Popular Categories",
                    CreatedAt = new DateTime(2024, 10, 14, 10, 0, 0),
                    IsDeleted = false
                },

                // POPÜLER KATEGORİLER DESCRIPTION TRANSLATIONS (SectionItemFieldValue ID: 48)
                new SectionItemFieldValueTranslation
                {
                    Id = 41,
                    SectionItemFieldValueId = 48,
                    LanguageId = 1, // Turkish
                    Value = "En popüler ürün kategorileri",
                    CreatedAt = new DateTime(2024, 10, 14, 10, 0, 0),
                    IsDeleted = false
                },
                new SectionItemFieldValueTranslation
                {
                    Id = 42,
                    SectionItemFieldValueId = 48,
                    LanguageId = 2, // English
                    Value = "Most popular product categories",
                    CreatedAt = new DateTime(2024, 10, 14, 10, 0, 0),
                    IsDeleted = false
                },

                // KAMPANYALAR TITLE TRANSLATIONS (SectionItemFieldValue ID: 49)
                new SectionItemFieldValueTranslation
                {
                    Id = 43,
                    SectionItemFieldValueId = 49,
                    LanguageId = 1, // Turkish
                    Value = "Kampanyalar",
                    CreatedAt = new DateTime(2024, 10, 14, 10, 0, 0),
                    IsDeleted = false
                },
                new SectionItemFieldValueTranslation
                {
                    Id = 44,
                    SectionItemFieldValueId = 49,
                    LanguageId = 2, // English
                    Value = "Campaigns",
                    CreatedAt = new DateTime(2024, 10, 14, 10, 0, 0),
                    IsDeleted = false
                },

                // KAMPANYALAR DESCRIPTION TRANSLATIONS (SectionItemFieldValue ID: 52)
                new SectionItemFieldValueTranslation
                {
                    Id = 45,
                    SectionItemFieldValueId = 52,
                    LanguageId = 1, // Turkish
                    Value = "Güncel kampanya ve fırsatlar",
                    CreatedAt = new DateTime(2024, 10, 14, 10, 0, 0),
                    IsDeleted = false
                },
                new SectionItemFieldValueTranslation
                {
                    Id = 46,
                    SectionItemFieldValueId = 52,
                    LanguageId = 2, // English
                    Value = "Current campaigns and opportunities",
                    CreatedAt = new DateTime(2024, 10, 14, 10, 0, 0),
                    IsDeleted = false
                },

                // EN ÇOK SATAN TITLE TRANSLATIONS (SectionItemFieldValue ID: 53)
                new SectionItemFieldValueTranslation
                {
                    Id = 47,
                    SectionItemFieldValueId = 53,
                    LanguageId = 1, // Turkish
                    Value = "En Çok Satan",
                    CreatedAt = new DateTime(2024, 10, 14, 10, 0, 0),
                    IsDeleted = false
                },
                new SectionItemFieldValueTranslation
                {
                    Id = 48,
                    SectionItemFieldValueId = 53,
                    LanguageId = 2, // English
                    Value = "Best Sellers",
                    CreatedAt = new DateTime(2024, 10, 14, 10, 0, 0),
                    IsDeleted = false
                },

                // FLASH SALE TITLE TRANSLATIONS (SectionItemFieldValue ID: 56)
                new SectionItemFieldValueTranslation
                {
                    Id = 49,
                    SectionItemFieldValueId = 56,
                    LanguageId = 1, // Turkish
                    Value = "Flash Sale",
                    CreatedAt = new DateTime(2024, 10, 14, 10, 0, 0),
                    IsDeleted = false
                },
                new SectionItemFieldValueTranslation
                {
                    Id = 50,
                    SectionItemFieldValueId = 56,
                    LanguageId = 2, // English
                    Value = "Flash Sale",
                    CreatedAt = new DateTime(2024, 10, 14, 10, 0, 0),
                    IsDeleted = false
                },

                // FLASH SALE DESCRIPTION TRANSLATIONS (SectionItemFieldValue ID: 59)
                new SectionItemFieldValueTranslation
                {
                    Id = 51,
                    SectionItemFieldValueId = 59,
                    LanguageId = 1, // Turkish
                    Value = "Sınırlı süre büyük indirimler",
                    CreatedAt = new DateTime(2024, 10, 14, 10, 0, 0),
                    IsDeleted = false
                },
                new SectionItemFieldValueTranslation
                {
                    Id = 52,
                    SectionItemFieldValueId = 59,
                    LanguageId = 2, // English
                    Value = "Limited time huge discounts",
                    CreatedAt = new DateTime(2024, 10, 14, 10, 0, 0),
                    IsDeleted = false
                },

                // FLASH SALE BADGE TRANSLATIONS (SectionItemFieldValue ID: 60)
                new SectionItemFieldValueTranslation
                {
                    Id = 53,
                    SectionItemFieldValueId = 60,
                    LanguageId = 1, // Turkish
                    Value = "FLASH",
                    CreatedAt = new DateTime(2024, 10, 14, 10, 0, 0),
                    IsDeleted = false
                },
                new SectionItemFieldValueTranslation
                {
                    Id = 54,
                    SectionItemFieldValueId = 60,
                    LanguageId = 2, // English
                    Value = "FLASH",
                    CreatedAt = new DateTime(2024, 10, 14, 10, 0, 0),
                    IsDeleted = false
                }
            );
        }
    }
}