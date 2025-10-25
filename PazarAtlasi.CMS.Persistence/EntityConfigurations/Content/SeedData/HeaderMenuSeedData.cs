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
                    Key = "menus.about.description",
                    Title = "Description",
                    Description = "About description section",
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
                    ParentSectionItemId = 1,
                    TemplateId = 2,
                    Type = SectionItemType.List,
                    SortOrder = 2,
                    Key = "menus.about.quickLinks",
                    Title = "Quick Links",
                    Description = "Quick navigation links",
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
                    ParentSectionItemId = 3,
                    TemplateId = 2,
                    Type = SectionItemType.Link,
                    SortOrder = 1,
                    Key = "menus.about.quickLinks.links.missionVision",
                    Title = "Mission & Vision",
                    IconClass = "fas fa-bullseye",
                    CreatedAt = baseDate,
                    Status = Status.Active,
                    IsDeleted = false
                },
                new SectionItem
                {
                    Id = 5,
                    ParentSectionItemId = 3,
                    TemplateId = 2,
                    Type = SectionItemType.Link,
                    SortOrder = 2,
                    Key = "menus.about.quickLinks.links.team",
                    Title = "Team",
                    IconClass = "fas fa-users",
                    CreatedAt = baseDate,
                    Status = Status.Active,
                    IsDeleted = false
                },
                new SectionItem
                {
                    Id = 6,
                    ParentSectionItemId = 3,
                    TemplateId = 2,
                    Type = SectionItemType.Link,
                    SortOrder = 3,
                    Key = "menus.about.quickLinks.links.careers",
                    Title = "Careers",
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
                    Key = "menus.about.quickLinks.links.press",
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
                    Key = "menus.about.features",
                    Title = "Features",
                    Description = "Company features",
                    AllowReorder = true,
                    AllowRemove = true,
                    IconClass = "fas fa-star",
                    CreatedAt = baseDate,
                    Status = Status.Active,
                    IsDeleted = false
                },

                // Feature Items
                new SectionItem
                {
                    Id = 9,
                    ParentSectionItemId = 8,
                    TemplateId = 2,
                    Type = SectionItemType.FeatureCard,
                    SortOrder = 1,
                    Key = "menus.about.features.items.experience",
                    Title = "Experience",
                    Description = "Years of experience",
                    IconClass = "fas fa-clock",
                    CreatedAt = baseDate,
                    Status = Status.Active,
                    IsDeleted = false
                },
                new SectionItem
                {
                    Id = 10,
                    ParentSectionItemId = 8,
                    TemplateId = 2,
                    Type = SectionItemType.FeatureCard,
                    SortOrder = 2,
                    Key = "menus.about.features.items.certifiedTeam",
                    Title = "Certified Team",
                    Description = "Professional certified team",
                    IconClass = "fas fa-certificate",
                    CreatedAt = baseDate,
                    Status = Status.Active,
                    IsDeleted = false
                },
                new SectionItem
                {
                    Id = 11,
                    ParentSectionItemId = 8,
                    TemplateId = 2,
                    Type = SectionItemType.FeatureCard,
                    SortOrder = 3,
                    Key = "menus.about.features.items.projects",
                    Title = "Projects",
                    Description = "Successful projects completed",
                    IconClass = "fas fa-project-diagram",
                    CreatedAt = baseDate,
                    Status = Status.Active,
                    IsDeleted = false
                },

                // ============================================
                // 2. SERVICES MENU - Service Tabs
                // ============================================
                new SectionItem
                {
                    Id = 12,
                    ParentSectionItemId = null,
                    TemplateId = 3,
                    Type = SectionItemType.Menu,
                    SortOrder = 2,
                    Key = "navbar.services",
                    Title = "Services",
                    Description = "Services menu with tabs",
                    AllowReorder = true,
                    AllowRemove = true,
                    IconClass = "fas fa-cogs",
                    CreatedAt = baseDate,
                    Status = Status.Active,
                    IsDeleted = false
                },

                // Service Tabs
                new SectionItem
                {
                    Id = 13,
                    ParentSectionItemId = 12,
                    TemplateId = 3,
                    Type = SectionItemType.Tab,
                    SortOrder = 1,
                    Key = "menus.services.tabs.managed",
                    Title = "Managed",
                    Description = "Managed services tab",
                    IconClass = "fas fa-server",
                    CreatedAt = baseDate,
                    Status = Status.Active,
                    IsDeleted = false
                },
                new SectionItem
                {
                    Id = 14,
                    ParentSectionItemId = 12,
                    TemplateId =3,
                    Type = SectionItemType.Tab,
                    SortOrder = 2,
                    Key = "menus.services.tabs.cloud",
                    Title = "Cloud",
                    Description = "Cloud services tab",
                    IconClass = "fas fa-cloud",
                    CreatedAt = baseDate,
                    Status = Status.Active,
                    IsDeleted = false
                },
                new SectionItem
                {
                    Id = 15,
                    ParentSectionItemId = 12,
                    TemplateId = 3,
                    Type = SectionItemType.Tab,
                    SortOrder = 3,
                    Key = "menus.services.tabs.security",
                    Title = "Security",
                    Description = "Security services tab",
                    IconClass = "fas fa-shield-alt",
                    CreatedAt = baseDate,
                    Status = Status.Active,
                    IsDeleted = false
                },
                new SectionItem
                {
                    Id = 16,
                    ParentSectionItemId = 12,
                    TemplateId = 3,
                    Type = SectionItemType.Tab,
                    SortOrder = 4,
                    Key = "menus.services.tabs.database",
                    Title = "Database",
                    Description = "Database services tab",
                    IconClass = "fas fa-database",
                    CreatedAt = baseDate,
                    Status = Status.Active,
                    IsDeleted = false
                },
                new SectionItem
                {
                    Id = 17,
                    ParentSectionItemId = 12,
                    TemplateId = 3,
                    Type = SectionItemType.Tab,
                    SortOrder = 5,
                    Key = "menus.services.tabs.monitoring",
                    Title = "Monitoring",
                    Description = "Monitoring services tab",
                    IconClass = "fas fa-chart-line",
                    CreatedAt = baseDate,
                    Status = Status.Active,
                    IsDeleted = false
                },
                new SectionItem
                {
                    Id = 18,
                    ParentSectionItemId = 12,
                    TemplateId = 3,
                    Type = SectionItemType.Tab,
                    SortOrder = 6,
                    Key = "menus.services.tabs.premium",
                    Title = "Premium",
                    Description = "Premium services tab",
                    IconClass = "fas fa-crown",
                    CreatedAt = baseDate,
                    Status = Status.Active,
                    IsDeleted = false
                },

                // Managed Services Content
                new SectionItem
                {
                    Id = 19,
                    ParentSectionItemId = 13,
                    TemplateId = 3,
                    Type = SectionItemType.ServiceCard,
                    SortOrder = 1,
                    Key = "menus.services.tabContent.managed.multiCloud",
                    Title = "Multi-Cloud",
                    Description = "Multi-cloud management services",
                    IconClass = "fas fa-cloud",
                    CreatedAt = baseDate,
                    Status = Status.Active,
                    IsDeleted = false
                },
                new SectionItem
                {
                    Id = 20,
                    ParentSectionItemId = 13,
                    TemplateId = 3,
                    Type = SectionItemType.ServiceCard,
                    SortOrder = 2,
                    Key = "menus.services.tabContent.managed.hybridCloud",
                    Title = "Hybrid Cloud",
                    Description = "Hybrid cloud solutions",
                    IconClass = "fas fa-sync",
                    CreatedAt = baseDate,
                    Status = Status.Active,
                    IsDeleted = false
                },
                new SectionItem
                {
                    Id = 21,
                    ParentSectionItemId = 13,
                    TemplateId = 3,
                    Type = SectionItemType.ServiceCard,
                    SortOrder = 3,
                    Key = "menus.services.tabContent.managed.monitoring",
                    Title = "Monitoring",
                    Description = "24/7 system monitoring",
                    IconClass = "fas fa-desktop",
                    CreatedAt = baseDate,
                    Status = Status.Active,
                    IsDeleted = false
                },
                new SectionItem
                {
                    Id = 22,
                    ParentSectionItemId = 13,
                    TemplateId = 3,
                    Type = SectionItemType.ServiceCard,
                    SortOrder = 4,
                    Key = "menus.services.tabContent.managed.container",
                    Title = "Container",
                    Description = "Container orchestration",
                    IconClass = "fas fa-cube",
                    CreatedAt = baseDate,
                    Status = Status.Active,
                    IsDeleted = false
                },

                // ============================================
                // 3. SOLUTIONS MENU - Categorized
                // ============================================
                new SectionItem
                {
                    Id = 23,
                    ParentSectionItemId = null,
                    TemplateId = 4,
                    Type = SectionItemType.Menu,
                    SortOrder = 3,
                    Key = "navbar.solutions",
                    Title = "Solutions",
                    Description = "Solutions menu with categories",
                    AllowReorder = true,
                    AllowRemove = true,
                    IconClass = "fas fa-puzzle-piece",
                    CreatedAt = baseDate,
                    Status = Status.Active,
                    IsDeleted = false
                },

                // Solution Categories
                new SectionItem
                {
                    Id = 24,
                    ParentSectionItemId = 23,
                    TemplateId = 4,
                    Type = SectionItemType.Category,
                    SortOrder = 1,
                    Key = "menus.solutions.categories.software",
                    Title = "Software",
                    Description = "Software solutions",
                    IconClass = "fas fa-code",
                    CreatedAt = baseDate,
                    Status = Status.Active,
                    IsDeleted = false
                },
                new SectionItem
                {
                    Id = 25,
                    ParentSectionItemId = 23,
                    TemplateId = 4,
                    Type = SectionItemType.Category,
                    SortOrder = 2,
                    Key = "menus.solutions.categories.devops",
                    Title = "DevOps",
                    Description = "DevOps solutions",
                    IconClass = "fas fa-server",
                    CreatedAt = baseDate,
                    Status = Status.Active,
                    IsDeleted = false
                },
                new SectionItem
                {
                    Id = 26,
                    ParentSectionItemId = 23,
                    TemplateId = 4,
                    Type = SectionItemType.Category,
                    SortOrder = 3,
                    Key = "menus.solutions.categories.hosting",
                    Title = "Hosting",
                    Description = "Hosting solutions",
                    IconClass = "fas fa-database",
                    CreatedAt = baseDate,
                    Status = Status.Active,
                    IsDeleted = false
                },
                new SectionItem
                {
                    Id = 27,
                    ParentSectionItemId = 23,
                    TemplateId = 4,
                    Type = SectionItemType.Category,
                    SortOrder = 4,
                    Key = "menus.solutions.categories.cloud",
                    Title = "Cloud",
                    Description = "Cloud solutions",
                    IconClass = "fas fa-cloud",
                    CreatedAt = baseDate,
                    Status = Status.Active,
                    IsDeleted = false
                },
                new SectionItem
                {
                    Id = 28,
                    ParentSectionItemId = 23,
                    TemplateId = 4,
                    Type = SectionItemType.Category,
                    SortOrder = 5,
                    Key = "menus.solutions.categories.security",
                    Title = "Security",
                    Description = "Security solutions",
                    IconClass = "fas fa-shield-alt",
                    CreatedAt = baseDate,
                    Status = Status.Active,
                    IsDeleted = false
                },

                // Software Solutions
                new SectionItem
                {
                    Id = 29,
                    ParentSectionItemId = 24,
                    TemplateId = 4,
                    Type = SectionItemType.ServiceCard,
                    SortOrder = 1,
                    Key = "menus.solutions.categoryContent.software.items.custom",
                    Title = "Custom Software",
                    Description = "Tailored software solutions",
                    IconClass = "fas fa-wrench",
                    CreatedAt = baseDate,
                    Status = Status.Active,
                    IsDeleted = false
                },
                new SectionItem
                {
                    Id = 30,
                    ParentSectionItemId = 24,
                    TemplateId = 4,
                    Type = SectionItemType.ServiceCard,
                    SortOrder = 2,
                    Key = "menus.solutions.categoryContent.software.items.web",
                    Title = "Web Applications",
                    Description = "Modern web applications",
                    IconClass = "fas fa-globe",
                    CreatedAt = baseDate,
                    Status = Status.Active,
                    IsDeleted = false
                },
                new SectionItem
                {
                    Id = 31,
                    ParentSectionItemId = 24,
                    TemplateId = 4,
                    Type = SectionItemType.ServiceCard,
                    SortOrder = 3,
                    Key = "menus.solutions.categoryContent.software.items.mobile",
                    Title = "Mobile Apps",
                    Description = "iOS and Android applications",
                    IconClass = "fas fa-mobile-alt",
                    CreatedAt = baseDate,
                    Status = Status.Active,
                    IsDeleted = false
                },
                new SectionItem
                {
                    Id = 32,
                    ParentSectionItemId = 24,
                    TemplateId = 4,
                    Type = SectionItemType.ServiceCard,
                    SortOrder = 4,
                    Key = "menus.solutions.categoryContent.software.items.api",
                    Title = "API Development",
                    Description = "RESTful API services",
                    IconClass = "fas fa-plug",
                    CreatedAt = baseDate,
                    Status = Status.Active,
                    IsDeleted = false
                },

                // ============================================
                // 4. BLOG MENU - Mega Menu
                // ============================================
                new SectionItem
                {
                    Id = 33,
                    ParentSectionItemId = null,
                    TemplateId = 2,
                    Type = SectionItemType.Menu,
                    SortOrder = 4,
                    Key = "navbar.blog",
                    Title = "Blog",
                    Description = "Blog mega menu",
                    AllowReorder = true,
                    AllowRemove = true,
                    IconClass = "fas fa-blog",
                    CreatedAt = baseDate,
                    Status = Status.Active,
                    IsDeleted = false
                },

                // Blog Description
                new SectionItem
                {
                    Id = 34,
                    ParentSectionItemId = 33,
                    TemplateId = 2,
                    Type = SectionItemType.Text,
                    SortOrder = 1,
                    Key = "menus.blog.description",
                    Title = "Blog Description",
                    Description = "Blog section description",
                    AllowReorder = true,
                    AllowRemove = true,
                    IconClass = "fas fa-newspaper",
                    CreatedAt = baseDate,
                    Status = Status.Active,
                    IsDeleted = false
                },

                // Blog Categories
                new SectionItem
                {
                    Id = 35,
                    ParentSectionItemId = 33,
                    TemplateId = 2,
                    Type = SectionItemType.List,
                    SortOrder = 2,
                    Key = "menus.blog.categories",
                    Title = "Categories",
                    Description = "Blog categories",
                    AllowReorder = true,
                    AllowRemove = true,
                    IconClass = "fas fa-tags",
                    CreatedAt = baseDate,
                    Status = Status.Active,
                    IsDeleted = false
                },

                // Blog Category Links
                new SectionItem
                {
                    Id = 36,
                    ParentSectionItemId = 35,
                    TemplateId = 2,
                    Type = SectionItemType.Link,
                    SortOrder = 1,
                    Key = "menus.blog.categories.links.cloudTrends",
                    Title = "Cloud Trends",
                    IconClass = "fas fa-cloud",
                    CreatedAt = baseDate,
                    Status = Status.Active,
                    IsDeleted = false
                },
                new SectionItem
                {
                    Id = 37,
                    ParentSectionItemId = 35,
                    TemplateId = 2,
                    Type = SectionItemType.Link,
                    SortOrder = 2,
                    Key = "menus.blog.categories.links.devopsPractices",
                    Title = "DevOps Practices",
                    IconClass = "fas fa-code-branch",
                    CreatedAt = baseDate,
                    Status = Status.Active,
                    IsDeleted = false
                },
                new SectionItem
                {
                    Id = 38,
                    ParentSectionItemId = 35,
                    TemplateId = 2,
                    Type = SectionItemType.Link,
                    SortOrder = 3,
                    Key = "menus.blog.categories.links.softwareInnovation",
                    Title = "Software Innovation",
                    IconClass = "fas fa-lightbulb",
                    CreatedAt = baseDate,
                    Status = Status.Active,
                    IsDeleted = false
                },
                new SectionItem
                {
                    Id = 39,
                    ParentSectionItemId = 35,
                    TemplateId = 2,
                    Type = SectionItemType.Link,
                    SortOrder = 4,
                    Key = "menus.blog.categories.links.techLeadership",
                    Title = "Tech Leadership",
                    IconClass = "fas fa-user-tie",
                    CreatedAt = baseDate,
                    Status = Status.Active,
                    IsDeleted = false
                },

                // Featured Posts
                new SectionItem
                {
                    Id = 40,
                    ParentSectionItemId = 33,
                    TemplateId = 2,
                    Type = SectionItemType.List,
                    SortOrder = 3,
                    Key = "menus.blog.featuredPosts",
                    Title = "Featured Posts",
                    Description = "Featured blog posts",
                    AllowReorder = true,
                    AllowRemove = true,
                    IconClass = "fas fa-star",
                    CreatedAt = baseDate,
                    Status = Status.Active,
                    IsDeleted = false
                },

                // Featured Post Items
                new SectionItem
                {
                    Id = 41,
                    ParentSectionItemId = 40,
                    TemplateId = 2,
                    Type = SectionItemType.BlogPost,
                    SortOrder = 1,
                    Key = "menus.blog.featuredPosts.posts.kubernetes",
                    Title = "Kubernetes Best Practices",
                    Description = "Learn about Kubernetes best practices",
                    IconClass = "fas fa-cube",
                    CreatedAt = baseDate,
                    Status = Status.Active,
                    IsDeleted = false
                },
                new SectionItem
                {
                    Id = 42,
                    ParentSectionItemId = 40,
                    TemplateId = 2,
                    Type = SectionItemType.BlogPost,
                    SortOrder = 2,
                    Key = "menus.blog.featuredPosts.posts.azure",
                    Title = "Azure Migration Guide",
                    Description = "Complete guide to Azure migration",
                    IconClass = "fas fa-cloud",
                    CreatedAt = baseDate,
                    Status = Status.Active,
                    IsDeleted = false
                },

                // ============================================
                // 5. SIMPLE LINK MENUS
                // ============================================
                new SectionItem
                {
                    Id = 43,
                    ParentSectionItemId = null,
                    TemplateId = 2,
                    Type = SectionItemType.Link,
                    SortOrder = 5,
                    Key = "navbar.careers",
                    Title = "Careers",
                    Description = "Career opportunities",
                    IconClass = "fas fa-briefcase",
                    CreatedAt = baseDate,
                    Status = Status.Active,
                    IsDeleted = false
                },
                new SectionItem
                {
                    Id = 44,
                    ParentSectionItemId = null,
                    TemplateId = 2,
                    Type = SectionItemType.Link,
                    SortOrder = 6,
                    Key = "navbar.datacenter",
                    Title = "Data Center",
                    Description = "System status and data center",
                    IconClass = "fas fa-server",
                    CreatedAt = baseDate,
                    Status = Status.Active,
                    IsDeleted = false
                },
                new SectionItem
                {
                    Id = 45,
                    ParentSectionItemId = null,
                    TemplateId = 2,
                    Type = SectionItemType.Link,
                    SortOrder = 7,
                    Key = "navbar.references",
                    Title = "References",
                    Description = "Client references",
                    IconClass = "fas fa-handshake",
                    CreatedAt = baseDate,
                    Status = Status.Active,
                    IsDeleted = false
                },

                // ============================================
                // 6. CONTACT MENU - Dropdown
                // ============================================
                new SectionItem
                {
                    Id = 46,
                    ParentSectionItemId = null,
                    TemplateId = 2,
                    Type = SectionItemType.Dropdown,
                    SortOrder = 8,
                    Key = "navbar.contact",
                    Title = "Contact",
                    Description = "Contact information dropdown",
                    AllowReorder = true,
                    AllowRemove = true,
                    IconClass = "fas fa-envelope",
                    CreatedAt = baseDate,
                    Status = Status.Active,
                    IsDeleted = false
                },

                // Contact Info
                new SectionItem
                {
                    Id = 47,
                    ParentSectionItemId = 46,
                    TemplateId = 2,
                    Type = SectionItemType.ContactInfo,
                    SortOrder = 1,
                    Key = "menus.contact.contactInfo.email",
                    Title = "Email",
                    Description = "Contact email information",
                    IconClass = "fas fa-envelope",
                    CreatedAt = baseDate,
                    Status = Status.Active,
                    IsDeleted = false
                },
                new SectionItem
                {
                    Id = 48,
                    ParentSectionItemId = 46,
                    TemplateId = 2,
                    Type = SectionItemType.ContactInfo,
                    SortOrder = 2,
                    Key = "menus.contact.contactInfo.address",
                    Title = "Address",
                    Description = "Office address information",
                    IconClass = "fas fa-map-marker-alt",
                    CreatedAt = baseDate,
                    Status = Status.Active,
                    IsDeleted = false
                }
            );
        }
    }
}
