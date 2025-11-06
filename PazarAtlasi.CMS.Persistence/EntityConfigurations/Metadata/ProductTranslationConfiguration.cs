using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PazarAtlasi.CMS.Domain.Entities.Metadata;

namespace PazarAtlasi.CMS.Persistence.EntityConfigurations.Metadata
{
    public class ProductTranslationConfiguration : IEntityTypeConfiguration<ProductTranslation>
    {
        public void Configure(EntityTypeBuilder<ProductTranslation> builder)
        {
            // Table name and primary key
            builder.ToTable("ProductTranslations").HasKey(pt => pt.Id);

            // Properties
            builder.Property(pt => pt.Id).HasColumnName("Id").IsRequired();
            builder.Property(pt => pt.ProductId).HasColumnName("ProductId").IsRequired();
            builder.Property(pt => pt.LanguageId).HasColumnName("LanguageId").IsRequired();
            builder.Property(pt => pt.Name).HasColumnName("Name").IsRequired().HasMaxLength(255);
            builder.Property(pt => pt.ShortDescription).HasColumnName("ShortDescription").HasMaxLength(500);
            builder.Property(pt => pt.LongDescription).HasColumnName("LongDescription").HasMaxLength(2000);
            builder.Property(pt => pt.Status).HasColumnName("Status").HasDefaultValue(Domain.Common.Status.Active);
            builder.Property(pt => pt.CreatedAt).HasColumnName("CreatedAt").IsRequired();
            builder.Property(pt => pt.UpdatedAt).HasColumnName("UpdatedAt");
            builder.Property(pt => pt.IsDeleted).HasColumnName("IsDeleted").HasDefaultValue(false);

            // Relationships
            builder.HasOne(pt => pt.Product)
                   .WithMany(p => p.Translations)
                   .HasForeignKey(pt => pt.ProductId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(pt => pt.Language)
                   .WithMany()
                   .HasForeignKey(pt => pt.LanguageId)
                   .OnDelete(DeleteBehavior.Restrict);

            // Indexes
            builder.HasIndex(pt => new { pt.ProductId, pt.LanguageId })
                   .HasDatabaseName("IX_ProductTranslations_ProductId_LanguageId")
                   .IsUnique();

            // Query Filter (Soft Delete)
            builder.HasQueryFilter(pt => !pt.IsDeleted);
        }
    }
}