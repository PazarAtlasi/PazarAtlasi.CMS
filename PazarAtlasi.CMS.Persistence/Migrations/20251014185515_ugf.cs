using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace PazarAtlasi.CMS.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class ugf : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LayoutSection_Layout_LayoutId",
                table: "LayoutSection");

            migrationBuilder.DropForeignKey(
                name: "FK_LayoutSection_Sections_SectionId",
                table: "LayoutSection");

            migrationBuilder.DropForeignKey(
                name: "FK_Pages_Layout_LayoutId",
                table: "Pages");

            migrationBuilder.DropPrimaryKey(
                name: "PK_LayoutSection",
                table: "LayoutSection");

            migrationBuilder.DropIndex(
                name: "IX_LayoutSection_LayoutId",
                table: "LayoutSection");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Layout",
                table: "Layout");

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

            migrationBuilder.RenameTable(
                name: "LayoutSection",
                newName: "LayoutSections");

            migrationBuilder.RenameTable(
                name: "Layout",
                newName: "Layouts");

            migrationBuilder.RenameIndex(
                name: "IX_LayoutSection_SectionId",
                table: "LayoutSections",
                newName: "IX_LayoutSections_SectionId");

            migrationBuilder.AlterColumn<int>(
                name: "SortOrder",
                table: "LayoutSections",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "Position",
                table: "LayoutSections",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<bool>(
                name: "IsRequired",
                table: "LayoutSections",
                type: "bit",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AlterColumn<bool>(
                name: "IsDeleted",
                table: "LayoutSections",
                type: "bit",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Layouts",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<bool>(
                name: "IsDeleted",
                table: "Layouts",
                type: "bit",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AlterColumn<bool>(
                name: "IsDefault",
                table: "Layouts",
                type: "bit",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Layouts",
                type: "nvarchar(1000)",
                maxLength: 1000,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddPrimaryKey(
                name: "PK_LayoutSections",
                table: "LayoutSections",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Layouts",
                table: "Layouts",
                column: "Id");

            migrationBuilder.InsertData(
                table: "Layouts",
                columns: new[] { "Id", "CreatedAt", "CreatedBy", "Description", "IsDefault", "Name", "Status", "UpdatedAt", "UpdatedBy" },
                values: new object[] { 1, new DateTime(2024, 10, 14, 10, 0, 0, 0, DateTimeKind.Unspecified), null, "Standard layout with header, main content, and footer", true, "Default Layout", 1, null, null });

            migrationBuilder.InsertData(
                table: "Layouts",
                columns: new[] { "Id", "CreatedAt", "CreatedBy", "Description", "Name", "Status", "UpdatedAt", "UpdatedBy" },
                values: new object[,]
                {
                    { 2, new DateTime(2024, 10, 14, 10, 0, 0, 0, DateTimeKind.Unspecified), null, "Hero-focused layout for landing pages", "Landing Page Layout", 1, null, null },
                    { 3, new DateTime(2024, 10, 14, 10, 0, 0, 0, DateTimeKind.Unspecified), null, "Content-focused layout with sidebar for blog posts", "Blog Layout", 1, null, null },
                    { 4, new DateTime(2024, 10, 14, 10, 0, 0, 0, DateTimeKind.Unspecified), null, "Clean minimal layout with just content area", "Minimal Layout", 1, null, null }
                });

            migrationBuilder.UpdateData(
                table: "Templates",
                keyColumn: "Id",
                keyValue: 2,
                column: "TemplateType",
                value: 4);

            migrationBuilder.UpdateData(
                table: "Templates",
                keyColumn: "Id",
                keyValue: 3,
                column: "TemplateType",
                value: 3);

            migrationBuilder.UpdateData(
                table: "Templates",
                keyColumn: "Id",
                keyValue: 4,
                column: "TemplateType",
                value: 2);

            migrationBuilder.InsertData(
                table: "LayoutSections",
                columns: new[] { "Id", "CreatedAt", "CreatedBy", "IsRequired", "LayoutId", "Position", "SectionId", "SortOrder", "Status", "UpdatedAt", "UpdatedBy" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 10, 14, 10, 0, 0, 0, DateTimeKind.Unspecified), null, true, 1, "header", 1, 1, 1, null, null },
                    { 2, new DateTime(2024, 10, 14, 10, 0, 0, 0, DateTimeKind.Unspecified), null, true, 1, "content", 2, 1, 1, null, null },
                    { 3, new DateTime(2024, 10, 14, 10, 0, 0, 0, DateTimeKind.Unspecified), null, true, 1, "footer", 3, 1, 1, null, null },
                    { 4, new DateTime(2024, 10, 14, 10, 0, 0, 0, DateTimeKind.Unspecified), null, true, 2, "header", 1, 1, 1, null, null },
                    { 5, new DateTime(2024, 10, 14, 10, 0, 0, 0, DateTimeKind.Unspecified), null, true, 2, "content", 4, 1, 1, null, null }
                });

            migrationBuilder.InsertData(
                table: "LayoutSections",
                columns: new[] { "Id", "CreatedAt", "CreatedBy", "LayoutId", "Position", "SectionId", "SortOrder", "Status", "UpdatedAt", "UpdatedBy" },
                values: new object[] { 6, new DateTime(2024, 10, 14, 10, 0, 0, 0, DateTimeKind.Unspecified), null, 2, "content", 2, 2, 1, null, null });

            migrationBuilder.InsertData(
                table: "LayoutSections",
                columns: new[] { "Id", "CreatedAt", "CreatedBy", "IsRequired", "LayoutId", "Position", "SectionId", "SortOrder", "Status", "UpdatedAt", "UpdatedBy" },
                values: new object[] { 7, new DateTime(2024, 10, 14, 10, 0, 0, 0, DateTimeKind.Unspecified), null, true, 2, "footer", 3, 1, 1, null, null });

            migrationBuilder.CreateIndex(
                name: "IX_LayoutSections_LayoutId_Position_SortOrder",
                table: "LayoutSections",
                columns: new[] { "LayoutId", "Position", "SortOrder" });

            migrationBuilder.CreateIndex(
                name: "IX_LayoutSections_LayoutId_SectionId",
                table: "LayoutSections",
                columns: new[] { "LayoutId", "SectionId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_LayoutSections_Status_IsDeleted",
                table: "LayoutSections",
                columns: new[] { "Status", "IsDeleted" });

            migrationBuilder.CreateIndex(
                name: "IX_Layouts_IsDefault",
                table: "Layouts",
                column: "IsDefault");

            migrationBuilder.CreateIndex(
                name: "IX_Layouts_Name",
                table: "Layouts",
                column: "Name");

            migrationBuilder.CreateIndex(
                name: "IX_Layouts_Status_IsDeleted",
                table: "Layouts",
                columns: new[] { "Status", "IsDeleted" });

            migrationBuilder.AddForeignKey(
                name: "FK_LayoutSections_Layouts_LayoutId",
                table: "LayoutSections",
                column: "LayoutId",
                principalTable: "Layouts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_LayoutSections_Sections_SectionId",
                table: "LayoutSections",
                column: "SectionId",
                principalTable: "Sections",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Pages_Layouts_LayoutId",
                table: "Pages",
                column: "LayoutId",
                principalTable: "Layouts",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LayoutSections_Layouts_LayoutId",
                table: "LayoutSections");

            migrationBuilder.DropForeignKey(
                name: "FK_LayoutSections_Sections_SectionId",
                table: "LayoutSections");

            migrationBuilder.DropForeignKey(
                name: "FK_Pages_Layouts_LayoutId",
                table: "Pages");

            migrationBuilder.DropPrimaryKey(
                name: "PK_LayoutSections",
                table: "LayoutSections");

            migrationBuilder.DropIndex(
                name: "IX_LayoutSections_LayoutId_Position_SortOrder",
                table: "LayoutSections");

            migrationBuilder.DropIndex(
                name: "IX_LayoutSections_LayoutId_SectionId",
                table: "LayoutSections");

            migrationBuilder.DropIndex(
                name: "IX_LayoutSections_Status_IsDeleted",
                table: "LayoutSections");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Layouts",
                table: "Layouts");

            migrationBuilder.DropIndex(
                name: "IX_Layouts_IsDefault",
                table: "Layouts");

            migrationBuilder.DropIndex(
                name: "IX_Layouts_Name",
                table: "Layouts");

            migrationBuilder.DropIndex(
                name: "IX_Layouts_Status_IsDeleted",
                table: "Layouts");

            migrationBuilder.DeleteData(
                table: "LayoutSections",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "LayoutSections",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "LayoutSections",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "LayoutSections",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "LayoutSections",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "LayoutSections",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "LayoutSections",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Layouts",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Layouts",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Layouts",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Layouts",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.RenameTable(
                name: "LayoutSections",
                newName: "LayoutSection");

            migrationBuilder.RenameTable(
                name: "Layouts",
                newName: "Layout");

            migrationBuilder.RenameIndex(
                name: "IX_LayoutSections_SectionId",
                table: "LayoutSection",
                newName: "IX_LayoutSection_SectionId");

            migrationBuilder.AlterColumn<int>(
                name: "SortOrder",
                table: "LayoutSection",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldDefaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "Position",
                table: "LayoutSection",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<bool>(
                name: "IsRequired",
                table: "LayoutSection",
                type: "bit",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldDefaultValue: false);

            migrationBuilder.AlterColumn<bool>(
                name: "IsDeleted",
                table: "LayoutSection",
                type: "bit",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldDefaultValue: false);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Layout",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(200)",
                oldMaxLength: 200);

            migrationBuilder.AlterColumn<bool>(
                name: "IsDeleted",
                table: "Layout",
                type: "bit",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldDefaultValue: false);

            migrationBuilder.AlterColumn<bool>(
                name: "IsDefault",
                table: "Layout",
                type: "bit",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldDefaultValue: false);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Layout",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(1000)",
                oldMaxLength: 1000);

            migrationBuilder.AddPrimaryKey(
                name: "PK_LayoutSection",
                table: "LayoutSection",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Layout",
                table: "Layout",
                column: "Id");

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

            migrationBuilder.InsertData(
                table: "Templates",
                columns: new[] { "Id", "ConfigurationSchema", "CreatedAt", "CreatedBy", "Description", "IsActive", "IsDeleted", "Name", "PreviewImageUrl", "SectionType", "SortOrder", "Status", "TemplateKey", "TemplateType", "UpdatedAt", "UpdatedBy" },
                values: new object[,]
                {
                    { 6, "{\"type\":\"object\",\"properties\":{\"autoPlay\":{\"type\":\"boolean\",\"default\":true},\"interval\":{\"type\":\"integer\",\"minimum\":2000,\"maximum\":10000,\"default\":5000},\"showIndicators\":{\"type\":\"boolean\",\"default\":true},\"showArrows\":{\"type\":\"boolean\",\"default\":true},\"transitionEffect\":{\"type\":\"string\",\"enum\":[\"fade\",\"slide\",\"zoom\"],\"default\":\"slide\"}}}", new DateTime(2024, 10, 14, 10, 0, 0, 0, DateTimeKind.Unspecified), null, "Hero section with rotating slides and multiple call-to-actions", true, false, "Hero Carousel", "/images/templates/hero-carousel.png", 3, 6, 0, "hero-carousel", 5, null, null },
                    { 7, "{\"type\":\"object\",\"properties\":{\"columns\":{\"type\":\"integer\",\"minimum\":1,\"maximum\":6,\"default\":3},\"gap\":{\"type\":\"string\",\"enum\":[\"small\",\"medium\",\"large\"],\"default\":\"medium\"},\"showImages\":{\"type\":\"boolean\",\"default\":true},\"showExcerpts\":{\"type\":\"boolean\",\"default\":true},\"itemsPerPage\":{\"type\":\"integer\",\"minimum\":6,\"maximum\":24,\"default\":12}}}", new DateTime(2024, 10, 14, 10, 0, 0, 0, DateTimeKind.Unspecified), null, "Content displayed in a responsive grid layout", true, false, "Grid Layout", "/images/templates/content-grid.png", 12, 7, 0, "content-grid", 3, null, null },
                    { 8, "{\"type\":\"object\",\"properties\":{\"columns\":{\"type\":\"integer\",\"minimum\":2,\"maximum\":5,\"default\":3},\"gap\":{\"type\":\"string\",\"enum\":[\"small\",\"medium\",\"large\"],\"default\":\"medium\"},\"showImages\":{\"type\":\"boolean\",\"default\":true},\"imageAspectRatio\":{\"type\":\"string\",\"enum\":[\"auto\",\"square\",\"landscape\",\"portrait\"],\"default\":\"auto\"}}}", new DateTime(2024, 10, 14, 10, 0, 0, 0, DateTimeKind.Unspecified), null, "Pinterest-style masonry layout for varied content sizes", true, false, "Masonry Layout", "/images/templates/content-masonry.png", 12, 8, 0, "content-masonry", 4, null, null },
                    { 9, "{\"type\":\"object\",\"properties\":{\"backgroundColor\":{\"type\":\"string\",\"default\":\"#2d3748\"},\"textColor\":{\"type\":\"string\",\"default\":\"#ffffff\"},\"columns\":{\"type\":\"integer\",\"minimum\":2,\"maximum\":5,\"default\":4},\"showSocialMedia\":{\"type\":\"boolean\",\"default\":true},\"showNewsletter\":{\"type\":\"boolean\",\"default\":true},\"showCopyright\":{\"type\":\"boolean\",\"default\":true}}}", new DateTime(2024, 10, 14, 10, 0, 0, 0, DateTimeKind.Unspecified), null, "Footer with multiple columns for links, contact info and social media", true, false, "Multi-Column Footer", "/images/templates/footer-multicolumn.png", 10, 9, 0, "footer-multicolumn", 8, null, null },
                    { 10, "{\"type\":\"object\",\"properties\":{\"backgroundColor\":{\"type\":\"string\",\"default\":\"#1a202c\"},\"textColor\":{\"type\":\"string\",\"default\":\"#ffffff\"},\"textAlign\":{\"type\":\"string\",\"enum\":[\"left\",\"center\",\"right\"],\"default\":\"center\"},\"showSocialMedia\":{\"type\":\"boolean\",\"default\":false},\"showCopyright\":{\"type\":\"boolean\",\"default\":true}}}", new DateTime(2024, 10, 14, 10, 0, 0, 0, DateTimeKind.Unspecified), null, "Minimal footer with essential links and copyright", true, false, "Simple Footer", "/images/templates/footer-simple.png", 10, 10, 0, "footer-simple", 7, null, null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_LayoutSection_LayoutId",
                table: "LayoutSection",
                column: "LayoutId");

            migrationBuilder.AddForeignKey(
                name: "FK_LayoutSection_Layout_LayoutId",
                table: "LayoutSection",
                column: "LayoutId",
                principalTable: "Layout",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_LayoutSection_Sections_SectionId",
                table: "LayoutSection",
                column: "SectionId",
                principalTable: "Sections",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Pages_Layout_LayoutId",
                table: "Pages",
                column: "LayoutId",
                principalTable: "Layout",
                principalColumn: "Id");
        }
    }
}
