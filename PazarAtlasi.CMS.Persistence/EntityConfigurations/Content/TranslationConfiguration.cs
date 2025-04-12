using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PazarAtlasi.CMS.Domain.Entities.Content;

namespace PazarAtlasi.CMS.Persistence.EntityConfigurations.Content
{
    public class TranslationConfiguration : IEntityTypeConfiguration<Translation>
    {
        public void Configure(EntityTypeBuilder<Translation> builder)
        {
            builder.ToTable("Translations");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Key)
                .IsRequired()
                .HasMaxLength(255);

            builder.Property(x => x.Language)
                .IsRequired()
                .HasMaxLength(10);

            builder.Property(x => x.Value)
                .IsRequired()
                .HasColumnType("nvarchar(max)");

            // Create a unique index on Key and Language
            builder.HasIndex(x => new { x.Key, x.Language })
                .IsUnique()
                .HasFilter("IsDeleted = 0");
        }
    }
} 