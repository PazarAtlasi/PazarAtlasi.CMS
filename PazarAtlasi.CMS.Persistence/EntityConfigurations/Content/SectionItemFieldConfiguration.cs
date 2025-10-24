using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PazarAtlasi.CMS.Domain.Entities.Content;

namespace PazarAtlasi.CMS.Persistence.EntityConfigurations.Content
{
    public class SectionItemFieldConfiguration : IEntityTypeConfiguration<SectionItemField>
    {
        public void Configure(EntityTypeBuilder<SectionItemField> builder)
        {
            builder.ToTable("SectionItemFields");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.FieldKey)
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(x => x.FieldName)
                .HasMaxLength(200)
                .IsRequired();

            builder.Property(x => x.Type)
                .IsRequired();

            builder.Property(x => x.Placeholder)
                .HasMaxLength(500);

            builder.Property(x => x.DefaultValue)
                .HasMaxLength(1000);

            builder.Property(x => x.OptionsJson)
                .HasColumnType("nvarchar(max)");

            // Relationships
            builder.HasOne(x => x.Template)
                .WithMany(t => t.Fields)
                .HasForeignKey(x => x.TemplateId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(x => x.Translations)
                .WithOne(x => x.SectionItemField)
                .HasForeignKey(x => x.SectionItemFieldId)
                .OnDelete(DeleteBehavior.Cascade);

            // Indexes
            builder.HasIndex(x => new { x.TemplateId, x.FieldKey })
                .HasDatabaseName("IX_SectionItemFields_TemplateId_FieldKey");

            builder.HasIndex(x => x.FieldKey)
                .HasDatabaseName("IX_SectionItemFields_FieldKey");

            builder.HasIndex(x => x.SortOrder)
                .HasDatabaseName("IX_SectionItemFields_SortOrder");

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