using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PazarAtlasi.CMS.Domain.Entities.Metadata;
using PazarAtlasi.CMS.Domain.Common;

namespace PazarAtlasi.CMS.Persistence.EntityConfigurations.Metadata
{
    public class DataSchemaConfiguration : IEntityTypeConfiguration<DataSchema>
    {
        public void Configure(EntityTypeBuilder<DataSchema> builder)
        {
            // Table name and primary key
            builder.ToTable("DataSchemas").HasKey(ds => ds.Id);

            // Property configurations
            builder.Property(ds => ds.Id).HasColumnName("Id").IsRequired();
            builder.Property(ds => ds.Name).HasColumnName("Name").IsRequired().HasMaxLength(200);
            builder.Property(ds => ds.Key).HasColumnName("Key").IsRequired().HasMaxLength(100);
            builder.Property(ds => ds.Description).HasColumnName("Description").HasMaxLength(1000);
            builder.Property(ds => ds.Category).HasColumnName("Category").HasMaxLength(100);
            builder.Property(ds => ds.Configuration).HasColumnName("Configuration").HasColumnType("nvarchar(max)");
            builder.Property(ds => ds.SortOrder).HasColumnName("SortOrder").HasDefaultValue(0);
            builder.Property(ds => ds.IsActive).HasColumnName("IsActive").HasDefaultValue(true);
            builder.Property(ds => ds.Status).HasColumnName("Status").HasDefaultValue(Status.Active);
            builder.Property(ds => ds.CreatedAt).HasColumnName("CreatedAt").IsRequired();
            builder.Property(ds => ds.UpdatedAt).HasColumnName("UpdatedAt");
            builder.Property(ds => ds.IsDeleted).HasColumnName("IsDeleted").HasDefaultValue(false);

            // Relationships
            builder.HasMany(ds => ds.Fields)
                   .WithOne(f => f.DataSchema)
                   .HasForeignKey(f => f.DataSchemaId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(ds => ds.ProductDataSchemas)
                   .WithOne(pds => pds.DataSchema)
                   .HasForeignKey(pds => pds.SchemaId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(ds => ds.FieldValues)
                   .WithOne(fv => fv.DataSchema)
                   .HasForeignKey(fv => fv.SchemaId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(ds => ds.Translations)
                   .WithOne(t => t.DataSchema)
                   .HasForeignKey(t => t.DataSchemaId)
                   .OnDelete(DeleteBehavior.Cascade);

            // Indexes
            builder.HasIndex(ds => ds.Key).HasDatabaseName("IX_DataSchemas_Key").IsUnique();
            builder.HasIndex(ds => ds.Name).HasDatabaseName("IX_DataSchemas_Name");
            builder.HasIndex(ds => ds.Category).HasDatabaseName("IX_DataSchemas_Category");
            builder.HasIndex(ds => ds.SortOrder).HasDatabaseName("IX_DataSchemas_SortOrder");
            builder.HasIndex(ds => ds.IsActive).HasDatabaseName("IX_DataSchemas_IsActive");
            builder.HasIndex(ds => ds.Status).HasDatabaseName("IX_DataSchemas_Status");

            // Query Filter (Soft Delete)
            builder.HasQueryFilter(ds => !ds.IsDeleted);

            // Seed Data
            builder.HasData(
                new DataSchema
                {
                    Id = 1,
                    Name = "Electronics Specifications",
                    Key = "electronics-specs",
                    Description = "General specifications for electronic products",
                    Category = "Electronics",
                    Configuration = "{}",
                    SortOrder = 1,
                    IsActive = true,
                    Status = Status.Active,
                    CreatedAt = DateTime.UtcNow,
                    IsDeleted = false
                },
                new DataSchema
                {
                    Id = 2,
                    Name = "Smartphone Specifications",
                    Key = "smartphone-specs",
                    Description = "Detailed specifications for smartphones",
                    Category = "Electronics",
                    Configuration = "{}",
                    SortOrder = 2,
                    IsActive = true,
                    Status = Status.Active,
                    CreatedAt = DateTime.UtcNow,
                    IsDeleted = false
                },
                new DataSchema
                {
                    Id = 3,
                    Name = "Laptop Specifications",
                    Key = "laptop-specs",
                    Description = "Detailed specifications for laptops",
                    Category = "Electronics",
                    Configuration = "{}",
                    SortOrder = 3,
                    IsActive = true,
                    Status = Status.Active,
                    CreatedAt = DateTime.UtcNow,
                    IsDeleted = false
                }
            );
        }
    }
}