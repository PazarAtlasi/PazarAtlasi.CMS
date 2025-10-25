using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PazarAtlasi.CMS.Domain.Entities.Content;
using PazarAtlasi.CMS.Domain.Common;

namespace PazarAtlasi.CMS.Persistence.EntityConfigurations.Content
{
    public class SectionItemTranslationConfiguration : IEntityTypeConfiguration<SectionItemTranslation>
    {
        public void Configure(EntityTypeBuilder<SectionItemTranslation> builder)
        {
            builder.ToTable("SectionItemTranslations").HasKey(sit => sit.Id);

            builder.Property(sit => sit.Id).HasColumnName("Id").IsRequired();
            builder.Property(sit => sit.SectionItemId).HasColumnName("SectionItemId").IsRequired();
            builder.Property(sit => sit.LanguageId).HasColumnName("LanguageId").IsRequired();
            builder.Property(sit => sit.Title).HasColumnName("Name").IsRequired().HasMaxLength(200);
            builder.Property(sit => sit.Title).HasColumnName("Title").HasMaxLength(300);
            builder.Property(sit => sit.Description).HasColumnName("Description").HasMaxLength(1000);
            builder.Property(sit => sit.CreatedAt).HasColumnName("CreatedAt").IsRequired();
            builder.Property(sit => sit.UpdatedAt).HasColumnName("UpdatedAt");
            builder.Property(sit => sit.IsDeleted).HasColumnName("IsDeleted").HasDefaultValue(false);
            builder.Property(sit => sit.Status).HasColumnName("Status").HasDefaultValue(Status.Draft);
            builder.Property(sit => sit.CreatedBy).HasColumnName("CreatedBy");
            builder.Property(sit => sit.UpdatedBy).HasColumnName("UpdatedBy");

            // Relationships
            builder.HasOne(sit => sit.SectionItem)
                   .WithMany(si => si.Translations)
                   .HasForeignKey(sit => sit.SectionItemId)
                   .OnDelete(DeleteBehavior.Cascade);

            // Indexes
            builder.HasIndex(sit => new { sit.SectionItemId, sit.LanguageId })
                   .IsUnique()
                   .HasDatabaseName("IX_SectionItemTranslations_SectionItemId_LanguageId");

            // Query Filter
            builder.HasQueryFilter(sit => !sit.IsDeleted);

            // Seed Data
            builder.HasData(
                // Hero Title Translations
                new SectionItemTranslation
                {
                    Id = 1,
                    SectionItemId = 1, // hero-title
                    LanguageId = 1, // Türkçe
                    Title = "Pazar Atlası'na Hoş Geldiniz",
                    Description = "En kaliteli ürünleri keşfedin",
                    CreatedAt = new DateTime(2024, 1, 1, 10, 0, 0),
                    Status = Status.Active,
                    IsDeleted = false
                },
                new SectionItemTranslation
                {
                    Id = 2,
                    SectionItemId = 1, // hero-title
                    LanguageId = 2, // İngilizce
                    Title = "Welcome to Pazar Atlası",
                    Description = "Discover the highest quality products",
                    CreatedAt = new DateTime(2024, 1, 1, 10, 0, 0),
                    Status = Status.Active,
                    IsDeleted = false
                },
                // Hero Subtitle Translations
                new SectionItemTranslation
                {
                    Id = 3,
                    SectionItemId = 2, // hero-subtitle
                    LanguageId = 1, // Türkçe
                    Title = "Kalite ve Güvenin Adresi",
                    Description = "Binlerce ürün arasından size en uygun olanları bulun. Hızlı teslimat, güvenli ödeme ve mükemmel müşteri hizmetiyle yanınızdayız.",
                    CreatedAt = new DateTime(2024, 1, 1, 10, 0, 0),
                    Status = Status.Active,
                    IsDeleted = false
                },
                new SectionItemTranslation
                {
                    Id = 4,
                    SectionItemId = 2, // hero-subtitle
                    LanguageId = 2, // İngilizce
                    Title = "Address of Quality and Trust",
                    Description = "Find the most suitable products for you among thousands of products. We are with you with fast delivery, secure payment and excellent customer service.",
                    CreatedAt = new DateTime(2024, 1, 1, 10, 0, 0),
                    Status = Status.Active,
                    IsDeleted = false
                },
                // Hero CTA Button Translations
                new SectionItemTranslation
                {
                    Id = 5,
                    SectionItemId = 3, // hero-cta-button
                    LanguageId = 1, // Türkçe
                    Title = "Ürünleri Keşfet",
                    Description = "Tüm ürünleri görüntülemek için tıklayın",
                    CreatedAt = new DateTime(2024, 1, 1, 10, 0, 0),
                    Status = Status.Active,
                    IsDeleted = false
                },
                new SectionItemTranslation
                {
                    Id = 6,
                    SectionItemId = 3, // hero-cta-button
                    LanguageId = 2, // İngilizce
                    Title = "Explore Products",
                    Description = "Click to view all products",
                    CreatedAt = new DateTime(2024, 1, 1, 10, 0, 0),
                    Status = Status.Active,
                    IsDeleted = false
                },
                // Featured Product 1 Translations
                new SectionItemTranslation
                {
                    Id = 7,
                    SectionItemId = 4, // featured-product-1
                    LanguageId = 1, // Türkçe
                    Title = "Premium Laptop",
                    Description = "Yüksek performanslı, şık tasarımlı laptop",
                    CreatedAt = new DateTime(2024, 1, 1, 10, 0, 0),
                    Status = Status.Active,
                    IsDeleted = false
                },
                new SectionItemTranslation
                {
                    Id = 8,
                    SectionItemId = 4, // featured-product-1
                    LanguageId = 2, // İngilizce
                    Title = "Premium Laptop",
                    Description = "High performance, stylish design laptop",
                    CreatedAt = new DateTime(2024, 1, 1, 10, 0, 0),
                    Status = Status.Active,
                    IsDeleted = false
                },
                // Newsletter Title Translations
                new SectionItemTranslation
                {
                    Id = 9,
                    SectionItemId = 7, // newsletter-title
                    LanguageId = 1, // Türkçe
                    Title = "Haberdar Olun",
                    Description = "Yeni ürünler ve kampanyalardan haberdar olmak için e-posta listemize katılın",
                    CreatedAt = new DateTime(2024, 1, 1, 10, 0, 0),
                    Status = Status.Active,
                    IsDeleted = false
                },
                new SectionItemTranslation
                {
                    Id = 10,
                    SectionItemId = 7, // newsletter-title
                    LanguageId = 2, // İngilizce
                    Title = "Stay Informed",
                    Description = "Join our email list to stay informed about new products and campaigns",
                    CreatedAt = new DateTime(2024, 1, 1, 10, 0, 0),
                    Status = Status.Active,
                    IsDeleted = false
                },
                // Blog Title Translations
                new SectionItemTranslation
                {
                    Id = 11,
                    SectionItemId = 9, // blog-title
                    LanguageId = 1, // Türkçe
                    Title = "Blog Yazıları",
                    Description = "En güncel haberler ve makaleler",
                    CreatedAt = new DateTime(2024, 1, 2, 10, 0, 0),
                    Status = Status.Active,
                    IsDeleted = false
                },
                new SectionItemTranslation
                {
                    Id = 12,
                    SectionItemId = 9, // blog-title
                    LanguageId = 2, // İngilizce
                    Title = "Blog Posts",
                    Description = "Latest news and articles",
                    CreatedAt = new DateTime(2024, 1, 2, 10, 0, 0),
                    Status = Status.Active,
                    IsDeleted = false
                }
            );
        }
    }
}
