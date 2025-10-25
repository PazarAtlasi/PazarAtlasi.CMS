using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PazarAtlasi.CMS.Domain.Common;
using PazarAtlasi.CMS.Domain.Entities.Content;
using PazarAtlasi.CMS.Persistence.EntityConfigurations.Content.SeedData;

namespace PazarAtlasi.CMS.Persistence.EntityConfigurations.Content
{
    public class SectionItemConfigurationBuilder : IEntityTypeConfiguration<SectionItem>
    {
        public void Configure(EntityTypeBuilder<SectionItem> builder)
        {
            builder.ToTable("SectionItems").HasKey(si => si.Id);

            builder.Property(si => si.Id).HasColumnName("Id").IsRequired();
            builder.Property(si => si.Type).HasColumnName("Type").HasDefaultValue(SectionItemType.None);
            builder.Property(si => si.MediaType).HasColumnName("MediaType").HasDefaultValue(MediaType.None);
            builder.Property(si => si.SortOrder).HasColumnName("SortOrder").HasDefaultValue(0);
            builder.Property(si => si.CreatedAt).HasColumnName("CreatedAt").IsRequired();
            builder.Property(si => si.UpdatedAt).HasColumnName("UpdatedAt");
            builder.Property(si => si.IsDeleted).HasColumnName("IsDeleted").HasDefaultValue(false);
            builder.Property(si => si.Status).HasColumnName("Status").HasDefaultValue(Status.Draft);
            builder.Property(si => si.CreatedBy).HasColumnName("CreatedBy");
            builder.Property(si => si.UpdatedBy).HasColumnName("UpdatedBy");

            // New properties
            builder.Property(si => si.Title)
                .HasColumnName("Title")
                .HasMaxLength(200);

            builder.Property(si => si.Key)
                .HasColumnName("Key")
                .HasMaxLength(200);

            builder.Property(si => si.Description)
                .HasColumnName("Description")
                .HasMaxLength(500);

            builder.Property(si => si.AllowReorder)
                .HasColumnName("AllowReorder")
                .HasDefaultValue(true);

            builder.Property(si => si.AllowRemove)
                .HasColumnName("AllowRemove")
                .HasDefaultValue(true);

            builder.Property(si => si.IconClass)
                .HasColumnName("IconClass")
                .HasMaxLength(100);

            // Template relationship
            builder.Property(si => si.TemplateId)
                .HasColumnName("TemplateId");

            builder.HasOne(si => si.Template)
                   .WithMany(c => c.SectionItems)
                   .HasForeignKey(si => si.TemplateId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(si => si.Translations)
                   .WithOne(sit => sit.SectionItem)
                   .HasForeignKey(sit => sit.SectionItemId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(si => si.SectionItemFields)
                   .WithOne(fv => fv.SectionItem)
                   .HasForeignKey(fv => fv.SectionItemId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasIndex(si => si.Type).HasDatabaseName("IX_SectionItems_Type");
            builder.HasIndex(si => si.TemplateId).HasDatabaseName("IX_SectionItems_TemplateId");

            // Query Filter
            builder.HasQueryFilter(si => !si.IsDeleted);

            builder.SeedHeaderMenuItems();
            builder.SeedServicesMenu();
            builder.SeedSolutionsMenu();
            builder.SeedOtherMenus();
        }
    }
}
