using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PazarAtlasi.CMS.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class @in : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SectionItems_SectionItems_ParentItemId",
                table: "SectionItems");

            migrationBuilder.DropColumn(
                name: "Data",
                table: "SectionItems");

            migrationBuilder.DropColumn(
                name: "Icon",
                table: "SectionItems");

            migrationBuilder.DropColumn(
                name: "MediaAttributes",
                table: "SectionItems");

            migrationBuilder.DropColumn(
                name: "PictureUrl",
                table: "SectionItems");

            migrationBuilder.DropColumn(
                name: "RedirectUrl",
                table: "SectionItems");

            migrationBuilder.DropColumn(
                name: "VideoUrl",
                table: "SectionItems");

            migrationBuilder.RenameColumn(
                name: "ParentItemId",
                table: "SectionItems",
                newName: "ParentSectionItemId");

            migrationBuilder.RenameIndex(
                name: "IX_SectionItems_ParentItemId",
                table: "SectionItems",
                newName: "IX_SectionItems_ParentSectionItemId");

            migrationBuilder.CreateTable(
                name: "SectionItemFields",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SectionItemId = table.Column<int>(type: "int", nullable: false),
                    FieldType = table.Column<int>(type: "int", nullable: false),
                    FieldKey = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    FieldValue = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<int>(type: "int", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<int>(type: "int", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    Status = table.Column<int>(type: "int", nullable: false, defaultValue: 0)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SectionItemFields", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SectionItemFields_SectionItems_SectionItemId",
                        column: x => x.SectionItemId,
                        principalTable: "SectionItems",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SectionItemFieldTranslations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SectionItemFieldId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    LanguageId = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<int>(type: "int", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<int>(type: "int", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
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
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SectionItemFieldTranslations_SectionItemFields_SectionItemFieldId",
                        column: x => x.SectionItemFieldId,
                        principalTable: "SectionItemFields",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "SectionItems",
                keyColumn: "Id",
                keyValue: 1,
                column: "Type",
                value: 5);

            migrationBuilder.UpdateData(
                table: "SectionItems",
                keyColumn: "Id",
                keyValue: 2,
                column: "Type",
                value: 8);

            migrationBuilder.UpdateData(
                table: "SectionItems",
                keyColumn: "Id",
                keyValue: 3,
                column: "Type",
                value: 4);

            migrationBuilder.UpdateData(
                table: "SectionItems",
                keyColumn: "Id",
                keyValue: 7,
                column: "Type",
                value: 5);

            migrationBuilder.UpdateData(
                table: "SectionItems",
                keyColumn: "Id",
                keyValue: 8,
                column: "Type",
                value: 14);

            migrationBuilder.UpdateData(
                table: "SectionItems",
                keyColumn: "Id",
                keyValue: 9,
                column: "Type",
                value: 5);

            migrationBuilder.UpdateData(
                table: "SectionItems",
                keyColumn: "Id",
                keyValue: 10,
                column: "Type",
                value: 17);

            migrationBuilder.CreateIndex(
                name: "IX_SectionItemFields_SectionItemId",
                table: "SectionItemFields",
                column: "SectionItemId");

            migrationBuilder.CreateIndex(
                name: "IX_SectionItemFieldTranslations_LanguageId",
                table: "SectionItemFieldTranslations",
                column: "LanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_SectionItemFieldTranslations_SectionItemFieldId",
                table: "SectionItemFieldTranslations",
                column: "SectionItemFieldId");

            migrationBuilder.AddForeignKey(
                name: "FK_SectionItems_SectionItems_ParentSectionItemId",
                table: "SectionItems",
                column: "ParentSectionItemId",
                principalTable: "SectionItems",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SectionItems_SectionItems_ParentSectionItemId",
                table: "SectionItems");

            migrationBuilder.DropTable(
                name: "SectionItemFieldTranslations");

            migrationBuilder.DropTable(
                name: "SectionItemFields");

            migrationBuilder.RenameColumn(
                name: "ParentSectionItemId",
                table: "SectionItems",
                newName: "ParentItemId");

            migrationBuilder.RenameIndex(
                name: "IX_SectionItems_ParentSectionItemId",
                table: "SectionItems",
                newName: "IX_SectionItems_ParentItemId");

            migrationBuilder.AddColumn<string>(
                name: "Data",
                table: "SectionItems",
                type: "nvarchar(max)",
                nullable: true,
                defaultValue: "{}");

            migrationBuilder.AddColumn<string>(
                name: "Icon",
                table: "SectionItems",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MediaAttributes",
                table: "SectionItems",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PictureUrl",
                table: "SectionItems",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "RedirectUrl",
                table: "SectionItems",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "VideoUrl",
                table: "SectionItems",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: true);

            migrationBuilder.UpdateData(
                table: "SectionItems",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Data", "Icon", "MediaAttributes", "PictureUrl", "RedirectUrl", "Type", "VideoUrl" },
                values: new object[] { "{}", null, null, null, null, 1, null });

            migrationBuilder.UpdateData(
                table: "SectionItems",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Data", "Icon", "MediaAttributes", "PictureUrl", "RedirectUrl", "Type", "VideoUrl" },
                values: new object[] { "{}", null, null, null, null, 3, null });

            migrationBuilder.UpdateData(
                table: "SectionItems",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Data", "Icon", "MediaAttributes", "PictureUrl", "RedirectUrl", "Type", "VideoUrl" },
                values: new object[] { "{}", null, null, null, "/products", 5, null });

            migrationBuilder.UpdateData(
                table: "SectionItems",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Data", "Icon", "MediaAttributes", "PictureUrl", "RedirectUrl", "VideoUrl" },
                values: new object[] { "{}", null, null, "/images/products/product1.jpg", "/products/1", null });

            migrationBuilder.UpdateData(
                table: "SectionItems",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Data", "Icon", "MediaAttributes", "PictureUrl", "RedirectUrl", "VideoUrl" },
                values: new object[] { "{}", null, null, "/images/products/product2.jpg", "/products/2", null });

            migrationBuilder.UpdateData(
                table: "SectionItems",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "Data", "Icon", "MediaAttributes", "PictureUrl", "RedirectUrl", "VideoUrl" },
                values: new object[] { "{}", null, null, "/images/products/product3.jpg", "/products/3", null });

            migrationBuilder.UpdateData(
                table: "SectionItems",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "Data", "Icon", "MediaAttributes", "PictureUrl", "RedirectUrl", "Type", "VideoUrl" },
                values: new object[] { "{}", null, null, null, null, 1, null });

            migrationBuilder.UpdateData(
                table: "SectionItems",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "Data", "Icon", "MediaAttributes", "PictureUrl", "RedirectUrl", "Type", "VideoUrl" },
                values: new object[] { "{}", null, null, null, null, 13, null });

            migrationBuilder.UpdateData(
                table: "SectionItems",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "Data", "Icon", "MediaAttributes", "PictureUrl", "RedirectUrl", "Type", "VideoUrl" },
                values: new object[] { "{}", null, null, null, null, 1, null });

            migrationBuilder.UpdateData(
                table: "SectionItems",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "Data", "Icon", "MediaAttributes", "PictureUrl", "RedirectUrl", "Type", "VideoUrl" },
                values: new object[] { "{}", null, null, null, null, 18, null });

            migrationBuilder.AddForeignKey(
                name: "FK_SectionItems_SectionItems_ParentItemId",
                table: "SectionItems",
                column: "ParentItemId",
                principalTable: "SectionItems",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
