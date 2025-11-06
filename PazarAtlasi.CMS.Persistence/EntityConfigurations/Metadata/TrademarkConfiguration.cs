using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PazarAtlasi.CMS.Domain.Entities.Metadata;

namespace PazarAtlasi.CMS.Persistence.EntityConfigurations.Metadata
{
    public class TrademarkConfiguration : IEntityTypeConfiguration<Trademark>
    {
        public void Configure(EntityTypeBuilder<Trademark> builder)
        {
            // Table name and primary key
            builder.ToTable("Trademarks").HasKey(t => t.Id);

            // Properties
            builder.Property(t => t.Id).HasColumnName("Id").IsRequired();
            builder.Property(t => t.ParentId).HasColumnName("ParentId");
            builder.Property(t => t.Code).HasColumnName("Code").IsRequired().HasMaxLength(100);
            builder.Property(t => t.IntegrationCode).HasColumnName("IntegrationCode").HasMaxLength(100);
            builder.Property(t => t.Name).HasColumnName("Name").IsRequired().HasMaxLength(255);
            builder.Property(t => t.ShortDescription).HasColumnName("ShortDescription").HasMaxLength(500);
            builder.Property(t => t.LongDescription).HasColumnName("LongDescription").HasMaxLength(2000);
            builder.Property(t => t.SortOrder).HasColumnName("SortOrder").HasDefaultValue(0);
            builder.Property(t => t.Status).HasColumnName("Status").HasDefaultValue(Domain.Common.Status.Active);
            builder.Property(t => t.CreatedAt).HasColumnName("CreatedAt").IsRequired();
            builder.Property(t => t.UpdatedAt).HasColumnName("UpdatedAt");
            builder.Property(t => t.IsDeleted).HasColumnName("IsDeleted").HasDefaultValue(false);

            // Relationships
            builder.HasOne(t => t.ParentTrademark)
                   .WithMany(t => t.ChildTrademarks)
                   .HasForeignKey(t => t.ParentId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(t => t.Translations)
                   .WithOne(tt => tt.Trademark)
                   .HasForeignKey(tt => tt.TrademarkId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(t => t.TrademarkProducts)
                   .WithOne(tp => tp.Trademark)
                   .HasForeignKey(tp => tp.TrademarkId)
                   .OnDelete(DeleteBehavior.Cascade);

            // Indexes
            builder.HasIndex(t => t.Code).HasDatabaseName("IX_Trademarks_Code").IsUnique();
            builder.HasIndex(t => t.IntegrationCode).HasDatabaseName("IX_Trademarks_IntegrationCode");
            builder.HasIndex(t => t.SortOrder).HasDatabaseName("IX_Trademarks_SortOrder");
            builder.HasIndex(t => t.Status).HasDatabaseName("IX_Trademarks_Status");
            builder.HasIndex(t => t.ParentId).HasDatabaseName("IX_Trademarks_ParentId");

            // Query Filter (Soft Delete)
            builder.HasQueryFilter(t => !t.IsDeleted);
        }
    }
}