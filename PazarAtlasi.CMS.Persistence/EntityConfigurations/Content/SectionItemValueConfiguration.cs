using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PazarAtlasi.CMS.Domain.Common;
using PazarAtlasi.CMS.Domain.Entities.Content;

namespace PazarAtlasi.CMS.Persistence.EntityConfigurations.Content
{
    public class SectionItemValueConfigurationBuilder : IEntityTypeConfiguration<SectionItemValue>
    {
        public void Configure(EntityTypeBuilder<SectionItemValue> builder)
        {
            builder.ToTable("SectionItemValues").HasKey(siv => siv.Id);

            builder.Property(siv => siv.Id).HasColumnName("Id").IsRequired();
            builder.Property(siv => siv.SectionId).HasColumnName("SectionId").IsRequired();
            builder.Property(siv => siv.SectionItemId).HasColumnName("SectionItemId").IsRequired();
            builder.Property(siv => siv.CreatedAt).HasColumnName("CreatedAt").IsRequired();
            builder.Property(siv => siv.UpdatedAt).HasColumnName("UpdatedAt");
            builder.Property(siv => siv.IsDeleted).HasColumnName("IsDeleted").HasDefaultValue(false);
            builder.Property(siv => siv.Status).HasColumnName("Status").HasDefaultValue(Status.Draft);
            builder.Property(siv => siv.CreatedBy).HasColumnName("CreatedBy");
            builder.Property(siv => siv.UpdatedBy).HasColumnName("UpdatedBy");

            // Foreign Key Relationships
            builder.HasOne(siv => siv.Section)
                   .WithMany(s => s.SectionItemValues)
                   .HasForeignKey(siv => siv.SectionId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(siv => siv.SectionItem)
                   .WithMany(si => si.SectionItemValues)
                   .HasForeignKey(siv => siv.SectionItemId)
                   .OnDelete(DeleteBehavior.Cascade);

            // Indexes
            builder.HasIndex(siv => siv.SectionId).HasDatabaseName("IX_SectionItemValues_SectionId");
            builder.HasIndex(siv => siv.SectionItemId).HasDatabaseName("IX_SectionItemValues_SectionItemId");
            builder.HasIndex(siv => new { siv.SectionId, siv.SectionItemId }).HasDatabaseName("IX_SectionItemValues_SectionId_SectionItemId");

            // Query Filter
            builder.HasQueryFilter(siv => !siv.IsDeleted);
        }
    }
}