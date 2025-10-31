using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace PazarAtlasi.CMS.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AddLocalizationEntities : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Languages_Code",
                table: "Languages");

            migrationBuilder.AlterColumn<int>(
                name: "Status",
                table: "Languages",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldDefaultValue: 0);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Languages",
                type: "datetime2",
                nullable: false,
                defaultValueSql: "GETUTCDATE()",
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<string>(
                name: "Code",
                table: "Languages",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(10)",
                oldMaxLength: 10,
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Flag",
                table: "Languages",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "Languages",
                type: "bit",
                nullable: false,
                defaultValue: true);

            migrationBuilder.AddColumn<string>(
                name: "NativeName",
                table: "Languages",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SortOrder",
                table: "Languages",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "LocalizationValues",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LanguageId = table.Column<int>(type: "int", nullable: false),
                    Key = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    Value = table.Column<string>(type: "nvarchar(4000)", maxLength: 4000, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    Category = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETUTCDATE()"),
                    CreatedBy = table.Column<int>(type: "int", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<int>(type: "int", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LocalizationValues", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LocalizationValues_Languages_LanguageId",
                        column: x => x.LanguageId,
                        principalTable: "Languages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "Flag", "IsActive", "NativeName", "SortOrder", "Status" },
                values: new object[] { new DateTime(2025, 10, 31, 12, 14, 0, 601, DateTimeKind.Utc).AddTicks(1023), "🇹🇷", true, "Türkçe", 1, 0 });

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "Flag", "IsActive", "NativeName", "SortOrder", "Status" },
                values: new object[] { new DateTime(2025, 10, 31, 12, 14, 0, 601, DateTimeKind.Utc).AddTicks(1028), "🇺🇸", true, "English", 2, 0 });

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "Flag", "IsActive", "NativeName", "SortOrder", "Status" },
                values: new object[] { new DateTime(2025, 10, 31, 12, 14, 0, 601, DateTimeKind.Utc).AddTicks(1030), "🇩🇪", true, "Deutsch", 3, 0 });

            migrationBuilder.InsertData(
                table: "Languages",
                columns: new[] { "Id", "Code", "CreatedAt", "CreatedBy", "Flag", "IsActive", "Name", "NativeName", "SortOrder", "Status", "UpdatedAt", "UpdatedBy" },
                values: new object[,]
                {
                    { 4, "fr-FR", new DateTime(2025, 10, 31, 12, 14, 0, 601, DateTimeKind.Utc).AddTicks(1032), null, "🇫🇷", true, "Français", "Français", 4, 0, null, null },
                    { 5, "es-ES", new DateTime(2025, 10, 31, 12, 14, 0, 601, DateTimeKind.Utc).AddTicks(1034), null, "🇪🇸", true, "Español", "Español", 5, 0, null, null }
                });

            migrationBuilder.InsertData(
                table: "LocalizationValues",
                columns: new[] { "Id", "Category", "CreatedAt", "CreatedBy", "Description", "IsActive", "Key", "LanguageId", "Status", "UpdatedAt", "UpdatedBy", "Value" },
                values: new object[,]
                {
                    { 1, "Common", new DateTime(2025, 10, 31, 12, 14, 0, 601, DateTimeKind.Utc).AddTicks(8956), null, "Save button text", true, "Common.Save", 1, 0, null, null, "Kaydet" },
                    { 2, "Common", new DateTime(2025, 10, 31, 12, 14, 0, 601, DateTimeKind.Utc).AddTicks(8960), null, "Save button text", true, "Common.Save", 2, 0, null, null, "Save" },
                    { 3, "Common", new DateTime(2025, 10, 31, 12, 14, 0, 601, DateTimeKind.Utc).AddTicks(8962), null, "Cancel button text", true, "Common.Cancel", 1, 0, null, null, "İptal" },
                    { 4, "Common", new DateTime(2025, 10, 31, 12, 14, 0, 601, DateTimeKind.Utc).AddTicks(8964), null, "Cancel button text", true, "Common.Cancel", 2, 0, null, null, "Cancel" },
                    { 5, "Common", new DateTime(2025, 10, 31, 12, 14, 0, 601, DateTimeKind.Utc).AddTicks(8965), null, "Delete button text", true, "Common.Delete", 1, 0, null, null, "Sil" },
                    { 6, "Common", new DateTime(2025, 10, 31, 12, 14, 0, 601, DateTimeKind.Utc).AddTicks(8967), null, "Delete button text", true, "Common.Delete", 2, 0, null, null, "Delete" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Languages_Code",
                table: "Languages",
                column: "Code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Languages_IsActive",
                table: "Languages",
                column: "IsActive");

            migrationBuilder.CreateIndex(
                name: "IX_Languages_IsDeleted",
                table: "Languages",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_Languages_SortOrder",
                table: "Languages",
                column: "SortOrder");

            migrationBuilder.CreateIndex(
                name: "IX_LocalizationValues_Category",
                table: "LocalizationValues",
                column: "Category");

            migrationBuilder.CreateIndex(
                name: "IX_LocalizationValues_IsActive",
                table: "LocalizationValues",
                column: "IsActive");

            migrationBuilder.CreateIndex(
                name: "IX_LocalizationValues_IsDeleted",
                table: "LocalizationValues",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_LocalizationValues_Key",
                table: "LocalizationValues",
                column: "Key");

            migrationBuilder.CreateIndex(
                name: "IX_LocalizationValues_Key_LanguageId",
                table: "LocalizationValues",
                columns: new[] { "Key", "LanguageId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_LocalizationValues_LanguageId",
                table: "LocalizationValues",
                column: "LanguageId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LocalizationValues");

            migrationBuilder.DropIndex(
                name: "IX_Languages_Code",
                table: "Languages");

            migrationBuilder.DropIndex(
                name: "IX_Languages_IsActive",
                table: "Languages");

            migrationBuilder.DropIndex(
                name: "IX_Languages_IsDeleted",
                table: "Languages");

            migrationBuilder.DropIndex(
                name: "IX_Languages_SortOrder",
                table: "Languages");

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DropColumn(
                name: "Flag",
                table: "Languages");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Languages");

            migrationBuilder.DropColumn(
                name: "NativeName",
                table: "Languages");

            migrationBuilder.DropColumn(
                name: "SortOrder",
                table: "Languages");

            migrationBuilder.AlterColumn<int>(
                name: "Status",
                table: "Languages",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Languages",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValueSql: "GETUTCDATE()");

            migrationBuilder.AlterColumn<string>(
                name: "Code",
                table: "Languages",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(10)",
                oldMaxLength: 10);

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "Status" },
                values: new object[] { new DateTime(2024, 1, 1, 10, 0, 0, 0, DateTimeKind.Unspecified), 1 });

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "Status" },
                values: new object[] { new DateTime(2024, 1, 1, 10, 0, 0, 0, DateTimeKind.Unspecified), 1 });

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "Status" },
                values: new object[] { new DateTime(2024, 1, 1, 10, 0, 0, 0, DateTimeKind.Unspecified), 1 });

            migrationBuilder.CreateIndex(
                name: "IX_Languages_Code",
                table: "Languages",
                column: "Code",
                unique: true,
                filter: "[Code] IS NOT NULL");
        }
    }
}
