using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PazarAtlasi.CMS.Domain.Entities.Metadata;
using PazarAtlasi.CMS.Domain.Common;

namespace PazarAtlasi.CMS.Persistence.EntityConfigurations.Metadata
{
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            // Table name and primary key
            builder.ToTable("Categories").HasKey(c => c.Id);

            // Properties
            builder.Property(c => c.Id).HasColumnName("Id").IsRequired();
            builder.Property(c => c.ParentCategoryId).HasColumnName("ParentCategoryId");
            builder.Property(c => c.Name).HasColumnName("Name").IsRequired().HasMaxLength(255);
            builder.Property(c => c.Code).HasColumnName("Code").IsRequired().HasMaxLength(100);
            builder.Property(c => c.IntegrationCode).HasColumnName("IntegrationCode").HasMaxLength(100);
            builder.Property(c => c.Description).HasColumnName("Description").HasMaxLength(1000);
            builder.Property(c => c.SortOrder).HasColumnName("SortOrder").HasDefaultValue(0);
            builder.Property(c => c.Status).HasColumnName("Status").HasDefaultValue(Status.Active);
            builder.Property(c => c.CreatedAt).HasColumnName("CreatedAt").IsRequired();
            builder.Property(c => c.UpdatedAt).HasColumnName("UpdatedAt");
            builder.Property(c => c.IsDeleted).HasColumnName("IsDeleted").HasDefaultValue(false);
            builder.Property(c => c.CreatedBy).HasColumnName("CreatedBy");
            builder.Property(c => c.UpdatedBy).HasColumnName("UpdatedBy");

            // Relationships
            // Self-referencing relationship for hierarchical categories
            builder.HasOne(c => c.ParentCategory)
                   .WithMany(c => c.ChildCategories)
                   .HasForeignKey(c => c.ParentCategoryId)
                   .OnDelete(DeleteBehavior.Restrict); // Prevent cascade delete to avoid orphaned categories

            // One-to-many relationship with CategoryTranslation
            builder.HasMany(c => c.Translations)
                   .WithOne(ct => ct.Category)
                   .HasForeignKey(ct => ct.CategoryId)
                   .OnDelete(DeleteBehavior.Cascade);

            // One-to-many relationship with CategoryProduct (junction table)
            builder.HasMany(c => c.CategoryProducts)
                   .WithOne(cp => cp.Category)
                   .HasForeignKey(cp => cp.CategoryId)
                   .OnDelete(DeleteBehavior.Cascade);

            // Indexes
            builder.HasIndex(c => c.Code).HasDatabaseName("IX_Categories_Code").IsUnique();
            builder.HasIndex(c => c.IntegrationCode).HasDatabaseName("IX_Categories_IntegrationCode");
            builder.HasIndex(c => c.ParentCategoryId).HasDatabaseName("IX_Categories_ParentCategoryId");
            builder.HasIndex(c => c.Status).HasDatabaseName("IX_Categories_Status");
            builder.HasIndex(c => c.SortOrder).HasDatabaseName("IX_Categories_SortOrder");
            builder.HasIndex(c => new { c.ParentCategoryId, c.SortOrder }).HasDatabaseName("IX_Categories_Parent_SortOrder");

            // Query Filter (Soft Delete)
            builder.HasQueryFilter(c => !c.IsDeleted);

            // Seed Data - Root categories
            builder.HasData(
                new Category
                {
                    Id = 1,
                    ParentCategoryId = null,
                    Name = "Elektronik",
                    Code = "elektronik",
                    IntegrationCode = "ELEC",
                    Description = "Elektronik ürünler kategorisi",
                    SortOrder = 1,
                    Status = Status.Active,
                    CreatedAt = new DateTime(2024, 1, 1, 10, 0, 0),
                    IsDeleted = false
                },
                new Category
                {
                    Id = 2,
                    ParentCategoryId = null,
                    Name = "Giyim",
                    Code = "giyim",
                    IntegrationCode = "CLTH",
                    Description = "Giyim ve aksesuar kategorisi",
                    SortOrder = 2,
                    Status = Status.Active,
                    CreatedAt = new DateTime(2024, 1, 1, 10, 0, 0),
                    IsDeleted = false
                },
                new Category
                {
                    Id = 3,
                    ParentCategoryId = null,
                    Name = "Ev & Yaşam",
                    Code = "ev-yasam",
                    IntegrationCode = "HOME",
                    Description = "Ev ve yaşam ürünleri kategorisi",
                    SortOrder = 3,
                    Status = Status.Active,
                    CreatedAt = new DateTime(2024, 1, 1, 10, 0, 0),
                    IsDeleted = false
                },
                // Alt kategoriler - Elektronik
                new Category
                {
                    Id = 4,
                    ParentCategoryId = 1,
                    Name = "Bilgisayar",
                    Code = "bilgisayar",
                    IntegrationCode = "COMP",
                    Description = "Bilgisayar ve aksesuarları",
                    SortOrder = 1,
                    Status = Status.Active,
                    CreatedAt = new DateTime(2024, 1, 1, 10, 0, 0),
                    IsDeleted = false
                },
                new Category
                {
                    Id = 5,
                    ParentCategoryId = 1,
                    Name = "Telefon",
                    Code = "telefon",
                    IntegrationCode = "PHONE",
                    Description = "Cep telefonu ve aksesuarları",
                    SortOrder = 2,
                    Status = Status.Active,
                    CreatedAt = new DateTime(2024, 1, 1, 10, 0, 0),
                    IsDeleted = false
                },
                // Alt kategoriler - Giyim
                new Category
                {
                    Id = 6,
                    ParentCategoryId = 2,
                    Name = "Erkek Giyim",
                    Code = "erkek-giyim",
                    IntegrationCode = "MENS",
                    Description = "Erkek giyim ürünleri",
                    SortOrder = 1,
                    Status = Status.Active,
                    CreatedAt = new DateTime(2024, 1, 1, 10, 0, 0),
                    IsDeleted = false
                },
                new Category
                {
                    Id = 7,
                    ParentCategoryId = 2,
                    Name = "Kadın Giyim",
                    Code = "kadin-giyim",
                    IntegrationCode = "WMNS",
                    Description = "Kadın giyim ürünleri",
                    SortOrder = 2,
                    Status = Status.Active,
                    CreatedAt = new DateTime(2024, 1, 1, 10, 0, 0),
                    IsDeleted = false
                }
            );
        }
    }
}