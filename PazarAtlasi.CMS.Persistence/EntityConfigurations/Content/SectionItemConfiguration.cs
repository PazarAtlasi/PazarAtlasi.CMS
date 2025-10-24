using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PazarAtlasi.CMS.Domain.Entities.Content;
using PazarAtlasi.CMS.Domain.Common;

namespace PazarAtlasi.CMS.Persistence.EntityConfigurations.Content
{
    public class SectionItemConfigurationBuilder : IEntityTypeConfiguration<SectionItem>
    {
        public void Configure(EntityTypeBuilder<SectionItem> builder)
        {
            builder.ToTable("SectionItems").HasKey(si => si.Id);

            builder.Property(si => si.Id).HasColumnName("Id").IsRequired();
            builder.Property(si => si.SectionId).HasColumnName("SectionId").IsRequired();
            builder.Property(si => si.Type).HasColumnName("Type").HasDefaultValue(SectionItemType.None);
            builder.Property(si => si.MediaType).HasColumnName("MediaType").HasDefaultValue(MediaType.None);
            builder.Property(si => si.SortOrder).HasColumnName("SortOrder").HasDefaultValue(0);
            builder.Property(si => si.CreatedAt).HasColumnName("CreatedAt").IsRequired();
            builder.Property(si => si.UpdatedAt).HasColumnName("UpdatedAt");
            builder.Property(si => si.IsDeleted).HasColumnName("IsDeleted").HasDefaultValue(false);
            builder.Property(si => si.Status).HasColumnName("Status").HasDefaultValue(Status.Draft);
            builder.Property(si => si.CreatedBy).HasColumnName("CreatedBy");
            builder.Property(si => si.UpdatedBy).HasColumnName("UpdatedBy");

            // New properties
            builder.Property(si => si.Title)
                .HasColumnName("Title")
                .HasMaxLength(200);

            builder.Property(si => si.Description)
                .HasColumnName("Description")
                .HasMaxLength(500);

            builder.Property(si => si.AllowReorder)
                .HasColumnName("AllowReorder")
                .HasDefaultValue(true);

            builder.Property(si => si.AllowRemove)
                .HasColumnName("AllowRemove")
                .HasDefaultValue(true);

            builder.Property(si => si.IconClass)
                .HasColumnName("IconClass")
                .HasMaxLength(100);

            // Template relationship
            builder.Property(si => si.TemplateId)
                .HasColumnName("TemplateId");

            // Relationships
            builder.HasOne(si => si.Section)
                   .WithMany(s => s.SectionItems)
                   .HasForeignKey(si => si.SectionId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(si => si.Template)
                   .WithMany(c => c.SectionItems)
                   .HasForeignKey(si => si.TemplateId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(si => si.Translations)
                   .WithOne(sit => sit.SectionItem)
                   .HasForeignKey(sit => sit.SectionItemId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(si => si.SectionItemFields)
                   .WithOne(fv => fv.SectionItem)
                   .HasForeignKey(fv => fv.SectionItemId)
                   .OnDelete(DeleteBehavior.Cascade);

            // Indexes
            builder.HasIndex(si => new { si.SectionId, si.SortOrder }).HasDatabaseName("IX_SectionItems_SectionId_SortOrder");
            builder.HasIndex(si => si.Type).HasDatabaseName("IX_SectionItems_Type");
            builder.HasIndex(si => si.TemplateId).HasDatabaseName("IX_SectionItems_TemplateId");

            // Query Filter
            builder.HasQueryFilter(si => !si.IsDeleted);

            // Seed Data - Mega Menu Navbar Structure
            builder.HasData(
                // LOGO SECTION
                new SectionItem
                {
                    Id = 1,
                    SectionId = 1, // Assuming section ID 1 is a navbar section
                    ParentSectionItemId = null,
                    TemplateId = 2, // Mega Menu Navbar Template
                    Type = SectionItemType.Logo,
                    SortOrder = 1,
                    Title = "Brand Logo",
                    Description = "Main brand logo and text",
                    AllowReorder = false,
                    AllowRemove = false,
                    IconClass = "fas fa-image",
                    CreatedAt = new DateTime(2024, 10, 14, 10, 0, 0),
                    Status = Status.Active,
                    IsDeleted = false
                },

                // MAIN MENU ITEMS (Level 1)
                new SectionItem
                {
                    Id = 2,
                    SectionId = 1,
                    ParentSectionItemId = null,
                    TemplateId = 2,
                    Type = SectionItemType.Menu,
                    SortOrder = 2,
                    Title = "Ana Sayfa",
                    Description = "Homepage menu with quick access links",
                    AllowReorder = true,
                    AllowRemove = true,
                    IconClass = "fas fa-home",
                    CreatedAt = new DateTime(2024, 10, 14, 10, 0, 0),
                    Status = Status.Active,
                    IsDeleted = false
                },
                new SectionItem
                {
                    Id = 3,
                    SectionId = 1,
                    ParentSectionItemId = null,
                    TemplateId = 2,
                    Type = SectionItemType.Menu,
                    SortOrder = 3,
                    Title = "Ürünler",
                    Description = "Products mega menu with categories",
                    AllowReorder = true,
                    AllowRemove = true,
                    IconClass = "fas fa-shopping-bag",
                    CreatedAt = new DateTime(2024, 10, 14, 10, 0, 0),
                    Status = Status.Active,
                    IsDeleted = false
                },
                new SectionItem
                {
                    Id = 4,
                    SectionId = 1,
                    ParentSectionItemId = null,
                    TemplateId = 2,
                    Type = SectionItemType.Menu,
                    SortOrder = 4,
                    Title = "Hizmetler",
                    Description = "Services dropdown menu",
                    AllowReorder = true,
                    AllowRemove = true,
                    IconClass = "fas fa-cogs",
                    CreatedAt = new DateTime(2024, 10, 14, 10, 0, 0),
                    Status = Status.Active,
                    IsDeleted = false
                },
                new SectionItem
                {
                    Id = 5,
                    SectionId = 1,
                    ParentSectionItemId = null,
                    TemplateId = 2,
                    Type = SectionItemType.Menu,
                    SortOrder = 5,
                    Title = "Hakkımızda",
                    Description = "About us menu item",
                    AllowReorder = true,
                    AllowRemove = true,
                    IconClass = "fas fa-info-circle",
                    CreatedAt = new DateTime(2024, 10, 14, 10, 0, 0),
                    Status = Status.Active,
                    IsDeleted = false
                },
                new SectionItem
                {
                    Id = 6,
                    SectionId = 1,
                    ParentSectionItemId = null,
                    TemplateId = 2,
                    Type = SectionItemType.Menu,
                    SortOrder = 6,
                    Title = "İletişim",
                    Description = "Contact menu item",
                    AllowReorder = true,
                    AllowRemove = true,
                    IconClass = "fas fa-envelope",
                    CreatedAt = new DateTime(2024, 10, 14, 10, 0, 0),
                    Status = Status.Active,
                    IsDeleted = false
                },

                // PRODUCTS MEGA MENU - Level 2 (Categories)
                new SectionItem
                {
                    Id = 7,
                    SectionId = 1,
                    ParentSectionItemId = 3, // Under "Ürünler"
                    TemplateId = 2,
                    Type = SectionItemType.Category,
                    SortOrder = 1,
                    Title = "Elektronik",
                    Description = "Electronics category with featured products",
                    AllowReorder = true,
                    AllowRemove = true,
                    IconClass = "fas fa-laptop",
                    CreatedAt = new DateTime(2024, 10, 14, 10, 0, 0),
                    Status = Status.Active,
                    IsDeleted = false
                },
                new SectionItem
                {
                    Id = 8,
                    SectionId = 1,
                    ParentSectionItemId = 3, // Under "Ürünler"
                    TemplateId = 2,
                    Type = SectionItemType.Category,
                    SortOrder = 2,
                    Title = "Giyim",
                    Description = "Fashion category with seasonal collections",
                    AllowReorder = true,
                    AllowRemove = true,
                    IconClass = "fas fa-tshirt",
                    CreatedAt = new DateTime(2024, 10, 14, 10, 0, 0),
                    Status = Status.Active,
                    IsDeleted = false
                },
                new SectionItem
                {
                    Id = 9,
                    SectionId = 1,
                    ParentSectionItemId = 3, // Under "Ürünler"
                    TemplateId = 2,
                    Type = SectionItemType.Category,
                    SortOrder = 3,
                    Title = "Ev & Yaşam",
                    Description = "Home and lifestyle products",
                    AllowReorder = true,
                    AllowRemove = true,
                    IconClass = "fas fa-home",
                    CreatedAt = new DateTime(2024, 10, 14, 10, 0, 0),
                    Status = Status.Active,
                    IsDeleted = false
                },

                // ELECTRONICS SUBCATEGORIES - Level 3
                new SectionItem
                {
                    Id = 10,
                    SectionId = 1,
                    ParentSectionItemId = 7, // Under "Elektronik"
                    TemplateId = 2,
                    Type = SectionItemType.SubCategory,
                    SortOrder = 1,
                    Title = "Bilgisayarlar",
                    Description = "Desktop and laptop computers",
                    AllowReorder = true,
                    AllowRemove = true,
                    IconClass = "fas fa-desktop",
                    CreatedAt = new DateTime(2024, 10, 14, 10, 0, 0),
                    Status = Status.Active,
                    IsDeleted = false
                },
                new SectionItem
                {
                    Id = 11,
                    SectionId = 1,
                    ParentSectionItemId = 7, // Under "Elektronik"
                    TemplateId = 2,
                    Type = SectionItemType.SubCategory,
                    SortOrder = 2,
                    Title = "Telefonlar",
                    Description = "Smartphones and accessories",
                    AllowReorder = true,
                    AllowRemove = true,
                    IconClass = "fas fa-mobile-alt",
                    CreatedAt = new DateTime(2024, 10, 14, 10, 0, 0),
                    Status = Status.Active,
                    IsDeleted = false
                },
                new SectionItem
                {
                    Id = 12,
                    SectionId = 1,
                    ParentSectionItemId = 7, // Under "Elektronik"
                    TemplateId = 2,
                    Type = SectionItemType.SubCategory,
                    SortOrder = 3,
                    Title = "Ses & Görüntü",
                    Description = "Audio and video equipment",
                    AllowReorder = true,
                    AllowRemove = true,
                    IconClass = "fas fa-headphones",
                    CreatedAt = new DateTime(2024, 10, 14, 10, 0, 0),
                    Status = Status.Active,
                    IsDeleted = false
                },

                // FASHION SUBCATEGORIES - Level 3
                new SectionItem
                {
                    Id = 13,
                    SectionId = 1,
                    ParentSectionItemId = 8, // Under "Giyim"
                    TemplateId = 2,
                    Type = SectionItemType.SubCategory,
                    SortOrder = 1,
                    Title = "Kadın",
                    Description = "Women's fashion and accessories",
                    AllowReorder = true,
                    AllowRemove = true,
                    IconClass = "fas fa-female",
                    CreatedAt = new DateTime(2024, 10, 14, 10, 0, 0),
                    Status = Status.Active,
                    IsDeleted = false
                },
                new SectionItem
                {
                    Id = 14,
                    SectionId = 1,
                    ParentSectionItemId = 8, // Under "Giyim"
                    TemplateId = 2,
                    Type = SectionItemType.SubCategory,
                    SortOrder = 2,
                    Title = "Erkek",
                    Description = "Men's fashion and accessories",
                    AllowReorder = true,
                    AllowRemove = true,
                    IconClass = "fas fa-male",
                    CreatedAt = new DateTime(2024, 10, 14, 10, 0, 0),
                    Status = Status.Active,
                    IsDeleted = false
                },
                new SectionItem
                {
                    Id = 15,
                    SectionId = 1,
                    ParentSectionItemId = 8, // Under "Giyim"
                    TemplateId = 2,
                    Type = SectionItemType.SubCategory,
                    SortOrder = 3,
                    Title = "Çocuk",
                    Description = "Children's clothing and accessories",
                    AllowReorder = true,
                    AllowRemove = true,
                    IconClass = "fas fa-child",
                    CreatedAt = new DateTime(2024, 10, 14, 10, 0, 0),
                    Status = Status.Active,
                    IsDeleted = false
                },

                // SERVICES DROPDOWN - Level 2
                new SectionItem
                {
                    Id = 16,
                    SectionId = 1,
                    ParentSectionItemId = 4, // Under "Hizmetler"
                    TemplateId = 2,
                    Type = SectionItemType.Service,
                    SortOrder = 1,
                    Title = "Web Tasarım",
                    Description = "Professional web design services",
                    AllowReorder = true,
                    AllowRemove = true,
                    IconClass = "fas fa-paint-brush",
                    CreatedAt = new DateTime(2024, 10, 14, 10, 0, 0),
                    Status = Status.Active,
                    IsDeleted = false
                },
                new SectionItem
                {
                    Id = 17,
                    SectionId = 1,
                    ParentSectionItemId = 4, // Under "Hizmetler"
                    TemplateId = 2,
                    Type = SectionItemType.Service,
                    SortOrder = 2,
                    Title = "E-Ticaret",
                    Description = "E-commerce solutions and development",
                    AllowReorder = true,
                    AllowRemove = true,
                    IconClass = "fas fa-shopping-cart",
                    CreatedAt = new DateTime(2024, 10, 14, 10, 0, 0),
                    Status = Status.Active,
                    IsDeleted = false
                },
                new SectionItem
                {
                    Id = 18,
                    SectionId = 1,
                    ParentSectionItemId = 4, // Under "Hizmetler"
                    TemplateId = 2,
                    Type = SectionItemType.Service,
                    SortOrder = 3,
                    Title = "Dijital Pazarlama",
                    Description = "Digital marketing and SEO services",
                    AllowReorder = true,
                    AllowRemove = true,
                    IconClass = "fas fa-chart-line",
                    CreatedAt = new DateTime(2024, 10, 14, 10, 0, 0),
                    Status = Status.Active,
                    IsDeleted = false
                },
                new SectionItem
                {
                    Id = 19,
                    SectionId = 1,
                    ParentSectionItemId = 4, // Under "Hizmetler"
                    TemplateId = 2,
                    Type = SectionItemType.Service,
                    SortOrder = 4,
                    Title = "Teknik Destek",
                    Description = "24/7 technical support services",
                    AllowReorder = true,
                    AllowRemove = true,
                    IconClass = "fas fa-life-ring",
                    CreatedAt = new DateTime(2024, 10, 14, 10, 0, 0),
                    Status = Status.Active,
                    IsDeleted = false
                },

                // FEATURED MEGA MENU ITEM (with special styling)
                new SectionItem
                {
                    Id = 20,
                    SectionId = 1,
                    ParentSectionItemId = 3, // Under "Ürünler"
                    TemplateId = 2,
                    Type = SectionItemType.FeatureCard,
                    SortOrder = 4,
                    Title = "Özel Kampanya",
                    Description = "Limited time special offers and deals",
                    AllowReorder = true,
                    AllowRemove = true,
                    IconClass = "fas fa-fire",
                    CreatedAt = new DateTime(2024, 10, 14, 10, 0, 0),
                    Status = Status.Active,
                    IsDeleted = false
                },

                // ANA SAYFA NESTED MENU ITEMS - Level 2 (Under "Ana Sayfa" - ID: 2)
                new SectionItem
                {
                    Id = 21,
                    SectionId = 1,
                    ParentSectionItemId = 2, // Under "Ana Sayfa"
                    TemplateId = 2,
                    Type = SectionItemType.Menu,
                    SortOrder = 1,
                    Title = "Yeni Ürünler",
                    Description = "Latest product arrivals and new releases",
                    AllowReorder = true,
                    AllowRemove = true,
                    IconClass = "fas fa-star",
                    CreatedAt = new DateTime(2024, 10, 14, 10, 0, 0),
                    Status = Status.Active,
                    IsDeleted = false
                },
                new SectionItem
                {
                    Id = 22,
                    SectionId = 1,
                    ParentSectionItemId = 2, // Under "Ana Sayfa"
                    TemplateId = 2,
                    Type = SectionItemType.Menu,
                    SortOrder = 2,
                    Title = "Popüler Kategoriler",
                    Description = "Most popular product categories",
                    AllowReorder = true,
                    AllowRemove = true,
                    IconClass = "fas fa-fire",
                    CreatedAt = new DateTime(2024, 10, 14, 10, 0, 0),
                    Status = Status.Active,
                    IsDeleted = false
                },
                new SectionItem
                {
                    Id = 23,
                    SectionId = 1,
                    ParentSectionItemId = 2, // Under "Ana Sayfa"
                    TemplateId = 2,
                    Type = SectionItemType.Menu,
                    SortOrder = 3,
                    Title = "Kampanyalar",
                    Description = "Current promotions and special offers",
                    AllowReorder = true,
                    AllowRemove = true,
                    IconClass = "fas fa-percentage",
                    CreatedAt = new DateTime(2024, 10, 14, 10, 0, 0),
                    Status = Status.Active,
                    IsDeleted = false
                },
                new SectionItem
                {
                    Id = 24,
                    SectionId = 1,
                    ParentSectionItemId = 2, // Under "Ana Sayfa"
                    TemplateId = 2,
                    Type = SectionItemType.Menu,
                    SortOrder = 4,
                    Title = "Müşteri Yorumları",
                    Description = "Customer reviews and testimonials",
                    AllowReorder = true,
                    AllowRemove = true,
                    IconClass = "fas fa-comments",
                    CreatedAt = new DateTime(2024, 10, 14, 10, 0, 0),
                    Status = Status.Active,
                    IsDeleted = false
                },

                // POPÜLER KATEGORİLER NESTED ITEMS - Level 3 (Under "Popüler Kategoriler" - ID: 22)
                new SectionItem
                {
                    Id = 25,
                    SectionId = 1,
                    ParentSectionItemId = 22, // Under "Popüler Kategoriler"
                    TemplateId = 2,
                    Type = SectionItemType.CategoryLink,
                    SortOrder = 1,
                    Title = "En Çok Satan",
                    Description = "Best selling products across all categories",
                    AllowReorder = true,
                    AllowRemove = true,
                    IconClass = "fas fa-trophy",
                    CreatedAt = new DateTime(2024, 10, 14, 10, 0, 0),
                    Status = Status.Active,
                    IsDeleted = false
                },
                new SectionItem
                {
                    Id = 26,
                    SectionId = 1,
                    ParentSectionItemId = 22, // Under "Popüler Kategoriler"
                    TemplateId = 2,
                    Type = SectionItemType.CategoryLink,
                    SortOrder = 2,
                    Title = "Trend Ürünler",
                    Description = "Trending products and viral items",
                    AllowReorder = true,
                    AllowRemove = true,
                    IconClass = "fas fa-trending-up",
                    CreatedAt = new DateTime(2024, 10, 14, 10, 0, 0),
                    Status = Status.Active,
                    IsDeleted = false
                },
                new SectionItem
                {
                    Id = 27,
                    SectionId = 1,
                    ParentSectionItemId = 22, // Under "Popüler Kategoriler"
                    TemplateId = 2,
                    Type = SectionItemType.CategoryLink,
                    SortOrder = 3,
                    Title = "Editörün Seçimi",
                    Description = "Editor's choice and curated collections",
                    AllowReorder = true,
                    AllowRemove = true,
                    IconClass = "fas fa-heart",
                    CreatedAt = new DateTime(2024, 10, 14, 10, 0, 0),
                    Status = Status.Active,
                    IsDeleted = false
                },

                // KAMPANYALAR NESTED ITEMS - Level 3 (Under "Kampanyalar" - ID: 23)
                new SectionItem
                {
                    Id = 28,
                    SectionId = 1,
                    ParentSectionItemId = 23, // Under "Kampanyalar"
                    TemplateId = 2,
                    Type = SectionItemType.PromoLink,
                    SortOrder = 1,
                    Title = "Flash Sale",
                    Description = "Limited time flash sales with huge discounts",
                    AllowReorder = true,
                    AllowRemove = true,
                    IconClass = "fas fa-bolt",
                    CreatedAt = new DateTime(2024, 10, 14, 10, 0, 0),
                    Status = Status.Active,
                    IsDeleted = false
                },
                new SectionItem
                {
                    Id = 29,
                    SectionId = 1,
                    ParentSectionItemId = 23, // Under "Kampanyalar"
                    TemplateId = 2,
                    Type = SectionItemType.PromoLink,
                    SortOrder = 2,
                    Title = "Sezon İndirimi",
                    Description = "Seasonal discounts and clearance sales",
                    AllowReorder = true,
                    AllowRemove = true,
                    IconClass = "fas fa-snowflake",
                    CreatedAt = new DateTime(2024, 10, 14, 10, 0, 0),
                    Status = Status.Active,
                    IsDeleted = false
                },
                new SectionItem
                {
                    Id = 30,
                    SectionId = 1,
                    ParentSectionItemId = 23, // Under "Kampanyalar"
                    TemplateId = 2,
                    Type = SectionItemType.PromoLink,
                    SortOrder = 3,
                    Title = "Ücretsiz Kargo",
                    Description = "Free shipping campaigns and offers",
                    AllowReorder = true,
                    AllowRemove = true,
                    IconClass = "fas fa-shipping-fast",
                    CreatedAt = new DateTime(2024, 10, 14, 10, 0, 0),
                    Status = Status.Active,
                    IsDeleted = false
                }
            );
        }
    }
}
