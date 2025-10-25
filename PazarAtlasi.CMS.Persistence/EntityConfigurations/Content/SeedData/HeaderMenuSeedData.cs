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
                },

                // Features Items
                new SectionItem { Id = 9, ParentSectionItemId = 8, TemplateId = 2, Type = SectionItemType.FeatureCard, SortOrder = 1, Title = "Experience", Description = "Years of experience", IconClass = "fas fa-calendar-alt", CreatedAt = baseDate, Status = Status.Active, IsDeleted = false },
                new SectionItem { Id = 10, ParentSectionItemId = 8, TemplateId = 2, Type = SectionItemType.FeatureCard, SortOrder = 2, Title = "Certified Team", Description = "Professional team", IconClass = "fas fa-certificate", CreatedAt = baseDate, Status = Status.Active, IsDeleted = false },
                new SectionItem { Id = 11, ParentSectionItemId = 8, TemplateId = 2, Type = SectionItemType.FeatureCard, SortOrder = 3, Title = "Projects", Description = "Successful projects", IconClass = "fas fa-project-diagram", CreatedAt = baseDate, Status = Status.Active, IsDeleted = false }
            );
        }

        public static void SeedServicesMenu(this EntityTypeBuilder<SectionItem> builder)
        {
            var baseDate = new DateTime(2024, 10, 25, 10, 0, 0);

            builder.HasData(
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
                new SectionItem { Id = 13, ParentSectionItemId = 12, TemplateId = 3, Type = SectionItemType.Service, SortOrder = 1, Title = "Managed", Description = "Managed services", IconClass = "fas fa-server", CreatedAt = baseDate, Status = Status.Active, IsDeleted = false },
                new SectionItem { Id = 14, ParentSectionItemId = 12, TemplateId = 3, Type = SectionItemType.Service, SortOrder = 2, Title = "Cloud", Description = "Cloud services", IconClass = "fas fa-cloud", CreatedAt = baseDate, Status = Status.Active, IsDeleted = false },
                new SectionItem { Id = 15, ParentSectionItemId = 12, TemplateId = 3, Type = SectionItemType.Service, SortOrder = 3, Title = "Security", Description = "Security services", IconClass = "fas fa-shield-alt", CreatedAt = baseDate, Status = Status.Active, IsDeleted = false },
                new SectionItem { Id = 16, ParentSectionItemId = 12, TemplateId = 3, Type = SectionItemType.Service, SortOrder = 4, Title = "Database", Description = "Database services", IconClass = "fas fa-database", CreatedAt = baseDate, Status = Status.Active, IsDeleted = false },
                new SectionItem { Id = 17, ParentSectionItemId = 12, TemplateId = 3, Type = SectionItemType.Service, SortOrder = 5, Title = "Monitoring", Description = "Monitoring services", IconClass = "fas fa-chart-line", CreatedAt = baseDate, Status = Status.Active, IsDeleted = false },
                new SectionItem { Id = 18, ParentSectionItemId = 12, TemplateId = 3, Type = SectionItemType.Service, SortOrder = 6, Title = "Premium", Description = "Premium services", IconClass = "fas fa-crown", CreatedAt = baseDate, Status = Status.Active, IsDeleted = false },

                // Managed Services Content
                new SectionItem { Id = 19, ParentSectionItemId = 13, TemplateId = 2, Type = SectionItemType.Service, SortOrder = 1, Title = "Multi-Cloud", Description = "Multi-cloud management", IconClass = "fas fa-cloud", CreatedAt = baseDate, Status = Status.Active, IsDeleted = false },
                new SectionItem { Id = 20, ParentSectionItemId = 13, TemplateId = 2, Type = SectionItemType.Service, SortOrder = 2, Title = "Hybrid Cloud", Description = "Hybrid cloud solutions", IconClass = "fas fa-sync-alt", CreatedAt = baseDate, Status = Status.Active, IsDeleted = false },
                new SectionItem { Id = 21, ParentSectionItemId = 13, TemplateId = 2, Type = SectionItemType.Service, SortOrder = 3, Title = "Monitoring", Description = "24/7 monitoring", IconClass = "fas fa-desktop", CreatedAt = baseDate, Status = Status.Active, IsDeleted = false },
                new SectionItem { Id = 22, ParentSectionItemId = 13, TemplateId = 2, Type = SectionItemType.Service, SortOrder = 4, Title = "Container", Description = "Container orchestration", IconClass = "fas fa-cube", CreatedAt = baseDate, Status = Status.Active, IsDeleted = false },

                // Cloud Services Content
                new SectionItem { Id = 23, ParentSectionItemId = 14, TemplateId = 2, Type = SectionItemType.Service, SortOrder = 1, Title = "Public Cloud", Description = "Public cloud infrastructure", IconClass = "fas fa-globe", CreatedAt = baseDate, Status = Status.Active, IsDeleted = false },
                new SectionItem { Id = 24, ParentSectionItemId = 14, TemplateId = 2, Type = SectionItemType.Service, SortOrder = 2, Title = "Migration", Description = "Cloud migration", IconClass = "fas fa-sync-alt", CreatedAt = baseDate, Status = Status.Active, IsDeleted = false },
                new SectionItem { Id = 25, ParentSectionItemId = 14, TemplateId = 2, Type = SectionItemType.Service, SortOrder = 3, Title = "Optimization", Description = "Cost optimization", IconClass = "fas fa-chart-pie", CreatedAt = baseDate, Status = Status.Active, IsDeleted = false },
                new SectionItem { Id = 26, ParentSectionItemId = 14, TemplateId = 2, Type = SectionItemType.Service, SortOrder = 4, Title = "Consulting", Description = "Cloud consulting", IconClass = "fas fa-cloud", CreatedAt = baseDate, Status = Status.Active, IsDeleted = false },

                // Security Services Content
                new SectionItem { Id = 27, ParentSectionItemId = 15, TemplateId = 2, Type = SectionItemType.Service, SortOrder = 1, Title = "Cloud Security", Description = "Cloud security solutions", IconClass = "fas fa-shield-alt", CreatedAt = baseDate, Status = Status.Active, IsDeleted = false },
                new SectionItem { Id = 28, ParentSectionItemId = 15, TemplateId = 2, Type = SectionItemType.Service, SortOrder = 2, Title = "Zero Trust", Description = "Zero trust architecture", IconClass = "fas fa-shield-alt", CreatedAt = baseDate, Status = Status.Active, IsDeleted = false },
                new SectionItem { Id = 29, ParentSectionItemId = 15, TemplateId = 2, Type = SectionItemType.Service, SortOrder = 3, Title = "Managed Security", Description = "Managed security services", IconClass = "fas fa-shield-alt", CreatedAt = baseDate, Status = Status.Active, IsDeleted = false },
                new SectionItem { Id = 30, ParentSectionItemId = 15, TemplateId = 2, Type = SectionItemType.Service, SortOrder = 4, Title = "Data Protection", Description = "Data protection services", IconClass = "fas fa-lock", CreatedAt = baseDate, Status = Status.Active, IsDeleted = false },

                // Database Services Content
                new SectionItem { Id = 31, ParentSectionItemId = 16, TemplateId = 2, Type = SectionItemType.Service, SortOrder = 1, Title = "Database Management", Description = "Database management", IconClass = "fas fa-database", CreatedAt = baseDate, Status = Status.Active, IsDeleted = false },
                new SectionItem { Id = 32, ParentSectionItemId = 16, TemplateId = 2, Type = SectionItemType.Service, SortOrder = 2, Title = "Data Migration", Description = "Data migration services", IconClass = "fas fa-sync-alt", CreatedAt = baseDate, Status = Status.Active, IsDeleted = false },
                new SectionItem { Id = 33, ParentSectionItemId = 16, TemplateId = 2, Type = SectionItemType.Service, SortOrder = 3, Title = "Performance", Description = "Performance optimization", IconClass = "fas fa-tachometer-alt", CreatedAt = baseDate, Status = Status.Active, IsDeleted = false },
                new SectionItem { Id = 34, ParentSectionItemId = 16, TemplateId = 2, Type = SectionItemType.Service, SortOrder = 4, Title = "Backup & Recovery", Description = "Backup and recovery", IconClass = "fas fa-save", CreatedAt = baseDate, Status = Status.Active, IsDeleted = false },

                // Monitoring Services Content
                new SectionItem { Id = 35, ParentSectionItemId = 17, TemplateId = 2, Type = SectionItemType.Service, SortOrder = 1, Title = "Performance Monitoring", Description = "Performance monitoring", IconClass = "fas fa-chart-line", CreatedAt = baseDate, Status = Status.Active, IsDeleted = false },
                new SectionItem { Id = 36, ParentSectionItemId = 17, TemplateId = 2, Type = SectionItemType.Service, SortOrder = 2, Title = "System Health", Description = "System health monitoring", IconClass = "fas fa-heartbeat", CreatedAt = baseDate, Status = Status.Active, IsDeleted = false },
                new SectionItem { Id = 37, ParentSectionItemId = 17, TemplateId = 2, Type = SectionItemType.Service, SortOrder = 3, Title = "Cost Optimization", Description = "Cost optimization", IconClass = "fas fa-chart-pie", CreatedAt = baseDate, Status = Status.Active, IsDeleted = false },
                new SectionItem { Id = 38, ParentSectionItemId = 17, TemplateId = 2, Type = SectionItemType.Service, SortOrder = 4, Title = "Capacity Planning", Description = "Capacity planning", IconClass = "fas fa-chart-area", CreatedAt = baseDate, Status = Status.Active, IsDeleted = false },

                // Premium Services Content
                new SectionItem { Id = 39, ParentSectionItemId = 18, TemplateId = 2, Type = SectionItemType.Service, SortOrder = 1, Title = "Premium Consulting", Description = "Premium consulting", IconClass = "fas fa-crown", CreatedAt = baseDate, Status = Status.Active, IsDeleted = false },
                new SectionItem { Id = 40, ParentSectionItemId = 18, TemplateId = 2, Type = SectionItemType.Service, SortOrder = 2, Title = "CTO as Service", Description = "CTO as a service", IconClass = "fas fa-user-tie", CreatedAt = baseDate, Status = Status.Active, IsDeleted = false },
                new SectionItem { Id = 41, ParentSectionItemId = 18, TemplateId = 2, Type = SectionItemType.Service, SortOrder = 3, Title = "Digital Transformation", Description = "Digital transformation", IconClass = "fas fa-sync-alt", CreatedAt = baseDate, Status = Status.Active, IsDeleted = false },
                new SectionItem { Id = 42, ParentSectionItemId = 18, TemplateId = 2, Type = SectionItemType.Service, SortOrder = 4, Title = "Strategic Planning", Description = "Strategic planning", IconClass = "fas fa-chess", CreatedAt = baseDate, Status = Status.Active, IsDeleted = false }
            );
        }

        public static void SeedSolutionsMenu(this EntityTypeBuilder<SectionItem> builder)
        {
            var baseDate = new DateTime(2024, 10, 25, 10, 0, 0);

            builder.HasData(
                // ============================================
                // 3. SOLUTIONS MENU - Categorized
                // ============================================
                new SectionItem
                {
                    Id = 43,
                    ParentSectionItemId = null,
                    TemplateId = 4,
                    Type = SectionItemType.Menu,
                    SortOrder = 3,
                    Title = "Solutions",
                    Description = "Solutions menu",
                    AllowReorder = true,
                    AllowRemove = true,
                    IconClass = "fas fa-lightbulb",
                    CreatedAt = baseDate,
                    Status = Status.Active,
                    IsDeleted = false
                },

                // Solution Categories
                new SectionItem { Id = 44, ParentSectionItemId = 43, TemplateId = 4, Type = SectionItemType.Category, SortOrder = 1, Title = "Software", Description = "Software solutions", IconClass = "fas fa-code", CreatedAt = baseDate, Status = Status.Active, IsDeleted = false },
                new SectionItem { Id = 45, ParentSectionItemId = 43, TemplateId = 4, Type = SectionItemType.Category, SortOrder = 2, Title = "DevOps", Description = "DevOps solutions", IconClass = "fas fa-server", CreatedAt = baseDate, Status = Status.Active, IsDeleted = false },
                new SectionItem { Id = 46, ParentSectionItemId = 43, TemplateId = 4, Type = SectionItemType.Category, SortOrder = 3, Title = "Hosting", Description = "Hosting solutions", IconClass = "fas fa-database", CreatedAt = baseDate, Status = Status.Active, IsDeleted = false },
                new SectionItem { Id = 47, ParentSectionItemId = 43, TemplateId = 4, Type = SectionItemType.Category, SortOrder = 4, Title = "Cloud", Description = "Cloud solutions", IconClass = "fas fa-cloud", CreatedAt = baseDate, Status = Status.Active, IsDeleted = false },
                new SectionItem { Id = 48, ParentSectionItemId = 43, TemplateId = 4, Type = SectionItemType.Category, SortOrder = 5, Title = "Security", Description = "Security solutions", IconClass = "fas fa-shield-alt", CreatedAt = baseDate, Status = Status.Active, IsDeleted = false },

                // Software Solutions
                new SectionItem { Id = 49, ParentSectionItemId = 44, TemplateId = 2, Type = SectionItemType.Service, SortOrder = 1, Title = "Custom Development", Description = "Custom software development", IconClass = "fas fa-laptop-code", CreatedAt = baseDate, Status = Status.Active, IsDeleted = false },
                new SectionItem { Id = 50, ParentSectionItemId = 44, TemplateId = 2, Type = SectionItemType.Service, SortOrder = 2, Title = "Web Applications", Description = "Web application development", IconClass = "fas fa-globe", CreatedAt = baseDate, Status = Status.Active, IsDeleted = false },
                new SectionItem { Id = 51, ParentSectionItemId = 44, TemplateId = 2, Type = SectionItemType.Service, SortOrder = 3, Title = "Mobile Applications", Description = "Mobile app development", IconClass = "fas fa-mobile-alt", CreatedAt = baseDate, Status = Status.Active, IsDeleted = false },
                new SectionItem { Id = 52, ParentSectionItemId = 44, TemplateId = 2, Type = SectionItemType.Service, SortOrder = 4, Title = "API Development", Description = "API development services", IconClass = "fas fa-plug", CreatedAt = baseDate, Status = Status.Active, IsDeleted = false },

                // DevOps Solutions
                new SectionItem { Id = 53, ParentSectionItemId = 45, TemplateId = 2, Type = SectionItemType.Service, SortOrder = 1, Title = "CI/CD", Description = "CI/CD pipelines", IconClass = "fas fa-code-branch", CreatedAt = baseDate, Status = Status.Active, IsDeleted = false },
                new SectionItem { Id = 54, ParentSectionItemId = 45, TemplateId = 2, Type = SectionItemType.Service, SortOrder = 2, Title = "Kubernetes", Description = "Kubernetes management", IconClass = "fas fa-dharmachakra", CreatedAt = baseDate, Status = Status.Active, IsDeleted = false },
                new SectionItem { Id = 55, ParentSectionItemId = 45, TemplateId = 2, Type = SectionItemType.Service, SortOrder = 3, Title = "Infrastructure as Code", Description = "IaC solutions", IconClass = "fas fa-file-code", CreatedAt = baseDate, Status = Status.Active, IsDeleted = false },
                new SectionItem { Id = 56, ParentSectionItemId = 45, TemplateId = 2, Type = SectionItemType.Service, SortOrder = 4, Title = "Monitoring", Description = "DevOps monitoring", IconClass = "fas fa-chart-line", CreatedAt = baseDate, Status = Status.Active, IsDeleted = false },

                // Hosting Solutions
                new SectionItem { Id = 57, ParentSectionItemId = 46, TemplateId = 2, Type = SectionItemType.Service, SortOrder = 1, Title = "VPS Hosting", Description = "VPS hosting services", IconClass = "fas fa-server", CreatedAt = baseDate, Status = Status.Active, IsDeleted = false },
                new SectionItem { Id = 58, ParentSectionItemId = 46, TemplateId = 2, Type = SectionItemType.Service, SortOrder = 2, Title = "Database Hosting", Description = "Database hosting", IconClass = "fas fa-database", CreatedAt = baseDate, Status = Status.Active, IsDeleted = false },
                new SectionItem { Id = 59, ParentSectionItemId = 46, TemplateId = 2, Type = SectionItemType.Service, SortOrder = 3, Title = "Disaster Recovery", Description = "Disaster recovery", IconClass = "fas fa-life-ring", CreatedAt = baseDate, Status = Status.Active, IsDeleted = false },
                new SectionItem { Id = 60, ParentSectionItemId = 46, TemplateId = 2, Type = SectionItemType.Service, SortOrder = 4, Title = "Web Hosting", Description = "Web hosting services", IconClass = "fas fa-globe", CreatedAt = baseDate, Status = Status.Active, IsDeleted = false },

                // Cloud Solutions
                new SectionItem { Id = 61, ParentSectionItemId = 47, TemplateId = 2, Type = SectionItemType.Service, SortOrder = 1, Title = "Azure", Description = "Microsoft Azure solutions", IconClass = "fab fa-microsoft", CreatedAt = baseDate, Status = Status.Active, IsDeleted = false },
                new SectionItem { Id = 62, ParentSectionItemId = 47, TemplateId = 2, Type = SectionItemType.Service, SortOrder = 2, Title = "AWS", Description = "Amazon Web Services", IconClass = "fab fa-aws", CreatedAt = baseDate, Status = Status.Active, IsDeleted = false },
                new SectionItem { Id = 63, ParentSectionItemId = 47, TemplateId = 2, Type = SectionItemType.Service, SortOrder = 3, Title = "Migration", Description = "Cloud migration", IconClass = "fas fa-sync-alt", CreatedAt = baseDate, Status = Status.Active, IsDeleted = false },
                new SectionItem { Id = 64, ParentSectionItemId = 47, TemplateId = 2, Type = SectionItemType.Service, SortOrder = 4, Title = "Optimization", Description = "Cloud optimization", IconClass = "fas fa-chart-pie", CreatedAt = baseDate, Status = Status.Active, IsDeleted = false },

                // Security Solutions
                new SectionItem { Id = 65, ParentSectionItemId = 48, TemplateId = 2, Type = SectionItemType.Service, SortOrder = 1, Title = "Network Security", Description = "Network security", IconClass = "fas fa-network-wired", CreatedAt = baseDate, Status = Status.Active, IsDeleted = false },
                new SectionItem { Id = 66, ParentSectionItemId = 48, TemplateId = 2, Type = SectionItemType.Service, SortOrder = 2, Title = "Application Security", Description = "Application security", IconClass = "fas fa-shield-alt", CreatedAt = baseDate, Status = Status.Active, IsDeleted = false },
                new SectionItem { Id = 67, ParentSectionItemId = 48, TemplateId = 2, Type = SectionItemType.Service, SortOrder = 3, Title = "Data Security", Description = "Data security", IconClass = "fas fa-lock", CreatedAt = baseDate, Status = Status.Active, IsDeleted = false },
                new SectionItem { Id = 68, ParentSectionItemId = 48, TemplateId = 2, Type = SectionItemType.Service, SortOrder = 4, Title = "Security Audit", Description = "Security auditing", IconClass = "fas fa-search", CreatedAt = baseDate, Status = Status.Active, IsDeleted = false }
            );
        }

        public static void SeedOtherMenus(this EntityTypeBuilder<SectionItem> builder)
        {
            var baseDate = new DateTime(2024, 10, 25, 10, 0, 0);

            builder.HasData(
                // ============================================
                // 4. BLOG MENU - Mega Menu
                // ============================================
                new SectionItem
                {
                    Id = 69,
                    ParentSectionItemId = null,
                    TemplateId = 2,
                    Type = SectionItemType.Menu,
                    SortOrder = 4,
                    Title = "Blog",
                    Description = "Blog mega menu",
                    AllowReorder = true,
                    AllowRemove = true,
                    IconClass = "fas fa-blog",
                    CreatedAt = baseDate,
                    Status = Status.Active,
                    IsDeleted = false
                },

                // Blog - Description
                new SectionItem { Id = 70, ParentSectionItemId = 69, TemplateId = 2, Type = SectionItemType.Text, SortOrder = 1, Title = "Description", Description = "Blog description", IconClass = "fas fa-info", CreatedAt = baseDate, Status = Status.Active, IsDeleted = false },

                // Blog - Categories
                new SectionItem { Id = 71, ParentSectionItemId = 69, TemplateId = 2, Type = SectionItemType.List, SortOrder = 2, Title = "Categories", Description = "Blog categories", IconClass = "fas fa-tags", CreatedAt = baseDate, Status = Status.Active, IsDeleted = false },
                new SectionItem { Id = 72, ParentSectionItemId = 71, TemplateId = 2, Type = SectionItemType.Link, SortOrder = 1, Title = "Cloud Trends", IconClass = "fas fa-cloud", CreatedAt = baseDate, Status = Status.Active, IsDeleted = false },
                new SectionItem { Id = 73, ParentSectionItemId = 71, TemplateId = 2, Type = SectionItemType.Link, SortOrder = 2, Title = "DevOps Practices", IconClass = "fas fa-cogs", CreatedAt = baseDate, Status = Status.Active, IsDeleted = false },
                new SectionItem { Id = 74, ParentSectionItemId = 71, TemplateId = 2, Type = SectionItemType.Link, SortOrder = 3, Title = "Software Innovation", IconClass = "fas fa-lightbulb", CreatedAt = baseDate, Status = Status.Active, IsDeleted = false },
                new SectionItem { Id = 75, ParentSectionItemId = 71, TemplateId = 2, Type = SectionItemType.Link, SortOrder = 4, Title = "Tech Leadership", IconClass = "fas fa-user-tie", CreatedAt = baseDate, Status = Status.Active, IsDeleted = false },

                // Blog - Featured Posts
                new SectionItem { Id = 76, ParentSectionItemId = 69, TemplateId = 2, Type = SectionItemType.FeatureCard, SortOrder = 3, Title = "Featured Posts", Description = "Featured blog posts", IconClass = "fas fa-star", CreatedAt = baseDate, Status = Status.Active, IsDeleted = false },
                new SectionItem { Id = 77, ParentSectionItemId = 76, TemplateId = 2, Type = SectionItemType.Media, SortOrder = 1, Title = "Kubernetes Guide", Description = "Best practices guide", IconClass = "fas fa-dharmachakra", CreatedAt = baseDate, Status = Status.Active, IsDeleted = false },
                new SectionItem { Id = 78, ParentSectionItemId = 76, TemplateId = 2, Type = SectionItemType.Media, SortOrder = 2, Title = "Azure Migration", Description = "Migration strategies", IconClass = "fab fa-microsoft", CreatedAt = baseDate, Status = Status.Active, IsDeleted = false },

                // ============================================
                // 5. SIMPLE MENU ITEMS
                // ============================================
                new SectionItem { Id = 79, ParentSectionItemId = null, TemplateId = 1, Type = SectionItemType.Link, SortOrder = 5, Title = "Careers", Description = "Career opportunities", IconClass = "fas fa-briefcase", CreatedAt = baseDate, Status = Status.Active, IsDeleted = false },
                new SectionItem { Id = 80, ParentSectionItemId = null, TemplateId = 1, Type = SectionItemType.Link, SortOrder = 6, Title = "Data Center", Description = "Data center status", IconClass = "fas fa-server", CreatedAt = baseDate, Status = Status.Active, IsDeleted = false },

                // ============================================
                // 6. CONTACT MENU - Dropdown
                // ============================================
                new SectionItem
                {
                    Id = 81,
                    ParentSectionItemId = null,
                    TemplateId = 1,
                    Type = SectionItemType.Dropdown,
                    SortOrder = 7,
                    Title = "Contact",
                    Description = "Contact information",
                    AllowReorder = true,
                    AllowRemove = true,
                    IconClass = "fas fa-envelope",
                    CreatedAt = baseDate,
                    Status = Status.Active,
                    IsDeleted = false
                },

                new SectionItem { Id = 82, ParentSectionItemId = 81, TemplateId = 2, Type = SectionItemType.Text, SortOrder = 1, Title = "Email", Description = "Email contact", IconClass = "fas fa-envelope", CreatedAt = baseDate, Status = Status.Active, IsDeleted = false },
                new SectionItem { Id = 83, ParentSectionItemId = 81, TemplateId = 2, Type = SectionItemType.Text, SortOrder = 2, Title = "Address", Description = "Office address", IconClass = "fas fa-map-marker-alt", CreatedAt = baseDate, Status = Status.Active, IsDeleted = false },

                // ============================================
                // 7. REFERENCES MENU
                // ============================================
                new SectionItem { Id = 84, ParentSectionItemId = null, TemplateId = 1, Type = SectionItemType.Link, SortOrder = 8, Title = "References", Description = "Customer references", IconClass = "fas fa-handshake", CreatedAt = baseDate, Status = Status.Active, IsDeleted = false }
            );
        }
    }
}
