using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PazarAtlasi.CMS.Domain.Entities.Content;
using PazarAtlasi.CMS.Persistence.EntityConfigurations.Content.SeedData;

namespace PazarAtlasi.CMS.Persistence.EntityConfigurations.Content
{
    public class SectionItemFieldTranslationConfiguration : IEntityTypeConfiguration<SectionItemFieldTranslation>
    {
        public void Configure(EntityTypeBuilder<SectionItemFieldTranslation> builder)
        {
            builder.ToTable("SectionItemFieldTranslations");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Label)
                .HasMaxLength(200)
                .IsRequired();

            builder.Property(x => x.Description)
                .HasMaxLength(500);

            builder.Property(x => x.Placeholder)
                .HasMaxLength(200);

            // Relationships
            builder.HasOne(x => x.SectionItemField)
                .WithMany(x => x.Translations)
                .HasForeignKey(x => x.SectionItemFieldId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(x => x.Language)
                .WithMany()
                .HasForeignKey(x => x.LanguageId)
                .OnDelete(DeleteBehavior.Cascade);

            // Indexes
            builder.HasIndex(x => new { x.SectionItemFieldId, x.LanguageId })
                .IsUnique()
                .HasDatabaseName("IX_SectionItemFieldTranslations_FieldId_LanguageId");

            builder.HasIndex(x => x.LanguageId)
                .HasDatabaseName("IX_SectionItemFieldTranslations_LanguageId");

            // Base entity configuration
            builder.Property(x => x.CreatedAt)
                .IsRequired();

            builder.Property(x => x.UpdatedAt);

            builder.Property(x => x.IsDeleted)
                .HasDefaultValue(false);

            builder.HasQueryFilter(x => !x.IsDeleted);

            // Seed Data
            builder.SeedCommonFieldTranslations();
        }
    }
}