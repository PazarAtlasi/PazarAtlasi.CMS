using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PazarAtlasi.CMS.Domain.Entities.Metadata;
using PazarAtlasi.CMS.Domain.Common;

namespace PazarAtlasi.CMS.Persistence.EntityConfigurations.Metadata
{
    public class CategoryTranslationConfiguration : IEntityTypeConfiguration<CategoryTranslation>
    {
        public void Configure(EntityTypeBuilder<CategoryTranslation> builder)
        {
            // Table name and primary key
            builder.ToTable("CategoryTranslations").HasKey(ct => ct.Id);

            // Properties
            builder.Property(ct => ct.Id).HasColumnName("Id").IsRequired();
            builder.Property(ct => ct.CategoryId).HasColumnName("CategoryId").IsRequired();
            builder.Property(ct => ct.LanguageId).HasColumnName("LanguageId").IsRequired();
            builder.Property(ct => ct.Name).HasColumnName("Name").IsRequired().HasMaxLength(255);
            builder.Property(ct => ct.ShortDescription).HasColumnName("ShortDescription").HasMaxLength(500);
            builder.Property(ct => ct.LongDescription).HasColumnName("LongDescription").HasMaxLength(2000);
            builder.Property(ct => ct.Status).HasColumnName("Status").HasDefaultValue(Status.Active);
            builder.Property(ct => ct.CreatedAt).HasColumnName("CreatedAt").IsRequired();
            builder.Property(ct => ct.UpdatedAt).HasColumnName("UpdatedAt");
            builder.Property(ct => ct.IsDeleted).HasColumnName("IsDeleted").HasDefaultValue(false);
            builder.Property(ct => ct.CreatedBy).HasColumnName("CreatedBy");
            builder.Property(ct => ct.UpdatedBy).HasColumnName("UpdatedBy");

            // Relationships
            builder.HasOne(ct => ct.Category)
                   .WithMany(c => c.Translations)
                   .HasForeignKey(ct => ct.CategoryId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(ct => ct.Language)
                   .WithMany()
                   .HasForeignKey(ct => ct.LanguageId)
                   .OnDelete(DeleteBehavior.Restrict);

            // Indexes
            builder.HasIndex(ct => new { ct.CategoryId, ct.LanguageId })
                   .HasDatabaseName("IX_CategoryTranslations_CategoryId_LanguageId")
                   .IsUnique();

            builder.HasIndex(ct => ct.CategoryId).HasDatabaseName("IX_CategoryTranslations_CategoryId");
            builder.HasIndex(ct => ct.LanguageId).HasDatabaseName("IX_CategoryTranslations_LanguageId");

            // Query Filter (Soft Delete)
            builder.HasQueryFilter(ct => !ct.IsDeleted);

            // Seed Data - Translations for root categories
            builder.HasData(
                // Elektronik - Turkish (Default)
                new CategoryTranslation
                {
                    Id = 1,
                    CategoryId = 1,
                    LanguageId = 1, // Turkish
                    Name = "Elektronik",
                    ShortDescription = "Elektronik ürünler",
                    LongDescription = "Bilgisayar, telefon ve diğer elektronik ürünler kategorisi",
                    Status = Status.Active,
                    CreatedAt = new DateTime(2024, 1, 1, 10, 0, 0),
                    IsDeleted = false
                },
                // Elektronik - English
                new CategoryTranslation
                {
                    Id = 2,
                    CategoryId = 1,
                    LanguageId = 2, // English
                    Name = "Electronics",
                    ShortDescription = "Electronic products",
                    LongDescription = "Category for computers, phones and other electronic products",
                    Status = Status.Active,
                    CreatedAt = new DateTime(2024, 1, 1, 10, 0, 0),
                    IsDeleted = false
                },
                // Giyim - Turkish
                new CategoryTranslation
                {
                    Id = 3,
                    CategoryId = 2,
                    LanguageId = 1, // Turkish
                    Name = "Giyim",
                    ShortDescription = "Giyim ürünleri",
                    LongDescription = "Erkek, kadın ve çocuk giyim ürünleri kategorisi",
                    Status = Status.Active,
                    CreatedAt = new DateTime(2024, 1, 1, 10, 0, 0),
                    IsDeleted = false
                },
                // Giyim - English
                new CategoryTranslation
                {
                    Id = 4,
                    CategoryId = 2,
                    LanguageId = 2, // English
                    Name = "Clothing",
                    ShortDescription = "Clothing products",
                    LongDescription = "Category for men's, women's and children's clothing products",
                    Status = Status.Active,
                    CreatedAt = new DateTime(2024, 1, 1, 10, 0, 0),
                    IsDeleted = false
                },
                // Ev & Yaşam - Turkish
                new CategoryTranslation
                {
                    Id = 5,
                    CategoryId = 3,
                    LanguageId = 1, // Turkish
                    Name = "Ev & Yaşam",
                    ShortDescription = "Ev ve yaşam ürünleri",
                    LongDescription = "Ev dekorasyonu, mutfak eşyaları ve yaşam ürünleri kategorisi",
                    Status = Status.Active,
                    CreatedAt = new DateTime(2024, 1, 1, 10, 0, 0),
                    IsDeleted = false
                },
                // Ev & Yaşam - English
                new CategoryTranslation
                {
                    Id = 6,
                    CategoryId = 3,
                    LanguageId = 2, // English
                    Name = "Home & Living",
                    ShortDescription = "Home and living products",
                    LongDescription = "Category for home decoration, kitchen items and living products",
                    Status = Status.Active,
                    CreatedAt = new DateTime(2024, 1, 1, 10, 0, 0),
                    IsDeleted = false
                },
                // Bilgisayar - Turkish
                new CategoryTranslation
                {
                    Id = 7,
                    CategoryId = 4,
                    LanguageId = 1, // Turkish
                    Name = "Bilgisayar",
                    ShortDescription = "Bilgisayar ürünleri",
                    LongDescription = "Masaüstü, dizüstü bilgisayar ve aksesuarları",
                    Status = Status.Active,
                    CreatedAt = new DateTime(2024, 1, 1, 10, 0, 0),
                    IsDeleted = false
                },
                // Bilgisayar - English
                new CategoryTranslation
                {
                    Id = 8,
                    CategoryId = 4,
                    LanguageId = 2, // English
                    Name = "Computer",
                    ShortDescription = "Computer products",
                    LongDescription = "Desktop, laptop computers and accessories",
                    Status = Status.Active,
                    CreatedAt = new DateTime(2024, 1, 1, 10, 0, 0),
                    IsDeleted = false
                },
                // Telefon - Turkish
                new CategoryTranslation
                {
                    Id = 9,
                    CategoryId = 5,
                    LanguageId = 1, // Turkish
                    Name = "Telefon",
                    ShortDescription = "Telefon ürünleri",
                    LongDescription = "Akıllı telefon, cep telefonu ve aksesuarları",
                    Status = Status.Active,
                    CreatedAt = new DateTime(2024, 1, 1, 10, 0, 0),
                    IsDeleted = false
                },
                // Telefon - English
                new CategoryTranslation
                {
                    Id = 10,
                    CategoryId = 5,
                    LanguageId = 2, // English
                    Name = "Phone",
                    ShortDescription = "Phone products",
                    LongDescription = "Smartphones, mobile phones and accessories",
                    Status = Status.Active,
                    CreatedAt = new DateTime(2024, 1, 1, 10, 0, 0),
                    IsDeleted = false
                }
            );
        }
    }
}