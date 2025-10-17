using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PazarAtlasi.CMS.Persistence.EntityConfigurations.Content
{
    public class PageSectionConfiguration : IEntityTypeConfiguration<Domain.Entities.Content.PageSection>
    {
        public PageSectionConfiguration() { }

        public void Configure(EntityTypeBuilder<Domain.Entities.Content.PageSection> builder)
        {
            builder.ToTable("PageSections").HasKey(ps => ps.Id);
            builder.Property(ps => ps.Id).HasColumnName("Id").IsRequired();
            builder.Property(ps => ps.PageId).HasColumnName("PageId").IsRequired();
            builder.Property(ps => ps.SectionId).HasColumnName("SectionId").IsRequired();
            builder.Property(ps => ps.SortOrder).HasColumnName("SortOrder").IsRequired().HasDefaultValue(0);
            // Relationships
            builder.HasOne(ps => ps.Page)
                   .WithMany(p => p.PageSections)
                   .HasForeignKey(ps => ps.PageId)
                   .OnDelete(DeleteBehavior.Cascade);
            builder.HasOne(ps => ps.Section)
                   .WithMany()
                   .HasForeignKey(ps => ps.SectionId)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
