using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PazarAtlasi.CMS.Domain.Entities.Content;
using PazarAtlasi.CMS.Domain.Common;

namespace PazarAtlasi.CMS.Persistence.EntityConfigurations.Content
{
    public class SectionTypeTemplateConfiguration : IEntityTypeConfiguration<SectionTypeTemplate>
    {
        public void Configure(EntityTypeBuilder<SectionTypeTemplate> builder)
        {
            builder.HasKey(st => st.Id);

            builder.Property(st => st.CustomConfiguration)
                .HasColumnType("nvarchar(max)");

            // Composite index for performance
            builder.HasIndex(st => new { st.SectionType, st.TemplateId }).IsUnique();

            builder.HasOne(st => st.Template)
                .WithMany(t => t.SectionTemplates)
                .HasForeignKey(st => st.TemplateId)
                .OnDelete(DeleteBehavior.Cascade);

            // Seed Data - Define which templates can be used with which sections
            builder.HasData(
                // Navbar sections can use navbar-specific templates (Id: 1-4)
                // These will be created when a navbar section is created
                
                // Example: If we have a navbar section with Id=1, it can use these templates:
                new SectionTypeTemplate
                {
                    Id = 1,
                    SectionType = SectionType.Navbar, // Assuming navbar section exists
                    TemplateId = 1, // Simple Navbar
                    Status = Status.Active,
                    CreatedAt = new DateTime(2024, 10, 14, 10, 0, 0),
                    IsDeleted = false
                },
                new SectionTypeTemplate
                {
                    Id = 2,
                    SectionType = SectionType.Navbar,
                    TemplateId = 2, // Mega Menu Navbar
                    Status = Status.Active,
                    CreatedAt = new DateTime(2024, 10, 14, 10, 0, 0),
                    IsDeleted = false
                },
                new SectionTypeTemplate
                {
                    Id = 3,
                    SectionType = SectionType.Navbar,
                    TemplateId = 3, // Service Tabs Navbar
                    Status = Status.Active,
                    CreatedAt = new DateTime(2024, 10, 14, 10, 0, 0),
                    IsDeleted = false
                },
                new SectionTypeTemplate
                {
                    Id = 4,
                    SectionType = SectionType.Navbar,   
                    TemplateId = 4, // Categorized Navbar
                    Status = Status.Active,
                    CreatedAt = new DateTime(2024, 10, 14, 10, 0, 0),
                    IsDeleted = false
                }
            );
        }
    }
}
