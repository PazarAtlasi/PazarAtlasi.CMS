using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PazarAtlasi.CMS.Domain.Entities.Content;
using PazarAtlasi.CMS.Domain.Common;

namespace PazarAtlasi.CMS.Persistence.EntityConfigurations.Content
{
    public class SectionItemConfigurationBuilder : IEntityTypeConfiguration<SectionItem>
    {
        public void Configure(EntityTypeBuilder<SectionItem> builder)
        {
            builder.ToTable("SectionItems").HasKey(si => si.Id);

            builder.Property(si => si.Id).HasColumnName("Id").IsRequired();
            builder.Property(si => si.SectionId).HasColumnName("SectionId").IsRequired();
            builder.Property(si => si.Type).HasColumnName("Type").HasDefaultValue(SectionItemType.None);
            builder.Property(si => si.MediaType).HasColumnName("MediaType").HasDefaultValue(MediaType.None);
            builder.Property(si => si.SortOrder).HasColumnName("SortOrder").HasDefaultValue(0);
            builder.Property(si => si.CreatedAt).HasColumnName("CreatedAt").IsRequired();
            builder.Property(si => si.UpdatedAt).HasColumnName("UpdatedAt");
            builder.Property(si => si.IsDeleted).HasColumnName("IsDeleted").HasDefaultValue(false);
            builder.Property(si => si.Status).HasColumnName("Status").HasDefaultValue(Status.Draft);
            builder.Property(si => si.CreatedBy).HasColumnName("CreatedBy");
            builder.Property(si => si.UpdatedBy).HasColumnName("UpdatedBy");

            // New properties
            builder.Property(si => si.Title)
                .HasColumnName("Title")
                .HasMaxLength(200);

            builder.Property(si => si.Description)
                .HasColumnName("Description")
                .HasMaxLength(500);

            builder.Property(si => si.AllowReorder)
                .HasColumnName("AllowReorder")
                .HasDefaultValue(true);

            builder.Property(si => si.AllowRemove)
                .HasColumnName("AllowRemove")
                .HasDefaultValue(true);

            builder.Property(si => si.IconClass)
                .HasColumnName("IconClass")
                .HasMaxLength(100);

            // Template relationship
            builder.Property(si => si.TemplateId)
                .HasColumnName("TemplateId");

            // Relationships
            builder.HasOne(si => si.Section)
                   .WithMany(s => s.SectionItems)
                   .HasForeignKey(si => si.SectionId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(si => si.Template)
                   .WithMany(c => c.SectionItems)
                   .HasForeignKey(si => si.TemplateId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(si => si.Translations)
                   .WithOne(sit => sit.SectionItem)
                   .HasForeignKey(sit => sit.SectionItemId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(si => si.FieldValues)
                   .WithOne(fv => fv.SectionItem)
                   .HasForeignKey(fv => fv.SectionItemId)
                   .OnDelete(DeleteBehavior.Cascade);

            // Indexes
            builder.HasIndex(si => new { si.SectionId, si.SortOrder }).HasDatabaseName("IX_SectionItems_SectionId_SortOrder");
            builder.HasIndex(si => si.Type).HasDatabaseName("IX_SectionItems_Type");
            builder.HasIndex(si => si.TemplateId).HasDatabaseName("IX_SectionItems_TemplateId");

            // Query Filter
            builder.HasQueryFilter(si => !si.IsDeleted);

            // Seed Data
            builder.HasData(
                // Hero Section Items
                new SectionItem
                {
                    Id = 1,
                    SectionId = 1, // hero-section
                    TemplateId = 1, // Placeholder - will need proper config
                    Type = SectionItemType.Text,
                    SortOrder = 1,
                    Title = "Hero Title",
                    Description = "Main hero section title",
                    AllowReorder = true,
                    AllowRemove = true,
                    IconClass = "fas fa-heading",
                    CreatedAt = new DateTime(2024, 1, 1, 10, 0, 0),
                    Status = Status.Active,
                    IsDeleted = false
                },
                new SectionItem
                {
                    Id = 2,
                    SectionId = 1, // hero-section
                    TemplateId = 1, // Placeholder
                    Type = SectionItemType.Paragraph,
                    SortOrder = 2,
                    Title = "Hero Description",
                    Description = "Hero section description text",
                    AllowReorder = true,
                    AllowRemove = true,
                    IconClass = "fas fa-paragraph",
                    CreatedAt = new DateTime(2024, 1, 1, 10, 0, 0),
                    Status = Status.Active,
                    IsDeleted = false
                },
                new SectionItem
                {
                    Id = 3,
                    SectionId = 1, // hero-section
                    TemplateId = 1, // Placeholder
                    Type = SectionItemType.Button,
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
                    TemplateId = 1, // Placeholder
                    Type = SectionItemType.Image,
                    SortOrder = 1,
                    CreatedAt = new DateTime(2024, 1, 1, 10, 0, 0),
                    Status = Status.Active,
                    IsDeleted = false
                },
                new SectionItem
                {
                    Id = 5,
                    SectionId = 2, // featured-products
                    TemplateId = 1, // Placeholder
                    Type = SectionItemType.Image,
                    SortOrder = 2,
                    CreatedAt = new DateTime(2024, 1, 1, 10, 0, 0),
                    Status = Status.Active,
                    IsDeleted = false
                },
                new SectionItem
                {
                    Id = 6,
                    SectionId = 2, // featured-products
                    TemplateId = 1, // Placeholder
                    Type = SectionItemType.Image,
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
                    TemplateId = 1, // Placeholder
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
                    TemplateId = 1, // Placeholder
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
                    TemplateId = 1, // Placeholder
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
                    TemplateId = 1, // Placeholder
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
