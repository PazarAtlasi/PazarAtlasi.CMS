using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PazarAtlasi.CMS.Domain.Entities.Content;
using PazarAtlasi.CMS.Domain.Common;

namespace PazarAtlasi.CMS.Persistence.EntityConfigurations.Content
{
    public class LayoutSectionConfiguration : IEntityTypeConfiguration<LayoutSection>
    {
        public void Configure(EntityTypeBuilder<LayoutSection> builder)
        {
            builder.HasKey(ls => ls.Id);

            builder.Property(ls => ls.LayoutId)
                .IsRequired();

            builder.Property(ls => ls.SectionId)
                .IsRequired();

            builder.Property(ls => ls.Position)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(ls => ls.SortOrder)
                .HasDefaultValue(0);

            builder.Property(ls => ls.IsRequired)
                .HasDefaultValue(false);

            builder.Property(ls => ls.Status)
                .IsRequired()
                .HasConversion<int>();

            builder.Property(ls => ls.CreatedAt)
                .IsRequired();

            builder.Property(ls => ls.IsDeleted)
                .HasDefaultValue(false);

            // Indexes
            builder.HasIndex(ls => new { ls.LayoutId, ls.Position, ls.SortOrder });
            builder.HasIndex(ls => new { ls.LayoutId, ls.SectionId }).IsUnique();
            builder.HasIndex(ls => new { ls.Status, ls.IsDeleted });

            // Relationships
            builder.HasOne(ls => ls.Layout)
                .WithMany(l => l.LayoutSections)
                .HasForeignKey(ls => ls.LayoutId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(ls => ls.Section)
                .WithMany() // No navigation property on Section side
                .HasForeignKey(ls => ls.SectionId)
                .OnDelete(DeleteBehavior.Cascade);

            // Seed Data - Example layout sections for Default Layout
            builder.HasData(
                // Default Layout (Id: 1) - assuming we have some reusable sections
                new LayoutSection
                {
                    Id = 1,
                    LayoutId = 1,
                    SectionId = 1, // Assuming section with Id 1 exists (navbar)
                    Position = "header",
                    SortOrder = 1,
                    IsRequired = true,
                    Status = Status.Active,
                    CreatedAt = new DateTime(2024, 10, 14, 10, 0, 0),
                    IsDeleted = false
                },
                new LayoutSection
                {
                    Id = 2,
                    LayoutId = 1,
                    SectionId = 2, // Assuming section with Id 2 exists (main content)
                    Position = "content",
                    SortOrder = 1,
                    IsRequired = true,
                    Status = Status.Active,
                    CreatedAt = new DateTime(2024, 10, 14, 10, 0, 0),
                    IsDeleted = false
                },
                new LayoutSection
                {
                    Id = 3,
                    LayoutId = 1,
                    SectionId = 3, // Assuming section with Id 3 exists (footer)
                    Position = "footer",
                    SortOrder = 1,
                    IsRequired = true,
                    Status = Status.Active,
                    CreatedAt = new DateTime(2024, 10, 14, 10, 0, 0),
                    IsDeleted = false
                },
                // Landing Page Layout (Id: 2)
                new LayoutSection
                {
                    Id = 4,
                    LayoutId = 2,
                    SectionId = 1, // Navbar
                    Position = "header",
                    SortOrder = 1,
                    IsRequired = true,
                    Status = Status.Active,
                    CreatedAt = new DateTime(2024, 10, 14, 10, 0, 0),
                    IsDeleted = false
                },
                new LayoutSection
                {
                    Id = 5,
                    LayoutId = 2,
                    SectionId = 4, // Assuming hero section exists
                    Position = "content",
                    SortOrder = 1,
                    IsRequired = true,
                    Status = Status.Active,
                    CreatedAt = new DateTime(2024, 10, 14, 10, 0, 0),
                    IsDeleted = false
                },
                new LayoutSection
                {
                    Id = 6,
                    LayoutId = 2,
                    SectionId = 2, // Main content
                    Position = "content",
                    SortOrder = 2,
                    IsRequired = false,
                    Status = Status.Active,
                    CreatedAt = new DateTime(2024, 10, 14, 10, 0, 0),
                    IsDeleted = false
                },
                new LayoutSection
                {
                    Id = 7,
                    LayoutId = 2,
                    SectionId = 3, // Footer
                    Position = "footer",
                    SortOrder = 1,
                    IsRequired = true,
                    Status = Status.Active,
                    CreatedAt = new DateTime(2024, 10, 14, 10, 0, 0),
                    IsDeleted = false
                }
            );
        }
    }
}
