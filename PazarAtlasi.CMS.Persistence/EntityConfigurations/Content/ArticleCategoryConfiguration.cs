using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PazarAtlasi.CMS.Domain.Entities.Content;

namespace PazarAtlasi.CMS.Persistence.EntityConfigurations.Content
{
    public class ArticleCategoryConfiguration : IEntityTypeConfiguration<ArticleCategory>
    {
        public void Configure(EntityTypeBuilder<ArticleCategory> builder)
        {
            // Table name and primary key
            builder.ToTable("ArticleCategories").HasKey(ac => ac.Id);

            // Properties
            builder.Property(ac => ac.Id).HasColumnName("Id").IsRequired();
            builder.Property(ac => ac.ParentCategoryId).HasColumnName("ParentCategoryId");
            builder.Property(ac => ac.Icon).HasColumnName("Icon").HasMaxLength(200);
            builder.Property(ac => ac.Color).HasColumnName("Color").HasMaxLength(50);
            builder.Property(ac => ac.SortOrder).HasColumnName("SortOrder").HasDefaultValue(0);
            builder.Property(ac => ac.Status).HasColumnName("Status").HasDefaultValue(Domain.Common.Status.Active);
            builder.Property(ac => ac.CreatedAt).HasColumnName("CreatedAt").IsRequired();
            builder.Property(ac => ac.UpdatedAt).HasColumnName("UpdatedAt");
            builder.Property(ac => ac.IsDeleted).HasColumnName("IsDeleted").HasDefaultValue(false);

            // Relationships
            builder.HasOne(ac => ac.ParentCategory)
                   .WithMany(pc => pc.ChildCategories)
                   .HasForeignKey(ac => ac.ParentCategoryId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(ac => ac.Articles)
                   .WithOne(a => a.Category)
                   .HasForeignKey(a => a.CategoryId)
                   .OnDelete(DeleteBehavior.SetNull);

            builder.HasMany(ac => ac.Translations)
                   .WithOne(t => t.ArticleCategory)
                   .HasForeignKey(t => t.ArticleCategoryId)
                   .OnDelete(DeleteBehavior.Cascade);

            // Indexes
            builder.HasIndex(ac => ac.ParentCategoryId).HasDatabaseName("IX_ArticleCategories_ParentCategoryId");
            builder.HasIndex(ac => ac.SortOrder).HasDatabaseName("IX_ArticleCategories_SortOrder");
            builder.HasIndex(ac => ac.Status).HasDatabaseName("IX_ArticleCategories_Status");

            // Query Filter (Soft Delete)
            builder.HasQueryFilter(ac => !ac.IsDeleted);

            // Seed Data
            builder.HasData(
                new ArticleCategory
                {
                    Id = 1,
                    Icon = "fas fa-newspaper",
                    Color = "#3b82f6",
                    SortOrder = 1,
                    Status = Domain.Common.Status.Active,
                    CreatedAt = DateTime.UtcNow,
                    IsDeleted = false
                },
                new ArticleCategory
                {
                    Id = 2,
                    Icon = "fas fa-lightbulb",
                    Color = "#f59e0b",
                    SortOrder = 2,
                    Status = Domain.Common.Status.Active,
                    CreatedAt = DateTime.UtcNow,
                    IsDeleted = false
                },
                new ArticleCategory
                {
                    Id = 3,
                    Icon = "fas fa-rocket",
                    Color = "#8b5cf6",
                    SortOrder = 3,
                    Status = Domain.Common.Status.Active,
                    CreatedAt = DateTime.UtcNow,
                    IsDeleted = false
                }
            );
        }
    }
}
