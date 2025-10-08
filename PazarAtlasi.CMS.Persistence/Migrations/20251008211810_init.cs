using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace PazarAtlasi.CMS.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Contents",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RelatedEntityId = table.Column<int>(type: "int", nullable: false),
                    RelatedDataId = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<int>(type: "int", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<int>(type: "int", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    Status = table.Column<int>(type: "int", nullable: false, defaultValue: 0)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contents", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Languages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Code = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    IsDefault = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<int>(type: "int", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<int>(type: "int", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    Status = table.Column<int>(type: "int", nullable: false, defaultValue: 0)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Languages", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Pages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ContentId = table.Column<int>(type: "int", nullable: true),
                    PageSEOParameterId = table.Column<int>(type: "int", nullable: true),
                    PageType = table.Column<int>(type: "int", nullable: false, defaultValue: 0),
                    Name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    Code = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Description = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<int>(type: "int", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<int>(type: "int", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    Status = table.Column<int>(type: "int", nullable: false, defaultValue: 0)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Pages_Contents_ContentId",
                        column: x => x.ContentId,
                        principalTable: "Contents",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "PageSEOParameters",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PageId = table.Column<int>(type: "int", nullable: false),
                    MetaTitle = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    MetaDescription = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    MetaKeywords = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: true),
                    SubDescription = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    Title = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    CanonicalURL = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Author = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Description = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<int>(type: "int", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<int>(type: "int", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    Status = table.Column<int>(type: "int", nullable: false, defaultValue: 0)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PageSEOParameters", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PageSEOParameters_Pages_PageId",
                        column: x => x.PageId,
                        principalTable: "Pages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PageTranslations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PageId = table.Column<int>(type: "int", nullable: false),
                    LanguageId = table.Column<int>(type: "int", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<int>(type: "int", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<int>(type: "int", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    Status = table.Column<int>(type: "int", nullable: false, defaultValue: 0)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PageTranslations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PageTranslations_Languages_LanguageId",
                        column: x => x.LanguageId,
                        principalTable: "Languages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PageTranslations_Pages_PageId",
                        column: x => x.PageId,
                        principalTable: "Pages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Sections",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PageId = table.Column<int>(type: "int", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Type = table.Column<int>(type: "int", nullable: false, defaultValue: 0),
                    TemplateType = table.Column<int>(type: "int", nullable: false, defaultValue: 0),
                    Attributes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SortOrder = table.Column<int>(type: "int", nullable: false, defaultValue: 0),
                    Configure = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<int>(type: "int", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<int>(type: "int", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    Status = table.Column<int>(type: "int", nullable: false, defaultValue: 0)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sections", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Sections_Pages_PageId",
                        column: x => x.PageId,
                        principalTable: "Pages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SectionItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SectionId = table.Column<int>(type: "int", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Type = table.Column<int>(type: "int", nullable: false, defaultValue: 0),
                    PictureUrl = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    RedirectUrl = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Icon = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
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
                    table.PrimaryKey("PK_SectionItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SectionItems_Sections_SectionId",
                        column: x => x.SectionId,
                        principalTable: "Sections",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SectionTranslations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SectionId = table.Column<int>(type: "int", nullable: false),
                    LanguageId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Title = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: true),
                    Description = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<int>(type: "int", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<int>(type: "int", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    Status = table.Column<int>(type: "int", nullable: false, defaultValue: 0)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SectionTranslations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SectionTranslations_Sections_SectionId",
                        column: x => x.SectionId,
                        principalTable: "Sections",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SectionItemTranslations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SectionItemId = table.Column<int>(type: "int", nullable: false),
                    LanguageId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Title = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: true),
                    Description = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<int>(type: "int", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<int>(type: "int", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    Status = table.Column<int>(type: "int", nullable: false, defaultValue: 0)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SectionItemTranslations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SectionItemTranslations_SectionItems_SectionItemId",
                        column: x => x.SectionItemId,
                        principalTable: "SectionItems",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Contents",
                columns: new[] { "Id", "CreatedAt", "CreatedBy", "Description", "RelatedDataId", "RelatedEntityId", "Status", "UpdatedAt", "UpdatedBy" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 1, 1, 10, 0, 0, 0, DateTimeKind.Unspecified), null, "Ana sayfa içeriği", 1, 2, 1, null, null },
                    { 2, new DateTime(2024, 1, 2, 10, 0, 0, 0, DateTimeKind.Unspecified), null, "Blog yazısı içeriği", 1, 9, 1, null, null },
                    { 3, new DateTime(2024, 1, 3, 10, 0, 0, 0, DateTimeKind.Unspecified), null, "Ürün detay sayfası içeriği", 1, 4, 1, null, null }
                });

            migrationBuilder.InsertData(
                table: "Languages",
                columns: new[] { "Id", "Code", "CreatedAt", "CreatedBy", "IsDefault", "Name", "Status", "UpdatedAt", "UpdatedBy" },
                values: new object[] { 1, "TR", new DateTime(2024, 1, 1, 10, 0, 0, 0, DateTimeKind.Unspecified), null, true, "Türkçe", 1, null, null });

            migrationBuilder.InsertData(
                table: "Languages",
                columns: new[] { "Id", "Code", "CreatedAt", "CreatedBy", "Name", "Status", "UpdatedAt", "UpdatedBy" },
                values: new object[,]
                {
                    { 2, "US", new DateTime(2024, 1, 1, 10, 0, 0, 0, DateTimeKind.Unspecified), null, "English", 1, null, null },
                    { 3, "DE", new DateTime(2024, 1, 1, 10, 0, 0, 0, DateTimeKind.Unspecified), null, "Deutsch", 1, null, null }
                });

            migrationBuilder.InsertData(
                table: "Pages",
                columns: new[] { "Id", "Code", "ContentId", "CreatedAt", "CreatedBy", "Description", "Name", "PageSEOParameterId", "PageType", "Status", "UpdatedAt", "UpdatedBy" },
                values: new object[,]
                {
                    { 4, "about", null, new DateTime(2024, 1, 4, 10, 0, 0, 0, DateTimeKind.Unspecified), null, "Şirket hakkında bilgi sayfası", "Hakkımızda", null, 2, 1, null, null },
                    { 5, "contact", null, new DateTime(2024, 1, 5, 10, 0, 0, 0, DateTimeKind.Unspecified), null, "İletişim bilgileri ve form sayfası", "İletişim", null, 2, 1, null, null }
                });

            migrationBuilder.InsertData(
                table: "PageTranslations",
                columns: new[] { "Id", "CreatedAt", "CreatedBy", "LanguageId", "PageId", "Status", "UpdatedAt", "UpdatedBy", "Value" },
                values: new object[,]
                {
                    { 7, new DateTime(2024, 1, 4, 10, 0, 0, 0, DateTimeKind.Unspecified), null, 1, 4, 1, null, null, "Hakkımızda" },
                    { 8, new DateTime(2024, 1, 4, 10, 0, 0, 0, DateTimeKind.Unspecified), null, 2, 4, 1, null, null, "About Us" }
                });

            migrationBuilder.InsertData(
                table: "Pages",
                columns: new[] { "Id", "Code", "ContentId", "CreatedAt", "CreatedBy", "Description", "Name", "PageSEOParameterId", "PageType", "Status", "UpdatedAt", "UpdatedBy" },
                values: new object[,]
                {
                    { 1, "home", 1, new DateTime(2024, 1, 1, 10, 0, 0, 0, DateTimeKind.Unspecified), null, "Web sitesinin ana sayfası", "Ana Sayfa", null, 1, 1, null, null },
                    { 2, "blog", 2, new DateTime(2024, 1, 2, 10, 0, 0, 0, DateTimeKind.Unspecified), null, "Blog yazıları sayfası", "Blog", null, 8, 1, null, null },
                    { 3, "products", 3, new DateTime(2024, 1, 3, 10, 0, 0, 0, DateTimeKind.Unspecified), null, "Ürün katalog sayfası", "Ürünler", null, 3, 1, null, null }
                });

            migrationBuilder.InsertData(
                table: "PageSEOParameters",
                columns: new[] { "Id", "Author", "CanonicalURL", "CreatedAt", "CreatedBy", "Description", "MetaDescription", "MetaKeywords", "MetaTitle", "PageId", "Status", "SubDescription", "Title", "UpdatedAt", "UpdatedBy" },
                values: new object[,]
                {
                    { 1, "Pazar Atlası", "https://www.pazaratlasi.com/", new DateTime(2024, 1, 1, 10, 0, 0, 0, DateTimeKind.Unspecified), null, "Web sitesinin ana sayfası için SEO parametreleri", "Pazar Atlası CMS ana sayfası. Modern ve kullanıcı dostu içerik yönetim sistemi.", "cms, içerik yönetimi, pazar atlası, web sitesi", "Ana Sayfa - Pazar Atlası CMS", 1, 1, null, "Ana Sayfa", null, null },
                    { 2, "Pazar Atlası", "https://www.pazaratlasi.com/blog", new DateTime(2024, 1, 2, 10, 0, 0, 0, DateTimeKind.Unspecified), null, "Blog sayfası için SEO parametreleri", "Pazar Atlası blog yazıları. Teknoloji, pazarlama ve iş dünyasından güncel haberler.", "blog, yazılar, teknoloji, pazarlama, iş", "Blog - Pazar Atlası CMS", 2, 1, null, "Blog", null, null },
                    { 3, "Pazar Atlası", "https://www.pazaratlasi.com/products", new DateTime(2024, 1, 3, 10, 0, 0, 0, DateTimeKind.Unspecified), null, "Ürün katalog sayfası için SEO parametreleri", "Pazar Atlası ürün kataloğu. Kaliteli ve uygun fiyatlı ürünler.", "ürünler, katalog, alışveriş, kalite", "Ürünler - Pazar Atlası CMS", 3, 1, null, "Ürünler", null, null }
                });

            migrationBuilder.InsertData(
                table: "PageTranslations",
                columns: new[] { "Id", "CreatedAt", "CreatedBy", "LanguageId", "PageId", "Status", "UpdatedAt", "UpdatedBy", "Value" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 1, 1, 10, 0, 0, 0, DateTimeKind.Unspecified), null, 1, 1, 1, null, null, "Ana Sayfa" },
                    { 2, new DateTime(2024, 1, 1, 10, 0, 0, 0, DateTimeKind.Unspecified), null, 2, 1, 1, null, null, "Home Page" },
                    { 3, new DateTime(2024, 1, 2, 10, 0, 0, 0, DateTimeKind.Unspecified), null, 1, 2, 1, null, null, "Blog" },
                    { 4, new DateTime(2024, 1, 2, 10, 0, 0, 0, DateTimeKind.Unspecified), null, 2, 2, 1, null, null, "Blog" },
                    { 5, new DateTime(2024, 1, 3, 10, 0, 0, 0, DateTimeKind.Unspecified), null, 1, 3, 1, null, null, "Ürünler" },
                    { 6, new DateTime(2024, 1, 3, 10, 0, 0, 0, DateTimeKind.Unspecified), null, 2, 3, 1, null, null, "Products" }
                });

            migrationBuilder.InsertData(
                table: "Sections",
                columns: new[] { "Id", "Attributes", "Code", "Configure", "CreatedAt", "CreatedBy", "PageId", "SortOrder", "Status", "TemplateType", "Type", "UpdatedAt", "UpdatedBy" },
                values: new object[,]
                {
                    { 1, "{\"backgroundImage\": \"hero-bg.jpg\", \"height\": \"500px\"}", "hero-section", "{\"showButton\": true, \"buttonText\": \"Keşfet\"}", new DateTime(2024, 1, 1, 10, 0, 0, 0, DateTimeKind.Unspecified), null, 1, 1, 1, 1, 3, null, null },
                    { 2, "{\"columns\": 3}", "featured-products", "{\"maxItems\": 6, \"showMore\": true, \"showPrices\": true}", new DateTime(2024, 1, 1, 10, 0, 0, 0, DateTimeKind.Unspecified), null, 1, 2, 1, 3, 6, null, null },
                    { 3, "{\"backgroundColor\": \"#f8f9fa\"}", "newsletter", "{\"showPrivacyText\": true}", new DateTime(2024, 1, 1, 10, 0, 0, 0, DateTimeKind.Unspecified), null, 1, 3, 1, 1, 7, null, null },
                    { 4, "{}", "blog-header", "{\"showSearchBox\": true,\"showBreadcrumbs\": true}", new DateTime(2024, 1, 2, 10, 0, 0, 0, DateTimeKind.Unspecified), null, 2, 1, 1, 1, 2, null, null },
                    { 5, "{}", "blog-content", "{\"showExcerpt\": true, \"showAuthor\": true, \"showDate\": true,\"postsPerPage\": 10}", new DateTime(2024, 1, 2, 10, 0, 0, 0, DateTimeKind.Unspecified), null, 2, 2, 1, 6, 12, null, null },
                    { 6, "{\"columns\": 4}", "product-catalog", "{\"productsPerPage\": 20, \"showSorting\": true, \"showFilters\": true}", new DateTime(2024, 1, 3, 10, 0, 0, 0, DateTimeKind.Unspecified), null, 3, 1, 1, 3, 4, null, null }
                });

            migrationBuilder.InsertData(
                table: "SectionItems",
                columns: new[] { "Id", "Code", "CreatedAt", "CreatedBy", "Icon", "PictureUrl", "RedirectUrl", "SectionId", "SortOrder", "Status", "Type", "UpdatedAt", "UpdatedBy" },
                values: new object[,]
                {
                    { 1, "hero-title", new DateTime(2024, 1, 1, 10, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, 1, 1, 1, 1, null, null },
                    { 2, "hero-subtitle", new DateTime(2024, 1, 1, 10, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, 1, 2, 1, 3, null, null },
                    { 3, "hero-cta-button", new DateTime(2024, 1, 1, 10, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, "/products", 1, 3, 1, 5, null, null },
                    { 4, "featured-product-1", new DateTime(2024, 1, 1, 10, 0, 0, 0, DateTimeKind.Unspecified), null, null, "/images/products/product1.jpg", "/products/1", 2, 1, 1, 9, null, null },
                    { 5, "featured-product-2", new DateTime(2024, 1, 1, 10, 0, 0, 0, DateTimeKind.Unspecified), null, null, "/images/products/product2.jpg", "/products/2", 2, 2, 1, 9, null, null },
                    { 6, "featured-product-3", new DateTime(2024, 1, 1, 10, 0, 0, 0, DateTimeKind.Unspecified), null, null, "/images/products/product3.jpg", "/products/3", 2, 3, 1, 9, null, null },
                    { 7, "newsletter-title", new DateTime(2024, 1, 1, 10, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, 3, 1, 1, 1, null, null },
                    { 8, "newsletter-form", new DateTime(2024, 1, 1, 10, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, 3, 2, 1, 13, null, null },
                    { 9, "blog-title", new DateTime(2024, 1, 2, 10, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, 4, 1, 1, 1, null, null },
                    { 10, "blog-search", new DateTime(2024, 1, 2, 10, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, 4, 2, 1, 22, null, null }
                });

            migrationBuilder.InsertData(
                table: "SectionTranslations",
                columns: new[] { "Id", "CreatedAt", "CreatedBy", "Description", "LanguageId", "Name", "SectionId", "Status", "Title", "UpdatedAt", "UpdatedBy" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 1, 1, 10, 0, 0, 0, DateTimeKind.Unspecified), null, "Web sitesinin ana sayfasındaki büyük banner alanı", 1, "Ana Banner", 1, 1, "Ana Sayfa Hero Bölümü", null, null },
                    { 2, new DateTime(2024, 1, 1, 10, 0, 0, 0, DateTimeKind.Unspecified), null, "Large banner area on the homepage of the website", 2, "Main Banner", 1, 1, "Homepage Hero Section", null, null },
                    { 3, new DateTime(2024, 1, 1, 10, 0, 0, 0, DateTimeKind.Unspecified), null, "Seçili ve popüler ürünlerin sergilendiği alan", 1, "Öne Çıkan Ürünler", 2, 1, "Öne Çıkan Ürünler Bölümü", null, null },
                    { 4, new DateTime(2024, 1, 1, 10, 0, 0, 0, DateTimeKind.Unspecified), null, "Area where selected and popular products are displayed", 2, "Featured Products", 2, 1, "Featured Products Section", null, null },
                    { 5, new DateTime(2024, 1, 1, 10, 0, 0, 0, DateTimeKind.Unspecified), null, "Kullanıcıların e-posta listesine kaydolabileceği alan", 1, "E-posta Bülteni", 3, 1, "E-posta Bülteni Kayıt Bölümü", null, null },
                    { 6, new DateTime(2024, 1, 1, 10, 0, 0, 0, DateTimeKind.Unspecified), null, "Area where users can register to the email list", 2, "Email Newsletter", 3, 1, "Email Newsletter Registration Section", null, null },
                    { 7, new DateTime(2024, 1, 2, 10, 0, 0, 0, DateTimeKind.Unspecified), null, "Blog sayfasının üst kısmındaki başlık alanı", 1, "Blog Başlığı", 4, 1, "Blog Sayfa Başlığı", null, null },
                    { 8, new DateTime(2024, 1, 2, 10, 0, 0, 0, DateTimeKind.Unspecified), null, "Header area at the top of the blog page", 2, "Blog Header", 4, 1, "Blog Page Header", null, null },
                    { 9, new DateTime(2024, 1, 2, 10, 0, 0, 0, DateTimeKind.Unspecified), null, "Blog yazılarının listelendiği ana içerik alanı", 1, "Blog İçeriği", 5, 1, "Blog Yazıları Listesi", null, null },
                    { 10, new DateTime(2024, 1, 2, 10, 0, 0, 0, DateTimeKind.Unspecified), null, "Main content area where blog posts are listed", 2, "Blog Content", 5, 1, "Blog Posts List", null, null },
                    { 11, new DateTime(2024, 1, 3, 10, 0, 0, 0, DateTimeKind.Unspecified), null, "Tüm ürünlerin kategorize edilmiş şekilde listelendiği alan", 1, "Ürün Kataloğu", 6, 1, "Ürün Katalog Listesi", null, null },
                    { 12, new DateTime(2024, 1, 3, 10, 0, 0, 0, DateTimeKind.Unspecified), null, "Area where all products are listed in a categorized manner", 2, "Product Catalog", 6, 1, "Product Catalog List", null, null }
                });

            migrationBuilder.InsertData(
                table: "SectionItemTranslations",
                columns: new[] { "Id", "CreatedAt", "CreatedBy", "Description", "LanguageId", "Name", "SectionItemId", "Status", "Title", "UpdatedAt", "UpdatedBy" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 1, 1, 10, 0, 0, 0, DateTimeKind.Unspecified), null, "En kaliteli ürünleri keşfedin", 1, "Hoş Geldiniz", 1, 1, "Pazar Atlası'na Hoş Geldiniz", null, null },
                    { 2, new DateTime(2024, 1, 1, 10, 0, 0, 0, DateTimeKind.Unspecified), null, "Discover the highest quality products", 2, "Welcome", 1, 1, "Welcome to Pazar Atlası", null, null },
                    { 3, new DateTime(2024, 1, 1, 10, 0, 0, 0, DateTimeKind.Unspecified), null, "Binlerce ürün arasından size en uygun olanları bulun. Hızlı teslimat, güvenli ödeme ve mükemmel müşteri hizmetiyle yanınızdayız.", 1, "Alt Başlık", 2, 1, "Kalite ve Güvenin Adresi", null, null },
                    { 4, new DateTime(2024, 1, 1, 10, 0, 0, 0, DateTimeKind.Unspecified), null, "Find the most suitable products for you among thousands of products. We are with you with fast delivery, secure payment and excellent customer service.", 2, "Subtitle", 2, 1, "Address of Quality and Trust", null, null },
                    { 5, new DateTime(2024, 1, 1, 10, 0, 0, 0, DateTimeKind.Unspecified), null, "Tüm ürünleri görüntülemek için tıklayın", 1, "Keşfet", 3, 1, "Ürünleri Keşfet", null, null },
                    { 6, new DateTime(2024, 1, 1, 10, 0, 0, 0, DateTimeKind.Unspecified), null, "Click to view all products", 2, "Explore", 3, 1, "Explore Products", null, null },
                    { 7, new DateTime(2024, 1, 1, 10, 0, 0, 0, DateTimeKind.Unspecified), null, "Yüksek performanslı, şık tasarımlı laptop", 1, "Öne Çıkan Ürün 1", 4, 1, "Premium Laptop", null, null },
                    { 8, new DateTime(2024, 1, 1, 10, 0, 0, 0, DateTimeKind.Unspecified), null, "High performance, stylish design laptop", 2, "Featured Product 1", 4, 1, "Premium Laptop", null, null },
                    { 9, new DateTime(2024, 1, 1, 10, 0, 0, 0, DateTimeKind.Unspecified), null, "Yeni ürünler ve kampanyalardan haberdar olmak için e-posta listemize katılın", 1, "Bülten", 7, 1, "Haberdar Olun", null, null },
                    { 10, new DateTime(2024, 1, 1, 10, 0, 0, 0, DateTimeKind.Unspecified), null, "Join our email list to stay informed about new products and campaigns", 2, "Newsletter", 7, 1, "Stay Informed", null, null },
                    { 11, new DateTime(2024, 1, 2, 10, 0, 0, 0, DateTimeKind.Unspecified), null, "En güncel haberler ve makaleler", 1, "Blog", 9, 1, "Blog Yazıları", null, null },
                    { 12, new DateTime(2024, 1, 2, 10, 0, 0, 0, DateTimeKind.Unspecified), null, "Latest news and articles", 2, "Blog", 9, 1, "Blog Posts", null, null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Languages_Code",
                table: "Languages",
                column: "Code",
                unique: true,
                filter: "[Code] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Languages_IsDefault",
                table: "Languages",
                column: "IsDefault");

            migrationBuilder.CreateIndex(
                name: "IX_Pages_Code",
                table: "Pages",
                column: "Code",
                unique: true,
                filter: "[Code] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Pages_ContentId",
                table: "Pages",
                column: "ContentId");

            migrationBuilder.CreateIndex(
                name: "IX_Pages_PageType",
                table: "Pages",
                column: "PageType");

            migrationBuilder.CreateIndex(
                name: "IX_PageSEOParameters_PageId",
                table: "PageSEOParameters",
                column: "PageId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_PageTranslations_LanguageId",
                table: "PageTranslations",
                column: "LanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_PageTranslations_PageId_LanguageId",
                table: "PageTranslations",
                columns: new[] { "PageId", "LanguageId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_SectionItems_Code",
                table: "SectionItems",
                column: "Code");

            migrationBuilder.CreateIndex(
                name: "IX_SectionItems_SectionId_SortOrder",
                table: "SectionItems",
                columns: new[] { "SectionId", "SortOrder" });

            migrationBuilder.CreateIndex(
                name: "IX_SectionItems_Type",
                table: "SectionItems",
                column: "Type");

            migrationBuilder.CreateIndex(
                name: "IX_SectionItemTranslations_SectionItemId_LanguageId",
                table: "SectionItemTranslations",
                columns: new[] { "SectionItemId", "LanguageId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Sections_Code",
                table: "Sections",
                column: "Code");

            migrationBuilder.CreateIndex(
                name: "IX_Sections_PageId_SortOrder",
                table: "Sections",
                columns: new[] { "PageId", "SortOrder" });

            migrationBuilder.CreateIndex(
                name: "IX_Sections_Type",
                table: "Sections",
                column: "Type");

            migrationBuilder.CreateIndex(
                name: "IX_SectionTranslations_SectionId_LanguageId",
                table: "SectionTranslations",
                columns: new[] { "SectionId", "LanguageId" },
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PageSEOParameters");

            migrationBuilder.DropTable(
                name: "PageTranslations");

            migrationBuilder.DropTable(
                name: "SectionItemTranslations");

            migrationBuilder.DropTable(
                name: "SectionTranslations");

            migrationBuilder.DropTable(
                name: "Languages");

            migrationBuilder.DropTable(
                name: "SectionItems");

            migrationBuilder.DropTable(
                name: "Sections");

            migrationBuilder.DropTable(
                name: "Pages");

            migrationBuilder.DropTable(
                name: "Contents");
        }
    }
}
