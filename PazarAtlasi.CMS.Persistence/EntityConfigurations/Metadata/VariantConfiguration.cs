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

            // Seed Data
            builder.HasData(
                // iPhone 15 Pro variants
                new Variant { Id = 1, ProductId = 1, Code = "iphone-15-pro-128gb-natural", IntegrationCode = "APPLE-IP15P-128-NAT", Name = "iPhone 15 Pro 128GB Natural Titanium", ShortDescription = "128GB Natural Titanium", Status = Domain.Common.Status.Active, CreatedAt = DateTime.UtcNow, IsDeleted = false },
                new Variant { Id = 2, ProductId = 1, Code = "iphone-15-pro-256gb-blue", IntegrationCode = "APPLE-IP15P-256-BLUE", Name = "iPhone 15 Pro 256GB Blue Titanium", ShortDescription = "256GB Blue Titanium", Status = Domain.Common.Status.Active, CreatedAt = DateTime.UtcNow, IsDeleted = false },
                new Variant { Id = 3, ProductId = 1, Code = "iphone-15-pro-512gb-white", IntegrationCode = "APPLE-IP15P-512-WHITE", Name = "iPhone 15 Pro 512GB White Titanium", ShortDescription = "512GB White Titanium", Status = Domain.Common.Status.Active, CreatedAt = DateTime.UtcNow, IsDeleted = false },
                
                // Samsung Galaxy S24 variants
                new Variant { Id = 4, ProductId = 2, Code = "galaxy-s24-128gb-black", IntegrationCode = "SAMSUNG-GS24-128-BLACK", Name = "Galaxy S24 128GB Onyx Black", ShortDescription = "128GB Onyx Black", Status = Domain.Common.Status.Active, CreatedAt = DateTime.UtcNow, IsDeleted = false },
                new Variant { Id = 5, ProductId = 2, Code = "galaxy-s24-256gb-violet", IntegrationCode = "SAMSUNG-GS24-256-VIOLET", Name = "Galaxy S24 256GB Cobalt Violet", ShortDescription = "256GB Cobalt Violet", Status = Domain.Common.Status.Active, CreatedAt = DateTime.UtcNow, IsDeleted = false },
                
                // MacBook Pro 14" variants
                new Variant { Id = 6, ProductId = 3, Code = "macbook-pro-14-m3-512gb", IntegrationCode = "APPLE-MBP14-M3-512", Name = "MacBook Pro 14\" M3 512GB", ShortDescription = "M3 chip, 512GB SSD", Status = Domain.Common.Status.Active, CreatedAt = DateTime.UtcNow, IsDeleted = false },
                new Variant { Id = 7, ProductId = 3, Code = "macbook-pro-14-m3-1tb", IntegrationCode = "APPLE-MBP14-M3-1TB", Name = "MacBook Pro 14\" M3 1TB", ShortDescription = "M3 chip, 1TB SSD", Status = Domain.Common.Status.Active, CreatedAt = DateTime.UtcNow, IsDeleted = false },
                
                // Dell XPS 13 variants
                new Variant { Id = 8, ProductId = 4, Code = "dell-xps-13-i5-256gb", IntegrationCode = "DELL-XPS13-I5-256", Name = "Dell XPS 13 Intel i5 256GB", ShortDescription = "Intel i5, 256GB SSD", Status = Domain.Common.Status.Active, CreatedAt = DateTime.UtcNow, IsDeleted = false },
                new Variant { Id = 9, ProductId = 4, Code = "dell-xps-13-i7-512gb", IntegrationCode = "DELL-XPS13-I7-512", Name = "Dell XPS 13 Intel i7 512GB", ShortDescription = "Intel i7, 512GB SSD", Status = Domain.Common.Status.Active, CreatedAt = DateTime.UtcNow, IsDeleted = false }
            );
        }
    }
}