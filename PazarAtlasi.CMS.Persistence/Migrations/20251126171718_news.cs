using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace PazarAtlasi.CMS.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class news : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ArticleCategories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ParentCategoryId = table.Column<int>(type: "int", nullable: true),
                    Icon = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    Color = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    SortOrder = table.Column<int>(type: "int", nullable: false, defaultValue: 0),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<int>(type: "int", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<int>(type: "int", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    Status = table.Column<int>(type: "int", nullable: false, defaultValue: 1)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ArticleCategories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ArticleCategories_ArticleCategories_ParentCategoryId",
                        column: x => x.ParentCategoryId,
                        principalTable: "ArticleCategories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ArticleCategoryTranslations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ArticleCategoryId = table.Column<int>(type: "int", nullable: false),
                    LanguageId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Slug = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<int>(type: "int", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<int>(type: "int", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ArticleCategoryTranslations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ArticleCategoryTranslations_ArticleCategories_ArticleCategoryId",
                        column: x => x.ArticleCategoryId,
                        principalTable: "ArticleCategories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ArticleCategoryTranslations_Languages_LanguageId",
                        column: x => x.LanguageId,
                        principalTable: "Languages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Articles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryId = table.Column<int>(type: "int", nullable: true),
                    AuthorId = table.Column<int>(type: "int", nullable: true),
                    FeaturedImage = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    VideoUrl = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    PublishedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ViewCount = table.Column<int>(type: "int", nullable: false, defaultValue: 0),
                    LikeCount = table.Column<int>(type: "int", nullable: false, defaultValue: 0),
                    IsFeatured = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    IsTrending = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    ReadingTime = table.Column<int>(type: "int", nullable: true),
                    Tags = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MetaDescription = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    MetaKeywords = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    SortOrder = table.Column<int>(type: "int", nullable: false, defaultValue: 0),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<int>(type: "int", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<int>(type: "int", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    Status = table.Column<int>(type: "int", nullable: false, defaultValue: 0)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Articles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Articles_ArticleCategories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "ArticleCategories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "ArticleTranslations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ArticleId = table.Column<int>(type: "int", nullable: false),
                    LanguageId = table.Column<int>(type: "int", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Slug = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Summary = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MetaTitle = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<int>(type: "int", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<int>(type: "int", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ArticleTranslations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ArticleTranslations_Articles_ArticleId",
                        column: x => x.ArticleId,
                        principalTable: "Articles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ArticleTranslations_Languages_LanguageId",
                        column: x => x.LanguageId,
                        principalTable: "Languages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "ArticleCategories",
                columns: new[] { "Id", "Color", "CreatedAt", "CreatedBy", "Icon", "ParentCategoryId", "SortOrder", "Status", "UpdatedAt", "UpdatedBy" },
                values: new object[,]
                {
                    { 1, "#3b82f6", new DateTime(2025, 11, 26, 17, 17, 13, 406, DateTimeKind.Utc).AddTicks(4675), null, "fas fa-newspaper", null, 1, 1, null, null },
                    { 2, "#f59e0b", new DateTime(2025, 11, 26, 17, 17, 13, 406, DateTimeKind.Utc).AddTicks(4678), null, "fas fa-lightbulb", null, 2, 1, null, null },
                    { 3, "#8b5cf6", new DateTime(2025, 11, 26, 17, 17, 13, 406, DateTimeKind.Utc).AddTicks(4681), null, "fas fa-rocket", null, 3, 1, null, null }
                });

            migrationBuilder.UpdateData(
                table: "DataSchemaFields",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 26, 17, 17, 13, 434, DateTimeKind.Utc).AddTicks(753));

            migrationBuilder.UpdateData(
                table: "DataSchemaFields",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 26, 17, 17, 13, 434, DateTimeKind.Utc).AddTicks(758));

            migrationBuilder.UpdateData(
                table: "DataSchemaFields",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 26, 17, 17, 13, 434, DateTimeKind.Utc).AddTicks(762));

            migrationBuilder.UpdateData(
                table: "DataSchemaFields",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 26, 17, 17, 13, 434, DateTimeKind.Utc).AddTicks(765));

            migrationBuilder.UpdateData(
                table: "DataSchemaFields",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 26, 17, 17, 13, 434, DateTimeKind.Utc).AddTicks(768));

            migrationBuilder.UpdateData(
                table: "DataSchemaFields",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 26, 17, 17, 13, 434, DateTimeKind.Utc).AddTicks(771));

            migrationBuilder.UpdateData(
                table: "DataSchemas",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 26, 17, 17, 13, 432, DateTimeKind.Utc).AddTicks(4396));

            migrationBuilder.UpdateData(
                table: "DataSchemas",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 26, 17, 17, 13, 432, DateTimeKind.Utc).AddTicks(4399));

            migrationBuilder.UpdateData(
                table: "DataSchemas",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 26, 17, 17, 13, 432, DateTimeKind.Utc).AddTicks(4402));

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 26, 17, 17, 13, 427, DateTimeKind.Utc).AddTicks(1868));

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 26, 17, 17, 13, 427, DateTimeKind.Utc).AddTicks(1872));

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 26, 17, 17, 13, 427, DateTimeKind.Utc).AddTicks(1875));

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 26, 17, 17, 13, 427, DateTimeKind.Utc).AddTicks(1884));

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 26, 17, 17, 13, 427, DateTimeKind.Utc).AddTicks(1886));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 26, 17, 17, 13, 427, DateTimeKind.Utc).AddTicks(9517));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 26, 17, 17, 13, 427, DateTimeKind.Utc).AddTicks(9522));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 26, 17, 17, 13, 427, DateTimeKind.Utc).AddTicks(9524));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 26, 17, 17, 13, 427, DateTimeKind.Utc).AddTicks(9525));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 26, 17, 17, 13, 427, DateTimeKind.Utc).AddTicks(9525));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 26, 17, 17, 13, 427, DateTimeKind.Utc).AddTicks(9528));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 26, 17, 17, 13, 427, DateTimeKind.Utc).AddTicks(9529));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 26, 17, 17, 13, 427, DateTimeKind.Utc).AddTicks(9529));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 26, 17, 17, 13, 427, DateTimeKind.Utc).AddTicks(9530));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 26, 17, 17, 13, 427, DateTimeKind.Utc).AddTicks(9532));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 26, 17, 17, 13, 427, DateTimeKind.Utc).AddTicks(9533));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 26, 17, 17, 13, 427, DateTimeKind.Utc).AddTicks(9533));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 26, 17, 17, 13, 427, DateTimeKind.Utc).AddTicks(9534));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 26, 17, 17, 13, 427, DateTimeKind.Utc).AddTicks(9535));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 26, 17, 17, 13, 427, DateTimeKind.Utc).AddTicks(9536));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 16,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 26, 17, 17, 13, 427, DateTimeKind.Utc).AddTicks(9537));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 17,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 26, 17, 17, 13, 427, DateTimeKind.Utc).AddTicks(9538));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 18,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 26, 17, 17, 13, 427, DateTimeKind.Utc).AddTicks(9540));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 19,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 26, 17, 17, 13, 427, DateTimeKind.Utc).AddTicks(9540));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 20,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 26, 17, 17, 13, 427, DateTimeKind.Utc).AddTicks(9541));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 21,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 26, 17, 17, 13, 427, DateTimeKind.Utc).AddTicks(9542));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 22,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 26, 17, 17, 13, 427, DateTimeKind.Utc).AddTicks(9543));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 23,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 26, 17, 17, 13, 427, DateTimeKind.Utc).AddTicks(9544));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 24,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 26, 17, 17, 13, 427, DateTimeKind.Utc).AddTicks(9545));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 25,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 26, 17, 17, 13, 427, DateTimeKind.Utc).AddTicks(9546));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 26,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 26, 17, 17, 13, 427, DateTimeKind.Utc).AddTicks(9547));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 27,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 26, 17, 17, 13, 427, DateTimeKind.Utc).AddTicks(9548));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 28,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 26, 17, 17, 13, 427, DateTimeKind.Utc).AddTicks(9549));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 29,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 26, 17, 17, 13, 427, DateTimeKind.Utc).AddTicks(9549));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 30,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 26, 17, 17, 13, 427, DateTimeKind.Utc).AddTicks(9567));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 31,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 26, 17, 17, 13, 427, DateTimeKind.Utc).AddTicks(9568));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 32,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 26, 17, 17, 13, 427, DateTimeKind.Utc).AddTicks(9569));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 33,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 26, 17, 17, 13, 427, DateTimeKind.Utc).AddTicks(9570));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 34,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 26, 17, 17, 13, 427, DateTimeKind.Utc).AddTicks(9580));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 35,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 26, 17, 17, 13, 427, DateTimeKind.Utc).AddTicks(9581));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 36,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 26, 17, 17, 13, 427, DateTimeKind.Utc).AddTicks(9582));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 37,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 26, 17, 17, 13, 427, DateTimeKind.Utc).AddTicks(9583));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 38,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 26, 17, 17, 13, 427, DateTimeKind.Utc).AddTicks(9584));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 39,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 26, 17, 17, 13, 427, DateTimeKind.Utc).AddTicks(9590));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 40,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 26, 17, 17, 13, 427, DateTimeKind.Utc).AddTicks(9592));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 41,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 26, 17, 17, 13, 427, DateTimeKind.Utc).AddTicks(9593));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 42,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 26, 17, 17, 13, 427, DateTimeKind.Utc).AddTicks(9593));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 43,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 26, 17, 17, 13, 427, DateTimeKind.Utc).AddTicks(9594));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 44,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 26, 17, 17, 13, 427, DateTimeKind.Utc).AddTicks(9595));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 45,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 26, 17, 17, 13, 427, DateTimeKind.Utc).AddTicks(9596));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 46,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 26, 17, 17, 13, 427, DateTimeKind.Utc).AddTicks(9597));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 47,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 26, 17, 17, 13, 427, DateTimeKind.Utc).AddTicks(9598));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 48,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 26, 17, 17, 13, 427, DateTimeKind.Utc).AddTicks(9598));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 49,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 26, 17, 17, 13, 427, DateTimeKind.Utc).AddTicks(9599));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 50,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 26, 17, 17, 13, 427, DateTimeKind.Utc).AddTicks(9601));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 51,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 26, 17, 17, 13, 427, DateTimeKind.Utc).AddTicks(9601));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 52,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 26, 17, 17, 13, 427, DateTimeKind.Utc).AddTicks(9602));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 53,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 26, 17, 17, 13, 427, DateTimeKind.Utc).AddTicks(9603));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 54,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 26, 17, 17, 13, 427, DateTimeKind.Utc).AddTicks(9605));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 55,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 26, 17, 17, 13, 427, DateTimeKind.Utc).AddTicks(9607));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 56,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 26, 17, 17, 13, 427, DateTimeKind.Utc).AddTicks(9607));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 57,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 26, 17, 17, 13, 427, DateTimeKind.Utc).AddTicks(9608));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 58,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 26, 17, 17, 13, 427, DateTimeKind.Utc).AddTicks(9609));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 59,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 26, 17, 17, 13, 427, DateTimeKind.Utc).AddTicks(9610));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 60,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 26, 17, 17, 13, 427, DateTimeKind.Utc).AddTicks(9610));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 61,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 26, 17, 17, 13, 427, DateTimeKind.Utc).AddTicks(9611));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 62,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 26, 17, 17, 13, 427, DateTimeKind.Utc).AddTicks(9612));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 63,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 26, 17, 17, 13, 427, DateTimeKind.Utc).AddTicks(9613));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 64,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 26, 17, 17, 13, 427, DateTimeKind.Utc).AddTicks(9614));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 65,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 26, 17, 17, 13, 427, DateTimeKind.Utc).AddTicks(9615));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 66,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 26, 17, 17, 13, 427, DateTimeKind.Utc).AddTicks(9623));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 67,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 26, 17, 17, 13, 427, DateTimeKind.Utc).AddTicks(9624));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 68,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 26, 17, 17, 13, 427, DateTimeKind.Utc).AddTicks(9625));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 69,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 26, 17, 17, 13, 427, DateTimeKind.Utc).AddTicks(9626));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 70,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 26, 17, 17, 13, 427, DateTimeKind.Utc).AddTicks(9628));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 71,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 26, 17, 17, 13, 427, DateTimeKind.Utc).AddTicks(9630));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 72,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 26, 17, 17, 13, 427, DateTimeKind.Utc).AddTicks(9630));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 73,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 26, 17, 17, 13, 427, DateTimeKind.Utc).AddTicks(9631));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 74,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 26, 17, 17, 13, 427, DateTimeKind.Utc).AddTicks(9632));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 75,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 26, 17, 17, 13, 427, DateTimeKind.Utc).AddTicks(9633));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 76,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 26, 17, 17, 13, 427, DateTimeKind.Utc).AddTicks(9634));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 77,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 26, 17, 17, 13, 427, DateTimeKind.Utc).AddTicks(9635));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 78,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 26, 17, 17, 13, 427, DateTimeKind.Utc).AddTicks(9636));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 79,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 26, 17, 17, 13, 427, DateTimeKind.Utc).AddTicks(9637));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 80,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 26, 17, 17, 13, 427, DateTimeKind.Utc).AddTicks(9639));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 81,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 26, 17, 17, 13, 427, DateTimeKind.Utc).AddTicks(9641));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 82,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 26, 17, 17, 13, 427, DateTimeKind.Utc).AddTicks(9641));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 83,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 26, 17, 17, 13, 427, DateTimeKind.Utc).AddTicks(9642));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 84,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 26, 17, 17, 13, 427, DateTimeKind.Utc).AddTicks(9643));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 85,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 26, 17, 17, 13, 427, DateTimeKind.Utc).AddTicks(9644));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 86,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 26, 17, 17, 13, 427, DateTimeKind.Utc).AddTicks(9645));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 87,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 26, 17, 17, 13, 427, DateTimeKind.Utc).AddTicks(9646));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 88,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 26, 17, 17, 13, 427, DateTimeKind.Utc).AddTicks(9647));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 89,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 26, 17, 17, 13, 427, DateTimeKind.Utc).AddTicks(9648));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 90,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 26, 17, 17, 13, 427, DateTimeKind.Utc).AddTicks(9648));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 91,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 26, 17, 17, 13, 427, DateTimeKind.Utc).AddTicks(9649));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 92,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 26, 17, 17, 13, 427, DateTimeKind.Utc).AddTicks(9650));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 93,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 26, 17, 17, 13, 427, DateTimeKind.Utc).AddTicks(9651));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 94,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 26, 17, 17, 13, 427, DateTimeKind.Utc).AddTicks(9652));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 95,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 26, 17, 17, 13, 427, DateTimeKind.Utc).AddTicks(9653));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 96,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 26, 17, 17, 13, 427, DateTimeKind.Utc).AddTicks(9654));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 97,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 26, 17, 17, 13, 427, DateTimeKind.Utc).AddTicks(9654));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 98,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 26, 17, 17, 13, 427, DateTimeKind.Utc).AddTicks(9655));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 99,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 26, 17, 17, 13, 427, DateTimeKind.Utc).AddTicks(9656));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 100,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 26, 17, 17, 13, 427, DateTimeKind.Utc).AddTicks(9657));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 101,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 26, 17, 17, 13, 427, DateTimeKind.Utc).AddTicks(9658));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 102,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 26, 17, 17, 13, 427, DateTimeKind.Utc).AddTicks(9664));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 103,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 26, 17, 17, 13, 427, DateTimeKind.Utc).AddTicks(9665));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 104,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 26, 17, 17, 13, 427, DateTimeKind.Utc).AddTicks(9666));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 105,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 26, 17, 17, 13, 427, DateTimeKind.Utc).AddTicks(9667));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 106,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 26, 17, 17, 13, 427, DateTimeKind.Utc).AddTicks(9667));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 107,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 26, 17, 17, 13, 427, DateTimeKind.Utc).AddTicks(9668));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 108,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 26, 17, 17, 13, 427, DateTimeKind.Utc).AddTicks(9669));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 109,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 26, 17, 17, 13, 427, DateTimeKind.Utc).AddTicks(9672));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 110,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 26, 17, 17, 13, 427, DateTimeKind.Utc).AddTicks(9673));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 111,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 26, 17, 17, 13, 427, DateTimeKind.Utc).AddTicks(9676));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 112,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 26, 17, 17, 13, 427, DateTimeKind.Utc).AddTicks(9677));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 113,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 26, 17, 17, 13, 427, DateTimeKind.Utc).AddTicks(9678));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 114,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 26, 17, 17, 13, 427, DateTimeKind.Utc).AddTicks(9678));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 115,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 26, 17, 17, 13, 427, DateTimeKind.Utc).AddTicks(9679));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 116,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 26, 17, 17, 13, 427, DateTimeKind.Utc).AddTicks(9680));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 117,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 26, 17, 17, 13, 427, DateTimeKind.Utc).AddTicks(9681));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 118,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 26, 17, 17, 13, 427, DateTimeKind.Utc).AddTicks(9682));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 119,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 26, 17, 17, 13, 427, DateTimeKind.Utc).AddTicks(9683));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 120,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 26, 17, 17, 13, 427, DateTimeKind.Utc).AddTicks(9684));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 121,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 26, 17, 17, 13, 427, DateTimeKind.Utc).AddTicks(9685));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 122,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 26, 17, 17, 13, 427, DateTimeKind.Utc).AddTicks(9685));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 123,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 26, 17, 17, 13, 427, DateTimeKind.Utc).AddTicks(9686));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 124,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 26, 17, 17, 13, 427, DateTimeKind.Utc).AddTicks(9687));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 125,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 26, 17, 17, 13, 427, DateTimeKind.Utc).AddTicks(9688));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 126,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 26, 17, 17, 13, 427, DateTimeKind.Utc).AddTicks(9689));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 127,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 26, 17, 17, 13, 427, DateTimeKind.Utc).AddTicks(9690));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 128,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 26, 17, 17, 13, 427, DateTimeKind.Utc).AddTicks(9691));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 129,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 26, 17, 17, 13, 427, DateTimeKind.Utc).AddTicks(9691));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 130,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 26, 17, 17, 13, 427, DateTimeKind.Utc).AddTicks(9702));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 131,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 26, 17, 17, 13, 427, DateTimeKind.Utc).AddTicks(9703));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 132,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 26, 17, 17, 13, 427, DateTimeKind.Utc).AddTicks(9704));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 133,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 26, 17, 17, 13, 427, DateTimeKind.Utc).AddTicks(9705));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 134,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 26, 17, 17, 13, 427, DateTimeKind.Utc).AddTicks(9706));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 135,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 26, 17, 17, 13, 427, DateTimeKind.Utc).AddTicks(9707));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 136,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 26, 17, 17, 13, 427, DateTimeKind.Utc).AddTicks(9708));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 137,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 26, 17, 17, 13, 427, DateTimeKind.Utc).AddTicks(9709));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 138,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 26, 17, 17, 13, 427, DateTimeKind.Utc).AddTicks(9710));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 139,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 26, 17, 17, 13, 427, DateTimeKind.Utc).AddTicks(9712));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 140,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 26, 17, 17, 13, 427, DateTimeKind.Utc).AddTicks(9713));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 141,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 26, 17, 17, 13, 427, DateTimeKind.Utc).AddTicks(9714));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 142,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 26, 17, 17, 13, 427, DateTimeKind.Utc).AddTicks(9715));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 143,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 26, 17, 17, 13, 427, DateTimeKind.Utc).AddTicks(9716));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 144,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 26, 17, 17, 13, 427, DateTimeKind.Utc).AddTicks(9717));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 145,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 26, 17, 17, 13, 427, DateTimeKind.Utc).AddTicks(9717));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 146,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 26, 17, 17, 13, 427, DateTimeKind.Utc).AddTicks(9718));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 147,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 26, 17, 17, 13, 427, DateTimeKind.Utc).AddTicks(9719));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 148,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 26, 17, 17, 13, 427, DateTimeKind.Utc).AddTicks(9720));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 149,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 26, 17, 17, 13, 427, DateTimeKind.Utc).AddTicks(9721));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 150,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 26, 17, 17, 13, 427, DateTimeKind.Utc).AddTicks(9722));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 151,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 26, 17, 17, 13, 427, DateTimeKind.Utc).AddTicks(9723));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 152,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 26, 17, 17, 13, 427, DateTimeKind.Utc).AddTicks(9724));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 153,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 26, 17, 17, 13, 427, DateTimeKind.Utc).AddTicks(9725));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 154,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 26, 17, 17, 13, 427, DateTimeKind.Utc).AddTicks(9726));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 155,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 26, 17, 17, 13, 427, DateTimeKind.Utc).AddTicks(9727));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 156,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 26, 17, 17, 13, 427, DateTimeKind.Utc).AddTicks(9728));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 157,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 26, 17, 17, 13, 427, DateTimeKind.Utc).AddTicks(9728));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 158,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 26, 17, 17, 13, 427, DateTimeKind.Utc).AddTicks(9729));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 159,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 26, 17, 17, 13, 427, DateTimeKind.Utc).AddTicks(9730));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 160,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 26, 17, 17, 13, 427, DateTimeKind.Utc).AddTicks(9731));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 161,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 26, 17, 17, 13, 427, DateTimeKind.Utc).AddTicks(9732));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 162,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 26, 17, 17, 13, 427, DateTimeKind.Utc).AddTicks(9737));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 163,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 26, 17, 17, 13, 427, DateTimeKind.Utc).AddTicks(9738));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 164,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 26, 17, 17, 13, 427, DateTimeKind.Utc).AddTicks(9741));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 165,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 26, 17, 17, 13, 427, DateTimeKind.Utc).AddTicks(9742));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 166,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 26, 17, 17, 13, 427, DateTimeKind.Utc).AddTicks(9743));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 167,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 26, 17, 17, 13, 427, DateTimeKind.Utc).AddTicks(9744));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 168,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 26, 17, 17, 13, 427, DateTimeKind.Utc).AddTicks(9744));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 169,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 26, 17, 17, 13, 427, DateTimeKind.Utc).AddTicks(9745));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 170,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 26, 17, 17, 13, 427, DateTimeKind.Utc).AddTicks(9746));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 171,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 26, 17, 17, 13, 427, DateTimeKind.Utc).AddTicks(9747));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 172,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 26, 17, 17, 13, 427, DateTimeKind.Utc).AddTicks(9748));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 173,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 26, 17, 17, 13, 427, DateTimeKind.Utc).AddTicks(9748));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 174,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 26, 17, 17, 13, 427, DateTimeKind.Utc).AddTicks(9749));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 175,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 26, 17, 17, 13, 427, DateTimeKind.Utc).AddTicks(9750));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 176,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 26, 17, 17, 13, 427, DateTimeKind.Utc).AddTicks(9751));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 177,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 26, 17, 17, 13, 427, DateTimeKind.Utc).AddTicks(9752));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 178,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 26, 17, 17, 13, 427, DateTimeKind.Utc).AddTicks(9753));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 179,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 26, 17, 17, 13, 427, DateTimeKind.Utc).AddTicks(9753));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 180,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 26, 17, 17, 13, 427, DateTimeKind.Utc).AddTicks(9754));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 181,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 26, 17, 17, 13, 427, DateTimeKind.Utc).AddTicks(9755));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 182,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 26, 17, 17, 13, 427, DateTimeKind.Utc).AddTicks(9756));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 183,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 26, 17, 17, 13, 427, DateTimeKind.Utc).AddTicks(9757));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 184,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 26, 17, 17, 13, 427, DateTimeKind.Utc).AddTicks(9758));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 185,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 26, 17, 17, 13, 427, DateTimeKind.Utc).AddTicks(9758));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 186,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 26, 17, 17, 13, 427, DateTimeKind.Utc).AddTicks(9759));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 187,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 26, 17, 17, 13, 427, DateTimeKind.Utc).AddTicks(9760));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 188,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 26, 17, 17, 13, 427, DateTimeKind.Utc).AddTicks(9761));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 189,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 26, 17, 17, 13, 427, DateTimeKind.Utc).AddTicks(9762));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 190,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 26, 17, 17, 13, 427, DateTimeKind.Utc).AddTicks(9763));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 191,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 26, 17, 17, 13, 427, DateTimeKind.Utc).AddTicks(9763));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 192,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 26, 17, 17, 13, 427, DateTimeKind.Utc).AddTicks(9764));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 193,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 26, 17, 17, 13, 427, DateTimeKind.Utc).AddTicks(9765));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 194,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 26, 17, 17, 13, 427, DateTimeKind.Utc).AddTicks(9766));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 195,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 26, 17, 17, 13, 427, DateTimeKind.Utc).AddTicks(9767));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 196,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 26, 17, 17, 13, 427, DateTimeKind.Utc).AddTicks(9768));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 197,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 26, 17, 17, 13, 427, DateTimeKind.Utc).AddTicks(9768));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 198,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 26, 17, 17, 13, 427, DateTimeKind.Utc).AddTicks(9769));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 199,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 26, 17, 17, 13, 427, DateTimeKind.Utc).AddTicks(9770));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 200,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 26, 17, 17, 13, 427, DateTimeKind.Utc).AddTicks(9776));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 201,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 26, 17, 17, 13, 427, DateTimeKind.Utc).AddTicks(9777));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 202,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 26, 17, 17, 13, 427, DateTimeKind.Utc).AddTicks(9779));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 203,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 26, 17, 17, 13, 427, DateTimeKind.Utc).AddTicks(9780));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 204,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 26, 17, 17, 13, 427, DateTimeKind.Utc).AddTicks(9781));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 205,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 26, 17, 17, 13, 427, DateTimeKind.Utc).AddTicks(9782));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 206,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 26, 17, 17, 13, 427, DateTimeKind.Utc).AddTicks(9783));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 207,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 26, 17, 17, 13, 427, DateTimeKind.Utc).AddTicks(9784));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 208,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 26, 17, 17, 13, 427, DateTimeKind.Utc).AddTicks(9785));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 209,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 26, 17, 17, 13, 427, DateTimeKind.Utc).AddTicks(9786));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 210,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 26, 17, 17, 13, 427, DateTimeKind.Utc).AddTicks(9786));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 211,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 26, 17, 17, 13, 427, DateTimeKind.Utc).AddTicks(9787));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 212,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 26, 17, 17, 13, 427, DateTimeKind.Utc).AddTicks(9788));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 213,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 26, 17, 17, 13, 427, DateTimeKind.Utc).AddTicks(9789));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 214,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 26, 17, 17, 13, 427, DateTimeKind.Utc).AddTicks(9790));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 215,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 26, 17, 17, 13, 427, DateTimeKind.Utc).AddTicks(9791));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 216,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 26, 17, 17, 13, 427, DateTimeKind.Utc).AddTicks(9791));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 217,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 26, 17, 17, 13, 427, DateTimeKind.Utc).AddTicks(9794));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 218,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 26, 17, 17, 13, 427, DateTimeKind.Utc).AddTicks(9795));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 219,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 26, 17, 17, 13, 427, DateTimeKind.Utc).AddTicks(9796));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 220,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 26, 17, 17, 13, 427, DateTimeKind.Utc).AddTicks(9797));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 221,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 26, 17, 17, 13, 427, DateTimeKind.Utc).AddTicks(9798));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 222,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 26, 17, 17, 13, 427, DateTimeKind.Utc).AddTicks(9798));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 223,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 26, 17, 17, 13, 427, DateTimeKind.Utc).AddTicks(9799));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 224,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 26, 17, 17, 13, 427, DateTimeKind.Utc).AddTicks(9800));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 225,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 26, 17, 17, 13, 427, DateTimeKind.Utc).AddTicks(9801));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 226,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 26, 17, 17, 13, 427, DateTimeKind.Utc).AddTicks(9802));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 227,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 26, 17, 17, 13, 427, DateTimeKind.Utc).AddTicks(9803));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 228,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 26, 17, 17, 13, 427, DateTimeKind.Utc).AddTicks(9804));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 229,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 26, 17, 17, 13, 427, DateTimeKind.Utc).AddTicks(9805));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 230,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 26, 17, 17, 13, 427, DateTimeKind.Utc).AddTicks(9806));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 231,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 26, 17, 17, 13, 427, DateTimeKind.Utc).AddTicks(9806));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 232,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 26, 17, 17, 13, 427, DateTimeKind.Utc).AddTicks(9807));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 233,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 26, 17, 17, 13, 427, DateTimeKind.Utc).AddTicks(9810));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 234,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 26, 17, 17, 13, 427, DateTimeKind.Utc).AddTicks(9811));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 235,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 26, 17, 17, 13, 427, DateTimeKind.Utc).AddTicks(9812));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 236,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 26, 17, 17, 13, 427, DateTimeKind.Utc).AddTicks(9813));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 237,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 26, 17, 17, 13, 427, DateTimeKind.Utc).AddTicks(9819));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 238,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 26, 17, 17, 13, 427, DateTimeKind.Utc).AddTicks(9820));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 239,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 26, 17, 17, 13, 427, DateTimeKind.Utc).AddTicks(9821));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 240,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 26, 17, 17, 13, 427, DateTimeKind.Utc).AddTicks(9821));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 241,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 26, 17, 17, 13, 427, DateTimeKind.Utc).AddTicks(9822));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 242,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 26, 17, 17, 13, 427, DateTimeKind.Utc).AddTicks(9823));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 243,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 26, 17, 17, 13, 427, DateTimeKind.Utc).AddTicks(9826));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 244,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 26, 17, 17, 13, 427, DateTimeKind.Utc).AddTicks(9827));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 245,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 26, 17, 17, 13, 427, DateTimeKind.Utc).AddTicks(9828));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 246,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 26, 17, 17, 13, 427, DateTimeKind.Utc).AddTicks(9828));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 247,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 26, 17, 17, 13, 427, DateTimeKind.Utc).AddTicks(9829));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 248,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 26, 17, 17, 13, 427, DateTimeKind.Utc).AddTicks(9830));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 249,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 26, 17, 17, 13, 427, DateTimeKind.Utc).AddTicks(9831));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 250,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 26, 17, 17, 13, 427, DateTimeKind.Utc).AddTicks(9832));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 251,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 26, 17, 17, 13, 427, DateTimeKind.Utc).AddTicks(9833));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 252,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 26, 17, 17, 13, 427, DateTimeKind.Utc).AddTicks(9834));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 253,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 26, 17, 17, 13, 427, DateTimeKind.Utc).AddTicks(9834));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 254,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 26, 17, 17, 13, 427, DateTimeKind.Utc).AddTicks(9836));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 255,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 26, 17, 17, 13, 427, DateTimeKind.Utc).AddTicks(9837));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 256,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 26, 17, 17, 13, 427, DateTimeKind.Utc).AddTicks(9837));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 257,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 26, 17, 17, 13, 427, DateTimeKind.Utc).AddTicks(9838));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 258,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 26, 17, 17, 13, 427, DateTimeKind.Utc).AddTicks(9848));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 259,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 26, 17, 17, 13, 427, DateTimeKind.Utc).AddTicks(9849));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 260,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 26, 17, 17, 13, 427, DateTimeKind.Utc).AddTicks(9850));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 261,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 26, 17, 17, 13, 427, DateTimeKind.Utc).AddTicks(9851));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 262,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 26, 17, 17, 13, 427, DateTimeKind.Utc).AddTicks(9852));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 263,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 26, 17, 17, 13, 427, DateTimeKind.Utc).AddTicks(9853));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 264,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 26, 17, 17, 13, 427, DateTimeKind.Utc).AddTicks(9854));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 265,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 26, 17, 17, 13, 427, DateTimeKind.Utc).AddTicks(9855));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 266,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 26, 17, 17, 13, 427, DateTimeKind.Utc).AddTicks(9856));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 267,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 26, 17, 17, 13, 427, DateTimeKind.Utc).AddTicks(9856));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 268,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 26, 17, 17, 13, 427, DateTimeKind.Utc).AddTicks(9857));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 269,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 26, 17, 17, 13, 427, DateTimeKind.Utc).AddTicks(9858));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 270,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 26, 17, 17, 13, 427, DateTimeKind.Utc).AddTicks(9859));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 271,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 26, 17, 17, 13, 427, DateTimeKind.Utc).AddTicks(9860));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 272,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 26, 17, 17, 13, 427, DateTimeKind.Utc).AddTicks(9862));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 273,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 26, 17, 17, 13, 427, DateTimeKind.Utc).AddTicks(9864));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 274,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 26, 17, 17, 13, 427, DateTimeKind.Utc).AddTicks(9866));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 275,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 26, 17, 17, 13, 427, DateTimeKind.Utc).AddTicks(9867));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 276,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 26, 17, 17, 13, 427, DateTimeKind.Utc).AddTicks(9868));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 277,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 26, 17, 17, 13, 427, DateTimeKind.Utc).AddTicks(9869));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 278,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 26, 17, 17, 13, 427, DateTimeKind.Utc).AddTicks(9870));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 279,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 26, 17, 17, 13, 427, DateTimeKind.Utc).AddTicks(9870));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 280,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 26, 17, 17, 13, 427, DateTimeKind.Utc).AddTicks(9871));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 281,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 26, 17, 17, 13, 427, DateTimeKind.Utc).AddTicks(9872));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 282,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 26, 17, 17, 13, 427, DateTimeKind.Utc).AddTicks(9873));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 283,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 26, 17, 17, 13, 427, DateTimeKind.Utc).AddTicks(9874));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 284,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 26, 17, 17, 13, 427, DateTimeKind.Utc).AddTicks(9875));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 285,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 26, 17, 17, 13, 427, DateTimeKind.Utc).AddTicks(9876));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 286,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 26, 17, 17, 13, 427, DateTimeKind.Utc).AddTicks(9876));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 287,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 26, 17, 17, 13, 427, DateTimeKind.Utc).AddTicks(9877));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 288,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 26, 17, 17, 13, 427, DateTimeKind.Utc).AddTicks(9878));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 289,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 26, 17, 17, 13, 427, DateTimeKind.Utc).AddTicks(9879));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 290,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 26, 17, 17, 13, 427, DateTimeKind.Utc).AddTicks(9886));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 291,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 26, 17, 17, 13, 427, DateTimeKind.Utc).AddTicks(9887));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 292,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 26, 17, 17, 13, 427, DateTimeKind.Utc).AddTicks(9887));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 293,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 26, 17, 17, 13, 427, DateTimeKind.Utc).AddTicks(9888));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 294,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 26, 17, 17, 13, 427, DateTimeKind.Utc).AddTicks(9889));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 295,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 26, 17, 17, 13, 427, DateTimeKind.Utc).AddTicks(9890));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 296,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 26, 17, 17, 13, 427, DateTimeKind.Utc).AddTicks(9891));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 297,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 26, 17, 17, 13, 427, DateTimeKind.Utc).AddTicks(9892));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 298,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 26, 17, 17, 13, 427, DateTimeKind.Utc).AddTicks(9893));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 299,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 26, 17, 17, 13, 427, DateTimeKind.Utc).AddTicks(9893));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 300,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 26, 17, 17, 13, 427, DateTimeKind.Utc).AddTicks(9894));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 301,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 26, 17, 17, 13, 427, DateTimeKind.Utc).AddTicks(9895));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 302,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 26, 17, 17, 13, 427, DateTimeKind.Utc).AddTicks(9898));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 303,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 26, 17, 17, 13, 427, DateTimeKind.Utc).AddTicks(9899));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 304,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 26, 17, 17, 13, 427, DateTimeKind.Utc).AddTicks(9900));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 305,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 26, 17, 17, 13, 427, DateTimeKind.Utc).AddTicks(9901));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 306,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 26, 17, 17, 13, 427, DateTimeKind.Utc).AddTicks(9902));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 307,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 26, 17, 17, 13, 427, DateTimeKind.Utc).AddTicks(9902));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 308,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 26, 17, 17, 13, 427, DateTimeKind.Utc).AddTicks(9903));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 309,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 26, 17, 17, 13, 427, DateTimeKind.Utc).AddTicks(9904));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 310,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 26, 17, 17, 13, 427, DateTimeKind.Utc).AddTicks(9905));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 311,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 26, 17, 17, 13, 427, DateTimeKind.Utc).AddTicks(9906));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 312,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 26, 17, 17, 13, 427, DateTimeKind.Utc).AddTicks(9906));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 313,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 26, 17, 17, 13, 427, DateTimeKind.Utc).AddTicks(9907));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 314,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 26, 17, 17, 13, 427, DateTimeKind.Utc).AddTicks(9908));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 315,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 26, 17, 17, 13, 427, DateTimeKind.Utc).AddTicks(9909));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 316,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 26, 17, 17, 13, 427, DateTimeKind.Utc).AddTicks(9910));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 317,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 26, 17, 17, 13, 427, DateTimeKind.Utc).AddTicks(9911));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 318,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 26, 17, 17, 13, 427, DateTimeKind.Utc).AddTicks(9912));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 319,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 26, 17, 17, 13, 427, DateTimeKind.Utc).AddTicks(9912));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 320,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 26, 17, 17, 13, 427, DateTimeKind.Utc).AddTicks(9913));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 321,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 26, 17, 17, 13, 427, DateTimeKind.Utc).AddTicks(9914));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 322,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 26, 17, 17, 13, 427, DateTimeKind.Utc).AddTicks(9915));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 323,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 26, 17, 17, 13, 427, DateTimeKind.Utc).AddTicks(9916));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 324,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 26, 17, 17, 13, 427, DateTimeKind.Utc).AddTicks(9922));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 325,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 26, 17, 17, 13, 427, DateTimeKind.Utc).AddTicks(9923));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 326,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 26, 17, 17, 13, 427, DateTimeKind.Utc).AddTicks(9924));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 327,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 26, 17, 17, 13, 427, DateTimeKind.Utc).AddTicks(9963));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 328,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 26, 17, 17, 13, 427, DateTimeKind.Utc).AddTicks(9964));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 329,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 26, 17, 17, 13, 427, DateTimeKind.Utc).AddTicks(9965));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 330,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 26, 17, 17, 13, 427, DateTimeKind.Utc).AddTicks(9966));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 331,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 26, 17, 17, 13, 427, DateTimeKind.Utc).AddTicks(9967));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 332,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 26, 17, 17, 13, 427, DateTimeKind.Utc).AddTicks(9968));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 333,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 26, 17, 17, 13, 427, DateTimeKind.Utc).AddTicks(9968));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 334,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 26, 17, 17, 13, 427, DateTimeKind.Utc).AddTicks(9969));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 335,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 26, 17, 17, 13, 427, DateTimeKind.Utc).AddTicks(9970));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 336,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 26, 17, 17, 13, 427, DateTimeKind.Utc).AddTicks(9971));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 337,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 26, 17, 17, 13, 427, DateTimeKind.Utc).AddTicks(9972));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 338,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 26, 17, 17, 13, 427, DateTimeKind.Utc).AddTicks(9972));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 339,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 26, 17, 17, 13, 427, DateTimeKind.Utc).AddTicks(9973));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 340,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 26, 17, 17, 13, 427, DateTimeKind.Utc).AddTicks(9974));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 341,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 26, 17, 17, 13, 427, DateTimeKind.Utc).AddTicks(9984));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 342,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 26, 17, 17, 13, 427, DateTimeKind.Utc).AddTicks(9985));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 343,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 26, 17, 17, 13, 427, DateTimeKind.Utc).AddTicks(9986));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 344,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 26, 17, 17, 13, 427, DateTimeKind.Utc).AddTicks(9987));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 345,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 26, 17, 17, 13, 427, DateTimeKind.Utc).AddTicks(9988));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 346,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 26, 17, 17, 13, 427, DateTimeKind.Utc).AddTicks(9989));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 347,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 26, 17, 17, 13, 427, DateTimeKind.Utc).AddTicks(9989));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 348,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 26, 17, 17, 13, 427, DateTimeKind.Utc).AddTicks(9990));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 349,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 26, 17, 17, 13, 427, DateTimeKind.Utc).AddTicks(9991));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 350,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 26, 17, 17, 13, 427, DateTimeKind.Utc).AddTicks(9992));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 351,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 26, 17, 17, 13, 427, DateTimeKind.Utc).AddTicks(9993));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 352,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 26, 17, 17, 13, 427, DateTimeKind.Utc).AddTicks(9994));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 353,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 26, 17, 17, 13, 427, DateTimeKind.Utc).AddTicks(9995));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 354,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 26, 17, 17, 13, 427, DateTimeKind.Utc).AddTicks(9996));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 355,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 26, 17, 17, 13, 427, DateTimeKind.Utc).AddTicks(9996));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 356,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 26, 17, 17, 13, 427, DateTimeKind.Utc).AddTicks(9997));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 357,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 26, 17, 17, 13, 427, DateTimeKind.Utc).AddTicks(9998));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 358,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 26, 17, 17, 13, 427, DateTimeKind.Utc).AddTicks(9999));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 359,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 26, 17, 17, 13, 428, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 360,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 26, 17, 17, 13, 428, DateTimeKind.Utc).AddTicks(1));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 361,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 26, 17, 17, 13, 428, DateTimeKind.Utc).AddTicks(3));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 362,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 26, 17, 17, 13, 428, DateTimeKind.Utc).AddTicks(4));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 363,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 26, 17, 17, 13, 428, DateTimeKind.Utc).AddTicks(5));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 364,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 26, 17, 17, 13, 428, DateTimeKind.Utc).AddTicks(7));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 365,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 26, 17, 17, 13, 428, DateTimeKind.Utc).AddTicks(8));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 366,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 26, 17, 17, 13, 428, DateTimeKind.Utc).AddTicks(9));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 367,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 26, 17, 17, 13, 428, DateTimeKind.Utc).AddTicks(10));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 368,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 26, 17, 17, 13, 428, DateTimeKind.Utc).AddTicks(11));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 369,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 26, 17, 17, 13, 428, DateTimeKind.Utc).AddTicks(12));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 370,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 26, 17, 17, 13, 428, DateTimeKind.Utc).AddTicks(12));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 371,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 26, 17, 17, 13, 428, DateTimeKind.Utc).AddTicks(13));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 372,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 26, 17, 17, 13, 428, DateTimeKind.Utc).AddTicks(14));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 373,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 26, 17, 17, 13, 428, DateTimeKind.Utc).AddTicks(15));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 374,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 26, 17, 17, 13, 428, DateTimeKind.Utc).AddTicks(16));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 375,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 26, 17, 17, 13, 428, DateTimeKind.Utc).AddTicks(16));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 376,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 26, 17, 17, 13, 428, DateTimeKind.Utc).AddTicks(17));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 377,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 26, 17, 17, 13, 428, DateTimeKind.Utc).AddTicks(27));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 378,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 26, 17, 17, 13, 428, DateTimeKind.Utc).AddTicks(28));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 379,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 26, 17, 17, 13, 428, DateTimeKind.Utc).AddTicks(29));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 380,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 26, 17, 17, 13, 428, DateTimeKind.Utc).AddTicks(30));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 381,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 26, 17, 17, 13, 428, DateTimeKind.Utc).AddTicks(31));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 382,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 26, 17, 17, 13, 428, DateTimeKind.Utc).AddTicks(32));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 383,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 26, 17, 17, 13, 428, DateTimeKind.Utc).AddTicks(32));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 384,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 26, 17, 17, 13, 428, DateTimeKind.Utc).AddTicks(33));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 385,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 26, 17, 17, 13, 428, DateTimeKind.Utc).AddTicks(34));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 386,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 26, 17, 17, 13, 428, DateTimeKind.Utc).AddTicks(35));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 387,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 26, 17, 17, 13, 428, DateTimeKind.Utc).AddTicks(36));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 388,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 26, 17, 17, 13, 428, DateTimeKind.Utc).AddTicks(36));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 389,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 26, 17, 17, 13, 428, DateTimeKind.Utc).AddTicks(37));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 390,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 26, 17, 17, 13, 428, DateTimeKind.Utc).AddTicks(38));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 391,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 26, 17, 17, 13, 428, DateTimeKind.Utc).AddTicks(39));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 392,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 26, 17, 17, 13, 428, DateTimeKind.Utc).AddTicks(40));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 393,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 26, 17, 17, 13, 428, DateTimeKind.Utc).AddTicks(41));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 394,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 26, 17, 17, 13, 428, DateTimeKind.Utc).AddTicks(41));

            migrationBuilder.UpdateData(
                table: "OptionTranslations",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 26, 17, 17, 13, 439, DateTimeKind.Utc).AddTicks(9650));

            migrationBuilder.UpdateData(
                table: "OptionTranslations",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 26, 17, 17, 13, 439, DateTimeKind.Utc).AddTicks(9654));

            migrationBuilder.UpdateData(
                table: "OptionTranslations",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 26, 17, 17, 13, 439, DateTimeKind.Utc).AddTicks(9656));

            migrationBuilder.UpdateData(
                table: "OptionTranslations",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 26, 17, 17, 13, 439, DateTimeKind.Utc).AddTicks(9658));

            migrationBuilder.UpdateData(
                table: "OptionTranslations",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 26, 17, 17, 13, 439, DateTimeKind.Utc).AddTicks(9659));

            migrationBuilder.UpdateData(
                table: "OptionTranslations",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 26, 17, 17, 13, 439, DateTimeKind.Utc).AddTicks(9660));

            migrationBuilder.UpdateData(
                table: "OptionTranslations",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 26, 17, 17, 13, 439, DateTimeKind.Utc).AddTicks(9662));

            migrationBuilder.UpdateData(
                table: "OptionTranslations",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 26, 17, 17, 13, 439, DateTimeKind.Utc).AddTicks(9663));

            migrationBuilder.UpdateData(
                table: "OptionTranslations",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 26, 17, 17, 13, 439, DateTimeKind.Utc).AddTicks(9665));

            migrationBuilder.UpdateData(
                table: "OptionTranslations",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 26, 17, 17, 13, 439, DateTimeKind.Utc).AddTicks(9666));

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 26, 17, 17, 13, 439, DateTimeKind.Utc).AddTicks(2018));

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 26, 17, 17, 13, 439, DateTimeKind.Utc).AddTicks(2023));

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 26, 17, 17, 13, 439, DateTimeKind.Utc).AddTicks(2026));

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 26, 17, 17, 13, 439, DateTimeKind.Utc).AddTicks(2028));

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 26, 17, 17, 13, 439, DateTimeKind.Utc).AddTicks(2030));

            migrationBuilder.UpdateData(
                table: "ProductOptions",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 26, 17, 17, 13, 443, DateTimeKind.Utc).AddTicks(4860));

            migrationBuilder.UpdateData(
                table: "ProductOptions",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 26, 17, 17, 13, 443, DateTimeKind.Utc).AddTicks(4865));

            migrationBuilder.UpdateData(
                table: "ProductOptions",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 26, 17, 17, 13, 443, DateTimeKind.Utc).AddTicks(4867));

            migrationBuilder.UpdateData(
                table: "ProductOptions",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 26, 17, 17, 13, 443, DateTimeKind.Utc).AddTicks(4872));

            migrationBuilder.UpdateData(
                table: "ProductOptions",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 26, 17, 17, 13, 443, DateTimeKind.Utc).AddTicks(4874));

            migrationBuilder.UpdateData(
                table: "ProductOptions",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 26, 17, 17, 13, 443, DateTimeKind.Utc).AddTicks(4876));

            migrationBuilder.UpdateData(
                table: "ProductOptions",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 26, 17, 17, 13, 443, DateTimeKind.Utc).AddTicks(4878));

            migrationBuilder.UpdateData(
                table: "ProductOptions",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 26, 17, 17, 13, 443, DateTimeKind.Utc).AddTicks(4880));

            migrationBuilder.UpdateData(
                table: "ProductOptions",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 26, 17, 17, 13, 443, DateTimeKind.Utc).AddTicks(4882));

            migrationBuilder.UpdateData(
                table: "ProductOptions",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 26, 17, 17, 13, 443, DateTimeKind.Utc).AddTicks(4884));

            migrationBuilder.UpdateData(
                table: "ProductOptions",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 26, 17, 17, 13, 443, DateTimeKind.Utc).AddTicks(4885));

            migrationBuilder.UpdateData(
                table: "ProductOptions",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 26, 17, 17, 13, 443, DateTimeKind.Utc).AddTicks(4887));

            migrationBuilder.UpdateData(
                table: "ProductOptions",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 26, 17, 17, 13, 443, DateTimeKind.Utc).AddTicks(4889));

            migrationBuilder.UpdateData(
                table: "ProductOptions",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 26, 17, 17, 13, 443, DateTimeKind.Utc).AddTicks(4891));

            migrationBuilder.UpdateData(
                table: "ProductOptions",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 26, 17, 17, 13, 443, DateTimeKind.Utc).AddTicks(4921));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 26, 17, 17, 13, 441, DateTimeKind.Utc).AddTicks(6845));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 26, 17, 17, 13, 441, DateTimeKind.Utc).AddTicks(6851));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 26, 17, 17, 13, 441, DateTimeKind.Utc).AddTicks(6855));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 26, 17, 17, 13, 441, DateTimeKind.Utc).AddTicks(6858));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 26, 17, 17, 13, 441, DateTimeKind.Utc).AddTicks(6861));

            migrationBuilder.UpdateData(
                table: "Trademarks",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 26, 17, 17, 13, 445, DateTimeKind.Utc).AddTicks(6788));

            migrationBuilder.UpdateData(
                table: "Trademarks",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 26, 17, 17, 13, 445, DateTimeKind.Utc).AddTicks(6795));

            migrationBuilder.UpdateData(
                table: "Trademarks",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 26, 17, 17, 13, 445, DateTimeKind.Utc).AddTicks(6797));

            migrationBuilder.UpdateData(
                table: "Trademarks",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 26, 17, 17, 13, 445, DateTimeKind.Utc).AddTicks(6800));

            migrationBuilder.UpdateData(
                table: "Trademarks",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 26, 17, 17, 13, 445, DateTimeKind.Utc).AddTicks(6802));

            migrationBuilder.UpdateData(
                table: "Variants",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 26, 17, 17, 13, 447, DateTimeKind.Utc).AddTicks(7524));

            migrationBuilder.UpdateData(
                table: "Variants",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 26, 17, 17, 13, 447, DateTimeKind.Utc).AddTicks(7529));

            migrationBuilder.UpdateData(
                table: "Variants",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 26, 17, 17, 13, 447, DateTimeKind.Utc).AddTicks(7532));

            migrationBuilder.UpdateData(
                table: "Variants",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 26, 17, 17, 13, 447, DateTimeKind.Utc).AddTicks(7534));

            migrationBuilder.UpdateData(
                table: "Variants",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 26, 17, 17, 13, 447, DateTimeKind.Utc).AddTicks(7535));

            migrationBuilder.UpdateData(
                table: "Variants",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 26, 17, 17, 13, 447, DateTimeKind.Utc).AddTicks(7537));

            migrationBuilder.UpdateData(
                table: "Variants",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 26, 17, 17, 13, 447, DateTimeKind.Utc).AddTicks(7538));

            migrationBuilder.UpdateData(
                table: "Variants",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 26, 17, 17, 13, 447, DateTimeKind.Utc).AddTicks(7540));

            migrationBuilder.UpdateData(
                table: "Variants",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 26, 17, 17, 13, 447, DateTimeKind.Utc).AddTicks(7541));

            migrationBuilder.InsertData(
                table: "ArticleCategoryTranslations",
                columns: new[] { "Id", "ArticleCategoryId", "CreatedAt", "CreatedBy", "Description", "LanguageId", "Name", "Slug", "Status", "UpdatedAt", "UpdatedBy" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2025, 11, 26, 17, 17, 13, 407, DateTimeKind.Utc).AddTicks(2175), null, "Genel haberler ve duyurular", 1, "Genel", "genel", 0, null, null },
                    { 2, 1, new DateTime(2025, 11, 26, 17, 17, 13, 407, DateTimeKind.Utc).AddTicks(2178), null, "General news and announcements", 2, "General", "general", 0, null, null },
                    { 3, 2, new DateTime(2025, 11, 26, 17, 17, 13, 407, DateTimeKind.Utc).AddTicks(2180), null, "Faydalı ipuçları ve öneriler", 1, "İpuçları", "ipuclari", 0, null, null },
                    { 4, 2, new DateTime(2025, 11, 26, 17, 17, 13, 407, DateTimeKind.Utc).AddTicks(2181), null, "Useful tips and suggestions", 2, "Tips", "tips", 0, null, null },
                    { 5, 3, new DateTime(2025, 11, 26, 17, 17, 13, 407, DateTimeKind.Utc).AddTicks(2183), null, "Sistem güncellemeleri ve yeni özellikler", 1, "Güncellemeler", "guncellemeler", 0, null, null },
                    { 6, 3, new DateTime(2025, 11, 26, 17, 17, 13, 407, DateTimeKind.Utc).AddTicks(2184), null, "System updates and new features", 2, "Updates", "updates", 0, null, null }
                });

            migrationBuilder.InsertData(
                table: "Articles",
                columns: new[] { "Id", "AuthorId", "CategoryId", "CreatedAt", "CreatedBy", "FeaturedImage", "IsFeatured", "LikeCount", "MetaDescription", "MetaKeywords", "PublishedAt", "ReadingTime", "Status", "Tags", "UpdatedAt", "UpdatedBy", "VideoUrl", "ViewCount" },
                values: new object[] { 1, null, 1, new DateTime(2025, 11, 26, 17, 17, 13, 408, DateTimeKind.Utc).AddTicks(1434), null, "/images/articles/welcome.jpg", true, 25, null, null, new DateTime(2025, 11, 26, 17, 17, 13, 408, DateTimeKind.Utc).AddTicks(1422), 5, 1, "[\"cms\",\"welcome\",\"tutorial\"]", null, null, null, 150 });

            migrationBuilder.InsertData(
                table: "Articles",
                columns: new[] { "Id", "AuthorId", "CategoryId", "CreatedAt", "CreatedBy", "FeaturedImage", "IsTrending", "LikeCount", "MetaDescription", "MetaKeywords", "PublishedAt", "ReadingTime", "Status", "Tags", "UpdatedAt", "UpdatedBy", "VideoUrl", "ViewCount" },
                values: new object[] { 2, null, 1, new DateTime(2025, 11, 26, 17, 17, 13, 408, DateTimeKind.Utc).AddTicks(1440), null, "/images/articles/getting-started.jpg", true, 42, null, null, new DateTime(2025, 11, 26, 17, 17, 13, 408, DateTimeKind.Utc).AddTicks(1437), 8, 1, "[\"tutorial\",\"guide\",\"beginners\"]", null, null, null, 220 });

            migrationBuilder.InsertData(
                table: "ArticleTranslations",
                columns: new[] { "Id", "ArticleId", "Content", "CreatedAt", "CreatedBy", "LanguageId", "MetaTitle", "Slug", "Status", "Summary", "Title", "UpdatedAt", "UpdatedBy" },
                values: new object[,]
                {
                    { 1, 1, "<p>PazarAtlası CMS, modern içerik yönetim sistemlerinin gücünü Clean Architecture prensiplerine göre tasarlanmış bir platform ile birleştiriyor.</p><p>Bu sistemle sayfa, section ve içerik yönetimi artık çok daha kolay!</p>", new DateTime(2025, 11, 26, 17, 17, 13, 408, DateTimeKind.Utc).AddTicks(7965), null, 1, "PazarAtlası CMS - Hoş Geldiniz", "pazaratlasi-cms-hos-geldiniz", 0, "PazarAtlası CMS ile modern ve esnek içerik yönetimi deneyimine adım atın.", "PazarAtlası CMS'e Hoş Geldiniz", null, null },
                    { 2, 1, "<p>PazarAtlası CMS combines the power of modern content management systems with a platform designed according to Clean Architecture principles.</p><p>Managing pages, sections and content is now much easier with this system!</p>", new DateTime(2025, 11, 26, 17, 17, 13, 408, DateTimeKind.Utc).AddTicks(7968), null, 2, "PazarAtlası CMS - Welcome", "welcome-to-pazaratlasi-cms", 0, "Experience modern and flexible content management with PazarAtlası CMS.", "Welcome to PazarAtlası CMS", null, null },
                    { 3, 2, "<p>Bu rehberde, PazarAtlası CMS'te ilk sayfanızı nasıl oluşturacağınızı öğreneceksiniz.</p><p>Section'ları ekleyip düzenleyerek profesyonel görünümlü sayfalar oluşturun.</p>", new DateTime(2025, 11, 26, 17, 17, 13, 408, DateTimeKind.Utc).AddTicks(7969), null, 1, "Başlangıç Rehberi - PazarAtlası CMS", "baslangic-rehberi-ilk-sayfanizi-olusturun", 0, "PazarAtlası CMS'te ilk sayfanızı oluşturmak için adım adım rehber.", "Başlangıç Rehberi: İlk Sayfanızı Oluşturun", null, null },
                    { 4, 2, "<p>In this guide, you'll learn how to create your first page in PazarAtlası CMS.</p><p>Create professional-looking pages by adding and editing sections.</p>", new DateTime(2025, 11, 26, 17, 17, 13, 408, DateTimeKind.Utc).AddTicks(7971), null, 2, "Getting Started - PazarAtlası CMS", "getting-started-create-your-first-page", 0, "A step-by-step guide to creating your first page in PazarAtlası CMS.", "Getting Started: Create Your First Page", null, null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_ArticleCategories_ParentCategoryId",
                table: "ArticleCategories",
                column: "ParentCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_ArticleCategories_SortOrder",
                table: "ArticleCategories",
                column: "SortOrder");

            migrationBuilder.CreateIndex(
                name: "IX_ArticleCategories_Status",
                table: "ArticleCategories",
                column: "Status");

            migrationBuilder.CreateIndex(
                name: "IX_ArticleCategoryTranslations_CategoryId_LanguageId",
                table: "ArticleCategoryTranslations",
                columns: new[] { "ArticleCategoryId", "LanguageId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ArticleCategoryTranslations_LanguageId",
                table: "ArticleCategoryTranslations",
                column: "LanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_ArticleCategoryTranslations_Slug",
                table: "ArticleCategoryTranslations",
                column: "Slug");

            migrationBuilder.CreateIndex(
                name: "IX_Articles_CategoryId",
                table: "Articles",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Articles_IsFeatured",
                table: "Articles",
                column: "IsFeatured");

            migrationBuilder.CreateIndex(
                name: "IX_Articles_IsTrending",
                table: "Articles",
                column: "IsTrending");

            migrationBuilder.CreateIndex(
                name: "IX_Articles_PublishedAt",
                table: "Articles",
                column: "PublishedAt");

            migrationBuilder.CreateIndex(
                name: "IX_Articles_SortOrder",
                table: "Articles",
                column: "SortOrder");

            migrationBuilder.CreateIndex(
                name: "IX_Articles_Status",
                table: "Articles",
                column: "Status");

            migrationBuilder.CreateIndex(
                name: "IX_ArticleTranslations_ArticleId_LanguageId",
                table: "ArticleTranslations",
                columns: new[] { "ArticleId", "LanguageId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ArticleTranslations_LanguageId",
                table: "ArticleTranslations",
                column: "LanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_ArticleTranslations_Slug",
                table: "ArticleTranslations",
                column: "Slug");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ArticleCategoryTranslations");

            migrationBuilder.DropTable(
                name: "ArticleTranslations");

            migrationBuilder.DropTable(
                name: "Articles");

            migrationBuilder.DropTable(
                name: "ArticleCategories");

            migrationBuilder.UpdateData(
                table: "DataSchemaFields",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 43, DateTimeKind.Utc).AddTicks(9597));

            migrationBuilder.UpdateData(
                table: "DataSchemaFields",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 43, DateTimeKind.Utc).AddTicks(9602));

            migrationBuilder.UpdateData(
                table: "DataSchemaFields",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 43, DateTimeKind.Utc).AddTicks(9606));

            migrationBuilder.UpdateData(
                table: "DataSchemaFields",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 43, DateTimeKind.Utc).AddTicks(9609));

            migrationBuilder.UpdateData(
                table: "DataSchemaFields",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 43, DateTimeKind.Utc).AddTicks(9613));

            migrationBuilder.UpdateData(
                table: "DataSchemaFields",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 43, DateTimeKind.Utc).AddTicks(9616));

            migrationBuilder.UpdateData(
                table: "DataSchemas",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 42, DateTimeKind.Utc).AddTicks(2033));

            migrationBuilder.UpdateData(
                table: "DataSchemas",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 42, DateTimeKind.Utc).AddTicks(2037));

            migrationBuilder.UpdateData(
                table: "DataSchemas",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 42, DateTimeKind.Utc).AddTicks(2040));

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 36, DateTimeKind.Utc).AddTicks(5464));

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 36, DateTimeKind.Utc).AddTicks(5468));

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 36, DateTimeKind.Utc).AddTicks(5471));

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 36, DateTimeKind.Utc).AddTicks(5473));

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 36, DateTimeKind.Utc).AddTicks(5476));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 37, DateTimeKind.Utc).AddTicks(4346));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 37, DateTimeKind.Utc).AddTicks(4351));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 37, DateTimeKind.Utc).AddTicks(4353));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 37, DateTimeKind.Utc).AddTicks(4354));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 37, DateTimeKind.Utc).AddTicks(4356));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 37, DateTimeKind.Utc).AddTicks(4358));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 37, DateTimeKind.Utc).AddTicks(4359));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 37, DateTimeKind.Utc).AddTicks(4361));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 37, DateTimeKind.Utc).AddTicks(4362));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 37, DateTimeKind.Utc).AddTicks(4364));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 37, DateTimeKind.Utc).AddTicks(4365));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 37, DateTimeKind.Utc).AddTicks(4366));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 37, DateTimeKind.Utc).AddTicks(4367));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 37, DateTimeKind.Utc).AddTicks(4368));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 37, DateTimeKind.Utc).AddTicks(4369));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 16,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 37, DateTimeKind.Utc).AddTicks(4380));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 17,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 37, DateTimeKind.Utc).AddTicks(4381));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 18,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 37, DateTimeKind.Utc).AddTicks(4383));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 19,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 37, DateTimeKind.Utc).AddTicks(4384));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 20,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 37, DateTimeKind.Utc).AddTicks(4385));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 21,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 37, DateTimeKind.Utc).AddTicks(4386));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 22,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 37, DateTimeKind.Utc).AddTicks(4387));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 23,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 37, DateTimeKind.Utc).AddTicks(4388));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 24,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 37, DateTimeKind.Utc).AddTicks(4389));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 25,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 37, DateTimeKind.Utc).AddTicks(4390));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 26,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 37, DateTimeKind.Utc).AddTicks(4391));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 27,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 37, DateTimeKind.Utc).AddTicks(4392));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 28,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 37, DateTimeKind.Utc).AddTicks(4393));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 29,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 37, DateTimeKind.Utc).AddTicks(4394));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 30,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 37, DateTimeKind.Utc).AddTicks(4410));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 31,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 37, DateTimeKind.Utc).AddTicks(4412));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 32,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 37, DateTimeKind.Utc).AddTicks(4412));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 33,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 37, DateTimeKind.Utc).AddTicks(4413));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 34,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 37, DateTimeKind.Utc).AddTicks(4415));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 35,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 37, DateTimeKind.Utc).AddTicks(4417));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 36,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 37, DateTimeKind.Utc).AddTicks(4418));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 37,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 37, DateTimeKind.Utc).AddTicks(4419));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 38,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 37, DateTimeKind.Utc).AddTicks(4420));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 39,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 37, DateTimeKind.Utc).AddTicks(4424));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 40,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 37, DateTimeKind.Utc).AddTicks(4425));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 41,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 37, DateTimeKind.Utc).AddTicks(4426));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 42,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 37, DateTimeKind.Utc).AddTicks(4427));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 43,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 37, DateTimeKind.Utc).AddTicks(4428));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 44,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 37, DateTimeKind.Utc).AddTicks(4429));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 45,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 37, DateTimeKind.Utc).AddTicks(4430));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 46,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 37, DateTimeKind.Utc).AddTicks(4431));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 47,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 37, DateTimeKind.Utc).AddTicks(4432));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 48,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 37, DateTimeKind.Utc).AddTicks(4433));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 49,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 37, DateTimeKind.Utc).AddTicks(4439));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 50,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 37, DateTimeKind.Utc).AddTicks(4440));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 51,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 37, DateTimeKind.Utc).AddTicks(4441));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 52,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 37, DateTimeKind.Utc).AddTicks(4442));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 53,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 37, DateTimeKind.Utc).AddTicks(4443));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 54,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 37, DateTimeKind.Utc).AddTicks(4445));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 55,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 37, DateTimeKind.Utc).AddTicks(4447));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 56,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 37, DateTimeKind.Utc).AddTicks(4447));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 57,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 37, DateTimeKind.Utc).AddTicks(4448));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 58,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 37, DateTimeKind.Utc).AddTicks(4449));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 59,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 37, DateTimeKind.Utc).AddTicks(4450));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 60,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 37, DateTimeKind.Utc).AddTicks(4451));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 61,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 37, DateTimeKind.Utc).AddTicks(4452));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 62,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 37, DateTimeKind.Utc).AddTicks(4453));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 63,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 37, DateTimeKind.Utc).AddTicks(4454));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 64,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 37, DateTimeKind.Utc).AddTicks(4455));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 65,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 37, DateTimeKind.Utc).AddTicks(4456));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 66,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 37, DateTimeKind.Utc).AddTicks(4458));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 67,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 37, DateTimeKind.Utc).AddTicks(4459));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 68,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 37, DateTimeKind.Utc).AddTicks(4460));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 69,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 37, DateTimeKind.Utc).AddTicks(4461));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 70,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 37, DateTimeKind.Utc).AddTicks(4464));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 71,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 37, DateTimeKind.Utc).AddTicks(4465));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 72,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 37, DateTimeKind.Utc).AddTicks(4466));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 73,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 37, DateTimeKind.Utc).AddTicks(4467));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 74,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 37, DateTimeKind.Utc).AddTicks(4469));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 75,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 37, DateTimeKind.Utc).AddTicks(4470));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 76,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 37, DateTimeKind.Utc).AddTicks(4470));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 77,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 37, DateTimeKind.Utc).AddTicks(4471));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 78,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 37, DateTimeKind.Utc).AddTicks(4472));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 79,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 37, DateTimeKind.Utc).AddTicks(4473));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 80,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 37, DateTimeKind.Utc).AddTicks(4476));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 81,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 37, DateTimeKind.Utc).AddTicks(4486));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 82,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 37, DateTimeKind.Utc).AddTicks(4487));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 83,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 37, DateTimeKind.Utc).AddTicks(4488));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 84,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 37, DateTimeKind.Utc).AddTicks(4489));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 85,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 37, DateTimeKind.Utc).AddTicks(4490));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 86,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 37, DateTimeKind.Utc).AddTicks(4492));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 87,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 37, DateTimeKind.Utc).AddTicks(4493));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 88,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 37, DateTimeKind.Utc).AddTicks(4494));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 89,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 37, DateTimeKind.Utc).AddTicks(4495));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 90,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 37, DateTimeKind.Utc).AddTicks(4496));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 91,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 37, DateTimeKind.Utc).AddTicks(4497));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 92,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 37, DateTimeKind.Utc).AddTicks(4498));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 93,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 37, DateTimeKind.Utc).AddTicks(4499));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 94,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 37, DateTimeKind.Utc).AddTicks(4500));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 95,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 37, DateTimeKind.Utc).AddTicks(4501));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 96,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 37, DateTimeKind.Utc).AddTicks(4502));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 97,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 37, DateTimeKind.Utc).AddTicks(4503));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 98,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 37, DateTimeKind.Utc).AddTicks(4504));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 99,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 37, DateTimeKind.Utc).AddTicks(4505));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 100,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 37, DateTimeKind.Utc).AddTicks(4506));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 101,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 37, DateTimeKind.Utc).AddTicks(4507));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 102,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 37, DateTimeKind.Utc).AddTicks(4508));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 103,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 37, DateTimeKind.Utc).AddTicks(4509));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 104,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 37, DateTimeKind.Utc).AddTicks(4510));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 105,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 37, DateTimeKind.Utc).AddTicks(4511));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 106,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 37, DateTimeKind.Utc).AddTicks(4512));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 107,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 37, DateTimeKind.Utc).AddTicks(4513));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 108,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 37, DateTimeKind.Utc).AddTicks(4514));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 109,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 37, DateTimeKind.Utc).AddTicks(4517));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 110,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 37, DateTimeKind.Utc).AddTicks(4518));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 111,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 37, DateTimeKind.Utc).AddTicks(4521));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 112,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 37, DateTimeKind.Utc).AddTicks(4522));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 113,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 37, DateTimeKind.Utc).AddTicks(4524));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 114,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 37, DateTimeKind.Utc).AddTicks(4525));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 115,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 37, DateTimeKind.Utc).AddTicks(4526));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 116,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 37, DateTimeKind.Utc).AddTicks(4527));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 117,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 37, DateTimeKind.Utc).AddTicks(4532));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 118,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 37, DateTimeKind.Utc).AddTicks(4533));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 119,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 37, DateTimeKind.Utc).AddTicks(4534));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 120,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 37, DateTimeKind.Utc).AddTicks(4535));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 121,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 37, DateTimeKind.Utc).AddTicks(4536));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 122,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 37, DateTimeKind.Utc).AddTicks(4537));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 123,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 37, DateTimeKind.Utc).AddTicks(4538));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 124,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 37, DateTimeKind.Utc).AddTicks(4539));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 125,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 37, DateTimeKind.Utc).AddTicks(4539));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 126,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 37, DateTimeKind.Utc).AddTicks(4540));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 127,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 37, DateTimeKind.Utc).AddTicks(4541));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 128,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 37, DateTimeKind.Utc).AddTicks(4542));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 129,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 37, DateTimeKind.Utc).AddTicks(4543));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 130,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 37, DateTimeKind.Utc).AddTicks(4545));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 131,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 37, DateTimeKind.Utc).AddTicks(4546));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 132,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 37, DateTimeKind.Utc).AddTicks(4547));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 133,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 37, DateTimeKind.Utc).AddTicks(4548));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 134,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 37, DateTimeKind.Utc).AddTicks(4549));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 135,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 37, DateTimeKind.Utc).AddTicks(4550));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 136,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 37, DateTimeKind.Utc).AddTicks(4551));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 137,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 37, DateTimeKind.Utc).AddTicks(4552));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 138,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 37, DateTimeKind.Utc).AddTicks(4553));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 139,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 37, DateTimeKind.Utc).AddTicks(4556));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 140,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 37, DateTimeKind.Utc).AddTicks(4557));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 141,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 37, DateTimeKind.Utc).AddTicks(4559));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 142,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 37, DateTimeKind.Utc).AddTicks(4560));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 143,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 37, DateTimeKind.Utc).AddTicks(4565));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 144,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 37, DateTimeKind.Utc).AddTicks(4566));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 145,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 37, DateTimeKind.Utc).AddTicks(4567));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 146,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 37, DateTimeKind.Utc).AddTicks(4569));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 147,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 37, DateTimeKind.Utc).AddTicks(4570));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 148,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 37, DateTimeKind.Utc).AddTicks(4571));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 149,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 37, DateTimeKind.Utc).AddTicks(4572));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 150,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 37, DateTimeKind.Utc).AddTicks(4573));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 151,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 37, DateTimeKind.Utc).AddTicks(4574));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 152,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 37, DateTimeKind.Utc).AddTicks(4575));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 153,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 37, DateTimeKind.Utc).AddTicks(4576));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 154,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 37, DateTimeKind.Utc).AddTicks(4577));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 155,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 37, DateTimeKind.Utc).AddTicks(4578));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 156,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 37, DateTimeKind.Utc).AddTicks(4579));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 157,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 37, DateTimeKind.Utc).AddTicks(4580));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 158,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 37, DateTimeKind.Utc).AddTicks(4581));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 159,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 37, DateTimeKind.Utc).AddTicks(4582));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 160,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 37, DateTimeKind.Utc).AddTicks(4583));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 161,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 37, DateTimeKind.Utc).AddTicks(4584));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 162,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 37, DateTimeKind.Utc).AddTicks(4585));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 163,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 37, DateTimeKind.Utc).AddTicks(4586));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 164,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 37, DateTimeKind.Utc).AddTicks(4588));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 165,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 37, DateTimeKind.Utc).AddTicks(4590));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 166,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 37, DateTimeKind.Utc).AddTicks(4591));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 167,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 37, DateTimeKind.Utc).AddTicks(4592));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 168,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 37, DateTimeKind.Utc).AddTicks(4593));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 169,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 37, DateTimeKind.Utc).AddTicks(4594));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 170,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 37, DateTimeKind.Utc).AddTicks(4595));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 171,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 37, DateTimeKind.Utc).AddTicks(4595));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 172,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 37, DateTimeKind.Utc).AddTicks(4596));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 173,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 37, DateTimeKind.Utc).AddTicks(4597));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 174,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 37, DateTimeKind.Utc).AddTicks(4598));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 175,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 37, DateTimeKind.Utc).AddTicks(4599));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 176,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 37, DateTimeKind.Utc).AddTicks(4600));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 177,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 37, DateTimeKind.Utc).AddTicks(4601));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 178,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 37, DateTimeKind.Utc).AddTicks(4607));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 179,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 37, DateTimeKind.Utc).AddTicks(4608));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 180,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 37, DateTimeKind.Utc).AddTicks(4609));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 181,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 37, DateTimeKind.Utc).AddTicks(4610));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 182,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 37, DateTimeKind.Utc).AddTicks(4611));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 183,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 37, DateTimeKind.Utc).AddTicks(4612));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 184,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 37, DateTimeKind.Utc).AddTicks(4613));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 185,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 37, DateTimeKind.Utc).AddTicks(4614));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 186,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 37, DateTimeKind.Utc).AddTicks(4615));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 187,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 37, DateTimeKind.Utc).AddTicks(4615));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 188,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 37, DateTimeKind.Utc).AddTicks(4616));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 189,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 37, DateTimeKind.Utc).AddTicks(4617));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 190,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 37, DateTimeKind.Utc).AddTicks(4618));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 191,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 37, DateTimeKind.Utc).AddTicks(4619));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 192,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 37, DateTimeKind.Utc).AddTicks(4620));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 193,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 37, DateTimeKind.Utc).AddTicks(4621));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 194,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 37, DateTimeKind.Utc).AddTicks(4622));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 195,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 37, DateTimeKind.Utc).AddTicks(4623));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 196,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 37, DateTimeKind.Utc).AddTicks(4624));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 197,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 37, DateTimeKind.Utc).AddTicks(4625));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 198,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 37, DateTimeKind.Utc).AddTicks(4626));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 199,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 37, DateTimeKind.Utc).AddTicks(4626));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 200,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 37, DateTimeKind.Utc).AddTicks(4627));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 201,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 37, DateTimeKind.Utc).AddTicks(4628));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 202,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 37, DateTimeKind.Utc).AddTicks(4631));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 203,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 37, DateTimeKind.Utc).AddTicks(4633));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 204,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 37, DateTimeKind.Utc).AddTicks(4633));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 205,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 37, DateTimeKind.Utc).AddTicks(4635));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 206,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 37, DateTimeKind.Utc).AddTicks(4636));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 207,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 37, DateTimeKind.Utc).AddTicks(4636));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 208,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 37, DateTimeKind.Utc).AddTicks(4637));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 209,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 37, DateTimeKind.Utc).AddTicks(4638));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 210,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 37, DateTimeKind.Utc).AddTicks(4639));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 211,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 37, DateTimeKind.Utc).AddTicks(4641));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 212,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 37, DateTimeKind.Utc).AddTicks(4641));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 213,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 37, DateTimeKind.Utc).AddTicks(4642));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 214,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 37, DateTimeKind.Utc).AddTicks(4643));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 215,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 37, DateTimeKind.Utc).AddTicks(4644));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 216,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 37, DateTimeKind.Utc).AddTicks(4650));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 217,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 37, DateTimeKind.Utc).AddTicks(4653));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 218,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 37, DateTimeKind.Utc).AddTicks(4655));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 219,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 37, DateTimeKind.Utc).AddTicks(4656));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 220,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 37, DateTimeKind.Utc).AddTicks(4657));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 221,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 37, DateTimeKind.Utc).AddTicks(4658));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 222,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 37, DateTimeKind.Utc).AddTicks(4659));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 223,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 37, DateTimeKind.Utc).AddTicks(4660));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 224,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 37, DateTimeKind.Utc).AddTicks(4661));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 225,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 37, DateTimeKind.Utc).AddTicks(4662));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 226,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 37, DateTimeKind.Utc).AddTicks(4663));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 227,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 37, DateTimeKind.Utc).AddTicks(4664));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 228,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 37, DateTimeKind.Utc).AddTicks(4664));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 229,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 37, DateTimeKind.Utc).AddTicks(4665));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 230,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 37, DateTimeKind.Utc).AddTicks(4666));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 231,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 37, DateTimeKind.Utc).AddTicks(4667));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 232,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 37, DateTimeKind.Utc).AddTicks(4668));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 233,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 37, DateTimeKind.Utc).AddTicks(4672));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 234,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 37, DateTimeKind.Utc).AddTicks(4673));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 235,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 37, DateTimeKind.Utc).AddTicks(4674));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 236,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 37, DateTimeKind.Utc).AddTicks(4675));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 237,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 37, DateTimeKind.Utc).AddTicks(4676));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 238,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 37, DateTimeKind.Utc).AddTicks(4677));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 239,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 37, DateTimeKind.Utc).AddTicks(4678));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 240,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 37, DateTimeKind.Utc).AddTicks(4679));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 241,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 37, DateTimeKind.Utc).AddTicks(4680));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 242,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 37, DateTimeKind.Utc).AddTicks(4681));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 243,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 37, DateTimeKind.Utc).AddTicks(4684));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 244,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 37, DateTimeKind.Utc).AddTicks(4686));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 245,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 37, DateTimeKind.Utc).AddTicks(4687));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 246,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 37, DateTimeKind.Utc).AddTicks(4688));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 247,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 37, DateTimeKind.Utc).AddTicks(4689));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 248,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 37, DateTimeKind.Utc).AddTicks(4690));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 249,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 37, DateTimeKind.Utc).AddTicks(4691));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 250,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 37, DateTimeKind.Utc).AddTicks(4692));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 251,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 37, DateTimeKind.Utc).AddTicks(4693));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 252,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 37, DateTimeKind.Utc).AddTicks(4699));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 253,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 37, DateTimeKind.Utc).AddTicks(4700));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 254,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 37, DateTimeKind.Utc).AddTicks(4701));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 255,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 37, DateTimeKind.Utc).AddTicks(4702));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 256,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 37, DateTimeKind.Utc).AddTicks(4703));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 257,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 37, DateTimeKind.Utc).AddTicks(4703));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 258,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 37, DateTimeKind.Utc).AddTicks(4706));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 259,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 37, DateTimeKind.Utc).AddTicks(4707));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 260,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 37, DateTimeKind.Utc).AddTicks(4707));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 261,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 37, DateTimeKind.Utc).AddTicks(4708));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 262,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 37, DateTimeKind.Utc).AddTicks(4709));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 263,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 37, DateTimeKind.Utc).AddTicks(4710));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 264,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 37, DateTimeKind.Utc).AddTicks(4711));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 265,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 37, DateTimeKind.Utc).AddTicks(4712));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 266,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 37, DateTimeKind.Utc).AddTicks(4713));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 267,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 37, DateTimeKind.Utc).AddTicks(4714));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 268,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 37, DateTimeKind.Utc).AddTicks(4715));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 269,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 37, DateTimeKind.Utc).AddTicks(4721));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 270,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 37, DateTimeKind.Utc).AddTicks(4722));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 271,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 37, DateTimeKind.Utc).AddTicks(4723));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 272,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 37, DateTimeKind.Utc).AddTicks(4726));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 273,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 37, DateTimeKind.Utc).AddTicks(4728));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 274,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 37, DateTimeKind.Utc).AddTicks(4731));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 275,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 37, DateTimeKind.Utc).AddTicks(4732));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 276,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 37, DateTimeKind.Utc).AddTicks(4734));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 277,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 37, DateTimeKind.Utc).AddTicks(4735));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 278,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 37, DateTimeKind.Utc).AddTicks(4735));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 279,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 37, DateTimeKind.Utc).AddTicks(4737));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 280,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 37, DateTimeKind.Utc).AddTicks(4738));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 281,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 37, DateTimeKind.Utc).AddTicks(4738));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 282,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 37, DateTimeKind.Utc).AddTicks(4739));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 283,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 37, DateTimeKind.Utc).AddTicks(4740));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 284,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 37, DateTimeKind.Utc).AddTicks(4742));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 285,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 37, DateTimeKind.Utc).AddTicks(4743));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 286,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 37, DateTimeKind.Utc).AddTicks(4744));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 287,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 37, DateTimeKind.Utc).AddTicks(4745));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 288,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 37, DateTimeKind.Utc).AddTicks(4746));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 289,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 37, DateTimeKind.Utc).AddTicks(4748));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 290,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 37, DateTimeKind.Utc).AddTicks(4748));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 291,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 37, DateTimeKind.Utc).AddTicks(4749));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 292,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 37, DateTimeKind.Utc).AddTicks(4750));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 293,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 37, DateTimeKind.Utc).AddTicks(4752));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 294,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 37, DateTimeKind.Utc).AddTicks(4752));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 295,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 37, DateTimeKind.Utc).AddTicks(4753));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 296,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 37, DateTimeKind.Utc).AddTicks(4754));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 297,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 37, DateTimeKind.Utc).AddTicks(4755));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 298,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 37, DateTimeKind.Utc).AddTicks(4756));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 299,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 37, DateTimeKind.Utc).AddTicks(4757));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 300,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 37, DateTimeKind.Utc).AddTicks(4758));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 301,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 37, DateTimeKind.Utc).AddTicks(4759));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 302,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 37, DateTimeKind.Utc).AddTicks(4762));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 303,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 37, DateTimeKind.Utc).AddTicks(4764));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 304,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 37, DateTimeKind.Utc).AddTicks(4765));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 305,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 37, DateTimeKind.Utc).AddTicks(4770));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 306,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 37, DateTimeKind.Utc).AddTicks(4771));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 307,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 37, DateTimeKind.Utc).AddTicks(4772));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 308,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 37, DateTimeKind.Utc).AddTicks(4773));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 309,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 37, DateTimeKind.Utc).AddTicks(4774));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 310,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 37, DateTimeKind.Utc).AddTicks(4775));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 311,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 37, DateTimeKind.Utc).AddTicks(4776));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 312,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 37, DateTimeKind.Utc).AddTicks(4777));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 313,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 37, DateTimeKind.Utc).AddTicks(4778));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 314,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 37, DateTimeKind.Utc).AddTicks(4779));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 315,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 37, DateTimeKind.Utc).AddTicks(4780));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 316,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 37, DateTimeKind.Utc).AddTicks(4781));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 317,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 37, DateTimeKind.Utc).AddTicks(4782));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 318,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 37, DateTimeKind.Utc).AddTicks(4783));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 319,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 37, DateTimeKind.Utc).AddTicks(4784));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 320,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 37, DateTimeKind.Utc).AddTicks(4785));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 321,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 37, DateTimeKind.Utc).AddTicks(4786));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 322,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 37, DateTimeKind.Utc).AddTicks(4786));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 323,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 37, DateTimeKind.Utc).AddTicks(4787));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 324,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 37, DateTimeKind.Utc).AddTicks(4788));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 325,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 37, DateTimeKind.Utc).AddTicks(4789));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 326,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 37, DateTimeKind.Utc).AddTicks(4790));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 327,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 37, DateTimeKind.Utc).AddTicks(4836));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 328,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 37, DateTimeKind.Utc).AddTicks(4838));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 329,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 37, DateTimeKind.Utc).AddTicks(4839));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 330,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 37, DateTimeKind.Utc).AddTicks(4840));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 331,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 37, DateTimeKind.Utc).AddTicks(4841));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 332,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 37, DateTimeKind.Utc).AddTicks(4842));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 333,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 37, DateTimeKind.Utc).AddTicks(4843));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 334,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 37, DateTimeKind.Utc).AddTicks(4843));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 335,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 37, DateTimeKind.Utc).AddTicks(4845));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 336,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 37, DateTimeKind.Utc).AddTicks(4846));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 337,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 37, DateTimeKind.Utc).AddTicks(4847));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 338,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 37, DateTimeKind.Utc).AddTicks(4848));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 339,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 37, DateTimeKind.Utc).AddTicks(4849));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 340,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 37, DateTimeKind.Utc).AddTicks(4850));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 341,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 37, DateTimeKind.Utc).AddTicks(4851));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 342,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 37, DateTimeKind.Utc).AddTicks(4852));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 343,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 37, DateTimeKind.Utc).AddTicks(4853));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 344,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 37, DateTimeKind.Utc).AddTicks(4853));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 345,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 37, DateTimeKind.Utc).AddTicks(4854));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 346,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 37, DateTimeKind.Utc).AddTicks(4855));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 347,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 37, DateTimeKind.Utc).AddTicks(4856));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 348,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 37, DateTimeKind.Utc).AddTicks(4857));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 349,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 37, DateTimeKind.Utc).AddTicks(4858));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 350,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 37, DateTimeKind.Utc).AddTicks(4859));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 351,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 37, DateTimeKind.Utc).AddTicks(4860));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 352,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 37, DateTimeKind.Utc).AddTicks(4861));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 353,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 37, DateTimeKind.Utc).AddTicks(4862));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 354,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 37, DateTimeKind.Utc).AddTicks(4863));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 355,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 37, DateTimeKind.Utc).AddTicks(4863));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 356,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 37, DateTimeKind.Utc).AddTicks(4864));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 357,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 37, DateTimeKind.Utc).AddTicks(4869));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 358,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 37, DateTimeKind.Utc).AddTicks(4870));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 359,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 37, DateTimeKind.Utc).AddTicks(4871));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 360,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 37, DateTimeKind.Utc).AddTicks(4872));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 361,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 37, DateTimeKind.Utc).AddTicks(4875));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 362,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 37, DateTimeKind.Utc).AddTicks(4876));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 363,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 37, DateTimeKind.Utc).AddTicks(4878));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 364,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 37, DateTimeKind.Utc).AddTicks(4879));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 365,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 37, DateTimeKind.Utc).AddTicks(4880));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 366,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 37, DateTimeKind.Utc).AddTicks(4881));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 367,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 37, DateTimeKind.Utc).AddTicks(4882));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 368,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 37, DateTimeKind.Utc).AddTicks(4883));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 369,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 37, DateTimeKind.Utc).AddTicks(4884));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 370,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 37, DateTimeKind.Utc).AddTicks(4885));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 371,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 37, DateTimeKind.Utc).AddTicks(4886));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 372,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 37, DateTimeKind.Utc).AddTicks(4887));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 373,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 37, DateTimeKind.Utc).AddTicks(4888));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 374,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 37, DateTimeKind.Utc).AddTicks(4889));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 375,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 37, DateTimeKind.Utc).AddTicks(4890));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 376,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 37, DateTimeKind.Utc).AddTicks(4891));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 377,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 37, DateTimeKind.Utc).AddTicks(4892));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 378,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 37, DateTimeKind.Utc).AddTicks(4893));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 379,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 37, DateTimeKind.Utc).AddTicks(4894));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 380,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 37, DateTimeKind.Utc).AddTicks(4895));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 381,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 37, DateTimeKind.Utc).AddTicks(4896));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 382,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 37, DateTimeKind.Utc).AddTicks(4897));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 383,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 37, DateTimeKind.Utc).AddTicks(4898));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 384,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 37, DateTimeKind.Utc).AddTicks(4899));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 385,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 37, DateTimeKind.Utc).AddTicks(4900));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 386,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 37, DateTimeKind.Utc).AddTicks(4900));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 387,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 37, DateTimeKind.Utc).AddTicks(4901));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 388,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 37, DateTimeKind.Utc).AddTicks(4902));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 389,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 37, DateTimeKind.Utc).AddTicks(4903));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 390,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 37, DateTimeKind.Utc).AddTicks(4904));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 391,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 37, DateTimeKind.Utc).AddTicks(4905));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 392,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 37, DateTimeKind.Utc).AddTicks(4906));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 393,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 37, DateTimeKind.Utc).AddTicks(4912));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 394,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 37, DateTimeKind.Utc).AddTicks(4914));

            migrationBuilder.UpdateData(
                table: "OptionTranslations",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 49, DateTimeKind.Utc).AddTicks(7419));

            migrationBuilder.UpdateData(
                table: "OptionTranslations",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 49, DateTimeKind.Utc).AddTicks(7421));

            migrationBuilder.UpdateData(
                table: "OptionTranslations",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 49, DateTimeKind.Utc).AddTicks(7423));

            migrationBuilder.UpdateData(
                table: "OptionTranslations",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 49, DateTimeKind.Utc).AddTicks(7425));

            migrationBuilder.UpdateData(
                table: "OptionTranslations",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 49, DateTimeKind.Utc).AddTicks(7427));

            migrationBuilder.UpdateData(
                table: "OptionTranslations",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 49, DateTimeKind.Utc).AddTicks(7428));

            migrationBuilder.UpdateData(
                table: "OptionTranslations",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 49, DateTimeKind.Utc).AddTicks(7430));

            migrationBuilder.UpdateData(
                table: "OptionTranslations",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 49, DateTimeKind.Utc).AddTicks(7432));

            migrationBuilder.UpdateData(
                table: "OptionTranslations",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 49, DateTimeKind.Utc).AddTicks(7433));

            migrationBuilder.UpdateData(
                table: "OptionTranslations",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 49, DateTimeKind.Utc).AddTicks(7435));

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 49, DateTimeKind.Utc).AddTicks(197));

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 49, DateTimeKind.Utc).AddTicks(201));

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 49, DateTimeKind.Utc).AddTicks(204));

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 49, DateTimeKind.Utc).AddTicks(206));

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 49, DateTimeKind.Utc).AddTicks(209));

            migrationBuilder.UpdateData(
                table: "ProductOptions",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 53, DateTimeKind.Utc).AddTicks(2446));

            migrationBuilder.UpdateData(
                table: "ProductOptions",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 53, DateTimeKind.Utc).AddTicks(2449));

            migrationBuilder.UpdateData(
                table: "ProductOptions",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 53, DateTimeKind.Utc).AddTicks(2452));

            migrationBuilder.UpdateData(
                table: "ProductOptions",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 53, DateTimeKind.Utc).AddTicks(2457));

            migrationBuilder.UpdateData(
                table: "ProductOptions",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 53, DateTimeKind.Utc).AddTicks(2460));

            migrationBuilder.UpdateData(
                table: "ProductOptions",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 53, DateTimeKind.Utc).AddTicks(2470));

            migrationBuilder.UpdateData(
                table: "ProductOptions",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 53, DateTimeKind.Utc).AddTicks(2472));

            migrationBuilder.UpdateData(
                table: "ProductOptions",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 53, DateTimeKind.Utc).AddTicks(2474));

            migrationBuilder.UpdateData(
                table: "ProductOptions",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 53, DateTimeKind.Utc).AddTicks(2476));

            migrationBuilder.UpdateData(
                table: "ProductOptions",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 53, DateTimeKind.Utc).AddTicks(2478));

            migrationBuilder.UpdateData(
                table: "ProductOptions",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 53, DateTimeKind.Utc).AddTicks(2480));

            migrationBuilder.UpdateData(
                table: "ProductOptions",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 53, DateTimeKind.Utc).AddTicks(2482));

            migrationBuilder.UpdateData(
                table: "ProductOptions",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 53, DateTimeKind.Utc).AddTicks(2484));

            migrationBuilder.UpdateData(
                table: "ProductOptions",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 53, DateTimeKind.Utc).AddTicks(2486));

            migrationBuilder.UpdateData(
                table: "ProductOptions",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 53, DateTimeKind.Utc).AddTicks(2494));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 51, DateTimeKind.Utc).AddTicks(4851));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 51, DateTimeKind.Utc).AddTicks(4864));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 51, DateTimeKind.Utc).AddTicks(4867));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 51, DateTimeKind.Utc).AddTicks(4871));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 51, DateTimeKind.Utc).AddTicks(4874));

            migrationBuilder.UpdateData(
                table: "Trademarks",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 54, DateTimeKind.Utc).AddTicks(9484));

            migrationBuilder.UpdateData(
                table: "Trademarks",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 54, DateTimeKind.Utc).AddTicks(9489));

            migrationBuilder.UpdateData(
                table: "Trademarks",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 54, DateTimeKind.Utc).AddTicks(9492));

            migrationBuilder.UpdateData(
                table: "Trademarks",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 54, DateTimeKind.Utc).AddTicks(9495));

            migrationBuilder.UpdateData(
                table: "Trademarks",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 54, DateTimeKind.Utc).AddTicks(9497));

            migrationBuilder.UpdateData(
                table: "Variants",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 56, DateTimeKind.Utc).AddTicks(9386));

            migrationBuilder.UpdateData(
                table: "Variants",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 56, DateTimeKind.Utc).AddTicks(9390));

            migrationBuilder.UpdateData(
                table: "Variants",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 56, DateTimeKind.Utc).AddTicks(9392));

            migrationBuilder.UpdateData(
                table: "Variants",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 56, DateTimeKind.Utc).AddTicks(9395));

            migrationBuilder.UpdateData(
                table: "Variants",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 56, DateTimeKind.Utc).AddTicks(9397));

            migrationBuilder.UpdateData(
                table: "Variants",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 56, DateTimeKind.Utc).AddTicks(9399));

            migrationBuilder.UpdateData(
                table: "Variants",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 56, DateTimeKind.Utc).AddTicks(9401));

            migrationBuilder.UpdateData(
                table: "Variants",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 56, DateTimeKind.Utc).AddTicks(9403));

            migrationBuilder.UpdateData(
                table: "Variants",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 56, DateTimeKind.Utc).AddTicks(9405));
        }
    }
}
