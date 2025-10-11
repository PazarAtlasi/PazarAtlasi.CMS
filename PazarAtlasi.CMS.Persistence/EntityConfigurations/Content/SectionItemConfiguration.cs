using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PazarAtlasi.CMS.Domain.Entities.Content;
using PazarAtlasi.CMS.Domain.Common;

namespace PazarAtlasi.CMS.Persistence.EntityConfigurations.Content
{
    public class SectionItemConfiguration : IEntityTypeConfiguration<SectionItem>
    {
        public void Configure(EntityTypeBuilder<SectionItem> builder)
        {
            builder.ToTable("SectionItems").HasKey(si => si.Id);

            builder.Property(si => si.Id).HasColumnName("Id").IsRequired();
            builder.Property(si => si.SectionId).HasColumnName("SectionId").IsRequired();
            builder.Property(si => si.Code).HasColumnName("Code").HasMaxLength(100);
            builder.Property(si => si.Type).HasColumnName("Type").HasDefaultValue(SectionItemType.None);
            builder.Property(si => si.MediaType).HasColumnName("MediaType").HasDefaultValue(MediaType.None);
            builder.Property(si => si.PictureUrl).HasColumnName("PictureUrl").HasMaxLength(500);
            builder.Property(si => si.VideoUrl).HasColumnName("VideoUrl").HasMaxLength(500);
            builder.Property(si => si.RedirectUrl).HasColumnName("RedirectUrl").HasMaxLength(500);
            builder.Property(si => si.Icon).HasColumnName("Icon").HasMaxLength(100);
            builder.Property(si => si.SortOrder).HasColumnName("SortOrder").HasDefaultValue(0);
            builder.Property(si => si.MediaAttributes).HasColumnName("MediaAttributes").HasColumnType("nvarchar(max)");
            builder.Property(si => si.CreatedAt).HasColumnName("CreatedAt").IsRequired();
            builder.Property(si => si.UpdatedAt).HasColumnName("UpdatedAt");
            builder.Property(si => si.IsDeleted).HasColumnName("IsDeleted").HasDefaultValue(false);
            builder.Property(si => si.Status).HasColumnName("Status").HasDefaultValue(Status.Draft);
            builder.Property(si => si.CreatedBy).HasColumnName("CreatedBy");
            builder.Property(si => si.UpdatedBy).HasColumnName("UpdatedBy");

            // Relationships
            builder.HasOne(si => si.Section)
                   .WithMany(s => s.SectionItems)
                   .HasForeignKey(si => si.SectionId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(si => si.Translations)
                   .WithOne(sit => sit.SectionItem)
                   .HasForeignKey(sit => sit.SectionItemId)
                   .OnDelete(DeleteBehavior.Cascade);

            // Indexes
            builder.HasIndex(si => new { si.SectionId, si.SortOrder }).HasDatabaseName("IX_SectionItems_SectionId_SortOrder");
            builder.HasIndex(si => si.Code).HasDatabaseName("IX_SectionItems_Code");
            builder.HasIndex(si => si.Type).HasDatabaseName("IX_SectionItems_Type");

            // Query Filter
            builder.HasQueryFilter(si => !si.IsDeleted);

            // Seed Data
            builder.HasData(
                // Hero Section Items
                new SectionItem
                {
                    Id = 1,
                    SectionId = 1, // hero-section
                    Code = "hero-title",
                    Type = SectionItemType.Text,
                    SortOrder = 1,
                    CreatedAt = new DateTime(2024, 1, 1, 10, 0, 0),
                    Status = Status.Active,
                    IsDeleted = false
                },
                new SectionItem
                {
                    Id = 2,
                    SectionId = 1, // hero-section
                    Code = "hero-subtitle",
                    Type = SectionItemType.Paragraph,
                    SortOrder = 2,
                    CreatedAt = new DateTime(2024, 1, 1, 10, 0, 0),
                    Status = Status.Active,
                    IsDeleted = false
                },
                new SectionItem
                {
                    Id = 3,
                    SectionId = 1, // hero-section
                    Code = "hero-cta-button",
                    Type = SectionItemType.Button,
                    RedirectUrl = "/products",
                    SortOrder = 3,
                    CreatedAt = new DateTime(2024, 1, 1, 10, 0, 0),
                    Status = Status.Active,
                    IsDeleted = false
                },
                // Featured Products Section Items
                new SectionItem
                {
                    Id = 4,
                    SectionId = 2, // featured-products
                    Code = "featured-product-1",
                    Type = SectionItemType.Picture,
                    PictureUrl = "/images/products/product1.jpg",
                    RedirectUrl = "/products/1",
                    SortOrder = 1,
                    CreatedAt = new DateTime(2024, 1, 1, 10, 0, 0),
                    Status = Status.Active,
                    IsDeleted = false
                },
                new SectionItem
                {
                    Id = 5,
                    SectionId = 2, // featured-products
                    Code = "featured-product-2",
                    Type = SectionItemType.Picture,
                    PictureUrl = "/images/products/product2.jpg",
                    RedirectUrl = "/products/2",
                    SortOrder = 2,
                    CreatedAt = new DateTime(2024, 1, 1, 10, 0, 0),
                    Status = Status.Active,
                    IsDeleted = false
                },
                new SectionItem
                {
                    Id = 6,
                    SectionId = 2, // featured-products
                    Code = "featured-product-3",
                    Type = SectionItemType.Picture,
                    PictureUrl = "/images/products/product3.jpg",
                    RedirectUrl = "/products/3",
                    SortOrder = 3,
                    CreatedAt = new DateTime(2024, 1, 1, 10, 0, 0),
                    Status = Status.Active,
                    IsDeleted = false
                },
                // Newsletter Section Items
                new SectionItem
                {
                    Id = 7,
                    SectionId = 3, // newsletter
                    Code = "newsletter-title",
                    Type = SectionItemType.Text,
                    SortOrder = 1,
                    CreatedAt = new DateTime(2024, 1, 1, 10, 0, 0),
                    Status = Status.Active,
                    IsDeleted = false
                },
                new SectionItem
                {
                    Id = 8,
                    SectionId = 3, // newsletter
                    Code = "newsletter-form",
                    Type = SectionItemType.Form,
                    SortOrder = 2,
                    CreatedAt = new DateTime(2024, 1, 1, 10, 0, 0),
                    Status = Status.Active,
                    IsDeleted = false
                },
                // Blog Header Section Items
                new SectionItem
                {
                    Id = 9,
                    SectionId = 4, // blog-header
                    Code = "blog-title",
                    Type = SectionItemType.Text,
                    SortOrder = 1,
                    CreatedAt = new DateTime(2024, 1, 2, 10, 0, 0),
                    Status = Status.Active,
                    IsDeleted = false
                },
                new SectionItem
                {
                    Id = 10,
                    SectionId = 4, // blog-header
                    Code = "blog-search",
                    Type = SectionItemType.Search,
                    SortOrder = 2,
                    CreatedAt = new DateTime(2024, 1, 2, 10, 0, 0),
                    Status = Status.Active,
                    IsDeleted = false
                }
            );
        }
    }
}
