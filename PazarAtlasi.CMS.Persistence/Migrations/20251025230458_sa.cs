using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace PazarAtlasi.CMS.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class sa : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "SectionItemTranslations");

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "SectionItemTranslations",
                type: "nvarchar(300)",
                maxLength: 300,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(300)",
                oldMaxLength: 300,
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "TemplateTranslations",
                columns: new[] { "Id", "CreatedAt", "CreatedBy", "Description", "IsDeleted", "LanguageId", "Name", "Status", "TemplateId", "UpdatedAt", "UpdatedBy" },
                values: new object[,]
                {
                    { 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Sade ve temiz tasarımlı navigasyon çubuğu şablonu", false, 1, "Basit Navbar", 0, 1, null, null },
                    { 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Clean and simple navigation bar template", false, 2, "Simple Navbar", 0, 1, null, null },
                    { 3, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Sauberes und einfaches Navigationsleisten-Template", false, 3, "Einfache Navbar", 0, 1, null, null },
                    { 4, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Geniş kategoriler ve alt menülerle mega menü şablonu", false, 1, "Mega Menü Navbar", 0, 2, null, null },
                    { 5, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Mega menu template with wide categories and submenus", false, 2, "Mega Menu Navbar", 0, 2, null, null },
                    { 6, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Mega-Menü-Template mit breiten Kategorien und Untermenüs", false, 3, "Mega-Menü Navbar", 0, 2, null, null },
                    { 7, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Hizmet kategorilerini sekme şeklinde gösteren navbar şablonu", false, 1, "Hizmet Sekmeli Navbar", 0, 3, null, null },
                    { 8, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Navbar template displaying service categories as tabs", false, 2, "Service Tabs Navbar", 0, 3, null, null },
                    { 9, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Navbar-Template, das Servicekategorien als Tabs anzeigt", false, 3, "Service-Tabs Navbar", 0, 3, null, null },
                    { 10, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "İçerikleri kategorilere göre düzenleyen navbar şablonu", false, 1, "Kategorili Navbar", 0, 4, null, null },
                    { 11, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Navbar template organizing content by categories", false, 2, "Categorized Navbar", 0, 4, null, null },
                    { 12, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Navbar-Template, das Inhalte nach Kategorien organisiert", false, 3, "Kategorisierte Navbar", 0, 4, null, null },
                    { 13, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Temel ve esnek kullanım için varsayılan şablon", false, 1, "Varsayılan Şablon", 0, 5, null, null },
                    { 14, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Default template for basic and flexible usage", false, 2, "Default Template", 0, 5, null, null },
                    { 15, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Standard-Template für grundlegende und flexible Verwendung", false, 3, "Standard-Template", 0, 5, null, null },
                    { 16, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "İçerikleri sıralı bir şekilde gösteren şablon", false, 1, "Sıralı Şablon", 0, 6, null, null },
                    { 17, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Template displaying content in sequential order", false, 2, "Sequential Template", 0, 6, null, null },
                    { 18, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Template, das Inhalte in sequenzieller Reihenfolge anzeigt", false, 3, "Sequenzielles Template", 0, 6, null, null },
                    { 19, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "İçerikleri ızgara düzeninde gösteren şablon", false, 1, "Izgara Şablonu", 0, 7, null, null },
                    { 20, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Template displaying content in grid layout", false, 2, "Grid Template", 0, 7, null, null },
                    { 21, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Template, das Inhalte im Raster-Layout anzeigt", false, 3, "Raster-Template", 0, 7, null, null },
                    { 22, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Pinterest tarzı duvar düzeninde içerik gösteren şablon", false, 1, "Masonry Şablonu", 0, 8, null, null },
                    { 23, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Template displaying content in Pinterest-style wall layout", false, 2, "Masonry Template", 0, 8, null, null },
                    { 24, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Template, das Inhalte im Pinterest-Stil Wand-Layout anzeigt", false, 3, "Masonry-Template", 0, 8, null, null },
                    { 25, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "İçerikleri kaydırmalı karusel şeklinde gösteren şablon", false, 1, "Karusel Şablonu", 0, 9, null, null },
                    { 26, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Template displaying content in scrollable carousel format", false, 2, "Carousel Template", 0, 9, null, null },
                    { 27, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Template, das Inhalte im scrollbaren Karussell-Format anzeigt", false, 3, "Karusell-Template", 0, 9, null, null },
                    { 28, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "İçerikleri liste halinde düzenli şekilde gösteren şablon", false, 1, "Liste Şablonu", 0, 10, null, null },
                    { 29, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Template displaying content in organized list format", false, 2, "List Template", 0, 10, null, null },
                    { 30, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Template, das Inhalte im organisierten Listenformat anzeigt", false, 3, "Listen-Template", 0, 10, null, null },
                    { 31, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Tek bir içerik öğesini vurgulayan şablon", false, 1, "Tek Öğe Şablonu", 0, 11, null, null },
                    { 32, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Template highlighting a single content item", false, 2, "Single Item Template", 0, 11, null, null },
                    { 33, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Template, das einen einzelnen Inhaltsartikel hervorhebt", false, 3, "Einzelartikel-Template", 0, 11, null, null },
                    { 34, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Birden fazla içerik öğesini düzenli şekilde gösteren şablon", false, 1, "Çoklu Öğe Şablonu", 0, 12, null, null },
                    { 35, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Template displaying multiple content items in organized manner", false, 2, "Multi Item Template", 0, 12, null, null },
                    { 36, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Template, das mehrere Inhaltsartikel organisiert anzeigt", false, 3, "Mehrfachartikel-Template", 0, 12, null, null },
                    { 37, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "İçerikleri açılır-kapanır akordeon şeklinde gösteren şablon", false, 1, "Akordeon Şablonu", 0, 13, null, null },
                    { 38, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Template displaying content in expandable accordion format", false, 2, "Accordion Template", 0, 13, null, null },
                    { 39, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Template, das Inhalte im erweiterbaren Akkordeon-Format anzeigt", false, 3, "Akkordeon-Template", 0, 13, null, null },
                    { 40, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "İçerikleri sekmeler halinde organize eden şablon", false, 1, "Sekme Şablonu", 0, 14, null, null },
                    { 41, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Template organizing content into tabs", false, 2, "Tabs Template", 0, 14, null, null },
                    { 42, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Template, das Inhalte in Tabs organisiert", false, 3, "Tabs-Template", 0, 14, null, null }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "TemplateTranslations",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "TemplateTranslations",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "TemplateTranslations",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "TemplateTranslations",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "TemplateTranslations",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "TemplateTranslations",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "TemplateTranslations",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "TemplateTranslations",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "TemplateTranslations",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "TemplateTranslations",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "TemplateTranslations",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "TemplateTranslations",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "TemplateTranslations",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "TemplateTranslations",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "TemplateTranslations",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "TemplateTranslations",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "TemplateTranslations",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "TemplateTranslations",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "TemplateTranslations",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "TemplateTranslations",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "TemplateTranslations",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "TemplateTranslations",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "TemplateTranslations",
                keyColumn: "Id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "TemplateTranslations",
                keyColumn: "Id",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "TemplateTranslations",
                keyColumn: "Id",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "TemplateTranslations",
                keyColumn: "Id",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "TemplateTranslations",
                keyColumn: "Id",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "TemplateTranslations",
                keyColumn: "Id",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "TemplateTranslations",
                keyColumn: "Id",
                keyValue: 29);

            migrationBuilder.DeleteData(
                table: "TemplateTranslations",
                keyColumn: "Id",
                keyValue: 30);

            migrationBuilder.DeleteData(
                table: "TemplateTranslations",
                keyColumn: "Id",
                keyValue: 31);

            migrationBuilder.DeleteData(
                table: "TemplateTranslations",
                keyColumn: "Id",
                keyValue: 32);

            migrationBuilder.DeleteData(
                table: "TemplateTranslations",
                keyColumn: "Id",
                keyValue: 33);

            migrationBuilder.DeleteData(
                table: "TemplateTranslations",
                keyColumn: "Id",
                keyValue: 34);

            migrationBuilder.DeleteData(
                table: "TemplateTranslations",
                keyColumn: "Id",
                keyValue: 35);

            migrationBuilder.DeleteData(
                table: "TemplateTranslations",
                keyColumn: "Id",
                keyValue: 36);

            migrationBuilder.DeleteData(
                table: "TemplateTranslations",
                keyColumn: "Id",
                keyValue: 37);

            migrationBuilder.DeleteData(
                table: "TemplateTranslations",
                keyColumn: "Id",
                keyValue: 38);

            migrationBuilder.DeleteData(
                table: "TemplateTranslations",
                keyColumn: "Id",
                keyValue: 39);

            migrationBuilder.DeleteData(
                table: "TemplateTranslations",
                keyColumn: "Id",
                keyValue: 40);

            migrationBuilder.DeleteData(
                table: "TemplateTranslations",
                keyColumn: "Id",
                keyValue: 41);

            migrationBuilder.DeleteData(
                table: "TemplateTranslations",
                keyColumn: "Id",
                keyValue: 42);

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "SectionItemTranslations",
                type: "nvarchar(300)",
                maxLength: 300,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(300)",
                oldMaxLength: 300);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "SectionItemTranslations",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "SectionItemTranslations",
                keyColumn: "Id",
                keyValue: 1,
                column: "Name",
                value: "Hoş Geldiniz");

            migrationBuilder.UpdateData(
                table: "SectionItemTranslations",
                keyColumn: "Id",
                keyValue: 2,
                column: "Name",
                value: "Welcome");

            migrationBuilder.UpdateData(
                table: "SectionItemTranslations",
                keyColumn: "Id",
                keyValue: 3,
                column: "Name",
                value: "Alt Başlık");

            migrationBuilder.UpdateData(
                table: "SectionItemTranslations",
                keyColumn: "Id",
                keyValue: 4,
                column: "Name",
                value: "Subtitle");

            migrationBuilder.UpdateData(
                table: "SectionItemTranslations",
                keyColumn: "Id",
                keyValue: 5,
                column: "Name",
                value: "Keşfet");

            migrationBuilder.UpdateData(
                table: "SectionItemTranslations",
                keyColumn: "Id",
                keyValue: 6,
                column: "Name",
                value: "Explore");

            migrationBuilder.UpdateData(
                table: "SectionItemTranslations",
                keyColumn: "Id",
                keyValue: 7,
                column: "Name",
                value: "Öne Çıkan Ürün 1");

            migrationBuilder.UpdateData(
                table: "SectionItemTranslations",
                keyColumn: "Id",
                keyValue: 8,
                column: "Name",
                value: "Featured Product 1");

            migrationBuilder.UpdateData(
                table: "SectionItemTranslations",
                keyColumn: "Id",
                keyValue: 9,
                column: "Name",
                value: "Bülten");

            migrationBuilder.UpdateData(
                table: "SectionItemTranslations",
                keyColumn: "Id",
                keyValue: 10,
                column: "Name",
                value: "Newsletter");

            migrationBuilder.UpdateData(
                table: "SectionItemTranslations",
                keyColumn: "Id",
                keyValue: 11,
                column: "Name",
                value: "Blog");

            migrationBuilder.UpdateData(
                table: "SectionItemTranslations",
                keyColumn: "Id",
                keyValue: 12,
                column: "Name",
                value: "Blog");
        }
    }
}
