using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PazarAtlasi.CMS.Domain.Entities.Localization;

namespace PazarAtlasi.CMS.Persistence.EntityConfigurations.Localization
{
    public class LocalizationValueConfigurationBuilder : IEntityTypeConfiguration<LocalizationValue>
    {
        public void Configure(EntityTypeBuilder<LocalizationValue> builder)
        {
            // Table configuration
            builder.ToTable("LocalizationValues").HasKey(lv => lv.Id);

            // Property configurations
            builder.Property(lv => lv.Id)
                .HasColumnName("Id")
                .IsRequired();

            builder.Property(lv => lv.LanguageId)
                .HasColumnName("LanguageId")
                .IsRequired();

            builder.Property(lv => lv.Key)
                .HasColumnName("Key")
                .HasMaxLength(500)
                .IsRequired();

            builder.Property(lv => lv.Value)
                .HasColumnName("Value")
                .HasMaxLength(4000)
                .IsRequired();

            builder.Property(lv => lv.Description)
                .HasColumnName("Description")
                .HasMaxLength(1000);

            builder.Property(lv => lv.Category)
                .HasColumnName("Category")
                .HasMaxLength(100);

            builder.Property(lv => lv.IsActive)
                .HasColumnName("IsActive")
                .HasDefaultValue(true)
                .IsRequired();

            builder.Property(lv => lv.CreatedAt)
                .HasColumnName("CreatedAt")
                .HasDefaultValueSql("GETUTCDATE()")
                .IsRequired();

            builder.Property(lv => lv.UpdatedAt)
                .HasColumnName("UpdatedAt");

            builder.Property(lv => lv.IsDeleted)
                .HasColumnName("IsDeleted")
                .HasDefaultValue(false)
                .IsRequired();

            // Relationships
            builder.HasOne(lv => lv.Language)
                .WithMany(l => l.LocalizationValues)
                .HasForeignKey(lv => lv.LanguageId)
                .OnDelete(DeleteBehavior.Restrict);

            // Indexes
            builder.HasIndex(lv => new { lv.Key, lv.LanguageId })
                .HasDatabaseName("IX_LocalizationValues_Key_LanguageId")
                .IsUnique();

            builder.HasIndex(lv => lv.Key)
                .HasDatabaseName("IX_LocalizationValues_Key");

            builder.HasIndex(lv => lv.LanguageId)
                .HasDatabaseName("IX_LocalizationValues_LanguageId");

            builder.HasIndex(lv => lv.Category)
                .HasDatabaseName("IX_LocalizationValues_Category");

            builder.HasIndex(lv => lv.IsActive)
                .HasDatabaseName("IX_LocalizationValues_IsActive");

            builder.HasIndex(lv => lv.IsDeleted)
                .HasDatabaseName("IX_LocalizationValues_IsDeleted");

            // Query filter for soft delete
            builder.HasQueryFilter(lv => !lv.IsDeleted);

            // Seed data (optional - basic system messages)
            builder.HasData(
                new LocalizationValue
                {
                    Id = 1,
                    LanguageId = 1, // Assuming Turkish is ID 1
                    Key = "Common.Save",
                    Value = "Kaydet",
                    Description = "Save button text",
                    Category = "Common",
                    IsActive = true,
                    CreatedAt = DateTime.UtcNow,
                    IsDeleted = false
                },
                new LocalizationValue
                {
                    Id = 2,
                    LanguageId = 2, // Assuming English is ID 2
                    Key = "Common.Save",
                    Value = "Save",
                    Description = "Save button text",
                    Category = "Common",
                    IsActive = true,
                    CreatedAt = DateTime.UtcNow,
                    IsDeleted = false
                },
                new LocalizationValue
                {
                    Id = 3,
                    LanguageId = 1,
                    Key = "Common.Cancel",
                    Value = "İptal",
                    Description = "Cancel button text",
                    Category = "Common",
                    IsActive = true,
                    CreatedAt = DateTime.UtcNow,
                    IsDeleted = false
                },
                new LocalizationValue
                {
                    Id = 4,
                    LanguageId = 2,
                    Key = "Common.Cancel",
                    Value = "Cancel",
                    Description = "Cancel button text",
                    Category = "Common",
                    IsActive = true,
                    CreatedAt = DateTime.UtcNow,
                    IsDeleted = false
                },
                new LocalizationValue
                {
                    Id = 5,
                    LanguageId = 1,
                    Key = "Common.Delete",
                    Value = "Sil",
                    Description = "Delete button text",
                    Category = "Common",
                    IsActive = true,
                    CreatedAt = DateTime.UtcNow,
                    IsDeleted = false
                },
                new LocalizationValue
                {
                    Id = 6,
                    LanguageId = 2,
                    Key = "Common.Delete",
                    Value = "Delete",
                    Description = "Delete button text",
                    Category = "Common",
                    IsActive = true,
                    CreatedAt = DateTime.UtcNow,
                    IsDeleted = false
                }
            );
        }
    }
}