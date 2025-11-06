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

            builder.HasMany(p => p.ProductOptions)
                   .WithOne(po => po.Product)
                   .HasForeignKey(po => po.ProductId)
                   .OnDelete(DeleteBehavior.Cascade);

            // Data Schema relationships
            builder.HasMany(p => p.ProductDataSchemas)
                   .WithOne(pds => pds.Product)
                   .HasForeignKey(pds => pds.ProductId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(p => p.DataSchemaFieldValues)
                   .WithOne(fv => fv.Product)
                   .HasForeignKey(fv => fv.ProductId)
                   .OnDelete(DeleteBehavior.Cascade);

            // Indexes
            builder.HasIndex(p => p.Code).HasDatabaseName("IX_Products_Code").IsUnique();
            builder.HasIndex(p => p.IntegrationCode).HasDatabaseName("IX_Products_IntegrationCode");
            builder.HasIndex(p => p.Type).HasDatabaseName("IX_Products_Type");
            builder.HasIndex(p => p.Status).HasDatabaseName("IX_Products_Status");
            builder.HasIndex(p => p.ParentId).HasDatabaseName("IX_Products_ParentId");

            // Query Filter (Soft Delete)
            builder.HasQueryFilter(p => !p.IsDeleted);

            // Seed Data
            builder.HasData(
                new Product { Id = 1, Name = "iPhone 15 Pro", Code = "iphone-15-pro", IntegrationCode = "APPLE-IP15P", ShortDescription = "Latest iPhone with Pro features", LongDescription = "The iPhone 15 Pro features a titanium design, A17 Pro chip, and advanced camera system.", Unit = "pcs", Type = Domain.Common.ProductType.Variable, TaxRate = 18, Status = Domain.Common.Status.Active, CreatedAt = DateTime.UtcNow, IsDeleted = false },
                new Product { Id = 2, Name = "Samsung Galaxy S24", Code = "galaxy-s24", IntegrationCode = "SAMSUNG-GS24", ShortDescription = "Premium Android smartphone", LongDescription = "Samsung Galaxy S24 with AI-powered features and exceptional camera quality.", Unit = "pcs", Type = Domain.Common.ProductType.Variable, TaxRate = 18, Status = Domain.Common.Status.Active, CreatedAt = DateTime.UtcNow, IsDeleted = false },
                new Product { Id = 3, Name = "MacBook Pro 14\"", Code = "macbook-pro-14", IntegrationCode = "APPLE-MBP14", ShortDescription = "Professional laptop for creators", LongDescription = "MacBook Pro 14-inch with M3 chip, perfect for professional workflows.", Unit = "pcs", Type = Domain.Common.ProductType.Variable, TaxRate = 18, Status = Domain.Common.Status.Active, CreatedAt = DateTime.UtcNow, IsDeleted = false },
                new Product { Id = 4, Name = "Dell XPS 13", Code = "dell-xps-13", IntegrationCode = "DELL-XPS13", ShortDescription = "Ultra-portable Windows laptop", LongDescription = "Dell XPS 13 with Intel Core processors and premium build quality.", Unit = "pcs", Type = Domain.Common.ProductType.Variable, TaxRate = 18, Status = Domain.Common.Status.Active, CreatedAt = DateTime.UtcNow, IsDeleted = false },
                new Product { Id = 5, Name = "AirPods Pro", Code = "airpods-pro", IntegrationCode = "APPLE-APP", ShortDescription = "Wireless earbuds with ANC", LongDescription = "AirPods Pro with active noise cancellation and spatial audio.", Unit = "pcs", Type = Domain.Common.ProductType.Simple, TaxRate = 18, Status = Domain.Common.Status.Active, CreatedAt = DateTime.UtcNow, IsDeleted = false }
            );
        }
    }
}