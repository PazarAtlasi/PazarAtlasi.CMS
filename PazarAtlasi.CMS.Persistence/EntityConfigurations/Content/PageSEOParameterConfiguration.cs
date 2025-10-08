using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PazarAtlasi.CMS.Domain.Entities.Content;
using PazarAtlasi.CMS.Domain.Common;

namespace PazarAtlasi.CMS.Persistence.EntityConfigurations.Content
{
    public class PageSEOParameterConfiguration : IEntityTypeConfiguration<PageSEOParameter>
    {
        public void Configure(EntityTypeBuilder<PageSEOParameter> builder)
        {
            builder.ToTable("PageSEOParameters").HasKey(seo => seo.Id);

            builder.Property(seo => seo.Id).HasColumnName("Id").IsRequired();
            builder.Property(seo => seo.PageId).HasColumnName("PageId").IsRequired();
            builder.Property(seo => seo.MetaTitle).HasColumnName("MetaTitle").HasMaxLength(200);
            builder.Property(seo => seo.MetaDescription).HasColumnName("MetaDescription").HasMaxLength(500);
            builder.Property(seo => seo.MetaKeywords).HasColumnName("MetaKeywords").HasMaxLength(300);
            builder.Property(seo => seo.SubDescription).HasColumnName("SubDescription").HasMaxLength(1000);
            builder.Property(seo => seo.Title).HasColumnName("Title").HasMaxLength(200);
            builder.Property(seo => seo.CanonicalURL).HasColumnName("CanonicalURL").HasMaxLength(500);
            builder.Property(seo => seo.Author).HasColumnName("Author").HasMaxLength(100);
            builder.Property(seo => seo.Description).HasColumnName("Description").HasMaxLength(1000);
            builder.Property(seo => seo.CreatedAt).HasColumnName("CreatedAt").IsRequired();
            builder.Property(seo => seo.UpdatedAt).HasColumnName("UpdatedAt");
            builder.Property(seo => seo.IsDeleted).HasColumnName("IsDeleted").HasDefaultValue(false);
            builder.Property(seo => seo.Status).HasColumnName("Status").HasDefaultValue(Status.Draft);
            builder.Property(seo => seo.CreatedBy).HasColumnName("CreatedBy");
            builder.Property(seo => seo.UpdatedBy).HasColumnName("UpdatedBy");

            // Relationships
            builder.HasOne(seo => seo.Page)
                   .WithOne(p => p.PageSEOParameter)
                   .HasForeignKey<PageSEOParameter>(seo => seo.PageId)
                   .OnDelete(DeleteBehavior.Cascade);

            // Indexes
            builder.HasIndex(seo => seo.PageId).IsUnique().HasDatabaseName("IX_PageSEOParameters_PageId");

            // Query Filter
            builder.HasQueryFilter(seo => !seo.IsDeleted);

            // Seed Data
            builder.HasData(
                new PageSEOParameter
                {
                    Id = 1,
                    PageId = 1,
                    MetaTitle = "Ana Sayfa - Pazar Atlası CMS",
                    MetaDescription = "Pazar Atlası CMS ana sayfası. Modern ve kullanıcı dostu içerik yönetim sistemi.",
                    MetaKeywords = "cms, içerik yönetimi, pazar atlası, web sitesi",
                    Title = "Ana Sayfa",
                    Description = "Web sitesinin ana sayfası için SEO parametreleri",
                    Author = "Pazar Atlası",
                    CanonicalURL = "https://www.pazaratlasi.com/",
                    CreatedAt = new DateTime(2024, 1, 1, 10, 0, 0),
                    Status = Status.Active,
                    IsDeleted = false
                },
                new PageSEOParameter
                {
                    Id = 2,
                    PageId = 2,
                    MetaTitle = "Blog - Pazar Atlası CMS",
                    MetaDescription = "Pazar Atlası blog yazıları. Teknoloji, pazarlama ve iş dünyasından güncel haberler.",
                    MetaKeywords = "blog, yazılar, teknoloji, pazarlama, iş",
                    Title = "Blog",
                    Description = "Blog sayfası için SEO parametreleri",
                    Author = "Pazar Atlası",
                    CanonicalURL = "https://www.pazaratlasi.com/blog",
                    CreatedAt = new DateTime(2024, 1, 2, 10, 0, 0),
                    Status = Status.Active,
                    IsDeleted = false
                },
                new PageSEOParameter
                {
                    Id = 3,
                    PageId = 3,
                    MetaTitle = "Ürünler - Pazar Atlası CMS",
                    MetaDescription = "Pazar Atlası ürün kataloğu. Kaliteli ve uygun fiyatlı ürünler.",
                    MetaKeywords = "ürünler, katalog, alışveriş, kalite",
                    Title = "Ürünler",
                    Description = "Ürün katalog sayfası için SEO parametreleri",
                    Author = "Pazar Atlası",
                    CanonicalURL = "https://www.pazaratlasi.com/products",
                    CreatedAt = new DateTime(2024, 1, 3, 10, 0, 0),
                    Status = Status.Active,
                    IsDeleted = false
                }
            );
        }
    }
}
