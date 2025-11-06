using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PazarAtlasi.CMS.Domain.Entities.Metadata;

namespace PazarAtlasi.CMS.Persistence.EntityConfigurations.Metadata
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            // Table name and primary key
            builder.ToTable("Products").HasKey(p => p.Id);

            // Properties
            builder.Property(p => p.Id).HasColumnName("Id").IsRequired();
            builder.Property(p => p.ParentId).HasColumnName("ParentId");
            builder.Property(p => p.Name).HasColumnName("Name").IsRequired().HasMaxLength(255);
            builder.Property(p => p.Code).HasColumnName("Code").IsRequired().HasMaxLength(100);
            builder.Property(p => p.IntegrationCode).HasColumnName("IntegrationCode").HasMaxLength(100);
            builder.Property(p => p.ShortDescription).HasColumnName("ShortDescription").HasMaxLength(500);
            builder.Property(p => p.LongDescription).HasColumnName("LongDescription").HasMaxLength(2000);
            builder.Property(p => p.Unit).HasColumnName("Unit").HasMaxLength(50);
            builder.Property(p => p.Type).HasColumnName("Type").HasDefaultValue(Domain.Common.ProductType.Simple);
            builder.Property(p => p.TaxRate).HasColumnName("TaxRate").HasColumnType("decimal(5,2)").HasDefaultValue(0);
            builder.Property(p => p.Status).HasColumnName("Status").HasDefaultValue(Domain.Common.Status.Active);
            builder.Property(p => p.CreatedAt).HasColumnName("CreatedAt").IsRequired();
            builder.Property(p => p.UpdatedAt).HasColumnName("UpdatedAt");
            builder.Property(p => p.IsDeleted).HasColumnName("IsDeleted").HasDefaultValue(false);

            // Relationships
            builder.HasOne(p => p.ParentProduct)
                   .WithMany(p => p.ChildProducts)
                   .HasForeignKey(p => p.ParentId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(p => p.Translations)
                   .WithOne(pt => pt.Product)
                   .HasForeignKey(pt => pt.ProductId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(p => p.Variants)
                   .WithOne(v => v.Product)
                   .HasForeignKey(v => v.ProductId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(p => p.CategoryProducts)
                   .WithOne(cp => cp.Product)
                   .HasForeignKey(cp => cp.ProductId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(p => p.TrademarkProducts)
                   .WithOne(tp => tp.Product)
                   .HasForeignKey(tp => tp.ProductId)
                   .OnDelete(DeleteBehavior.Cascade);

            // Indexes
            builder.HasIndex(p => p.Code).HasDatabaseName("IX_Products_Code").IsUnique();
            builder.HasIndex(p => p.IntegrationCode).HasDatabaseName("IX_Products_IntegrationCode");
            builder.HasIndex(p => p.Type).HasDatabaseName("IX_Products_Type");
            builder.HasIndex(p => p.Status).HasDatabaseName("IX_Products_Status");
            builder.HasIndex(p => p.ParentId).HasDatabaseName("IX_Products_ParentId");

            // Query Filter (Soft Delete)
            builder.HasQueryFilter(p => !p.IsDeleted);
        }
    }
}