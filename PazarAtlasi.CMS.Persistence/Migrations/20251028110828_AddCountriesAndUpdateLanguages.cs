using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace PazarAtlasi.CMS.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AddCountriesAndUpdateLanguages : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Countries",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Code = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    SortOrder = table.Column<int>(type: "int", nullable: false, defaultValue: 0),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<int>(type: "int", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<int>(type: "int", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    Status = table.Column<int>(type: "int", nullable: false, defaultValue: 1)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Countries", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Code", "CreatedAt", "CreatedBy", "IsActive", "Name", "SortOrder", "Status", "UpdatedAt", "UpdatedBy" },
                values: new object[,]
                {
                    { 1, "EG", new DateTime(2024, 1, 1, 10, 0, 0, 0, DateTimeKind.Unspecified), null, true, "Mısır", 1, 1, null, null },
                    { 2, "GA", new DateTime(2024, 1, 1, 10, 0, 0, 0, DateTimeKind.Unspecified), null, true, "Gabon", 2, 1, null, null },
                    { 3, "GH", new DateTime(2024, 1, 1, 10, 0, 0, 0, DateTimeKind.Unspecified), null, true, "Gana", 3, 1, null, null },
                    { 4, "ET", new DateTime(2024, 1, 1, 10, 0, 0, 0, DateTimeKind.Unspecified), null, true, "Etiyopya", 4, 1, null, null },
                    { 5, "KE", new DateTime(2024, 1, 1, 10, 0, 0, 0, DateTimeKind.Unspecified), null, true, "Kenya", 5, 1, null, null },
                    { 6, "TZ", new DateTime(2024, 1, 1, 10, 0, 0, 0, DateTimeKind.Unspecified), null, true, "Tanzanya", 6, 1, null, null },
                    { 7, "ZA", new DateTime(2024, 1, 1, 10, 0, 0, 0, DateTimeKind.Unspecified), null, true, "Güney Afrika", 7, 1, null, null },
                    { 8, "NG", new DateTime(2024, 1, 1, 10, 0, 0, 0, DateTimeKind.Unspecified), null, true, "Nijerya", 8, 1, null, null },
                    { 9, "SN", new DateTime(2024, 1, 1, 10, 0, 0, 0, DateTimeKind.Unspecified), null, true, "Senegal", 9, 1, null, null },
                    { 10, "MA", new DateTime(2024, 1, 1, 10, 0, 0, 0, DateTimeKind.Unspecified), null, true, "Fas", 10, 1, null, null },
                    { 11, "TN", new DateTime(2024, 1, 1, 10, 0, 0, 0, DateTimeKind.Unspecified), null, true, "Tunus", 11, 1, null, null },
                    { 12, "DZ", new DateTime(2024, 1, 1, 10, 0, 0, 0, DateTimeKind.Unspecified), null, true, "Cezayir", 12, 1, null, null },
                    { 13, "UG", new DateTime(2024, 1, 1, 10, 0, 0, 0, DateTimeKind.Unspecified), null, true, "Uganda", 13, 1, null, null },
                    { 14, "RW", new DateTime(2024, 1, 1, 10, 0, 0, 0, DateTimeKind.Unspecified), null, true, "Ruanda", 14, 1, null, null },
                    { 15, "CM", new DateTime(2024, 1, 1, 10, 0, 0, 0, DateTimeKind.Unspecified), null, true, "Kamerun", 15, 1, null, null },
                    { 16, "DE", new DateTime(2024, 1, 1, 10, 0, 0, 0, DateTimeKind.Unspecified), null, true, "Almanya", 16, 1, null, null },
                    { 17, "FR", new DateTime(2024, 1, 1, 10, 0, 0, 0, DateTimeKind.Unspecified), null, true, "Fransa", 17, 1, null, null },
                    { 18, "GB", new DateTime(2024, 1, 1, 10, 0, 0, 0, DateTimeKind.Unspecified), null, true, "İngiltere", 18, 1, null, null },
                    { 19, "IT", new DateTime(2024, 1, 1, 10, 0, 0, 0, DateTimeKind.Unspecified), null, true, "İtalya", 19, 1, null, null },
                    { 20, "ES", new DateTime(2024, 1, 1, 10, 0, 0, 0, DateTimeKind.Unspecified), null, true, "İspanya", 20, 1, null, null },
                    { 21, "NL", new DateTime(2024, 1, 1, 10, 0, 0, 0, DateTimeKind.Unspecified), null, true, "Hollanda", 21, 1, null, null },
                    { 22, "BE", new DateTime(2024, 1, 1, 10, 0, 0, 0, DateTimeKind.Unspecified), null, true, "Belçika", 22, 1, null, null },
                    { 23, "PL", new DateTime(2024, 1, 1, 10, 0, 0, 0, DateTimeKind.Unspecified), null, true, "Polonya", 23, 1, null, null },
                    { 24, "RO", new DateTime(2024, 1, 1, 10, 0, 0, 0, DateTimeKind.Unspecified), null, true, "Romanya", 24, 1, null, null },
                    { 25, "GR", new DateTime(2024, 1, 1, 10, 0, 0, 0, DateTimeKind.Unspecified), null, true, "Yunanistan", 25, 1, null, null },
                    { 26, "PT", new DateTime(2024, 1, 1, 10, 0, 0, 0, DateTimeKind.Unspecified), null, true, "Portekiz", 26, 1, null, null },
                    { 27, "AT", new DateTime(2024, 1, 1, 10, 0, 0, 0, DateTimeKind.Unspecified), null, true, "Avusturya", 27, 1, null, null },
                    { 28, "CH", new DateTime(2024, 1, 1, 10, 0, 0, 0, DateTimeKind.Unspecified), null, true, "İsviçre", 28, 1, null, null },
                    { 29, "SE", new DateTime(2024, 1, 1, 10, 0, 0, 0, DateTimeKind.Unspecified), null, true, "İsveç", 29, 1, null, null },
                    { 30, "NO", new DateTime(2024, 1, 1, 10, 0, 0, 0, DateTimeKind.Unspecified), null, true, "Norveç", 30, 1, null, null },
                    { 31, "DK", new DateTime(2024, 1, 1, 10, 0, 0, 0, DateTimeKind.Unspecified), null, true, "Danimarka", 31, 1, null, null },
                    { 32, "FI", new DateTime(2024, 1, 1, 10, 0, 0, 0, DateTimeKind.Unspecified), null, true, "Finlandiya", 32, 1, null, null },
                    { 33, "CZ", new DateTime(2024, 1, 1, 10, 0, 0, 0, DateTimeKind.Unspecified), null, true, "Çek Cumhuriyeti", 33, 1, null, null },
                    { 34, "HU", new DateTime(2024, 1, 1, 10, 0, 0, 0, DateTimeKind.Unspecified), null, true, "Macaristan", 34, 1, null, null },
                    { 35, "BG", new DateTime(2024, 1, 1, 10, 0, 0, 0, DateTimeKind.Unspecified), null, true, "Bulgaristan", 35, 1, null, null },
                    { 36, "HR", new DateTime(2024, 1, 1, 10, 0, 0, 0, DateTimeKind.Unspecified), null, true, "Hırvatistan", 36, 1, null, null },
                    { 37, "SK", new DateTime(2024, 1, 1, 10, 0, 0, 0, DateTimeKind.Unspecified), null, true, "Slovakya", 37, 1, null, null },
                    { 38, "SI", new DateTime(2024, 1, 1, 10, 0, 0, 0, DateTimeKind.Unspecified), null, true, "Slovenya", 38, 1, null, null },
                    { 39, "LT", new DateTime(2024, 1, 1, 10, 0, 0, 0, DateTimeKind.Unspecified), null, true, "Litvanya", 39, 1, null, null },
                    { 40, "LV", new DateTime(2024, 1, 1, 10, 0, 0, 0, DateTimeKind.Unspecified), null, true, "Letonya", 40, 1, null, null },
                    { 41, "EE", new DateTime(2024, 1, 1, 10, 0, 0, 0, DateTimeKind.Unspecified), null, true, "Estonya", 41, 1, null, null },
                    { 42, "US", new DateTime(2024, 1, 1, 10, 0, 0, 0, DateTimeKind.Unspecified), null, true, "Amerika Birleşik Devletleri", 42, 1, null, null },
                    { 43, "CA", new DateTime(2024, 1, 1, 10, 0, 0, 0, DateTimeKind.Unspecified), null, true, "Kanada", 43, 1, null, null },
                    { 44, "MX", new DateTime(2024, 1, 1, 10, 0, 0, 0, DateTimeKind.Unspecified), null, true, "Meksika", 44, 1, null, null },
                    { 45, "BR", new DateTime(2024, 1, 1, 10, 0, 0, 0, DateTimeKind.Unspecified), null, true, "Brezilya", 45, 1, null, null },
                    { 46, "AR", new DateTime(2024, 1, 1, 10, 0, 0, 0, DateTimeKind.Unspecified), null, true, "Arjantin", 46, 1, null, null },
                    { 47, "CL", new DateTime(2024, 1, 1, 10, 0, 0, 0, DateTimeKind.Unspecified), null, true, "Şili", 47, 1, null, null },
                    { 48, "CO", new DateTime(2024, 1, 1, 10, 0, 0, 0, DateTimeKind.Unspecified), null, true, "Kolombiya", 48, 1, null, null },
                    { 49, "PE", new DateTime(2024, 1, 1, 10, 0, 0, 0, DateTimeKind.Unspecified), null, true, "Peru", 49, 1, null, null },
                    { 50, "VE", new DateTime(2024, 1, 1, 10, 0, 0, 0, DateTimeKind.Unspecified), null, true, "Venezuela", 50, 1, null, null },
                    { 51, "EC", new DateTime(2024, 1, 1, 10, 0, 0, 0, DateTimeKind.Unspecified), null, true, "Ekvador", 51, 1, null, null },
                    { 52, "UY", new DateTime(2024, 1, 1, 10, 0, 0, 0, DateTimeKind.Unspecified), null, true, "Uruguay", 52, 1, null, null },
                    { 53, "PY", new DateTime(2024, 1, 1, 10, 0, 0, 0, DateTimeKind.Unspecified), null, true, "Paraguay", 53, 1, null, null },
                    { 54, "BO", new DateTime(2024, 1, 1, 10, 0, 0, 0, DateTimeKind.Unspecified), null, true, "Bolivya", 54, 1, null, null },
                    { 55, "CN", new DateTime(2024, 1, 1, 10, 0, 0, 0, DateTimeKind.Unspecified), null, true, "Çin", 55, 1, null, null },
                    { 56, "JP", new DateTime(2024, 1, 1, 10, 0, 0, 0, DateTimeKind.Unspecified), null, true, "Japonya", 56, 1, null, null },
                    { 57, "KR", new DateTime(2024, 1, 1, 10, 0, 0, 0, DateTimeKind.Unspecified), null, true, "Güney Kore", 57, 1, null, null },
                    { 58, "IN", new DateTime(2024, 1, 1, 10, 0, 0, 0, DateTimeKind.Unspecified), null, true, "Hindistan", 58, 1, null, null },
                    { 59, "PK", new DateTime(2024, 1, 1, 10, 0, 0, 0, DateTimeKind.Unspecified), null, true, "Pakistan", 59, 1, null, null },
                    { 60, "BD", new DateTime(2024, 1, 1, 10, 0, 0, 0, DateTimeKind.Unspecified), null, true, "Bangladeş", 60, 1, null, null },
                    { 61, "ID", new DateTime(2024, 1, 1, 10, 0, 0, 0, DateTimeKind.Unspecified), null, true, "Endonezya", 61, 1, null, null },
                    { 62, "PH", new DateTime(2024, 1, 1, 10, 0, 0, 0, DateTimeKind.Unspecified), null, true, "Filipinler", 62, 1, null, null },
                    { 63, "VN", new DateTime(2024, 1, 1, 10, 0, 0, 0, DateTimeKind.Unspecified), null, true, "Vietnam", 63, 1, null, null },
                    { 64, "TH", new DateTime(2024, 1, 1, 10, 0, 0, 0, DateTimeKind.Unspecified), null, true, "Tayland", 64, 1, null, null },
                    { 65, "MY", new DateTime(2024, 1, 1, 10, 0, 0, 0, DateTimeKind.Unspecified), null, true, "Malezya", 65, 1, null, null },
                    { 66, "SG", new DateTime(2024, 1, 1, 10, 0, 0, 0, DateTimeKind.Unspecified), null, true, "Singapur", 66, 1, null, null },
                    { 67, "MM", new DateTime(2024, 1, 1, 10, 0, 0, 0, DateTimeKind.Unspecified), null, true, "Myanmar", 67, 1, null, null },
                    { 68, "KH", new DateTime(2024, 1, 1, 10, 0, 0, 0, DateTimeKind.Unspecified), null, true, "Kamboçya", 68, 1, null, null },
                    { 69, "LA", new DateTime(2024, 1, 1, 10, 0, 0, 0, DateTimeKind.Unspecified), null, true, "Laos", 69, 1, null, null },
                    { 70, "LK", new DateTime(2024, 1, 1, 10, 0, 0, 0, DateTimeKind.Unspecified), null, true, "Sri Lanka", 70, 1, null, null },
                    { 71, "NP", new DateTime(2024, 1, 1, 10, 0, 0, 0, DateTimeKind.Unspecified), null, true, "Nepal", 71, 1, null, null },
                    { 72, "AU", new DateTime(2024, 1, 1, 10, 0, 0, 0, DateTimeKind.Unspecified), null, true, "Avustralya", 72, 1, null, null },
                    { 73, "NZ", new DateTime(2024, 1, 1, 10, 0, 0, 0, DateTimeKind.Unspecified), null, true, "Yeni Zelanda", 73, 1, null, null },
                    { 74, "RU", new DateTime(2024, 1, 1, 10, 0, 0, 0, DateTimeKind.Unspecified), null, true, "Rusya", 74, 1, null, null },
                    { 75, "UA", new DateTime(2024, 1, 1, 10, 0, 0, 0, DateTimeKind.Unspecified), null, true, "Ukrayna", 75, 1, null, null },
                    { 76, "KZ", new DateTime(2024, 1, 1, 10, 0, 0, 0, DateTimeKind.Unspecified), null, true, "Kazakistan", 76, 1, null, null },
                    { 77, "UZ", new DateTime(2024, 1, 1, 10, 0, 0, 0, DateTimeKind.Unspecified), null, true, "Özbekistan", 77, 1, null, null },
                    { 78, "TM", new DateTime(2024, 1, 1, 10, 0, 0, 0, DateTimeKind.Unspecified), null, true, "Türkmenistan", 78, 1, null, null },
                    { 79, "KG", new DateTime(2024, 1, 1, 10, 0, 0, 0, DateTimeKind.Unspecified), null, true, "Kırgızistan", 79, 1, null, null },
                    { 80, "TJ", new DateTime(2024, 1, 1, 10, 0, 0, 0, DateTimeKind.Unspecified), null, true, "Tacikistan", 80, 1, null, null },
                    { 81, "AZ", new DateTime(2024, 1, 1, 10, 0, 0, 0, DateTimeKind.Unspecified), null, true, "Azerbaycan", 81, 1, null, null },
                    { 82, "GE", new DateTime(2024, 1, 1, 10, 0, 0, 0, DateTimeKind.Unspecified), null, true, "Gürcistan", 82, 1, null, null },
                    { 83, "AM", new DateTime(2024, 1, 1, 10, 0, 0, 0, DateTimeKind.Unspecified), null, true, "Ermenistan", 83, 1, null, null },
                    { 84, "IR", new DateTime(2024, 1, 1, 10, 0, 0, 0, DateTimeKind.Unspecified), null, true, "İran", 84, 1, null, null },
                    { 85, "IQ", new DateTime(2024, 1, 1, 10, 0, 0, 0, DateTimeKind.Unspecified), null, true, "Irak", 85, 1, null, null },
                    { 86, "SY", new DateTime(2024, 1, 1, 10, 0, 0, 0, DateTimeKind.Unspecified), null, true, "Suriye", 86, 1, null, null },
                    { 87, "JO", new DateTime(2024, 1, 1, 10, 0, 0, 0, DateTimeKind.Unspecified), null, true, "Ürdün", 87, 1, null, null },
                    { 88, "LB", new DateTime(2024, 1, 1, 10, 0, 0, 0, DateTimeKind.Unspecified), null, true, "Lübnan", 88, 1, null, null },
                    { 89, "IL", new DateTime(2024, 1, 1, 10, 0, 0, 0, DateTimeKind.Unspecified), null, true, "İsrail", 89, 1, null, null },
                    { 90, "SA", new DateTime(2024, 1, 1, 10, 0, 0, 0, DateTimeKind.Unspecified), null, true, "Suudi Arabistan", 90, 1, null, null },
                    { 91, "AE", new DateTime(2024, 1, 1, 10, 0, 0, 0, DateTimeKind.Unspecified), null, true, "Birleşik Arap Emirlikleri", 91, 1, null, null },
                    { 92, "KW", new DateTime(2024, 1, 1, 10, 0, 0, 0, DateTimeKind.Unspecified), null, true, "Kuveyt", 92, 1, null, null },
                    { 93, "QA", new DateTime(2024, 1, 1, 10, 0, 0, 0, DateTimeKind.Unspecified), null, true, "Katar", 93, 1, null, null },
                    { 94, "BH", new DateTime(2024, 1, 1, 10, 0, 0, 0, DateTimeKind.Unspecified), null, true, "Bahreyn", 94, 1, null, null },
                    { 95, "OM", new DateTime(2024, 1, 1, 10, 0, 0, 0, DateTimeKind.Unspecified), null, true, "Umman", 95, 1, null, null },
                    { 96, "YE", new DateTime(2024, 1, 1, 10, 0, 0, 0, DateTimeKind.Unspecified), null, true, "Yemen", 96, 1, null, null },
                    { 97, "AF", new DateTime(2024, 1, 1, 10, 0, 0, 0, DateTimeKind.Unspecified), null, true, "Afganistan", 97, 1, null, null },
                    { 98, "LY", new DateTime(2024, 1, 1, 10, 0, 0, 0, DateTimeKind.Unspecified), null, true, "Libya", 98, 1, null, null },
                    { 99, "SD", new DateTime(2024, 1, 1, 10, 0, 0, 0, DateTimeKind.Unspecified), null, true, "Sudan", 99, 1, null, null },
                    { 100, "SO", new DateTime(2024, 1, 1, 10, 0, 0, 0, DateTimeKind.Unspecified), null, true, "Somali", 100, 1, null, null }
                });

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: 1,
                column: "Code",
                value: "tr-TR");

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: 2,
                column: "Code",
                value: "en-US");

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: 3,
                column: "Code",
                value: "de-DE");

            migrationBuilder.CreateIndex(
                name: "IX_Countries_Code",
                table: "Countries",
                column: "Code");

            migrationBuilder.CreateIndex(
                name: "IX_Countries_IsActive",
                table: "Countries",
                column: "IsActive");

            migrationBuilder.CreateIndex(
                name: "IX_Countries_SortOrder",
                table: "Countries",
                column: "SortOrder");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Countries");

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: 1,
                column: "Code",
                value: "TR");

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: 2,
                column: "Code",
                value: "US");

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: 3,
                column: "Code",
                value: "DE");
        }
    }
}
