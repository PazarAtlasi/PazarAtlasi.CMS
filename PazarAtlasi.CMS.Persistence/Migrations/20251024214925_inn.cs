using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PazarAtlasi.CMS.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class inn : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SectionItemFields_Templates_TemplateId",
                table: "SectionItemFields");

            migrationBuilder.DropForeignKey(
                name: "FK_SectionItemFields_Templates_TemplateId1",
                table: "SectionItemFields");

            migrationBuilder.DropIndex(
                name: "IX_SectionItemFields_TemplateId1",
                table: "SectionItemFields");

            migrationBuilder.DropColumn(
                name: "TemplateId1",
                table: "SectionItemFields");

            migrationBuilder.AlterColumn<int>(
                name: "TemplateId",
                table: "SectionItemFields",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "MaxLength",
                table: "SectionItemFields",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateTable(
                name: "SectionItemFieldTranslations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SectionItemFieldId = table.Column<int>(type: "int", nullable: false),
                    LanguageId = table.Column<int>(type: "int", nullable: false),
                    Label = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Placeholder = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<int>(type: "int", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<int>(type: "int", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SectionItemFieldTranslations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SectionItemFieldTranslations_Languages_LanguageId",
                        column: x => x.LanguageId,
                        principalTable: "Languages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SectionItemFieldTranslations_SectionItemFields_SectionItemFieldId",
                        column: x => x.SectionItemFieldId,
                        principalTable: "SectionItemFields",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SectionItemFieldTranslations_FieldId_LanguageId",
                table: "SectionItemFieldTranslations",
                columns: new[] { "SectionItemFieldId", "LanguageId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_SectionItemFieldTranslations_LanguageId",
                table: "SectionItemFieldTranslations",
                column: "LanguageId");

            migrationBuilder.AddForeignKey(
                name: "FK_SectionItemFields_Templates_TemplateId",
                table: "SectionItemFields",
                column: "TemplateId",
                principalTable: "Templates",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SectionItemFields_Templates_TemplateId",
                table: "SectionItemFields");

            migrationBuilder.DropTable(
                name: "SectionItemFieldTranslations");

            migrationBuilder.AlterColumn<int>(
                name: "TemplateId",
                table: "SectionItemFields",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "MaxLength",
                table: "SectionItemFields",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TemplateId1",
                table: "SectionItemFields",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_SectionItemFields_TemplateId1",
                table: "SectionItemFields",
                column: "TemplateId1");

            migrationBuilder.AddForeignKey(
                name: "FK_SectionItemFields_Templates_TemplateId",
                table: "SectionItemFields",
                column: "TemplateId",
                principalTable: "Templates",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_SectionItemFields_Templates_TemplateId1",
                table: "SectionItemFields",
                column: "TemplateId1",
                principalTable: "Templates",
                principalColumn: "Id");
        }
    }
}
