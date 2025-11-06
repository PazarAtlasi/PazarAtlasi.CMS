using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PazarAtlasi.CMS.Domain.Entities.Metadata;
using PazarAtlasi.CMS.Domain.Common;

namespace PazarAtlasi.CMS.Persistence.EntityConfigurations.Metadata
{
    public class DataSchemaTranslationConfiguration : IEntityTypeConfiguration<DataSchemaTranslation>
    {
        public void Configure(EntityTypeBuilder<DataSchemaTranslation> builder)
        {
            // Table name and primary key
            builder.ToTable("DataSchemaTranslations").HasKey(t => t.Id);

            // Property configurations
            builder.Property(t => t.Id).HasColumnName("Id").IsRequired();
            builder.Property(t => t.DataSchemaId).HasColumnName("DataSchemaId").IsRequired();
            builder.Property(t => t.LanguageId).HasColumnName("LanguageId").IsRequired();
            builder.Property(t => t.Name).HasColumnName("Name").IsRequired().HasMaxLength(200);
            builder.Property(t => t.Description).HasColumnName("Description").HasMaxLength(1000);
            builder.Property(t => t.Category).HasColumnName("Category").HasMaxLength(100);
            builder.Property(t => t.Status).HasColumnName("Status").HasDefaultValue(Status.Active);
            builder.Property(t => t.CreatedAt).HasColumnName("CreatedAt").IsRequired();
            builder.Property(t => t.UpdatedAt).HasColumnName("UpdatedAt");
            builder.Property(t => t.IsDeleted).HasColumnName("IsDeleted").HasDefaultValue(false);

            // Relationships
            builder.HasOne(t => t.DataSchema)
                   .WithMany(ds => ds.Translations)
                   .HasForeignKey(t => t.DataSchemaId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(t => t.Language)
                   .WithMany()
                   .HasForeignKey(t => t.LanguageId)
                   .OnDelete(DeleteBehavior.Restrict);

            // Indexes
            builder.HasIndex(t => new { t.DataSchemaId, t.LanguageId }).HasDatabaseName("IX_DataSchemaTranslations_Schema_Language").IsUnique();
            builder.HasIndex(t => t.DataSchemaId).HasDatabaseName("IX_DataSchemaTranslations_DataSchemaId");
            builder.HasIndex(t => t.LanguageId).HasDatabaseName("IX_DataSchemaTranslations_LanguageId");

            // Query Filter (Soft Delete)
            builder.HasQueryFilter(t => !t.IsDeleted);
        }
    }
}