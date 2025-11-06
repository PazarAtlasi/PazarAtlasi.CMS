using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PazarAtlasi.CMS.Domain.Entities.Metadata;

namespace PazarAtlasi.CMS.Persistence.EntityConfigurations.Metadata
{
    public class VariantTranslationConfiguration : IEntityTypeConfiguration<VariantTranslation>
    {
        public void Configure(EntityTypeBuilder<VariantTranslation> builder)
        {
            // Table name and primary key
            builder.ToTable("VariantTranslations").HasKey(vt => vt.Id);

            // Properties
            builder.Property(vt => vt.Id).HasColumnName("Id").IsRequired();
            builder.Property(vt => vt.VariantId).HasColumnName("VariantId").IsRequired();
            builder.Property(vt => vt.LanguageId).HasColumnName("LanguageId").IsRequired();
            builder.Property(vt => vt.Name).HasColumnName("Name").IsRequired().HasMaxLength(255);
            builder.Property(vt => vt.ShortDescription).HasColumnName("ShortDescription").HasMaxLength(500);
            builder.Property(vt => vt.LongDescription).HasColumnName("LongDescription").HasMaxLength(2000);
            builder.Property(vt => vt.Status).HasColumnName("Status").HasDefaultValue(Domain.Common.Status.Active);
            builder.Property(vt => vt.CreatedAt).HasColumnName("CreatedAt").IsRequired();
            builder.Property(vt => vt.UpdatedAt).HasColumnName("UpdatedAt");
            builder.Property(vt => vt.IsDeleted).HasColumnName("IsDeleted").HasDefaultValue(false);

            // Relationships
            builder.HasOne(vt => vt.Variant)
                   .WithMany(v => v.Translations)
                   .HasForeignKey(vt => vt.VariantId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(vt => vt.Language)
                   .WithMany()
                   .HasForeignKey(vt => vt.LanguageId)
                   .OnDelete(DeleteBehavior.Restrict);

            // Indexes
            builder.HasIndex(vt => new { vt.VariantId, vt.LanguageId })
                   .HasDatabaseName("IX_VariantTranslations_VariantId_LanguageId")
                   .IsUnique();

            // Query Filter (Soft Delete)
            builder.HasQueryFilter(vt => !vt.IsDeleted);
        }
    }
}