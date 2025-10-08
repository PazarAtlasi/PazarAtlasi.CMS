using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PazarAtlasi.CMS.Domain.Entities.Content;
using PazarAtlasi.CMS.Domain.Common;

namespace PazarAtlasi.CMS.Persistence.EntityConfigurations.Content
{
    public class SectionConfiguration : IEntityTypeConfiguration<Section>
    {
        public void Configure(EntityTypeBuilder<Section> builder)
        {
            builder.ToTable("Sections").HasKey(s => s.Id);

            builder.Property(s => s.Id).HasColumnName("Id").IsRequired();
            builder.Property(s => s.PageId).HasColumnName("PageId").IsRequired();
            builder.Property(s => s.Code).HasColumnName("Code").HasMaxLength(100);
            builder.Property(s => s.Type).HasColumnName("Type").HasDefaultValue(SectionType.None);
            builder.Property(s => s.TemplateType).HasColumnName("TemplateType").HasDefaultValue(TemplateType.None);
            builder.Property(s => s.Attributes).HasColumnName("Attributes").HasColumnType("nvarchar(max)");
            builder.Property(s => s.SortOrder).HasColumnName("SortOrder").HasDefaultValue(0);
            builder.Property(s => s.Configure).HasColumnName("Configure").HasColumnType("nvarchar(max)");
            builder.Property(s => s.CreatedAt).HasColumnName("CreatedAt").IsRequired();
            builder.Property(s => s.UpdatedAt).HasColumnName("UpdatedAt");
            builder.Property(s => s.IsDeleted).HasColumnName("IsDeleted").HasDefaultValue(false);
            builder.Property(s => s.Status).HasColumnName("Status").HasDefaultValue(Status.Draft);
            builder.Property(s => s.CreatedBy).HasColumnName("CreatedBy");
            builder.Property(s => s.UpdatedBy).HasColumnName("UpdatedBy");

            // Relationships
            builder.HasOne(s => s.Page)
                   .WithMany(p => p.Sections)
                   .HasForeignKey(s => s.PageId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(s => s.SectionItems)
                   .WithOne(si => si.Section)
                   .HasForeignKey(si => si.SectionId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(s => s.Translations)
                   .WithOne(st => st.Section)
                   .HasForeignKey(st => st.SectionId)
                   .OnDelete(DeleteBehavior.Cascade);

            // Indexes
            builder.HasIndex(s => new { s.PageId, s.SortOrder }).HasDatabaseName("IX_Sections_PageId_SortOrder");
            builder.HasIndex(s => s.Code).HasDatabaseName("IX_Sections_Code");
            builder.HasIndex(s => s.Type).HasDatabaseName("IX_Sections_Type");

            // Query Filter
            builder.HasQueryFilter(s => !s.IsDeleted);

            // Seed Data
            builder.HasData(
                // Ana Sayfa Sections
                new Section
                {
                    Id = 1,
                    PageId = 1,
                    Code = "hero-section",
                    Type = SectionType.Hero,
                    TemplateType = TemplateType.Default,
                    SortOrder = 1,
                    Attributes = "{\"backgroundImage\": \"hero-bg.jpg\", \"height\": \"500px\"}",
                    Configure = "{\"showButton\": true, \"buttonText\": \"Keşfet\"}",
                    CreatedAt = new DateTime(2024, 1, 1, 10, 0, 0),
                    Status = Status.Active,
                    IsDeleted = false
                },
                new Section
                {
                    Id = 2,
                    PageId = 1,
                    Code = "featured-products",
                    Type = SectionType.Featured,
                    TemplateType = TemplateType.Grid,
                    SortOrder = 2,
                    Attributes = "{\"columns\": 3}",
                    Configure = "{\"maxItems\": 6, \"showMore\": true, \"showPrices\": true}",
                    CreatedAt = new DateTime(2024, 1, 1, 10, 0, 0),
                    Status = Status.Active,
                    IsDeleted = false
                },
                new Section
                {
                    Id = 3,
                    PageId = 1,
                    Code = "newsletter",
                    Type = SectionType.Newsletter,
                    TemplateType = TemplateType.Default,
                    SortOrder = 3,
                    Attributes = "{\"backgroundColor\": \"#f8f9fa\"}",
                    Configure = "{\"showPrivacyText\": true}",
                    CreatedAt = new DateTime(2024, 1, 1, 10, 0, 0),
                    Status = Status.Active,
                    IsDeleted = false
                },
                // Blog Sayfası Sections
                new Section
                {
                    Id = 4,
                    PageId = 2,
                    Code = "blog-header",
                    Type = SectionType.Header,
                    TemplateType = TemplateType.Default,
                    SortOrder = 1,
                    Attributes = "{}",
                    Configure = "{\"showSearchBox\": true,\"showBreadcrumbs\": true}",
                    CreatedAt = new DateTime(2024, 1, 2, 10, 0, 0),
                    Status = Status.Active,
                    IsDeleted = false
                },
                new Section
                {
                    Id = 5,
                    PageId = 2,
                    Code = "blog-content",
                    Type = SectionType.MainContent,
                    TemplateType = TemplateType.List,
                    SortOrder = 2,
                    Attributes = "{}",
                    Configure = "{\"showExcerpt\": true, \"showAuthor\": true, \"showDate\": true,\"postsPerPage\": 10}",
                    CreatedAt = new DateTime(2024, 1, 2, 10, 0, 0),
                    Status = Status.Active,
                    IsDeleted = false
                },
                // Ürünler Sayfası Sections
                new Section
                {
                    Id = 6,
                    PageId = 3,
                    Code = "product-catalog",
                    Type = SectionType.Catalog,
                    TemplateType = TemplateType.Grid,
                    SortOrder = 1,
                    Attributes = "{\"columns\": 4}",
                    Configure = "{\"productsPerPage\": 20, \"showSorting\": true, \"showFilters\": true}",
                    CreatedAt = new DateTime(2024, 1, 3, 10, 0, 0),
                    Status = Status.Active,
                    IsDeleted = false
                }
            );
        }
    }
}
