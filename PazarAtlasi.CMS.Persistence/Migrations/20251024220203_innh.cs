using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace PazarAtlasi.CMS.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class innh : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "SectionItemFields",
                columns: new[] { "Id", "CreatedAt", "CreatedBy", "DefaultValue", "FieldKey", "FieldName", "IsTranslatable", "MaxLength", "OptionsJson", "Placeholder", "Required", "SortOrder", "Status", "TemplateId", "Type", "UpdatedAt", "UpdatedBy" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 10, 14, 10, 0, 0, 0, DateTimeKind.Unspecified), null, "", "logo_image", "Logo Image", false, null, null, "Upload your logo image", false, 1, 0, 2, 11, null, null },
                    { 2, new DateTime(2024, 10, 14, 10, 0, 0, 0, DateTimeKind.Unspecified), null, "", "logo_text", "Logo Text", true, 100, null, "Enter logo text", false, 2, 0, 2, 1, null, null },
                    { 3, new DateTime(2024, 10, 14, 10, 0, 0, 0, DateTimeKind.Unspecified), null, "", "menu_title", "Menu Title", true, 50, null, "Enter menu title", true, 3, 0, 2, 1, null, null },
                    { 4, new DateTime(2024, 10, 14, 10, 0, 0, 0, DateTimeKind.Unspecified), null, "#", "menu_url", "Menu URL", false, null, null, "Enter menu URL (optional for dropdowns)", false, 4, 0, 2, 13, null, null },
                    { 5, new DateTime(2024, 10, 14, 10, 0, 0, 0, DateTimeKind.Unspecified), null, "", "menu_icon", "Menu Icon", false, 50, null, "Enter icon class (e.g., fas fa-home)", false, 5, 0, 2, 1, null, null },
                    { 6, new DateTime(2024, 10, 14, 10, 0, 0, 0, DateTimeKind.Unspecified), null, "", "menu_description", "Menu Description", true, 200, null, "Enter menu description for mega menu", false, 6, 0, 2, 2, null, null },
                    { 7, new DateTime(2024, 10, 14, 10, 0, 0, 0, DateTimeKind.Unspecified), null, "", "featured_image", "Featured Image", false, null, null, "Upload featured image for mega menu", false, 7, 0, 2, 11, null, null },
                    { 8, new DateTime(2024, 10, 14, 10, 0, 0, 0, DateTimeKind.Unspecified), null, "false", "is_featured", "Is Featured", false, null, null, "Mark as featured item", false, 8, 0, 2, 5, null, null },
                    { 9, new DateTime(2024, 10, 14, 10, 0, 0, 0, DateTimeKind.Unspecified), null, "", "badge_text", "Badge Text", true, 20, null, "Enter badge text (e.g., NEW, HOT)", false, 9, 0, 2, 1, null, null },
                    { 10, new DateTime(2024, 10, 14, 10, 0, 0, 0, DateTimeKind.Unspecified), null, "primary", "badge_color", "Badge Color", false, null, "[\"primary\", \"secondary\", \"success\", \"danger\", \"warning\", \"info\"]", "Select badge color", false, 10, 0, 2, 15, null, null }
                });

            migrationBuilder.UpdateData(
                table: "SectionItems",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "Description", "IconClass", "TemplateId", "Title", "Type" },
                values: new object[] { new DateTime(2024, 10, 14, 10, 0, 0, 0, DateTimeKind.Unspecified), "Main brand logo and text", "fas fa-image", 2, "Brand Logo", 1 });

            migrationBuilder.UpdateData(
                table: "SectionItems",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "Description", "IconClass", "TemplateId", "Title", "Type" },
                values: new object[] { new DateTime(2024, 10, 14, 10, 0, 0, 0, DateTimeKind.Unspecified), "Homepage menu item", "fas fa-home", 2, "Ana Sayfa", 24 });

            migrationBuilder.UpdateData(
                table: "SectionItems",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "Description", "IconClass", "TemplateId", "Title", "Type" },
                values: new object[] { new DateTime(2024, 10, 14, 10, 0, 0, 0, DateTimeKind.Unspecified), "Products mega menu with categories", "fas fa-shopping-bag", 2, "Ürünler", 24 });

            migrationBuilder.UpdateData(
                table: "SectionItems",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "Description", "IconClass", "SectionId", "SortOrder", "TemplateId", "Title", "Type" },
                values: new object[] { new DateTime(2024, 10, 14, 10, 0, 0, 0, DateTimeKind.Unspecified), "Services dropdown menu", "fas fa-cogs", 1, 4, 2, "Hizmetler", 24 });

            migrationBuilder.UpdateData(
                table: "SectionItems",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "Description", "IconClass", "SectionId", "SortOrder", "TemplateId", "Title", "Type" },
                values: new object[] { new DateTime(2024, 10, 14, 10, 0, 0, 0, DateTimeKind.Unspecified), "About us menu item", "fas fa-info-circle", 1, 5, 2, "Hakkımızda", 24 });

            migrationBuilder.UpdateData(
                table: "SectionItems",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedAt", "Description", "IconClass", "SectionId", "SortOrder", "TemplateId", "Title", "Type" },
                values: new object[] { new DateTime(2024, 10, 14, 10, 0, 0, 0, DateTimeKind.Unspecified), "Contact menu item", "fas fa-envelope", 1, 6, 2, "İletişim", 24 });

            migrationBuilder.UpdateData(
                table: "SectionItems",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedAt", "Description", "IconClass", "ParentSectionItemId", "SectionId", "TemplateId", "Title", "Type" },
                values: new object[] { new DateTime(2024, 10, 14, 10, 0, 0, 0, DateTimeKind.Unspecified), "Electronics category with featured products", "fas fa-laptop", 3, 1, 2, "Elektronik", 2 });

            migrationBuilder.UpdateData(
                table: "SectionItems",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreatedAt", "Description", "IconClass", "ParentSectionItemId", "SectionId", "TemplateId", "Title", "Type" },
                values: new object[] { new DateTime(2024, 10, 14, 10, 0, 0, 0, DateTimeKind.Unspecified), "Fashion category with seasonal collections", "fas fa-tshirt", 3, 1, 2, "Giyim", 2 });

            migrationBuilder.UpdateData(
                table: "SectionItems",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "CreatedAt", "Description", "IconClass", "ParentSectionItemId", "SectionId", "SortOrder", "TemplateId", "Title", "Type" },
                values: new object[] { new DateTime(2024, 10, 14, 10, 0, 0, 0, DateTimeKind.Unspecified), "Home and lifestyle products", "fas fa-home", 3, 1, 3, 2, "Ev & Yaşam", 2 });

            migrationBuilder.UpdateData(
                table: "SectionItems",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "CreatedAt", "Description", "IconClass", "ParentSectionItemId", "SectionId", "SortOrder", "TemplateId", "Title", "Type" },
                values: new object[] { new DateTime(2024, 10, 14, 10, 0, 0, 0, DateTimeKind.Unspecified), "Desktop and laptop computers", "fas fa-desktop", 7, 1, 1, 2, "Bilgisayarlar", 3 });

            migrationBuilder.InsertData(
                table: "SectionItems",
                columns: new[] { "Id", "AllowRemove", "AllowReorder", "CreatedAt", "CreatedBy", "Description", "IconClass", "LinkedPageId", "ParentSectionItemId", "SectionId", "SortOrder", "Status", "TemplateId", "Title", "Type", "UpdatedAt", "UpdatedBy" },
                values: new object[,]
                {
                    { 11, true, true, new DateTime(2024, 10, 14, 10, 0, 0, 0, DateTimeKind.Unspecified), null, "Smartphones and accessories", "fas fa-mobile-alt", null, 7, 1, 2, 1, 2, "Telefonlar", 3, null, null },
                    { 12, true, true, new DateTime(2024, 10, 14, 10, 0, 0, 0, DateTimeKind.Unspecified), null, "Audio and video equipment", "fas fa-headphones", null, 7, 1, 3, 1, 2, "Ses & Görüntü", 3, null, null },
                    { 13, true, true, new DateTime(2024, 10, 14, 10, 0, 0, 0, DateTimeKind.Unspecified), null, "Women's fashion and accessories", "fas fa-female", null, 8, 1, 1, 1, 2, "Kadın", 3, null, null },
                    { 14, true, true, new DateTime(2024, 10, 14, 10, 0, 0, 0, DateTimeKind.Unspecified), null, "Men's fashion and accessories", "fas fa-male", null, 8, 1, 2, 1, 2, "Erkek", 3, null, null },
                    { 15, true, true, new DateTime(2024, 10, 14, 10, 0, 0, 0, DateTimeKind.Unspecified), null, "Children's clothing and accessories", "fas fa-child", null, 8, 1, 3, 1, 2, "Çocuk", 3, null, null },
                    { 16, true, true, new DateTime(2024, 10, 14, 10, 0, 0, 0, DateTimeKind.Unspecified), null, "Professional web design services", "fas fa-paint-brush", null, 4, 1, 1, 1, 2, "Web Tasarım", 4, null, null },
                    { 17, true, true, new DateTime(2024, 10, 14, 10, 0, 0, 0, DateTimeKind.Unspecified), null, "E-commerce solutions and development", "fas fa-shopping-cart", null, 4, 1, 2, 1, 2, "E-Ticaret", 4, null, null },
                    { 18, true, true, new DateTime(2024, 10, 14, 10, 0, 0, 0, DateTimeKind.Unspecified), null, "Digital marketing and SEO services", "fas fa-chart-line", null, 4, 1, 3, 1, 2, "Dijital Pazarlama", 4, null, null },
                    { 19, true, true, new DateTime(2024, 10, 14, 10, 0, 0, 0, DateTimeKind.Unspecified), null, "24/7 technical support services", "fas fa-life-ring", null, 4, 1, 4, 1, 2, "Teknik Destek", 4, null, null },
                    { 20, true, true, new DateTime(2024, 10, 14, 10, 0, 0, 0, DateTimeKind.Unspecified), null, "Limited time special offers and deals", "fas fa-fire", null, 3, 1, 4, 1, 2, "Özel Kampanya", 5, null, null }
                });

            migrationBuilder.InsertData(
                table: "SectionItemFieldTranslations",
                columns: new[] { "Id", "CreatedAt", "CreatedBy", "Description", "Label", "LanguageId", "Placeholder", "SectionItemFieldId", "Status", "UpdatedAt", "UpdatedBy" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 10, 14, 10, 0, 0, 0, DateTimeKind.Unspecified), null, "Navbar için logo resmi yükleyin", "Logo Resmi", 1, "Logo resminizi yükleyin", 1, 0, null, null },
                    { 2, new DateTime(2024, 10, 14, 10, 0, 0, 0, DateTimeKind.Unspecified), null, "Logo yerine gösterilecek metin", "Logo Metni", 1, "Logo metnini girin", 2, 0, null, null },
                    { 3, new DateTime(2024, 10, 14, 10, 0, 0, 0, DateTimeKind.Unspecified), null, "Menü öğesinin başlığı", "Menü Başlığı", 1, "Menü başlığını girin", 3, 0, null, null },
                    { 4, new DateTime(2024, 10, 14, 10, 0, 0, 0, DateTimeKind.Unspecified), null, "Menü öğesinin yönlendirileceği URL", "Menü URL'si", 1, "Menü URL'sini girin (dropdown'lar için opsiyonel)", 4, 0, null, null },
                    { 5, new DateTime(2024, 10, 14, 10, 0, 0, 0, DateTimeKind.Unspecified), null, "Menü öğesi için ikon sınıfı", "Menü İkonu", 1, "İkon sınıfını girin (örn: fas fa-home)", 5, 0, null, null },
                    { 6, new DateTime(2024, 10, 14, 10, 0, 0, 0, DateTimeKind.Unspecified), null, "Mega menü için açıklama metni", "Menü Açıklaması", 1, "Mega menü açıklamasını girin", 6, 0, null, null },
                    { 7, new DateTime(2024, 10, 14, 10, 0, 0, 0, DateTimeKind.Unspecified), null, "Mega menü için öne çıkan resim", "Öne Çıkan Resim", 1, "Öne çıkan resim yükleyin", 7, 0, null, null },
                    { 8, new DateTime(2024, 10, 14, 10, 0, 0, 0, DateTimeKind.Unspecified), null, "Bu öğeyi öne çıkan olarak işaretle", "Öne Çıkan", 1, "Öne çıkan öğe olarak işaretle", 8, 0, null, null },
                    { 9, new DateTime(2024, 10, 14, 10, 0, 0, 0, DateTimeKind.Unspecified), null, "Menü öğesi için rozet metni", "Rozet Metni", 1, "Rozet metnini girin (örn: YENİ, POPÜLER)", 9, 0, null, null },
                    { 10, new DateTime(2024, 10, 14, 10, 0, 0, 0, DateTimeKind.Unspecified), null, "Rozet için renk seçimi", "Rozet Rengi", 1, "Rozet rengini seçin", 10, 0, null, null },
                    { 11, new DateTime(2024, 10, 14, 10, 0, 0, 0, DateTimeKind.Unspecified), null, "Upload logo image for navbar", "Logo Image", 2, "Upload your logo image", 1, 0, null, null },
                    { 12, new DateTime(2024, 10, 14, 10, 0, 0, 0, DateTimeKind.Unspecified), null, "Text to display instead of logo", "Logo Text", 2, "Enter logo text", 2, 0, null, null },
                    { 13, new DateTime(2024, 10, 14, 10, 0, 0, 0, DateTimeKind.Unspecified), null, "Title of the menu item", "Menu Title", 2, "Enter menu title", 3, 0, null, null },
                    { 14, new DateTime(2024, 10, 14, 10, 0, 0, 0, DateTimeKind.Unspecified), null, "URL where the menu item should redirect", "Menu URL", 2, "Enter menu URL (optional for dropdowns)", 4, 0, null, null },
                    { 15, new DateTime(2024, 10, 14, 10, 0, 0, 0, DateTimeKind.Unspecified), null, "Icon class for the menu item", "Menu Icon", 2, "Enter icon class (e.g., fas fa-home)", 5, 0, null, null },
                    { 16, new DateTime(2024, 10, 14, 10, 0, 0, 0, DateTimeKind.Unspecified), null, "Description text for mega menu", "Menu Description", 2, "Enter mega menu description", 6, 0, null, null },
                    { 17, new DateTime(2024, 10, 14, 10, 0, 0, 0, DateTimeKind.Unspecified), null, "Featured image for mega menu", "Featured Image", 2, "Upload featured image", 7, 0, null, null },
                    { 18, new DateTime(2024, 10, 14, 10, 0, 0, 0, DateTimeKind.Unspecified), null, "Mark this item as featured", "Is Featured", 2, "Mark as featured item", 8, 0, null, null },
                    { 19, new DateTime(2024, 10, 14, 10, 0, 0, 0, DateTimeKind.Unspecified), null, "Badge text for menu item", "Badge Text", 2, "Enter badge text (e.g., NEW, HOT)", 9, 0, null, null },
                    { 20, new DateTime(2024, 10, 14, 10, 0, 0, 0, DateTimeKind.Unspecified), null, "Color selection for badge", "Badge Color", 2, "Select badge color", 10, 0, null, null }
                });

            migrationBuilder.InsertData(
                table: "SectionItemFieldValues",
                columns: new[] { "Id", "CreatedAt", "CreatedBy", "JsonValue", "SectionItemFieldId", "SectionItemId", "Status", "UpdatedAt", "UpdatedBy", "Value" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 10, 14, 10, 0, 0, 0, DateTimeKind.Unspecified), null, null, 1, 1, 0, null, null, "/images/logo.png" },
                    { 2, new DateTime(2024, 10, 14, 10, 0, 0, 0, DateTimeKind.Unspecified), null, null, 2, 1, 0, null, null, "PazarAtlası" },
                    { 3, new DateTime(2024, 10, 14, 10, 0, 0, 0, DateTimeKind.Unspecified), null, null, 3, 2, 0, null, null, "Ana Sayfa" },
                    { 4, new DateTime(2024, 10, 14, 10, 0, 0, 0, DateTimeKind.Unspecified), null, null, 4, 2, 0, null, null, "/" },
                    { 5, new DateTime(2024, 10, 14, 10, 0, 0, 0, DateTimeKind.Unspecified), null, null, 5, 2, 0, null, null, "fas fa-home" },
                    { 6, new DateTime(2024, 10, 14, 10, 0, 0, 0, DateTimeKind.Unspecified), null, null, 3, 3, 0, null, null, "Ürünler" },
                    { 7, new DateTime(2024, 10, 14, 10, 0, 0, 0, DateTimeKind.Unspecified), null, null, 4, 3, 0, null, null, "/products" },
                    { 8, new DateTime(2024, 10, 14, 10, 0, 0, 0, DateTimeKind.Unspecified), null, null, 5, 3, 0, null, null, "fas fa-shopping-bag" },
                    { 9, new DateTime(2024, 10, 14, 10, 0, 0, 0, DateTimeKind.Unspecified), null, null, 6, 3, 0, null, null, "Geniş ürün yelpazemizi keşfedin" },
                    { 10, new DateTime(2024, 10, 14, 10, 0, 0, 0, DateTimeKind.Unspecified), null, null, 7, 3, 0, null, null, "/images/products-featured.jpg" },
                    { 11, new DateTime(2024, 10, 14, 10, 0, 0, 0, DateTimeKind.Unspecified), null, null, 3, 4, 0, null, null, "Hizmetler" },
                    { 12, new DateTime(2024, 10, 14, 10, 0, 0, 0, DateTimeKind.Unspecified), null, null, 4, 4, 0, null, null, "/services" },
                    { 13, new DateTime(2024, 10, 14, 10, 0, 0, 0, DateTimeKind.Unspecified), null, null, 5, 4, 0, null, null, "fas fa-cogs" },
                    { 14, new DateTime(2024, 10, 14, 10, 0, 0, 0, DateTimeKind.Unspecified), null, null, 6, 4, 0, null, null, "Profesyonel hizmetlerimiz" },
                    { 15, new DateTime(2024, 10, 14, 10, 0, 0, 0, DateTimeKind.Unspecified), null, null, 3, 7, 0, null, null, "Elektronik" },
                    { 16, new DateTime(2024, 10, 14, 10, 0, 0, 0, DateTimeKind.Unspecified), null, null, 4, 7, 0, null, null, "/products/electronics" },
                    { 17, new DateTime(2024, 10, 14, 10, 0, 0, 0, DateTimeKind.Unspecified), null, null, 5, 7, 0, null, null, "fas fa-laptop" },
                    { 18, new DateTime(2024, 10, 14, 10, 0, 0, 0, DateTimeKind.Unspecified), null, null, 6, 7, 0, null, null, "En son teknoloji ürünleri" },
                    { 19, new DateTime(2024, 10, 14, 10, 0, 0, 0, DateTimeKind.Unspecified), null, null, 7, 7, 0, null, null, "/images/electronics-category.jpg" },
                    { 20, new DateTime(2024, 10, 14, 10, 0, 0, 0, DateTimeKind.Unspecified), null, null, 8, 7, 0, null, null, "true" },
                    { 21, new DateTime(2024, 10, 14, 10, 0, 0, 0, DateTimeKind.Unspecified), null, null, 9, 7, 0, null, null, "YENİ" },
                    { 22, new DateTime(2024, 10, 14, 10, 0, 0, 0, DateTimeKind.Unspecified), null, null, 10, 7, 0, null, null, "success" },
                    { 23, new DateTime(2024, 10, 14, 10, 0, 0, 0, DateTimeKind.Unspecified), null, null, 3, 10, 0, null, null, "Bilgisayarlar" },
                    { 24, new DateTime(2024, 10, 14, 10, 0, 0, 0, DateTimeKind.Unspecified), null, null, 4, 10, 0, null, null, "/products/electronics/computers" },
                    { 25, new DateTime(2024, 10, 14, 10, 0, 0, 0, DateTimeKind.Unspecified), null, null, 5, 10, 0, null, null, "fas fa-desktop" },
                    { 26, new DateTime(2024, 10, 14, 10, 0, 0, 0, DateTimeKind.Unspecified), null, null, 6, 10, 0, null, null, "Masaüstü ve dizüstü bilgisayarlar" },
                    { 27, new DateTime(2024, 10, 14, 10, 0, 0, 0, DateTimeKind.Unspecified), null, null, 3, 16, 0, null, null, "Web Tasarım" },
                    { 28, new DateTime(2024, 10, 14, 10, 0, 0, 0, DateTimeKind.Unspecified), null, null, 4, 16, 0, null, null, "/services/web-design" },
                    { 29, new DateTime(2024, 10, 14, 10, 0, 0, 0, DateTimeKind.Unspecified), null, null, 5, 16, 0, null, null, "fas fa-paint-brush" },
                    { 30, new DateTime(2024, 10, 14, 10, 0, 0, 0, DateTimeKind.Unspecified), null, null, 6, 16, 0, null, null, "Modern ve kullanıcı dostu web siteleri" },
                    { 31, new DateTime(2024, 10, 14, 10, 0, 0, 0, DateTimeKind.Unspecified), null, null, 3, 20, 0, null, null, "Özel Kampanya" },
                    { 32, new DateTime(2024, 10, 14, 10, 0, 0, 0, DateTimeKind.Unspecified), null, null, 4, 20, 0, null, null, "/special-offers" },
                    { 33, new DateTime(2024, 10, 14, 10, 0, 0, 0, DateTimeKind.Unspecified), null, null, 5, 20, 0, null, null, "fas fa-fire" },
                    { 34, new DateTime(2024, 10, 14, 10, 0, 0, 0, DateTimeKind.Unspecified), null, null, 6, 20, 0, null, null, "Sınırlı süre özel fırsatlar" },
                    { 35, new DateTime(2024, 10, 14, 10, 0, 0, 0, DateTimeKind.Unspecified), null, null, 7, 20, 0, null, null, "/images/special-offers-banner.jpg" },
                    { 36, new DateTime(2024, 10, 14, 10, 0, 0, 0, DateTimeKind.Unspecified), null, null, 8, 20, 0, null, null, "true" },
                    { 37, new DateTime(2024, 10, 14, 10, 0, 0, 0, DateTimeKind.Unspecified), null, null, 9, 20, 0, null, null, "SICAK" },
                    { 38, new DateTime(2024, 10, 14, 10, 0, 0, 0, DateTimeKind.Unspecified), null, null, 10, 20, 0, null, null, "danger" }
                });

            migrationBuilder.InsertData(
                table: "SectionItemFieldValueTranslations",
                columns: new[] { "Id", "CreatedAt", "CreatedBy", "JsonValue", "LanguageId", "SectionItemFieldValueId", "Status", "UpdatedAt", "UpdatedBy", "Value" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 10, 14, 10, 0, 0, 0, DateTimeKind.Unspecified), null, null, 1, 2, 0, null, null, "PazarAtlası" },
                    { 2, new DateTime(2024, 10, 14, 10, 0, 0, 0, DateTimeKind.Unspecified), null, null, 2, 2, 0, null, null, "MarketAtlas" },
                    { 3, new DateTime(2024, 10, 14, 10, 0, 0, 0, DateTimeKind.Unspecified), null, null, 1, 3, 0, null, null, "Ana Sayfa" },
                    { 4, new DateTime(2024, 10, 14, 10, 0, 0, 0, DateTimeKind.Unspecified), null, null, 2, 3, 0, null, null, "Home" },
                    { 5, new DateTime(2024, 10, 14, 10, 0, 0, 0, DateTimeKind.Unspecified), null, null, 1, 6, 0, null, null, "Ürünler" },
                    { 6, new DateTime(2024, 10, 14, 10, 0, 0, 0, DateTimeKind.Unspecified), null, null, 2, 6, 0, null, null, "Products" },
                    { 7, new DateTime(2024, 10, 14, 10, 0, 0, 0, DateTimeKind.Unspecified), null, null, 1, 9, 0, null, null, "Geniş ürün yelpazemizi keşfedin" },
                    { 8, new DateTime(2024, 10, 14, 10, 0, 0, 0, DateTimeKind.Unspecified), null, null, 2, 9, 0, null, null, "Discover our wide range of products" },
                    { 9, new DateTime(2024, 10, 14, 10, 0, 0, 0, DateTimeKind.Unspecified), null, null, 1, 11, 0, null, null, "Hizmetler" },
                    { 10, new DateTime(2024, 10, 14, 10, 0, 0, 0, DateTimeKind.Unspecified), null, null, 2, 11, 0, null, null, "Services" },
                    { 11, new DateTime(2024, 10, 14, 10, 0, 0, 0, DateTimeKind.Unspecified), null, null, 1, 14, 0, null, null, "Profesyonel hizmetlerimiz" },
                    { 12, new DateTime(2024, 10, 14, 10, 0, 0, 0, DateTimeKind.Unspecified), null, null, 2, 14, 0, null, null, "Our professional services" },
                    { 13, new DateTime(2024, 10, 14, 10, 0, 0, 0, DateTimeKind.Unspecified), null, null, 1, 15, 0, null, null, "Elektronik" },
                    { 14, new DateTime(2024, 10, 14, 10, 0, 0, 0, DateTimeKind.Unspecified), null, null, 2, 15, 0, null, null, "Electronics" },
                    { 15, new DateTime(2024, 10, 14, 10, 0, 0, 0, DateTimeKind.Unspecified), null, null, 1, 18, 0, null, null, "En son teknoloji ürünleri" },
                    { 16, new DateTime(2024, 10, 14, 10, 0, 0, 0, DateTimeKind.Unspecified), null, null, 2, 18, 0, null, null, "Latest technology products" },
                    { 17, new DateTime(2024, 10, 14, 10, 0, 0, 0, DateTimeKind.Unspecified), null, null, 1, 21, 0, null, null, "YENİ" },
                    { 18, new DateTime(2024, 10, 14, 10, 0, 0, 0, DateTimeKind.Unspecified), null, null, 2, 21, 0, null, null, "NEW" },
                    { 19, new DateTime(2024, 10, 14, 10, 0, 0, 0, DateTimeKind.Unspecified), null, null, 1, 23, 0, null, null, "Bilgisayarlar" },
                    { 20, new DateTime(2024, 10, 14, 10, 0, 0, 0, DateTimeKind.Unspecified), null, null, 2, 23, 0, null, null, "Computers" },
                    { 21, new DateTime(2024, 10, 14, 10, 0, 0, 0, DateTimeKind.Unspecified), null, null, 1, 26, 0, null, null, "Masaüstü ve dizüstü bilgisayarlar" },
                    { 22, new DateTime(2024, 10, 14, 10, 0, 0, 0, DateTimeKind.Unspecified), null, null, 2, 26, 0, null, null, "Desktop and laptop computers" },
                    { 23, new DateTime(2024, 10, 14, 10, 0, 0, 0, DateTimeKind.Unspecified), null, null, 1, 27, 0, null, null, "Web Tasarım" },
                    { 24, new DateTime(2024, 10, 14, 10, 0, 0, 0, DateTimeKind.Unspecified), null, null, 2, 27, 0, null, null, "Web Design" },
                    { 25, new DateTime(2024, 10, 14, 10, 0, 0, 0, DateTimeKind.Unspecified), null, null, 1, 30, 0, null, null, "Modern ve kullanıcı dostu web siteleri" },
                    { 26, new DateTime(2024, 10, 14, 10, 0, 0, 0, DateTimeKind.Unspecified), null, null, 2, 30, 0, null, null, "Modern and user-friendly websites" },
                    { 27, new DateTime(2024, 10, 14, 10, 0, 0, 0, DateTimeKind.Unspecified), null, null, 1, 31, 0, null, null, "Özel Kampanya" },
                    { 28, new DateTime(2024, 10, 14, 10, 0, 0, 0, DateTimeKind.Unspecified), null, null, 2, 31, 0, null, null, "Special Campaign" },
                    { 29, new DateTime(2024, 10, 14, 10, 0, 0, 0, DateTimeKind.Unspecified), null, null, 1, 34, 0, null, null, "Sınırlı süre özel fırsatlar" },
                    { 30, new DateTime(2024, 10, 14, 10, 0, 0, 0, DateTimeKind.Unspecified), null, null, 2, 34, 0, null, null, "Limited time special offers" },
                    { 31, new DateTime(2024, 10, 14, 10, 0, 0, 0, DateTimeKind.Unspecified), null, null, 1, 37, 0, null, null, "SICAK" },
                    { 32, new DateTime(2024, 10, 14, 10, 0, 0, 0, DateTimeKind.Unspecified), null, null, 2, 37, 0, null, null, "HOT" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "SectionItemFieldTranslations",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "SectionItemFieldTranslations",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "SectionItemFieldTranslations",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "SectionItemFieldTranslations",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "SectionItemFieldTranslations",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "SectionItemFieldTranslations",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "SectionItemFieldTranslations",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "SectionItemFieldTranslations",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "SectionItemFieldTranslations",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "SectionItemFieldTranslations",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "SectionItemFieldTranslations",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "SectionItemFieldTranslations",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "SectionItemFieldTranslations",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "SectionItemFieldTranslations",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "SectionItemFieldTranslations",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "SectionItemFieldTranslations",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "SectionItemFieldTranslations",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "SectionItemFieldTranslations",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "SectionItemFieldTranslations",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "SectionItemFieldTranslations",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "SectionItemFieldValueTranslations",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "SectionItemFieldValueTranslations",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "SectionItemFieldValueTranslations",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "SectionItemFieldValueTranslations",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "SectionItemFieldValueTranslations",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "SectionItemFieldValueTranslations",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "SectionItemFieldValueTranslations",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "SectionItemFieldValueTranslations",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "SectionItemFieldValueTranslations",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "SectionItemFieldValueTranslations",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "SectionItemFieldValueTranslations",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "SectionItemFieldValueTranslations",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "SectionItemFieldValueTranslations",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "SectionItemFieldValueTranslations",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "SectionItemFieldValueTranslations",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "SectionItemFieldValueTranslations",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "SectionItemFieldValueTranslations",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "SectionItemFieldValueTranslations",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "SectionItemFieldValueTranslations",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "SectionItemFieldValueTranslations",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "SectionItemFieldValueTranslations",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "SectionItemFieldValueTranslations",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "SectionItemFieldValueTranslations",
                keyColumn: "Id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "SectionItemFieldValueTranslations",
                keyColumn: "Id",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "SectionItemFieldValueTranslations",
                keyColumn: "Id",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "SectionItemFieldValueTranslations",
                keyColumn: "Id",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "SectionItemFieldValueTranslations",
                keyColumn: "Id",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "SectionItemFieldValueTranslations",
                keyColumn: "Id",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "SectionItemFieldValueTranslations",
                keyColumn: "Id",
                keyValue: 29);

            migrationBuilder.DeleteData(
                table: "SectionItemFieldValueTranslations",
                keyColumn: "Id",
                keyValue: 30);

            migrationBuilder.DeleteData(
                table: "SectionItemFieldValueTranslations",
                keyColumn: "Id",
                keyValue: 31);

            migrationBuilder.DeleteData(
                table: "SectionItemFieldValueTranslations",
                keyColumn: "Id",
                keyValue: 32);

            migrationBuilder.DeleteData(
                table: "SectionItemFieldValues",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "SectionItemFieldValues",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "SectionItemFieldValues",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "SectionItemFieldValues",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "SectionItemFieldValues",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "SectionItemFieldValues",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "SectionItemFieldValues",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "SectionItemFieldValues",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "SectionItemFieldValues",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "SectionItemFieldValues",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "SectionItemFieldValues",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "SectionItemFieldValues",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "SectionItemFieldValues",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "SectionItemFieldValues",
                keyColumn: "Id",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "SectionItemFieldValues",
                keyColumn: "Id",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "SectionItemFieldValues",
                keyColumn: "Id",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "SectionItemFieldValues",
                keyColumn: "Id",
                keyValue: 29);

            migrationBuilder.DeleteData(
                table: "SectionItemFieldValues",
                keyColumn: "Id",
                keyValue: 32);

            migrationBuilder.DeleteData(
                table: "SectionItemFieldValues",
                keyColumn: "Id",
                keyValue: 33);

            migrationBuilder.DeleteData(
                table: "SectionItemFieldValues",
                keyColumn: "Id",
                keyValue: 35);

            migrationBuilder.DeleteData(
                table: "SectionItemFieldValues",
                keyColumn: "Id",
                keyValue: 36);

            migrationBuilder.DeleteData(
                table: "SectionItemFieldValues",
                keyColumn: "Id",
                keyValue: 38);

            migrationBuilder.DeleteData(
                table: "SectionItems",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "SectionItems",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "SectionItems",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "SectionItems",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "SectionItems",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "SectionItems",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "SectionItems",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "SectionItems",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "SectionItemFieldValues",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "SectionItemFieldValues",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "SectionItemFieldValues",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "SectionItemFieldValues",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "SectionItemFieldValues",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "SectionItemFieldValues",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "SectionItemFieldValues",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "SectionItemFieldValues",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "SectionItemFieldValues",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "SectionItemFieldValues",
                keyColumn: "Id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "SectionItemFieldValues",
                keyColumn: "Id",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "SectionItemFieldValues",
                keyColumn: "Id",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "SectionItemFieldValues",
                keyColumn: "Id",
                keyValue: 30);

            migrationBuilder.DeleteData(
                table: "SectionItemFieldValues",
                keyColumn: "Id",
                keyValue: 31);

            migrationBuilder.DeleteData(
                table: "SectionItemFieldValues",
                keyColumn: "Id",
                keyValue: 34);

            migrationBuilder.DeleteData(
                table: "SectionItemFieldValues",
                keyColumn: "Id",
                keyValue: 37);

            migrationBuilder.DeleteData(
                table: "SectionItemFields",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "SectionItemFields",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "SectionItemFields",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "SectionItemFields",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "SectionItemFields",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "SectionItemFields",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "SectionItemFields",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "SectionItemFields",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "SectionItemFields",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "SectionItemFields",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "SectionItems",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "SectionItems",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.UpdateData(
                table: "SectionItems",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "Description", "IconClass", "TemplateId", "Title", "Type" },
                values: new object[] { new DateTime(2024, 1, 1, 10, 0, 0, 0, DateTimeKind.Unspecified), "Main hero section title", "fas fa-heading", 1, "Hero Title", 6 });

            migrationBuilder.UpdateData(
                table: "SectionItems",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "Description", "IconClass", "TemplateId", "Title", "Type" },
                values: new object[] { new DateTime(2024, 1, 1, 10, 0, 0, 0, DateTimeKind.Unspecified), "Hero section description text", "fas fa-paragraph", 1, "Hero Description", 9 });

            migrationBuilder.UpdateData(
                table: "SectionItems",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "Description", "IconClass", "TemplateId", "Title", "Type" },
                values: new object[] { new DateTime(2024, 1, 1, 10, 0, 0, 0, DateTimeKind.Unspecified), null, null, 1, null, 5 });

            migrationBuilder.UpdateData(
                table: "SectionItems",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "Description", "IconClass", "SectionId", "SortOrder", "TemplateId", "Title", "Type" },
                values: new object[] { new DateTime(2024, 1, 1, 10, 0, 0, 0, DateTimeKind.Unspecified), null, null, 2, 1, 1, null, 10 });

            migrationBuilder.UpdateData(
                table: "SectionItems",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "Description", "IconClass", "SectionId", "SortOrder", "TemplateId", "Title", "Type" },
                values: new object[] { new DateTime(2024, 1, 1, 10, 0, 0, 0, DateTimeKind.Unspecified), null, null, 2, 2, 1, null, 10 });

            migrationBuilder.UpdateData(
                table: "SectionItems",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedAt", "Description", "IconClass", "SectionId", "SortOrder", "TemplateId", "Title", "Type" },
                values: new object[] { new DateTime(2024, 1, 1, 10, 0, 0, 0, DateTimeKind.Unspecified), null, null, 2, 3, 1, null, 10 });

            migrationBuilder.UpdateData(
                table: "SectionItems",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedAt", "Description", "IconClass", "ParentSectionItemId", "SectionId", "TemplateId", "Title", "Type" },
                values: new object[] { new DateTime(2024, 1, 1, 10, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, 3, 1, null, 6 });

            migrationBuilder.UpdateData(
                table: "SectionItems",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreatedAt", "Description", "IconClass", "ParentSectionItemId", "SectionId", "TemplateId", "Title", "Type" },
                values: new object[] { new DateTime(2024, 1, 1, 10, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, 3, 1, null, 15 });

            migrationBuilder.UpdateData(
                table: "SectionItems",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "CreatedAt", "Description", "IconClass", "ParentSectionItemId", "SectionId", "SortOrder", "TemplateId", "Title", "Type" },
                values: new object[] { new DateTime(2024, 1, 2, 10, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, 4, 1, 1, null, 6 });

            migrationBuilder.UpdateData(
                table: "SectionItems",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "CreatedAt", "Description", "IconClass", "ParentSectionItemId", "SectionId", "SortOrder", "TemplateId", "Title", "Type" },
                values: new object[] { new DateTime(2024, 1, 2, 10, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, 4, 2, 1, null, 18 });
        }
    }
}
