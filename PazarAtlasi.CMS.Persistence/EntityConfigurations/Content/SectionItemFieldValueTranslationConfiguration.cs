using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PazarAtlasi.CMS.Domain.Entities.Content;

namespace PazarAtlasi.CMS.Persistence.EntityConfigurations.Content
{
    public class SectionItemFieldValueTranslationConfiguration : IEntityTypeConfiguration<SectionItemFieldValueTranslation>
    {
        public void Configure(EntityTypeBuilder<SectionItemFieldValueTranslation> builder)
        {
            builder.ToTable("SectionItemFieldValueTranslations");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Value)
                .HasMaxLength(4000)
                .IsRequired();

            builder.Property(x => x.JsonValue)
                .HasColumnType("nvarchar(max)");

            // Relationships
            builder.HasOne(x => x.SectionItemFieldValue)
                .WithMany(x => x.Translations)
                .HasForeignKey(x => x.SectionItemFieldValueId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(x => x.Language)
                .WithMany()
                .HasForeignKey(x => x.LanguageId)
                .OnDelete(DeleteBehavior.Restrict);

            // Indexes
            builder.HasIndex(x => new { x.SectionItemFieldValueId, x.LanguageId })
                .IsUnique()
                .HasDatabaseName("IX_SectionItemFieldValueTranslations_ValueId_LanguageId");

            builder.HasIndex(x => x.LanguageId)
                .HasDatabaseName("IX_SectionItemFieldValueTranslations_LanguageId");

            // Base entity configuration
            builder.Property(x => x.CreatedAt)
                .IsRequired();

            builder.Property(x => x.UpdatedAt);

            builder.Property(x => x.IsDeleted)
                .HasDefaultValue(false);

            builder.HasQueryFilter(x => !x.IsDeleted);
        }
    }
}