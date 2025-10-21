using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PazarAtlasi.CMS.Domain.Entities.Content;
using PazarAtlasi.CMS.Domain.Common;

namespace PazarAtlasi.CMS.Persistence.EntityConfigurations.Content
{
    public class SectionItemSettingTranslationConfiguration : IEntityTypeConfiguration<SectionItemSettingTranslation>
    {
        public void Configure(EntityTypeBuilder<SectionItemSettingTranslation> builder)
        {
            builder.ToTable("SectionItemSettingTranslations");
            builder.HasKey(sist => sist.Id);

            builder.Property(sist => sist.Id)
                .HasColumnName("Id")
                .IsRequired();

            builder.Property(sist => sist.SectionItemSettingId)
                .HasColumnName("SectionItemSettingId")
                .IsRequired();

            builder.Property(sist => sist.LanguageId)
                .HasColumnName("LanguageId")
                .IsRequired();

            builder.Property(sist => sist.Title)
                .HasColumnName("Title")
                .HasMaxLength(200)
                .IsRequired();

            builder.Property(sist => sist.Description)
                .HasColumnName("Description")
                .HasMaxLength(1000);

            builder.Property(sist => sist.CreatedAt)
                .HasColumnName("CreatedAt")
                .IsRequired();

            builder.Property(sist => sist.UpdatedAt)
                .HasColumnName("UpdatedAt");

            builder.Property(sist => sist.IsDeleted)
                .HasColumnName("IsDeleted")
                .HasDefaultValue(false);

            builder.Property(sist => sist.Status)
                .HasColumnName("Status")
                .HasDefaultValue(Status.Active);

            builder.Property(sist => sist.CreatedBy)
                .HasColumnName("CreatedBy");

            builder.Property(sist => sist.UpdatedBy)
                .HasColumnName("UpdatedBy");

            // Relationships
            builder.HasOne(sist => sist.SectionItemSetting)
                .WithMany(sis => sis.Translations)
                .HasForeignKey(sist => sist.SectionItemSettingId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(sist => sist.Language)
                .WithMany()
                .HasForeignKey(sist => sist.LanguageId)
                .OnDelete(DeleteBehavior.Restrict);

            // Indexes
            builder.HasIndex(sist => new { sist.SectionItemSettingId, sist.LanguageId })
                .HasDatabaseName("IX_SectionItemSettingTranslations_SettingId_LanguageId")
                .IsUnique();

            // Query Filter
            builder.HasQueryFilter(sist => !sist.IsDeleted);

            // Seed Data - Translations for All Configurations
            SeedNavbarSimpleSettingTranslations(builder);
            SeedNavbarMegaMenuSettingTranslations(builder);
            SeedNavbarServiceTabsSettingTranslations(builder);
            SeedNavbarCategorizedSettingTranslations(builder);
            SeedCarouselSettingTranslations(builder);
            SeedDefaultSettingTranslations(builder);
            SeedSequentialSettingTranslations(builder);
            SeedGridSettingTranslations(builder);
            SeedMasonrySettingTranslations(builder);
            SeedListSettingTranslations(builder);
            SeedSingleItemSettingTranslations(builder);
            SeedMultiItemSettingTranslations(builder);
            SeedAccordionSettingTranslations(builder);
            SeedTabsSettingTranslations(builder);
        }

        private void SeedNavbarSimpleSettingTranslations(EntityTypeBuilder<SectionItemSettingTranslation> builder)
        {
            // Logo Configuration Translations (SettingId: 1)
            builder.HasData(
                // Turkish (ID = 1)
                new SectionItemSettingTranslation
                {
                    Id = 1,
                    SectionItemSettingId = 1,
                    LanguageId = 1, // Türkçe
                    Title = "Logo",
                    Description = "Web sitesi logosu",
                    CreatedAt = new DateTime(2024, 10, 21, 10, 0, 0),
                    Status = Status.Active,
                    IsDeleted = false
                },
                // English (ID = 2)
                new SectionItemSettingTranslation
                {
                    Id = 2,
                    SectionItemSettingId = 1,
                    LanguageId = 2, // English
                    Title = "Logo",
                    Description = "Website Logo",
                    CreatedAt = new DateTime(2024, 10, 21, 10, 0, 0),
                    Status = Status.Active,
                    IsDeleted = false
                }
            );

            // Menu Configuration Translations (SettingId: 2)
            builder.HasData(
                // Turkish (ID = 1)
                new SectionItemSettingTranslation
                {
                    Id = 3,
                    SectionItemSettingId = 2,
                    LanguageId = 1, // Türkçe
                    Title = "Menü Öğeleri",
                    Description = "Navigasyon menü öğeleri",
                    CreatedAt = new DateTime(2024, 10, 21, 10, 0, 0),
                    Status = Status.Active,
                    IsDeleted = false
                },
                // English (ID = 2)
                new SectionItemSettingTranslation
                {
                    Id = 4,
                    SectionItemSettingId = 2,
                    LanguageId = 2, // English
                    Title = "Menu Items",
                    Description = "Navigation menu items",
                    CreatedAt = new DateTime(2024, 10, 21, 10, 0, 0),
                    Status = Status.Active,
                    IsDeleted = false
                }
            );

            // Dropdown Link Configuration Translations (SettingId: 3)
            builder.HasData(
                // Turkish (ID = 1)
                new SectionItemSettingTranslation
                {
                    Id = 5,
                    SectionItemSettingId = 3,
                    LanguageId = 1, // Türkçe
                    Title = "Açılır Menü Linki",
                    Description = "Açılır menüdeki bağlantı",
                    CreatedAt = new DateTime(2024, 10, 21, 10, 0, 0),
                    Status = Status.Active,
                    IsDeleted = false
                },
                // English (ID = 2)
                new SectionItemSettingTranslation
                {
                    Id = 6,
                    SectionItemSettingId = 3,
                    LanguageId = 2, // English
                    Title = "Dropdown Link",
                    Description = "Link in dropdown menu",
                    CreatedAt = new DateTime(2024, 10, 21, 10, 0, 0),
                    Status = Status.Active,
                    IsDeleted = false
                }
            );
        }

        private void SeedCarouselSettingTranslations(EntityTypeBuilder<SectionItemSettingTranslation> builder)
        {
            // Carousel Slide Configuration Translations (SettingId: 10)
            builder.HasData(
                // Turkish (ID = 1)
                new SectionItemSettingTranslation
                {
                    Id = 10,
                    SectionItemSettingId = 10,
                    LanguageId = 1, // Türkçe
                    Title = "Slayt",
                    Description = "Carousel slaytı",
                    CreatedAt = new DateTime(2024, 10, 21, 10, 0, 0),
                    Status = Status.Active,
                    IsDeleted = false
                },
                // English (ID = 2)
                new SectionItemSettingTranslation
                {
                    Id = 11,
                    SectionItemSettingId = 10,
                    LanguageId = 2, // English
                    Title = "Slide",
                    Description = "Carousel slide",
                    CreatedAt = new DateTime(2024, 10, 21, 10, 0, 0),
                    Status = Status.Active,
                    IsDeleted = false
                }
            );
        }

        private void SeedDefaultSettingTranslations(EntityTypeBuilder<SectionItemSettingTranslation> builder)
        {
            // Default Content Item Configuration Translations (SettingId: 20)
            builder.HasData(
                // Turkish (ID = 1)
                new SectionItemSettingTranslation
                {
                    Id = 20,
                    SectionItemSettingId = 20,
                    LanguageId = 1, // Türkçe
                    Title = "İçerik Öğesi",
                    Description = "Genel içerik öğesi",
                    CreatedAt = new DateTime(2024, 10, 21, 10, 0, 0),
                    Status = Status.Active,
                    IsDeleted = false
                },
                // English (ID = 2)
                new SectionItemSettingTranslation
                {
                    Id = 21,
                    SectionItemSettingId = 20,
                    LanguageId = 2, // English
                    Title = "Content Item",
                    Description = "General content item",
                    CreatedAt = new DateTime(2024, 10, 21, 10, 0, 0),
                    Status = Status.Active,
                    IsDeleted = false
                }
            );
        }

        private void SeedNavbarMegaMenuSettingTranslations(EntityTypeBuilder<SectionItemSettingTranslation> builder)
        {
            builder.HasData(
                // Mega Menu Category (SettingId: 30)
                new SectionItemSettingTranslation { Id = 300, SectionItemSettingId = 30, LanguageId = 1, Title = "Mega Menü Kategorisi", Description = "Geniş açılır menü kategorisi", CreatedAt = new DateTime(2024, 10, 21, 10, 0, 0), Status = Status.Active, IsDeleted = false },
                new SectionItemSettingTranslation { Id = 301, SectionItemSettingId = 30, LanguageId = 2, Title = "Mega Menu Category", Description = "Large dropdown menu category", CreatedAt = new DateTime(2024, 10, 21, 10, 0, 0), Status = Status.Active, IsDeleted = false },
                // Mega Menu Link (SettingId: 31)
                new SectionItemSettingTranslation { Id = 302, SectionItemSettingId = 31, LanguageId = 1, Title = "Mega Menü Linki", Description = "Kategori içindeki bağlantı", CreatedAt = new DateTime(2024, 10, 21, 10, 0, 0), Status = Status.Active, IsDeleted = false },
                new SectionItemSettingTranslation { Id = 303, SectionItemSettingId = 31, LanguageId = 2, Title = "Mega Menu Link", Description = "Link within category", CreatedAt = new DateTime(2024, 10, 21, 10, 0, 0), Status = Status.Active, IsDeleted = false }
            );
        }

        private void SeedNavbarServiceTabsSettingTranslations(EntityTypeBuilder<SectionItemSettingTranslation> builder)
        {
            builder.HasData(
                // Service Tab (SettingId: 40)
                new SectionItemSettingTranslation { Id = 400, SectionItemSettingId = 40, LanguageId = 1, Title = "Hizmet Sekmesi", Description = "Hizmet navigasyon sekmesi", CreatedAt = new DateTime(2024, 10, 21, 10, 0, 0), Status = Status.Active, IsDeleted = false },
                new SectionItemSettingTranslation { Id = 401, SectionItemSettingId = 40, LanguageId = 2, Title = "Service Tab", Description = "Service navigation tab", CreatedAt = new DateTime(2024, 10, 21, 10, 0, 0), Status = Status.Active, IsDeleted = false }
            );
        }

        private void SeedNavbarCategorizedSettingTranslations(EntityTypeBuilder<SectionItemSettingTranslation> builder)
        {
            builder.HasData(
                // Category (SettingId: 50)
                new SectionItemSettingTranslation { Id = 500, SectionItemSettingId = 50, LanguageId = 1, Title = "Kategori", Description = "Menü kategorisi", CreatedAt = new DateTime(2024, 10, 21, 10, 0, 0), Status = Status.Active, IsDeleted = false },
                new SectionItemSettingTranslation { Id = 501, SectionItemSettingId = 50, LanguageId = 2, Title = "Category", Description = "Menu category", CreatedAt = new DateTime(2024, 10, 21, 10, 0, 0), Status = Status.Active, IsDeleted = false },
                // Category Item (SettingId: 51)
                new SectionItemSettingTranslation { Id = 502, SectionItemSettingId = 51, LanguageId = 1, Title = "Kategori Öğesi", Description = "Kategori altındaki öğe", CreatedAt = new DateTime(2024, 10, 21, 10, 0, 0), Status = Status.Active, IsDeleted = false },
                new SectionItemSettingTranslation { Id = 503, SectionItemSettingId = 51, LanguageId = 2, Title = "Category Item", Description = "Item under category", CreatedAt = new DateTime(2024, 10, 21, 10, 0, 0), Status = Status.Active, IsDeleted = false }
            );
        }

        private void SeedSequentialSettingTranslations(EntityTypeBuilder<SectionItemSettingTranslation> builder)
        {
            builder.HasData(
                // Sequential Step (SettingId: 60)
                new SectionItemSettingTranslation { Id = 600, SectionItemSettingId = 60, LanguageId = 1, Title = "Adım", Description = "Sıralı adım öğesi", CreatedAt = new DateTime(2024, 10, 21, 10, 0, 0), Status = Status.Active, IsDeleted = false },
                new SectionItemSettingTranslation { Id = 601, SectionItemSettingId = 60, LanguageId = 2, Title = "Step", Description = "Sequential step item", CreatedAt = new DateTime(2024, 10, 21, 10, 0, 0), Status = Status.Active, IsDeleted = false }
            );
        }

        private void SeedGridSettingTranslations(EntityTypeBuilder<SectionItemSettingTranslation> builder)
        {
            builder.HasData(
                // Grid Item (SettingId: 70)
                new SectionItemSettingTranslation { Id = 700, SectionItemSettingId = 70, LanguageId = 1, Title = "Grid Öğesi", Description = "Izgara düzeninde öğe", CreatedAt = new DateTime(2024, 10, 21, 10, 0, 0), Status = Status.Active, IsDeleted = false },
                new SectionItemSettingTranslation { Id = 701, SectionItemSettingId = 70, LanguageId = 2, Title = "Grid Item", Description = "Grid layout item", CreatedAt = new DateTime(2024, 10, 21, 10, 0, 0), Status = Status.Active, IsDeleted = false }
            );
        }

        private void SeedMasonrySettingTranslations(EntityTypeBuilder<SectionItemSettingTranslation> builder)
        {
            builder.HasData(
                // Masonry Image (SettingId: 80)
                new SectionItemSettingTranslation { Id = 800, SectionItemSettingId = 80, LanguageId = 1, Title = "Masonry Resim", Description = "Masonry galeri resmi", CreatedAt = new DateTime(2024, 10, 21, 10, 0, 0), Status = Status.Active, IsDeleted = false },
                new SectionItemSettingTranslation { Id = 801, SectionItemSettingId = 80, LanguageId = 2, Title = "Masonry Image", Description = "Masonry gallery image", CreatedAt = new DateTime(2024, 10, 21, 10, 0, 0), Status = Status.Active, IsDeleted = false }
            );
        }

        private void SeedListSettingTranslations(EntityTypeBuilder<SectionItemSettingTranslation> builder)
        {
            builder.HasData(
                // List Item (SettingId: 90)
                new SectionItemSettingTranslation { Id = 900, SectionItemSettingId = 90, LanguageId = 1, Title = "Liste Öğesi", Description = "Liste öğesi", CreatedAt = new DateTime(2024, 10, 21, 10, 0, 0), Status = Status.Active, IsDeleted = false },
                new SectionItemSettingTranslation { Id = 901, SectionItemSettingId = 90, LanguageId = 2, Title = "List Item", Description = "List item", CreatedAt = new DateTime(2024, 10, 21, 10, 0, 0), Status = Status.Active, IsDeleted = false }
            );
        }

        private void SeedSingleItemSettingTranslations(EntityTypeBuilder<SectionItemSettingTranslation> builder)
        {
            builder.HasData(
                // Single Item (SettingId: 101)
                new SectionItemSettingTranslation { Id = 1010, SectionItemSettingId = 101, LanguageId = 1, Title = "Tekli Öğe", Description = "Öne çıkan tek öğe", CreatedAt = new DateTime(2024, 10, 21, 10, 0, 0), Status = Status.Active, IsDeleted = false },
                new SectionItemSettingTranslation { Id = 1011, SectionItemSettingId = 101, LanguageId = 2, Title = "Single Item", Description = "Featured single item", CreatedAt = new DateTime(2024, 10, 21, 10, 0, 0), Status = Status.Active, IsDeleted = false }
            );
        }

        private void SeedMultiItemSettingTranslations(EntityTypeBuilder<SectionItemSettingTranslation> builder)
        {
            builder.HasData(
                // Multi Item (SettingId: 110)
                new SectionItemSettingTranslation { Id = 1100, SectionItemSettingId = 110, LanguageId = 1, Title = "Çoklu Öğe", Description = "Çoklu içerik öğesi", CreatedAt = new DateTime(2024, 10, 21, 10, 0, 0), Status = Status.Active, IsDeleted = false },
                new SectionItemSettingTranslation { Id = 1101, SectionItemSettingId = 110, LanguageId = 2, Title = "Multi Item", Description = "Multiple content item", CreatedAt = new DateTime(2024, 10, 21, 10, 0, 0), Status = Status.Active, IsDeleted = false }
            );
        }

        private void SeedAccordionSettingTranslations(EntityTypeBuilder<SectionItemSettingTranslation> builder)
        {
            builder.HasData(
                // Accordion Panel (SettingId: 120)
                new SectionItemSettingTranslation { Id = 1200, SectionItemSettingId = 120, LanguageId = 1, Title = "Akordeon Paneli", Description = "Genişletilebilir panel", CreatedAt = new DateTime(2024, 10, 21, 10, 0, 0), Status = Status.Active, IsDeleted = false },
                new SectionItemSettingTranslation { Id = 1201, SectionItemSettingId = 120, LanguageId = 2, Title = "Accordion Panel", Description = "Expandable panel", CreatedAt = new DateTime(2024, 10, 21, 10, 0, 0), Status = Status.Active, IsDeleted = false }
            );
        }

        private void SeedTabsSettingTranslations(EntityTypeBuilder<SectionItemSettingTranslation> builder)
        {
            builder.HasData(
                // Tab (SettingId: 130)
                new SectionItemSettingTranslation { Id = 1300, SectionItemSettingId = 130, LanguageId = 1, Title = "Sekme", Description = "İçerik sekmesi", CreatedAt = new DateTime(2024, 10, 21, 10, 0, 0), Status = Status.Active, IsDeleted = false },
                new SectionItemSettingTranslation { Id = 1301, SectionItemSettingId = 130, LanguageId = 2, Title = "Tab", Description = "Content tab", CreatedAt = new DateTime(2024, 10, 21, 10, 0, 0), Status = Status.Active, IsDeleted = false }
            );
        }
    }
}

