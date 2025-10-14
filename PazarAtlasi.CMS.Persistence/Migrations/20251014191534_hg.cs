using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace PazarAtlasi.CMS.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class hg : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Templates_SectionType_IsActive",
                table: "Templates");

            migrationBuilder.DropColumn(
                name: "SectionType",
                table: "Templates");

            migrationBuilder.InsertData(
                table: "SectionTemplates",
                columns: new[] { "Id", "CreatedAt", "CreatedBy", "CustomConfiguration", "IsDeleted", "SectionId", "Status", "TemplateId", "UpdatedAt", "UpdatedBy" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 10, 14, 10, 0, 0, 0, DateTimeKind.Unspecified), null, null, false, 1, 1, 1, null, null },
                    { 2, new DateTime(2024, 10, 14, 10, 0, 0, 0, DateTimeKind.Unspecified), null, null, false, 1, 1, 2, null, null },
                    { 3, new DateTime(2024, 10, 14, 10, 0, 0, 0, DateTimeKind.Unspecified), null, null, false, 1, 1, 3, null, null },
                    { 4, new DateTime(2024, 10, 14, 10, 0, 0, 0, DateTimeKind.Unspecified), null, null, false, 1, 1, 4, null, null }
                });

            migrationBuilder.UpdateData(
                table: "Templates",
                keyColumn: "Id",
                keyValue: 2,
                column: "TemplateType",
                value: 11);

            migrationBuilder.UpdateData(
                table: "Templates",
                keyColumn: "Id",
                keyValue: 3,
                column: "TemplateType",
                value: 10);

            migrationBuilder.UpdateData(
                table: "Templates",
                keyColumn: "Id",
                keyValue: 4,
                column: "TemplateType",
                value: 6);

            migrationBuilder.UpdateData(
                table: "Templates",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "ConfigurationSchema", "Description", "Name", "PreviewImageUrl", "TemplateKey" },
                values: new object[] { "{\"type\":\"object\",\"properties\":{\"backgroundColor\":{\"type\":\"string\",\"default\":\"#ffffff\"},\"textColor\":{\"type\":\"string\",\"default\":\"#333333\"},\"padding\":{\"type\":\"string\",\"enum\":[\"small\",\"medium\",\"large\"],\"default\":\"medium\"}}}", "Standard template for any section type", "Default Template", "/images/templates/default.png", "default" });

            migrationBuilder.InsertData(
                table: "Templates",
                columns: new[] { "Id", "ConfigurationSchema", "CreatedAt", "CreatedBy", "Description", "IsActive", "IsDeleted", "Name", "PreviewImageUrl", "SortOrder", "Status", "TemplateKey", "TemplateType", "UpdatedAt", "UpdatedBy" },
                values: new object[,]
                {
                    { 6, "{\"type\":\"object\",\"properties\":{\"direction\":{\"type\":\"string\",\"enum\":[\"horizontal\",\"vertical\"],\"default\":\"vertical\"},\"spacing\":{\"type\":\"string\",\"enum\":[\"small\",\"medium\",\"large\"],\"default\":\"medium\"},\"showNumbers\":{\"type\":\"boolean\",\"default\":false}}}", new DateTime(2024, 10, 14, 10, 0, 0, 0, DateTimeKind.Unspecified), null, "Items displayed in sequential order", true, false, "Sequential Layout", "/images/templates/sequential.png", 6, 0, "sequential", 2, null, null },
                    { 7, "{\"type\":\"object\",\"properties\":{\"columns\":{\"type\":\"integer\",\"minimum\":1,\"maximum\":6,\"default\":3},\"gap\":{\"type\":\"string\",\"enum\":[\"small\",\"medium\",\"large\"],\"default\":\"medium\"},\"showImages\":{\"type\":\"boolean\",\"default\":true},\"showExcerpts\":{\"type\":\"boolean\",\"default\":true}}}", new DateTime(2024, 10, 14, 10, 0, 0, 0, DateTimeKind.Unspecified), null, "Content displayed in a responsive grid layout", true, false, "Grid Layout", "/images/templates/grid.png", 7, 0, "grid", 3, null, null },
                    { 8, "{\"type\":\"object\",\"properties\":{\"columns\":{\"type\":\"integer\",\"minimum\":2,\"maximum\":5,\"default\":3},\"gap\":{\"type\":\"string\",\"enum\":[\"small\",\"medium\",\"large\"],\"default\":\"medium\"},\"showImages\":{\"type\":\"boolean\",\"default\":true},\"imageAspectRatio\":{\"type\":\"string\",\"enum\":[\"auto\",\"square\",\"landscape\",\"portrait\"],\"default\":\"auto\"}}}", new DateTime(2024, 10, 14, 10, 0, 0, 0, DateTimeKind.Unspecified), null, "Pinterest-style masonry layout for varied content sizes", true, false, "Masonry Layout", "/images/templates/masonry.png", 8, 0, "masonry", 4, null, null },
                    { 9, "{\"type\":\"object\",\"properties\":{\"autoPlay\":{\"type\":\"boolean\",\"default\":true},\"interval\":{\"type\":\"integer\",\"minimum\":2000,\"maximum\":10000,\"default\":5000},\"showIndicators\":{\"type\":\"boolean\",\"default\":true},\"showArrows\":{\"type\":\"boolean\",\"default\":true},\"transitionEffect\":{\"type\":\"string\",\"enum\":[\"fade\",\"slide\",\"zoom\"],\"default\":\"slide\"}}}", new DateTime(2024, 10, 14, 10, 0, 0, 0, DateTimeKind.Unspecified), null, "Sliding carousel with navigation controls", true, false, "Carousel", "/images/templates/carousel.png", 9, 0, "carousel", 5, null, null },
                    { 10, "{\"type\":\"object\",\"properties\":{\"showIcons\":{\"type\":\"boolean\",\"default\":true},\"iconPosition\":{\"type\":\"string\",\"enum\":[\"left\",\"right\"],\"default\":\"left\"},\"spacing\":{\"type\":\"string\",\"enum\":[\"compact\",\"comfortable\",\"spacious\"],\"default\":\"comfortable\"},\"showDividers\":{\"type\":\"boolean\",\"default\":false}}}", new DateTime(2024, 10, 14, 10, 0, 0, 0, DateTimeKind.Unspecified), null, "Simple list layout with optional icons", true, false, "List Layout", "/images/templates/list.png", 10, 0, "list", 6, null, null },
                    { 11, "{\"type\":\"object\",\"properties\":{\"alignment\":{\"type\":\"string\",\"enum\":[\"left\",\"center\",\"right\"],\"default\":\"center\"},\"showImage\":{\"type\":\"boolean\",\"default\":true},\"imageSize\":{\"type\":\"string\",\"enum\":[\"small\",\"medium\",\"large\"],\"default\":\"medium\"},\"showDescription\":{\"type\":\"boolean\",\"default\":true}}}", new DateTime(2024, 10, 14, 10, 0, 0, 0, DateTimeKind.Unspecified), null, "Display single item with focus", true, false, "Single Item", "/images/templates/single-item.png", 11, 0, "single-item", 7, null, null },
                    { 12, "{\"type\":\"object\",\"properties\":{\"itemsPerRow\":{\"type\":\"integer\",\"minimum\":2,\"maximum\":6,\"default\":3},\"showTitles\":{\"type\":\"boolean\",\"default\":true},\"showDescriptions\":{\"type\":\"boolean\",\"default\":true},\"equalHeight\":{\"type\":\"boolean\",\"default\":true}}}", new DateTime(2024, 10, 14, 10, 0, 0, 0, DateTimeKind.Unspecified), null, "Display multiple items in organized layout", true, false, "Multi Item", "/images/templates/multi-item.png", 12, 0, "multi-item", 8, null, null },
                    { 13, "{\"type\":\"object\",\"properties\":{\"allowMultiple\":{\"type\":\"boolean\",\"default\":false},\"defaultOpen\":{\"type\":\"integer\",\"minimum\":0,\"default\":0},\"showIcons\":{\"type\":\"boolean\",\"default\":true},\"animationDuration\":{\"type\":\"integer\",\"minimum\":100,\"maximum\":1000,\"default\":300}}}", new DateTime(2024, 10, 14, 10, 0, 0, 0, DateTimeKind.Unspecified), null, "Collapsible accordion layout", true, false, "Accordion", "/images/templates/accordion.png", 13, 0, "accordion", 9, null, null },
                    { 14, "{\"type\":\"object\",\"properties\":{\"tabPosition\":{\"type\":\"string\",\"enum\":[\"top\",\"bottom\",\"left\",\"right\"],\"default\":\"top\"},\"tabStyle\":{\"type\":\"string\",\"enum\":[\"pills\",\"underline\",\"background\"],\"default\":\"underline\"},\"showIcons\":{\"type\":\"boolean\",\"default\":false},\"defaultTab\":{\"type\":\"integer\",\"minimum\":0,\"default\":0}}}", new DateTime(2024, 10, 14, 10, 0, 0, 0, DateTimeKind.Unspecified), null, "Tabbed content layout", true, false, "Tabs", "/images/templates/tabs.png", 14, 0, "tabs", 10, null, null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Templates_TemplateType_IsActive",
                table: "Templates",
                columns: new[] { "TemplateType", "IsActive" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Templates_TemplateType_IsActive",
                table: "Templates");

            migrationBuilder.DeleteData(
                table: "SectionTemplates",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "SectionTemplates",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "SectionTemplates",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "SectionTemplates",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Templates",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Templates",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Templates",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Templates",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Templates",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Templates",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Templates",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Templates",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Templates",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.AddColumn<int>(
                name: "SectionType",
                table: "Templates",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Templates",
                keyColumn: "Id",
                keyValue: 1,
                column: "SectionType",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Templates",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "SectionType", "TemplateType" },
                values: new object[] { 1, 4 });

            migrationBuilder.UpdateData(
                table: "Templates",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "SectionType", "TemplateType" },
                values: new object[] { 1, 3 });

            migrationBuilder.UpdateData(
                table: "Templates",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "SectionType", "TemplateType" },
                values: new object[] { 1, 2 });

            migrationBuilder.UpdateData(
                table: "Templates",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "ConfigurationSchema", "Description", "Name", "PreviewImageUrl", "SectionType", "TemplateKey" },
                values: new object[] { "{\"type\":\"object\",\"properties\":{\"backgroundType\":{\"type\":\"string\",\"enum\":[\"color\",\"image\",\"gradient\"],\"default\":\"gradient\"},\"backgroundColor\":{\"type\":\"string\",\"default\":\"#667eea\"},\"backgroundImage\":{\"type\":\"string\"},\"textAlign\":{\"type\":\"string\",\"enum\":[\"left\",\"center\",\"right\"],\"default\":\"center\"},\"showButton\":{\"type\":\"boolean\",\"default\":true},\"buttonStyle\":{\"type\":\"string\",\"enum\":[\"primary\",\"secondary\",\"outline\"],\"default\":\"primary\"}}}", "Clean hero section with title, subtitle and call-to-action button", "Simple Hero", "/images/templates/hero-simple.png", 3, "hero-simple" });

            migrationBuilder.CreateIndex(
                name: "IX_Templates_SectionType_IsActive",
                table: "Templates",
                columns: new[] { "SectionType", "IsActive" });
        }
    }
}
