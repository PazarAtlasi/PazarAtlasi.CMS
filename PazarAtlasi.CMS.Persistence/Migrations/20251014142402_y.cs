using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PazarAtlasi.CMS.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class y : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Sections_Code",
                table: "Sections");

            migrationBuilder.DropIndex(
                name: "IX_SectionItems_Code",
                table: "SectionItems");

            migrationBuilder.DropColumn(
                name: "Code",
                table: "Sections");

            migrationBuilder.DropColumn(
                name: "Code",
                table: "SectionItems");

            migrationBuilder.UpdateData(
                table: "SectionItems",
                keyColumn: "Id",
                keyValue: 10,
                column: "Type",
                value: 18);

            migrationBuilder.CreateIndex(
                name: "IX_SectionTranslations_LanguageId",
                table: "SectionTranslations",
                column: "LanguageId");

            migrationBuilder.AddForeignKey(
                name: "FK_SectionTranslations_Languages_LanguageId",
                table: "SectionTranslations",
                column: "LanguageId",
                principalTable: "Languages",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SectionTranslations_Languages_LanguageId",
                table: "SectionTranslations");

            migrationBuilder.DropIndex(
                name: "IX_SectionTranslations_LanguageId",
                table: "SectionTranslations");

            migrationBuilder.AddColumn<string>(
                name: "Code",
                table: "Sections",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Code",
                table: "SectionItems",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true);

            migrationBuilder.UpdateData(
                table: "SectionItems",
                keyColumn: "Id",
                keyValue: 1,
                column: "Code",
                value: "hero-title");

            migrationBuilder.UpdateData(
                table: "SectionItems",
                keyColumn: "Id",
                keyValue: 2,
                column: "Code",
                value: "hero-subtitle");

            migrationBuilder.UpdateData(
                table: "SectionItems",
                keyColumn: "Id",
                keyValue: 3,
                column: "Code",
                value: "hero-cta-button");

            migrationBuilder.UpdateData(
                table: "SectionItems",
                keyColumn: "Id",
                keyValue: 4,
                column: "Code",
                value: "featured-product-1");

            migrationBuilder.UpdateData(
                table: "SectionItems",
                keyColumn: "Id",
                keyValue: 5,
                column: "Code",
                value: "featured-product-2");

            migrationBuilder.UpdateData(
                table: "SectionItems",
                keyColumn: "Id",
                keyValue: 6,
                column: "Code",
                value: "featured-product-3");

            migrationBuilder.UpdateData(
                table: "SectionItems",
                keyColumn: "Id",
                keyValue: 7,
                column: "Code",
                value: "newsletter-title");

            migrationBuilder.UpdateData(
                table: "SectionItems",
                keyColumn: "Id",
                keyValue: 8,
                column: "Code",
                value: "newsletter-form");

            migrationBuilder.UpdateData(
                table: "SectionItems",
                keyColumn: "Id",
                keyValue: 9,
                column: "Code",
                value: "blog-title");

            migrationBuilder.UpdateData(
                table: "SectionItems",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "Code", "Type" },
                values: new object[] { "blog-search", 22 });

            migrationBuilder.UpdateData(
                table: "Sections",
                keyColumn: "Id",
                keyValue: 1,
                column: "Code",
                value: "hero-section");

            migrationBuilder.UpdateData(
                table: "Sections",
                keyColumn: "Id",
                keyValue: 2,
                column: "Code",
                value: "featured-products");

            migrationBuilder.UpdateData(
                table: "Sections",
                keyColumn: "Id",
                keyValue: 3,
                column: "Code",
                value: "newsletter");

            migrationBuilder.UpdateData(
                table: "Sections",
                keyColumn: "Id",
                keyValue: 4,
                column: "Code",
                value: "blog-header");

            migrationBuilder.UpdateData(
                table: "Sections",
                keyColumn: "Id",
                keyValue: 5,
                column: "Code",
                value: "blog-content");

            migrationBuilder.UpdateData(
                table: "Sections",
                keyColumn: "Id",
                keyValue: 6,
                column: "Code",
                value: "product-catalog");

            migrationBuilder.CreateIndex(
                name: "IX_Sections_Code",
                table: "Sections",
                column: "Code");

            migrationBuilder.CreateIndex(
                name: "IX_SectionItems_Code",
                table: "SectionItems",
                column: "Code");
        }
    }
}
