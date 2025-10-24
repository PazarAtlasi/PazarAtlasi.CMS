using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PazarAtlasi.CMS.Domain.Entities.Content;

namespace PazarAtlasi.CMS.Persistence.EntityConfigurations.Content
{
    public class SectionItemFieldValueConfiguration : IEntityTypeConfiguration<SectionItemFieldValue>
    {
        public void Configure(EntityTypeBuilder<SectionItemFieldValue> builder)
        {
            builder.ToTable("SectionItemFieldValues");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Value)
                .HasMaxLength(4000)
                .IsRequired();

            builder.Property(x => x.JsonValue)
                .HasColumnType("nvarchar(max)");

            // Relationships
            builder.HasOne(x => x.SectionItem)
                .WithMany(x => x.FieldValues)
                .HasForeignKey(x => x.SectionItemId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(x => x.SectionItemField)
                .WithMany(x => x.Values)
                .HasForeignKey(x => x.SectionItemFieldId)
                .OnDelete(DeleteBehavior.Cascade);

            // Indexes
            builder.HasIndex(x => new { x.SectionItemId, x.SectionItemFieldId })
                .IsUnique()
                .HasDatabaseName("IX_SectionItemFieldValues_SectionItemId_FieldId");

            builder.HasIndex(x => x.SectionItemFieldId)
                .HasDatabaseName("IX_SectionItemFieldValues_FieldId");

            // Base entity configuration
            builder.Property(x => x.CreatedAt)
                .IsRequired();

            builder.Property(x => x.UpdatedAt);

            builder.Property(x => x.IsDeleted)
                .HasDefaultValue(false);

            builder.HasQueryFilter(x => !x.IsDeleted);

            // Seed Data - Field Values for Navbar Items
            builder.HasData(
                // LOGO SECTION VALUES (SectionItem ID: 1)
                new SectionItemFieldValue
                {
                    Id = 1,
                    SectionItemId = 1,
                    SectionItemFieldId = 1, // logo_image
                    Value = "/images/logo.png",
                    CreatedAt = new DateTime(2024, 10, 14, 10, 0, 0),
                    IsDeleted = false
                },
                new SectionItemFieldValue
                {
                    Id = 2,
                    SectionItemId = 1,
                    SectionItemFieldId = 2, // logo_text
                    Value = "PazarAtlası",
                    CreatedAt = new DateTime(2024, 10, 14, 10, 0, 0),
                    IsDeleted = false
                },

                // ANA SAYFA VALUES (SectionItem ID: 2)
                new SectionItemFieldValue
                {
                    Id = 3,
                    SectionItemId = 2,
                    SectionItemFieldId = 3, // menu_title
                    Value = "Ana Sayfa",
                    CreatedAt = new DateTime(2024, 10, 14, 10, 0, 0),
                    IsDeleted = false
                },
                new SectionItemFieldValue
                {
                    Id = 4,
                    SectionItemId = 2,
                    SectionItemFieldId = 4, // menu_url
                    Value = "/",
                    CreatedAt = new DateTime(2024, 10, 14, 10, 0, 0),
                    IsDeleted = false
                },
                new SectionItemFieldValue
                {
                    Id = 5,
                    SectionItemId = 2,
                    SectionItemFieldId = 5, // menu_icon
                    Value = "fas fa-home",
                    CreatedAt = new DateTime(2024, 10, 14, 10, 0, 0),
                    IsDeleted = false
                },

                // ÜRÜNLER VALUES (SectionItem ID: 3)
                new SectionItemFieldValue
                {
                    Id = 6,
                    SectionItemId = 3,
                    SectionItemFieldId = 3, // menu_title
                    Value = "Ürünler",
                    CreatedAt = new DateTime(2024, 10, 14, 10, 0, 0),
                    IsDeleted = false
                },
                new SectionItemFieldValue
                {
                    Id = 7,
                    SectionItemId = 3,
                    SectionItemFieldId = 4, // menu_url
                    Value = "/products",
                    CreatedAt = new DateTime(2024, 10, 14, 10, 0, 0),
                    IsDeleted = false
                },
                new SectionItemFieldValue
                {
                    Id = 8,
                    SectionItemId = 3,
                    SectionItemFieldId = 5, // menu_icon
                    Value = "fas fa-shopping-bag",
                    CreatedAt = new DateTime(2024, 10, 14, 10, 0, 0),
                    IsDeleted = false
                },
                new SectionItemFieldValue
                {
                    Id = 9,
                    SectionItemId = 3,
                    SectionItemFieldId = 6, // menu_description
                    Value = "Geniş ürün yelpazemizi keşfedin",
                    CreatedAt = new DateTime(2024, 10, 14, 10, 0, 0),
                    IsDeleted = false
                },
                new SectionItemFieldValue
                {
                    Id = 10,
                    SectionItemId = 3,
                    SectionItemFieldId = 7, // featured_image
                    Value = "/images/products-featured.jpg",
                    CreatedAt = new DateTime(2024, 10, 14, 10, 0, 0),
                    IsDeleted = false
                },

                // HİZMETLER VALUES (SectionItem ID: 4)
                new SectionItemFieldValue
                {
                    Id = 11,
                    SectionItemId = 4,
                    SectionItemFieldId = 3, // menu_title
                    Value = "Hizmetler",
                    CreatedAt = new DateTime(2024, 10, 14, 10, 0, 0),
                    IsDeleted = false
                },
                new SectionItemFieldValue
                {
                    Id = 12,
                    SectionItemId = 4,
                    SectionItemFieldId = 4, // menu_url
                    Value = "/services",
                    CreatedAt = new DateTime(2024, 10, 14, 10, 0, 0),
                    IsDeleted = false
                },
                new SectionItemFieldValue
                {
                    Id = 13,
                    SectionItemId = 4,
                    SectionItemFieldId = 5, // menu_icon
                    Value = "fas fa-cogs",
                    CreatedAt = new DateTime(2024, 10, 14, 10, 0, 0),
                    IsDeleted = false
                },
                new SectionItemFieldValue
                {
                    Id = 14,
                    SectionItemId = 4,
                    SectionItemFieldId = 6, // menu_description
                    Value = "Profesyonel hizmetlerimiz",
                    CreatedAt = new DateTime(2024, 10, 14, 10, 0, 0),
                    IsDeleted = false
                },

                // ELEKTRONİK CATEGORY VALUES (SectionItem ID: 7)
                new SectionItemFieldValue
                {
                    Id = 15,
                    SectionItemId = 7,
                    SectionItemFieldId = 3, // menu_title
                    Value = "Elektronik",
                    CreatedAt = new DateTime(2024, 10, 14, 10, 0, 0),
                    IsDeleted = false
                },
                new SectionItemFieldValue
                {
                    Id = 16,
                    SectionItemId = 7,
                    SectionItemFieldId = 4, // menu_url
                    Value = "/products/electronics",
                    CreatedAt = new DateTime(2024, 10, 14, 10, 0, 0),
                    IsDeleted = false
                },
                new SectionItemFieldValue
                {
                    Id = 17,
                    SectionItemId = 7,
                    SectionItemFieldId = 5, // menu_icon
                    Value = "fas fa-laptop",
                    CreatedAt = new DateTime(2024, 10, 14, 10, 0, 0),
                    IsDeleted = false
                },
                new SectionItemFieldValue
                {
                    Id = 18,
                    SectionItemId = 7,
                    SectionItemFieldId = 6, // menu_description
                    Value = "En son teknoloji ürünleri",
                    CreatedAt = new DateTime(2024, 10, 14, 10, 0, 0),
                    IsDeleted = false
                },
                new SectionItemFieldValue
                {
                    Id = 19,
                    SectionItemId = 7,
                    SectionItemFieldId = 7, // featured_image
                    Value = "/images/electronics-category.jpg",
                    CreatedAt = new DateTime(2024, 10, 14, 10, 0, 0),
                    IsDeleted = false
                },
                new SectionItemFieldValue
                {
                    Id = 20,
                    SectionItemId = 7,
                    SectionItemFieldId = 8, // is_featured
                    Value = "true",
                    CreatedAt = new DateTime(2024, 10, 14, 10, 0, 0),
                    IsDeleted = false
                },
                new SectionItemFieldValue
                {
                    Id = 21,
                    SectionItemId = 7,
                    SectionItemFieldId = 9, // badge_text
                    Value = "YENİ",
                    CreatedAt = new DateTime(2024, 10, 14, 10, 0, 0),
                    IsDeleted = false
                },
                new SectionItemFieldValue
                {
                    Id = 22,
                    SectionItemId = 7,
                    SectionItemFieldId = 10, // badge_color
                    Value = "success",
                    CreatedAt = new DateTime(2024, 10, 14, 10, 0, 0),
                    IsDeleted = false
                },

                // BİLGİSAYARLAR SUBCATEGORY VALUES (SectionItem ID: 10)
                new SectionItemFieldValue
                {
                    Id = 23,
                    SectionItemId = 10,
                    SectionItemFieldId = 3, // menu_title
                    Value = "Bilgisayarlar",
                    CreatedAt = new DateTime(2024, 10, 14, 10, 0, 0),
                    IsDeleted = false
                },
                new SectionItemFieldValue
                {
                    Id = 24,
                    SectionItemId = 10,
                    SectionItemFieldId = 4, // menu_url
                    Value = "/products/electronics/computers",
                    CreatedAt = new DateTime(2024, 10, 14, 10, 0, 0),
                    IsDeleted = false
                },
                new SectionItemFieldValue
                {
                    Id = 25,
                    SectionItemId = 10,
                    SectionItemFieldId = 5, // menu_icon
                    Value = "fas fa-desktop",
                    CreatedAt = new DateTime(2024, 10, 14, 10, 0, 0),
                    IsDeleted = false
                },
                new SectionItemFieldValue
                {
                    Id = 26,
                    SectionItemId = 10,
                    SectionItemFieldId = 6, // menu_description
                    Value = "Masaüstü ve dizüstü bilgisayarlar",
                    CreatedAt = new DateTime(2024, 10, 14, 10, 0, 0),
                    IsDeleted = false
                },

                // WEB TASARIM SERVICE VALUES (SectionItem ID: 16)
                new SectionItemFieldValue
                {
                    Id = 27,
                    SectionItemId = 16,
                    SectionItemFieldId = 3, // menu_title
                    Value = "Web Tasarım",
                    CreatedAt = new DateTime(2024, 10, 14, 10, 0, 0),
                    IsDeleted = false
                },
                new SectionItemFieldValue
                {
                    Id = 28,
                    SectionItemId = 16,
                    SectionItemFieldId = 4, // menu_url
                    Value = "/services/web-design",
                    CreatedAt = new DateTime(2024, 10, 14, 10, 0, 0),
                    IsDeleted = false
                },
                new SectionItemFieldValue
                {
                    Id = 29,
                    SectionItemId = 16,
                    SectionItemFieldId = 5, // menu_icon
                    Value = "fas fa-paint-brush",
                    CreatedAt = new DateTime(2024, 10, 14, 10, 0, 0),
                    IsDeleted = false
                },
                new SectionItemFieldValue
                {
                    Id = 30,
                    SectionItemId = 16,
                    SectionItemFieldId = 6, // menu_description
                    Value = "Modern ve kullanıcı dostu web siteleri",
                    CreatedAt = new DateTime(2024, 10, 14, 10, 0, 0),
                    IsDeleted = false
                },

                // ÖZEL KAMPANYA FEATURED VALUES (SectionItem ID: 20)
                new SectionItemFieldValue
                {
                    Id = 31,
                    SectionItemId = 20,
                    SectionItemFieldId = 3, // menu_title
                    Value = "Özel Kampanya",
                    CreatedAt = new DateTime(2024, 10, 14, 10, 0, 0),
                    IsDeleted = false
                },
                new SectionItemFieldValue
                {
                    Id = 32,
                    SectionItemId = 20,
                    SectionItemFieldId = 4, // menu_url
                    Value = "/special-offers",
                    CreatedAt = new DateTime(2024, 10, 14, 10, 0, 0),
                    IsDeleted = false
                },
                new SectionItemFieldValue
                {
                    Id = 33,
                    SectionItemId = 20,
                    SectionItemFieldId = 5, // menu_icon
                    Value = "fas fa-fire",
                    CreatedAt = new DateTime(2024, 10, 14, 10, 0, 0),
                    IsDeleted = false
                },
                new SectionItemFieldValue
                {
                    Id = 34,
                    SectionItemId = 20,
                    SectionItemFieldId = 6, // menu_description
                    Value = "Sınırlı süre özel fırsatlar",
                    CreatedAt = new DateTime(2024, 10, 14, 10, 0, 0),
                    IsDeleted = false
                },
                new SectionItemFieldValue
                {
                    Id = 35,
                    SectionItemId = 20,
                    SectionItemFieldId = 7, // featured_image
                    Value = "/images/special-offers-banner.jpg",
                    CreatedAt = new DateTime(2024, 10, 14, 10, 0, 0),
                    IsDeleted = false
                },
                new SectionItemFieldValue
                {
                    Id = 36,
                    SectionItemId = 20,
                    SectionItemFieldId = 8, // is_featured
                    Value = "true",
                    CreatedAt = new DateTime(2024, 10, 14, 10, 0, 0),
                    IsDeleted = false
                },
                new SectionItemFieldValue
                {
                    Id = 37,
                    SectionItemId = 20,
                    SectionItemFieldId = 9, // badge_text
                    Value = "SICAK",
                    CreatedAt = new DateTime(2024, 10, 14, 10, 0, 0),
                    IsDeleted = false
                },
                new SectionItemFieldValue
                {
                    Id = 38,
                    SectionItemId = 20,
                    SectionItemFieldId = 10, // badge_color
                    Value = "danger",
                    CreatedAt = new DateTime(2024, 10, 14, 10, 0, 0),
                    IsDeleted = false
                },

                // ANA SAYFA NESTED MENU VALUES
                // YENİ ÜRÜNLER (SectionItem ID: 21)
                new SectionItemFieldValue
                {
                    Id = 39,
                    SectionItemId = 21,
                    SectionItemFieldId = 3, // menu_title
                    Value = "Yeni Ürünler",
                    CreatedAt = new DateTime(2024, 10, 14, 10, 0, 0),
                    IsDeleted = false
                },
                new SectionItemFieldValue
                {
                    Id = 40,
                    SectionItemId = 21,
                    SectionItemFieldId = 4, // menu_url
                    Value = "/products/new",
                    CreatedAt = new DateTime(2024, 10, 14, 10, 0, 0),
                    IsDeleted = false
                },
                new SectionItemFieldValue
                {
                    Id = 41,
                    SectionItemId = 21,
                    SectionItemFieldId = 5, // menu_icon
                    Value = "fas fa-star",
                    CreatedAt = new DateTime(2024, 10, 14, 10, 0, 0),
                    IsDeleted = false
                },
                new SectionItemFieldValue
                {
                    Id = 42,
                    SectionItemId = 21,
                    SectionItemFieldId = 6, // menu_description
                    Value = "En yeni ürün koleksiyonları",
                    CreatedAt = new DateTime(2024, 10, 14, 10, 0, 0),
                    IsDeleted = false
                },
                new SectionItemFieldValue
                {
                    Id = 43,
                    SectionItemId = 21,
                    SectionItemFieldId = 9, // badge_text
                    Value = "YENİ",
                    CreatedAt = new DateTime(2024, 10, 14, 10, 0, 0),
                    IsDeleted = false
                },
                new SectionItemFieldValue
                {
                    Id = 44,
                    SectionItemId = 21,
                    SectionItemFieldId = 10, // badge_color
                    Value = "primary",
                    CreatedAt = new DateTime(2024, 10, 14, 10, 0, 0),
                    IsDeleted = false
                },

                // POPÜLER KATEGORİLER (SectionItem ID: 22)
                new SectionItemFieldValue
                {
                    Id = 45,
                    SectionItemId = 22,
                    SectionItemFieldId = 3, // menu_title
                    Value = "Popüler Kategoriler",
                    CreatedAt = new DateTime(2024, 10, 14, 10, 0, 0),
                    IsDeleted = false
                },
                new SectionItemFieldValue
                {
                    Id = 46,
                    SectionItemId = 22,
                    SectionItemFieldId = 4, // menu_url
                    Value = "/categories/popular",
                    CreatedAt = new DateTime(2024, 10, 14, 10, 0, 0),
                    IsDeleted = false
                },
                new SectionItemFieldValue
                {
                    Id = 47,
                    SectionItemId = 22,
                    SectionItemFieldId = 5, // menu_icon
                    Value = "fas fa-fire",
                    CreatedAt = new DateTime(2024, 10, 14, 10, 0, 0),
                    IsDeleted = false
                },
                new SectionItemFieldValue
                {
                    Id = 48,
                    SectionItemId = 22,
                    SectionItemFieldId = 6, // menu_description
                    Value = "En popüler ürün kategorileri",
                    CreatedAt = new DateTime(2024, 10, 14, 10, 0, 0),
                    IsDeleted = false
                },

                // KAMPANYALAR (SectionItem ID: 23)
                new SectionItemFieldValue
                {
                    Id = 49,
                    SectionItemId = 23,
                    SectionItemFieldId = 3, // menu_title
                    Value = "Kampanyalar",
                    CreatedAt = new DateTime(2024, 10, 14, 10, 0, 0),
                    IsDeleted = false
                },
                new SectionItemFieldValue
                {
                    Id = 50,
                    SectionItemId = 23,
                    SectionItemFieldId = 4, // menu_url
                    Value = "/campaigns",
                    CreatedAt = new DateTime(2024, 10, 14, 10, 0, 0),
                    IsDeleted = false
                },
                new SectionItemFieldValue
                {
                    Id = 51,
                    SectionItemId = 23,
                    SectionItemFieldId = 5, // menu_icon
                    Value = "fas fa-percentage",
                    CreatedAt = new DateTime(2024, 10, 14, 10, 0, 0),
                    IsDeleted = false
                },
                new SectionItemFieldValue
                {
                    Id = 52,
                    SectionItemId = 23,
                    SectionItemFieldId = 6, // menu_description
                    Value = "Güncel kampanya ve fırsatlar",
                    CreatedAt = new DateTime(2024, 10, 14, 10, 0, 0),
                    IsDeleted = false
                },

                // EN ÇOK SATAN (SectionItem ID: 25)
                new SectionItemFieldValue
                {
                    Id = 53,
                    SectionItemId = 25,
                    SectionItemFieldId = 3, // menu_title
                    Value = "En Çok Satan",
                    CreatedAt = new DateTime(2024, 10, 14, 10, 0, 0),
                    IsDeleted = false
                },
                new SectionItemFieldValue
                {
                    Id = 54,
                    SectionItemId = 25,
                    SectionItemFieldId = 4, // menu_url
                    Value = "/products/bestsellers",
                    CreatedAt = new DateTime(2024, 10, 14, 10, 0, 0),
                    IsDeleted = false
                },
                new SectionItemFieldValue
                {
                    Id = 55,
                    SectionItemId = 25,
                    SectionItemFieldId = 5, // menu_icon
                    Value = "fas fa-trophy",
                    CreatedAt = new DateTime(2024, 10, 14, 10, 0, 0),
                    IsDeleted = false
                },

                // FLASH SALE (SectionItem ID: 28)
                new SectionItemFieldValue
                {
                    Id = 56,
                    SectionItemId = 28,
                    SectionItemFieldId = 3, // menu_title
                    Value = "Flash Sale",
                    CreatedAt = new DateTime(2024, 10, 14, 10, 0, 0),
                    IsDeleted = false
                },
                new SectionItemFieldValue
                {
                    Id = 57,
                    SectionItemId = 28,
                    SectionItemFieldId = 4, // menu_url
                    Value = "/flash-sale",
                    CreatedAt = new DateTime(2024, 10, 14, 10, 0, 0),
                    IsDeleted = false
                },
                new SectionItemFieldValue
                {
                    Id = 58,
                    SectionItemId = 28,
                    SectionItemFieldId = 5, // menu_icon
                    Value = "fas fa-bolt",
                    CreatedAt = new DateTime(2024, 10, 14, 10, 0, 0),
                    IsDeleted = false
                },
                new SectionItemFieldValue
                {
                    Id = 59,
                    SectionItemId = 28,
                    SectionItemFieldId = 6, // menu_description
                    Value = "Sınırlı süre büyük indirimler",
                    CreatedAt = new DateTime(2024, 10, 14, 10, 0, 0),
                    IsDeleted = false
                },
                new SectionItemFieldValue
                {
                    Id = 60,
                    SectionItemId = 28,
                    SectionItemFieldId = 9, // badge_text
                    Value = "FLASH",
                    CreatedAt = new DateTime(2024, 10, 14, 10, 0, 0),
                    IsDeleted = false
                },
                new SectionItemFieldValue
                {
                    Id = 61,
                    SectionItemId = 28,
                    SectionItemFieldId = 10, // badge_color
                    Value = "warning",
                    CreatedAt = new DateTime(2024, 10, 14, 10, 0, 0),
                    IsDeleted = false
                }
            );
        }
    }
}