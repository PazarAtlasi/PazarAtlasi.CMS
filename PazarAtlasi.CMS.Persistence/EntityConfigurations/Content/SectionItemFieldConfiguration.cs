using Microsoft.EntityFrameworkCore;
using PazarAtlasi.CMS.Domain.Entities.Content;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PazarAtlasi.CMS.Persistence.EntityConfigurations.Content
{
    public class SectionItemFieldConfiguration : IEntityTypeConfiguration<SectionItemField>
    {
        public SectionItemFieldConfiguration() { }

        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<SectionItemField> builder)
        {
            builder.ToTable("SectionItemFields");
            builder.HasKey(e => e.Id);

            builder.Property(e => e.Id).ValueGeneratedOnAdd();
            
            builder.Property(e => e.FieldKey)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(e => e.FieldType)
                .IsRequired();

            builder.Property(e => e.FieldValue)
                .IsRequired(false);

            builder.HasOne(e => e.SectionItem)
                .WithMany(si => si.Fields)
                .HasForeignKey(e => e.SectionItemId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Property(e => e.IsDeleted)
                .HasDefaultValue(false);

            builder.Property(e => e.Status)
                .HasDefaultValue(Domain.Common.Status.Draft);
        }
    }
}
