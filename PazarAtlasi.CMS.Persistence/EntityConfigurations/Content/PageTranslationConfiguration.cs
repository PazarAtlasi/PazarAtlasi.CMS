using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PazarAtlasi.CMS.Domain.Entities.Content;
using PazarAtlasi.CMS.Domain.Common;

namespace PazarAtlasi.CMS.Persistence.EntityConfigurations.Content
{
    public class PageTranslationConfiguration : IEntityTypeConfiguration<PageTranslation>
    {
        public void Configure(EntityTypeBuilder<PageTranslation> builder)
        {
            builder.ToTable("PageTranslations").HasKey(pt => pt.Id);

            builder.Property(pt => pt.Id).HasColumnName("Id").IsRequired();
            builder.Property(pt => pt.PageId).HasColumnName("PageId").IsRequired();
            builder.Property(pt => pt.LanguageId).HasColumnName("LanguageId").IsRequired();
            builder.Property(pt => pt.Value).HasColumnName("Value").IsRequired().HasMaxLength(2000);
            builder.Property(pt => pt.CreatedAt).HasColumnName("CreatedAt").IsRequired();
            builder.Property(pt => pt.UpdatedAt).HasColumnName("UpdatedAt");
            builder.Property(pt => pt.IsDeleted).HasColumnName("IsDeleted").HasDefaultValue(false);
            builder.Property(pt => pt.Status).HasColumnName("Status").HasDefaultValue(Status.Draft);
            builder.Property(pt => pt.CreatedBy).HasColumnName("CreatedBy");
            builder.Property(pt => pt.UpdatedBy).HasColumnName("UpdatedBy");

            // Relationships
            builder.HasOne(pt => pt.Page)
                   .WithMany(p => p.PageTranslations)
                   .HasForeignKey(pt => pt.PageId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(pt => pt.Language)
                   .WithMany()
                   .HasForeignKey(pt => pt.LanguageId)
                   .OnDelete(DeleteBehavior.Restrict);

            // Indexes
            builder.HasIndex(pt => new { pt.PageId, pt.LanguageId })
                   .IsUnique()
                   .HasDatabaseName("IX_PageTranslations_PageId_LanguageId");

            // Query Filter
            builder.HasQueryFilter(pt => !pt.IsDeleted);

            // Seed Data
            builder.HasData(
                // Ana Sayfa Çevirileri
                new PageTranslation
                {
                    Id = 1,
                    PageId = 1,
                    LanguageId = 1, // Türkçe
                    Value = "Ana Sayfa",
                    CreatedAt = new DateTime(2024, 1, 1, 10, 0, 0),
                    Status = Status.Active,
                    IsDeleted = false
                },
                new PageTranslation
                {
                    Id = 2,
                    PageId = 1,
                    LanguageId = 2, // İngilizce
                    Value = "Home Page",
                    CreatedAt = new DateTime(2024, 1, 1, 10, 0, 0),
                    Status = Status.Active,
                    IsDeleted = false
                },
                // Blog Çevirileri
                new PageTranslation
                {
                    Id = 3,
                    PageId = 2,
                    LanguageId = 1, // Türkçe
                    Value = "Blog",
                    CreatedAt = new DateTime(2024, 1, 2, 10, 0, 0),
                    Status = Status.Active,
                    IsDeleted = false
                },
                new PageTranslation
                {
                    Id = 4,
                    PageId = 2,
                    LanguageId = 2, // İngilizce
                    Value = "Blog",
                    CreatedAt = new DateTime(2024, 1, 2, 10, 0, 0),
                    Status = Status.Active,
                    IsDeleted = false
                },
                // Ürünler Çevirileri
                new PageTranslation
                {
                    Id = 5,
                    PageId = 3,
                    LanguageId = 1, // Türkçe
                    Value = "Ürünler",
                    CreatedAt = new DateTime(2024, 1, 3, 10, 0, 0),
                    Status = Status.Active,
                    IsDeleted = false
                },
                new PageTranslation
                {
                    Id = 6,
                    PageId = 3,
                    LanguageId = 2, // İngilizce
                    Value = "Products",
                    CreatedAt = new DateTime(2024, 1, 3, 10, 0, 0),
                    Status = Status.Active,
                    IsDeleted = false
                },
                // Hakkımızda Çevirileri
                new PageTranslation
                {
                    Id = 7,
                    PageId = 4,
                    LanguageId = 1, // Türkçe
                    Value = "Hakkımızda",
                    CreatedAt = new DateTime(2024, 1, 4, 10, 0, 0),
                    Status = Status.Active,
                    IsDeleted = false
                },
                new PageTranslation
                {
                    Id = 8,
                    PageId = 4,
                    LanguageId = 2, // İngilizce
                    Value = "About Us",
                    CreatedAt = new DateTime(2024, 1, 4, 10, 0, 0),
                    Status = Status.Active,
                    IsDeleted = false
                }
            );
        }
    }
}
