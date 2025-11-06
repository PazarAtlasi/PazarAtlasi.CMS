using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PazarAtlasi.CMS.Domain.Entities.Metadata;

namespace PazarAtlasi.CMS.Persistence.EntityConfigurations.Metadata
{
    public class OptionTranslationConfiguration : IEntityTypeConfiguration<OptionTranslation>
    {
        public void Configure(EntityTypeBuilder<OptionTranslation> builder)
        {
            // Table name and primary key
            builder.ToTable("OptionTranslations").HasKey(ot => ot.Id);

            // Properties
            builder.Property(ot => ot.Id).HasColumnName("Id").IsRequired();
            builder.Property(ot => ot.OptionId).HasColumnName("OptionId").IsRequired();
            builder.Property(ot => ot.LanguageId).HasColumnName("LanguageId").IsRequired();
            builder.Property(ot => ot.Name).HasColumnName("Name").IsRequired().HasMaxLength(255);
            builder.Property(ot => ot.ShortDescription).HasColumnName("ShortDescription").HasMaxLength(500);
            builder.Property(ot => ot.LongDescription).HasColumnName("LongDescription").HasMaxLength(2000);
            builder.Property(ot => ot.Status).HasColumnName("Status").HasDefaultValue(Domain.Common.Status.Active);
            builder.Property(ot => ot.CreatedAt).HasColumnName("CreatedAt").IsRequired();
            builder.Property(ot => ot.UpdatedAt).HasColumnName("UpdatedAt");
            builder.Property(ot => ot.IsDeleted).HasColumnName("IsDeleted").HasDefaultValue(false);

            // Relationships
            builder.HasOne(ot => ot.Option)
                   .WithMany(o => o.Translations)
                   .HasForeignKey(ot => ot.OptionId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(ot => ot.Language)
                   .WithMany()
                   .HasForeignKey(ot => ot.LanguageId)
                   .OnDelete(DeleteBehavior.Restrict);

            // Indexes
            builder.HasIndex(ot => new { ot.OptionId, ot.LanguageId }).HasDatabaseName("IX_OptionTranslations_OptionId_LanguageId").IsUnique();
            builder.HasIndex(ot => ot.OptionId).HasDatabaseName("IX_OptionTranslations_OptionId");
            builder.HasIndex(ot => ot.LanguageId).HasDatabaseName("IX_OptionTranslations_LanguageId");

            // Query Filter (Soft Delete)
            builder.HasQueryFilter(ot => !ot.IsDeleted);

            // Seed Data
            builder.HasData(
                // Color translations
                new OptionTranslation { Id = 1, OptionId = 1, LanguageId = 1, Name = "Renk", ShortDescription = "Ürün rengi", Status = Domain.Common.Status.Active, CreatedAt = DateTime.UtcNow, IsDeleted = false },
                new OptionTranslation { Id = 2, OptionId = 1, LanguageId = 2, Name = "Color", ShortDescription = "Product color", Status = Domain.Common.Status.Active, CreatedAt = DateTime.UtcNow, IsDeleted = false },
                
                // Size translations
                new OptionTranslation { Id = 3, OptionId = 2, LanguageId = 1, Name = "Beden", ShortDescription = "Ürün bedeni", Status = Domain.Common.Status.Active, CreatedAt = DateTime.UtcNow, IsDeleted = false },
                new OptionTranslation { Id = 4, OptionId = 2, LanguageId = 2, Name = "Size", ShortDescription = "Product size", Status = Domain.Common.Status.Active, CreatedAt = DateTime.UtcNow, IsDeleted = false },
                
                // Material translations
                new OptionTranslation { Id = 5, OptionId = 3, LanguageId = 1, Name = "Malzeme", ShortDescription = "Ürün malzemesi", Status = Domain.Common.Status.Active, CreatedAt = DateTime.UtcNow, IsDeleted = false },
                new OptionTranslation { Id = 6, OptionId = 3, LanguageId = 2, Name = "Material", ShortDescription = "Product material", Status = Domain.Common.Status.Active, CreatedAt = DateTime.UtcNow, IsDeleted = false },
                
                // Weight translations
                new OptionTranslation { Id = 7, OptionId = 4, LanguageId = 1, Name = "Ağırlık", ShortDescription = "Ürün ağırlığı", Status = Domain.Common.Status.Active, CreatedAt = DateTime.UtcNow, IsDeleted = false },
                new OptionTranslation { Id = 8, OptionId = 4, LanguageId = 2, Name = "Weight", ShortDescription = "Product weight", Status = Domain.Common.Status.Active, CreatedAt = DateTime.UtcNow, IsDeleted = false },
                
                // Warranty translations
                new OptionTranslation { Id = 9, OptionId = 5, LanguageId = 1, Name = "Garanti", ShortDescription = "Ürün garanti süresi", Status = Domain.Common.Status.Active, CreatedAt = DateTime.UtcNow, IsDeleted = false },
                new OptionTranslation { Id = 10, OptionId = 5, LanguageId = 2, Name = "Warranty", ShortDescription = "Product warranty period", Status = Domain.Common.Status.Active, CreatedAt = DateTime.UtcNow, IsDeleted = false }
            );
        }
    }
}