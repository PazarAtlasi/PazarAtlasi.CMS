using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PazarAtlasi.CMS.Domain.Entities.Metadata;
using PazarAtlasi.CMS.Domain.Common;

namespace PazarAtlasi.CMS.Persistence.EntityConfigurations.Metadata
{
    public class DataSchemaFieldTranslationConfiguration : IEntityTypeConfiguration<DataSchemaFieldTranslation>
    {
        public void Configure(EntityTypeBuilder<DataSchemaFieldTranslation> builder)
        {
            // Table name and primary key
            builder.ToTable("DataSchemaFieldTranslations").HasKey(t => t.Id);

            // Property configurations
            builder.Property(t => t.Id).HasColumnName("Id").IsRequired();
            builder.Property(t => t.DataSchemaFieldId).HasColumnName("DataSchemaFieldId").IsRequired();
            builder.Property(t => t.LanguageId).HasColumnName("LanguageId").IsRequired();
            builder.Property(t => t.FieldName).HasColumnName("FieldName").IsRequired().HasMaxLength(200);
            builder.Property(t => t.Description).HasColumnName("Description").HasMaxLength(500);
            builder.Property(t => t.Placeholder).HasColumnName("Placeholder").HasMaxLength(200);
            builder.Property(t => t.Unit).HasColumnName("Unit").HasMaxLength(50);
            builder.Property(t => t.OptionsJson).HasColumnName("OptionsJson").HasColumnType("nvarchar(max)");
            builder.Property(t => t.Status).HasColumnName("Status").HasDefaultValue(Status.Active);
            builder.Property(t => t.CreatedAt).HasColumnName("CreatedAt").IsRequired();
            builder.Property(t => t.UpdatedAt).HasColumnName("UpdatedAt");
            builder.Property(t => t.IsDeleted).HasColumnName("IsDeleted").HasDefaultValue(false);

            // Relationships
            builder.HasOne(t => t.DataSchemaField)
                   .WithMany(f => f.Translations)
                   .HasForeignKey(t => t.DataSchemaFieldId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(t => t.Language)
                   .WithMany()
                   .HasForeignKey(t => t.LanguageId)
                   .OnDelete(DeleteBehavior.Restrict);

            // Indexes
            builder.HasIndex(t => new { t.DataSchemaFieldId, t.LanguageId }).HasDatabaseName("IX_DataSchemaFieldTranslations_Field_Language").IsUnique();
            builder.HasIndex(t => t.DataSchemaFieldId).HasDatabaseName("IX_DataSchemaFieldTranslations_DataSchemaFieldId");
            builder.HasIndex(t => t.LanguageId).HasDatabaseName("IX_DataSchemaFieldTranslations_LanguageId");

            // Query Filter (Soft Delete)
            builder.HasQueryFilter(t => !t.IsDeleted);
        }
    }
}