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
                name: "Announcements",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Summary = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    CoverImage = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    PublishStart = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PublishEnd = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedByName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<int>(type: "int", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<int>(type: "int", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    Status = table.Column<int>(type: "int", nullable: false, defaultValue: 0)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Announcements", x => x.Id);
                });

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
                name: "Contents",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RelatedDataEntityType = table.Column<int>(type: "int", nullable: false),
                    RelatedDataEntityId = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: true),
                    MetaTitle = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    MetaDescription = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    MetaKeywords = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    SubDescription = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    Title = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    Author = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<int>(type: "int", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<int>(type: "int", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contents", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Continents",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Code = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
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
                    table.PrimaryKey("PK_Continents", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DataSchemas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Key = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    Configuration = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SortOrder = table.Column<int>(type: "int", nullable: false, defaultValue: 0),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<int>(type: "int", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<int>(type: "int", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    Status = table.Column<int>(type: "int", nullable: false, defaultValue: 1)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DataSchemas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Languages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Code = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    NativeName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Flag = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    IsDefault = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    SortOrder = table.Column<int>(type: "int", nullable: false, defaultValue: 0),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETUTCDATE()"),
                    CreatedBy = table.Column<int>(type: "int", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<int>(type: "int", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Languages", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Layouts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    IsDefault = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<int>(type: "int", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<int>(type: "int", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Layouts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Options",
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
                    Type = table.Column<int>(type: "int", nullable: false, defaultValue: 1),
                    DefaultValue = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    IsRequired = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    AllowMultipleSelection = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
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
                    table.PrimaryKey("PK_Options", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Options_Options_ParentId",
                        column: x => x.ParentId,
                        principalTable: "Options",
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
                name: "Sections",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Type = table.Column<int>(type: "int", nullable: false, defaultValue: 0),
                    Key = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
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
                });

            migrationBuilder.CreateTable(
                name: "Templates",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TemplateKey = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
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
                name: "Countries",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Code = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    SortOrder = table.Column<int>(type: "int", nullable: false, defaultValue: 0),
                    ContinentId = table.Column<int>(type: "int", nullable: true),
                    IsPopular = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<int>(type: "int", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<int>(type: "int", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    Status = table.Column<int>(type: "int", nullable: false, defaultValue: 1)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Countries", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Countries_Continents_ContinentId",
                        column: x => x.ContinentId,
                        principalTable: "Continents",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "DataSchemaFields",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DataSchemaId = table.Column<int>(type: "int", nullable: false),
                    FieldKey = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    FieldName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Type = table.Column<int>(type: "int", nullable: false, defaultValue: 1),
                    IsRequired = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    IsTranslatable = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    ShowInListing = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    ShowInDetails = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    IsFilterable = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    IsSortable = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    DefaultValue = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Placeholder = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    OptionsJson = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ValidationRules = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Unit = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    SortOrder = table.Column<int>(type: "int", nullable: false, defaultValue: 0),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<int>(type: "int", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<int>(type: "int", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    Status = table.Column<int>(type: "int", nullable: false, defaultValue: 1)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DataSchemaFields", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DataSchemaFields_DataSchemas_DataSchemaId",
                        column: x => x.DataSchemaId,
                        principalTable: "DataSchemas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AnnouncementTranslations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AnnouncementId = table.Column<int>(type: "int", nullable: false),
                    LanguageId = table.Column<int>(type: "int", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Summary = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<int>(type: "int", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<int>(type: "int", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    Status = table.Column<int>(type: "int", nullable: false, defaultValue: 0)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AnnouncementTranslations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AnnouncementTranslations_Announcements_AnnouncementId",
                        column: x => x.AnnouncementId,
                        principalTable: "Announcements",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AnnouncementTranslations_Languages_LanguageId",
                        column: x => x.LanguageId,
                        principalTable: "Languages",
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
                name: "ContentSlugs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ContentId = table.Column<int>(type: "int", nullable: false),
                    Slug = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    LanguageId = table.Column<int>(type: "int", nullable: false),
                    Priority = table.Column<int>(type: "int", nullable: true),
                    IsCanonical = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<int>(type: "int", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<int>(type: "int", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContentSlugs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ContentSlugs_Contents_ContentId",
                        column: x => x.ContentId,
                        principalTable: "Contents",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ContentSlugs_Languages_LanguageId",
                        column: x => x.LanguageId,
                        principalTable: "Languages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DataSchemaTranslations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DataSchemaId = table.Column<int>(type: "int", nullable: false),
                    LanguageId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<int>(type: "int", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<int>(type: "int", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    Status = table.Column<int>(type: "int", nullable: false, defaultValue: 1)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DataSchemaTranslations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DataSchemaTranslations_DataSchemas_DataSchemaId",
                        column: x => x.DataSchemaId,
                        principalTable: "DataSchemas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DataSchemaTranslations_Languages_LanguageId",
                        column: x => x.LanguageId,
                        principalTable: "Languages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "LocalizationValues",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LanguageId = table.Column<int>(type: "int", nullable: false),
                    Key = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    Value = table.Column<string>(type: "nvarchar(4000)", maxLength: 4000, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    Category = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETUTCDATE()"),
                    CreatedBy = table.Column<int>(type: "int", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<int>(type: "int", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LocalizationValues", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LocalizationValues_Languages_LanguageId",
                        column: x => x.LanguageId,
                        principalTable: "Languages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Pages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ContentId = table.Column<int>(type: "int", nullable: true),
                    PageSEOParameterId = table.Column<int>(type: "int", nullable: true),
                    LayoutId = table.Column<int>(type: "int", nullable: true),
                    ParentPageId = table.Column<int>(type: "int", nullable: true),
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
                    table.ForeignKey(
                        name: "FK_Pages_Layouts_LayoutId",
                        column: x => x.LayoutId,
                        principalTable: "Layouts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_Pages_Pages_ParentPageId",
                        column: x => x.ParentPageId,
                        principalTable: "Pages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "OptionTranslations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OptionId = table.Column<int>(type: "int", nullable: false),
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
                    table.PrimaryKey("PK_OptionTranslations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OptionTranslations_Languages_LanguageId",
                        column: x => x.LanguageId,
                        principalTable: "Languages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_OptionTranslations_Options_OptionId",
                        column: x => x.OptionId,
                        principalTable: "Options",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
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
                name: "ProductDataSchemas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    SchemaId = table.Column<int>(type: "int", nullable: false),
                    IsPrimary = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    SortOrder = table.Column<int>(type: "int", nullable: false, defaultValue: 0),
                    Configuration = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<int>(type: "int", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<int>(type: "int", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    Status = table.Column<int>(type: "int", nullable: false, defaultValue: 1)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductDataSchemas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductDataSchemas_DataSchemas_SchemaId",
                        column: x => x.SchemaId,
                        principalTable: "DataSchemas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductDataSchemas_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductOptions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    OptionId = table.Column<int>(type: "int", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    JsonValue = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PriceModifier = table.Column<decimal>(type: "decimal(10,2)", nullable: true, defaultValue: 0m),
                    StockQuantity = table.Column<int>(type: "int", nullable: true),
                    IsRequired = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    IsDefault = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
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
                    table.PrimaryKey("PK_ProductOptions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductOptions_Options_OptionId",
                        column: x => x.OptionId,
                        principalTable: "Options",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductOptions_Products_ProductId",
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
                name: "LayoutSections",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LayoutId = table.Column<int>(type: "int", nullable: false),
                    SectionId = table.Column<int>(type: "int", nullable: false),
                    SortOrder = table.Column<int>(type: "int", nullable: false, defaultValue: 0),
                    IsRequired = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    Position = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<int>(type: "int", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<int>(type: "int", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LayoutSections", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LayoutSections_Layouts_LayoutId",
                        column: x => x.LayoutId,
                        principalTable: "Layouts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LayoutSections_Sections_SectionId",
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
                        name: "FK_SectionTranslations_Languages_LanguageId",
                        column: x => x.LanguageId,
                        principalTable: "Languages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SectionTranslations_Sections_SectionId",
                        column: x => x.SectionId,
                        principalTable: "Sections",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SectionItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ParentSectionItemId = table.Column<int>(type: "int", nullable: true),
                    TemplateId = table.Column<int>(type: "int", nullable: true),
                    Type = table.Column<int>(type: "int", nullable: false, defaultValue: 0),
                    MediaType = table.Column<int>(type: "int", nullable: false, defaultValue: 0),
                    SortOrder = table.Column<int>(type: "int", nullable: false, defaultValue: 0),
                    Title = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    Key = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    AllowReorder = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    AllowRemove = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    IconClass = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
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
                        name: "FK_SectionItems_SectionItems_ParentSectionItemId",
                        column: x => x.ParentSectionItemId,
                        principalTable: "SectionItems",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_SectionItems_Templates_TemplateId",
                        column: x => x.TemplateId,
                        principalTable: "Templates",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SectionTypeTemplates",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SectionType = table.Column<int>(type: "int", nullable: false),
                    TemplateId = table.Column<int>(type: "int", nullable: false),
                    CustomConfiguration = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SectionId = table.Column<int>(type: "int", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<int>(type: "int", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<int>(type: "int", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SectionTypeTemplates", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SectionTypeTemplates_Sections_SectionId",
                        column: x => x.SectionId,
                        principalTable: "Sections",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_SectionTypeTemplates_Templates_TemplateId",
                        column: x => x.TemplateId,
                        principalTable: "Templates",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TemplateTranslations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TemplateId = table.Column<int>(type: "int", nullable: false),
                    LanguageId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<int>(type: "int", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<int>(type: "int", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TemplateTranslations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TemplateTranslations_Languages_LanguageId",
                        column: x => x.LanguageId,
                        principalTable: "Languages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TemplateTranslations_Templates_TemplateId",
                        column: x => x.TemplateId,
                        principalTable: "Templates",
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
                name: "DataSchemaFieldTranslations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DataSchemaFieldId = table.Column<int>(type: "int", nullable: false),
                    LanguageId = table.Column<int>(type: "int", nullable: false),
                    FieldName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Placeholder = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    Unit = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    OptionsJson = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<int>(type: "int", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<int>(type: "int", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    Status = table.Column<int>(type: "int", nullable: false, defaultValue: 1)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DataSchemaFieldTranslations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DataSchemaFieldTranslations_DataSchemaFields_DataSchemaFieldId",
                        column: x => x.DataSchemaFieldId,
                        principalTable: "DataSchemaFields",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DataSchemaFieldTranslations_Languages_LanguageId",
                        column: x => x.LanguageId,
                        principalTable: "Languages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DataSchemaFieldValues",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    SchemaId = table.Column<int>(type: "int", nullable: false),
                    FieldId = table.Column<int>(type: "int", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: false),
                    JsonValue = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NumericValue = table.Column<decimal>(type: "decimal(18,4)", nullable: true),
                    BooleanValue = table.Column<bool>(type: "bit", nullable: true),
                    DateValue = table.Column<DateTime>(type: "datetime2", nullable: true),
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
                    table.PrimaryKey("PK_DataSchemaFieldValues", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DataSchemaFieldValues_DataSchemaFields_FieldId",
                        column: x => x.FieldId,
                        principalTable: "DataSchemaFields",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DataSchemaFieldValues_DataSchemas_SchemaId",
                        column: x => x.SchemaId,
                        principalTable: "DataSchemas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DataSchemaFieldValues_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PageSections",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PageId = table.Column<int>(type: "int", nullable: false),
                    SectionId = table.Column<int>(type: "int", nullable: false),
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
                    table.PrimaryKey("PK_PageSections", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PageSections_Pages_PageId",
                        column: x => x.PageId,
                        principalTable: "Pages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PageSections_Sections_SectionId",
                        column: x => x.SectionId,
                        principalTable: "Sections",
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

            migrationBuilder.CreateTable(
                name: "SectionItemFields",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SectionItemId = table.Column<int>(type: "int", nullable: false),
                    FieldKey = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    FieldName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    Type = table.Column<int>(type: "int", nullable: false),
                    Required = table.Column<bool>(type: "bit", nullable: false),
                    MaxLength = table.Column<int>(type: "int", nullable: true),
                    Placeholder = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    DefaultValue = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    IsTranslatable = table.Column<bool>(type: "bit", nullable: false),
                    ShowInUI = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    OptionsJson = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AcceptedFileTypes = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    MaxFileSize = table.Column<long>(type: "bigint", nullable: true),
                    SortOrder = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<int>(type: "int", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<int>(type: "int", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    Status = table.Column<int>(type: "int", nullable: false)
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
                name: "SectionItemTranslations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SectionItemId = table.Column<int>(type: "int", nullable: false),
                    LanguageId = table.Column<int>(type: "int", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
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
                        name: "FK_SectionItemTranslations_Languages_LanguageId",
                        column: x => x.LanguageId,
                        principalTable: "Languages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SectionItemTranslations_SectionItems_SectionItemId",
                        column: x => x.SectionItemId,
                        principalTable: "SectionItems",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SectionItemValues",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SectionId = table.Column<int>(type: "int", nullable: false),
                    SectionItemId = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<int>(type: "int", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<int>(type: "int", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    Status = table.Column<int>(type: "int", nullable: false, defaultValue: 0)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SectionItemValues", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SectionItemValues_SectionItems_SectionItemId",
                        column: x => x.SectionItemId,
                        principalTable: "SectionItems",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SectionItemValues_Sections_SectionId",
                        column: x => x.SectionId,
                        principalTable: "Sections",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DataSchemaFieldValueTranslations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DataSchemaFieldValueId = table.Column<int>(type: "int", nullable: false),
                    LanguageId = table.Column<int>(type: "int", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: false),
                    JsonValue = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<int>(type: "int", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<int>(type: "int", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    Status = table.Column<int>(type: "int", nullable: false, defaultValue: 1)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DataSchemaFieldValueTranslations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DataSchemaFieldValueTranslations_DataSchemaFieldValues_DataSchemaFieldValueId",
                        column: x => x.DataSchemaFieldValueId,
                        principalTable: "DataSchemaFieldValues",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DataSchemaFieldValueTranslations_Languages_LanguageId",
                        column: x => x.LanguageId,
                        principalTable: "Languages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

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

            migrationBuilder.CreateTable(
                name: "SectionItemFieldValues",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SectionId = table.Column<int>(type: "int", nullable: false),
                    SectionItemId = table.Column<int>(type: "int", nullable: false),
                    SectionItemFieldId = table.Column<int>(type: "int", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(4000)", maxLength: 4000, nullable: false),
                    JsonValue = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<int>(type: "int", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<int>(type: "int", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SectionItemFieldValues", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SectionItemFieldValues_SectionItemFields_SectionItemFieldId",
                        column: x => x.SectionItemFieldId,
                        principalTable: "SectionItemFields",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SectionItemFieldValues_SectionItems_SectionItemId",
                        column: x => x.SectionItemId,
                        principalTable: "SectionItems",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_SectionItemFieldValues_Sections_SectionId",
                        column: x => x.SectionId,
                        principalTable: "Sections",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "SectionItemFieldValueTranslations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SectionItemFieldValueId = table.Column<int>(type: "int", nullable: false),
                    LanguageId = table.Column<int>(type: "int", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(4000)", maxLength: 4000, nullable: false),
                    JsonValue = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<int>(type: "int", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<int>(type: "int", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SectionItemFieldValueTranslations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SectionItemFieldValueTranslations_Languages_LanguageId",
                        column: x => x.LanguageId,
                        principalTable: "Languages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SectionItemFieldValueTranslations_SectionItemFieldValues_SectionItemFieldValueId",
                        column: x => x.SectionItemFieldValueId,
                        principalTable: "SectionItemFieldValues",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Announcements",
                columns: new[] { "Id", "Content", "CoverImage", "CreatedAt", "CreatedBy", "CreatedByName", "PublishEnd", "PublishStart", "Status", "Summary", "Title", "UpdatedAt", "UpdatedBy" },
                values: new object[,]
                {
                    { 1, "<p>Yeni duyuru sistemimize hoş geldiniz. Bu sistem ile önemli duyurularınızı kolayca yönetebilirsiniz.</p>", null, new DateTime(2024, 10, 27, 10, 0, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2024, 11, 27, 10, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 10, 27, 10, 0, 0, 0, DateTimeKind.Unspecified), 1, "Yeni duyuru sistemi tanıtımı", "Hoş Geldiniz!", null, null },
                    { 2, "<p>Sistemimizde planlı bakım çalışması yapılacaktır. Bakım sırasında hizmetlerimizde kısa süreli kesintiler yaşanabilir.</p><p>Bakım tarihi: <strong>15 Kasım 2024, 02:00-04:00</strong></p>", null, new DateTime(2024, 10, 22, 10, 0, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2024, 11, 6, 10, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 10, 22, 10, 0, 0, 0, DateTimeKind.Unspecified), 1, "Planlı sistem bakımı hakkında bilgilendirme", "Sistem Bakımı Duyurusu", null, null }
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Code", "CreatedAt", "CreatedBy", "IntegrationCode", "Name", "ParentCategoryId", "SortOrder", "Status", "UpdatedAt", "UpdatedBy" },
                values: new object[,]
                {
                    { 1, "elektronik", new DateTime(2024, 1, 1, 10, 0, 0, 0, DateTimeKind.Unspecified), null, "ELEC", "Elektronik", null, 1, 1, null, null },
                    { 2, "giyim", new DateTime(2024, 1, 1, 10, 0, 0, 0, DateTimeKind.Unspecified), null, "CLTH", "Giyim", null, 2, 1, null, null },
                    { 3, "ev-yasam", new DateTime(2024, 1, 1, 10, 0, 0, 0, DateTimeKind.Unspecified), null, "HOME", "Ev & Yaşam", null, 3, 1, null, null }
                });

            migrationBuilder.InsertData(
                table: "Contents",
                columns: new[] { "Id", "Author", "CreatedAt", "CreatedBy", "Description", "IsDeleted", "MetaDescription", "MetaKeywords", "MetaTitle", "RelatedDataEntityId", "RelatedDataEntityType", "Status", "SubDescription", "Title", "UpdatedAt", "UpdatedBy" },
                values: new object[,]
                {
                    { 1, "Pazar Atlası", new DateTime(2024, 1, 1, 10, 0, 0, 0, DateTimeKind.Unspecified), null, "Pazar Atlası CMS ana sayfası. Modern ve kullanıcı dostu içerik yönetim sistemi ile web sitenizi kolayca yönetin.", false, "Pazar Atlası CMS ana sayfası. Modern ve kullanıcı dostu içerik yönetim sistemi.", "cms, içerik yönetimi, pazar atlası, web sitesi, modern cms", "Ana Sayfa - Pazar Atlası CMS", 1, 1, 1, "Güçlü CMS çözümü ile dijital varlığınızı güçlendirin", "Ana Sayfa", null, null },
                    { 2, "Pazar Atlası", new DateTime(2024, 1, 2, 10, 0, 0, 0, DateTimeKind.Unspecified), null, "Pazar Atlası blog yazıları. Teknoloji, pazarlama ve iş dünyasından güncel haberler, ipuçları ve derinlemesine analizler.", false, "Pazar Atlası blog yazıları. Teknoloji, pazarlama ve iş dünyasından güncel haberler.", "blog, yazılar, teknoloji, pazarlama, iş, haberler, analiz", "Blog - Pazar Atlası CMS", 2, 1, 1, "Sektörden güncel haberler ve uzman görüşleri", "Blog", null, null },
                    { 3, "Pazar Atlası", new DateTime(2024, 1, 3, 10, 0, 0, 0, DateTimeKind.Unspecified), null, "Pazar Atlası ürün kataloğu. Kaliteli ve uygun fiyatlı ürünler, geniş kategori seçenekleri ve güvenli alışveriş imkanı.", false, "Pazar Atlası ürün kataloğu. Kaliteli ve uygun fiyatlı ürünler.", "ürünler, katalog, alışveriş, kalite, elektronik, giyim", "Ürünler - Pazar Atlası CMS", 3, 1, 1, "Kaliteli ürünler, uygun fiyatlar", "Ürünler", null, null }
                });

            migrationBuilder.InsertData(
                table: "Continents",
                columns: new[] { "Id", "Code", "CreatedAt", "CreatedBy", "IsActive", "Name", "SortOrder", "Status", "UpdatedAt", "UpdatedBy" },
                values: new object[,]
                {
                    { 1, "AF", new DateTime(2024, 1, 1, 10, 0, 0, 0, DateTimeKind.Unspecified), null, true, "Afrika", 1, 1, null, null },
                    { 2, "EU", new DateTime(2024, 1, 1, 10, 0, 0, 0, DateTimeKind.Unspecified), null, true, "Avrupa", 2, 1, null, null },
                    { 3, "NA", new DateTime(2024, 1, 1, 10, 0, 0, 0, DateTimeKind.Unspecified), null, true, "Kuzey Amerika", 3, 1, null, null },
                    { 4, "SA", new DateTime(2024, 1, 1, 10, 0, 0, 0, DateTimeKind.Unspecified), null, true, "Güney Amerika", 4, 1, null, null },
                    { 5, "AS", new DateTime(2024, 1, 1, 10, 0, 0, 0, DateTimeKind.Unspecified), null, true, "Asya", 5, 1, null, null },
                    { 6, "OC", new DateTime(2024, 1, 1, 10, 0, 0, 0, DateTimeKind.Unspecified), null, true, "Okyanusya", 6, 1, null, null }
                });

            migrationBuilder.InsertData(
                table: "DataSchemas",
                columns: new[] { "Id", "Configuration", "CreatedAt", "CreatedBy", "Description", "IsActive", "Key", "Name", "SortOrder", "Status", "UpdatedAt", "UpdatedBy" },
                values: new object[,]
                {
                    { 1, "{}", new DateTime(2025, 11, 7, 16, 2, 17, 725, DateTimeKind.Utc).AddTicks(7236), null, "General specifications for electronic products", true, "electronics-specs", "Electronics Specifications", 1, 1, null, null },
                    { 2, "{}", new DateTime(2025, 11, 7, 16, 2, 17, 725, DateTimeKind.Utc).AddTicks(7240), null, "Detailed specifications for smartphones", true, "smartphone-specs", "Smartphone Specifications", 2, 1, null, null },
                    { 3, "{}", new DateTime(2025, 11, 7, 16, 2, 17, 725, DateTimeKind.Utc).AddTicks(7243), null, "Detailed specifications for laptops", true, "laptop-specs", "Laptop Specifications", 3, 1, null, null }
                });

            migrationBuilder.InsertData(
                table: "Languages",
                columns: new[] { "Id", "Code", "CreatedAt", "CreatedBy", "Flag", "IsActive", "IsDefault", "Name", "NativeName", "SortOrder", "Status", "UpdatedAt", "UpdatedBy" },
                values: new object[] { 1, "tr-TR", new DateTime(2025, 11, 7, 16, 2, 17, 720, DateTimeKind.Utc).AddTicks(1558), null, "🇹🇷", true, true, "Türkçe", "Türkçe", 1, 0, null, null });

            migrationBuilder.InsertData(
                table: "Languages",
                columns: new[] { "Id", "Code", "CreatedAt", "CreatedBy", "Flag", "IsActive", "Name", "NativeName", "SortOrder", "Status", "UpdatedAt", "UpdatedBy" },
                values: new object[,]
                {
                    { 2, "en-US", new DateTime(2025, 11, 7, 16, 2, 17, 720, DateTimeKind.Utc).AddTicks(1563), null, "🇺🇸", true, "English", "English", 2, 0, null, null },
                    { 3, "de-DE", new DateTime(2025, 11, 7, 16, 2, 17, 720, DateTimeKind.Utc).AddTicks(1565), null, "🇩🇪", true, "Deutsch", "Deutsch", 3, 0, null, null },
                    { 4, "fr-FR", new DateTime(2025, 11, 7, 16, 2, 17, 720, DateTimeKind.Utc).AddTicks(1567), null, "🇫🇷", true, "Français", "Français", 4, 0, null, null },
                    { 5, "es-ES", new DateTime(2025, 11, 7, 16, 2, 17, 720, DateTimeKind.Utc).AddTicks(1569), null, "🇪🇸", true, "Español", "Español", 5, 0, null, null }
                });

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

            migrationBuilder.InsertData(
                table: "Options",
                columns: new[] { "Id", "Code", "CreatedAt", "CreatedBy", "DefaultValue", "IntegrationCode", "LongDescription", "Name", "ParentId", "ShortDescription", "SortOrder", "Status", "Type", "UpdatedAt", "UpdatedBy" },
                values: new object[,]
                {
                    { 1, "color", new DateTime(2025, 11, 7, 16, 2, 17, 732, DateTimeKind.Utc).AddTicks(2020), null, null, "", "", "Color", null, "", 1, 1, 3, null, null },
                    { 2, "size", new DateTime(2025, 11, 7, 16, 2, 17, 732, DateTimeKind.Utc).AddTicks(2024), null, null, "", "", "Size", null, "", 2, 1, 4, null, null },
                    { 3, "material", new DateTime(2025, 11, 7, 16, 2, 17, 732, DateTimeKind.Utc).AddTicks(2027), null, null, "", "", "Material", null, "", 3, 1, 5, null, null },
                    { 4, "weight", new DateTime(2025, 11, 7, 16, 2, 17, 732, DateTimeKind.Utc).AddTicks(2029), null, null, "", "", "Weight", null, "", 4, 1, 2, null, null },
                    { 5, "warranty", new DateTime(2025, 11, 7, 16, 2, 17, 732, DateTimeKind.Utc).AddTicks(2031), null, null, "", "", "Warranty", null, "", 5, 1, 6, null, null }
                });

            migrationBuilder.InsertData(
                table: "Pages",
                columns: new[] { "Id", "Code", "ContentId", "CreatedAt", "CreatedBy", "Description", "LayoutId", "Name", "PageSEOParameterId", "PageType", "ParentPageId", "Status", "UpdatedAt", "UpdatedBy" },
                values: new object[] { 4, "corporate", null, new DateTime(2024, 1, 4, 10, 0, 0, 0, DateTimeKind.Unspecified), null, "Kurumsal sayfalar", null, "Kurumsal", null, 2, null, 1, null, null });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Code", "CreatedAt", "CreatedBy", "IntegrationCode", "LongDescription", "Name", "ParentId", "ShortDescription", "Status", "TaxRate", "Type", "Unit", "UpdatedAt", "UpdatedBy" },
                values: new object[,]
                {
                    { 1, "iphone-15-pro", new DateTime(2025, 11, 7, 16, 2, 17, 734, DateTimeKind.Utc).AddTicks(5438), null, "APPLE-IP15P", "The iPhone 15 Pro features a titanium design, A17 Pro chip, and advanced camera system.", "iPhone 15 Pro", null, "Latest iPhone with Pro features", 1, 18m, 2, "pcs", null, null },
                    { 2, "galaxy-s24", new DateTime(2025, 11, 7, 16, 2, 17, 734, DateTimeKind.Utc).AddTicks(5443), null, "SAMSUNG-GS24", "Samsung Galaxy S24 with AI-powered features and exceptional camera quality.", "Samsung Galaxy S24", null, "Premium Android smartphone", 1, 18m, 2, "pcs", null, null },
                    { 3, "macbook-pro-14", new DateTime(2025, 11, 7, 16, 2, 17, 734, DateTimeKind.Utc).AddTicks(5446), null, "APPLE-MBP14", "MacBook Pro 14-inch with M3 chip, perfect for professional workflows.", "MacBook Pro 14\"", null, "Professional laptop for creators", 1, 18m, 2, "pcs", null, null },
                    { 4, "dell-xps-13", new DateTime(2025, 11, 7, 16, 2, 17, 734, DateTimeKind.Utc).AddTicks(5450), null, "DELL-XPS13", "Dell XPS 13 with Intel Core processors and premium build quality.", "Dell XPS 13", null, "Ultra-portable Windows laptop", 1, 18m, 2, "pcs", null, null },
                    { 5, "airpods-pro", new DateTime(2025, 11, 7, 16, 2, 17, 734, DateTimeKind.Utc).AddTicks(5453), null, "APPLE-APP", "AirPods Pro with active noise cancellation and spatial audio.", "AirPods Pro", null, "Wireless earbuds with ANC", 1, 18m, 1, "pcs", null, null }
                });

            migrationBuilder.InsertData(
                table: "Sections",
                columns: new[] { "Id", "Attributes", "Configure", "CreatedAt", "CreatedBy", "Key", "SortOrder", "Status", "Type", "UpdatedAt", "UpdatedBy" },
                values: new object[,]
                {
                    { 1, "{\"backgroundImage\": \"hero-bg.jpg\", \"height\": \"500px\"}", "{\"showButton\": true, \"buttonText\": \"Keşfet\"}", new DateTime(2024, 1, 1, 10, 0, 0, 0, DateTimeKind.Unspecified), null, "home-hero", 1, 1, 3, null, null },
                    { 2, "{\"columns\": 3}", "{\"maxItems\": 6, \"showMore\": true, \"showPrices\": true}", new DateTime(2024, 1, 1, 10, 0, 0, 0, DateTimeKind.Unspecified), null, "home-featured-products", 2, 1, 6, null, null },
                    { 3, "{\"backgroundColor\": \"#f8f9fa\"}", "{\"showPrivacyText\": true}", new DateTime(2024, 1, 1, 10, 0, 0, 0, DateTimeKind.Unspecified), null, "home-newsletter", 3, 1, 7, null, null },
                    { 4, "{}", "{\"showSearchBox\": true,\"showBreadcrumbs\": true}", new DateTime(2024, 1, 2, 10, 0, 0, 0, DateTimeKind.Unspecified), null, "blog-header", 1, 1, 2, null, null },
                    { 5, "{}", "{\"showExcerpt\": true, \"showAuthor\": true, \"showDate\": true,\"postsPerPage\": 10}", new DateTime(2024, 1, 2, 10, 0, 0, 0, DateTimeKind.Unspecified), null, "blog-main-content", 2, 1, 12, null, null },
                    { 6, "{\"columns\": 4}", "{\"productsPerPage\": 20, \"showSorting\": true, \"showFilters\": true}", new DateTime(2024, 1, 3, 10, 0, 0, 0, DateTimeKind.Unspecified), null, "products-catalog", 1, 1, 4, null, null }
                });

            migrationBuilder.InsertData(
                table: "Templates",
                columns: new[] { "Id", "ConfigurationSchema", "CreatedAt", "CreatedBy", "IsActive", "IsDeleted", "SortOrder", "Status", "TemplateKey", "UpdatedAt", "UpdatedBy" },
                values: new object[,]
                {
                    { 1, "{\"type\":\"object\",\"properties\":{\"backgroundColor\":{\"type\":\"string\",\"default\":\"#ffffff\"},\"textColor\":{\"type\":\"string\",\"default\":\"#333333\"},\"showLogo\":{\"type\":\"boolean\",\"default\":true},\"logoPosition\":{\"type\":\"string\",\"enum\":[\"left\",\"center\",\"right\"],\"default\":\"left\"}}}", new DateTime(2024, 10, 14, 10, 0, 0, 0, DateTimeKind.Unspecified), null, true, false, 1, 0, "navbar-simple", null, null },
                    { 2, "{\"type\":\"object\",\"properties\":{\"backgroundColor\":{\"type\":\"string\",\"default\":\"#1a1a1a\"},\"textColor\":{\"type\":\"string\",\"default\":\"#ffffff\"},\"showLogo\":{\"type\":\"boolean\",\"default\":true},\"logoPosition\":{\"type\":\"string\",\"enum\":[\"left\",\"center\",\"right\"],\"default\":\"left\"},\"megaMenuColumns\":{\"type\":\"integer\",\"minimum\":2,\"maximum\":4,\"default\":3},\"showDescriptions\":{\"type\":\"boolean\",\"default\":true},\"showImages\":{\"type\":\"boolean\",\"default\":true}}}", new DateTime(2024, 10, 14, 10, 0, 0, 0, DateTimeKind.Unspecified), null, true, false, 2, 0, "navbar-megamenu", null, null },
                    { 3, "{\"type\":\"object\",\"properties\":{\"backgroundColor\":{\"type\":\"string\",\"default\":\"#2d3748\"},\"textColor\":{\"type\":\"string\",\"default\":\"#ffffff\"},\"showLogo\":{\"type\":\"boolean\",\"default\":true},\"logoPosition\":{\"type\":\"string\",\"enum\":[\"left\",\"center\",\"right\"],\"default\":\"left\"},\"tabStyle\":{\"type\":\"string\",\"enum\":[\"pills\",\"underline\",\"background\"],\"default\":\"pills\"},\"showIcons\":{\"type\":\"boolean\",\"default\":true},\"animationDuration\":{\"type\":\"integer\",\"minimum\":100,\"maximum\":1000,\"default\":300}}}", new DateTime(2024, 10, 14, 10, 0, 0, 0, DateTimeKind.Unspecified), null, true, false, 3, 0, "navbar-servicetabs", null, null },
                    { 4, "{\"type\":\"object\",\"properties\":{\"backgroundColor\":{\"type\":\"string\",\"default\":\"#4a5568\"},\"textColor\":{\"type\":\"string\",\"default\":\"#ffffff\"},\"showLogo\":{\"type\":\"boolean\",\"default\":true},\"logoPosition\":{\"type\":\"string\",\"enum\":[\"left\",\"center\",\"right\"],\"default\":\"left\"},\"categoryStyle\":{\"type\":\"string\",\"enum\":[\"sidebar\",\"dropdown\",\"tabs\"],\"default\":\"sidebar\"},\"showCategoryIcons\":{\"type\":\"boolean\",\"default\":true},\"itemsPerCategory\":{\"type\":\"integer\",\"minimum\":2,\"maximum\":8,\"default\":4}}}", new DateTime(2024, 10, 14, 10, 0, 0, 0, DateTimeKind.Unspecified), null, true, false, 4, 0, "navbar-categorized", null, null },
                    { 5, "{\"type\":\"object\",\"properties\":{\"backgroundColor\":{\"type\":\"string\",\"default\":\"#ffffff\"},\"textColor\":{\"type\":\"string\",\"default\":\"#333333\"},\"padding\":{\"type\":\"string\",\"enum\":[\"small\",\"medium\",\"large\"],\"default\":\"medium\"}}}", new DateTime(2024, 10, 14, 10, 0, 0, 0, DateTimeKind.Unspecified), null, true, false, 5, 0, "default", null, null },
                    { 6, "{\"type\":\"object\",\"properties\":{\"direction\":{\"type\":\"string\",\"enum\":[\"horizontal\",\"vertical\"],\"default\":\"vertical\"},\"spacing\":{\"type\":\"string\",\"enum\":[\"small\",\"medium\",\"large\"],\"default\":\"medium\"},\"showNumbers\":{\"type\":\"boolean\",\"default\":false}}}", new DateTime(2024, 10, 14, 10, 0, 0, 0, DateTimeKind.Unspecified), null, true, false, 6, 0, "sequential", null, null },
                    { 7, "{\"type\":\"object\",\"properties\":{\"columns\":{\"type\":\"integer\",\"minimum\":1,\"maximum\":6,\"default\":3},\"gap\":{\"type\":\"string\",\"enum\":[\"small\",\"medium\",\"large\"],\"default\":\"medium\"},\"showImages\":{\"type\":\"boolean\",\"default\":true},\"showExcerpts\":{\"type\":\"boolean\",\"default\":true}}}", new DateTime(2024, 10, 14, 10, 0, 0, 0, DateTimeKind.Unspecified), null, true, false, 7, 0, "grid", null, null },
                    { 8, "{\"type\":\"object\",\"properties\":{\"columns\":{\"type\":\"integer\",\"minimum\":2,\"maximum\":5,\"default\":3},\"gap\":{\"type\":\"string\",\"enum\":[\"small\",\"medium\",\"large\"],\"default\":\"medium\"},\"showImages\":{\"type\":\"boolean\",\"default\":true},\"imageAspectRatio\":{\"type\":\"string\",\"enum\":[\"auto\",\"square\",\"landscape\",\"portrait\"],\"default\":\"auto\"}}}", new DateTime(2024, 10, 14, 10, 0, 0, 0, DateTimeKind.Unspecified), null, true, false, 8, 0, "masonry", null, null },
                    { 9, "{\"type\":\"object\",\"properties\":{\"autoPlay\":{\"type\":\"boolean\",\"default\":true},\"interval\":{\"type\":\"integer\",\"minimum\":2000,\"maximum\":10000,\"default\":5000},\"showIndicators\":{\"type\":\"boolean\",\"default\":true},\"showArrows\":{\"type\":\"boolean\",\"default\":true},\"transitionEffect\":{\"type\":\"string\",\"enum\":[\"fade\",\"slide\",\"zoom\"],\"default\":\"slide\"}}}", new DateTime(2024, 10, 14, 10, 0, 0, 0, DateTimeKind.Unspecified), null, true, false, 9, 0, "carousel", null, null },
                    { 10, "{\"type\":\"object\",\"properties\":{\"showIcons\":{\"type\":\"boolean\",\"default\":true},\"iconPosition\":{\"type\":\"string\",\"enum\":[\"left\",\"right\"],\"default\":\"left\"},\"spacing\":{\"type\":\"string\",\"enum\":[\"compact\",\"comfortable\",\"spacious\"],\"default\":\"comfortable\"},\"showDividers\":{\"type\":\"boolean\",\"default\":false}}}", new DateTime(2024, 10, 14, 10, 0, 0, 0, DateTimeKind.Unspecified), null, true, false, 10, 0, "list", null, null },
                    { 11, "{\"type\":\"object\",\"properties\":{\"alignment\":{\"type\":\"string\",\"enum\":[\"left\",\"center\",\"right\"],\"default\":\"center\"},\"showImage\":{\"type\":\"boolean\",\"default\":true},\"imageSize\":{\"type\":\"string\",\"enum\":[\"small\",\"medium\",\"large\"],\"default\":\"medium\"},\"showDescription\":{\"type\":\"boolean\",\"default\":true}}}", new DateTime(2024, 10, 14, 10, 0, 0, 0, DateTimeKind.Unspecified), null, true, false, 11, 0, "single-item", null, null },
                    { 12, "{\"type\":\"object\",\"properties\":{\"itemsPerRow\":{\"type\":\"integer\",\"minimum\":2,\"maximum\":6,\"default\":3},\"showTitles\":{\"type\":\"boolean\",\"default\":true},\"showDescriptions\":{\"type\":\"boolean\",\"default\":true},\"equalHeight\":{\"type\":\"boolean\",\"default\":true}}}", new DateTime(2024, 10, 14, 10, 0, 0, 0, DateTimeKind.Unspecified), null, true, false, 12, 0, "multi-item", null, null },
                    { 13, "{\"type\":\"object\",\"properties\":{\"allowMultiple\":{\"type\":\"boolean\",\"default\":false},\"defaultOpen\":{\"type\":\"integer\",\"minimum\":0,\"default\":0},\"showIcons\":{\"type\":\"boolean\",\"default\":true},\"animationDuration\":{\"type\":\"integer\",\"minimum\":100,\"maximum\":1000,\"default\":300}}}", new DateTime(2024, 10, 14, 10, 0, 0, 0, DateTimeKind.Unspecified), null, true, false, 13, 0, "accordion", null, null },
                    { 14, "{\"type\":\"object\",\"properties\":{\"tabPosition\":{\"type\":\"string\",\"enum\":[\"top\",\"bottom\",\"left\",\"right\"],\"default\":\"top\"},\"tabStyle\":{\"type\":\"string\",\"enum\":[\"pills\",\"underline\",\"background\"],\"default\":\"underline\"},\"showIcons\":{\"type\":\"boolean\",\"default\":false},\"defaultTab\":{\"type\":\"integer\",\"minimum\":0,\"default\":0}}}", new DateTime(2024, 10, 14, 10, 0, 0, 0, DateTimeKind.Unspecified), null, true, false, 14, 0, "tabs", null, null }
                });

            migrationBuilder.InsertData(
                table: "Trademarks",
                columns: new[] { "Id", "Code", "CreatedAt", "CreatedBy", "IntegrationCode", "LongDescription", "Name", "ParentId", "ShortDescription", "SortOrder", "Status", "UpdatedAt", "UpdatedBy" },
                values: new object[,]
                {
                    { 1, "apple", new DateTime(2025, 11, 7, 16, 2, 17, 737, DateTimeKind.Utc).AddTicks(8012), null, "APPLE", "Apple Inc. is an American multinational technology company.", "Apple", null, "Technology company", 1, 1, null, null },
                    { 2, "samsung", new DateTime(2025, 11, 7, 16, 2, 17, 737, DateTimeKind.Utc).AddTicks(8016), null, "SAMSUNG", "Samsung Electronics is a South Korean multinational electronics corporation.", "Samsung", null, "Electronics manufacturer", 2, 1, null, null },
                    { 3, "dell", new DateTime(2025, 11, 7, 16, 2, 17, 737, DateTimeKind.Utc).AddTicks(8018), null, "DELL", "Dell Technologies is an American multinational computer technology company.", "Dell", null, "Computer technology company", 3, 1, null, null },
                    { 4, "microsoft", new DateTime(2025, 11, 7, 16, 2, 17, 737, DateTimeKind.Utc).AddTicks(8021), null, "MICROSOFT", "Microsoft Corporation is an American multinational technology corporation.", "Microsoft", null, "Software corporation", 4, 1, null, null },
                    { 5, "sony", new DateTime(2025, 11, 7, 16, 2, 17, 737, DateTimeKind.Utc).AddTicks(8023), null, "SONY", "Sony Corporation is a Japanese multinational conglomerate corporation.", "Sony", null, "Entertainment and technology", 5, 1, null, null }
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Code", "CreatedAt", "CreatedBy", "IntegrationCode", "Name", "ParentCategoryId", "SortOrder", "Status", "UpdatedAt", "UpdatedBy" },
                values: new object[,]
                {
                    { 4, "bilgisayar", new DateTime(2024, 1, 1, 10, 0, 0, 0, DateTimeKind.Unspecified), null, "COMP", "Bilgisayar", 1, 1, 1, null, null },
                    { 5, "telefon", new DateTime(2024, 1, 1, 10, 0, 0, 0, DateTimeKind.Unspecified), null, "PHONE", "Telefon", 1, 2, 1, null, null },
                    { 6, "erkek-giyim", new DateTime(2024, 1, 1, 10, 0, 0, 0, DateTimeKind.Unspecified), null, "MENS", "Erkek Giyim", 2, 1, 1, null, null },
                    { 7, "kadin-giyim", new DateTime(2024, 1, 1, 10, 0, 0, 0, DateTimeKind.Unspecified), null, "WMNS", "Kadın Giyim", 2, 2, 1, null, null }
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
                    { 6, 3, new DateTime(2024, 1, 1, 10, 0, 0, 0, DateTimeKind.Unspecified), null, 2, "Category for home decoration, kitchen items and living products", "Home & Living", "Home and living products", 1, null, null }
                });

            migrationBuilder.InsertData(
                table: "ContentSlugs",
                columns: new[] { "Id", "ContentId", "CreatedAt", "CreatedBy", "IsCanonical", "IsDeleted", "LanguageId", "Priority", "Slug", "Status", "UpdatedAt", "UpdatedBy" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2024, 1, 1, 10, 0, 0, 0, DateTimeKind.Unspecified), null, true, false, 1, 1, "ana-sayfa", 0, null, null },
                    { 2, 1, new DateTime(2024, 1, 1, 10, 0, 0, 0, DateTimeKind.Unspecified), null, true, false, 2, 1, "home", 0, null, null },
                    { 3, 2, new DateTime(2024, 1, 2, 10, 0, 0, 0, DateTimeKind.Unspecified), null, true, false, 1, 1, "blog", 0, null, null },
                    { 4, 2, new DateTime(2024, 1, 2, 10, 0, 0, 0, DateTimeKind.Unspecified), null, true, false, 2, 1, "blog", 0, null, null },
                    { 5, 3, new DateTime(2024, 1, 3, 10, 0, 0, 0, DateTimeKind.Unspecified), null, true, false, 1, 1, "urunler", 0, null, null },
                    { 6, 3, new DateTime(2024, 1, 3, 10, 0, 0, 0, DateTimeKind.Unspecified), null, true, false, 2, 1, "products", 0, null, null }
                });

            migrationBuilder.InsertData(
                table: "ContentSlugs",
                columns: new[] { "Id", "ContentId", "CreatedAt", "CreatedBy", "IsDeleted", "LanguageId", "Priority", "Slug", "Status", "UpdatedAt", "UpdatedBy" },
                values: new object[,]
                {
                    { 7, 1, new DateTime(2024, 1, 1, 10, 0, 0, 0, DateTimeKind.Unspecified), null, false, 1, 2, "anasayfa", 0, null, null },
                    { 8, 3, new DateTime(2024, 1, 3, 10, 0, 0, 0, DateTimeKind.Unspecified), null, false, 1, 2, "katalog", 0, null, null }
                });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Code", "ContinentId", "CreatedAt", "CreatedBy", "IsActive", "Name", "SortOrder", "Status", "UpdatedAt", "UpdatedBy" },
                values: new object[,]
                {
                    { 1, "EG", 1, new DateTime(2024, 1, 1, 10, 0, 0, 0, DateTimeKind.Unspecified), null, true, "Mısır", 1, 1, null, null },
                    { 2, "GA", 1, new DateTime(2024, 1, 1, 10, 0, 0, 0, DateTimeKind.Unspecified), null, true, "Gabon", 2, 1, null, null },
                    { 3, "GH", 1, new DateTime(2024, 1, 1, 10, 0, 0, 0, DateTimeKind.Unspecified), null, true, "Gana", 3, 1, null, null },
                    { 4, "ET", 1, new DateTime(2024, 1, 1, 10, 0, 0, 0, DateTimeKind.Unspecified), null, true, "Etiyopya", 4, 1, null, null },
                    { 5, "KE", 1, new DateTime(2024, 1, 1, 10, 0, 0, 0, DateTimeKind.Unspecified), null, true, "Kenya", 5, 1, null, null },
                    { 6, "TZ", 1, new DateTime(2024, 1, 1, 10, 0, 0, 0, DateTimeKind.Unspecified), null, true, "Tanzanya", 6, 1, null, null }
                });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Code", "ContinentId", "CreatedAt", "CreatedBy", "IsActive", "IsPopular", "Name", "SortOrder", "Status", "UpdatedAt", "UpdatedBy" },
                values: new object[] { 7, "ZA", 1, new DateTime(2024, 1, 1, 10, 0, 0, 0, DateTimeKind.Unspecified), null, true, true, "Güney Afrika", 7, 1, null, null });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Code", "ContinentId", "CreatedAt", "CreatedBy", "IsActive", "Name", "SortOrder", "Status", "UpdatedAt", "UpdatedBy" },
                values: new object[,]
                {
                    { 8, "NG", 1, new DateTime(2024, 1, 1, 10, 0, 0, 0, DateTimeKind.Unspecified), null, true, "Nijerya", 8, 1, null, null },
                    { 9, "SN", 1, new DateTime(2024, 1, 1, 10, 0, 0, 0, DateTimeKind.Unspecified), null, true, "Senegal", 9, 1, null, null },
                    { 10, "MA", 1, new DateTime(2024, 1, 1, 10, 0, 0, 0, DateTimeKind.Unspecified), null, true, "Fas", 10, 1, null, null },
                    { 11, "TN", 1, new DateTime(2024, 1, 1, 10, 0, 0, 0, DateTimeKind.Unspecified), null, true, "Tunus", 11, 1, null, null },
                    { 12, "DZ", 1, new DateTime(2024, 1, 1, 10, 0, 0, 0, DateTimeKind.Unspecified), null, true, "Cezayir", 12, 1, null, null },
                    { 13, "UG", 1, new DateTime(2024, 1, 1, 10, 0, 0, 0, DateTimeKind.Unspecified), null, true, "Uganda", 13, 1, null, null },
                    { 14, "RW", 1, new DateTime(2024, 1, 1, 10, 0, 0, 0, DateTimeKind.Unspecified), null, true, "Ruanda", 14, 1, null, null },
                    { 15, "CM", 1, new DateTime(2024, 1, 1, 10, 0, 0, 0, DateTimeKind.Unspecified), null, true, "Kamerun", 15, 1, null, null }
                });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Code", "ContinentId", "CreatedAt", "CreatedBy", "IsActive", "IsPopular", "Name", "SortOrder", "Status", "UpdatedAt", "UpdatedBy" },
                values: new object[,]
                {
                    { 16, "DE", 2, new DateTime(2024, 1, 1, 10, 0, 0, 0, DateTimeKind.Unspecified), null, true, true, "Almanya", 16, 1, null, null },
                    { 17, "FR", 2, new DateTime(2024, 1, 1, 10, 0, 0, 0, DateTimeKind.Unspecified), null, true, true, "Fransa", 17, 1, null, null },
                    { 18, "GB", 2, new DateTime(2024, 1, 1, 10, 0, 0, 0, DateTimeKind.Unspecified), null, true, true, "İngiltere", 18, 1, null, null },
                    { 19, "IT", 2, new DateTime(2024, 1, 1, 10, 0, 0, 0, DateTimeKind.Unspecified), null, true, true, "İtalya", 19, 1, null, null },
                    { 20, "ES", 2, new DateTime(2024, 1, 1, 10, 0, 0, 0, DateTimeKind.Unspecified), null, true, true, "İspanya", 20, 1, null, null }
                });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Code", "ContinentId", "CreatedAt", "CreatedBy", "IsActive", "Name", "SortOrder", "Status", "UpdatedAt", "UpdatedBy" },
                values: new object[,]
                {
                    { 21, "NL", 2, new DateTime(2024, 1, 1, 10, 0, 0, 0, DateTimeKind.Unspecified), null, true, "Hollanda", 21, 1, null, null },
                    { 22, "BE", 2, new DateTime(2024, 1, 1, 10, 0, 0, 0, DateTimeKind.Unspecified), null, true, "Belçika", 22, 1, null, null },
                    { 23, "PL", 2, new DateTime(2024, 1, 1, 10, 0, 0, 0, DateTimeKind.Unspecified), null, true, "Polonya", 23, 1, null, null },
                    { 24, "RO", 2, new DateTime(2024, 1, 1, 10, 0, 0, 0, DateTimeKind.Unspecified), null, true, "Romanya", 24, 1, null, null },
                    { 25, "GR", 2, new DateTime(2024, 1, 1, 10, 0, 0, 0, DateTimeKind.Unspecified), null, true, "Yunanistan", 25, 1, null, null },
                    { 26, "PT", 2, new DateTime(2024, 1, 1, 10, 0, 0, 0, DateTimeKind.Unspecified), null, true, "Portekiz", 26, 1, null, null },
                    { 27, "AT", 2, new DateTime(2024, 1, 1, 10, 0, 0, 0, DateTimeKind.Unspecified), null, true, "Avusturya", 27, 1, null, null },
                    { 28, "CH", 2, new DateTime(2024, 1, 1, 10, 0, 0, 0, DateTimeKind.Unspecified), null, true, "İsviçre", 28, 1, null, null },
                    { 29, "SE", 2, new DateTime(2024, 1, 1, 10, 0, 0, 0, DateTimeKind.Unspecified), null, true, "İsveç", 29, 1, null, null },
                    { 30, "NO", 2, new DateTime(2024, 1, 1, 10, 0, 0, 0, DateTimeKind.Unspecified), null, true, "Norveç", 30, 1, null, null },
                    { 31, "DK", 2, new DateTime(2024, 1, 1, 10, 0, 0, 0, DateTimeKind.Unspecified), null, true, "Danimarka", 31, 1, null, null },
                    { 32, "FI", 2, new DateTime(2024, 1, 1, 10, 0, 0, 0, DateTimeKind.Unspecified), null, true, "Finlandiya", 32, 1, null, null },
                    { 33, "CZ", 2, new DateTime(2024, 1, 1, 10, 0, 0, 0, DateTimeKind.Unspecified), null, true, "Çek Cumhuriyeti", 33, 1, null, null },
                    { 34, "HU", 2, new DateTime(2024, 1, 1, 10, 0, 0, 0, DateTimeKind.Unspecified), null, true, "Macaristan", 34, 1, null, null },
                    { 35, "BG", 2, new DateTime(2024, 1, 1, 10, 0, 0, 0, DateTimeKind.Unspecified), null, true, "Bulgaristan", 35, 1, null, null },
                    { 36, "HR", 2, new DateTime(2024, 1, 1, 10, 0, 0, 0, DateTimeKind.Unspecified), null, true, "Hırvatistan", 36, 1, null, null },
                    { 37, "SK", 2, new DateTime(2024, 1, 1, 10, 0, 0, 0, DateTimeKind.Unspecified), null, true, "Slovakya", 37, 1, null, null },
                    { 38, "SI", 2, new DateTime(2024, 1, 1, 10, 0, 0, 0, DateTimeKind.Unspecified), null, true, "Slovenya", 38, 1, null, null },
                    { 39, "LT", 2, new DateTime(2024, 1, 1, 10, 0, 0, 0, DateTimeKind.Unspecified), null, true, "Litvanya", 39, 1, null, null },
                    { 40, "LV", 2, new DateTime(2024, 1, 1, 10, 0, 0, 0, DateTimeKind.Unspecified), null, true, "Letonya", 40, 1, null, null },
                    { 41, "EE", 2, new DateTime(2024, 1, 1, 10, 0, 0, 0, DateTimeKind.Unspecified), null, true, "Estonya", 41, 1, null, null }
                });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Code", "ContinentId", "CreatedAt", "CreatedBy", "IsActive", "IsPopular", "Name", "SortOrder", "Status", "UpdatedAt", "UpdatedBy" },
                values: new object[,]
                {
                    { 42, "US", 3, new DateTime(2024, 1, 1, 10, 0, 0, 0, DateTimeKind.Unspecified), null, true, true, "Amerika Birleşik Devletleri", 42, 1, null, null },
                    { 43, "CA", 3, new DateTime(2024, 1, 1, 10, 0, 0, 0, DateTimeKind.Unspecified), null, true, true, "Kanada", 43, 1, null, null }
                });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Code", "ContinentId", "CreatedAt", "CreatedBy", "IsActive", "Name", "SortOrder", "Status", "UpdatedAt", "UpdatedBy" },
                values: new object[] { 44, "MX", 3, new DateTime(2024, 1, 1, 10, 0, 0, 0, DateTimeKind.Unspecified), null, true, "Meksika", 44, 1, null, null });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Code", "ContinentId", "CreatedAt", "CreatedBy", "IsActive", "IsPopular", "Name", "SortOrder", "Status", "UpdatedAt", "UpdatedBy" },
                values: new object[] { 45, "BR", 4, new DateTime(2024, 1, 1, 10, 0, 0, 0, DateTimeKind.Unspecified), null, true, true, "Brezilya", 45, 1, null, null });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Code", "ContinentId", "CreatedAt", "CreatedBy", "IsActive", "Name", "SortOrder", "Status", "UpdatedAt", "UpdatedBy" },
                values: new object[,]
                {
                    { 46, "AR", 4, new DateTime(2024, 1, 1, 10, 0, 0, 0, DateTimeKind.Unspecified), null, true, "Arjantin", 46, 1, null, null },
                    { 47, "CL", 4, new DateTime(2024, 1, 1, 10, 0, 0, 0, DateTimeKind.Unspecified), null, true, "Şili", 47, 1, null, null },
                    { 48, "CO", 4, new DateTime(2024, 1, 1, 10, 0, 0, 0, DateTimeKind.Unspecified), null, true, "Kolombiya", 48, 1, null, null },
                    { 49, "PE", 4, new DateTime(2024, 1, 1, 10, 0, 0, 0, DateTimeKind.Unspecified), null, true, "Peru", 49, 1, null, null },
                    { 50, "VE", 4, new DateTime(2024, 1, 1, 10, 0, 0, 0, DateTimeKind.Unspecified), null, true, "Venezuela", 50, 1, null, null },
                    { 51, "EC", 4, new DateTime(2024, 1, 1, 10, 0, 0, 0, DateTimeKind.Unspecified), null, true, "Ekvador", 51, 1, null, null },
                    { 52, "UY", 4, new DateTime(2024, 1, 1, 10, 0, 0, 0, DateTimeKind.Unspecified), null, true, "Uruguay", 52, 1, null, null },
                    { 53, "PY", 4, new DateTime(2024, 1, 1, 10, 0, 0, 0, DateTimeKind.Unspecified), null, true, "Paraguay", 53, 1, null, null },
                    { 54, "BO", 4, new DateTime(2024, 1, 1, 10, 0, 0, 0, DateTimeKind.Unspecified), null, true, "Bolivya", 54, 1, null, null }
                });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Code", "ContinentId", "CreatedAt", "CreatedBy", "IsActive", "IsPopular", "Name", "SortOrder", "Status", "UpdatedAt", "UpdatedBy" },
                values: new object[,]
                {
                    { 55, "CN", 5, new DateTime(2024, 1, 1, 10, 0, 0, 0, DateTimeKind.Unspecified), null, true, true, "Çin", 55, 1, null, null },
                    { 56, "JP", 5, new DateTime(2024, 1, 1, 10, 0, 0, 0, DateTimeKind.Unspecified), null, true, true, "Japonya", 56, 1, null, null }
                });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Code", "ContinentId", "CreatedAt", "CreatedBy", "IsActive", "Name", "SortOrder", "Status", "UpdatedAt", "UpdatedBy" },
                values: new object[] { 57, "KR", 5, new DateTime(2024, 1, 1, 10, 0, 0, 0, DateTimeKind.Unspecified), null, true, "Güney Kore", 57, 1, null, null });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Code", "ContinentId", "CreatedAt", "CreatedBy", "IsActive", "IsPopular", "Name", "SortOrder", "Status", "UpdatedAt", "UpdatedBy" },
                values: new object[] { 58, "IN", 5, new DateTime(2024, 1, 1, 10, 0, 0, 0, DateTimeKind.Unspecified), null, true, true, "Hindistan", 58, 1, null, null });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Code", "ContinentId", "CreatedAt", "CreatedBy", "IsActive", "Name", "SortOrder", "Status", "UpdatedAt", "UpdatedBy" },
                values: new object[,]
                {
                    { 59, "PK", 5, new DateTime(2024, 1, 1, 10, 0, 0, 0, DateTimeKind.Unspecified), null, true, "Pakistan", 59, 1, null, null },
                    { 60, "BD", 5, new DateTime(2024, 1, 1, 10, 0, 0, 0, DateTimeKind.Unspecified), null, true, "Bangladeş", 60, 1, null, null },
                    { 61, "ID", 5, new DateTime(2024, 1, 1, 10, 0, 0, 0, DateTimeKind.Unspecified), null, true, "Endonezya", 61, 1, null, null },
                    { 62, "PH", 5, new DateTime(2024, 1, 1, 10, 0, 0, 0, DateTimeKind.Unspecified), null, true, "Filipinler", 62, 1, null, null },
                    { 63, "VN", 5, new DateTime(2024, 1, 1, 10, 0, 0, 0, DateTimeKind.Unspecified), null, true, "Vietnam", 63, 1, null, null },
                    { 64, "TH", 5, new DateTime(2024, 1, 1, 10, 0, 0, 0, DateTimeKind.Unspecified), null, true, "Tayland", 64, 1, null, null },
                    { 65, "MY", 5, new DateTime(2024, 1, 1, 10, 0, 0, 0, DateTimeKind.Unspecified), null, true, "Malezya", 65, 1, null, null },
                    { 66, "SG", 5, new DateTime(2024, 1, 1, 10, 0, 0, 0, DateTimeKind.Unspecified), null, true, "Singapur", 66, 1, null, null },
                    { 67, "MM", 5, new DateTime(2024, 1, 1, 10, 0, 0, 0, DateTimeKind.Unspecified), null, true, "Myanmar", 67, 1, null, null },
                    { 68, "KH", 5, new DateTime(2024, 1, 1, 10, 0, 0, 0, DateTimeKind.Unspecified), null, true, "Kamboçya", 68, 1, null, null },
                    { 69, "LA", 5, new DateTime(2024, 1, 1, 10, 0, 0, 0, DateTimeKind.Unspecified), null, true, "Laos", 69, 1, null, null },
                    { 70, "LK", 5, new DateTime(2024, 1, 1, 10, 0, 0, 0, DateTimeKind.Unspecified), null, true, "Sri Lanka", 70, 1, null, null },
                    { 71, "NP", 5, new DateTime(2024, 1, 1, 10, 0, 0, 0, DateTimeKind.Unspecified), null, true, "Nepal", 71, 1, null, null }
                });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Code", "ContinentId", "CreatedAt", "CreatedBy", "IsActive", "IsPopular", "Name", "SortOrder", "Status", "UpdatedAt", "UpdatedBy" },
                values: new object[] { 72, "AU", 6, new DateTime(2024, 1, 1, 10, 0, 0, 0, DateTimeKind.Unspecified), null, true, true, "Avustralya", 72, 1, null, null });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Code", "ContinentId", "CreatedAt", "CreatedBy", "IsActive", "Name", "SortOrder", "Status", "UpdatedAt", "UpdatedBy" },
                values: new object[] { 73, "NZ", 6, new DateTime(2024, 1, 1, 10, 0, 0, 0, DateTimeKind.Unspecified), null, true, "Yeni Zelanda", 73, 1, null, null });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Code", "ContinentId", "CreatedAt", "CreatedBy", "IsActive", "IsPopular", "Name", "SortOrder", "Status", "UpdatedAt", "UpdatedBy" },
                values: new object[] { 74, "RU", 5, new DateTime(2024, 1, 1, 10, 0, 0, 0, DateTimeKind.Unspecified), null, true, true, "Rusya", 74, 1, null, null });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Code", "ContinentId", "CreatedAt", "CreatedBy", "IsActive", "Name", "SortOrder", "Status", "UpdatedAt", "UpdatedBy" },
                values: new object[,]
                {
                    { 75, "UA", 2, new DateTime(2024, 1, 1, 10, 0, 0, 0, DateTimeKind.Unspecified), null, true, "Ukrayna", 75, 1, null, null },
                    { 76, "KZ", 5, new DateTime(2024, 1, 1, 10, 0, 0, 0, DateTimeKind.Unspecified), null, true, "Kazakistan", 76, 1, null, null },
                    { 77, "UZ", 5, new DateTime(2024, 1, 1, 10, 0, 0, 0, DateTimeKind.Unspecified), null, true, "Özbekistan", 77, 1, null, null },
                    { 78, "TM", 5, new DateTime(2024, 1, 1, 10, 0, 0, 0, DateTimeKind.Unspecified), null, true, "Türkmenistan", 78, 1, null, null },
                    { 79, "KG", 5, new DateTime(2024, 1, 1, 10, 0, 0, 0, DateTimeKind.Unspecified), null, true, "Kırgızistan", 79, 1, null, null },
                    { 80, "TJ", 5, new DateTime(2024, 1, 1, 10, 0, 0, 0, DateTimeKind.Unspecified), null, true, "Tacikistan", 80, 1, null, null },
                    { 81, "AZ", 5, new DateTime(2024, 1, 1, 10, 0, 0, 0, DateTimeKind.Unspecified), null, true, "Azerbaycan", 81, 1, null, null },
                    { 82, "GE", 5, new DateTime(2024, 1, 1, 10, 0, 0, 0, DateTimeKind.Unspecified), null, true, "Gürcistan", 82, 1, null, null },
                    { 83, "AM", 5, new DateTime(2024, 1, 1, 10, 0, 0, 0, DateTimeKind.Unspecified), null, true, "Ermenistan", 83, 1, null, null },
                    { 84, "IR", 5, new DateTime(2024, 1, 1, 10, 0, 0, 0, DateTimeKind.Unspecified), null, true, "İran", 84, 1, null, null },
                    { 85, "IQ", 5, new DateTime(2024, 1, 1, 10, 0, 0, 0, DateTimeKind.Unspecified), null, true, "Irak", 85, 1, null, null },
                    { 86, "SY", 5, new DateTime(2024, 1, 1, 10, 0, 0, 0, DateTimeKind.Unspecified), null, true, "Suriye", 86, 1, null, null },
                    { 87, "JO", 5, new DateTime(2024, 1, 1, 10, 0, 0, 0, DateTimeKind.Unspecified), null, true, "Ürdün", 87, 1, null, null },
                    { 88, "LB", 5, new DateTime(2024, 1, 1, 10, 0, 0, 0, DateTimeKind.Unspecified), null, true, "Lübnan", 88, 1, null, null },
                    { 89, "IL", 5, new DateTime(2024, 1, 1, 10, 0, 0, 0, DateTimeKind.Unspecified), null, true, "İsrail", 89, 1, null, null },
                    { 90, "SA", 5, new DateTime(2024, 1, 1, 10, 0, 0, 0, DateTimeKind.Unspecified), null, true, "Suudi Arabistan", 90, 1, null, null },
                    { 91, "AE", 5, new DateTime(2024, 1, 1, 10, 0, 0, 0, DateTimeKind.Unspecified), null, true, "Birleşik Arap Emirlikleri", 91, 1, null, null },
                    { 92, "KW", 5, new DateTime(2024, 1, 1, 10, 0, 0, 0, DateTimeKind.Unspecified), null, true, "Kuveyt", 92, 1, null, null },
                    { 93, "QA", 5, new DateTime(2024, 1, 1, 10, 0, 0, 0, DateTimeKind.Unspecified), null, true, "Katar", 93, 1, null, null },
                    { 94, "BH", 5, new DateTime(2024, 1, 1, 10, 0, 0, 0, DateTimeKind.Unspecified), null, true, "Bahreyn", 94, 1, null, null },
                    { 95, "OM", 5, new DateTime(2024, 1, 1, 10, 0, 0, 0, DateTimeKind.Unspecified), null, true, "Umman", 95, 1, null, null },
                    { 96, "YE", 5, new DateTime(2024, 1, 1, 10, 0, 0, 0, DateTimeKind.Unspecified), null, true, "Yemen", 96, 1, null, null },
                    { 97, "AF", 5, new DateTime(2024, 1, 1, 10, 0, 0, 0, DateTimeKind.Unspecified), null, true, "Afganistan", 97, 1, null, null },
                    { 98, "LY", 1, new DateTime(2024, 1, 1, 10, 0, 0, 0, DateTimeKind.Unspecified), null, true, "Libya", 98, 1, null, null },
                    { 99, "SD", 1, new DateTime(2024, 1, 1, 10, 0, 0, 0, DateTimeKind.Unspecified), null, true, "Sudan", 99, 1, null, null },
                    { 100, "SO", 1, new DateTime(2024, 1, 1, 10, 0, 0, 0, DateTimeKind.Unspecified), null, true, "Somali", 100, 1, null, null }
                });

            migrationBuilder.InsertData(
                table: "DataSchemaFields",
                columns: new[] { "Id", "CreatedAt", "CreatedBy", "DataSchemaId", "DefaultValue", "Description", "FieldKey", "FieldName", "IsActive", "IsFilterable", "IsRequired", "IsSortable", "OptionsJson", "Placeholder", "ShowInDetails", "ShowInListing", "SortOrder", "Status", "Type", "Unit", "UpdatedAt", "UpdatedBy", "ValidationRules" },
                values: new object[,]
                {
                    { 1, new DateTime(2025, 11, 7, 16, 2, 17, 727, DateTimeKind.Utc).AddTicks(5926), null, 2, null, "Internal storage capacity", "storage_gb", "Storage", true, true, true, true, "[{\"value\":\"64\",\"label\":\"64 GB\"},{\"value\":\"128\",\"label\":\"128 GB\"},{\"value\":\"256\",\"label\":\"256 GB\"},{\"value\":\"512\",\"label\":\"512 GB\"},{\"value\":\"1024\",\"label\":\"1 TB\"}]", null, true, true, 1, 1, 14, "GB", null, null, null },
                    { 2, new DateTime(2025, 11, 7, 16, 2, 17, 727, DateTimeKind.Utc).AddTicks(5932), null, 2, null, "Display screen size", "screen_size", "Screen Size", true, true, true, true, null, null, true, true, 2, 1, 3, "inches", null, null, "{\"min\":3.0,\"max\":10.0,\"step\":0.1}" }
                });

            migrationBuilder.InsertData(
                table: "DataSchemaFields",
                columns: new[] { "Id", "CreatedAt", "CreatedBy", "DataSchemaId", "DefaultValue", "Description", "FieldKey", "FieldName", "IsActive", "IsFilterable", "OptionsJson", "Placeholder", "ShowInDetails", "ShowInListing", "SortOrder", "Status", "Type", "Unit", "UpdatedAt", "UpdatedBy", "ValidationRules" },
                values: new object[] { 3, new DateTime(2025, 11, 7, 16, 2, 17, 727, DateTimeKind.Utc).AddTicks(5935), null, 2, null, "Display technology type", "screen_type", "Screen Type", true, true, "[{\"value\":\"LCD\",\"label\":\"LCD\"},{\"value\":\"OLED\",\"label\":\"OLED\"},{\"value\":\"AMOLED\",\"label\":\"AMOLED\"},{\"value\":\"Super AMOLED\",\"label\":\"Super AMOLED\"},{\"value\":\"IPS\",\"label\":\"IPS\"}]", null, true, true, 3, 1, 14, null, null, null, null });

            migrationBuilder.InsertData(
                table: "DataSchemaFields",
                columns: new[] { "Id", "CreatedAt", "CreatedBy", "DataSchemaId", "DefaultValue", "Description", "FieldKey", "FieldName", "IsActive", "IsFilterable", "IsSortable", "OptionsJson", "Placeholder", "ShowInDetails", "SortOrder", "Status", "Type", "Unit", "UpdatedAt", "UpdatedBy", "ValidationRules" },
                values: new object[] { 4, new DateTime(2025, 11, 7, 16, 2, 17, 727, DateTimeKind.Utc).AddTicks(5939), null, 2, null, "Maximum screen brightness", "brightness", "Brightness", true, true, true, null, null, true, 4, 1, 3, "nits", null, null, "{\"min\":100,\"max\":3000}" });

            migrationBuilder.InsertData(
                table: "DataSchemaFields",
                columns: new[] { "Id", "CreatedAt", "CreatedBy", "DataSchemaId", "DefaultValue", "Description", "FieldKey", "FieldName", "IsActive", "IsFilterable", "IsRequired", "IsSortable", "OptionsJson", "Placeholder", "ShowInDetails", "ShowInListing", "SortOrder", "Status", "Type", "Unit", "UpdatedAt", "UpdatedBy", "ValidationRules" },
                values: new object[] { 5, new DateTime(2025, 11, 7, 16, 2, 17, 727, DateTimeKind.Utc).AddTicks(5942), null, 2, null, "Random Access Memory", "ram_gb", "RAM", true, true, true, true, "[{\"value\":\"2\",\"label\":\"2 GB\"},{\"value\":\"3\",\"label\":\"3 GB\"},{\"value\":\"4\",\"label\":\"4 GB\"},{\"value\":\"6\",\"label\":\"6 GB\"},{\"value\":\"8\",\"label\":\"8 GB\"},{\"value\":\"12\",\"label\":\"12 GB\"},{\"value\":\"16\",\"label\":\"16 GB\"}]", null, true, true, 5, 1, 14, "GB", null, null, null });

            migrationBuilder.InsertData(
                table: "DataSchemaFields",
                columns: new[] { "Id", "CreatedAt", "CreatedBy", "DataSchemaId", "DefaultValue", "Description", "FieldKey", "FieldName", "IsActive", "IsFilterable", "IsSortable", "OptionsJson", "Placeholder", "ShowInDetails", "ShowInListing", "SortOrder", "Status", "Type", "Unit", "UpdatedAt", "UpdatedBy", "ValidationRules" },
                values: new object[] { 6, new DateTime(2025, 11, 7, 16, 2, 17, 727, DateTimeKind.Utc).AddTicks(5945), null, 2, null, "Battery capacity in mAh", "battery_mah", "Battery Capacity", true, true, true, null, null, true, true, 6, 1, 3, "mAh", null, null, "{\"min\":1000,\"max\":10000}" });

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

            migrationBuilder.InsertData(
                table: "LocalizationValues",
                columns: new[] { "Id", "Category", "CreatedAt", "CreatedBy", "Description", "IsActive", "Key", "LanguageId", "Status", "UpdatedAt", "UpdatedBy", "Value" },
                values: new object[,]
                {
                    { 1, "Common", new DateTime(2025, 11, 7, 16, 2, 17, 720, DateTimeKind.Utc).AddTicks(8712), null, "Turkish translation for Common.Save", true, "Common.Save", 1, 0, null, null, "Kaydet" },
                    { 2, "Common", new DateTime(2025, 11, 7, 16, 2, 17, 720, DateTimeKind.Utc).AddTicks(8718), null, "Turkish translation for Common.Cancel", true, "Common.Cancel", 1, 0, null, null, "İptal" },
                    { 3, "Common", new DateTime(2025, 11, 7, 16, 2, 17, 720, DateTimeKind.Utc).AddTicks(8721), null, "Turkish translation for Common.Delete", true, "Common.Delete", 1, 0, null, null, "Sil" },
                    { 4, "Common", new DateTime(2025, 11, 7, 16, 2, 17, 720, DateTimeKind.Utc).AddTicks(8722), null, "Turkish translation for Common.Edit", true, "Common.Edit", 1, 0, null, null, "Düzenle" },
                    { 5, "Common", new DateTime(2025, 11, 7, 16, 2, 17, 720, DateTimeKind.Utc).AddTicks(8724), null, "Turkish translation for Common.Add", true, "Common.Add", 1, 0, null, null, "Ekle" },
                    { 6, "Common", new DateTime(2025, 11, 7, 16, 2, 17, 720, DateTimeKind.Utc).AddTicks(8727), null, "Turkish translation for Common.Update", true, "Common.Update", 1, 0, null, null, "Güncelle" },
                    { 7, "Common", new DateTime(2025, 11, 7, 16, 2, 17, 720, DateTimeKind.Utc).AddTicks(8728), null, "Turkish translation for Common.Create", true, "Common.Create", 1, 0, null, null, "Oluştur" },
                    { 8, "Common", new DateTime(2025, 11, 7, 16, 2, 17, 720, DateTimeKind.Utc).AddTicks(8729), null, "Turkish translation for Common.Remove", true, "Common.Remove", 1, 0, null, null, "Kaldır" },
                    { 9, "Common", new DateTime(2025, 11, 7, 16, 2, 17, 720, DateTimeKind.Utc).AddTicks(8730), null, "Turkish translation for Common.Search", true, "Common.Search", 1, 0, null, null, "Ara" },
                    { 10, "Common", new DateTime(2025, 11, 7, 16, 2, 17, 720, DateTimeKind.Utc).AddTicks(8732), null, "Turkish translation for Common.Filter", true, "Common.Filter", 1, 0, null, null, "Filtrele" },
                    { 11, "Common", new DateTime(2025, 11, 7, 16, 2, 17, 720, DateTimeKind.Utc).AddTicks(8733), null, "Turkish translation for Common.Export", true, "Common.Export", 1, 0, null, null, "Dışa Aktar" },
                    { 12, "Common", new DateTime(2025, 11, 7, 16, 2, 17, 720, DateTimeKind.Utc).AddTicks(8734), null, "Turkish translation for Common.Import", true, "Common.Import", 1, 0, null, null, "İçe Aktar" },
                    { 13, "Common", new DateTime(2025, 11, 7, 16, 2, 17, 720, DateTimeKind.Utc).AddTicks(8735), null, "Turkish translation for Common.Upload", true, "Common.Upload", 1, 0, null, null, "Yükle" },
                    { 14, "Common", new DateTime(2025, 11, 7, 16, 2, 17, 720, DateTimeKind.Utc).AddTicks(8736), null, "Turkish translation for Common.Download", true, "Common.Download", 1, 0, null, null, "İndir" },
                    { 15, "Common", new DateTime(2025, 11, 7, 16, 2, 17, 720, DateTimeKind.Utc).AddTicks(8737), null, "Turkish translation for Common.Preview", true, "Common.Preview", 1, 0, null, null, "Önizle" },
                    { 16, "Common", new DateTime(2025, 11, 7, 16, 2, 17, 720, DateTimeKind.Utc).AddTicks(8739), null, "Turkish translation for Common.Publish", true, "Common.Publish", 1, 0, null, null, "Yayınla" },
                    { 17, "Common", new DateTime(2025, 11, 7, 16, 2, 17, 720, DateTimeKind.Utc).AddTicks(8740), null, "Turkish translation for Common.Draft", true, "Common.Draft", 1, 0, null, null, "Taslak" },
                    { 18, "Common", new DateTime(2025, 11, 7, 16, 2, 17, 720, DateTimeKind.Utc).AddTicks(8741), null, "Turkish translation for Common.Active", true, "Common.Active", 1, 0, null, null, "Aktif" },
                    { 19, "Common", new DateTime(2025, 11, 7, 16, 2, 17, 720, DateTimeKind.Utc).AddTicks(8742), null, "Turkish translation for Common.Inactive", true, "Common.Inactive", 1, 0, null, null, "Pasif" },
                    { 20, "Common", new DateTime(2025, 11, 7, 16, 2, 17, 720, DateTimeKind.Utc).AddTicks(8776), null, "Turkish translation for Common.Yes", true, "Common.Yes", 1, 0, null, null, "Evet" },
                    { 21, "Common", new DateTime(2025, 11, 7, 16, 2, 17, 720, DateTimeKind.Utc).AddTicks(8784), null, "Turkish translation for Common.No", true, "Common.No", 1, 0, null, null, "Hayır" },
                    { 22, "Common", new DateTime(2025, 11, 7, 16, 2, 17, 720, DateTimeKind.Utc).AddTicks(8785), null, "Turkish translation for Common.OK", true, "Common.OK", 1, 0, null, null, "Tamam" },
                    { 23, "Common", new DateTime(2025, 11, 7, 16, 2, 17, 720, DateTimeKind.Utc).AddTicks(8786), null, "Turkish translation for Common.Close", true, "Common.Close", 1, 0, null, null, "Kapat" },
                    { 24, "Common", new DateTime(2025, 11, 7, 16, 2, 17, 720, DateTimeKind.Utc).AddTicks(8787), null, "Turkish translation for Common.Back", true, "Common.Back", 1, 0, null, null, "Geri" },
                    { 25, "Common", new DateTime(2025, 11, 7, 16, 2, 17, 720, DateTimeKind.Utc).AddTicks(8788), null, "Turkish translation for Common.Next", true, "Common.Next", 1, 0, null, null, "İleri" },
                    { 26, "Common", new DateTime(2025, 11, 7, 16, 2, 17, 720, DateTimeKind.Utc).AddTicks(8789), null, "Turkish translation for Common.Previous", true, "Common.Previous", 1, 0, null, null, "Önceki" },
                    { 27, "Common", new DateTime(2025, 11, 7, 16, 2, 17, 720, DateTimeKind.Utc).AddTicks(8790), null, "Turkish translation for Common.Loading", true, "Common.Loading", 1, 0, null, null, "Yükleniyor..." },
                    { 28, "Common", new DateTime(2025, 11, 7, 16, 2, 17, 720, DateTimeKind.Utc).AddTicks(8791), null, "Turkish translation for Common.Success", true, "Common.Success", 1, 0, null, null, "Başarılı" },
                    { 29, "Common", new DateTime(2025, 11, 7, 16, 2, 17, 720, DateTimeKind.Utc).AddTicks(8792), null, "Turkish translation for Common.Error", true, "Common.Error", 1, 0, null, null, "Hata" },
                    { 30, "Common", new DateTime(2025, 11, 7, 16, 2, 17, 720, DateTimeKind.Utc).AddTicks(8802), null, "Turkish translation for Common.Warning", true, "Common.Warning", 1, 0, null, null, "Uyarı" },
                    { 31, "Common", new DateTime(2025, 11, 7, 16, 2, 17, 720, DateTimeKind.Utc).AddTicks(8803), null, "Turkish translation for Common.Info", true, "Common.Info", 1, 0, null, null, "Bilgi" },
                    { 32, "Common", new DateTime(2025, 11, 7, 16, 2, 17, 720, DateTimeKind.Utc).AddTicks(8804), null, "Turkish translation for Common.Refresh", true, "Common.Refresh", 1, 0, null, null, "Yenile" },
                    { 33, "Common", new DateTime(2025, 11, 7, 16, 2, 17, 720, DateTimeKind.Utc).AddTicks(8805), null, "Turkish translation for Common.Settings", true, "Common.Settings", 1, 0, null, null, "Ayarlar" },
                    { 34, "Common", new DateTime(2025, 11, 7, 16, 2, 17, 720, DateTimeKind.Utc).AddTicks(8807), null, "Turkish translation for Common.ViewAll", true, "Common.ViewAll", 1, 0, null, null, "Tümünü Gör" },
                    { 35, "Common", new DateTime(2025, 11, 7, 16, 2, 17, 720, DateTimeKind.Utc).AddTicks(8808), null, "Turkish translation for Common.All", true, "Common.All", 1, 0, null, null, "Tümü" },
                    { 36, "Common", new DateTime(2025, 11, 7, 16, 2, 17, 720, DateTimeKind.Utc).AddTicks(8809), null, "Turkish translation for Common.Actions", true, "Common.Actions", 1, 0, null, null, "İşlemler" },
                    { 37, "Common", new DateTime(2025, 11, 7, 16, 2, 17, 720, DateTimeKind.Utc).AddTicks(8810), null, "Turkish translation for Common.AreYouSure", true, "Common.AreYouSure", 1, 0, null, null, "Emin misiniz?" },
                    { 38, "Common", new DateTime(2025, 11, 7, 16, 2, 17, 720, DateTimeKind.Utc).AddTicks(8811), null, "Turkish translation for Common.UnexpectedError", true, "Common.UnexpectedError", 1, 0, null, null, "Beklenmeyen bir hata oluştu" },
                    { 39, "Page", new DateTime(2025, 11, 7, 16, 2, 17, 720, DateTimeKind.Utc).AddTicks(8815), null, "Turkish translation for Page.Title", true, "Page.Title", 1, 0, null, null, "Sayfa Başlığı" },
                    { 40, "Page", new DateTime(2025, 11, 7, 16, 2, 17, 720, DateTimeKind.Utc).AddTicks(8816), null, "Turkish translation for Page.Content", true, "Page.Content", 1, 0, null, null, "Sayfa İçeriği" },
                    { 41, "Page", new DateTime(2025, 11, 7, 16, 2, 17, 720, DateTimeKind.Utc).AddTicks(8817), null, "Turkish translation for Page.Description", true, "Page.Description", 1, 0, null, null, "Sayfa Açıklaması" },
                    { 42, "Page", new DateTime(2025, 11, 7, 16, 2, 17, 720, DateTimeKind.Utc).AddTicks(8818), null, "Turkish translation for Page.Keywords", true, "Page.Keywords", 1, 0, null, null, "Anahtar Kelimeler" },
                    { 43, "Page", new DateTime(2025, 11, 7, 16, 2, 17, 720, DateTimeKind.Utc).AddTicks(8819), null, "Turkish translation for Page.Author", true, "Page.Author", 1, 0, null, null, "Yazar" },
                    { 44, "Page", new DateTime(2025, 11, 7, 16, 2, 17, 720, DateTimeKind.Utc).AddTicks(8821), null, "Turkish translation for Page.CreatedAt", true, "Page.CreatedAt", 1, 0, null, null, "Oluşturulma Tarihi" },
                    { 45, "Page", new DateTime(2025, 11, 7, 16, 2, 17, 720, DateTimeKind.Utc).AddTicks(8823), null, "Turkish translation for Page.UpdatedAt", true, "Page.UpdatedAt", 1, 0, null, null, "Güncellenme Tarihi" },
                    { 46, "Page", new DateTime(2025, 11, 7, 16, 2, 17, 720, DateTimeKind.Utc).AddTicks(8824), null, "Turkish translation for Page.Status", true, "Page.Status", 1, 0, null, null, "Durum" },
                    { 47, "Page", new DateTime(2025, 11, 7, 16, 2, 17, 720, DateTimeKind.Utc).AddTicks(8825), null, "Turkish translation for Page.Type", true, "Page.Type", 1, 0, null, null, "Sayfa Tipi" },
                    { 48, "Page", new DateTime(2025, 11, 7, 16, 2, 17, 720, DateTimeKind.Utc).AddTicks(8826), null, "Turkish translation for Page.Layout", true, "Page.Layout", 1, 0, null, null, "Düzen" },
                    { 49, "Page", new DateTime(2025, 11, 7, 16, 2, 17, 720, DateTimeKind.Utc).AddTicks(8827), null, "Turkish translation for Page.Template", true, "Page.Template", 1, 0, null, null, "Şablon" },
                    { 50, "Page", new DateTime(2025, 11, 7, 16, 2, 17, 720, DateTimeKind.Utc).AddTicks(8828), null, "Turkish translation for Page.SEO", true, "Page.SEO", 1, 0, null, null, "SEO Ayarları" },
                    { 51, "Page", new DateTime(2025, 11, 7, 16, 2, 17, 720, DateTimeKind.Utc).AddTicks(8829), null, "Turkish translation for Page.Sections", true, "Page.Sections", 1, 0, null, null, "Bölümler" },
                    { 52, "Page", new DateTime(2025, 11, 7, 16, 2, 17, 720, DateTimeKind.Utc).AddTicks(8830), null, "Turkish translation for Page.Items", true, "Page.Items", 1, 0, null, null, "Öğeler" },
                    { 53, "Page", new DateTime(2025, 11, 7, 16, 2, 17, 720, DateTimeKind.Utc).AddTicks(8831), null, "Turkish translation for Page.Fields", true, "Page.Fields", 1, 0, null, null, "Alanlar" },
                    { 54, "Section", new DateTime(2025, 11, 7, 16, 2, 17, 720, DateTimeKind.Utc).AddTicks(8834), null, "Turkish translation for Section.Name", true, "Section.Name", 1, 0, null, null, "Bölüm Adı" },
                    { 55, "Section", new DateTime(2025, 11, 7, 16, 2, 17, 720, DateTimeKind.Utc).AddTicks(8859), null, "Turkish translation for Section.Type", true, "Section.Type", 1, 0, null, null, "Bölüm Tipi" },
                    { 56, "Section", new DateTime(2025, 11, 7, 16, 2, 17, 720, DateTimeKind.Utc).AddTicks(8860), null, "Turkish translation for Section.Key", true, "Section.Key", 1, 0, null, null, "Bölüm Anahtarı" },
                    { 57, "Section", new DateTime(2025, 11, 7, 16, 2, 17, 720, DateTimeKind.Utc).AddTicks(8861), null, "Turkish translation for Section.Order", true, "Section.Order", 1, 0, null, null, "Sıralama" },
                    { 58, "Section", new DateTime(2025, 11, 7, 16, 2, 17, 720, DateTimeKind.Utc).AddTicks(8862), null, "Turkish translation for Section.Settings", true, "Section.Settings", 1, 0, null, null, "Ayarlar" },
                    { 59, "Section", new DateTime(2025, 11, 7, 16, 2, 17, 720, DateTimeKind.Utc).AddTicks(8863), null, "Turkish translation for Section.Items", true, "Section.Items", 1, 0, null, null, "Öğeler" },
                    { 60, "Section", new DateTime(2025, 11, 7, 16, 2, 17, 720, DateTimeKind.Utc).AddTicks(8864), null, "Turkish translation for Section.AddItem", true, "Section.AddItem", 1, 0, null, null, "Öğe Ekle" },
                    { 61, "Section", new DateTime(2025, 11, 7, 16, 2, 17, 720, DateTimeKind.Utc).AddTicks(8865), null, "Turkish translation for Section.EditItems", true, "Section.EditItems", 1, 0, null, null, "Öğeleri Düzenle" },
                    { 62, "Section", new DateTime(2025, 11, 7, 16, 2, 17, 720, DateTimeKind.Utc).AddTicks(8867), null, "Turkish translation for Section.Duplicate", true, "Section.Duplicate", 1, 0, null, null, "Kopyala" },
                    { 63, "Section", new DateTime(2025, 11, 7, 16, 2, 17, 720, DateTimeKind.Utc).AddTicks(8868), null, "Turkish translation for Section.Remove", true, "Section.Remove", 1, 0, null, null, "Kaldır" },
                    { 64, "Section", new DateTime(2025, 11, 7, 16, 2, 17, 720, DateTimeKind.Utc).AddTicks(8869), null, "Turkish translation for Section.Hero", true, "Section.Hero", 1, 0, null, null, "Ana Bölüm" },
                    { 65, "Section", new DateTime(2025, 11, 7, 16, 2, 17, 720, DateTimeKind.Utc).AddTicks(8870), null, "Turkish translation for Section.Navbar", true, "Section.Navbar", 1, 0, null, null, "Navigasyon" },
                    { 66, "Section", new DateTime(2025, 11, 7, 16, 2, 17, 720, DateTimeKind.Utc).AddTicks(8872), null, "Turkish translation for Section.Footer", true, "Section.Footer", 1, 0, null, null, "Alt Bilgi" },
                    { 67, "Section", new DateTime(2025, 11, 7, 16, 2, 17, 720, DateTimeKind.Utc).AddTicks(8873), null, "Turkish translation for Section.Content", true, "Section.Content", 1, 0, null, null, "İçerik" },
                    { 68, "Section", new DateTime(2025, 11, 7, 16, 2, 17, 720, DateTimeKind.Utc).AddTicks(8874), null, "Turkish translation for Section.Gallery", true, "Section.Gallery", 1, 0, null, null, "Galeri" },
                    { 69, "Section", new DateTime(2025, 11, 7, 16, 2, 17, 720, DateTimeKind.Utc).AddTicks(8875), null, "Turkish translation for Section.Contact", true, "Section.Contact", 1, 0, null, null, "İletişim" },
                    { 70, "Validation", new DateTime(2025, 11, 7, 16, 2, 17, 720, DateTimeKind.Utc).AddTicks(8878), null, "Turkish translation for Validation.Required", true, "Validation.Required", 1, 0, null, null, "Bu alan zorunludur" },
                    { 71, "Validation", new DateTime(2025, 11, 7, 16, 2, 17, 720, DateTimeKind.Utc).AddTicks(8880), null, "Turkish translation for Validation.Email", true, "Validation.Email", 1, 0, null, null, "Geçerli bir e-posta adresi giriniz" },
                    { 72, "Validation", new DateTime(2025, 11, 7, 16, 2, 17, 720, DateTimeKind.Utc).AddTicks(8881), null, "Turkish translation for Validation.MinLength", true, "Validation.MinLength", 1, 0, null, null, "En az {0} karakter olmalıdır" },
                    { 73, "Validation", new DateTime(2025, 11, 7, 16, 2, 17, 720, DateTimeKind.Utc).AddTicks(8882), null, "Turkish translation for Validation.MaxLength", true, "Validation.MaxLength", 1, 0, null, null, "En fazla {0} karakter olmalıdır" },
                    { 74, "Validation", new DateTime(2025, 11, 7, 16, 2, 17, 720, DateTimeKind.Utc).AddTicks(8884), null, "Turkish translation for Validation.Range", true, "Validation.Range", 1, 0, null, null, "{0} ile {1} arasında olmalıdır" },
                    { 75, "Validation", new DateTime(2025, 11, 7, 16, 2, 17, 720, DateTimeKind.Utc).AddTicks(8885), null, "Turkish translation for Validation.Numeric", true, "Validation.Numeric", 1, 0, null, null, "Sayısal bir değer giriniz" },
                    { 76, "Validation", new DateTime(2025, 11, 7, 16, 2, 17, 720, DateTimeKind.Utc).AddTicks(8886), null, "Turkish translation for Validation.Date", true, "Validation.Date", 1, 0, null, null, "Geçerli bir tarih giriniz" },
                    { 77, "Validation", new DateTime(2025, 11, 7, 16, 2, 17, 720, DateTimeKind.Utc).AddTicks(8887), null, "Turkish translation for Validation.Url", true, "Validation.Url", 1, 0, null, null, "Geçerli bir URL giriniz" },
                    { 78, "Validation", new DateTime(2025, 11, 7, 16, 2, 17, 720, DateTimeKind.Utc).AddTicks(8888), null, "Turkish translation for Validation.Phone", true, "Validation.Phone", 1, 0, null, null, "Geçerli bir telefon numarası giriniz" },
                    { 79, "Validation", new DateTime(2025, 11, 7, 16, 2, 17, 720, DateTimeKind.Utc).AddTicks(8889), null, "Turkish translation for Validation.Password", true, "Validation.Password", 1, 0, null, null, "Şifre en az 8 karakter olmalıdır" },
                    { 80, "Navigation", new DateTime(2025, 11, 7, 16, 2, 17, 720, DateTimeKind.Utc).AddTicks(8893), null, "Turkish translation for Navigation.Dashboard", true, "Navigation.Dashboard", 1, 0, null, null, "Dashboard" },
                    { 81, "Navigation", new DateTime(2025, 11, 7, 16, 2, 17, 720, DateTimeKind.Utc).AddTicks(8895), null, "Turkish translation for Navigation.Announcements", true, "Navigation.Announcements", 1, 0, null, null, "Duyurular" },
                    { 82, "Navigation", new DateTime(2025, 11, 7, 16, 2, 17, 720, DateTimeKind.Utc).AddTicks(8896), null, "Turkish translation for Navigation.Campaigns", true, "Navigation.Campaigns", 1, 0, null, null, "Kampanyalar" },
                    { 83, "Navigation", new DateTime(2025, 11, 7, 16, 2, 17, 720, DateTimeKind.Utc).AddTicks(8897), null, "Turkish translation for Navigation.Content", true, "Navigation.Content", 1, 0, null, null, "İçerik" },
                    { 84, "Navigation", new DateTime(2025, 11, 7, 16, 2, 17, 720, DateTimeKind.Utc).AddTicks(8898), null, "Turkish translation for Navigation.Pages", true, "Navigation.Pages", 1, 0, null, null, "Sayfalar" },
                    { 85, "Navigation", new DateTime(2025, 11, 7, 16, 2, 17, 720, DateTimeKind.Utc).AddTicks(8900), null, "Turkish translation for Navigation.Sections", true, "Navigation.Sections", 1, 0, null, null, "Bölümler" },
                    { 86, "Navigation", new DateTime(2025, 11, 7, 16, 2, 17, 720, DateTimeKind.Utc).AddTicks(8901), null, "Turkish translation for Navigation.Layouts", true, "Navigation.Layouts", 1, 0, null, null, "Düzenler" },
                    { 87, "Navigation", new DateTime(2025, 11, 7, 16, 2, 17, 720, DateTimeKind.Utc).AddTicks(8932), null, "Turkish translation for Navigation.WebUrlManagement", true, "Navigation.WebUrlManagement", 1, 0, null, null, "Web URL Yönetimi" },
                    { 88, "Navigation", new DateTime(2025, 11, 7, 16, 2, 17, 720, DateTimeKind.Utc).AddTicks(8933), null, "Turkish translation for Navigation.News", true, "Navigation.News", 1, 0, null, null, "Haberler" },
                    { 89, "Navigation", new DateTime(2025, 11, 7, 16, 2, 17, 720, DateTimeKind.Utc).AddTicks(8934), null, "Turkish translation for Navigation.Blog", true, "Navigation.Blog", 1, 0, null, null, "Blog" },
                    { 90, "Navigation", new DateTime(2025, 11, 7, 16, 2, 17, 720, DateTimeKind.Utc).AddTicks(8935), null, "Turkish translation for Navigation.Templates", true, "Navigation.Templates", 1, 0, null, null, "Şablonlar" },
                    { 91, "Navigation", new DateTime(2025, 11, 7, 16, 2, 17, 720, DateTimeKind.Utc).AddTicks(8937), null, "Turkish translation for Navigation.SectionItems", true, "Navigation.SectionItems", 1, 0, null, null, "Bölüm Öğeleri" },
                    { 92, "Navigation", new DateTime(2025, 11, 7, 16, 2, 17, 720, DateTimeKind.Utc).AddTicks(8938), null, "Turkish translation for Navigation.ECommerce", true, "Navigation.ECommerce", 1, 0, null, null, "E-Ticaret" },
                    { 93, "Navigation", new DateTime(2025, 11, 7, 16, 2, 17, 720, DateTimeKind.Utc).AddTicks(8939), null, "Turkish translation for Navigation.Products", true, "Navigation.Products", 1, 0, null, null, "Ürünler" },
                    { 94, "Navigation", new DateTime(2025, 11, 7, 16, 2, 17, 720, DateTimeKind.Utc).AddTicks(8940), null, "Turkish translation for Navigation.Categories", true, "Navigation.Categories", 1, 0, null, null, "Kategoriler" },
                    { 95, "Navigation", new DateTime(2025, 11, 7, 16, 2, 17, 720, DateTimeKind.Utc).AddTicks(8941), null, "Turkish translation for Navigation.Orders", true, "Navigation.Orders", 1, 0, null, null, "Siparişler" },
                    { 96, "Navigation", new DateTime(2025, 11, 7, 16, 2, 17, 720, DateTimeKind.Utc).AddTicks(8942), null, "Turkish translation for Navigation.Users", true, "Navigation.Users", 1, 0, null, null, "Kullanıcılar" },
                    { 97, "Navigation", new DateTime(2025, 11, 7, 16, 2, 17, 720, DateTimeKind.Utc).AddTicks(8943), null, "Turkish translation for Navigation.ManageUsers", true, "Navigation.ManageUsers", 1, 0, null, null, "Kullanıcı Yönetimi" },
                    { 98, "Navigation", new DateTime(2025, 11, 7, 16, 2, 17, 720, DateTimeKind.Utc).AddTicks(8944), null, "Turkish translation for Navigation.ManageRoles", true, "Navigation.ManageRoles", 1, 0, null, null, "Rol Yönetimi" },
                    { 99, "Navigation", new DateTime(2025, 11, 7, 16, 2, 17, 720, DateTimeKind.Utc).AddTicks(8945), null, "Turkish translation for Navigation.ManagePermissions", true, "Navigation.ManagePermissions", 1, 0, null, null, "İzin Yönetimi" },
                    { 100, "Navigation", new DateTime(2025, 11, 7, 16, 2, 17, 720, DateTimeKind.Utc).AddTicks(8946), null, "Turkish translation for Navigation.Analytics", true, "Navigation.Analytics", 1, 0, null, null, "Analitik" },
                    { 101, "Navigation", new DateTime(2025, 11, 7, 16, 2, 17, 720, DateTimeKind.Utc).AddTicks(8947), null, "Turkish translation for Navigation.Settings", true, "Navigation.Settings", 1, 0, null, null, "Ayarlar" },
                    { 102, "Navigation", new DateTime(2025, 11, 7, 16, 2, 17, 720, DateTimeKind.Utc).AddTicks(8948), null, "Turkish translation for Navigation.GeneralSettings", true, "Navigation.GeneralSettings", 1, 0, null, null, "Genel Ayarlar" },
                    { 103, "Navigation", new DateTime(2025, 11, 7, 16, 2, 17, 720, DateTimeKind.Utc).AddTicks(8949), null, "Turkish translation for Navigation.Countries", true, "Navigation.Countries", 1, 0, null, null, "Ülkeler" },
                    { 104, "Navigation", new DateTime(2025, 11, 7, 16, 2, 17, 720, DateTimeKind.Utc).AddTicks(8950), null, "Turkish translation for Navigation.Languages", true, "Navigation.Languages", 1, 0, null, null, "Diller" },
                    { 105, "Navigation", new DateTime(2025, 11, 7, 16, 2, 17, 720, DateTimeKind.Utc).AddTicks(8951), null, "Turkish translation for Navigation.Localization", true, "Navigation.Localization", 1, 0, null, null, "Lokalizasyon" },
                    { 106, "Navigation", new DateTime(2025, 11, 7, 16, 2, 17, 720, DateTimeKind.Utc).AddTicks(8953), null, "Turkish translation for Navigation.Profile", true, "Navigation.Profile", 1, 0, null, null, "Profil" },
                    { 107, "Navigation", new DateTime(2025, 11, 7, 16, 2, 17, 720, DateTimeKind.Utc).AddTicks(8954), null, "Turkish translation for Navigation.Help", true, "Navigation.Help", 1, 0, null, null, "Yardım" },
                    { 108, "Navigation", new DateTime(2025, 11, 7, 16, 2, 17, 720, DateTimeKind.Utc).AddTicks(8955), null, "Turkish translation for Navigation.Logout", true, "Navigation.Logout", 1, 0, null, null, "Çıkış" },
                    { 109, "Language", new DateTime(2025, 11, 7, 16, 2, 17, 720, DateTimeKind.Utc).AddTicks(8958), null, "Turkish translation for Language.English", true, "Language.English", 1, 0, null, null, "İngilizce" },
                    { 110, "Language", new DateTime(2025, 11, 7, 16, 2, 17, 720, DateTimeKind.Utc).AddTicks(8960), null, "Turkish translation for Language.Turkish", true, "Language.Turkish", 1, 0, null, null, "Türkçe" },
                    { 111, "Dashboard", new DateTime(2025, 11, 7, 16, 2, 17, 720, DateTimeKind.Utc).AddTicks(8963), null, "Turkish translation for Dashboard.Title", true, "Dashboard.Title", 1, 0, null, null, "Dashboard" },
                    { 112, "Dashboard", new DateTime(2025, 11, 7, 16, 2, 17, 720, DateTimeKind.Utc).AddTicks(8965), null, "Turkish translation for Dashboard.WelcomeMessage", true, "Dashboard.WelcomeMessage", 1, 0, null, null, "Hoş geldin! CMS analitiklerin ve son aktivitelerin özeti burada." },
                    { 113, "Dashboard", new DateTime(2025, 11, 7, 16, 2, 17, 720, DateTimeKind.Utc).AddTicks(8966), null, "Turkish translation for Dashboard.Last7Days", true, "Dashboard.Last7Days", 1, 0, null, null, "Son 7 gün" },
                    { 114, "Dashboard", new DateTime(2025, 11, 7, 16, 2, 17, 720, DateTimeKind.Utc).AddTicks(8967), null, "Turkish translation for Dashboard.Last30Days", true, "Dashboard.Last30Days", 1, 0, null, null, "Son 30 gün" },
                    { 115, "Dashboard", new DateTime(2025, 11, 7, 16, 2, 17, 720, DateTimeKind.Utc).AddTicks(8968), null, "Turkish translation for Dashboard.Last90Days", true, "Dashboard.Last90Days", 1, 0, null, null, "Son 90 gün" },
                    { 116, "Dashboard", new DateTime(2025, 11, 7, 16, 2, 17, 720, DateTimeKind.Utc).AddTicks(8969), null, "Turkish translation for Dashboard.TotalUsers", true, "Dashboard.TotalUsers", 1, 0, null, null, "Toplam Kullanıcı" },
                    { 117, "Dashboard", new DateTime(2025, 11, 7, 16, 2, 17, 720, DateTimeKind.Utc).AddTicks(8970), null, "Turkish translation for Dashboard.TotalRevenue", true, "Dashboard.TotalRevenue", 1, 0, null, null, "Toplam Gelir" },
                    { 118, "Dashboard", new DateTime(2025, 11, 7, 16, 2, 17, 720, DateTimeKind.Utc).AddTicks(8971), null, "Turkish translation for Dashboard.Products", true, "Dashboard.Products", 1, 0, null, null, "Ürünler" },
                    { 119, "Dashboard", new DateTime(2025, 11, 7, 16, 2, 17, 720, DateTimeKind.Utc).AddTicks(8972), null, "Turkish translation for Dashboard.SupportTickets", true, "Dashboard.SupportTickets", 1, 0, null, null, "Destek Biletleri" },
                    { 120, "Dashboard", new DateTime(2025, 11, 7, 16, 2, 17, 720, DateTimeKind.Utc).AddTicks(8973), null, "Turkish translation for Dashboard.FromLastMonth", true, "Dashboard.FromLastMonth", 1, 0, null, null, "geçen aydan" },
                    { 121, "Dashboard", new DateTime(2025, 11, 7, 16, 2, 17, 720, DateTimeKind.Utc).AddTicks(8974), null, "Turkish translation for Dashboard.SalesOverview", true, "Dashboard.SalesOverview", 1, 0, null, null, "Satış Genel Bakış" },
                    { 122, "Dashboard", new DateTime(2025, 11, 7, 16, 2, 17, 720, DateTimeKind.Utc).AddTicks(9000), null, "Turkish translation for Dashboard.Monthly", true, "Dashboard.Monthly", 1, 0, null, null, "Aylık" },
                    { 123, "Dashboard", new DateTime(2025, 11, 7, 16, 2, 17, 720, DateTimeKind.Utc).AddTicks(9001), null, "Turkish translation for Dashboard.ChartVisualization", true, "Dashboard.ChartVisualization", 1, 0, null, null, "Grafik görselleştirmesi burada olacak" },
                    { 124, "Dashboard", new DateTime(2025, 11, 7, 16, 2, 17, 720, DateTimeKind.Utc).AddTicks(9002), null, "Turkish translation for Dashboard.ThisYear", true, "Dashboard.ThisYear", 1, 0, null, null, "Bu Yıl" },
                    { 125, "Dashboard", new DateTime(2025, 11, 7, 16, 2, 17, 720, DateTimeKind.Utc).AddTicks(9003), null, "Turkish translation for Dashboard.LastYear", true, "Dashboard.LastYear", 1, 0, null, null, "Geçen Yıl" },
                    { 126, "Dashboard", new DateTime(2025, 11, 7, 16, 2, 17, 720, DateTimeKind.Utc).AddTicks(9004), null, "Turkish translation for Dashboard.RecentActivities", true, "Dashboard.RecentActivities", 1, 0, null, null, "Son Aktiviteler" },
                    { 127, "Dashboard", new DateTime(2025, 11, 7, 16, 2, 17, 720, DateTimeKind.Utc).AddTicks(9005), null, "Turkish translation for Dashboard.TopProducts", true, "Dashboard.TopProducts", 1, 0, null, null, "En İyi Ürünler" },
                    { 128, "Dashboard", new DateTime(2025, 11, 7, 16, 2, 17, 720, DateTimeKind.Utc).AddTicks(9007), null, "Turkish translation for Dashboard.Product", true, "Dashboard.Product", 1, 0, null, null, "Ürün" },
                    { 129, "Dashboard", new DateTime(2025, 11, 7, 16, 2, 17, 720, DateTimeKind.Utc).AddTicks(9008), null, "Turkish translation for Dashboard.Category", true, "Dashboard.Category", 1, 0, null, null, "Kategori" },
                    { 130, "Dashboard", new DateTime(2025, 11, 7, 16, 2, 17, 720, DateTimeKind.Utc).AddTicks(9010), null, "Turkish translation for Dashboard.Sales", true, "Dashboard.Sales", 1, 0, null, null, "Satışlar" },
                    { 131, "Dashboard", new DateTime(2025, 11, 7, 16, 2, 17, 720, DateTimeKind.Utc).AddTicks(9011), null, "Turkish translation for Dashboard.Status", true, "Dashboard.Status", 1, 0, null, null, "Durum" },
                    { 132, "Dashboard", new DateTime(2025, 11, 7, 16, 2, 17, 720, DateTimeKind.Utc).AddTicks(9013), null, "Turkish translation for Dashboard.LatestOrders", true, "Dashboard.LatestOrders", 1, 0, null, null, "Son Siparişler" },
                    { 133, "Dashboard", new DateTime(2025, 11, 7, 16, 2, 17, 720, DateTimeKind.Utc).AddTicks(9014), null, "Turkish translation for Dashboard.Today", true, "Dashboard.Today", 1, 0, null, null, "Bugün" },
                    { 134, "Dashboard", new DateTime(2025, 11, 7, 16, 2, 17, 720, DateTimeKind.Utc).AddTicks(9015), null, "Turkish translation for Dashboard.Yesterday", true, "Dashboard.Yesterday", 1, 0, null, null, "Dün" },
                    { 135, "Dashboard", new DateTime(2025, 11, 7, 16, 2, 17, 720, DateTimeKind.Utc).AddTicks(9016), null, "Turkish translation for Dashboard.OrderId", true, "Dashboard.OrderId", 1, 0, null, null, "Sipariş ID" },
                    { 136, "Dashboard", new DateTime(2025, 11, 7, 16, 2, 17, 720, DateTimeKind.Utc).AddTicks(9017), null, "Turkish translation for Dashboard.Customer", true, "Dashboard.Customer", 1, 0, null, null, "Müşteri" },
                    { 137, "Dashboard", new DateTime(2025, 11, 7, 16, 2, 17, 720, DateTimeKind.Utc).AddTicks(9018), null, "Turkish translation for Dashboard.Date", true, "Dashboard.Date", 1, 0, null, null, "Tarih" },
                    { 138, "Dashboard", new DateTime(2025, 11, 7, 16, 2, 17, 720, DateTimeKind.Utc).AddTicks(9019), null, "Turkish translation for Dashboard.Amount", true, "Dashboard.Amount", 1, 0, null, null, "Tutar" },
                    { 139, "Localization", new DateTime(2025, 11, 7, 16, 2, 17, 720, DateTimeKind.Utc).AddTicks(9022), null, "Turkish translation for Localization.SystemDescription", true, "Localization.SystemDescription", 1, 0, null, null, "Sistem genelinde kullanılan metin çevirilerini yönetin" },
                    { 140, "Localization", new DateTime(2025, 11, 7, 16, 2, 17, 720, DateTimeKind.Utc).AddTicks(9024), null, "Turkish translation for Localization.Keys", true, "Localization.Keys", 1, 0, null, null, "Lokalizasyon Anahtarları" },
                    { 141, "Localization", new DateTime(2025, 11, 7, 16, 2, 17, 720, DateTimeKind.Utc).AddTicks(9025), null, "Turkish translation for Localization.Key", true, "Localization.Key", 1, 0, null, null, "Anahtar" },
                    { 142, "Localization", new DateTime(2025, 11, 7, 16, 2, 17, 720, DateTimeKind.Utc).AddTicks(9026), null, "Turkish translation for Localization.AddKey", true, "Localization.AddKey", 1, 0, null, null, "Yeni Anahtar Ekle" },
                    { 143, "Localization", new DateTime(2025, 11, 7, 16, 2, 17, 720, DateTimeKind.Utc).AddTicks(9027), null, "Turkish translation for Localization.EditKey", true, "Localization.EditKey", 1, 0, null, null, "Anahtar Düzenle" },
                    { 144, "Localization", new DateTime(2025, 11, 7, 16, 2, 17, 720, DateTimeKind.Utc).AddTicks(9029), null, "Turkish translation for Localization.KeyDetails", true, "Localization.KeyDetails", 1, 0, null, null, "Anahtar Detayları" },
                    { 145, "Localization", new DateTime(2025, 11, 7, 16, 2, 17, 720, DateTimeKind.Utc).AddTicks(9030), null, "Turkish translation for Localization.AddKeyDescription", true, "Localization.AddKeyDescription", 1, 0, null, null, "Yeni bir lokalizasyon anahtarı ve çevirilerini ekleyin" },
                    { 146, "Localization", new DateTime(2025, 11, 7, 16, 2, 17, 720, DateTimeKind.Utc).AddTicks(9031), null, "Turkish translation for Localization.EditKeyDescription", true, "Localization.EditKeyDescription", 1, 0, null, null, "Mevcut lokalizasyon anahtarını ve çevirilerini düzenleyin" },
                    { 147, "Localization", new DateTime(2025, 11, 7, 16, 2, 17, 720, DateTimeKind.Utc).AddTicks(9032), null, "Turkish translation for Localization.KeyPlaceholder", true, "Localization.KeyPlaceholder", 1, 0, null, null, "örn: Common.Save" },
                    { 148, "Localization", new DateTime(2025, 11, 7, 16, 2, 17, 720, DateTimeKind.Utc).AddTicks(9058), null, "Turkish translation for Localization.KeyHint", true, "Localization.KeyHint", 1, 0, null, null, "Nokta ile ayrılmış hiyerarşik anahtar kullanın" },
                    { 149, "Localization", new DateTime(2025, 11, 7, 16, 2, 17, 720, DateTimeKind.Utc).AddTicks(9059), null, "Turkish translation for Localization.KeyReadonly", true, "Localization.KeyReadonly", 1, 0, null, null, "Anahtar değiştirilemez" },
                    { 150, "Localization", new DateTime(2025, 11, 7, 16, 2, 17, 720, DateTimeKind.Utc).AddTicks(9060), null, "Turkish translation for Localization.Description", true, "Localization.Description", 1, 0, null, null, "Açıklama" },
                    { 151, "Localization", new DateTime(2025, 11, 7, 16, 2, 17, 720, DateTimeKind.Utc).AddTicks(9061), null, "Turkish translation for Localization.DescriptionPlaceholder", true, "Localization.DescriptionPlaceholder", 1, 0, null, null, "Bu anahtarın ne için kullanıldığını açıklayın" },
                    { 152, "Localization", new DateTime(2025, 11, 7, 16, 2, 17, 720, DateTimeKind.Utc).AddTicks(9063), null, "Turkish translation for Localization.SelectCategory", true, "Localization.SelectCategory", 1, 0, null, null, "Kategori Seçin" },
                    { 153, "Localization", new DateTime(2025, 11, 7, 16, 2, 17, 720, DateTimeKind.Utc).AddTicks(9064), null, "Turkish translation for Localization.Translations", true, "Localization.Translations", 1, 0, null, null, "Çeviriler" },
                    { 154, "Localization", new DateTime(2025, 11, 7, 16, 2, 17, 720, DateTimeKind.Utc).AddTicks(9065), null, "Turkish translation for Localization.TranslationPlaceholder", true, "Localization.TranslationPlaceholder", 1, 0, null, null, "{0} dilinde çeviri girin" },
                    { 155, "Localization", new DateTime(2025, 11, 7, 16, 2, 17, 720, DateTimeKind.Utc).AddTicks(9067), null, "Turkish translation for Localization.Translated", true, "Localization.Translated", 1, 0, null, null, "Çevrildi" },
                    { 156, "Localization", new DateTime(2025, 11, 7, 16, 2, 17, 720, DateTimeKind.Utc).AddTicks(9068), null, "Turkish translation for Localization.NotTranslated", true, "Localization.NotTranslated", 1, 0, null, null, "Çevrilmedi" },
                    { 157, "Localization", new DateTime(2025, 11, 7, 16, 2, 17, 720, DateTimeKind.Utc).AddTicks(9069), null, "Turkish translation for Localization.LastUpdated", true, "Localization.LastUpdated", 1, 0, null, null, "Son Güncelleme" },
                    { 158, "Localization", new DateTime(2025, 11, 7, 16, 2, 17, 720, DateTimeKind.Utc).AddTicks(9070), null, "Turkish translation for Localization.SearchPlaceholder", true, "Localization.SearchPlaceholder", 1, 0, null, null, "Anahtar veya değer ara..." },
                    { 159, "Localization", new DateTime(2025, 11, 7, 16, 2, 17, 720, DateTimeKind.Utc).AddTicks(9071), null, "Turkish translation for Localization.ShowingResults", true, "Localization.ShowingResults", 1, 0, null, null, "{0}-{1} / {2} sonuç gösteriliyor" },
                    { 160, "Localization", new DateTime(2025, 11, 7, 16, 2, 17, 720, DateTimeKind.Utc).AddTicks(9072), null, "Turkish translation for Localization.NoKeys", true, "Localization.NoKeys", 1, 0, null, null, "Lokalizasyon anahtarı bulunamadı" },
                    { 161, "Localization", new DateTime(2025, 11, 7, 16, 2, 17, 720, DateTimeKind.Utc).AddTicks(9073), null, "Turkish translation for Localization.NoKeysDescription", true, "Localization.NoKeysDescription", 1, 0, null, null, "Henüz hiç lokalizasyon anahtarı eklenmemiş" },
                    { 162, "Localization", new DateTime(2025, 11, 7, 16, 2, 17, 720, DateTimeKind.Utc).AddTicks(9074), null, "Turkish translation for Localization.AddFirstKey", true, "Localization.AddFirstKey", 1, 0, null, null, "İlk Anahtarı Ekle" },
                    { 163, "Localization", new DateTime(2025, 11, 7, 16, 2, 17, 720, DateTimeKind.Utc).AddTicks(9075), null, "Turkish translation for Localization.DeleteConfirmation", true, "Localization.DeleteConfirmation", 1, 0, null, null, "Bu anahtarı ve tüm çevirilerini silmek istediğinizden emin misiniz?" },
                    { 164, "Common", new DateTime(2025, 11, 7, 16, 2, 17, 720, DateTimeKind.Utc).AddTicks(9079), null, "English translation for Common.Save", true, "Common.Save", 2, 0, null, null, "Save" },
                    { 165, "Common", new DateTime(2025, 11, 7, 16, 2, 17, 720, DateTimeKind.Utc).AddTicks(9080), null, "English translation for Common.Cancel", true, "Common.Cancel", 2, 0, null, null, "Cancel" },
                    { 166, "Common", new DateTime(2025, 11, 7, 16, 2, 17, 720, DateTimeKind.Utc).AddTicks(9082), null, "English translation for Common.Delete", true, "Common.Delete", 2, 0, null, null, "Delete" },
                    { 167, "Common", new DateTime(2025, 11, 7, 16, 2, 17, 720, DateTimeKind.Utc).AddTicks(9083), null, "English translation for Common.Edit", true, "Common.Edit", 2, 0, null, null, "Edit" },
                    { 168, "Common", new DateTime(2025, 11, 7, 16, 2, 17, 720, DateTimeKind.Utc).AddTicks(9084), null, "English translation for Common.Add", true, "Common.Add", 2, 0, null, null, "Add" },
                    { 169, "Common", new DateTime(2025, 11, 7, 16, 2, 17, 720, DateTimeKind.Utc).AddTicks(9085), null, "English translation for Common.Update", true, "Common.Update", 2, 0, null, null, "Update" },
                    { 170, "Common", new DateTime(2025, 11, 7, 16, 2, 17, 720, DateTimeKind.Utc).AddTicks(9086), null, "English translation for Common.Create", true, "Common.Create", 2, 0, null, null, "Create" },
                    { 171, "Common", new DateTime(2025, 11, 7, 16, 2, 17, 720, DateTimeKind.Utc).AddTicks(9087), null, "English translation for Common.Remove", true, "Common.Remove", 2, 0, null, null, "Remove" },
                    { 172, "Common", new DateTime(2025, 11, 7, 16, 2, 17, 720, DateTimeKind.Utc).AddTicks(9088), null, "English translation for Common.Search", true, "Common.Search", 2, 0, null, null, "Search" },
                    { 173, "Common", new DateTime(2025, 11, 7, 16, 2, 17, 720, DateTimeKind.Utc).AddTicks(9089), null, "English translation for Common.Filter", true, "Common.Filter", 2, 0, null, null, "Filter" },
                    { 174, "Common", new DateTime(2025, 11, 7, 16, 2, 17, 720, DateTimeKind.Utc).AddTicks(9090), null, "English translation for Common.Export", true, "Common.Export", 2, 0, null, null, "Export" },
                    { 175, "Common", new DateTime(2025, 11, 7, 16, 2, 17, 720, DateTimeKind.Utc).AddTicks(9091), null, "English translation for Common.Import", true, "Common.Import", 2, 0, null, null, "Import" },
                    { 176, "Common", new DateTime(2025, 11, 7, 16, 2, 17, 720, DateTimeKind.Utc).AddTicks(9092), null, "English translation for Common.Upload", true, "Common.Upload", 2, 0, null, null, "Upload" },
                    { 177, "Common", new DateTime(2025, 11, 7, 16, 2, 17, 720, DateTimeKind.Utc).AddTicks(9093), null, "English translation for Common.Download", true, "Common.Download", 2, 0, null, null, "Download" },
                    { 178, "Common", new DateTime(2025, 11, 7, 16, 2, 17, 720, DateTimeKind.Utc).AddTicks(9094), null, "English translation for Common.Preview", true, "Common.Preview", 2, 0, null, null, "Preview" },
                    { 179, "Common", new DateTime(2025, 11, 7, 16, 2, 17, 720, DateTimeKind.Utc).AddTicks(9095), null, "English translation for Common.Publish", true, "Common.Publish", 2, 0, null, null, "Publish" },
                    { 180, "Common", new DateTime(2025, 11, 7, 16, 2, 17, 720, DateTimeKind.Utc).AddTicks(9096), null, "English translation for Common.Draft", true, "Common.Draft", 2, 0, null, null, "Draft" },
                    { 181, "Common", new DateTime(2025, 11, 7, 16, 2, 17, 720, DateTimeKind.Utc).AddTicks(9097), null, "English translation for Common.Active", true, "Common.Active", 2, 0, null, null, "Active" },
                    { 182, "Common", new DateTime(2025, 11, 7, 16, 2, 17, 720, DateTimeKind.Utc).AddTicks(9098), null, "English translation for Common.Inactive", true, "Common.Inactive", 2, 0, null, null, "Inactive" },
                    { 183, "Common", new DateTime(2025, 11, 7, 16, 2, 17, 720, DateTimeKind.Utc).AddTicks(9099), null, "English translation for Common.Yes", true, "Common.Yes", 2, 0, null, null, "Yes" },
                    { 184, "Common", new DateTime(2025, 11, 7, 16, 2, 17, 720, DateTimeKind.Utc).AddTicks(9133), null, "English translation for Common.No", true, "Common.No", 2, 0, null, null, "No" },
                    { 185, "Common", new DateTime(2025, 11, 7, 16, 2, 17, 720, DateTimeKind.Utc).AddTicks(9134), null, "English translation for Common.OK", true, "Common.OK", 2, 0, null, null, "OK" },
                    { 186, "Common", new DateTime(2025, 11, 7, 16, 2, 17, 720, DateTimeKind.Utc).AddTicks(9135), null, "English translation for Common.Close", true, "Common.Close", 2, 0, null, null, "Close" },
                    { 187, "Common", new DateTime(2025, 11, 7, 16, 2, 17, 720, DateTimeKind.Utc).AddTicks(9136), null, "English translation for Common.Back", true, "Common.Back", 2, 0, null, null, "Back" },
                    { 188, "Common", new DateTime(2025, 11, 7, 16, 2, 17, 720, DateTimeKind.Utc).AddTicks(9137), null, "English translation for Common.Next", true, "Common.Next", 2, 0, null, null, "Next" },
                    { 189, "Common", new DateTime(2025, 11, 7, 16, 2, 17, 720, DateTimeKind.Utc).AddTicks(9138), null, "English translation for Common.Previous", true, "Common.Previous", 2, 0, null, null, "Previous" },
                    { 190, "Common", new DateTime(2025, 11, 7, 16, 2, 17, 720, DateTimeKind.Utc).AddTicks(9139), null, "English translation for Common.Loading", true, "Common.Loading", 2, 0, null, null, "Loading..." },
                    { 191, "Common", new DateTime(2025, 11, 7, 16, 2, 17, 720, DateTimeKind.Utc).AddTicks(9140), null, "English translation for Common.Success", true, "Common.Success", 2, 0, null, null, "Success" },
                    { 192, "Common", new DateTime(2025, 11, 7, 16, 2, 17, 720, DateTimeKind.Utc).AddTicks(9141), null, "English translation for Common.Error", true, "Common.Error", 2, 0, null, null, "Error" },
                    { 193, "Common", new DateTime(2025, 11, 7, 16, 2, 17, 720, DateTimeKind.Utc).AddTicks(9142), null, "English translation for Common.Warning", true, "Common.Warning", 2, 0, null, null, "Warning" },
                    { 194, "Common", new DateTime(2025, 11, 7, 16, 2, 17, 720, DateTimeKind.Utc).AddTicks(9143), null, "English translation for Common.Info", true, "Common.Info", 2, 0, null, null, "Info" },
                    { 195, "Common", new DateTime(2025, 11, 7, 16, 2, 17, 720, DateTimeKind.Utc).AddTicks(9144), null, "English translation for Common.Refresh", true, "Common.Refresh", 2, 0, null, null, "Refresh" },
                    { 196, "Common", new DateTime(2025, 11, 7, 16, 2, 17, 720, DateTimeKind.Utc).AddTicks(9145), null, "English translation for Common.Settings", true, "Common.Settings", 2, 0, null, null, "Settings" },
                    { 197, "Common", new DateTime(2025, 11, 7, 16, 2, 17, 720, DateTimeKind.Utc).AddTicks(9146), null, "English translation for Common.ViewAll", true, "Common.ViewAll", 2, 0, null, null, "View All" },
                    { 198, "Common", new DateTime(2025, 11, 7, 16, 2, 17, 720, DateTimeKind.Utc).AddTicks(9147), null, "English translation for Common.All", true, "Common.All", 2, 0, null, null, "All" },
                    { 199, "Common", new DateTime(2025, 11, 7, 16, 2, 17, 720, DateTimeKind.Utc).AddTicks(9148), null, "English translation for Common.Actions", true, "Common.Actions", 2, 0, null, null, "Actions" },
                    { 200, "Common", new DateTime(2025, 11, 7, 16, 2, 17, 720, DateTimeKind.Utc).AddTicks(9149), null, "English translation for Common.AreYouSure", true, "Common.AreYouSure", 2, 0, null, null, "Are you sure?" },
                    { 201, "Common", new DateTime(2025, 11, 7, 16, 2, 17, 720, DateTimeKind.Utc).AddTicks(9150), null, "English translation for Common.UnexpectedError", true, "Common.UnexpectedError", 2, 0, null, null, "An unexpected error occurred" },
                    { 202, "Page", new DateTime(2025, 11, 7, 16, 2, 17, 720, DateTimeKind.Utc).AddTicks(9154), null, "English translation for Page.Title", true, "Page.Title", 2, 0, null, null, "Page Title" },
                    { 203, "Page", new DateTime(2025, 11, 7, 16, 2, 17, 720, DateTimeKind.Utc).AddTicks(9155), null, "English translation for Page.Content", true, "Page.Content", 2, 0, null, null, "Page Content" },
                    { 204, "Page", new DateTime(2025, 11, 7, 16, 2, 17, 720, DateTimeKind.Utc).AddTicks(9156), null, "English translation for Page.Description", true, "Page.Description", 2, 0, null, null, "Page Description" },
                    { 205, "Page", new DateTime(2025, 11, 7, 16, 2, 17, 720, DateTimeKind.Utc).AddTicks(9157), null, "English translation for Page.Keywords", true, "Page.Keywords", 2, 0, null, null, "Keywords" },
                    { 206, "Page", new DateTime(2025, 11, 7, 16, 2, 17, 720, DateTimeKind.Utc).AddTicks(9158), null, "English translation for Page.Author", true, "Page.Author", 2, 0, null, null, "Author" },
                    { 207, "Page", new DateTime(2025, 11, 7, 16, 2, 17, 720, DateTimeKind.Utc).AddTicks(9159), null, "English translation for Page.CreatedAt", true, "Page.CreatedAt", 2, 0, null, null, "Created At" },
                    { 208, "Page", new DateTime(2025, 11, 7, 16, 2, 17, 720, DateTimeKind.Utc).AddTicks(9160), null, "English translation for Page.UpdatedAt", true, "Page.UpdatedAt", 2, 0, null, null, "Updated At" },
                    { 209, "Page", new DateTime(2025, 11, 7, 16, 2, 17, 720, DateTimeKind.Utc).AddTicks(9161), null, "English translation for Page.Status", true, "Page.Status", 2, 0, null, null, "Status" },
                    { 210, "Page", new DateTime(2025, 11, 7, 16, 2, 17, 720, DateTimeKind.Utc).AddTicks(9162), null, "English translation for Page.Type", true, "Page.Type", 2, 0, null, null, "Page Type" },
                    { 211, "Page", new DateTime(2025, 11, 7, 16, 2, 17, 720, DateTimeKind.Utc).AddTicks(9164), null, "English translation for Page.Layout", true, "Page.Layout", 2, 0, null, null, "Layout" },
                    { 212, "Page", new DateTime(2025, 11, 7, 16, 2, 17, 720, DateTimeKind.Utc).AddTicks(9165), null, "English translation for Page.Template", true, "Page.Template", 2, 0, null, null, "Template" },
                    { 213, "Page", new DateTime(2025, 11, 7, 16, 2, 17, 720, DateTimeKind.Utc).AddTicks(9166), null, "English translation for Page.SEO", true, "Page.SEO", 2, 0, null, null, "SEO Settings" },
                    { 214, "Page", new DateTime(2025, 11, 7, 16, 2, 17, 720, DateTimeKind.Utc).AddTicks(9167), null, "English translation for Page.Sections", true, "Page.Sections", 2, 0, null, null, "Sections" },
                    { 215, "Page", new DateTime(2025, 11, 7, 16, 2, 17, 720, DateTimeKind.Utc).AddTicks(9168), null, "English translation for Page.Items", true, "Page.Items", 2, 0, null, null, "Items" },
                    { 216, "Page", new DateTime(2025, 11, 7, 16, 2, 17, 720, DateTimeKind.Utc).AddTicks(9169), null, "English translation for Page.Fields", true, "Page.Fields", 2, 0, null, null, "Fields" },
                    { 217, "Section", new DateTime(2025, 11, 7, 16, 2, 17, 720, DateTimeKind.Utc).AddTicks(9172), null, "English translation for Section.Name", true, "Section.Name", 2, 0, null, null, "Section Name" },
                    { 218, "Section", new DateTime(2025, 11, 7, 16, 2, 17, 720, DateTimeKind.Utc).AddTicks(9174), null, "English translation for Section.Type", true, "Section.Type", 2, 0, null, null, "Section Type" },
                    { 219, "Section", new DateTime(2025, 11, 7, 16, 2, 17, 720, DateTimeKind.Utc).AddTicks(9175), null, "English translation for Section.Key", true, "Section.Key", 2, 0, null, null, "Section Key" },
                    { 220, "Section", new DateTime(2025, 11, 7, 16, 2, 17, 720, DateTimeKind.Utc).AddTicks(9176), null, "English translation for Section.Order", true, "Section.Order", 2, 0, null, null, "Order" },
                    { 221, "Section", new DateTime(2025, 11, 7, 16, 2, 17, 720, DateTimeKind.Utc).AddTicks(9198), null, "English translation for Section.Settings", true, "Section.Settings", 2, 0, null, null, "Settings" },
                    { 222, "Section", new DateTime(2025, 11, 7, 16, 2, 17, 720, DateTimeKind.Utc).AddTicks(9200), null, "English translation for Section.Items", true, "Section.Items", 2, 0, null, null, "Items" },
                    { 223, "Section", new DateTime(2025, 11, 7, 16, 2, 17, 720, DateTimeKind.Utc).AddTicks(9201), null, "English translation for Section.AddItem", true, "Section.AddItem", 2, 0, null, null, "Add Item" },
                    { 224, "Section", new DateTime(2025, 11, 7, 16, 2, 17, 720, DateTimeKind.Utc).AddTicks(9203), null, "English translation for Section.EditItems", true, "Section.EditItems", 2, 0, null, null, "Edit Items" },
                    { 225, "Section", new DateTime(2025, 11, 7, 16, 2, 17, 720, DateTimeKind.Utc).AddTicks(9204), null, "English translation for Section.Duplicate", true, "Section.Duplicate", 2, 0, null, null, "Duplicate" },
                    { 226, "Section", new DateTime(2025, 11, 7, 16, 2, 17, 720, DateTimeKind.Utc).AddTicks(9205), null, "English translation for Section.Remove", true, "Section.Remove", 2, 0, null, null, "Remove" },
                    { 227, "Section", new DateTime(2025, 11, 7, 16, 2, 17, 720, DateTimeKind.Utc).AddTicks(9206), null, "English translation for Section.Hero", true, "Section.Hero", 2, 0, null, null, "Hero Section" },
                    { 228, "Section", new DateTime(2025, 11, 7, 16, 2, 17, 720, DateTimeKind.Utc).AddTicks(9207), null, "English translation for Section.Navbar", true, "Section.Navbar", 2, 0, null, null, "Navigation" },
                    { 229, "Section", new DateTime(2025, 11, 7, 16, 2, 17, 720, DateTimeKind.Utc).AddTicks(9208), null, "English translation for Section.Footer", true, "Section.Footer", 2, 0, null, null, "Footer" },
                    { 230, "Section", new DateTime(2025, 11, 7, 16, 2, 17, 720, DateTimeKind.Utc).AddTicks(9209), null, "English translation for Section.Content", true, "Section.Content", 2, 0, null, null, "Content" },
                    { 231, "Section", new DateTime(2025, 11, 7, 16, 2, 17, 720, DateTimeKind.Utc).AddTicks(9211), null, "English translation for Section.Gallery", true, "Section.Gallery", 2, 0, null, null, "Gallery" },
                    { 232, "Section", new DateTime(2025, 11, 7, 16, 2, 17, 720, DateTimeKind.Utc).AddTicks(9212), null, "English translation for Section.Contact", true, "Section.Contact", 2, 0, null, null, "Contact" },
                    { 233, "Validation", new DateTime(2025, 11, 7, 16, 2, 17, 720, DateTimeKind.Utc).AddTicks(9215), null, "English translation for Validation.Required", true, "Validation.Required", 2, 0, null, null, "This field is required" },
                    { 234, "Validation", new DateTime(2025, 11, 7, 16, 2, 17, 720, DateTimeKind.Utc).AddTicks(9217), null, "English translation for Validation.Email", true, "Validation.Email", 2, 0, null, null, "Please enter a valid email address" },
                    { 235, "Validation", new DateTime(2025, 11, 7, 16, 2, 17, 720, DateTimeKind.Utc).AddTicks(9218), null, "English translation for Validation.MinLength", true, "Validation.MinLength", 2, 0, null, null, "Must be at least {0} characters" },
                    { 236, "Validation", new DateTime(2025, 11, 7, 16, 2, 17, 720, DateTimeKind.Utc).AddTicks(9219), null, "English translation for Validation.MaxLength", true, "Validation.MaxLength", 2, 0, null, null, "Must be at most {0} characters" },
                    { 237, "Validation", new DateTime(2025, 11, 7, 16, 2, 17, 720, DateTimeKind.Utc).AddTicks(9221), null, "English translation for Validation.Range", true, "Validation.Range", 2, 0, null, null, "Must be between {0} and {1}" },
                    { 238, "Validation", new DateTime(2025, 11, 7, 16, 2, 17, 720, DateTimeKind.Utc).AddTicks(9222), null, "English translation for Validation.Numeric", true, "Validation.Numeric", 2, 0, null, null, "Please enter a numeric value" },
                    { 239, "Validation", new DateTime(2025, 11, 7, 16, 2, 17, 720, DateTimeKind.Utc).AddTicks(9223), null, "English translation for Validation.Date", true, "Validation.Date", 2, 0, null, null, "Please enter a valid date" },
                    { 240, "Validation", new DateTime(2025, 11, 7, 16, 2, 17, 720, DateTimeKind.Utc).AddTicks(9224), null, "English translation for Validation.Url", true, "Validation.Url", 2, 0, null, null, "Please enter a valid URL" },
                    { 241, "Validation", new DateTime(2025, 11, 7, 16, 2, 17, 720, DateTimeKind.Utc).AddTicks(9225), null, "English translation for Validation.Phone", true, "Validation.Phone", 2, 0, null, null, "Please enter a valid phone number" },
                    { 242, "Validation", new DateTime(2025, 11, 7, 16, 2, 17, 720, DateTimeKind.Utc).AddTicks(9226), null, "English translation for Validation.Password", true, "Validation.Password", 2, 0, null, null, "Password must be at least 8 characters" },
                    { 243, "Navigation", new DateTime(2025, 11, 7, 16, 2, 17, 720, DateTimeKind.Utc).AddTicks(9229), null, "English translation for Navigation.Dashboard", true, "Navigation.Dashboard", 2, 0, null, null, "Dashboard" },
                    { 244, "Navigation", new DateTime(2025, 11, 7, 16, 2, 17, 720, DateTimeKind.Utc).AddTicks(9231), null, "English translation for Navigation.Announcements", true, "Navigation.Announcements", 2, 0, null, null, "Announcements" },
                    { 245, "Navigation", new DateTime(2025, 11, 7, 16, 2, 17, 720, DateTimeKind.Utc).AddTicks(9232), null, "English translation for Navigation.Campaigns", true, "Navigation.Campaigns", 2, 0, null, null, "Campaigns" },
                    { 246, "Navigation", new DateTime(2025, 11, 7, 16, 2, 17, 720, DateTimeKind.Utc).AddTicks(9234), null, "English translation for Navigation.Content", true, "Navigation.Content", 2, 0, null, null, "Content" },
                    { 247, "Navigation", new DateTime(2025, 11, 7, 16, 2, 17, 720, DateTimeKind.Utc).AddTicks(9235), null, "English translation for Navigation.Pages", true, "Navigation.Pages", 2, 0, null, null, "Pages" },
                    { 248, "Navigation", new DateTime(2025, 11, 7, 16, 2, 17, 720, DateTimeKind.Utc).AddTicks(9236), null, "English translation for Navigation.Sections", true, "Navigation.Sections", 2, 0, null, null, "Sections" },
                    { 249, "Navigation", new DateTime(2025, 11, 7, 16, 2, 17, 720, DateTimeKind.Utc).AddTicks(9237), null, "English translation for Navigation.Layouts", true, "Navigation.Layouts", 2, 0, null, null, "Layouts" },
                    { 250, "Navigation", new DateTime(2025, 11, 7, 16, 2, 17, 720, DateTimeKind.Utc).AddTicks(9239), null, "English translation for Navigation.WebUrlManagement", true, "Navigation.WebUrlManagement", 2, 0, null, null, "Web URL Management" },
                    { 251, "Navigation", new DateTime(2025, 11, 7, 16, 2, 17, 720, DateTimeKind.Utc).AddTicks(9240), null, "English translation for Navigation.News", true, "Navigation.News", 2, 0, null, null, "News" },
                    { 252, "Navigation", new DateTime(2025, 11, 7, 16, 2, 17, 720, DateTimeKind.Utc).AddTicks(9241), null, "English translation for Navigation.Blog", true, "Navigation.Blog", 2, 0, null, null, "Blog" },
                    { 253, "Navigation", new DateTime(2025, 11, 7, 16, 2, 17, 720, DateTimeKind.Utc).AddTicks(9242), null, "English translation for Navigation.Templates", true, "Navigation.Templates", 2, 0, null, null, "Templates" },
                    { 254, "Navigation", new DateTime(2025, 11, 7, 16, 2, 17, 720, DateTimeKind.Utc).AddTicks(9243), null, "English translation for Navigation.SectionItems", true, "Navigation.SectionItems", 2, 0, null, null, "Section Items" },
                    { 255, "Navigation", new DateTime(2025, 11, 7, 16, 2, 17, 720, DateTimeKind.Utc).AddTicks(9244), null, "English translation for Navigation.ECommerce", true, "Navigation.ECommerce", 2, 0, null, null, "E-Commerce" },
                    { 256, "Navigation", new DateTime(2025, 11, 7, 16, 2, 17, 720, DateTimeKind.Utc).AddTicks(9279), null, "English translation for Navigation.Products", true, "Navigation.Products", 2, 0, null, null, "Products" },
                    { 257, "Navigation", new DateTime(2025, 11, 7, 16, 2, 17, 720, DateTimeKind.Utc).AddTicks(9280), null, "English translation for Navigation.Categories", true, "Navigation.Categories", 2, 0, null, null, "Categories" },
                    { 258, "Navigation", new DateTime(2025, 11, 7, 16, 2, 17, 720, DateTimeKind.Utc).AddTicks(9283), null, "English translation for Navigation.Orders", true, "Navigation.Orders", 2, 0, null, null, "Orders" },
                    { 259, "Navigation", new DateTime(2025, 11, 7, 16, 2, 17, 720, DateTimeKind.Utc).AddTicks(9284), null, "English translation for Navigation.Users", true, "Navigation.Users", 2, 0, null, null, "Users" },
                    { 260, "Navigation", new DateTime(2025, 11, 7, 16, 2, 17, 720, DateTimeKind.Utc).AddTicks(9285), null, "English translation for Navigation.ManageUsers", true, "Navigation.ManageUsers", 2, 0, null, null, "Manage Users" },
                    { 261, "Navigation", new DateTime(2025, 11, 7, 16, 2, 17, 720, DateTimeKind.Utc).AddTicks(9286), null, "English translation for Navigation.ManageRoles", true, "Navigation.ManageRoles", 2, 0, null, null, "Manage Roles" },
                    { 262, "Navigation", new DateTime(2025, 11, 7, 16, 2, 17, 720, DateTimeKind.Utc).AddTicks(9287), null, "English translation for Navigation.ManagePermissions", true, "Navigation.ManagePermissions", 2, 0, null, null, "Manage Permissions" },
                    { 263, "Navigation", new DateTime(2025, 11, 7, 16, 2, 17, 720, DateTimeKind.Utc).AddTicks(9288), null, "English translation for Navigation.Analytics", true, "Navigation.Analytics", 2, 0, null, null, "Analytics" },
                    { 264, "Navigation", new DateTime(2025, 11, 7, 16, 2, 17, 720, DateTimeKind.Utc).AddTicks(9289), null, "English translation for Navigation.Settings", true, "Navigation.Settings", 2, 0, null, null, "Settings" },
                    { 265, "Navigation", new DateTime(2025, 11, 7, 16, 2, 17, 720, DateTimeKind.Utc).AddTicks(9291), null, "English translation for Navigation.GeneralSettings", true, "Navigation.GeneralSettings", 2, 0, null, null, "General Settings" },
                    { 266, "Navigation", new DateTime(2025, 11, 7, 16, 2, 17, 720, DateTimeKind.Utc).AddTicks(9292), null, "English translation for Navigation.Countries", true, "Navigation.Countries", 2, 0, null, null, "Countries" },
                    { 267, "Navigation", new DateTime(2025, 11, 7, 16, 2, 17, 720, DateTimeKind.Utc).AddTicks(9293), null, "English translation for Navigation.Languages", true, "Navigation.Languages", 2, 0, null, null, "Languages" },
                    { 268, "Navigation", new DateTime(2025, 11, 7, 16, 2, 17, 720, DateTimeKind.Utc).AddTicks(9294), null, "English translation for Navigation.Localization", true, "Navigation.Localization", 2, 0, null, null, "Localization" },
                    { 269, "Navigation", new DateTime(2025, 11, 7, 16, 2, 17, 720, DateTimeKind.Utc).AddTicks(9295), null, "English translation for Navigation.Profile", true, "Navigation.Profile", 2, 0, null, null, "Profile" },
                    { 270, "Navigation", new DateTime(2025, 11, 7, 16, 2, 17, 720, DateTimeKind.Utc).AddTicks(9296), null, "English translation for Navigation.Help", true, "Navigation.Help", 2, 0, null, null, "Help" },
                    { 271, "Navigation", new DateTime(2025, 11, 7, 16, 2, 17, 720, DateTimeKind.Utc).AddTicks(9297), null, "English translation for Navigation.Logout", true, "Navigation.Logout", 2, 0, null, null, "Logout" },
                    { 272, "Language", new DateTime(2025, 11, 7, 16, 2, 17, 720, DateTimeKind.Utc).AddTicks(9300), null, "English translation for Language.English", true, "Language.English", 2, 0, null, null, "English" },
                    { 273, "Language", new DateTime(2025, 11, 7, 16, 2, 17, 720, DateTimeKind.Utc).AddTicks(9302), null, "English translation for Language.Turkish", true, "Language.Turkish", 2, 0, null, null, "Turkish" },
                    { 274, "Dashboard", new DateTime(2025, 11, 7, 16, 2, 17, 720, DateTimeKind.Utc).AddTicks(9341), null, "English translation for Dashboard.Title", true, "Dashboard.Title", 2, 0, null, null, "Dashboard" },
                    { 275, "Dashboard", new DateTime(2025, 11, 7, 16, 2, 17, 720, DateTimeKind.Utc).AddTicks(9343), null, "English translation for Dashboard.WelcomeMessage", true, "Dashboard.WelcomeMessage", 2, 0, null, null, "Welcome back! Here's a summary of your CMS analytics and recent activity." },
                    { 276, "Dashboard", new DateTime(2025, 11, 7, 16, 2, 17, 720, DateTimeKind.Utc).AddTicks(9344), null, "English translation for Dashboard.Last7Days", true, "Dashboard.Last7Days", 2, 0, null, null, "Last 7 days" },
                    { 277, "Dashboard", new DateTime(2025, 11, 7, 16, 2, 17, 720, DateTimeKind.Utc).AddTicks(9345), null, "English translation for Dashboard.Last30Days", true, "Dashboard.Last30Days", 2, 0, null, null, "Last 30 days" },
                    { 278, "Dashboard", new DateTime(2025, 11, 7, 16, 2, 17, 720, DateTimeKind.Utc).AddTicks(9346), null, "English translation for Dashboard.Last90Days", true, "Dashboard.Last90Days", 2, 0, null, null, "Last 90 days" },
                    { 279, "Dashboard", new DateTime(2025, 11, 7, 16, 2, 17, 720, DateTimeKind.Utc).AddTicks(9347), null, "English translation for Dashboard.TotalUsers", true, "Dashboard.TotalUsers", 2, 0, null, null, "Total Users" },
                    { 280, "Dashboard", new DateTime(2025, 11, 7, 16, 2, 17, 720, DateTimeKind.Utc).AddTicks(9348), null, "English translation for Dashboard.TotalRevenue", true, "Dashboard.TotalRevenue", 2, 0, null, null, "Total Revenue" },
                    { 281, "Dashboard", new DateTime(2025, 11, 7, 16, 2, 17, 720, DateTimeKind.Utc).AddTicks(9350), null, "English translation for Dashboard.Products", true, "Dashboard.Products", 2, 0, null, null, "Products" },
                    { 282, "Dashboard", new DateTime(2025, 11, 7, 16, 2, 17, 720, DateTimeKind.Utc).AddTicks(9351), null, "English translation for Dashboard.SupportTickets", true, "Dashboard.SupportTickets", 2, 0, null, null, "Support Tickets" },
                    { 283, "Dashboard", new DateTime(2025, 11, 7, 16, 2, 17, 720, DateTimeKind.Utc).AddTicks(9352), null, "English translation for Dashboard.FromLastMonth", true, "Dashboard.FromLastMonth", 2, 0, null, null, "from last month" },
                    { 284, "Dashboard", new DateTime(2025, 11, 7, 16, 2, 17, 720, DateTimeKind.Utc).AddTicks(9353), null, "English translation for Dashboard.SalesOverview", true, "Dashboard.SalesOverview", 2, 0, null, null, "Sales Overview" },
                    { 285, "Dashboard", new DateTime(2025, 11, 7, 16, 2, 17, 720, DateTimeKind.Utc).AddTicks(9354), null, "English translation for Dashboard.Monthly", true, "Dashboard.Monthly", 2, 0, null, null, "Monthly" },
                    { 286, "Dashboard", new DateTime(2025, 11, 7, 16, 2, 17, 720, DateTimeKind.Utc).AddTicks(9355), null, "English translation for Dashboard.ChartVisualization", true, "Dashboard.ChartVisualization", 2, 0, null, null, "Chart visualization goes here" },
                    { 287, "Dashboard", new DateTime(2025, 11, 7, 16, 2, 17, 720, DateTimeKind.Utc).AddTicks(9356), null, "English translation for Dashboard.ThisYear", true, "Dashboard.ThisYear", 2, 0, null, null, "This Year" },
                    { 288, "Dashboard", new DateTime(2025, 11, 7, 16, 2, 17, 720, DateTimeKind.Utc).AddTicks(9357), null, "English translation for Dashboard.LastYear", true, "Dashboard.LastYear", 2, 0, null, null, "Last Year" },
                    { 289, "Dashboard", new DateTime(2025, 11, 7, 16, 2, 17, 720, DateTimeKind.Utc).AddTicks(9359), null, "English translation for Dashboard.RecentActivities", true, "Dashboard.RecentActivities", 2, 0, null, null, "Recent Activities" },
                    { 290, "Dashboard", new DateTime(2025, 11, 7, 16, 2, 17, 720, DateTimeKind.Utc).AddTicks(9360), null, "English translation for Dashboard.TopProducts", true, "Dashboard.TopProducts", 2, 0, null, null, "Top Products" },
                    { 291, "Dashboard", new DateTime(2025, 11, 7, 16, 2, 17, 720, DateTimeKind.Utc).AddTicks(9361), null, "English translation for Dashboard.Product", true, "Dashboard.Product", 2, 0, null, null, "Product" },
                    { 292, "Dashboard", new DateTime(2025, 11, 7, 16, 2, 17, 720, DateTimeKind.Utc).AddTicks(9362), null, "English translation for Dashboard.Category", true, "Dashboard.Category", 2, 0, null, null, "Category" },
                    { 293, "Dashboard", new DateTime(2025, 11, 7, 16, 2, 17, 720, DateTimeKind.Utc).AddTicks(9363), null, "English translation for Dashboard.Sales", true, "Dashboard.Sales", 2, 0, null, null, "Sales" },
                    { 294, "Dashboard", new DateTime(2025, 11, 7, 16, 2, 17, 720, DateTimeKind.Utc).AddTicks(9364), null, "English translation for Dashboard.Status", true, "Dashboard.Status", 2, 0, null, null, "Status" },
                    { 295, "Dashboard", new DateTime(2025, 11, 7, 16, 2, 17, 720, DateTimeKind.Utc).AddTicks(9365), null, "English translation for Dashboard.LatestOrders", true, "Dashboard.LatestOrders", 2, 0, null, null, "Latest Orders" },
                    { 296, "Dashboard", new DateTime(2025, 11, 7, 16, 2, 17, 720, DateTimeKind.Utc).AddTicks(9366), null, "English translation for Dashboard.Today", true, "Dashboard.Today", 2, 0, null, null, "Today" },
                    { 297, "Dashboard", new DateTime(2025, 11, 7, 16, 2, 17, 720, DateTimeKind.Utc).AddTicks(9367), null, "English translation for Dashboard.Yesterday", true, "Dashboard.Yesterday", 2, 0, null, null, "Yesterday" },
                    { 298, "Dashboard", new DateTime(2025, 11, 7, 16, 2, 17, 720, DateTimeKind.Utc).AddTicks(9368), null, "English translation for Dashboard.OrderId", true, "Dashboard.OrderId", 2, 0, null, null, "Order ID" },
                    { 299, "Dashboard", new DateTime(2025, 11, 7, 16, 2, 17, 720, DateTimeKind.Utc).AddTicks(9369), null, "English translation for Dashboard.Customer", true, "Dashboard.Customer", 2, 0, null, null, "Customer" },
                    { 300, "Dashboard", new DateTime(2025, 11, 7, 16, 2, 17, 720, DateTimeKind.Utc).AddTicks(9370), null, "English translation for Dashboard.Date", true, "Dashboard.Date", 2, 0, null, null, "Date" },
                    { 301, "Dashboard", new DateTime(2025, 11, 7, 16, 2, 17, 720, DateTimeKind.Utc).AddTicks(9372), null, "English translation for Dashboard.Amount", true, "Dashboard.Amount", 2, 0, null, null, "Amount" },
                    { 302, "Localization", new DateTime(2025, 11, 7, 16, 2, 17, 720, DateTimeKind.Utc).AddTicks(9375), null, "English translation for Localization.SystemDescription", true, "Localization.SystemDescription", 2, 0, null, null, "Manage text translations used throughout the system" },
                    { 303, "Localization", new DateTime(2025, 11, 7, 16, 2, 17, 720, DateTimeKind.Utc).AddTicks(9376), null, "English translation for Localization.Keys", true, "Localization.Keys", 2, 0, null, null, "Localization Keys" },
                    { 304, "Localization", new DateTime(2025, 11, 7, 16, 2, 17, 720, DateTimeKind.Utc).AddTicks(9378), null, "English translation for Localization.Key", true, "Localization.Key", 2, 0, null, null, "Key" },
                    { 305, "Localization", new DateTime(2025, 11, 7, 16, 2, 17, 720, DateTimeKind.Utc).AddTicks(9379), null, "English translation for Localization.AddKey", true, "Localization.AddKey", 2, 0, null, null, "Add New Key" },
                    { 306, "Localization", new DateTime(2025, 11, 7, 16, 2, 17, 720, DateTimeKind.Utc).AddTicks(9380), null, "English translation for Localization.EditKey", true, "Localization.EditKey", 2, 0, null, null, "Edit Key" },
                    { 307, "Localization", new DateTime(2025, 11, 7, 16, 2, 17, 720, DateTimeKind.Utc).AddTicks(9381), null, "English translation for Localization.KeyDetails", true, "Localization.KeyDetails", 2, 0, null, null, "Key Details" },
                    { 308, "Localization", new DateTime(2025, 11, 7, 16, 2, 17, 720, DateTimeKind.Utc).AddTicks(9382), null, "English translation for Localization.AddKeyDescription", true, "Localization.AddKeyDescription", 2, 0, null, null, "Add a new localization key and its translations" },
                    { 309, "Localization", new DateTime(2025, 11, 7, 16, 2, 17, 720, DateTimeKind.Utc).AddTicks(9409), null, "English translation for Localization.EditKeyDescription", true, "Localization.EditKeyDescription", 2, 0, null, null, "Edit existing localization key and its translations" },
                    { 310, "Localization", new DateTime(2025, 11, 7, 16, 2, 17, 720, DateTimeKind.Utc).AddTicks(9411), null, "English translation for Localization.KeyPlaceholder", true, "Localization.KeyPlaceholder", 2, 0, null, null, "e.g: Common.Save" },
                    { 311, "Localization", new DateTime(2025, 11, 7, 16, 2, 17, 720, DateTimeKind.Utc).AddTicks(9412), null, "English translation for Localization.KeyHint", true, "Localization.KeyHint", 2, 0, null, null, "Use dot-separated hierarchical key" },
                    { 312, "Localization", new DateTime(2025, 11, 7, 16, 2, 17, 720, DateTimeKind.Utc).AddTicks(9413), null, "English translation for Localization.KeyReadonly", true, "Localization.KeyReadonly", 2, 0, null, null, "Key cannot be changed" },
                    { 313, "Localization", new DateTime(2025, 11, 7, 16, 2, 17, 720, DateTimeKind.Utc).AddTicks(9414), null, "English translation for Localization.Description", true, "Localization.Description", 2, 0, null, null, "Description" },
                    { 314, "Localization", new DateTime(2025, 11, 7, 16, 2, 17, 720, DateTimeKind.Utc).AddTicks(9415), null, "English translation for Localization.DescriptionPlaceholder", true, "Localization.DescriptionPlaceholder", 2, 0, null, null, "Describe what this key is used for" },
                    { 315, "Localization", new DateTime(2025, 11, 7, 16, 2, 17, 720, DateTimeKind.Utc).AddTicks(9417), null, "English translation for Localization.SelectCategory", true, "Localization.SelectCategory", 2, 0, null, null, "Select Category" },
                    { 316, "Localization", new DateTime(2025, 11, 7, 16, 2, 17, 720, DateTimeKind.Utc).AddTicks(9418), null, "English translation for Localization.Translations", true, "Localization.Translations", 2, 0, null, null, "Translations" },
                    { 317, "Localization", new DateTime(2025, 11, 7, 16, 2, 17, 720, DateTimeKind.Utc).AddTicks(9419), null, "English translation for Localization.TranslationPlaceholder", true, "Localization.TranslationPlaceholder", 2, 0, null, null, "Enter translation in {0}" },
                    { 318, "Localization", new DateTime(2025, 11, 7, 16, 2, 17, 720, DateTimeKind.Utc).AddTicks(9420), null, "English translation for Localization.Translated", true, "Localization.Translated", 2, 0, null, null, "Translated" },
                    { 319, "Localization", new DateTime(2025, 11, 7, 16, 2, 17, 720, DateTimeKind.Utc).AddTicks(9421), null, "English translation for Localization.NotTranslated", true, "Localization.NotTranslated", 2, 0, null, null, "Not Translated" },
                    { 320, "Localization", new DateTime(2025, 11, 7, 16, 2, 17, 720, DateTimeKind.Utc).AddTicks(9423), null, "English translation for Localization.LastUpdated", true, "Localization.LastUpdated", 2, 0, null, null, "Last Updated" },
                    { 321, "Localization", new DateTime(2025, 11, 7, 16, 2, 17, 720, DateTimeKind.Utc).AddTicks(9424), null, "English translation for Localization.SearchPlaceholder", true, "Localization.SearchPlaceholder", 2, 0, null, null, "Search key or value..." },
                    { 322, "Localization", new DateTime(2025, 11, 7, 16, 2, 17, 720, DateTimeKind.Utc).AddTicks(9425), null, "English translation for Localization.ShowingResults", true, "Localization.ShowingResults", 2, 0, null, null, "Showing {0}-{1} of {2} results" },
                    { 323, "Localization", new DateTime(2025, 11, 7, 16, 2, 17, 720, DateTimeKind.Utc).AddTicks(9426), null, "English translation for Localization.NoKeys", true, "Localization.NoKeys", 2, 0, null, null, "No localization keys found" },
                    { 324, "Localization", new DateTime(2025, 11, 7, 16, 2, 17, 720, DateTimeKind.Utc).AddTicks(9428), null, "English translation for Localization.NoKeysDescription", true, "Localization.NoKeysDescription", 2, 0, null, null, "No localization keys have been added yet" },
                    { 325, "Localization", new DateTime(2025, 11, 7, 16, 2, 17, 720, DateTimeKind.Utc).AddTicks(9429), null, "English translation for Localization.AddFirstKey", true, "Localization.AddFirstKey", 2, 0, null, null, "Add First Key" },
                    { 326, "Localization", new DateTime(2025, 11, 7, 16, 2, 17, 720, DateTimeKind.Utc).AddTicks(9430), null, "English translation for Localization.DeleteConfirmation", true, "Localization.DeleteConfirmation", 2, 0, null, null, "Are you sure you want to delete this key and all its translations?" },
                    { 327, "Product", new DateTime(2025, 11, 7, 16, 2, 17, 720, DateTimeKind.Utc).AddTicks(9498), null, "Turkish translation for Navigation.ProductManagement", true, "Navigation.ProductManagement", 1, 0, null, null, "Ürün Yönetimi" },
                    { 328, "Product", new DateTime(2025, 11, 7, 16, 2, 17, 720, DateTimeKind.Utc).AddTicks(9500), null, "Turkish translation for Navigation.Variants", true, "Navigation.Variants", 1, 0, null, null, "Varyantlar" },
                    { 329, "Product", new DateTime(2025, 11, 7, 16, 2, 17, 720, DateTimeKind.Utc).AddTicks(9501), null, "Turkish translation for Navigation.Trademarks", true, "Navigation.Trademarks", 1, 0, null, null, "Markalar" },
                    { 330, "Product", new DateTime(2025, 11, 7, 16, 2, 17, 720, DateTimeKind.Utc).AddTicks(9503), null, "Turkish translation for Navigation.Cart", true, "Navigation.Cart", 1, 0, null, null, "Sepet" },
                    { 331, "Product", new DateTime(2025, 11, 7, 16, 2, 17, 720, DateTimeKind.Utc).AddTicks(9504), null, "Turkish translation for Navigation.Payments", true, "Navigation.Payments", 1, 0, null, null, "Ödemeler" },
                    { 332, "Product", new DateTime(2025, 11, 7, 16, 2, 17, 720, DateTimeKind.Utc).AddTicks(9505), null, "Turkish translation for Product.Name", true, "Product.Name", 1, 0, null, null, "Ürün Adı" },
                    { 333, "Product", new DateTime(2025, 11, 7, 16, 2, 17, 720, DateTimeKind.Utc).AddTicks(9506), null, "Turkish translation for Product.Code", true, "Product.Code", 1, 0, null, null, "Ürün Kodu" },
                    { 334, "Product", new DateTime(2025, 11, 7, 16, 2, 17, 720, DateTimeKind.Utc).AddTicks(9507), null, "Turkish translation for Product.IntegrationCode", true, "Product.IntegrationCode", 1, 0, null, null, "Entegrasyon Kodu" },
                    { 335, "Product", new DateTime(2025, 11, 7, 16, 2, 17, 720, DateTimeKind.Utc).AddTicks(9508), null, "Turkish translation for Product.ShortDescription", true, "Product.ShortDescription", 1, 0, null, null, "Kısa Açıklama" },
                    { 336, "Product", new DateTime(2025, 11, 7, 16, 2, 17, 720, DateTimeKind.Utc).AddTicks(9509), null, "Turkish translation for Product.LongDescription", true, "Product.LongDescription", 1, 0, null, null, "Uzun Açıklama" },
                    { 337, "Product", new DateTime(2025, 11, 7, 16, 2, 17, 720, DateTimeKind.Utc).AddTicks(9510), null, "Turkish translation for Product.Unit", true, "Product.Unit", 1, 0, null, null, "Birim" },
                    { 338, "Product", new DateTime(2025, 11, 7, 16, 2, 17, 720, DateTimeKind.Utc).AddTicks(9511), null, "Turkish translation for Product.Type", true, "Product.Type", 1, 0, null, null, "Ürün Tipi" },
                    { 339, "Product", new DateTime(2025, 11, 7, 16, 2, 17, 720, DateTimeKind.Utc).AddTicks(9512), null, "Turkish translation for Product.TaxRate", true, "Product.TaxRate", 1, 0, null, null, "Vergi Oranı" },
                    { 340, "Product", new DateTime(2025, 11, 7, 16, 2, 17, 720, DateTimeKind.Utc).AddTicks(9513), null, "Turkish translation for Product.Parent", true, "Product.Parent", 1, 0, null, null, "Üst Ürün" },
                    { 341, "Product", new DateTime(2025, 11, 7, 16, 2, 17, 720, DateTimeKind.Utc).AddTicks(9514), null, "Turkish translation for Product.Variants", true, "Product.Variants", 1, 0, null, null, "Varyantlar" },
                    { 342, "Product", new DateTime(2025, 11, 7, 16, 2, 17, 720, DateTimeKind.Utc).AddTicks(9515), null, "Turkish translation for Product.Categories", true, "Product.Categories", 1, 0, null, null, "Kategoriler" },
                    { 343, "Product", new DateTime(2025, 11, 7, 16, 2, 17, 720, DateTimeKind.Utc).AddTicks(9517), null, "Turkish translation for Product.Trademarks", true, "Product.Trademarks", 1, 0, null, null, "Markalar" },
                    { 344, "Product", new DateTime(2025, 11, 7, 16, 2, 17, 720, DateTimeKind.Utc).AddTicks(9518), null, "Turkish translation for Product.CreateNew", true, "Product.CreateNew", 1, 0, null, null, "Yeni Ürün Oluştur" },
                    { 345, "Product", new DateTime(2025, 11, 7, 16, 2, 17, 720, DateTimeKind.Utc).AddTicks(9519), null, "Turkish translation for Product.EditProduct", true, "Product.EditProduct", 1, 0, null, null, "Ürün Düzenle" },
                    { 346, "Product", new DateTime(2025, 11, 7, 16, 2, 17, 720, DateTimeKind.Utc).AddTicks(9520), null, "Turkish translation for Product.DeleteProduct", true, "Product.DeleteProduct", 1, 0, null, null, "Ürün Sil" },
                    { 347, "Product", new DateTime(2025, 11, 7, 16, 2, 17, 720, DateTimeKind.Utc).AddTicks(9521), null, "Turkish translation for Product.ProductDetails", true, "Product.ProductDetails", 1, 0, null, null, "Ürün Detayları" },
                    { 348, "Product", new DateTime(2025, 11, 7, 16, 2, 17, 720, DateTimeKind.Utc).AddTicks(9522), null, "Turkish translation for Variant.Name", true, "Variant.Name", 1, 0, null, null, "Varyant Adı" },
                    { 349, "Product", new DateTime(2025, 11, 7, 16, 2, 17, 720, DateTimeKind.Utc).AddTicks(9523), null, "Turkish translation for Variant.Code", true, "Variant.Code", 1, 0, null, null, "Varyant Kodu" },
                    { 350, "Product", new DateTime(2025, 11, 7, 16, 2, 17, 720, DateTimeKind.Utc).AddTicks(9524), null, "Turkish translation for Variant.Product", true, "Variant.Product", 1, 0, null, null, "Ürün" },
                    { 351, "Product", new DateTime(2025, 11, 7, 16, 2, 17, 720, DateTimeKind.Utc).AddTicks(9525), null, "Turkish translation for Variant.CreateNew", true, "Variant.CreateNew", 1, 0, null, null, "Yeni Varyant Oluştur" },
                    { 352, "Product", new DateTime(2025, 11, 7, 16, 2, 17, 720, DateTimeKind.Utc).AddTicks(9526), null, "Turkish translation for Variant.EditVariant", true, "Variant.EditVariant", 1, 0, null, null, "Varyant Düzenle" },
                    { 353, "Product", new DateTime(2025, 11, 7, 16, 2, 17, 720, DateTimeKind.Utc).AddTicks(9527), null, "Turkish translation for Variant.DeleteVariant", true, "Variant.DeleteVariant", 1, 0, null, null, "Varyant Sil" },
                    { 354, "Product", new DateTime(2025, 11, 7, 16, 2, 17, 720, DateTimeKind.Utc).AddTicks(9528), null, "Turkish translation for Trademark.Name", true, "Trademark.Name", 1, 0, null, null, "Marka Adı" },
                    { 355, "Product", new DateTime(2025, 11, 7, 16, 2, 17, 720, DateTimeKind.Utc).AddTicks(9529), null, "Turkish translation for Trademark.Code", true, "Trademark.Code", 1, 0, null, null, "Marka Kodu" },
                    { 356, "Product", new DateTime(2025, 11, 7, 16, 2, 17, 720, DateTimeKind.Utc).AddTicks(9530), null, "Turkish translation for Trademark.SortOrder", true, "Trademark.SortOrder", 1, 0, null, null, "Sıralama" },
                    { 357, "Product", new DateTime(2025, 11, 7, 16, 2, 17, 720, DateTimeKind.Utc).AddTicks(9531), null, "Turkish translation for Trademark.Parent", true, "Trademark.Parent", 1, 0, null, null, "Üst Marka" },
                    { 358, "Product", new DateTime(2025, 11, 7, 16, 2, 17, 720, DateTimeKind.Utc).AddTicks(9533), null, "Turkish translation for Trademark.CreateNew", true, "Trademark.CreateNew", 1, 0, null, null, "Yeni Marka Oluştur" },
                    { 359, "Product", new DateTime(2025, 11, 7, 16, 2, 17, 720, DateTimeKind.Utc).AddTicks(9534), null, "Turkish translation for Trademark.EditTrademark", true, "Trademark.EditTrademark", 1, 0, null, null, "Marka Düzenle" },
                    { 360, "Product", new DateTime(2025, 11, 7, 16, 2, 17, 720, DateTimeKind.Utc).AddTicks(9535), null, "Turkish translation for Trademark.DeleteTrademark", true, "Trademark.DeleteTrademark", 1, 0, null, null, "Marka Sil" },
                    { 361, "Product", new DateTime(2025, 11, 7, 16, 2, 17, 720, DateTimeKind.Utc).AddTicks(9562), null, "English translation for Navigation.ProductManagement", true, "Navigation.ProductManagement", 2, 0, null, null, "Product Management" },
                    { 362, "Product", new DateTime(2025, 11, 7, 16, 2, 17, 720, DateTimeKind.Utc).AddTicks(9564), null, "English translation for Navigation.Variants", true, "Navigation.Variants", 2, 0, null, null, "Variants" },
                    { 363, "Product", new DateTime(2025, 11, 7, 16, 2, 17, 720, DateTimeKind.Utc).AddTicks(9565), null, "English translation for Navigation.Trademarks", true, "Navigation.Trademarks", 2, 0, null, null, "Trademarks" },
                    { 364, "Product", new DateTime(2025, 11, 7, 16, 2, 17, 720, DateTimeKind.Utc).AddTicks(9567), null, "English translation for Navigation.Cart", true, "Navigation.Cart", 2, 0, null, null, "Cart" },
                    { 365, "Product", new DateTime(2025, 11, 7, 16, 2, 17, 720, DateTimeKind.Utc).AddTicks(9568), null, "English translation for Navigation.Payments", true, "Navigation.Payments", 2, 0, null, null, "Payments" },
                    { 366, "Product", new DateTime(2025, 11, 7, 16, 2, 17, 720, DateTimeKind.Utc).AddTicks(9569), null, "English translation for Product.Name", true, "Product.Name", 2, 0, null, null, "Product Name" },
                    { 367, "Product", new DateTime(2025, 11, 7, 16, 2, 17, 720, DateTimeKind.Utc).AddTicks(9570), null, "English translation for Product.Code", true, "Product.Code", 2, 0, null, null, "Product Code" },
                    { 368, "Product", new DateTime(2025, 11, 7, 16, 2, 17, 720, DateTimeKind.Utc).AddTicks(9571), null, "English translation for Product.IntegrationCode", true, "Product.IntegrationCode", 2, 0, null, null, "Integration Code" },
                    { 369, "Product", new DateTime(2025, 11, 7, 16, 2, 17, 720, DateTimeKind.Utc).AddTicks(9572), null, "English translation for Product.ShortDescription", true, "Product.ShortDescription", 2, 0, null, null, "Short Description" },
                    { 370, "Product", new DateTime(2025, 11, 7, 16, 2, 17, 720, DateTimeKind.Utc).AddTicks(9573), null, "English translation for Product.LongDescription", true, "Product.LongDescription", 2, 0, null, null, "Long Description" },
                    { 371, "Product", new DateTime(2025, 11, 7, 16, 2, 17, 720, DateTimeKind.Utc).AddTicks(9574), null, "English translation for Product.Unit", true, "Product.Unit", 2, 0, null, null, "Unit" },
                    { 372, "Product", new DateTime(2025, 11, 7, 16, 2, 17, 720, DateTimeKind.Utc).AddTicks(9575), null, "English translation for Product.Type", true, "Product.Type", 2, 0, null, null, "Product Type" },
                    { 373, "Product", new DateTime(2025, 11, 7, 16, 2, 17, 720, DateTimeKind.Utc).AddTicks(9577), null, "English translation for Product.TaxRate", true, "Product.TaxRate", 2, 0, null, null, "Tax Rate" },
                    { 374, "Product", new DateTime(2025, 11, 7, 16, 2, 17, 720, DateTimeKind.Utc).AddTicks(9578), null, "English translation for Product.Parent", true, "Product.Parent", 2, 0, null, null, "Parent Product" },
                    { 375, "Product", new DateTime(2025, 11, 7, 16, 2, 17, 720, DateTimeKind.Utc).AddTicks(9579), null, "English translation for Product.Variants", true, "Product.Variants", 2, 0, null, null, "Variants" },
                    { 376, "Product", new DateTime(2025, 11, 7, 16, 2, 17, 720, DateTimeKind.Utc).AddTicks(9580), null, "English translation for Product.Categories", true, "Product.Categories", 2, 0, null, null, "Categories" },
                    { 377, "Product", new DateTime(2025, 11, 7, 16, 2, 17, 720, DateTimeKind.Utc).AddTicks(9581), null, "English translation for Product.Trademarks", true, "Product.Trademarks", 2, 0, null, null, "Trademarks" },
                    { 378, "Product", new DateTime(2025, 11, 7, 16, 2, 17, 720, DateTimeKind.Utc).AddTicks(9582), null, "English translation for Product.CreateNew", true, "Product.CreateNew", 2, 0, null, null, "Create New Product" },
                    { 379, "Product", new DateTime(2025, 11, 7, 16, 2, 17, 720, DateTimeKind.Utc).AddTicks(9583), null, "English translation for Product.EditProduct", true, "Product.EditProduct", 2, 0, null, null, "Edit Product" },
                    { 380, "Product", new DateTime(2025, 11, 7, 16, 2, 17, 720, DateTimeKind.Utc).AddTicks(9584), null, "English translation for Product.DeleteProduct", true, "Product.DeleteProduct", 2, 0, null, null, "Delete Product" },
                    { 381, "Product", new DateTime(2025, 11, 7, 16, 2, 17, 720, DateTimeKind.Utc).AddTicks(9585), null, "English translation for Product.ProductDetails", true, "Product.ProductDetails", 2, 0, null, null, "Product Details" },
                    { 382, "Product", new DateTime(2025, 11, 7, 16, 2, 17, 720, DateTimeKind.Utc).AddTicks(9586), null, "English translation for Variant.Name", true, "Variant.Name", 2, 0, null, null, "Variant Name" },
                    { 383, "Product", new DateTime(2025, 11, 7, 16, 2, 17, 720, DateTimeKind.Utc).AddTicks(9587), null, "English translation for Variant.Code", true, "Variant.Code", 2, 0, null, null, "Variant Code" },
                    { 384, "Product", new DateTime(2025, 11, 7, 16, 2, 17, 720, DateTimeKind.Utc).AddTicks(9588), null, "English translation for Variant.Product", true, "Variant.Product", 2, 0, null, null, "Product" },
                    { 385, "Product", new DateTime(2025, 11, 7, 16, 2, 17, 720, DateTimeKind.Utc).AddTicks(9589), null, "English translation for Variant.CreateNew", true, "Variant.CreateNew", 2, 0, null, null, "Create New Variant" },
                    { 386, "Product", new DateTime(2025, 11, 7, 16, 2, 17, 720, DateTimeKind.Utc).AddTicks(9590), null, "English translation for Variant.EditVariant", true, "Variant.EditVariant", 2, 0, null, null, "Edit Variant" },
                    { 387, "Product", new DateTime(2025, 11, 7, 16, 2, 17, 720, DateTimeKind.Utc).AddTicks(9591), null, "English translation for Variant.DeleteVariant", true, "Variant.DeleteVariant", 2, 0, null, null, "Delete Variant" },
                    { 388, "Product", new DateTime(2025, 11, 7, 16, 2, 17, 720, DateTimeKind.Utc).AddTicks(9592), null, "English translation for Trademark.Name", true, "Trademark.Name", 2, 0, null, null, "Trademark Name" },
                    { 389, "Product", new DateTime(2025, 11, 7, 16, 2, 17, 720, DateTimeKind.Utc).AddTicks(9594), null, "English translation for Trademark.Code", true, "Trademark.Code", 2, 0, null, null, "Trademark Code" },
                    { 390, "Product", new DateTime(2025, 11, 7, 16, 2, 17, 720, DateTimeKind.Utc).AddTicks(9595), null, "English translation for Trademark.SortOrder", true, "Trademark.SortOrder", 2, 0, null, null, "Sort Order" },
                    { 391, "Product", new DateTime(2025, 11, 7, 16, 2, 17, 720, DateTimeKind.Utc).AddTicks(9596), null, "English translation for Trademark.Parent", true, "Trademark.Parent", 2, 0, null, null, "Parent Trademark" },
                    { 392, "Product", new DateTime(2025, 11, 7, 16, 2, 17, 720, DateTimeKind.Utc).AddTicks(9597), null, "English translation for Trademark.CreateNew", true, "Trademark.CreateNew", 2, 0, null, null, "Create New Trademark" },
                    { 393, "Product", new DateTime(2025, 11, 7, 16, 2, 17, 720, DateTimeKind.Utc).AddTicks(9599), null, "English translation for Trademark.EditTrademark", true, "Trademark.EditTrademark", 2, 0, null, null, "Edit Trademark" },
                    { 394, "Product", new DateTime(2025, 11, 7, 16, 2, 17, 720, DateTimeKind.Utc).AddTicks(9600), null, "English translation for Trademark.DeleteTrademark", true, "Trademark.DeleteTrademark", 2, 0, null, null, "Delete Trademark" }
                });

            migrationBuilder.InsertData(
                table: "OptionTranslations",
                columns: new[] { "Id", "CreatedAt", "CreatedBy", "LanguageId", "LongDescription", "Name", "OptionId", "ShortDescription", "Status", "UpdatedAt", "UpdatedBy" },
                values: new object[,]
                {
                    { 1, new DateTime(2025, 11, 7, 16, 2, 17, 733, DateTimeKind.Utc).AddTicks(297), null, 1, null, "Renk", 1, "Ürün rengi", 1, null, null },
                    { 2, new DateTime(2025, 11, 7, 16, 2, 17, 733, DateTimeKind.Utc).AddTicks(300), null, 2, null, "Color", 1, "Product color", 1, null, null },
                    { 3, new DateTime(2025, 11, 7, 16, 2, 17, 733, DateTimeKind.Utc).AddTicks(302), null, 1, null, "Beden", 2, "Ürün bedeni", 1, null, null },
                    { 4, new DateTime(2025, 11, 7, 16, 2, 17, 733, DateTimeKind.Utc).AddTicks(304), null, 2, null, "Size", 2, "Product size", 1, null, null },
                    { 5, new DateTime(2025, 11, 7, 16, 2, 17, 733, DateTimeKind.Utc).AddTicks(305), null, 1, null, "Malzeme", 3, "Ürün malzemesi", 1, null, null },
                    { 6, new DateTime(2025, 11, 7, 16, 2, 17, 733, DateTimeKind.Utc).AddTicks(307), null, 2, null, "Material", 3, "Product material", 1, null, null },
                    { 7, new DateTime(2025, 11, 7, 16, 2, 17, 733, DateTimeKind.Utc).AddTicks(308), null, 1, null, "Ağırlık", 4, "Ürün ağırlığı", 1, null, null },
                    { 8, new DateTime(2025, 11, 7, 16, 2, 17, 733, DateTimeKind.Utc).AddTicks(310), null, 2, null, "Weight", 4, "Product weight", 1, null, null },
                    { 9, new DateTime(2025, 11, 7, 16, 2, 17, 733, DateTimeKind.Utc).AddTicks(311), null, 1, null, "Garanti", 5, "Ürün garanti süresi", 1, null, null },
                    { 10, new DateTime(2025, 11, 7, 16, 2, 17, 733, DateTimeKind.Utc).AddTicks(313), null, 2, null, "Warranty", 5, "Product warranty period", 1, null, null }
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
                columns: new[] { "Id", "Code", "ContentId", "CreatedAt", "CreatedBy", "Description", "LayoutId", "Name", "PageSEOParameterId", "PageType", "ParentPageId", "Status", "UpdatedAt", "UpdatedBy" },
                values: new object[,]
                {
                    { 1, "home", 1, new DateTime(2024, 1, 1, 10, 0, 0, 0, DateTimeKind.Unspecified), null, "Web sitesinin ana sayfası", null, "Ana Sayfa", null, 1, null, 1, null, null },
                    { 2, "blog", 2, new DateTime(2024, 1, 2, 10, 0, 0, 0, DateTimeKind.Unspecified), null, "Blog yazıları sayfası", null, "Blog", null, 8, null, 1, null, null },
                    { 3, "products", 3, new DateTime(2024, 1, 3, 10, 0, 0, 0, DateTimeKind.Unspecified), null, "Ürün katalog sayfası", null, "Ürünler", null, 4, null, 1, null, null },
                    { 9, "about", null, new DateTime(2024, 1, 9, 10, 0, 0, 0, DateTimeKind.Unspecified), null, "Şirket hakkında bilgi sayfası", null, "Hakkımızda", null, 2, 4, 1, null, null },
                    { 10, "contact", null, new DateTime(2024, 1, 10, 10, 0, 0, 0, DateTimeKind.Unspecified), null, "İletişim bilgileri ve form sayfası", null, "İletişim", null, 2, 4, 1, null, null }
                });

            migrationBuilder.InsertData(
                table: "ProductOptions",
                columns: new[] { "Id", "CreatedAt", "CreatedBy", "IsDefault", "JsonValue", "OptionId", "PriceModifier", "ProductId", "SortOrder", "Status", "StockQuantity", "UpdatedAt", "UpdatedBy", "Value" },
                values: new object[] { 1, new DateTime(2025, 11, 7, 16, 2, 17, 736, DateTimeKind.Utc).AddTicks(1645), null, true, null, 1, 0m, 1, 1, 1, null, null, null, "Natural Titanium" });

            migrationBuilder.InsertData(
                table: "ProductOptions",
                columns: new[] { "Id", "CreatedAt", "CreatedBy", "JsonValue", "OptionId", "PriceModifier", "ProductId", "SortOrder", "Status", "StockQuantity", "UpdatedAt", "UpdatedBy", "Value" },
                values: new object[,]
                {
                    { 2, new DateTime(2025, 11, 7, 16, 2, 17, 736, DateTimeKind.Utc).AddTicks(1649), null, null, 1, 0m, 1, 2, 1, null, null, null, "Blue Titanium" },
                    { 3, new DateTime(2025, 11, 7, 16, 2, 17, 736, DateTimeKind.Utc).AddTicks(1652), null, null, 1, 0m, 1, 3, 1, null, null, null, "White Titanium" },
                    { 4, new DateTime(2025, 11, 7, 16, 2, 17, 736, DateTimeKind.Utc).AddTicks(1657), null, null, 5, 200m, 1, 1, 1, null, null, null, "2 Years" }
                });

            migrationBuilder.InsertData(
                table: "ProductOptions",
                columns: new[] { "Id", "CreatedAt", "CreatedBy", "IsDefault", "JsonValue", "OptionId", "PriceModifier", "ProductId", "SortOrder", "Status", "StockQuantity", "UpdatedAt", "UpdatedBy", "Value" },
                values: new object[] { 5, new DateTime(2025, 11, 7, 16, 2, 17, 736, DateTimeKind.Utc).AddTicks(1660), null, true, null, 1, 0m, 2, 1, 1, null, null, null, "Onyx Black" });

            migrationBuilder.InsertData(
                table: "ProductOptions",
                columns: new[] { "Id", "CreatedAt", "CreatedBy", "JsonValue", "OptionId", "PriceModifier", "ProductId", "SortOrder", "Status", "StockQuantity", "UpdatedAt", "UpdatedBy", "Value" },
                values: new object[,]
                {
                    { 6, new DateTime(2025, 11, 7, 16, 2, 17, 736, DateTimeKind.Utc).AddTicks(1662), null, null, 1, 0m, 2, 2, 1, null, null, null, "Cobalt Violet" },
                    { 7, new DateTime(2025, 11, 7, 16, 2, 17, 736, DateTimeKind.Utc).AddTicks(1664), null, null, 5, 100m, 2, 1, 1, null, null, null, "1 Year" }
                });

            migrationBuilder.InsertData(
                table: "ProductOptions",
                columns: new[] { "Id", "CreatedAt", "CreatedBy", "IsDefault", "JsonValue", "OptionId", "PriceModifier", "ProductId", "SortOrder", "Status", "StockQuantity", "UpdatedAt", "UpdatedBy", "Value" },
                values: new object[] { 8, new DateTime(2025, 11, 7, 16, 2, 17, 736, DateTimeKind.Utc).AddTicks(1666), null, true, null, 1, 0m, 3, 1, 1, null, null, null, "Space Gray" });

            migrationBuilder.InsertData(
                table: "ProductOptions",
                columns: new[] { "Id", "CreatedAt", "CreatedBy", "JsonValue", "OptionId", "PriceModifier", "ProductId", "SortOrder", "Status", "StockQuantity", "UpdatedAt", "UpdatedBy", "Value" },
                values: new object[] { 9, new DateTime(2025, 11, 7, 16, 2, 17, 736, DateTimeKind.Utc).AddTicks(1668), null, null, 1, 0m, 3, 2, 1, null, null, null, "Silver" });

            migrationBuilder.InsertData(
                table: "ProductOptions",
                columns: new[] { "Id", "CreatedAt", "CreatedBy", "IsDefault", "JsonValue", "OptionId", "PriceModifier", "ProductId", "SortOrder", "Status", "StockQuantity", "UpdatedAt", "UpdatedBy", "Value" },
                values: new object[,]
                {
                    { 10, new DateTime(2025, 11, 7, 16, 2, 17, 736, DateTimeKind.Utc).AddTicks(1670), null, true, null, 4, 0m, 3, 1, 1, null, null, null, "1.55 kg" },
                    { 11, new DateTime(2025, 11, 7, 16, 2, 17, 736, DateTimeKind.Utc).AddTicks(1672), null, true, null, 1, 0m, 4, 1, 1, null, null, null, "Platinum Silver" }
                });

            migrationBuilder.InsertData(
                table: "ProductOptions",
                columns: new[] { "Id", "CreatedAt", "CreatedBy", "JsonValue", "OptionId", "PriceModifier", "ProductId", "SortOrder", "Status", "StockQuantity", "UpdatedAt", "UpdatedBy", "Value" },
                values: new object[] { 12, new DateTime(2025, 11, 7, 16, 2, 17, 736, DateTimeKind.Utc).AddTicks(1674), null, null, 1, 50m, 4, 2, 1, null, null, null, "Graphite" });

            migrationBuilder.InsertData(
                table: "ProductOptions",
                columns: new[] { "Id", "CreatedAt", "CreatedBy", "IsDefault", "JsonValue", "OptionId", "PriceModifier", "ProductId", "SortOrder", "Status", "StockQuantity", "UpdatedAt", "UpdatedBy", "Value" },
                values: new object[,]
                {
                    { 13, new DateTime(2025, 11, 7, 16, 2, 17, 736, DateTimeKind.Utc).AddTicks(1676), null, true, null, 4, 0m, 4, 1, 1, null, null, null, "1.23 kg" },
                    { 14, new DateTime(2025, 11, 7, 16, 2, 17, 736, DateTimeKind.Utc).AddTicks(1678), null, true, null, 1, 0m, 5, 1, 1, null, null, null, "White" }
                });

            migrationBuilder.InsertData(
                table: "ProductOptions",
                columns: new[] { "Id", "CreatedAt", "CreatedBy", "JsonValue", "OptionId", "PriceModifier", "ProductId", "SortOrder", "Status", "StockQuantity", "UpdatedAt", "UpdatedBy", "Value" },
                values: new object[] { 15, new DateTime(2025, 11, 7, 16, 2, 17, 736, DateTimeKind.Utc).AddTicks(1685), null, null, 5, 50m, 5, 1, 1, null, null, null, "1 Year" });

            migrationBuilder.InsertData(
                table: "SectionItems",
                columns: new[] { "Id", "AllowRemove", "AllowReorder", "CreatedAt", "CreatedBy", "Description", "IconClass", "Key", "ParentSectionItemId", "SortOrder", "Status", "TemplateId", "Title", "Type", "UpdatedAt", "UpdatedBy" },
                values: new object[,]
                {
                    { 1, true, true, new DateTime(2024, 10, 25, 10, 0, 0, 0, DateTimeKind.Unspecified), null, "About us mega menu", "fas fa-info-circle", "navbar.about", null, 1, 1, 2, "About", 31, null, null },
                    { 12, true, true, new DateTime(2024, 10, 25, 10, 0, 0, 0, DateTimeKind.Unspecified), null, "Services menu with tabs", "fas fa-cogs", "navbar.services", null, 2, 1, 3, "Services", 31, null, null },
                    { 23, true, true, new DateTime(2024, 10, 25, 10, 0, 0, 0, DateTimeKind.Unspecified), null, "Solutions menu with categories", "fas fa-puzzle-piece", "navbar.solutions", null, 3, 1, 4, "Solutions", 31, null, null },
                    { 33, true, true, new DateTime(2024, 10, 25, 10, 0, 0, 0, DateTimeKind.Unspecified), null, "Blog mega menu", "fas fa-blog", "navbar.blog", null, 4, 1, 2, "Blog", 31, null, null },
                    { 43, true, true, new DateTime(2024, 10, 25, 10, 0, 0, 0, DateTimeKind.Unspecified), null, "Career opportunities", "fas fa-briefcase", "navbar.careers", null, 5, 1, 2, "Careers", 17, null, null },
                    { 44, true, true, new DateTime(2024, 10, 25, 10, 0, 0, 0, DateTimeKind.Unspecified), null, "System status and data center", "fas fa-server", "navbar.datacenter", null, 6, 1, 2, "Data Center", 17, null, null },
                    { 45, true, true, new DateTime(2024, 10, 25, 10, 0, 0, 0, DateTimeKind.Unspecified), null, "Client references", "fas fa-handshake", "navbar.references", null, 7, 1, 2, "References", 17, null, null },
                    { 46, true, true, new DateTime(2024, 10, 25, 10, 0, 0, 0, DateTimeKind.Unspecified), null, "Contact information dropdown", "fas fa-envelope", "navbar.contact", null, 8, 1, 2, "Contact", 13, null, null }
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
                table: "SectionTypeTemplates",
                columns: new[] { "Id", "CreatedAt", "CreatedBy", "CustomConfiguration", "IsDeleted", "SectionId", "SectionType", "Status", "TemplateId", "UpdatedAt", "UpdatedBy" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 10, 14, 10, 0, 0, 0, DateTimeKind.Unspecified), null, null, false, null, 1, 1, 1, null, null },
                    { 2, new DateTime(2024, 10, 14, 10, 0, 0, 0, DateTimeKind.Unspecified), null, null, false, null, 1, 1, 2, null, null },
                    { 3, new DateTime(2024, 10, 14, 10, 0, 0, 0, DateTimeKind.Unspecified), null, null, false, null, 1, 1, 3, null, null },
                    { 4, new DateTime(2024, 10, 14, 10, 0, 0, 0, DateTimeKind.Unspecified), null, null, false, null, 1, 1, 4, null, null },
                    { 5, new DateTime(2024, 10, 14, 10, 0, 0, 0, DateTimeKind.Unspecified), null, null, false, null, 2, 1, 5, null, null },
                    { 6, new DateTime(2024, 10, 14, 10, 0, 0, 0, DateTimeKind.Unspecified), null, null, false, null, 2, 1, 6, null, null },
                    { 7, new DateTime(2024, 10, 14, 10, 0, 0, 0, DateTimeKind.Unspecified), null, null, false, null, 2, 1, 7, null, null },
                    { 8, new DateTime(2024, 10, 14, 10, 0, 0, 0, DateTimeKind.Unspecified), null, null, false, null, 2, 1, 8, null, null },
                    { 9, new DateTime(2024, 10, 14, 10, 0, 0, 0, DateTimeKind.Unspecified), null, null, false, null, 2, 1, 9, null, null },
                    { 10, new DateTime(2024, 10, 14, 10, 0, 0, 0, DateTimeKind.Unspecified), null, null, false, null, 2, 1, 10, null, null },
                    { 11, new DateTime(2024, 10, 14, 10, 0, 0, 0, DateTimeKind.Unspecified), null, null, false, null, 2, 1, 11, null, null },
                    { 12, new DateTime(2024, 10, 14, 10, 0, 0, 0, DateTimeKind.Unspecified), null, null, false, null, 2, 1, 12, null, null },
                    { 13, new DateTime(2024, 10, 14, 10, 0, 0, 0, DateTimeKind.Unspecified), null, null, false, null, 2, 1, 13, null, null },
                    { 14, new DateTime(2024, 10, 14, 10, 0, 0, 0, DateTimeKind.Unspecified), null, null, false, null, 2, 1, 14, null, null },
                    { 15, new DateTime(2024, 10, 14, 10, 0, 0, 0, DateTimeKind.Unspecified), null, null, false, null, 3, 1, 5, null, null },
                    { 16, new DateTime(2024, 10, 14, 10, 0, 0, 0, DateTimeKind.Unspecified), null, null, false, null, 3, 1, 6, null, null },
                    { 17, new DateTime(2024, 10, 14, 10, 0, 0, 0, DateTimeKind.Unspecified), null, null, false, null, 3, 1, 7, null, null },
                    { 18, new DateTime(2024, 10, 14, 10, 0, 0, 0, DateTimeKind.Unspecified), null, null, false, null, 3, 1, 8, null, null },
                    { 19, new DateTime(2024, 10, 14, 10, 0, 0, 0, DateTimeKind.Unspecified), null, null, false, null, 3, 1, 9, null, null },
                    { 20, new DateTime(2024, 10, 14, 10, 0, 0, 0, DateTimeKind.Unspecified), null, null, false, null, 3, 1, 10, null, null },
                    { 21, new DateTime(2024, 10, 14, 10, 0, 0, 0, DateTimeKind.Unspecified), null, null, false, null, 3, 1, 11, null, null },
                    { 22, new DateTime(2024, 10, 14, 10, 0, 0, 0, DateTimeKind.Unspecified), null, null, false, null, 3, 1, 12, null, null },
                    { 23, new DateTime(2024, 10, 14, 10, 0, 0, 0, DateTimeKind.Unspecified), null, null, false, null, 3, 1, 13, null, null },
                    { 24, new DateTime(2024, 10, 14, 10, 0, 0, 0, DateTimeKind.Unspecified), null, null, false, null, 3, 1, 14, null, null },
                    { 25, new DateTime(2024, 10, 14, 10, 0, 0, 0, DateTimeKind.Unspecified), null, null, false, null, 4, 1, 5, null, null },
                    { 26, new DateTime(2024, 10, 14, 10, 0, 0, 0, DateTimeKind.Unspecified), null, null, false, null, 4, 1, 6, null, null },
                    { 27, new DateTime(2024, 10, 14, 10, 0, 0, 0, DateTimeKind.Unspecified), null, null, false, null, 4, 1, 7, null, null },
                    { 28, new DateTime(2024, 10, 14, 10, 0, 0, 0, DateTimeKind.Unspecified), null, null, false, null, 4, 1, 8, null, null },
                    { 29, new DateTime(2024, 10, 14, 10, 0, 0, 0, DateTimeKind.Unspecified), null, null, false, null, 4, 1, 9, null, null },
                    { 30, new DateTime(2024, 10, 14, 10, 0, 0, 0, DateTimeKind.Unspecified), null, null, false, null, 4, 1, 10, null, null },
                    { 31, new DateTime(2024, 10, 14, 10, 0, 0, 0, DateTimeKind.Unspecified), null, null, false, null, 4, 1, 11, null, null },
                    { 32, new DateTime(2024, 10, 14, 10, 0, 0, 0, DateTimeKind.Unspecified), null, null, false, null, 4, 1, 12, null, null },
                    { 33, new DateTime(2024, 10, 14, 10, 0, 0, 0, DateTimeKind.Unspecified), null, null, false, null, 4, 1, 13, null, null },
                    { 34, new DateTime(2024, 10, 14, 10, 0, 0, 0, DateTimeKind.Unspecified), null, null, false, null, 4, 1, 14, null, null },
                    { 35, new DateTime(2024, 10, 14, 10, 0, 0, 0, DateTimeKind.Unspecified), null, null, false, null, 5, 1, 5, null, null },
                    { 36, new DateTime(2024, 10, 14, 10, 0, 0, 0, DateTimeKind.Unspecified), null, null, false, null, 5, 1, 6, null, null },
                    { 37, new DateTime(2024, 10, 14, 10, 0, 0, 0, DateTimeKind.Unspecified), null, null, false, null, 5, 1, 7, null, null },
                    { 38, new DateTime(2024, 10, 14, 10, 0, 0, 0, DateTimeKind.Unspecified), null, null, false, null, 5, 1, 8, null, null },
                    { 39, new DateTime(2024, 10, 14, 10, 0, 0, 0, DateTimeKind.Unspecified), null, null, false, null, 5, 1, 9, null, null },
                    { 40, new DateTime(2024, 10, 14, 10, 0, 0, 0, DateTimeKind.Unspecified), null, null, false, null, 5, 1, 10, null, null },
                    { 41, new DateTime(2024, 10, 14, 10, 0, 0, 0, DateTimeKind.Unspecified), null, null, false, null, 5, 1, 11, null, null },
                    { 42, new DateTime(2024, 10, 14, 10, 0, 0, 0, DateTimeKind.Unspecified), null, null, false, null, 5, 1, 12, null, null },
                    { 43, new DateTime(2024, 10, 14, 10, 0, 0, 0, DateTimeKind.Unspecified), null, null, false, null, 5, 1, 13, null, null },
                    { 44, new DateTime(2024, 10, 14, 10, 0, 0, 0, DateTimeKind.Unspecified), null, null, false, null, 5, 1, 14, null, null },
                    { 45, new DateTime(2024, 10, 14, 10, 0, 0, 0, DateTimeKind.Unspecified), null, null, false, null, 6, 1, 5, null, null },
                    { 46, new DateTime(2024, 10, 14, 10, 0, 0, 0, DateTimeKind.Unspecified), null, null, false, null, 6, 1, 6, null, null },
                    { 47, new DateTime(2024, 10, 14, 10, 0, 0, 0, DateTimeKind.Unspecified), null, null, false, null, 6, 1, 7, null, null },
                    { 48, new DateTime(2024, 10, 14, 10, 0, 0, 0, DateTimeKind.Unspecified), null, null, false, null, 6, 1, 8, null, null },
                    { 49, new DateTime(2024, 10, 14, 10, 0, 0, 0, DateTimeKind.Unspecified), null, null, false, null, 6, 1, 9, null, null },
                    { 50, new DateTime(2024, 10, 14, 10, 0, 0, 0, DateTimeKind.Unspecified), null, null, false, null, 6, 1, 10, null, null },
                    { 51, new DateTime(2024, 10, 14, 10, 0, 0, 0, DateTimeKind.Unspecified), null, null, false, null, 6, 1, 11, null, null },
                    { 52, new DateTime(2024, 10, 14, 10, 0, 0, 0, DateTimeKind.Unspecified), null, null, false, null, 6, 1, 12, null, null },
                    { 53, new DateTime(2024, 10, 14, 10, 0, 0, 0, DateTimeKind.Unspecified), null, null, false, null, 6, 1, 13, null, null },
                    { 54, new DateTime(2024, 10, 14, 10, 0, 0, 0, DateTimeKind.Unspecified), null, null, false, null, 6, 1, 14, null, null },
                    { 55, new DateTime(2024, 10, 14, 10, 0, 0, 0, DateTimeKind.Unspecified), null, null, false, null, 7, 1, 5, null, null },
                    { 56, new DateTime(2024, 10, 14, 10, 0, 0, 0, DateTimeKind.Unspecified), null, null, false, null, 7, 1, 6, null, null },
                    { 57, new DateTime(2024, 10, 14, 10, 0, 0, 0, DateTimeKind.Unspecified), null, null, false, null, 7, 1, 7, null, null },
                    { 58, new DateTime(2024, 10, 14, 10, 0, 0, 0, DateTimeKind.Unspecified), null, null, false, null, 7, 1, 8, null, null },
                    { 59, new DateTime(2024, 10, 14, 10, 0, 0, 0, DateTimeKind.Unspecified), null, null, false, null, 7, 1, 9, null, null },
                    { 60, new DateTime(2024, 10, 14, 10, 0, 0, 0, DateTimeKind.Unspecified), null, null, false, null, 7, 1, 10, null, null },
                    { 61, new DateTime(2024, 10, 14, 10, 0, 0, 0, DateTimeKind.Unspecified), null, null, false, null, 7, 1, 11, null, null },
                    { 62, new DateTime(2024, 10, 14, 10, 0, 0, 0, DateTimeKind.Unspecified), null, null, false, null, 7, 1, 12, null, null },
                    { 63, new DateTime(2024, 10, 14, 10, 0, 0, 0, DateTimeKind.Unspecified), null, null, false, null, 7, 1, 13, null, null },
                    { 64, new DateTime(2024, 10, 14, 10, 0, 0, 0, DateTimeKind.Unspecified), null, null, false, null, 7, 1, 14, null, null },
                    { 65, new DateTime(2024, 10, 14, 10, 0, 0, 0, DateTimeKind.Unspecified), null, null, false, null, 8, 1, 5, null, null },
                    { 66, new DateTime(2024, 10, 14, 10, 0, 0, 0, DateTimeKind.Unspecified), null, null, false, null, 8, 1, 6, null, null },
                    { 67, new DateTime(2024, 10, 14, 10, 0, 0, 0, DateTimeKind.Unspecified), null, null, false, null, 8, 1, 7, null, null },
                    { 68, new DateTime(2024, 10, 14, 10, 0, 0, 0, DateTimeKind.Unspecified), null, null, false, null, 8, 1, 8, null, null },
                    { 69, new DateTime(2024, 10, 14, 10, 0, 0, 0, DateTimeKind.Unspecified), null, null, false, null, 8, 1, 9, null, null },
                    { 70, new DateTime(2024, 10, 14, 10, 0, 0, 0, DateTimeKind.Unspecified), null, null, false, null, 8, 1, 10, null, null },
                    { 71, new DateTime(2024, 10, 14, 10, 0, 0, 0, DateTimeKind.Unspecified), null, null, false, null, 8, 1, 11, null, null },
                    { 72, new DateTime(2024, 10, 14, 10, 0, 0, 0, DateTimeKind.Unspecified), null, null, false, null, 8, 1, 12, null, null },
                    { 73, new DateTime(2024, 10, 14, 10, 0, 0, 0, DateTimeKind.Unspecified), null, null, false, null, 8, 1, 13, null, null },
                    { 74, new DateTime(2024, 10, 14, 10, 0, 0, 0, DateTimeKind.Unspecified), null, null, false, null, 8, 1, 14, null, null },
                    { 75, new DateTime(2024, 10, 14, 10, 0, 0, 0, DateTimeKind.Unspecified), null, null, false, null, 9, 1, 5, null, null },
                    { 76, new DateTime(2024, 10, 14, 10, 0, 0, 0, DateTimeKind.Unspecified), null, null, false, null, 9, 1, 6, null, null },
                    { 77, new DateTime(2024, 10, 14, 10, 0, 0, 0, DateTimeKind.Unspecified), null, null, false, null, 9, 1, 7, null, null },
                    { 78, new DateTime(2024, 10, 14, 10, 0, 0, 0, DateTimeKind.Unspecified), null, null, false, null, 9, 1, 8, null, null },
                    { 79, new DateTime(2024, 10, 14, 10, 0, 0, 0, DateTimeKind.Unspecified), null, null, false, null, 9, 1, 9, null, null },
                    { 80, new DateTime(2024, 10, 14, 10, 0, 0, 0, DateTimeKind.Unspecified), null, null, false, null, 9, 1, 10, null, null },
                    { 81, new DateTime(2024, 10, 14, 10, 0, 0, 0, DateTimeKind.Unspecified), null, null, false, null, 9, 1, 11, null, null },
                    { 82, new DateTime(2024, 10, 14, 10, 0, 0, 0, DateTimeKind.Unspecified), null, null, false, null, 9, 1, 12, null, null },
                    { 83, new DateTime(2024, 10, 14, 10, 0, 0, 0, DateTimeKind.Unspecified), null, null, false, null, 9, 1, 13, null, null },
                    { 84, new DateTime(2024, 10, 14, 10, 0, 0, 0, DateTimeKind.Unspecified), null, null, false, null, 9, 1, 14, null, null },
                    { 85, new DateTime(2024, 10, 14, 10, 0, 0, 0, DateTimeKind.Unspecified), null, null, false, null, 10, 1, 5, null, null },
                    { 86, new DateTime(2024, 10, 14, 10, 0, 0, 0, DateTimeKind.Unspecified), null, null, false, null, 10, 1, 6, null, null },
                    { 87, new DateTime(2024, 10, 14, 10, 0, 0, 0, DateTimeKind.Unspecified), null, null, false, null, 10, 1, 7, null, null },
                    { 88, new DateTime(2024, 10, 14, 10, 0, 0, 0, DateTimeKind.Unspecified), null, null, false, null, 10, 1, 8, null, null },
                    { 89, new DateTime(2024, 10, 14, 10, 0, 0, 0, DateTimeKind.Unspecified), null, null, false, null, 10, 1, 9, null, null },
                    { 90, new DateTime(2024, 10, 14, 10, 0, 0, 0, DateTimeKind.Unspecified), null, null, false, null, 10, 1, 10, null, null },
                    { 91, new DateTime(2024, 10, 14, 10, 0, 0, 0, DateTimeKind.Unspecified), null, null, false, null, 10, 1, 11, null, null },
                    { 92, new DateTime(2024, 10, 14, 10, 0, 0, 0, DateTimeKind.Unspecified), null, null, false, null, 10, 1, 12, null, null },
                    { 93, new DateTime(2024, 10, 14, 10, 0, 0, 0, DateTimeKind.Unspecified), null, null, false, null, 10, 1, 13, null, null },
                    { 94, new DateTime(2024, 10, 14, 10, 0, 0, 0, DateTimeKind.Unspecified), null, null, false, null, 10, 1, 14, null, null },
                    { 95, new DateTime(2024, 10, 14, 10, 0, 0, 0, DateTimeKind.Unspecified), null, null, false, null, 11, 1, 5, null, null },
                    { 96, new DateTime(2024, 10, 14, 10, 0, 0, 0, DateTimeKind.Unspecified), null, null, false, null, 11, 1, 6, null, null },
                    { 97, new DateTime(2024, 10, 14, 10, 0, 0, 0, DateTimeKind.Unspecified), null, null, false, null, 11, 1, 7, null, null },
                    { 98, new DateTime(2024, 10, 14, 10, 0, 0, 0, DateTimeKind.Unspecified), null, null, false, null, 11, 1, 8, null, null },
                    { 99, new DateTime(2024, 10, 14, 10, 0, 0, 0, DateTimeKind.Unspecified), null, null, false, null, 11, 1, 9, null, null },
                    { 100, new DateTime(2024, 10, 14, 10, 0, 0, 0, DateTimeKind.Unspecified), null, null, false, null, 11, 1, 10, null, null },
                    { 101, new DateTime(2024, 10, 14, 10, 0, 0, 0, DateTimeKind.Unspecified), null, null, false, null, 11, 1, 11, null, null },
                    { 102, new DateTime(2024, 10, 14, 10, 0, 0, 0, DateTimeKind.Unspecified), null, null, false, null, 11, 1, 12, null, null },
                    { 103, new DateTime(2024, 10, 14, 10, 0, 0, 0, DateTimeKind.Unspecified), null, null, false, null, 11, 1, 13, null, null },
                    { 104, new DateTime(2024, 10, 14, 10, 0, 0, 0, DateTimeKind.Unspecified), null, null, false, null, 11, 1, 14, null, null },
                    { 105, new DateTime(2024, 10, 14, 10, 0, 0, 0, DateTimeKind.Unspecified), null, null, false, null, 12, 1, 5, null, null },
                    { 106, new DateTime(2024, 10, 14, 10, 0, 0, 0, DateTimeKind.Unspecified), null, null, false, null, 12, 1, 6, null, null },
                    { 107, new DateTime(2024, 10, 14, 10, 0, 0, 0, DateTimeKind.Unspecified), null, null, false, null, 12, 1, 7, null, null },
                    { 108, new DateTime(2024, 10, 14, 10, 0, 0, 0, DateTimeKind.Unspecified), null, null, false, null, 12, 1, 8, null, null },
                    { 109, new DateTime(2024, 10, 14, 10, 0, 0, 0, DateTimeKind.Unspecified), null, null, false, null, 12, 1, 9, null, null },
                    { 110, new DateTime(2024, 10, 14, 10, 0, 0, 0, DateTimeKind.Unspecified), null, null, false, null, 12, 1, 10, null, null },
                    { 111, new DateTime(2024, 10, 14, 10, 0, 0, 0, DateTimeKind.Unspecified), null, null, false, null, 12, 1, 11, null, null },
                    { 112, new DateTime(2024, 10, 14, 10, 0, 0, 0, DateTimeKind.Unspecified), null, null, false, null, 12, 1, 12, null, null },
                    { 113, new DateTime(2024, 10, 14, 10, 0, 0, 0, DateTimeKind.Unspecified), null, null, false, null, 12, 1, 13, null, null },
                    { 114, new DateTime(2024, 10, 14, 10, 0, 0, 0, DateTimeKind.Unspecified), null, null, false, null, 12, 1, 14, null, null },
                    { 115, new DateTime(2024, 10, 14, 10, 0, 0, 0, DateTimeKind.Unspecified), null, null, false, null, 13, 1, 5, null, null },
                    { 116, new DateTime(2024, 10, 14, 10, 0, 0, 0, DateTimeKind.Unspecified), null, null, false, null, 13, 1, 6, null, null },
                    { 117, new DateTime(2024, 10, 14, 10, 0, 0, 0, DateTimeKind.Unspecified), null, null, false, null, 13, 1, 7, null, null },
                    { 118, new DateTime(2024, 10, 14, 10, 0, 0, 0, DateTimeKind.Unspecified), null, null, false, null, 13, 1, 8, null, null },
                    { 119, new DateTime(2024, 10, 14, 10, 0, 0, 0, DateTimeKind.Unspecified), null, null, false, null, 13, 1, 9, null, null },
                    { 120, new DateTime(2024, 10, 14, 10, 0, 0, 0, DateTimeKind.Unspecified), null, null, false, null, 13, 1, 10, null, null },
                    { 121, new DateTime(2024, 10, 14, 10, 0, 0, 0, DateTimeKind.Unspecified), null, null, false, null, 13, 1, 11, null, null },
                    { 122, new DateTime(2024, 10, 14, 10, 0, 0, 0, DateTimeKind.Unspecified), null, null, false, null, 13, 1, 12, null, null },
                    { 123, new DateTime(2024, 10, 14, 10, 0, 0, 0, DateTimeKind.Unspecified), null, null, false, null, 13, 1, 13, null, null },
                    { 124, new DateTime(2024, 10, 14, 10, 0, 0, 0, DateTimeKind.Unspecified), null, null, false, null, 13, 1, 14, null, null },
                    { 125, new DateTime(2024, 10, 14, 10, 0, 0, 0, DateTimeKind.Unspecified), null, null, false, null, 14, 1, 5, null, null },
                    { 126, new DateTime(2024, 10, 14, 10, 0, 0, 0, DateTimeKind.Unspecified), null, null, false, null, 14, 1, 6, null, null },
                    { 127, new DateTime(2024, 10, 14, 10, 0, 0, 0, DateTimeKind.Unspecified), null, null, false, null, 14, 1, 7, null, null },
                    { 128, new DateTime(2024, 10, 14, 10, 0, 0, 0, DateTimeKind.Unspecified), null, null, false, null, 14, 1, 8, null, null },
                    { 129, new DateTime(2024, 10, 14, 10, 0, 0, 0, DateTimeKind.Unspecified), null, null, false, null, 14, 1, 9, null, null },
                    { 130, new DateTime(2024, 10, 14, 10, 0, 0, 0, DateTimeKind.Unspecified), null, null, false, null, 14, 1, 10, null, null },
                    { 131, new DateTime(2024, 10, 14, 10, 0, 0, 0, DateTimeKind.Unspecified), null, null, false, null, 14, 1, 11, null, null },
                    { 132, new DateTime(2024, 10, 14, 10, 0, 0, 0, DateTimeKind.Unspecified), null, null, false, null, 14, 1, 12, null, null },
                    { 133, new DateTime(2024, 10, 14, 10, 0, 0, 0, DateTimeKind.Unspecified), null, null, false, null, 14, 1, 13, null, null },
                    { 134, new DateTime(2024, 10, 14, 10, 0, 0, 0, DateTimeKind.Unspecified), null, null, false, null, 14, 1, 14, null, null },
                    { 135, new DateTime(2024, 10, 14, 10, 0, 0, 0, DateTimeKind.Unspecified), null, null, false, null, 15, 1, 5, null, null },
                    { 136, new DateTime(2024, 10, 14, 10, 0, 0, 0, DateTimeKind.Unspecified), null, null, false, null, 15, 1, 6, null, null },
                    { 137, new DateTime(2024, 10, 14, 10, 0, 0, 0, DateTimeKind.Unspecified), null, null, false, null, 15, 1, 7, null, null },
                    { 138, new DateTime(2024, 10, 14, 10, 0, 0, 0, DateTimeKind.Unspecified), null, null, false, null, 15, 1, 8, null, null },
                    { 139, new DateTime(2024, 10, 14, 10, 0, 0, 0, DateTimeKind.Unspecified), null, null, false, null, 15, 1, 9, null, null },
                    { 140, new DateTime(2024, 10, 14, 10, 0, 0, 0, DateTimeKind.Unspecified), null, null, false, null, 15, 1, 10, null, null },
                    { 141, new DateTime(2024, 10, 14, 10, 0, 0, 0, DateTimeKind.Unspecified), null, null, false, null, 15, 1, 11, null, null },
                    { 142, new DateTime(2024, 10, 14, 10, 0, 0, 0, DateTimeKind.Unspecified), null, null, false, null, 15, 1, 12, null, null },
                    { 143, new DateTime(2024, 10, 14, 10, 0, 0, 0, DateTimeKind.Unspecified), null, null, false, null, 15, 1, 13, null, null },
                    { 144, new DateTime(2024, 10, 14, 10, 0, 0, 0, DateTimeKind.Unspecified), null, null, false, null, 15, 1, 14, null, null },
                    { 145, new DateTime(2024, 10, 14, 10, 0, 0, 0, DateTimeKind.Unspecified), null, null, false, null, 16, 1, 5, null, null },
                    { 146, new DateTime(2024, 10, 14, 10, 0, 0, 0, DateTimeKind.Unspecified), null, null, false, null, 16, 1, 6, null, null },
                    { 147, new DateTime(2024, 10, 14, 10, 0, 0, 0, DateTimeKind.Unspecified), null, null, false, null, 16, 1, 7, null, null },
                    { 148, new DateTime(2024, 10, 14, 10, 0, 0, 0, DateTimeKind.Unspecified), null, null, false, null, 16, 1, 8, null, null },
                    { 149, new DateTime(2024, 10, 14, 10, 0, 0, 0, DateTimeKind.Unspecified), null, null, false, null, 16, 1, 9, null, null },
                    { 150, new DateTime(2024, 10, 14, 10, 0, 0, 0, DateTimeKind.Unspecified), null, null, false, null, 16, 1, 10, null, null },
                    { 151, new DateTime(2024, 10, 14, 10, 0, 0, 0, DateTimeKind.Unspecified), null, null, false, null, 16, 1, 11, null, null },
                    { 152, new DateTime(2024, 10, 14, 10, 0, 0, 0, DateTimeKind.Unspecified), null, null, false, null, 16, 1, 12, null, null },
                    { 153, new DateTime(2024, 10, 14, 10, 0, 0, 0, DateTimeKind.Unspecified), null, null, false, null, 16, 1, 13, null, null },
                    { 154, new DateTime(2024, 10, 14, 10, 0, 0, 0, DateTimeKind.Unspecified), null, null, false, null, 16, 1, 14, null, null },
                    { 155, new DateTime(2024, 10, 14, 10, 0, 0, 0, DateTimeKind.Unspecified), null, null, false, null, 17, 1, 5, null, null },
                    { 156, new DateTime(2024, 10, 14, 10, 0, 0, 0, DateTimeKind.Unspecified), null, null, false, null, 17, 1, 6, null, null },
                    { 157, new DateTime(2024, 10, 14, 10, 0, 0, 0, DateTimeKind.Unspecified), null, null, false, null, 17, 1, 7, null, null },
                    { 158, new DateTime(2024, 10, 14, 10, 0, 0, 0, DateTimeKind.Unspecified), null, null, false, null, 17, 1, 8, null, null },
                    { 159, new DateTime(2024, 10, 14, 10, 0, 0, 0, DateTimeKind.Unspecified), null, null, false, null, 17, 1, 9, null, null },
                    { 160, new DateTime(2024, 10, 14, 10, 0, 0, 0, DateTimeKind.Unspecified), null, null, false, null, 17, 1, 10, null, null },
                    { 161, new DateTime(2024, 10, 14, 10, 0, 0, 0, DateTimeKind.Unspecified), null, null, false, null, 17, 1, 11, null, null },
                    { 162, new DateTime(2024, 10, 14, 10, 0, 0, 0, DateTimeKind.Unspecified), null, null, false, null, 17, 1, 12, null, null },
                    { 163, new DateTime(2024, 10, 14, 10, 0, 0, 0, DateTimeKind.Unspecified), null, null, false, null, 17, 1, 13, null, null },
                    { 164, new DateTime(2024, 10, 14, 10, 0, 0, 0, DateTimeKind.Unspecified), null, null, false, null, 17, 1, 14, null, null },
                    { 165, new DateTime(2024, 10, 14, 10, 0, 0, 0, DateTimeKind.Unspecified), null, null, false, null, 18, 1, 5, null, null },
                    { 166, new DateTime(2024, 10, 14, 10, 0, 0, 0, DateTimeKind.Unspecified), null, null, false, null, 18, 1, 6, null, null },
                    { 167, new DateTime(2024, 10, 14, 10, 0, 0, 0, DateTimeKind.Unspecified), null, null, false, null, 18, 1, 7, null, null },
                    { 168, new DateTime(2024, 10, 14, 10, 0, 0, 0, DateTimeKind.Unspecified), null, null, false, null, 18, 1, 8, null, null },
                    { 169, new DateTime(2024, 10, 14, 10, 0, 0, 0, DateTimeKind.Unspecified), null, null, false, null, 18, 1, 9, null, null },
                    { 170, new DateTime(2024, 10, 14, 10, 0, 0, 0, DateTimeKind.Unspecified), null, null, false, null, 18, 1, 10, null, null },
                    { 171, new DateTime(2024, 10, 14, 10, 0, 0, 0, DateTimeKind.Unspecified), null, null, false, null, 18, 1, 11, null, null },
                    { 172, new DateTime(2024, 10, 14, 10, 0, 0, 0, DateTimeKind.Unspecified), null, null, false, null, 18, 1, 12, null, null },
                    { 173, new DateTime(2024, 10, 14, 10, 0, 0, 0, DateTimeKind.Unspecified), null, null, false, null, 18, 1, 13, null, null },
                    { 174, new DateTime(2024, 10, 14, 10, 0, 0, 0, DateTimeKind.Unspecified), null, null, false, null, 18, 1, 14, null, null },
                    { 175, new DateTime(2024, 10, 14, 10, 0, 0, 0, DateTimeKind.Unspecified), null, null, false, null, 19, 1, 5, null, null },
                    { 176, new DateTime(2024, 10, 14, 10, 0, 0, 0, DateTimeKind.Unspecified), null, null, false, null, 19, 1, 6, null, null },
                    { 177, new DateTime(2024, 10, 14, 10, 0, 0, 0, DateTimeKind.Unspecified), null, null, false, null, 19, 1, 7, null, null },
                    { 178, new DateTime(2024, 10, 14, 10, 0, 0, 0, DateTimeKind.Unspecified), null, null, false, null, 19, 1, 8, null, null },
                    { 179, new DateTime(2024, 10, 14, 10, 0, 0, 0, DateTimeKind.Unspecified), null, null, false, null, 19, 1, 9, null, null },
                    { 180, new DateTime(2024, 10, 14, 10, 0, 0, 0, DateTimeKind.Unspecified), null, null, false, null, 19, 1, 10, null, null },
                    { 181, new DateTime(2024, 10, 14, 10, 0, 0, 0, DateTimeKind.Unspecified), null, null, false, null, 19, 1, 11, null, null },
                    { 182, new DateTime(2024, 10, 14, 10, 0, 0, 0, DateTimeKind.Unspecified), null, null, false, null, 19, 1, 12, null, null },
                    { 183, new DateTime(2024, 10, 14, 10, 0, 0, 0, DateTimeKind.Unspecified), null, null, false, null, 19, 1, 13, null, null },
                    { 184, new DateTime(2024, 10, 14, 10, 0, 0, 0, DateTimeKind.Unspecified), null, null, false, null, 19, 1, 14, null, null },
                    { 185, new DateTime(2024, 10, 14, 10, 0, 0, 0, DateTimeKind.Unspecified), null, null, false, null, 20, 1, 5, null, null },
                    { 186, new DateTime(2024, 10, 14, 10, 0, 0, 0, DateTimeKind.Unspecified), null, null, false, null, 20, 1, 6, null, null },
                    { 187, new DateTime(2024, 10, 14, 10, 0, 0, 0, DateTimeKind.Unspecified), null, null, false, null, 20, 1, 7, null, null },
                    { 188, new DateTime(2024, 10, 14, 10, 0, 0, 0, DateTimeKind.Unspecified), null, null, false, null, 20, 1, 8, null, null },
                    { 189, new DateTime(2024, 10, 14, 10, 0, 0, 0, DateTimeKind.Unspecified), null, null, false, null, 20, 1, 9, null, null },
                    { 190, new DateTime(2024, 10, 14, 10, 0, 0, 0, DateTimeKind.Unspecified), null, null, false, null, 20, 1, 10, null, null },
                    { 191, new DateTime(2024, 10, 14, 10, 0, 0, 0, DateTimeKind.Unspecified), null, null, false, null, 20, 1, 11, null, null },
                    { 192, new DateTime(2024, 10, 14, 10, 0, 0, 0, DateTimeKind.Unspecified), null, null, false, null, 20, 1, 12, null, null },
                    { 193, new DateTime(2024, 10, 14, 10, 0, 0, 0, DateTimeKind.Unspecified), null, null, false, null, 20, 1, 13, null, null },
                    { 194, new DateTime(2024, 10, 14, 10, 0, 0, 0, DateTimeKind.Unspecified), null, null, false, null, 20, 1, 14, null, null },
                    { 195, new DateTime(2024, 10, 14, 10, 0, 0, 0, DateTimeKind.Unspecified), null, null, false, null, 21, 1, 5, null, null },
                    { 196, new DateTime(2024, 10, 14, 10, 0, 0, 0, DateTimeKind.Unspecified), null, null, false, null, 21, 1, 6, null, null },
                    { 197, new DateTime(2024, 10, 14, 10, 0, 0, 0, DateTimeKind.Unspecified), null, null, false, null, 21, 1, 7, null, null },
                    { 198, new DateTime(2024, 10, 14, 10, 0, 0, 0, DateTimeKind.Unspecified), null, null, false, null, 21, 1, 8, null, null },
                    { 199, new DateTime(2024, 10, 14, 10, 0, 0, 0, DateTimeKind.Unspecified), null, null, false, null, 21, 1, 9, null, null },
                    { 200, new DateTime(2024, 10, 14, 10, 0, 0, 0, DateTimeKind.Unspecified), null, null, false, null, 21, 1, 10, null, null },
                    { 201, new DateTime(2024, 10, 14, 10, 0, 0, 0, DateTimeKind.Unspecified), null, null, false, null, 21, 1, 11, null, null },
                    { 202, new DateTime(2024, 10, 14, 10, 0, 0, 0, DateTimeKind.Unspecified), null, null, false, null, 21, 1, 12, null, null },
                    { 203, new DateTime(2024, 10, 14, 10, 0, 0, 0, DateTimeKind.Unspecified), null, null, false, null, 21, 1, 13, null, null },
                    { 204, new DateTime(2024, 10, 14, 10, 0, 0, 0, DateTimeKind.Unspecified), null, null, false, null, 21, 1, 14, null, null },
                    { 205, new DateTime(2024, 10, 14, 10, 0, 0, 0, DateTimeKind.Unspecified), null, null, false, null, 22, 1, 5, null, null },
                    { 206, new DateTime(2024, 10, 14, 10, 0, 0, 0, DateTimeKind.Unspecified), null, null, false, null, 22, 1, 6, null, null },
                    { 207, new DateTime(2024, 10, 14, 10, 0, 0, 0, DateTimeKind.Unspecified), null, null, false, null, 22, 1, 7, null, null },
                    { 208, new DateTime(2024, 10, 14, 10, 0, 0, 0, DateTimeKind.Unspecified), null, null, false, null, 22, 1, 8, null, null },
                    { 209, new DateTime(2024, 10, 14, 10, 0, 0, 0, DateTimeKind.Unspecified), null, null, false, null, 22, 1, 9, null, null },
                    { 210, new DateTime(2024, 10, 14, 10, 0, 0, 0, DateTimeKind.Unspecified), null, null, false, null, 22, 1, 10, null, null },
                    { 211, new DateTime(2024, 10, 14, 10, 0, 0, 0, DateTimeKind.Unspecified), null, null, false, null, 22, 1, 11, null, null },
                    { 212, new DateTime(2024, 10, 14, 10, 0, 0, 0, DateTimeKind.Unspecified), null, null, false, null, 22, 1, 12, null, null },
                    { 213, new DateTime(2024, 10, 14, 10, 0, 0, 0, DateTimeKind.Unspecified), null, null, false, null, 22, 1, 13, null, null },
                    { 214, new DateTime(2024, 10, 14, 10, 0, 0, 0, DateTimeKind.Unspecified), null, null, false, null, 22, 1, 14, null, null },
                    { 215, new DateTime(2024, 10, 14, 10, 0, 0, 0, DateTimeKind.Unspecified), null, null, false, null, 23, 1, 5, null, null },
                    { 216, new DateTime(2024, 10, 14, 10, 0, 0, 0, DateTimeKind.Unspecified), null, null, false, null, 23, 1, 6, null, null },
                    { 217, new DateTime(2024, 10, 14, 10, 0, 0, 0, DateTimeKind.Unspecified), null, null, false, null, 23, 1, 7, null, null },
                    { 218, new DateTime(2024, 10, 14, 10, 0, 0, 0, DateTimeKind.Unspecified), null, null, false, null, 23, 1, 8, null, null },
                    { 219, new DateTime(2024, 10, 14, 10, 0, 0, 0, DateTimeKind.Unspecified), null, null, false, null, 23, 1, 9, null, null },
                    { 220, new DateTime(2024, 10, 14, 10, 0, 0, 0, DateTimeKind.Unspecified), null, null, false, null, 23, 1, 10, null, null },
                    { 221, new DateTime(2024, 10, 14, 10, 0, 0, 0, DateTimeKind.Unspecified), null, null, false, null, 23, 1, 11, null, null },
                    { 222, new DateTime(2024, 10, 14, 10, 0, 0, 0, DateTimeKind.Unspecified), null, null, false, null, 23, 1, 12, null, null },
                    { 223, new DateTime(2024, 10, 14, 10, 0, 0, 0, DateTimeKind.Unspecified), null, null, false, null, 23, 1, 13, null, null },
                    { 224, new DateTime(2024, 10, 14, 10, 0, 0, 0, DateTimeKind.Unspecified), null, null, false, null, 23, 1, 14, null, null },
                    { 225, new DateTime(2024, 10, 14, 10, 0, 0, 0, DateTimeKind.Unspecified), null, null, false, null, 24, 1, 5, null, null },
                    { 226, new DateTime(2024, 10, 14, 10, 0, 0, 0, DateTimeKind.Unspecified), null, null, false, null, 24, 1, 6, null, null },
                    { 227, new DateTime(2024, 10, 14, 10, 0, 0, 0, DateTimeKind.Unspecified), null, null, false, null, 24, 1, 7, null, null },
                    { 228, new DateTime(2024, 10, 14, 10, 0, 0, 0, DateTimeKind.Unspecified), null, null, false, null, 24, 1, 8, null, null },
                    { 229, new DateTime(2024, 10, 14, 10, 0, 0, 0, DateTimeKind.Unspecified), null, null, false, null, 24, 1, 9, null, null },
                    { 230, new DateTime(2024, 10, 14, 10, 0, 0, 0, DateTimeKind.Unspecified), null, null, false, null, 24, 1, 10, null, null },
                    { 231, new DateTime(2024, 10, 14, 10, 0, 0, 0, DateTimeKind.Unspecified), null, null, false, null, 24, 1, 11, null, null },
                    { 232, new DateTime(2024, 10, 14, 10, 0, 0, 0, DateTimeKind.Unspecified), null, null, false, null, 24, 1, 12, null, null },
                    { 233, new DateTime(2024, 10, 14, 10, 0, 0, 0, DateTimeKind.Unspecified), null, null, false, null, 24, 1, 13, null, null },
                    { 234, new DateTime(2024, 10, 14, 10, 0, 0, 0, DateTimeKind.Unspecified), null, null, false, null, 24, 1, 14, null, null }
                });

            migrationBuilder.InsertData(
                table: "TemplateTranslations",
                columns: new[] { "Id", "CreatedAt", "CreatedBy", "Description", "IsDeleted", "LanguageId", "Name", "Status", "TemplateId", "UpdatedAt", "UpdatedBy" },
                values: new object[,]
                {
                    { 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Sade ve temiz tasarımlı navigasyon çubuğu şablonu", false, 1, "Basit Navbar", 0, 1, null, null },
                    { 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Clean and simple navigation bar template", false, 2, "Simple Navbar", 0, 1, null, null },
                    { 3, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Sauberes und einfaches Navigationsleisten-Template", false, 3, "Einfache Navbar", 0, 1, null, null },
                    { 4, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Geniş kategoriler ve alt menülerle mega menü şablonu", false, 1, "Mega Menü Navbar", 0, 2, null, null },
                    { 5, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Mega menu template with wide categories and submenus", false, 2, "Mega Menu Navbar", 0, 2, null, null },
                    { 6, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Mega-Menü-Template mit breiten Kategorien und Untermenüs", false, 3, "Mega-Menü Navbar", 0, 2, null, null },
                    { 7, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Hizmet kategorilerini sekme şeklinde gösteren navbar şablonu", false, 1, "Hizmet Sekmeli Navbar", 0, 3, null, null },
                    { 8, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Navbar template displaying service categories as tabs", false, 2, "Service Tabs Navbar", 0, 3, null, null },
                    { 9, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Navbar-Template, das Servicekategorien als Tabs anzeigt", false, 3, "Service-Tabs Navbar", 0, 3, null, null },
                    { 10, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "İçerikleri kategorilere göre düzenleyen navbar şablonu", false, 1, "Kategorili Navbar", 0, 4, null, null },
                    { 11, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Navbar template organizing content by categories", false, 2, "Categorized Navbar", 0, 4, null, null },
                    { 12, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Navbar-Template, das Inhalte nach Kategorien organisiert", false, 3, "Kategorisierte Navbar", 0, 4, null, null },
                    { 13, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Temel ve esnek kullanım için varsayılan şablon", false, 1, "Varsayılan Şablon", 0, 5, null, null },
                    { 14, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Default template for basic and flexible usage", false, 2, "Default Template", 0, 5, null, null },
                    { 15, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Standard-Template für grundlegende und flexible Verwendung", false, 3, "Standard-Template", 0, 5, null, null },
                    { 16, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "İçerikleri sıralı bir şekilde gösteren şablon", false, 1, "Sıralı Şablon", 0, 6, null, null },
                    { 17, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Template displaying content in sequential order", false, 2, "Sequential Template", 0, 6, null, null },
                    { 18, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Template, das Inhalte in sequenzieller Reihenfolge anzeigt", false, 3, "Sequenzielles Template", 0, 6, null, null },
                    { 19, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "İçerikleri ızgara düzeninde gösteren şablon", false, 1, "Izgara Şablonu", 0, 7, null, null },
                    { 20, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Template displaying content in grid layout", false, 2, "Grid Template", 0, 7, null, null },
                    { 21, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Template, das Inhalte im Raster-Layout anzeigt", false, 3, "Raster-Template", 0, 7, null, null },
                    { 22, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Pinterest tarzı duvar düzeninde içerik gösteren şablon", false, 1, "Masonry Şablonu", 0, 8, null, null },
                    { 23, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Template displaying content in Pinterest-style wall layout", false, 2, "Masonry Template", 0, 8, null, null },
                    { 24, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Template, das Inhalte im Pinterest-Stil Wand-Layout anzeigt", false, 3, "Masonry-Template", 0, 8, null, null },
                    { 25, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "İçerikleri kaydırmalı karusel şeklinde gösteren şablon", false, 1, "Karusel Şablonu", 0, 9, null, null },
                    { 26, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Template displaying content in scrollable carousel format", false, 2, "Carousel Template", 0, 9, null, null },
                    { 27, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Template, das Inhalte im scrollbaren Karussell-Format anzeigt", false, 3, "Karusell-Template", 0, 9, null, null },
                    { 28, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "İçerikleri liste halinde düzenli şekilde gösteren şablon", false, 1, "Liste Şablonu", 0, 10, null, null },
                    { 29, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Template displaying content in organized list format", false, 2, "List Template", 0, 10, null, null },
                    { 30, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Template, das Inhalte im organisierten Listenformat anzeigt", false, 3, "Listen-Template", 0, 10, null, null },
                    { 31, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Tek bir içerik öğesini vurgulayan şablon", false, 1, "Tek Öğe Şablonu", 0, 11, null, null },
                    { 32, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Template highlighting a single content item", false, 2, "Single Item Template", 0, 11, null, null },
                    { 33, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Template, das einen einzelnen Inhaltsartikel hervorhebt", false, 3, "Einzelartikel-Template", 0, 11, null, null },
                    { 34, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Birden fazla içerik öğesini düzenli şekilde gösteren şablon", false, 1, "Çoklu Öğe Şablonu", 0, 12, null, null },
                    { 35, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Template displaying multiple content items in organized manner", false, 2, "Multi Item Template", 0, 12, null, null },
                    { 36, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Template, das mehrere Inhaltsartikel organisiert anzeigt", false, 3, "Mehrfachartikel-Template", 0, 12, null, null },
                    { 37, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "İçerikleri açılır-kapanır akordeon şeklinde gösteren şablon", false, 1, "Akordeon Şablonu", 0, 13, null, null },
                    { 38, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Template displaying content in expandable accordion format", false, 2, "Accordion Template", 0, 13, null, null },
                    { 39, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Template, das Inhalte im erweiterbaren Akkordeon-Format anzeigt", false, 3, "Akkordeon-Template", 0, 13, null, null },
                    { 40, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "İçerikleri sekmeler halinde organize eden şablon", false, 1, "Sekme Şablonu", 0, 14, null, null },
                    { 41, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Template organizing content into tabs", false, 2, "Tabs Template", 0, 14, null, null },
                    { 42, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Template, das Inhalte in Tabs organisiert", false, 3, "Tabs-Template", 0, 14, null, null }
                });

            migrationBuilder.InsertData(
                table: "Variants",
                columns: new[] { "Id", "Code", "CreatedAt", "CreatedBy", "IntegrationCode", "LongDescription", "Name", "ProductId", "ShortDescription", "Status", "UpdatedAt", "UpdatedBy" },
                values: new object[,]
                {
                    { 1, "iphone-15-pro-128gb-natural", new DateTime(2025, 11, 7, 16, 2, 17, 740, DateTimeKind.Utc).AddTicks(1978), null, "APPLE-IP15P-128-NAT", "", "iPhone 15 Pro 128GB Natural Titanium", 1, "128GB Natural Titanium", 1, null, null },
                    { 2, "iphone-15-pro-256gb-blue", new DateTime(2025, 11, 7, 16, 2, 17, 740, DateTimeKind.Utc).AddTicks(1984), null, "APPLE-IP15P-256-BLUE", "", "iPhone 15 Pro 256GB Blue Titanium", 1, "256GB Blue Titanium", 1, null, null },
                    { 3, "iphone-15-pro-512gb-white", new DateTime(2025, 11, 7, 16, 2, 17, 740, DateTimeKind.Utc).AddTicks(1987), null, "APPLE-IP15P-512-WHITE", "", "iPhone 15 Pro 512GB White Titanium", 1, "512GB White Titanium", 1, null, null },
                    { 4, "galaxy-s24-128gb-black", new DateTime(2025, 11, 7, 16, 2, 17, 740, DateTimeKind.Utc).AddTicks(1989), null, "SAMSUNG-GS24-128-BLACK", "", "Galaxy S24 128GB Onyx Black", 2, "128GB Onyx Black", 1, null, null },
                    { 5, "galaxy-s24-256gb-violet", new DateTime(2025, 11, 7, 16, 2, 17, 740, DateTimeKind.Utc).AddTicks(1991), null, "SAMSUNG-GS24-256-VIOLET", "", "Galaxy S24 256GB Cobalt Violet", 2, "256GB Cobalt Violet", 1, null, null },
                    { 6, "macbook-pro-14-m3-512gb", new DateTime(2025, 11, 7, 16, 2, 17, 740, DateTimeKind.Utc).AddTicks(1993), null, "APPLE-MBP14-M3-512", "", "MacBook Pro 14\" M3 512GB", 3, "M3 chip, 512GB SSD", 1, null, null },
                    { 7, "macbook-pro-14-m3-1tb", new DateTime(2025, 11, 7, 16, 2, 17, 740, DateTimeKind.Utc).AddTicks(1995), null, "APPLE-MBP14-M3-1TB", "", "MacBook Pro 14\" M3 1TB", 3, "M3 chip, 1TB SSD", 1, null, null },
                    { 8, "dell-xps-13-i5-256gb", new DateTime(2025, 11, 7, 16, 2, 17, 740, DateTimeKind.Utc).AddTicks(2023), null, "DELL-XPS13-I5-256", "", "Dell XPS 13 Intel i5 256GB", 4, "Intel i5, 256GB SSD", 1, null, null },
                    { 9, "dell-xps-13-i7-512gb", new DateTime(2025, 11, 7, 16, 2, 17, 740, DateTimeKind.Utc).AddTicks(2025), null, "DELL-XPS13-I7-512", "", "Dell XPS 13 Intel i7 512GB", 4, "Intel i7, 512GB SSD", 1, null, null }
                });

            migrationBuilder.InsertData(
                table: "CategoryTranslations",
                columns: new[] { "Id", "CategoryId", "CreatedAt", "CreatedBy", "LanguageId", "LongDescription", "Name", "ShortDescription", "Status", "UpdatedAt", "UpdatedBy" },
                values: new object[,]
                {
                    { 7, 4, new DateTime(2024, 1, 1, 10, 0, 0, 0, DateTimeKind.Unspecified), null, 1, "Masaüstü, dizüstü bilgisayar ve aksesuarları", "Bilgisayar", "Bilgisayar ürünleri", 1, null, null },
                    { 8, 4, new DateTime(2024, 1, 1, 10, 0, 0, 0, DateTimeKind.Unspecified), null, 2, "Desktop, laptop computers and accessories", "Computer", "Computer products", 1, null, null },
                    { 9, 5, new DateTime(2024, 1, 1, 10, 0, 0, 0, DateTimeKind.Unspecified), null, 1, "Akıllı telefon, cep telefonu ve aksesuarları", "Telefon", "Telefon ürünleri", 1, null, null },
                    { 10, 5, new DateTime(2024, 1, 1, 10, 0, 0, 0, DateTimeKind.Unspecified), null, 2, "Smartphones, mobile phones and accessories", "Phone", "Phone products", 1, null, null }
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
                table: "Pages",
                columns: new[] { "Id", "Code", "ContentId", "CreatedAt", "CreatedBy", "Description", "LayoutId", "Name", "PageSEOParameterId", "PageType", "ParentPageId", "Status", "UpdatedAt", "UpdatedBy" },
                values: new object[,]
                {
                    { 5, "blog-teknoloji", null, new DateTime(2024, 1, 5, 10, 0, 0, 0, DateTimeKind.Unspecified), null, "Teknoloji ile ilgili blog yazıları", null, "Teknoloji", null, 5, 2, 1, null, null },
                    { 6, "blog-tasarim", null, new DateTime(2024, 1, 6, 10, 0, 0, 0, DateTimeKind.Unspecified), null, "Tasarım ile ilgili blog yazıları", null, "Tasarım", null, 5, 2, 1, null, null },
                    { 7, "products-elektronik", null, new DateTime(2024, 1, 7, 10, 0, 0, 0, DateTimeKind.Unspecified), null, "Elektronik ürünler kategorisi", null, "Elektronik", null, 5, 3, 1, null, null },
                    { 8, "products-giyim", null, new DateTime(2024, 1, 8, 10, 0, 0, 0, DateTimeKind.Unspecified), null, "Giyim ürünleri kategorisi", null, "Giyim", null, 5, 3, 1, null, null }
                });

            migrationBuilder.InsertData(
                table: "SectionItemFields",
                columns: new[] { "Id", "AcceptedFileTypes", "CreatedAt", "CreatedBy", "DefaultValue", "FieldKey", "FieldName", "IsTranslatable", "MaxFileSize", "MaxLength", "OptionsJson", "Placeholder", "Required", "SectionItemId", "ShowInUI", "SortOrder", "Status", "Type", "UpdatedAt", "UpdatedBy" },
                values: new object[,]
                {
                    { 1, null, new DateTime(2024, 10, 25, 10, 0, 0, 0, DateTimeKind.Unspecified), null, null, "label", "Menu Label", true, null, 100, null, "Enter menu label", true, 1, true, 1, 0, 1, null, null },
                    { 2, null, new DateTime(2024, 10, 25, 10, 0, 0, 0, DateTimeKind.Unspecified), null, "megamenu", "type", "Menu Type", false, null, null, null, "Menu type (megamenu, dropdown, etc.)", false, 1, true, 2, 0, 1, null, null },
                    { 3, null, new DateTime(2024, 10, 25, 10, 0, 0, 0, DateTimeKind.Unspecified), null, "#", "url", "Menu URL", false, null, null, null, "Enter menu URL (optional for dropdowns)", false, 1, true, 3, 0, 13, null, null },
                    { 24, null, new DateTime(2024, 10, 25, 10, 0, 0, 0, DateTimeKind.Unspecified), null, null, "label", "Menu Label", true, null, 100, null, "Enter menu label", true, 12, true, 1, 0, 1, null, null },
                    { 25, null, new DateTime(2024, 10, 25, 10, 0, 0, 0, DateTimeKind.Unspecified), null, "servicetabs", "type", "Menu Type", false, null, null, null, "Menu type", false, 12, true, 2, 0, 1, null, null },
                    { 42, null, new DateTime(2024, 10, 25, 10, 0, 0, 0, DateTimeKind.Unspecified), null, null, "label", "Menu Label", true, null, 100, null, "Enter menu label", true, 23, true, 1, 0, 1, null, null },
                    { 43, null, new DateTime(2024, 10, 25, 10, 0, 0, 0, DateTimeKind.Unspecified), null, "categorized", "type", "Menu Type", false, null, null, null, "Menu type", false, 23, true, 2, 0, 1, null, null },
                    { 46, null, new DateTime(2024, 10, 25, 10, 0, 0, 0, DateTimeKind.Unspecified), null, null, "label", "Menu Label", true, null, 100, null, "Enter menu label", true, 33, true, 1, 0, 1, null, null },
                    { 47, null, new DateTime(2024, 10, 25, 10, 0, 0, 0, DateTimeKind.Unspecified), null, "megamenu", "type", "Menu Type", false, null, null, null, "Menu type", false, 33, true, 2, 0, 1, null, null },
                    { 56, null, new DateTime(2024, 10, 25, 10, 0, 0, 0, DateTimeKind.Unspecified), null, null, "label", "Link Label", true, null, 100, null, "Enter link label", true, 43, true, 1, 0, 1, null, null },
                    { 57, null, new DateTime(2024, 10, 25, 10, 0, 0, 0, DateTimeKind.Unspecified), null, null, "url", "Link URL", false, null, null, null, "Enter link URL", true, 43, true, 2, 0, 13, null, null },
                    { 58, null, new DateTime(2024, 10, 25, 10, 0, 0, 0, DateTimeKind.Unspecified), null, null, "label", "Link Label", true, null, 100, null, "Enter link label", true, 44, true, 1, 0, 1, null, null },
                    { 59, null, new DateTime(2024, 10, 25, 10, 0, 0, 0, DateTimeKind.Unspecified), null, null, "url", "Link URL", false, null, null, null, "Enter link URL", true, 44, true, 2, 0, 13, null, null },
                    { 60, null, new DateTime(2024, 10, 25, 10, 0, 0, 0, DateTimeKind.Unspecified), null, "true", "showStatus", "Show Status", false, null, null, null, null, false, 44, true, 3, 0, 10, null, null },
                    { 61, null, new DateTime(2024, 10, 25, 10, 0, 0, 0, DateTimeKind.Unspecified), null, "online", "status", "Status", false, null, null, null, "Enter status", false, 44, true, 4, 0, 1, null, null },
                    { 62, null, new DateTime(2024, 10, 25, 10, 0, 0, 0, DateTimeKind.Unspecified), null, null, "label", "Link Label", true, null, 100, null, "Enter link label", true, 45, true, 1, 0, 1, null, null },
                    { 63, null, new DateTime(2024, 10, 25, 10, 0, 0, 0, DateTimeKind.Unspecified), null, null, "url", "Link URL", false, null, null, null, "Enter link URL", true, 45, true, 2, 0, 13, null, null },
                    { 64, null, new DateTime(2024, 10, 25, 10, 0, 0, 0, DateTimeKind.Unspecified), null, null, "label", "Menu Label", true, null, 100, null, "Enter menu label", true, 46, true, 1, 0, 1, null, null },
                    { 65, null, new DateTime(2024, 10, 25, 10, 0, 0, 0, DateTimeKind.Unspecified), null, "dropdown", "type", "Menu Type", false, null, null, null, "Menu type", false, 46, true, 2, 0, 1, null, null }
                });

            migrationBuilder.InsertData(
                table: "SectionItemTranslations",
                columns: new[] { "Id", "CreatedAt", "CreatedBy", "Description", "LanguageId", "SectionItemId", "Status", "Title", "UpdatedAt", "UpdatedBy" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 1, 1, 10, 0, 0, 0, DateTimeKind.Unspecified), null, "En kaliteli ürünleri keşfedin", 1, 1, 1, "Pazar Atlası'na Hoş Geldiniz", null, null },
                    { 2, new DateTime(2024, 1, 1, 10, 0, 0, 0, DateTimeKind.Unspecified), null, "Discover the highest quality products", 2, 1, 1, "Welcome to Pazar Atlası", null, null }
                });

            migrationBuilder.InsertData(
                table: "SectionItems",
                columns: new[] { "Id", "AllowRemove", "AllowReorder", "CreatedAt", "CreatedBy", "Description", "IconClass", "Key", "ParentSectionItemId", "SortOrder", "Status", "TemplateId", "Title", "Type", "UpdatedAt", "UpdatedBy" },
                values: new object[,]
                {
                    { 2, true, true, new DateTime(2024, 10, 25, 10, 0, 0, 0, DateTimeKind.Unspecified), null, "About description section", "fas fa-building", "menus.about.description", 1, 1, 1, 2, "Description", 16, null, null },
                    { 3, true, true, new DateTime(2024, 10, 25, 10, 0, 0, 0, DateTimeKind.Unspecified), null, "Quick navigation links", "fas fa-link", "menus.about.quickLinks", 1, 2, 1, 2, "Quick Links", 14, null, null },
                    { 8, true, true, new DateTime(2024, 10, 25, 10, 0, 0, 0, DateTimeKind.Unspecified), null, "Company features", "fas fa-star", "menus.about.features", 1, 3, 1, 2, "Features", 12, null, null },
                    { 13, true, true, new DateTime(2024, 10, 25, 10, 0, 0, 0, DateTimeKind.Unspecified), null, "Managed services tab", "fas fa-server", "menus.services.tabs.managed", 12, 1, 1, 3, "Managed", 3, null, null },
                    { 14, true, true, new DateTime(2024, 10, 25, 10, 0, 0, 0, DateTimeKind.Unspecified), null, "Cloud services tab", "fas fa-cloud", "menus.services.tabs.cloud", 12, 2, 1, 3, "Cloud", 3, null, null },
                    { 15, true, true, new DateTime(2024, 10, 25, 10, 0, 0, 0, DateTimeKind.Unspecified), null, "Security services tab", "fas fa-shield-alt", "menus.services.tabs.security", 12, 3, 1, 3, "Security", 3, null, null },
                    { 16, true, true, new DateTime(2024, 10, 25, 10, 0, 0, 0, DateTimeKind.Unspecified), null, "Database services tab", "fas fa-database", "menus.services.tabs.database", 12, 4, 1, 3, "Database", 3, null, null },
                    { 17, true, true, new DateTime(2024, 10, 25, 10, 0, 0, 0, DateTimeKind.Unspecified), null, "Monitoring services tab", "fas fa-chart-line", "menus.services.tabs.monitoring", 12, 5, 1, 3, "Monitoring", 3, null, null },
                    { 18, true, true, new DateTime(2024, 10, 25, 10, 0, 0, 0, DateTimeKind.Unspecified), null, "Premium services tab", "fas fa-crown", "menus.services.tabs.premium", 12, 6, 1, 3, "Premium", 3, null, null },
                    { 24, true, true, new DateTime(2024, 10, 25, 10, 0, 0, 0, DateTimeKind.Unspecified), null, "Software solutions", "fas fa-code", "menus.solutions.categories.software", 23, 1, 1, 4, "Software", 4, null, null },
                    { 25, true, true, new DateTime(2024, 10, 25, 10, 0, 0, 0, DateTimeKind.Unspecified), null, "DevOps solutions", "fas fa-server", "menus.solutions.categories.devops", 23, 2, 1, 4, "DevOps", 4, null, null },
                    { 26, true, true, new DateTime(2024, 10, 25, 10, 0, 0, 0, DateTimeKind.Unspecified), null, "Hosting solutions", "fas fa-database", "menus.solutions.categories.hosting", 23, 3, 1, 4, "Hosting", 4, null, null },
                    { 27, true, true, new DateTime(2024, 10, 25, 10, 0, 0, 0, DateTimeKind.Unspecified), null, "Cloud solutions", "fas fa-cloud", "menus.solutions.categories.cloud", 23, 4, 1, 4, "Cloud", 4, null, null },
                    { 28, true, true, new DateTime(2024, 10, 25, 10, 0, 0, 0, DateTimeKind.Unspecified), null, "Security solutions", "fas fa-shield-alt", "menus.solutions.categories.security", 23, 5, 1, 4, "Security", 4, null, null },
                    { 34, true, true, new DateTime(2024, 10, 25, 10, 0, 0, 0, DateTimeKind.Unspecified), null, "Blog section description", "fas fa-newspaper", "menus.blog.description", 33, 1, 1, 2, "Blog Description", 16, null, null },
                    { 35, true, true, new DateTime(2024, 10, 25, 10, 0, 0, 0, DateTimeKind.Unspecified), null, "Blog categories", "fas fa-tags", "menus.blog.categories", 33, 2, 1, 2, "Categories", 14, null, null },
                    { 40, true, true, new DateTime(2024, 10, 25, 10, 0, 0, 0, DateTimeKind.Unspecified), null, "Featured blog posts", "fas fa-star", "menus.blog.featuredPosts", 33, 3, 1, 2, "Featured Posts", 14, null, null },
                    { 47, true, true, new DateTime(2024, 10, 25, 10, 0, 0, 0, DateTimeKind.Unspecified), null, "Contact email information", "fas fa-envelope", "menus.contact.contactInfo.email", 46, 1, 1, 2, "Email", 8, null, null },
                    { 48, true, true, new DateTime(2024, 10, 25, 10, 0, 0, 0, DateTimeKind.Unspecified), null, "Office address information", "fas fa-map-marker-alt", "menus.contact.contactInfo.address", 46, 2, 1, 2, "Address", 8, null, null }
                });

            migrationBuilder.InsertData(
                table: "Pages",
                columns: new[] { "Id", "Code", "ContentId", "CreatedAt", "CreatedBy", "Description", "LayoutId", "Name", "PageSEOParameterId", "PageType", "ParentPageId", "Status", "UpdatedAt", "UpdatedBy" },
                values: new object[,]
                {
                    { 11, "products-elektronik-bilgisayar", null, new DateTime(2024, 1, 11, 10, 0, 0, 0, DateTimeKind.Unspecified), null, "Bilgisayar ve aksesuarları", null, "Bilgisayar", null, 5, 7, 1, null, null },
                    { 12, "products-elektronik-telefon", null, new DateTime(2024, 1, 12, 10, 0, 0, 0, DateTimeKind.Unspecified), null, "Akıllı telefonlar ve aksesuarları", null, "Telefon", null, 5, 7, 1, null, null }
                });

            migrationBuilder.InsertData(
                table: "SectionItemFieldTranslations",
                columns: new[] { "Id", "CreatedAt", "CreatedBy", "Description", "Label", "LanguageId", "Placeholder", "SectionItemFieldId", "Status", "UpdatedAt", "UpdatedBy" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 10, 25, 10, 0, 0, 0, DateTimeKind.Unspecified), null, "Ana menü etiketi", "Menü Etiketi", 1, "Menü etiketini girin", 1, 0, null, null },
                    { 2, new DateTime(2024, 10, 25, 10, 0, 0, 0, DateTimeKind.Unspecified), null, "Main menu label", "Menu Label", 2, "Enter menu label", 1, 0, null, null },
                    { 3, new DateTime(2024, 10, 25, 10, 0, 0, 0, DateTimeKind.Unspecified), null, "Menü türü (megamenu, dropdown, vb.)", "Menü Tipi", 1, "Menü tipini girin", 2, 0, null, null },
                    { 4, new DateTime(2024, 10, 25, 10, 0, 0, 0, DateTimeKind.Unspecified), null, "Menu type (megamenu, dropdown, etc.)", "Menu Type", 2, "Enter menu type", 2, 0, null, null },
                    { 5, new DateTime(2024, 10, 25, 10, 0, 0, 0, DateTimeKind.Unspecified), null, "Menü URL'si (dropdown'lar için opsiyonel)", "Menü URL'si", 1, "Menü URL'sini girin", 3, 0, null, null },
                    { 6, new DateTime(2024, 10, 25, 10, 0, 0, 0, DateTimeKind.Unspecified), null, "Menu URL (optional for dropdowns)", "Menu URL", 2, "Enter menu URL", 3, 0, null, null },
                    { 47, new DateTime(2024, 10, 25, 10, 0, 0, 0, DateTimeKind.Unspecified), null, "Hizmetler menü etiketi", "Menü Etiketi", 1, "Menü etiketini girin", 24, 0, null, null },
                    { 48, new DateTime(2024, 10, 25, 10, 0, 0, 0, DateTimeKind.Unspecified), null, "Services menu label", "Menu Label", 2, "Enter menu label", 24, 0, null, null },
                    { 49, new DateTime(2024, 10, 25, 10, 0, 0, 0, DateTimeKind.Unspecified), null, "Hizmetler menü türü", "Menü Tipi", 1, "Menü tipini girin", 25, 0, null, null },
                    { 50, new DateTime(2024, 10, 25, 10, 0, 0, 0, DateTimeKind.Unspecified), null, "Services menu type", "Menu Type", 2, "Enter menu type", 25, 0, null, null },
                    { 83, new DateTime(2024, 10, 25, 10, 0, 0, 0, DateTimeKind.Unspecified), null, "Çözümler menü türü", "Menü Tipi", 1, "Menü tipini girin", 42, 0, null, null },
                    { 84, new DateTime(2024, 10, 25, 10, 0, 0, 0, DateTimeKind.Unspecified), null, "Solutions menu type", "Menu Type", 2, "Enter menu type", 42, 0, null, null },
                    { 85, new DateTime(2024, 10, 25, 10, 0, 0, 0, DateTimeKind.Unspecified), null, "Yazılım çözümleri kategori etiketi", "Kategori Etiketi", 1, "Kategori etiketini girin", 43, 0, null, null },
                    { 86, new DateTime(2024, 10, 25, 10, 0, 0, 0, DateTimeKind.Unspecified), null, "Software solutions category label", "Category Label", 2, "Enter category label", 43, 0, null, null },
                    { 91, new DateTime(2024, 10, 25, 10, 0, 0, 0, DateTimeKind.Unspecified), null, "Blog menü türü", "Menü Tipi", 1, "Menü tipini girin", 46, 0, null, null },
                    { 92, new DateTime(2024, 10, 25, 10, 0, 0, 0, DateTimeKind.Unspecified), null, "Blog menu type", "Menu Type", 2, "Enter menu type", 46, 0, null, null },
                    { 93, new DateTime(2024, 10, 25, 10, 0, 0, 0, DateTimeKind.Unspecified), null, "Blog açıklama başlığı", "Açıklama Başlığı", 1, "Açıklama başlığını girin", 47, 0, null, null },
                    { 94, new DateTime(2024, 10, 25, 10, 0, 0, 0, DateTimeKind.Unspecified), null, "Blog description title", "Description Title", 2, "Enter description title", 47, 0, null, null },
                    { 111, new DateTime(2024, 10, 25, 10, 0, 0, 0, DateTimeKind.Unspecified), null, "Kariyer link URL'si", "Link URL'si", 1, "Link URL'sini girin", 56, 0, null, null },
                    { 112, new DateTime(2024, 10, 25, 10, 0, 0, 0, DateTimeKind.Unspecified), null, "Careers link URL", "Link URL", 2, "Enter link URL", 56, 0, null, null },
                    { 113, new DateTime(2024, 10, 25, 10, 0, 0, 0, DateTimeKind.Unspecified), null, "Veri merkezi link etiketi", "Link Etiketi", 1, "Link etiketini girin", 57, 0, null, null },
                    { 114, new DateTime(2024, 10, 25, 10, 0, 0, 0, DateTimeKind.Unspecified), null, "Data center link label", "Link Label", 2, "Enter link label", 57, 0, null, null },
                    { 115, new DateTime(2024, 10, 25, 10, 0, 0, 0, DateTimeKind.Unspecified), null, "Veri merkezi link URL'si", "Link URL'si", 1, "Link URL'sini girin", 58, 0, null, null },
                    { 116, new DateTime(2024, 10, 25, 10, 0, 0, 0, DateTimeKind.Unspecified), null, "Data center link URL", "Link URL", 2, "Enter link URL", 58, 0, null, null },
                    { 117, new DateTime(2024, 10, 25, 10, 0, 0, 0, DateTimeKind.Unspecified), null, "Sistem durumunu göster", "Durum Göster", 1, "Durum gösterimini ayarla", 59, 0, null, null },
                    { 118, new DateTime(2024, 10, 25, 10, 0, 0, 0, DateTimeKind.Unspecified), null, "Show system status", "Show Status", 2, "Set status display", 59, 0, null, null },
                    { 119, new DateTime(2024, 10, 25, 10, 0, 0, 0, DateTimeKind.Unspecified), null, "Sistem durumu", "Durum", 1, "Durumu girin", 60, 0, null, null },
                    { 120, new DateTime(2024, 10, 25, 10, 0, 0, 0, DateTimeKind.Unspecified), null, "System status", "Status", 2, "Enter status", 60, 0, null, null },
                    { 121, new DateTime(2024, 10, 25, 10, 0, 0, 0, DateTimeKind.Unspecified), null, "Referanslar link etiketi", "Link Etiketi", 1, "Link etiketini girin", 61, 0, null, null },
                    { 122, new DateTime(2024, 10, 25, 10, 0, 0, 0, DateTimeKind.Unspecified), null, "References link label", "Link Label", 2, "Enter link label", 61, 0, null, null },
                    { 123, new DateTime(2024, 10, 25, 10, 0, 0, 0, DateTimeKind.Unspecified), null, "Referanslar link URL'si", "Link URL'si", 1, "Link URL'sini girin", 62, 0, null, null },
                    { 124, new DateTime(2024, 10, 25, 10, 0, 0, 0, DateTimeKind.Unspecified), null, "References link URL", "Link URL", 2, "Enter link URL", 62, 0, null, null },
                    { 125, new DateTime(2024, 10, 25, 10, 0, 0, 0, DateTimeKind.Unspecified), null, "İletişim menü etiketi", "Menü Etiketi", 1, "Menü etiketini girin", 63, 0, null, null },
                    { 126, new DateTime(2024, 10, 25, 10, 0, 0, 0, DateTimeKind.Unspecified), null, "Contact menu label", "Menu Label", 2, "Enter menu label", 63, 0, null, null },
                    { 127, new DateTime(2024, 10, 25, 10, 0, 0, 0, DateTimeKind.Unspecified), null, "İletişim menü türü", "Menü Tipi", 1, "Menü tipini girin", 64, 0, null, null },
                    { 128, new DateTime(2024, 10, 25, 10, 0, 0, 0, DateTimeKind.Unspecified), null, "Contact menu type", "Menu Type", 2, "Enter menu type", 64, 0, null, null },
                    { 129, new DateTime(2024, 10, 25, 10, 0, 0, 0, DateTimeKind.Unspecified), null, "E-posta iletişim etiketi", "İletişim Etiketi", 1, "İletişim etiketini girin", 65, 0, null, null },
                    { 130, new DateTime(2024, 10, 25, 10, 0, 0, 0, DateTimeKind.Unspecified), null, "Email contact label", "Contact Label", 2, "Enter contact label", 65, 0, null, null }
                });

            migrationBuilder.InsertData(
                table: "SectionItemFields",
                columns: new[] { "Id", "AcceptedFileTypes", "CreatedAt", "CreatedBy", "DefaultValue", "FieldKey", "FieldName", "IsTranslatable", "MaxFileSize", "MaxLength", "OptionsJson", "Placeholder", "Required", "SectionItemId", "ShowInUI", "SortOrder", "Status", "Type", "UpdatedAt", "UpdatedBy" },
                values: new object[,]
                {
                    { 4, null, new DateTime(2024, 10, 25, 10, 0, 0, 0, DateTimeKind.Unspecified), null, null, "title", "Description Title", true, null, 200, null, "Enter description title", true, 2, true, 1, 0, 1, null, null },
                    { 5, null, new DateTime(2024, 10, 25, 10, 0, 0, 0, DateTimeKind.Unspecified), null, null, "text", "Description Text", true, null, 500, null, "Enter description text", true, 2, true, 2, 0, 2, null, null },
                    { 6, null, new DateTime(2024, 10, 25, 10, 0, 0, 0, DateTimeKind.Unspecified), null, null, "linkText", "Link Text", true, null, 50, null, "Enter link text", false, 2, true, 3, 0, 1, null, null },
                    { 7, null, new DateTime(2024, 10, 25, 10, 0, 0, 0, DateTimeKind.Unspecified), null, "#", "linkUrl", "Link URL", false, null, null, null, "Enter link URL", false, 2, true, 4, 0, 13, null, null },
                    { 8, null, new DateTime(2024, 10, 25, 10, 0, 0, 0, DateTimeKind.Unspecified), null, null, "title", "Section Title", true, null, 100, null, "Enter section title", true, 3, true, 1, 0, 1, null, null },
                    { 17, null, new DateTime(2024, 10, 25, 10, 0, 0, 0, DateTimeKind.Unspecified), null, null, "title", "Section Title", true, null, 100, null, "Enter section title", true, 8, true, 1, 0, 1, null, null },
                    { 26, null, new DateTime(2024, 10, 25, 10, 0, 0, 0, DateTimeKind.Unspecified), null, null, "label", "Tab Label", true, null, 100, null, "Enter tab label", true, 13, true, 1, 0, 1, null, null },
                    { 27, null, new DateTime(2024, 10, 25, 10, 0, 0, 0, DateTimeKind.Unspecified), null, "fas fa-server", "icon", "Tab Icon", false, null, null, null, "Enter icon class", false, 13, true, 2, 0, 1, null, null },
                    { 28, null, new DateTime(2024, 10, 25, 10, 0, 0, 0, DateTimeKind.Unspecified), null, null, "label", "Tab Label", true, null, 100, null, "Enter tab label", true, 14, true, 1, 0, 1, null, null },
                    { 29, null, new DateTime(2024, 10, 25, 10, 0, 0, 0, DateTimeKind.Unspecified), null, "fas fa-cloud", "icon", "Tab Icon", false, null, null, null, "Enter icon class", false, 14, true, 2, 0, 1, null, null },
                    { 30, null, new DateTime(2024, 10, 25, 10, 0, 0, 0, DateTimeKind.Unspecified), null, null, "label", "Tab Label", true, null, 100, null, "Enter tab label", true, 15, true, 1, 0, 1, null, null },
                    { 31, null, new DateTime(2024, 10, 25, 10, 0, 0, 0, DateTimeKind.Unspecified), null, "fas fa-shield-alt", "icon", "Tab Icon", false, null, null, null, "Enter icon class", false, 15, true, 2, 0, 1, null, null },
                    { 32, null, new DateTime(2024, 10, 25, 10, 0, 0, 0, DateTimeKind.Unspecified), null, null, "label", "Tab Label", true, null, 100, null, "Enter tab label", true, 16, true, 1, 0, 1, null, null },
                    { 33, null, new DateTime(2024, 10, 25, 10, 0, 0, 0, DateTimeKind.Unspecified), null, "fas fa-database", "icon", "Tab Icon", false, null, null, null, "Enter icon class", false, 16, true, 2, 0, 1, null, null },
                    { 34, null, new DateTime(2024, 10, 25, 10, 0, 0, 0, DateTimeKind.Unspecified), null, null, "label", "Tab Label", true, null, 100, null, "Enter tab label", true, 17, true, 1, 0, 1, null, null },
                    { 35, null, new DateTime(2024, 10, 25, 10, 0, 0, 0, DateTimeKind.Unspecified), null, "fas fa-chart-line", "icon", "Tab Icon", false, null, null, null, "Enter icon class", false, 17, true, 2, 0, 1, null, null },
                    { 36, null, new DateTime(2024, 10, 25, 10, 0, 0, 0, DateTimeKind.Unspecified), null, null, "label", "Tab Label", true, null, 100, null, "Enter tab label", true, 18, true, 1, 0, 1, null, null },
                    { 37, null, new DateTime(2024, 10, 25, 10, 0, 0, 0, DateTimeKind.Unspecified), null, "fas fa-crown", "icon", "Tab Icon", false, null, null, null, "Enter icon class", false, 18, true, 2, 0, 1, null, null },
                    { 38, null, new DateTime(2024, 10, 25, 10, 0, 0, 0, DateTimeKind.Unspecified), null, "true", "isPremium", "Is Premium", false, null, null, null, null, false, 18, true, 3, 0, 10, null, null },
                    { 44, null, new DateTime(2024, 10, 25, 10, 0, 0, 0, DateTimeKind.Unspecified), null, null, "label", "Category Label", true, null, 100, null, "Enter category label", true, 24, true, 1, 0, 1, null, null },
                    { 45, null, new DateTime(2024, 10, 25, 10, 0, 0, 0, DateTimeKind.Unspecified), null, "fas fa-code", "icon", "Category Icon", false, null, null, null, "Enter icon class", false, 24, true, 2, 0, 1, null, null },
                    { 48, null, new DateTime(2024, 10, 25, 10, 0, 0, 0, DateTimeKind.Unspecified), null, null, "title", "Description Title", true, null, 200, null, "Enter description title", true, 34, true, 1, 0, 1, null, null },
                    { 49, null, new DateTime(2024, 10, 25, 10, 0, 0, 0, DateTimeKind.Unspecified), null, null, "text", "Description Text", true, null, 500, null, "Enter description text", true, 34, true, 2, 0, 2, null, null },
                    { 50, null, new DateTime(2024, 10, 25, 10, 0, 0, 0, DateTimeKind.Unspecified), null, null, "linkText", "Link Text", true, null, 50, null, "Enter link text", false, 34, true, 3, 0, 1, null, null },
                    { 51, null, new DateTime(2024, 10, 25, 10, 0, 0, 0, DateTimeKind.Unspecified), null, "#", "linkUrl", "Link URL", false, null, null, null, "Enter link URL", false, 34, true, 4, 0, 13, null, null },
                    { 66, null, new DateTime(2024, 10, 25, 10, 0, 0, 0, DateTimeKind.Unspecified), null, null, "label", "Contact Label", true, null, 100, null, "Enter contact label", true, 47, true, 1, 0, 1, null, null },
                    { 67, null, new DateTime(2024, 10, 25, 10, 0, 0, 0, DateTimeKind.Unspecified), null, null, "value", "Contact Value", true, null, 200, null, "Enter contact value", true, 47, true, 2, 0, 1, null, null },
                    { 68, null, new DateTime(2024, 10, 25, 10, 0, 0, 0, DateTimeKind.Unspecified), null, "email", "type", "Contact Type", false, null, null, null, "Enter contact type", false, 47, true, 3, 0, 1, null, null },
                    { 69, null, new DateTime(2024, 10, 25, 10, 0, 0, 0, DateTimeKind.Unspecified), null, "fas fa-envelope", "icon", "Contact Icon", false, null, null, null, "Enter icon class", false, 47, true, 4, 0, 1, null, null },
                    { 70, null, new DateTime(2024, 10, 25, 10, 0, 0, 0, DateTimeKind.Unspecified), null, null, "label", "Contact Label", true, null, 100, null, "Enter contact label", true, 48, true, 1, 0, 1, null, null },
                    { 71, null, new DateTime(2024, 10, 25, 10, 0, 0, 0, DateTimeKind.Unspecified), null, null, "value", "Contact Value", true, null, 200, null, "Enter contact value", true, 48, true, 2, 0, 1, null, null },
                    { 72, null, new DateTime(2024, 10, 25, 10, 0, 0, 0, DateTimeKind.Unspecified), null, "address", "type", "Contact Type", false, null, null, null, "Enter contact type", false, 48, true, 3, 0, 1, null, null },
                    { 73, null, new DateTime(2024, 10, 25, 10, 0, 0, 0, DateTimeKind.Unspecified), null, "fas fa-map-marker-alt", "icon", "Contact Icon", false, null, null, null, "Enter icon class", false, 48, true, 4, 0, 1, null, null }
                });

            migrationBuilder.InsertData(
                table: "SectionItemTranslations",
                columns: new[] { "Id", "CreatedAt", "CreatedBy", "Description", "LanguageId", "SectionItemId", "Status", "Title", "UpdatedAt", "UpdatedBy" },
                values: new object[,]
                {
                    { 3, new DateTime(2024, 1, 1, 10, 0, 0, 0, DateTimeKind.Unspecified), null, "Binlerce ürün arasından size en uygun olanları bulun. Hızlı teslimat, güvenli ödeme ve mükemmel müşteri hizmetiyle yanınızdayız.", 1, 2, 1, "Kalite ve Güvenin Adresi", null, null },
                    { 4, new DateTime(2024, 1, 1, 10, 0, 0, 0, DateTimeKind.Unspecified), null, "Find the most suitable products for you among thousands of products. We are with you with fast delivery, secure payment and excellent customer service.", 2, 2, 1, "Address of Quality and Trust", null, null },
                    { 5, new DateTime(2024, 1, 1, 10, 0, 0, 0, DateTimeKind.Unspecified), null, "Tüm ürünleri görüntülemek için tıklayın", 1, 3, 1, "Ürünleri Keşfet", null, null },
                    { 6, new DateTime(2024, 1, 1, 10, 0, 0, 0, DateTimeKind.Unspecified), null, "Click to view all products", 2, 3, 1, "Explore Products", null, null }
                });

            migrationBuilder.InsertData(
                table: "SectionItems",
                columns: new[] { "Id", "AllowRemove", "AllowReorder", "CreatedAt", "CreatedBy", "Description", "IconClass", "Key", "ParentSectionItemId", "SortOrder", "Status", "TemplateId", "Title", "Type", "UpdatedAt", "UpdatedBy" },
                values: new object[,]
                {
                    { 4, true, true, new DateTime(2024, 10, 25, 10, 0, 0, 0, DateTimeKind.Unspecified), null, null, "fas fa-bullseye", "menus.about.quickLinks.links.missionVision", 3, 1, 1, 2, "Mission & Vision", 17, null, null },
                    { 5, true, true, new DateTime(2024, 10, 25, 10, 0, 0, 0, DateTimeKind.Unspecified), null, null, "fas fa-users", "menus.about.quickLinks.links.team", 3, 2, 1, 2, "Team", 17, null, null },
                    { 6, true, true, new DateTime(2024, 10, 25, 10, 0, 0, 0, DateTimeKind.Unspecified), null, null, "fas fa-briefcase", "menus.about.quickLinks.links.careers", 3, 3, 1, 2, "Careers", 17, null, null },
                    { 7, true, true, new DateTime(2024, 10, 25, 10, 0, 0, 0, DateTimeKind.Unspecified), null, null, "fas fa-newspaper", "menus.about.quickLinks.links.press", 3, 4, 1, 2, "Press", 17, null, null },
                    { 9, true, true, new DateTime(2024, 10, 25, 10, 0, 0, 0, DateTimeKind.Unspecified), null, "Years of experience", "fas fa-clock", "menus.about.features.items.experience", 8, 1, 1, 2, "Experience", 12, null, null },
                    { 10, true, true, new DateTime(2024, 10, 25, 10, 0, 0, 0, DateTimeKind.Unspecified), null, "Professional certified team", "fas fa-certificate", "menus.about.features.items.certifiedTeam", 8, 2, 1, 2, "Certified Team", 12, null, null },
                    { 11, true, true, new DateTime(2024, 10, 25, 10, 0, 0, 0, DateTimeKind.Unspecified), null, "Successful projects completed", "fas fa-project-diagram", "menus.about.features.items.projects", 8, 3, 1, 2, "Projects", 12, null, null },
                    { 19, true, true, new DateTime(2024, 10, 25, 10, 0, 0, 0, DateTimeKind.Unspecified), null, "Multi-cloud management services", "fas fa-cloud", "menus.services.tabContent.managed.multiCloud", 13, 1, 1, 3, "Multi-Cloud", 5, null, null },
                    { 20, true, true, new DateTime(2024, 10, 25, 10, 0, 0, 0, DateTimeKind.Unspecified), null, "Hybrid cloud solutions", "fas fa-sync", "menus.services.tabContent.managed.hybridCloud", 13, 2, 1, 3, "Hybrid Cloud", 5, null, null },
                    { 21, true, true, new DateTime(2024, 10, 25, 10, 0, 0, 0, DateTimeKind.Unspecified), null, "24/7 system monitoring", "fas fa-desktop", "menus.services.tabContent.managed.monitoring", 13, 3, 1, 3, "Monitoring", 5, null, null },
                    { 22, true, true, new DateTime(2024, 10, 25, 10, 0, 0, 0, DateTimeKind.Unspecified), null, "Container orchestration", "fas fa-cube", "menus.services.tabContent.managed.container", 13, 4, 1, 3, "Container", 5, null, null },
                    { 29, true, true, new DateTime(2024, 10, 25, 10, 0, 0, 0, DateTimeKind.Unspecified), null, "Tailored software solutions", "fas fa-wrench", "menus.solutions.categoryContent.software.items.custom", 24, 1, 1, 4, "Custom Software", 5, null, null },
                    { 30, true, true, new DateTime(2024, 10, 25, 10, 0, 0, 0, DateTimeKind.Unspecified), null, "Modern web applications", "fas fa-globe", "menus.solutions.categoryContent.software.items.web", 24, 2, 1, 4, "Web Applications", 5, null, null },
                    { 31, true, true, new DateTime(2024, 10, 25, 10, 0, 0, 0, DateTimeKind.Unspecified), null, "iOS and Android applications", "fas fa-mobile-alt", "menus.solutions.categoryContent.software.items.mobile", 24, 3, 1, 4, "Mobile Apps", 5, null, null },
                    { 32, true, true, new DateTime(2024, 10, 25, 10, 0, 0, 0, DateTimeKind.Unspecified), null, "RESTful API services", "fas fa-plug", "menus.solutions.categoryContent.software.items.api", 24, 4, 1, 4, "API Development", 5, null, null },
                    { 36, true, true, new DateTime(2024, 10, 25, 10, 0, 0, 0, DateTimeKind.Unspecified), null, null, "fas fa-cloud", "menus.blog.categories.links.cloudTrends", 35, 1, 1, 2, "Cloud Trends", 17, null, null },
                    { 37, true, true, new DateTime(2024, 10, 25, 10, 0, 0, 0, DateTimeKind.Unspecified), null, null, "fas fa-code-branch", "menus.blog.categories.links.devopsPractices", 35, 2, 1, 2, "DevOps Practices", 17, null, null },
                    { 38, true, true, new DateTime(2024, 10, 25, 10, 0, 0, 0, DateTimeKind.Unspecified), null, null, "fas fa-lightbulb", "menus.blog.categories.links.softwareInnovation", 35, 3, 1, 2, "Software Innovation", 17, null, null },
                    { 39, true, true, new DateTime(2024, 10, 25, 10, 0, 0, 0, DateTimeKind.Unspecified), null, null, "fas fa-user-tie", "menus.blog.categories.links.techLeadership", 35, 4, 1, 2, "Tech Leadership", 17, null, null },
                    { 41, true, true, new DateTime(2024, 10, 25, 10, 0, 0, 0, DateTimeKind.Unspecified), null, "Learn about Kubernetes best practices", "fas fa-cube", "menus.blog.featuredPosts.posts.kubernetes", 40, 1, 1, 2, "Kubernetes Best Practices", 7, null, null },
                    { 42, true, true, new DateTime(2024, 10, 25, 10, 0, 0, 0, DateTimeKind.Unspecified), null, "Complete guide to Azure migration", "fas fa-cloud", "menus.blog.featuredPosts.posts.azure", 40, 2, 1, 2, "Azure Migration Guide", 7, null, null }
                });

            migrationBuilder.InsertData(
                table: "SectionItemFieldTranslations",
                columns: new[] { "Id", "CreatedAt", "CreatedBy", "Description", "Label", "LanguageId", "Placeholder", "SectionItemFieldId", "Status", "UpdatedAt", "UpdatedBy" },
                values: new object[,]
                {
                    { 7, new DateTime(2024, 10, 25, 10, 0, 0, 0, DateTimeKind.Unspecified), null, "Açıklama bölümü başlığı", "Açıklama Başlığı", 1, "Açıklama başlığını girin", 4, 0, null, null },
                    { 8, new DateTime(2024, 10, 25, 10, 0, 0, 0, DateTimeKind.Unspecified), null, "Description section title", "Description Title", 2, "Enter description title", 4, 0, null, null },
                    { 9, new DateTime(2024, 10, 25, 10, 0, 0, 0, DateTimeKind.Unspecified), null, "Açıklama içeriği", "Açıklama Metni", 1, "Açıklama metnini girin", 5, 0, null, null },
                    { 10, new DateTime(2024, 10, 25, 10, 0, 0, 0, DateTimeKind.Unspecified), null, "Description content", "Description Text", 2, "Enter description text", 5, 0, null, null },
                    { 11, new DateTime(2024, 10, 25, 10, 0, 0, 0, DateTimeKind.Unspecified), null, "Link buton metni", "Link Metni", 1, "Link metnini girin", 6, 0, null, null },
                    { 12, new DateTime(2024, 10, 25, 10, 0, 0, 0, DateTimeKind.Unspecified), null, "Link button text", "Link Text", 2, "Enter link text", 6, 0, null, null },
                    { 13, new DateTime(2024, 10, 25, 10, 0, 0, 0, DateTimeKind.Unspecified), null, "Link hedef URL'si", "Link URL'si", 1, "Link URL'sini girin", 7, 0, null, null },
                    { 14, new DateTime(2024, 10, 25, 10, 0, 0, 0, DateTimeKind.Unspecified), null, "Link target URL", "Link URL", 2, "Enter link URL", 7, 0, null, null },
                    { 15, new DateTime(2024, 10, 25, 10, 0, 0, 0, DateTimeKind.Unspecified), null, "Hızlı linkler bölümü başlığı", "Bölüm Başlığı", 1, "Bölüm başlığını girin", 8, 0, null, null },
                    { 16, new DateTime(2024, 10, 25, 10, 0, 0, 0, DateTimeKind.Unspecified), null, "Quick links section title", "Section Title", 2, "Enter section title", 8, 0, null, null },
                    { 33, new DateTime(2024, 10, 25, 10, 0, 0, 0, DateTimeKind.Unspecified), null, "Özellikler bölümü başlığı", "Bölüm Başlığı", 1, "Bölüm başlığını girin", 17, 0, null, null },
                    { 34, new DateTime(2024, 10, 25, 10, 0, 0, 0, DateTimeKind.Unspecified), null, "Features section title", "Section Title", 2, "Enter section title", 17, 0, null, null },
                    { 51, new DateTime(2024, 10, 25, 10, 0, 0, 0, DateTimeKind.Unspecified), null, "Yönetilen hizmetler sekme etiketi", "Sekme Etiketi", 1, "Sekme etiketini girin", 26, 0, null, null },
                    { 52, new DateTime(2024, 10, 25, 10, 0, 0, 0, DateTimeKind.Unspecified), null, "Managed services tab label", "Tab Label", 2, "Enter tab label", 26, 0, null, null },
                    { 53, new DateTime(2024, 10, 25, 10, 0, 0, 0, DateTimeKind.Unspecified), null, "Yönetilen hizmetler sekme ikonu", "Sekme İkonu", 1, "İkon sınıfını girin", 27, 0, null, null },
                    { 54, new DateTime(2024, 10, 25, 10, 0, 0, 0, DateTimeKind.Unspecified), null, "Managed services tab icon", "Tab Icon", 2, "Enter icon class", 27, 0, null, null },
                    { 55, new DateTime(2024, 10, 25, 10, 0, 0, 0, DateTimeKind.Unspecified), null, "Bulut hizmetleri sekme etiketi", "Sekme Etiketi", 1, "Sekme etiketini girin", 28, 0, null, null },
                    { 56, new DateTime(2024, 10, 25, 10, 0, 0, 0, DateTimeKind.Unspecified), null, "Cloud services tab label", "Tab Label", 2, "Enter tab label", 28, 0, null, null },
                    { 57, new DateTime(2024, 10, 25, 10, 0, 0, 0, DateTimeKind.Unspecified), null, "Bulut hizmetleri sekme ikonu", "Sekme İkonu", 1, "İkon sınıfını girin", 29, 0, null, null },
                    { 58, new DateTime(2024, 10, 25, 10, 0, 0, 0, DateTimeKind.Unspecified), null, "Cloud services tab icon", "Tab Icon", 2, "Enter icon class", 29, 0, null, null },
                    { 59, new DateTime(2024, 10, 25, 10, 0, 0, 0, DateTimeKind.Unspecified), null, "Güvenlik hizmetleri sekme etiketi", "Sekme Etiketi", 1, "Sekme etiketini girin", 30, 0, null, null },
                    { 60, new DateTime(2024, 10, 25, 10, 0, 0, 0, DateTimeKind.Unspecified), null, "Security services tab label", "Tab Label", 2, "Enter tab label", 30, 0, null, null },
                    { 61, new DateTime(2024, 10, 25, 10, 0, 0, 0, DateTimeKind.Unspecified), null, "Güvenlik hizmetleri sekme ikonu", "Sekme İkonu", 1, "İkon sınıfını girin", 31, 0, null, null },
                    { 62, new DateTime(2024, 10, 25, 10, 0, 0, 0, DateTimeKind.Unspecified), null, "Security services tab icon", "Tab Icon", 2, "Enter icon class", 31, 0, null, null },
                    { 63, new DateTime(2024, 10, 25, 10, 0, 0, 0, DateTimeKind.Unspecified), null, "Veritabanı hizmetleri sekme etiketi", "Sekme Etiketi", 1, "Sekme etiketini girin", 32, 0, null, null },
                    { 64, new DateTime(2024, 10, 25, 10, 0, 0, 0, DateTimeKind.Unspecified), null, "Database services tab label", "Tab Label", 2, "Enter tab label", 32, 0, null, null },
                    { 65, new DateTime(2024, 10, 25, 10, 0, 0, 0, DateTimeKind.Unspecified), null, "Veritabanı hizmetleri sekme ikonu", "Sekme İkonu", 1, "İkon sınıfını girin", 33, 0, null, null },
                    { 66, new DateTime(2024, 10, 25, 10, 0, 0, 0, DateTimeKind.Unspecified), null, "Database services tab icon", "Tab Icon", 2, "Enter icon class", 33, 0, null, null },
                    { 67, new DateTime(2024, 10, 25, 10, 0, 0, 0, DateTimeKind.Unspecified), null, "İzleme hizmetleri sekme etiketi", "Sekme Etiketi", 1, "Sekme etiketini girin", 34, 0, null, null },
                    { 68, new DateTime(2024, 10, 25, 10, 0, 0, 0, DateTimeKind.Unspecified), null, "Monitoring services tab label", "Tab Label", 2, "Enter tab label", 34, 0, null, null },
                    { 69, new DateTime(2024, 10, 25, 10, 0, 0, 0, DateTimeKind.Unspecified), null, "İzleme hizmetleri sekme ikonu", "Sekme İkonu", 1, "İkon sınıfını girin", 35, 0, null, null },
                    { 70, new DateTime(2024, 10, 25, 10, 0, 0, 0, DateTimeKind.Unspecified), null, "Monitoring services tab icon", "Tab Icon", 2, "Enter icon class", 35, 0, null, null },
                    { 71, new DateTime(2024, 10, 25, 10, 0, 0, 0, DateTimeKind.Unspecified), null, "Premium hizmetler sekme etiketi", "Sekme Etiketi", 1, "Sekme etiketini girin", 36, 0, null, null },
                    { 72, new DateTime(2024, 10, 25, 10, 0, 0, 0, DateTimeKind.Unspecified), null, "Premium services tab label", "Tab Label", 2, "Enter tab label", 36, 0, null, null },
                    { 73, new DateTime(2024, 10, 25, 10, 0, 0, 0, DateTimeKind.Unspecified), null, "Premium hizmetler sekme ikonu", "Sekme İkonu", 1, "İkon sınıfını girin", 37, 0, null, null },
                    { 74, new DateTime(2024, 10, 25, 10, 0, 0, 0, DateTimeKind.Unspecified), null, "Premium services tab icon", "Tab Icon", 2, "Enter icon class", 37, 0, null, null },
                    { 75, new DateTime(2024, 10, 25, 10, 0, 0, 0, DateTimeKind.Unspecified), null, "Multi-cloud hizmet başlığı", "Hizmet Başlığı", 1, "Hizmet başlığını girin", 38, 0, null, null },
                    { 76, new DateTime(2024, 10, 25, 10, 0, 0, 0, DateTimeKind.Unspecified), null, "Multi-cloud service title", "Service Title", 2, "Enter service title", 38, 0, null, null },
                    { 87, new DateTime(2024, 10, 25, 10, 0, 0, 0, DateTimeKind.Unspecified), null, "Yazılım çözümleri kategori ikonu", "Kategori İkonu", 1, "İkon sınıfını girin", 44, 0, null, null },
                    { 88, new DateTime(2024, 10, 25, 10, 0, 0, 0, DateTimeKind.Unspecified), null, "Software solutions category icon", "Category Icon", 2, "Enter icon class", 44, 0, null, null },
                    { 89, new DateTime(2024, 10, 25, 10, 0, 0, 0, DateTimeKind.Unspecified), null, "Blog menü etiketi", "Menü Etiketi", 1, "Menü etiketini girin", 45, 0, null, null },
                    { 90, new DateTime(2024, 10, 25, 10, 0, 0, 0, DateTimeKind.Unspecified), null, "Blog menu label", "Menu Label", 2, "Enter menu label", 45, 0, null, null },
                    { 95, new DateTime(2024, 10, 25, 10, 0, 0, 0, DateTimeKind.Unspecified), null, "Blog açıklama metni", "Açıklama Metni", 1, "Açıklama metnini girin", 48, 0, null, null },
                    { 96, new DateTime(2024, 10, 25, 10, 0, 0, 0, DateTimeKind.Unspecified), null, "Blog description text", "Description Text", 2, "Enter description text", 48, 0, null, null },
                    { 97, new DateTime(2024, 10, 25, 10, 0, 0, 0, DateTimeKind.Unspecified), null, "Blog link metni", "Link Metni", 1, "Link metnini girin", 49, 0, null, null },
                    { 98, new DateTime(2024, 10, 25, 10, 0, 0, 0, DateTimeKind.Unspecified), null, "Blog link text", "Link Text", 2, "Enter link text", 49, 0, null, null },
                    { 99, new DateTime(2024, 10, 25, 10, 0, 0, 0, DateTimeKind.Unspecified), null, "Blog link URL'si", "Link URL'si", 1, "Link URL'sini girin", 50, 0, null, null },
                    { 100, new DateTime(2024, 10, 25, 10, 0, 0, 0, DateTimeKind.Unspecified), null, "Blog link URL", "Link URL", 2, "Enter link URL", 50, 0, null, null },
                    { 101, new DateTime(2024, 10, 25, 10, 0, 0, 0, DateTimeKind.Unspecified), null, "Kubernetes yazı başlığı", "Yazı Başlığı", 1, "Yazı başlığını girin", 51, 0, null, null },
                    { 102, new DateTime(2024, 10, 25, 10, 0, 0, 0, DateTimeKind.Unspecified), null, "Kubernetes post title", "Post Title", 2, "Enter post title", 51, 0, null, null },
                    { 131, new DateTime(2024, 10, 25, 10, 0, 0, 0, DateTimeKind.Unspecified), null, "E-posta iletişim değeri", "İletişim Değeri", 1, "İletişim değerini girin", 66, 0, null, null },
                    { 132, new DateTime(2024, 10, 25, 10, 0, 0, 0, DateTimeKind.Unspecified), null, "Email contact value", "Contact Value", 2, "Enter contact value", 66, 0, null, null },
                    { 133, new DateTime(2024, 10, 25, 10, 0, 0, 0, DateTimeKind.Unspecified), null, "E-posta iletişim tipi", "İletişim Tipi", 1, "İletişim tipini girin", 67, 0, null, null },
                    { 134, new DateTime(2024, 10, 25, 10, 0, 0, 0, DateTimeKind.Unspecified), null, "Email contact type", "Contact Type", 2, "Enter contact type", 67, 0, null, null },
                    { 135, new DateTime(2024, 10, 25, 10, 0, 0, 0, DateTimeKind.Unspecified), null, "E-posta iletişim ikonu", "İletişim İkonu", 1, "İkon sınıfını girin", 68, 0, null, null },
                    { 136, new DateTime(2024, 10, 25, 10, 0, 0, 0, DateTimeKind.Unspecified), null, "Email contact icon", "Contact Icon", 2, "Enter icon class", 68, 0, null, null },
                    { 137, new DateTime(2024, 10, 25, 10, 0, 0, 0, DateTimeKind.Unspecified), null, "Adres iletişim etiketi", "İletişim Etiketi", 1, "İletişim etiketini girin", 69, 0, null, null },
                    { 138, new DateTime(2024, 10, 25, 10, 0, 0, 0, DateTimeKind.Unspecified), null, "Address contact label", "Contact Label", 2, "Enter contact label", 69, 0, null, null },
                    { 139, new DateTime(2024, 10, 25, 10, 0, 0, 0, DateTimeKind.Unspecified), null, "Adres iletişim değeri", "İletişim Değeri", 1, "İletişim değerini girin", 70, 0, null, null },
                    { 140, new DateTime(2024, 10, 25, 10, 0, 0, 0, DateTimeKind.Unspecified), null, "Address contact value", "Contact Value", 2, "Enter contact value", 70, 0, null, null },
                    { 141, new DateTime(2024, 10, 25, 10, 0, 0, 0, DateTimeKind.Unspecified), null, "Adres iletişim tipi", "İletişim Tipi", 1, "İletişim tipini girin", 71, 0, null, null },
                    { 142, new DateTime(2024, 10, 25, 10, 0, 0, 0, DateTimeKind.Unspecified), null, "Address contact type", "Contact Type", 2, "Enter contact type", 71, 0, null, null },
                    { 143, new DateTime(2024, 10, 25, 10, 0, 0, 0, DateTimeKind.Unspecified), null, "Adres iletişim ikonu", "İletişim İkonu", 1, "İkon sınıfını girin", 72, 0, null, null },
                    { 144, new DateTime(2024, 10, 25, 10, 0, 0, 0, DateTimeKind.Unspecified), null, "Address contact icon", "Contact Icon", 2, "Enter icon class", 72, 0, null, null }
                });

            migrationBuilder.InsertData(
                table: "SectionItemFields",
                columns: new[] { "Id", "AcceptedFileTypes", "CreatedAt", "CreatedBy", "DefaultValue", "FieldKey", "FieldName", "IsTranslatable", "MaxFileSize", "MaxLength", "OptionsJson", "Placeholder", "Required", "SectionItemId", "ShowInUI", "SortOrder", "Status", "Type", "UpdatedAt", "UpdatedBy" },
                values: new object[,]
                {
                    { 9, null, new DateTime(2024, 10, 25, 10, 0, 0, 0, DateTimeKind.Unspecified), null, null, "text", "Link Text", true, null, 100, null, "Enter link text", true, 4, true, 1, 0, 1, null, null },
                    { 10, null, new DateTime(2024, 10, 25, 10, 0, 0, 0, DateTimeKind.Unspecified), null, null, "url", "Link URL", false, null, null, null, "Enter link URL", true, 4, true, 2, 0, 13, null, null },
                    { 11, null, new DateTime(2024, 10, 25, 10, 0, 0, 0, DateTimeKind.Unspecified), null, null, "text", "Link Text", true, null, 100, null, "Enter link text", true, 5, true, 1, 0, 1, null, null },
                    { 12, null, new DateTime(2024, 10, 25, 10, 0, 0, 0, DateTimeKind.Unspecified), null, null, "url", "Link URL", false, null, null, null, "Enter link URL", true, 5, true, 2, 0, 13, null, null },
                    { 13, null, new DateTime(2024, 10, 25, 10, 0, 0, 0, DateTimeKind.Unspecified), null, null, "text", "Link Text", true, null, 100, null, "Enter link text", true, 6, true, 1, 0, 1, null, null },
                    { 14, null, new DateTime(2024, 10, 25, 10, 0, 0, 0, DateTimeKind.Unspecified), null, null, "url", "Link URL", false, null, null, null, "Enter link URL", true, 6, true, 2, 0, 13, null, null },
                    { 15, null, new DateTime(2024, 10, 25, 10, 0, 0, 0, DateTimeKind.Unspecified), null, null, "text", "Link Text", true, null, 100, null, "Enter link text", true, 7, true, 1, 0, 1, null, null },
                    { 16, null, new DateTime(2024, 10, 25, 10, 0, 0, 0, DateTimeKind.Unspecified), null, null, "url", "Link URL", false, null, null, null, "Enter link URL", true, 7, true, 2, 0, 13, null, null },
                    { 18, null, new DateTime(2024, 10, 25, 10, 0, 0, 0, DateTimeKind.Unspecified), null, null, "title", "Feature Title", true, null, 100, null, "Enter feature title", true, 9, true, 1, 0, 1, null, null },
                    { 19, null, new DateTime(2024, 10, 25, 10, 0, 0, 0, DateTimeKind.Unspecified), null, null, "description", "Feature Description", true, null, 300, null, "Enter feature description", true, 9, true, 2, 0, 2, null, null },
                    { 20, null, new DateTime(2024, 10, 25, 10, 0, 0, 0, DateTimeKind.Unspecified), null, null, "title", "Feature Title", true, null, 100, null, "Enter feature title", true, 10, true, 1, 0, 1, null, null },
                    { 21, null, new DateTime(2024, 10, 25, 10, 0, 0, 0, DateTimeKind.Unspecified), null, null, "description", "Feature Description", true, null, 300, null, "Enter feature description", true, 10, true, 2, 0, 2, null, null },
                    { 22, null, new DateTime(2024, 10, 25, 10, 0, 0, 0, DateTimeKind.Unspecified), null, null, "title", "Feature Title", true, null, 100, null, "Enter feature title", true, 11, true, 1, 0, 1, null, null },
                    { 23, null, new DateTime(2024, 10, 25, 10, 0, 0, 0, DateTimeKind.Unspecified), null, null, "description", "Feature Description", true, null, 300, null, "Enter feature description", true, 11, true, 2, 0, 2, null, null },
                    { 39, null, new DateTime(2024, 10, 25, 10, 0, 0, 0, DateTimeKind.Unspecified), null, null, "title", "Service Title", true, null, 100, null, "Enter service title", true, 19, true, 1, 0, 1, null, null },
                    { 40, null, new DateTime(2024, 10, 25, 10, 0, 0, 0, DateTimeKind.Unspecified), null, null, "description", "Service Description", true, null, 300, null, "Enter service description", true, 19, true, 2, 0, 2, null, null },
                    { 41, null, new DateTime(2024, 10, 25, 10, 0, 0, 0, DateTimeKind.Unspecified), null, "fas fa-cloud", "icon", "Service Icon", false, null, null, null, "Enter icon class", false, 19, true, 3, 0, 1, null, null },
                    { 52, null, new DateTime(2024, 10, 25, 10, 0, 0, 0, DateTimeKind.Unspecified), null, null, "title", "Post Title", true, null, 200, null, "Enter post title", true, 41, true, 1, 0, 1, null, null },
                    { 53, null, new DateTime(2024, 10, 25, 10, 0, 0, 0, DateTimeKind.Unspecified), null, "/api/placeholder/400/300", "image", "Post Image", false, null, null, null, "Enter image URL", false, 41, true, 2, 0, 11, null, null },
                    { 54, null, new DateTime(2024, 10, 25, 10, 0, 0, 0, DateTimeKind.Unspecified), null, null, "date", "Post Date", true, null, null, null, "Enter post date", false, 41, true, 3, 0, 9, null, null },
                    { 55, null, new DateTime(2024, 10, 25, 10, 0, 0, 0, DateTimeKind.Unspecified), null, null, "readTime", "Read Time", true, null, 20, null, "Enter read time", false, 41, true, 4, 0, 1, null, null }
                });

            migrationBuilder.InsertData(
                table: "SectionItemTranslations",
                columns: new[] { "Id", "CreatedAt", "CreatedBy", "Description", "LanguageId", "SectionItemId", "Status", "Title", "UpdatedAt", "UpdatedBy" },
                values: new object[,]
                {
                    { 7, new DateTime(2024, 1, 1, 10, 0, 0, 0, DateTimeKind.Unspecified), null, "Yüksek performanslı, şık tasarımlı laptop", 1, 4, 1, "Premium Laptop", null, null },
                    { 8, new DateTime(2024, 1, 1, 10, 0, 0, 0, DateTimeKind.Unspecified), null, "High performance, stylish design laptop", 2, 4, 1, "Premium Laptop", null, null },
                    { 9, new DateTime(2024, 1, 1, 10, 0, 0, 0, DateTimeKind.Unspecified), null, "Yeni ürünler ve kampanyalardan haberdar olmak için e-posta listemize katılın", 1, 7, 1, "Haberdar Olun", null, null },
                    { 10, new DateTime(2024, 1, 1, 10, 0, 0, 0, DateTimeKind.Unspecified), null, "Join our email list to stay informed about new products and campaigns", 2, 7, 1, "Stay Informed", null, null },
                    { 11, new DateTime(2024, 1, 2, 10, 0, 0, 0, DateTimeKind.Unspecified), null, "En güncel haberler ve makaleler", 1, 9, 1, "Blog Yazıları", null, null },
                    { 12, new DateTime(2024, 1, 2, 10, 0, 0, 0, DateTimeKind.Unspecified), null, "Latest news and articles", 2, 9, 1, "Blog Posts", null, null }
                });

            migrationBuilder.InsertData(
                table: "SectionItemFieldTranslations",
                columns: new[] { "Id", "CreatedAt", "CreatedBy", "Description", "Label", "LanguageId", "Placeholder", "SectionItemFieldId", "Status", "UpdatedAt", "UpdatedBy" },
                values: new object[,]
                {
                    { 17, new DateTime(2024, 10, 25, 10, 0, 0, 0, DateTimeKind.Unspecified), null, "Misyon ve vizyon link metni", "Link Metni", 1, "Link metnini girin", 9, 0, null, null },
                    { 18, new DateTime(2024, 10, 25, 10, 0, 0, 0, DateTimeKind.Unspecified), null, "Mission and vision link text", "Link Text", 2, "Enter link text", 9, 0, null, null },
                    { 19, new DateTime(2024, 10, 25, 10, 0, 0, 0, DateTimeKind.Unspecified), null, "Misyon ve vizyon link URL'si", "Link URL'si", 1, "Link URL'sini girin", 10, 0, null, null },
                    { 20, new DateTime(2024, 10, 25, 10, 0, 0, 0, DateTimeKind.Unspecified), null, "Mission and vision link URL", "Link URL", 2, "Enter link URL", 10, 0, null, null },
                    { 21, new DateTime(2024, 10, 25, 10, 0, 0, 0, DateTimeKind.Unspecified), null, "Takım link metni", "Link Metni", 1, "Link metnini girin", 11, 0, null, null },
                    { 22, new DateTime(2024, 10, 25, 10, 0, 0, 0, DateTimeKind.Unspecified), null, "Team link text", "Link Text", 2, "Enter link text", 11, 0, null, null },
                    { 23, new DateTime(2024, 10, 25, 10, 0, 0, 0, DateTimeKind.Unspecified), null, "Takım link URL'si", "Link URL'si", 1, "Link URL'sini girin", 12, 0, null, null },
                    { 24, new DateTime(2024, 10, 25, 10, 0, 0, 0, DateTimeKind.Unspecified), null, "Team link URL", "Link URL", 2, "Enter link URL", 12, 0, null, null },
                    { 25, new DateTime(2024, 10, 25, 10, 0, 0, 0, DateTimeKind.Unspecified), null, "Kariyer link metni", "Link Metni", 1, "Link metnini girin", 13, 0, null, null },
                    { 26, new DateTime(2024, 10, 25, 10, 0, 0, 0, DateTimeKind.Unspecified), null, "Careers link text", "Link Text", 2, "Enter link text", 13, 0, null, null },
                    { 27, new DateTime(2024, 10, 25, 10, 0, 0, 0, DateTimeKind.Unspecified), null, "Kariyer link URL'si", "Link URL'si", 1, "Link URL'sini girin", 14, 0, null, null },
                    { 28, new DateTime(2024, 10, 25, 10, 0, 0, 0, DateTimeKind.Unspecified), null, "Careers link URL", "Link URL", 2, "Enter link URL", 14, 0, null, null },
                    { 29, new DateTime(2024, 10, 25, 10, 0, 0, 0, DateTimeKind.Unspecified), null, "Basın link metni", "Link Metni", 1, "Link metnini girin", 15, 0, null, null },
                    { 30, new DateTime(2024, 10, 25, 10, 0, 0, 0, DateTimeKind.Unspecified), null, "Press link text", "Link Text", 2, "Enter link text", 15, 0, null, null },
                    { 31, new DateTime(2024, 10, 25, 10, 0, 0, 0, DateTimeKind.Unspecified), null, "Basın link URL'si", "Link URL'si", 1, "Link URL'sini girin", 16, 0, null, null },
                    { 32, new DateTime(2024, 10, 25, 10, 0, 0, 0, DateTimeKind.Unspecified), null, "Press link URL", "Link URL", 2, "Enter link URL", 16, 0, null, null },
                    { 35, new DateTime(2024, 10, 25, 10, 0, 0, 0, DateTimeKind.Unspecified), null, "Deneyim özellik başlığı", "Özellik Başlığı", 1, "Özellik başlığını girin", 18, 0, null, null },
                    { 36, new DateTime(2024, 10, 25, 10, 0, 0, 0, DateTimeKind.Unspecified), null, "Experience feature title", "Feature Title", 2, "Enter feature title", 18, 0, null, null },
                    { 37, new DateTime(2024, 10, 25, 10, 0, 0, 0, DateTimeKind.Unspecified), null, "Deneyim özellik açıklaması", "Özellik Açıklaması", 1, "Özellik açıklamasını girin", 19, 0, null, null },
                    { 38, new DateTime(2024, 10, 25, 10, 0, 0, 0, DateTimeKind.Unspecified), null, "Experience feature description", "Feature Description", 2, "Enter feature description", 19, 0, null, null },
                    { 39, new DateTime(2024, 10, 25, 10, 0, 0, 0, DateTimeKind.Unspecified), null, "Sertifikalı takım özellik başlığı", "Özellik Başlığı", 1, "Özellik başlığını girin", 20, 0, null, null },
                    { 40, new DateTime(2024, 10, 25, 10, 0, 0, 0, DateTimeKind.Unspecified), null, "Certified team feature title", "Feature Title", 2, "Enter feature title", 20, 0, null, null },
                    { 41, new DateTime(2024, 10, 25, 10, 0, 0, 0, DateTimeKind.Unspecified), null, "Sertifikalı takım özellik açıklaması", "Özellik Açıklaması", 1, "Özellik açıklamasını girin", 21, 0, null, null },
                    { 42, new DateTime(2024, 10, 25, 10, 0, 0, 0, DateTimeKind.Unspecified), null, "Certified team feature description", "Feature Description", 2, "Enter feature description", 21, 0, null, null },
                    { 43, new DateTime(2024, 10, 25, 10, 0, 0, 0, DateTimeKind.Unspecified), null, "Projeler özellik başlığı", "Özellik Başlığı", 1, "Özellik başlığını girin", 22, 0, null, null },
                    { 44, new DateTime(2024, 10, 25, 10, 0, 0, 0, DateTimeKind.Unspecified), null, "Projects feature title", "Feature Title", 2, "Enter feature title", 22, 0, null, null },
                    { 45, new DateTime(2024, 10, 25, 10, 0, 0, 0, DateTimeKind.Unspecified), null, "Projeler özellik açıklaması", "Özellik Açıklaması", 1, "Özellik açıklamasını girin", 23, 0, null, null },
                    { 46, new DateTime(2024, 10, 25, 10, 0, 0, 0, DateTimeKind.Unspecified), null, "Projects feature description", "Feature Description", 2, "Enter feature description", 23, 0, null, null },
                    { 77, new DateTime(2024, 10, 25, 10, 0, 0, 0, DateTimeKind.Unspecified), null, "Multi-cloud hizmet açıklaması", "Hizmet Açıklaması", 1, "Hizmet açıklamasını girin", 39, 0, null, null },
                    { 78, new DateTime(2024, 10, 25, 10, 0, 0, 0, DateTimeKind.Unspecified), null, "Multi-cloud service description", "Service Description", 2, "Enter service description", 39, 0, null, null },
                    { 79, new DateTime(2024, 10, 25, 10, 0, 0, 0, DateTimeKind.Unspecified), null, "Multi-cloud hizmet ikonu", "Hizmet İkonu", 1, "İkon sınıfını girin", 40, 0, null, null },
                    { 80, new DateTime(2024, 10, 25, 10, 0, 0, 0, DateTimeKind.Unspecified), null, "Multi-cloud service icon", "Service Icon", 2, "Enter icon class", 40, 0, null, null },
                    { 81, new DateTime(2024, 10, 25, 10, 0, 0, 0, DateTimeKind.Unspecified), null, "Çözümler menü etiketi", "Menü Etiketi", 1, "Menü etiketini girin", 41, 0, null, null },
                    { 82, new DateTime(2024, 10, 25, 10, 0, 0, 0, DateTimeKind.Unspecified), null, "Solutions menu label", "Menu Label", 2, "Enter menu label", 41, 0, null, null },
                    { 103, new DateTime(2024, 10, 25, 10, 0, 0, 0, DateTimeKind.Unspecified), null, "Kubernetes yazı resmi", "Yazı Resmi", 1, "Resim URL'sini girin", 52, 0, null, null },
                    { 104, new DateTime(2024, 10, 25, 10, 0, 0, 0, DateTimeKind.Unspecified), null, "Kubernetes post image", "Post Image", 2, "Enter image URL", 52, 0, null, null },
                    { 105, new DateTime(2024, 10, 25, 10, 0, 0, 0, DateTimeKind.Unspecified), null, "Kubernetes yazı tarihi", "Yazı Tarihi", 1, "Yazı tarihini girin", 53, 0, null, null },
                    { 106, new DateTime(2024, 10, 25, 10, 0, 0, 0, DateTimeKind.Unspecified), null, "Kubernetes post date", "Post Date", 2, "Enter post date", 53, 0, null, null },
                    { 107, new DateTime(2024, 10, 25, 10, 0, 0, 0, DateTimeKind.Unspecified), null, "Kubernetes yazı okuma süresi", "Okuma Süresi", 1, "Okuma süresini girin", 54, 0, null, null },
                    { 108, new DateTime(2024, 10, 25, 10, 0, 0, 0, DateTimeKind.Unspecified), null, "Kubernetes post read time", "Read Time", 2, "Enter read time", 54, 0, null, null },
                    { 109, new DateTime(2024, 10, 25, 10, 0, 0, 0, DateTimeKind.Unspecified), null, "Kariyer link etiketi", "Link Etiketi", 1, "Link etiketini girin", 55, 0, null, null },
                    { 110, new DateTime(2024, 10, 25, 10, 0, 0, 0, DateTimeKind.Unspecified), null, "Careers link label", "Link Label", 2, "Enter link label", 55, 0, null, null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Announcements_CreatedAt",
                table: "Announcements",
                column: "CreatedAt");

            migrationBuilder.CreateIndex(
                name: "IX_Announcements_PublishEnd",
                table: "Announcements",
                column: "PublishEnd");

            migrationBuilder.CreateIndex(
                name: "IX_Announcements_PublishStart",
                table: "Announcements",
                column: "PublishStart");

            migrationBuilder.CreateIndex(
                name: "IX_Announcements_Status",
                table: "Announcements",
                column: "Status");

            migrationBuilder.CreateIndex(
                name: "IX_AnnouncementTranslations_AnnouncementId",
                table: "AnnouncementTranslations",
                column: "AnnouncementId");

            migrationBuilder.CreateIndex(
                name: "IX_AnnouncementTranslations_AnnouncementId_LanguageId",
                table: "AnnouncementTranslations",
                columns: new[] { "AnnouncementId", "LanguageId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AnnouncementTranslations_LanguageId",
                table: "AnnouncementTranslations",
                column: "LanguageId");

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
                name: "IX_Contents_RelatedDataEntity",
                table: "Contents",
                columns: new[] { "RelatedDataEntityType", "RelatedDataEntityId" });

            migrationBuilder.CreateIndex(
                name: "IX_Contents_RelatedDataEntityType",
                table: "Contents",
                column: "RelatedDataEntityType");

            migrationBuilder.CreateIndex(
                name: "IX_ContentSlugs_ContentId_LanguageId",
                table: "ContentSlugs",
                columns: new[] { "ContentId", "LanguageId" });

            migrationBuilder.CreateIndex(
                name: "IX_ContentSlugs_LanguageId",
                table: "ContentSlugs",
                column: "LanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_ContentSlugs_Slug",
                table: "ContentSlugs",
                column: "Slug");

            migrationBuilder.CreateIndex(
                name: "IX_ContentSlugs_Slug_LanguageId",
                table: "ContentSlugs",
                columns: new[] { "Slug", "LanguageId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Continents_Code",
                table: "Continents",
                column: "Code");

            migrationBuilder.CreateIndex(
                name: "IX_Continents_IsActive",
                table: "Continents",
                column: "IsActive");

            migrationBuilder.CreateIndex(
                name: "IX_Continents_SortOrder",
                table: "Continents",
                column: "SortOrder");

            migrationBuilder.CreateIndex(
                name: "IX_Countries_Code",
                table: "Countries",
                column: "Code");

            migrationBuilder.CreateIndex(
                name: "IX_Countries_ContinentId",
                table: "Countries",
                column: "ContinentId");

            migrationBuilder.CreateIndex(
                name: "IX_Countries_IsActive",
                table: "Countries",
                column: "IsActive");

            migrationBuilder.CreateIndex(
                name: "IX_Countries_IsPopular",
                table: "Countries",
                column: "IsPopular");

            migrationBuilder.CreateIndex(
                name: "IX_Countries_SortOrder",
                table: "Countries",
                column: "SortOrder");

            migrationBuilder.CreateIndex(
                name: "IX_DataSchemaFields_FieldName",
                table: "DataSchemaFields",
                column: "FieldName");

            migrationBuilder.CreateIndex(
                name: "IX_DataSchemaFields_IsActive",
                table: "DataSchemaFields",
                column: "IsActive");

            migrationBuilder.CreateIndex(
                name: "IX_DataSchemaFields_IsFilterable",
                table: "DataSchemaFields",
                column: "IsFilterable");

            migrationBuilder.CreateIndex(
                name: "IX_DataSchemaFields_IsSortable",
                table: "DataSchemaFields",
                column: "IsSortable");

            migrationBuilder.CreateIndex(
                name: "IX_DataSchemaFields_SchemaId_FieldKey",
                table: "DataSchemaFields",
                columns: new[] { "DataSchemaId", "FieldKey" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_DataSchemaFields_SortOrder",
                table: "DataSchemaFields",
                column: "SortOrder");

            migrationBuilder.CreateIndex(
                name: "IX_DataSchemaFields_Type",
                table: "DataSchemaFields",
                column: "Type");

            migrationBuilder.CreateIndex(
                name: "IX_DataSchemaFieldTranslations_DataSchemaFieldId",
                table: "DataSchemaFieldTranslations",
                column: "DataSchemaFieldId");

            migrationBuilder.CreateIndex(
                name: "IX_DataSchemaFieldTranslations_Field_Language",
                table: "DataSchemaFieldTranslations",
                columns: new[] { "DataSchemaFieldId", "LanguageId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_DataSchemaFieldTranslations_LanguageId",
                table: "DataSchemaFieldTranslations",
                column: "LanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_DataSchemaFieldValues_BooleanValue",
                table: "DataSchemaFieldValues",
                column: "BooleanValue");

            migrationBuilder.CreateIndex(
                name: "IX_DataSchemaFieldValues_DateValue",
                table: "DataSchemaFieldValues",
                column: "DateValue");

            migrationBuilder.CreateIndex(
                name: "IX_DataSchemaFieldValues_FieldId",
                table: "DataSchemaFieldValues",
                column: "FieldId");

            migrationBuilder.CreateIndex(
                name: "IX_DataSchemaFieldValues_NumericValue",
                table: "DataSchemaFieldValues",
                column: "NumericValue");

            migrationBuilder.CreateIndex(
                name: "IX_DataSchemaFieldValues_Product_Schema_Field",
                table: "DataSchemaFieldValues",
                columns: new[] { "ProductId", "SchemaId", "FieldId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_DataSchemaFieldValues_ProductId",
                table: "DataSchemaFieldValues",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_DataSchemaFieldValues_SchemaId",
                table: "DataSchemaFieldValues",
                column: "SchemaId");

            migrationBuilder.CreateIndex(
                name: "IX_DataSchemaFieldValues_SortOrder",
                table: "DataSchemaFieldValues",
                column: "SortOrder");

            migrationBuilder.CreateIndex(
                name: "IX_DataSchemaFieldValueTranslations_DataSchemaFieldValueId",
                table: "DataSchemaFieldValueTranslations",
                column: "DataSchemaFieldValueId");

            migrationBuilder.CreateIndex(
                name: "IX_DataSchemaFieldValueTranslations_LanguageId",
                table: "DataSchemaFieldValueTranslations",
                column: "LanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_DataSchemaFieldValueTranslations_Value_Language",
                table: "DataSchemaFieldValueTranslations",
                columns: new[] { "DataSchemaFieldValueId", "LanguageId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_DataSchemas_IsActive",
                table: "DataSchemas",
                column: "IsActive");

            migrationBuilder.CreateIndex(
                name: "IX_DataSchemas_Key",
                table: "DataSchemas",
                column: "Key",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_DataSchemas_Name",
                table: "DataSchemas",
                column: "Name");

            migrationBuilder.CreateIndex(
                name: "IX_DataSchemas_SortOrder",
                table: "DataSchemas",
                column: "SortOrder");

            migrationBuilder.CreateIndex(
                name: "IX_DataSchemas_Status",
                table: "DataSchemas",
                column: "Status");

            migrationBuilder.CreateIndex(
                name: "IX_DataSchemaTranslations_DataSchemaId",
                table: "DataSchemaTranslations",
                column: "DataSchemaId");

            migrationBuilder.CreateIndex(
                name: "IX_DataSchemaTranslations_LanguageId",
                table: "DataSchemaTranslations",
                column: "LanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_DataSchemaTranslations_Schema_Language",
                table: "DataSchemaTranslations",
                columns: new[] { "DataSchemaId", "LanguageId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Languages_Code",
                table: "Languages",
                column: "Code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Languages_IsActive",
                table: "Languages",
                column: "IsActive");

            migrationBuilder.CreateIndex(
                name: "IX_Languages_IsDefault",
                table: "Languages",
                column: "IsDefault");

            migrationBuilder.CreateIndex(
                name: "IX_Languages_IsDeleted",
                table: "Languages",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_Languages_SortOrder",
                table: "Languages",
                column: "SortOrder");

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
                name: "IX_LayoutSections_SectionId",
                table: "LayoutSections",
                column: "SectionId");

            migrationBuilder.CreateIndex(
                name: "IX_LayoutSections_Status_IsDeleted",
                table: "LayoutSections",
                columns: new[] { "Status", "IsDeleted" });

            migrationBuilder.CreateIndex(
                name: "IX_LocalizationValues_Category",
                table: "LocalizationValues",
                column: "Category");

            migrationBuilder.CreateIndex(
                name: "IX_LocalizationValues_IsActive",
                table: "LocalizationValues",
                column: "IsActive");

            migrationBuilder.CreateIndex(
                name: "IX_LocalizationValues_IsDeleted",
                table: "LocalizationValues",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_LocalizationValues_Key",
                table: "LocalizationValues",
                column: "Key");

            migrationBuilder.CreateIndex(
                name: "IX_LocalizationValues_Key_LanguageId",
                table: "LocalizationValues",
                columns: new[] { "Key", "LanguageId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_LocalizationValues_LanguageId",
                table: "LocalizationValues",
                column: "LanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_Options_Code",
                table: "Options",
                column: "Code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Options_IntegrationCode",
                table: "Options",
                column: "IntegrationCode");

            migrationBuilder.CreateIndex(
                name: "IX_Options_ParentId",
                table: "Options",
                column: "ParentId");

            migrationBuilder.CreateIndex(
                name: "IX_Options_SortOrder",
                table: "Options",
                column: "SortOrder");

            migrationBuilder.CreateIndex(
                name: "IX_Options_Status",
                table: "Options",
                column: "Status");

            migrationBuilder.CreateIndex(
                name: "IX_Options_Type",
                table: "Options",
                column: "Type");

            migrationBuilder.CreateIndex(
                name: "IX_OptionTranslations_LanguageId",
                table: "OptionTranslations",
                column: "LanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_OptionTranslations_OptionId",
                table: "OptionTranslations",
                column: "OptionId");

            migrationBuilder.CreateIndex(
                name: "IX_OptionTranslations_OptionId_LanguageId",
                table: "OptionTranslations",
                columns: new[] { "OptionId", "LanguageId" },
                unique: true);

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
                name: "IX_Pages_LayoutId",
                table: "Pages",
                column: "LayoutId");

            migrationBuilder.CreateIndex(
                name: "IX_Pages_PageType",
                table: "Pages",
                column: "PageType");

            migrationBuilder.CreateIndex(
                name: "IX_Pages_ParentPageId",
                table: "Pages",
                column: "ParentPageId");

            migrationBuilder.CreateIndex(
                name: "IX_PageSections_PageId",
                table: "PageSections",
                column: "PageId");

            migrationBuilder.CreateIndex(
                name: "IX_PageSections_SectionId",
                table: "PageSections",
                column: "SectionId");

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
                name: "IX_ProductDataSchemas_IsActive",
                table: "ProductDataSchemas",
                column: "IsActive");

            migrationBuilder.CreateIndex(
                name: "IX_ProductDataSchemas_IsPrimary",
                table: "ProductDataSchemas",
                column: "IsPrimary");

            migrationBuilder.CreateIndex(
                name: "IX_ProductDataSchemas_Product_Schema",
                table: "ProductDataSchemas",
                columns: new[] { "ProductId", "SchemaId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ProductDataSchemas_ProductId",
                table: "ProductDataSchemas",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductDataSchemas_SchemaId",
                table: "ProductDataSchemas",
                column: "SchemaId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductDataSchemas_SortOrder",
                table: "ProductDataSchemas",
                column: "SortOrder");

            migrationBuilder.CreateIndex(
                name: "IX_ProductOptions_OptionId",
                table: "ProductOptions",
                column: "OptionId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductOptions_ProductId",
                table: "ProductOptions",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductOptions_ProductId_OptionId",
                table: "ProductOptions",
                columns: new[] { "ProductId", "OptionId" });

            migrationBuilder.CreateIndex(
                name: "IX_ProductOptions_SortOrder",
                table: "ProductOptions",
                column: "SortOrder");

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
                name: "IX_SectionItemFields_FieldKey",
                table: "SectionItemFields",
                column: "FieldKey");

            migrationBuilder.CreateIndex(
                name: "IX_SectionItemFields_SectionItemId",
                table: "SectionItemFields",
                column: "SectionItemId");

            migrationBuilder.CreateIndex(
                name: "IX_SectionItemFields_SortOrder",
                table: "SectionItemFields",
                column: "SortOrder");

            migrationBuilder.CreateIndex(
                name: "IX_SectionItemFieldTranslations_FieldId_LanguageId",
                table: "SectionItemFieldTranslations",
                columns: new[] { "SectionItemFieldId", "LanguageId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_SectionItemFieldTranslations_LanguageId",
                table: "SectionItemFieldTranslations",
                column: "LanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_SectionItemFieldValues_FieldId",
                table: "SectionItemFieldValues",
                column: "SectionItemFieldId");

            migrationBuilder.CreateIndex(
                name: "IX_SectionItemFieldValues_SectionId",
                table: "SectionItemFieldValues",
                column: "SectionId");

            migrationBuilder.CreateIndex(
                name: "IX_SectionItemFieldValues_SectionItemId",
                table: "SectionItemFieldValues",
                column: "SectionItemId");

            migrationBuilder.CreateIndex(
                name: "IX_SectionItemFieldValueTranslations_LanguageId",
                table: "SectionItemFieldValueTranslations",
                column: "LanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_SectionItemFieldValueTranslations_ValueId_LanguageId",
                table: "SectionItemFieldValueTranslations",
                columns: new[] { "SectionItemFieldValueId", "LanguageId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_SectionItems_ParentSectionItemId",
                table: "SectionItems",
                column: "ParentSectionItemId");

            migrationBuilder.CreateIndex(
                name: "IX_SectionItems_TemplateId",
                table: "SectionItems",
                column: "TemplateId");

            migrationBuilder.CreateIndex(
                name: "IX_SectionItems_Type",
                table: "SectionItems",
                column: "Type");

            migrationBuilder.CreateIndex(
                name: "IX_SectionItemTranslations_LanguageId",
                table: "SectionItemTranslations",
                column: "LanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_SectionItemTranslations_SectionItemId_LanguageId",
                table: "SectionItemTranslations",
                columns: new[] { "SectionItemId", "LanguageId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_SectionItemValues_SectionId",
                table: "SectionItemValues",
                column: "SectionId");

            migrationBuilder.CreateIndex(
                name: "IX_SectionItemValues_SectionId_SectionItemId",
                table: "SectionItemValues",
                columns: new[] { "SectionId", "SectionItemId" });

            migrationBuilder.CreateIndex(
                name: "IX_SectionItemValues_SectionItemId",
                table: "SectionItemValues",
                column: "SectionItemId");

            migrationBuilder.CreateIndex(
                name: "IX_Sections_Key",
                table: "Sections",
                column: "Key",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Sections_Type",
                table: "Sections",
                column: "Type");

            migrationBuilder.CreateIndex(
                name: "IX_SectionTranslations_LanguageId",
                table: "SectionTranslations",
                column: "LanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_SectionTranslations_SectionId_LanguageId",
                table: "SectionTranslations",
                columns: new[] { "SectionId", "LanguageId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_SectionTypeTemplates_SectionId",
                table: "SectionTypeTemplates",
                column: "SectionId");

            migrationBuilder.CreateIndex(
                name: "IX_SectionTypeTemplates_SectionType_TemplateId",
                table: "SectionTypeTemplates",
                columns: new[] { "SectionType", "TemplateId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_SectionTypeTemplates_TemplateId",
                table: "SectionTypeTemplates",
                column: "TemplateId");

            migrationBuilder.CreateIndex(
                name: "IX_Templates_TemplateKey",
                table: "Templates",
                column: "TemplateKey",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TemplateTranslations_LanguageId",
                table: "TemplateTranslations",
                column: "LanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_TemplateTranslations_TemplateId_LanguageId",
                table: "TemplateTranslations",
                columns: new[] { "TemplateId", "LanguageId" },
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
                name: "AnnouncementTranslations");

            migrationBuilder.DropTable(
                name: "CategoryProducts");

            migrationBuilder.DropTable(
                name: "CategoryTranslations");

            migrationBuilder.DropTable(
                name: "ContentSlugs");

            migrationBuilder.DropTable(
                name: "Countries");

            migrationBuilder.DropTable(
                name: "DataSchemaFieldTranslations");

            migrationBuilder.DropTable(
                name: "DataSchemaFieldValueTranslations");

            migrationBuilder.DropTable(
                name: "DataSchemaTranslations");

            migrationBuilder.DropTable(
                name: "LayoutSections");

            migrationBuilder.DropTable(
                name: "LocalizationValues");

            migrationBuilder.DropTable(
                name: "OptionTranslations");

            migrationBuilder.DropTable(
                name: "PageSections");

            migrationBuilder.DropTable(
                name: "PageTranslations");

            migrationBuilder.DropTable(
                name: "ProductDataSchemas");

            migrationBuilder.DropTable(
                name: "ProductOptions");

            migrationBuilder.DropTable(
                name: "ProductTranslations");

            migrationBuilder.DropTable(
                name: "SectionItemFieldTranslations");

            migrationBuilder.DropTable(
                name: "SectionItemFieldValueTranslations");

            migrationBuilder.DropTable(
                name: "SectionItemTranslations");

            migrationBuilder.DropTable(
                name: "SectionItemValues");

            migrationBuilder.DropTable(
                name: "SectionTranslations");

            migrationBuilder.DropTable(
                name: "SectionTypeTemplates");

            migrationBuilder.DropTable(
                name: "TemplateTranslations");

            migrationBuilder.DropTable(
                name: "TrademarkProducts");

            migrationBuilder.DropTable(
                name: "TrademarkTranslations");

            migrationBuilder.DropTable(
                name: "VariantTranslations");

            migrationBuilder.DropTable(
                name: "Announcements");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Continents");

            migrationBuilder.DropTable(
                name: "DataSchemaFieldValues");

            migrationBuilder.DropTable(
                name: "Pages");

            migrationBuilder.DropTable(
                name: "Options");

            migrationBuilder.DropTable(
                name: "SectionItemFieldValues");

            migrationBuilder.DropTable(
                name: "Trademarks");

            migrationBuilder.DropTable(
                name: "Languages");

            migrationBuilder.DropTable(
                name: "Variants");

            migrationBuilder.DropTable(
                name: "DataSchemaFields");

            migrationBuilder.DropTable(
                name: "Contents");

            migrationBuilder.DropTable(
                name: "Layouts");

            migrationBuilder.DropTable(
                name: "SectionItemFields");

            migrationBuilder.DropTable(
                name: "Sections");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "DataSchemas");

            migrationBuilder.DropTable(
                name: "SectionItems");

            migrationBuilder.DropTable(
                name: "Templates");
        }
    }
}
