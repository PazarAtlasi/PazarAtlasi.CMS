using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PazarAtlasi.CMS.Domain.Entities.Content;

namespace PazarAtlasi.CMS.Persistence.EntityConfigurations.Content
{
    public class ContentSlugsConfiguration : IEntityTypeConfiguration<ContentSlugs>
    {
        public void Configure(EntityTypeBuilder<ContentSlugs> builder)
        {
            // Tablo adı ve primary key
            builder.ToTable("ContentSlugs").HasKey(cs => cs.Id);

            // Özellik konfigürasyonları
            builder.Property(cs => cs.Id).HasColumnName("Id").IsRequired();
            builder.Property(cs => cs.ContentId).HasColumnName("ContentId").IsRequired();
            builder.Property(cs => cs.Slug).HasColumnName("Slug").IsRequired().HasMaxLength(500);
            builder.Property(cs => cs.LanguageId).HasColumnName("LanguageId").IsRequired();
            builder.Property(cs => cs.Priority).HasColumnName("Priority");
            builder.Property(cs => cs.IsCanonical).HasColumnName("IsCanonical").HasDefaultValue(false);

            // İlişkiler
            builder.HasOne(cs => cs.Content)
                   .WithMany(c => c.ContentSlugs)
                   .HasForeignKey(cs => cs.ContentId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(cs => cs.Language)
                   .WithMany()
                   .HasForeignKey(cs => cs.LanguageId)
                   .OnDelete(DeleteBehavior.Restrict);

            // İndeksler
            builder.HasIndex(cs => cs.Slug)
                   .HasDatabaseName("IX_ContentSlugs_Slug");
            builder.HasIndex(cs => new { cs.ContentId, cs.LanguageId })
                   .HasDatabaseName("IX_ContentSlugs_ContentId_LanguageId");
            builder.HasIndex(cs => new { cs.Slug, cs.LanguageId })
                   .HasDatabaseName("IX_ContentSlugs_Slug_LanguageId")
                   .IsUnique(); // Aynı dilde aynı slug olamaz

            // Query Filter (Soft Delete)
            builder.HasQueryFilter(cs => !cs.IsDeleted);

            // Seed Data - Multi-language slugs for main pages
            builder.HasData(
                // Ana Sayfa slugs
                new ContentSlugs
                {
                    Id = 1,
                    ContentId = 1,
                    Slug = "ana-sayfa",
                    LanguageId = 1, // Türkçe
                    Priority = 1,
                    IsCanonical = true,
                    CreatedAt = new DateTime(2024, 1, 1, 10, 0, 0),
                    IsDeleted = false
                },
                new ContentSlugs
                {
                    Id = 2,
                    ContentId = 1,
                    Slug = "home",
                    LanguageId = 2, // İngilizce
                    Priority = 1,
                    IsCanonical = true,
                    CreatedAt = new DateTime(2024, 1, 1, 10, 0, 0),
                    IsDeleted = false
                },
                
                // Blog slugs
                new ContentSlugs
                {
                    Id = 3,
                    ContentId = 2,
                    Slug = "blog",
                    LanguageId = 1, // Türkçe
                    Priority = 1,
                    IsCanonical = true,
                    CreatedAt = new DateTime(2024, 1, 2, 10, 0, 0),
                    IsDeleted = false
                },
                new ContentSlugs
                {
                    Id = 4,
                    ContentId = 2,
                    Slug = "blog",
                    LanguageId = 2, // İngilizce
                    Priority = 1,
                    IsCanonical = true,
                    CreatedAt = new DateTime(2024, 1, 2, 10, 0, 0),
                    IsDeleted = false
                },
                
                // Ürünler slugs
                new ContentSlugs
                {
                    Id = 5,
                    ContentId = 3,
                    Slug = "urunler",
                    LanguageId = 1, // Türkçe
                    Priority = 1,
                    IsCanonical = true,
                    CreatedAt = new DateTime(2024, 1, 3, 10, 0, 0),
                    IsDeleted = false
                },
                new ContentSlugs
                {
                    Id = 6,
                    ContentId = 3,
                    Slug = "products",
                    LanguageId = 2, // İngilizce
                    Priority = 1,
                    IsCanonical = true,
                    CreatedAt = new DateTime(2024, 1, 3, 10, 0, 0),
                    IsDeleted = false
                },
                
                // Alternative slugs (lower priority)
                new ContentSlugs
                {
                    Id = 7,
                    ContentId = 1,
                    Slug = "anasayfa",
                    LanguageId = 1, // Türkçe alternative
                    Priority = 2,
                    IsCanonical = false,
                    CreatedAt = new DateTime(2024, 1, 1, 10, 0, 0),
                    IsDeleted = false
                },
                new ContentSlugs
                {
                    Id = 8,
                    ContentId = 3,
                    Slug = "katalog",
                    LanguageId = 1, // Türkçe alternative
                    Priority = 2,
                    IsCanonical = false,
                    CreatedAt = new DateTime(2024, 1, 3, 10, 0, 0),
                    IsDeleted = false
                }
            );
        }
    }
}