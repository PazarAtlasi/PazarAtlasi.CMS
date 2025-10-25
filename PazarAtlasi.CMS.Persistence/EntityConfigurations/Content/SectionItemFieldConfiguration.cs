using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PazarAtlasi.CMS.Domain.Common;
using PazarAtlasi.CMS.Domain.Entities.Content;

namespace PazarAtlasi.CMS.Persistence.EntityConfigurations.Content
{
    public class SectionItemFieldConfiguration : IEntityTypeConfiguration<SectionItemField>
    {
        public void Configure(EntityTypeBuilder<SectionItemField> builder)
        {
            builder.ToTable("SectionItemFields");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.FieldKey)
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(x => x.FieldName)
                .HasMaxLength(200)
                .IsRequired();

            builder.Property(x => x.Type)
                .IsRequired();

            builder.Property(x => x.Placeholder)
                .HasMaxLength(500);

            builder.Property(x => x.DefaultValue)
                .HasMaxLength(1000);

            builder.Property(x => x.OptionsJson)
                .HasColumnType("nvarchar(max)");

            builder.HasMany(x => x.Translations)
                .WithOne(x => x.SectionItemField)
                .HasForeignKey(x => x.SectionItemFieldId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(t => t.SectionItem)
                .WithMany(si => si.SectionItemFields)
                .HasForeignKey(x => x.SectionItemId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasIndex(x => x.FieldKey)
                .HasDatabaseName("IX_SectionItemFields_FieldKey");

            builder.HasIndex(x => x.SortOrder)
                .HasDatabaseName("IX_SectionItemFields_SortOrder");

            // Base entity configuration
            builder.Property(x => x.CreatedAt)
                .IsRequired();

            builder.Property(x => x.UpdatedAt);

            builder.Property(x => x.IsDeleted)
                .HasDefaultValue(false);

            builder.HasQueryFilter(x => !x.IsDeleted);

            // Seed Data - Navbar Template Fields
            builder.HasData(
                // Mega Menu Navbar Template (ID: 2) Fields
                new SectionItemField
                {
                    Id = 1,
                    SectionItemId = 1, // Assuming SectionItem with ID 2 corresponds to Mega Menu Navbar
                    FieldKey = "logo_image",
                    FieldName = "Logo Image",
                    Type = SectionItemFieldType.Image,
                    Required = false,
                    Placeholder = "Upload your logo image",
                    DefaultValue = "",
                    IsTranslatable = false,
                    SortOrder = 1,
                    CreatedAt = new DateTime(2024, 10, 14, 10, 0, 0),
                    IsDeleted = false
                },
                new SectionItemField
                {
                    Id = 2,
                    SectionItemId = 1, // Assuming SectionItem with ID 2 corresponds to Mega Menu Navbar
                    FieldKey = "logo_text",
                    FieldName = "Logo Text",
                    Type = SectionItemFieldType.Text,
                    Required = false,
                    MaxLength = 100,
                    Placeholder = "Enter logo text",
                    DefaultValue = "",
                    IsTranslatable = true,
                    SortOrder = 2,
                    CreatedAt = new DateTime(2024, 10, 14, 10, 0, 0),
                    IsDeleted = false
                },
                new SectionItemField
                {
                    Id = 3,
                    SectionItemId = 2, // Assuming SectionItem with ID 2 corresponds to Mega Menu Navbar
                    FieldKey = "menu_title",
                    FieldName = "Menu Title",
                    Type = SectionItemFieldType.Text,
                    Required = true,
                    MaxLength = 50,
                    Placeholder = "Enter menu title",
                    DefaultValue = "",
                    IsTranslatable = true,
                    SortOrder = 3,
                    CreatedAt = new DateTime(2024, 10, 14, 10, 0, 0),
                    IsDeleted = false
                },
                new SectionItemField
                {
                    Id = 4,
                    SectionItemId = 2, // Assuming SectionItem with ID 2 corresponds to Mega Menu Navbar
                    FieldKey = "menu_url",
                    FieldName = "Menu URL",
                    Type = SectionItemFieldType.URL,
                    Required = false,
                    Placeholder = "Enter menu URL (optional for dropdowns)",
                    DefaultValue = "#",
                    IsTranslatable = false,
                    SortOrder = 4,
                    CreatedAt = new DateTime(2024, 10, 14, 10, 0, 0),
                    IsDeleted = false
                },
                new SectionItemField
                {
                    Id = 5,
                    SectionItemId = 2, // Assuming SectionItem with ID 2 corresponds to Mega Menu Navbar
                    FieldKey = "menu_icon",
                    FieldName = "Menu Icon",
                    Type = SectionItemFieldType.Text,
                    Required = false,
                    MaxLength = 50,
                    Placeholder = "Enter icon class (e.g., fas fa-home)",
                    DefaultValue = "",
                    IsTranslatable = false,
                    SortOrder = 5,
                    CreatedAt = new DateTime(2024, 10, 14, 10, 0, 0),
                    IsDeleted = false
                },
                new SectionItemField
                {
                    Id = 6,
                    SectionItemId = 2, // Assuming SectionItem with ID 2 corresponds to Mega Menu Navbar
                    FieldKey = "menu_description",
                    FieldName = "Menu Description",
                    Type = SectionItemFieldType.TextArea,
                    Required = false,
                    MaxLength = 200,
                    Placeholder = "Enter menu description for mega menu",
                    DefaultValue = "",
                    IsTranslatable = true,
                    SortOrder = 6,
                    CreatedAt = new DateTime(2024, 10, 14, 10, 0, 0),
                    IsDeleted = false
                },
                new SectionItemField
                {
                    Id = 7,
                    SectionItemId = 2, // Assuming SectionItem with ID 2 corresponds to Mega Menu Navbar
                    FieldKey = "featured_image",
                    FieldName = "Featured Image",
                    Type = SectionItemFieldType.Image,
                    Required = false,
                    Placeholder = "Upload featured image for mega menu",
                    DefaultValue = "",
                    IsTranslatable = false,
                    SortOrder = 7,
                    CreatedAt = new DateTime(2024, 10, 14, 10, 0, 0),
                    IsDeleted = false
                },
                new SectionItemField
                {
                    Id = 8,
                    SectionItemId = 2, // Assuming SectionItem with ID 2 corresponds to Mega Menu Navbar
                    FieldKey = "is_featured",
                    FieldName = "Is Featured",
                    Type = SectionItemFieldType.Checkbox,
                    Required = false,
                    Placeholder = "Mark as featured item",
                    DefaultValue = "false",
                    IsTranslatable = false,
                    SortOrder = 8,
                    CreatedAt = new DateTime(2024, 10, 14, 10, 0, 0),
                    IsDeleted = false
                },
                new SectionItemField
                {
                    Id = 9,
                    SectionItemId = 2, // Assuming SectionItem with ID 2 corresponds to Mega Menu Navbar
                    FieldKey = "badge_text",
                    FieldName = "Badge Text",
                    Type = SectionItemFieldType.Text,
                    Required = false,
                    MaxLength = 20,
                    Placeholder = "Enter badge text (e.g., NEW, HOT)",
                    DefaultValue = "",
                    IsTranslatable = true,
                    SortOrder = 9,
                    CreatedAt = new DateTime(2024, 10, 14, 10, 0, 0),
                    IsDeleted = false
                },
                new SectionItemField
                {
                    Id = 10,
                    SectionItemId = 2, // Assuming SectionItem with ID 2 corresponds to Mega Menu Navbar
                    FieldKey = "badge_color",
                    FieldName = "Badge Color",
                    Type = SectionItemFieldType.MultiSelect,
                    Required = false,
                    Placeholder = "Select badge color",
                    DefaultValue = "primary",
                    OptionsJson = @"[""primary"", ""secondary"", ""success"", ""danger"", ""warning"", ""info""]",
                    IsTranslatable = false,
                    SortOrder = 10,
                    CreatedAt = new DateTime(2024, 10, 14, 10, 0, 0),
                    IsDeleted = false
                },
                new SectionItemField
                {
                    Id = 11,
                    SectionItemId = 21, // Assuming SectionItem with ID 2 corresponds to Mega Menu Navbar
                    FieldKey = "is_featured",
                    FieldName = "Is Featured",
                    Type = SectionItemFieldType.Checkbox,
                    Required = false,
                    Placeholder = "Mark as featured item",
                    DefaultValue = "false",
                    IsTranslatable = false,
                    SortOrder = 8,
                    CreatedAt = new DateTime(2024, 10, 14, 10, 0, 0),
                    IsDeleted = false
                },
                new SectionItemField
                {
                    Id = 12,
                    SectionItemId = 21, // Assuming SectionItem with ID 2 corresponds to Mega Menu Navbar
                    FieldKey = "badge_text",
                    FieldName = "Badge Text",
                    Type = SectionItemFieldType.Text,
                    Required = false,
                    MaxLength = 20,
                    Placeholder = "Enter badge text (e.g., NEW, HOT)",
                    DefaultValue = "",
                    IsTranslatable = true,
                    SortOrder = 9,
                    CreatedAt = new DateTime(2024, 10, 14, 10, 0, 0),
                    IsDeleted = false
                },
                new SectionItemField
                {
                    Id = 13,
                    SectionItemId = 21, // Assuming SectionItem with ID 2 corresponds to Mega Menu Navbar
                    FieldKey = "badge_color",
                    FieldName = "Badge Color",
                    Type = SectionItemFieldType.MultiSelect,
                    Required = false,
                    Placeholder = "Select badge color",
                    DefaultValue = "primary",
                    OptionsJson = @"[""primary"", ""secondary"", ""success"", ""danger"", ""warning"", ""info""]",
                    IsTranslatable = false,
                    SortOrder = 10,
                    CreatedAt = new DateTime(2024, 10, 14, 10, 0, 0),
                    IsDeleted = false
                }
            );
        }
    }
}