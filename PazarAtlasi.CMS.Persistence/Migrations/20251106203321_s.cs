using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace PazarAtlasi.CMS.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class s : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ParentCategoryId = table.Column<int>(type: "int", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Code = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    IntegrationCode = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Description = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
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
                    table.PrimaryKey("PK_Categories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Categories_Categories_ParentCategoryId",
                        column: x => x.ParentCategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ParentId = table.Column<int>(type: "int", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Code = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    IntegrationCode = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    ShortDescription = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    LongDescription = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: false),
                    Unit = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Type = table.Column<int>(type: "int", nullable: false, defaultValue: 1),
                    TaxRate = table.Column<decimal>(type: "decimal(5,2)", nullable: false, defaultValue: 0m),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<int>(type: "int", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<int>(type: "int", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    Status = table.Column<int>(type: "int", nullable: false, defaultValue: 1)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Products_Products_ParentId",
                        column: x => x.ParentId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Trademarks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ParentId = table.Column<int>(type: "int", nullable: true),
                    Code = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    IntegrationCode = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    ShortDescription = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    LongDescription = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: false),
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
                    table.PrimaryKey("PK_Trademarks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Trademarks_Trademarks_ParentId",
                        column: x => x.ParentId,
                        principalTable: "Trademarks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CategoryTranslations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    LanguageId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    ShortDescription = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    LongDescription = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<int>(type: "int", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<int>(type: "int", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    Status = table.Column<int>(type: "int", nullable: false, defaultValue: 1)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategoryTranslations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CategoryTranslations_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CategoryTranslations_Languages_LanguageId",
                        column: x => x.LanguageId,
                        principalTable: "Languages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CategoryProducts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<int>(type: "int", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<int>(type: "int", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    Status = table.Column<int>(type: "int", nullable: false, defaultValue: 1)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategoryProducts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CategoryProducts_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CategoryProducts_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductTranslations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    LanguageId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    ShortDescription = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    LongDescription = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<int>(type: "int", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<int>(type: "int", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    Status = table.Column<int>(type: "int", nullable: false, defaultValue: 1)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductTranslations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductTranslations_Languages_LanguageId",
                        column: x => x.LanguageId,
                        principalTable: "Languages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ProductTranslations_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Variants",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    IntegrationCode = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    ShortDescription = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    LongDescription = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<int>(type: "int", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<int>(type: "int", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    Status = table.Column<int>(type: "int", nullable: false, defaultValue: 1)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Variants", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Variants_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TrademarkProducts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TrademarkId = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<int>(type: "int", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<int>(type: "int", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    Status = table.Column<int>(type: "int", nullable: false, defaultValue: 1)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrademarkProducts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TrademarkProducts_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TrademarkProducts_Trademarks_TrademarkId",
                        column: x => x.TrademarkId,
                        principalTable: "Trademarks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TrademarkTranslations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TrademarkId = table.Column<int>(type: "int", nullable: false),
                    LanguageId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    ShortDescription = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    LongDescription = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<int>(type: "int", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<int>(type: "int", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    Status = table.Column<int>(type: "int", nullable: false, defaultValue: 1)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrademarkTranslations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TrademarkTranslations_Languages_LanguageId",
                        column: x => x.LanguageId,
                        principalTable: "Languages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TrademarkTranslations_Trademarks_TrademarkId",
                        column: x => x.TrademarkId,
                        principalTable: "Trademarks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "VariantTranslations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VariantId = table.Column<int>(type: "int", nullable: false),
                    LanguageId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    ShortDescription = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    LongDescription = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<int>(type: "int", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<int>(type: "int", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    Status = table.Column<int>(type: "int", nullable: false, defaultValue: 1)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VariantTranslations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_VariantTranslations_Languages_LanguageId",
                        column: x => x.LanguageId,
                        principalTable: "Languages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_VariantTranslations_Variants_VariantId",
                        column: x => x.VariantId,
                        principalTable: "Variants",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Code", "CreatedAt", "CreatedBy", "Description", "IntegrationCode", "Name", "ParentCategoryId", "SortOrder", "Status", "UpdatedAt", "UpdatedBy" },
                values: new object[,]
                {
                    { 1, "elektronik", new DateTime(2024, 1, 1, 10, 0, 0, 0, DateTimeKind.Unspecified), null, "Elektronik ürünler kategorisi", "ELEC", "Elektronik", null, 1, 1, null, null },
                    { 2, "giyim", new DateTime(2024, 1, 1, 10, 0, 0, 0, DateTimeKind.Unspecified), null, "Giyim ve aksesuar kategorisi", "CLTH", "Giyim", null, 2, 1, null, null },
                    { 3, "ev-yasam", new DateTime(2024, 1, 1, 10, 0, 0, 0, DateTimeKind.Unspecified), null, "Ev ve yaşam ürünleri kategorisi", "HOME", "Ev & Yaşam", null, 3, 1, null, null }
                });

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 20, 33, 18, 286, DateTimeKind.Utc).AddTicks(439));

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 20, 33, 18, 286, DateTimeKind.Utc).AddTicks(443));

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 20, 33, 18, 286, DateTimeKind.Utc).AddTicks(446));

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 20, 33, 18, 286, DateTimeKind.Utc).AddTicks(448));

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 20, 33, 18, 286, DateTimeKind.Utc).AddTicks(450));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 20, 33, 18, 286, DateTimeKind.Utc).AddTicks(6723));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 20, 33, 18, 286, DateTimeKind.Utc).AddTicks(6727));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 20, 33, 18, 286, DateTimeKind.Utc).AddTicks(6729));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 20, 33, 18, 286, DateTimeKind.Utc).AddTicks(6730));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 20, 33, 18, 286, DateTimeKind.Utc).AddTicks(6731));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 20, 33, 18, 286, DateTimeKind.Utc).AddTicks(6733));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 20, 33, 18, 286, DateTimeKind.Utc).AddTicks(6734));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 20, 33, 18, 286, DateTimeKind.Utc).AddTicks(6735));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 20, 33, 18, 286, DateTimeKind.Utc).AddTicks(6736));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 20, 33, 18, 286, DateTimeKind.Utc).AddTicks(6738));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 20, 33, 18, 286, DateTimeKind.Utc).AddTicks(6739));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 20, 33, 18, 286, DateTimeKind.Utc).AddTicks(6740));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 20, 33, 18, 286, DateTimeKind.Utc).AddTicks(6741));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 20, 33, 18, 286, DateTimeKind.Utc).AddTicks(6742));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 20, 33, 18, 286, DateTimeKind.Utc).AddTicks(6743));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 16,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 20, 33, 18, 286, DateTimeKind.Utc).AddTicks(6744));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 17,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 20, 33, 18, 286, DateTimeKind.Utc).AddTicks(6745));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 18,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 20, 33, 18, 286, DateTimeKind.Utc).AddTicks(6746));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 19,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 20, 33, 18, 286, DateTimeKind.Utc).AddTicks(6747));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 20,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 20, 33, 18, 286, DateTimeKind.Utc).AddTicks(6748));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 21,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 20, 33, 18, 286, DateTimeKind.Utc).AddTicks(6749));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 22,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 20, 33, 18, 286, DateTimeKind.Utc).AddTicks(6779));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 23,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 20, 33, 18, 286, DateTimeKind.Utc).AddTicks(6780));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 24,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 20, 33, 18, 286, DateTimeKind.Utc).AddTicks(6781));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 25,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 20, 33, 18, 286, DateTimeKind.Utc).AddTicks(6782));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 26,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 20, 33, 18, 286, DateTimeKind.Utc).AddTicks(6783));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 27,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 20, 33, 18, 286, DateTimeKind.Utc).AddTicks(6784));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 28,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 20, 33, 18, 286, DateTimeKind.Utc).AddTicks(6785));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 29,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 20, 33, 18, 286, DateTimeKind.Utc).AddTicks(6786));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 30,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 20, 33, 18, 286, DateTimeKind.Utc).AddTicks(6787));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 31,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 20, 33, 18, 286, DateTimeKind.Utc).AddTicks(6788));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 32,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 20, 33, 18, 286, DateTimeKind.Utc).AddTicks(6789));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 33,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 20, 33, 18, 286, DateTimeKind.Utc).AddTicks(6790));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 34,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 20, 33, 18, 286, DateTimeKind.Utc).AddTicks(6792));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 35,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 20, 33, 18, 286, DateTimeKind.Utc).AddTicks(6793));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 36,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 20, 33, 18, 286, DateTimeKind.Utc).AddTicks(6794));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 37,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 20, 33, 18, 286, DateTimeKind.Utc).AddTicks(6795));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 38,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 20, 33, 18, 286, DateTimeKind.Utc).AddTicks(6796));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 39,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 20, 33, 18, 286, DateTimeKind.Utc).AddTicks(6799));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 40,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 20, 33, 18, 286, DateTimeKind.Utc).AddTicks(6801));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 41,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 20, 33, 18, 286, DateTimeKind.Utc).AddTicks(6802));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 42,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 20, 33, 18, 286, DateTimeKind.Utc).AddTicks(6803));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 43,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 20, 33, 18, 286, DateTimeKind.Utc).AddTicks(6804));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 44,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 20, 33, 18, 286, DateTimeKind.Utc).AddTicks(6805));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 45,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 20, 33, 18, 286, DateTimeKind.Utc).AddTicks(6806));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 46,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 20, 33, 18, 286, DateTimeKind.Utc).AddTicks(6807));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 47,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 20, 33, 18, 286, DateTimeKind.Utc).AddTicks(6808));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 48,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 20, 33, 18, 286, DateTimeKind.Utc).AddTicks(6809));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 49,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 20, 33, 18, 286, DateTimeKind.Utc).AddTicks(6810));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 50,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 20, 33, 18, 286, DateTimeKind.Utc).AddTicks(6811));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 51,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 20, 33, 18, 286, DateTimeKind.Utc).AddTicks(6812));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 52,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 20, 33, 18, 286, DateTimeKind.Utc).AddTicks(6813));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 53,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 20, 33, 18, 286, DateTimeKind.Utc).AddTicks(6813));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 54,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 20, 33, 18, 286, DateTimeKind.Utc).AddTicks(6816));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 55,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 20, 33, 18, 286, DateTimeKind.Utc).AddTicks(6817));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 56,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 20, 33, 18, 286, DateTimeKind.Utc).AddTicks(6818));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 57,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 20, 33, 18, 286, DateTimeKind.Utc).AddTicks(6843));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 58,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 20, 33, 18, 286, DateTimeKind.Utc).AddTicks(6844));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 59,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 20, 33, 18, 286, DateTimeKind.Utc).AddTicks(6845));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 60,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 20, 33, 18, 286, DateTimeKind.Utc).AddTicks(6846));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 61,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 20, 33, 18, 286, DateTimeKind.Utc).AddTicks(6847));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 62,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 20, 33, 18, 286, DateTimeKind.Utc).AddTicks(6848));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 63,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 20, 33, 18, 286, DateTimeKind.Utc).AddTicks(6849));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 64,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 20, 33, 18, 286, DateTimeKind.Utc).AddTicks(6850));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 65,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 20, 33, 18, 286, DateTimeKind.Utc).AddTicks(6852));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 66,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 20, 33, 18, 286, DateTimeKind.Utc).AddTicks(6854));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 67,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 20, 33, 18, 286, DateTimeKind.Utc).AddTicks(6855));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 68,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 20, 33, 18, 286, DateTimeKind.Utc).AddTicks(6856));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 69,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 20, 33, 18, 286, DateTimeKind.Utc).AddTicks(6857));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 70,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 20, 33, 18, 286, DateTimeKind.Utc).AddTicks(6859));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 71,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 20, 33, 18, 286, DateTimeKind.Utc).AddTicks(6861));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 72,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 20, 33, 18, 286, DateTimeKind.Utc).AddTicks(6862));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 73,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 20, 33, 18, 286, DateTimeKind.Utc).AddTicks(6863));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 74,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 20, 33, 18, 286, DateTimeKind.Utc).AddTicks(6864));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 75,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 20, 33, 18, 286, DateTimeKind.Utc).AddTicks(6865));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 76,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 20, 33, 18, 286, DateTimeKind.Utc).AddTicks(6866));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 77,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 20, 33, 18, 286, DateTimeKind.Utc).AddTicks(6867));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 78,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 20, 33, 18, 286, DateTimeKind.Utc).AddTicks(6868));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 79,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 20, 33, 18, 286, DateTimeKind.Utc).AddTicks(6870));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 80,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 20, 33, 18, 286, DateTimeKind.Utc).AddTicks(6873));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 81,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 20, 33, 18, 286, DateTimeKind.Utc).AddTicks(6874));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 82,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 20, 33, 18, 286, DateTimeKind.Utc).AddTicks(6875));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 83,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 20, 33, 18, 286, DateTimeKind.Utc).AddTicks(6876));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 84,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 20, 33, 18, 286, DateTimeKind.Utc).AddTicks(6877));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 85,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 20, 33, 18, 286, DateTimeKind.Utc).AddTicks(6878));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 86,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 20, 33, 18, 286, DateTimeKind.Utc).AddTicks(6879));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 87,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 20, 33, 18, 286, DateTimeKind.Utc).AddTicks(6880));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 88,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 20, 33, 18, 286, DateTimeKind.Utc).AddTicks(6881));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 89,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 20, 33, 18, 286, DateTimeKind.Utc).AddTicks(6905));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 90,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 20, 33, 18, 286, DateTimeKind.Utc).AddTicks(6906));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 91,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 20, 33, 18, 286, DateTimeKind.Utc).AddTicks(6907));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 92,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 20, 33, 18, 286, DateTimeKind.Utc).AddTicks(6908));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 93,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 20, 33, 18, 286, DateTimeKind.Utc).AddTicks(6909));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 94,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 20, 33, 18, 286, DateTimeKind.Utc).AddTicks(6910));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 95,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 20, 33, 18, 286, DateTimeKind.Utc).AddTicks(6911));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 96,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 20, 33, 18, 286, DateTimeKind.Utc).AddTicks(6912));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 97,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 20, 33, 18, 286, DateTimeKind.Utc).AddTicks(6913));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 98,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 20, 33, 18, 286, DateTimeKind.Utc).AddTicks(6914));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 99,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 20, 33, 18, 286, DateTimeKind.Utc).AddTicks(6915));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 100,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 20, 33, 18, 286, DateTimeKind.Utc).AddTicks(6916));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 101,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 20, 33, 18, 286, DateTimeKind.Utc).AddTicks(6917));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 102,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 20, 33, 18, 286, DateTimeKind.Utc).AddTicks(6918));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 103,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 20, 33, 18, 286, DateTimeKind.Utc).AddTicks(6919));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 104,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 20, 33, 18, 286, DateTimeKind.Utc).AddTicks(6920));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 105,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 20, 33, 18, 286, DateTimeKind.Utc).AddTicks(6921));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 106,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 20, 33, 18, 286, DateTimeKind.Utc).AddTicks(6922));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 107,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 20, 33, 18, 286, DateTimeKind.Utc).AddTicks(6923));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 108,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 20, 33, 18, 286, DateTimeKind.Utc).AddTicks(6924));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 109,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 20, 33, 18, 286, DateTimeKind.Utc).AddTicks(6927));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 110,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 20, 33, 18, 286, DateTimeKind.Utc).AddTicks(6928));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 111,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 20, 33, 18, 286, DateTimeKind.Utc).AddTicks(6931));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 112,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 20, 33, 18, 286, DateTimeKind.Utc).AddTicks(6933));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 113,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 20, 33, 18, 286, DateTimeKind.Utc).AddTicks(6933));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 114,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 20, 33, 18, 286, DateTimeKind.Utc).AddTicks(6935));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 115,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 20, 33, 18, 286, DateTimeKind.Utc).AddTicks(6935));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 116,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 20, 33, 18, 286, DateTimeKind.Utc).AddTicks(6936));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 117,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 20, 33, 18, 286, DateTimeKind.Utc).AddTicks(6937));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 118,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 20, 33, 18, 286, DateTimeKind.Utc).AddTicks(6938));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 119,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 20, 33, 18, 286, DateTimeKind.Utc).AddTicks(6939));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 120,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 20, 33, 18, 286, DateTimeKind.Utc).AddTicks(6940));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 121,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 20, 33, 18, 286, DateTimeKind.Utc).AddTicks(6941));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 122,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 20, 33, 18, 286, DateTimeKind.Utc).AddTicks(6942));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 123,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 20, 33, 18, 286, DateTimeKind.Utc).AddTicks(6943));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 124,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 20, 33, 18, 286, DateTimeKind.Utc).AddTicks(6970));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 125,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 20, 33, 18, 286, DateTimeKind.Utc).AddTicks(6971));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 126,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 20, 33, 18, 286, DateTimeKind.Utc).AddTicks(6972));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 127,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 20, 33, 18, 286, DateTimeKind.Utc).AddTicks(6973));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 128,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 20, 33, 18, 286, DateTimeKind.Utc).AddTicks(6974));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 129,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 20, 33, 18, 286, DateTimeKind.Utc).AddTicks(6975));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 130,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 20, 33, 18, 286, DateTimeKind.Utc).AddTicks(6978));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 131,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 20, 33, 18, 286, DateTimeKind.Utc).AddTicks(6979));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 132,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 20, 33, 18, 286, DateTimeKind.Utc).AddTicks(6980));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 133,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 20, 33, 18, 286, DateTimeKind.Utc).AddTicks(6981));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 134,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 20, 33, 18, 286, DateTimeKind.Utc).AddTicks(6982));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 135,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 20, 33, 18, 286, DateTimeKind.Utc).AddTicks(6983));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 136,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 20, 33, 18, 286, DateTimeKind.Utc).AddTicks(6984));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 137,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 20, 33, 18, 286, DateTimeKind.Utc).AddTicks(6985));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 138,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 20, 33, 18, 286, DateTimeKind.Utc).AddTicks(6986));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 139,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 20, 33, 18, 286, DateTimeKind.Utc).AddTicks(6989));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 140,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 20, 33, 18, 286, DateTimeKind.Utc).AddTicks(6990));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 141,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 20, 33, 18, 286, DateTimeKind.Utc).AddTicks(6991));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 142,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 20, 33, 18, 286, DateTimeKind.Utc).AddTicks(6992));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 143,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 20, 33, 18, 286, DateTimeKind.Utc).AddTicks(6993));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 144,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 20, 33, 18, 286, DateTimeKind.Utc).AddTicks(6994));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 145,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 20, 33, 18, 286, DateTimeKind.Utc).AddTicks(6995));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 146,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 20, 33, 18, 286, DateTimeKind.Utc).AddTicks(6996));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 147,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 20, 33, 18, 286, DateTimeKind.Utc).AddTicks(6997));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 148,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 20, 33, 18, 286, DateTimeKind.Utc).AddTicks(6998));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 149,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 20, 33, 18, 286, DateTimeKind.Utc).AddTicks(6999));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 150,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 20, 33, 18, 286, DateTimeKind.Utc).AddTicks(7022));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 151,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 20, 33, 18, 286, DateTimeKind.Utc).AddTicks(7023));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 152,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 20, 33, 18, 286, DateTimeKind.Utc).AddTicks(7024));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 153,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 20, 33, 18, 286, DateTimeKind.Utc).AddTicks(7025));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 154,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 20, 33, 18, 286, DateTimeKind.Utc).AddTicks(7026));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 155,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 20, 33, 18, 286, DateTimeKind.Utc).AddTicks(7027));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 156,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 20, 33, 18, 286, DateTimeKind.Utc).AddTicks(7028));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 157,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 20, 33, 18, 286, DateTimeKind.Utc).AddTicks(7029));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 158,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 20, 33, 18, 286, DateTimeKind.Utc).AddTicks(7030));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 159,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 20, 33, 18, 286, DateTimeKind.Utc).AddTicks(7030));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 160,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 20, 33, 18, 286, DateTimeKind.Utc).AddTicks(7031));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 161,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 20, 33, 18, 286, DateTimeKind.Utc).AddTicks(7032));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 162,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 20, 33, 18, 286, DateTimeKind.Utc).AddTicks(7033));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 163,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 20, 33, 18, 286, DateTimeKind.Utc).AddTicks(7034));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 164,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 20, 33, 18, 286, DateTimeKind.Utc).AddTicks(7041));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 165,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 20, 33, 18, 286, DateTimeKind.Utc).AddTicks(7042));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 166,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 20, 33, 18, 286, DateTimeKind.Utc).AddTicks(7043));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 167,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 20, 33, 18, 286, DateTimeKind.Utc).AddTicks(7044));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 168,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 20, 33, 18, 286, DateTimeKind.Utc).AddTicks(7045));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 169,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 20, 33, 18, 286, DateTimeKind.Utc).AddTicks(7046));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 170,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 20, 33, 18, 286, DateTimeKind.Utc).AddTicks(7047));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 171,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 20, 33, 18, 286, DateTimeKind.Utc).AddTicks(7048));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 172,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 20, 33, 18, 286, DateTimeKind.Utc).AddTicks(7049));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 173,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 20, 33, 18, 286, DateTimeKind.Utc).AddTicks(7049));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 174,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 20, 33, 18, 286, DateTimeKind.Utc).AddTicks(7050));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 175,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 20, 33, 18, 286, DateTimeKind.Utc).AddTicks(7052));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 176,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 20, 33, 18, 286, DateTimeKind.Utc).AddTicks(7053));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 177,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 20, 33, 18, 286, DateTimeKind.Utc).AddTicks(7053));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 178,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 20, 33, 18, 286, DateTimeKind.Utc).AddTicks(7054));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 179,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 20, 33, 18, 286, DateTimeKind.Utc).AddTicks(7055));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 180,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 20, 33, 18, 286, DateTimeKind.Utc).AddTicks(7056));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 181,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 20, 33, 18, 286, DateTimeKind.Utc).AddTicks(7057));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 182,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 20, 33, 18, 286, DateTimeKind.Utc).AddTicks(7058));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 183,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 20, 33, 18, 286, DateTimeKind.Utc).AddTicks(7059));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 184,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 20, 33, 18, 286, DateTimeKind.Utc).AddTicks(7060));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 185,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 20, 33, 18, 286, DateTimeKind.Utc).AddTicks(7060));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 186,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 20, 33, 18, 286, DateTimeKind.Utc).AddTicks(7082));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 187,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 20, 33, 18, 286, DateTimeKind.Utc).AddTicks(7083));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 188,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 20, 33, 18, 286, DateTimeKind.Utc).AddTicks(7084));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 189,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 20, 33, 18, 286, DateTimeKind.Utc).AddTicks(7085));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 190,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 20, 33, 18, 286, DateTimeKind.Utc).AddTicks(7086));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 191,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 20, 33, 18, 286, DateTimeKind.Utc).AddTicks(7087));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 192,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 20, 33, 18, 286, DateTimeKind.Utc).AddTicks(7088));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 193,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 20, 33, 18, 286, DateTimeKind.Utc).AddTicks(7088));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 194,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 20, 33, 18, 286, DateTimeKind.Utc).AddTicks(7089));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 195,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 20, 33, 18, 286, DateTimeKind.Utc).AddTicks(7090));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 196,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 20, 33, 18, 286, DateTimeKind.Utc).AddTicks(7091));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 197,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 20, 33, 18, 286, DateTimeKind.Utc).AddTicks(7092));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 198,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 20, 33, 18, 286, DateTimeKind.Utc).AddTicks(7093));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 199,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 20, 33, 18, 286, DateTimeKind.Utc).AddTicks(7094));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 200,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 20, 33, 18, 286, DateTimeKind.Utc).AddTicks(7095));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 201,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 20, 33, 18, 286, DateTimeKind.Utc).AddTicks(7096));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 202,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 20, 33, 18, 286, DateTimeKind.Utc).AddTicks(7099));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 203,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 20, 33, 18, 286, DateTimeKind.Utc).AddTicks(7100));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 204,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 20, 33, 18, 286, DateTimeKind.Utc).AddTicks(7101));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 205,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 20, 33, 18, 286, DateTimeKind.Utc).AddTicks(7102));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 206,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 20, 33, 18, 286, DateTimeKind.Utc).AddTicks(7103));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 207,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 20, 33, 18, 286, DateTimeKind.Utc).AddTicks(7104));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 208,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 20, 33, 18, 286, DateTimeKind.Utc).AddTicks(7105));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 209,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 20, 33, 18, 286, DateTimeKind.Utc).AddTicks(7106));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 210,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 20, 33, 18, 286, DateTimeKind.Utc).AddTicks(7107));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 211,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 20, 33, 18, 286, DateTimeKind.Utc).AddTicks(7108));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 212,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 20, 33, 18, 286, DateTimeKind.Utc).AddTicks(7109));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 213,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 20, 33, 18, 286, DateTimeKind.Utc).AddTicks(7110));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 214,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 20, 33, 18, 286, DateTimeKind.Utc).AddTicks(7111));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 215,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 20, 33, 18, 286, DateTimeKind.Utc).AddTicks(7112));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 216,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 20, 33, 18, 286, DateTimeKind.Utc).AddTicks(7113));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 217,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 20, 33, 18, 286, DateTimeKind.Utc).AddTicks(7115));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 218,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 20, 33, 18, 286, DateTimeKind.Utc).AddTicks(7117));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 219,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 20, 33, 18, 286, DateTimeKind.Utc).AddTicks(7118));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 220,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 20, 33, 18, 286, DateTimeKind.Utc).AddTicks(7119));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 221,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 20, 33, 18, 286, DateTimeKind.Utc).AddTicks(7120));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 222,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 20, 33, 18, 286, DateTimeKind.Utc).AddTicks(7121));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 223,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 20, 33, 18, 286, DateTimeKind.Utc).AddTicks(7136));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 224,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 20, 33, 18, 286, DateTimeKind.Utc).AddTicks(7138));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 225,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 20, 33, 18, 286, DateTimeKind.Utc).AddTicks(7139));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 226,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 20, 33, 18, 286, DateTimeKind.Utc).AddTicks(7140));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 227,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 20, 33, 18, 286, DateTimeKind.Utc).AddTicks(7141));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 228,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 20, 33, 18, 286, DateTimeKind.Utc).AddTicks(7142));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 229,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 20, 33, 18, 286, DateTimeKind.Utc).AddTicks(7143));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 230,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 20, 33, 18, 286, DateTimeKind.Utc).AddTicks(7144));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 231,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 20, 33, 18, 286, DateTimeKind.Utc).AddTicks(7145));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 232,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 20, 33, 18, 286, DateTimeKind.Utc).AddTicks(7146));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 233,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 20, 33, 18, 286, DateTimeKind.Utc).AddTicks(7149));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 234,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 20, 33, 18, 286, DateTimeKind.Utc).AddTicks(7150));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 235,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 20, 33, 18, 286, DateTimeKind.Utc).AddTicks(7151));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 236,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 20, 33, 18, 286, DateTimeKind.Utc).AddTicks(7152));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 237,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 20, 33, 18, 286, DateTimeKind.Utc).AddTicks(7153));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 238,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 20, 33, 18, 286, DateTimeKind.Utc).AddTicks(7154));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 239,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 20, 33, 18, 286, DateTimeKind.Utc).AddTicks(7155));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 240,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 20, 33, 18, 286, DateTimeKind.Utc).AddTicks(7156));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 241,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 20, 33, 18, 286, DateTimeKind.Utc).AddTicks(7157));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 242,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 20, 33, 18, 286, DateTimeKind.Utc).AddTicks(7158));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 243,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 20, 33, 18, 286, DateTimeKind.Utc).AddTicks(7161));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 244,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 20, 33, 18, 286, DateTimeKind.Utc).AddTicks(7162));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 245,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 20, 33, 18, 286, DateTimeKind.Utc).AddTicks(7163));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 246,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 20, 33, 18, 286, DateTimeKind.Utc).AddTicks(7164));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 247,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 20, 33, 18, 286, DateTimeKind.Utc).AddTicks(7165));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 248,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 20, 33, 18, 286, DateTimeKind.Utc).AddTicks(7166));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 249,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 20, 33, 18, 286, DateTimeKind.Utc).AddTicks(7167));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 250,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 20, 33, 18, 286, DateTimeKind.Utc).AddTicks(7169));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 251,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 20, 33, 18, 286, DateTimeKind.Utc).AddTicks(7169));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 252,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 20, 33, 18, 286, DateTimeKind.Utc).AddTicks(7170));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 253,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 20, 33, 18, 286, DateTimeKind.Utc).AddTicks(7171));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 254,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 20, 33, 18, 286, DateTimeKind.Utc).AddTicks(7173));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 255,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 20, 33, 18, 286, DateTimeKind.Utc).AddTicks(7173));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 256,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 20, 33, 18, 286, DateTimeKind.Utc).AddTicks(7175));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 257,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 20, 33, 18, 286, DateTimeKind.Utc).AddTicks(7175));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 258,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 20, 33, 18, 286, DateTimeKind.Utc).AddTicks(7209));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 259,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 20, 33, 18, 286, DateTimeKind.Utc).AddTicks(7210));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 260,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 20, 33, 18, 286, DateTimeKind.Utc).AddTicks(7211));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 261,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 20, 33, 18, 286, DateTimeKind.Utc).AddTicks(7212));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 262,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 20, 33, 18, 286, DateTimeKind.Utc).AddTicks(7213));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 263,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 20, 33, 18, 286, DateTimeKind.Utc).AddTicks(7214));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 264,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 20, 33, 18, 286, DateTimeKind.Utc).AddTicks(7214));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 265,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 20, 33, 18, 286, DateTimeKind.Utc).AddTicks(7215));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 266,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 20, 33, 18, 286, DateTimeKind.Utc).AddTicks(7216));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 267,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 20, 33, 18, 286, DateTimeKind.Utc).AddTicks(7217));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 268,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 20, 33, 18, 286, DateTimeKind.Utc).AddTicks(7218));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 269,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 20, 33, 18, 286, DateTimeKind.Utc).AddTicks(7219));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 270,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 20, 33, 18, 286, DateTimeKind.Utc).AddTicks(7220));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 271,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 20, 33, 18, 286, DateTimeKind.Utc).AddTicks(7221));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 272,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 20, 33, 18, 286, DateTimeKind.Utc).AddTicks(7224));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 273,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 20, 33, 18, 286, DateTimeKind.Utc).AddTicks(7226));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 274,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 20, 33, 18, 286, DateTimeKind.Utc).AddTicks(7228));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 275,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 20, 33, 18, 286, DateTimeKind.Utc).AddTicks(7258));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 276,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 20, 33, 18, 286, DateTimeKind.Utc).AddTicks(7259));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 277,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 20, 33, 18, 286, DateTimeKind.Utc).AddTicks(7261));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 278,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 20, 33, 18, 286, DateTimeKind.Utc).AddTicks(7262));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 279,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 20, 33, 18, 286, DateTimeKind.Utc).AddTicks(7263));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 280,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 20, 33, 18, 286, DateTimeKind.Utc).AddTicks(7264));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 281,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 20, 33, 18, 286, DateTimeKind.Utc).AddTicks(7264));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 282,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 20, 33, 18, 286, DateTimeKind.Utc).AddTicks(7265));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 283,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 20, 33, 18, 286, DateTimeKind.Utc).AddTicks(7266));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 284,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 20, 33, 18, 286, DateTimeKind.Utc).AddTicks(7267));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 285,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 20, 33, 18, 286, DateTimeKind.Utc).AddTicks(7268));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 286,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 20, 33, 18, 286, DateTimeKind.Utc).AddTicks(7269));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 287,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 20, 33, 18, 286, DateTimeKind.Utc).AddTicks(7270));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 288,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 20, 33, 18, 286, DateTimeKind.Utc).AddTicks(7271));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 289,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 20, 33, 18, 286, DateTimeKind.Utc).AddTicks(7272));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 290,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 20, 33, 18, 286, DateTimeKind.Utc).AddTicks(7273));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 291,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 20, 33, 18, 286, DateTimeKind.Utc).AddTicks(7274));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 292,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 20, 33, 18, 286, DateTimeKind.Utc).AddTicks(7275));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 293,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 20, 33, 18, 286, DateTimeKind.Utc).AddTicks(7276));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 294,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 20, 33, 18, 286, DateTimeKind.Utc).AddTicks(7277));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 295,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 20, 33, 18, 286, DateTimeKind.Utc).AddTicks(7278));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 296,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 20, 33, 18, 286, DateTimeKind.Utc).AddTicks(7279));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 297,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 20, 33, 18, 286, DateTimeKind.Utc).AddTicks(7280));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 298,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 20, 33, 18, 286, DateTimeKind.Utc).AddTicks(7280));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 299,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 20, 33, 18, 286, DateTimeKind.Utc).AddTicks(7281));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 300,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 20, 33, 18, 286, DateTimeKind.Utc).AddTicks(7282));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 301,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 20, 33, 18, 286, DateTimeKind.Utc).AddTicks(7283));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 302,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 20, 33, 18, 286, DateTimeKind.Utc).AddTicks(7286));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 303,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 20, 33, 18, 286, DateTimeKind.Utc).AddTicks(7288));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 304,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 20, 33, 18, 286, DateTimeKind.Utc).AddTicks(7289));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 305,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 20, 33, 18, 286, DateTimeKind.Utc).AddTicks(7290));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 306,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 20, 33, 18, 286, DateTimeKind.Utc).AddTicks(7290));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 307,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 20, 33, 18, 286, DateTimeKind.Utc).AddTicks(7291));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 308,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 20, 33, 18, 286, DateTimeKind.Utc).AddTicks(7292));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 309,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 20, 33, 18, 286, DateTimeKind.Utc).AddTicks(7293));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 310,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 20, 33, 18, 286, DateTimeKind.Utc).AddTicks(7315));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 311,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 20, 33, 18, 286, DateTimeKind.Utc).AddTicks(7316));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 312,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 20, 33, 18, 286, DateTimeKind.Utc).AddTicks(7317));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 313,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 20, 33, 18, 286, DateTimeKind.Utc).AddTicks(7318));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 314,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 20, 33, 18, 286, DateTimeKind.Utc).AddTicks(7319));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 315,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 20, 33, 18, 286, DateTimeKind.Utc).AddTicks(7320));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 316,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 20, 33, 18, 286, DateTimeKind.Utc).AddTicks(7321));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 317,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 20, 33, 18, 286, DateTimeKind.Utc).AddTicks(7322));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 318,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 20, 33, 18, 286, DateTimeKind.Utc).AddTicks(7323));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 319,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 20, 33, 18, 286, DateTimeKind.Utc).AddTicks(7324));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 320,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 20, 33, 18, 286, DateTimeKind.Utc).AddTicks(7325));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 321,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 20, 33, 18, 286, DateTimeKind.Utc).AddTicks(7326));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 322,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 20, 33, 18, 286, DateTimeKind.Utc).AddTicks(7327));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 323,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 20, 33, 18, 286, DateTimeKind.Utc).AddTicks(7327));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 324,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 20, 33, 18, 286, DateTimeKind.Utc).AddTicks(7329));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 325,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 20, 33, 18, 286, DateTimeKind.Utc).AddTicks(7330));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 326,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 20, 33, 18, 286, DateTimeKind.Utc).AddTicks(7331));

            migrationBuilder.InsertData(
                table: "LocalizationValues",
                columns: new[] { "Id", "Category", "CreatedAt", "CreatedBy", "Description", "IsActive", "Key", "LanguageId", "Status", "UpdatedAt", "UpdatedBy", "Value" },
                values: new object[,]
                {
                    { 327, "Product", new DateTime(2025, 11, 6, 20, 33, 18, 286, DateTimeKind.Utc).AddTicks(7386), null, "Turkish translation for Navigation.ProductManagement", true, "Navigation.ProductManagement", 1, 0, null, null, "Ürün Yönetimi" },
                    { 328, "Product", new DateTime(2025, 11, 6, 20, 33, 18, 286, DateTimeKind.Utc).AddTicks(7388), null, "Turkish translation for Navigation.Variants", true, "Navigation.Variants", 1, 0, null, null, "Varyantlar" },
                    { 329, "Product", new DateTime(2025, 11, 6, 20, 33, 18, 286, DateTimeKind.Utc).AddTicks(7389), null, "Turkish translation for Navigation.Trademarks", true, "Navigation.Trademarks", 1, 0, null, null, "Markalar" },
                    { 330, "Product", new DateTime(2025, 11, 6, 20, 33, 18, 286, DateTimeKind.Utc).AddTicks(7390), null, "Turkish translation for Navigation.Cart", true, "Navigation.Cart", 1, 0, null, null, "Sepet" },
                    { 331, "Product", new DateTime(2025, 11, 6, 20, 33, 18, 286, DateTimeKind.Utc).AddTicks(7392), null, "Turkish translation for Navigation.Payments", true, "Navigation.Payments", 1, 0, null, null, "Ödemeler" },
                    { 332, "Product", new DateTime(2025, 11, 6, 20, 33, 18, 286, DateTimeKind.Utc).AddTicks(7393), null, "Turkish translation for Product.Name", true, "Product.Name", 1, 0, null, null, "Ürün Adı" },
                    { 333, "Product", new DateTime(2025, 11, 6, 20, 33, 18, 286, DateTimeKind.Utc).AddTicks(7394), null, "Turkish translation for Product.Code", true, "Product.Code", 1, 0, null, null, "Ürün Kodu" },
                    { 334, "Product", new DateTime(2025, 11, 6, 20, 33, 18, 286, DateTimeKind.Utc).AddTicks(7394), null, "Turkish translation for Product.IntegrationCode", true, "Product.IntegrationCode", 1, 0, null, null, "Entegrasyon Kodu" },
                    { 335, "Product", new DateTime(2025, 11, 6, 20, 33, 18, 286, DateTimeKind.Utc).AddTicks(7395), null, "Turkish translation for Product.ShortDescription", true, "Product.ShortDescription", 1, 0, null, null, "Kısa Açıklama" },
                    { 336, "Product", new DateTime(2025, 11, 6, 20, 33, 18, 286, DateTimeKind.Utc).AddTicks(7396), null, "Turkish translation for Product.LongDescription", true, "Product.LongDescription", 1, 0, null, null, "Uzun Açıklama" },
                    { 337, "Product", new DateTime(2025, 11, 6, 20, 33, 18, 286, DateTimeKind.Utc).AddTicks(7397), null, "Turkish translation for Product.Unit", true, "Product.Unit", 1, 0, null, null, "Birim" },
                    { 338, "Product", new DateTime(2025, 11, 6, 20, 33, 18, 286, DateTimeKind.Utc).AddTicks(7398), null, "Turkish translation for Product.Type", true, "Product.Type", 1, 0, null, null, "Ürün Tipi" },
                    { 339, "Product", new DateTime(2025, 11, 6, 20, 33, 18, 286, DateTimeKind.Utc).AddTicks(7399), null, "Turkish translation for Product.TaxRate", true, "Product.TaxRate", 1, 0, null, null, "Vergi Oranı" },
                    { 340, "Product", new DateTime(2025, 11, 6, 20, 33, 18, 286, DateTimeKind.Utc).AddTicks(7400), null, "Turkish translation for Product.Parent", true, "Product.Parent", 1, 0, null, null, "Üst Ürün" },
                    { 341, "Product", new DateTime(2025, 11, 6, 20, 33, 18, 286, DateTimeKind.Utc).AddTicks(7401), null, "Turkish translation for Product.Variants", true, "Product.Variants", 1, 0, null, null, "Varyantlar" },
                    { 342, "Product", new DateTime(2025, 11, 6, 20, 33, 18, 286, DateTimeKind.Utc).AddTicks(7403), null, "Turkish translation for Product.Categories", true, "Product.Categories", 1, 0, null, null, "Kategoriler" },
                    { 343, "Product", new DateTime(2025, 11, 6, 20, 33, 18, 286, DateTimeKind.Utc).AddTicks(7403), null, "Turkish translation for Product.Trademarks", true, "Product.Trademarks", 1, 0, null, null, "Markalar" },
                    { 344, "Product", new DateTime(2025, 11, 6, 20, 33, 18, 286, DateTimeKind.Utc).AddTicks(7404), null, "Turkish translation for Product.CreateNew", true, "Product.CreateNew", 1, 0, null, null, "Yeni Ürün Oluştur" },
                    { 345, "Product", new DateTime(2025, 11, 6, 20, 33, 18, 286, DateTimeKind.Utc).AddTicks(7406), null, "Turkish translation for Product.EditProduct", true, "Product.EditProduct", 1, 0, null, null, "Ürün Düzenle" },
                    { 346, "Product", new DateTime(2025, 11, 6, 20, 33, 18, 286, DateTimeKind.Utc).AddTicks(7407), null, "Turkish translation for Product.DeleteProduct", true, "Product.DeleteProduct", 1, 0, null, null, "Ürün Sil" },
                    { 347, "Product", new DateTime(2025, 11, 6, 20, 33, 18, 286, DateTimeKind.Utc).AddTicks(7407), null, "Turkish translation for Product.ProductDetails", true, "Product.ProductDetails", 1, 0, null, null, "Ürün Detayları" },
                    { 348, "Product", new DateTime(2025, 11, 6, 20, 33, 18, 286, DateTimeKind.Utc).AddTicks(7408), null, "Turkish translation for Variant.Name", true, "Variant.Name", 1, 0, null, null, "Varyant Adı" },
                    { 349, "Product", new DateTime(2025, 11, 6, 20, 33, 18, 286, DateTimeKind.Utc).AddTicks(7409), null, "Turkish translation for Variant.Code", true, "Variant.Code", 1, 0, null, null, "Varyant Kodu" },
                    { 350, "Product", new DateTime(2025, 11, 6, 20, 33, 18, 286, DateTimeKind.Utc).AddTicks(7410), null, "Turkish translation for Variant.Product", true, "Variant.Product", 1, 0, null, null, "Ürün" },
                    { 351, "Product", new DateTime(2025, 11, 6, 20, 33, 18, 286, DateTimeKind.Utc).AddTicks(7411), null, "Turkish translation for Variant.CreateNew", true, "Variant.CreateNew", 1, 0, null, null, "Yeni Varyant Oluştur" },
                    { 352, "Product", new DateTime(2025, 11, 6, 20, 33, 18, 286, DateTimeKind.Utc).AddTicks(7412), null, "Turkish translation for Variant.EditVariant", true, "Variant.EditVariant", 1, 0, null, null, "Varyant Düzenle" },
                    { 353, "Product", new DateTime(2025, 11, 6, 20, 33, 18, 286, DateTimeKind.Utc).AddTicks(7413), null, "Turkish translation for Variant.DeleteVariant", true, "Variant.DeleteVariant", 1, 0, null, null, "Varyant Sil" },
                    { 354, "Product", new DateTime(2025, 11, 6, 20, 33, 18, 286, DateTimeKind.Utc).AddTicks(7414), null, "Turkish translation for Trademark.Name", true, "Trademark.Name", 1, 0, null, null, "Marka Adı" },
                    { 355, "Product", new DateTime(2025, 11, 6, 20, 33, 18, 286, DateTimeKind.Utc).AddTicks(7415), null, "Turkish translation for Trademark.Code", true, "Trademark.Code", 1, 0, null, null, "Marka Kodu" },
                    { 356, "Product", new DateTime(2025, 11, 6, 20, 33, 18, 286, DateTimeKind.Utc).AddTicks(7415), null, "Turkish translation for Trademark.SortOrder", true, "Trademark.SortOrder", 1, 0, null, null, "Sıralama" },
                    { 357, "Product", new DateTime(2025, 11, 6, 20, 33, 18, 286, DateTimeKind.Utc).AddTicks(7416), null, "Turkish translation for Trademark.Parent", true, "Trademark.Parent", 1, 0, null, null, "Üst Marka" },
                    { 358, "Product", new DateTime(2025, 11, 6, 20, 33, 18, 286, DateTimeKind.Utc).AddTicks(7417), null, "Turkish translation for Trademark.CreateNew", true, "Trademark.CreateNew", 1, 0, null, null, "Yeni Marka Oluştur" },
                    { 359, "Product", new DateTime(2025, 11, 6, 20, 33, 18, 286, DateTimeKind.Utc).AddTicks(7418), null, "Turkish translation for Trademark.EditTrademark", true, "Trademark.EditTrademark", 1, 0, null, null, "Marka Düzenle" },
                    { 360, "Product", new DateTime(2025, 11, 6, 20, 33, 18, 286, DateTimeKind.Utc).AddTicks(7419), null, "Turkish translation for Trademark.DeleteTrademark", true, "Trademark.DeleteTrademark", 1, 0, null, null, "Marka Sil" },
                    { 361, "Product", new DateTime(2025, 11, 6, 20, 33, 18, 286, DateTimeKind.Utc).AddTicks(7422), null, "English translation for Navigation.ProductManagement", true, "Navigation.ProductManagement", 2, 0, null, null, "Product Management" },
                    { 362, "Product", new DateTime(2025, 11, 6, 20, 33, 18, 286, DateTimeKind.Utc).AddTicks(7424), null, "English translation for Navigation.Variants", true, "Navigation.Variants", 2, 0, null, null, "Variants" },
                    { 363, "Product", new DateTime(2025, 11, 6, 20, 33, 18, 286, DateTimeKind.Utc).AddTicks(7446), null, "English translation for Navigation.Trademarks", true, "Navigation.Trademarks", 2, 0, null, null, "Trademarks" },
                    { 364, "Product", new DateTime(2025, 11, 6, 20, 33, 18, 286, DateTimeKind.Utc).AddTicks(7447), null, "English translation for Navigation.Cart", true, "Navigation.Cart", 2, 0, null, null, "Cart" },
                    { 365, "Product", new DateTime(2025, 11, 6, 20, 33, 18, 286, DateTimeKind.Utc).AddTicks(7448), null, "English translation for Navigation.Payments", true, "Navigation.Payments", 2, 0, null, null, "Payments" },
                    { 366, "Product", new DateTime(2025, 11, 6, 20, 33, 18, 286, DateTimeKind.Utc).AddTicks(7449), null, "English translation for Product.Name", true, "Product.Name", 2, 0, null, null, "Product Name" },
                    { 367, "Product", new DateTime(2025, 11, 6, 20, 33, 18, 286, DateTimeKind.Utc).AddTicks(7450), null, "English translation for Product.Code", true, "Product.Code", 2, 0, null, null, "Product Code" },
                    { 368, "Product", new DateTime(2025, 11, 6, 20, 33, 18, 286, DateTimeKind.Utc).AddTicks(7451), null, "English translation for Product.IntegrationCode", true, "Product.IntegrationCode", 2, 0, null, null, "Integration Code" },
                    { 369, "Product", new DateTime(2025, 11, 6, 20, 33, 18, 286, DateTimeKind.Utc).AddTicks(7452), null, "English translation for Product.ShortDescription", true, "Product.ShortDescription", 2, 0, null, null, "Short Description" },
                    { 370, "Product", new DateTime(2025, 11, 6, 20, 33, 18, 286, DateTimeKind.Utc).AddTicks(7453), null, "English translation for Product.LongDescription", true, "Product.LongDescription", 2, 0, null, null, "Long Description" },
                    { 371, "Product", new DateTime(2025, 11, 6, 20, 33, 18, 286, DateTimeKind.Utc).AddTicks(7454), null, "English translation for Product.Unit", true, "Product.Unit", 2, 0, null, null, "Unit" },
                    { 372, "Product", new DateTime(2025, 11, 6, 20, 33, 18, 286, DateTimeKind.Utc).AddTicks(7455), null, "English translation for Product.Type", true, "Product.Type", 2, 0, null, null, "Product Type" },
                    { 373, "Product", new DateTime(2025, 11, 6, 20, 33, 18, 286, DateTimeKind.Utc).AddTicks(7456), null, "English translation for Product.TaxRate", true, "Product.TaxRate", 2, 0, null, null, "Tax Rate" },
                    { 374, "Product", new DateTime(2025, 11, 6, 20, 33, 18, 286, DateTimeKind.Utc).AddTicks(7457), null, "English translation for Product.Parent", true, "Product.Parent", 2, 0, null, null, "Parent Product" },
                    { 375, "Product", new DateTime(2025, 11, 6, 20, 33, 18, 286, DateTimeKind.Utc).AddTicks(7458), null, "English translation for Product.Variants", true, "Product.Variants", 2, 0, null, null, "Variants" },
                    { 376, "Product", new DateTime(2025, 11, 6, 20, 33, 18, 286, DateTimeKind.Utc).AddTicks(7459), null, "English translation for Product.Categories", true, "Product.Categories", 2, 0, null, null, "Categories" },
                    { 377, "Product", new DateTime(2025, 11, 6, 20, 33, 18, 286, DateTimeKind.Utc).AddTicks(7460), null, "English translation for Product.Trademarks", true, "Product.Trademarks", 2, 0, null, null, "Trademarks" },
                    { 378, "Product", new DateTime(2025, 11, 6, 20, 33, 18, 286, DateTimeKind.Utc).AddTicks(7460), null, "English translation for Product.CreateNew", true, "Product.CreateNew", 2, 0, null, null, "Create New Product" },
                    { 379, "Product", new DateTime(2025, 11, 6, 20, 33, 18, 286, DateTimeKind.Utc).AddTicks(7461), null, "English translation for Product.EditProduct", true, "Product.EditProduct", 2, 0, null, null, "Edit Product" },
                    { 380, "Product", new DateTime(2025, 11, 6, 20, 33, 18, 286, DateTimeKind.Utc).AddTicks(7462), null, "English translation for Product.DeleteProduct", true, "Product.DeleteProduct", 2, 0, null, null, "Delete Product" },
                    { 381, "Product", new DateTime(2025, 11, 6, 20, 33, 18, 286, DateTimeKind.Utc).AddTicks(7464), null, "English translation for Product.ProductDetails", true, "Product.ProductDetails", 2, 0, null, null, "Product Details" },
                    { 382, "Product", new DateTime(2025, 11, 6, 20, 33, 18, 286, DateTimeKind.Utc).AddTicks(7464), null, "English translation for Variant.Name", true, "Variant.Name", 2, 0, null, null, "Variant Name" },
                    { 383, "Product", new DateTime(2025, 11, 6, 20, 33, 18, 286, DateTimeKind.Utc).AddTicks(7465), null, "English translation for Variant.Code", true, "Variant.Code", 2, 0, null, null, "Variant Code" },
                    { 384, "Product", new DateTime(2025, 11, 6, 20, 33, 18, 286, DateTimeKind.Utc).AddTicks(7466), null, "English translation for Variant.Product", true, "Variant.Product", 2, 0, null, null, "Product" },
                    { 385, "Product", new DateTime(2025, 11, 6, 20, 33, 18, 286, DateTimeKind.Utc).AddTicks(7467), null, "English translation for Variant.CreateNew", true, "Variant.CreateNew", 2, 0, null, null, "Create New Variant" },
                    { 386, "Product", new DateTime(2025, 11, 6, 20, 33, 18, 286, DateTimeKind.Utc).AddTicks(7468), null, "English translation for Variant.EditVariant", true, "Variant.EditVariant", 2, 0, null, null, "Edit Variant" },
                    { 387, "Product", new DateTime(2025, 11, 6, 20, 33, 18, 286, DateTimeKind.Utc).AddTicks(7469), null, "English translation for Variant.DeleteVariant", true, "Variant.DeleteVariant", 2, 0, null, null, "Delete Variant" },
                    { 388, "Product", new DateTime(2025, 11, 6, 20, 33, 18, 286, DateTimeKind.Utc).AddTicks(7470), null, "English translation for Trademark.Name", true, "Trademark.Name", 2, 0, null, null, "Trademark Name" },
                    { 389, "Product", new DateTime(2025, 11, 6, 20, 33, 18, 286, DateTimeKind.Utc).AddTicks(7471), null, "English translation for Trademark.Code", true, "Trademark.Code", 2, 0, null, null, "Trademark Code" },
                    { 390, "Product", new DateTime(2025, 11, 6, 20, 33, 18, 286, DateTimeKind.Utc).AddTicks(7472), null, "English translation for Trademark.SortOrder", true, "Trademark.SortOrder", 2, 0, null, null, "Sort Order" },
                    { 391, "Product", new DateTime(2025, 11, 6, 20, 33, 18, 286, DateTimeKind.Utc).AddTicks(7473), null, "English translation for Trademark.Parent", true, "Trademark.Parent", 2, 0, null, null, "Parent Trademark" },
                    { 392, "Product", new DateTime(2025, 11, 6, 20, 33, 18, 286, DateTimeKind.Utc).AddTicks(7474), null, "English translation for Trademark.CreateNew", true, "Trademark.CreateNew", 2, 0, null, null, "Create New Trademark" },
                    { 393, "Product", new DateTime(2025, 11, 6, 20, 33, 18, 286, DateTimeKind.Utc).AddTicks(7474), null, "English translation for Trademark.EditTrademark", true, "Trademark.EditTrademark", 2, 0, null, null, "Edit Trademark" },
                    { 394, "Product", new DateTime(2025, 11, 6, 20, 33, 18, 286, DateTimeKind.Utc).AddTicks(7475), null, "English translation for Trademark.DeleteTrademark", true, "Trademark.DeleteTrademark", 2, 0, null, null, "Delete Trademark" }
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Code", "CreatedAt", "CreatedBy", "Description", "IntegrationCode", "Name", "ParentCategoryId", "SortOrder", "Status", "UpdatedAt", "UpdatedBy" },
                values: new object[,]
                {
                    { 4, "bilgisayar", new DateTime(2024, 1, 1, 10, 0, 0, 0, DateTimeKind.Unspecified), null, "Bilgisayar ve aksesuarları", "COMP", "Bilgisayar", 1, 1, 1, null, null },
                    { 5, "telefon", new DateTime(2024, 1, 1, 10, 0, 0, 0, DateTimeKind.Unspecified), null, "Cep telefonu ve aksesuarları", "PHONE", "Telefon", 1, 2, 1, null, null },
                    { 6, "erkek-giyim", new DateTime(2024, 1, 1, 10, 0, 0, 0, DateTimeKind.Unspecified), null, "Erkek giyim ürünleri", "MENS", "Erkek Giyim", 2, 1, 1, null, null },
                    { 7, "kadin-giyim", new DateTime(2024, 1, 1, 10, 0, 0, 0, DateTimeKind.Unspecified), null, "Kadın giyim ürünleri", "WMNS", "Kadın Giyim", 2, 2, 1, null, null }
                });

            migrationBuilder.InsertData(
                table: "CategoryTranslations",
                columns: new[] { "Id", "CategoryId", "CreatedAt", "CreatedBy", "LanguageId", "LongDescription", "Name", "ShortDescription", "Status", "UpdatedAt", "UpdatedBy" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2024, 1, 1, 10, 0, 0, 0, DateTimeKind.Unspecified), null, 1, "Bilgisayar, telefon ve diğer elektronik ürünler kategorisi", "Elektronik", "Elektronik ürünler", 1, null, null },
                    { 2, 1, new DateTime(2024, 1, 1, 10, 0, 0, 0, DateTimeKind.Unspecified), null, 2, "Category for computers, phones and other electronic products", "Electronics", "Electronic products", 1, null, null },
                    { 3, 2, new DateTime(2024, 1, 1, 10, 0, 0, 0, DateTimeKind.Unspecified), null, 1, "Erkek, kadın ve çocuk giyim ürünleri kategorisi", "Giyim", "Giyim ürünleri", 1, null, null },
                    { 4, 2, new DateTime(2024, 1, 1, 10, 0, 0, 0, DateTimeKind.Unspecified), null, 2, "Category for men's, women's and children's clothing products", "Clothing", "Clothing products", 1, null, null },
                    { 5, 3, new DateTime(2024, 1, 1, 10, 0, 0, 0, DateTimeKind.Unspecified), null, 1, "Ev dekorasyonu, mutfak eşyaları ve yaşam ürünleri kategorisi", "Ev & Yaşam", "Ev ve yaşam ürünleri", 1, null, null },
                    { 6, 3, new DateTime(2024, 1, 1, 10, 0, 0, 0, DateTimeKind.Unspecified), null, 2, "Category for home decoration, kitchen items and living products", "Home & Living", "Home and living products", 1, null, null },
                    { 7, 4, new DateTime(2024, 1, 1, 10, 0, 0, 0, DateTimeKind.Unspecified), null, 1, "Masaüstü, dizüstü bilgisayar ve aksesuarları", "Bilgisayar", "Bilgisayar ürünleri", 1, null, null },
                    { 8, 4, new DateTime(2024, 1, 1, 10, 0, 0, 0, DateTimeKind.Unspecified), null, 2, "Desktop, laptop computers and accessories", "Computer", "Computer products", 1, null, null },
                    { 9, 5, new DateTime(2024, 1, 1, 10, 0, 0, 0, DateTimeKind.Unspecified), null, 1, "Akıllı telefon, cep telefonu ve aksesuarları", "Telefon", "Telefon ürünleri", 1, null, null },
                    { 10, 5, new DateTime(2024, 1, 1, 10, 0, 0, 0, DateTimeKind.Unspecified), null, 2, "Smartphones, mobile phones and accessories", "Phone", "Phone products", 1, null, null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Categories_Code",
                table: "Categories",
                column: "Code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Categories_IntegrationCode",
                table: "Categories",
                column: "IntegrationCode");

            migrationBuilder.CreateIndex(
                name: "IX_Categories_Parent_SortOrder",
                table: "Categories",
                columns: new[] { "ParentCategoryId", "SortOrder" });

            migrationBuilder.CreateIndex(
                name: "IX_Categories_ParentCategoryId",
                table: "Categories",
                column: "ParentCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Categories_SortOrder",
                table: "Categories",
                column: "SortOrder");

            migrationBuilder.CreateIndex(
                name: "IX_Categories_Status",
                table: "Categories",
                column: "Status");

            migrationBuilder.CreateIndex(
                name: "IX_CategoryProducts_CategoryId_ProductId",
                table: "CategoryProducts",
                columns: new[] { "CategoryId", "ProductId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_CategoryProducts_ProductId",
                table: "CategoryProducts",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_CategoryTranslations_CategoryId",
                table: "CategoryTranslations",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_CategoryTranslations_CategoryId_LanguageId",
                table: "CategoryTranslations",
                columns: new[] { "CategoryId", "LanguageId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_CategoryTranslations_LanguageId",
                table: "CategoryTranslations",
                column: "LanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_Code",
                table: "Products",
                column: "Code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Products_IntegrationCode",
                table: "Products",
                column: "IntegrationCode");

            migrationBuilder.CreateIndex(
                name: "IX_Products_ParentId",
                table: "Products",
                column: "ParentId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_Status",
                table: "Products",
                column: "Status");

            migrationBuilder.CreateIndex(
                name: "IX_Products_Type",
                table: "Products",
                column: "Type");

            migrationBuilder.CreateIndex(
                name: "IX_ProductTranslations_LanguageId",
                table: "ProductTranslations",
                column: "LanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductTranslations_ProductId_LanguageId",
                table: "ProductTranslations",
                columns: new[] { "ProductId", "LanguageId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TrademarkProducts_ProductId",
                table: "TrademarkProducts",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_TrademarkProducts_TrademarkId_ProductId",
                table: "TrademarkProducts",
                columns: new[] { "TrademarkId", "ProductId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Trademarks_Code",
                table: "Trademarks",
                column: "Code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Trademarks_IntegrationCode",
                table: "Trademarks",
                column: "IntegrationCode");

            migrationBuilder.CreateIndex(
                name: "IX_Trademarks_ParentId",
                table: "Trademarks",
                column: "ParentId");

            migrationBuilder.CreateIndex(
                name: "IX_Trademarks_SortOrder",
                table: "Trademarks",
                column: "SortOrder");

            migrationBuilder.CreateIndex(
                name: "IX_Trademarks_Status",
                table: "Trademarks",
                column: "Status");

            migrationBuilder.CreateIndex(
                name: "IX_TrademarkTranslations_LanguageId",
                table: "TrademarkTranslations",
                column: "LanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_TrademarkTranslations_TrademarkId_LanguageId",
                table: "TrademarkTranslations",
                columns: new[] { "TrademarkId", "LanguageId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Variants_Code",
                table: "Variants",
                column: "Code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Variants_IntegrationCode",
                table: "Variants",
                column: "IntegrationCode");

            migrationBuilder.CreateIndex(
                name: "IX_Variants_ProductId",
                table: "Variants",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Variants_Status",
                table: "Variants",
                column: "Status");

            migrationBuilder.CreateIndex(
                name: "IX_VariantTranslations_LanguageId",
                table: "VariantTranslations",
                column: "LanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_VariantTranslations_VariantId_LanguageId",
                table: "VariantTranslations",
                columns: new[] { "VariantId", "LanguageId" },
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CategoryProducts");

            migrationBuilder.DropTable(
                name: "CategoryTranslations");

            migrationBuilder.DropTable(
                name: "ProductTranslations");

            migrationBuilder.DropTable(
                name: "TrademarkProducts");

            migrationBuilder.DropTable(
                name: "TrademarkTranslations");

            migrationBuilder.DropTable(
                name: "VariantTranslations");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Trademarks");

            migrationBuilder.DropTable(
                name: "Variants");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DeleteData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 327);

            migrationBuilder.DeleteData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 328);

            migrationBuilder.DeleteData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 329);

            migrationBuilder.DeleteData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 330);

            migrationBuilder.DeleteData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 331);

            migrationBuilder.DeleteData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 332);

            migrationBuilder.DeleteData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 333);

            migrationBuilder.DeleteData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 334);

            migrationBuilder.DeleteData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 335);

            migrationBuilder.DeleteData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 336);

            migrationBuilder.DeleteData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 337);

            migrationBuilder.DeleteData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 338);

            migrationBuilder.DeleteData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 339);

            migrationBuilder.DeleteData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 340);

            migrationBuilder.DeleteData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 341);

            migrationBuilder.DeleteData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 342);

            migrationBuilder.DeleteData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 343);

            migrationBuilder.DeleteData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 344);

            migrationBuilder.DeleteData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 345);

            migrationBuilder.DeleteData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 346);

            migrationBuilder.DeleteData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 347);

            migrationBuilder.DeleteData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 348);

            migrationBuilder.DeleteData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 349);

            migrationBuilder.DeleteData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 350);

            migrationBuilder.DeleteData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 351);

            migrationBuilder.DeleteData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 352);

            migrationBuilder.DeleteData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 353);

            migrationBuilder.DeleteData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 354);

            migrationBuilder.DeleteData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 355);

            migrationBuilder.DeleteData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 356);

            migrationBuilder.DeleteData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 357);

            migrationBuilder.DeleteData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 358);

            migrationBuilder.DeleteData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 359);

            migrationBuilder.DeleteData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 360);

            migrationBuilder.DeleteData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 361);

            migrationBuilder.DeleteData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 362);

            migrationBuilder.DeleteData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 363);

            migrationBuilder.DeleteData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 364);

            migrationBuilder.DeleteData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 365);

            migrationBuilder.DeleteData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 366);

            migrationBuilder.DeleteData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 367);

            migrationBuilder.DeleteData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 368);

            migrationBuilder.DeleteData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 369);

            migrationBuilder.DeleteData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 370);

            migrationBuilder.DeleteData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 371);

            migrationBuilder.DeleteData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 372);

            migrationBuilder.DeleteData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 373);

            migrationBuilder.DeleteData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 374);

            migrationBuilder.DeleteData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 375);

            migrationBuilder.DeleteData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 376);

            migrationBuilder.DeleteData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 377);

            migrationBuilder.DeleteData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 378);

            migrationBuilder.DeleteData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 379);

            migrationBuilder.DeleteData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 380);

            migrationBuilder.DeleteData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 381);

            migrationBuilder.DeleteData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 382);

            migrationBuilder.DeleteData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 383);

            migrationBuilder.DeleteData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 384);

            migrationBuilder.DeleteData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 385);

            migrationBuilder.DeleteData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 386);

            migrationBuilder.DeleteData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 387);

            migrationBuilder.DeleteData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 388);

            migrationBuilder.DeleteData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 389);

            migrationBuilder.DeleteData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 390);

            migrationBuilder.DeleteData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 391);

            migrationBuilder.DeleteData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 392);

            migrationBuilder.DeleteData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 393);

            migrationBuilder.DeleteData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 394);

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 2, 21, 31, 29, 984, DateTimeKind.Utc).AddTicks(330));

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 2, 21, 31, 29, 984, DateTimeKind.Utc).AddTicks(361));

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 2, 21, 31, 29, 984, DateTimeKind.Utc).AddTicks(363));

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 2, 21, 31, 29, 984, DateTimeKind.Utc).AddTicks(365));

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 2, 21, 31, 29, 984, DateTimeKind.Utc).AddTicks(367));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 2, 21, 31, 29, 984, DateTimeKind.Utc).AddTicks(5906));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 2, 21, 31, 29, 984, DateTimeKind.Utc).AddTicks(5912));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 2, 21, 31, 29, 984, DateTimeKind.Utc).AddTicks(5913));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 2, 21, 31, 29, 984, DateTimeKind.Utc).AddTicks(5914));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 2, 21, 31, 29, 984, DateTimeKind.Utc).AddTicks(5915));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 2, 21, 31, 29, 984, DateTimeKind.Utc).AddTicks(5917));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 2, 21, 31, 29, 984, DateTimeKind.Utc).AddTicks(5918));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 2, 21, 31, 29, 984, DateTimeKind.Utc).AddTicks(5918));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 2, 21, 31, 29, 984, DateTimeKind.Utc).AddTicks(5919));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 2, 21, 31, 29, 984, DateTimeKind.Utc).AddTicks(5921));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 2, 21, 31, 29, 984, DateTimeKind.Utc).AddTicks(5921));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 2, 21, 31, 29, 984, DateTimeKind.Utc).AddTicks(5922));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 2, 21, 31, 29, 984, DateTimeKind.Utc).AddTicks(5924));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 2, 21, 31, 29, 984, DateTimeKind.Utc).AddTicks(5939));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 2, 21, 31, 29, 984, DateTimeKind.Utc).AddTicks(5940));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 16,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 2, 21, 31, 29, 984, DateTimeKind.Utc).AddTicks(5941));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 17,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 2, 21, 31, 29, 984, DateTimeKind.Utc).AddTicks(5942));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 18,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 2, 21, 31, 29, 984, DateTimeKind.Utc).AddTicks(5943));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 19,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 2, 21, 31, 29, 984, DateTimeKind.Utc).AddTicks(5944));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 20,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 2, 21, 31, 29, 984, DateTimeKind.Utc).AddTicks(5945));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 21,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 2, 21, 31, 29, 984, DateTimeKind.Utc).AddTicks(5946));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 22,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 2, 21, 31, 29, 984, DateTimeKind.Utc).AddTicks(5947));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 23,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 2, 21, 31, 29, 984, DateTimeKind.Utc).AddTicks(5948));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 24,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 2, 21, 31, 29, 984, DateTimeKind.Utc).AddTicks(5948));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 25,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 2, 21, 31, 29, 984, DateTimeKind.Utc).AddTicks(5949));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 26,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 2, 21, 31, 29, 984, DateTimeKind.Utc).AddTicks(5950));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 27,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 2, 21, 31, 29, 984, DateTimeKind.Utc).AddTicks(5950));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 28,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 2, 21, 31, 29, 984, DateTimeKind.Utc).AddTicks(5951));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 29,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 2, 21, 31, 29, 984, DateTimeKind.Utc).AddTicks(5952));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 30,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 2, 21, 31, 29, 984, DateTimeKind.Utc).AddTicks(5953));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 31,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 2, 21, 31, 29, 984, DateTimeKind.Utc).AddTicks(5954));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 32,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 2, 21, 31, 29, 984, DateTimeKind.Utc).AddTicks(5954));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 33,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 2, 21, 31, 29, 984, DateTimeKind.Utc).AddTicks(5955));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 34,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 2, 21, 31, 29, 984, DateTimeKind.Utc).AddTicks(5957));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 35,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 2, 21, 31, 29, 984, DateTimeKind.Utc).AddTicks(5957));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 36,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 2, 21, 31, 29, 984, DateTimeKind.Utc).AddTicks(5958));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 37,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 2, 21, 31, 29, 984, DateTimeKind.Utc).AddTicks(5959));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 38,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 2, 21, 31, 29, 984, DateTimeKind.Utc).AddTicks(5960));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 39,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 2, 21, 31, 29, 984, DateTimeKind.Utc).AddTicks(5963));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 40,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 2, 21, 31, 29, 984, DateTimeKind.Utc).AddTicks(5964));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 41,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 2, 21, 31, 29, 984, DateTimeKind.Utc).AddTicks(5965));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 42,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 2, 21, 31, 29, 984, DateTimeKind.Utc).AddTicks(5966));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 43,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 2, 21, 31, 29, 984, DateTimeKind.Utc).AddTicks(5967));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 44,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 2, 21, 31, 29, 984, DateTimeKind.Utc).AddTicks(5967));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 45,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 2, 21, 31, 29, 984, DateTimeKind.Utc).AddTicks(5968));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 46,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 2, 21, 31, 29, 984, DateTimeKind.Utc).AddTicks(6005));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 47,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 2, 21, 31, 29, 984, DateTimeKind.Utc).AddTicks(6006));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 48,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 2, 21, 31, 29, 984, DateTimeKind.Utc).AddTicks(6007));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 49,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 2, 21, 31, 29, 984, DateTimeKind.Utc).AddTicks(6008));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 50,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 2, 21, 31, 29, 984, DateTimeKind.Utc).AddTicks(6009));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 51,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 2, 21, 31, 29, 984, DateTimeKind.Utc).AddTicks(6010));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 52,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 2, 21, 31, 29, 984, DateTimeKind.Utc).AddTicks(6010));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 53,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 2, 21, 31, 29, 984, DateTimeKind.Utc).AddTicks(6011));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 54,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 2, 21, 31, 29, 984, DateTimeKind.Utc).AddTicks(6014));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 55,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 2, 21, 31, 29, 984, DateTimeKind.Utc).AddTicks(6015));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 56,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 2, 21, 31, 29, 984, DateTimeKind.Utc).AddTicks(6016));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 57,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 2, 21, 31, 29, 984, DateTimeKind.Utc).AddTicks(6017));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 58,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 2, 21, 31, 29, 984, DateTimeKind.Utc).AddTicks(6018));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 59,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 2, 21, 31, 29, 984, DateTimeKind.Utc).AddTicks(6019));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 60,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 2, 21, 31, 29, 984, DateTimeKind.Utc).AddTicks(6019));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 61,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 2, 21, 31, 29, 984, DateTimeKind.Utc).AddTicks(6020));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 62,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 2, 21, 31, 29, 984, DateTimeKind.Utc).AddTicks(6021));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 63,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 2, 21, 31, 29, 984, DateTimeKind.Utc).AddTicks(6022));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 64,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 2, 21, 31, 29, 984, DateTimeKind.Utc).AddTicks(6023));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 65,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 2, 21, 31, 29, 984, DateTimeKind.Utc).AddTicks(6023));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 66,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 2, 21, 31, 29, 984, DateTimeKind.Utc).AddTicks(6025));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 67,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 2, 21, 31, 29, 984, DateTimeKind.Utc).AddTicks(6026));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 68,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 2, 21, 31, 29, 984, DateTimeKind.Utc).AddTicks(6027));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 69,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 2, 21, 31, 29, 984, DateTimeKind.Utc).AddTicks(6028));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 70,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 2, 21, 31, 29, 984, DateTimeKind.Utc).AddTicks(6030));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 71,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 2, 21, 31, 29, 984, DateTimeKind.Utc).AddTicks(6031));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 72,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 2, 21, 31, 29, 984, DateTimeKind.Utc).AddTicks(6032));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 73,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 2, 21, 31, 29, 984, DateTimeKind.Utc).AddTicks(6033));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 74,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 2, 21, 31, 29, 984, DateTimeKind.Utc).AddTicks(6034));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 75,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 2, 21, 31, 29, 984, DateTimeKind.Utc).AddTicks(6035));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 76,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 2, 21, 31, 29, 984, DateTimeKind.Utc).AddTicks(6036));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 77,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 2, 21, 31, 29, 984, DateTimeKind.Utc).AddTicks(6037));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 78,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 2, 21, 31, 29, 984, DateTimeKind.Utc).AddTicks(6065));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 79,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 2, 21, 31, 29, 984, DateTimeKind.Utc).AddTicks(6066));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 80,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 2, 21, 31, 29, 984, DateTimeKind.Utc).AddTicks(6068));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 81,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 2, 21, 31, 29, 984, DateTimeKind.Utc).AddTicks(6069));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 82,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 2, 21, 31, 29, 984, DateTimeKind.Utc).AddTicks(6070));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 83,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 2, 21, 31, 29, 984, DateTimeKind.Utc).AddTicks(6071));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 84,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 2, 21, 31, 29, 984, DateTimeKind.Utc).AddTicks(6072));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 85,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 2, 21, 31, 29, 984, DateTimeKind.Utc).AddTicks(6073));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 86,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 2, 21, 31, 29, 984, DateTimeKind.Utc).AddTicks(6073));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 87,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 2, 21, 31, 29, 984, DateTimeKind.Utc).AddTicks(6074));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 88,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 2, 21, 31, 29, 984, DateTimeKind.Utc).AddTicks(6075));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 89,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 2, 21, 31, 29, 984, DateTimeKind.Utc).AddTicks(6076));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 90,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 2, 21, 31, 29, 984, DateTimeKind.Utc).AddTicks(6077));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 91,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 2, 21, 31, 29, 984, DateTimeKind.Utc).AddTicks(6077));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 92,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 2, 21, 31, 29, 984, DateTimeKind.Utc).AddTicks(6078));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 93,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 2, 21, 31, 29, 984, DateTimeKind.Utc).AddTicks(6079));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 94,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 2, 21, 31, 29, 984, DateTimeKind.Utc).AddTicks(6080));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 95,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 2, 21, 31, 29, 984, DateTimeKind.Utc).AddTicks(6081));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 96,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 2, 21, 31, 29, 984, DateTimeKind.Utc).AddTicks(6081));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 97,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 2, 21, 31, 29, 984, DateTimeKind.Utc).AddTicks(6082));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 98,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 2, 21, 31, 29, 984, DateTimeKind.Utc).AddTicks(6083));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 99,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 2, 21, 31, 29, 984, DateTimeKind.Utc).AddTicks(6084));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 100,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 2, 21, 31, 29, 984, DateTimeKind.Utc).AddTicks(6084));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 101,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 2, 21, 31, 29, 984, DateTimeKind.Utc).AddTicks(6085));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 102,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 2, 21, 31, 29, 984, DateTimeKind.Utc).AddTicks(6086));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 103,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 2, 21, 31, 29, 984, DateTimeKind.Utc).AddTicks(6087));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 104,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 2, 21, 31, 29, 984, DateTimeKind.Utc).AddTicks(6088));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 105,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 2, 21, 31, 29, 984, DateTimeKind.Utc).AddTicks(6088));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 106,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 2, 21, 31, 29, 984, DateTimeKind.Utc).AddTicks(6089));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 107,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 2, 21, 31, 29, 984, DateTimeKind.Utc).AddTicks(6090));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 108,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 2, 21, 31, 29, 984, DateTimeKind.Utc).AddTicks(6091));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 109,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 2, 21, 31, 29, 984, DateTimeKind.Utc).AddTicks(6093));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 110,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 2, 21, 31, 29, 984, DateTimeKind.Utc).AddTicks(6094));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 111,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 2, 21, 31, 29, 984, DateTimeKind.Utc).AddTicks(6096));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 112,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 2, 21, 31, 29, 984, DateTimeKind.Utc).AddTicks(6097));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 113,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 2, 21, 31, 29, 984, DateTimeKind.Utc).AddTicks(6098));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 114,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 2, 21, 31, 29, 984, DateTimeKind.Utc).AddTicks(6128));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 115,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 2, 21, 31, 29, 984, DateTimeKind.Utc).AddTicks(6129));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 116,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 2, 21, 31, 29, 984, DateTimeKind.Utc).AddTicks(6130));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 117,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 2, 21, 31, 29, 984, DateTimeKind.Utc).AddTicks(6130));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 118,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 2, 21, 31, 29, 984, DateTimeKind.Utc).AddTicks(6131));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 119,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 2, 21, 31, 29, 984, DateTimeKind.Utc).AddTicks(6132));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 120,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 2, 21, 31, 29, 984, DateTimeKind.Utc).AddTicks(6132));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 121,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 2, 21, 31, 29, 984, DateTimeKind.Utc).AddTicks(6133));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 122,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 2, 21, 31, 29, 984, DateTimeKind.Utc).AddTicks(6134));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 123,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 2, 21, 31, 29, 984, DateTimeKind.Utc).AddTicks(6135));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 124,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 2, 21, 31, 29, 984, DateTimeKind.Utc).AddTicks(6135));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 125,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 2, 21, 31, 29, 984, DateTimeKind.Utc).AddTicks(6136));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 126,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 2, 21, 31, 29, 984, DateTimeKind.Utc).AddTicks(6137));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 127,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 2, 21, 31, 29, 984, DateTimeKind.Utc).AddTicks(6138));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 128,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 2, 21, 31, 29, 984, DateTimeKind.Utc).AddTicks(6139));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 129,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 2, 21, 31, 29, 984, DateTimeKind.Utc).AddTicks(6140));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 130,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 2, 21, 31, 29, 984, DateTimeKind.Utc).AddTicks(6142));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 131,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 2, 21, 31, 29, 984, DateTimeKind.Utc).AddTicks(6142));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 132,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 2, 21, 31, 29, 984, DateTimeKind.Utc).AddTicks(6143));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 133,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 2, 21, 31, 29, 984, DateTimeKind.Utc).AddTicks(6144));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 134,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 2, 21, 31, 29, 984, DateTimeKind.Utc).AddTicks(6145));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 135,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 2, 21, 31, 29, 984, DateTimeKind.Utc).AddTicks(6146));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 136,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 2, 21, 31, 29, 984, DateTimeKind.Utc).AddTicks(6147));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 137,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 2, 21, 31, 29, 984, DateTimeKind.Utc).AddTicks(6147));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 138,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 2, 21, 31, 29, 984, DateTimeKind.Utc).AddTicks(6148));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 139,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 2, 21, 31, 29, 984, DateTimeKind.Utc).AddTicks(6180));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 140,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 2, 21, 31, 29, 984, DateTimeKind.Utc).AddTicks(6182));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 141,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 2, 21, 31, 29, 984, DateTimeKind.Utc).AddTicks(6183));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 142,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 2, 21, 31, 29, 984, DateTimeKind.Utc).AddTicks(6183));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 143,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 2, 21, 31, 29, 984, DateTimeKind.Utc).AddTicks(6184));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 144,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 2, 21, 31, 29, 984, DateTimeKind.Utc).AddTicks(6185));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 145,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 2, 21, 31, 29, 984, DateTimeKind.Utc).AddTicks(6186));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 146,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 2, 21, 31, 29, 984, DateTimeKind.Utc).AddTicks(6187));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 147,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 2, 21, 31, 29, 984, DateTimeKind.Utc).AddTicks(6187));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 148,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 2, 21, 31, 29, 984, DateTimeKind.Utc).AddTicks(6188));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 149,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 2, 21, 31, 29, 984, DateTimeKind.Utc).AddTicks(6189));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 150,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 2, 21, 31, 29, 984, DateTimeKind.Utc).AddTicks(6190));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 151,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 2, 21, 31, 29, 984, DateTimeKind.Utc).AddTicks(6191));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 152,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 2, 21, 31, 29, 984, DateTimeKind.Utc).AddTicks(6192));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 153,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 2, 21, 31, 29, 984, DateTimeKind.Utc).AddTicks(6192));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 154,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 2, 21, 31, 29, 984, DateTimeKind.Utc).AddTicks(6193));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 155,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 2, 21, 31, 29, 984, DateTimeKind.Utc).AddTicks(6194));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 156,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 2, 21, 31, 29, 984, DateTimeKind.Utc).AddTicks(6195));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 157,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 2, 21, 31, 29, 984, DateTimeKind.Utc).AddTicks(6196));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 158,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 2, 21, 31, 29, 984, DateTimeKind.Utc).AddTicks(6197));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 159,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 2, 21, 31, 29, 984, DateTimeKind.Utc).AddTicks(6197));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 160,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 2, 21, 31, 29, 984, DateTimeKind.Utc).AddTicks(6198));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 161,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 2, 21, 31, 29, 984, DateTimeKind.Utc).AddTicks(6199));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 162,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 2, 21, 31, 29, 984, DateTimeKind.Utc).AddTicks(6200));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 163,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 2, 21, 31, 29, 984, DateTimeKind.Utc).AddTicks(6201));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 164,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 2, 21, 31, 29, 984, DateTimeKind.Utc).AddTicks(6203));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 165,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 2, 21, 31, 29, 984, DateTimeKind.Utc).AddTicks(6204));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 166,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 2, 21, 31, 29, 984, DateTimeKind.Utc).AddTicks(6205));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 167,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 2, 21, 31, 29, 984, DateTimeKind.Utc).AddTicks(6206));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 168,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 2, 21, 31, 29, 984, DateTimeKind.Utc).AddTicks(6207));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 169,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 2, 21, 31, 29, 984, DateTimeKind.Utc).AddTicks(6208));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 170,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 2, 21, 31, 29, 984, DateTimeKind.Utc).AddTicks(6208));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 171,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 2, 21, 31, 29, 984, DateTimeKind.Utc).AddTicks(6209));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 172,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 2, 21, 31, 29, 984, DateTimeKind.Utc).AddTicks(6210));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 173,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 2, 21, 31, 29, 984, DateTimeKind.Utc).AddTicks(6239));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 174,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 2, 21, 31, 29, 984, DateTimeKind.Utc).AddTicks(6240));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 175,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 2, 21, 31, 29, 984, DateTimeKind.Utc).AddTicks(6240));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 176,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 2, 21, 31, 29, 984, DateTimeKind.Utc).AddTicks(6241));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 177,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 2, 21, 31, 29, 984, DateTimeKind.Utc).AddTicks(6242));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 178,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 2, 21, 31, 29, 984, DateTimeKind.Utc).AddTicks(6243));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 179,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 2, 21, 31, 29, 984, DateTimeKind.Utc).AddTicks(6243));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 180,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 2, 21, 31, 29, 984, DateTimeKind.Utc).AddTicks(6244));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 181,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 2, 21, 31, 29, 984, DateTimeKind.Utc).AddTicks(6245));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 182,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 2, 21, 31, 29, 984, DateTimeKind.Utc).AddTicks(6246));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 183,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 2, 21, 31, 29, 984, DateTimeKind.Utc).AddTicks(6246));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 184,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 2, 21, 31, 29, 984, DateTimeKind.Utc).AddTicks(6247));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 185,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 2, 21, 31, 29, 984, DateTimeKind.Utc).AddTicks(6248));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 186,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 2, 21, 31, 29, 984, DateTimeKind.Utc).AddTicks(6249));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 187,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 2, 21, 31, 29, 984, DateTimeKind.Utc).AddTicks(6250));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 188,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 2, 21, 31, 29, 984, DateTimeKind.Utc).AddTicks(6250));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 189,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 2, 21, 31, 29, 984, DateTimeKind.Utc).AddTicks(6251));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 190,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 2, 21, 31, 29, 984, DateTimeKind.Utc).AddTicks(6252));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 191,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 2, 21, 31, 29, 984, DateTimeKind.Utc).AddTicks(6253));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 192,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 2, 21, 31, 29, 984, DateTimeKind.Utc).AddTicks(6253));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 193,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 2, 21, 31, 29, 984, DateTimeKind.Utc).AddTicks(6254));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 194,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 2, 21, 31, 29, 984, DateTimeKind.Utc).AddTicks(6255));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 195,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 2, 21, 31, 29, 984, DateTimeKind.Utc).AddTicks(6256));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 196,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 2, 21, 31, 29, 984, DateTimeKind.Utc).AddTicks(6256));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 197,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 2, 21, 31, 29, 984, DateTimeKind.Utc).AddTicks(6257));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 198,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 2, 21, 31, 29, 984, DateTimeKind.Utc).AddTicks(6258));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 199,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 2, 21, 31, 29, 984, DateTimeKind.Utc).AddTicks(6259));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 200,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 2, 21, 31, 29, 984, DateTimeKind.Utc).AddTicks(6260));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 201,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 2, 21, 31, 29, 984, DateTimeKind.Utc).AddTicks(6260));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 202,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 2, 21, 31, 29, 984, DateTimeKind.Utc).AddTicks(6263));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 203,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 2, 21, 31, 29, 984, DateTimeKind.Utc).AddTicks(6264));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 204,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 2, 21, 31, 29, 984, DateTimeKind.Utc).AddTicks(6265));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 205,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 2, 21, 31, 29, 984, DateTimeKind.Utc).AddTicks(6266));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 206,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 2, 21, 31, 29, 984, DateTimeKind.Utc).AddTicks(6267));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 207,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 2, 21, 31, 29, 984, DateTimeKind.Utc).AddTicks(6268));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 208,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 2, 21, 31, 29, 984, DateTimeKind.Utc).AddTicks(6269));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 209,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 2, 21, 31, 29, 984, DateTimeKind.Utc).AddTicks(6269));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 210,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 2, 21, 31, 29, 984, DateTimeKind.Utc).AddTicks(6270));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 211,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 2, 21, 31, 29, 984, DateTimeKind.Utc).AddTicks(6292));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 212,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 2, 21, 31, 29, 984, DateTimeKind.Utc).AddTicks(6293));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 213,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 2, 21, 31, 29, 984, DateTimeKind.Utc).AddTicks(6294));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 214,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 2, 21, 31, 29, 984, DateTimeKind.Utc).AddTicks(6295));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 215,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 2, 21, 31, 29, 984, DateTimeKind.Utc).AddTicks(6295));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 216,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 2, 21, 31, 29, 984, DateTimeKind.Utc).AddTicks(6296));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 217,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 2, 21, 31, 29, 984, DateTimeKind.Utc).AddTicks(6299));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 218,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 2, 21, 31, 29, 984, DateTimeKind.Utc).AddTicks(6300));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 219,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 2, 21, 31, 29, 984, DateTimeKind.Utc).AddTicks(6301));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 220,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 2, 21, 31, 29, 984, DateTimeKind.Utc).AddTicks(6302));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 221,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 2, 21, 31, 29, 984, DateTimeKind.Utc).AddTicks(6302));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 222,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 2, 21, 31, 29, 984, DateTimeKind.Utc).AddTicks(6303));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 223,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 2, 21, 31, 29, 984, DateTimeKind.Utc).AddTicks(6304));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 224,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 2, 21, 31, 29, 984, DateTimeKind.Utc).AddTicks(6305));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 225,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 2, 21, 31, 29, 984, DateTimeKind.Utc).AddTicks(6305));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 226,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 2, 21, 31, 29, 984, DateTimeKind.Utc).AddTicks(6306));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 227,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 2, 21, 31, 29, 984, DateTimeKind.Utc).AddTicks(6307));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 228,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 2, 21, 31, 29, 984, DateTimeKind.Utc).AddTicks(6308));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 229,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 2, 21, 31, 29, 984, DateTimeKind.Utc).AddTicks(6309));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 230,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 2, 21, 31, 29, 984, DateTimeKind.Utc).AddTicks(6310));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 231,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 2, 21, 31, 29, 984, DateTimeKind.Utc).AddTicks(6310));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 232,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 2, 21, 31, 29, 984, DateTimeKind.Utc).AddTicks(6311));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 233,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 2, 21, 31, 29, 984, DateTimeKind.Utc).AddTicks(6314));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 234,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 2, 21, 31, 29, 984, DateTimeKind.Utc).AddTicks(6315));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 235,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 2, 21, 31, 29, 984, DateTimeKind.Utc).AddTicks(6316));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 236,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 2, 21, 31, 29, 984, DateTimeKind.Utc).AddTicks(6317));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 237,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 2, 21, 31, 29, 984, DateTimeKind.Utc).AddTicks(6317));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 238,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 2, 21, 31, 29, 984, DateTimeKind.Utc).AddTicks(6318));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 239,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 2, 21, 31, 29, 984, DateTimeKind.Utc).AddTicks(6319));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 240,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 2, 21, 31, 29, 984, DateTimeKind.Utc).AddTicks(6320));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 241,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 2, 21, 31, 29, 984, DateTimeKind.Utc).AddTicks(6321));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 242,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 2, 21, 31, 29, 984, DateTimeKind.Utc).AddTicks(6321));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 243,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 2, 21, 31, 29, 984, DateTimeKind.Utc).AddTicks(6324));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 244,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 2, 21, 31, 29, 984, DateTimeKind.Utc).AddTicks(6325));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 245,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 2, 21, 31, 29, 984, DateTimeKind.Utc).AddTicks(6325));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 246,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 2, 21, 31, 29, 984, DateTimeKind.Utc).AddTicks(6326));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 247,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 2, 21, 31, 29, 984, DateTimeKind.Utc).AddTicks(6327));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 248,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 2, 21, 31, 29, 984, DateTimeKind.Utc).AddTicks(6349));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 249,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 2, 21, 31, 29, 984, DateTimeKind.Utc).AddTicks(6350));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 250,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 2, 21, 31, 29, 984, DateTimeKind.Utc).AddTicks(6351));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 251,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 2, 21, 31, 29, 984, DateTimeKind.Utc).AddTicks(6352));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 252,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 2, 21, 31, 29, 984, DateTimeKind.Utc).AddTicks(6352));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 253,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 2, 21, 31, 29, 984, DateTimeKind.Utc).AddTicks(6353));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 254,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 2, 21, 31, 29, 984, DateTimeKind.Utc).AddTicks(6354));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 255,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 2, 21, 31, 29, 984, DateTimeKind.Utc).AddTicks(6355));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 256,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 2, 21, 31, 29, 984, DateTimeKind.Utc).AddTicks(6355));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 257,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 2, 21, 31, 29, 984, DateTimeKind.Utc).AddTicks(6356));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 258,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 2, 21, 31, 29, 984, DateTimeKind.Utc).AddTicks(6358));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 259,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 2, 21, 31, 29, 984, DateTimeKind.Utc).AddTicks(6359));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 260,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 2, 21, 31, 29, 984, DateTimeKind.Utc).AddTicks(6360));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 261,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 2, 21, 31, 29, 984, DateTimeKind.Utc).AddTicks(6361));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 262,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 2, 21, 31, 29, 984, DateTimeKind.Utc).AddTicks(6362));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 263,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 2, 21, 31, 29, 984, DateTimeKind.Utc).AddTicks(6362));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 264,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 2, 21, 31, 29, 984, DateTimeKind.Utc).AddTicks(6363));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 265,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 2, 21, 31, 29, 984, DateTimeKind.Utc).AddTicks(6385));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 266,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 2, 21, 31, 29, 984, DateTimeKind.Utc).AddTicks(6386));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 267,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 2, 21, 31, 29, 984, DateTimeKind.Utc).AddTicks(6387));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 268,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 2, 21, 31, 29, 984, DateTimeKind.Utc).AddTicks(6388));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 269,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 2, 21, 31, 29, 984, DateTimeKind.Utc).AddTicks(6388));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 270,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 2, 21, 31, 29, 984, DateTimeKind.Utc).AddTicks(6389));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 271,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 2, 21, 31, 29, 984, DateTimeKind.Utc).AddTicks(6390));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 272,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 2, 21, 31, 29, 984, DateTimeKind.Utc).AddTicks(6392));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 273,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 2, 21, 31, 29, 984, DateTimeKind.Utc).AddTicks(6394));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 274,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 2, 21, 31, 29, 984, DateTimeKind.Utc).AddTicks(6396));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 275,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 2, 21, 31, 29, 984, DateTimeKind.Utc).AddTicks(6397));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 276,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 2, 21, 31, 29, 984, DateTimeKind.Utc).AddTicks(6398));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 277,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 2, 21, 31, 29, 984, DateTimeKind.Utc).AddTicks(6399));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 278,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 2, 21, 31, 29, 984, DateTimeKind.Utc).AddTicks(6400));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 279,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 2, 21, 31, 29, 984, DateTimeKind.Utc).AddTicks(6400));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 280,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 2, 21, 31, 29, 984, DateTimeKind.Utc).AddTicks(6401));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 281,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 2, 21, 31, 29, 984, DateTimeKind.Utc).AddTicks(6402));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 282,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 2, 21, 31, 29, 984, DateTimeKind.Utc).AddTicks(6403));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 283,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 2, 21, 31, 29, 984, DateTimeKind.Utc).AddTicks(6403));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 284,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 2, 21, 31, 29, 984, DateTimeKind.Utc).AddTicks(6404));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 285,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 2, 21, 31, 29, 984, DateTimeKind.Utc).AddTicks(6405));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 286,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 2, 21, 31, 29, 984, DateTimeKind.Utc).AddTicks(6406));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 287,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 2, 21, 31, 29, 984, DateTimeKind.Utc).AddTicks(6407));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 288,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 2, 21, 31, 29, 984, DateTimeKind.Utc).AddTicks(6408));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 289,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 2, 21, 31, 29, 984, DateTimeKind.Utc).AddTicks(6408));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 290,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 2, 21, 31, 29, 984, DateTimeKind.Utc).AddTicks(6409));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 291,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 2, 21, 31, 29, 984, DateTimeKind.Utc).AddTicks(6410));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 292,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 2, 21, 31, 29, 984, DateTimeKind.Utc).AddTicks(6410));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 293,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 2, 21, 31, 29, 984, DateTimeKind.Utc).AddTicks(6411));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 294,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 2, 21, 31, 29, 984, DateTimeKind.Utc).AddTicks(6412));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 295,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 2, 21, 31, 29, 984, DateTimeKind.Utc).AddTicks(6413));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 296,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 2, 21, 31, 29, 984, DateTimeKind.Utc).AddTicks(6414));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 297,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 2, 21, 31, 29, 984, DateTimeKind.Utc).AddTicks(6414));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 298,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 2, 21, 31, 29, 984, DateTimeKind.Utc).AddTicks(6415));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 299,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 2, 21, 31, 29, 984, DateTimeKind.Utc).AddTicks(6416));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 300,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 2, 21, 31, 29, 984, DateTimeKind.Utc).AddTicks(6440));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 301,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 2, 21, 31, 29, 984, DateTimeKind.Utc).AddTicks(6441));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 302,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 2, 21, 31, 29, 984, DateTimeKind.Utc).AddTicks(6444));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 303,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 2, 21, 31, 29, 984, DateTimeKind.Utc).AddTicks(6445));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 304,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 2, 21, 31, 29, 984, DateTimeKind.Utc).AddTicks(6446));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 305,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 2, 21, 31, 29, 984, DateTimeKind.Utc).AddTicks(6447));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 306,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 2, 21, 31, 29, 984, DateTimeKind.Utc).AddTicks(6447));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 307,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 2, 21, 31, 29, 984, DateTimeKind.Utc).AddTicks(6448));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 308,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 2, 21, 31, 29, 984, DateTimeKind.Utc).AddTicks(6449));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 309,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 2, 21, 31, 29, 984, DateTimeKind.Utc).AddTicks(6450));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 310,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 2, 21, 31, 29, 984, DateTimeKind.Utc).AddTicks(6450));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 311,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 2, 21, 31, 29, 984, DateTimeKind.Utc).AddTicks(6451));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 312,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 2, 21, 31, 29, 984, DateTimeKind.Utc).AddTicks(6452));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 313,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 2, 21, 31, 29, 984, DateTimeKind.Utc).AddTicks(6453));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 314,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 2, 21, 31, 29, 984, DateTimeKind.Utc).AddTicks(6453));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 315,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 2, 21, 31, 29, 984, DateTimeKind.Utc).AddTicks(6454));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 316,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 2, 21, 31, 29, 984, DateTimeKind.Utc).AddTicks(6455));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 317,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 2, 21, 31, 29, 984, DateTimeKind.Utc).AddTicks(6456));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 318,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 2, 21, 31, 29, 984, DateTimeKind.Utc).AddTicks(6457));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 319,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 2, 21, 31, 29, 984, DateTimeKind.Utc).AddTicks(6457));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 320,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 2, 21, 31, 29, 984, DateTimeKind.Utc).AddTicks(6458));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 321,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 2, 21, 31, 29, 984, DateTimeKind.Utc).AddTicks(6459));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 322,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 2, 21, 31, 29, 984, DateTimeKind.Utc).AddTicks(6460));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 323,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 2, 21, 31, 29, 984, DateTimeKind.Utc).AddTicks(6461));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 324,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 2, 21, 31, 29, 984, DateTimeKind.Utc).AddTicks(6461));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 325,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 2, 21, 31, 29, 984, DateTimeKind.Utc).AddTicks(6462));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 326,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 2, 21, 31, 29, 984, DateTimeKind.Utc).AddTicks(6463));
        }
    }
}
