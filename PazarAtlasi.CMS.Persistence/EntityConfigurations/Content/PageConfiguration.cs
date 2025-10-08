using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PazarAtlasi.CMS.Domain.Entities.Content;
using PazarAtlasi.CMS.Domain.Common;

namespace PazarAtlasi.CMS.Persistence.EntityConfigurations.Content
{
    public class PageConfiguration : IEntityTypeConfiguration<Page>
    {
        public void Configure(EntityTypeBuilder<Page> builder)
        {
            builder.ToTable("Pages").HasKey(p => p.Id);

            builder.Property(p => p.Id).HasColumnName("Id").IsRequired();
            builder.Property(p => p.ContentId).HasColumnName("ContentId");
            builder.Property(p => p.PageSEOParameterId).HasColumnName("PageSEOParameterId");
            builder.Property(p => p.PageType).HasColumnName("PageType").HasDefaultValue(PageType.None);
            builder.Property(p => p.Name).HasColumnName("Name").HasMaxLength(200);
            builder.Property(p => p.Code).HasColumnName("Code").HasMaxLength(100);
            builder.Property(p => p.Description).HasColumnName("Description").HasMaxLength(1000);
            builder.Property(p => p.CreatedAt).HasColumnName("CreatedAt").IsRequired();
            builder.Property(p => p.UpdatedAt).HasColumnName("UpdatedAt");
            builder.Property(p => p.IsDeleted).HasColumnName("IsDeleted").HasDefaultValue(false);
            builder.Property(p => p.Status).HasColumnName("Status").HasDefaultValue(Status.Draft);
            builder.Property(p => p.CreatedBy).HasColumnName("CreatedBy");
            builder.Property(p => p.UpdatedBy).HasColumnName("UpdatedBy");

            // Relationships
            builder.HasOne(p => p.Content)
                   .WithMany(c => c.Pages)
                   .HasForeignKey(p => p.ContentId)
                   .OnDelete(DeleteBehavior.SetNull);

            builder.HasOne(p => p.PageSEOParameter)
                   .WithOne(seo => seo.Page)
                   .HasForeignKey<PageSEOParameter>(seo => seo.PageId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(p => p.Sections)
                   .WithOne(s => s.Page)
                   .HasForeignKey(s => s.PageId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(p => p.PageTranslations)
                   .WithOne(pt => pt.Page)
                   .HasForeignKey(pt => pt.PageId)
                   .OnDelete(DeleteBehavior.Cascade);

            // Indexes
            builder.HasIndex(p => p.Code).IsUnique().HasDatabaseName("IX_Pages_Code");
            builder.HasIndex(p => p.PageType).HasDatabaseName("IX_Pages_PageType");

            // Query Filter
            builder.HasQueryFilter(p => !p.IsDeleted);

            // Seed Data
            builder.HasData(
                new Page
                {
                    Id = 1,
                    ContentId = 1,
                    PageType = PageType.Home,
                    Name = "Ana Sayfa",
                    Code = "home",
                    Description = "Web sitesinin ana sayfası",
                    CreatedAt = new DateTime(2024, 1, 1, 10, 0, 0),
                    Status = Status.Active,
                    IsDeleted = false
                },
                new Page
                {
                    Id = 2,
                    ContentId = 2,
                    PageType = PageType.Blog,
                    Name = "Blog",
                    Code = "blog",
                    Description = "Blog yazıları sayfası",
                    CreatedAt = new DateTime(2024, 1, 2, 10, 0, 0),
                    Status = Status.Active,
                    IsDeleted = false
                },
                new Page
                {
                    Id = 3,
                    ContentId = 3,
                    PageType = PageType.Product,
                    Name = "Ürünler",
                    Code = "products",
                    Description = "Ürün katalog sayfası",
                    CreatedAt = new DateTime(2024, 1, 3, 10, 0, 0),
                    Status = Status.Active,
                    IsDeleted = false
                },
                new Page
                {
                    Id = 4,
                    PageType = PageType.Article,
                    Name = "Hakkımızda",
                    Code = "about",
                    Description = "Şirket hakkında bilgi sayfası",
                    CreatedAt = new DateTime(2024, 1, 4, 10, 0, 0),
                    Status = Status.Active,
                    IsDeleted = false
                },
                new Page
                {
                    Id = 5,
                    PageType = PageType.Article,
                    Name = "İletişim",
                    Code = "contact",
                    Description = "İletişim bilgileri ve form sayfası",
                    CreatedAt = new DateTime(2024, 1, 5, 10, 0, 0),
                    Status = Status.Active,
                    IsDeleted = false
                }
            );
        }
    }
}
