using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PazarAtlasi.CMS.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class ı : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "LayoutId",
                table: "Pages",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Layout",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsDefault = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<int>(type: "int", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<int>(type: "int", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Layout", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "LayoutSection",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LayoutId = table.Column<int>(type: "int", nullable: false),
                    SectionId = table.Column<int>(type: "int", nullable: false),
                    SortOrder = table.Column<int>(type: "int", nullable: false),
                    IsRequired = table.Column<bool>(type: "bit", nullable: false),
                    Position = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<int>(type: "int", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<int>(type: "int", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LayoutSection", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LayoutSection_Layout_LayoutId",
                        column: x => x.LayoutId,
                        principalTable: "Layout",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LayoutSection_Sections_SectionId",
                        column: x => x.SectionId,
                        principalTable: "Sections",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "Pages",
                keyColumn: "Id",
                keyValue: 1,
                column: "LayoutId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Pages",
                keyColumn: "Id",
                keyValue: 2,
                column: "LayoutId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Pages",
                keyColumn: "Id",
                keyValue: 3,
                column: "LayoutId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Pages",
                keyColumn: "Id",
                keyValue: 4,
                column: "LayoutId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Pages",
                keyColumn: "Id",
                keyValue: 5,
                column: "LayoutId",
                value: null);

            migrationBuilder.CreateIndex(
                name: "IX_Pages_LayoutId",
                table: "Pages",
                column: "LayoutId");

            migrationBuilder.CreateIndex(
                name: "IX_LayoutSection_LayoutId",
                table: "LayoutSection",
                column: "LayoutId");

            migrationBuilder.CreateIndex(
                name: "IX_LayoutSection_SectionId",
                table: "LayoutSection",
                column: "SectionId");

            migrationBuilder.AddForeignKey(
                name: "FK_Pages_Layout_LayoutId",
                table: "Pages",
                column: "LayoutId",
                principalTable: "Layout",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pages_Layout_LayoutId",
                table: "Pages");

            migrationBuilder.DropTable(
                name: "LayoutSection");

            migrationBuilder.DropTable(
                name: "Layout");

            migrationBuilder.DropIndex(
                name: "IX_Pages_LayoutId",
                table: "Pages");

            migrationBuilder.DropColumn(
                name: "LayoutId",
                table: "Pages");
        }
    }
}
