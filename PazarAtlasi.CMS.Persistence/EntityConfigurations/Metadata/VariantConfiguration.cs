using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PazarAtlasi.CMS.Domain.Entities.Metadata;

namespace PazarAtlasi.CMS.Persistence.EntityConfigurations.Metadata
{
    public class VariantConfiguration : IEntityTypeConfiguration<Variant>
    {
        public void Configure(EntityTypeBuilder<Variant> builder)
        {
            // Table name and primary key
            builder.ToTable("Variants").HasKey(v => v.Id);

            // Properties
            builder.Property(v => v.Id).HasColumnName("Id").IsRequired();
            builder.Property(v => v.ProductId).HasColumnName("ProductId").IsRequired();
            builder.Property(v => v.Code).HasColumnName("Code").IsRequired().HasMaxLength(100);
            builder.Property(v => v.IntegrationCode).HasColumnName("IntegrationCode").HasMaxLength(100);
            builder.Property(v => v.Name).HasColumnName("Name").IsRequired().HasMaxLength(255);
            builder.Property(v => v.ShortDescription).HasColumnName("ShortDescription").HasMaxLength(500);
            builder.Property(v => v.LongDescription).HasColumnName("LongDescription").HasMaxLength(2000);
            builder.Property(v => v.Status).HasColumnName("Status").HasDefaultValue(Domain.Common.Status.Active);
            builder.Property(v => v.CreatedAt).HasColumnName("CreatedAt").IsRequired();
            builder.Property(v => v.UpdatedAt).HasColumnName("UpdatedAt");
            builder.Property(v => v.IsDeleted).HasColumnName("IsDeleted").HasDefaultValue(false);

            // Relationships
            builder.HasOne(v => v.Product)
                   .WithMany(p => p.Variants)
                   .HasForeignKey(v => v.ProductId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(v => v.Translations)
                   .WithOne(vt => vt.Variant)
                   .HasForeignKey(vt => vt.VariantId)
                   .OnDelete(DeleteBehavior.Cascade);

            // Indexes
            builder.HasIndex(v => v.Code).HasDatabaseName("IX_Variants_Code").IsUnique();
            builder.HasIndex(v => v.IntegrationCode).HasDatabaseName("IX_Variants_IntegrationCode");
            builder.HasIndex(v => v.ProductId).HasDatabaseName("IX_Variants_ProductId");
            builder.HasIndex(v => v.Status).HasDatabaseName("IX_Variants_Status");

            // Query Filter (Soft Delete)
            builder.HasQueryFilter(v => !v.IsDeleted);
        }
    }
}