using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PazarAtlasi.CMS.Domain.Entities.Content;

namespace PazarAtlasi.CMS.Persistence.EntityConfigurations.Content
{
    public class ContentConfiguration : IEntityTypeConfiguration<Domain.Entities.Content.Content>
    {
        public void Configure(EntityTypeBuilder<Domain.Entities.Content.Content> builder)
        {
            // Tablo adı ve primary key
            builder.ToTable("Contents").HasKey(c => c.Id);

            // Özellik konfigürasyonları
            builder.Property(c => c.Id).HasColumnName("Id").IsRequired();
            builder.Property(c => c.RelatedDataEntityType).HasColumnName("RelatedDataEntityType").IsRequired();
            builder.Property(c => c.RelatedDataEntityId).HasColumnName("RelatedDataEntityId").IsRequired();
            builder.Property(c => c.Description).HasColumnName("Description").HasMaxLength(2000);
            builder.Property(c => c.MetaTitle).HasColumnName("MetaTitle").HasMaxLength(200);
            builder.Property(c => c.MetaDescription).HasColumnName("MetaDescription").HasMaxLength(500);
            builder.Property(c => c.MetaKeywords).HasColumnName("MetaKeywords").HasMaxLength(500);
            builder.Property(c => c.SubDescription).HasColumnName("SubDescription").HasMaxLength(1000);
            builder.Property(c => c.Title).HasColumnName("Title").HasMaxLength(200);
            builder.Property(c => c.Author).HasColumnName("Author").HasMaxLength(100);

            // İlişkiler
            builder.HasMany(c => c.Pages)
                   .WithOne(p => p.Content)
                   .HasForeignKey(p => p.ContentId)
                   .OnDelete(DeleteBehavior.SetNull);

            builder.HasMany(c => c.ContentSlugs)
                   .WithOne(cs => cs.Content)
                   .HasForeignKey(cs => cs.ContentId)
                   .OnDelete(DeleteBehavior.Cascade);

            // İndeksler
            builder.HasIndex(c => new { c.RelatedDataEntityType, c.RelatedDataEntityId })
                   .HasDatabaseName("IX_Contents_RelatedDataEntity");
            builder.HasIndex(c => c.RelatedDataEntityType)
                   .HasDatabaseName("IX_Contents_RelatedDataEntityType");

            // Query Filter (Soft Delete)
            builder.HasQueryFilter(c => !c.IsDeleted);

            // Seed Data - Content entities for main pages
            builder.HasData(
                new Domain.Entities.Content.Content
                {
                    Id = 1,
                    RelatedDataEntityType = Domain.Common.EntityType.Page,
                    RelatedDataEntityId = 1, // Ana Sayfa
                    Title = "Ana Sayfa",
                    Description = "Pazar Atlası CMS ana sayfası. Modern ve kullanıcı dostu içerik yönetim sistemi ile web sitenizi kolayca yönetin.",
                    SubDescription = "Güçlü CMS çözümü ile dijital varlığınızı güçlendirin",
                    MetaTitle = "Ana Sayfa - Pazar Atlası CMS",
                    MetaDescription = "Pazar Atlası CMS ana sayfası. Modern ve kullanıcı dostu içerik yönetim sistemi.",
                    MetaKeywords = "cms, içerik yönetimi, pazar atlası, web sitesi, modern cms",
                    Author = "Pazar Atlası",
                    CreatedAt = new DateTime(2024, 1, 1, 10, 0, 0),
                    IsDeleted = false,
                    Status = Domain.Common.Status.Active
                },
                new Domain.Entities.Content.Content
                {
                    Id = 2,
                    RelatedDataEntityType = Domain.Common.EntityType.Page,
                    RelatedDataEntityId = 2, // Blog
                    Title = "Blog",
                    Description = "Pazar Atlası blog yazıları. Teknoloji, pazarlama ve iş dünyasından güncel haberler, ipuçları ve derinlemesine analizler.",
                    SubDescription = "Sektörden güncel haberler ve uzman görüşleri",
                    MetaTitle = "Blog - Pazar Atlası CMS",
                    MetaDescription = "Pazar Atlası blog yazıları. Teknoloji, pazarlama ve iş dünyasından güncel haberler.",
                    MetaKeywords = "blog, yazılar, teknoloji, pazarlama, iş, haberler, analiz",
                    Author = "Pazar Atlası",
                    CreatedAt = new DateTime(2024, 1, 2, 10, 0, 0),
                    IsDeleted = false,
                    Status = Domain.Common.Status.Active
                },
                new Domain.Entities.Content.Content
                {
                    Id = 3,
                    RelatedDataEntityType = Domain.Common.EntityType.Page,
                    RelatedDataEntityId = 3, // Ürünler
                    Title = "Ürünler",
                    Description = "Pazar Atlası ürün kataloğu. Kaliteli ve uygun fiyatlı ürünler, geniş kategori seçenekleri ve güvenli alışveriş imkanı.",
                    SubDescription = "Kaliteli ürünler, uygun fiyatlar",
                    MetaTitle = "Ürünler - Pazar Atlası CMS",
                    MetaDescription = "Pazar Atlası ürün kataloğu. Kaliteli ve uygun fiyatlı ürünler.",
                    MetaKeywords = "ürünler, katalog, alışveriş, kalite, elektronik, giyim",
                    Author = "Pazar Atlası",
                    CreatedAt = new DateTime(2024, 1, 3, 10, 0, 0),
                    IsDeleted = false,
                    Status = Domain.Common.Status.Active
                }
            );
        }
    }
}