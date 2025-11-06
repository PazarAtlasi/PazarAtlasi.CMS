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

            // Seed Data
            builder.HasData(
                new Trademark { Id = 1, Name = "Apple", Code = "apple", IntegrationCode = "APPLE", ShortDescription = "Technology company", LongDescription = "Apple Inc. is an American multinational technology company.", SortOrder = 1, Status = Domain.Common.Status.Active, CreatedAt = DateTime.UtcNow, IsDeleted = false },
                new Trademark { Id = 2, Name = "Samsung", Code = "samsung", IntegrationCode = "SAMSUNG", ShortDescription = "Electronics manufacturer", LongDescription = "Samsung Electronics is a South Korean multinational electronics corporation.", SortOrder = 2, Status = Domain.Common.Status.Active, CreatedAt = DateTime.UtcNow, IsDeleted = false },
                new Trademark { Id = 3, Name = "Dell", Code = "dell", IntegrationCode = "DELL", ShortDescription = "Computer technology company", LongDescription = "Dell Technologies is an American multinational computer technology company.", SortOrder = 3, Status = Domain.Common.Status.Active, CreatedAt = DateTime.UtcNow, IsDeleted = false },
                new Trademark { Id = 4, Name = "Microsoft", Code = "microsoft", IntegrationCode = "MICROSOFT", ShortDescription = "Software corporation", LongDescription = "Microsoft Corporation is an American multinational technology corporation.", SortOrder = 4, Status = Domain.Common.Status.Active, CreatedAt = DateTime.UtcNow, IsDeleted = false },
                new Trademark { Id = 5, Name = "Sony", Code = "sony", IntegrationCode = "SONY", ShortDescription = "Entertainment and technology", LongDescription = "Sony Corporation is a Japanese multinational conglomerate corporation.", SortOrder = 5, Status = Domain.Common.Status.Active, CreatedAt = DateTime.UtcNow, IsDeleted = false }
            );
        }
    }
}