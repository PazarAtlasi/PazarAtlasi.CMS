using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PazarAtlasi.CMS.Domain.Entities.Content;

namespace PazarAtlasi.CMS.Persistence.EntityConfigurations.Content
{
    public class ArticleConfiguration : IEntityTypeConfiguration<Article>
    {
        public void Configure(EntityTypeBuilder<Article> builder)
        {
            // Table name and primary key
            builder.ToTable("Articles").HasKey(a => a.Id);

            // Properties
            builder.Property(a => a.Id).HasColumnName("Id").IsRequired();
            builder.Property(a => a.CategoryId).HasColumnName("CategoryId");
            builder.Property(a => a.AuthorId).HasColumnName("AuthorId");
            builder.Property(a => a.FeaturedImage).HasColumnName("FeaturedImage").HasMaxLength(500);
            builder.Property(a => a.VideoUrl).HasColumnName("VideoUrl").HasMaxLength(500);
            builder.Property(a => a.PublishedAt).HasColumnName("PublishedAt");
            builder.Property(a => a.ViewCount).HasColumnName("ViewCount").HasDefaultValue(0);
            builder.Property(a => a.LikeCount).HasColumnName("LikeCount").HasDefaultValue(0);
            builder.Property(a => a.IsFeatured).HasColumnName("IsFeatured").HasDefaultValue(false);
            builder.Property(a => a.IsTrending).HasColumnName("IsTrending").HasDefaultValue(false);
            builder.Property(a => a.ReadingTime).HasColumnName("ReadingTime");
            builder.Property(a => a.Tags).HasColumnName("Tags").HasColumnType("nvarchar(max)");
            builder.Property(a => a.MetaDescription).HasColumnName("MetaDescription").HasMaxLength(500);
            builder.Property(a => a.MetaKeywords).HasColumnName("MetaKeywords").HasMaxLength(500);
            builder.Property(a => a.SortOrder).HasColumnName("SortOrder").HasDefaultValue(0);
            builder.Property(a => a.Status).HasColumnName("Status").HasDefaultValue(Domain.Common.Status.Draft);
            builder.Property(a => a.CreatedAt).HasColumnName("CreatedAt").IsRequired();
            builder.Property(a => a.UpdatedAt).HasColumnName("UpdatedAt");
            builder.Property(a => a.IsDeleted).HasColumnName("IsDeleted").HasDefaultValue(false);

            // Relationships
            builder.HasOne(a => a.Category)
                   .WithMany(c => c.Articles)
                   .HasForeignKey(a => a.CategoryId)
                   .OnDelete(DeleteBehavior.SetNull);

            builder.HasMany(a => a.Translations)
                   .WithOne(t => t.Article)
                   .HasForeignKey(t => t.ArticleId)
                   .OnDelete(DeleteBehavior.Cascade);

            // Indexes
            builder.HasIndex(a => a.CategoryId).HasDatabaseName("IX_Articles_CategoryId");
            builder.HasIndex(a => a.PublishedAt).HasDatabaseName("IX_Articles_PublishedAt");
            builder.HasIndex(a => a.IsFeatured).HasDatabaseName("IX_Articles_IsFeatured");
            builder.HasIndex(a => a.IsTrending).HasDatabaseName("IX_Articles_IsTrending");
            builder.HasIndex(a => a.Status).HasDatabaseName("IX_Articles_Status");
            builder.HasIndex(a => a.SortOrder).HasDatabaseName("IX_Articles_SortOrder");

            // Query Filter (Soft Delete)
            builder.HasQueryFilter(a => !a.IsDeleted);

            // Seed Data
            builder.HasData(
                new Article
                {
                    Id = 1,
                    CategoryId = 1,
                    FeaturedImage = "/images/articles/welcome.jpg",
                    PublishedAt = DateTime.UtcNow,
                    IsFeatured = true,
                    ReadingTime = 5,
                    ViewCount = 150,
                    LikeCount = 25,
                    Tags = "[\"cms\",\"welcome\",\"tutorial\"]",
                    Status = Domain.Common.Status.Active,
                    CreatedAt = DateTime.UtcNow,
                    IsDeleted = false
                },
                new Article
                {
                    Id = 2,
                    CategoryId = 1,
                    FeaturedImage = "/images/articles/getting-started.jpg",
                    PublishedAt = DateTime.UtcNow,
                    IsTrending = true,
                    ReadingTime = 8,
                    ViewCount = 220,
                    LikeCount = 42,
                    Tags = "[\"tutorial\",\"guide\",\"beginners\"]",
                    Status = Domain.Common.Status.Active,
                    CreatedAt = DateTime.UtcNow,
                    IsDeleted = false
                }
            );
        }
    }
}
