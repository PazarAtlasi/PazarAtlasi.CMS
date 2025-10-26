using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PazarAtlasi.CMS.Domain.Common;
using PazarAtlasi.CMS.Domain.Entities.Announcement;

namespace PazarAtlasi.CMS.Persistence.EntityConfigurations.Announcement
{
    public class AnnouncementConfiguration : IEntityTypeConfiguration<PazarAtlasi.CMS.Domain.Entities.Announcement.Announcement>
    {
        public void Configure(EntityTypeBuilder<PazarAtlasi.CMS.Domain.Entities.Announcement.Announcement> builder)
        {
            builder.ToTable("Announcements").HasKey(a => a.Id);

            builder.Property(a => a.Id).HasColumnName("Id").IsRequired();
            builder.Property(a => a.Title).HasColumnName("Title").HasMaxLength(500).IsRequired();
            builder.Property(a => a.Content).HasColumnName("Content").HasColumnType("nvarchar(max)").IsRequired();
            builder.Property(a => a.Summary).HasColumnName("Summary").HasMaxLength(1000);
            builder.Property(a => a.CoverImage).HasColumnName("CoverImage").HasMaxLength(500);
            builder.Property(a => a.PublishStart).HasColumnName("PublishStart").IsRequired();
            builder.Property(a => a.PublishEnd).HasColumnName("PublishEnd").IsRequired();
            builder.Property(a => a.CreatedAt).HasColumnName("CreatedAt").IsRequired();
            builder.Property(a => a.UpdatedAt).HasColumnName("UpdatedAt");
            builder.Property(a => a.IsDeleted).HasColumnName("IsDeleted").HasDefaultValue(false);
            builder.Property(a => a.Status).HasColumnName("Status").HasDefaultValue(Status.Draft);
            builder.Property(a => a.CreatedBy).HasColumnName("CreatedBy");
            builder.Property(a => a.UpdatedBy).HasColumnName("UpdatedBy");

            // Indexes
            builder.HasIndex(a => a.PublishStart).HasDatabaseName("IX_Announcements_PublishStart");
            builder.HasIndex(a => a.PublishEnd).HasDatabaseName("IX_Announcements_PublishEnd");
            builder.HasIndex(a => a.Status).HasDatabaseName("IX_Announcements_Status");
            builder.HasIndex(a => a.CreatedAt).HasDatabaseName("IX_Announcements_CreatedAt");

            // Query Filter
            builder.HasQueryFilter(a => !a.IsDeleted);

            // Seed Data
            builder.HasData(
                new PazarAtlasi.CMS.Domain.Entities.Announcement.Announcement
                {
                    Id = 1,
                    Title = "Hoş Geldiniz!",
                    Content = "<p>Yeni duyuru sistemimize hoş geldiniz. Bu sistem ile önemli duyurularınızı kolayca yönetebilirsiniz.</p>",
                    Summary = "Yeni duyuru sistemi tanıtımı",
                    PublishStart = new DateTime(2024, 10, 27, 10, 0, 0),
                    PublishEnd = new DateTime(2024, 11, 27, 10, 0, 0),
                    CreatedAt = new DateTime(2024, 10, 27, 10, 0, 0),
                    Status = Status.Active,
                    IsDeleted = false
                },
                new Domain.Entities.Announcement.Announcement
                {
                    Id = 2,
                    Title = "Sistem Bakımı Duyurusu",
                    Content = "<p>Sistemimizde planlı bakım çalışması yapılacaktır. Bakım sırasında hizmetlerimizde kısa süreli kesintiler yaşanabilir.</p><p>Bakım tarihi: <strong>15 Kasım 2024, 02:00-04:00</strong></p>",
                    Summary = "Planlı sistem bakımı hakkında bilgilendirme",
                    PublishStart = new DateTime(2024, 10, 22, 10, 0, 0),
                    PublishEnd = new DateTime(2024, 11, 6, 10, 0, 0),
                    CreatedAt = new DateTime(2024, 10, 22, 10, 0, 0),
                    Status = Status.Active,
                    IsDeleted = false
                }
            );
        }
    }
}