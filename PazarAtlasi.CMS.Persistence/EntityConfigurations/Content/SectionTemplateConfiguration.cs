using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PazarAtlasi.CMS.Domain.Entities.Content;
using PazarAtlasi.CMS.Domain.Common;

namespace PazarAtlasi.CMS.Persistence.EntityConfigurations.Content
{
    public class SectionTemplateConfiguration : IEntityTypeConfiguration<SectionTemplate>
    {
        public void Configure(EntityTypeBuilder<SectionTemplate> builder)
        {
            builder.HasKey(st => st.Id);

            builder.Property(st => st.CustomConfiguration)
                .HasColumnType("nvarchar(max)");

            // Composite index for performance
            builder.HasIndex(st => new { st.SectionId, st.TemplateId }).IsUnique();

            // Relationships
            builder.HasOne(st => st.Section)
                .WithMany(s => s.SectionTemplates)
                .HasForeignKey(st => st.SectionId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(st => st.Template)
                .WithMany(t => t.SectionTemplates)
                .HasForeignKey(st => st.TemplateId)
                .OnDelete(DeleteBehavior.Cascade);

            // Seed Data - Define which templates can be used with which sections
            builder.HasData(
                // Navbar sections can use navbar-specific templates (Id: 1-4)
                // These will be created when a navbar section is created
                
                // Example: If we have a navbar section with Id=1, it can use these templates:
                new SectionTemplate
                {
                    Id = 1,
                    SectionId = 1, // Assuming navbar section exists
                    TemplateId = 1, // Simple Navbar
                    Status = Status.Active,
                    CreatedAt = new DateTime(2024, 10, 14, 10, 0, 0),
                    IsDeleted = false
                },
                new SectionTemplate
                {
                    Id = 2,
                    SectionId = 1, // Same navbar section
                    TemplateId = 2, // Mega Menu Navbar
                    Status = Status.Active,
                    CreatedAt = new DateTime(2024, 10, 14, 10, 0, 0),
                    IsDeleted = false
                },
                new SectionTemplate
                {
                    Id = 3,
                    SectionId = 1, // Same navbar section
                    TemplateId = 3, // Service Tabs Navbar
                    Status = Status.Active,
                    CreatedAt = new DateTime(2024, 10, 14, 10, 0, 0),
                    IsDeleted = false
                },
                new SectionTemplate
                {
                    Id = 4,
                    SectionId = 1, // Same navbar section
                    TemplateId = 4, // Categorized Navbar
                    Status = Status.Active,
                    CreatedAt = new DateTime(2024, 10, 14, 10, 0, 0),
                    IsDeleted = false
                }
            );
        }
    }
}
