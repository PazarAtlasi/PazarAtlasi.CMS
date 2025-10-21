using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PazarAtlasi.CMS.Domain.Entities.Content;
using PazarAtlasi.CMS.Domain.Common;

namespace PazarAtlasi.CMS.Persistence.EntityConfigurations.Content
{
    public class SectionItemSettingConfiguration : IEntityTypeConfiguration<SectionItemSetting>
    {
        public void Configure(EntityTypeBuilder<SectionItemSetting> builder)
        {
            builder.ToTable("SectionItemSettings");
            builder.HasKey(sis => sis.Id);

            builder.Property(sis => sis.Id)
                .HasColumnName("Id")
                .IsRequired();

            builder.Property(sis => sis.TemplateId)
                .HasColumnName("TemplateId")
                .IsRequired();

            builder.Property(sis => sis.ConfigurationKey)
                .HasColumnName("ConfigurationKey")
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(sis => sis.ItemType)
                .HasColumnName("ItemType")
                .IsRequired()
                .HasConversion<int>();

            builder.Property(sis => sis.MinItems)
                .HasColumnName("MinItems")
                .HasDefaultValue(0);

            builder.Property(sis => sis.MaxItems)
                .HasColumnName("MaxItems");

            builder.Property(sis => sis.DefaultItemCount)
                .HasColumnName("DefaultItemCount")
                .HasDefaultValue(1);

            builder.Property(sis => sis.AllowDynamicSectionItems)
                .HasColumnName("AllowDynamicSectionItems")
                .HasDefaultValue(true);

            builder.Property(sis => sis.UIConfigurationJson)
                .HasColumnName("UIConfigurationJson")
                .HasColumnType("nvarchar(max)");

            builder.Property(sis => sis.ParentSettingId)
                .HasColumnName("ParentSettingId");

            builder.Property(sis => sis.CreatedAt)
                .HasColumnName("CreatedAt")
                .IsRequired();

            builder.Property(sis => sis.UpdatedAt)
                .HasColumnName("UpdatedAt");

            builder.Property(sis => sis.IsDeleted)
                .HasColumnName("IsDeleted")
                .HasDefaultValue(false);

            builder.Property(sis => sis.Status)
                .HasColumnName("Status")
                .HasDefaultValue(Status.Active);

            builder.Property(sis => sis.CreatedBy)
                .HasColumnName("CreatedBy");

            builder.Property(sis => sis.UpdatedBy)
                .HasColumnName("UpdatedBy");

            // Relationships
            builder.HasOne(sis => sis.Template)
                .WithMany()
                .HasForeignKey(sis => sis.TemplateId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(sis => sis.ParentSetting)
                .WithMany(p => p.ChildSettings)
                .HasForeignKey(sis => sis.ParentSettingId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(sis => sis.Fields)
                .WithOne(f => f.SectionItemSetting)
                .HasForeignKey(f => f.SectionItemSettingId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(sis => sis.Translations)
                .WithOne(t => t.SectionItemSetting)
                .HasForeignKey(t => t.SectionItemSettingId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(sis => sis.SectionItems)
                .WithOne(si => si.Setting)
                .HasForeignKey(si => si.SectionItemSettingId)
                .OnDelete(DeleteBehavior.Restrict);

            // Indexes
            builder.HasIndex(sis => new { sis.TemplateId, sis.ConfigurationKey })
                .HasDatabaseName("IX_SectionItemSettings_TemplateId_ConfigurationKey")
                .IsUnique();

            builder.HasIndex(sis => sis.ItemType)
                .HasDatabaseName("IX_SectionItemSettings_ItemType");

            builder.HasIndex(sis => sis.ParentSettingId)
                .HasDatabaseName("IX_SectionItemSettings_ParentSettingId");

            // Query Filter
            builder.HasQueryFilter(sis => !sis.IsDeleted);

            // Seed Data - All Template Configurations
            SeedNavbarSimpleConfigurations(builder);
            SeedNavbarMegaMenuConfigurations(builder);
            SeedNavbarServiceTabsConfigurations(builder);
            SeedNavbarCategorizedConfigurations(builder);
            SeedCarouselConfigurations(builder);
            SeedDefaultConfigurations(builder);
            SeedSequentialConfigurations(builder);
            SeedGridConfigurations(builder);
            SeedMasonryConfigurations(builder);
            SeedListConfigurations(builder);
            SeedSingleItemConfigurations(builder);
            SeedMultiItemConfigurations(builder);
            SeedAccordionConfigurations(builder);
            SeedTabsConfigurations(builder);
        }

        private void SeedNavbarSimpleConfigurations(EntityTypeBuilder<SectionItemSetting> builder)
        {
            // Logo Configuration (ID: 1)
            builder.HasData(
                new SectionItemSetting
                {
                    Id = 1,
                    TemplateId = 1, // navbar-simple
                    ConfigurationKey = "logo",
                    ItemType = SectionItemType.Logo,
                    MinItems = 1,
                    MaxItems = 1,
                    DefaultItemCount = 1,
                    AllowDynamicSectionItems = false,
                    UIConfigurationJson = @"{""Layout"":""list"",""ShowPreview"":true,""ShowReorder"":false,""IconClass"":""fa-image""}",
                    CreatedAt = new DateTime(2024, 10, 21, 10, 0, 0),
                    Status = Status.Active,
                    IsDeleted = false
                }
            );

            // Menu Configuration (ID: 2)
            builder.HasData(
                new SectionItemSetting
                {
                    Id = 2,
                    TemplateId = 1, // navbar-simple
                    ConfigurationKey = "menu",
                    ItemType = SectionItemType.Menu,
                    MinItems = 3,
                    MaxItems = 8,
                    DefaultItemCount = 3,
                    AllowDynamicSectionItems = true,
                    UIConfigurationJson = @"{""Layout"":""list"",""ShowPreview"":true,""ShowReorder"":true,""AddButtonText"":""Add Menu Item"",""IconClass"":""fa-bars""}",
                    CreatedAt = new DateTime(2024, 10, 21, 10, 0, 0),
                    Status = Status.Active,
                    IsDeleted = false
                }
            );

            // Dropdown Link Configuration (ID: 3) - Nested under Menu
            builder.HasData(
                new SectionItemSetting
                {
                    Id = 3,
                    TemplateId = 1, // navbar-simple
                    ParentSettingId = 2, // menu
                    ConfigurationKey = "dropdown-link",
                    ItemType = SectionItemType.Link,
                    MinItems = 1,
                    MaxItems = 10,
                    DefaultItemCount = 3,
                    AllowDynamicSectionItems = true,
                    UIConfigurationJson = @"{""Layout"":""list"",""ShowPreview"":true,""ShowReorder"":true,""AddButtonText"":""Add Dropdown Link"",""IconClass"":""fa-link""}",
                    CreatedAt = new DateTime(2024, 10, 21, 10, 0, 0),
                    Status = Status.Active,
                    IsDeleted = false
                }
            );
        }

        private void SeedCarouselConfigurations(EntityTypeBuilder<SectionItemSetting> builder)
        {
            // Carousel Slide Configuration (ID: 10, TemplateId: 9 - carousel)
            builder.HasData(
                new SectionItemSetting
                {
                    Id = 10,
                    TemplateId = 9, // carousel
                    ConfigurationKey = "slide",
                    ItemType = SectionItemType.Image,
                    MinItems = 3,
                    MaxItems = 10,
                    DefaultItemCount = 5,
                    AllowDynamicSectionItems = true,
                    UIConfigurationJson = @"{""Layout"":""grid"",""Columns"":3,""ShowPreview"":true,""ShowReorder"":true,""AddButtonText"":""Add Slide"",""IconClass"":""fa-images""}",
                    CreatedAt = new DateTime(2024, 10, 21, 10, 0, 0),
                    Status = Status.Active,
                    IsDeleted = false
                }
            );
        }

        private void SeedDefaultConfigurations(EntityTypeBuilder<SectionItemSetting> builder)
        {
            // Default Content Item Configuration (ID: 20, TemplateId: 5 - default)
            builder.HasData(
                new SectionItemSetting
                {
                    Id = 20,
                    TemplateId = 5, // default
                    ConfigurationKey = "content-item",
                    ItemType = SectionItemType.Text,
                    MinItems = 1,
                    MaxItems = null,
                    DefaultItemCount = 3,
                    AllowDynamicSectionItems = true,
                    UIConfigurationJson = @"{""Layout"":""list"",""ShowPreview"":true,""ShowReorder"":true,""AddButtonText"":""Add Item"",""IconClass"":""fa-file-alt""}",
                    CreatedAt = new DateTime(2024, 10, 21, 10, 0, 0),
                    Status = Status.Active,
                    IsDeleted = false
                }
            );
        }

        private void SeedNavbarMegaMenuConfigurations(EntityTypeBuilder<SectionItemSetting> builder)
        {
            // Mega Menu Category (ID: 30, TemplateId: 2)
            builder.HasData(
                new SectionItemSetting
                {
                    Id = 30,
                    TemplateId = 2,
                    ConfigurationKey = "mega-menu-category",
                    ItemType = SectionItemType.Menu,
                    MinItems = 3,
                    MaxItems = 6,
                    DefaultItemCount = 3,
                    AllowDynamicSectionItems = true,
                    UIConfigurationJson = @"{""Layout"":""grid"",""Columns"":2,""ShowPreview"":true,""ShowReorder"":true,""AddButtonText"":""Add Category"",""IconClass"":""fa-th-large""}",
                    CreatedAt = new DateTime(2024, 10, 21, 10, 0, 0),
                    Status = Status.Active,
                    IsDeleted = false
                },
                // Mega Menu Link (ID: 31, nested under category)
                new SectionItemSetting
                {
                    Id = 31,
                    TemplateId = 2,
                    ParentSettingId = 30,
                    ConfigurationKey = "mega-menu-link",
                    ItemType = SectionItemType.Link,
                    MinItems = 2,
                    MaxItems = 15,
                    DefaultItemCount = 3,
                    AllowDynamicSectionItems = true,
                    UIConfigurationJson = @"{""Layout"":""list"",""ShowPreview"":true,""ShowReorder"":true,""AddButtonText"":""Add Link"",""IconClass"":""fa-link""}",
                    CreatedAt = new DateTime(2024, 10, 21, 10, 0, 0),
                    Status = Status.Active,
                    IsDeleted = false
                }
            );
        }

        private void SeedNavbarServiceTabsConfigurations(EntityTypeBuilder<SectionItemSetting> builder)
        {
            // Service Tab (ID: 40, TemplateId: 3)
            builder.HasData(
                new SectionItemSetting
                {
                    Id = 40,
                    TemplateId = 3,
                    ConfigurationKey = "service-tab",
                    ItemType = SectionItemType.Menu,
                    MinItems = 3,
                    MaxItems = 6,
                    DefaultItemCount = 4,
                    AllowDynamicSectionItems = true,
                    UIConfigurationJson = @"{""Layout"":""list"",""ShowPreview"":true,""ShowReorder"":true,""AddButtonText"":""Add Tab"",""IconClass"":""fa-folder-open""}",
                    CreatedAt = new DateTime(2024, 10, 21, 10, 0, 0),
                    Status = Status.Active,
                    IsDeleted = false
                }
            );
        }

        private void SeedNavbarCategorizedConfigurations(EntityTypeBuilder<SectionItemSetting> builder)
        {
            // Category (ID: 50, TemplateId: 4)
            builder.HasData(
                new SectionItemSetting
                {
                    Id = 50,
                    TemplateId = 4,
                    ConfigurationKey = "category",
                    ItemType = SectionItemType.Menu,
                    MinItems = 3,
                    MaxItems = 8,
                    DefaultItemCount = 3,
                    AllowDynamicSectionItems = true,
                    UIConfigurationJson = @"{""Layout"":""list"",""ShowPreview"":true,""ShowReorder"":true,""AddButtonText"":""Add Category"",""IconClass"":""fa-tags""}",
                    CreatedAt = new DateTime(2024, 10, 21, 10, 0, 0),
                    Status = Status.Active,
                    IsDeleted = false
                },
                // Category Item (ID: 51, nested)
                new SectionItemSetting
                {
                    Id = 51,
                    TemplateId = 4,
                    ParentSettingId = 50,
                    ConfigurationKey = "category-item",
                    ItemType = SectionItemType.Link,
                    MinItems = 1,
                    MaxItems = 12,
                    DefaultItemCount = 3,
                    AllowDynamicSectionItems = true,
                    UIConfigurationJson = @"{""Layout"":""list"",""ShowPreview"":true,""ShowReorder"":true,""AddButtonText"":""Add Item"",""IconClass"":""fa-link""}",
                    CreatedAt = new DateTime(2024, 10, 21, 10, 0, 0),
                    Status = Status.Active,
                    IsDeleted = false
                }
            );
        }

        private void SeedSequentialConfigurations(EntityTypeBuilder<SectionItemSetting> builder)
        {
            // Sequential Step (ID: 60, TemplateId: 6)
            builder.HasData(
                new SectionItemSetting
                {
                    Id = 60,
                    TemplateId = 6,
                    ConfigurationKey = "step",
                    ItemType = SectionItemType.Text,
                    MinItems = 2,
                    MaxItems = 10,
                    DefaultItemCount = 4,
                    AllowDynamicSectionItems = true,
                    UIConfigurationJson = @"{""Layout"":""list"",""ShowPreview"":true,""ShowReorder"":true,""AddButtonText"":""Add Step"",""IconClass"":""fa-list-ol""}",
                    CreatedAt = new DateTime(2024, 10, 21, 10, 0, 0),
                    Status = Status.Active,
                    IsDeleted = false
                }
            );
        }

        private void SeedGridConfigurations(EntityTypeBuilder<SectionItemSetting> builder)
        {
            // Grid Item (ID: 70, TemplateId: 7)
            builder.HasData(
                new SectionItemSetting
                {
                    Id = 70,
                    TemplateId = 7,
                    ConfigurationKey = "grid-item",
                    ItemType = SectionItemType.Text,
                    MinItems = 3,
                    MaxItems = 12,
                    DefaultItemCount = 6,
                    AllowDynamicSectionItems = true,
                    UIConfigurationJson = @"{""Layout"":""grid"",""Columns"":3,""ShowPreview"":true,""ShowReorder"":true,""AddButtonText"":""Add Grid Item"",""IconClass"":""fa-th""}",
                    CreatedAt = new DateTime(2024, 10, 21, 10, 0, 0),
                    Status = Status.Active,
                    IsDeleted = false
                }
            );
        }

        private void SeedMasonryConfigurations(EntityTypeBuilder<SectionItemSetting> builder)
        {
            // Masonry Image (ID: 80, TemplateId: 8)
            builder.HasData(
                new SectionItemSetting
                {
                    Id = 80,
                    TemplateId = 8,
                    ConfigurationKey = "masonry-image",
                    ItemType = SectionItemType.Image,
                    MinItems = 4,
                    MaxItems = 20,
                    DefaultItemCount = 8,
                    AllowDynamicSectionItems = true,
                    UIConfigurationJson = @"{""Layout"":""grid"",""Columns"":4,""ShowPreview"":true,""ShowReorder"":true,""AddButtonText"":""Add Image"",""IconClass"":""fa-images""}",
                    CreatedAt = new DateTime(2024, 10, 21, 10, 0, 0),
                    Status = Status.Active,
                    IsDeleted = false
                }
            );
        }

        private void SeedListConfigurations(EntityTypeBuilder<SectionItemSetting> builder)
        {
            // List Item (ID: 90, TemplateId: 10)
            builder.HasData(
                new SectionItemSetting
                {
                    Id = 90,
                    TemplateId = 10,
                    ConfigurationKey = "list-item",
                    ItemType = SectionItemType.Text,
                    MinItems = 3,
                    MaxItems = 15,
                    DefaultItemCount = 5,
                    AllowDynamicSectionItems = true,
                    UIConfigurationJson = @"{""Layout"":""list"",""ShowPreview"":true,""ShowReorder"":true,""AddButtonText"":""Add List Item"",""IconClass"":""fa-list""}",
                    CreatedAt = new DateTime(2024, 10, 21, 10, 0, 0),
                    Status = Status.Active,
                    IsDeleted = false
                }
            );
        }

        private void SeedSingleItemConfigurations(EntityTypeBuilder<SectionItemSetting> builder)
        {
            // Single Featured Item (ID: 100, TemplateId: 11)
            builder.HasData(
                new SectionItemSetting
                {
                    Id = 101,
                    TemplateId = 11,
                    ConfigurationKey = "single-item",
                    ItemType = SectionItemType.Text,
                    MinItems = 1,
                    MaxItems = 1,
                    DefaultItemCount = 1,
                    AllowDynamicSectionItems = false,
                    UIConfigurationJson = @"{""Layout"":""list"",""ShowPreview"":true,""ShowReorder"":false,""AddButtonText"":"""",""IconClass"":""fa-star""}",
                    CreatedAt = new DateTime(2024, 10, 21, 10, 0, 0),
                    Status = Status.Active,
                    IsDeleted = false
                }
            );
        }

        private void SeedMultiItemConfigurations(EntityTypeBuilder<SectionItemSetting> builder)
        {
            // Multi Item (ID: 110, TemplateId: 12)
            builder.HasData(
                new SectionItemSetting
                {
                    Id = 110,
                    TemplateId = 12,
                    ConfigurationKey = "multi-item",
                    ItemType = SectionItemType.Text,
                    MinItems = 2,
                    MaxItems = 8,
                    DefaultItemCount = 4,
                    AllowDynamicSectionItems = true,
                    UIConfigurationJson = @"{""Layout"":""grid"",""Columns"":2,""ShowPreview"":true,""ShowReorder"":true,""AddButtonText"":""Add Item"",""IconClass"":""fa-th-large""}",
                    CreatedAt = new DateTime(2024, 10, 21, 10, 0, 0),
                    Status = Status.Active,
                    IsDeleted = false
                }
            );
        }

        private void SeedAccordionConfigurations(EntityTypeBuilder<SectionItemSetting> builder)
        {
            // Accordion Panel (ID: 120, TemplateId: 13)
            builder.HasData(
                new SectionItemSetting
                {
                    Id = 120,
                    TemplateId = 13,
                    ConfigurationKey = "panel",
                    ItemType = SectionItemType.Text,
                    MinItems = 3,
                    MaxItems = 10,
                    DefaultItemCount = 5,
                    AllowDynamicSectionItems = true,
                    UIConfigurationJson = @"{""Layout"":""list"",""ShowPreview"":true,""ShowReorder"":true,""AddButtonText"":""Add Panel"",""IconClass"":""fa-bars""}",
                    CreatedAt = new DateTime(2024, 10, 21, 10, 0, 0),
                    Status = Status.Active,
                    IsDeleted = false
                }
            );
        }

        private void SeedTabsConfigurations(EntityTypeBuilder<SectionItemSetting> builder)
        {
            // Tab (ID: 130, TemplateId: 14)
            builder.HasData(
                new SectionItemSetting
                {
                    Id = 130,
                    TemplateId = 14,
                    ConfigurationKey = "tab",
                    ItemType = SectionItemType.Text,
                    MinItems = 2,
                    MaxItems = 8,
                    DefaultItemCount = 4,
                    AllowDynamicSectionItems = true,
                    UIConfigurationJson = @"{""Layout"":""list"",""ShowPreview"":true,""ShowReorder"":true,""AddButtonText"":""Add Tab"",""IconClass"":""fa-folder""}",
                    CreatedAt = new DateTime(2024, 10, 21, 10, 0, 0),
                    Status = Status.Active,
                    IsDeleted = false
                }
            );
        }
    }
}

