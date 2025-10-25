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
            int fieldId = 1;

            builder.HasData(
                // ============================================
                // MAIN MENU FIELDS
                // ============================================
                
                // About Menu Fields
                new SectionItemField
                {
                    Id = fieldId++,
                    SectionItemId = 1, // About Menu
                    FieldKey = "label",
                    FieldName = "Menu Label",
                    Type = SectionItemFieldType.Text,
                    Required = true,
                    MaxLength = 100,
                    Placeholder = "Enter menu label",
                    IsTranslatable = true,
                    SortOrder = 1,
                    CreatedAt = baseDate,
                    IsDeleted = false
                },
                new SectionItemField
                {
                    Id = fieldId++,
                    SectionItemId = 1,
                    FieldKey = "type",
                    FieldName = "Menu Type",
                    Type = SectionItemFieldType.Text,
                    Required = false,
                    Placeholder = "Menu type (megamenu, dropdown, etc.)",
                    DefaultValue = "megamenu",
                    IsTranslatable = false,
                    SortOrder = 2,
                    CreatedAt = baseDate,
                    IsDeleted = false
                },
                new SectionItemField
                {
                    Id = fieldId++,
                    SectionItemId = 1,
                    FieldKey = "url",
                    FieldName = "Menu URL",
                    Type = SectionItemFieldType.URL,
                    Required = false,
                    Placeholder = "Enter menu URL (optional for dropdowns)",
                    DefaultValue = "#",
                    IsTranslatable = false,
                    SortOrder = 3,
                    CreatedAt = baseDate,
                    IsDeleted = false
                },

                // About Description Section Fields
                new SectionItemField
                {
                    Id = fieldId++,
                    SectionItemId = 2, // About Description
                    FieldKey = "title",
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
                    Id = fieldId++,
                    SectionItemId = 2,
                    FieldKey = "text",
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
                    Id = fieldId++,
                    SectionItemId = 2,
                    FieldKey = "linkText",
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
                    Id = fieldId++,
                    SectionItemId = 2,
                    FieldKey = "linkUrl",
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
                    Id = fieldId++,
                    SectionItemId = 3, // Quick Links
                    FieldKey = "title",
                    FieldName = "Section Title",
                    Type = SectionItemFieldType.Text,
                    Required = true,
                    MaxLength = 100,
                    Placeholder = "Enter section title",
                    IsTranslatable = true,
                    SortOrder = 1,
                    CreatedAt = baseDate,
                    IsDeleted = false
                },

                // Quick Link Items Fields
                new SectionItemField
                {
                    Id = fieldId++,
                    SectionItemId = 4, // Mission & Vision
                    FieldKey = "text",
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
                    Id = fieldId++,
                    SectionItemId = 4,
                    FieldKey = "url",
                    FieldName = "Link URL",
                    Type = SectionItemFieldType.URL,
                    Required = true,
                    Placeholder = "Enter link URL",
                    IsTranslatable = false,
                    SortOrder = 2,
                    CreatedAt = baseDate,
                    IsDeleted = false
                },

                new SectionItemField
                {
                    Id = fieldId++,
                    SectionItemId = 5, // Team
                    FieldKey = "text",
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
                    Id = fieldId++,
                    SectionItemId = 5,
                    FieldKey = "url",
                    FieldName = "Link URL",
                    Type = SectionItemFieldType.URL,
                    Required = true,
                    Placeholder = "Enter link URL",
                    IsTranslatable = false,
                    SortOrder = 2,
                    CreatedAt = baseDate,
                    IsDeleted = false
                },

                new SectionItemField
                {
                    Id = fieldId++,
                    SectionItemId = 6, // Careers
                    FieldKey = "text",
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
                    Id = fieldId++,
                    SectionItemId = 6,
                    FieldKey = "url",
                    FieldName = "Link URL",
                    Type = SectionItemFieldType.URL,
                    Required = true,
                    Placeholder = "Enter link URL",
                    IsTranslatable = false,
                    SortOrder = 2,
                    CreatedAt = baseDate,
                    IsDeleted = false
                },

                new SectionItemField
                {
                    Id = fieldId++,
                    SectionItemId = 7, // Press
                    FieldKey = "text",
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
                    Id = fieldId++,
                    SectionItemId = 7,
                    FieldKey = "url",
                    FieldName = "Link URL",
                    Type = SectionItemFieldType.URL,
                    Required = true,
                    Placeholder = "Enter link URL",
                    IsTranslatable = false,
                    SortOrder = 2,
                    CreatedAt = baseDate,
                    IsDeleted = false
                },

                // Features Section Fields
                new SectionItemField
                {
                    Id = fieldId++,
                    SectionItemId = 8, // Features
                    FieldKey = "title",
                    FieldName = "Section Title",
                    Type = SectionItemFieldType.Text,
                    Required = true,
                    MaxLength = 100,
                    Placeholder = "Enter section title",
                    IsTranslatable = true,
                    SortOrder = 1,
                    CreatedAt = baseDate,
                    IsDeleted = false
                },

                // Feature Items Fields
                new SectionItemField
                {
                    Id = fieldId++,
                    SectionItemId = 9, // Experience
                    FieldKey = "title",
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
                    Id = fieldId++,
                    SectionItemId = 9,
                    FieldKey = "description",
                    FieldName = "Feature Description",
                    Type = SectionItemFieldType.TextArea,
                    Required = true,
                    MaxLength = 300,
                    Placeholder = "Enter feature description",
                    IsTranslatable = true,
                    SortOrder = 2,
                    CreatedAt = baseDate,
                    IsDeleted = false
                },

                new SectionItemField
                {
                    Id = fieldId++,
                    SectionItemId = 10, // Certified Team
                    FieldKey = "title",
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
                    Id = fieldId++,
                    SectionItemId = 10,
                    FieldKey = "description",
                    FieldName = "Feature Description",
                    Type = SectionItemFieldType.TextArea,
                    Required = true,
                    MaxLength = 300,
                    Placeholder = "Enter feature description",
                    IsTranslatable = true,
                    SortOrder = 2,
                    CreatedAt = baseDate,
                    IsDeleted = false
                },

                new SectionItemField
                {
                    Id = fieldId++,
                    SectionItemId = 11, // Projects
                    FieldKey = "title",
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
                    Id = fieldId++,
                    SectionItemId = 11,
                    FieldKey = "description",
                    FieldName = "Feature Description",
                    Type = SectionItemFieldType.TextArea,
                    Required = true,
                    MaxLength = 300,
                    Placeholder = "Enter feature description",
                    IsTranslatable = true,
                    SortOrder = 2,
                    CreatedAt = baseDate,
                    IsDeleted = false
                },

                // ============================================
                // SERVICES MENU FIELDS
                // ============================================
                
                // Services Menu Fields
                new SectionItemField
                {
                    Id = fieldId++,
                    SectionItemId = 12, // Services Menu
                    FieldKey = "label",
                    FieldName = "Menu Label",
                    Type = SectionItemFieldType.Text,
                    Required = true,
                    MaxLength = 100,
                    Placeholder = "Enter menu label",
                    IsTranslatable = true,
                    SortOrder = 1,
                    CreatedAt = baseDate,
                    IsDeleted = false
                },
                new SectionItemField
                {
                    Id = fieldId++,
                    SectionItemId = 12,
                    FieldKey = "type",
                    FieldName = "Menu Type",
                    Type = SectionItemFieldType.Text,
                    Required = false,
                    Placeholder = "Menu type",
                    DefaultValue = "servicetabs",
                    IsTranslatable = false,
                    SortOrder = 2,
                    CreatedAt = baseDate,
                    IsDeleted = false
                },

                // Service Tab Fields
                new SectionItemField
                {
                    Id = fieldId++,
                    SectionItemId = 13, // Managed Tab
                    FieldKey = "label",
                    FieldName = "Tab Label",
                    Type = SectionItemFieldType.Text,
                    Required = true,
                    MaxLength = 100,
                    Placeholder = "Enter tab label",
                    IsTranslatable = true,
                    SortOrder = 1,
                    CreatedAt = baseDate,
                    IsDeleted = false
                },
                new SectionItemField
                {
                    Id = fieldId++,
                    SectionItemId = 13,
                    FieldKey = "icon",
                    FieldName = "Tab Icon",
                    Type = SectionItemFieldType.Text,
                    Required = false,
                    Placeholder = "Enter icon class",
                    DefaultValue = "fas fa-server",
                    IsTranslatable = false,
                    SortOrder = 2,
                    CreatedAt = baseDate,
                    IsDeleted = false
                },

                new SectionItemField
                {
                    Id = fieldId++,
                    SectionItemId = 14, // Cloud Tab
                    FieldKey = "label",
                    FieldName = "Tab Label",
                    Type = SectionItemFieldType.Text,
                    Required = true,
                    MaxLength = 100,
                    Placeholder = "Enter tab label",
                    IsTranslatable = true,
                    SortOrder = 1,
                    CreatedAt = baseDate,
                    IsDeleted = false
                },
                new SectionItemField
                {
                    Id = fieldId++,
                    SectionItemId = 14,
                    FieldKey = "icon",
                    FieldName = "Tab Icon",
                    Type = SectionItemFieldType.Text,
                    Required = false,
                    Placeholder = "Enter icon class",
                    DefaultValue = "fas fa-cloud",
                    IsTranslatable = false,
                    SortOrder = 2,
                    CreatedAt = baseDate,
                    IsDeleted = false
                },

                new SectionItemField
                {
                    Id = fieldId++,
                    SectionItemId = 15, // Security Tab
                    FieldKey = "label",
                    FieldName = "Tab Label",
                    Type = SectionItemFieldType.Text,
                    Required = true,
                    MaxLength = 100,
                    Placeholder = "Enter tab label",
                    IsTranslatable = true,
                    SortOrder = 1,
                    CreatedAt = baseDate,
                    IsDeleted = false
                },
                new SectionItemField
                {
                    Id = fieldId++,
                    SectionItemId = 15,
                    FieldKey = "icon",
                    FieldName = "Tab Icon",
                    Type = SectionItemFieldType.Text,
                    Required = false,
                    Placeholder = "Enter icon class",
                    DefaultValue = "fas fa-shield-alt",
                    IsTranslatable = false,
                    SortOrder = 2,
                    CreatedAt = baseDate,
                    IsDeleted = false
                },

                new SectionItemField
                {
                    Id = fieldId++,
                    SectionItemId = 16, // Database Tab
                    FieldKey = "label",
                    FieldName = "Tab Label",
                    Type = SectionItemFieldType.Text,
                    Required = true,
                    MaxLength = 100,
                    Placeholder = "Enter tab label",
                    IsTranslatable = true,
                    SortOrder = 1,
                    CreatedAt = baseDate,
                    IsDeleted = false
                },
                new SectionItemField
                {
                    Id = fieldId++,
                    SectionItemId = 16,
                    FieldKey = "icon",
                    FieldName = "Tab Icon",
                    Type = SectionItemFieldType.Text,
                    Required = false,
                    Placeholder = "Enter icon class",
                    DefaultValue = "fas fa-database",
                    IsTranslatable = false,
                    SortOrder = 2,
                    CreatedAt = baseDate,
                    IsDeleted = false
                },

                new SectionItemField
                {
                    Id = fieldId++,
                    SectionItemId = 17, // Monitoring Tab
                    FieldKey = "label",
                    FieldName = "Tab Label",
                    Type = SectionItemFieldType.Text,
                    Required = true,
                    MaxLength = 100,
                    Placeholder = "Enter tab label",
                    IsTranslatable = true,
                    SortOrder = 1,
                    CreatedAt = baseDate,
                    IsDeleted = false
                },
                new SectionItemField
                {
                    Id = fieldId++,
                    SectionItemId = 17,
                    FieldKey = "icon",
                    FieldName = "Tab Icon",
                    Type = SectionItemFieldType.Text,
                    Required = false,
                    Placeholder = "Enter icon class",
                    DefaultValue = "fas fa-chart-line",
                    IsTranslatable = false,
                    SortOrder = 2,
                    CreatedAt = baseDate,
                    IsDeleted = false
                },

                new SectionItemField
                {
                    Id = fieldId++,
                    SectionItemId = 18, // Premium Tab
                    FieldKey = "label",
                    FieldName = "Tab Label",
                    Type = SectionItemFieldType.Text,
                    Required = true,
                    MaxLength = 100,
                    Placeholder = "Enter tab label",
                    IsTranslatable = true,
                    SortOrder = 1,
                    CreatedAt = baseDate,
                    IsDeleted = false
                },
                new SectionItemField
                {
                    Id = fieldId++,
                    SectionItemId = 18,
                    FieldKey = "icon",
                    FieldName = "Tab Icon",
                    Type = SectionItemFieldType.Text,
                    Required = false,
                    Placeholder = "Enter icon class",
                    DefaultValue = "fas fa-crown",
                    IsTranslatable = false,
                    SortOrder = 2,
                    CreatedAt = baseDate,
                    IsDeleted = false
                },
                new SectionItemField
                {
                    Id = fieldId++,
                    SectionItemId = 18,
                    FieldKey = "isPremium",
                    FieldName = "Is Premium",
                    Type = SectionItemFieldType.Boolean,
                    Required = false,
                    DefaultValue = "true",
                    IsTranslatable = false,
                    SortOrder = 3,
                    CreatedAt = baseDate,
                    IsDeleted = false
                },

                // Service Content Fields
                new SectionItemField
                {
                    Id = fieldId++,
                    SectionItemId = 19, // Multi-Cloud Service
                    FieldKey = "title",
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
                    Id = fieldId++,
                    SectionItemId = 19,
                    FieldKey = "description",
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
                    Id = fieldId++,
                    SectionItemId = 19,
                    FieldKey = "icon",
                    FieldName = "Service Icon",
                    Type = SectionItemFieldType.Text,
                    Required = false,
                    Placeholder = "Enter icon class",
                    DefaultValue = "fas fa-cloud",
                    IsTranslatable = false,
                    SortOrder = 3,
                    CreatedAt = baseDate,
                    IsDeleted = false
                },

                // ============================================
                // SOLUTIONS MENU FIELDS
                // ============================================
                
                // Solutions Menu Fields
                new SectionItemField
                {
                    Id = fieldId++,
                    SectionItemId = 23, // Solutions Menu
                    FieldKey = "label",
                    FieldName = "Menu Label",
                    Type = SectionItemFieldType.Text,
                    Required = true,
                    MaxLength = 100,
                    Placeholder = "Enter menu label",
                    IsTranslatable = true,
                    SortOrder = 1,
                    CreatedAt = baseDate,
                    IsDeleted = false
                },
                new SectionItemField
                {
                    Id = fieldId++,
                    SectionItemId = 23,
                    FieldKey = "type",
                    FieldName = "Menu Type",
                    Type = SectionItemFieldType.Text,
                    Required = false,
                    Placeholder = "Menu type",
                    DefaultValue = "categorized",
                    IsTranslatable = false,
                    SortOrder = 2,
                    CreatedAt = baseDate,
                    IsDeleted = false
                },

                // Solution Category Fields
                new SectionItemField
                {
                    Id = fieldId++,
                    SectionItemId = 24, // Software Category
                    FieldKey = "label",
                    FieldName = "Category Label",
                    Type = SectionItemFieldType.Text,
                    Required = true,
                    MaxLength = 100,
                    Placeholder = "Enter category label",
                    IsTranslatable = true,
                    SortOrder = 1,
                    CreatedAt = baseDate,
                    IsDeleted = false
                },
                new SectionItemField
                {
                    Id = fieldId++,
                    SectionItemId = 24,
                    FieldKey = "icon",
                    FieldName = "Category Icon",
                    Type = SectionItemFieldType.Text,
                    Required = false,
                    Placeholder = "Enter icon class",
                    DefaultValue = "fas fa-code",
                    IsTranslatable = false,
                    SortOrder = 2,
                    CreatedAt = baseDate,
                    IsDeleted = false
                },

                // ============================================
                // BLOG MENU FIELDS
                // ============================================
                
                // Blog Menu Fields
                new SectionItemField
                {
                    Id = fieldId++,
                    SectionItemId = 33, // Blog Menu
                    FieldKey = "label",
                    FieldName = "Menu Label",
                    Type = SectionItemFieldType.Text,
                    Required = true,
                    MaxLength = 100,
                    Placeholder = "Enter menu label",
                    IsTranslatable = true,
                    SortOrder = 1,
                    CreatedAt = baseDate,
                    IsDeleted = false
                },
                new SectionItemField
                {
                    Id = fieldId++,
                    SectionItemId = 33,
                    FieldKey = "type",
                    FieldName = "Menu Type",
                    Type = SectionItemFieldType.Text,
                    Required = false,
                    Placeholder = "Menu type",
                    DefaultValue = "megamenu",
                    IsTranslatable = false,
                    SortOrder = 2,
                    CreatedAt = baseDate,
                    IsDeleted = false
                },

                // Blog Description Fields
                new SectionItemField
                {
                    Id = fieldId++,
                    SectionItemId = 34, // Blog Description
                    FieldKey = "title",
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
                    Id = fieldId++,
                    SectionItemId = 34,
                    FieldKey = "text",
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
                    Id = fieldId++,
                    SectionItemId = 34,
                    FieldKey = "linkText",
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
                    Id = fieldId++,
                    SectionItemId = 34,
                    FieldKey = "linkUrl",
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

                // Blog Post Fields
                new SectionItemField
                {
                    Id = fieldId++,
                    SectionItemId = 41, // Kubernetes Post
                    FieldKey = "title",
                    FieldName = "Post Title",
                    Type = SectionItemFieldType.Text,
                    Required = true,
                    MaxLength = 200,
                    Placeholder = "Enter post title",
                    IsTranslatable = true,
                    SortOrder = 1,
                    CreatedAt = baseDate,
                    IsDeleted = false
                },
                new SectionItemField
                {
                    Id = fieldId++,
                    SectionItemId = 41,
                    FieldKey = "image",
                    FieldName = "Post Image",
                    Type = SectionItemFieldType.Image,
                    Required = false,
                    Placeholder = "Enter image URL",
                    DefaultValue = "/api/placeholder/400/300",
                    IsTranslatable = false,
                    SortOrder = 2,
                    CreatedAt = baseDate,
                    IsDeleted = false
                },
                new SectionItemField
                {
                    Id = fieldId++,
                    SectionItemId = 41,
                    FieldKey = "date",
                    FieldName = "Post Date",
                    Type = SectionItemFieldType.Date,
                    Required = false,
                    Placeholder = "Enter post date",
                    IsTranslatable = true,
                    SortOrder = 3,
                    CreatedAt = baseDate,
                    IsDeleted = false
                },
                new SectionItemField
                {
                    Id = fieldId++,
                    SectionItemId = 41,
                    FieldKey = "readTime",
                    FieldName = "Read Time",
                    Type = SectionItemFieldType.Text,
                    Required = false,
                    MaxLength = 20,
                    Placeholder = "Enter read time",
                    IsTranslatable = true,
                    SortOrder = 4,
                    CreatedAt = baseDate,
                    IsDeleted = false
                },

                // ============================================
                // SIMPLE LINK MENU FIELDS
                // ============================================
                
                new SectionItemField
                {
                    Id = fieldId++,
                    SectionItemId = 43, // Careers
                    FieldKey = "label",
                    FieldName = "Link Label",
                    Type = SectionItemFieldType.Text,
                    Required = true,
                    MaxLength = 100,
                    Placeholder = "Enter link label",
                    IsTranslatable = true,
                    SortOrder = 1,
                    CreatedAt = baseDate,
                    IsDeleted = false
                },
                new SectionItemField
                {
                    Id = fieldId++,
                    SectionItemId = 43,
                    FieldKey = "url",
                    FieldName = "Link URL",
                    Type = SectionItemFieldType.URL,
                    Required = true,
                    Placeholder = "Enter link URL",
                    IsTranslatable = false,
                    SortOrder = 2,
                    CreatedAt = baseDate,
                    IsDeleted = false
                },

                new SectionItemField
                {
                    Id = fieldId++,
                    SectionItemId = 44, // Data Center
                    FieldKey = "label",
                    FieldName = "Link Label",
                    Type = SectionItemFieldType.Text,
                    Required = true,
                    MaxLength = 100,
                    Placeholder = "Enter link label",
                    IsTranslatable = true,
                    SortOrder = 1,
                    CreatedAt = baseDate,
                    IsDeleted = false
                },
                new SectionItemField
                {
                    Id = fieldId++,
                    SectionItemId = 44,
                    FieldKey = "url",
                    FieldName = "Link URL",
                    Type = SectionItemFieldType.URL,
                    Required = true,
                    Placeholder = "Enter link URL",
                    IsTranslatable = false,
                    SortOrder = 2,
                    CreatedAt = baseDate,
                    IsDeleted = false
                },
                new SectionItemField
                {
                    Id = fieldId++,
                    SectionItemId = 44,
                    FieldKey = "showStatus",
                    FieldName = "Show Status",
                    Type = SectionItemFieldType.Boolean,
                    Required = false,
                    DefaultValue = "true",
                    IsTranslatable = false,
                    SortOrder = 3,
                    CreatedAt = baseDate,
                    IsDeleted = false
                },
                new SectionItemField
                {
                    Id = fieldId++,
                    SectionItemId = 44,
                    FieldKey = "status",
                    FieldName = "Status",
                    Type = SectionItemFieldType.Text,
                    Required = false,
                    Placeholder = "Enter status",
                    DefaultValue = "online",
                    IsTranslatable = false,
                    SortOrder = 4,
                    CreatedAt = baseDate,
                    IsDeleted = false
                },

                new SectionItemField
                {
                    Id = fieldId++,
                    SectionItemId = 45, // References
                    FieldKey = "label",
                    FieldName = "Link Label",
                    Type = SectionItemFieldType.Text,
                    Required = true,
                    MaxLength = 100,
                    Placeholder = "Enter link label",
                    IsTranslatable = true,
                    SortOrder = 1,
                    CreatedAt = baseDate,
                    IsDeleted = false
                },
                new SectionItemField
                {
                    Id = fieldId++,
                    SectionItemId = 45,
                    FieldKey = "url",
                    FieldName = "Link URL",
                    Type = SectionItemFieldType.URL,
                    Required = true,
                    Placeholder = "Enter link URL",
                    IsTranslatable = false,
                    SortOrder = 2,
                    CreatedAt = baseDate,
                    IsDeleted = false
                },

                // ============================================
                // CONTACT MENU FIELDS
                // ============================================
                
                // Contact Menu Fields
                new SectionItemField
                {
                    Id = fieldId++,
                    SectionItemId = 46, // Contact Menu
                    FieldKey = "label",
                    FieldName = "Menu Label",
                    Type = SectionItemFieldType.Text,
                    Required = true,
                    MaxLength = 100,
                    Placeholder = "Enter menu label",
                    IsTranslatable = true,
                    SortOrder = 1,
                    CreatedAt = baseDate,
                    IsDeleted = false
                },
                new SectionItemField
                {
                    Id = fieldId++,
                    SectionItemId = 46,
                    FieldKey = "type",
                    FieldName = "Menu Type",
                    Type = SectionItemFieldType.Text,
                    Required = false,
                    Placeholder = "Menu type",
                    DefaultValue = "dropdown",
                    IsTranslatable = false,
                    SortOrder = 2,
                    CreatedAt = baseDate,
                    IsDeleted = false
                },

                // Contact Info Fields
                new SectionItemField
                {
                    Id = fieldId++,
                    SectionItemId = 47, // Email
                    FieldKey = "label",
                    FieldName = "Contact Label",
                    Type = SectionItemFieldType.Text,
                    Required = true,
                    MaxLength = 100,
                    Placeholder = "Enter contact label",
                    IsTranslatable = true,
                    SortOrder = 1,
                    CreatedAt = baseDate,
                    IsDeleted = false
                },
                new SectionItemField
                {
                    Id = fieldId++,
                    SectionItemId = 47,
                    FieldKey = "value",
                    FieldName = "Contact Value",
                    Type = SectionItemFieldType.Text,
                    Required = true,
                    MaxLength = 200,
                    Placeholder = "Enter contact value",
                    IsTranslatable = true,
                    SortOrder = 2,
                    CreatedAt = baseDate,
                    IsDeleted = false
                },
                new SectionItemField
                {
                    Id = fieldId++,
                    SectionItemId = 47,
                    FieldKey = "type",
                    FieldName = "Contact Type",
                    Type = SectionItemFieldType.Text,
                    Required = false,
                    Placeholder = "Enter contact type",
                    DefaultValue = "email",
                    IsTranslatable = false,
                    SortOrder = 3,
                    CreatedAt = baseDate,
                    IsDeleted = false
                },
                new SectionItemField
                {
                    Id = fieldId++,
                    SectionItemId = 47,
                    FieldKey = "icon",
                    FieldName = "Contact Icon",
                    Type = SectionItemFieldType.Text,
                    Required = false,
                    Placeholder = "Enter icon class",
                    DefaultValue = "fas fa-envelope",
                    IsTranslatable = false,
                    SortOrder = 4,
                    CreatedAt = baseDate,
                    IsDeleted = false
                },

                new SectionItemField
                {
                    Id = fieldId++,
                    SectionItemId = 48, // Address
                    FieldKey = "label",
                    FieldName = "Contact Label",
                    Type = SectionItemFieldType.Text,
                    Required = true,
                    MaxLength = 100,
                    Placeholder = "Enter contact label",
                    IsTranslatable = true,
                    SortOrder = 1,
                    CreatedAt = baseDate,
                    IsDeleted = false
                },
                new SectionItemField
                {
                    Id = fieldId++,
                    SectionItemId = 48,
                    FieldKey = "value",
                    FieldName = "Contact Value",
                    Type = SectionItemFieldType.Text,
                    Required = true,
                    MaxLength = 200,
                    Placeholder = "Enter contact value",
                    IsTranslatable = true,
                    SortOrder = 2,
                    CreatedAt = baseDate,
                    IsDeleted = false
                },
                new SectionItemField
                {
                    Id = fieldId++,
                    SectionItemId = 48,
                    FieldKey = "type",
                    FieldName = "Contact Type",
                    Type = SectionItemFieldType.Text,
                    Required = false,
                    Placeholder = "Enter contact type",
                    DefaultValue = "address",
                    IsTranslatable = false,
                    SortOrder = 3,
                    CreatedAt = baseDate,
                    IsDeleted = false
                },
                new SectionItemField
                {
                    Id = fieldId++,
                    SectionItemId = 48,
                    FieldKey = "icon",
                    FieldName = "Contact Icon",
                    Type = SectionItemFieldType.Text,
                    Required = false,
                    Placeholder = "Enter icon class",
                    DefaultValue = "fas fa-map-marker-alt",
                    IsTranslatable = false,
                    SortOrder = 4,
                    CreatedAt = baseDate,
                    IsDeleted = false
                }
            );
        }
    }
}