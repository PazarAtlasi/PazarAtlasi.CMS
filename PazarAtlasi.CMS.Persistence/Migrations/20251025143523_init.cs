using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PazarAtlasi.CMS.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SectionId",
                table: "SectionItemFieldValues",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "SectionItemId",
                table: "SectionItemFieldValues",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "SectionItemFieldValues",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "SectionId", "SectionItemId" },
                values: new object[] { 0, 0 });

            migrationBuilder.UpdateData(
                table: "SectionItemFieldValues",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "SectionId", "SectionItemId" },
                values: new object[] { 0, 0 });

            migrationBuilder.UpdateData(
                table: "SectionItemFieldValues",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "SectionId", "SectionItemId" },
                values: new object[] { 0, 0 });

            migrationBuilder.UpdateData(
                table: "SectionItemFieldValues",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "SectionId", "SectionItemId" },
                values: new object[] { 0, 0 });

            migrationBuilder.UpdateData(
                table: "SectionItemFieldValues",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "SectionId", "SectionItemId" },
                values: new object[] { 0, 0 });

            migrationBuilder.UpdateData(
                table: "SectionItemFieldValues",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "SectionId", "SectionItemId" },
                values: new object[] { 0, 0 });

            migrationBuilder.UpdateData(
                table: "SectionItemFieldValues",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "SectionId", "SectionItemId" },
                values: new object[] { 0, 0 });

            migrationBuilder.UpdateData(
                table: "SectionItemFieldValues",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "SectionId", "SectionItemId" },
                values: new object[] { 0, 0 });

            migrationBuilder.UpdateData(
                table: "SectionItemFieldValues",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "SectionId", "SectionItemId" },
                values: new object[] { 0, 0 });

            migrationBuilder.UpdateData(
                table: "SectionItemFieldValues",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "SectionId", "SectionItemId" },
                values: new object[] { 0, 0 });

            migrationBuilder.UpdateData(
                table: "SectionItemFieldValues",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "SectionId", "SectionItemId" },
                values: new object[] { 0, 0 });

            migrationBuilder.UpdateData(
                table: "SectionItemFieldValues",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "SectionId", "SectionItemId" },
                values: new object[] { 0, 0 });

            migrationBuilder.UpdateData(
                table: "SectionItemFieldValues",
                keyColumn: "Id",
                keyValue: 13,
                columns: new[] { "SectionId", "SectionItemId" },
                values: new object[] { 0, 0 });

            migrationBuilder.UpdateData(
                table: "SectionItemFieldValues",
                keyColumn: "Id",
                keyValue: 14,
                columns: new[] { "SectionId", "SectionItemId" },
                values: new object[] { 0, 0 });

            migrationBuilder.UpdateData(
                table: "SectionItemFieldValues",
                keyColumn: "Id",
                keyValue: 15,
                columns: new[] { "SectionId", "SectionItemId" },
                values: new object[] { 0, 0 });

            migrationBuilder.UpdateData(
                table: "SectionItemFieldValues",
                keyColumn: "Id",
                keyValue: 16,
                columns: new[] { "SectionId", "SectionItemId" },
                values: new object[] { 0, 0 });

            migrationBuilder.UpdateData(
                table: "SectionItemFieldValues",
                keyColumn: "Id",
                keyValue: 17,
                columns: new[] { "SectionId", "SectionItemId" },
                values: new object[] { 0, 0 });

            migrationBuilder.UpdateData(
                table: "SectionItemFieldValues",
                keyColumn: "Id",
                keyValue: 18,
                columns: new[] { "SectionId", "SectionItemId" },
                values: new object[] { 0, 0 });

            migrationBuilder.UpdateData(
                table: "SectionItemFieldValues",
                keyColumn: "Id",
                keyValue: 19,
                columns: new[] { "SectionId", "SectionItemId" },
                values: new object[] { 0, 0 });

            migrationBuilder.UpdateData(
                table: "SectionItemFieldValues",
                keyColumn: "Id",
                keyValue: 20,
                columns: new[] { "SectionId", "SectionItemId" },
                values: new object[] { 0, 0 });

            migrationBuilder.UpdateData(
                table: "SectionItemFieldValues",
                keyColumn: "Id",
                keyValue: 21,
                columns: new[] { "SectionId", "SectionItemId" },
                values: new object[] { 0, 0 });

            migrationBuilder.UpdateData(
                table: "SectionItemFieldValues",
                keyColumn: "Id",
                keyValue: 22,
                columns: new[] { "SectionId", "SectionItemId" },
                values: new object[] { 0, 0 });

            migrationBuilder.UpdateData(
                table: "SectionItemFieldValues",
                keyColumn: "Id",
                keyValue: 23,
                columns: new[] { "SectionId", "SectionItemId" },
                values: new object[] { 0, 0 });

            migrationBuilder.UpdateData(
                table: "SectionItemFieldValues",
                keyColumn: "Id",
                keyValue: 24,
                columns: new[] { "SectionId", "SectionItemId" },
                values: new object[] { 0, 0 });

            migrationBuilder.UpdateData(
                table: "SectionItemFieldValues",
                keyColumn: "Id",
                keyValue: 25,
                columns: new[] { "SectionId", "SectionItemId" },
                values: new object[] { 0, 0 });

            migrationBuilder.UpdateData(
                table: "SectionItemFieldValues",
                keyColumn: "Id",
                keyValue: 26,
                columns: new[] { "SectionId", "SectionItemId" },
                values: new object[] { 0, 0 });

            migrationBuilder.UpdateData(
                table: "SectionItemFieldValues",
                keyColumn: "Id",
                keyValue: 27,
                columns: new[] { "SectionId", "SectionItemId" },
                values: new object[] { 0, 0 });

            migrationBuilder.UpdateData(
                table: "SectionItemFieldValues",
                keyColumn: "Id",
                keyValue: 28,
                columns: new[] { "SectionId", "SectionItemId" },
                values: new object[] { 0, 0 });

            migrationBuilder.UpdateData(
                table: "SectionItemFieldValues",
                keyColumn: "Id",
                keyValue: 29,
                columns: new[] { "SectionId", "SectionItemId" },
                values: new object[] { 0, 0 });

            migrationBuilder.UpdateData(
                table: "SectionItemFieldValues",
                keyColumn: "Id",
                keyValue: 30,
                columns: new[] { "SectionId", "SectionItemId" },
                values: new object[] { 0, 0 });

            migrationBuilder.UpdateData(
                table: "SectionItemFieldValues",
                keyColumn: "Id",
                keyValue: 31,
                columns: new[] { "SectionId", "SectionItemId" },
                values: new object[] { 0, 0 });

            migrationBuilder.UpdateData(
                table: "SectionItemFieldValues",
                keyColumn: "Id",
                keyValue: 32,
                columns: new[] { "SectionId", "SectionItemId" },
                values: new object[] { 0, 0 });

            migrationBuilder.UpdateData(
                table: "SectionItemFieldValues",
                keyColumn: "Id",
                keyValue: 33,
                columns: new[] { "SectionId", "SectionItemId" },
                values: new object[] { 0, 0 });

            migrationBuilder.UpdateData(
                table: "SectionItemFieldValues",
                keyColumn: "Id",
                keyValue: 34,
                columns: new[] { "SectionId", "SectionItemId" },
                values: new object[] { 0, 0 });

            migrationBuilder.UpdateData(
                table: "SectionItemFieldValues",
                keyColumn: "Id",
                keyValue: 35,
                columns: new[] { "SectionId", "SectionItemId" },
                values: new object[] { 0, 0 });

            migrationBuilder.UpdateData(
                table: "SectionItemFieldValues",
                keyColumn: "Id",
                keyValue: 36,
                columns: new[] { "SectionId", "SectionItemId" },
                values: new object[] { 0, 0 });

            migrationBuilder.UpdateData(
                table: "SectionItemFieldValues",
                keyColumn: "Id",
                keyValue: 37,
                columns: new[] { "SectionId", "SectionItemId" },
                values: new object[] { 0, 0 });

            migrationBuilder.UpdateData(
                table: "SectionItemFieldValues",
                keyColumn: "Id",
                keyValue: 38,
                columns: new[] { "SectionId", "SectionItemId" },
                values: new object[] { 0, 0 });

            migrationBuilder.UpdateData(
                table: "SectionItemFieldValues",
                keyColumn: "Id",
                keyValue: 39,
                columns: new[] { "SectionId", "SectionItemId" },
                values: new object[] { 0, 0 });

            migrationBuilder.UpdateData(
                table: "SectionItemFieldValues",
                keyColumn: "Id",
                keyValue: 40,
                columns: new[] { "SectionId", "SectionItemId" },
                values: new object[] { 0, 0 });

            migrationBuilder.UpdateData(
                table: "SectionItemFieldValues",
                keyColumn: "Id",
                keyValue: 41,
                columns: new[] { "SectionId", "SectionItemId" },
                values: new object[] { 0, 0 });

            migrationBuilder.UpdateData(
                table: "SectionItemFieldValues",
                keyColumn: "Id",
                keyValue: 42,
                columns: new[] { "SectionId", "SectionItemId" },
                values: new object[] { 0, 0 });

            migrationBuilder.UpdateData(
                table: "SectionItemFieldValues",
                keyColumn: "Id",
                keyValue: 43,
                columns: new[] { "SectionId", "SectionItemId" },
                values: new object[] { 0, 0 });

            migrationBuilder.UpdateData(
                table: "SectionItemFieldValues",
                keyColumn: "Id",
                keyValue: 44,
                columns: new[] { "SectionId", "SectionItemId" },
                values: new object[] { 0, 0 });

            migrationBuilder.UpdateData(
                table: "SectionItemFieldValues",
                keyColumn: "Id",
                keyValue: 45,
                columns: new[] { "SectionId", "SectionItemId" },
                values: new object[] { 0, 0 });

            migrationBuilder.UpdateData(
                table: "SectionItemFieldValues",
                keyColumn: "Id",
                keyValue: 46,
                columns: new[] { "SectionId", "SectionItemId" },
                values: new object[] { 0, 0 });

            migrationBuilder.UpdateData(
                table: "SectionItemFieldValues",
                keyColumn: "Id",
                keyValue: 47,
                columns: new[] { "SectionId", "SectionItemId" },
                values: new object[] { 0, 0 });

            migrationBuilder.UpdateData(
                table: "SectionItemFieldValues",
                keyColumn: "Id",
                keyValue: 48,
                columns: new[] { "SectionId", "SectionItemId" },
                values: new object[] { 0, 0 });

            migrationBuilder.UpdateData(
                table: "SectionItemFieldValues",
                keyColumn: "Id",
                keyValue: 49,
                columns: new[] { "SectionId", "SectionItemId" },
                values: new object[] { 0, 0 });

            migrationBuilder.UpdateData(
                table: "SectionItemFieldValues",
                keyColumn: "Id",
                keyValue: 50,
                columns: new[] { "SectionId", "SectionItemId" },
                values: new object[] { 0, 0 });

            migrationBuilder.UpdateData(
                table: "SectionItemFieldValues",
                keyColumn: "Id",
                keyValue: 51,
                columns: new[] { "SectionId", "SectionItemId" },
                values: new object[] { 0, 0 });

            migrationBuilder.UpdateData(
                table: "SectionItemFieldValues",
                keyColumn: "Id",
                keyValue: 52,
                columns: new[] { "SectionId", "SectionItemId" },
                values: new object[] { 0, 0 });

            migrationBuilder.UpdateData(
                table: "SectionItemFieldValues",
                keyColumn: "Id",
                keyValue: 53,
                columns: new[] { "SectionId", "SectionItemId" },
                values: new object[] { 0, 0 });

            migrationBuilder.UpdateData(
                table: "SectionItemFieldValues",
                keyColumn: "Id",
                keyValue: 54,
                columns: new[] { "SectionId", "SectionItemId" },
                values: new object[] { 0, 0 });

            migrationBuilder.UpdateData(
                table: "SectionItemFieldValues",
                keyColumn: "Id",
                keyValue: 55,
                columns: new[] { "SectionId", "SectionItemId" },
                values: new object[] { 0, 0 });

            migrationBuilder.UpdateData(
                table: "SectionItemFieldValues",
                keyColumn: "Id",
                keyValue: 56,
                columns: new[] { "SectionId", "SectionItemId" },
                values: new object[] { 0, 0 });

            migrationBuilder.UpdateData(
                table: "SectionItemFieldValues",
                keyColumn: "Id",
                keyValue: 57,
                columns: new[] { "SectionId", "SectionItemId" },
                values: new object[] { 0, 0 });

            migrationBuilder.UpdateData(
                table: "SectionItemFieldValues",
                keyColumn: "Id",
                keyValue: 58,
                columns: new[] { "SectionId", "SectionItemId" },
                values: new object[] { 0, 0 });

            migrationBuilder.UpdateData(
                table: "SectionItemFieldValues",
                keyColumn: "Id",
                keyValue: 59,
                columns: new[] { "SectionId", "SectionItemId" },
                values: new object[] { 0, 0 });

            migrationBuilder.UpdateData(
                table: "SectionItemFieldValues",
                keyColumn: "Id",
                keyValue: 60,
                columns: new[] { "SectionId", "SectionItemId" },
                values: new object[] { 0, 0 });

            migrationBuilder.UpdateData(
                table: "SectionItemFieldValues",
                keyColumn: "Id",
                keyValue: 61,
                columns: new[] { "SectionId", "SectionItemId" },
                values: new object[] { 0, 0 });

            migrationBuilder.CreateIndex(
                name: "IX_SectionItemFieldValues_SectionId",
                table: "SectionItemFieldValues",
                column: "SectionId");

            migrationBuilder.CreateIndex(
                name: "IX_SectionItemFieldValues_SectionItemId",
                table: "SectionItemFieldValues",
                column: "SectionItemId");

            migrationBuilder.AddForeignKey(
                name: "FK_SectionItemFieldValues_SectionItems_SectionItemId",
                table: "SectionItemFieldValues",
                column: "SectionItemId",
                principalTable: "SectionItems",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SectionItemFieldValues_Sections_SectionId",
                table: "SectionItemFieldValues",
                column: "SectionId",
                principalTable: "Sections",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SectionItemFieldValues_SectionItems_SectionItemId",
                table: "SectionItemFieldValues");

            migrationBuilder.DropForeignKey(
                name: "FK_SectionItemFieldValues_Sections_SectionId",
                table: "SectionItemFieldValues");

            migrationBuilder.DropIndex(
                name: "IX_SectionItemFieldValues_SectionId",
                table: "SectionItemFieldValues");

            migrationBuilder.DropIndex(
                name: "IX_SectionItemFieldValues_SectionItemId",
                table: "SectionItemFieldValues");

            migrationBuilder.DropColumn(
                name: "SectionId",
                table: "SectionItemFieldValues");

            migrationBuilder.DropColumn(
                name: "SectionItemId",
                table: "SectionItemFieldValues");
        }
    }
}
