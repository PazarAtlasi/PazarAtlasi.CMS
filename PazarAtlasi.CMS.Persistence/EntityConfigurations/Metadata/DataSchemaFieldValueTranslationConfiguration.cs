using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PazarAtlasi.CMS.Domain.Entities.Metadata;
using PazarAtlasi.CMS.Domain.Common;

namespace PazarAtlasi.CMS.Persistence.EntityConfigurations.Metadata
{
    public class DataSchemaFieldValueTranslationConfiguration : IEntityTypeConfiguration<DataSchemaFieldValueTranslation>
    {
        public void Configure(EntityTypeBuilder<DataSchemaFieldValueTranslation> builder)
        {
            // Table name and primary key
            builder.ToTable("DataSchemaFieldValueTranslations").HasKey(t => t.Id);

            // Property configurations
            builder.Property(t => t.Id).HasColumnName("Id").IsRequired();
            builder.Property(t => t.DataSchemaFieldValueId).HasColumnName("DataSchemaFieldValueId").IsRequired();
            builder.Property(t => t.LanguageId).HasColumnName("LanguageId").IsRequired();
            builder.Property(t => t.Value).HasColumnName("Value").IsRequired().HasMaxLength(2000);
            builder.Property(t => t.JsonValue).HasColumnName("JsonValue").HasColumnType("nvarchar(max)");
            builder.Property(t => t.Status).HasColumnName("Status").HasDefaultValue(Status.Active);
            builder.Property(t => t.CreatedAt).HasColumnName("CreatedAt").IsRequired();
            builder.Property(t => t.UpdatedAt).HasColumnName("UpdatedAt");
            builder.Property(t => t.IsDeleted).HasColumnName("IsDeleted").HasDefaultValue(false);

            // Relationships
            builder.HasOne(t => t.DataSchemaFieldValue)
                   .WithMany(fv => fv.Translations)
                   .HasForeignKey(t => t.DataSchemaFieldValueId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(t => t.Language)
                   .WithMany()
                   .HasForeignKey(t => t.LanguageId)
                   .OnDelete(DeleteBehavior.Restrict);

            // Indexes
            builder.HasIndex(t => new { t.DataSchemaFieldValueId, t.LanguageId }).HasDatabaseName("IX_DataSchemaFieldValueTranslations_Value_Language").IsUnique();
            builder.HasIndex(t => t.DataSchemaFieldValueId).HasDatabaseName("IX_DataSchemaFieldValueTranslations_DataSchemaFieldValueId");
            builder.HasIndex(t => t.LanguageId).HasDatabaseName("IX_DataSchemaFieldValueTranslations_LanguageId");

            // Query Filter (Soft Delete)
            builder.HasQueryFilter(t => !t.IsDeleted);
        }
    }
}