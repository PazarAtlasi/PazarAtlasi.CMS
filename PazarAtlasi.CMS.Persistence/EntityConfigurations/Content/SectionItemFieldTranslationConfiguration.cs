using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PazarAtlasi.CMS.Domain.Entities.Content;

namespace PazarAtlasi.CMS.Persistence.EntityConfigurations.Content
{
    public class SectionItemFieldTranslationConfiguration : IEntityTypeConfiguration<SectionItemFieldTranslation>
    {
        public void Configure(EntityTypeBuilder<SectionItemFieldTranslation> builder)
        {
            builder.ToTable("SectionItemFieldTranslations");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Label)
                .HasMaxLength(200)
                .IsRequired();

            builder.Property(x => x.Description)
                .HasMaxLength(500);

            builder.Property(x => x.Placeholder)
                .HasMaxLength(200);

            // Relationships
            builder.HasOne(x => x.SectionItemField)
                .WithMany(x => x.Translations)
                .HasForeignKey(x => x.SectionItemFieldId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(x => x.Language)
                .WithMany()
                .HasForeignKey(x => x.LanguageId)
                .OnDelete(DeleteBehavior.Cascade);

            // Indexes
            builder.HasIndex(x => new { x.SectionItemFieldId, x.LanguageId })
                .IsUnique()
                .HasDatabaseName("IX_SectionItemFieldTranslations_FieldId_LanguageId");

            builder.HasIndex(x => x.LanguageId)
                .HasDatabaseName("IX_SectionItemFieldTranslations_LanguageId");

            // Base entity configuration
            builder.Property(x => x.CreatedAt)
                .IsRequired();

            builder.Property(x => x.UpdatedAt);

            builder.Property(x => x.IsDeleted)
                .HasDefaultValue(false);

            builder.HasQueryFilter(x => !x.IsDeleted);

            // Seed Data - Field Translations (Turkish and English)
            builder.HasData(
                // Turkish Translations (Language ID: 1)
                new SectionItemFieldTranslation
                {
                    Id = 1,
                    SectionItemFieldId = 1,
                    LanguageId = 1, // Turkish
                    Label = "Logo Resmi",
                    Description = "Navbar için logo resmi yükleyin",
                    Placeholder = "Logo resminizi yükleyin",
                    CreatedAt = new DateTime(2024, 10, 14, 10, 0, 0),
                    IsDeleted = false
                },
                new SectionItemFieldTranslation
                {
                    Id = 2,
                    SectionItemFieldId = 2,
                    LanguageId = 1, // Turkish
                    Label = "Logo Metni",
                    Description = "Logo yerine gösterilecek metin",
                    Placeholder = "Logo metnini girin",
                    CreatedAt = new DateTime(2024, 10, 14, 10, 0, 0),
                    IsDeleted = false
                },
                new SectionItemFieldTranslation
                {
                    Id = 3,
                    SectionItemFieldId = 3,
                    LanguageId = 1, // Turkish
                    Label = "Menü Başlığı",
                    Description = "Menü öğesinin başlığı",
                    Placeholder = "Menü başlığını girin",
                    CreatedAt = new DateTime(2024, 10, 14, 10, 0, 0),
                    IsDeleted = false
                },
                new SectionItemFieldTranslation
                {
                    Id = 4,
                    SectionItemFieldId = 4,
                    LanguageId = 1, // Turkish
                    Label = "Menü URL'si",
                    Description = "Menü öğesinin yönlendirileceği URL",
                    Placeholder = "Menü URL'sini girin (dropdown'lar için opsiyonel)",
                    CreatedAt = new DateTime(2024, 10, 14, 10, 0, 0),
                    IsDeleted = false
                },
                new SectionItemFieldTranslation
                {
                    Id = 5,
                    SectionItemFieldId = 5,
                    LanguageId = 1, // Turkish
                    Label = "Menü İkonu",
                    Description = "Menü öğesi için ikon sınıfı",
                    Placeholder = "İkon sınıfını girin (örn: fas fa-home)",
                    CreatedAt = new DateTime(2024, 10, 14, 10, 0, 0),
                    IsDeleted = false
                },
                new SectionItemFieldTranslation
                {
                    Id = 6,
                    SectionItemFieldId = 6,
                    LanguageId = 1, // Turkish
                    Label = "Menü Açıklaması",
                    Description = "Mega menü için açıklama metni",
                    Placeholder = "Mega menü açıklamasını girin",
                    CreatedAt = new DateTime(2024, 10, 14, 10, 0, 0),
                    IsDeleted = false
                },
                new SectionItemFieldTranslation
                {
                    Id = 7,
                    SectionItemFieldId = 7,
                    LanguageId = 1, // Turkish
                    Label = "Öne Çıkan Resim",
                    Description = "Mega menü için öne çıkan resim",
                    Placeholder = "Öne çıkan resim yükleyin",
                    CreatedAt = new DateTime(2024, 10, 14, 10, 0, 0),
                    IsDeleted = false
                },
                new SectionItemFieldTranslation
                {
                    Id = 8,
                    SectionItemFieldId = 8,
                    LanguageId = 1, // Turkish
                    Label = "Öne Çıkan",
                    Description = "Bu öğeyi öne çıkan olarak işaretle",
                    Placeholder = "Öne çıkan öğe olarak işaretle",
                    CreatedAt = new DateTime(2024, 10, 14, 10, 0, 0),
                    IsDeleted = false
                },
                new SectionItemFieldTranslation
                {
                    Id = 9,
                    SectionItemFieldId = 9,
                    LanguageId = 1, // Turkish
                    Label = "Rozet Metni",
                    Description = "Menü öğesi için rozet metni",
                    Placeholder = "Rozet metnini girin (örn: YENİ, POPÜLER)",
                    CreatedAt = new DateTime(2024, 10, 14, 10, 0, 0),
                    IsDeleted = false
                },
                new SectionItemFieldTranslation
                {
                    Id = 10,
                    SectionItemFieldId = 10,
                    LanguageId = 1, // Turkish
                    Label = "Rozet Rengi",
                    Description = "Rozet için renk seçimi",
                    Placeholder = "Rozet rengini seçin",
                    CreatedAt = new DateTime(2024, 10, 14, 10, 0, 0),
                    IsDeleted = false
                },

                // English Translations (Language ID: 2)
                new SectionItemFieldTranslation
                {
                    Id = 11,
                    SectionItemFieldId = 1,
                    LanguageId = 2, // English
                    Label = "Logo Image",
                    Description = "Upload logo image for navbar",
                    Placeholder = "Upload your logo image",
                    CreatedAt = new DateTime(2024, 10, 14, 10, 0, 0),
                    IsDeleted = false
                },
                new SectionItemFieldTranslation
                {
                    Id = 12,
                    SectionItemFieldId = 2,
                    LanguageId = 2, // English
                    Label = "Logo Text",
                    Description = "Text to display instead of logo",
                    Placeholder = "Enter logo text",
                    CreatedAt = new DateTime(2024, 10, 14, 10, 0, 0),
                    IsDeleted = false
                },
                new SectionItemFieldTranslation
                {
                    Id = 13,
                    SectionItemFieldId = 3,
                    LanguageId = 2, // English
                    Label = "Menu Title",
                    Description = "Title of the menu item",
                    Placeholder = "Enter menu title",
                    CreatedAt = new DateTime(2024, 10, 14, 10, 0, 0),
                    IsDeleted = false
                },
                new SectionItemFieldTranslation
                {
                    Id = 14,
                    SectionItemFieldId = 4,
                    LanguageId = 2, // English
                    Label = "Menu URL",
                    Description = "URL where the menu item should redirect",
                    Placeholder = "Enter menu URL (optional for dropdowns)",
                    CreatedAt = new DateTime(2024, 10, 14, 10, 0, 0),
                    IsDeleted = false
                },
                new SectionItemFieldTranslation
                {
                    Id = 15,
                    SectionItemFieldId = 5,
                    LanguageId = 2, // English
                    Label = "Menu Icon",
                    Description = "Icon class for the menu item",
                    Placeholder = "Enter icon class (e.g., fas fa-home)",
                    CreatedAt = new DateTime(2024, 10, 14, 10, 0, 0),
                    IsDeleted = false
                },
                new SectionItemFieldTranslation
                {
                    Id = 16,
                    SectionItemFieldId = 6,
                    LanguageId = 2, // English
                    Label = "Menu Description",
                    Description = "Description text for mega menu",
                    Placeholder = "Enter mega menu description",
                    CreatedAt = new DateTime(2024, 10, 14, 10, 0, 0),
                    IsDeleted = false
                },
                new SectionItemFieldTranslation
                {
                    Id = 17,
                    SectionItemFieldId = 7,
                    LanguageId = 2, // English
                    Label = "Featured Image",
                    Description = "Featured image for mega menu",
                    Placeholder = "Upload featured image",
                    CreatedAt = new DateTime(2024, 10, 14, 10, 0, 0),
                    IsDeleted = false
                },
                new SectionItemFieldTranslation
                {
                    Id = 18,
                    SectionItemFieldId = 8,
                    LanguageId = 2, // English
                    Label = "Is Featured",
                    Description = "Mark this item as featured",
                    Placeholder = "Mark as featured item",
                    CreatedAt = new DateTime(2024, 10, 14, 10, 0, 0),
                    IsDeleted = false
                },
                new SectionItemFieldTranslation
                {
                    Id = 19,
                    SectionItemFieldId = 9,
                    LanguageId = 2, // English
                    Label = "Badge Text",
                    Description = "Badge text for menu item",
                    Placeholder = "Enter badge text (e.g., NEW, HOT)",
                    CreatedAt = new DateTime(2024, 10, 14, 10, 0, 0),
                    IsDeleted = false
                },
                new SectionItemFieldTranslation
                {
                    Id = 20,
                    SectionItemFieldId = 10,
                    LanguageId = 2, // English
                    Label = "Badge Color",
                    Description = "Color selection for badge",
                    Placeholder = "Select badge color",
                    CreatedAt = new DateTime(2024, 10, 14, 10, 0, 0),
                    IsDeleted = false
                }
            );
        }
    }
}