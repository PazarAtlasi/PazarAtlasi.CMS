using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PazarAtlasi.CMS.Domain.Entities;

namespace PazarAtlasi.CMS.Persistence.EntityConfigurations
{
    public class WebUrlConfiguration : IEntityTypeConfiguration<WebUrl>
    {
        public void Configure(EntityTypeBuilder<WebUrl> builder)
        {
            builder.ToTable("WebUrls");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Slug)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(x => x.OriginalUrl)
                .HasMaxLength(500);

            builder.Property(x => x.TargetUrl)
                .IsRequired()
                .HasMaxLength(500);

            builder.Property(x => x.Notes)
                .HasMaxLength(500);

            builder.Property(x => x.Category)
                .HasMaxLength(50);

            builder.HasIndex(x => x.Slug)
                .IsUnique()
                .HasFilter("IsDeleted = 0");
        }
    }
}