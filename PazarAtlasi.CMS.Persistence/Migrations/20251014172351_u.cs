using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PazarAtlasi.CMS.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class u : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "LinkedPageId",
                table: "SectionItems",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Slug",
                table: "Pages",
                type: "nvarchar(max)",
                nullable: true);

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
                table: "SectionItems",
                keyColumn: "Id",
                keyValue: 1,
                column: "LinkedPageId",
                value: null);

            migrationBuilder.UpdateData(
                table: "SectionItems",
                keyColumn: "Id",
                keyValue: 2,
                column: "LinkedPageId",
                value: null);

            migrationBuilder.UpdateData(
                table: "SectionItems",
                keyColumn: "Id",
                keyValue: 3,
                column: "LinkedPageId",
                value: null);

            migrationBuilder.UpdateData(
                table: "SectionItems",
                keyColumn: "Id",
                keyValue: 4,
                column: "LinkedPageId",
                value: null);

            migrationBuilder.UpdateData(
                table: "SectionItems",
                keyColumn: "Id",
                keyValue: 5,
                column: "LinkedPageId",
                value: null);

            migrationBuilder.UpdateData(
                table: "SectionItems",
                keyColumn: "Id",
                keyValue: 6,
                column: "LinkedPageId",
                value: null);

            migrationBuilder.UpdateData(
                table: "SectionItems",
                keyColumn: "Id",
                keyValue: 7,
                column: "LinkedPageId",
                value: null);

            migrationBuilder.UpdateData(
                table: "SectionItems",
                keyColumn: "Id",
                keyValue: 8,
                column: "LinkedPageId",
                value: null);

            migrationBuilder.UpdateData(
                table: "SectionItems",
                keyColumn: "Id",
                keyValue: 9,
                column: "LinkedPageId",
                value: null);

            migrationBuilder.UpdateData(
                table: "SectionItems",
                keyColumn: "Id",
                keyValue: 10,
                column: "LinkedPageId",
                value: null);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LinkedPageId",
                table: "SectionItems");

            migrationBuilder.DropColumn(
                name: "Slug",
                table: "Pages");
        }
    }
}
