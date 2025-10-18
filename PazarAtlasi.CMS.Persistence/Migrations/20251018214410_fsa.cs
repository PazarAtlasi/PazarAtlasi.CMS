using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PazarAtlasi.CMS.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class fsa : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Sections_Pages_PageId",
                table: "Sections");

            migrationBuilder.DropForeignKey(
                name: "FK_SectionTemplates_Sections_SectionId",
                table: "SectionTemplates");

            migrationBuilder.DropForeignKey(
                name: "FK_SectionTemplates_Templates_TemplateId",
                table: "SectionTemplates");

            migrationBuilder.DropIndex(
                name: "IX_Sections_PageId_SortOrder",
                table: "Sections");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SectionTemplates",
                table: "SectionTemplates");

            migrationBuilder.DropColumn(
                name: "PageId",
                table: "Sections");

            migrationBuilder.RenameTable(
                name: "SectionTemplates",
                newName: "SectionTypeTemplates");

            migrationBuilder.RenameIndex(
                name: "IX_SectionTemplates_TemplateId",
                table: "SectionTypeTemplates",
                newName: "IX_SectionTypeTemplates_TemplateId");

            migrationBuilder.RenameIndex(
                name: "IX_SectionTemplates_SectionType_TemplateId",
                table: "SectionTypeTemplates",
                newName: "IX_SectionTypeTemplates_SectionType_TemplateId");

            migrationBuilder.RenameIndex(
                name: "IX_SectionTemplates_SectionId",
                table: "SectionTypeTemplates",
                newName: "IX_SectionTypeTemplates_SectionId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SectionTypeTemplates",
                table: "SectionTypeTemplates",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "PageSections",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PageId = table.Column<int>(type: "int", nullable: false),
                    SectionId = table.Column<int>(type: "int", nullable: false),
                    SortOrder = table.Column<int>(type: "int", nullable: false, defaultValue: 0),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<int>(type: "int", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<int>(type: "int", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PageSections", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PageSections_Pages_PageId",
                        column: x => x.PageId,
                        principalTable: "Pages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PageSections_Sections_SectionId",
                        column: x => x.SectionId,
                        principalTable: "Sections",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PageSections_PageId",
                table: "PageSections",
                column: "PageId");

            migrationBuilder.CreateIndex(
                name: "IX_PageSections_SectionId",
                table: "PageSections",
                column: "SectionId");

            migrationBuilder.AddForeignKey(
                name: "FK_SectionTypeTemplates_Sections_SectionId",
                table: "SectionTypeTemplates",
                column: "SectionId",
                principalTable: "Sections",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_SectionTypeTemplates_Templates_TemplateId",
                table: "SectionTypeTemplates",
                column: "TemplateId",
                principalTable: "Templates",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SectionTypeTemplates_Sections_SectionId",
                table: "SectionTypeTemplates");

            migrationBuilder.DropForeignKey(
                name: "FK_SectionTypeTemplates_Templates_TemplateId",
                table: "SectionTypeTemplates");

            migrationBuilder.DropTable(
                name: "PageSections");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SectionTypeTemplates",
                table: "SectionTypeTemplates");

            migrationBuilder.RenameTable(
                name: "SectionTypeTemplates",
                newName: "SectionTemplates");

            migrationBuilder.RenameIndex(
                name: "IX_SectionTypeTemplates_TemplateId",
                table: "SectionTemplates",
                newName: "IX_SectionTemplates_TemplateId");

            migrationBuilder.RenameIndex(
                name: "IX_SectionTypeTemplates_SectionType_TemplateId",
                table: "SectionTemplates",
                newName: "IX_SectionTemplates_SectionType_TemplateId");

            migrationBuilder.RenameIndex(
                name: "IX_SectionTypeTemplates_SectionId",
                table: "SectionTemplates",
                newName: "IX_SectionTemplates_SectionId");

            migrationBuilder.AddColumn<int>(
                name: "PageId",
                table: "Sections",
                type: "int",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_SectionTemplates",
                table: "SectionTemplates",
                column: "Id");

            migrationBuilder.UpdateData(
                table: "Sections",
                keyColumn: "Id",
                keyValue: 1,
                column: "PageId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Sections",
                keyColumn: "Id",
                keyValue: 2,
                column: "PageId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Sections",
                keyColumn: "Id",
                keyValue: 3,
                column: "PageId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Sections",
                keyColumn: "Id",
                keyValue: 4,
                column: "PageId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Sections",
                keyColumn: "Id",
                keyValue: 5,
                column: "PageId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Sections",
                keyColumn: "Id",
                keyValue: 6,
                column: "PageId",
                value: 3);

            migrationBuilder.CreateIndex(
                name: "IX_Sections_PageId_SortOrder",
                table: "Sections",
                columns: new[] { "PageId", "SortOrder" });

            migrationBuilder.AddForeignKey(
                name: "FK_Sections_Pages_PageId",
                table: "Sections",
                column: "PageId",
                principalTable: "Pages",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SectionTemplates_Sections_SectionId",
                table: "SectionTemplates",
                column: "SectionId",
                principalTable: "Sections",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_SectionTemplates_Templates_TemplateId",
                table: "SectionTemplates",
                column: "TemplateId",
                principalTable: "Templates",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
