using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PazarAtlasi.CMS.Domain.Entities.Metadata;
using PazarAtlasi.CMS.Domain.Common;

namespace PazarAtlasi.CMS.Persistence.EntityConfigurations.Metadata
{
    public class ProductDataSchemaConfiguration : IEntityTypeConfiguration<ProductDataSchema>
    {
        public void Configure(EntityTypeBuilder<ProductDataSchema> builder)
        {
            // Table name and primary key
            builder.ToTable("ProductDataSchemas").HasKey(pds => pds.Id);

            // Property configurations
            builder.Property(pds => pds.Id).HasColumnName("Id").IsRequired();
            builder.Property(pds => pds.ProductId).HasColumnName("ProductId").IsRequired();
            builder.Property(pds => pds.SchemaId).HasColumnName("SchemaId").IsRequired();
            builder.Property(pds => pds.IsPrimary).HasColumnName("IsPrimary").HasDefaultValue(false);
            builder.Property(pds => pds.SortOrder).HasColumnName("SortOrder").HasDefaultValue(0);
            builder.Property(pds => pds.Configuration).HasColumnName("Configuration").HasColumnType("nvarchar(max)");
            builder.Property(pds => pds.IsActive).HasColumnName("IsActive").HasDefaultValue(true);
            builder.Property(pds => pds.Status).HasColumnName("Status").HasDefaultValue(Status.Active);
            builder.Property(pds => pds.CreatedAt).HasColumnName("CreatedAt").IsRequired();
            builder.Property(pds => pds.UpdatedAt).HasColumnName("UpdatedAt");
            builder.Property(pds => pds.IsDeleted).HasColumnName("IsDeleted").HasDefaultValue(false);

            // Relationships
            builder.HasOne(pds => pds.Product)
                   .WithMany(p => p.ProductDataSchemas)
                   .HasForeignKey(pds => pds.ProductId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(pds => pds.DataSchema)
                   .WithMany(ds => ds.ProductDataSchemas)
                   .HasForeignKey(pds => pds.SchemaId)
                   .OnDelete(DeleteBehavior.Cascade);

            // Indexes
            builder.HasIndex(pds => new { pds.ProductId, pds.SchemaId }).HasDatabaseName("IX_ProductDataSchemas_Product_Schema").IsUnique();
            builder.HasIndex(pds => pds.ProductId).HasDatabaseName("IX_ProductDataSchemas_ProductId");
            builder.HasIndex(pds => pds.SchemaId).HasDatabaseName("IX_ProductDataSchemas_SchemaId");
            builder.HasIndex(pds => pds.IsPrimary).HasDatabaseName("IX_ProductDataSchemas_IsPrimary");
            builder.HasIndex(pds => pds.SortOrder).HasDatabaseName("IX_ProductDataSchemas_SortOrder");
            builder.HasIndex(pds => pds.IsActive).HasDatabaseName("IX_ProductDataSchemas_IsActive");

            // Query Filter (Soft Delete)
            builder.HasQueryFilter(pds => !pds.IsDeleted);
        }
    }
}