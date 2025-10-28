using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PazarAtlasi.CMS.Domain.Entities.Content;
using PazarAtlasi.CMS.Domain.Common;

namespace PazarAtlasi.CMS.Persistence.EntityConfigurations.Content
{
    public class SectionConfigurationBuilder : IEntityTypeConfiguration<Section>
    {
        public void Configure(EntityTypeBuilder<Section> builder)
        {
            builder.ToTable("Sections").HasKey(s => s.Id);

            builder.Property(s => s.Id).HasColumnName("Id").IsRequired();
            builder.Property(s => s.Type).HasColumnName("Type").HasDefaultValue(SectionType.None);
            builder.Property(s => s.Key).HasColumnName("Key").HasMaxLength(100).IsRequired();
            builder.Property(s => s.Attributes).HasColumnName("Attributes").HasColumnType("nvarchar(max)");
            builder.Property(s => s.SortOrder).HasColumnName("SortOrder").HasDefaultValue(0);
            builder.Property(s => s.Configure).HasColumnName("Configure").HasColumnType("nvarchar(max)");
            builder.Property(s => s.CreatedAt).HasColumnName("CreatedAt").IsRequired();
            builder.Property(s => s.UpdatedAt).HasColumnName("UpdatedAt");
            builder.Property(s => s.IsDeleted).HasColumnName("IsDeleted").HasDefaultValue(false);
            builder.Property(s => s.Status).HasColumnName("Status").HasDefaultValue(Status.Draft);
            builder.Property(s => s.CreatedBy).HasColumnName("CreatedBy");
            builder.Property(s => s.UpdatedBy).HasColumnName("UpdatedBy");

            builder.HasMany(s => s.Translations)
                   .WithOne(st => st.Section)
                   .HasForeignKey(st => st.SectionId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(s => s.SectionItemValues)
                   .WithOne(siv => siv.Section)
                   .HasForeignKey(siv => siv.SectionId)
                   .OnDelete(DeleteBehavior.Cascade);
            // Indexes
            builder.HasIndex(s => s.Type).HasDatabaseName("IX_Sections_Type");
            builder.HasIndex(s => s.Key).HasDatabaseName("IX_Sections_Key").IsUnique();

            // Query Filter
            builder.HasQueryFilter(s => !s.IsDeleted);

            // Seed Data - Only update existing sections with Key values
            builder.HasData(
                // Ana Sayfa Sections
                new Section
                {
                    Id = 1,
                    Type = SectionType.Hero,
                    Key = "home-hero",
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
                    Type = SectionType.Featured,
                    Key = "home-featured-products",
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
                    Type = SectionType.Newsletter,
                    Key = "home-newsletter",
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
                    Type = SectionType.Header,
                    Key = "blog-header",
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
                    Type = SectionType.MainContent,
                    Key = "blog-main-content",
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
                    Type = SectionType.Catalog,
                    Key = "products-catalog",
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
