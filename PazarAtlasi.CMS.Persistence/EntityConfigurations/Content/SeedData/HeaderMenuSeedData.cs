using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PazarAtlasi.CMS.Domain.Common;
using PazarAtlasi.CMS.Domain.Entities.Content;

namespace PazarAtlasi.CMS.Persistence.EntityConfigurations.Content.SeedData
{
    public static class HeaderMenuSeedData
    {
        public static void SeedHeaderMenuItems(this EntityTypeBuilder<SectionItem> builder)
        {
            var baseDate = new DateTime(2024, 10, 25, 10, 0, 0);

            builder.HasData(
                // ============================================
                // 1. ABOUT MENU - Mega Menu
                // ============================================
                new SectionItem
                {
                    Id = 1,
                    ParentSectionItemId = null,
                    TemplateId = 2,
                    Type = SectionItemType.Menu,
                    SortOrder = 1,
                    Key = "navbar.about",
                    Title = "About",
                    Description = "About us mega menu",
                    AllowReorder = true,
                    AllowRemove = true,
                    IconClass = "fas fa-info-circle",
                    CreatedAt = baseDate,
                    Status = Status.Active,
                    IsDeleted = false
                },

                // About - Description Section
                new SectionItem
                {
                    Id = 2,
                    ParentSectionItemId = 1,
                    TemplateId = 2,
                    Type = SectionItemType.Text,
                    SortOrder = 1,
                    Key = "navbar.content",
                    Title = "content",
                    Description = "Content",
                    AllowReorder = true,
                    AllowRemove = true,
                    IconClass = "fas fa-building",
                    CreatedAt = baseDate,
                    Status = Status.Active,
                    IsDeleted = false
                },

                // About - Quick Links Section
                new SectionItem
                {
                    Id = 3,
                    ParentSectionItemId = 2,
                    TemplateId = 2,
                    Type = SectionItemType.List,
                    SortOrder = 2,
                    Key = "navbar.description",
                    Title = "description",
                    Description = "description",
                    AllowReorder = true,
                    AllowRemove = true,
                    IconClass = "fas fa-link",
                    CreatedAt = baseDate,
                    Status = Status.Active,
                    IsDeleted = false
                },

                // Quick Links Items
                new SectionItem
                {
                    Id = 4,
                    ParentSectionItemId = 2,
                    TemplateId = 2,
                    Type = SectionItemType.Link,
                    SortOrder = 1,
                    Key = "navbar.quicklinks",
                    Title = "quick links",
                    IconClass = "fas fa-bullseye",
                    CreatedAt = baseDate,
                    Status = Status.Active,
                    IsDeleted = false
                },
                new SectionItem
                {
                    Id = 5,
                    ParentSectionItemId = 4,
                    TemplateId = 2,
                    Type = SectionItemType.Link,
                    SortOrder = 2,
                    Title = "Team",
                    IconClass = "fas fa-users",
                    CreatedAt = baseDate,
                    Status = Status.Active,
                    IsDeleted = false
                },
                new SectionItem
                {
                    Id = 6,
                    ParentSectionItemId = 2,
                    TemplateId = 2,
                    Type = SectionItemType.Link,
                    SortOrder = 3,
                    Title = "features",
                    IconClass = "fas fa-briefcase",
                    CreatedAt = baseDate,
                    Status = Status.Active,
                    IsDeleted = false
                },
                new SectionItem
                {
                    Id = 7,
                    ParentSectionItemId = 3,
                    TemplateId = 2,
                    Type = SectionItemType.Link,
                    SortOrder = 4,
                    Title = "Press",
                    IconClass = "fas fa-newspaper",
                    CreatedAt = baseDate,
                    Status = Status.Active,
                    IsDeleted = false
                },

                // About - Features Section
                new SectionItem
                {
                    Id = 8,
                    ParentSectionItemId = 1,
                    TemplateId = 2,
                    Type = SectionItemType.FeatureCard,
                    SortOrder = 3,
                    Title = "Features",
                    Description = "Company features",
                    AllowReorder = true,
                    AllowRemove = true,
                    IconClass = "fas fa-star",
                    CreatedAt = baseDate,
                    Status = Status.Active,
                    IsDeleted = false
                }
            );
        }
    }
}
