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
            builder.Property(p => p.ParentPageId).HasColumnName("ParentPageId");
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

            builder.HasMany(p => p.PageTranslations)
                   .WithOne(pt => pt.Page)
                   .HasForeignKey(pt => pt.PageId)
                   .OnDelete(DeleteBehavior.Cascade);

            // Self-referencing relationship for hierarchical structure
            builder.HasOne(p => p.ParentPage)
                   .WithMany(p => p.ChildPages)
                   .HasForeignKey(p => p.ParentPageId)
                   .OnDelete(DeleteBehavior.Restrict); // Prevent cascade delete to avoid cycles

            // Indexes
            builder.HasIndex(p => p.Code).IsUnique().HasDatabaseName("IX_Pages_Code");
            builder.HasIndex(p => p.PageType).HasDatabaseName("IX_Pages_PageType");
            builder.HasIndex(p => p.ParentPageId).HasDatabaseName("IX_Pages_ParentPageId");

            // Query Filter
            builder.HasQueryFilter(p => !p.IsDeleted);

            // Seed Data - Hierarchical structure
            builder.HasData(
                // Root Pages
                new Page
                {
                    Id = 1,
                    ContentId = 1,
                    ParentPageId = null, // Root page
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
                    ParentPageId = null, // Root page
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
                    ParentPageId = null, // Root page
                    PageType = PageType.Catalog,
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
                    ParentPageId = null, // Root page
                    PageType = PageType.Article,
                    Name = "Kurumsal",
                    Code = "corporate",
                    Description = "Kurumsal sayfalar",
                    CreatedAt = new DateTime(2024, 1, 4, 10, 0, 0),
                    Status = Status.Active,
                    IsDeleted = false
                },
                
                // Child Pages - Blog Categories
                new Page
                {
                    Id = 5,
                    ParentPageId = 2, // Child of Blog
                    PageType = PageType.Category,
                    Name = "Teknoloji",
                    Code = "blog-teknoloji",
                    Description = "Teknoloji ile ilgili blog yazıları",
                    CreatedAt = new DateTime(2024, 1, 5, 10, 0, 0),
                    Status = Status.Active,
                    IsDeleted = false
                },
                new Page
                {
                    Id = 6,
                    ParentPageId = 2, // Child of Blog
                    PageType = PageType.Category,
                    Name = "Tasarım",
                    Code = "blog-tasarim",
                    Description = "Tasarım ile ilgili blog yazıları",
                    CreatedAt = new DateTime(2024, 1, 6, 10, 0, 0),
                    Status = Status.Active,
                    IsDeleted = false
                },
                
                // Child Pages - Product Categories
                new Page
                {
                    Id = 7,
                    ParentPageId = 3, // Child of Products
                    PageType = PageType.Category,
                    Name = "Elektronik",
                    Code = "products-elektronik",
                    Description = "Elektronik ürünler kategorisi",
                    CreatedAt = new DateTime(2024, 1, 7, 10, 0, 0),
                    Status = Status.Active,
                    IsDeleted = false
                },
                new Page
                {
                    Id = 8,
                    ParentPageId = 3, // Child of Products
                    PageType = PageType.Category,
                    Name = "Giyim",
                    Code = "products-giyim",
                    Description = "Giyim ürünleri kategorisi",
                    CreatedAt = new DateTime(2024, 1, 8, 10, 0, 0),
                    Status = Status.Active,
                    IsDeleted = false
                },
                
                // Child Pages - Corporate
                new Page
                {
                    Id = 9,
                    ParentPageId = 4, // Child of Corporate
                    PageType = PageType.Article,
                    Name = "Hakkımızda",
                    Code = "about",
                    Description = "Şirket hakkında bilgi sayfası",
                    CreatedAt = new DateTime(2024, 1, 9, 10, 0, 0),
                    Status = Status.Active,
                    IsDeleted = false
                },
                new Page
                {
                    Id = 10,
                    ParentPageId = 4, // Child of Corporate
                    PageType = PageType.Article,
                    Name = "İletişim",
                    Code = "contact",
                    Description = "İletişim bilgileri ve form sayfası",
                    CreatedAt = new DateTime(2024, 1, 10, 10, 0, 0),
                    Status = Status.Active,
                    IsDeleted = false
                },
                
                // Sub-child Pages - Electronics subcategories
                new Page
                {
                    Id = 11,
                    ParentPageId = 7, // Child of Electronics
                    PageType = PageType.Category,
                    Name = "Bilgisayar",
                    Code = "products-elektronik-bilgisayar",
                    Description = "Bilgisayar ve aksesuarları",
                    CreatedAt = new DateTime(2024, 1, 11, 10, 0, 0),
                    Status = Status.Active,
                    IsDeleted = false
                },
                new Page
                {
                    Id = 12,
                    ParentPageId = 7, // Child of Electronics
                    PageType = PageType.Category,
                    Name = "Telefon",
                    Code = "products-elektronik-telefon",
                    Description = "Akıllı telefonlar ve aksesuarları",
                    CreatedAt = new DateTime(2024, 1, 12, 10, 0, 0),
                    Status = Status.Active,
                    IsDeleted = false
                }
            );
        }
    }
}
