using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PazarAtlasi.CMS.Domain.Entities.Metadata;

namespace PazarAtlasi.CMS.Persistence.EntityConfigurations.Metadata
{
    public class TrademarkProductConfiguration : IEntityTypeConfiguration<TrademarkProduct>
    {
        public void Configure(EntityTypeBuilder<TrademarkProduct> builder)
        {
            // Table name and primary key
            builder.ToTable("TrademarkProducts").HasKey(tp => tp.Id);

            // Properties
            builder.Property(tp => tp.Id).HasColumnName("Id").IsRequired();
            builder.Property(tp => tp.TrademarkId).HasColumnName("TrademarkId").IsRequired();
            builder.Property(tp => tp.ProductId).HasColumnName("ProductId").IsRequired();
            builder.Property(tp => tp.Status).HasColumnName("Status").HasDefaultValue(Domain.Common.Status.Active);
            builder.Property(tp => tp.CreatedAt).HasColumnName("CreatedAt").IsRequired();
            builder.Property(tp => tp.UpdatedAt).HasColumnName("UpdatedAt");
            builder.Property(tp => tp.IsDeleted).HasColumnName("IsDeleted").HasDefaultValue(false);

            // Relationships
            builder.HasOne(tp => tp.Trademark)
                   .WithMany(t => t.TrademarkProducts)
                   .HasForeignKey(tp => tp.TrademarkId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(tp => tp.Product)
                   .WithMany(p => p.TrademarkProducts)
                   .HasForeignKey(tp => tp.ProductId)
                   .OnDelete(DeleteBehavior.Cascade);

            // Indexes
            builder.HasIndex(tp => new { tp.TrademarkId, tp.ProductId })
                   .HasDatabaseName("IX_TrademarkProducts_TrademarkId_ProductId")
                   .IsUnique();

            // Query Filter (Soft Delete)
            builder.HasQueryFilter(tp => !tp.IsDeleted);
        }
    }
}