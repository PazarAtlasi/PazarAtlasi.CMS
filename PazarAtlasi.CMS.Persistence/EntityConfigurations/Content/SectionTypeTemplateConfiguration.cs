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
            var seedData = new List<SectionTypeTemplate>() {
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
            };

            int idCounter = 5;
            var baseDate = new DateTime(2024, 10, 14, 10, 0, 0);

            // Get all SectionTypes except None and Navbar
            var allSectionTypes = Enum.GetValues<SectionType>()
                .Where(st => st != SectionType.None && st != SectionType.Navbar)
                .ToList();

            // For each SectionType (except None and Navbar), add all 14 templates
            foreach (var sectionType in allSectionTypes)
            {
                if(sectionType == SectionType.None || sectionType == SectionType.Navbar)
                    continue;

                for (int templateId = 5; templateId <= 14; templateId++)
                {
                    seedData.Add(new SectionTypeTemplate
                    {
                        Id = idCounter++,
                        SectionType = sectionType,
                        TemplateId = templateId,
                        Status = Status.Active,
                        CreatedAt = baseDate,
                        IsDeleted = false
                    });
                }
            }

            builder.HasData(seedData.ToArray());
        }
    }
}
