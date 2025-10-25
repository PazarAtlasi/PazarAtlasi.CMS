using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PazarAtlasi.CMS.Domain.Common;
using PazarAtlasi.CMS.Domain.Entities.Content;

namespace PazarAtlasi.CMS.Persistence.EntityConfigurations.Content.SeedData
{
    public static class SectionItemFieldSeedData
    {
        public static void SeedCommonFields(this EntityTypeBuilder<SectionItemField> builder)
        {
            var baseDate = new DateTime(2024, 10, 25, 10, 0, 0);

            builder.HasData(
                // Title Field (for all menu items)
                new SectionItemField
                {
                    Id = 1,
                    SectionItemId = 1, // About Menu
                    FieldKey = "label",
                    FieldName = "label",
                    Type = SectionItemFieldType.Text,
                    Required = true,
                    MaxLength = 100,
                    Placeholder = "Enter menu label",
                    IsTranslatable = true,
                    SortOrder = 1,
                    CreatedAt = baseDate,
                    IsDeleted = false
                },

                // URL Field
                new SectionItemField
                {
                    Id = 2,
                    SectionItemId = 1,
                    FieldKey = "type",
                    FieldName = "TYPE",
                    Type = SectionItemFieldType.Text,
                    Required = false,
                    Placeholder = "Menu type.",
                    DefaultValue = "#",
                    IsTranslatable = false,
                    SortOrder = 2,
                    CreatedAt = baseDate,
                    IsDeleted = false
                },

                // Description Field (for About Description section)
                new SectionItemField
                {
                    Id = 3,
                    SectionItemId = 3, // About Description
                    FieldKey = "description_title",
                    FieldName = "Description Title",
                    Type = SectionItemFieldType.Text,
                    Required = true,
                    MaxLength = 200,
                    Placeholder = "Enter description title",
                    IsTranslatable = true,
                    SortOrder = 1,
                    CreatedAt = baseDate,
                    IsDeleted = false
                },

                new SectionItemField
                {
                    Id = 4,
                    SectionItemId = 3,
                    FieldKey = "description_text",
                    FieldName = "Description Text",
                    Type = SectionItemFieldType.TextArea,
                    Required = true,
                    MaxLength = 500,
                    Placeholder = "Enter description text",
                    IsTranslatable = true,
                    SortOrder = 2,
                    CreatedAt = baseDate,
                    IsDeleted = false
                },

                new SectionItemField
                {
                    Id = 5,
                    SectionItemId = 3,
                    FieldKey = "link_text",
                    FieldName = "Link Text",
                    Type = SectionItemFieldType.Text,
                    Required = false,
                    MaxLength = 50,
                    Placeholder = "Enter link text",
                    IsTranslatable = true,
                    SortOrder = 3,
                    CreatedAt = baseDate,
                    IsDeleted = false
                },

                new SectionItemField
                {
                    Id = 6,
                    SectionItemId = 3,
                    FieldKey = "link_url",
                    FieldName = "Link URL",
                    Type = SectionItemFieldType.URL,
                    Required = false,
                    Placeholder = "Enter link URL",
                    DefaultValue = "#",
                    IsTranslatable = false,
                    SortOrder = 4,
                    CreatedAt = baseDate,
                    IsDeleted = false
                },

                // Quick Links Section Fields
                new SectionItemField
                {
                    Id = 7,
                    SectionItemId = 4, // Quick Links
                    FieldKey = "quicklinks.title",
                    FieldName = "Quicklink Title",
                    Type = SectionItemFieldType.Text,
                    Required = true,
                    MaxLength = 100,
                    Placeholder = "Enter section title",
                    IsTranslatable = true,
                    SortOrder = 1,
                    CreatedAt = baseDate,
                    IsDeleted = false
                },

                // Link Item Fields (for Quick Links items)
                new SectionItemField
                {
                    Id = 8,
                    SectionItemId = 5, // Mission & Vision link
                    FieldKey = "quicklink.links.missionVision.text",
                    FieldName = "Link Text",
                    Type = SectionItemFieldType.Text,
                    Required = true,
                    MaxLength = 100,
                    Placeholder = "Enter link text",
                    IsTranslatable = true,
                    SortOrder = 1,
                    CreatedAt = baseDate,
                    IsDeleted = false
                },

                new SectionItemField
                {
                    Id = 9,
                    SectionItemId = 5,
                    FieldKey = "quicklink.links.missionVision.link",
                    FieldName = "Link URL",
                    Type = SectionItemFieldType.URL,
                    Required = true,
                    Placeholder = "Enter link URL",
                    IsTranslatable = false,
                    SortOrder = 2,
                    CreatedAt = baseDate,
                    IsDeleted = false
                },

                // Feature Card Fields
                new SectionItemField
                {
                    Id = 10,
                    SectionItemId = 5, // Experience feature
                    FieldKey = "quicklink.links.team.text",
                    FieldName = "Feature Title",
                    Type = SectionItemFieldType.Text,
                    Required = true,
                    MaxLength = 100,
                    Placeholder = "Enter feature title",
                    IsTranslatable = true,
                    SortOrder = 1,
                    CreatedAt = baseDate,
                    IsDeleted = false
                },

                new SectionItemField
                {
                    Id = 11,
                    SectionItemId = 5,
                    FieldKey = "quicklink.links.missionVision.link",
                    FieldName = "Feature Description",
                    Type = SectionItemFieldType.URL,
                    Required = true,
                    MaxLength = 300,
                    Placeholder = "mission vision",
                    IsTranslatable = true,
                    SortOrder = 2,
                    CreatedAt = baseDate,
                    IsDeleted = false
                }
            );
        }

