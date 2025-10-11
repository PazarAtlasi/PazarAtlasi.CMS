using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PazarAtlasi.CMS.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AddVideoAndMediaTypeToSectionItem : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "MediaAttributes",
                table: "SectionItems",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MediaType",
                table: "SectionItems",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "VideoUrl",
                table: "SectionItems",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: true);

            migrationBuilder.UpdateData(
                table: "SectionItems",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "MediaAttributes", "VideoUrl" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "SectionItems",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "MediaAttributes", "VideoUrl" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "SectionItems",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "MediaAttributes", "VideoUrl" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "SectionItems",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "MediaAttributes", "VideoUrl" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "SectionItems",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "MediaAttributes", "VideoUrl" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "SectionItems",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "MediaAttributes", "VideoUrl" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "SectionItems",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "MediaAttributes", "VideoUrl" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "SectionItems",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "MediaAttributes", "VideoUrl" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "SectionItems",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "MediaAttributes", "VideoUrl" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "SectionItems",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "MediaAttributes", "VideoUrl" },
                values: new object[] { null, null });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MediaAttributes",
                table: "SectionItems");

            migrationBuilder.DropColumn(
                name: "MediaType",
                table: "SectionItems");

            migrationBuilder.DropColumn(
                name: "VideoUrl",
                table: "SectionItems");
        }
    }
}
