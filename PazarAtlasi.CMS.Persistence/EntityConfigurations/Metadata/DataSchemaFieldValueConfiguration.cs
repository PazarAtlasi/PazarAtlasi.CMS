using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PazarAtlasi.CMS.Domain.Entities.Metadata;
using PazarAtlasi.CMS.Domain.Common;

namespace PazarAtlasi.CMS.Persistence.EntityConfigurations.Metadata
{
    public class DataSchemaFieldValueConfiguration : IEntityTypeConfiguration<DataSchemaFieldValue>
    {
        public void Configure(EntityTypeBuilder<DataSchemaFieldValue> builder)
        {
            // Table name and primary key
            builder.ToTable("DataSchemaFieldValues").HasKey(fv => fv.Id);

            // Property configurations
            builder.Property(fv => fv.Id).HasColumnName("Id").IsRequired();
            builder.Property(fv => fv.ProductId).HasColumnName("ProductId").IsRequired();
            builder.Property(fv => fv.SchemaId).HasColumnName("SchemaId").IsRequired();
            builder.Property(fv => fv.FieldId).HasColumnName("FieldId").IsRequired();
            builder.Property(fv => fv.Value).HasColumnName("Value").IsRequired().HasMaxLength(2000);
            builder.Property(fv => fv.JsonValue).HasColumnName("JsonValue").HasColumnType("nvarchar(max)");
            builder.Property(fv => fv.NumericValue).HasColumnName("NumericValue").HasColumnType("decimal(18,4)");
            builder.Property(fv => fv.BooleanValue).HasColumnName("BooleanValue");
            builder.Property(fv => fv.DateValue).HasColumnName("DateValue");
            builder.Property(fv => fv.SortOrder).HasColumnName("SortOrder").HasDefaultValue(0);
            builder.Property(fv => fv.Status).HasColumnName("Status").HasDefaultValue(Status.Active);
            builder.Property(fv => fv.CreatedAt).HasColumnName("CreatedAt").IsRequired();
            builder.Property(fv => fv.UpdatedAt).HasColumnName("UpdatedAt");
            builder.Property(fv => fv.IsDeleted).HasColumnName("IsDeleted").HasDefaultValue(false);

            // Relationships
            builder.HasOne(fv => fv.Product)
                   .WithMany(p => p.DataSchemaFieldValues)
                   .HasForeignKey(fv => fv.ProductId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(fv => fv.DataSchema)
                   .WithMany(ds => ds.FieldValues)
                   .HasForeignKey(fv => fv.SchemaId)
                   .OnDelete(DeleteBehavior.Restrict); // Prevent cascade delete conflicts

            builder.HasOne(fv => fv.DataSchemaField)
                   .WithMany(f => f.FieldValues)
                   .HasForeignKey(fv => fv.FieldId)
                   .OnDelete(DeleteBehavior.Restrict); // Prevent cascade delete conflicts

            builder.HasMany(fv => fv.Translations)
                   .WithOne(t => t.DataSchemaFieldValue)
                   .HasForeignKey(t => t.DataSchemaFieldValueId)
                   .OnDelete(DeleteBehavior.Cascade);

            // Indexes
            builder.HasIndex(fv => new { fv.ProductId, fv.SchemaId, fv.FieldId }).HasDatabaseName("IX_DataSchemaFieldValues_Product_Schema_Field").IsUnique();
            builder.HasIndex(fv => fv.ProductId).HasDatabaseName("IX_DataSchemaFieldValues_ProductId");
            builder.HasIndex(fv => fv.SchemaId).HasDatabaseName("IX_DataSchemaFieldValues_SchemaId");
            builder.HasIndex(fv => fv.FieldId).HasDatabaseName("IX_DataSchemaFieldValues_FieldId");
            builder.HasIndex(fv => fv.NumericValue).HasDatabaseName("IX_DataSchemaFieldValues_NumericValue");
            builder.HasIndex(fv => fv.BooleanValue).HasDatabaseName("IX_DataSchemaFieldValues_BooleanValue");
            builder.HasIndex(fv => fv.DateValue).HasDatabaseName("IX_DataSchemaFieldValues_DateValue");
            builder.HasIndex(fv => fv.SortOrder).HasDatabaseName("IX_DataSchemaFieldValues_SortOrder");

            // Query Filter (Soft Delete)
            builder.HasQueryFilter(fv => !fv.IsDeleted);
        }
    }
}