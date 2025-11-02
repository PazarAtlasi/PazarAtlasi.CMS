using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace PazarAtlasi.CMS.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AddContentAndContentSlugs : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Contents",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Contents",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Contents",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DropColumn(
                name: "Slug",
                table: "Pages");

            migrationBuilder.RenameColumn(
                name: "RelatedEntityId",
                table: "Contents",
                newName: "RelatedDataEntityType");

            migrationBuilder.RenameColumn(
                name: "RelatedDataId",
                table: "Contents",
                newName: "RelatedDataEntityId");

            migrationBuilder.AlterColumn<int>(
                name: "Status",
                table: "Contents",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldDefaultValue: 0);

            migrationBuilder.AlterColumn<bool>(
                name: "IsDeleted",
                table: "Contents",
                type: "bit",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldDefaultValue: false);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Contents",
                type: "nvarchar(2000)",
                maxLength: 2000,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(1000)",
                oldMaxLength: 1000);

            migrationBuilder.AddColumn<string>(
                name: "Author",
                table: "Contents",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MetaDescription",
                table: "Contents",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MetaKeywords",
                table: "Contents",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MetaTitle",
                table: "Contents",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SubDescription",
                table: "Contents",
                type: "nvarchar(1000)",
                maxLength: 1000,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Title",
                table: "Contents",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: true);

            migrationBuilder.CreateTable(
                name: "ContentSlugs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ContentId = table.Column<int>(type: "int", nullable: false),
                    Slug = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    LanguageId = table.Column<int>(type: "int", nullable: false),
                    Priority = table.Column<int>(type: "int", nullable: true),
                    IsCanonical = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<int>(type: "int", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<int>(type: "int", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContentSlugs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ContentSlugs_Contents_ContentId",
                        column: x => x.ContentId,
                        principalTable: "Contents",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ContentSlugs_Languages_LanguageId",
                        column: x => x.LanguageId,
                        principalTable: "Languages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 2, 21, 8, 26, 563, DateTimeKind.Utc).AddTicks(2773));

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 2, 21, 8, 26, 563, DateTimeKind.Utc).AddTicks(2778));

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 2, 21, 8, 26, 563, DateTimeKind.Utc).AddTicks(2782));

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 2, 21, 8, 26, 563, DateTimeKind.Utc).AddTicks(2784));

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 2, 21, 8, 26, 563, DateTimeKind.Utc).AddTicks(2787));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 2, 21, 8, 26, 564, DateTimeKind.Utc).AddTicks(2392));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 2, 21, 8, 26, 564, DateTimeKind.Utc).AddTicks(2401));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 2, 21, 8, 26, 564, DateTimeKind.Utc).AddTicks(2404));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 2, 21, 8, 26, 564, DateTimeKind.Utc).AddTicks(2405));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 2, 21, 8, 26, 564, DateTimeKind.Utc).AddTicks(2407));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 2, 21, 8, 26, 564, DateTimeKind.Utc).AddTicks(2410));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 2, 21, 8, 26, 564, DateTimeKind.Utc).AddTicks(2412));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 2, 21, 8, 26, 564, DateTimeKind.Utc).AddTicks(2413));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 2, 21, 8, 26, 564, DateTimeKind.Utc).AddTicks(2414));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 2, 21, 8, 26, 564, DateTimeKind.Utc).AddTicks(2416));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 2, 21, 8, 26, 564, DateTimeKind.Utc).AddTicks(2417));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 2, 21, 8, 26, 564, DateTimeKind.Utc).AddTicks(2419));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 2, 21, 8, 26, 564, DateTimeKind.Utc).AddTicks(2420));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 2, 21, 8, 26, 564, DateTimeKind.Utc).AddTicks(2421));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 2, 21, 8, 26, 564, DateTimeKind.Utc).AddTicks(2422));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 16,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 2, 21, 8, 26, 564, DateTimeKind.Utc).AddTicks(2424));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 17,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 2, 21, 8, 26, 564, DateTimeKind.Utc).AddTicks(2452));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 18,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 2, 21, 8, 26, 564, DateTimeKind.Utc).AddTicks(2454));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 19,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 2, 21, 8, 26, 564, DateTimeKind.Utc).AddTicks(2456));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 20,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 2, 21, 8, 26, 564, DateTimeKind.Utc).AddTicks(2458));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 21,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 2, 21, 8, 26, 564, DateTimeKind.Utc).AddTicks(2459));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 22,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 2, 21, 8, 26, 564, DateTimeKind.Utc).AddTicks(2460));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 23,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 2, 21, 8, 26, 564, DateTimeKind.Utc).AddTicks(2471));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 24,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 2, 21, 8, 26, 564, DateTimeKind.Utc).AddTicks(2473));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 25,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 2, 21, 8, 26, 564, DateTimeKind.Utc).AddTicks(2475));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 26,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 2, 21, 8, 26, 564, DateTimeKind.Utc).AddTicks(2476));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 27,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 2, 21, 8, 26, 564, DateTimeKind.Utc).AddTicks(2477));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 28,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 2, 21, 8, 26, 564, DateTimeKind.Utc).AddTicks(2479));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 29,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 2, 21, 8, 26, 564, DateTimeKind.Utc).AddTicks(2480));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 30,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 2, 21, 8, 26, 564, DateTimeKind.Utc).AddTicks(2489));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 31,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 2, 21, 8, 26, 564, DateTimeKind.Utc).AddTicks(2490));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 32,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 2, 21, 8, 26, 564, DateTimeKind.Utc).AddTicks(2491));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 33,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 2, 21, 8, 26, 564, DateTimeKind.Utc).AddTicks(2492));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 34,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 2, 21, 8, 26, 564, DateTimeKind.Utc).AddTicks(2494));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 35,
                columns: new[] { "Category", "CreatedAt", "Description", "Key", "Value" },
                values: new object[] { "Common", new DateTime(2025, 11, 2, 21, 8, 26, 564, DateTimeKind.Utc).AddTicks(2496), "Turkish translation for Common.All", "Common.All", "Tümü" });

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 36,
                columns: new[] { "Category", "CreatedAt", "Description", "Key", "Value" },
                values: new object[] { "Common", new DateTime(2025, 11, 2, 21, 8, 26, 564, DateTimeKind.Utc).AddTicks(2497), "Turkish translation for Common.Actions", "Common.Actions", "İşlemler" });

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 37,
                columns: new[] { "Category", "CreatedAt", "Description", "Key", "Value" },
                values: new object[] { "Common", new DateTime(2025, 11, 2, 21, 8, 26, 564, DateTimeKind.Utc).AddTicks(2499), "Turkish translation for Common.AreYouSure", "Common.AreYouSure", "Emin misiniz?" });

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 38,
                columns: new[] { "Category", "CreatedAt", "Description", "Key", "Value" },
                values: new object[] { "Common", new DateTime(2025, 11, 2, 21, 8, 26, 564, DateTimeKind.Utc).AddTicks(2500), "Turkish translation for Common.UnexpectedError", "Common.UnexpectedError", "Beklenmeyen bir hata oluştu" });

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 39,
                columns: new[] { "CreatedAt", "Description", "Key", "Value" },
                values: new object[] { new DateTime(2025, 11, 2, 21, 8, 26, 564, DateTimeKind.Utc).AddTicks(2504), "Turkish translation for Page.Title", "Page.Title", "Sayfa Başlığı" });

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 40,
                columns: new[] { "CreatedAt", "Description", "Key", "Value" },
                values: new object[] { new DateTime(2025, 11, 2, 21, 8, 26, 564, DateTimeKind.Utc).AddTicks(2506), "Turkish translation for Page.Content", "Page.Content", "Sayfa İçeriği" });

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 41,
                columns: new[] { "CreatedAt", "Description", "Key", "Value" },
                values: new object[] { new DateTime(2025, 11, 2, 21, 8, 26, 564, DateTimeKind.Utc).AddTicks(2507), "Turkish translation for Page.Description", "Page.Description", "Sayfa Açıklaması" });

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 42,
                columns: new[] { "CreatedAt", "Description", "Key", "Value" },
                values: new object[] { new DateTime(2025, 11, 2, 21, 8, 26, 564, DateTimeKind.Utc).AddTicks(2508), "Turkish translation for Page.Keywords", "Page.Keywords", "Anahtar Kelimeler" });

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 43,
                columns: new[] { "CreatedAt", "Description", "Key", "Value" },
                values: new object[] { new DateTime(2025, 11, 2, 21, 8, 26, 564, DateTimeKind.Utc).AddTicks(2509), "Turkish translation for Page.Author", "Page.Author", "Yazar" });

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 44,
                columns: new[] { "CreatedAt", "Description", "Key", "Value" },
                values: new object[] { new DateTime(2025, 11, 2, 21, 8, 26, 564, DateTimeKind.Utc).AddTicks(2510), "Turkish translation for Page.CreatedAt", "Page.CreatedAt", "Oluşturulma Tarihi" });

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 45,
                columns: new[] { "CreatedAt", "Description", "Key", "Value" },
                values: new object[] { new DateTime(2025, 11, 2, 21, 8, 26, 564, DateTimeKind.Utc).AddTicks(2512), "Turkish translation for Page.UpdatedAt", "Page.UpdatedAt", "Güncellenme Tarihi" });

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 46,
                columns: new[] { "CreatedAt", "Description", "Key", "Value" },
                values: new object[] { new DateTime(2025, 11, 2, 21, 8, 26, 564, DateTimeKind.Utc).AddTicks(2513), "Turkish translation for Page.Status", "Page.Status", "Durum" });

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 47,
                columns: new[] { "CreatedAt", "Description", "Key", "Value" },
                values: new object[] { new DateTime(2025, 11, 2, 21, 8, 26, 564, DateTimeKind.Utc).AddTicks(2514), "Turkish translation for Page.Type", "Page.Type", "Sayfa Tipi" });

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 48,
                columns: new[] { "CreatedAt", "Description", "Key", "Value" },
                values: new object[] { new DateTime(2025, 11, 2, 21, 8, 26, 564, DateTimeKind.Utc).AddTicks(2515), "Turkish translation for Page.Layout", "Page.Layout", "Düzen" });

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 49,
                columns: new[] { "CreatedAt", "Description", "Key", "Value" },
                values: new object[] { new DateTime(2025, 11, 2, 21, 8, 26, 564, DateTimeKind.Utc).AddTicks(2516), "Turkish translation for Page.Template", "Page.Template", "Şablon" });

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 50,
                columns: new[] { "Category", "CreatedAt", "Description", "Key", "Value" },
                values: new object[] { "Page", new DateTime(2025, 11, 2, 21, 8, 26, 564, DateTimeKind.Utc).AddTicks(2518), "Turkish translation for Page.SEO", "Page.SEO", "SEO Ayarları" });

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 51,
                columns: new[] { "Category", "CreatedAt", "Description", "Key", "Value" },
                values: new object[] { "Page", new DateTime(2025, 11, 2, 21, 8, 26, 564, DateTimeKind.Utc).AddTicks(2546), "Turkish translation for Page.Sections", "Page.Sections", "Bölümler" });

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 52,
                columns: new[] { "Category", "CreatedAt", "Description", "Key", "Value" },
                values: new object[] { "Page", new DateTime(2025, 11, 2, 21, 8, 26, 564, DateTimeKind.Utc).AddTicks(2547), "Turkish translation for Page.Items", "Page.Items", "Öğeler" });

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 53,
                columns: new[] { "Category", "CreatedAt", "Description", "Key", "Value" },
                values: new object[] { "Page", new DateTime(2025, 11, 2, 21, 8, 26, 564, DateTimeKind.Utc).AddTicks(2549), "Turkish translation for Page.Fields", "Page.Fields", "Alanlar" });

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 54,
                columns: new[] { "CreatedAt", "Description", "Key", "Value" },
                values: new object[] { new DateTime(2025, 11, 2, 21, 8, 26, 564, DateTimeKind.Utc).AddTicks(2552), "Turkish translation for Section.Name", "Section.Name", "Bölüm Adı" });

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 55,
                columns: new[] { "CreatedAt", "Description", "Key", "Value" },
                values: new object[] { new DateTime(2025, 11, 2, 21, 8, 26, 564, DateTimeKind.Utc).AddTicks(2554), "Turkish translation for Section.Type", "Section.Type", "Bölüm Tipi" });

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 56,
                columns: new[] { "CreatedAt", "Description", "Key", "Value" },
                values: new object[] { new DateTime(2025, 11, 2, 21, 8, 26, 564, DateTimeKind.Utc).AddTicks(2555), "Turkish translation for Section.Key", "Section.Key", "Bölüm Anahtarı" });

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 57,
                columns: new[] { "CreatedAt", "Description", "Key", "Value" },
                values: new object[] { new DateTime(2025, 11, 2, 21, 8, 26, 564, DateTimeKind.Utc).AddTicks(2557), "Turkish translation for Section.Order", "Section.Order", "Sıralama" });

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 58,
                columns: new[] { "CreatedAt", "Description", "Key", "Value" },
                values: new object[] { new DateTime(2025, 11, 2, 21, 8, 26, 564, DateTimeKind.Utc).AddTicks(2559), "Turkish translation for Section.Settings", "Section.Settings", "Ayarlar" });

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 59,
                columns: new[] { "CreatedAt", "Description", "Key", "Value" },
                values: new object[] { new DateTime(2025, 11, 2, 21, 8, 26, 564, DateTimeKind.Utc).AddTicks(2560), "Turkish translation for Section.Items", "Section.Items", "Öğeler" });

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 60,
                columns: new[] { "CreatedAt", "Description", "Key", "Value" },
                values: new object[] { new DateTime(2025, 11, 2, 21, 8, 26, 564, DateTimeKind.Utc).AddTicks(2561), "Turkish translation for Section.AddItem", "Section.AddItem", "Öğe Ekle" });

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 61,
                columns: new[] { "CreatedAt", "Description", "Key", "Value" },
                values: new object[] { new DateTime(2025, 11, 2, 21, 8, 26, 564, DateTimeKind.Utc).AddTicks(2563), "Turkish translation for Section.EditItems", "Section.EditItems", "Öğeleri Düzenle" });

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 62,
                columns: new[] { "CreatedAt", "Description", "Key", "Value" },
                values: new object[] { new DateTime(2025, 11, 2, 21, 8, 26, 564, DateTimeKind.Utc).AddTicks(2564), "Turkish translation for Section.Duplicate", "Section.Duplicate", "Kopyala" });

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 63,
                columns: new[] { "CreatedAt", "Description", "Key", "Value" },
                values: new object[] { new DateTime(2025, 11, 2, 21, 8, 26, 564, DateTimeKind.Utc).AddTicks(2565), "Turkish translation for Section.Remove", "Section.Remove", "Kaldır" });

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 64,
                columns: new[] { "CreatedAt", "Description", "Key", "Value" },
                values: new object[] { new DateTime(2025, 11, 2, 21, 8, 26, 564, DateTimeKind.Utc).AddTicks(2567), "Turkish translation for Section.Hero", "Section.Hero", "Ana Bölüm" });

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 65,
                columns: new[] { "CreatedAt", "Description", "Key", "Value" },
                values: new object[] { new DateTime(2025, 11, 2, 21, 8, 26, 564, DateTimeKind.Utc).AddTicks(2568), "Turkish translation for Section.Navbar", "Section.Navbar", "Navigasyon" });

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 66,
                columns: new[] { "Category", "CreatedAt", "Description", "Key", "Value" },
                values: new object[] { "Section", new DateTime(2025, 11, 2, 21, 8, 26, 564, DateTimeKind.Utc).AddTicks(2570), "Turkish translation for Section.Footer", "Section.Footer", "Alt Bilgi" });

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 67,
                columns: new[] { "Category", "CreatedAt", "Description", "Key", "Value" },
                values: new object[] { "Section", new DateTime(2025, 11, 2, 21, 8, 26, 564, DateTimeKind.Utc).AddTicks(2572), "Turkish translation for Section.Content", "Section.Content", "İçerik" });

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 68,
                columns: new[] { "Category", "CreatedAt", "Description", "Key", "Value" },
                values: new object[] { "Section", new DateTime(2025, 11, 2, 21, 8, 26, 564, DateTimeKind.Utc).AddTicks(2573), "Turkish translation for Section.Gallery", "Section.Gallery", "Galeri" });

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 69,
                columns: new[] { "Category", "CreatedAt", "Description", "Key", "Value" },
                values: new object[] { "Section", new DateTime(2025, 11, 2, 21, 8, 26, 564, DateTimeKind.Utc).AddTicks(2575), "Turkish translation for Section.Contact", "Section.Contact", "İletişim" });

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 70,
                columns: new[] { "CreatedAt", "Description", "Key", "Value" },
                values: new object[] { new DateTime(2025, 11, 2, 21, 8, 26, 564, DateTimeKind.Utc).AddTicks(2578), "Turkish translation for Validation.Required", "Validation.Required", "Bu alan zorunludur" });

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 71,
                columns: new[] { "CreatedAt", "Description", "Key", "Value" },
                values: new object[] { new DateTime(2025, 11, 2, 21, 8, 26, 564, DateTimeKind.Utc).AddTicks(2580), "Turkish translation for Validation.Email", "Validation.Email", "Geçerli bir e-posta adresi giriniz" });

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 72,
                columns: new[] { "CreatedAt", "Description", "Key", "Value" },
                values: new object[] { new DateTime(2025, 11, 2, 21, 8, 26, 564, DateTimeKind.Utc).AddTicks(2582), "Turkish translation for Validation.MinLength", "Validation.MinLength", "En az {0} karakter olmalıdır" });

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 73,
                columns: new[] { "CreatedAt", "Description", "Key", "Value" },
                values: new object[] { new DateTime(2025, 11, 2, 21, 8, 26, 564, DateTimeKind.Utc).AddTicks(2583), "Turkish translation for Validation.MaxLength", "Validation.MaxLength", "En fazla {0} karakter olmalıdır" });

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 74,
                columns: new[] { "CreatedAt", "Description", "Key", "Value" },
                values: new object[] { new DateTime(2025, 11, 2, 21, 8, 26, 564, DateTimeKind.Utc).AddTicks(2584), "Turkish translation for Validation.Range", "Validation.Range", "{0} ile {1} arasında olmalıdır" });

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 75,
                columns: new[] { "CreatedAt", "Description", "Key", "Value" },
                values: new object[] { new DateTime(2025, 11, 2, 21, 8, 26, 564, DateTimeKind.Utc).AddTicks(2586), "Turkish translation for Validation.Numeric", "Validation.Numeric", "Sayısal bir değer giriniz" });

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 76,
                columns: new[] { "Category", "CreatedAt", "Description", "Key", "Value" },
                values: new object[] { "Validation", new DateTime(2025, 11, 2, 21, 8, 26, 564, DateTimeKind.Utc).AddTicks(2587), "Turkish translation for Validation.Date", "Validation.Date", "Geçerli bir tarih giriniz" });

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 77,
                columns: new[] { "Category", "CreatedAt", "Description", "Key", "Value" },
                values: new object[] { "Validation", new DateTime(2025, 11, 2, 21, 8, 26, 564, DateTimeKind.Utc).AddTicks(2589), "Turkish translation for Validation.Url", "Validation.Url", "Geçerli bir URL giriniz" });

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 78,
                columns: new[] { "Category", "CreatedAt", "Description", "Key", "Value" },
                values: new object[] { "Validation", new DateTime(2025, 11, 2, 21, 8, 26, 564, DateTimeKind.Utc).AddTicks(2590), "Turkish translation for Validation.Phone", "Validation.Phone", "Geçerli bir telefon numarası giriniz" });

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 79,
                columns: new[] { "Category", "CreatedAt", "Description", "Key", "Value" },
                values: new object[] { "Validation", new DateTime(2025, 11, 2, 21, 8, 26, 564, DateTimeKind.Utc).AddTicks(2591), "Turkish translation for Validation.Password", "Validation.Password", "Şifre en az 8 karakter olmalıdır" });

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 80,
                columns: new[] { "CreatedAt", "Description", "Key", "Value" },
                values: new object[] { new DateTime(2025, 11, 2, 21, 8, 26, 564, DateTimeKind.Utc).AddTicks(2594), "Turkish translation for Navigation.Dashboard", "Navigation.Dashboard", "Dashboard" });

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 81,
                columns: new[] { "CreatedAt", "Description", "Key", "Value" },
                values: new object[] { new DateTime(2025, 11, 2, 21, 8, 26, 564, DateTimeKind.Utc).AddTicks(2596), "Turkish translation for Navigation.Announcements", "Navigation.Announcements", "Duyurular" });

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 82,
                columns: new[] { "CreatedAt", "Description", "Key", "Value" },
                values: new object[] { new DateTime(2025, 11, 2, 21, 8, 26, 564, DateTimeKind.Utc).AddTicks(2597), "Turkish translation for Navigation.Campaigns", "Navigation.Campaigns", "Kampanyalar" });

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 83,
                columns: new[] { "CreatedAt", "Description", "Key", "Value" },
                values: new object[] { new DateTime(2025, 11, 2, 21, 8, 26, 564, DateTimeKind.Utc).AddTicks(2626), "Turkish translation for Navigation.Content", "Navigation.Content", "İçerik" });

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 84,
                columns: new[] { "CreatedAt", "Description", "Key", "Value" },
                values: new object[] { new DateTime(2025, 11, 2, 21, 8, 26, 564, DateTimeKind.Utc).AddTicks(2628), "Turkish translation for Navigation.Pages", "Navigation.Pages", "Sayfalar" });

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 85,
                columns: new[] { "CreatedAt", "Description", "Key", "Value" },
                values: new object[] { new DateTime(2025, 11, 2, 21, 8, 26, 564, DateTimeKind.Utc).AddTicks(2629), "Turkish translation for Navigation.Sections", "Navigation.Sections", "Bölümler" });

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 86,
                columns: new[] { "CreatedAt", "Description", "Key", "Value" },
                values: new object[] { new DateTime(2025, 11, 2, 21, 8, 26, 564, DateTimeKind.Utc).AddTicks(2630), "Turkish translation for Navigation.Layouts", "Navigation.Layouts", "Düzenler" });

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 87,
                columns: new[] { "CreatedAt", "Description", "Key", "Value" },
                values: new object[] { new DateTime(2025, 11, 2, 21, 8, 26, 564, DateTimeKind.Utc).AddTicks(2632), "Turkish translation for Navigation.WebUrlManagement", "Navigation.WebUrlManagement", "Web URL Yönetimi" });

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 88,
                columns: new[] { "CreatedAt", "Description", "Key", "Value" },
                values: new object[] { new DateTime(2025, 11, 2, 21, 8, 26, 564, DateTimeKind.Utc).AddTicks(2633), "Turkish translation for Navigation.News", "Navigation.News", "Haberler" });

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 89,
                columns: new[] { "CreatedAt", "Description", "Key", "Value" },
                values: new object[] { new DateTime(2025, 11, 2, 21, 8, 26, 564, DateTimeKind.Utc).AddTicks(2634), "Turkish translation for Navigation.Blog", "Navigation.Blog", "Blog" });

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 90,
                columns: new[] { "CreatedAt", "Description", "Key", "Value" },
                values: new object[] { new DateTime(2025, 11, 2, 21, 8, 26, 564, DateTimeKind.Utc).AddTicks(2635), "Turkish translation for Navigation.Templates", "Navigation.Templates", "Şablonlar" });

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 91,
                columns: new[] { "CreatedAt", "Description", "Key", "Value" },
                values: new object[] { new DateTime(2025, 11, 2, 21, 8, 26, 564, DateTimeKind.Utc).AddTicks(2637), "Turkish translation for Navigation.SectionItems", "Navigation.SectionItems", "Bölüm Öğeleri" });

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 92,
                columns: new[] { "CreatedAt", "Description", "Key", "Value" },
                values: new object[] { new DateTime(2025, 11, 2, 21, 8, 26, 564, DateTimeKind.Utc).AddTicks(2638), "Turkish translation for Navigation.ECommerce", "Navigation.ECommerce", "E-Ticaret" });

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 93,
                columns: new[] { "CreatedAt", "Description", "Key", "Value" },
                values: new object[] { new DateTime(2025, 11, 2, 21, 8, 26, 564, DateTimeKind.Utc).AddTicks(2639), "Turkish translation for Navigation.Products", "Navigation.Products", "Ürünler" });

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 94,
                columns: new[] { "CreatedAt", "Description", "Key", "Value" },
                values: new object[] { new DateTime(2025, 11, 2, 21, 8, 26, 564, DateTimeKind.Utc).AddTicks(2641), "Turkish translation for Navigation.Categories", "Navigation.Categories", "Kategoriler" });

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 95,
                columns: new[] { "CreatedAt", "Description", "Key", "Value" },
                values: new object[] { new DateTime(2025, 11, 2, 21, 8, 26, 564, DateTimeKind.Utc).AddTicks(2642), "Turkish translation for Navigation.Orders", "Navigation.Orders", "Siparişler" });

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 96,
                columns: new[] { "CreatedAt", "Description", "Key", "Value" },
                values: new object[] { new DateTime(2025, 11, 2, 21, 8, 26, 564, DateTimeKind.Utc).AddTicks(2643), "Turkish translation for Navigation.Users", "Navigation.Users", "Kullanıcılar" });

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 97,
                columns: new[] { "CreatedAt", "Description", "Key", "Value" },
                values: new object[] { new DateTime(2025, 11, 2, 21, 8, 26, 564, DateTimeKind.Utc).AddTicks(2644), "Turkish translation for Navigation.ManageUsers", "Navigation.ManageUsers", "Kullanıcı Yönetimi" });

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 98,
                columns: new[] { "CreatedAt", "Description", "Key", "Value" },
                values: new object[] { new DateTime(2025, 11, 2, 21, 8, 26, 564, DateTimeKind.Utc).AddTicks(2646), "Turkish translation for Navigation.ManageRoles", "Navigation.ManageRoles", "Rol Yönetimi" });

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 99,
                columns: new[] { "CreatedAt", "Description", "Key", "Value" },
                values: new object[] { new DateTime(2025, 11, 2, 21, 8, 26, 564, DateTimeKind.Utc).AddTicks(2647), "Turkish translation for Navigation.ManagePermissions", "Navigation.ManagePermissions", "İzin Yönetimi" });

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 100,
                columns: new[] { "CreatedAt", "Description", "Key", "Value" },
                values: new object[] { new DateTime(2025, 11, 2, 21, 8, 26, 564, DateTimeKind.Utc).AddTicks(2648), "Turkish translation for Navigation.Analytics", "Navigation.Analytics", "Analitik" });

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 101,
                columns: new[] { "CreatedAt", "Description", "Key", "Value" },
                values: new object[] { new DateTime(2025, 11, 2, 21, 8, 26, 564, DateTimeKind.Utc).AddTicks(2649), "Turkish translation for Navigation.Settings", "Navigation.Settings", "Ayarlar" });

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 102,
                columns: new[] { "CreatedAt", "Description", "Key", "Value" },
                values: new object[] { new DateTime(2025, 11, 2, 21, 8, 26, 564, DateTimeKind.Utc).AddTicks(2651), "Turkish translation for Navigation.GeneralSettings", "Navigation.GeneralSettings", "Genel Ayarlar" });

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 103,
                columns: new[] { "CreatedAt", "Description", "Key", "Value" },
                values: new object[] { new DateTime(2025, 11, 2, 21, 8, 26, 564, DateTimeKind.Utc).AddTicks(2652), "Turkish translation for Navigation.Countries", "Navigation.Countries", "Ülkeler" });

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 104,
                columns: new[] { "Category", "CreatedAt", "Description", "Key", "Value" },
                values: new object[] { "Navigation", new DateTime(2025, 11, 2, 21, 8, 26, 564, DateTimeKind.Utc).AddTicks(2653), "Turkish translation for Navigation.Languages", "Navigation.Languages", "Diller" });

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 105,
                columns: new[] { "Category", "CreatedAt", "Description", "Key", "Value" },
                values: new object[] { "Navigation", new DateTime(2025, 11, 2, 21, 8, 26, 564, DateTimeKind.Utc).AddTicks(2654), "Turkish translation for Navigation.Localization", "Navigation.Localization", "Lokalizasyon" });

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 106,
                columns: new[] { "Category", "CreatedAt", "Description", "Key", "Value" },
                values: new object[] { "Navigation", new DateTime(2025, 11, 2, 21, 8, 26, 564, DateTimeKind.Utc).AddTicks(2656), "Turkish translation for Navigation.Profile", "Navigation.Profile", "Profil" });

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 107,
                columns: new[] { "Category", "CreatedAt", "Description", "Key", "Value" },
                values: new object[] { "Navigation", new DateTime(2025, 11, 2, 21, 8, 26, 564, DateTimeKind.Utc).AddTicks(2657), "Turkish translation for Navigation.Help", "Navigation.Help", "Yardım" });

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 108,
                columns: new[] { "Category", "CreatedAt", "Description", "Key", "Value" },
                values: new object[] { "Navigation", new DateTime(2025, 11, 2, 21, 8, 26, 564, DateTimeKind.Utc).AddTicks(2658), "Turkish translation for Navigation.Logout", "Navigation.Logout", "Çıkış" });

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 109,
                columns: new[] { "Category", "CreatedAt", "Description", "Key", "Value" },
                values: new object[] { "Language", new DateTime(2025, 11, 2, 21, 8, 26, 564, DateTimeKind.Utc).AddTicks(2661), "Turkish translation for Language.English", "Language.English", "İngilizce" });

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 110,
                columns: new[] { "Category", "CreatedAt", "Description", "Key", "Value" },
                values: new object[] { "Language", new DateTime(2025, 11, 2, 21, 8, 26, 564, DateTimeKind.Utc).AddTicks(2664), "Turkish translation for Language.Turkish", "Language.Turkish", "Türkçe" });

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 111,
                columns: new[] { "CreatedAt", "Description", "Key", "Value" },
                values: new object[] { new DateTime(2025, 11, 2, 21, 8, 26, 564, DateTimeKind.Utc).AddTicks(2667), "Turkish translation for Dashboard.Title", "Dashboard.Title", "Dashboard" });

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 112,
                columns: new[] { "CreatedAt", "Description", "Key", "Value" },
                values: new object[] { new DateTime(2025, 11, 2, 21, 8, 26, 564, DateTimeKind.Utc).AddTicks(2670), "Turkish translation for Dashboard.WelcomeMessage", "Dashboard.WelcomeMessage", "Hoş geldin! CMS analitiklerin ve son aktivitelerin özeti burada." });

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 113,
                columns: new[] { "CreatedAt", "Description", "Key", "Value" },
                values: new object[] { new DateTime(2025, 11, 2, 21, 8, 26, 564, DateTimeKind.Utc).AddTicks(2671), "Turkish translation for Dashboard.Last7Days", "Dashboard.Last7Days", "Son 7 gün" });

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 114,
                columns: new[] { "CreatedAt", "Description", "Key", "Value" },
                values: new object[] { new DateTime(2025, 11, 2, 21, 8, 26, 564, DateTimeKind.Utc).AddTicks(2673), "Turkish translation for Dashboard.Last30Days", "Dashboard.Last30Days", "Son 30 gün" });

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 115,
                columns: new[] { "CreatedAt", "Description", "Key", "Value" },
                values: new object[] { new DateTime(2025, 11, 2, 21, 8, 26, 564, DateTimeKind.Utc).AddTicks(2674), "Turkish translation for Dashboard.Last90Days", "Dashboard.Last90Days", "Son 90 gün" });

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 116,
                columns: new[] { "CreatedAt", "Description", "Key", "Value" },
                values: new object[] { new DateTime(2025, 11, 2, 21, 8, 26, 564, DateTimeKind.Utc).AddTicks(2675), "Turkish translation for Dashboard.TotalUsers", "Dashboard.TotalUsers", "Toplam Kullanıcı" });

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 117,
                columns: new[] { "CreatedAt", "Description", "Key", "Value" },
                values: new object[] { new DateTime(2025, 11, 2, 21, 8, 26, 564, DateTimeKind.Utc).AddTicks(2677), "Turkish translation for Dashboard.TotalRevenue", "Dashboard.TotalRevenue", "Toplam Gelir" });

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 118,
                columns: new[] { "CreatedAt", "Description", "Key", "Value" },
                values: new object[] { new DateTime(2025, 11, 2, 21, 8, 26, 564, DateTimeKind.Utc).AddTicks(2695), "Turkish translation for Dashboard.Products", "Dashboard.Products", "Ürünler" });

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 119,
                columns: new[] { "CreatedAt", "Description", "Key", "Value" },
                values: new object[] { new DateTime(2025, 11, 2, 21, 8, 26, 564, DateTimeKind.Utc).AddTicks(2697), "Turkish translation for Dashboard.SupportTickets", "Dashboard.SupportTickets", "Destek Biletleri" });

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 120,
                columns: new[] { "CreatedAt", "Description", "Key", "Value" },
                values: new object[] { new DateTime(2025, 11, 2, 21, 8, 26, 564, DateTimeKind.Utc).AddTicks(2698), "Turkish translation for Dashboard.FromLastMonth", "Dashboard.FromLastMonth", "geçen aydan" });

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 121,
                columns: new[] { "CreatedAt", "Description", "Key", "Value" },
                values: new object[] { new DateTime(2025, 11, 2, 21, 8, 26, 564, DateTimeKind.Utc).AddTicks(2699), "Turkish translation for Dashboard.SalesOverview", "Dashboard.SalesOverview", "Satış Genel Bakış" });

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 122,
                columns: new[] { "CreatedAt", "Description", "Key", "Value" },
                values: new object[] { new DateTime(2025, 11, 2, 21, 8, 26, 564, DateTimeKind.Utc).AddTicks(2700), "Turkish translation for Dashboard.Monthly", "Dashboard.Monthly", "Aylık" });

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 123,
                columns: new[] { "CreatedAt", "Description", "Key", "Value" },
                values: new object[] { new DateTime(2025, 11, 2, 21, 8, 26, 564, DateTimeKind.Utc).AddTicks(2701), "Turkish translation for Dashboard.ChartVisualization", "Dashboard.ChartVisualization", "Grafik görselleştirmesi burada olacak" });

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 124,
                columns: new[] { "CreatedAt", "Description", "Key", "Value" },
                values: new object[] { new DateTime(2025, 11, 2, 21, 8, 26, 564, DateTimeKind.Utc).AddTicks(2703), "Turkish translation for Dashboard.ThisYear", "Dashboard.ThisYear", "Bu Yıl" });

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 125,
                columns: new[] { "CreatedAt", "Description", "Key", "Value" },
                values: new object[] { new DateTime(2025, 11, 2, 21, 8, 26, 564, DateTimeKind.Utc).AddTicks(2704), "Turkish translation for Dashboard.LastYear", "Dashboard.LastYear", "Geçen Yıl" });

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 126,
                columns: new[] { "CreatedAt", "Description", "Key", "Value" },
                values: new object[] { new DateTime(2025, 11, 2, 21, 8, 26, 564, DateTimeKind.Utc).AddTicks(2705), "Turkish translation for Dashboard.RecentActivities", "Dashboard.RecentActivities", "Son Aktiviteler" });

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 127,
                columns: new[] { "CreatedAt", "Description", "Key", "Value" },
                values: new object[] { new DateTime(2025, 11, 2, 21, 8, 26, 564, DateTimeKind.Utc).AddTicks(2706), "Turkish translation for Dashboard.TopProducts", "Dashboard.TopProducts", "En İyi Ürünler" });

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 128,
                columns: new[] { "CreatedAt", "Description", "Key", "Value" },
                values: new object[] { new DateTime(2025, 11, 2, 21, 8, 26, 564, DateTimeKind.Utc).AddTicks(2708), "Turkish translation for Dashboard.Product", "Dashboard.Product", "Ürün" });

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 129,
                columns: new[] { "CreatedAt", "Description", "Key", "Value" },
                values: new object[] { new DateTime(2025, 11, 2, 21, 8, 26, 564, DateTimeKind.Utc).AddTicks(2709), "Turkish translation for Dashboard.Category", "Dashboard.Category", "Kategori" });

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 130,
                columns: new[] { "CreatedAt", "Description", "Key", "Value" },
                values: new object[] { new DateTime(2025, 11, 2, 21, 8, 26, 564, DateTimeKind.Utc).AddTicks(2711), "Turkish translation for Dashboard.Sales", "Dashboard.Sales", "Satışlar" });

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 131,
                columns: new[] { "CreatedAt", "Description", "Key", "Value" },
                values: new object[] { new DateTime(2025, 11, 2, 21, 8, 26, 564, DateTimeKind.Utc).AddTicks(2712), "Turkish translation for Dashboard.Status", "Dashboard.Status", "Durum" });

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 132,
                columns: new[] { "CreatedAt", "Description", "Key", "Value" },
                values: new object[] { new DateTime(2025, 11, 2, 21, 8, 26, 564, DateTimeKind.Utc).AddTicks(2714), "Turkish translation for Dashboard.LatestOrders", "Dashboard.LatestOrders", "Son Siparişler" });

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 133,
                columns: new[] { "CreatedAt", "Description", "Key", "Value" },
                values: new object[] { new DateTime(2025, 11, 2, 21, 8, 26, 564, DateTimeKind.Utc).AddTicks(2715), "Turkish translation for Dashboard.Today", "Dashboard.Today", "Bugün" });

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 134,
                columns: new[] { "Category", "CreatedAt", "Description", "Key", "LanguageId", "Value" },
                values: new object[] { "Dashboard", new DateTime(2025, 11, 2, 21, 8, 26, 564, DateTimeKind.Utc).AddTicks(2716), "Turkish translation for Dashboard.Yesterday", "Dashboard.Yesterday", 1, "Dün" });

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 135,
                columns: new[] { "Category", "CreatedAt", "Description", "Key", "LanguageId", "Value" },
                values: new object[] { "Dashboard", new DateTime(2025, 11, 2, 21, 8, 26, 564, DateTimeKind.Utc).AddTicks(2717), "Turkish translation for Dashboard.OrderId", "Dashboard.OrderId", 1, "Sipariş ID" });

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 136,
                columns: new[] { "Category", "CreatedAt", "Description", "Key", "LanguageId", "Value" },
                values: new object[] { "Dashboard", new DateTime(2025, 11, 2, 21, 8, 26, 564, DateTimeKind.Utc).AddTicks(2719), "Turkish translation for Dashboard.Customer", "Dashboard.Customer", 1, "Müşteri" });

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 137,
                columns: new[] { "Category", "CreatedAt", "Description", "Key", "LanguageId", "Value" },
                values: new object[] { "Dashboard", new DateTime(2025, 11, 2, 21, 8, 26, 564, DateTimeKind.Utc).AddTicks(2720), "Turkish translation for Dashboard.Date", "Dashboard.Date", 1, "Tarih" });

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 138,
                columns: new[] { "Category", "CreatedAt", "Description", "Key", "LanguageId", "Value" },
                values: new object[] { "Dashboard", new DateTime(2025, 11, 2, 21, 8, 26, 564, DateTimeKind.Utc).AddTicks(2721), "Turkish translation for Dashboard.Amount", "Dashboard.Amount", 1, "Tutar" });

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 139,
                columns: new[] { "Category", "CreatedAt", "Description", "Key", "LanguageId", "Value" },
                values: new object[] { "Localization", new DateTime(2025, 11, 2, 21, 8, 26, 564, DateTimeKind.Utc).AddTicks(2725), "Turkish translation for Localization.SystemDescription", "Localization.SystemDescription", 1, "Sistem genelinde kullanılan metin çevirilerini yönetin" });

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 140,
                columns: new[] { "Category", "CreatedAt", "Description", "Key", "LanguageId", "Value" },
                values: new object[] { "Localization", new DateTime(2025, 11, 2, 21, 8, 26, 564, DateTimeKind.Utc).AddTicks(2728), "Turkish translation for Localization.Keys", "Localization.Keys", 1, "Lokalizasyon Anahtarları" });

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 141,
                columns: new[] { "Category", "CreatedAt", "Description", "Key", "LanguageId", "Value" },
                values: new object[] { "Localization", new DateTime(2025, 11, 2, 21, 8, 26, 564, DateTimeKind.Utc).AddTicks(2729), "Turkish translation for Localization.Key", "Localization.Key", 1, "Anahtar" });

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 142,
                columns: new[] { "Category", "CreatedAt", "Description", "Key", "LanguageId", "Value" },
                values: new object[] { "Localization", new DateTime(2025, 11, 2, 21, 8, 26, 564, DateTimeKind.Utc).AddTicks(2731), "Turkish translation for Localization.AddKey", "Localization.AddKey", 1, "Yeni Anahtar Ekle" });

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 143,
                columns: new[] { "Category", "CreatedAt", "Description", "Key", "LanguageId", "Value" },
                values: new object[] { "Localization", new DateTime(2025, 11, 2, 21, 8, 26, 564, DateTimeKind.Utc).AddTicks(2774), "Turkish translation for Localization.EditKey", "Localization.EditKey", 1, "Anahtar Düzenle" });

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 144,
                columns: new[] { "Category", "CreatedAt", "Description", "Key", "LanguageId", "Value" },
                values: new object[] { "Localization", new DateTime(2025, 11, 2, 21, 8, 26, 564, DateTimeKind.Utc).AddTicks(2776), "Turkish translation for Localization.KeyDetails", "Localization.KeyDetails", 1, "Anahtar Detayları" });

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 145,
                columns: new[] { "Category", "CreatedAt", "Description", "Key", "LanguageId", "Value" },
                values: new object[] { "Localization", new DateTime(2025, 11, 2, 21, 8, 26, 564, DateTimeKind.Utc).AddTicks(2778), "Turkish translation for Localization.AddKeyDescription", "Localization.AddKeyDescription", 1, "Yeni bir lokalizasyon anahtarı ve çevirilerini ekleyin" });

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 146,
                columns: new[] { "Category", "CreatedAt", "Description", "Key", "LanguageId", "Value" },
                values: new object[] { "Localization", new DateTime(2025, 11, 2, 21, 8, 26, 564, DateTimeKind.Utc).AddTicks(2779), "Turkish translation for Localization.EditKeyDescription", "Localization.EditKeyDescription", 1, "Mevcut lokalizasyon anahtarını ve çevirilerini düzenleyin" });

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 147,
                columns: new[] { "Category", "CreatedAt", "Description", "Key", "LanguageId", "Value" },
                values: new object[] { "Localization", new DateTime(2025, 11, 2, 21, 8, 26, 564, DateTimeKind.Utc).AddTicks(2780), "Turkish translation for Localization.KeyPlaceholder", "Localization.KeyPlaceholder", 1, "örn: Common.Save" });

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 148,
                columns: new[] { "Category", "CreatedAt", "Description", "Key", "LanguageId", "Value" },
                values: new object[] { "Localization", new DateTime(2025, 11, 2, 21, 8, 26, 564, DateTimeKind.Utc).AddTicks(2782), "Turkish translation for Localization.KeyHint", "Localization.KeyHint", 1, "Nokta ile ayrılmış hiyerarşik anahtar kullanın" });

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 149,
                columns: new[] { "Category", "CreatedAt", "Description", "Key", "LanguageId", "Value" },
                values: new object[] { "Localization", new DateTime(2025, 11, 2, 21, 8, 26, 564, DateTimeKind.Utc).AddTicks(2783), "Turkish translation for Localization.KeyReadonly", "Localization.KeyReadonly", 1, "Anahtar değiştirilemez" });

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 150,
                columns: new[] { "Category", "CreatedAt", "Description", "Key", "LanguageId", "Value" },
                values: new object[] { "Localization", new DateTime(2025, 11, 2, 21, 8, 26, 564, DateTimeKind.Utc).AddTicks(2784), "Turkish translation for Localization.Description", "Localization.Description", 1, "Açıklama" });

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 151,
                columns: new[] { "Category", "CreatedAt", "Description", "Key", "LanguageId", "Value" },
                values: new object[] { "Localization", new DateTime(2025, 11, 2, 21, 8, 26, 564, DateTimeKind.Utc).AddTicks(2786), "Turkish translation for Localization.DescriptionPlaceholder", "Localization.DescriptionPlaceholder", 1, "Bu anahtarın ne için kullanıldığını açıklayın" });

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 152,
                columns: new[] { "Category", "CreatedAt", "Description", "Key", "LanguageId", "Value" },
                values: new object[] { "Localization", new DateTime(2025, 11, 2, 21, 8, 26, 564, DateTimeKind.Utc).AddTicks(2788), "Turkish translation for Localization.SelectCategory", "Localization.SelectCategory", 1, "Kategori Seçin" });

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 153,
                columns: new[] { "Category", "CreatedAt", "Description", "Key", "LanguageId", "Value" },
                values: new object[] { "Localization", new DateTime(2025, 11, 2, 21, 8, 26, 564, DateTimeKind.Utc).AddTicks(2789), "Turkish translation for Localization.Translations", "Localization.Translations", 1, "Çeviriler" });

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 154,
                columns: new[] { "Category", "CreatedAt", "Description", "Key", "LanguageId", "Value" },
                values: new object[] { "Localization", new DateTime(2025, 11, 2, 21, 8, 26, 564, DateTimeKind.Utc).AddTicks(2790), "Turkish translation for Localization.TranslationPlaceholder", "Localization.TranslationPlaceholder", 1, "{0} dilinde çeviri girin" });

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 155,
                columns: new[] { "Category", "CreatedAt", "Description", "Key", "LanguageId", "Value" },
                values: new object[] { "Localization", new DateTime(2025, 11, 2, 21, 8, 26, 564, DateTimeKind.Utc).AddTicks(2792), "Turkish translation for Localization.Translated", "Localization.Translated", 1, "Çevrildi" });

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 156,
                columns: new[] { "Category", "CreatedAt", "Description", "Key", "LanguageId", "Value" },
                values: new object[] { "Localization", new DateTime(2025, 11, 2, 21, 8, 26, 564, DateTimeKind.Utc).AddTicks(2793), "Turkish translation for Localization.NotTranslated", "Localization.NotTranslated", 1, "Çevrilmedi" });

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 157,
                columns: new[] { "Category", "CreatedAt", "Description", "Key", "LanguageId", "Value" },
                values: new object[] { "Localization", new DateTime(2025, 11, 2, 21, 8, 26, 564, DateTimeKind.Utc).AddTicks(2794), "Turkish translation for Localization.LastUpdated", "Localization.LastUpdated", 1, "Son Güncelleme" });

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 158,
                columns: new[] { "Category", "CreatedAt", "Description", "Key", "LanguageId", "Value" },
                values: new object[] { "Localization", new DateTime(2025, 11, 2, 21, 8, 26, 564, DateTimeKind.Utc).AddTicks(2796), "Turkish translation for Localization.SearchPlaceholder", "Localization.SearchPlaceholder", 1, "Anahtar veya değer ara..." });

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 159,
                columns: new[] { "Category", "CreatedAt", "Description", "Key", "LanguageId", "Value" },
                values: new object[] { "Localization", new DateTime(2025, 11, 2, 21, 8, 26, 564, DateTimeKind.Utc).AddTicks(2797), "Turkish translation for Localization.ShowingResults", "Localization.ShowingResults", 1, "{0}-{1} / {2} sonuç gösteriliyor" });

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 160,
                columns: new[] { "Category", "CreatedAt", "Description", "Key", "LanguageId", "Value" },
                values: new object[] { "Localization", new DateTime(2025, 11, 2, 21, 8, 26, 564, DateTimeKind.Utc).AddTicks(2798), "Turkish translation for Localization.NoKeys", "Localization.NoKeys", 1, "Lokalizasyon anahtarı bulunamadı" });

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 161,
                columns: new[] { "Category", "CreatedAt", "Description", "Key", "LanguageId", "Value" },
                values: new object[] { "Localization", new DateTime(2025, 11, 2, 21, 8, 26, 564, DateTimeKind.Utc).AddTicks(2799), "Turkish translation for Localization.NoKeysDescription", "Localization.NoKeysDescription", 1, "Henüz hiç lokalizasyon anahtarı eklenmemiş" });

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 162,
                columns: new[] { "Category", "CreatedAt", "Description", "Key", "LanguageId", "Value" },
                values: new object[] { "Localization", new DateTime(2025, 11, 2, 21, 8, 26, 564, DateTimeKind.Utc).AddTicks(2800), "Turkish translation for Localization.AddFirstKey", "Localization.AddFirstKey", 1, "İlk Anahtarı Ekle" });

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 163,
                columns: new[] { "Category", "CreatedAt", "Description", "Key", "LanguageId", "Value" },
                values: new object[] { "Localization", new DateTime(2025, 11, 2, 21, 8, 26, 564, DateTimeKind.Utc).AddTicks(2802), "Turkish translation for Localization.DeleteConfirmation", "Localization.DeleteConfirmation", 1, "Bu anahtarı ve tüm çevirilerini silmek istediğinizden emin misiniz?" });

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 164,
                columns: new[] { "CreatedAt", "Description", "Key", "Value" },
                values: new object[] { new DateTime(2025, 11, 2, 21, 8, 26, 564, DateTimeKind.Utc).AddTicks(2806), "English translation for Common.Save", "Common.Save", "Save" });

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 165,
                columns: new[] { "CreatedAt", "Description", "Key", "Value" },
                values: new object[] { new DateTime(2025, 11, 2, 21, 8, 26, 564, DateTimeKind.Utc).AddTicks(2807), "English translation for Common.Cancel", "Common.Cancel", "Cancel" });

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 166,
                columns: new[] { "CreatedAt", "Description", "Key", "Value" },
                values: new object[] { new DateTime(2025, 11, 2, 21, 8, 26, 564, DateTimeKind.Utc).AddTicks(2809), "English translation for Common.Delete", "Common.Delete", "Delete" });

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 167,
                columns: new[] { "CreatedAt", "Description", "Key", "Value" },
                values: new object[] { new DateTime(2025, 11, 2, 21, 8, 26, 564, DateTimeKind.Utc).AddTicks(2810), "English translation for Common.Edit", "Common.Edit", "Edit" });

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 168,
                columns: new[] { "Category", "CreatedAt", "Description", "Key", "Value" },
                values: new object[] { "Common", new DateTime(2025, 11, 2, 21, 8, 26, 564, DateTimeKind.Utc).AddTicks(2811), "English translation for Common.Add", "Common.Add", "Add" });

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 169,
                columns: new[] { "Category", "CreatedAt", "Description", "Key", "Value" },
                values: new object[] { "Common", new DateTime(2025, 11, 2, 21, 8, 26, 564, DateTimeKind.Utc).AddTicks(2813), "English translation for Common.Update", "Common.Update", "Update" });

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 170,
                columns: new[] { "Category", "CreatedAt", "Description", "Key", "Value" },
                values: new object[] { "Common", new DateTime(2025, 11, 2, 21, 8, 26, 564, DateTimeKind.Utc).AddTicks(2814), "English translation for Common.Create", "Common.Create", "Create" });

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 171,
                columns: new[] { "Category", "CreatedAt", "Description", "Key", "Value" },
                values: new object[] { "Common", new DateTime(2025, 11, 2, 21, 8, 26, 564, DateTimeKind.Utc).AddTicks(2815), "English translation for Common.Remove", "Common.Remove", "Remove" });

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 172,
                columns: new[] { "Category", "CreatedAt", "Description", "Key", "Value" },
                values: new object[] { "Common", new DateTime(2025, 11, 2, 21, 8, 26, 564, DateTimeKind.Utc).AddTicks(2816), "English translation for Common.Search", "Common.Search", "Search" });

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 173,
                columns: new[] { "Category", "CreatedAt", "Description", "Key", "Value" },
                values: new object[] { "Common", new DateTime(2025, 11, 2, 21, 8, 26, 564, DateTimeKind.Utc).AddTicks(2817), "English translation for Common.Filter", "Common.Filter", "Filter" });

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 174,
                columns: new[] { "Category", "CreatedAt", "Description", "Key", "Value" },
                values: new object[] { "Common", new DateTime(2025, 11, 2, 21, 8, 26, 564, DateTimeKind.Utc).AddTicks(2819), "English translation for Common.Export", "Common.Export", "Export" });

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 175,
                columns: new[] { "Category", "CreatedAt", "Description", "Key", "Value" },
                values: new object[] { "Common", new DateTime(2025, 11, 2, 21, 8, 26, 564, DateTimeKind.Utc).AddTicks(2820), "English translation for Common.Import", "Common.Import", "Import" });

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 176,
                columns: new[] { "Category", "CreatedAt", "Description", "Key", "Value" },
                values: new object[] { "Common", new DateTime(2025, 11, 2, 21, 8, 26, 564, DateTimeKind.Utc).AddTicks(2821), "English translation for Common.Upload", "Common.Upload", "Upload" });

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 177,
                columns: new[] { "Category", "CreatedAt", "Description", "Key", "Value" },
                values: new object[] { "Common", new DateTime(2025, 11, 2, 21, 8, 26, 564, DateTimeKind.Utc).AddTicks(2822), "English translation for Common.Download", "Common.Download", "Download" });

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 178,
                columns: new[] { "Category", "CreatedAt", "Description", "Key", "Value" },
                values: new object[] { "Common", new DateTime(2025, 11, 2, 21, 8, 26, 564, DateTimeKind.Utc).AddTicks(2859), "English translation for Common.Preview", "Common.Preview", "Preview" });

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 179,
                columns: new[] { "Category", "CreatedAt", "Description", "Key", "Value" },
                values: new object[] { "Common", new DateTime(2025, 11, 2, 21, 8, 26, 564, DateTimeKind.Utc).AddTicks(2861), "English translation for Common.Publish", "Common.Publish", "Publish" });

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 180,
                columns: new[] { "Category", "CreatedAt", "Description", "Key", "Value" },
                values: new object[] { "Common", new DateTime(2025, 11, 2, 21, 8, 26, 564, DateTimeKind.Utc).AddTicks(2862), "English translation for Common.Draft", "Common.Draft", "Draft" });

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 181,
                columns: new[] { "Category", "CreatedAt", "Description", "Key", "Value" },
                values: new object[] { "Common", new DateTime(2025, 11, 2, 21, 8, 26, 564, DateTimeKind.Utc).AddTicks(2863), "English translation for Common.Active", "Common.Active", "Active" });

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 182,
                columns: new[] { "Category", "CreatedAt", "Description", "Key", "Value" },
                values: new object[] { "Common", new DateTime(2025, 11, 2, 21, 8, 26, 564, DateTimeKind.Utc).AddTicks(2864), "English translation for Common.Inactive", "Common.Inactive", "Inactive" });

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 183,
                columns: new[] { "Category", "CreatedAt", "Description", "Key", "Value" },
                values: new object[] { "Common", new DateTime(2025, 11, 2, 21, 8, 26, 564, DateTimeKind.Utc).AddTicks(2866), "English translation for Common.Yes", "Common.Yes", "Yes" });

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 184,
                columns: new[] { "Category", "CreatedAt", "Description", "Key", "Value" },
                values: new object[] { "Common", new DateTime(2025, 11, 2, 21, 8, 26, 564, DateTimeKind.Utc).AddTicks(2867), "English translation for Common.No", "Common.No", "No" });

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 185,
                columns: new[] { "Category", "CreatedAt", "Description", "Key", "Value" },
                values: new object[] { "Common", new DateTime(2025, 11, 2, 21, 8, 26, 564, DateTimeKind.Utc).AddTicks(2868), "English translation for Common.OK", "Common.OK", "OK" });

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 186,
                columns: new[] { "Category", "CreatedAt", "Description", "Key", "Value" },
                values: new object[] { "Common", new DateTime(2025, 11, 2, 21, 8, 26, 564, DateTimeKind.Utc).AddTicks(2869), "English translation for Common.Close", "Common.Close", "Close" });

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 187,
                columns: new[] { "Category", "CreatedAt", "Description", "Key", "Value" },
                values: new object[] { "Common", new DateTime(2025, 11, 2, 21, 8, 26, 564, DateTimeKind.Utc).AddTicks(2870), "English translation for Common.Back", "Common.Back", "Back" });

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 188,
                columns: new[] { "Category", "CreatedAt", "Description", "Key", "Value" },
                values: new object[] { "Common", new DateTime(2025, 11, 2, 21, 8, 26, 564, DateTimeKind.Utc).AddTicks(2872), "English translation for Common.Next", "Common.Next", "Next" });

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 189,
                columns: new[] { "Category", "CreatedAt", "Description", "Key", "Value" },
                values: new object[] { "Common", new DateTime(2025, 11, 2, 21, 8, 26, 564, DateTimeKind.Utc).AddTicks(2873), "English translation for Common.Previous", "Common.Previous", "Previous" });

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 190,
                columns: new[] { "Category", "CreatedAt", "Description", "Key", "Value" },
                values: new object[] { "Common", new DateTime(2025, 11, 2, 21, 8, 26, 564, DateTimeKind.Utc).AddTicks(2874), "English translation for Common.Loading", "Common.Loading", "Loading..." });

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 191,
                columns: new[] { "Category", "CreatedAt", "Description", "Key", "Value" },
                values: new object[] { "Common", new DateTime(2025, 11, 2, 21, 8, 26, 564, DateTimeKind.Utc).AddTicks(2875), "English translation for Common.Success", "Common.Success", "Success" });

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 192,
                columns: new[] { "Category", "CreatedAt", "Description", "Key", "Value" },
                values: new object[] { "Common", new DateTime(2025, 11, 2, 21, 8, 26, 564, DateTimeKind.Utc).AddTicks(2876), "English translation for Common.Error", "Common.Error", "Error" });

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 193,
                columns: new[] { "Category", "CreatedAt", "Description", "Key", "Value" },
                values: new object[] { "Common", new DateTime(2025, 11, 2, 21, 8, 26, 564, DateTimeKind.Utc).AddTicks(2877), "English translation for Common.Warning", "Common.Warning", "Warning" });

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 194,
                columns: new[] { "Category", "CreatedAt", "Description", "Key", "Value" },
                values: new object[] { "Common", new DateTime(2025, 11, 2, 21, 8, 26, 564, DateTimeKind.Utc).AddTicks(2878), "English translation for Common.Info", "Common.Info", "Info" });

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 195,
                columns: new[] { "Category", "CreatedAt", "Description", "Key", "Value" },
                values: new object[] { "Common", new DateTime(2025, 11, 2, 21, 8, 26, 564, DateTimeKind.Utc).AddTicks(2880), "English translation for Common.Refresh", "Common.Refresh", "Refresh" });

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 196,
                columns: new[] { "Category", "CreatedAt", "Description", "Key", "Value" },
                values: new object[] { "Common", new DateTime(2025, 11, 2, 21, 8, 26, 564, DateTimeKind.Utc).AddTicks(2881), "English translation for Common.Settings", "Common.Settings", "Settings" });

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 197,
                columns: new[] { "Category", "CreatedAt", "Description", "Key", "Value" },
                values: new object[] { "Common", new DateTime(2025, 11, 2, 21, 8, 26, 564, DateTimeKind.Utc).AddTicks(2882), "English translation for Common.ViewAll", "Common.ViewAll", "View All" });

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 198,
                columns: new[] { "Category", "CreatedAt", "Description", "Key", "Value" },
                values: new object[] { "Common", new DateTime(2025, 11, 2, 21, 8, 26, 564, DateTimeKind.Utc).AddTicks(2883), "English translation for Common.All", "Common.All", "All" });

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 199,
                columns: new[] { "Category", "CreatedAt", "Description", "Key", "Value" },
                values: new object[] { "Common", new DateTime(2025, 11, 2, 21, 8, 26, 564, DateTimeKind.Utc).AddTicks(2884), "English translation for Common.Actions", "Common.Actions", "Actions" });

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 200,
                columns: new[] { "Category", "CreatedAt", "Description", "Key", "Value" },
                values: new object[] { "Common", new DateTime(2025, 11, 2, 21, 8, 26, 564, DateTimeKind.Utc).AddTicks(2886), "English translation for Common.AreYouSure", "Common.AreYouSure", "Are you sure?" });

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 201,
                columns: new[] { "Category", "CreatedAt", "Description", "Key", "Value" },
                values: new object[] { "Common", new DateTime(2025, 11, 2, 21, 8, 26, 564, DateTimeKind.Utc).AddTicks(2887), "English translation for Common.UnexpectedError", "Common.UnexpectedError", "An unexpected error occurred" });

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 202,
                columns: new[] { "Category", "CreatedAt", "Description", "Key", "Value" },
                values: new object[] { "Page", new DateTime(2025, 11, 2, 21, 8, 26, 564, DateTimeKind.Utc).AddTicks(2891), "English translation for Page.Title", "Page.Title", "Page Title" });

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 203,
                columns: new[] { "Category", "CreatedAt", "Description", "Key", "Value" },
                values: new object[] { "Page", new DateTime(2025, 11, 2, 21, 8, 26, 564, DateTimeKind.Utc).AddTicks(2892), "English translation for Page.Content", "Page.Content", "Page Content" });

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 204,
                columns: new[] { "Category", "CreatedAt", "Description", "Key", "Value" },
                values: new object[] { "Page", new DateTime(2025, 11, 2, 21, 8, 26, 564, DateTimeKind.Utc).AddTicks(2894), "English translation for Page.Description", "Page.Description", "Page Description" });

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 205,
                columns: new[] { "Category", "CreatedAt", "Description", "Key", "Value" },
                values: new object[] { "Page", new DateTime(2025, 11, 2, 21, 8, 26, 564, DateTimeKind.Utc).AddTicks(2895), "English translation for Page.Keywords", "Page.Keywords", "Keywords" });

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 206,
                columns: new[] { "Category", "CreatedAt", "Description", "Key", "Value" },
                values: new object[] { "Page", new DateTime(2025, 11, 2, 21, 8, 26, 564, DateTimeKind.Utc).AddTicks(2896), "English translation for Page.Author", "Page.Author", "Author" });

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 207,
                columns: new[] { "Category", "CreatedAt", "Description", "Key", "Value" },
                values: new object[] { "Page", new DateTime(2025, 11, 2, 21, 8, 26, 564, DateTimeKind.Utc).AddTicks(2897), "English translation for Page.CreatedAt", "Page.CreatedAt", "Created At" });

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 208,
                columns: new[] { "Category", "CreatedAt", "Description", "Key", "Value" },
                values: new object[] { "Page", new DateTime(2025, 11, 2, 21, 8, 26, 564, DateTimeKind.Utc).AddTicks(2899), "English translation for Page.UpdatedAt", "Page.UpdatedAt", "Updated At" });

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 209,
                columns: new[] { "Category", "CreatedAt", "Description", "Key", "Value" },
                values: new object[] { "Page", new DateTime(2025, 11, 2, 21, 8, 26, 564, DateTimeKind.Utc).AddTicks(2900), "English translation for Page.Status", "Page.Status", "Status" });

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 210,
                columns: new[] { "Category", "CreatedAt", "Description", "Key", "Value" },
                values: new object[] { "Page", new DateTime(2025, 11, 2, 21, 8, 26, 564, DateTimeKind.Utc).AddTicks(2901), "English translation for Page.Type", "Page.Type", "Page Type" });

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 211,
                columns: new[] { "Category", "CreatedAt", "Description", "Key", "Value" },
                values: new object[] { "Page", new DateTime(2025, 11, 2, 21, 8, 26, 564, DateTimeKind.Utc).AddTicks(2902), "English translation for Page.Layout", "Page.Layout", "Layout" });

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 212,
                columns: new[] { "Category", "CreatedAt", "Description", "Key", "Value" },
                values: new object[] { "Page", new DateTime(2025, 11, 2, 21, 8, 26, 564, DateTimeKind.Utc).AddTicks(2904), "English translation for Page.Template", "Page.Template", "Template" });

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 213,
                columns: new[] { "Category", "CreatedAt", "Description", "Key", "Value" },
                values: new object[] { "Page", new DateTime(2025, 11, 2, 21, 8, 26, 564, DateTimeKind.Utc).AddTicks(2905), "English translation for Page.SEO", "Page.SEO", "SEO Settings" });

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 214,
                columns: new[] { "Category", "CreatedAt", "Description", "Key" },
                values: new object[] { "Page", new DateTime(2025, 11, 2, 21, 8, 26, 564, DateTimeKind.Utc).AddTicks(2906), "English translation for Page.Sections", "Page.Sections" });

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 215,
                columns: new[] { "Category", "CreatedAt", "Description", "Key", "Value" },
                values: new object[] { "Page", new DateTime(2025, 11, 2, 21, 8, 26, 564, DateTimeKind.Utc).AddTicks(2907), "English translation for Page.Items", "Page.Items", "Items" });

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 216,
                columns: new[] { "Category", "CreatedAt", "Description", "Key", "Value" },
                values: new object[] { "Page", new DateTime(2025, 11, 2, 21, 8, 26, 564, DateTimeKind.Utc).AddTicks(2936), "English translation for Page.Fields", "Page.Fields", "Fields" });

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 217,
                columns: new[] { "Category", "CreatedAt", "Description", "Key", "Value" },
                values: new object[] { "Section", new DateTime(2025, 11, 2, 21, 8, 26, 564, DateTimeKind.Utc).AddTicks(2940), "English translation for Section.Name", "Section.Name", "Section Name" });

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 218,
                columns: new[] { "Category", "CreatedAt", "Description", "Key", "Value" },
                values: new object[] { "Section", new DateTime(2025, 11, 2, 21, 8, 26, 564, DateTimeKind.Utc).AddTicks(2941), "English translation for Section.Type", "Section.Type", "Section Type" });

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 219,
                columns: new[] { "Category", "CreatedAt", "Description", "Key", "Value" },
                values: new object[] { "Section", new DateTime(2025, 11, 2, 21, 8, 26, 564, DateTimeKind.Utc).AddTicks(2943), "English translation for Section.Key", "Section.Key", "Section Key" });

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 220,
                columns: new[] { "Category", "CreatedAt", "Description", "Key", "Value" },
                values: new object[] { "Section", new DateTime(2025, 11, 2, 21, 8, 26, 564, DateTimeKind.Utc).AddTicks(2944), "English translation for Section.Order", "Section.Order", "Order" });

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 221,
                columns: new[] { "Category", "CreatedAt", "Description", "Key", "Value" },
                values: new object[] { "Section", new DateTime(2025, 11, 2, 21, 8, 26, 564, DateTimeKind.Utc).AddTicks(2945), "English translation for Section.Settings", "Section.Settings", "Settings" });

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 222,
                columns: new[] { "Category", "CreatedAt", "Description", "Key", "Value" },
                values: new object[] { "Section", new DateTime(2025, 11, 2, 21, 8, 26, 564, DateTimeKind.Utc).AddTicks(2947), "English translation for Section.Items", "Section.Items", "Items" });

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 223,
                columns: new[] { "Category", "CreatedAt", "Description", "Key", "Value" },
                values: new object[] { "Section", new DateTime(2025, 11, 2, 21, 8, 26, 564, DateTimeKind.Utc).AddTicks(2948), "English translation for Section.AddItem", "Section.AddItem", "Add Item" });

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 224,
                columns: new[] { "Category", "CreatedAt", "Description", "Key", "Value" },
                values: new object[] { "Section", new DateTime(2025, 11, 2, 21, 8, 26, 564, DateTimeKind.Utc).AddTicks(2950), "English translation for Section.EditItems", "Section.EditItems", "Edit Items" });

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 225,
                columns: new[] { "Category", "CreatedAt", "Description", "Key", "Value" },
                values: new object[] { "Section", new DateTime(2025, 11, 2, 21, 8, 26, 564, DateTimeKind.Utc).AddTicks(2951), "English translation for Section.Duplicate", "Section.Duplicate", "Duplicate" });

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 226,
                columns: new[] { "Category", "CreatedAt", "Description", "Key", "Value" },
                values: new object[] { "Section", new DateTime(2025, 11, 2, 21, 8, 26, 564, DateTimeKind.Utc).AddTicks(2952), "English translation for Section.Remove", "Section.Remove", "Remove" });

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 227,
                columns: new[] { "Category", "CreatedAt", "Description", "Key", "Value" },
                values: new object[] { "Section", new DateTime(2025, 11, 2, 21, 8, 26, 564, DateTimeKind.Utc).AddTicks(2954), "English translation for Section.Hero", "Section.Hero", "Hero Section" });

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 228,
                columns: new[] { "Category", "CreatedAt", "Description", "Key", "Value" },
                values: new object[] { "Section", new DateTime(2025, 11, 2, 21, 8, 26, 564, DateTimeKind.Utc).AddTicks(2955), "English translation for Section.Navbar", "Section.Navbar", "Navigation" });

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 229,
                columns: new[] { "Category", "CreatedAt", "Description", "Key", "Value" },
                values: new object[] { "Section", new DateTime(2025, 11, 2, 21, 8, 26, 564, DateTimeKind.Utc).AddTicks(2956), "English translation for Section.Footer", "Section.Footer", "Footer" });

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 230,
                columns: new[] { "Category", "CreatedAt", "Description", "Key", "Value" },
                values: new object[] { "Section", new DateTime(2025, 11, 2, 21, 8, 26, 564, DateTimeKind.Utc).AddTicks(2957), "English translation for Section.Content", "Section.Content", "Content" });

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 231,
                columns: new[] { "Category", "CreatedAt", "Description", "Key", "Value" },
                values: new object[] { "Section", new DateTime(2025, 11, 2, 21, 8, 26, 564, DateTimeKind.Utc).AddTicks(2958), "English translation for Section.Gallery", "Section.Gallery", "Gallery" });

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 232,
                columns: new[] { "Category", "CreatedAt", "Description", "Key", "Value" },
                values: new object[] { "Section", new DateTime(2025, 11, 2, 21, 8, 26, 564, DateTimeKind.Utc).AddTicks(2959), "English translation for Section.Contact", "Section.Contact", "Contact" });

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 233,
                columns: new[] { "Category", "CreatedAt", "Description", "Key", "Value" },
                values: new object[] { "Validation", new DateTime(2025, 11, 2, 21, 8, 26, 564, DateTimeKind.Utc).AddTicks(2963), "English translation for Validation.Required", "Validation.Required", "This field is required" });

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 234,
                columns: new[] { "Category", "CreatedAt", "Description", "Key", "Value" },
                values: new object[] { "Validation", new DateTime(2025, 11, 2, 21, 8, 26, 564, DateTimeKind.Utc).AddTicks(2965), "English translation for Validation.Email", "Validation.Email", "Please enter a valid email address" });

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 235,
                columns: new[] { "Category", "CreatedAt", "Description", "Key", "Value" },
                values: new object[] { "Validation", new DateTime(2025, 11, 2, 21, 8, 26, 564, DateTimeKind.Utc).AddTicks(2966), "English translation for Validation.MinLength", "Validation.MinLength", "Must be at least {0} characters" });

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 236,
                columns: new[] { "Category", "CreatedAt", "Description", "Key", "Value" },
                values: new object[] { "Validation", new DateTime(2025, 11, 2, 21, 8, 26, 564, DateTimeKind.Utc).AddTicks(2967), "English translation for Validation.MaxLength", "Validation.MaxLength", "Must be at most {0} characters" });

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 237,
                columns: new[] { "Category", "CreatedAt", "Description", "Key", "Value" },
                values: new object[] { "Validation", new DateTime(2025, 11, 2, 21, 8, 26, 564, DateTimeKind.Utc).AddTicks(2969), "English translation for Validation.Range", "Validation.Range", "Must be between {0} and {1}" });

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 238,
                columns: new[] { "Category", "CreatedAt", "Description", "Key", "Value" },
                values: new object[] { "Validation", new DateTime(2025, 11, 2, 21, 8, 26, 564, DateTimeKind.Utc).AddTicks(2970), "English translation for Validation.Numeric", "Validation.Numeric", "Please enter a numeric value" });

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 239,
                columns: new[] { "Category", "CreatedAt", "Description", "Key", "Value" },
                values: new object[] { "Validation", new DateTime(2025, 11, 2, 21, 8, 26, 564, DateTimeKind.Utc).AddTicks(2972), "English translation for Validation.Date", "Validation.Date", "Please enter a valid date" });

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 240,
                columns: new[] { "Category", "CreatedAt", "Description", "Key", "Value" },
                values: new object[] { "Validation", new DateTime(2025, 11, 2, 21, 8, 26, 564, DateTimeKind.Utc).AddTicks(2973), "English translation for Validation.Url", "Validation.Url", "Please enter a valid URL" });

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 241,
                columns: new[] { "Category", "CreatedAt", "Description", "Key", "Value" },
                values: new object[] { "Validation", new DateTime(2025, 11, 2, 21, 8, 26, 564, DateTimeKind.Utc).AddTicks(2974), "English translation for Validation.Phone", "Validation.Phone", "Please enter a valid phone number" });

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 242,
                columns: new[] { "Category", "CreatedAt", "Description", "Key", "Value" },
                values: new object[] { "Validation", new DateTime(2025, 11, 2, 21, 8, 26, 564, DateTimeKind.Utc).AddTicks(2975), "English translation for Validation.Password", "Validation.Password", "Password must be at least 8 characters" });

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 243,
                columns: new[] { "Category", "CreatedAt", "Description", "Key", "Value" },
                values: new object[] { "Navigation", new DateTime(2025, 11, 2, 21, 8, 26, 564, DateTimeKind.Utc).AddTicks(2979), "English translation for Navigation.Dashboard", "Navigation.Dashboard", "Dashboard" });

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 244,
                columns: new[] { "Category", "CreatedAt", "Description", "Key", "Value" },
                values: new object[] { "Navigation", new DateTime(2025, 11, 2, 21, 8, 26, 564, DateTimeKind.Utc).AddTicks(2980), "English translation for Navigation.Announcements", "Navigation.Announcements", "Announcements" });

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 245,
                columns: new[] { "Category", "CreatedAt", "Description", "Key", "Value" },
                values: new object[] { "Navigation", new DateTime(2025, 11, 2, 21, 8, 26, 564, DateTimeKind.Utc).AddTicks(2982), "English translation for Navigation.Campaigns", "Navigation.Campaigns", "Campaigns" });

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 246,
                columns: new[] { "Category", "CreatedAt", "Description", "Key", "Value" },
                values: new object[] { "Navigation", new DateTime(2025, 11, 2, 21, 8, 26, 564, DateTimeKind.Utc).AddTicks(2983), "English translation for Navigation.Content", "Navigation.Content", "Content" });

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 247,
                columns: new[] { "Category", "CreatedAt", "Description", "Key", "Value" },
                values: new object[] { "Navigation", new DateTime(2025, 11, 2, 21, 8, 26, 564, DateTimeKind.Utc).AddTicks(2985), "English translation for Navigation.Pages", "Navigation.Pages", "Pages" });

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 248,
                columns: new[] { "Category", "CreatedAt", "Description", "Key", "Value" },
                values: new object[] { "Navigation", new DateTime(2025, 11, 2, 21, 8, 26, 564, DateTimeKind.Utc).AddTicks(2986), "English translation for Navigation.Sections", "Navigation.Sections", "Sections" });

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 249,
                columns: new[] { "Category", "CreatedAt", "Description", "Key", "Value" },
                values: new object[] { "Navigation", new DateTime(2025, 11, 2, 21, 8, 26, 564, DateTimeKind.Utc).AddTicks(2987), "English translation for Navigation.Layouts", "Navigation.Layouts", "Layouts" });

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 250,
                columns: new[] { "Category", "CreatedAt", "Description", "Key", "Value" },
                values: new object[] { "Navigation", new DateTime(2025, 11, 2, 21, 8, 26, 564, DateTimeKind.Utc).AddTicks(2989), "English translation for Navigation.WebUrlManagement", "Navigation.WebUrlManagement", "Web URL Management" });

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 251,
                columns: new[] { "Category", "CreatedAt", "Description", "Key", "Value" },
                values: new object[] { "Navigation", new DateTime(2025, 11, 2, 21, 8, 26, 564, DateTimeKind.Utc).AddTicks(2990), "English translation for Navigation.News", "Navigation.News", "News" });

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 252,
                columns: new[] { "Category", "CreatedAt", "Description", "Key", "Value" },
                values: new object[] { "Navigation", new DateTime(2025, 11, 2, 21, 8, 26, 564, DateTimeKind.Utc).AddTicks(3021), "English translation for Navigation.Blog", "Navigation.Blog", "Blog" });

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 253,
                columns: new[] { "Category", "CreatedAt", "Description", "Key", "Value" },
                values: new object[] { "Navigation", new DateTime(2025, 11, 2, 21, 8, 26, 564, DateTimeKind.Utc).AddTicks(3022), "English translation for Navigation.Templates", "Navigation.Templates", "Templates" });

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 254,
                columns: new[] { "Category", "CreatedAt", "Description", "Key", "Value" },
                values: new object[] { "Navigation", new DateTime(2025, 11, 2, 21, 8, 26, 564, DateTimeKind.Utc).AddTicks(3023), "English translation for Navigation.SectionItems", "Navigation.SectionItems", "Section Items" });

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 255,
                columns: new[] { "Category", "CreatedAt", "Description", "Key", "Value" },
                values: new object[] { "Navigation", new DateTime(2025, 11, 2, 21, 8, 26, 564, DateTimeKind.Utc).AddTicks(3025), "English translation for Navigation.ECommerce", "Navigation.ECommerce", "E-Commerce" });

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 256,
                columns: new[] { "Category", "CreatedAt", "Description", "Key", "Value" },
                values: new object[] { "Navigation", new DateTime(2025, 11, 2, 21, 8, 26, 564, DateTimeKind.Utc).AddTicks(3026), "English translation for Navigation.Products", "Navigation.Products", "Products" });

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 257,
                columns: new[] { "Category", "CreatedAt", "Description", "Key", "Value" },
                values: new object[] { "Navigation", new DateTime(2025, 11, 2, 21, 8, 26, 564, DateTimeKind.Utc).AddTicks(3028), "English translation for Navigation.Categories", "Navigation.Categories", "Categories" });

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 258,
                columns: new[] { "Category", "CreatedAt", "Description", "Key", "Value" },
                values: new object[] { "Navigation", new DateTime(2025, 11, 2, 21, 8, 26, 564, DateTimeKind.Utc).AddTicks(3031), "English translation for Navigation.Orders", "Navigation.Orders", "Orders" });

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 259,
                columns: new[] { "Category", "CreatedAt", "Description", "Key", "Value" },
                values: new object[] { "Navigation", new DateTime(2025, 11, 2, 21, 8, 26, 564, DateTimeKind.Utc).AddTicks(3032), "English translation for Navigation.Users", "Navigation.Users", "Users" });

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 260,
                columns: new[] { "Category", "CreatedAt", "Description", "Key", "Value" },
                values: new object[] { "Navigation", new DateTime(2025, 11, 2, 21, 8, 26, 564, DateTimeKind.Utc).AddTicks(3033), "English translation for Navigation.ManageUsers", "Navigation.ManageUsers", "Manage Users" });

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 261,
                columns: new[] { "Category", "CreatedAt", "Description", "Key", "Value" },
                values: new object[] { "Navigation", new DateTime(2025, 11, 2, 21, 8, 26, 564, DateTimeKind.Utc).AddTicks(3035), "English translation for Navigation.ManageRoles", "Navigation.ManageRoles", "Manage Roles" });

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 262,
                columns: new[] { "Category", "CreatedAt", "Description", "Key", "Value" },
                values: new object[] { "Navigation", new DateTime(2025, 11, 2, 21, 8, 26, 564, DateTimeKind.Utc).AddTicks(3036), "English translation for Navigation.ManagePermissions", "Navigation.ManagePermissions", "Manage Permissions" });

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 263,
                columns: new[] { "Category", "CreatedAt", "Description", "Key", "Value" },
                values: new object[] { "Navigation", new DateTime(2025, 11, 2, 21, 8, 26, 564, DateTimeKind.Utc).AddTicks(3038), "English translation for Navigation.Analytics", "Navigation.Analytics", "Analytics" });

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 264,
                columns: new[] { "Category", "CreatedAt", "Description", "Key", "Value" },
                values: new object[] { "Navigation", new DateTime(2025, 11, 2, 21, 8, 26, 564, DateTimeKind.Utc).AddTicks(3040), "English translation for Navigation.Settings", "Navigation.Settings", "Settings" });

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 265,
                columns: new[] { "Category", "CreatedAt", "Description", "Key", "Value" },
                values: new object[] { "Navigation", new DateTime(2025, 11, 2, 21, 8, 26, 564, DateTimeKind.Utc).AddTicks(3041), "English translation for Navigation.GeneralSettings", "Navigation.GeneralSettings", "General Settings" });

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 266,
                columns: new[] { "Category", "CreatedAt", "Description", "Key", "Value" },
                values: new object[] { "Navigation", new DateTime(2025, 11, 2, 21, 8, 26, 564, DateTimeKind.Utc).AddTicks(3043), "English translation for Navigation.Countries", "Navigation.Countries", "Countries" });

            migrationBuilder.InsertData(
                table: "LocalizationValues",
                columns: new[] { "Id", "Category", "CreatedAt", "CreatedBy", "Description", "IsActive", "Key", "LanguageId", "Status", "UpdatedAt", "UpdatedBy", "Value" },
                values: new object[,]
                {
                    { 267, "Navigation", new DateTime(2025, 11, 2, 21, 8, 26, 564, DateTimeKind.Utc).AddTicks(3044), null, "English translation for Navigation.Languages", true, "Navigation.Languages", 2, 0, null, null, "Languages" },
                    { 268, "Navigation", new DateTime(2025, 11, 2, 21, 8, 26, 564, DateTimeKind.Utc).AddTicks(3045), null, "English translation for Navigation.Localization", true, "Navigation.Localization", 2, 0, null, null, "Localization" },
                    { 269, "Navigation", new DateTime(2025, 11, 2, 21, 8, 26, 564, DateTimeKind.Utc).AddTicks(3072), null, "English translation for Navigation.Profile", true, "Navigation.Profile", 2, 0, null, null, "Profile" },
                    { 270, "Navigation", new DateTime(2025, 11, 2, 21, 8, 26, 564, DateTimeKind.Utc).AddTicks(3074), null, "English translation for Navigation.Help", true, "Navigation.Help", 2, 0, null, null, "Help" },
                    { 271, "Navigation", new DateTime(2025, 11, 2, 21, 8, 26, 564, DateTimeKind.Utc).AddTicks(3075), null, "English translation for Navigation.Logout", true, "Navigation.Logout", 2, 0, null, null, "Logout" },
                    { 272, "Language", new DateTime(2025, 11, 2, 21, 8, 26, 564, DateTimeKind.Utc).AddTicks(3079), null, "English translation for Language.English", true, "Language.English", 2, 0, null, null, "English" },
                    { 273, "Language", new DateTime(2025, 11, 2, 21, 8, 26, 564, DateTimeKind.Utc).AddTicks(3081), null, "English translation for Language.Turkish", true, "Language.Turkish", 2, 0, null, null, "Turkish" },
                    { 274, "Dashboard", new DateTime(2025, 11, 2, 21, 8, 26, 564, DateTimeKind.Utc).AddTicks(3085), null, "English translation for Dashboard.Title", true, "Dashboard.Title", 2, 0, null, null, "Dashboard" },
                    { 275, "Dashboard", new DateTime(2025, 11, 2, 21, 8, 26, 564, DateTimeKind.Utc).AddTicks(3087), null, "English translation for Dashboard.WelcomeMessage", true, "Dashboard.WelcomeMessage", 2, 0, null, null, "Welcome back! Here's a summary of your CMS analytics and recent activity." },
                    { 276, "Dashboard", new DateTime(2025, 11, 2, 21, 8, 26, 564, DateTimeKind.Utc).AddTicks(3088), null, "English translation for Dashboard.Last7Days", true, "Dashboard.Last7Days", 2, 0, null, null, "Last 7 days" },
                    { 277, "Dashboard", new DateTime(2025, 11, 2, 21, 8, 26, 564, DateTimeKind.Utc).AddTicks(3089), null, "English translation for Dashboard.Last30Days", true, "Dashboard.Last30Days", 2, 0, null, null, "Last 30 days" },
                    { 278, "Dashboard", new DateTime(2025, 11, 2, 21, 8, 26, 564, DateTimeKind.Utc).AddTicks(3090), null, "English translation for Dashboard.Last90Days", true, "Dashboard.Last90Days", 2, 0, null, null, "Last 90 days" },
                    { 279, "Dashboard", new DateTime(2025, 11, 2, 21, 8, 26, 564, DateTimeKind.Utc).AddTicks(3091), null, "English translation for Dashboard.TotalUsers", true, "Dashboard.TotalUsers", 2, 0, null, null, "Total Users" },
                    { 280, "Dashboard", new DateTime(2025, 11, 2, 21, 8, 26, 564, DateTimeKind.Utc).AddTicks(3093), null, "English translation for Dashboard.TotalRevenue", true, "Dashboard.TotalRevenue", 2, 0, null, null, "Total Revenue" },
                    { 281, "Dashboard", new DateTime(2025, 11, 2, 21, 8, 26, 564, DateTimeKind.Utc).AddTicks(3094), null, "English translation for Dashboard.Products", true, "Dashboard.Products", 2, 0, null, null, "Products" },
                    { 282, "Dashboard", new DateTime(2025, 11, 2, 21, 8, 26, 564, DateTimeKind.Utc).AddTicks(3095), null, "English translation for Dashboard.SupportTickets", true, "Dashboard.SupportTickets", 2, 0, null, null, "Support Tickets" },
                    { 283, "Dashboard", new DateTime(2025, 11, 2, 21, 8, 26, 564, DateTimeKind.Utc).AddTicks(3096), null, "English translation for Dashboard.FromLastMonth", true, "Dashboard.FromLastMonth", 2, 0, null, null, "from last month" },
                    { 284, "Dashboard", new DateTime(2025, 11, 2, 21, 8, 26, 564, DateTimeKind.Utc).AddTicks(3097), null, "English translation for Dashboard.SalesOverview", true, "Dashboard.SalesOverview", 2, 0, null, null, "Sales Overview" },
                    { 285, "Dashboard", new DateTime(2025, 11, 2, 21, 8, 26, 564, DateTimeKind.Utc).AddTicks(3099), null, "English translation for Dashboard.Monthly", true, "Dashboard.Monthly", 2, 0, null, null, "Monthly" },
                    { 286, "Dashboard", new DateTime(2025, 11, 2, 21, 8, 26, 564, DateTimeKind.Utc).AddTicks(3100), null, "English translation for Dashboard.ChartVisualization", true, "Dashboard.ChartVisualization", 2, 0, null, null, "Chart visualization goes here" },
                    { 287, "Dashboard", new DateTime(2025, 11, 2, 21, 8, 26, 564, DateTimeKind.Utc).AddTicks(3101), null, "English translation for Dashboard.ThisYear", true, "Dashboard.ThisYear", 2, 0, null, null, "This Year" },
                    { 288, "Dashboard", new DateTime(2025, 11, 2, 21, 8, 26, 564, DateTimeKind.Utc).AddTicks(3103), null, "English translation for Dashboard.LastYear", true, "Dashboard.LastYear", 2, 0, null, null, "Last Year" },
                    { 289, "Dashboard", new DateTime(2025, 11, 2, 21, 8, 26, 564, DateTimeKind.Utc).AddTicks(3104), null, "English translation for Dashboard.RecentActivities", true, "Dashboard.RecentActivities", 2, 0, null, null, "Recent Activities" },
                    { 290, "Dashboard", new DateTime(2025, 11, 2, 21, 8, 26, 564, DateTimeKind.Utc).AddTicks(3105), null, "English translation for Dashboard.TopProducts", true, "Dashboard.TopProducts", 2, 0, null, null, "Top Products" },
                    { 291, "Dashboard", new DateTime(2025, 11, 2, 21, 8, 26, 564, DateTimeKind.Utc).AddTicks(3106), null, "English translation for Dashboard.Product", true, "Dashboard.Product", 2, 0, null, null, "Product" },
                    { 292, "Dashboard", new DateTime(2025, 11, 2, 21, 8, 26, 564, DateTimeKind.Utc).AddTicks(3108), null, "English translation for Dashboard.Category", true, "Dashboard.Category", 2, 0, null, null, "Category" },
                    { 293, "Dashboard", new DateTime(2025, 11, 2, 21, 8, 26, 564, DateTimeKind.Utc).AddTicks(3109), null, "English translation for Dashboard.Sales", true, "Dashboard.Sales", 2, 0, null, null, "Sales" },
                    { 294, "Dashboard", new DateTime(2025, 11, 2, 21, 8, 26, 564, DateTimeKind.Utc).AddTicks(3110), null, "English translation for Dashboard.Status", true, "Dashboard.Status", 2, 0, null, null, "Status" },
                    { 295, "Dashboard", new DateTime(2025, 11, 2, 21, 8, 26, 564, DateTimeKind.Utc).AddTicks(3112), null, "English translation for Dashboard.LatestOrders", true, "Dashboard.LatestOrders", 2, 0, null, null, "Latest Orders" },
                    { 296, "Dashboard", new DateTime(2025, 11, 2, 21, 8, 26, 564, DateTimeKind.Utc).AddTicks(3113), null, "English translation for Dashboard.Today", true, "Dashboard.Today", 2, 0, null, null, "Today" },
                    { 297, "Dashboard", new DateTime(2025, 11, 2, 21, 8, 26, 564, DateTimeKind.Utc).AddTicks(3115), null, "English translation for Dashboard.Yesterday", true, "Dashboard.Yesterday", 2, 0, null, null, "Yesterday" },
                    { 298, "Dashboard", new DateTime(2025, 11, 2, 21, 8, 26, 564, DateTimeKind.Utc).AddTicks(3116), null, "English translation for Dashboard.OrderId", true, "Dashboard.OrderId", 2, 0, null, null, "Order ID" },
                    { 299, "Dashboard", new DateTime(2025, 11, 2, 21, 8, 26, 564, DateTimeKind.Utc).AddTicks(3118), null, "English translation for Dashboard.Customer", true, "Dashboard.Customer", 2, 0, null, null, "Customer" },
                    { 300, "Dashboard", new DateTime(2025, 11, 2, 21, 8, 26, 564, DateTimeKind.Utc).AddTicks(3119), null, "English translation for Dashboard.Date", true, "Dashboard.Date", 2, 0, null, null, "Date" },
                    { 301, "Dashboard", new DateTime(2025, 11, 2, 21, 8, 26, 564, DateTimeKind.Utc).AddTicks(3120), null, "English translation for Dashboard.Amount", true, "Dashboard.Amount", 2, 0, null, null, "Amount" },
                    { 302, "Localization", new DateTime(2025, 11, 2, 21, 8, 26, 564, DateTimeKind.Utc).AddTicks(3124), null, "English translation for Localization.SystemDescription", true, "Localization.SystemDescription", 2, 0, null, null, "Manage text translations used throughout the system" },
                    { 303, "Localization", new DateTime(2025, 11, 2, 21, 8, 26, 564, DateTimeKind.Utc).AddTicks(3125), null, "English translation for Localization.Keys", true, "Localization.Keys", 2, 0, null, null, "Localization Keys" },
                    { 304, "Localization", new DateTime(2025, 11, 2, 21, 8, 26, 564, DateTimeKind.Utc).AddTicks(3127), null, "English translation for Localization.Key", true, "Localization.Key", 2, 0, null, null, "Key" },
                    { 305, "Localization", new DateTime(2025, 11, 2, 21, 8, 26, 564, DateTimeKind.Utc).AddTicks(3192), null, "English translation for Localization.AddKey", true, "Localization.AddKey", 2, 0, null, null, "Add New Key" },
                    { 306, "Localization", new DateTime(2025, 11, 2, 21, 8, 26, 564, DateTimeKind.Utc).AddTicks(3194), null, "English translation for Localization.EditKey", true, "Localization.EditKey", 2, 0, null, null, "Edit Key" },
                    { 307, "Localization", new DateTime(2025, 11, 2, 21, 8, 26, 564, DateTimeKind.Utc).AddTicks(3195), null, "English translation for Localization.KeyDetails", true, "Localization.KeyDetails", 2, 0, null, null, "Key Details" },
                    { 308, "Localization", new DateTime(2025, 11, 2, 21, 8, 26, 564, DateTimeKind.Utc).AddTicks(3196), null, "English translation for Localization.AddKeyDescription", true, "Localization.AddKeyDescription", 2, 0, null, null, "Add a new localization key and its translations" },
                    { 309, "Localization", new DateTime(2025, 11, 2, 21, 8, 26, 564, DateTimeKind.Utc).AddTicks(3197), null, "English translation for Localization.EditKeyDescription", true, "Localization.EditKeyDescription", 2, 0, null, null, "Edit existing localization key and its translations" },
                    { 310, "Localization", new DateTime(2025, 11, 2, 21, 8, 26, 564, DateTimeKind.Utc).AddTicks(3199), null, "English translation for Localization.KeyPlaceholder", true, "Localization.KeyPlaceholder", 2, 0, null, null, "e.g: Common.Save" },
                    { 311, "Localization", new DateTime(2025, 11, 2, 21, 8, 26, 564, DateTimeKind.Utc).AddTicks(3200), null, "English translation for Localization.KeyHint", true, "Localization.KeyHint", 2, 0, null, null, "Use dot-separated hierarchical key" },
                    { 312, "Localization", new DateTime(2025, 11, 2, 21, 8, 26, 564, DateTimeKind.Utc).AddTicks(3201), null, "English translation for Localization.KeyReadonly", true, "Localization.KeyReadonly", 2, 0, null, null, "Key cannot be changed" },
                    { 313, "Localization", new DateTime(2025, 11, 2, 21, 8, 26, 564, DateTimeKind.Utc).AddTicks(3202), null, "English translation for Localization.Description", true, "Localization.Description", 2, 0, null, null, "Description" },
                    { 314, "Localization", new DateTime(2025, 11, 2, 21, 8, 26, 564, DateTimeKind.Utc).AddTicks(3204), null, "English translation for Localization.DescriptionPlaceholder", true, "Localization.DescriptionPlaceholder", 2, 0, null, null, "Describe what this key is used for" },
                    { 315, "Localization", new DateTime(2025, 11, 2, 21, 8, 26, 564, DateTimeKind.Utc).AddTicks(3205), null, "English translation for Localization.SelectCategory", true, "Localization.SelectCategory", 2, 0, null, null, "Select Category" },
                    { 316, "Localization", new DateTime(2025, 11, 2, 21, 8, 26, 564, DateTimeKind.Utc).AddTicks(3206), null, "English translation for Localization.Translations", true, "Localization.Translations", 2, 0, null, null, "Translations" },
                    { 317, "Localization", new DateTime(2025, 11, 2, 21, 8, 26, 564, DateTimeKind.Utc).AddTicks(3208), null, "English translation for Localization.TranslationPlaceholder", true, "Localization.TranslationPlaceholder", 2, 0, null, null, "Enter translation in {0}" },
                    { 318, "Localization", new DateTime(2025, 11, 2, 21, 8, 26, 564, DateTimeKind.Utc).AddTicks(3209), null, "English translation for Localization.Translated", true, "Localization.Translated", 2, 0, null, null, "Translated" },
                    { 319, "Localization", new DateTime(2025, 11, 2, 21, 8, 26, 564, DateTimeKind.Utc).AddTicks(3210), null, "English translation for Localization.NotTranslated", true, "Localization.NotTranslated", 2, 0, null, null, "Not Translated" },
                    { 320, "Localization", new DateTime(2025, 11, 2, 21, 8, 26, 564, DateTimeKind.Utc).AddTicks(3212), null, "English translation for Localization.LastUpdated", true, "Localization.LastUpdated", 2, 0, null, null, "Last Updated" },
                    { 321, "Localization", new DateTime(2025, 11, 2, 21, 8, 26, 564, DateTimeKind.Utc).AddTicks(3213), null, "English translation for Localization.SearchPlaceholder", true, "Localization.SearchPlaceholder", 2, 0, null, null, "Search key or value..." },
                    { 322, "Localization", new DateTime(2025, 11, 2, 21, 8, 26, 564, DateTimeKind.Utc).AddTicks(3214), null, "English translation for Localization.ShowingResults", true, "Localization.ShowingResults", 2, 0, null, null, "Showing {0}-{1} of {2} results" },
                    { 323, "Localization", new DateTime(2025, 11, 2, 21, 8, 26, 564, DateTimeKind.Utc).AddTicks(3216), null, "English translation for Localization.NoKeys", true, "Localization.NoKeys", 2, 0, null, null, "No localization keys found" },
                    { 324, "Localization", new DateTime(2025, 11, 2, 21, 8, 26, 564, DateTimeKind.Utc).AddTicks(3217), null, "English translation for Localization.NoKeysDescription", true, "Localization.NoKeysDescription", 2, 0, null, null, "No localization keys have been added yet" },
                    { 325, "Localization", new DateTime(2025, 11, 2, 21, 8, 26, 564, DateTimeKind.Utc).AddTicks(3218), null, "English translation for Localization.AddFirstKey", true, "Localization.AddFirstKey", 2, 0, null, null, "Add First Key" },
                    { 326, "Localization", new DateTime(2025, 11, 2, 21, 8, 26, 564, DateTimeKind.Utc).AddTicks(3219), null, "English translation for Localization.DeleteConfirmation", true, "Localization.DeleteConfirmation", 2, 0, null, null, "Are you sure you want to delete this key and all its translations?" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Contents_RelatedDataEntity",
                table: "Contents",
                columns: new[] { "RelatedDataEntityType", "RelatedDataEntityId" });

            migrationBuilder.CreateIndex(
                name: "IX_Contents_RelatedDataEntityType",
                table: "Contents",
                column: "RelatedDataEntityType");

            migrationBuilder.CreateIndex(
                name: "IX_ContentSlugs_ContentId_LanguageId",
                table: "ContentSlugs",
                columns: new[] { "ContentId", "LanguageId" });

            migrationBuilder.CreateIndex(
                name: "IX_ContentSlugs_LanguageId",
                table: "ContentSlugs",
                column: "LanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_ContentSlugs_Slug",
                table: "ContentSlugs",
                column: "Slug");

            migrationBuilder.CreateIndex(
                name: "IX_ContentSlugs_Slug_LanguageId",
                table: "ContentSlugs",
                columns: new[] { "Slug", "LanguageId" },
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ContentSlugs");

            migrationBuilder.DropIndex(
                name: "IX_Contents_RelatedDataEntity",
                table: "Contents");

            migrationBuilder.DropIndex(
                name: "IX_Contents_RelatedDataEntityType",
                table: "Contents");

            migrationBuilder.DeleteData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 267);

            migrationBuilder.DeleteData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 268);

            migrationBuilder.DeleteData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 269);

            migrationBuilder.DeleteData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 270);

            migrationBuilder.DeleteData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 271);

            migrationBuilder.DeleteData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 272);

            migrationBuilder.DeleteData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 273);

            migrationBuilder.DeleteData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 274);

            migrationBuilder.DeleteData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 275);

            migrationBuilder.DeleteData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 276);

            migrationBuilder.DeleteData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 277);

            migrationBuilder.DeleteData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 278);

            migrationBuilder.DeleteData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 279);

            migrationBuilder.DeleteData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 280);

            migrationBuilder.DeleteData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 281);

            migrationBuilder.DeleteData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 282);

            migrationBuilder.DeleteData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 283);

            migrationBuilder.DeleteData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 284);

            migrationBuilder.DeleteData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 285);

            migrationBuilder.DeleteData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 286);

            migrationBuilder.DeleteData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 287);

            migrationBuilder.DeleteData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 288);

            migrationBuilder.DeleteData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 289);

            migrationBuilder.DeleteData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 290);

            migrationBuilder.DeleteData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 291);

            migrationBuilder.DeleteData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 292);

            migrationBuilder.DeleteData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 293);

            migrationBuilder.DeleteData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 294);

            migrationBuilder.DeleteData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 295);

            migrationBuilder.DeleteData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 296);

            migrationBuilder.DeleteData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 297);

            migrationBuilder.DeleteData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 298);

            migrationBuilder.DeleteData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 299);

            migrationBuilder.DeleteData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 300);

            migrationBuilder.DeleteData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 301);

            migrationBuilder.DeleteData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 302);

            migrationBuilder.DeleteData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 303);

            migrationBuilder.DeleteData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 304);

            migrationBuilder.DeleteData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 305);

            migrationBuilder.DeleteData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 306);

            migrationBuilder.DeleteData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 307);

            migrationBuilder.DeleteData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 308);

            migrationBuilder.DeleteData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 309);

            migrationBuilder.DeleteData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 310);

            migrationBuilder.DeleteData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 311);

            migrationBuilder.DeleteData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 312);

            migrationBuilder.DeleteData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 313);

            migrationBuilder.DeleteData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 314);

            migrationBuilder.DeleteData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 315);

            migrationBuilder.DeleteData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 316);

            migrationBuilder.DeleteData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 317);

            migrationBuilder.DeleteData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 318);

            migrationBuilder.DeleteData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 319);

            migrationBuilder.DeleteData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 320);

            migrationBuilder.DeleteData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 321);

            migrationBuilder.DeleteData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 322);

            migrationBuilder.DeleteData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 323);

            migrationBuilder.DeleteData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 324);

            migrationBuilder.DeleteData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 325);

            migrationBuilder.DeleteData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 326);

            migrationBuilder.DropColumn(
                name: "Author",
                table: "Contents");

            migrationBuilder.DropColumn(
                name: "MetaDescription",
                table: "Contents");

            migrationBuilder.DropColumn(
                name: "MetaKeywords",
                table: "Contents");

            migrationBuilder.DropColumn(
                name: "MetaTitle",
                table: "Contents");

            migrationBuilder.DropColumn(
                name: "SubDescription",
                table: "Contents");

            migrationBuilder.DropColumn(
                name: "Title",
                table: "Contents");

            migrationBuilder.RenameColumn(
                name: "RelatedDataEntityType",
                table: "Contents",
                newName: "RelatedEntityId");

            migrationBuilder.RenameColumn(
                name: "RelatedDataEntityId",
                table: "Contents",
                newName: "RelatedDataId");

            migrationBuilder.AddColumn<string>(
                name: "Slug",
                table: "Pages",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Status",
                table: "Contents",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<bool>(
                name: "IsDeleted",
                table: "Contents",
                type: "bit",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Contents",
                type: "nvarchar(1000)",
                maxLength: 1000,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(2000)",
                oldMaxLength: 2000,
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "Contents",
                columns: new[] { "Id", "CreatedAt", "CreatedBy", "Description", "RelatedDataId", "RelatedEntityId", "Status", "UpdatedAt", "UpdatedBy" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 1, 1, 10, 0, 0, 0, DateTimeKind.Unspecified), null, "Ana sayfa içeriği", 1, 2, 1, null, null },
                    { 2, new DateTime(2024, 1, 2, 10, 0, 0, 0, DateTimeKind.Unspecified), null, "Blog yazısı içeriği", 1, 9, 1, null, null },
                    { 3, new DateTime(2024, 1, 3, 10, 0, 0, 0, DateTimeKind.Unspecified), null, "Ürün detay sayfası içeriği", 1, 4, 1, null, null }
                });

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 31, 12, 51, 20, 466, DateTimeKind.Utc).AddTicks(7253));

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 31, 12, 51, 20, 466, DateTimeKind.Utc).AddTicks(7257));

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 31, 12, 51, 20, 466, DateTimeKind.Utc).AddTicks(7259));

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 31, 12, 51, 20, 466, DateTimeKind.Utc).AddTicks(7261));

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 31, 12, 51, 20, 466, DateTimeKind.Utc).AddTicks(7263));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 31, 12, 51, 20, 467, DateTimeKind.Utc).AddTicks(2546));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 31, 12, 51, 20, 467, DateTimeKind.Utc).AddTicks(2573));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 31, 12, 51, 20, 467, DateTimeKind.Utc).AddTicks(2574));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 31, 12, 51, 20, 467, DateTimeKind.Utc).AddTicks(2576));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 31, 12, 51, 20, 467, DateTimeKind.Utc).AddTicks(2576));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 31, 12, 51, 20, 467, DateTimeKind.Utc).AddTicks(2579));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 31, 12, 51, 20, 467, DateTimeKind.Utc).AddTicks(2579));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 31, 12, 51, 20, 467, DateTimeKind.Utc).AddTicks(2580));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 31, 12, 51, 20, 467, DateTimeKind.Utc).AddTicks(2581));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 31, 12, 51, 20, 467, DateTimeKind.Utc).AddTicks(2582));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 31, 12, 51, 20, 467, DateTimeKind.Utc).AddTicks(2583));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 31, 12, 51, 20, 467, DateTimeKind.Utc).AddTicks(2584));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 31, 12, 51, 20, 467, DateTimeKind.Utc).AddTicks(2585));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 31, 12, 51, 20, 467, DateTimeKind.Utc).AddTicks(2586));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 31, 12, 51, 20, 467, DateTimeKind.Utc).AddTicks(2587));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 16,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 31, 12, 51, 20, 467, DateTimeKind.Utc).AddTicks(2588));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 17,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 31, 12, 51, 20, 467, DateTimeKind.Utc).AddTicks(2588));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 18,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 31, 12, 51, 20, 467, DateTimeKind.Utc).AddTicks(2590));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 19,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 31, 12, 51, 20, 467, DateTimeKind.Utc).AddTicks(2590));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 20,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 31, 12, 51, 20, 467, DateTimeKind.Utc).AddTicks(2591));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 21,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 31, 12, 51, 20, 467, DateTimeKind.Utc).AddTicks(2592));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 22,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 31, 12, 51, 20, 467, DateTimeKind.Utc).AddTicks(2593));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 23,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 31, 12, 51, 20, 467, DateTimeKind.Utc).AddTicks(2594));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 24,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 31, 12, 51, 20, 467, DateTimeKind.Utc).AddTicks(2594));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 25,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 31, 12, 51, 20, 467, DateTimeKind.Utc).AddTicks(2595));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 26,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 31, 12, 51, 20, 467, DateTimeKind.Utc).AddTicks(2596));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 27,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 31, 12, 51, 20, 467, DateTimeKind.Utc).AddTicks(2597));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 28,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 31, 12, 51, 20, 467, DateTimeKind.Utc).AddTicks(2598));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 29,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 31, 12, 51, 20, 467, DateTimeKind.Utc).AddTicks(2598));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 30,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 31, 12, 51, 20, 467, DateTimeKind.Utc).AddTicks(2599));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 31,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 31, 12, 51, 20, 467, DateTimeKind.Utc).AddTicks(2600));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 32,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 31, 12, 51, 20, 467, DateTimeKind.Utc).AddTicks(2601));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 33,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 31, 12, 51, 20, 467, DateTimeKind.Utc).AddTicks(2602));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 34,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 31, 12, 51, 20, 467, DateTimeKind.Utc).AddTicks(2624));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 35,
                columns: new[] { "Category", "CreatedAt", "Description", "Key", "Value" },
                values: new object[] { "Page", new DateTime(2025, 10, 31, 12, 51, 20, 467, DateTimeKind.Utc).AddTicks(2627), "Turkish translation for Page.Title", "Page.Title", "Sayfa Başlığı" });

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 36,
                columns: new[] { "Category", "CreatedAt", "Description", "Key", "Value" },
                values: new object[] { "Page", new DateTime(2025, 10, 31, 12, 51, 20, 467, DateTimeKind.Utc).AddTicks(2628), "Turkish translation for Page.Content", "Page.Content", "Sayfa İçeriği" });

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 37,
                columns: new[] { "Category", "CreatedAt", "Description", "Key", "Value" },
                values: new object[] { "Page", new DateTime(2025, 10, 31, 12, 51, 20, 467, DateTimeKind.Utc).AddTicks(2629), "Turkish translation for Page.Description", "Page.Description", "Sayfa Açıklaması" });

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 38,
                columns: new[] { "Category", "CreatedAt", "Description", "Key", "Value" },
                values: new object[] { "Page", new DateTime(2025, 10, 31, 12, 51, 20, 467, DateTimeKind.Utc).AddTicks(2630), "Turkish translation for Page.Keywords", "Page.Keywords", "Anahtar Kelimeler" });

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 39,
                columns: new[] { "CreatedAt", "Description", "Key", "Value" },
                values: new object[] { new DateTime(2025, 10, 31, 12, 51, 20, 467, DateTimeKind.Utc).AddTicks(2631), "Turkish translation for Page.Author", "Page.Author", "Yazar" });

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 40,
                columns: new[] { "CreatedAt", "Description", "Key", "Value" },
                values: new object[] { new DateTime(2025, 10, 31, 12, 51, 20, 467, DateTimeKind.Utc).AddTicks(2632), "Turkish translation for Page.CreatedAt", "Page.CreatedAt", "Oluşturulma Tarihi" });

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 41,
                columns: new[] { "CreatedAt", "Description", "Key", "Value" },
                values: new object[] { new DateTime(2025, 10, 31, 12, 51, 20, 467, DateTimeKind.Utc).AddTicks(2632), "Turkish translation for Page.UpdatedAt", "Page.UpdatedAt", "Güncellenme Tarihi" });

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 42,
                columns: new[] { "CreatedAt", "Description", "Key", "Value" },
                values: new object[] { new DateTime(2025, 10, 31, 12, 51, 20, 467, DateTimeKind.Utc).AddTicks(2633), "Turkish translation for Page.Status", "Page.Status", "Durum" });

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 43,
                columns: new[] { "CreatedAt", "Description", "Key", "Value" },
                values: new object[] { new DateTime(2025, 10, 31, 12, 51, 20, 467, DateTimeKind.Utc).AddTicks(2634), "Turkish translation for Page.Type", "Page.Type", "Sayfa Tipi" });

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 44,
                columns: new[] { "CreatedAt", "Description", "Key", "Value" },
                values: new object[] { new DateTime(2025, 10, 31, 12, 51, 20, 467, DateTimeKind.Utc).AddTicks(2635), "Turkish translation for Page.Layout", "Page.Layout", "Düzen" });

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 45,
                columns: new[] { "CreatedAt", "Description", "Key", "Value" },
                values: new object[] { new DateTime(2025, 10, 31, 12, 51, 20, 467, DateTimeKind.Utc).AddTicks(2636), "Turkish translation for Page.Template", "Page.Template", "Şablon" });

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 46,
                columns: new[] { "CreatedAt", "Description", "Key", "Value" },
                values: new object[] { new DateTime(2025, 10, 31, 12, 51, 20, 467, DateTimeKind.Utc).AddTicks(2636), "Turkish translation for Page.SEO", "Page.SEO", "SEO Ayarları" });

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 47,
                columns: new[] { "CreatedAt", "Description", "Key", "Value" },
                values: new object[] { new DateTime(2025, 10, 31, 12, 51, 20, 467, DateTimeKind.Utc).AddTicks(2637), "Turkish translation for Page.Sections", "Page.Sections", "Bölümler" });

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 48,
                columns: new[] { "CreatedAt", "Description", "Key", "Value" },
                values: new object[] { new DateTime(2025, 10, 31, 12, 51, 20, 467, DateTimeKind.Utc).AddTicks(2638), "Turkish translation for Page.Items", "Page.Items", "Öğeler" });

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 49,
                columns: new[] { "CreatedAt", "Description", "Key", "Value" },
                values: new object[] { new DateTime(2025, 10, 31, 12, 51, 20, 467, DateTimeKind.Utc).AddTicks(2639), "Turkish translation for Page.Fields", "Page.Fields", "Alanlar" });

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 50,
                columns: new[] { "Category", "CreatedAt", "Description", "Key", "Value" },
                values: new object[] { "Section", new DateTime(2025, 10, 31, 12, 51, 20, 467, DateTimeKind.Utc).AddTicks(2642), "Turkish translation for Section.Name", "Section.Name", "Bölüm Adı" });

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 51,
                columns: new[] { "Category", "CreatedAt", "Description", "Key", "Value" },
                values: new object[] { "Section", new DateTime(2025, 10, 31, 12, 51, 20, 467, DateTimeKind.Utc).AddTicks(2643), "Turkish translation for Section.Type", "Section.Type", "Bölüm Tipi" });

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 52,
                columns: new[] { "Category", "CreatedAt", "Description", "Key", "Value" },
                values: new object[] { "Section", new DateTime(2025, 10, 31, 12, 51, 20, 467, DateTimeKind.Utc).AddTicks(2644), "Turkish translation for Section.Key", "Section.Key", "Bölüm Anahtarı" });

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 53,
                columns: new[] { "Category", "CreatedAt", "Description", "Key", "Value" },
                values: new object[] { "Section", new DateTime(2025, 10, 31, 12, 51, 20, 467, DateTimeKind.Utc).AddTicks(2645), "Turkish translation for Section.Order", "Section.Order", "Sıralama" });

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 54,
                columns: new[] { "CreatedAt", "Description", "Key", "Value" },
                values: new object[] { new DateTime(2025, 10, 31, 12, 51, 20, 467, DateTimeKind.Utc).AddTicks(2646), "Turkish translation for Section.Settings", "Section.Settings", "Ayarlar" });

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 55,
                columns: new[] { "CreatedAt", "Description", "Key", "Value" },
                values: new object[] { new DateTime(2025, 10, 31, 12, 51, 20, 467, DateTimeKind.Utc).AddTicks(2647), "Turkish translation for Section.Items", "Section.Items", "Öğeler" });

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 56,
                columns: new[] { "CreatedAt", "Description", "Key", "Value" },
                values: new object[] { new DateTime(2025, 10, 31, 12, 51, 20, 467, DateTimeKind.Utc).AddTicks(2647), "Turkish translation for Section.AddItem", "Section.AddItem", "Öğe Ekle" });

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 57,
                columns: new[] { "CreatedAt", "Description", "Key", "Value" },
                values: new object[] { new DateTime(2025, 10, 31, 12, 51, 20, 467, DateTimeKind.Utc).AddTicks(2648), "Turkish translation for Section.EditItems", "Section.EditItems", "Öğeleri Düzenle" });

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 58,
                columns: new[] { "CreatedAt", "Description", "Key", "Value" },
                values: new object[] { new DateTime(2025, 10, 31, 12, 51, 20, 467, DateTimeKind.Utc).AddTicks(2649), "Turkish translation for Section.Duplicate", "Section.Duplicate", "Kopyala" });

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 59,
                columns: new[] { "CreatedAt", "Description", "Key", "Value" },
                values: new object[] { new DateTime(2025, 10, 31, 12, 51, 20, 467, DateTimeKind.Utc).AddTicks(2650), "Turkish translation for Section.Remove", "Section.Remove", "Kaldır" });

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 60,
                columns: new[] { "CreatedAt", "Description", "Key", "Value" },
                values: new object[] { new DateTime(2025, 10, 31, 12, 51, 20, 467, DateTimeKind.Utc).AddTicks(2650), "Turkish translation for Section.Hero", "Section.Hero", "Ana Bölüm" });

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 61,
                columns: new[] { "CreatedAt", "Description", "Key", "Value" },
                values: new object[] { new DateTime(2025, 10, 31, 12, 51, 20, 467, DateTimeKind.Utc).AddTicks(2651), "Turkish translation for Section.Navbar", "Section.Navbar", "Navigasyon" });

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 62,
                columns: new[] { "CreatedAt", "Description", "Key", "Value" },
                values: new object[] { new DateTime(2025, 10, 31, 12, 51, 20, 467, DateTimeKind.Utc).AddTicks(2652), "Turkish translation for Section.Footer", "Section.Footer", "Alt Bilgi" });

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 63,
                columns: new[] { "CreatedAt", "Description", "Key", "Value" },
                values: new object[] { new DateTime(2025, 10, 31, 12, 51, 20, 467, DateTimeKind.Utc).AddTicks(2653), "Turkish translation for Section.Content", "Section.Content", "İçerik" });

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 64,
                columns: new[] { "CreatedAt", "Description", "Key", "Value" },
                values: new object[] { new DateTime(2025, 10, 31, 12, 51, 20, 467, DateTimeKind.Utc).AddTicks(2654), "Turkish translation for Section.Gallery", "Section.Gallery", "Galeri" });

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 65,
                columns: new[] { "CreatedAt", "Description", "Key", "Value" },
                values: new object[] { new DateTime(2025, 10, 31, 12, 51, 20, 467, DateTimeKind.Utc).AddTicks(2654), "Turkish translation for Section.Contact", "Section.Contact", "İletişim" });

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 66,
                columns: new[] { "Category", "CreatedAt", "Description", "Key", "Value" },
                values: new object[] { "Validation", new DateTime(2025, 10, 31, 12, 51, 20, 467, DateTimeKind.Utc).AddTicks(2658), "Turkish translation for Validation.Required", "Validation.Required", "Bu alan zorunludur" });

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 67,
                columns: new[] { "Category", "CreatedAt", "Description", "Key", "Value" },
                values: new object[] { "Validation", new DateTime(2025, 10, 31, 12, 51, 20, 467, DateTimeKind.Utc).AddTicks(2673), "Turkish translation for Validation.Email", "Validation.Email", "Geçerli bir e-posta adresi giriniz" });

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 68,
                columns: new[] { "Category", "CreatedAt", "Description", "Key", "Value" },
                values: new object[] { "Validation", new DateTime(2025, 10, 31, 12, 51, 20, 467, DateTimeKind.Utc).AddTicks(2674), "Turkish translation for Validation.MinLength", "Validation.MinLength", "En az {0} karakter olmalıdır" });

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 69,
                columns: new[] { "Category", "CreatedAt", "Description", "Key", "Value" },
                values: new object[] { "Validation", new DateTime(2025, 10, 31, 12, 51, 20, 467, DateTimeKind.Utc).AddTicks(2675), "Turkish translation for Validation.MaxLength", "Validation.MaxLength", "En fazla {0} karakter olmalıdır" });

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 70,
                columns: new[] { "CreatedAt", "Description", "Key", "Value" },
                values: new object[] { new DateTime(2025, 10, 31, 12, 51, 20, 467, DateTimeKind.Utc).AddTicks(2676), "Turkish translation for Validation.Range", "Validation.Range", "{0} ile {1} arasında olmalıdır" });

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 71,
                columns: new[] { "CreatedAt", "Description", "Key", "Value" },
                values: new object[] { new DateTime(2025, 10, 31, 12, 51, 20, 467, DateTimeKind.Utc).AddTicks(2677), "Turkish translation for Validation.Numeric", "Validation.Numeric", "Sayısal bir değer giriniz" });

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 72,
                columns: new[] { "CreatedAt", "Description", "Key", "Value" },
                values: new object[] { new DateTime(2025, 10, 31, 12, 51, 20, 467, DateTimeKind.Utc).AddTicks(2678), "Turkish translation for Validation.Date", "Validation.Date", "Geçerli bir tarih giriniz" });

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 73,
                columns: new[] { "CreatedAt", "Description", "Key", "Value" },
                values: new object[] { new DateTime(2025, 10, 31, 12, 51, 20, 467, DateTimeKind.Utc).AddTicks(2678), "Turkish translation for Validation.Url", "Validation.Url", "Geçerli bir URL giriniz" });

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 74,
                columns: new[] { "CreatedAt", "Description", "Key", "Value" },
                values: new object[] { new DateTime(2025, 10, 31, 12, 51, 20, 467, DateTimeKind.Utc).AddTicks(2679), "Turkish translation for Validation.Phone", "Validation.Phone", "Geçerli bir telefon numarası giriniz" });

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 75,
                columns: new[] { "CreatedAt", "Description", "Key", "Value" },
                values: new object[] { new DateTime(2025, 10, 31, 12, 51, 20, 467, DateTimeKind.Utc).AddTicks(2680), "Turkish translation for Validation.Password", "Validation.Password", "Şifre en az 8 karakter olmalıdır" });

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 76,
                columns: new[] { "Category", "CreatedAt", "Description", "Key", "Value" },
                values: new object[] { "Navigation", new DateTime(2025, 10, 31, 12, 51, 20, 467, DateTimeKind.Utc).AddTicks(2682), "Turkish translation for Navigation.Dashboard", "Navigation.Dashboard", "Dashboard" });

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 77,
                columns: new[] { "Category", "CreatedAt", "Description", "Key", "Value" },
                values: new object[] { "Navigation", new DateTime(2025, 10, 31, 12, 51, 20, 467, DateTimeKind.Utc).AddTicks(2683), "Turkish translation for Navigation.Announcements", "Navigation.Announcements", "Duyurular" });

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 78,
                columns: new[] { "Category", "CreatedAt", "Description", "Key", "Value" },
                values: new object[] { "Navigation", new DateTime(2025, 10, 31, 12, 51, 20, 467, DateTimeKind.Utc).AddTicks(2684), "Turkish translation for Navigation.Campaigns", "Navigation.Campaigns", "Kampanyalar" });

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 79,
                columns: new[] { "Category", "CreatedAt", "Description", "Key", "Value" },
                values: new object[] { "Navigation", new DateTime(2025, 10, 31, 12, 51, 20, 467, DateTimeKind.Utc).AddTicks(2685), "Turkish translation for Navigation.Content", "Navigation.Content", "İçerik" });

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 80,
                columns: new[] { "CreatedAt", "Description", "Key", "Value" },
                values: new object[] { new DateTime(2025, 10, 31, 12, 51, 20, 467, DateTimeKind.Utc).AddTicks(2686), "Turkish translation for Navigation.Pages", "Navigation.Pages", "Sayfalar" });

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 81,
                columns: new[] { "CreatedAt", "Description", "Key", "Value" },
                values: new object[] { new DateTime(2025, 10, 31, 12, 51, 20, 467, DateTimeKind.Utc).AddTicks(2687), "Turkish translation for Navigation.Sections", "Navigation.Sections", "Bölümler" });

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 82,
                columns: new[] { "CreatedAt", "Description", "Key", "Value" },
                values: new object[] { new DateTime(2025, 10, 31, 12, 51, 20, 467, DateTimeKind.Utc).AddTicks(2688), "Turkish translation for Navigation.Layouts", "Navigation.Layouts", "Düzenler" });

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 83,
                columns: new[] { "CreatedAt", "Description", "Key", "Value" },
                values: new object[] { new DateTime(2025, 10, 31, 12, 51, 20, 467, DateTimeKind.Utc).AddTicks(2689), "Turkish translation for Navigation.WebUrlManagement", "Navigation.WebUrlManagement", "Web URL Yönetimi" });

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 84,
                columns: new[] { "CreatedAt", "Description", "Key", "Value" },
                values: new object[] { new DateTime(2025, 10, 31, 12, 51, 20, 467, DateTimeKind.Utc).AddTicks(2689), "Turkish translation for Navigation.News", "Navigation.News", "Haberler" });

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 85,
                columns: new[] { "CreatedAt", "Description", "Key", "Value" },
                values: new object[] { new DateTime(2025, 10, 31, 12, 51, 20, 467, DateTimeKind.Utc).AddTicks(2690), "Turkish translation for Navigation.Blog", "Navigation.Blog", "Blog" });

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 86,
                columns: new[] { "CreatedAt", "Description", "Key", "Value" },
                values: new object[] { new DateTime(2025, 10, 31, 12, 51, 20, 467, DateTimeKind.Utc).AddTicks(2691), "Turkish translation for Navigation.Templates", "Navigation.Templates", "Şablonlar" });

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 87,
                columns: new[] { "CreatedAt", "Description", "Key", "Value" },
                values: new object[] { new DateTime(2025, 10, 31, 12, 51, 20, 467, DateTimeKind.Utc).AddTicks(2692), "Turkish translation for Navigation.SectionItems", "Navigation.SectionItems", "Bölüm Öğeleri" });

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 88,
                columns: new[] { "CreatedAt", "Description", "Key", "Value" },
                values: new object[] { new DateTime(2025, 10, 31, 12, 51, 20, 467, DateTimeKind.Utc).AddTicks(2692), "Turkish translation for Navigation.ECommerce", "Navigation.ECommerce", "E-Ticaret" });

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 89,
                columns: new[] { "CreatedAt", "Description", "Key", "Value" },
                values: new object[] { new DateTime(2025, 10, 31, 12, 51, 20, 467, DateTimeKind.Utc).AddTicks(2693), "Turkish translation for Navigation.Products", "Navigation.Products", "Ürünler" });

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 90,
                columns: new[] { "CreatedAt", "Description", "Key", "Value" },
                values: new object[] { new DateTime(2025, 10, 31, 12, 51, 20, 467, DateTimeKind.Utc).AddTicks(2694), "Turkish translation for Navigation.Categories", "Navigation.Categories", "Kategoriler" });

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 91,
                columns: new[] { "CreatedAt", "Description", "Key", "Value" },
                values: new object[] { new DateTime(2025, 10, 31, 12, 51, 20, 467, DateTimeKind.Utc).AddTicks(2695), "Turkish translation for Navigation.Orders", "Navigation.Orders", "Siparişler" });

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 92,
                columns: new[] { "CreatedAt", "Description", "Key", "Value" },
                values: new object[] { new DateTime(2025, 10, 31, 12, 51, 20, 467, DateTimeKind.Utc).AddTicks(2696), "Turkish translation for Navigation.Users", "Navigation.Users", "Kullanıcılar" });

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 93,
                columns: new[] { "CreatedAt", "Description", "Key", "Value" },
                values: new object[] { new DateTime(2025, 10, 31, 12, 51, 20, 467, DateTimeKind.Utc).AddTicks(2696), "Turkish translation for Navigation.ManageUsers", "Navigation.ManageUsers", "Kullanıcı Yönetimi" });

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 94,
                columns: new[] { "CreatedAt", "Description", "Key", "Value" },
                values: new object[] { new DateTime(2025, 10, 31, 12, 51, 20, 467, DateTimeKind.Utc).AddTicks(2697), "Turkish translation for Navigation.ManageRoles", "Navigation.ManageRoles", "Rol Yönetimi" });

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 95,
                columns: new[] { "CreatedAt", "Description", "Key", "Value" },
                values: new object[] { new DateTime(2025, 10, 31, 12, 51, 20, 467, DateTimeKind.Utc).AddTicks(2698), "Turkish translation for Navigation.ManagePermissions", "Navigation.ManagePermissions", "İzin Yönetimi" });

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 96,
                columns: new[] { "CreatedAt", "Description", "Key", "Value" },
                values: new object[] { new DateTime(2025, 10, 31, 12, 51, 20, 467, DateTimeKind.Utc).AddTicks(2699), "Turkish translation for Navigation.Analytics", "Navigation.Analytics", "Analitik" });

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 97,
                columns: new[] { "CreatedAt", "Description", "Key", "Value" },
                values: new object[] { new DateTime(2025, 10, 31, 12, 51, 20, 467, DateTimeKind.Utc).AddTicks(2699), "Turkish translation for Navigation.Settings", "Navigation.Settings", "Ayarlar" });

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 98,
                columns: new[] { "CreatedAt", "Description", "Key", "Value" },
                values: new object[] { new DateTime(2025, 10, 31, 12, 51, 20, 467, DateTimeKind.Utc).AddTicks(2700), "Turkish translation for Navigation.GeneralSettings", "Navigation.GeneralSettings", "Genel Ayarlar" });

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 99,
                columns: new[] { "CreatedAt", "Description", "Key", "Value" },
                values: new object[] { new DateTime(2025, 10, 31, 12, 51, 20, 467, DateTimeKind.Utc).AddTicks(2701), "Turkish translation for Navigation.Countries", "Navigation.Countries", "Ülkeler" });

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 100,
                columns: new[] { "CreatedAt", "Description", "Key", "Value" },
                values: new object[] { new DateTime(2025, 10, 31, 12, 51, 20, 467, DateTimeKind.Utc).AddTicks(2702), "Turkish translation for Navigation.Languages", "Navigation.Languages", "Diller" });

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 101,
                columns: new[] { "CreatedAt", "Description", "Key", "Value" },
                values: new object[] { new DateTime(2025, 10, 31, 12, 51, 20, 467, DateTimeKind.Utc).AddTicks(2739), "Turkish translation for Navigation.Profile", "Navigation.Profile", "Profil" });

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 102,
                columns: new[] { "CreatedAt", "Description", "Key", "Value" },
                values: new object[] { new DateTime(2025, 10, 31, 12, 51, 20, 467, DateTimeKind.Utc).AddTicks(2741), "Turkish translation for Navigation.Help", "Navigation.Help", "Yardım" });

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 103,
                columns: new[] { "CreatedAt", "Description", "Key", "Value" },
                values: new object[] { new DateTime(2025, 10, 31, 12, 51, 20, 467, DateTimeKind.Utc).AddTicks(2741), "Turkish translation for Navigation.Logout", "Navigation.Logout", "Çıkış" });

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 104,
                columns: new[] { "Category", "CreatedAt", "Description", "Key", "Value" },
                values: new object[] { "Language", new DateTime(2025, 10, 31, 12, 51, 20, 467, DateTimeKind.Utc).AddTicks(2744), "Turkish translation for Language.English", "Language.English", "İngilizce" });

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 105,
                columns: new[] { "Category", "CreatedAt", "Description", "Key", "Value" },
                values: new object[] { "Language", new DateTime(2025, 10, 31, 12, 51, 20, 467, DateTimeKind.Utc).AddTicks(2745), "Turkish translation for Language.Turkish", "Language.Turkish", "Türkçe" });

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 106,
                columns: new[] { "Category", "CreatedAt", "Description", "Key", "Value" },
                values: new object[] { "Dashboard", new DateTime(2025, 10, 31, 12, 51, 20, 467, DateTimeKind.Utc).AddTicks(2747), "Turkish translation for Dashboard.Title", "Dashboard.Title", "Dashboard" });

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 107,
                columns: new[] { "Category", "CreatedAt", "Description", "Key", "Value" },
                values: new object[] { "Dashboard", new DateTime(2025, 10, 31, 12, 51, 20, 467, DateTimeKind.Utc).AddTicks(2748), "Turkish translation for Dashboard.WelcomeMessage", "Dashboard.WelcomeMessage", "Hoş geldin! CMS analitiklerin ve son aktivitelerin özeti burada." });

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 108,
                columns: new[] { "Category", "CreatedAt", "Description", "Key", "Value" },
                values: new object[] { "Dashboard", new DateTime(2025, 10, 31, 12, 51, 20, 467, DateTimeKind.Utc).AddTicks(2749), "Turkish translation for Dashboard.Last7Days", "Dashboard.Last7Days", "Son 7 gün" });

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 109,
                columns: new[] { "Category", "CreatedAt", "Description", "Key", "Value" },
                values: new object[] { "Dashboard", new DateTime(2025, 10, 31, 12, 51, 20, 467, DateTimeKind.Utc).AddTicks(2750), "Turkish translation for Dashboard.Last30Days", "Dashboard.Last30Days", "Son 30 gün" });

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 110,
                columns: new[] { "Category", "CreatedAt", "Description", "Key", "Value" },
                values: new object[] { "Dashboard", new DateTime(2025, 10, 31, 12, 51, 20, 467, DateTimeKind.Utc).AddTicks(2751), "Turkish translation for Dashboard.Last90Days", "Dashboard.Last90Days", "Son 90 gün" });

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 111,
                columns: new[] { "CreatedAt", "Description", "Key", "Value" },
                values: new object[] { new DateTime(2025, 10, 31, 12, 51, 20, 467, DateTimeKind.Utc).AddTicks(2752), "Turkish translation for Dashboard.TotalUsers", "Dashboard.TotalUsers", "Toplam Kullanıcı" });

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 112,
                columns: new[] { "CreatedAt", "Description", "Key", "Value" },
                values: new object[] { new DateTime(2025, 10, 31, 12, 51, 20, 467, DateTimeKind.Utc).AddTicks(2752), "Turkish translation for Dashboard.TotalRevenue", "Dashboard.TotalRevenue", "Toplam Gelir" });

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 113,
                columns: new[] { "CreatedAt", "Description", "Key", "Value" },
                values: new object[] { new DateTime(2025, 10, 31, 12, 51, 20, 467, DateTimeKind.Utc).AddTicks(2753), "Turkish translation for Dashboard.Products", "Dashboard.Products", "Ürünler" });

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 114,
                columns: new[] { "CreatedAt", "Description", "Key", "Value" },
                values: new object[] { new DateTime(2025, 10, 31, 12, 51, 20, 467, DateTimeKind.Utc).AddTicks(2754), "Turkish translation for Dashboard.SupportTickets", "Dashboard.SupportTickets", "Destek Biletleri" });

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 115,
                columns: new[] { "CreatedAt", "Description", "Key", "Value" },
                values: new object[] { new DateTime(2025, 10, 31, 12, 51, 20, 467, DateTimeKind.Utc).AddTicks(2755), "Turkish translation for Dashboard.FromLastMonth", "Dashboard.FromLastMonth", "geçen aydan" });

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 116,
                columns: new[] { "CreatedAt", "Description", "Key", "Value" },
                values: new object[] { new DateTime(2025, 10, 31, 12, 51, 20, 467, DateTimeKind.Utc).AddTicks(2755), "Turkish translation for Dashboard.SalesOverview", "Dashboard.SalesOverview", "Satış Genel Bakış" });

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 117,
                columns: new[] { "CreatedAt", "Description", "Key", "Value" },
                values: new object[] { new DateTime(2025, 10, 31, 12, 51, 20, 467, DateTimeKind.Utc).AddTicks(2756), "Turkish translation for Dashboard.Monthly", "Dashboard.Monthly", "Aylık" });

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 118,
                columns: new[] { "CreatedAt", "Description", "Key", "Value" },
                values: new object[] { new DateTime(2025, 10, 31, 12, 51, 20, 467, DateTimeKind.Utc).AddTicks(2757), "Turkish translation for Dashboard.ChartVisualization", "Dashboard.ChartVisualization", "Grafik görselleştirmesi burada olacak" });

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 119,
                columns: new[] { "CreatedAt", "Description", "Key", "Value" },
                values: new object[] { new DateTime(2025, 10, 31, 12, 51, 20, 467, DateTimeKind.Utc).AddTicks(2758), "Turkish translation for Dashboard.ThisYear", "Dashboard.ThisYear", "Bu Yıl" });

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 120,
                columns: new[] { "CreatedAt", "Description", "Key", "Value" },
                values: new object[] { new DateTime(2025, 10, 31, 12, 51, 20, 467, DateTimeKind.Utc).AddTicks(2759), "Turkish translation for Dashboard.LastYear", "Dashboard.LastYear", "Geçen Yıl" });

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 121,
                columns: new[] { "CreatedAt", "Description", "Key", "Value" },
                values: new object[] { new DateTime(2025, 10, 31, 12, 51, 20, 467, DateTimeKind.Utc).AddTicks(2759), "Turkish translation for Dashboard.RecentActivities", "Dashboard.RecentActivities", "Son Aktiviteler" });

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 122,
                columns: new[] { "CreatedAt", "Description", "Key", "Value" },
                values: new object[] { new DateTime(2025, 10, 31, 12, 51, 20, 467, DateTimeKind.Utc).AddTicks(2760), "Turkish translation for Dashboard.TopProducts", "Dashboard.TopProducts", "En İyi Ürünler" });

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 123,
                columns: new[] { "CreatedAt", "Description", "Key", "Value" },
                values: new object[] { new DateTime(2025, 10, 31, 12, 51, 20, 467, DateTimeKind.Utc).AddTicks(2761), "Turkish translation for Dashboard.Product", "Dashboard.Product", "Ürün" });

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 124,
                columns: new[] { "CreatedAt", "Description", "Key", "Value" },
                values: new object[] { new DateTime(2025, 10, 31, 12, 51, 20, 467, DateTimeKind.Utc).AddTicks(2762), "Turkish translation for Dashboard.Category", "Dashboard.Category", "Kategori" });

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 125,
                columns: new[] { "CreatedAt", "Description", "Key", "Value" },
                values: new object[] { new DateTime(2025, 10, 31, 12, 51, 20, 467, DateTimeKind.Utc).AddTicks(2762), "Turkish translation for Dashboard.Sales", "Dashboard.Sales", "Satışlar" });

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 126,
                columns: new[] { "CreatedAt", "Description", "Key", "Value" },
                values: new object[] { new DateTime(2025, 10, 31, 12, 51, 20, 467, DateTimeKind.Utc).AddTicks(2763), "Turkish translation for Dashboard.Status", "Dashboard.Status", "Durum" });

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 127,
                columns: new[] { "CreatedAt", "Description", "Key", "Value" },
                values: new object[] { new DateTime(2025, 10, 31, 12, 51, 20, 467, DateTimeKind.Utc).AddTicks(2764), "Turkish translation for Dashboard.LatestOrders", "Dashboard.LatestOrders", "Son Siparişler" });

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 128,
                columns: new[] { "CreatedAt", "Description", "Key", "Value" },
                values: new object[] { new DateTime(2025, 10, 31, 12, 51, 20, 467, DateTimeKind.Utc).AddTicks(2765), "Turkish translation for Dashboard.Today", "Dashboard.Today", "Bugün" });

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 129,
                columns: new[] { "CreatedAt", "Description", "Key", "Value" },
                values: new object[] { new DateTime(2025, 10, 31, 12, 51, 20, 467, DateTimeKind.Utc).AddTicks(2766), "Turkish translation for Dashboard.Yesterday", "Dashboard.Yesterday", "Dün" });

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 130,
                columns: new[] { "CreatedAt", "Description", "Key", "Value" },
                values: new object[] { new DateTime(2025, 10, 31, 12, 51, 20, 467, DateTimeKind.Utc).AddTicks(2794), "Turkish translation for Dashboard.OrderId", "Dashboard.OrderId", "Sipariş ID" });

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 131,
                columns: new[] { "CreatedAt", "Description", "Key", "Value" },
                values: new object[] { new DateTime(2025, 10, 31, 12, 51, 20, 467, DateTimeKind.Utc).AddTicks(2795), "Turkish translation for Dashboard.Customer", "Dashboard.Customer", "Müşteri" });

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 132,
                columns: new[] { "CreatedAt", "Description", "Key", "Value" },
                values: new object[] { new DateTime(2025, 10, 31, 12, 51, 20, 467, DateTimeKind.Utc).AddTicks(2796), "Turkish translation for Dashboard.Date", "Dashboard.Date", "Tarih" });

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 133,
                columns: new[] { "CreatedAt", "Description", "Key", "Value" },
                values: new object[] { new DateTime(2025, 10, 31, 12, 51, 20, 467, DateTimeKind.Utc).AddTicks(2797), "Turkish translation for Dashboard.Amount", "Dashboard.Amount", "Tutar" });

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 134,
                columns: new[] { "Category", "CreatedAt", "Description", "Key", "LanguageId", "Value" },
                values: new object[] { "Common", new DateTime(2025, 10, 31, 12, 51, 20, 467, DateTimeKind.Utc).AddTicks(2799), "English translation for Common.Save", "Common.Save", 2, "Save" });

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 135,
                columns: new[] { "Category", "CreatedAt", "Description", "Key", "LanguageId", "Value" },
                values: new object[] { "Common", new DateTime(2025, 10, 31, 12, 51, 20, 467, DateTimeKind.Utc).AddTicks(2800), "English translation for Common.Cancel", "Common.Cancel", 2, "Cancel" });

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 136,
                columns: new[] { "Category", "CreatedAt", "Description", "Key", "LanguageId", "Value" },
                values: new object[] { "Common", new DateTime(2025, 10, 31, 12, 51, 20, 467, DateTimeKind.Utc).AddTicks(2801), "English translation for Common.Delete", "Common.Delete", 2, "Delete" });

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 137,
                columns: new[] { "Category", "CreatedAt", "Description", "Key", "LanguageId", "Value" },
                values: new object[] { "Common", new DateTime(2025, 10, 31, 12, 51, 20, 467, DateTimeKind.Utc).AddTicks(2802), "English translation for Common.Edit", "Common.Edit", 2, "Edit" });

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 138,
                columns: new[] { "Category", "CreatedAt", "Description", "Key", "LanguageId", "Value" },
                values: new object[] { "Common", new DateTime(2025, 10, 31, 12, 51, 20, 467, DateTimeKind.Utc).AddTicks(2802), "English translation for Common.Add", "Common.Add", 2, "Add" });

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 139,
                columns: new[] { "Category", "CreatedAt", "Description", "Key", "LanguageId", "Value" },
                values: new object[] { "Common", new DateTime(2025, 10, 31, 12, 51, 20, 467, DateTimeKind.Utc).AddTicks(2803), "English translation for Common.Update", "Common.Update", 2, "Update" });

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 140,
                columns: new[] { "Category", "CreatedAt", "Description", "Key", "LanguageId", "Value" },
                values: new object[] { "Common", new DateTime(2025, 10, 31, 12, 51, 20, 467, DateTimeKind.Utc).AddTicks(2804), "English translation for Common.Create", "Common.Create", 2, "Create" });

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 141,
                columns: new[] { "Category", "CreatedAt", "Description", "Key", "LanguageId", "Value" },
                values: new object[] { "Common", new DateTime(2025, 10, 31, 12, 51, 20, 467, DateTimeKind.Utc).AddTicks(2805), "English translation for Common.Remove", "Common.Remove", 2, "Remove" });

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 142,
                columns: new[] { "Category", "CreatedAt", "Description", "Key", "LanguageId", "Value" },
                values: new object[] { "Common", new DateTime(2025, 10, 31, 12, 51, 20, 467, DateTimeKind.Utc).AddTicks(2806), "English translation for Common.Search", "Common.Search", 2, "Search" });

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 143,
                columns: new[] { "Category", "CreatedAt", "Description", "Key", "LanguageId", "Value" },
                values: new object[] { "Common", new DateTime(2025, 10, 31, 12, 51, 20, 467, DateTimeKind.Utc).AddTicks(2807), "English translation for Common.Filter", "Common.Filter", 2, "Filter" });

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 144,
                columns: new[] { "Category", "CreatedAt", "Description", "Key", "LanguageId", "Value" },
                values: new object[] { "Common", new DateTime(2025, 10, 31, 12, 51, 20, 467, DateTimeKind.Utc).AddTicks(2808), "English translation for Common.Export", "Common.Export", 2, "Export" });

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 145,
                columns: new[] { "Category", "CreatedAt", "Description", "Key", "LanguageId", "Value" },
                values: new object[] { "Common", new DateTime(2025, 10, 31, 12, 51, 20, 467, DateTimeKind.Utc).AddTicks(2808), "English translation for Common.Import", "Common.Import", 2, "Import" });

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 146,
                columns: new[] { "Category", "CreatedAt", "Description", "Key", "LanguageId", "Value" },
                values: new object[] { "Common", new DateTime(2025, 10, 31, 12, 51, 20, 467, DateTimeKind.Utc).AddTicks(2809), "English translation for Common.Upload", "Common.Upload", 2, "Upload" });

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 147,
                columns: new[] { "Category", "CreatedAt", "Description", "Key", "LanguageId", "Value" },
                values: new object[] { "Common", new DateTime(2025, 10, 31, 12, 51, 20, 467, DateTimeKind.Utc).AddTicks(2810), "English translation for Common.Download", "Common.Download", 2, "Download" });

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 148,
                columns: new[] { "Category", "CreatedAt", "Description", "Key", "LanguageId", "Value" },
                values: new object[] { "Common", new DateTime(2025, 10, 31, 12, 51, 20, 467, DateTimeKind.Utc).AddTicks(2811), "English translation for Common.Preview", "Common.Preview", 2, "Preview" });

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 149,
                columns: new[] { "Category", "CreatedAt", "Description", "Key", "LanguageId", "Value" },
                values: new object[] { "Common", new DateTime(2025, 10, 31, 12, 51, 20, 467, DateTimeKind.Utc).AddTicks(2812), "English translation for Common.Publish", "Common.Publish", 2, "Publish" });

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 150,
                columns: new[] { "Category", "CreatedAt", "Description", "Key", "LanguageId", "Value" },
                values: new object[] { "Common", new DateTime(2025, 10, 31, 12, 51, 20, 467, DateTimeKind.Utc).AddTicks(2813), "English translation for Common.Draft", "Common.Draft", 2, "Draft" });

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 151,
                columns: new[] { "Category", "CreatedAt", "Description", "Key", "LanguageId", "Value" },
                values: new object[] { "Common", new DateTime(2025, 10, 31, 12, 51, 20, 467, DateTimeKind.Utc).AddTicks(2814), "English translation for Common.Active", "Common.Active", 2, "Active" });

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 152,
                columns: new[] { "Category", "CreatedAt", "Description", "Key", "LanguageId", "Value" },
                values: new object[] { "Common", new DateTime(2025, 10, 31, 12, 51, 20, 467, DateTimeKind.Utc).AddTicks(2814), "English translation for Common.Inactive", "Common.Inactive", 2, "Inactive" });

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 153,
                columns: new[] { "Category", "CreatedAt", "Description", "Key", "LanguageId", "Value" },
                values: new object[] { "Common", new DateTime(2025, 10, 31, 12, 51, 20, 467, DateTimeKind.Utc).AddTicks(2815), "English translation for Common.Yes", "Common.Yes", 2, "Yes" });

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 154,
                columns: new[] { "Category", "CreatedAt", "Description", "Key", "LanguageId", "Value" },
                values: new object[] { "Common", new DateTime(2025, 10, 31, 12, 51, 20, 467, DateTimeKind.Utc).AddTicks(2816), "English translation for Common.No", "Common.No", 2, "No" });

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 155,
                columns: new[] { "Category", "CreatedAt", "Description", "Key", "LanguageId", "Value" },
                values: new object[] { "Common", new DateTime(2025, 10, 31, 12, 51, 20, 467, DateTimeKind.Utc).AddTicks(2817), "English translation for Common.OK", "Common.OK", 2, "OK" });

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 156,
                columns: new[] { "Category", "CreatedAt", "Description", "Key", "LanguageId", "Value" },
                values: new object[] { "Common", new DateTime(2025, 10, 31, 12, 51, 20, 467, DateTimeKind.Utc).AddTicks(2818), "English translation for Common.Close", "Common.Close", 2, "Close" });

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 157,
                columns: new[] { "Category", "CreatedAt", "Description", "Key", "LanguageId", "Value" },
                values: new object[] { "Common", new DateTime(2025, 10, 31, 12, 51, 20, 467, DateTimeKind.Utc).AddTicks(2818), "English translation for Common.Back", "Common.Back", 2, "Back" });

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 158,
                columns: new[] { "Category", "CreatedAt", "Description", "Key", "LanguageId", "Value" },
                values: new object[] { "Common", new DateTime(2025, 10, 31, 12, 51, 20, 467, DateTimeKind.Utc).AddTicks(2819), "English translation for Common.Next", "Common.Next", 2, "Next" });

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 159,
                columns: new[] { "Category", "CreatedAt", "Description", "Key", "LanguageId", "Value" },
                values: new object[] { "Common", new DateTime(2025, 10, 31, 12, 51, 20, 467, DateTimeKind.Utc).AddTicks(2820), "English translation for Common.Previous", "Common.Previous", 2, "Previous" });

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 160,
                columns: new[] { "Category", "CreatedAt", "Description", "Key", "LanguageId", "Value" },
                values: new object[] { "Common", new DateTime(2025, 10, 31, 12, 51, 20, 467, DateTimeKind.Utc).AddTicks(2821), "English translation for Common.Loading", "Common.Loading", 2, "Loading..." });

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 161,
                columns: new[] { "Category", "CreatedAt", "Description", "Key", "LanguageId", "Value" },
                values: new object[] { "Common", new DateTime(2025, 10, 31, 12, 51, 20, 467, DateTimeKind.Utc).AddTicks(2822), "English translation for Common.Success", "Common.Success", 2, "Success" });

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 162,
                columns: new[] { "Category", "CreatedAt", "Description", "Key", "LanguageId", "Value" },
                values: new object[] { "Common", new DateTime(2025, 10, 31, 12, 51, 20, 467, DateTimeKind.Utc).AddTicks(2822), "English translation for Common.Error", "Common.Error", 2, "Error" });

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 163,
                columns: new[] { "Category", "CreatedAt", "Description", "Key", "LanguageId", "Value" },
                values: new object[] { "Common", new DateTime(2025, 10, 31, 12, 51, 20, 467, DateTimeKind.Utc).AddTicks(2823), "English translation for Common.Warning", "Common.Warning", 2, "Warning" });

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 164,
                columns: new[] { "CreatedAt", "Description", "Key", "Value" },
                values: new object[] { new DateTime(2025, 10, 31, 12, 51, 20, 467, DateTimeKind.Utc).AddTicks(2824), "English translation for Common.Info", "Common.Info", "Info" });

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 165,
                columns: new[] { "CreatedAt", "Description", "Key", "Value" },
                values: new object[] { new DateTime(2025, 10, 31, 12, 51, 20, 467, DateTimeKind.Utc).AddTicks(2846), "English translation for Common.Refresh", "Common.Refresh", "Refresh" });

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 166,
                columns: new[] { "CreatedAt", "Description", "Key", "Value" },
                values: new object[] { new DateTime(2025, 10, 31, 12, 51, 20, 467, DateTimeKind.Utc).AddTicks(2847), "English translation for Common.Settings", "Common.Settings", "Settings" });

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 167,
                columns: new[] { "CreatedAt", "Description", "Key", "Value" },
                values: new object[] { new DateTime(2025, 10, 31, 12, 51, 20, 467, DateTimeKind.Utc).AddTicks(2848), "English translation for Common.ViewAll", "Common.ViewAll", "View All" });

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 168,
                columns: new[] { "Category", "CreatedAt", "Description", "Key", "Value" },
                values: new object[] { "Page", new DateTime(2025, 10, 31, 12, 51, 20, 467, DateTimeKind.Utc).AddTicks(2851), "English translation for Page.Title", "Page.Title", "Page Title" });

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 169,
                columns: new[] { "Category", "CreatedAt", "Description", "Key", "Value" },
                values: new object[] { "Page", new DateTime(2025, 10, 31, 12, 51, 20, 467, DateTimeKind.Utc).AddTicks(2852), "English translation for Page.Content", "Page.Content", "Page Content" });

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 170,
                columns: new[] { "Category", "CreatedAt", "Description", "Key", "Value" },
                values: new object[] { "Page", new DateTime(2025, 10, 31, 12, 51, 20, 467, DateTimeKind.Utc).AddTicks(2852), "English translation for Page.Description", "Page.Description", "Page Description" });

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 171,
                columns: new[] { "Category", "CreatedAt", "Description", "Key", "Value" },
                values: new object[] { "Page", new DateTime(2025, 10, 31, 12, 51, 20, 467, DateTimeKind.Utc).AddTicks(2853), "English translation for Page.Keywords", "Page.Keywords", "Keywords" });

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 172,
                columns: new[] { "Category", "CreatedAt", "Description", "Key", "Value" },
                values: new object[] { "Page", new DateTime(2025, 10, 31, 12, 51, 20, 467, DateTimeKind.Utc).AddTicks(2854), "English translation for Page.Author", "Page.Author", "Author" });

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 173,
                columns: new[] { "Category", "CreatedAt", "Description", "Key", "Value" },
                values: new object[] { "Page", new DateTime(2025, 10, 31, 12, 51, 20, 467, DateTimeKind.Utc).AddTicks(2855), "English translation for Page.CreatedAt", "Page.CreatedAt", "Created At" });

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 174,
                columns: new[] { "Category", "CreatedAt", "Description", "Key", "Value" },
                values: new object[] { "Page", new DateTime(2025, 10, 31, 12, 51, 20, 467, DateTimeKind.Utc).AddTicks(2856), "English translation for Page.UpdatedAt", "Page.UpdatedAt", "Updated At" });

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 175,
                columns: new[] { "Category", "CreatedAt", "Description", "Key", "Value" },
                values: new object[] { "Page", new DateTime(2025, 10, 31, 12, 51, 20, 467, DateTimeKind.Utc).AddTicks(2856), "English translation for Page.Status", "Page.Status", "Status" });

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 176,
                columns: new[] { "Category", "CreatedAt", "Description", "Key", "Value" },
                values: new object[] { "Page", new DateTime(2025, 10, 31, 12, 51, 20, 467, DateTimeKind.Utc).AddTicks(2857), "English translation for Page.Type", "Page.Type", "Page Type" });

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 177,
                columns: new[] { "Category", "CreatedAt", "Description", "Key", "Value" },
                values: new object[] { "Page", new DateTime(2025, 10, 31, 12, 51, 20, 467, DateTimeKind.Utc).AddTicks(2858), "English translation for Page.Layout", "Page.Layout", "Layout" });

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 178,
                columns: new[] { "Category", "CreatedAt", "Description", "Key", "Value" },
                values: new object[] { "Page", new DateTime(2025, 10, 31, 12, 51, 20, 467, DateTimeKind.Utc).AddTicks(2859), "English translation for Page.Template", "Page.Template", "Template" });

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 179,
                columns: new[] { "Category", "CreatedAt", "Description", "Key", "Value" },
                values: new object[] { "Page", new DateTime(2025, 10, 31, 12, 51, 20, 467, DateTimeKind.Utc).AddTicks(2860), "English translation for Page.SEO", "Page.SEO", "SEO Settings" });

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 180,
                columns: new[] { "Category", "CreatedAt", "Description", "Key", "Value" },
                values: new object[] { "Page", new DateTime(2025, 10, 31, 12, 51, 20, 467, DateTimeKind.Utc).AddTicks(2860), "English translation for Page.Sections", "Page.Sections", "Sections" });

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 181,
                columns: new[] { "Category", "CreatedAt", "Description", "Key", "Value" },
                values: new object[] { "Page", new DateTime(2025, 10, 31, 12, 51, 20, 467, DateTimeKind.Utc).AddTicks(2861), "English translation for Page.Items", "Page.Items", "Items" });

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 182,
                columns: new[] { "Category", "CreatedAt", "Description", "Key", "Value" },
                values: new object[] { "Page", new DateTime(2025, 10, 31, 12, 51, 20, 467, DateTimeKind.Utc).AddTicks(2862), "English translation for Page.Fields", "Page.Fields", "Fields" });

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 183,
                columns: new[] { "Category", "CreatedAt", "Description", "Key", "Value" },
                values: new object[] { "Section", new DateTime(2025, 10, 31, 12, 51, 20, 467, DateTimeKind.Utc).AddTicks(2864), "English translation for Section.Name", "Section.Name", "Section Name" });

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 184,
                columns: new[] { "Category", "CreatedAt", "Description", "Key", "Value" },
                values: new object[] { "Section", new DateTime(2025, 10, 31, 12, 51, 20, 467, DateTimeKind.Utc).AddTicks(2865), "English translation for Section.Type", "Section.Type", "Section Type" });

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 185,
                columns: new[] { "Category", "CreatedAt", "Description", "Key", "Value" },
                values: new object[] { "Section", new DateTime(2025, 10, 31, 12, 51, 20, 467, DateTimeKind.Utc).AddTicks(2866), "English translation for Section.Key", "Section.Key", "Section Key" });

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 186,
                columns: new[] { "Category", "CreatedAt", "Description", "Key", "Value" },
                values: new object[] { "Section", new DateTime(2025, 10, 31, 12, 51, 20, 467, DateTimeKind.Utc).AddTicks(2867), "English translation for Section.Order", "Section.Order", "Order" });

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 187,
                columns: new[] { "Category", "CreatedAt", "Description", "Key", "Value" },
                values: new object[] { "Section", new DateTime(2025, 10, 31, 12, 51, 20, 467, DateTimeKind.Utc).AddTicks(2906), "English translation for Section.Settings", "Section.Settings", "Settings" });

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 188,
                columns: new[] { "Category", "CreatedAt", "Description", "Key", "Value" },
                values: new object[] { "Section", new DateTime(2025, 10, 31, 12, 51, 20, 467, DateTimeKind.Utc).AddTicks(2907), "English translation for Section.Items", "Section.Items", "Items" });

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 189,
                columns: new[] { "Category", "CreatedAt", "Description", "Key", "Value" },
                values: new object[] { "Section", new DateTime(2025, 10, 31, 12, 51, 20, 467, DateTimeKind.Utc).AddTicks(2908), "English translation for Section.AddItem", "Section.AddItem", "Add Item" });

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 190,
                columns: new[] { "Category", "CreatedAt", "Description", "Key", "Value" },
                values: new object[] { "Section", new DateTime(2025, 10, 31, 12, 51, 20, 467, DateTimeKind.Utc).AddTicks(2909), "English translation for Section.EditItems", "Section.EditItems", "Edit Items" });

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 191,
                columns: new[] { "Category", "CreatedAt", "Description", "Key", "Value" },
                values: new object[] { "Section", new DateTime(2025, 10, 31, 12, 51, 20, 467, DateTimeKind.Utc).AddTicks(2909), "English translation for Section.Duplicate", "Section.Duplicate", "Duplicate" });

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 192,
                columns: new[] { "Category", "CreatedAt", "Description", "Key", "Value" },
                values: new object[] { "Section", new DateTime(2025, 10, 31, 12, 51, 20, 467, DateTimeKind.Utc).AddTicks(2910), "English translation for Section.Remove", "Section.Remove", "Remove" });

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 193,
                columns: new[] { "Category", "CreatedAt", "Description", "Key", "Value" },
                values: new object[] { "Section", new DateTime(2025, 10, 31, 12, 51, 20, 467, DateTimeKind.Utc).AddTicks(2911), "English translation for Section.Hero", "Section.Hero", "Hero Section" });

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 194,
                columns: new[] { "Category", "CreatedAt", "Description", "Key", "Value" },
                values: new object[] { "Section", new DateTime(2025, 10, 31, 12, 51, 20, 467, DateTimeKind.Utc).AddTicks(2912), "English translation for Section.Navbar", "Section.Navbar", "Navigation" });

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 195,
                columns: new[] { "Category", "CreatedAt", "Description", "Key", "Value" },
                values: new object[] { "Section", new DateTime(2025, 10, 31, 12, 51, 20, 467, DateTimeKind.Utc).AddTicks(2913), "English translation for Section.Footer", "Section.Footer", "Footer" });

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 196,
                columns: new[] { "Category", "CreatedAt", "Description", "Key", "Value" },
                values: new object[] { "Section", new DateTime(2025, 10, 31, 12, 51, 20, 467, DateTimeKind.Utc).AddTicks(2913), "English translation for Section.Content", "Section.Content", "Content" });

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 197,
                columns: new[] { "Category", "CreatedAt", "Description", "Key", "Value" },
                values: new object[] { "Section", new DateTime(2025, 10, 31, 12, 51, 20, 467, DateTimeKind.Utc).AddTicks(2914), "English translation for Section.Gallery", "Section.Gallery", "Gallery" });

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 198,
                columns: new[] { "Category", "CreatedAt", "Description", "Key", "Value" },
                values: new object[] { "Section", new DateTime(2025, 10, 31, 12, 51, 20, 467, DateTimeKind.Utc).AddTicks(2915), "English translation for Section.Contact", "Section.Contact", "Contact" });

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 199,
                columns: new[] { "Category", "CreatedAt", "Description", "Key", "Value" },
                values: new object[] { "Validation", new DateTime(2025, 10, 31, 12, 51, 20, 467, DateTimeKind.Utc).AddTicks(2918), "English translation for Validation.Required", "Validation.Required", "This field is required" });

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 200,
                columns: new[] { "Category", "CreatedAt", "Description", "Key", "Value" },
                values: new object[] { "Validation", new DateTime(2025, 10, 31, 12, 51, 20, 467, DateTimeKind.Utc).AddTicks(2919), "English translation for Validation.Email", "Validation.Email", "Please enter a valid email address" });

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 201,
                columns: new[] { "Category", "CreatedAt", "Description", "Key", "Value" },
                values: new object[] { "Validation", new DateTime(2025, 10, 31, 12, 51, 20, 467, DateTimeKind.Utc).AddTicks(2919), "English translation for Validation.MinLength", "Validation.MinLength", "Must be at least {0} characters" });

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 202,
                columns: new[] { "Category", "CreatedAt", "Description", "Key", "Value" },
                values: new object[] { "Validation", new DateTime(2025, 10, 31, 12, 51, 20, 467, DateTimeKind.Utc).AddTicks(2957), "English translation for Validation.MaxLength", "Validation.MaxLength", "Must be at most {0} characters" });

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 203,
                columns: new[] { "Category", "CreatedAt", "Description", "Key", "Value" },
                values: new object[] { "Validation", new DateTime(2025, 10, 31, 12, 51, 20, 467, DateTimeKind.Utc).AddTicks(2958), "English translation for Validation.Range", "Validation.Range", "Must be between {0} and {1}" });

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 204,
                columns: new[] { "Category", "CreatedAt", "Description", "Key", "Value" },
                values: new object[] { "Validation", new DateTime(2025, 10, 31, 12, 51, 20, 467, DateTimeKind.Utc).AddTicks(2959), "English translation for Validation.Numeric", "Validation.Numeric", "Please enter a numeric value" });

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 205,
                columns: new[] { "Category", "CreatedAt", "Description", "Key", "Value" },
                values: new object[] { "Validation", new DateTime(2025, 10, 31, 12, 51, 20, 467, DateTimeKind.Utc).AddTicks(2960), "English translation for Validation.Date", "Validation.Date", "Please enter a valid date" });

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 206,
                columns: new[] { "Category", "CreatedAt", "Description", "Key", "Value" },
                values: new object[] { "Validation", new DateTime(2025, 10, 31, 12, 51, 20, 467, DateTimeKind.Utc).AddTicks(2961), "English translation for Validation.Url", "Validation.Url", "Please enter a valid URL" });

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 207,
                columns: new[] { "Category", "CreatedAt", "Description", "Key", "Value" },
                values: new object[] { "Validation", new DateTime(2025, 10, 31, 12, 51, 20, 467, DateTimeKind.Utc).AddTicks(2962), "English translation for Validation.Phone", "Validation.Phone", "Please enter a valid phone number" });

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 208,
                columns: new[] { "Category", "CreatedAt", "Description", "Key", "Value" },
                values: new object[] { "Validation", new DateTime(2025, 10, 31, 12, 51, 20, 467, DateTimeKind.Utc).AddTicks(2963), "English translation for Validation.Password", "Validation.Password", "Password must be at least 8 characters" });

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 209,
                columns: new[] { "Category", "CreatedAt", "Description", "Key", "Value" },
                values: new object[] { "Navigation", new DateTime(2025, 10, 31, 12, 51, 20, 467, DateTimeKind.Utc).AddTicks(2965), "English translation for Navigation.Dashboard", "Navigation.Dashboard", "Dashboard" });

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 210,
                columns: new[] { "Category", "CreatedAt", "Description", "Key", "Value" },
                values: new object[] { "Navigation", new DateTime(2025, 10, 31, 12, 51, 20, 467, DateTimeKind.Utc).AddTicks(2966), "English translation for Navigation.Announcements", "Navigation.Announcements", "Announcements" });

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 211,
                columns: new[] { "Category", "CreatedAt", "Description", "Key", "Value" },
                values: new object[] { "Navigation", new DateTime(2025, 10, 31, 12, 51, 20, 467, DateTimeKind.Utc).AddTicks(2967), "English translation for Navigation.Campaigns", "Navigation.Campaigns", "Campaigns" });

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 212,
                columns: new[] { "Category", "CreatedAt", "Description", "Key", "Value" },
                values: new object[] { "Navigation", new DateTime(2025, 10, 31, 12, 51, 20, 467, DateTimeKind.Utc).AddTicks(2968), "English translation for Navigation.Content", "Navigation.Content", "Content" });

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 213,
                columns: new[] { "Category", "CreatedAt", "Description", "Key", "Value" },
                values: new object[] { "Navigation", new DateTime(2025, 10, 31, 12, 51, 20, 467, DateTimeKind.Utc).AddTicks(2969), "English translation for Navigation.Pages", "Navigation.Pages", "Pages" });

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 214,
                columns: new[] { "Category", "CreatedAt", "Description", "Key" },
                values: new object[] { "Navigation", new DateTime(2025, 10, 31, 12, 51, 20, 467, DateTimeKind.Utc).AddTicks(2970), "English translation for Navigation.Sections", "Navigation.Sections" });

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 215,
                columns: new[] { "Category", "CreatedAt", "Description", "Key", "Value" },
                values: new object[] { "Navigation", new DateTime(2025, 10, 31, 12, 51, 20, 467, DateTimeKind.Utc).AddTicks(2971), "English translation for Navigation.Layouts", "Navigation.Layouts", "Layouts" });

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 216,
                columns: new[] { "Category", "CreatedAt", "Description", "Key", "Value" },
                values: new object[] { "Navigation", new DateTime(2025, 10, 31, 12, 51, 20, 467, DateTimeKind.Utc).AddTicks(2971), "English translation for Navigation.WebUrlManagement", "Navigation.WebUrlManagement", "Web URL Management" });

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 217,
                columns: new[] { "Category", "CreatedAt", "Description", "Key", "Value" },
                values: new object[] { "Navigation", new DateTime(2025, 10, 31, 12, 51, 20, 467, DateTimeKind.Utc).AddTicks(2972), "English translation for Navigation.News", "Navigation.News", "News" });

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 218,
                columns: new[] { "Category", "CreatedAt", "Description", "Key", "Value" },
                values: new object[] { "Navigation", new DateTime(2025, 10, 31, 12, 51, 20, 467, DateTimeKind.Utc).AddTicks(2973), "English translation for Navigation.Blog", "Navigation.Blog", "Blog" });

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 219,
                columns: new[] { "Category", "CreatedAt", "Description", "Key", "Value" },
                values: new object[] { "Navigation", new DateTime(2025, 10, 31, 12, 51, 20, 467, DateTimeKind.Utc).AddTicks(2974), "English translation for Navigation.Templates", "Navigation.Templates", "Templates" });

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 220,
                columns: new[] { "Category", "CreatedAt", "Description", "Key", "Value" },
                values: new object[] { "Navigation", new DateTime(2025, 10, 31, 12, 51, 20, 467, DateTimeKind.Utc).AddTicks(2974), "English translation for Navigation.SectionItems", "Navigation.SectionItems", "Section Items" });

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 221,
                columns: new[] { "Category", "CreatedAt", "Description", "Key", "Value" },
                values: new object[] { "Navigation", new DateTime(2025, 10, 31, 12, 51, 20, 467, DateTimeKind.Utc).AddTicks(2975), "English translation for Navigation.ECommerce", "Navigation.ECommerce", "E-Commerce" });

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 222,
                columns: new[] { "Category", "CreatedAt", "Description", "Key", "Value" },
                values: new object[] { "Navigation", new DateTime(2025, 10, 31, 12, 51, 20, 467, DateTimeKind.Utc).AddTicks(2976), "English translation for Navigation.Products", "Navigation.Products", "Products" });

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 223,
                columns: new[] { "Category", "CreatedAt", "Description", "Key", "Value" },
                values: new object[] { "Navigation", new DateTime(2025, 10, 31, 12, 51, 20, 467, DateTimeKind.Utc).AddTicks(2977), "English translation for Navigation.Categories", "Navigation.Categories", "Categories" });

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 224,
                columns: new[] { "Category", "CreatedAt", "Description", "Key", "Value" },
                values: new object[] { "Navigation", new DateTime(2025, 10, 31, 12, 51, 20, 467, DateTimeKind.Utc).AddTicks(2977), "English translation for Navigation.Orders", "Navigation.Orders", "Orders" });

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 225,
                columns: new[] { "Category", "CreatedAt", "Description", "Key", "Value" },
                values: new object[] { "Navigation", new DateTime(2025, 10, 31, 12, 51, 20, 467, DateTimeKind.Utc).AddTicks(2978), "English translation for Navigation.Users", "Navigation.Users", "Users" });

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 226,
                columns: new[] { "Category", "CreatedAt", "Description", "Key", "Value" },
                values: new object[] { "Navigation", new DateTime(2025, 10, 31, 12, 51, 20, 467, DateTimeKind.Utc).AddTicks(2979), "English translation for Navigation.ManageUsers", "Navigation.ManageUsers", "Manage Users" });

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 227,
                columns: new[] { "Category", "CreatedAt", "Description", "Key", "Value" },
                values: new object[] { "Navigation", new DateTime(2025, 10, 31, 12, 51, 20, 467, DateTimeKind.Utc).AddTicks(2980), "English translation for Navigation.ManageRoles", "Navigation.ManageRoles", "Manage Roles" });

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 228,
                columns: new[] { "Category", "CreatedAt", "Description", "Key", "Value" },
                values: new object[] { "Navigation", new DateTime(2025, 10, 31, 12, 51, 20, 467, DateTimeKind.Utc).AddTicks(2981), "English translation for Navigation.ManagePermissions", "Navigation.ManagePermissions", "Manage Permissions" });

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 229,
                columns: new[] { "Category", "CreatedAt", "Description", "Key", "Value" },
                values: new object[] { "Navigation", new DateTime(2025, 10, 31, 12, 51, 20, 467, DateTimeKind.Utc).AddTicks(2982), "English translation for Navigation.Analytics", "Navigation.Analytics", "Analytics" });

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 230,
                columns: new[] { "Category", "CreatedAt", "Description", "Key", "Value" },
                values: new object[] { "Navigation", new DateTime(2025, 10, 31, 12, 51, 20, 467, DateTimeKind.Utc).AddTicks(2982), "English translation for Navigation.Settings", "Navigation.Settings", "Settings" });

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 231,
                columns: new[] { "Category", "CreatedAt", "Description", "Key", "Value" },
                values: new object[] { "Navigation", new DateTime(2025, 10, 31, 12, 51, 20, 467, DateTimeKind.Utc).AddTicks(2983), "English translation for Navigation.GeneralSettings", "Navigation.GeneralSettings", "General Settings" });

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 232,
                columns: new[] { "Category", "CreatedAt", "Description", "Key", "Value" },
                values: new object[] { "Navigation", new DateTime(2025, 10, 31, 12, 51, 20, 467, DateTimeKind.Utc).AddTicks(2984), "English translation for Navigation.Countries", "Navigation.Countries", "Countries" });

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 233,
                columns: new[] { "Category", "CreatedAt", "Description", "Key", "Value" },
                values: new object[] { "Navigation", new DateTime(2025, 10, 31, 12, 51, 20, 467, DateTimeKind.Utc).AddTicks(2985), "English translation for Navigation.Languages", "Navigation.Languages", "Languages" });

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 234,
                columns: new[] { "Category", "CreatedAt", "Description", "Key", "Value" },
                values: new object[] { "Navigation", new DateTime(2025, 10, 31, 12, 51, 20, 467, DateTimeKind.Utc).AddTicks(2985), "English translation for Navigation.Profile", "Navigation.Profile", "Profile" });

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 235,
                columns: new[] { "Category", "CreatedAt", "Description", "Key", "Value" },
                values: new object[] { "Navigation", new DateTime(2025, 10, 31, 12, 51, 20, 467, DateTimeKind.Utc).AddTicks(2986), "English translation for Navigation.Help", "Navigation.Help", "Help" });

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 236,
                columns: new[] { "Category", "CreatedAt", "Description", "Key", "Value" },
                values: new object[] { "Navigation", new DateTime(2025, 10, 31, 12, 51, 20, 467, DateTimeKind.Utc).AddTicks(2987), "English translation for Navigation.Logout", "Navigation.Logout", "Logout" });

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 237,
                columns: new[] { "Category", "CreatedAt", "Description", "Key", "Value" },
                values: new object[] { "Language", new DateTime(2025, 10, 31, 12, 51, 20, 467, DateTimeKind.Utc).AddTicks(3011), "English translation for Language.English", "Language.English", "English" });

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 238,
                columns: new[] { "Category", "CreatedAt", "Description", "Key", "Value" },
                values: new object[] { "Language", new DateTime(2025, 10, 31, 12, 51, 20, 467, DateTimeKind.Utc).AddTicks(3012), "English translation for Language.Turkish", "Language.Turkish", "Turkish" });

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 239,
                columns: new[] { "Category", "CreatedAt", "Description", "Key", "Value" },
                values: new object[] { "Dashboard", new DateTime(2025, 10, 31, 12, 51, 20, 467, DateTimeKind.Utc).AddTicks(3015), "English translation for Dashboard.Title", "Dashboard.Title", "Dashboard" });

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 240,
                columns: new[] { "Category", "CreatedAt", "Description", "Key", "Value" },
                values: new object[] { "Dashboard", new DateTime(2025, 10, 31, 12, 51, 20, 467, DateTimeKind.Utc).AddTicks(3016), "English translation for Dashboard.WelcomeMessage", "Dashboard.WelcomeMessage", "Welcome back! Here's a summary of your CMS analytics and recent activity." });

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 241,
                columns: new[] { "Category", "CreatedAt", "Description", "Key", "Value" },
                values: new object[] { "Dashboard", new DateTime(2025, 10, 31, 12, 51, 20, 467, DateTimeKind.Utc).AddTicks(3017), "English translation for Dashboard.Last7Days", "Dashboard.Last7Days", "Last 7 days" });

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 242,
                columns: new[] { "Category", "CreatedAt", "Description", "Key", "Value" },
                values: new object[] { "Dashboard", new DateTime(2025, 10, 31, 12, 51, 20, 467, DateTimeKind.Utc).AddTicks(3017), "English translation for Dashboard.Last30Days", "Dashboard.Last30Days", "Last 30 days" });

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 243,
                columns: new[] { "Category", "CreatedAt", "Description", "Key", "Value" },
                values: new object[] { "Dashboard", new DateTime(2025, 10, 31, 12, 51, 20, 467, DateTimeKind.Utc).AddTicks(3018), "English translation for Dashboard.Last90Days", "Dashboard.Last90Days", "Last 90 days" });

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 244,
                columns: new[] { "Category", "CreatedAt", "Description", "Key", "Value" },
                values: new object[] { "Dashboard", new DateTime(2025, 10, 31, 12, 51, 20, 467, DateTimeKind.Utc).AddTicks(3019), "English translation for Dashboard.TotalUsers", "Dashboard.TotalUsers", "Total Users" });

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 245,
                columns: new[] { "Category", "CreatedAt", "Description", "Key", "Value" },
                values: new object[] { "Dashboard", new DateTime(2025, 10, 31, 12, 51, 20, 467, DateTimeKind.Utc).AddTicks(3020), "English translation for Dashboard.TotalRevenue", "Dashboard.TotalRevenue", "Total Revenue" });

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 246,
                columns: new[] { "Category", "CreatedAt", "Description", "Key", "Value" },
                values: new object[] { "Dashboard", new DateTime(2025, 10, 31, 12, 51, 20, 467, DateTimeKind.Utc).AddTicks(3021), "English translation for Dashboard.Products", "Dashboard.Products", "Products" });

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 247,
                columns: new[] { "Category", "CreatedAt", "Description", "Key", "Value" },
                values: new object[] { "Dashboard", new DateTime(2025, 10, 31, 12, 51, 20, 467, DateTimeKind.Utc).AddTicks(3021), "English translation for Dashboard.SupportTickets", "Dashboard.SupportTickets", "Support Tickets" });

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 248,
                columns: new[] { "Category", "CreatedAt", "Description", "Key", "Value" },
                values: new object[] { "Dashboard", new DateTime(2025, 10, 31, 12, 51, 20, 467, DateTimeKind.Utc).AddTicks(3022), "English translation for Dashboard.FromLastMonth", "Dashboard.FromLastMonth", "from last month" });

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 249,
                columns: new[] { "Category", "CreatedAt", "Description", "Key", "Value" },
                values: new object[] { "Dashboard", new DateTime(2025, 10, 31, 12, 51, 20, 467, DateTimeKind.Utc).AddTicks(3023), "English translation for Dashboard.SalesOverview", "Dashboard.SalesOverview", "Sales Overview" });

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 250,
                columns: new[] { "Category", "CreatedAt", "Description", "Key", "Value" },
                values: new object[] { "Dashboard", new DateTime(2025, 10, 31, 12, 51, 20, 467, DateTimeKind.Utc).AddTicks(3023), "English translation for Dashboard.Monthly", "Dashboard.Monthly", "Monthly" });

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 251,
                columns: new[] { "Category", "CreatedAt", "Description", "Key", "Value" },
                values: new object[] { "Dashboard", new DateTime(2025, 10, 31, 12, 51, 20, 467, DateTimeKind.Utc).AddTicks(3024), "English translation for Dashboard.ChartVisualization", "Dashboard.ChartVisualization", "Chart visualization goes here" });

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 252,
                columns: new[] { "Category", "CreatedAt", "Description", "Key", "Value" },
                values: new object[] { "Dashboard", new DateTime(2025, 10, 31, 12, 51, 20, 467, DateTimeKind.Utc).AddTicks(3025), "English translation for Dashboard.ThisYear", "Dashboard.ThisYear", "This Year" });

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 253,
                columns: new[] { "Category", "CreatedAt", "Description", "Key", "Value" },
                values: new object[] { "Dashboard", new DateTime(2025, 10, 31, 12, 51, 20, 467, DateTimeKind.Utc).AddTicks(3026), "English translation for Dashboard.LastYear", "Dashboard.LastYear", "Last Year" });

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 254,
                columns: new[] { "Category", "CreatedAt", "Description", "Key", "Value" },
                values: new object[] { "Dashboard", new DateTime(2025, 10, 31, 12, 51, 20, 467, DateTimeKind.Utc).AddTicks(3027), "English translation for Dashboard.RecentActivities", "Dashboard.RecentActivities", "Recent Activities" });

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 255,
                columns: new[] { "Category", "CreatedAt", "Description", "Key", "Value" },
                values: new object[] { "Dashboard", new DateTime(2025, 10, 31, 12, 51, 20, 467, DateTimeKind.Utc).AddTicks(3028), "English translation for Dashboard.TopProducts", "Dashboard.TopProducts", "Top Products" });

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 256,
                columns: new[] { "Category", "CreatedAt", "Description", "Key", "Value" },
                values: new object[] { "Dashboard", new DateTime(2025, 10, 31, 12, 51, 20, 467, DateTimeKind.Utc).AddTicks(3029), "English translation for Dashboard.Product", "Dashboard.Product", "Product" });

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 257,
                columns: new[] { "Category", "CreatedAt", "Description", "Key", "Value" },
                values: new object[] { "Dashboard", new DateTime(2025, 10, 31, 12, 51, 20, 467, DateTimeKind.Utc).AddTicks(3029), "English translation for Dashboard.Category", "Dashboard.Category", "Category" });

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 258,
                columns: new[] { "Category", "CreatedAt", "Description", "Key", "Value" },
                values: new object[] { "Dashboard", new DateTime(2025, 10, 31, 12, 51, 20, 467, DateTimeKind.Utc).AddTicks(3054), "English translation for Dashboard.Sales", "Dashboard.Sales", "Sales" });

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 259,
                columns: new[] { "Category", "CreatedAt", "Description", "Key", "Value" },
                values: new object[] { "Dashboard", new DateTime(2025, 10, 31, 12, 51, 20, 467, DateTimeKind.Utc).AddTicks(3055), "English translation for Dashboard.Status", "Dashboard.Status", "Status" });

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 260,
                columns: new[] { "Category", "CreatedAt", "Description", "Key", "Value" },
                values: new object[] { "Dashboard", new DateTime(2025, 10, 31, 12, 51, 20, 467, DateTimeKind.Utc).AddTicks(3056), "English translation for Dashboard.LatestOrders", "Dashboard.LatestOrders", "Latest Orders" });

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 261,
                columns: new[] { "Category", "CreatedAt", "Description", "Key", "Value" },
                values: new object[] { "Dashboard", new DateTime(2025, 10, 31, 12, 51, 20, 467, DateTimeKind.Utc).AddTicks(3057), "English translation for Dashboard.Today", "Dashboard.Today", "Today" });

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 262,
                columns: new[] { "Category", "CreatedAt", "Description", "Key", "Value" },
                values: new object[] { "Dashboard", new DateTime(2025, 10, 31, 12, 51, 20, 467, DateTimeKind.Utc).AddTicks(3058), "English translation for Dashboard.Yesterday", "Dashboard.Yesterday", "Yesterday" });

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 263,
                columns: new[] { "Category", "CreatedAt", "Description", "Key", "Value" },
                values: new object[] { "Dashboard", new DateTime(2025, 10, 31, 12, 51, 20, 467, DateTimeKind.Utc).AddTicks(3059), "English translation for Dashboard.OrderId", "Dashboard.OrderId", "Order ID" });

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 264,
                columns: new[] { "Category", "CreatedAt", "Description", "Key", "Value" },
                values: new object[] { "Dashboard", new DateTime(2025, 10, 31, 12, 51, 20, 467, DateTimeKind.Utc).AddTicks(3060), "English translation for Dashboard.Customer", "Dashboard.Customer", "Customer" });

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 265,
                columns: new[] { "Category", "CreatedAt", "Description", "Key", "Value" },
                values: new object[] { "Dashboard", new DateTime(2025, 10, 31, 12, 51, 20, 467, DateTimeKind.Utc).AddTicks(3061), "English translation for Dashboard.Date", "Dashboard.Date", "Date" });

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 266,
                columns: new[] { "Category", "CreatedAt", "Description", "Key", "Value" },
                values: new object[] { "Dashboard", new DateTime(2025, 10, 31, 12, 51, 20, 467, DateTimeKind.Utc).AddTicks(3062), "English translation for Dashboard.Amount", "Dashboard.Amount", "Amount" });

            migrationBuilder.UpdateData(
                table: "Pages",
                keyColumn: "Id",
                keyValue: 1,
                column: "Slug",
                value: null);

            migrationBuilder.UpdateData(
                table: "Pages",
                keyColumn: "Id",
                keyValue: 2,
                column: "Slug",
                value: null);

            migrationBuilder.UpdateData(
                table: "Pages",
                keyColumn: "Id",
                keyValue: 3,
                column: "Slug",
                value: null);

            migrationBuilder.UpdateData(
                table: "Pages",
                keyColumn: "Id",
                keyValue: 4,
                column: "Slug",
                value: null);

            migrationBuilder.UpdateData(
                table: "Pages",
                keyColumn: "Id",
                keyValue: 5,
                column: "Slug",
                value: null);

            migrationBuilder.UpdateData(
                table: "Pages",
                keyColumn: "Id",
                keyValue: 6,
                column: "Slug",
                value: null);

            migrationBuilder.UpdateData(
                table: "Pages",
                keyColumn: "Id",
                keyValue: 7,
                column: "Slug",
                value: null);

            migrationBuilder.UpdateData(
                table: "Pages",
                keyColumn: "Id",
                keyValue: 8,
                column: "Slug",
                value: null);

            migrationBuilder.UpdateData(
                table: "Pages",
                keyColumn: "Id",
                keyValue: 9,
                column: "Slug",
                value: null);

            migrationBuilder.UpdateData(
                table: "Pages",
                keyColumn: "Id",
                keyValue: 10,
                column: "Slug",
                value: null);

            migrationBuilder.UpdateData(
                table: "Pages",
                keyColumn: "Id",
                keyValue: 11,
                column: "Slug",
                value: null);

            migrationBuilder.UpdateData(
                table: "Pages",
                keyColumn: "Id",
                keyValue: 12,
                column: "Slug",
                value: null);
        }
    }
}
