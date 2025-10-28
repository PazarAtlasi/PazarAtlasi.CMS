using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PazarAtlasi.CMS.Domain.Entities.Content;
using PazarAtlasi.CMS.Domain.Common;

namespace PazarAtlasi.CMS.Persistence.EntityConfigurations.Content
{
    public class LanguageConfiguration : IEntityTypeConfiguration<Language>
    {
        public void Configure(EntityTypeBuilder<Language> builder)
        {
            builder.ToTable("Languages").HasKey(l => l.Id);

            builder.Property(l => l.Id).HasColumnName("Id").IsRequired();
            builder.Property(l => l.Name).HasColumnName("Name").IsRequired().HasMaxLength(100);
            builder.Property(l => l.Code).HasColumnName("Code").HasMaxLength(10);
            builder.Property(l => l.IsDefault).HasColumnName("IsDefault").HasDefaultValue(false);
            builder.Property(l => l.CreatedAt).HasColumnName("CreatedAt").IsRequired();
            builder.Property(l => l.UpdatedAt).HasColumnName("UpdatedAt");
            builder.Property(l => l.IsDeleted).HasColumnName("IsDeleted").HasDefaultValue(false);
            builder.Property(l => l.Status).HasColumnName("Status").HasDefaultValue(Status.Draft);
            builder.Property(l => l.CreatedBy).HasColumnName("CreatedBy");
            builder.Property(l => l.UpdatedBy).HasColumnName("UpdatedBy");

            // Indexes
            builder.HasIndex(l => l.Code).IsUnique().HasDatabaseName("IX_Languages_Code");
            builder.HasIndex(l => l.IsDefault).HasDatabaseName("IX_Languages_IsDefault");

            // Query Filter
            builder.HasQueryFilter(l => !l.IsDeleted);

            // Seed Data
            builder.HasData(
                new Language
                {
                    Id = 1,
                    Name = "Türkçe",
                    Code = "tr-TR",
                    IsDefault = true,
                    CreatedAt = new DateTime(2024, 1, 1, 10, 0, 0),
                    Status = Status.Active,
                    IsDeleted = false
                },
                new Language
                {
                    Id = 2,
                    Name = "English",
                    Code = "en-US",
                    IsDefault = false,
                    CreatedAt = new DateTime(2024, 1, 1, 10, 0, 0),
                    Status = Status.Active,
                    IsDeleted = false
                },
                new Language
                {
                    Id = 3,
                    Name = "Deutsch",
                    Code = "de-DE",
                    IsDefault = false,
                    CreatedAt = new DateTime(2024, 1, 1, 10, 0, 0),
                    Status = Status.Active,
                    IsDeleted = false
                }
            );
        }
    }
}
