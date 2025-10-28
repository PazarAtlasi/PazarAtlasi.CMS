using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PazarAtlasi.CMS.Domain.Common;

namespace PazarAtlasi.CMS.Persistence.EntityConfigurations.Content
{
    public class ContinentConfiguration : IEntityTypeConfiguration<Continent>
    {
        public void Configure(EntityTypeBuilder<Continent> builder)
        {
            builder.ToTable("Continents").HasKey(c => c.Id);

            builder.Property(c => c.Id).HasColumnName("Id").IsRequired();
            builder.Property(c => c.Name).HasColumnName("Name").IsRequired().HasMaxLength(100);
            builder.Property(c => c.Code).HasColumnName("Code").HasMaxLength(10);
            builder.Property(c => c.IsActive).HasColumnName("IsActive").HasDefaultValue(true);
            builder.Property(c => c.SortOrder).HasColumnName("SortOrder").HasDefaultValue(0);
            builder.Property(c => c.CreatedAt).HasColumnName("CreatedAt").IsRequired();
            builder.Property(c => c.UpdatedAt).HasColumnName("UpdatedAt");
            builder.Property(c => c.IsDeleted).HasColumnName("IsDeleted").HasDefaultValue(false);
            builder.Property(c => c.Status).HasColumnName("Status").HasDefaultValue(Status.Active);
            builder.Property(c => c.CreatedBy).HasColumnName("CreatedBy");
            builder.Property(c => c.UpdatedBy).HasColumnName("UpdatedBy");

            // Relationships
            builder.HasMany(c => c.Countries)
                   .WithOne(co => co.Continent)
                   .HasForeignKey(co => co.ContinentId)
                   .OnDelete(DeleteBehavior.SetNull);

            // Indexes
            builder.HasIndex(c => c.Code).HasDatabaseName("IX_Continents_Code");
            builder.HasIndex(c => c.IsActive).HasDatabaseName("IX_Continents_IsActive");
            builder.HasIndex(c => c.SortOrder).HasDatabaseName("IX_Continents_SortOrder");

            // Query Filter
            builder.HasQueryFilter(c => !c.IsDeleted);

            // Seed Data
            builder.HasData(
                new Continent
                {
                    Id = 1,
                    Name = "Afrika",
                    Code = "AF",
                    IsActive = true,
                    SortOrder = 1,
                    CreatedAt = new DateTime(2024, 1, 1, 10, 0, 0),
                    Status = Status.Active,
                    IsDeleted = false
                },
                new Continent
                {
                    Id = 2,
                    Name = "Avrupa",
                    Code = "EU",
                    IsActive = true,
                    SortOrder = 2,
                    CreatedAt = new DateTime(2024, 1, 1, 10, 0, 0),
                    Status = Status.Active,
                    IsDeleted = false
                },
                new Continent
                {
                    Id = 3,
                    Name = "Kuzey Amerika",
                    Code = "NA",
                    IsActive = true,
                    SortOrder = 3,
                    CreatedAt = new DateTime(2024, 1, 1, 10, 0, 0),
                    Status = Status.Active,
                    IsDeleted = false
                },
                new Continent
                {
                    Id = 4,
                    Name = "Güney Amerika",
                    Code = "SA",
                    IsActive = true,
                    SortOrder = 4,
                    CreatedAt = new DateTime(2024, 1, 1, 10, 0, 0),
                    Status = Status.Active,
                    IsDeleted = false
                },
                new Continent
                {
                    Id = 5,
                    Name = "Asya",
                    Code = "AS",
                    IsActive = true,
                    SortOrder = 5,
                    CreatedAt = new DateTime(2024, 1, 1, 10, 0, 0),
                    Status = Status.Active,
                    IsDeleted = false
                },
                new Continent
                {
                    Id = 6,
                    Name = "Okyanusya",
                    Code = "OC",
                    IsActive = true,
                    SortOrder = 6,
                    CreatedAt = new DateTime(2024, 1, 1, 10, 0, 0),
                    Status = Status.Active,
                    IsDeleted = false
                }
            );
        }
    }
}