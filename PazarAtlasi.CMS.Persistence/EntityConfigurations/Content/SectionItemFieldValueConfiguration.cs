using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PazarAtlasi.CMS.Domain.Entities.Content;

namespace PazarAtlasi.CMS.Persistence.EntityConfigurations.Content
{
    public class SectionItemFieldValueConfiguration : IEntityTypeConfiguration<SectionItemFieldValue>
    {
        public void Configure(EntityTypeBuilder<SectionItemFieldValue> builder)
        {
            builder.ToTable("SectionItemFieldValues");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Value)
                .HasMaxLength(4000)
                .IsRequired();

            builder.Property(x => x.JsonValue)
                .HasColumnType("nvarchar(max)");

            // Relationships
            builder.HasOne(x => x.SectionItem)
                .WithMany(x => x.FieldValues)
                .HasForeignKey(x => x.SectionItemId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(x => x.SectionItemField)
                .WithMany(x => x.Values)
                .HasForeignKey(x => x.SectionItemFieldId)
                .OnDelete(DeleteBehavior.Cascade);

            // Indexes
            builder.HasIndex(x => new { x.SectionItemId, x.SectionItemFieldId })
                .IsUnique()
                .HasDatabaseName("IX_SectionItemFieldValues_SectionItemId_FieldId");

            builder.HasIndex(x => x.SectionItemFieldId)
                .HasDatabaseName("IX_SectionItemFieldValues_FieldId");

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