using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PazarAtlasi.CMS.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class fixsa : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ParentId",
                table: "SectionItems",
                newName: "ParentItemId");

            migrationBuilder.AddColumn<string>(
                name: "Data",
                table: "SectionItems",
                type: "nvarchar(max)",
                nullable: true,
                defaultValue: "{}");

            migrationBuilder.UpdateData(
                table: "SectionItems",
                keyColumn: "Id",
                keyValue: 1,
                column: "Data",
                value: "{}");

            migrationBuilder.UpdateData(
                table: "SectionItems",
                keyColumn: "Id",
                keyValue: 2,
                column: "Data",
                value: "{}");

            migrationBuilder.UpdateData(
                table: "SectionItems",
                keyColumn: "Id",
                keyValue: 3,
                column: "Data",
                value: "{}");

            migrationBuilder.UpdateData(
                table: "SectionItems",
                keyColumn: "Id",
                keyValue: 4,
                column: "Data",
                value: "{}");

            migrationBuilder.UpdateData(
                table: "SectionItems",
                keyColumn: "Id",
                keyValue: 5,
                column: "Data",
                value: "{}");

            migrationBuilder.UpdateData(
                table: "SectionItems",
                keyColumn: "Id",
                keyValue: 6,
                column: "Data",
                value: "{}");

            migrationBuilder.UpdateData(
                table: "SectionItems",
                keyColumn: "Id",
                keyValue: 7,
                column: "Data",
                value: "{}");

            migrationBuilder.UpdateData(
                table: "SectionItems",
                keyColumn: "Id",
                keyValue: 8,
                column: "Data",
                value: "{}");

            migrationBuilder.UpdateData(
                table: "SectionItems",
                keyColumn: "Id",
                keyValue: 9,
                column: "Data",
                value: "{}");

            migrationBuilder.UpdateData(
                table: "SectionItems",
                keyColumn: "Id",
                keyValue: 10,
                column: "Data",
                value: "{}");

            migrationBuilder.CreateIndex(
                name: "IX_SectionItems_ParentItemId",
                table: "SectionItems",
                column: "ParentItemId");

            migrationBuilder.AddForeignKey(
                name: "FK_SectionItems_SectionItems_ParentItemId",
                table: "SectionItems",
                column: "ParentItemId",
                principalTable: "SectionItems",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SectionItems_SectionItems_ParentItemId",
                table: "SectionItems");

            migrationBuilder.DropIndex(
                name: "IX_SectionItems_ParentItemId",
                table: "SectionItems");

            migrationBuilder.DropColumn(
                name: "Data",
                table: "SectionItems");

            migrationBuilder.RenameColumn(
                name: "ParentItemId",
                table: "SectionItems",
                newName: "ParentId");
        }
    }
}
