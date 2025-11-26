using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PazarAtlasi.CMS.Domain.Entities.Content;

namespace PazarAtlasi.CMS.Persistence.EntityConfigurations.Content
{
    public class ArticleTranslationConfiguration : IEntityTypeConfiguration<ArticleTranslation>
    {
        public void Configure(EntityTypeBuilder<ArticleTranslation> builder)
        {
            // Table name and primary key
            builder.ToTable("ArticleTranslations").HasKey(at => at.Id);

            // Properties
            builder.Property(at => at.Id).HasColumnName("Id").IsRequired();
            builder.Property(at => at.ArticleId).HasColumnName("ArticleId").IsRequired();
            builder.Property(at => at.LanguageId).HasColumnName("LanguageId").IsRequired();
            builder.Property(at => at.Title).HasColumnName("Title").HasMaxLength(200).IsRequired();
            builder.Property(at => at.Slug).HasColumnName("Slug").HasMaxLength(200).IsRequired();
            builder.Property(at => at.Summary).HasColumnName("Summary").HasMaxLength(500);
            builder.Property(at => at.Content).HasColumnName("Content").HasColumnType("nvarchar(max)");
            builder.Property(at => at.MetaTitle).HasColumnName("MetaTitle").HasMaxLength(200);
            builder.Property(at => at.CreatedAt).HasColumnName("CreatedAt").IsRequired();
            builder.Property(at => at.UpdatedAt).HasColumnName("UpdatedAt");
            builder.Property(at => at.IsDeleted).HasColumnName("IsDeleted").HasDefaultValue(false);

            // Relationships
            builder.HasOne(at => at.Article)
                   .WithMany(a => a.Translations)
                   .HasForeignKey(at => at.ArticleId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(at => at.Language)
                   .WithMany()
                   .HasForeignKey(at => at.LanguageId)
                   .OnDelete(DeleteBehavior.Restrict);

            // Indexes
            builder.HasIndex(at => new { at.ArticleId, at.LanguageId })
                   .HasDatabaseName("IX_ArticleTranslations_ArticleId_LanguageId")
                   .IsUnique();
            builder.HasIndex(at => at.Slug).HasDatabaseName("IX_ArticleTranslations_Slug");

            // Query Filter (Soft Delete)
            builder.HasQueryFilter(at => !at.IsDeleted);

            // Seed Data
            builder.HasData(
                // Article 1 - Turkish
                new ArticleTranslation
                {
                    Id = 1,
                    ArticleId = 1,
                    LanguageId = 1, // Turkish
                    Title = "PazarAtlası CMS'e Hoş Geldiniz",
                    Slug = "pazaratlasi-cms-hos-geldiniz",
                    Summary = "PazarAtlası CMS ile modern ve esnek içerik yönetimi deneyimine adım atın.",
                    Content = "<p>PazarAtlası CMS, modern içerik yönetim sistemlerinin gücünü Clean Architecture prensiplerine göre tasarlanmış bir platform ile birleştiriyor.</p><p>Bu sistemle sayfa, section ve içerik yönetimi artık çok daha kolay!</p>",
                    MetaTitle = "PazarAtlası CMS - Hoş Geldiniz",
                    CreatedAt = DateTime.UtcNow,
                    IsDeleted = false
                },
                // Article 1 - English
                new ArticleTranslation
                {
                    Id = 2,
                    ArticleId = 1,
                    LanguageId = 2, // English
                    Title = "Welcome to PazarAtlası CMS",
                    Slug = "welcome-to-pazaratlasi-cms",
                    Summary = "Experience modern and flexible content management with PazarAtlası CMS.",
                    Content = "<p>PazarAtlası CMS combines the power of modern content management systems with a platform designed according to Clean Architecture principles.</p><p>Managing pages, sections and content is now much easier with this system!</p>",
                    MetaTitle = "PazarAtlası CMS - Welcome",
                    CreatedAt = DateTime.UtcNow,
                    IsDeleted = false
                },
                // Article 2 - Turkish
                new ArticleTranslation
                {
                    Id = 3,
                    ArticleId = 2,
                    LanguageId = 1, // Turkish
                    Title = "Başlangıç Rehberi: İlk Sayfanızı Oluşturun",
                    Slug = "baslangic-rehberi-ilk-sayfanizi-olusturun",
                    Summary = "PazarAtlası CMS'te ilk sayfanızı oluşturmak için adım adım rehber.",
                    Content = "<p>Bu rehberde, PazarAtlası CMS'te ilk sayfanızı nasıl oluşturacağınızı öğreneceksiniz.</p><p>Section'ları ekleyip düzenleyerek profesyonel görünümlü sayfalar oluşturun.</p>",
                    MetaTitle = "Başlangıç Rehberi - PazarAtlası CMS",
                    CreatedAt = DateTime.UtcNow,
                    IsDeleted = false
                },
                // Article 2 - English
                new ArticleTranslation
                {
                    Id = 4,
                    ArticleId = 2,
                    LanguageId = 2, // English
                    Title = "Getting Started: Create Your First Page",
                    Slug = "getting-started-create-your-first-page",
                    Summary = "A step-by-step guide to creating your first page in PazarAtlası CMS.",
                    Content = "<p>In this guide, you'll learn how to create your first page in PazarAtlası CMS.</p><p>Create professional-looking pages by adding and editing sections.</p>",
                    MetaTitle = "Getting Started - PazarAtlası CMS",
                    CreatedAt = DateTime.UtcNow,
                    IsDeleted = false
                }
            );
        }
    }
}
