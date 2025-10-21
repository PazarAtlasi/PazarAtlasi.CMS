using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PazarAtlasi.CMS.Domain.Entities.Content;
using PazarAtlasi.CMS.Domain.Common;

namespace PazarAtlasi.CMS.Persistence.EntityConfigurations.Content
{
    public class SectionItemFieldSettingTranslationConfiguration : IEntityTypeConfiguration<SectionItemFieldSettingTranslation>
    {
        public void Configure(EntityTypeBuilder<SectionItemFieldSettingTranslation> builder)
        {
            builder.ToTable("SectionItemFieldSettingTranslations");
            builder.HasKey(sifst => sifst.Id);

            builder.Property(sifst => sifst.Id)
                .HasColumnName("Id")
                .IsRequired();

            builder.Property(sifst => sifst.SectionItemFieldSettingId)
                .HasColumnName("SectionItemFieldSettingId")
                .IsRequired();

            builder.Property(sifst => sifst.LanguageId)
                .HasColumnName("LanguageId")
                .IsRequired();

            builder.Property(sifst => sifst.Label)
                .HasColumnName("Label")
                .HasMaxLength(200)
                .IsRequired();

            builder.Property(sifst => sifst.Description)
                .HasColumnName("Description")
                .HasMaxLength(1000);

            builder.Property(sifst => sifst.CreatedAt)
                .HasColumnName("CreatedAt")
                .IsRequired();

            builder.Property(sifst => sifst.UpdatedAt)
                .HasColumnName("UpdatedAt");

            builder.Property(sifst => sifst.IsDeleted)
                .HasColumnName("IsDeleted")
                .HasDefaultValue(false);

            builder.Property(sifst => sifst.Status)
                .HasColumnName("Status")
                .HasDefaultValue(Status.Active);

            builder.Property(sifst => sifst.CreatedBy)
                .HasColumnName("CreatedBy");

            builder.Property(sifst => sifst.UpdatedBy)
                .HasColumnName("UpdatedBy");

            // Relationships
            builder.HasOne(sifst => sifst.SectionItemFieldSetting)
                .WithMany(sifs => sifs.Translations)
                .HasForeignKey(sifst => sifst.SectionItemFieldSettingId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(sifst => sifst.Language)
                .WithMany()
                .HasForeignKey(sifst => sifst.LanguageId)
                .OnDelete(DeleteBehavior.Restrict);

            // Indexes
            builder.HasIndex(sifst => new { sifst.SectionItemFieldSettingId, sifst.LanguageId })
                .HasDatabaseName("IX_SectionItemFieldSettingTranslations_FieldSettingId_LanguageId")
                .IsUnique();

            // Query Filter
            builder.HasQueryFilter(sifst => !sifst.IsDeleted);

            // Seed Data - Field Translations for All Templates
            SeedNavbarSimpleFieldTranslations(builder);
            SeedNavbarMegaMenuFieldTranslations(builder);
            SeedNavbarServiceTabsFieldTranslations(builder);
            SeedNavbarCategorizedFieldTranslations(builder);
            SeedCarouselFieldTranslations(builder);
            SeedDefaultFieldTranslations(builder);
            SeedSequentialFieldTranslations(builder);
            SeedGridFieldTranslations(builder);
            SeedMasonryFieldTranslations(builder);
            SeedListFieldTranslations(builder);
            SeedSingleItemFieldTranslations(builder);
            SeedMultiItemFieldTranslations(builder);
            SeedAccordionFieldTranslations(builder);
            SeedTabsFieldTranslations(builder);
        }

        private void SeedNavbarSimpleFieldTranslations(EntityTypeBuilder<SectionItemFieldSettingTranslation> builder)
        {
            int translationId = 1;

            // Logo Fields Translations
            // Field 1: image
            builder.HasData(
                new SectionItemFieldSettingTranslation
                {
                    Id = translationId++,
                    SectionItemFieldSettingId = 1,
                    LanguageId = 1, // Türkçe
                    Label = "Logo Resmi",
                    Description = "Logo resminizi yükleyin",
                    CreatedAt = new DateTime(2024, 10, 21, 10, 0, 0),
                    Status = Status.Active,
                    IsDeleted = false
                },
                new SectionItemFieldSettingTranslation
                {
                    Id = translationId++,
                    SectionItemFieldSettingId = 1,
                    LanguageId = 2, // English
                    Label = "Logo Image",
                    Description = "Upload your logo image",
                    CreatedAt = new DateTime(2024, 10, 21, 10, 0, 0),
                    Status = Status.Active,
                    IsDeleted = false
                }
            );

            // Field 2: altText
            builder.HasData(
                new SectionItemFieldSettingTranslation
                {
                    Id = translationId++,
                    SectionItemFieldSettingId = 2,
                    LanguageId = 2, // English
                    Label = "Alt Text",
                    Description = "Alternative text for accessibility",
                    CreatedAt = new DateTime(2024, 10, 21, 10, 0, 0),
                    Status = Status.Active,
                    IsDeleted = false
                },
                new SectionItemFieldSettingTranslation
                {
                    Id = translationId++,
                    SectionItemFieldSettingId = 2,
                    LanguageId = 1, // Türkçe
                    Label = "Alternatif Metin",
                    Description = "Erişilebilirlik için alternatif metin",
                    CreatedAt = new DateTime(2024, 10, 21, 10, 0, 0),
                    Status = Status.Active,
                    IsDeleted = false
                }
            );

            // Field 3: url
            builder.HasData(
                new SectionItemFieldSettingTranslation
                {
                    Id = translationId++,
                    SectionItemFieldSettingId = 3,
                    LanguageId = 2, // English
                    Label = "Link URL",
                    Description = "Where logo should link to",
                    CreatedAt = new DateTime(2024, 10, 21, 10, 0, 0),
                    Status = Status.Active,
                    IsDeleted = false
                },
                new SectionItemFieldSettingTranslation
                {
                    Id = translationId++,
                    SectionItemFieldSettingId = 3,
                    LanguageId = 1, // Türkçe
                    Label = "Bağlantı URL",
                    Description = "Logonun yönlendireceği adres",
                    CreatedAt = new DateTime(2024, 10, 21, 10, 0, 0),
                    Status = Status.Active,
                    IsDeleted = false
                }
            );

            // Menu Fields Translations
            // Field 4: title
            builder.HasData(
                new SectionItemFieldSettingTranslation
                {
                    Id = translationId++,
                    SectionItemFieldSettingId = 4,
                    LanguageId = 2, // English
                    Label = "Menu Title",
                    Description = "Title of the menu item",
                    CreatedAt = new DateTime(2024, 10, 21, 10, 0, 0),
                    Status = Status.Active,
                    IsDeleted = false
                },
                new SectionItemFieldSettingTranslation
                {
                    Id = translationId++,
                    SectionItemFieldSettingId = 4,
                    LanguageId = 1, // Türkçe
                    Label = "Menü Başlığı",
                    Description = "Menü öğesinin başlığı",
                    CreatedAt = new DateTime(2024, 10, 21, 10, 0, 0),
                    Status = Status.Active,
                    IsDeleted = false
                }
            );

            // Field 5: icon
            builder.HasData(
                new SectionItemFieldSettingTranslation
                {
                    Id = translationId++,
                    SectionItemFieldSettingId = 5,
                    LanguageId = 2, // English
                    Label = "Icon (Optional)",
                    Description = "FontAwesome icon class",
                    CreatedAt = new DateTime(2024, 10, 21, 10, 0, 0),
                    Status = Status.Active,
                    IsDeleted = false
                },
                new SectionItemFieldSettingTranslation
                {
                    Id = translationId++,
                    SectionItemFieldSettingId = 5,
                    LanguageId = 1, // Türkçe
                    Label = "İkon (Opsiyonel)",
                    Description = "FontAwesome ikon sınıfı",
                    CreatedAt = new DateTime(2024, 10, 21, 10, 0, 0),
                    Status = Status.Active,
                    IsDeleted = false
                }
            );

            // Dropdown Link Fields Translations
            // Field 6: title
            builder.HasData(
                new SectionItemFieldSettingTranslation
                {
                    Id = translationId++,
                    SectionItemFieldSettingId = 6,
                    LanguageId = 2, // English
                    Label = "Link Text",
                    Description = "Text for the navigation link",
                    CreatedAt = new DateTime(2024, 10, 21, 10, 0, 0),
                    Status = Status.Active,
                    IsDeleted = false
                },
                new SectionItemFieldSettingTranslation
                {
                    Id = translationId++,
                    SectionItemFieldSettingId = 6,
                    LanguageId = 1, // Türkçe
                    Label = "Link Metni",
                    Description = "Navigasyon linki için metin",
                    CreatedAt = new DateTime(2024, 10, 21, 10, 0, 0),
                    Status = Status.Active,
                    IsDeleted = false
                }
            );

            // Field 7: url
            builder.HasData(
                new SectionItemFieldSettingTranslation
                {
                    Id = translationId++,
                    SectionItemFieldSettingId = 7,
                    LanguageId = 2, // English
                    Label = "URL",
                    Description = "Link destination",
                    CreatedAt = new DateTime(2024, 10, 21, 10, 0, 0),
                    Status = Status.Active,
                    IsDeleted = false
                },
                new SectionItemFieldSettingTranslation
                {
                    Id = translationId++,
                    SectionItemFieldSettingId = 7,
                    LanguageId = 1, // Türkçe
                    Label = "URL",
                    Description = "Link hedefi",
                    CreatedAt = new DateTime(2024, 10, 21, 10, 0, 0),
                    Status = Status.Active,
                    IsDeleted = false
                }
            );

            // Field 8: icon
            builder.HasData(
                new SectionItemFieldSettingTranslation
                {
                    Id = translationId++,
                    SectionItemFieldSettingId = 8,
                    LanguageId = 2, // English
                    Label = "Icon (Optional)",
                    Description = "FontAwesome icon class",
                    CreatedAt = new DateTime(2024, 10, 21, 10, 0, 0),
                    Status = Status.Active,
                    IsDeleted = false
                },
                new SectionItemFieldSettingTranslation
                {
                    Id = translationId++,
                    SectionItemFieldSettingId = 8,
                    LanguageId = 1, // Türkçe
                    Label = "İkon (Opsiyonel)",
                    Description = "FontAwesome ikon sınıfı",
                    CreatedAt = new DateTime(2024, 10, 21, 10, 0, 0),
                    Status = Status.Active,
                    IsDeleted = false
                }
            );

            // Field 9: openInNewTab
            builder.HasData(
                new SectionItemFieldSettingTranslation
                {
                    Id = translationId++,
                    SectionItemFieldSettingId = 9,
                    LanguageId = 2, // English
                    Label = "Open in New Tab",
                    Description = "Open link in new browser tab",
                    CreatedAt = new DateTime(2024, 10, 21, 10, 0, 0),
                    Status = Status.Active,
                    IsDeleted = false
                },
                new SectionItemFieldSettingTranslation
                {
                    Id = translationId++,
                    SectionItemFieldSettingId = 9,
                    LanguageId = 1, // Türkçe
                    Label = "Yeni Sekmede Aç",
                    Description = "Linki yeni tarayıcı sekmesinde aç",
                    CreatedAt = new DateTime(2024, 10, 21, 10, 0, 0),
                    Status = Status.Active,
                    IsDeleted = false
                }
            );
        }

        private void SeedCarouselFieldTranslations(EntityTypeBuilder<SectionItemFieldSettingTranslation> builder)
        {
            int translationId = 100;

            // Carousel Fields Translations
            // Field 100: image
            builder.HasData(
                new SectionItemFieldSettingTranslation
                {
                    Id = translationId++,
                    SectionItemFieldSettingId = 100,
                    LanguageId = 1, // Türkçe
                    Label = "Slayt Resmi",
                    Description = "Slayt için resim",
                    CreatedAt = new DateTime(2024, 10, 21, 10, 0, 0),
                    Status = Status.Active,
                    IsDeleted = false
                },
                new SectionItemFieldSettingTranslation
                {
                    Id = translationId++,
                    SectionItemFieldSettingId = 100,
                    LanguageId = 2, // English
                    Label = "Slide Image",
                    Description = "Image for the slide",
                    CreatedAt = new DateTime(2024, 10, 21, 10, 0, 0),
                    Status = Status.Active,
                    IsDeleted = false
                }
            );

            // Field 101: title
            builder.HasData(
                new SectionItemFieldSettingTranslation
                {
                    Id = translationId++,
                    SectionItemFieldSettingId = 101,
                    LanguageId = 1, // Türkçe
                    Label = "Slayt Başlığı",
                    Description = "Slayt başlığı",
                    CreatedAt = new DateTime(2024, 10, 21, 10, 0, 0),
                    Status = Status.Active,
                    IsDeleted = false
                },
                new SectionItemFieldSettingTranslation
                {
                    Id = translationId++,
                    SectionItemFieldSettingId = 101,
                    LanguageId = 2, // English
                    Label = "Slide Title",
                    Description = "Title for the slide",
                    CreatedAt = new DateTime(2024, 10, 21, 10, 0, 0),
                    Status = Status.Active,
                    IsDeleted = false
                }
            );

            // Field 102: description
            builder.HasData(
                new SectionItemFieldSettingTranslation
                {
                    Id = translationId++,
                    SectionItemFieldSettingId = 102,
                    LanguageId = 1, // Türkçe
                    Label = "Slayt Açıklaması",
                    Description = "Slayt açıklaması",
                    CreatedAt = new DateTime(2024, 10, 21, 10, 0, 0),
                    Status = Status.Active,
                    IsDeleted = false
                },
                new SectionItemFieldSettingTranslation
                {
                    Id = translationId++,
                    SectionItemFieldSettingId = 102,
                    LanguageId = 2, // English
                    Label = "Slide Description",
                    Description = "Description for the slide",
                    CreatedAt = new DateTime(2024, 10, 21, 10, 0, 0),
                    Status = Status.Active,
                    IsDeleted = false
                }
            );

            // Field 103: buttonText
            builder.HasData(
                new SectionItemFieldSettingTranslation
                {
                    Id = translationId++,
                    SectionItemFieldSettingId = 103,
                    LanguageId = 1, // Türkçe
                    Label = "Buton Metni",
                    Description = "Buton metni",
                    CreatedAt = new DateTime(2024, 10, 21, 10, 0, 0),
                    Status = Status.Active,
                    IsDeleted = false
                },
                new SectionItemFieldSettingTranslation
                {
                    Id = translationId++,
                    SectionItemFieldSettingId = 103,
                    LanguageId = 2, // English
                    Label = "Button Text",
                    Description = "Text for the button",
                    CreatedAt = new DateTime(2024, 10, 21, 10, 0, 0),
                    Status = Status.Active,
                    IsDeleted = false
                }
            );

            // Field 104: buttonUrl
            builder.HasData(
                new SectionItemFieldSettingTranslation
                {
                    Id = translationId++,
                    SectionItemFieldSettingId = 104,
                    LanguageId = 1, // Türkçe
                    Label = "Buton URL",
                    Description = "Butonun yönlendirileceği adres",
                    CreatedAt = new DateTime(2024, 10, 21, 10, 0, 0),
                    Status = Status.Active,
                    IsDeleted = false
                },
                new SectionItemFieldSettingTranslation
                {
                    Id = translationId++,
                    SectionItemFieldSettingId = 104,
                    LanguageId = 2, // English
                    Label = "Button URL",
                    Description = "URL for the button",
                    CreatedAt = new DateTime(2024, 10, 21, 10, 0, 0),
                    Status = Status.Active,
                    IsDeleted = false
                }
            );
        }

        private void SeedDefaultFieldTranslations(EntityTypeBuilder<SectionItemFieldSettingTranslation> builder)
        {
            int translationId = 200;

            // Default Fields Translations
            // Field 200: title
            builder.HasData(
                new SectionItemFieldSettingTranslation
                {
                    Id = translationId++,
                    SectionItemFieldSettingId = 200,
                    LanguageId = 1, // Türkçe
                    Label = "Başlık",
                    Description = "Öğe başlığı",
                    CreatedAt = new DateTime(2024, 10, 21, 10, 0, 0),
                    Status = Status.Active,
                    IsDeleted = false
                },
                new SectionItemFieldSettingTranslation
                {
                    Id = translationId++,
                    SectionItemFieldSettingId = 200,
                    LanguageId = 2, // English
                    Label = "Title",
                    Description = "Item title",
                    CreatedAt = new DateTime(2024, 10, 21, 10, 0, 0),
                    Status = Status.Active,
                    IsDeleted = false
                }
            );

            // Field 201: description
            builder.HasData(
                new SectionItemFieldSettingTranslation
                {
                    Id = translationId++,
                    SectionItemFieldSettingId = 201,
                    LanguageId = 1, // Türkçe
                    Label = "Açıklama",
                    Description = "Öğe açıklaması",
                    CreatedAt = new DateTime(2024, 10, 21, 10, 0, 0),
                    Status = Status.Active,
                    IsDeleted = false
                },
                new SectionItemFieldSettingTranslation
                {
                    Id = translationId++,
                    SectionItemFieldSettingId = 201,
                    LanguageId = 2, // English
                    Label = "Description",
                    Description = "Item description",
                    CreatedAt = new DateTime(2024, 10, 21, 10, 0, 0),
                    Status = Status.Active,
                    IsDeleted = false
                }
            );
        }

        private void SeedNavbarMegaMenuFieldTranslations(EntityTypeBuilder<SectionItemFieldSettingTranslation> builder)
        {
            int id = 3000;
            // FieldId 300: title
            builder.HasData(
                new SectionItemFieldSettingTranslation { Id = id++, SectionItemFieldSettingId = 300, LanguageId = 1, Label = "Başlık", Description = "Kategori başlığı", CreatedAt = new DateTime(2024, 10, 21, 10, 0, 0), Status = Status.Active, IsDeleted = false },
                new SectionItemFieldSettingTranslation { Id = id++, SectionItemFieldSettingId = 300, LanguageId = 2, Label = "Title", Description = "Category title", CreatedAt = new DateTime(2024, 10, 21, 10, 0, 0), Status = Status.Active, IsDeleted = false },
                // FieldId 301: icon
                new SectionItemFieldSettingTranslation { Id = id++, SectionItemFieldSettingId = 301, LanguageId = 1, Label = "İkon", Description = "Kategori ikonu", CreatedAt = new DateTime(2024, 10, 21, 10, 0, 0), Status = Status.Active, IsDeleted = false },
                new SectionItemFieldSettingTranslation { Id = id++, SectionItemFieldSettingId = 301, LanguageId = 2, Label = "Icon", Description = "Category icon", CreatedAt = new DateTime(2024, 10, 21, 10, 0, 0), Status = Status.Active, IsDeleted = false },
                // FieldId 302: description
                new SectionItemFieldSettingTranslation { Id = id++, SectionItemFieldSettingId = 302, LanguageId = 1, Label = "Açıklama", Description = "Kategori açıklaması", CreatedAt = new DateTime(2024, 10, 21, 10, 0, 0), Status = Status.Active, IsDeleted = false },
                new SectionItemFieldSettingTranslation { Id = id++, SectionItemFieldSettingId = 302, LanguageId = 2, Label = "Description", Description = "Category description", CreatedAt = new DateTime(2024, 10, 21, 10, 0, 0), Status = Status.Active, IsDeleted = false },
                // FieldId 310: title
                new SectionItemFieldSettingTranslation { Id = id++, SectionItemFieldSettingId = 310, LanguageId = 1, Label = "Başlık", Description = "Link başlığı", CreatedAt = new DateTime(2024, 10, 21, 10, 0, 0), Status = Status.Active, IsDeleted = false },
                new SectionItemFieldSettingTranslation { Id = id++, SectionItemFieldSettingId = 310, LanguageId = 2, Label = "Title", Description = "Link title", CreatedAt = new DateTime(2024, 10, 21, 10, 0, 0), Status = Status.Active, IsDeleted = false },
                // FieldId 311: url
                new SectionItemFieldSettingTranslation { Id = id++, SectionItemFieldSettingId = 311, LanguageId = 1, Label = "URL", Description = "Link adresi", CreatedAt = new DateTime(2024, 10, 21, 10, 0, 0), Status = Status.Active, IsDeleted = false },
                new SectionItemFieldSettingTranslation { Id = id++, SectionItemFieldSettingId = 311, LanguageId = 2, Label = "URL", Description = "Link address", CreatedAt = new DateTime(2024, 10, 21, 10, 0, 0), Status = Status.Active, IsDeleted = false },
                // FieldId 312: icon
                new SectionItemFieldSettingTranslation { Id = id++, SectionItemFieldSettingId = 312, LanguageId = 1, Label = "İkon", Description = "Link ikonu", CreatedAt = new DateTime(2024, 10, 21, 10, 0, 0), Status = Status.Active, IsDeleted = false },
                new SectionItemFieldSettingTranslation { Id = id++, SectionItemFieldSettingId = 312, LanguageId = 2, Label = "Icon", Description = "Link icon", CreatedAt = new DateTime(2024, 10, 21, 10, 0, 0), Status = Status.Active, IsDeleted = false }
            );
        }

        private void SeedNavbarServiceTabsFieldTranslations(EntityTypeBuilder<SectionItemFieldSettingTranslation> builder)
        {
            int id = 4000;
            builder.HasData(
                // FieldId 400-403: Service Tab fields
                new SectionItemFieldSettingTranslation { Id = id++, SectionItemFieldSettingId = 400, LanguageId = 1, Label = "Başlık", Description = "Sekme başlığı", CreatedAt = new DateTime(2024, 10, 21, 10, 0, 0), Status = Status.Active, IsDeleted = false },
                new SectionItemFieldSettingTranslation { Id = id++, SectionItemFieldSettingId = 400, LanguageId = 2, Label = "Title", Description = "Tab title", CreatedAt = new DateTime(2024, 10, 21, 10, 0, 0), Status = Status.Active, IsDeleted = false },
                new SectionItemFieldSettingTranslation { Id = id++, SectionItemFieldSettingId = 401, LanguageId = 1, Label = "İkon", Description = "Sekme ikonu", CreatedAt = new DateTime(2024, 10, 21, 10, 0, 0), Status = Status.Active, IsDeleted = false },
                new SectionItemFieldSettingTranslation { Id = id++, SectionItemFieldSettingId = 401, LanguageId = 2, Label = "Icon", Description = "Tab icon", CreatedAt = new DateTime(2024, 10, 21, 10, 0, 0), Status = Status.Active, IsDeleted = false },
                new SectionItemFieldSettingTranslation { Id = id++, SectionItemFieldSettingId = 402, LanguageId = 1, Label = "Açıklama", Description = "Sekme açıklaması", CreatedAt = new DateTime(2024, 10, 21, 10, 0, 0), Status = Status.Active, IsDeleted = false },
                new SectionItemFieldSettingTranslation { Id = id++, SectionItemFieldSettingId = 402, LanguageId = 2, Label = "Description", Description = "Tab description", CreatedAt = new DateTime(2024, 10, 21, 10, 0, 0), Status = Status.Active, IsDeleted = false },
                new SectionItemFieldSettingTranslation { Id = id++, SectionItemFieldSettingId = 403, LanguageId = 1, Label = "URL", Description = "Sekme bağlantısı", CreatedAt = new DateTime(2024, 10, 21, 10, 0, 0), Status = Status.Active, IsDeleted = false },
                new SectionItemFieldSettingTranslation { Id = id++, SectionItemFieldSettingId = 403, LanguageId = 2, Label = "URL", Description = "Tab link", CreatedAt = new DateTime(2024, 10, 21, 10, 0, 0), Status = Status.Active, IsDeleted = false }
            );
        }

        private void SeedNavbarCategorizedFieldTranslations(EntityTypeBuilder<SectionItemFieldSettingTranslation> builder)
        {
            int id = 5000;
            builder.HasData(
                // FieldId 500-501: Category fields
                new SectionItemFieldSettingTranslation { Id = id++, SectionItemFieldSettingId = 500, LanguageId = 1, Label = "Başlık", Description = "Kategori başlığı", CreatedAt = new DateTime(2024, 10, 21, 10, 0, 0), Status = Status.Active, IsDeleted = false },
                new SectionItemFieldSettingTranslation { Id = id++, SectionItemFieldSettingId = 500, LanguageId = 2, Label = "Title", Description = "Category title", CreatedAt = new DateTime(2024, 10, 21, 10, 0, 0), Status = Status.Active, IsDeleted = false },
                new SectionItemFieldSettingTranslation { Id = id++, SectionItemFieldSettingId = 501, LanguageId = 1, Label = "İkon", Description = "Kategori ikonu", CreatedAt = new DateTime(2024, 10, 21, 10, 0, 0), Status = Status.Active, IsDeleted = false },
                new SectionItemFieldSettingTranslation { Id = id++, SectionItemFieldSettingId = 501, LanguageId = 2, Label = "Icon", Description = "Category icon", CreatedAt = new DateTime(2024, 10, 21, 10, 0, 0), Status = Status.Active, IsDeleted = false },
                // FieldId 510-512: Category Item fields
                new SectionItemFieldSettingTranslation { Id = id++, SectionItemFieldSettingId = 510, LanguageId = 1, Label = "Başlık", Description = "Öğe başlığı", CreatedAt = new DateTime(2024, 10, 21, 10, 0, 0), Status = Status.Active, IsDeleted = false },
                new SectionItemFieldSettingTranslation { Id = id++, SectionItemFieldSettingId = 510, LanguageId = 2, Label = "Title", Description = "Item title", CreatedAt = new DateTime(2024, 10, 21, 10, 0, 0), Status = Status.Active, IsDeleted = false },
                new SectionItemFieldSettingTranslation { Id = id++, SectionItemFieldSettingId = 511, LanguageId = 1, Label = "URL", Description = "Öğe adresi", CreatedAt = new DateTime(2024, 10, 21, 10, 0, 0), Status = Status.Active, IsDeleted = false },
                new SectionItemFieldSettingTranslation { Id = id++, SectionItemFieldSettingId = 511, LanguageId = 2, Label = "URL", Description = "Item URL", CreatedAt = new DateTime(2024, 10, 21, 10, 0, 0), Status = Status.Active, IsDeleted = false },
                new SectionItemFieldSettingTranslation { Id = id++, SectionItemFieldSettingId = 512, LanguageId = 1, Label = "Rozet", Description = "Öğe rozeti", CreatedAt = new DateTime(2024, 10, 21, 10, 0, 0), Status = Status.Active, IsDeleted = false },
                new SectionItemFieldSettingTranslation { Id = id++, SectionItemFieldSettingId = 512, LanguageId = 2, Label = "Badge", Description = "Item badge", CreatedAt = new DateTime(2024, 10, 21, 10, 0, 0), Status = Status.Active, IsDeleted = false }
            );
        }

        private void SeedSequentialFieldTranslations(EntityTypeBuilder<SectionItemFieldSettingTranslation> builder)
        {
            int id = 6000;
            builder.HasData(
                // FieldId 600-602: Step fields
                new SectionItemFieldSettingTranslation { Id = id++, SectionItemFieldSettingId = 600, LanguageId = 1, Label = "Başlık", Description = "Adım başlığı", CreatedAt = new DateTime(2024, 10, 21, 10, 0, 0), Status = Status.Active, IsDeleted = false },
                new SectionItemFieldSettingTranslation { Id = id++, SectionItemFieldSettingId = 600, LanguageId = 2, Label = "Title", Description = "Step title", CreatedAt = new DateTime(2024, 10, 21, 10, 0, 0), Status = Status.Active, IsDeleted = false },
                new SectionItemFieldSettingTranslation { Id = id++, SectionItemFieldSettingId = 601, LanguageId = 1, Label = "Açıklama", Description = "Adım açıklaması", CreatedAt = new DateTime(2024, 10, 21, 10, 0, 0), Status = Status.Active, IsDeleted = false },
                new SectionItemFieldSettingTranslation { Id = id++, SectionItemFieldSettingId = 601, LanguageId = 2, Label = "Description", Description = "Step description", CreatedAt = new DateTime(2024, 10, 21, 10, 0, 0), Status = Status.Active, IsDeleted = false },
                new SectionItemFieldSettingTranslation { Id = id++, SectionItemFieldSettingId = 602, LanguageId = 1, Label = "İkon", Description = "Adım ikonu", CreatedAt = new DateTime(2024, 10, 21, 10, 0, 0), Status = Status.Active, IsDeleted = false },
                new SectionItemFieldSettingTranslation { Id = id++, SectionItemFieldSettingId = 602, LanguageId = 2, Label = "Icon", Description = "Step icon", CreatedAt = new DateTime(2024, 10, 21, 10, 0, 0), Status = Status.Active, IsDeleted = false }
            );
        }

        private void SeedGridFieldTranslations(EntityTypeBuilder<SectionItemFieldSettingTranslation> builder)
        {
            int id = 7000;
            builder.HasData(
                // FieldId 700-703: Grid Item fields
                new SectionItemFieldSettingTranslation { Id = id++, SectionItemFieldSettingId = 700, LanguageId = 1, Label = "Resim", Description = "Grid resmi", CreatedAt = new DateTime(2024, 10, 21, 10, 0, 0), Status = Status.Active, IsDeleted = false },
                new SectionItemFieldSettingTranslation { Id = id++, SectionItemFieldSettingId = 700, LanguageId = 2, Label = "Image", Description = "Grid image", CreatedAt = new DateTime(2024, 10, 21, 10, 0, 0), Status = Status.Active, IsDeleted = false },
                new SectionItemFieldSettingTranslation { Id = id++, SectionItemFieldSettingId = 701, LanguageId = 1, Label = "Başlık", Description = "Öğe başlığı", CreatedAt = new DateTime(2024, 10, 21, 10, 0, 0), Status = Status.Active, IsDeleted = false },
                new SectionItemFieldSettingTranslation { Id = id++, SectionItemFieldSettingId = 701, LanguageId = 2, Label = "Title", Description = "Item title", CreatedAt = new DateTime(2024, 10, 21, 10, 0, 0), Status = Status.Active, IsDeleted = false },
                new SectionItemFieldSettingTranslation { Id = id++, SectionItemFieldSettingId = 702, LanguageId = 1, Label = "Açıklama", Description = "Öğe açıklaması", CreatedAt = new DateTime(2024, 10, 21, 10, 0, 0), Status = Status.Active, IsDeleted = false },
                new SectionItemFieldSettingTranslation { Id = id++, SectionItemFieldSettingId = 702, LanguageId = 2, Label = "Description", Description = "Item description", CreatedAt = new DateTime(2024, 10, 21, 10, 0, 0), Status = Status.Active, IsDeleted = false },
                new SectionItemFieldSettingTranslation { Id = id++, SectionItemFieldSettingId = 703, LanguageId = 1, Label = "URL", Description = "Bağlantı adresi", CreatedAt = new DateTime(2024, 10, 21, 10, 0, 0), Status = Status.Active, IsDeleted = false },
                new SectionItemFieldSettingTranslation { Id = id++, SectionItemFieldSettingId = 703, LanguageId = 2, Label = "URL", Description = "Link URL", CreatedAt = new DateTime(2024, 10, 21, 10, 0, 0), Status = Status.Active, IsDeleted = false }
            );
        }

        private void SeedMasonryFieldTranslations(EntityTypeBuilder<SectionItemFieldSettingTranslation> builder)
        {
            int id = 8000;
            builder.HasData(
                // FieldId 800-803: Masonry fields
                new SectionItemFieldSettingTranslation { Id = id++, SectionItemFieldSettingId = 800, LanguageId = 1, Label = "Resim", Description = "Galeri resmi", CreatedAt = new DateTime(2024, 10, 21, 10, 0, 0), Status = Status.Active, IsDeleted = false },
                new SectionItemFieldSettingTranslation { Id = id++, SectionItemFieldSettingId = 800, LanguageId = 2, Label = "Image", Description = "Gallery image", CreatedAt = new DateTime(2024, 10, 21, 10, 0, 0), Status = Status.Active, IsDeleted = false },
                new SectionItemFieldSettingTranslation { Id = id++, SectionItemFieldSettingId = 801, LanguageId = 1, Label = "Alt Metni", Description = "Resim alt metni", CreatedAt = new DateTime(2024, 10, 21, 10, 0, 0), Status = Status.Active, IsDeleted = false },
                new SectionItemFieldSettingTranslation { Id = id++, SectionItemFieldSettingId = 801, LanguageId = 2, Label = "Alt Text", Description = "Image alt text", CreatedAt = new DateTime(2024, 10, 21, 10, 0, 0), Status = Status.Active, IsDeleted = false },
                new SectionItemFieldSettingTranslation { Id = id++, SectionItemFieldSettingId = 802, LanguageId = 1, Label = "Başlık", Description = "Resim başlığı", CreatedAt = new DateTime(2024, 10, 21, 10, 0, 0), Status = Status.Active, IsDeleted = false },
                new SectionItemFieldSettingTranslation { Id = id++, SectionItemFieldSettingId = 802, LanguageId = 2, Label = "Caption", Description = "Image caption", CreatedAt = new DateTime(2024, 10, 21, 10, 0, 0), Status = Status.Active, IsDeleted = false },
                new SectionItemFieldSettingTranslation { Id = id++, SectionItemFieldSettingId = 803, LanguageId = 1, Label = "Bağlantı", Description = "Resim bağlantısı", CreatedAt = new DateTime(2024, 10, 21, 10, 0, 0), Status = Status.Active, IsDeleted = false },
                new SectionItemFieldSettingTranslation { Id = id++, SectionItemFieldSettingId = 803, LanguageId = 2, Label = "Link URL", Description = "Image link", CreatedAt = new DateTime(2024, 10, 21, 10, 0, 0), Status = Status.Active, IsDeleted = false }
            );
        }

        private void SeedListFieldTranslations(EntityTypeBuilder<SectionItemFieldSettingTranslation> builder)
        {
            int id = 9000;
            builder.HasData(
                // FieldId 900-902: List Item fields
                new SectionItemFieldSettingTranslation { Id = id++, SectionItemFieldSettingId = 900, LanguageId = 1, Label = "Başlık", Description = "Liste öğesi başlığı", CreatedAt = new DateTime(2024, 10, 21, 10, 0, 0), Status = Status.Active, IsDeleted = false },
                new SectionItemFieldSettingTranslation { Id = id++, SectionItemFieldSettingId = 900, LanguageId = 2, Label = "Title", Description = "List item title", CreatedAt = new DateTime(2024, 10, 21, 10, 0, 0), Status = Status.Active, IsDeleted = false },
                new SectionItemFieldSettingTranslation { Id = id++, SectionItemFieldSettingId = 901, LanguageId = 1, Label = "Açıklama", Description = "Liste öğesi açıklaması", CreatedAt = new DateTime(2024, 10, 21, 10, 0, 0), Status = Status.Active, IsDeleted = false },
                new SectionItemFieldSettingTranslation { Id = id++, SectionItemFieldSettingId = 901, LanguageId = 2, Label = "Description", Description = "List item description", CreatedAt = new DateTime(2024, 10, 21, 10, 0, 0), Status = Status.Active, IsDeleted = false },
                new SectionItemFieldSettingTranslation { Id = id++, SectionItemFieldSettingId = 902, LanguageId = 1, Label = "İkon", Description = "Liste ikonu", CreatedAt = new DateTime(2024, 10, 21, 10, 0, 0), Status = Status.Active, IsDeleted = false },
                new SectionItemFieldSettingTranslation { Id = id++, SectionItemFieldSettingId = 902, LanguageId = 2, Label = "Icon", Description = "List icon", CreatedAt = new DateTime(2024, 10, 21, 10, 0, 0), Status = Status.Active, IsDeleted = false }
            );
        }

        private void SeedSingleItemFieldTranslations(EntityTypeBuilder<SectionItemFieldSettingTranslation> builder)
        {
            int id = 10100;
            builder.HasData(
                // FieldId 1010-1015: Single Item fields
                new SectionItemFieldSettingTranslation { Id = id++, SectionItemFieldSettingId = 1010, LanguageId = 1, Label = "Resim", Description = "Öne çıkan resim", CreatedAt = new DateTime(2024, 10, 21, 10, 0, 0), Status = Status.Active, IsDeleted = false },
                new SectionItemFieldSettingTranslation { Id = id++, SectionItemFieldSettingId = 1010, LanguageId = 2, Label = "Image", Description = "Featured image", CreatedAt = new DateTime(2024, 10, 21, 10, 0, 0), Status = Status.Active, IsDeleted = false },
                new SectionItemFieldSettingTranslation { Id = id++, SectionItemFieldSettingId = 1011, LanguageId = 1, Label = "Başlık", Description = "Ana başlık", CreatedAt = new DateTime(2024, 10, 21, 10, 0, 0), Status = Status.Active, IsDeleted = false },
                new SectionItemFieldSettingTranslation { Id = id++, SectionItemFieldSettingId = 1011, LanguageId = 2, Label = "Title", Description = "Main title", CreatedAt = new DateTime(2024, 10, 21, 10, 0, 0), Status = Status.Active, IsDeleted = false },
                new SectionItemFieldSettingTranslation { Id = id++, SectionItemFieldSettingId = 1012, LanguageId = 1, Label = "Alt Başlık", Description = "İkincil başlık", CreatedAt = new DateTime(2024, 10, 21, 10, 0, 0), Status = Status.Active, IsDeleted = false },
                new SectionItemFieldSettingTranslation { Id = id++, SectionItemFieldSettingId = 1012, LanguageId = 2, Label = "Subtitle", Description = "Secondary title", CreatedAt = new DateTime(2024, 10, 21, 10, 0, 0), Status = Status.Active, IsDeleted = false },
                new SectionItemFieldSettingTranslation { Id = id++, SectionItemFieldSettingId = 1013, LanguageId = 1, Label = "Açıklama", Description = "Detaylı açıklama", CreatedAt = new DateTime(2024, 10, 21, 10, 0, 0), Status = Status.Active, IsDeleted = false },
                new SectionItemFieldSettingTranslation { Id = id++, SectionItemFieldSettingId = 1013, LanguageId = 2, Label = "Description", Description = "Detailed description", CreatedAt = new DateTime(2024, 10, 21, 10, 0, 0), Status = Status.Active, IsDeleted = false },
                new SectionItemFieldSettingTranslation { Id = id++, SectionItemFieldSettingId = 1014, LanguageId = 1, Label = "Buton Metni", Description = "Aksiyon buton metni", CreatedAt = new DateTime(2024, 10, 21, 10, 0, 0), Status = Status.Active, IsDeleted = false },
                new SectionItemFieldSettingTranslation { Id = id++, SectionItemFieldSettingId = 1014, LanguageId = 2, Label = "Button Text", Description = "Action button text", CreatedAt = new DateTime(2024, 10, 21, 10, 0, 0), Status = Status.Active, IsDeleted = false },
                new SectionItemFieldSettingTranslation { Id = id++, SectionItemFieldSettingId = 1015, LanguageId = 1, Label = "Buton URL", Description = "Buton bağlantısı", CreatedAt = new DateTime(2024, 10, 21, 10, 0, 0), Status = Status.Active, IsDeleted = false },
                new SectionItemFieldSettingTranslation { Id = id++, SectionItemFieldSettingId = 1015, LanguageId = 2, Label = "Button URL", Description = "Button link", CreatedAt = new DateTime(2024, 10, 21, 10, 0, 0), Status = Status.Active, IsDeleted = false }
            );
        }

        private void SeedMultiItemFieldTranslations(EntityTypeBuilder<SectionItemFieldSettingTranslation> builder)
        {
            int id = 11000;
            builder.HasData(
                // FieldId 1100-1103: Multi Item fields
                new SectionItemFieldSettingTranslation { Id = id++, SectionItemFieldSettingId = 1100, LanguageId = 1, Label = "Resim", Description = "Öğe resmi", CreatedAt = new DateTime(2024, 10, 21, 10, 0, 0), Status = Status.Active, IsDeleted = false },
                new SectionItemFieldSettingTranslation { Id = id++, SectionItemFieldSettingId = 1100, LanguageId = 2, Label = "Image", Description = "Item image", CreatedAt = new DateTime(2024, 10, 21, 10, 0, 0), Status = Status.Active, IsDeleted = false },
                new SectionItemFieldSettingTranslation { Id = id++, SectionItemFieldSettingId = 1101, LanguageId = 1, Label = "Başlık", Description = "Öğe başlığı", CreatedAt = new DateTime(2024, 10, 21, 10, 0, 0), Status = Status.Active, IsDeleted = false },
                new SectionItemFieldSettingTranslation { Id = id++, SectionItemFieldSettingId = 1101, LanguageId = 2, Label = "Title", Description = "Item title", CreatedAt = new DateTime(2024, 10, 21, 10, 0, 0), Status = Status.Active, IsDeleted = false },
                new SectionItemFieldSettingTranslation { Id = id++, SectionItemFieldSettingId = 1102, LanguageId = 1, Label = "Açıklama", Description = "Öğe açıklaması", CreatedAt = new DateTime(2024, 10, 21, 10, 0, 0), Status = Status.Active, IsDeleted = false },
                new SectionItemFieldSettingTranslation { Id = id++, SectionItemFieldSettingId = 1102, LanguageId = 2, Label = "Description", Description = "Item description", CreatedAt = new DateTime(2024, 10, 21, 10, 0, 0), Status = Status.Active, IsDeleted = false },
                new SectionItemFieldSettingTranslation { Id = id++, SectionItemFieldSettingId = 1103, LanguageId = 1, Label = "URL", Description = "Öğe bağlantısı", CreatedAt = new DateTime(2024, 10, 21, 10, 0, 0), Status = Status.Active, IsDeleted = false },
                new SectionItemFieldSettingTranslation { Id = id++, SectionItemFieldSettingId = 1103, LanguageId = 2, Label = "URL", Description = "Item link", CreatedAt = new DateTime(2024, 10, 21, 10, 0, 0), Status = Status.Active, IsDeleted = false }
            );
        }

        private void SeedAccordionFieldTranslations(EntityTypeBuilder<SectionItemFieldSettingTranslation> builder)
        {
            int id = 12000;
            builder.HasData(
                // FieldId 1200-1202: Accordion fields
                new SectionItemFieldSettingTranslation { Id = id++, SectionItemFieldSettingId = 1200, LanguageId = 1, Label = "Başlık", Description = "Panel başlığı", CreatedAt = new DateTime(2024, 10, 21, 10, 0, 0), Status = Status.Active, IsDeleted = false },
                new SectionItemFieldSettingTranslation { Id = id++, SectionItemFieldSettingId = 1200, LanguageId = 2, Label = "Title", Description = "Panel title", CreatedAt = new DateTime(2024, 10, 21, 10, 0, 0), Status = Status.Active, IsDeleted = false },
                new SectionItemFieldSettingTranslation { Id = id++, SectionItemFieldSettingId = 1201, LanguageId = 1, Label = "İçerik", Description = "Panel içeriği", CreatedAt = new DateTime(2024, 10, 21, 10, 0, 0), Status = Status.Active, IsDeleted = false },
                new SectionItemFieldSettingTranslation { Id = id++, SectionItemFieldSettingId = 1201, LanguageId = 2, Label = "Content", Description = "Panel content", CreatedAt = new DateTime(2024, 10, 21, 10, 0, 0), Status = Status.Active, IsDeleted = false },
                new SectionItemFieldSettingTranslation { Id = id++, SectionItemFieldSettingId = 1202, LanguageId = 1, Label = "Açık Mı?", Description = "Başlangıçta açık", CreatedAt = new DateTime(2024, 10, 21, 10, 0, 0), Status = Status.Active, IsDeleted = false },
                new SectionItemFieldSettingTranslation { Id = id++, SectionItemFieldSettingId = 1202, LanguageId = 2, Label = "Is Open?", Description = "Initially open", CreatedAt = new DateTime(2024, 10, 21, 10, 0, 0), Status = Status.Active, IsDeleted = false }
            );
        }

        private void SeedTabsFieldTranslations(EntityTypeBuilder<SectionItemFieldSettingTranslation> builder)
        {
            int id = 13000;
            builder.HasData(
                // FieldId 1300-1302: Tabs fields
                new SectionItemFieldSettingTranslation { Id = id++, SectionItemFieldSettingId = 1300, LanguageId = 1, Label = "Başlık", Description = "Sekme başlığı", CreatedAt = new DateTime(2024, 10, 21, 10, 0, 0), Status = Status.Active, IsDeleted = false },
                new SectionItemFieldSettingTranslation { Id = id++, SectionItemFieldSettingId = 1300, LanguageId = 2, Label = "Title", Description = "Tab title", CreatedAt = new DateTime(2024, 10, 21, 10, 0, 0), Status = Status.Active, IsDeleted = false },
                new SectionItemFieldSettingTranslation { Id = id++, SectionItemFieldSettingId = 1301, LanguageId = 1, Label = "İkon", Description = "Sekme ikonu", CreatedAt = new DateTime(2024, 10, 21, 10, 0, 0), Status = Status.Active, IsDeleted = false },
                new SectionItemFieldSettingTranslation { Id = id++, SectionItemFieldSettingId = 1301, LanguageId = 2, Label = "Icon", Description = "Tab icon", CreatedAt = new DateTime(2024, 10, 21, 10, 0, 0), Status = Status.Active, IsDeleted = false },
                new SectionItemFieldSettingTranslation { Id = id++, SectionItemFieldSettingId = 1302, LanguageId = 1, Label = "İçerik", Description = "Sekme içeriği", CreatedAt = new DateTime(2024, 10, 21, 10, 0, 0), Status = Status.Active, IsDeleted = false },
                new SectionItemFieldSettingTranslation { Id = id++, SectionItemFieldSettingId = 1302, LanguageId = 2, Label = "Content", Description = "Tab content", CreatedAt = new DateTime(2024, 10, 21, 10, 0, 0), Status = Status.Active, IsDeleted = false }
            );
        }
    }
}

