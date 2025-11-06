using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PazarAtlasi.CMS.Domain.Entities.Metadata;
using PazarAtlasi.CMS.Domain.Enums;
using PazarAtlasi.CMS.Domain.Common;

namespace PazarAtlasi.CMS.Persistence.EntityConfigurations.Metadata
{
    public class DataSchemaFieldConfiguration : IEntityTypeConfiguration<DataSchemaField>
    {
        public void Configure(EntityTypeBuilder<DataSchemaField> builder)
        {
            // Table name and primary key
            builder.ToTable("DataSchemaFields").HasKey(f => f.Id);

            // Property configurations
            builder.Property(f => f.Id).HasColumnName("Id").IsRequired();
            builder.Property(f => f.DataSchemaId).HasColumnName("DataSchemaId").IsRequired();
            builder.Property(f => f.FieldKey).HasColumnName("FieldKey").IsRequired().HasMaxLength(100);
            builder.Property(f => f.FieldName).HasColumnName("FieldName").IsRequired().HasMaxLength(200);
            builder.Property(f => f.Description).HasColumnName("Description").HasMaxLength(500);
            builder.Property(f => f.Type).HasColumnName("Type").HasDefaultValue(DataSchemaFieldType.Text);
            builder.Property(f => f.IsRequired).HasColumnName("IsRequired").HasDefaultValue(false);
            builder.Property(f => f.IsTranslatable).HasColumnName("IsTranslatable").HasDefaultValue(false);
            builder.Property(f => f.ShowInListing).HasColumnName("ShowInListing").HasDefaultValue(true);
            builder.Property(f => f.ShowInDetails).HasColumnName("ShowInDetails").HasDefaultValue(true);
            builder.Property(f => f.IsFilterable).HasColumnName("IsFilterable").HasDefaultValue(false);
            builder.Property(f => f.IsSortable).HasColumnName("IsSortable").HasDefaultValue(false);
            builder.Property(f => f.DefaultValue).HasColumnName("DefaultValue").HasMaxLength(500);
            builder.Property(f => f.Placeholder).HasColumnName("Placeholder").HasMaxLength(200);
            builder.Property(f => f.OptionsJson).HasColumnName("OptionsJson").HasColumnType("nvarchar(max)");
            builder.Property(f => f.ValidationRules).HasColumnName("ValidationRules").HasColumnType("nvarchar(max)");
            builder.Property(f => f.Unit).HasColumnName("Unit").HasMaxLength(50);
            builder.Property(f => f.SortOrder).HasColumnName("SortOrder").HasDefaultValue(0);
            builder.Property(f => f.IsActive).HasColumnName("IsActive").HasDefaultValue(true);
            builder.Property(f => f.Status).HasColumnName("Status").HasDefaultValue(Status.Active);
            builder.Property(f => f.CreatedAt).HasColumnName("CreatedAt").IsRequired();
            builder.Property(f => f.UpdatedAt).HasColumnName("UpdatedAt");
            builder.Property(f => f.IsDeleted).HasColumnName("IsDeleted").HasDefaultValue(false);

            // Relationships
            builder.HasOne(f => f.DataSchema)
                   .WithMany(ds => ds.Fields)
                   .HasForeignKey(f => f.DataSchemaId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(f => f.FieldValues)
                   .WithOne(fv => fv.DataSchemaField)
                   .HasForeignKey(fv => fv.FieldId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(f => f.Translations)
                   .WithOne(t => t.DataSchemaField)
                   .HasForeignKey(t => t.DataSchemaFieldId)
                   .OnDelete(DeleteBehavior.Cascade);

            // Indexes
            builder.HasIndex(f => new { f.DataSchemaId, f.FieldKey }).HasDatabaseName("IX_DataSchemaFields_SchemaId_FieldKey").IsUnique();
            builder.HasIndex(f => f.FieldName).HasDatabaseName("IX_DataSchemaFields_FieldName");
            builder.HasIndex(f => f.Type).HasDatabaseName("IX_DataSchemaFields_Type");
            builder.HasIndex(f => f.SortOrder).HasDatabaseName("IX_DataSchemaFields_SortOrder");
            builder.HasIndex(f => f.IsActive).HasDatabaseName("IX_DataSchemaFields_IsActive");
            builder.HasIndex(f => f.IsFilterable).HasDatabaseName("IX_DataSchemaFields_IsFilterable");
            builder.HasIndex(f => f.IsSortable).HasDatabaseName("IX_DataSchemaFields_IsSortable");

            // Query Filter (Soft Delete)
            builder.HasQueryFilter(f => !f.IsDeleted);

            // Seed Data - Smartphone Specifications
            builder.HasData(
                // Storage
                new DataSchemaField
                {
                    Id = 1,
                    DataSchemaId = 2, // Smartphone Specifications
                    FieldKey = "storage_gb",
                    FieldName = "Storage",
                    Description = "Internal storage capacity",
                    Type = DataSchemaFieldType.Select,
                    IsRequired = true,
                    ShowInListing = true,
                    ShowInDetails = true,
                    IsFilterable = true,
                    IsSortable = true,
                    Unit = "GB",
                    OptionsJson = "[{\"value\":\"64\",\"label\":\"64 GB\"},{\"value\":\"128\",\"label\":\"128 GB\"},{\"value\":\"256\",\"label\":\"256 GB\"},{\"value\":\"512\",\"label\":\"512 GB\"},{\"value\":\"1024\",\"label\":\"1 TB\"}]",
                    SortOrder = 1,
                    IsActive = true,
                    Status = Status.Active,
                    CreatedAt = DateTime.UtcNow,
                    IsDeleted = false
                },
                // Screen Size
                new DataSchemaField
                {
                    Id = 2,
                    DataSchemaId = 2, // Smartphone Specifications
                    FieldKey = "screen_size",
                    FieldName = "Screen Size",
                    Description = "Display screen size",
                    Type = DataSchemaFieldType.Number,
                    IsRequired = true,
                    ShowInListing = true,
                    ShowInDetails = true,
                    IsFilterable = true,
                    IsSortable = true,
                    Unit = "inches",
                    ValidationRules = "{\"min\":3.0,\"max\":10.0,\"step\":0.1}",
                    SortOrder = 2,
                    IsActive = true,
                    Status = Status.Active,
                    CreatedAt = DateTime.UtcNow,
                    IsDeleted = false
                },
                // Screen Type
                new DataSchemaField
                {
                    Id = 3,
                    DataSchemaId = 2, // Smartphone Specifications
                    FieldKey = "screen_type",
                    FieldName = "Screen Type",
                    Description = "Display technology type",
                    Type = DataSchemaFieldType.Select,
                    IsRequired = false,
                    ShowInListing = true,
                    ShowInDetails = true,
                    IsFilterable = true,
                    OptionsJson = "[{\"value\":\"LCD\",\"label\":\"LCD\"},{\"value\":\"OLED\",\"label\":\"OLED\"},{\"value\":\"AMOLED\",\"label\":\"AMOLED\"},{\"value\":\"Super AMOLED\",\"label\":\"Super AMOLED\"},{\"value\":\"IPS\",\"label\":\"IPS\"}]",
                    SortOrder = 3,
                    IsActive = true,
                    Status = Status.Active,
                    CreatedAt = DateTime.UtcNow,
                    IsDeleted = false
                },
                // Brightness
                new DataSchemaField
                {
                    Id = 4,
                    DataSchemaId = 2, // Smartphone Specifications
                    FieldKey = "brightness",
                    FieldName = "Brightness",
                    Description = "Maximum screen brightness",
                    Type = DataSchemaFieldType.Number,
                    IsRequired = false,
                    ShowInListing = false,
                    ShowInDetails = true,
                    IsFilterable = true,
                    IsSortable = true,
                    Unit = "nits",
                    ValidationRules = "{\"min\":100,\"max\":3000}",
                    SortOrder = 4,
                    IsActive = true,
                    Status = Status.Active,
                    CreatedAt = DateTime.UtcNow,
                    IsDeleted = false
                },
                // RAM
                new DataSchemaField
                {
                    Id = 5,
                    DataSchemaId = 2, // Smartphone Specifications
                    FieldKey = "ram_gb",
                    FieldName = "RAM",
                    Description = "Random Access Memory",
                    Type = DataSchemaFieldType.Select,
                    IsRequired = true,
                    ShowInListing = true,
                    ShowInDetails = true,
                    IsFilterable = true,
                    IsSortable = true,
                    Unit = "GB",
                    OptionsJson = "[{\"value\":\"2\",\"label\":\"2 GB\"},{\"value\":\"3\",\"label\":\"3 GB\"},{\"value\":\"4\",\"label\":\"4 GB\"},{\"value\":\"6\",\"label\":\"6 GB\"},{\"value\":\"8\",\"label\":\"8 GB\"},{\"value\":\"12\",\"label\":\"12 GB\"},{\"value\":\"16\",\"label\":\"16 GB\"}]",
                    SortOrder = 5,
                    IsActive = true,
                    Status = Status.Active,
                    CreatedAt = DateTime.UtcNow,
                    IsDeleted = false
                },
                // Battery Capacity
                new DataSchemaField
                {
                    Id = 6,
                    DataSchemaId = 2, // Smartphone Specifications
                    FieldKey = "battery_mah",
                    FieldName = "Battery Capacity",
                    Description = "Battery capacity in mAh",
                    Type = DataSchemaFieldType.Number,
                    IsRequired = false,
                    ShowInListing = true,
                    ShowInDetails = true,
                    IsFilterable = true,
                    IsSortable = true,
                    Unit = "mAh",
                    ValidationRules = "{\"min\":1000,\"max\":10000}",
                    SortOrder = 6,
                    IsActive = true,
                    Status = Status.Active,
                    CreatedAt = DateTime.UtcNow,
                    IsDeleted = false
                }
            );
        }
    }
}