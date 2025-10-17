using Microsoft.EntityFrameworkCore;
using PazarAtlasi.CMS.Domain.Entities.Content;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PazarAtlasi.CMS.Persistence.EntityConfigurations.Content
{
    public class SectionItemFieldTranslationConfiguration : IEntityTypeConfiguration<SectionItemFieldTranslation>
    {
        public SectionItemFieldTranslationConfiguration() { }

        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<SectionItemFieldTranslation> builder)
        {
            builder.ToTable("SectionItemFieldTranslations");
            builder.HasKey(e => e.Id);
            builder.Property(e => e.Id).ValueGeneratedOnAdd();
            builder.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(200);
            builder.Property(e => e.Description)
                .IsRequired(false)
                .HasMaxLength(1000);
            builder.Property(e => e.LanguageId)
                .IsRequired();
            builder.Property(e => e.SectionItemFieldId)
                .IsRequired();
            builder.HasOne(e => e.SectionItemField)
                .WithMany(sif => sif.Translations)
                .HasForeignKey(e => e.SectionItemFieldId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(e => e.Language)
                .WithMany()
                .HasForeignKey(e => e.LanguageId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
