using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PazarAtlasi.CMS.Domain.Entities.Content;
using PazarAtlasi.CMS.Domain.Common;

namespace PazarAtlasi.CMS.Persistence.EntityConfigurations.Content
{
    public class SectionItemTypeTemplateConfiguration : IEntityTypeConfiguration<SectionItemTypeTemplate>
    {
        public void Configure(EntityTypeBuilder<SectionItemTypeTemplate> builder)
        {
            builder.HasKey(st => st.Id);

            builder.Property(st => st.CustomConfiguration)
                .HasColumnType("nvarchar(max)");

            // Composite index for performance
            builder.HasIndex(st => new { st.SectionItemType, st.TemplateId }).IsUnique();

            builder.HasOne(st => st.Template)
                .WithMany(t => t.SectionItemTypeTemplates)
                .HasForeignKey(st => st.TemplateId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
