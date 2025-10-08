using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PazarAtlasi.CMS.Domain.Entities.Content;
using PazarAtlasi.CMS.Domain.Common;

namespace PazarAtlasi.CMS.Persistence.EntityConfigurations.Content
{
    public class ContentConfiguration : IEntityTypeConfiguration<Domain.Entities.Content.Content>
    {
        public void Configure(EntityTypeBuilder<Domain.Entities.Content.Content> builder)
        {
            builder.ToTable("Contents").HasKey(c => c.Id);

            builder.Property(c => c.Id).HasColumnName("Id").IsRequired();
            builder.Property(c => c.RelatedEntityId).HasColumnName("RelatedEntityId").IsRequired();
            builder.Property(c => c.RelatedDataId).HasColumnName("RelatedDataId").IsRequired();
            builder.Property(c => c.Description).HasColumnName("Description").HasMaxLength(1000);
            builder.Property(c => c.CreatedAt).HasColumnName("CreatedAt").IsRequired();
            builder.Property(c => c.UpdatedAt).HasColumnName("UpdatedAt");
            builder.Property(c => c.IsDeleted).HasColumnName("IsDeleted").HasDefaultValue(false);
            builder.Property(c => c.Status).HasColumnName("Status").HasDefaultValue(Status.Draft);
            builder.Property(c => c.CreatedBy).HasColumnName("CreatedBy");
            builder.Property(c => c.UpdatedBy).HasColumnName("UpdatedBy");

            // Relationships
            builder.HasMany(c => c.Pages)
                   .WithOne(p => p.Content)
                   .HasForeignKey(p => p.ContentId)
                   .OnDelete(DeleteBehavior.Cascade);

            // Query Filter
            builder.HasQueryFilter(c => !c.IsDeleted);

            // Seed Data
            builder.HasData(
                new Domain.Entities.Content.Content
                {
                    Id = 1,
                    RelatedEntityId = EntityType.Page,
                    RelatedDataId = 1,
                    Description = "Ana sayfa içeriği",
                    CreatedAt = new DateTime(2024, 1, 1, 10, 0, 0),
                    Status = Status.Active,
                    IsDeleted = false
                },
                new Domain.Entities.Content.Content
                {
                    Id = 2,
                    RelatedEntityId = EntityType.Blog,
                    RelatedDataId = 1,
                    Description = "Blog yazısı içeriği",
                    CreatedAt = new DateTime(2024, 1, 2, 10, 0, 0),
                    Status = Status.Active,
                    IsDeleted = false
                },
                new Domain.Entities.Content.Content
                {
                    Id = 3,
                    RelatedEntityId = EntityType.Product,
                    RelatedDataId = 1,
                    Description = "Ürün detay sayfası içeriği",
                    CreatedAt = new DateTime(2024, 1, 3, 10, 0, 0),
                    Status = Status.Active,
                    IsDeleted = false
                }
            );
        }
    }
}
