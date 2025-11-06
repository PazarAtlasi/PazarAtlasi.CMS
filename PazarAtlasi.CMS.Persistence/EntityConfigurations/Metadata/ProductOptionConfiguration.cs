using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PazarAtlasi.CMS.Domain.Entities.Metadata;

namespace PazarAtlasi.CMS.Persistence.EntityConfigurations.Metadata
{
    public class ProductOptionConfiguration : IEntityTypeConfiguration<ProductOption>
    {
        public void Configure(EntityTypeBuilder<ProductOption> builder)
        {
            // Table name and primary key
            builder.ToTable("ProductOptions").HasKey(po => po.Id);

            // Properties
            builder.Property(po => po.Id).HasColumnName("Id").IsRequired();
            builder.Property(po => po.ProductId).HasColumnName("ProductId").IsRequired();
            builder.Property(po => po.OptionId).HasColumnName("OptionId").IsRequired();
            builder.Property(po => po.Value).HasColumnName("Value").HasMaxLength(500);
            builder.Property(po => po.JsonValue).HasColumnName("JsonValue").HasColumnType("nvarchar(max)");
            builder.Property(po => po.PriceModifier).HasColumnName("PriceModifier").HasColumnType("decimal(10,2)").HasDefaultValue(0m);
            builder.Property(po => po.StockQuantity).HasColumnName("StockQuantity");
            builder.Property(po => po.IsRequired).HasColumnName("IsRequired").HasDefaultValue(false);
            builder.Property(po => po.IsDefault).HasColumnName("IsDefault").HasDefaultValue(false);
            builder.Property(po => po.SortOrder).HasColumnName("SortOrder").HasDefaultValue(0);
            builder.Property(po => po.Status).HasColumnName("Status").HasDefaultValue(Domain.Common.Status.Active);
            builder.Property(po => po.CreatedAt).HasColumnName("CreatedAt").IsRequired();
            builder.Property(po => po.UpdatedAt).HasColumnName("UpdatedAt");
            builder.Property(po => po.IsDeleted).HasColumnName("IsDeleted").HasDefaultValue(false);

            // Relationships
            builder.HasOne(po => po.Product)
                   .WithMany(p => p.ProductOptions)
                   .HasForeignKey(po => po.ProductId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(po => po.Option)
                   .WithMany(o => o.ProductOptions)
                   .HasForeignKey(po => po.OptionId)
                   .OnDelete(DeleteBehavior.Cascade);

            // Indexes
            builder.HasIndex(po => new { po.ProductId, po.OptionId }).HasDatabaseName("IX_ProductOptions_ProductId_OptionId");
            builder.HasIndex(po => po.ProductId).HasDatabaseName("IX_ProductOptions_ProductId");
            builder.HasIndex(po => po.OptionId).HasDatabaseName("IX_ProductOptions_OptionId");
            builder.HasIndex(po => po.SortOrder).HasDatabaseName("IX_ProductOptions_SortOrder");

            // Query Filter (Soft Delete)
            builder.HasQueryFilter(po => !po.IsDeleted);

            // Seed Data
            builder.HasData(
                // iPhone 15 Pro options
                new ProductOption { Id = 1, ProductId = 1, OptionId = 1, Value = "Natural Titanium", PriceModifier = 0m, IsDefault = true, SortOrder = 1, Status = Domain.Common.Status.Active, CreatedAt = DateTime.UtcNow, IsDeleted = false },
                new ProductOption { Id = 2, ProductId = 1, OptionId = 1, Value = "Blue Titanium", PriceModifier = 0m, IsDefault = false, SortOrder = 2, Status = Domain.Common.Status.Active, CreatedAt = DateTime.UtcNow, IsDeleted = false },
                new ProductOption { Id = 3, ProductId = 1, OptionId = 1, Value = "White Titanium", PriceModifier = 0m, IsDefault = false, SortOrder = 3, Status = Domain.Common.Status.Active, CreatedAt = DateTime.UtcNow, IsDeleted = false },
                new ProductOption { Id = 4, ProductId = 1, OptionId = 5, Value = "2 Years", PriceModifier = 200, IsDefault = false, SortOrder = 1, Status = Domain.Common.Status.Active, CreatedAt = DateTime.UtcNow, IsDeleted = false },
                
                // Samsung Galaxy S24 options
                new ProductOption { Id = 5, ProductId = 2, OptionId = 1, Value = "Onyx Black", PriceModifier = 0m, IsDefault = true, SortOrder = 1, Status = Domain.Common.Status.Active, CreatedAt = DateTime.UtcNow, IsDeleted = false },
                new ProductOption { Id = 6, ProductId = 2, OptionId = 1, Value = "Cobalt Violet", PriceModifier = 0m, IsDefault = false, SortOrder = 2, Status = Domain.Common.Status.Active, CreatedAt = DateTime.UtcNow, IsDeleted = false },
                new ProductOption { Id = 7, ProductId = 2, OptionId = 5, Value = "1 Year", PriceModifier = 100, IsDefault = false, SortOrder = 1, Status = Domain.Common.Status.Active, CreatedAt = DateTime.UtcNow, IsDeleted = false },
                
                // MacBook Pro 14" options
                new ProductOption { Id = 8, ProductId = 3, OptionId = 1, Value = "Space Gray", PriceModifier = 0m, IsDefault = true, SortOrder = 1, Status = Domain.Common.Status.Active, CreatedAt = DateTime.UtcNow, IsDeleted = false },
                new ProductOption { Id = 9, ProductId = 3, OptionId = 1, Value = "Silver", PriceModifier = 0m, IsDefault = false, SortOrder = 2, Status = Domain.Common.Status.Active, CreatedAt = DateTime.UtcNow, IsDeleted = false },
                new ProductOption { Id = 10, ProductId = 3, OptionId = 4, Value = "1.55 kg", PriceModifier = 0m, IsDefault = true, SortOrder = 1, Status = Domain.Common.Status.Active, CreatedAt = DateTime.UtcNow, IsDeleted = false },
                
                // Dell XPS 13 options
                new ProductOption { Id = 11, ProductId = 4, OptionId = 1, Value = "Platinum Silver", PriceModifier = 0m, IsDefault = true, SortOrder = 1, Status = Domain.Common.Status.Active, CreatedAt = DateTime.UtcNow, IsDeleted = false },
                new ProductOption { Id = 12, ProductId = 4, OptionId = 1, Value = "Graphite", PriceModifier = 50, IsDefault = false, SortOrder = 2, Status = Domain.Common.Status.Active, CreatedAt = DateTime.UtcNow, IsDeleted = false },
                new ProductOption { Id = 13, ProductId = 4, OptionId = 4, Value = "1.23 kg", PriceModifier = 0m, IsDefault = true, SortOrder = 1, Status = Domain.Common.Status.Active, CreatedAt = DateTime.UtcNow, IsDeleted = false },
                
                // AirPods Pro options
                new ProductOption { Id = 14, ProductId = 5, OptionId = 1, Value = "White", PriceModifier = 0m, IsDefault = true, SortOrder = 1, Status = Domain.Common.Status.Active, CreatedAt = DateTime.UtcNow, IsDeleted = false },
                new ProductOption { Id = 15, ProductId = 5, OptionId = 5, Value = "1 Year", PriceModifier = 50, IsDefault = false, SortOrder = 1, Status = Domain.Common.Status.Active, CreatedAt = DateTime.UtcNow, IsDeleted = false }
            );
        }
    }
}