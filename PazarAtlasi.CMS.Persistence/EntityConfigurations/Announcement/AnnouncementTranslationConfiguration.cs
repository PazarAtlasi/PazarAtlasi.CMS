using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PazarAtlasi.CMS.Domain.Entities.Announcement;
using PazarAtlasi.CMS.Domain.Common;

namespace PazarAtlasi.CMS.Persistence.EntityConfigurations.Announcement
{
    public class AnnouncementTranslationConfiguration : IEntityTypeConfiguration<AnnouncementTranslation>
    {
        public void Configure(EntityTypeBuilder<AnnouncementTranslation> builder)
        {
            builder.ToTable("AnnouncementTranslations").HasKey(at => at.Id);

            builder.Property(at => at.Id).HasColumnName("Id").IsRequired();
            builder.Property(at => at.AnnouncementId).HasColumnName("AnnouncementId").IsRequired();
            builder.Property(at => at.LanguageId).HasColumnName("LanguageId").IsRequired();
            builder.Property(at => at.Title).HasColumnName("Title").HasMaxLength(500).IsRequired();
            builder.Property(at => at.Content).HasColumnName("Content").HasColumnType("nvarchar(max)").IsRequired();
            builder.Property(at => at.Summary).HasColumnName("Summary").HasMaxLength(1000);
            builder.Property(at => at.CreatedAt).HasColumnName("CreatedAt").IsRequired();
            builder.Property(at => at.UpdatedAt).HasColumnName("UpdatedAt");
            builder.Property(at => at.IsDeleted).HasColumnName("IsDeleted").HasDefaultValue(false);
            builder.Property(at => at.Status).HasColumnName("Status").HasDefaultValue(Status.Draft);
            builder.Property(at => at.CreatedBy).HasColumnName("CreatedBy");
            builder.Property(at => at.UpdatedBy).HasColumnName("UpdatedBy");

            // Relationships
            builder.HasOne(at => at.Announcement)
                   .WithMany(a => a.Translations)
                   .HasForeignKey(at => at.AnnouncementId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(at => at.Language)
                   .WithMany()
                   .HasForeignKey(at => at.LanguageId)
                   .OnDelete(DeleteBehavior.Restrict);

            // Indexes
            builder.HasIndex(at => at.AnnouncementId).HasDatabaseName("IX_AnnouncementTranslations_AnnouncementId");
            builder.HasIndex(at => at.LanguageId).HasDatabaseName("IX_AnnouncementTranslations_LanguageId");
            builder.HasIndex(at => new { at.AnnouncementId, at.LanguageId })
                   .IsUnique()
                   .HasDatabaseName("IX_AnnouncementTranslations_AnnouncementId_LanguageId");

            // Query Filter
            builder.HasQueryFilter(at => !at.IsDeleted);
        }
    }
}