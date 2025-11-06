using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PazarAtlasi.CMS.Domain.Entities.Metadata;

namespace PazarAtlasi.CMS.Persistence.EntityConfigurations.Metadata
{
    public class CategoryProductConfiguration : IEntityTypeConfiguration<CategoryProduct>
    {
        public void Configure(EntityTypeBuilder<CategoryProduct> builder)
        {
            // Table name and primary key
            builder.ToTable("CategoryProducts").HasKey(cp => cp.Id);

            // Properties
            builder.Property(cp => cp.Id).HasColumnName("Id").IsRequired();
            builder.Property(cp => cp.CategoryId).HasColumnName("CategoryId").IsRequired();
            builder.Property(cp => cp.ProductId).HasColumnName("ProductId").IsRequired();
            builder.Property(cp => cp.Status).HasColumnName("Status").HasDefaultValue(Domain.Common.Status.Active);
            builder.Property(cp => cp.CreatedAt).HasColumnName("CreatedAt").IsRequired();
            builder.Property(cp => cp.UpdatedAt).HasColumnName("UpdatedAt");
            builder.Property(cp => cp.IsDeleted).HasColumnName("IsDeleted").HasDefaultValue(false);
            builder.Property(cp => cp.CreatedBy).HasColumnName("CreatedBy");
            builder.Property(cp => cp.UpdatedBy).HasColumnName("UpdatedBy");

            // Relationships
            builder.HasOne(cp => cp.Category)
                   .WithMany(c => c.CategoryProducts)
                   .HasForeignKey(cp => cp.CategoryId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(cp => cp.Product)
                   .WithMany(p => p.CategoryProducts)
                   .HasForeignKey(cp => cp.ProductId)
                   .OnDelete(DeleteBehavior.Cascade);

            // Indexes
            builder.HasIndex(cp => new { cp.CategoryId, cp.ProductId })
                   .HasDatabaseName("IX_CategoryProducts_CategoryId_ProductId")
                   .IsUnique();

            // Query Filter (Soft Delete)
            builder.HasQueryFilter(cp => !cp.IsDeleted);
        }
    }
}