        public static void SeedServiceFields(this EntityTypeBuilder<SectionItemField> builder)
        {
            var baseDate = new DateTime(2024, 10, 25, 10, 0, 0);

            builder.HasData(
                // ============================================
                // Service Tab Fields
                // ============================================
                new SectionItemField
                {
                    Id = 12,
                    SectionItemId = 13, // Managed tab
                    FieldKey = "tab_label",
                    FieldName = "Tab Label",
                    Type = SectionItemFieldType.Text,
                    Required = true,
                    MaxLength = 50,
                    Placeholder = "Enter tab label",
                    IsTranslatable = true,
                    SortOrder = 1,
                    CreatedAt = baseDate,
                    IsDeleted = false
                },

                new SectionItemField
                {
                    Id = 13,
                    SectionItemId = 13,
                    FieldKey = "tab_icon",
                    FieldName = "Tab Icon",
                    Type = SectionItemFieldType.Text,
                    Required = false,
                    MaxLength = 50,
                    Placeholder = "Enter icon class",
                    IsTranslatable = false,
                    SortOrder = 2,
                    CreatedAt = baseDate,
                    IsDeleted = false
                },

                new SectionItemField
                {
                    Id = 14,
                    SectionItemId = 18, // Premium tab
                    FieldKey = "is_premium",
                    FieldName = "Is Premium",
                    Type = SectionItemFieldType.Checkbox,
                    Required = false,
                    DefaultValue = "false",
                    IsTranslatable = false,
                    SortOrder = 3,
                    CreatedAt = baseDate,
                    IsDeleted = false
                },

                // Service Item Fields
                new SectionItemField
                {
                    Id = 15,
                    SectionItemId = 19, // Multi-Cloud service
                    FieldKey = "service_title",
                    FieldName = "Service Title",
                    Type = SectionItemFieldType.Text,
                    Required = true,
                    MaxLength = 100,
                    Placeholder = "Enter service title",
                    IsTranslatable = true,
                    SortOrder = 1,
                    CreatedAt = baseDate,
                    IsDeleted = false
                },

                new SectionItemField
                {
                    Id = 16,
                    SectionItemId = 19,
                    FieldKey = "service_description",
                    FieldName = "Service Description",
                    Type = SectionItemFieldType.TextArea,
                    Required = true,
                    MaxLength = 300,
                    Placeholder = "Enter service description",
                    IsTranslatable = true,
                    SortOrder = 2,
                    CreatedAt = baseDate,
                    IsDeleted = false
                },

                new SectionItemField
                {
                    Id = 17,
                    SectionItemId = 19,
                    FieldKey = "service_icon",
                    FieldName = "Service Icon",
                    Type = SectionItemFieldType.Text,
                    Required = false,
                    MaxLength = 50,
                    Placeholder = "Enter icon class",
                    IsTranslatable = false,
                    SortOrder = 3,
                    CreatedAt = baseDate,
                    IsDeleted = false
                }
            );
        }

        public static void SeedCategoryFields(this EntityTypeBuilder<SectionItemField> builder)
        {
            var baseDate = new DateTime(2024, 10, 25, 10, 0, 0);

            builder.HasData(
                // ============================================
                // Category Fields (Solutions Menu)
                // ============================================
                new SectionItemField
                {
                    Id = 18,
                    SectionItemId = 44, // Software category
                    FieldKey = "category_label",
                    FieldName = "Category Label",
                    Type = SectionItemFieldType.Text,
                    Required = true,
                    MaxLength = 50,
                    Placeholder = "Enter category label",
                    IsTranslatable = true,
                    SortOrder = 1,
                    CreatedAt = baseDate,
                    IsDeleted = false
                },

                new SectionItemField
                {
                    Id = 19,
                    SectionItemId = 44,
                    FieldKey = "category_icon",
                    FieldName = "Category Icon",
                    Type = SectionItemFieldType.Text,
                    Required = false,
                    MaxLength = 50,
                    Placeholder = "Enter icon class",
                    IsTranslatable = false,
                    SortOrder = 2,
                    CreatedAt = baseDate,
                    IsDeleted = false
                },

                new SectionItemField
                {
                    Id = 20,
                    SectionItemId = 44,
                    FieldKey = "category_color",
                    FieldName = "Category Color",
                    Type = SectionItemFieldType.MultiSelect,
                    Required = false,
                    DefaultValue = "blue",
                    OptionsJson = @"[""blue"", ""indigo"", ""purple"", ""green"", ""red"", ""yellow""]",
                    IsTranslatable = false,
                    SortOrder = 3,
                    CreatedAt = baseDate,
                    IsDeleted = false
                }
            );
        }
    }
}