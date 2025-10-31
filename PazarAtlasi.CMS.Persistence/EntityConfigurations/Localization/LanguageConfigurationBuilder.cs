using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PazarAtlasi.CMS.Domain.Common;
using PazarAtlasi.CMS.Domain.Entities.Localization;

namespace PazarAtlasi.CMS.Persistence.EntityConfigurations.Localization
{
    public class LanguageConfigurationBuilder : IEntityTypeConfiguration<Language>
    {
        public void Configure(EntityTypeBuilder<Language> builder)
        {
            // Table configuration
            builder.ToTable("Languages").HasKey(l => l.Id);

            // Property configurations
            builder.Property(l => l.Id)
                .HasColumnName("Id")
                .IsRequired();

            builder.Property(l => l.Name)
                .HasColumnName("Name")
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(l => l.Code)
                .HasColumnName("Code")
                .HasMaxLength(10)
                .IsRequired();

            builder.Property(l => l.NativeName)
                .HasColumnName("NativeName")
                .HasMaxLength(100);

            builder.Property(l => l.Flag)
                .HasColumnName("Flag")
                .HasMaxLength(10);

            builder.Property(l => l.IsDefault)
                .HasColumnName("IsDefault")
                .HasDefaultValue(false)
                .IsRequired();

            builder.Property(l => l.IsActive)
                .HasColumnName("IsActive")
                .HasDefaultValue(true)
                .IsRequired();

            builder.Property(l => l.SortOrder)
                .HasColumnName("SortOrder")
                .HasDefaultValue(0)
                .IsRequired();

            builder.Property(l => l.CreatedAt)
                .HasColumnName("CreatedAt")
                .HasDefaultValueSql("GETUTCDATE()")
                .IsRequired();

            builder.Property(l => l.UpdatedAt)
                .HasColumnName("UpdatedAt");

            builder.Property(l => l.IsDeleted)
                .HasColumnName("IsDeleted")
                .HasDefaultValue(false)
                .IsRequired();

            // Relationships
            builder.HasMany(l => l.LocalizationValues)
                .WithOne(lv => lv.Language)
                .HasForeignKey(lv => lv.LanguageId)
                .OnDelete(DeleteBehavior.Restrict);

            // Indexes
            builder.HasIndex(l => l.Code)
                .HasDatabaseName("IX_Languages_Code")
                .IsUnique();

            builder.HasIndex(l => l.IsDefault)
                .HasDatabaseName("IX_Languages_IsDefault");

            builder.HasIndex(l => l.IsActive)
                .HasDatabaseName("IX_Languages_IsActive");

            builder.HasIndex(l => l.SortOrder)
                .HasDatabaseName("IX_Languages_SortOrder");

            builder.HasIndex(l => l.IsDeleted)
                .HasDatabaseName("IX_Languages_IsDeleted");

            // Query filter for soft delete
            builder.HasQueryFilter(l => !l.IsDeleted);

            // Seed data
            builder.HasData(
                new Language
                {
                    Id = 1,
                    Name = "Türkçe",
                    Code = "tr-TR",
                    NativeName = "Türkçe",
                    Flag = "🇹🇷",
                    IsDefault = true,
                    IsActive = true,
                    SortOrder = 1,
                    CreatedAt = DateTime.UtcNow,
                    IsDeleted = false
                },
                new Language
                {
                    Id = 2,
                    Name = "English",
                    Code = "en-US",
                    NativeName = "English",
                    Flag = "🇺🇸",
                    IsDefault = false,
                    IsActive = true,
                    SortOrder = 2,
                    CreatedAt = DateTime.UtcNow,
                    IsDeleted = false
                },
                new Language
                {
                    Id = 3,
                    Name = "Deutsch",
                    Code = "de-DE",
                    NativeName = "Deutsch",
                    Flag = "🇩🇪",
                    IsDefault = false,
                    IsActive = true,
                    SortOrder = 3,
                    CreatedAt = DateTime.UtcNow,
                    IsDeleted = false
                },
                new Language
                {
                    Id = 4,
                    Name = "Français",
                    Code = "fr-FR",
                    NativeName = "Français",
                    Flag = "🇫🇷",
                    IsDefault = false,
                    IsActive = true,
                    SortOrder = 4,
                    CreatedAt = DateTime.UtcNow,
                    IsDeleted = false
                },
                new Language
                {
                    Id = 5,
                    Name = "Español",
                    Code = "es-ES",
                    NativeName = "Español",
                    Flag = "🇪🇸",
                    IsDefault = false,
                    IsActive = true,
                    SortOrder = 5,
                    CreatedAt = DateTime.UtcNow,
                    IsDeleted = false
                }
            );
        }
    }
}