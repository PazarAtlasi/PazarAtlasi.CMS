using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PazarAtlasi.CMS.Domain.Entities.Content;

namespace PazarAtlasi.CMS.Persistence.EntityConfigurations.Content
{
    public class ArticleCategoryTranslationConfiguration : IEntityTypeConfiguration<ArticleCategoryTranslation>
    {
        public void Configure(EntityTypeBuilder<ArticleCategoryTranslation> builder)
        {
            // Table name and primary key
            builder.ToTable("ArticleCategoryTranslations").HasKey(act => act.Id);

            // Properties
            builder.Property(act => act.Id).HasColumnName("Id").IsRequired();
            builder.Property(act => act.ArticleCategoryId).HasColumnName("ArticleCategoryId").IsRequired();
            builder.Property(act => act.LanguageId).HasColumnName("LanguageId").IsRequired();
            builder.Property(act => act.Name).HasColumnName("Name").HasMaxLength(100).IsRequired();
            builder.Property(act => act.Description).HasColumnName("Description").HasMaxLength(500);
            builder.Property(act => act.Slug).HasColumnName("Slug").HasMaxLength(100);
            builder.Property(act => act.CreatedAt).HasColumnName("CreatedAt").IsRequired();
            builder.Property(act => act.UpdatedAt).HasColumnName("UpdatedAt");
            builder.Property(act => act.IsDeleted).HasColumnName("IsDeleted").HasDefaultValue(false);

            // Relationships
            builder.HasOne(act => act.ArticleCategory)
                   .WithMany(ac => ac.Translations)
                   .HasForeignKey(act => act.ArticleCategoryId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(act => act.Language)
                   .WithMany()
                   .HasForeignKey(act => act.LanguageId)
                   .OnDelete(DeleteBehavior.Restrict);

            // Indexes
            builder.HasIndex(act => new { act.ArticleCategoryId, act.LanguageId })
                   .HasDatabaseName("IX_ArticleCategoryTranslations_CategoryId_LanguageId")
                   .IsUnique();
            builder.HasIndex(act => act.Slug).HasDatabaseName("IX_ArticleCategoryTranslations_Slug");

            // Query Filter (Soft Delete)
            builder.HasQueryFilter(act => !act.IsDeleted);

            // Seed Data
            builder.HasData(
                // Category 1 - Turkish
                new ArticleCategoryTranslation
                {
                    Id = 1,
                    ArticleCategoryId = 1,
                    LanguageId = 1, // Turkish
                    Name = "Genel",
                    Description = "Genel haberler ve duyurular",
                    Slug = "genel",
                    CreatedAt = DateTime.UtcNow,
                    IsDeleted = false
                },
                // Category 1 - English
                new ArticleCategoryTranslation
                {
                    Id = 2,
                    ArticleCategoryId = 1,
                    LanguageId = 2, // English
                    Name = "General",
                    Description = "General news and announcements",
                    Slug = "general",
                    CreatedAt = DateTime.UtcNow,
                    IsDeleted = false
                },
                // Category 2 - Turkish
                new ArticleCategoryTranslation
                {
                    Id = 3,
                    ArticleCategoryId = 2,
                    LanguageId = 1, // Turkish
                    Name = "İpuçları",
                    Description = "Faydalı ipuçları ve öneriler",
                    Slug = "ipuclari",
                    CreatedAt = DateTime.UtcNow,
                    IsDeleted = false
                },
                // Category 2 - English
                new ArticleCategoryTranslation
                {
                    Id = 4,
                    ArticleCategoryId = 2,
                    LanguageId = 2, // English
                    Name = "Tips",
                    Description = "Useful tips and suggestions",
                    Slug = "tips",
                    CreatedAt = DateTime.UtcNow,
                    IsDeleted = false
                },
                // Category 3 - Turkish
                new ArticleCategoryTranslation
                {
                    Id = 5,
                    ArticleCategoryId = 3,
                    LanguageId = 1, // Turkish
                    Name = "Güncellemeler",
                    Description = "Sistem güncellemeleri ve yeni özellikler",
                    Slug = "guncellemeler",
                    CreatedAt = DateTime.UtcNow,
                    IsDeleted = false
                },
                // Category 3 - English
                new ArticleCategoryTranslation
                {
                    Id = 6,
                    ArticleCategoryId = 3,
                    LanguageId = 2, // English
                    Name = "Updates",
                    Description = "System updates and new features",
                    Slug = "updates",
                    CreatedAt = DateTime.UtcNow,
                    IsDeleted = false
                }
            );
        }
    }
}
