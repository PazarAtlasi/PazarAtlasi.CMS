using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PazarAtlasi.CMS.Domain.Entities.Content;
using PazarAtlasi.CMS.Domain.Common;

namespace PazarAtlasi.CMS.Persistence.EntityConfigurations.Content
{
    public class SectionItemFieldSettingConfiguration : IEntityTypeConfiguration<SectionItemFieldSetting>
    {
        public void Configure(EntityTypeBuilder<SectionItemFieldSetting> builder)
        {
            builder.ToTable("SectionItemFieldSettings");
            builder.HasKey(sifs => sifs.Id);

            builder.Property(sifs => sifs.Id)
                .HasColumnName("Id")
                .IsRequired();

            builder.Property(sifs => sifs.SectionItemSettingId)
                .HasColumnName("SectionItemSettingId")
                .IsRequired();

            builder.Property(sifs => sifs.FieldKey)
                .HasColumnName("FieldKey")
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(sifs => sifs.Type)
                .HasColumnName("Type")
                .IsRequired()
                .HasConversion<int>();

            builder.Property(sifs => sifs.Required)
                .HasColumnName("Required")
                .HasDefaultValue(false);

            builder.Property(sifs => sifs.MaxLength)
                .HasColumnName("MaxLength")
                .HasDefaultValue(0);

            builder.Property(sifs => sifs.Placeholder)
                .HasColumnName("Placeholder")
                .HasMaxLength(500);

            builder.Property(sifs => sifs.DefaultValue)
                .HasColumnName("DefaultValue")
                .HasMaxLength(500);

            builder.Property(sifs => sifs.IsTranslatable)
                .HasColumnName("IsTranslatable")
                .HasDefaultValue(false);

            builder.Property(sifs => sifs.OptionsJson)
                .HasColumnName("OptionsJson")
                .HasColumnType("nvarchar(max)");

            builder.Property(sifs => sifs.SortOrder)
                .HasColumnName("SortOrder")
                .HasDefaultValue(0);

            builder.Property(sifs => sifs.CreatedAt)
                .HasColumnName("CreatedAt")
                .IsRequired();

            builder.Property(sifs => sifs.UpdatedAt)
                .HasColumnName("UpdatedAt");

            builder.Property(sifs => sifs.IsDeleted)
                .HasColumnName("IsDeleted")
                .HasDefaultValue(false);

            builder.Property(sifs => sifs.Status)
                .HasColumnName("Status")
                .HasDefaultValue(Status.Active);

            builder.Property(sifs => sifs.CreatedBy)
                .HasColumnName("CreatedBy");

            builder.Property(sifs => sifs.UpdatedBy)
                .HasColumnName("UpdatedBy");

            // Relationships
            builder.HasOne(sifs => sifs.SectionItemSetting)
                .WithMany(sis => sis.Fields)
                .HasForeignKey(sifs => sifs.SectionItemSettingId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(sifs => sifs.Translations)
                .WithOne(t => t.SectionItemFieldSetting)
                .HasForeignKey(t => t.SectionItemFieldSettingId)
                .OnDelete(DeleteBehavior.Cascade);

            // Indexes
            builder.HasIndex(sifs => new { sifs.SectionItemSettingId, sifs.FieldKey })
                .HasDatabaseName("IX_SectionItemFieldSettings_SettingId_FieldKey")
                .IsUnique();

            builder.HasIndex(sifs => sifs.Type)
                .HasDatabaseName("IX_SectionItemFieldSettings_Type");

            builder.HasIndex(sifs => new { sifs.SectionItemSettingId, sifs.SortOrder })
                .HasDatabaseName("IX_SectionItemFieldSettings_SettingId_SortOrder");

            // Query Filter
            builder.HasQueryFilter(sifs => !sifs.IsDeleted);

            // Seed Data - Fields for All Template Configurations
            SeedNavbarSimpleFields(builder);
            SeedNavbarMegaMenuFields(builder);
            SeedNavbarServiceTabsFields(builder);
            SeedNavbarCategorizedFields(builder);
            SeedCarouselFields(builder);
            SeedDefaultFields(builder);
            SeedSequentialFields(builder);
            SeedGridFields(builder);
            SeedMasonryFields(builder);
            SeedListFields(builder);
            SeedSingleItemFields(builder);
            SeedMultiItemFields(builder);
            SeedAccordionFields(builder);
            SeedTabsFields(builder);
        }

        private void SeedNavbarSimpleFields(EntityTypeBuilder<SectionItemFieldSetting> builder)
        {
            // Logo Configuration Fields (SettingId: 1)
            builder.HasData(
                // Logo - Image field
                new SectionItemFieldSetting
                {
                    Id = 1,
                    SectionItemSettingId = 1,
                    FieldKey = "image",
                    Type = SectionItemFieldType.Image,
                    Required = true,
                    MaxLength = 0,
                    IsTranslatable = false,
                    SortOrder = 1,
                    CreatedAt = new DateTime(2024, 10, 21, 10, 0, 0),
                    Status = Status.Active,
                    IsDeleted = false
                },
                // Logo - Alt Text field
                new SectionItemFieldSetting
                {
                    Id = 2,
                    SectionItemSettingId = 1,
                    FieldKey = "altText",
                    Type = SectionItemFieldType.Text,
                    Required = false,
                    MaxLength = 100,
                    Placeholder = "Logo alt text",
                    IsTranslatable = true,
                    SortOrder = 2,
                    CreatedAt = new DateTime(2024, 10, 21, 10, 0, 0),
                    Status = Status.Active,
                    IsDeleted = false
                },
                // Logo - URL field
                new SectionItemFieldSetting
                {
                    Id = 3,
                    SectionItemSettingId = 1,
                    FieldKey = "url",
                    Type = SectionItemFieldType.URL,
                    Required = false,
                    MaxLength = 500,
                    Placeholder = "/",
                    DefaultValue = "/",
                    IsTranslatable = false,
                    SortOrder = 3,
                    CreatedAt = new DateTime(2024, 10, 21, 10, 0, 0),
                    Status = Status.Active,
                    IsDeleted = false
                }
            );

            // Menu Configuration Fields (SettingId: 2)
            builder.HasData(
                // Menu - Title field
                new SectionItemFieldSetting
                {
                    Id = 4,
                    SectionItemSettingId = 2,
                    FieldKey = "title",
                    Type = SectionItemFieldType.Title,
                    Required = true,
                    MaxLength = 50,
                    Placeholder = "e.g., Products, Services",
                    IsTranslatable = true,
                    SortOrder = 1,
                    CreatedAt = new DateTime(2024, 10, 21, 10, 0, 0),
                    Status = Status.Active,
                    IsDeleted = false
                },
                // Menu - Icon field
                new SectionItemFieldSetting
                {
                    Id = 5,
                    SectionItemSettingId = 2,
                    FieldKey = "icon",
                    Type = SectionItemFieldType.Text,
                    Required = false,
                    MaxLength = 50,
                    Placeholder = "fa fa-bars",
                    IsTranslatable = false,
                    SortOrder = 2,
                    CreatedAt = new DateTime(2024, 10, 21, 10, 0, 0),
                    Status = Status.Active,
                    IsDeleted = false
                }
            );

            // Dropdown Link Configuration Fields (SettingId: 3)
            builder.HasData(
                // Dropdown Link - Title field
                new SectionItemFieldSetting
                {
                    Id = 6,
                    SectionItemSettingId = 3,
                    FieldKey = "title",
                    Type = SectionItemFieldType.Title,
                    Required = true,
                    MaxLength = 50,
                    Placeholder = "e.g., Home, About",
                    IsTranslatable = true,
                    SortOrder = 1,
                    CreatedAt = new DateTime(2024, 10, 21, 10, 0, 0),
                    Status = Status.Active,
                    IsDeleted = false
                },
                // Dropdown Link - URL field
                new SectionItemFieldSetting
                {
                    Id = 7,
                    SectionItemSettingId = 3,
                    FieldKey = "url",
                    Type = SectionItemFieldType.URL,
                    Required = true,
                    MaxLength = 500,
                    Placeholder = "/page-url or https://example.com",
                    IsTranslatable = false,
                    SortOrder = 2,
                    CreatedAt = new DateTime(2024, 10, 21, 10, 0, 0),
                    Status = Status.Active,
                    IsDeleted = false
                },
                // Dropdown Link - Icon field
                new SectionItemFieldSetting
                {
                    Id = 8,
                    SectionItemSettingId = 3,
                    FieldKey = "icon",
                    Type = SectionItemFieldType.Text,
                    Required = false,
                    MaxLength = 50,
                    Placeholder = "fa fa-home",
                    IsTranslatable = false,
                    SortOrder = 3,
                    CreatedAt = new DateTime(2024, 10, 21, 10, 0, 0),
                    Status = Status.Active,
                    IsDeleted = false
                },
                // Dropdown Link - Open in New Tab checkbox
                new SectionItemFieldSetting
                {
                    Id = 9,
                    SectionItemSettingId = 3,
                    FieldKey = "openInNewTab",
                    Type = SectionItemFieldType.Checkbox,
                    Required = false,
                    DefaultValue = "false",
                    IsTranslatable = false,
                    SortOrder = 4,
                    CreatedAt = new DateTime(2024, 10, 21, 10, 0, 0),
                    Status = Status.Active,
                    IsDeleted = false
                }
            );
        }

        private void SeedCarouselFields(EntityTypeBuilder<SectionItemFieldSetting> builder)
        {
            // Carousel Slide Fields (SettingId: 10)
            builder.HasData(
                // Slide - Image field
                new SectionItemFieldSetting
                {
                    Id = 100,
                    SectionItemSettingId = 10,
                    FieldKey = "image",
                    Type = SectionItemFieldType.Image,
                    Required = true,
                    MaxLength = 0,
                    IsTranslatable = false,
                    SortOrder = 1,
                    CreatedAt = new DateTime(2024, 10, 21, 10, 0, 0),
                    Status = Status.Active,
                    IsDeleted = false
                },
                // Slide - Title field
                new SectionItemFieldSetting
                {
                    Id = 101,
                    SectionItemSettingId = 10,
                    FieldKey = "title",
                    Type = SectionItemFieldType.Title,
                    Required = false,
                    MaxLength = 100,
                    IsTranslatable = true,
                    SortOrder = 2,
                    CreatedAt = new DateTime(2024, 10, 21, 10, 0, 0),
                    Status = Status.Active,
                    IsDeleted = false
                },
                // Slide - Description field
                new SectionItemFieldSetting
                {
                    Id = 102,
                    SectionItemSettingId = 10,
                    FieldKey = "description",
                    Type = SectionItemFieldType.Description,
                    Required = false,
                    MaxLength = 300,
                    IsTranslatable = true,
                    SortOrder = 3,
                    CreatedAt = new DateTime(2024, 10, 21, 10, 0, 0),
                    Status = Status.Active,
                    IsDeleted = false
                },
                // Slide - Button Text field
                new SectionItemFieldSetting
                {
                    Id = 103,
                    SectionItemSettingId = 10,
                    FieldKey = "buttonText",
                    Type = SectionItemFieldType.Text,
                    Required = false,
                    MaxLength = 50,
                    IsTranslatable = true,
                    SortOrder = 4,
                    CreatedAt = new DateTime(2024, 10, 21, 10, 0, 0),
                    Status = Status.Active,
                    IsDeleted = false
                },
                // Slide - Button URL field
                new SectionItemFieldSetting
                {
                    Id = 104,
                    SectionItemSettingId = 10,
                    FieldKey = "buttonUrl",
                    Type = SectionItemFieldType.URL,
                    Required = false,
                    MaxLength = 500,
                    IsTranslatable = false,
                    SortOrder = 5,
                    CreatedAt = new DateTime(2024, 10, 21, 10, 0, 0),
                    Status = Status.Active,
                    IsDeleted = false
                }
            );
        }

        private void SeedDefaultFields(EntityTypeBuilder<SectionItemFieldSetting> builder)
        {
            // Default Content Item Fields (SettingId: 20)
            builder.HasData(
                // Content - Title field
                new SectionItemFieldSetting
                {
                    Id = 200,
                    SectionItemSettingId = 20,
                    FieldKey = "title",
                    Type = SectionItemFieldType.Title,
                    Required = true,
                    MaxLength = 100,
                    IsTranslatable = true,
                    SortOrder = 1,
                    CreatedAt = new DateTime(2024, 10, 21, 10, 0, 0),
                    Status = Status.Active,
                    IsDeleted = false
                },
                // Content - Description field
                new SectionItemFieldSetting
                {
                    Id = 201,
                    SectionItemSettingId = 20,
                    FieldKey = "description",
                    Type = SectionItemFieldType.Description,
                    Required = false,
                    MaxLength = 500,
                    IsTranslatable = true,
                    SortOrder = 2,
                    CreatedAt = new DateTime(2024, 10, 21, 10, 0, 0),
                    Status = Status.Active,
                    IsDeleted = false
                }
            );
        }

        private void SeedNavbarMegaMenuFields(EntityTypeBuilder<SectionItemFieldSetting> builder)
        {
            // Mega Menu Category Fields (SettingId: 30)
            builder.HasData(
                new SectionItemFieldSetting
                {
                    Id = 300,
                    SectionItemSettingId = 30,
                    FieldKey = "title",
                    Type = SectionItemFieldType.Title,
                    Required = true,
                    MaxLength = 50,
                    Placeholder = "e.g., Products, Services",
                    IsTranslatable = true,
                    SortOrder = 1,
                    CreatedAt = new DateTime(2024, 10, 21, 10, 0, 0),
                    Status = Status.Active,
                    IsDeleted = false
                },
                new SectionItemFieldSetting
                {
                    Id = 301,
                    SectionItemSettingId = 30,
                    FieldKey = "icon",
                    Type = SectionItemFieldType.Text,
                    MaxLength = 50,
                    Placeholder = "fa fa-cube",
                    SortOrder = 2,
                    CreatedAt = new DateTime(2024, 10, 21, 10, 0, 0),
                    Status = Status.Active,
                    IsDeleted = false
                },
                new SectionItemFieldSetting
                {
                    Id = 302,
                    SectionItemSettingId = 30,
                    FieldKey = "description",
                    Type = SectionItemFieldType.Description,
                    MaxLength = 200,
                    IsTranslatable = true,
                    SortOrder = 3,
                    CreatedAt = new DateTime(2024, 10, 21, 10, 0, 0),
                    Status = Status.Active,
                    IsDeleted = false
                }
            );

            // Mega Menu Link Fields (SettingId: 31)
            builder.HasData(
                new SectionItemFieldSetting
                {
                    Id = 310,
                    SectionItemSettingId = 31,
                    FieldKey = "title",
                    Type = SectionItemFieldType.Title,
                    Required = true,
                    MaxLength = 50,
                    IsTranslatable = true,
                    SortOrder = 1,
                    CreatedAt = new DateTime(2024, 10, 21, 10, 0, 0),
                    Status = Status.Active,
                    IsDeleted = false
                },
                new SectionItemFieldSetting
                {
                    Id = 311,
                    SectionItemSettingId = 31,
                    FieldKey = "url",
                    Type = SectionItemFieldType.URL,
                    Required = true,
                    MaxLength = 500,
                    SortOrder = 2,
                    CreatedAt = new DateTime(2024, 10, 21, 10, 0, 0),
                    Status = Status.Active,
                    IsDeleted = false
                },
                new SectionItemFieldSetting
                {
                    Id = 312,
                    SectionItemSettingId = 31,
                    FieldKey = "icon",
                    Type = SectionItemFieldType.Text,
                    MaxLength = 50,
                    Placeholder = "fa fa-arrow-right",
                    SortOrder = 3,
                    CreatedAt = new DateTime(2024, 10, 21, 10, 0, 0),
                    Status = Status.Active,
                    IsDeleted = false
                }
            );
        }

        private void SeedNavbarServiceTabsFields(EntityTypeBuilder<SectionItemFieldSetting> builder)
        {
            // Service Tab Fields (SettingId: 40)
            builder.HasData(
                new SectionItemFieldSetting
                {
                    Id = 400,
                    SectionItemSettingId = 40,
                    FieldKey = "title",
                    Type = SectionItemFieldType.Title,
                    Required = true,
                    MaxLength = 50,
                    IsTranslatable = true,
                    SortOrder = 1,
                    CreatedAt = new DateTime(2024, 10, 21, 10, 0, 0),
                    Status = Status.Active,
                    IsDeleted = false
                },
                new SectionItemFieldSetting
                {
                    Id = 401,
                    SectionItemSettingId = 40,
                    FieldKey = "icon",
                    Type = SectionItemFieldType.Text,
                    MaxLength = 50,
                    Placeholder = "fa fa-cog",
                    SortOrder = 2,
                    CreatedAt = new DateTime(2024, 10, 21, 10, 0, 0),
                    Status = Status.Active,
                    IsDeleted = false
                },
                new SectionItemFieldSetting
                {
                    Id = 402,
                    SectionItemSettingId = 40,
                    FieldKey = "description",
                    Type = SectionItemFieldType.Description,
                    MaxLength = 300,
                    IsTranslatable = true,
                    SortOrder = 3,
                    CreatedAt = new DateTime(2024, 10, 21, 10, 0, 0),
                    Status = Status.Active,
                    IsDeleted = false
                },
                new SectionItemFieldSetting
                {
                    Id = 403,
                    SectionItemSettingId = 40,
                    FieldKey = "url",
                    Type = SectionItemFieldType.URL,
                    MaxLength = 500,
                    SortOrder = 4,
                    CreatedAt = new DateTime(2024, 10, 21, 10, 0, 0),
                    Status = Status.Active,
                    IsDeleted = false
                }
            );
        }

        private void SeedNavbarCategorizedFields(EntityTypeBuilder<SectionItemFieldSetting> builder)
        {
            // Category Fields (SettingId: 50)
            builder.HasData(
                new SectionItemFieldSetting
                {
                    Id = 500,
                    SectionItemSettingId = 50,
                    FieldKey = "title",
                    Type = SectionItemFieldType.Title,
                    Required = true,
                    MaxLength = 50,
                    IsTranslatable = true,
                    SortOrder = 1,
                    CreatedAt = new DateTime(2024, 10, 21, 10, 0, 0),
                    Status = Status.Active,
                    IsDeleted = false
                },
                new SectionItemFieldSetting
                {
                    Id = 501,
                    SectionItemSettingId = 50,
                    FieldKey = "icon",
                    Type = SectionItemFieldType.Text,
                    MaxLength = 50,
                    Placeholder = "fa fa-tag",
                    SortOrder = 2,
                    CreatedAt = new DateTime(2024, 10, 21, 10, 0, 0),
                    Status = Status.Active,
                    IsDeleted = false
                }
            );

            // Category Item Fields (SettingId: 51)
            builder.HasData(
                new SectionItemFieldSetting
                {
                    Id = 510,
                    SectionItemSettingId = 51,
                    FieldKey = "title",
                    Type = SectionItemFieldType.Title,
                    Required = true,
                    MaxLength = 50,
                    IsTranslatable = true,
                    SortOrder = 1,
                    CreatedAt = new DateTime(2024, 10, 21, 10, 0, 0),
                    Status = Status.Active,
                    IsDeleted = false
                },
                new SectionItemFieldSetting
                {
                    Id = 511,
                    SectionItemSettingId = 51,
                    FieldKey = "url",
                    Type = SectionItemFieldType.URL,
                    Required = true,
                    MaxLength = 500,
                    SortOrder = 2,
                    CreatedAt = new DateTime(2024, 10, 21, 10, 0, 0),
                    Status = Status.Active,
                    IsDeleted = false
                },
                new SectionItemFieldSetting
                {
                    Id = 512,
                    SectionItemSettingId = 51,
                    FieldKey = "badge",
                    Type = SectionItemFieldType.Text,
                    MaxLength = 20,
                    Placeholder = "New, Hot, etc.",
                    IsTranslatable = true,
                    SortOrder = 3,
                    CreatedAt = new DateTime(2024, 10, 21, 10, 0, 0),
                    Status = Status.Active,
                    IsDeleted = false
                }
            );
        }

        private void SeedSequentialFields(EntityTypeBuilder<SectionItemFieldSetting> builder)
        {
            // Sequential Step Fields (SettingId: 60)
            builder.HasData(
                new SectionItemFieldSetting
                {
                    Id = 600,
                    SectionItemSettingId = 60,
                    FieldKey = "title",
                    Type = SectionItemFieldType.Title,
                    Required = true,
                    MaxLength = 100,
                    IsTranslatable = true,
                    SortOrder = 1,
                    CreatedAt = new DateTime(2024, 10, 21, 10, 0, 0),
                    Status = Status.Active,
                    IsDeleted = false
                },
                new SectionItemFieldSetting
                {
                    Id = 601,
                    SectionItemSettingId = 60,
                    FieldKey = "description",
                    Type = SectionItemFieldType.Description,
                    MaxLength = 300,
                    IsTranslatable = true,
                    SortOrder = 2,
                    CreatedAt = new DateTime(2024, 10, 21, 10, 0, 0),
                    Status = Status.Active,
                    IsDeleted = false
                },
                new SectionItemFieldSetting
                {
                    Id = 602,
                    SectionItemSettingId = 60,
                    FieldKey = "icon",
                    Type = SectionItemFieldType.Text,
                    MaxLength = 50,
                    Placeholder = "fa fa-check",
                    SortOrder = 3,
                    CreatedAt = new DateTime(2024, 10, 21, 10, 0, 0),
                    Status = Status.Active,
                    IsDeleted = false
                }
            );
        }

        private void SeedGridFields(EntityTypeBuilder<SectionItemFieldSetting> builder)
        {
            // Grid Item Fields (SettingId: 70)
            builder.HasData(
                new SectionItemFieldSetting
                {
                    Id = 700,
                    SectionItemSettingId = 70,
                    FieldKey = "image",
                    Type = SectionItemFieldType.Image,
                    Required = true,
                    SortOrder = 1,
                    CreatedAt = new DateTime(2024, 10, 21, 10, 0, 0),
                    Status = Status.Active,
                    IsDeleted = false
                },
                new SectionItemFieldSetting
                {
                    Id = 701,
                    SectionItemSettingId = 70,
                    FieldKey = "title",
                    Type = SectionItemFieldType.Title,
                    Required = true,
                    MaxLength = 100,
                    IsTranslatable = true,
                    SortOrder = 2,
                    CreatedAt = new DateTime(2024, 10, 21, 10, 0, 0),
                    Status = Status.Active,
                    IsDeleted = false
                },
                new SectionItemFieldSetting
                {
                    Id = 702,
                    SectionItemSettingId = 70,
                    FieldKey = "description",
                    Type = SectionItemFieldType.Description,
                    MaxLength = 200,
                    IsTranslatable = true,
                    SortOrder = 3,
                    CreatedAt = new DateTime(2024, 10, 21, 10, 0, 0),
                    Status = Status.Active,
                    IsDeleted = false
                },
                new SectionItemFieldSetting
                {
                    Id = 703,
                    SectionItemSettingId = 70,
                    FieldKey = "url",
                    Type = SectionItemFieldType.URL,
                    MaxLength = 500,
                    SortOrder = 4,
                    CreatedAt = new DateTime(2024, 10, 21, 10, 0, 0),
                    Status = Status.Active,
                    IsDeleted = false
                }
            );
        }

        private void SeedMasonryFields(EntityTypeBuilder<SectionItemFieldSetting> builder)
        {
            // Masonry Image Fields (SettingId: 80)
            builder.HasData(
                new SectionItemFieldSetting
                {
                    Id = 800,
                    SectionItemSettingId = 80,
                    FieldKey = "image",
                    Type = SectionItemFieldType.Image,
                    Required = true,
                    SortOrder = 1,
                    CreatedAt = new DateTime(2024, 10, 21, 10, 0, 0),
                    Status = Status.Active,
                    IsDeleted = false
                },
                new SectionItemFieldSetting
                {
                    Id = 801,
                    SectionItemSettingId = 80,
                    FieldKey = "altText",
                    Type = SectionItemFieldType.Text,
                    MaxLength = 100,
                    IsTranslatable = true,
                    SortOrder = 2,
                    CreatedAt = new DateTime(2024, 10, 21, 10, 0, 0),
                    Status = Status.Active,
                    IsDeleted = false
                },
                new SectionItemFieldSetting
                {
                    Id = 802,
                    SectionItemSettingId = 80,
                    FieldKey = "caption",
                    Type = SectionItemFieldType.Text,
                    MaxLength = 200,
                    IsTranslatable = true,
                    SortOrder = 3,
                    CreatedAt = new DateTime(2024, 10, 21, 10, 0, 0),
                    Status = Status.Active,
                    IsDeleted = false
                },
                new SectionItemFieldSetting
                {
                    Id = 803,
                    SectionItemSettingId = 80,
                    FieldKey = "linkUrl",
                    Type = SectionItemFieldType.URL,
                    MaxLength = 500,
                    SortOrder = 4,
                    CreatedAt = new DateTime(2024, 10, 21, 10, 0, 0),
                    Status = Status.Active,
                    IsDeleted = false
                }
            );
        }

        private void SeedListFields(EntityTypeBuilder<SectionItemFieldSetting> builder)
        {
            // List Item Fields (SettingId: 90)
            builder.HasData(
                new SectionItemFieldSetting
                {
                    Id = 900,
                    SectionItemSettingId = 90,
                    FieldKey = "title",
                    Type = SectionItemFieldType.Title,
                    Required = true,
                    MaxLength = 100,
                    IsTranslatable = true,
                    SortOrder = 1,
                    CreatedAt = new DateTime(2024, 10, 21, 10, 0, 0),
                    Status = Status.Active,
                    IsDeleted = false
                },
                new SectionItemFieldSetting
                {
                    Id = 901,
                    SectionItemSettingId = 90,
                    FieldKey = "description",
                    Type = SectionItemFieldType.Description,
                    MaxLength = 300,
                    IsTranslatable = true,
                    SortOrder = 2,
                    CreatedAt = new DateTime(2024, 10, 21, 10, 0, 0),
                    Status = Status.Active,
                    IsDeleted = false
                },
                new SectionItemFieldSetting
                {
                    Id = 902,
                    SectionItemSettingId = 90,
                    FieldKey = "icon",
                    Type = SectionItemFieldType.Text,
                    MaxLength = 50,
                    Placeholder = "fa fa-check",
                    SortOrder = 3,
                    CreatedAt = new DateTime(2024, 10, 21, 10, 0, 0),
                    Status = Status.Active,
                    IsDeleted = false
                }
            );
        }

        private void SeedSingleItemFields(EntityTypeBuilder<SectionItemFieldSetting> builder)
        {
            // Single Item Fields (SettingId: 101)
            builder.HasData(
                new SectionItemFieldSetting
                {
                    Id = 1010,
                    SectionItemSettingId = 101,
                    FieldKey = "image",
                    Type = SectionItemFieldType.Image,
                    SortOrder = 1,
                    CreatedAt = new DateTime(2024, 10, 21, 10, 0, 0),
                    Status = Status.Active,
                    IsDeleted = false
                },
                new SectionItemFieldSetting
                {
                    Id = 1011,
                    SectionItemSettingId = 101,
                    FieldKey = "title",
                    Type = SectionItemFieldType.Title,
                    Required = true,
                    MaxLength = 100,
                    IsTranslatable = true,
                    SortOrder = 2,
                    CreatedAt = new DateTime(2024, 10, 21, 10, 0, 0),
                    Status = Status.Active,
                    IsDeleted = false
                },
                new SectionItemFieldSetting
                {
                    Id = 1012,
                    SectionItemSettingId = 101,
                    FieldKey = "subtitle",
                    Type = SectionItemFieldType.Text,
                    MaxLength = 100,
                    IsTranslatable = true,
                    SortOrder = 3,
                    CreatedAt = new DateTime(2024, 10, 21, 10, 0, 0),
                    Status = Status.Active,
                    IsDeleted = false
                },
                new SectionItemFieldSetting
                {
                    Id = 1013,
                    SectionItemSettingId = 101,
                    FieldKey = "description",
                    Type = SectionItemFieldType.Description,
                    MaxLength = 500,
                    IsTranslatable = true,
                    SortOrder = 4,
                    CreatedAt = new DateTime(2024, 10, 21, 10, 0, 0),
                    Status = Status.Active,
                    IsDeleted = false
                },
                new SectionItemFieldSetting
                {
                    Id = 1014,
                    SectionItemSettingId = 101,
                    FieldKey = "buttonText",
                    Type = SectionItemFieldType.Text,
                    MaxLength = 50,
                    IsTranslatable = true,
                    SortOrder = 5,
                    CreatedAt = new DateTime(2024, 10, 21, 10, 0, 0),
                    Status = Status.Active,
                    IsDeleted = false
                },
                new SectionItemFieldSetting
                {
                    Id = 1015,
                    SectionItemSettingId = 101,
                    FieldKey = "buttonUrl",
                    Type = SectionItemFieldType.URL,
                    MaxLength = 500,
                    SortOrder = 6,
                    CreatedAt = new DateTime(2024, 10, 21, 10, 0, 0),
                    Status = Status.Active,
                    IsDeleted = false
                }
            );
        }

        private void SeedMultiItemFields(EntityTypeBuilder<SectionItemFieldSetting> builder)
        {
            // Multi Item Fields (SettingId: 110)
            builder.HasData(
                new SectionItemFieldSetting
                {
                    Id = 1100,
                    SectionItemSettingId = 110,
                    FieldKey = "image",
                    Type = SectionItemFieldType.Image,
                    SortOrder = 1,
                    CreatedAt = new DateTime(2024, 10, 21, 10, 0, 0),
                    Status = Status.Active,
                    IsDeleted = false
                },
                new SectionItemFieldSetting
                {
                    Id = 1101,
                    SectionItemSettingId = 110,
                    FieldKey = "title",
                    Type = SectionItemFieldType.Title,
                    Required = true,
                    MaxLength = 100,
                    IsTranslatable = true,
                    SortOrder = 2,
                    CreatedAt = new DateTime(2024, 10, 21, 10, 0, 0),
                    Status = Status.Active,
                    IsDeleted = false
                },
                new SectionItemFieldSetting
                {
                    Id = 1102,
                    SectionItemSettingId = 110,
                    FieldKey = "description",
                    Type = SectionItemFieldType.Description,
                    MaxLength = 300,
                    IsTranslatable = true,
                    SortOrder = 3,
                    CreatedAt = new DateTime(2024, 10, 21, 10, 0, 0),
                    Status = Status.Active,
                    IsDeleted = false
                },
                new SectionItemFieldSetting
                {
                    Id = 1103,
                    SectionItemSettingId = 110,
                    FieldKey = "url",
                    Type = SectionItemFieldType.URL,
                    MaxLength = 500,
                    SortOrder = 4,
                    CreatedAt = new DateTime(2024, 10, 21, 10, 0, 0),
                    Status = Status.Active,
                    IsDeleted = false
                }
            );
        }

        private void SeedAccordionFields(EntityTypeBuilder<SectionItemFieldSetting> builder)
        {
            // Accordion Panel Fields (SettingId: 120)
            builder.HasData(
                new SectionItemFieldSetting
                {
                    Id = 1200,
                    SectionItemSettingId = 120,
                    FieldKey = "title",
                    Type = SectionItemFieldType.Title,
                    Required = true,
                    MaxLength = 100,
                    IsTranslatable = true,
                    SortOrder = 1,
                    CreatedAt = new DateTime(2024, 10, 21, 10, 0, 0),
                    Status = Status.Active,
                    IsDeleted = false
                },
                new SectionItemFieldSetting
                {
                    Id = 1201,
                    SectionItemSettingId = 120,
                    FieldKey = "content",
                    Type = SectionItemFieldType.TextArea,
                    Required = true,
                    MaxLength = 1000,
                    IsTranslatable = true,
                    SortOrder = 2,
                    CreatedAt = new DateTime(2024, 10, 21, 10, 0, 0),
                    Status = Status.Active,
                    IsDeleted = false
                },
                new SectionItemFieldSetting
                {
                    Id = 1202,
                    SectionItemSettingId = 120,
                    FieldKey = "isOpen",
                    Type = SectionItemFieldType.Checkbox,
                    DefaultValue = "false",
                    SortOrder = 3,
                    CreatedAt = new DateTime(2024, 10, 21, 10, 0, 0),
                    Status = Status.Active,
                    IsDeleted = false
                }
            );
        }

        private void SeedTabsFields(EntityTypeBuilder<SectionItemFieldSetting> builder)
        {
            // Tab Fields (SettingId: 130)
            builder.HasData(
                new SectionItemFieldSetting
                {
                    Id = 1300,
                    SectionItemSettingId = 130,
                    FieldKey = "title",
                    Type = SectionItemFieldType.Title,
                    Required = true,
                    MaxLength = 50,
                    IsTranslatable = true,
                    SortOrder = 1,
                    CreatedAt = new DateTime(2024, 10, 21, 10, 0, 0),
                    Status = Status.Active,
                    IsDeleted = false
                },
                new SectionItemFieldSetting
                {
                    Id = 1301,
                    SectionItemSettingId = 130,
                    FieldKey = "icon",
                    Type = SectionItemFieldType.Text,
                    MaxLength = 50,
                    Placeholder = "fa fa-info",
                    SortOrder = 2,
                    CreatedAt = new DateTime(2024, 10, 21, 10, 0, 0),
                    Status = Status.Active,
                    IsDeleted = false
                },
                new SectionItemFieldSetting
                {
                    Id = 1302,
                    SectionItemSettingId = 130,
                    FieldKey = "content",
                    Type = SectionItemFieldType.TextArea,
                    Required = true,
                    MaxLength = 1000,
                    IsTranslatable = true,
                    SortOrder = 3,
                    CreatedAt = new DateTime(2024, 10, 21, 10, 0, 0),
                    Status = Status.Active,
                    IsDeleted = false
                }
            );
        }
    }
}

