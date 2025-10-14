using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PazarAtlasi.CMS.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class fds : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SectionTemplates_Sections_SectionId",
                table: "SectionTemplates");

            migrationBuilder.DropIndex(
                name: "IX_SectionTemplates_SectionId_TemplateId",
                table: "SectionTemplates");

            migrationBuilder.DropColumn(
                name: "PreviewImageUrl",
                table: "Templates");

            migrationBuilder.AlterColumn<int>(
                name: "SectionId",
                table: "SectionTemplates",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "SectionType",
                table: "SectionTemplates",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "SectionTemplates",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "SectionId", "SectionType" },
                values: new object[] { null, 1 });

            migrationBuilder.UpdateData(
                table: "SectionTemplates",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "SectionId", "SectionType" },
                values: new object[] { null, 1 });

            migrationBuilder.UpdateData(
                table: "SectionTemplates",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "SectionId", "SectionType" },
                values: new object[] { null, 1 });

            migrationBuilder.UpdateData(
                table: "SectionTemplates",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "SectionId", "SectionType" },
                values: new object[] { null, 1 });

            migrationBuilder.CreateIndex(
                name: "IX_SectionTemplates_SectionId",
                table: "SectionTemplates",
                column: "SectionId");

            migrationBuilder.CreateIndex(
                name: "IX_SectionTemplates_SectionType_TemplateId",
                table: "SectionTemplates",
                columns: new[] { "SectionType", "TemplateId" },
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_SectionTemplates_Sections_SectionId",
                table: "SectionTemplates",
                column: "SectionId",
                principalTable: "Sections",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SectionTemplates_Sections_SectionId",
                table: "SectionTemplates");

            migrationBuilder.DropIndex(
                name: "IX_SectionTemplates_SectionId",
                table: "SectionTemplates");

            migrationBuilder.DropIndex(
                name: "IX_SectionTemplates_SectionType_TemplateId",
                table: "SectionTemplates");

            migrationBuilder.DropColumn(
                name: "SectionType",
                table: "SectionTemplates");

            migrationBuilder.AddColumn<string>(
                name: "PreviewImageUrl",
                table: "Templates",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "SectionId",
                table: "SectionTemplates",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "SectionTemplates",
                keyColumn: "Id",
                keyValue: 1,
                column: "SectionId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "SectionTemplates",
                keyColumn: "Id",
                keyValue: 2,
                column: "SectionId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "SectionTemplates",
                keyColumn: "Id",
                keyValue: 3,
                column: "SectionId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "SectionTemplates",
                keyColumn: "Id",
                keyValue: 4,
                column: "SectionId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Templates",
                keyColumn: "Id",
                keyValue: 1,
                column: "PreviewImageUrl",
                value: "/images/templates/navbar-simple.png");

            migrationBuilder.UpdateData(
                table: "Templates",
                keyColumn: "Id",
                keyValue: 2,
                column: "PreviewImageUrl",
                value: "/images/templates/navbar-megamenu.png");

            migrationBuilder.UpdateData(
                table: "Templates",
                keyColumn: "Id",
                keyValue: 3,
                column: "PreviewImageUrl",
                value: "/images/templates/navbar-servicetabs.png");

            migrationBuilder.UpdateData(
                table: "Templates",
                keyColumn: "Id",
                keyValue: 4,
                column: "PreviewImageUrl",
                value: "/images/templates/navbar-categorized.png");

            migrationBuilder.UpdateData(
                table: "Templates",
                keyColumn: "Id",
                keyValue: 5,
                column: "PreviewImageUrl",
                value: "/images/templates/default.png");

            migrationBuilder.UpdateData(
                table: "Templates",
                keyColumn: "Id",
                keyValue: 6,
                column: "PreviewImageUrl",
                value: "/images/templates/sequential.png");

            migrationBuilder.UpdateData(
                table: "Templates",
                keyColumn: "Id",
                keyValue: 7,
                column: "PreviewImageUrl",
                value: "/images/templates/grid.png");

            migrationBuilder.UpdateData(
                table: "Templates",
                keyColumn: "Id",
                keyValue: 8,
                column: "PreviewImageUrl",
                value: "/images/templates/masonry.png");

            migrationBuilder.UpdateData(
                table: "Templates",
                keyColumn: "Id",
                keyValue: 9,
                column: "PreviewImageUrl",
                value: "/images/templates/carousel.png");

            migrationBuilder.UpdateData(
                table: "Templates",
                keyColumn: "Id",
                keyValue: 10,
                column: "PreviewImageUrl",
                value: "/images/templates/list.png");

            migrationBuilder.UpdateData(
                table: "Templates",
                keyColumn: "Id",
                keyValue: 11,
                column: "PreviewImageUrl",
                value: "/images/templates/single-item.png");

            migrationBuilder.UpdateData(
                table: "Templates",
                keyColumn: "Id",
                keyValue: 12,
                column: "PreviewImageUrl",
                value: "/images/templates/multi-item.png");

            migrationBuilder.UpdateData(
                table: "Templates",
                keyColumn: "Id",
                keyValue: 13,
                column: "PreviewImageUrl",
                value: "/images/templates/accordion.png");

            migrationBuilder.UpdateData(
                table: "Templates",
                keyColumn: "Id",
                keyValue: 14,
                column: "PreviewImageUrl",
                value: "/images/templates/tabs.png");

            migrationBuilder.CreateIndex(
                name: "IX_SectionTemplates_SectionId_TemplateId",
                table: "SectionTemplates",
                columns: new[] { "SectionId", "TemplateId" },
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_SectionTemplates_Sections_SectionId",
                table: "SectionTemplates",
                column: "SectionId",
                principalTable: "Sections",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
