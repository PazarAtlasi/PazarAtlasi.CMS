using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace PazarAtlasi.CMS.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AddTemplateAndSectionTemplateEntities : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TemplateType",
                table: "Sections");

            migrationBuilder.AlterColumn<int>(
                name: "PageId",
                table: "Sections",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateTable(
                name: "Templates",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    SectionType = table.Column<int>(type: "int", nullable: false),
                    TemplateType = table.Column<int>(type: "int", nullable: false),
                    TemplateKey = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    PreviewImageUrl = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    ConfigurationSchema = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
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
                    table.PrimaryKey("PK_Templates", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SectionTemplates",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SectionId = table.Column<int>(type: "int", nullable: false),
                    TemplateId = table.Column<int>(type: "int", nullable: false),
                    CustomConfiguration = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<int>(type: "int", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<int>(type: "int", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SectionTemplates", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SectionTemplates_Sections_SectionId",
                        column: x => x.SectionId,
                        principalTable: "Sections",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SectionTemplates_Templates_TemplateId",
                        column: x => x.TemplateId,
                        principalTable: "Templates",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Templates",
                columns: new[] { "Id", "ConfigurationSchema", "CreatedAt", "CreatedBy", "Description", "IsActive", "IsDeleted", "Name", "PreviewImageUrl", "SectionType", "SortOrder", "Status", "TemplateKey", "TemplateType", "UpdatedAt", "UpdatedBy" },
                values: new object[,]
                {
                    { 1, "{\"type\":\"object\",\"properties\":{\"backgroundColor\":{\"type\":\"string\",\"default\":\"#ffffff\"},\"textColor\":{\"type\":\"string\",\"default\":\"#333333\"},\"showLogo\":{\"type\":\"boolean\",\"default\":true},\"logoPosition\":{\"type\":\"string\",\"enum\":[\"left\",\"center\",\"right\"],\"default\":\"left\"}}}", new DateTime(2024, 10, 14, 10, 0, 0, 0, DateTimeKind.Unspecified), null, "A simple horizontal navigation bar with basic menu items", true, false, "Simple Navbar", "/images/templates/navbar-simple.png", 1, 1, 0, "navbar-simple", 1, null, null },
                    { 2, "{\"type\":\"object\",\"properties\":{\"backgroundColor\":{\"type\":\"string\",\"default\":\"#1a1a1a\"},\"textColor\":{\"type\":\"string\",\"default\":\"#ffffff\"},\"showLogo\":{\"type\":\"boolean\",\"default\":true},\"logoPosition\":{\"type\":\"string\",\"enum\":[\"left\",\"center\",\"right\"],\"default\":\"left\"},\"megaMenuColumns\":{\"type\":\"integer\",\"minimum\":2,\"maximum\":4,\"default\":3},\"showDescriptions\":{\"type\":\"boolean\",\"default\":true},\"showImages\":{\"type\":\"boolean\",\"default\":true}}}", new DateTime(2024, 10, 14, 10, 0, 0, 0, DateTimeKind.Unspecified), null, "Advanced navbar with dropdown mega menus and rich content", true, false, "Mega Menu Navbar", "/images/templates/navbar-megamenu.png", 1, 2, 0, "navbar-megamenu", 11, null, null },
                    { 3, "{\"type\":\"object\",\"properties\":{\"backgroundColor\":{\"type\":\"string\",\"default\":\"#2d3748\"},\"textColor\":{\"type\":\"string\",\"default\":\"#ffffff\"},\"showLogo\":{\"type\":\"boolean\",\"default\":true},\"logoPosition\":{\"type\":\"string\",\"enum\":[\"left\",\"center\",\"right\"],\"default\":\"left\"},\"tabStyle\":{\"type\":\"string\",\"enum\":[\"pills\",\"underline\",\"background\"],\"default\":\"pills\"},\"showIcons\":{\"type\":\"boolean\",\"default\":true},\"animationDuration\":{\"type\":\"integer\",\"minimum\":100,\"maximum\":1000,\"default\":300}}}", new DateTime(2024, 10, 14, 10, 0, 0, 0, DateTimeKind.Unspecified), null, "Navbar with tabbed service navigation and interactive content", true, false, "Service Tabs Navbar", "/images/templates/navbar-servicetabs.png", 1, 3, 0, "navbar-servicetabs", 10, null, null },
                    { 4, "{\"type\":\"object\",\"properties\":{\"backgroundColor\":{\"type\":\"string\",\"default\":\"#4a5568\"},\"textColor\":{\"type\":\"string\",\"default\":\"#ffffff\"},\"showLogo\":{\"type\":\"boolean\",\"default\":true},\"logoPosition\":{\"type\":\"string\",\"enum\":[\"left\",\"center\",\"right\"],\"default\":\"left\"},\"categoryStyle\":{\"type\":\"string\",\"enum\":[\"sidebar\",\"dropdown\",\"tabs\"],\"default\":\"sidebar\"},\"showCategoryIcons\":{\"type\":\"boolean\",\"default\":true},\"itemsPerCategory\":{\"type\":\"integer\",\"minimum\":2,\"maximum\":8,\"default\":4}}}", new DateTime(2024, 10, 14, 10, 0, 0, 0, DateTimeKind.Unspecified), null, "Navbar with categorized menu items and filtered content display", true, false, "Categorized Navbar", "/images/templates/navbar-categorized.png", 1, 4, 0, "navbar-categorized", 6, null, null },
                    { 5, "{\"type\":\"object\",\"properties\":{\"backgroundType\":{\"type\":\"string\",\"enum\":[\"color\",\"image\",\"gradient\"],\"default\":\"gradient\"},\"backgroundColor\":{\"type\":\"string\",\"default\":\"#667eea\"},\"backgroundImage\":{\"type\":\"string\"},\"textAlign\":{\"type\":\"string\",\"enum\":[\"left\",\"center\",\"right\"],\"default\":\"center\"},\"showButton\":{\"type\":\"boolean\",\"default\":true},\"buttonStyle\":{\"type\":\"string\",\"enum\":[\"primary\",\"secondary\",\"outline\"],\"default\":\"primary\"}}}", new DateTime(2024, 10, 14, 10, 0, 0, 0, DateTimeKind.Unspecified), null, "Clean hero section with title, subtitle and call-to-action button", true, false, "Simple Hero", "/images/templates/hero-simple.png", 3, 5, 0, "hero-simple", 1, null, null },
                    { 6, "{\"type\":\"object\",\"properties\":{\"autoPlay\":{\"type\":\"boolean\",\"default\":true},\"interval\":{\"type\":\"integer\",\"minimum\":2000,\"maximum\":10000,\"default\":5000},\"showIndicators\":{\"type\":\"boolean\",\"default\":true},\"showArrows\":{\"type\":\"boolean\",\"default\":true},\"transitionEffect\":{\"type\":\"string\",\"enum\":[\"fade\",\"slide\",\"zoom\"],\"default\":\"slide\"}}}", new DateTime(2024, 10, 14, 10, 0, 0, 0, DateTimeKind.Unspecified), null, "Hero section with rotating slides and multiple call-to-actions", true, false, "Hero Carousel", "/images/templates/hero-carousel.png", 3, 6, 0, "hero-carousel", 5, null, null },
                    { 7, "{\"type\":\"object\",\"properties\":{\"columns\":{\"type\":\"integer\",\"minimum\":1,\"maximum\":6,\"default\":3},\"gap\":{\"type\":\"string\",\"enum\":[\"small\",\"medium\",\"large\"],\"default\":\"medium\"},\"showImages\":{\"type\":\"boolean\",\"default\":true},\"showExcerpts\":{\"type\":\"boolean\",\"default\":true},\"itemsPerPage\":{\"type\":\"integer\",\"minimum\":6,\"maximum\":24,\"default\":12}}}", new DateTime(2024, 10, 14, 10, 0, 0, 0, DateTimeKind.Unspecified), null, "Content displayed in a responsive grid layout", true, false, "Grid Layout", "/images/templates/content-grid.png", 12, 7, 0, "content-grid", 3, null, null },
                    { 8, "{\"type\":\"object\",\"properties\":{\"columns\":{\"type\":\"integer\",\"minimum\":2,\"maximum\":5,\"default\":3},\"gap\":{\"type\":\"string\",\"enum\":[\"small\",\"medium\",\"large\"],\"default\":\"medium\"},\"showImages\":{\"type\":\"boolean\",\"default\":true},\"imageAspectRatio\":{\"type\":\"string\",\"enum\":[\"auto\",\"square\",\"landscape\",\"portrait\"],\"default\":\"auto\"}}}", new DateTime(2024, 10, 14, 10, 0, 0, 0, DateTimeKind.Unspecified), null, "Pinterest-style masonry layout for varied content sizes", true, false, "Masonry Layout", "/images/templates/content-masonry.png", 12, 8, 0, "content-masonry", 4, null, null },
                    { 9, "{\"type\":\"object\",\"properties\":{\"backgroundColor\":{\"type\":\"string\",\"default\":\"#2d3748\"},\"textColor\":{\"type\":\"string\",\"default\":\"#ffffff\"},\"columns\":{\"type\":\"integer\",\"minimum\":2,\"maximum\":5,\"default\":4},\"showSocialMedia\":{\"type\":\"boolean\",\"default\":true},\"showNewsletter\":{\"type\":\"boolean\",\"default\":true},\"showCopyright\":{\"type\":\"boolean\",\"default\":true}}}", new DateTime(2024, 10, 14, 10, 0, 0, 0, DateTimeKind.Unspecified), null, "Footer with multiple columns for links, contact info and social media", true, false, "Multi-Column Footer", "/images/templates/footer-multicolumn.png", 10, 9, 0, "footer-multicolumn", 8, null, null },
                    { 10, "{\"type\":\"object\",\"properties\":{\"backgroundColor\":{\"type\":\"string\",\"default\":\"#1a202c\"},\"textColor\":{\"type\":\"string\",\"default\":\"#ffffff\"},\"textAlign\":{\"type\":\"string\",\"enum\":[\"left\",\"center\",\"right\"],\"default\":\"center\"},\"showSocialMedia\":{\"type\":\"boolean\",\"default\":false},\"showCopyright\":{\"type\":\"boolean\",\"default\":true}}}", new DateTime(2024, 10, 14, 10, 0, 0, 0, DateTimeKind.Unspecified), null, "Minimal footer with essential links and copyright", true, false, "Simple Footer", "/images/templates/footer-simple.png", 10, 10, 0, "footer-simple", 7, null, null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_SectionTemplates_SectionId_TemplateId",
                table: "SectionTemplates",
                columns: new[] { "SectionId", "TemplateId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_SectionTemplates_TemplateId",
                table: "SectionTemplates",
                column: "TemplateId");

            migrationBuilder.CreateIndex(
                name: "IX_Templates_SectionType_IsActive",
                table: "Templates",
                columns: new[] { "SectionType", "IsActive" });

            migrationBuilder.CreateIndex(
                name: "IX_Templates_TemplateKey",
                table: "Templates",
                column: "TemplateKey",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SectionTemplates");

            migrationBuilder.DropTable(
                name: "Templates");

            migrationBuilder.AlterColumn<int>(
                name: "PageId",
                table: "Sections",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TemplateType",
                table: "Sections",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Sections",
                keyColumn: "Id",
                keyValue: 1,
                column: "TemplateType",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Sections",
                keyColumn: "Id",
                keyValue: 2,
                column: "TemplateType",
                value: 3);

            migrationBuilder.UpdateData(
                table: "Sections",
                keyColumn: "Id",
                keyValue: 3,
                column: "TemplateType",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Sections",
                keyColumn: "Id",
                keyValue: 4,
                column: "TemplateType",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Sections",
                keyColumn: "Id",
                keyValue: 5,
                column: "TemplateType",
                value: 6);

            migrationBuilder.UpdateData(
                table: "Sections",
                keyColumn: "Id",
                keyValue: 6,
                column: "TemplateType",
                value: 3);
        }
    }
}
