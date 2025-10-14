using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PazarAtlasi.CMS.Domain.Entities.Content;
using PazarAtlasi.CMS.Domain.Common;

namespace PazarAtlasi.CMS.Persistence.EntityConfigurations.Content
{
    public class LayoutConfiguration : IEntityTypeConfiguration<Layout>
    {
        public void Configure(EntityTypeBuilder<Layout> builder)
        {
            builder.HasKey(l => l.Id);

            builder.Property(l => l.Name)
                .IsRequired()
                .HasMaxLength(200);

            builder.Property(l => l.Description)
                .HasMaxLength(1000);

            builder.Property(l => l.IsDefault)
                .HasDefaultValue(false);

            builder.Property(l => l.Status)
                .IsRequired()
                .HasConversion<int>();

            builder.Property(l => l.CreatedAt)
                .IsRequired();

            builder.Property(l => l.IsDeleted)
                .HasDefaultValue(false);

            // Indexes
            builder.HasIndex(l => l.Name);
            builder.HasIndex(l => l.IsDefault);
            builder.HasIndex(l => new { l.Status, l.IsDeleted });

            // Relationships
            builder.HasMany(l => l.LayoutSections)
                .WithOne(ls => ls.Layout)
                .HasForeignKey(ls => ls.LayoutId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(l => l.Pages)
                .WithOne(p => p.Layout)
                .HasForeignKey(p => p.LayoutId)
                .OnDelete(DeleteBehavior.SetNull)
                .IsRequired(false);

            // Seed Data
            builder.HasData(
                new Layout
                {
                    Id = 1,
                    Name = "Default Layout",
                    Description = "Standard layout with header, main content, and footer",
                    IsDefault = true,
                    Status = Status.Active,
                    CreatedAt = new DateTime(2024, 10, 14, 10, 0, 0),
                    IsDeleted = false
                },
                new Layout
                {
                    Id = 2,
                    Name = "Landing Page Layout",
                    Description = "Hero-focused layout for landing pages",
                    IsDefault = false,
                    Status = Status.Active,
                    CreatedAt = new DateTime(2024, 10, 14, 10, 0, 0),
                    IsDeleted = false
                },
                new Layout
                {
                    Id = 3,
                    Name = "Blog Layout",
                    Description = "Content-focused layout with sidebar for blog posts",
                    IsDefault = false,
                    Status = Status.Active,
                    CreatedAt = new DateTime(2024, 10, 14, 10, 0, 0),
                    IsDeleted = false
                },
                new Layout
                {
                    Id = 4,
                    Name = "Minimal Layout",
                    Description = "Clean minimal layout with just content area",
                    IsDefault = false,
                    Status = Status.Active,
                    CreatedAt = new DateTime(2024, 10, 14, 10, 0, 0),
                    IsDeleted = false
                }
            );
        }
    }
}
