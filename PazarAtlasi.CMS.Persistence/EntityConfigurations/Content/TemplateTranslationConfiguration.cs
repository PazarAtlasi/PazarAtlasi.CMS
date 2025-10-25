using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PazarAtlasi.CMS.Domain.Entities.Content;

namespace PazarAtlasi.CMS.Persistence.EntityConfigurations.Content
{
    public class TemplateTranslationConfiguration : IEntityTypeConfiguration<TemplateTranslation>
    {
        public void Configure(EntityTypeBuilder<TemplateTranslation> builder)
        {
            builder.HasKey(tt => tt.Id);

            builder.Property(tt => tt.Name)
                .IsRequired()
                .HasMaxLength(200);

            builder.Property(tt => tt.Description)
                .HasMaxLength(1000);

            // Foreign key relationships
            builder.HasOne(tt => tt.Template)
                .WithMany(t => t.Translations)
                .HasForeignKey(tt => tt.TemplateId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(tt => tt.Language)
                .WithMany()
                .HasForeignKey(tt => tt.LanguageId)
                .OnDelete(DeleteBehavior.Restrict);

            // Unique constraint for TemplateId + LanguageId combination
            builder.HasIndex(tt => new { tt.TemplateId, tt.LanguageId })
                .IsUnique();

            // Index for performance
            builder.HasIndex(tt => tt.LanguageId);

            // Seed Data - Template Translations for 3 languages
            builder.HasData(
                // Template 1: navbar-simple translations
                new TemplateTranslation
                {
                    Id = 1,
                    TemplateId = 1,
                    LanguageId = 1, // Türkçe
                    Name = "Basit Navbar",
                    Description = "Sade ve temiz tasarımlı navigasyon çubuğu şablonu"
                },
                new TemplateTranslation
                {
                    Id = 2,
                    TemplateId = 1,
                    LanguageId = 2, // English
                    Name = "Simple Navbar",
                    Description = "Clean and simple navigation bar template"
                },
                new TemplateTranslation
                {
                    Id = 3,
                    TemplateId = 1,
                    LanguageId = 3, // Deutsch
                    Name = "Einfache Navbar",
                    Description = "Sauberes und einfaches Navigationsleisten-Template"
                },

                // Template 2: navbar-megamenu translations
                new TemplateTranslation
                {
                    Id = 4,
                    TemplateId = 2,
                    LanguageId = 1, // Türkçe
                    Name = "Mega Menü Navbar",
                    Description = "Geniş kategoriler ve alt menülerle mega menü şablonu"
                },
                new TemplateTranslation
                {
                    Id = 5,
                    TemplateId = 2,
                    LanguageId = 2, // English
                    Name = "Mega Menu Navbar",
                    Description = "Mega menu template with wide categories and submenus"
                },
                new TemplateTranslation
                {
                    Id = 6,
                    TemplateId = 2,
                    LanguageId = 3, // Deutsch
                    Name = "Mega-Menü Navbar",
                    Description = "Mega-Menü-Template mit breiten Kategorien und Untermenüs"
                },

                // Template 3: navbar-servicetabs translations
                new TemplateTranslation
                {
                    Id = 7,
                    TemplateId = 3,
                    LanguageId = 1, // Türkçe
                    Name = "Hizmet Sekmeli Navbar",
                    Description = "Hizmet kategorilerini sekme şeklinde gösteren navbar şablonu"
                },
                new TemplateTranslation
                {
                    Id = 8,
                    TemplateId = 3,
                    LanguageId = 2, // English
                    Name = "Service Tabs Navbar",
                    Description = "Navbar template displaying service categories as tabs"
                },
                new TemplateTranslation
                {
                    Id = 9,
                    TemplateId = 3,
                    LanguageId = 3, // Deutsch
                    Name = "Service-Tabs Navbar",
                    Description = "Navbar-Template, das Servicekategorien als Tabs anzeigt"
                },

                // Template 4: navbar-categorized translations
                new TemplateTranslation
                {
                    Id = 10,
                    TemplateId = 4,
                    LanguageId = 1, // Türkçe
                    Name = "Kategorili Navbar",
                    Description = "İçerikleri kategorilere göre düzenleyen navbar şablonu"
                },
                new TemplateTranslation
                {
                    Id = 11,
                    TemplateId = 4,
                    LanguageId = 2, // English
                    Name = "Categorized Navbar",
                    Description = "Navbar template organizing content by categories"
                },
                new TemplateTranslation
                {
                    Id = 12,
                    TemplateId = 4,
                    LanguageId = 3, // Deutsch
                    Name = "Kategorisierte Navbar",
                    Description = "Navbar-Template, das Inhalte nach Kategorien organisiert"
                },

                // Template 5: default translations
                new TemplateTranslation
                {
                    Id = 13,
                    TemplateId = 5,
                    LanguageId = 1, // Türkçe
                    Name = "Varsayılan Şablon",
                    Description = "Temel ve esnek kullanım için varsayılan şablon"
                },
                new TemplateTranslation
                {
                    Id = 14,
                    TemplateId = 5,
                    LanguageId = 2, // English
                    Name = "Default Template",
                    Description = "Default template for basic and flexible usage"
                },
                new TemplateTranslation
                {
                    Id = 15,
                    TemplateId = 5,
                    LanguageId = 3, // Deutsch
                    Name = "Standard-Template",
                    Description = "Standard-Template für grundlegende und flexible Verwendung"
                },

                // Template 6: sequential translations
                new TemplateTranslation
                {
                    Id = 16,
                    TemplateId = 6,
                    LanguageId = 1, // Türkçe
                    Name = "Sıralı Şablon",
                    Description = "İçerikleri sıralı bir şekilde gösteren şablon"
                },
                new TemplateTranslation
                {
                    Id = 17,
                    TemplateId = 6,
                    LanguageId = 2, // English
                    Name = "Sequential Template",
                    Description = "Template displaying content in sequential order"
                },
                new TemplateTranslation
                {
                    Id = 18,
                    TemplateId = 6,
                    LanguageId = 3, // Deutsch
                    Name = "Sequenzielles Template",
                    Description = "Template, das Inhalte in sequenzieller Reihenfolge anzeigt"
                },

                // Template 7: grid translations
                new TemplateTranslation
                {
                    Id = 19,
                    TemplateId = 7,
                    LanguageId = 1, // Türkçe
                    Name = "Izgara Şablonu",
                    Description = "İçerikleri ızgara düzeninde gösteren şablon"
                },
                new TemplateTranslation
                {
                    Id = 20,
                    TemplateId = 7,
                    LanguageId = 2, // English
                    Name = "Grid Template",
                    Description = "Template displaying content in grid layout"
                },
                new TemplateTranslation
                {
                    Id = 21,
                    TemplateId = 7,
                    LanguageId = 3, // Deutsch
                    Name = "Raster-Template",
                    Description = "Template, das Inhalte im Raster-Layout anzeigt"
                },

                // Template 8: masonry translations
                new TemplateTranslation
                {
                    Id = 22,
                    TemplateId = 8,
                    LanguageId = 1, // Türkçe
                    Name = "Masonry Şablonu",
                    Description = "Pinterest tarzı duvar düzeninde içerik gösteren şablon"
                },
                new TemplateTranslation
                {
                    Id = 23,
                    TemplateId = 8,
                    LanguageId = 2, // English
                    Name = "Masonry Template",
                    Description = "Template displaying content in Pinterest-style wall layout"
                },
                new TemplateTranslation
                {
                    Id = 24,
                    TemplateId = 8,
                    LanguageId = 3, // Deutsch
                    Name = "Masonry-Template",
                    Description = "Template, das Inhalte im Pinterest-Stil Wand-Layout anzeigt"
                },

                // Template 9: carousel translations
                new TemplateTranslation
                {
                    Id = 25,
                    TemplateId = 9,
                    LanguageId = 1, // Türkçe
                    Name = "Karusel Şablonu",
                    Description = "İçerikleri kaydırmalı karusel şeklinde gösteren şablon"
                },
                new TemplateTranslation
                {
                    Id = 26,
                    TemplateId = 9,
                    LanguageId = 2, // English
                    Name = "Carousel Template",
                    Description = "Template displaying content in scrollable carousel format"
                },
                new TemplateTranslation
                {
                    Id = 27,
                    TemplateId = 9,
                    LanguageId = 3, // Deutsch
                    Name = "Karusell-Template",
                    Description = "Template, das Inhalte im scrollbaren Karussell-Format anzeigt"
                },

                // Template 10: list translations
                new TemplateTranslation
                {
                    Id = 28,
                    TemplateId = 10,
                    LanguageId = 1, // Türkçe
                    Name = "Liste Şablonu",
                    Description = "İçerikleri liste halinde düzenli şekilde gösteren şablon"
                },
                new TemplateTranslation
                {
                    Id = 29,
                    TemplateId = 10,
                    LanguageId = 2, // English
                    Name = "List Template",
                    Description = "Template displaying content in organized list format"
                },
                new TemplateTranslation
                {
                    Id = 30,
                    TemplateId = 10,
                    LanguageId = 3, // Deutsch
                    Name = "Listen-Template",
                    Description = "Template, das Inhalte im organisierten Listenformat anzeigt"
                },

                // Template 11: single-item translations
                new TemplateTranslation
                {
                    Id = 31,
                    TemplateId = 11,
                    LanguageId = 1, // Türkçe
                    Name = "Tek Öğe Şablonu",
                    Description = "Tek bir içerik öğesini vurgulayan şablon"
                },
                new TemplateTranslation
                {
                    Id = 32,
                    TemplateId = 11,
                    LanguageId = 2, // English
                    Name = "Single Item Template",
                    Description = "Template highlighting a single content item"
                },
                new TemplateTranslation
                {
                    Id = 33,
                    TemplateId = 11,
                    LanguageId = 3, // Deutsch
                    Name = "Einzelartikel-Template",
                    Description = "Template, das einen einzelnen Inhaltsartikel hervorhebt"
                },

                // Template 12: multi-item translations
                new TemplateTranslation
                {
                    Id = 34,
                    TemplateId = 12,
                    LanguageId = 1, // Türkçe
                    Name = "Çoklu Öğe Şablonu",
                    Description = "Birden fazla içerik öğesini düzenli şekilde gösteren şablon"
                },
                new TemplateTranslation
                {
                    Id = 35,
                    TemplateId = 12,
                    LanguageId = 2, // English
                    Name = "Multi Item Template",
                    Description = "Template displaying multiple content items in organized manner"
                },
                new TemplateTranslation
                {
                    Id = 36,
                    TemplateId = 12,
                    LanguageId = 3, // Deutsch
                    Name = "Mehrfachartikel-Template",
                    Description = "Template, das mehrere Inhaltsartikel organisiert anzeigt"
                },

                // Template 13: accordion translations
                new TemplateTranslation
                {
                    Id = 37,
                    TemplateId = 13,
                    LanguageId = 1, // Türkçe
                    Name = "Akordeon Şablonu",
                    Description = "İçerikleri açılır-kapanır akordeon şeklinde gösteren şablon"
                },
                new TemplateTranslation
                {
                    Id = 38,
                    TemplateId = 13,
                    LanguageId = 2, // English
                    Name = "Accordion Template",
                    Description = "Template displaying content in expandable accordion format"
                },
                new TemplateTranslation
                {
                    Id = 39,
                    TemplateId = 13,
                    LanguageId = 3, // Deutsch
                    Name = "Akkordeon-Template",
                    Description = "Template, das Inhalte im erweiterbaren Akkordeon-Format anzeigt"
                },

                // Template 14: tabs translations
                new TemplateTranslation
                {
                    Id = 40,
                    TemplateId = 14,
                    LanguageId = 1, // Türkçe
                    Name = "Sekme Şablonu",
                    Description = "İçerikleri sekmeler halinde organize eden şablon"
                },
                new TemplateTranslation
                {
                    Id = 41,
                    TemplateId = 14,
                    LanguageId = 2, // English
                    Name = "Tabs Template",
                    Description = "Template organizing content into tabs"
                },
                new TemplateTranslation
                {
                    Id = 42,
                    TemplateId = 14,
                    LanguageId = 3, // Deutsch
                    Name = "Tabs-Template",
                    Description = "Template, das Inhalte in Tabs organisiert"
                }
            );
        }
    }
}
