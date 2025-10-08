using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PazarAtlasi.CMS.Domain.Entities.Content;
using PazarAtlasi.CMS.Domain.Common;

namespace PazarAtlasi.CMS.Persistence.EntityConfigurations.Content
{
    public class SectionTranslationConfiguration : IEntityTypeConfiguration<SectionTranslation>
    {
        public void Configure(EntityTypeBuilder<SectionTranslation> builder)
        {
            builder.ToTable("SectionTranslations").HasKey(st => st.Id);

            builder.Property(st => st.Id).HasColumnName("Id").IsRequired();
            builder.Property(st => st.SectionId).HasColumnName("SectionId").IsRequired();
            builder.Property(st => st.LanguageId).HasColumnName("LanguageId").IsRequired();
            builder.Property(st => st.Name).HasColumnName("Name").IsRequired().HasMaxLength(200);
            builder.Property(st => st.Title).HasColumnName("Title").HasMaxLength(300);
            builder.Property(st => st.Description).HasColumnName("Description").HasMaxLength(1000);
            builder.Property(st => st.CreatedAt).HasColumnName("CreatedAt").IsRequired();
            builder.Property(st => st.UpdatedAt).HasColumnName("UpdatedAt");
            builder.Property(st => st.IsDeleted).HasColumnName("IsDeleted").HasDefaultValue(false);
            builder.Property(st => st.Status).HasColumnName("Status").HasDefaultValue(Status.Draft);
            builder.Property(st => st.CreatedBy).HasColumnName("CreatedBy");
            builder.Property(st => st.UpdatedBy).HasColumnName("UpdatedBy");

            // Relationships
            builder.HasOne(st => st.Section)
                   .WithMany(s => s.Translations)
                   .HasForeignKey(st => st.SectionId)
                   .OnDelete(DeleteBehavior.Cascade);

            // Indexes
            builder.HasIndex(st => new { st.SectionId, st.LanguageId })
                   .IsUnique()
                   .HasDatabaseName("IX_SectionTranslations_SectionId_LanguageId");

            // Query Filter
            builder.HasQueryFilter(st => !st.IsDeleted);

            // Seed Data
            builder.HasData(
                // Hero Section Translations
                new SectionTranslation
                {
                    Id = 1,
                    SectionId = 1, // hero-section
                    LanguageId = 1, // Türkçe
                    Name = "Ana Banner",
                    Title = "Ana Sayfa Hero Bölümü",
                    Description = "Web sitesinin ana sayfasındaki büyük banner alanı",
                    CreatedAt = new DateTime(2024, 1, 1, 10, 0, 0),
                    Status = Status.Active,
                    IsDeleted = false
                },
                new SectionTranslation
                {
                    Id = 2,
                    SectionId = 1, // hero-section
                    LanguageId = 2, // İngilizce
                    Name = "Main Banner",
                    Title = "Homepage Hero Section",
                    Description = "Large banner area on the homepage of the website",
                    CreatedAt = new DateTime(2024, 1, 1, 10, 0, 0),
                    Status = Status.Active,
                    IsDeleted = false
                },
                // Featured Products Section Translations
                new SectionTranslation
                {
                    Id = 3,
                    SectionId = 2, // featured-products
                    LanguageId = 1, // Türkçe
                    Name = "Öne Çıkan Ürünler",
                    Title = "Öne Çıkan Ürünler Bölümü",
                    Description = "Seçili ve popüler ürünlerin sergilendiği alan",
                    CreatedAt = new DateTime(2024, 1, 1, 10, 0, 0),
                    Status = Status.Active,
                    IsDeleted = false
                },
                new SectionTranslation
                {
                    Id = 4,
                    SectionId = 2, // featured-products
                    LanguageId = 2, // İngilizce
                    Name = "Featured Products",
                    Title = "Featured Products Section",
                    Description = "Area where selected and popular products are displayed",
                    CreatedAt = new DateTime(2024, 1, 1, 10, 0, 0),
                    Status = Status.Active,
                    IsDeleted = false
                },
                // Newsletter Section Translations
                new SectionTranslation
                {
                    Id = 5,
                    SectionId = 3, // newsletter
                    LanguageId = 1, // Türkçe
                    Name = "E-posta Bülteni",
                    Title = "E-posta Bülteni Kayıt Bölümü",
                    Description = "Kullanıcıların e-posta listesine kaydolabileceği alan",
                    CreatedAt = new DateTime(2024, 1, 1, 10, 0, 0),
                    Status = Status.Active,
                    IsDeleted = false
                },
                new SectionTranslation
                {
                    Id = 6,
                    SectionId = 3, // newsletter
                    LanguageId = 2, // İngilizce
                    Name = "Email Newsletter",
                    Title = "Email Newsletter Registration Section",
                    Description = "Area where users can register to the email list",
                    CreatedAt = new DateTime(2024, 1, 1, 10, 0, 0),
                    Status = Status.Active,
                    IsDeleted = false
                },
                // Blog Header Section Translations
                new SectionTranslation
                {
                    Id = 7,
                    SectionId = 4, // blog-header
                    LanguageId = 1, // Türkçe
                    Name = "Blog Başlığı",
                    Title = "Blog Sayfa Başlığı",
                    Description = "Blog sayfasının üst kısmındaki başlık alanı",
                    CreatedAt = new DateTime(2024, 1, 2, 10, 0, 0),
                    Status = Status.Active,
                    IsDeleted = false
                },
                new SectionTranslation
                {
                    Id = 8,
                    SectionId = 4, // blog-header
                    LanguageId = 2, // İngilizce
                    Name = "Blog Header",
                    Title = "Blog Page Header",
                    Description = "Header area at the top of the blog page",
                    CreatedAt = new DateTime(2024, 1, 2, 10, 0, 0),
                    Status = Status.Active,
                    IsDeleted = false
                },
                // Blog Content Section Translations
                new SectionTranslation
                {
                    Id = 9,
                    SectionId = 5, // blog-content
                    LanguageId = 1, // Türkçe
                    Name = "Blog İçeriği",
                    Title = "Blog Yazıları Listesi",
                    Description = "Blog yazılarının listelendiği ana içerik alanı",
                    CreatedAt = new DateTime(2024, 1, 2, 10, 0, 0),
                    Status = Status.Active,
                    IsDeleted = false
                },
                new SectionTranslation
                {
                    Id = 10,
                    SectionId = 5, // blog-content
                    LanguageId = 2, // İngilizce
                    Name = "Blog Content",
                    Title = "Blog Posts List",
                    Description = "Main content area where blog posts are listed",
                    CreatedAt = new DateTime(2024, 1, 2, 10, 0, 0),
                    Status = Status.Active,
                    IsDeleted = false
                },
                // Product Catalog Section Translations
                new SectionTranslation
                {
                    Id = 11,
                    SectionId = 6, // product-catalog
                    LanguageId = 1, // Türkçe
                    Name = "Ürün Kataloğu",
                    Title = "Ürün Katalog Listesi",
                    Description = "Tüm ürünlerin kategorize edilmiş şekilde listelendiği alan",
                    CreatedAt = new DateTime(2024, 1, 3, 10, 0, 0),
                    Status = Status.Active,
                    IsDeleted = false
                },
                new SectionTranslation
                {
                    Id = 12,
                    SectionId = 6, // product-catalog
                    LanguageId = 2, // İngilizce
                    Name = "Product Catalog",
                    Title = "Product Catalog List",
                    Description = "Area where all products are listed in a categorized manner",
                    CreatedAt = new DateTime(2024, 1, 3, 10, 0, 0),
                    Status = Status.Active,
                    IsDeleted = false
                }
            );
        }
    }
}
