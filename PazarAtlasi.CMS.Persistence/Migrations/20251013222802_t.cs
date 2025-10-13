using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PazarAtlasi.CMS.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class t : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_SectionItemTranslations_LanguageId",
                table: "SectionItemTranslations",
                column: "LanguageId");

            migrationBuilder.AddForeignKey(
                name: "FK_SectionItemTranslations_Languages_LanguageId",
                table: "SectionItemTranslations",
                column: "LanguageId",
                principalTable: "Languages",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SectionItemTranslations_Languages_LanguageId",
                table: "SectionItemTranslations");

            migrationBuilder.DropIndex(
                name: "IX_SectionItemTranslations_LanguageId",
                table: "SectionItemTranslations");
        }
    }
}
