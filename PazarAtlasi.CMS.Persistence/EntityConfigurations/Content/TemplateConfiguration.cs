using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PazarAtlasi.CMS.Domain.Entities.Content;
using PazarAtlasi.CMS.Domain.Common;

namespace PazarAtlasi.CMS.Persistence.EntityConfigurations.Content
{
    public class TemplateConfigurationBuilder : IEntityTypeConfiguration<Template>
    {
        public void Configure(EntityTypeBuilder<Template> builder)
        {
            builder.HasKey(t => t.Id);

            builder.Property(t => t.Name)
                .IsRequired()
                .HasMaxLength(200);

            builder.Property(t => t.Description)
                .HasMaxLength(1000);

            builder.Property(t => t.TemplateKey)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(t => t.ConfigurationSchema)
                .HasColumnType("nvarchar(max)");

            builder.Property(t => t.TemplateType)
                .IsRequired()
                .HasConversion<int>();

            builder.Property(t => t.IsActive)
                .HasDefaultValue(true);

            builder.Property(t => t.SortOrder)
                .HasDefaultValue(0);

            // Index for performance
            builder.HasIndex(t => new { t.TemplateType, t.IsActive });
            builder.HasIndex(t => t.TemplateKey).IsUnique();

            // Relationships
            builder.HasMany(t => t.SectionTemplates)
                .WithOne(st => st.Template)
                .HasForeignKey(st => st.TemplateId)
                .OnDelete(DeleteBehavior.Cascade);

            // Seed Data
            builder.HasData(
                // Navbar Templates
                new Template
                {
                    Id = 1,
                    Name = "Simple Navbar",
                    Description = "A simple horizontal navigation bar with basic menu items",
                    TemplateType = TemplateType.Default,
                    TemplateKey = "navbar-simple",
                    ConfigurationSchema = @"{""type"":""object"",""properties"":{""backgroundColor"":{""type"":""string"",""default"":""#ffffff""},""textColor"":{""type"":""string"",""default"":""#333333""},""showLogo"":{""type"":""boolean"",""default"":true},""logoPosition"":{""type"":""string"",""enum"":[""left"",""center"",""right""],""default"":""left""}}}",
                    IsActive = true,
                    SortOrder = 1,
                    CreatedAt = new DateTime(2024, 10, 14, 10, 0, 0),
                    IsDeleted = false
                },
                new Template
                {
                    Id = 2,
                    Name = "Mega Menu Navbar",
                    Description = "Advanced navbar with dropdown mega menus and rich content",
                    TemplateType = TemplateType.MegaMenu,
                    TemplateKey = "navbar-megamenu",
                    ConfigurationSchema = @"{""type"":""object"",""properties"":{""backgroundColor"":{""type"":""string"",""default"":""#1a1a1a""},""textColor"":{""type"":""string"",""default"":""#ffffff""},""showLogo"":{""type"":""boolean"",""default"":true},""logoPosition"":{""type"":""string"",""enum"":[""left"",""center"",""right""],""default"":""left""},""megaMenuColumns"":{""type"":""integer"",""minimum"":2,""maximum"":4,""default"":3},""showDescriptions"":{""type"":""boolean"",""default"":true},""showImages"":{""type"":""boolean"",""default"":true}}}",
                    IsActive = true,
                    SortOrder = 2,
                    CreatedAt = new DateTime(2024, 10, 14, 10, 0, 0),
                    IsDeleted = false
                },
                new Template
                {
                    Id = 3,
                    Name = "Service Tabs Navbar",
                    Description = "Navbar with tabbed service navigation and interactive content",
                    TemplateType = TemplateType.Tabs,
                    TemplateKey = "navbar-servicetabs",
                    ConfigurationSchema = @"{""type"":""object"",""properties"":{""backgroundColor"":{""type"":""string"",""default"":""#2d3748""},""textColor"":{""type"":""string"",""default"":""#ffffff""},""showLogo"":{""type"":""boolean"",""default"":true},""logoPosition"":{""type"":""string"",""enum"":[""left"",""center"",""right""],""default"":""left""},""tabStyle"":{""type"":""string"",""enum"":[""pills"",""underline"",""background""],""default"":""pills""},""showIcons"":{""type"":""boolean"",""default"":true},""animationDuration"":{""type"":""integer"",""minimum"":100,""maximum"":1000,""default"":300}}}",
                    IsActive = true,
                    SortOrder = 3,
                    CreatedAt = new DateTime(2024, 10, 14, 10, 0, 0),
                    IsDeleted = false
                },
                new Template
                {
                    Id = 4,
                    Name = "Categorized Navbar",
                    Description = "Navbar with categorized menu items and filtered content display",
                    TemplateType = TemplateType.List,
                    TemplateKey = "navbar-categorized",
                    ConfigurationSchema = @"{""type"":""object"",""properties"":{""backgroundColor"":{""type"":""string"",""default"":""#4a5568""},""textColor"":{""type"":""string"",""default"":""#ffffff""},""showLogo"":{""type"":""boolean"",""default"":true},""logoPosition"":{""type"":""string"",""enum"":[""left"",""center"",""right""],""default"":""left""},""categoryStyle"":{""type"":""string"",""enum"":[""sidebar"",""dropdown"",""tabs""],""default"":""sidebar""},""showCategoryIcons"":{""type"":""boolean"",""default"":true},""itemsPerCategory"":{""type"":""integer"",""minimum"":2,""maximum"":8,""default"":4}}}",
                    IsActive = true,
                    SortOrder = 4,
                    CreatedAt = new DateTime(2024, 10, 14, 10, 0, 0),
                    IsDeleted = false
                },
                // Hero Templates
                // General Templates (Id: 5-14) - Can be used with any SectionType
                new Template
                {
                    Id = 5,
                    Name = "Default Template",
                    Description = "Standard template for any section type",
                    TemplateType = TemplateType.Default,
                    TemplateKey = "default",
                    ConfigurationSchema = @"{""type"":""object"",""properties"":{""backgroundColor"":{""type"":""string"",""default"":""#ffffff""},""textColor"":{""type"":""string"",""default"":""#333333""},""padding"":{""type"":""string"",""enum"":[""small"",""medium"",""large""],""default"":""medium""}}}",
                    IsActive = true,
                    SortOrder = 5,
                    CreatedAt = new DateTime(2024, 10, 14, 10, 0, 0),
                    IsDeleted = false
                },
                new Template
                {
                    Id = 6,
                    Name = "Sequential Layout",
                    Description = "Items displayed in sequential order",
                    TemplateType = TemplateType.Sequential,
                    TemplateKey = "sequential",
                    ConfigurationSchema = @"{""type"":""object"",""properties"":{""direction"":{""type"":""string"",""enum"":[""horizontal"",""vertical""],""default"":""vertical""},""spacing"":{""type"":""string"",""enum"":[""small"",""medium"",""large""],""default"":""medium""},""showNumbers"":{""type"":""boolean"",""default"":false}}}",
                    IsActive = true,
                    SortOrder = 6,
                    CreatedAt = new DateTime(2024, 10, 14, 10, 0, 0),
                    IsDeleted = false
                },
                new Template
                {
                    Id = 7,
                    Name = "Grid Layout",
                    Description = "Content displayed in a responsive grid layout",
                    TemplateType = TemplateType.Grid,
                    TemplateKey = "grid",
                    ConfigurationSchema = @"{""type"":""object"",""properties"":{""columns"":{""type"":""integer"",""minimum"":1,""maximum"":6,""default"":3},""gap"":{""type"":""string"",""enum"":[""small"",""medium"",""large""],""default"":""medium""},""showImages"":{""type"":""boolean"",""default"":true},""showExcerpts"":{""type"":""boolean"",""default"":true}}}",
                    IsActive = true,
                    SortOrder = 7,
                    CreatedAt = new DateTime(2024, 10, 14, 10, 0, 0),
                    IsDeleted = false
                },
                new Template
                {
                    Id = 8,
                    Name = "Masonry Layout",
                    Description = "Pinterest-style masonry layout for varied content sizes",
                    TemplateType = TemplateType.Masonry,
                    TemplateKey = "masonry",
                    ConfigurationSchema = @"{""type"":""object"",""properties"":{""columns"":{""type"":""integer"",""minimum"":2,""maximum"":5,""default"":3},""gap"":{""type"":""string"",""enum"":[""small"",""medium"",""large""],""default"":""medium""},""showImages"":{""type"":""boolean"",""default"":true},""imageAspectRatio"":{""type"":""string"",""enum"":[""auto"",""square"",""landscape"",""portrait""],""default"":""auto""}}}",
                    IsActive = true,
                    SortOrder = 8,
                    CreatedAt = new DateTime(2024, 10, 14, 10, 0, 0),
                    IsDeleted = false
                },
                new Template
                {
                    Id = 9,
                    Name = "Carousel",
                    Description = "Sliding carousel with navigation controls",
                    TemplateType = TemplateType.Carousel,
                    TemplateKey = "carousel",
                    ConfigurationSchema = @"{""type"":""object"",""properties"":{""autoPlay"":{""type"":""boolean"",""default"":true},""interval"":{""type"":""integer"",""minimum"":2000,""maximum"":10000,""default"":5000},""showIndicators"":{""type"":""boolean"",""default"":true},""showArrows"":{""type"":""boolean"",""default"":true},""transitionEffect"":{""type"":""string"",""enum"":[""fade"",""slide"",""zoom""],""default"":""slide""}}}",
                    IsActive = true,
                    SortOrder = 9,
                    CreatedAt = new DateTime(2024, 10, 14, 10, 0, 0),
                    IsDeleted = false
                },
                new Template
                {
                    Id = 10,
                    Name = "List Layout",
                    Description = "Simple list layout with optional icons",
                    TemplateType = TemplateType.List,
                    TemplateKey = "list",
                    ConfigurationSchema = @"{""type"":""object"",""properties"":{""showIcons"":{""type"":""boolean"",""default"":true},""iconPosition"":{""type"":""string"",""enum"":[""left"",""right""],""default"":""left""},""spacing"":{""type"":""string"",""enum"":[""compact"",""comfortable"",""spacious""],""default"":""comfortable""},""showDividers"":{""type"":""boolean"",""default"":false}}}",
                    IsActive = true,
                    SortOrder = 10,
                    CreatedAt = new DateTime(2024, 10, 14, 10, 0, 0),
                    IsDeleted = false
                },
                new Template
                {
                    Id = 11,
                    Name = "Single Item",
                    Description = "Display single item with focus",
                    TemplateType = TemplateType.SingleItem,
                    TemplateKey = "single-item",
                    ConfigurationSchema = @"{""type"":""object"",""properties"":{""alignment"":{""type"":""string"",""enum"":[""left"",""center"",""right""],""default"":""center""},""showImage"":{""type"":""boolean"",""default"":true},""imageSize"":{""type"":""string"",""enum"":[""small"",""medium"",""large""],""default"":""medium""},""showDescription"":{""type"":""boolean"",""default"":true}}}",
                    IsActive = true,
                    SortOrder = 11,
                    CreatedAt = new DateTime(2024, 10, 14, 10, 0, 0),
                    IsDeleted = false
                },
                new Template
                {
                    Id = 12,
                    Name = "Multi Item",
                    Description = "Display multiple items in organized layout",
                    TemplateType = TemplateType.MultiItem,
                    TemplateKey = "multi-item",
                    ConfigurationSchema = @"{""type"":""object"",""properties"":{""itemsPerRow"":{""type"":""integer"",""minimum"":2,""maximum"":6,""default"":3},""showTitles"":{""type"":""boolean"",""default"":true},""showDescriptions"":{""type"":""boolean"",""default"":true},""equalHeight"":{""type"":""boolean"",""default"":true}}}",
                    IsActive = true,
                    SortOrder = 12,
                    CreatedAt = new DateTime(2024, 10, 14, 10, 0, 0),
                    IsDeleted = false
                },
                new Template
                {
                    Id = 13,
                    Name = "Accordion",
                    Description = "Collapsible accordion layout",
                    TemplateType = TemplateType.Accordion,
                    TemplateKey = "accordion",
                    ConfigurationSchema = @"{""type"":""object"",""properties"":{""allowMultiple"":{""type"":""boolean"",""default"":false},""defaultOpen"":{""type"":""integer"",""minimum"":0,""default"":0},""showIcons"":{""type"":""boolean"",""default"":true},""animationDuration"":{""type"":""integer"",""minimum"":100,""maximum"":1000,""default"":300}}}",
                    IsActive = true,
                    SortOrder = 13,
                    CreatedAt = new DateTime(2024, 10, 14, 10, 0, 0),
                    IsDeleted = false
                },
                new Template
                {
                    Id = 14,
                    Name = "Tabs",
                    Description = "Tabbed content layout",
                    TemplateType = TemplateType.Tabs,
                    TemplateKey = "tabs",
                    ConfigurationSchema = @"{""type"":""object"",""properties"":{""tabPosition"":{""type"":""string"",""enum"":[""top"",""bottom"",""left"",""right""],""default"":""top""},""tabStyle"":{""type"":""string"",""enum"":[""pills"",""underline"",""background""],""default"":""underline""},""showIcons"":{""type"":""boolean"",""default"":false},""defaultTab"":{""type"":""integer"",""minimum"":0,""default"":0}}}",
                    IsActive = true,
                    SortOrder = 14,
                    CreatedAt = new DateTime(2024, 10, 14, 10, 0, 0),
                    IsDeleted = false
                }
            );
        }
    }
}
