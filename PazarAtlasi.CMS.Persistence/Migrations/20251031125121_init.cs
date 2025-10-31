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
                    Slug = table.Column<string>(type: "nvarchar(max)", nullable: true),
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
                table: "Contents",
                columns: new[] { "Id", "CreatedAt", "CreatedBy", "Description", "RelatedDataId", "RelatedEntityId", "Status", "UpdatedAt", "UpdatedBy" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 1, 1, 10, 0, 0, 0, DateTimeKind.Unspecified), null, "Ana sayfa içeriği", 1, 2, 1, null, null },
                    { 2, new DateTime(2024, 1, 2, 10, 0, 0, 0, DateTimeKind.Unspecified), null, "Blog yazısı içeriği", 1, 9, 1, null, null },
                    { 3, new DateTime(2024, 1, 3, 10, 0, 0, 0, DateTimeKind.Unspecified), null, "Ürün detay sayfası içeriği", 1, 4, 1, null, null }
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
                table: "Languages",
                columns: new[] { "Id", "Code", "CreatedAt", "CreatedBy", "Flag", "IsActive", "IsDefault", "Name", "NativeName", "SortOrder", "Status", "UpdatedAt", "UpdatedBy" },
                values: new object[] { 1, "tr-TR", new DateTime(2025, 10, 31, 12, 51, 20, 466, DateTimeKind.Utc).AddTicks(7253), null, "🇹🇷", true, true, "Türkçe", "Türkçe", 1, 0, null, null });

            migrationBuilder.InsertData(
                table: "Languages",
                columns: new[] { "Id", "Code", "CreatedAt", "CreatedBy", "Flag", "IsActive", "Name", "NativeName", "SortOrder", "Status", "UpdatedAt", "UpdatedBy" },
                values: new object[,]
                {
                    { 2, "en-US", new DateTime(2025, 10, 31, 12, 51, 20, 466, DateTimeKind.Utc).AddTicks(7257), null, "🇺🇸", true, "English", "English", 2, 0, null, null },
                    { 3, "de-DE", new DateTime(2025, 10, 31, 12, 51, 20, 466, DateTimeKind.Utc).AddTicks(7259), null, "🇩🇪", true, "Deutsch", "Deutsch", 3, 0, null, null },
                    { 4, "fr-FR", new DateTime(2025, 10, 31, 12, 51, 20, 466, DateTimeKind.Utc).AddTicks(7261), null, "🇫🇷", true, "Français", "Français", 4, 0, null, null },
                    { 5, "es-ES", new DateTime(2025, 10, 31, 12, 51, 20, 466, DateTimeKind.Utc).AddTicks(7263), null, "🇪🇸", true, "Español", "Español", 5, 0, null, null }
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
                table: "Pages",
                columns: new[] { "Id", "Code", "ContentId", "CreatedAt", "CreatedBy", "Description", "LayoutId", "Name", "PageSEOParameterId", "PageType", "ParentPageId", "Slug", "Status", "UpdatedAt", "UpdatedBy" },
                values: new object[] { 4, "corporate", null, new DateTime(2024, 1, 4, 10, 0, 0, 0, DateTimeKind.Unspecified), null, "Kurumsal sayfalar", null, "Kurumsal", null, 2, null, null, 1, null, null });

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
                    { 1, "Common", new DateTime(2025, 10, 31, 12, 51, 20, 467, DateTimeKind.Utc).AddTicks(2546), null, "Turkish translation for Common.Save", true, "Common.Save", 1, 0, null, null, "Kaydet" },
                    { 2, "Common", new DateTime(2025, 10, 31, 12, 51, 20, 467, DateTimeKind.Utc).AddTicks(2573), null, "Turkish translation for Common.Cancel", true, "Common.Cancel", 1, 0, null, null, "İptal" },
                    { 3, "Common", new DateTime(2025, 10, 31, 12, 51, 20, 467, DateTimeKind.Utc).AddTicks(2574), null, "Turkish translation for Common.Delete", true, "Common.Delete", 1, 0, null, null, "Sil" },
                    { 4, "Common", new DateTime(2025, 10, 31, 12, 51, 20, 467, DateTimeKind.Utc).AddTicks(2576), null, "Turkish translation for Common.Edit", true, "Common.Edit", 1, 0, null, null, "Düzenle" },
                    { 5, "Common", new DateTime(2025, 10, 31, 12, 51, 20, 467, DateTimeKind.Utc).AddTicks(2576), null, "Turkish translation for Common.Add", true, "Common.Add", 1, 0, null, null, "Ekle" },
                    { 6, "Common", new DateTime(2025, 10, 31, 12, 51, 20, 467, DateTimeKind.Utc).AddTicks(2579), null, "Turkish translation for Common.Update", true, "Common.Update", 1, 0, null, null, "Güncelle" },
                    { 7, "Common", new DateTime(2025, 10, 31, 12, 51, 20, 467, DateTimeKind.Utc).AddTicks(2579), null, "Turkish translation for Common.Create", true, "Common.Create", 1, 0, null, null, "Oluştur" },
                    { 8, "Common", new DateTime(2025, 10, 31, 12, 51, 20, 467, DateTimeKind.Utc).AddTicks(2580), null, "Turkish translation for Common.Remove", true, "Common.Remove", 1, 0, null, null, "Kaldır" },
                    { 9, "Common", new DateTime(2025, 10, 31, 12, 51, 20, 467, DateTimeKind.Utc).AddTicks(2581), null, "Turkish translation for Common.Search", true, "Common.Search", 1, 0, null, null, "Ara" },
                    { 10, "Common", new DateTime(2025, 10, 31, 12, 51, 20, 467, DateTimeKind.Utc).AddTicks(2582), null, "Turkish translation for Common.Filter", true, "Common.Filter", 1, 0, null, null, "Filtrele" },
                    { 11, "Common", new DateTime(2025, 10, 31, 12, 51, 20, 467, DateTimeKind.Utc).AddTicks(2583), null, "Turkish translation for Common.Export", true, "Common.Export", 1, 0, null, null, "Dışa Aktar" },
                    { 12, "Common", new DateTime(2025, 10, 31, 12, 51, 20, 467, DateTimeKind.Utc).AddTicks(2584), null, "Turkish translation for Common.Import", true, "Common.Import", 1, 0, null, null, "İçe Aktar" },
                    { 13, "Common", new DateTime(2025, 10, 31, 12, 51, 20, 467, DateTimeKind.Utc).AddTicks(2585), null, "Turkish translation for Common.Upload", true, "Common.Upload", 1, 0, null, null, "Yükle" },
                    { 14, "Common", new DateTime(2025, 10, 31, 12, 51, 20, 467, DateTimeKind.Utc).AddTicks(2586), null, "Turkish translation for Common.Download", true, "Common.Download", 1, 0, null, null, "İndir" },
                    { 15, "Common", new DateTime(2025, 10, 31, 12, 51, 20, 467, DateTimeKind.Utc).AddTicks(2587), null, "Turkish translation for Common.Preview", true, "Common.Preview", 1, 0, null, null, "Önizle" },
                    { 16, "Common", new DateTime(2025, 10, 31, 12, 51, 20, 467, DateTimeKind.Utc).AddTicks(2588), null, "Turkish translation for Common.Publish", true, "Common.Publish", 1, 0, null, null, "Yayınla" },
                    { 17, "Common", new DateTime(2025, 10, 31, 12, 51, 20, 467, DateTimeKind.Utc).AddTicks(2588), null, "Turkish translation for Common.Draft", true, "Common.Draft", 1, 0, null, null, "Taslak" },
                    { 18, "Common", new DateTime(2025, 10, 31, 12, 51, 20, 467, DateTimeKind.Utc).AddTicks(2590), null, "Turkish translation for Common.Active", true, "Common.Active", 1, 0, null, null, "Aktif" },
                    { 19, "Common", new DateTime(2025, 10, 31, 12, 51, 20, 467, DateTimeKind.Utc).AddTicks(2590), null, "Turkish translation for Common.Inactive", true, "Common.Inactive", 1, 0, null, null, "Pasif" },
                    { 20, "Common", new DateTime(2025, 10, 31, 12, 51, 20, 467, DateTimeKind.Utc).AddTicks(2591), null, "Turkish translation for Common.Yes", true, "Common.Yes", 1, 0, null, null, "Evet" },
                    { 21, "Common", new DateTime(2025, 10, 31, 12, 51, 20, 467, DateTimeKind.Utc).AddTicks(2592), null, "Turkish translation for Common.No", true, "Common.No", 1, 0, null, null, "Hayır" },
                    { 22, "Common", new DateTime(2025, 10, 31, 12, 51, 20, 467, DateTimeKind.Utc).AddTicks(2593), null, "Turkish translation for Common.OK", true, "Common.OK", 1, 0, null, null, "Tamam" },
                    { 23, "Common", new DateTime(2025, 10, 31, 12, 51, 20, 467, DateTimeKind.Utc).AddTicks(2594), null, "Turkish translation for Common.Close", true, "Common.Close", 1, 0, null, null, "Kapat" },
                    { 24, "Common", new DateTime(2025, 10, 31, 12, 51, 20, 467, DateTimeKind.Utc).AddTicks(2594), null, "Turkish translation for Common.Back", true, "Common.Back", 1, 0, null, null, "Geri" },
                    { 25, "Common", new DateTime(2025, 10, 31, 12, 51, 20, 467, DateTimeKind.Utc).AddTicks(2595), null, "Turkish translation for Common.Next", true, "Common.Next", 1, 0, null, null, "İleri" },
                    { 26, "Common", new DateTime(2025, 10, 31, 12, 51, 20, 467, DateTimeKind.Utc).AddTicks(2596), null, "Turkish translation for Common.Previous", true, "Common.Previous", 1, 0, null, null, "Önceki" },
                    { 27, "Common", new DateTime(2025, 10, 31, 12, 51, 20, 467, DateTimeKind.Utc).AddTicks(2597), null, "Turkish translation for Common.Loading", true, "Common.Loading", 1, 0, null, null, "Yükleniyor..." },
                    { 28, "Common", new DateTime(2025, 10, 31, 12, 51, 20, 467, DateTimeKind.Utc).AddTicks(2598), null, "Turkish translation for Common.Success", true, "Common.Success", 1, 0, null, null, "Başarılı" },
                    { 29, "Common", new DateTime(2025, 10, 31, 12, 51, 20, 467, DateTimeKind.Utc).AddTicks(2598), null, "Turkish translation for Common.Error", true, "Common.Error", 1, 0, null, null, "Hata" },
                    { 30, "Common", new DateTime(2025, 10, 31, 12, 51, 20, 467, DateTimeKind.Utc).AddTicks(2599), null, "Turkish translation for Common.Warning", true, "Common.Warning", 1, 0, null, null, "Uyarı" },
                    { 31, "Common", new DateTime(2025, 10, 31, 12, 51, 20, 467, DateTimeKind.Utc).AddTicks(2600), null, "Turkish translation for Common.Info", true, "Common.Info", 1, 0, null, null, "Bilgi" },
                    { 32, "Common", new DateTime(2025, 10, 31, 12, 51, 20, 467, DateTimeKind.Utc).AddTicks(2601), null, "Turkish translation for Common.Refresh", true, "Common.Refresh", 1, 0, null, null, "Yenile" },
                    { 33, "Common", new DateTime(2025, 10, 31, 12, 51, 20, 467, DateTimeKind.Utc).AddTicks(2602), null, "Turkish translation for Common.Settings", true, "Common.Settings", 1, 0, null, null, "Ayarlar" },
                    { 34, "Common", new DateTime(2025, 10, 31, 12, 51, 20, 467, DateTimeKind.Utc).AddTicks(2624), null, "Turkish translation for Common.ViewAll", true, "Common.ViewAll", 1, 0, null, null, "Tümünü Gör" },
                    { 35, "Page", new DateTime(2025, 10, 31, 12, 51, 20, 467, DateTimeKind.Utc).AddTicks(2627), null, "Turkish translation for Page.Title", true, "Page.Title", 1, 0, null, null, "Sayfa Başlığı" },
                    { 36, "Page", new DateTime(2025, 10, 31, 12, 51, 20, 467, DateTimeKind.Utc).AddTicks(2628), null, "Turkish translation for Page.Content", true, "Page.Content", 1, 0, null, null, "Sayfa İçeriği" },
                    { 37, "Page", new DateTime(2025, 10, 31, 12, 51, 20, 467, DateTimeKind.Utc).AddTicks(2629), null, "Turkish translation for Page.Description", true, "Page.Description", 1, 0, null, null, "Sayfa Açıklaması" },
                    { 38, "Page", new DateTime(2025, 10, 31, 12, 51, 20, 467, DateTimeKind.Utc).AddTicks(2630), null, "Turkish translation for Page.Keywords", true, "Page.Keywords", 1, 0, null, null, "Anahtar Kelimeler" },
                    { 39, "Page", new DateTime(2025, 10, 31, 12, 51, 20, 467, DateTimeKind.Utc).AddTicks(2631), null, "Turkish translation for Page.Author", true, "Page.Author", 1, 0, null, null, "Yazar" },
                    { 40, "Page", new DateTime(2025, 10, 31, 12, 51, 20, 467, DateTimeKind.Utc).AddTicks(2632), null, "Turkish translation for Page.CreatedAt", true, "Page.CreatedAt", 1, 0, null, null, "Oluşturulma Tarihi" },
                    { 41, "Page", new DateTime(2025, 10, 31, 12, 51, 20, 467, DateTimeKind.Utc).AddTicks(2632), null, "Turkish translation for Page.UpdatedAt", true, "Page.UpdatedAt", 1, 0, null, null, "Güncellenme Tarihi" },
                    { 42, "Page", new DateTime(2025, 10, 31, 12, 51, 20, 467, DateTimeKind.Utc).AddTicks(2633), null, "Turkish translation for Page.Status", true, "Page.Status", 1, 0, null, null, "Durum" },
                    { 43, "Page", new DateTime(2025, 10, 31, 12, 51, 20, 467, DateTimeKind.Utc).AddTicks(2634), null, "Turkish translation for Page.Type", true, "Page.Type", 1, 0, null, null, "Sayfa Tipi" },
                    { 44, "Page", new DateTime(2025, 10, 31, 12, 51, 20, 467, DateTimeKind.Utc).AddTicks(2635), null, "Turkish translation for Page.Layout", true, "Page.Layout", 1, 0, null, null, "Düzen" },
                    { 45, "Page", new DateTime(2025, 10, 31, 12, 51, 20, 467, DateTimeKind.Utc).AddTicks(2636), null, "Turkish translation for Page.Template", true, "Page.Template", 1, 0, null, null, "Şablon" },
                    { 46, "Page", new DateTime(2025, 10, 31, 12, 51, 20, 467, DateTimeKind.Utc).AddTicks(2636), null, "Turkish translation for Page.SEO", true, "Page.SEO", 1, 0, null, null, "SEO Ayarları" },
                    { 47, "Page", new DateTime(2025, 10, 31, 12, 51, 20, 467, DateTimeKind.Utc).AddTicks(2637), null, "Turkish translation for Page.Sections", true, "Page.Sections", 1, 0, null, null, "Bölümler" },
                    { 48, "Page", new DateTime(2025, 10, 31, 12, 51, 20, 467, DateTimeKind.Utc).AddTicks(2638), null, "Turkish translation for Page.Items", true, "Page.Items", 1, 0, null, null, "Öğeler" },
                    { 49, "Page", new DateTime(2025, 10, 31, 12, 51, 20, 467, DateTimeKind.Utc).AddTicks(2639), null, "Turkish translation for Page.Fields", true, "Page.Fields", 1, 0, null, null, "Alanlar" },
                    { 50, "Section", new DateTime(2025, 10, 31, 12, 51, 20, 467, DateTimeKind.Utc).AddTicks(2642), null, "Turkish translation for Section.Name", true, "Section.Name", 1, 0, null, null, "Bölüm Adı" },
                    { 51, "Section", new DateTime(2025, 10, 31, 12, 51, 20, 467, DateTimeKind.Utc).AddTicks(2643), null, "Turkish translation for Section.Type", true, "Section.Type", 1, 0, null, null, "Bölüm Tipi" },
                    { 52, "Section", new DateTime(2025, 10, 31, 12, 51, 20, 467, DateTimeKind.Utc).AddTicks(2644), null, "Turkish translation for Section.Key", true, "Section.Key", 1, 0, null, null, "Bölüm Anahtarı" },
                    { 53, "Section", new DateTime(2025, 10, 31, 12, 51, 20, 467, DateTimeKind.Utc).AddTicks(2645), null, "Turkish translation for Section.Order", true, "Section.Order", 1, 0, null, null, "Sıralama" },
                    { 54, "Section", new DateTime(2025, 10, 31, 12, 51, 20, 467, DateTimeKind.Utc).AddTicks(2646), null, "Turkish translation for Section.Settings", true, "Section.Settings", 1, 0, null, null, "Ayarlar" },
                    { 55, "Section", new DateTime(2025, 10, 31, 12, 51, 20, 467, DateTimeKind.Utc).AddTicks(2647), null, "Turkish translation for Section.Items", true, "Section.Items", 1, 0, null, null, "Öğeler" },
                    { 56, "Section", new DateTime(2025, 10, 31, 12, 51, 20, 467, DateTimeKind.Utc).AddTicks(2647), null, "Turkish translation for Section.AddItem", true, "Section.AddItem", 1, 0, null, null, "Öğe Ekle" },
                    { 57, "Section", new DateTime(2025, 10, 31, 12, 51, 20, 467, DateTimeKind.Utc).AddTicks(2648), null, "Turkish translation for Section.EditItems", true, "Section.EditItems", 1, 0, null, null, "Öğeleri Düzenle" },
                    { 58, "Section", new DateTime(2025, 10, 31, 12, 51, 20, 467, DateTimeKind.Utc).AddTicks(2649), null, "Turkish translation for Section.Duplicate", true, "Section.Duplicate", 1, 0, null, null, "Kopyala" },
                    { 59, "Section", new DateTime(2025, 10, 31, 12, 51, 20, 467, DateTimeKind.Utc).AddTicks(2650), null, "Turkish translation for Section.Remove", true, "Section.Remove", 1, 0, null, null, "Kaldır" },
                    { 60, "Section", new DateTime(2025, 10, 31, 12, 51, 20, 467, DateTimeKind.Utc).AddTicks(2650), null, "Turkish translation for Section.Hero", true, "Section.Hero", 1, 0, null, null, "Ana Bölüm" },
                    { 61, "Section", new DateTime(2025, 10, 31, 12, 51, 20, 467, DateTimeKind.Utc).AddTicks(2651), null, "Turkish translation for Section.Navbar", true, "Section.Navbar", 1, 0, null, null, "Navigasyon" },
                    { 62, "Section", new DateTime(2025, 10, 31, 12, 51, 20, 467, DateTimeKind.Utc).AddTicks(2652), null, "Turkish translation for Section.Footer", true, "Section.Footer", 1, 0, null, null, "Alt Bilgi" },
                    { 63, "Section", new DateTime(2025, 10, 31, 12, 51, 20, 467, DateTimeKind.Utc).AddTicks(2653), null, "Turkish translation for Section.Content", true, "Section.Content", 1, 0, null, null, "İçerik" },
                    { 64, "Section", new DateTime(2025, 10, 31, 12, 51, 20, 467, DateTimeKind.Utc).AddTicks(2654), null, "Turkish translation for Section.Gallery", true, "Section.Gallery", 1, 0, null, null, "Galeri" },
                    { 65, "Section", new DateTime(2025, 10, 31, 12, 51, 20, 467, DateTimeKind.Utc).AddTicks(2654), null, "Turkish translation for Section.Contact", true, "Section.Contact", 1, 0, null, null, "İletişim" },
                    { 66, "Validation", new DateTime(2025, 10, 31, 12, 51, 20, 467, DateTimeKind.Utc).AddTicks(2658), null, "Turkish translation for Validation.Required", true, "Validation.Required", 1, 0, null, null, "Bu alan zorunludur" },
                    { 67, "Validation", new DateTime(2025, 10, 31, 12, 51, 20, 467, DateTimeKind.Utc).AddTicks(2673), null, "Turkish translation for Validation.Email", true, "Validation.Email", 1, 0, null, null, "Geçerli bir e-posta adresi giriniz" },
                    { 68, "Validation", new DateTime(2025, 10, 31, 12, 51, 20, 467, DateTimeKind.Utc).AddTicks(2674), null, "Turkish translation for Validation.MinLength", true, "Validation.MinLength", 1, 0, null, null, "En az {0} karakter olmalıdır" },
                    { 69, "Validation", new DateTime(2025, 10, 31, 12, 51, 20, 467, DateTimeKind.Utc).AddTicks(2675), null, "Turkish translation for Validation.MaxLength", true, "Validation.MaxLength", 1, 0, null, null, "En fazla {0} karakter olmalıdır" },
                    { 70, "Validation", new DateTime(2025, 10, 31, 12, 51, 20, 467, DateTimeKind.Utc).AddTicks(2676), null, "Turkish translation for Validation.Range", true, "Validation.Range", 1, 0, null, null, "{0} ile {1} arasında olmalıdır" },
                    { 71, "Validation", new DateTime(2025, 10, 31, 12, 51, 20, 467, DateTimeKind.Utc).AddTicks(2677), null, "Turkish translation for Validation.Numeric", true, "Validation.Numeric", 1, 0, null, null, "Sayısal bir değer giriniz" },
                    { 72, "Validation", new DateTime(2025, 10, 31, 12, 51, 20, 467, DateTimeKind.Utc).AddTicks(2678), null, "Turkish translation for Validation.Date", true, "Validation.Date", 1, 0, null, null, "Geçerli bir tarih giriniz" },
                    { 73, "Validation", new DateTime(2025, 10, 31, 12, 51, 20, 467, DateTimeKind.Utc).AddTicks(2678), null, "Turkish translation for Validation.Url", true, "Validation.Url", 1, 0, null, null, "Geçerli bir URL giriniz" },
                    { 74, "Validation", new DateTime(2025, 10, 31, 12, 51, 20, 467, DateTimeKind.Utc).AddTicks(2679), null, "Turkish translation for Validation.Phone", true, "Validation.Phone", 1, 0, null, null, "Geçerli bir telefon numarası giriniz" },
                    { 75, "Validation", new DateTime(2025, 10, 31, 12, 51, 20, 467, DateTimeKind.Utc).AddTicks(2680), null, "Turkish translation for Validation.Password", true, "Validation.Password", 1, 0, null, null, "Şifre en az 8 karakter olmalıdır" },
                    { 76, "Navigation", new DateTime(2025, 10, 31, 12, 51, 20, 467, DateTimeKind.Utc).AddTicks(2682), null, "Turkish translation for Navigation.Dashboard", true, "Navigation.Dashboard", 1, 0, null, null, "Dashboard" },
                    { 77, "Navigation", new DateTime(2025, 10, 31, 12, 51, 20, 467, DateTimeKind.Utc).AddTicks(2683), null, "Turkish translation for Navigation.Announcements", true, "Navigation.Announcements", 1, 0, null, null, "Duyurular" },
                    { 78, "Navigation", new DateTime(2025, 10, 31, 12, 51, 20, 467, DateTimeKind.Utc).AddTicks(2684), null, "Turkish translation for Navigation.Campaigns", true, "Navigation.Campaigns", 1, 0, null, null, "Kampanyalar" },
                    { 79, "Navigation", new DateTime(2025, 10, 31, 12, 51, 20, 467, DateTimeKind.Utc).AddTicks(2685), null, "Turkish translation for Navigation.Content", true, "Navigation.Content", 1, 0, null, null, "İçerik" },
                    { 80, "Navigation", new DateTime(2025, 10, 31, 12, 51, 20, 467, DateTimeKind.Utc).AddTicks(2686), null, "Turkish translation for Navigation.Pages", true, "Navigation.Pages", 1, 0, null, null, "Sayfalar" },
                    { 81, "Navigation", new DateTime(2025, 10, 31, 12, 51, 20, 467, DateTimeKind.Utc).AddTicks(2687), null, "Turkish translation for Navigation.Sections", true, "Navigation.Sections", 1, 0, null, null, "Bölümler" },
                    { 82, "Navigation", new DateTime(2025, 10, 31, 12, 51, 20, 467, DateTimeKind.Utc).AddTicks(2688), null, "Turkish translation for Navigation.Layouts", true, "Navigation.Layouts", 1, 0, null, null, "Düzenler" },
                    { 83, "Navigation", new DateTime(2025, 10, 31, 12, 51, 20, 467, DateTimeKind.Utc).AddTicks(2689), null, "Turkish translation for Navigation.WebUrlManagement", true, "Navigation.WebUrlManagement", 1, 0, null, null, "Web URL Yönetimi" },
                    { 84, "Navigation", new DateTime(2025, 10, 31, 12, 51, 20, 467, DateTimeKind.Utc).AddTicks(2689), null, "Turkish translation for Navigation.News", true, "Navigation.News", 1, 0, null, null, "Haberler" },
                    { 85, "Navigation", new DateTime(2025, 10, 31, 12, 51, 20, 467, DateTimeKind.Utc).AddTicks(2690), null, "Turkish translation for Navigation.Blog", true, "Navigation.Blog", 1, 0, null, null, "Blog" },
                    { 86, "Navigation", new DateTime(2025, 10, 31, 12, 51, 20, 467, DateTimeKind.Utc).AddTicks(2691), null, "Turkish translation for Navigation.Templates", true, "Navigation.Templates", 1, 0, null, null, "Şablonlar" },
                    { 87, "Navigation", new DateTime(2025, 10, 31, 12, 51, 20, 467, DateTimeKind.Utc).AddTicks(2692), null, "Turkish translation for Navigation.SectionItems", true, "Navigation.SectionItems", 1, 0, null, null, "Bölüm Öğeleri" },
                    { 88, "Navigation", new DateTime(2025, 10, 31, 12, 51, 20, 467, DateTimeKind.Utc).AddTicks(2692), null, "Turkish translation for Navigation.ECommerce", true, "Navigation.ECommerce", 1, 0, null, null, "E-Ticaret" },
                    { 89, "Navigation", new DateTime(2025, 10, 31, 12, 51, 20, 467, DateTimeKind.Utc).AddTicks(2693), null, "Turkish translation for Navigation.Products", true, "Navigation.Products", 1, 0, null, null, "Ürünler" },
                    { 90, "Navigation", new DateTime(2025, 10, 31, 12, 51, 20, 467, DateTimeKind.Utc).AddTicks(2694), null, "Turkish translation for Navigation.Categories", true, "Navigation.Categories", 1, 0, null, null, "Kategoriler" },
                    { 91, "Navigation", new DateTime(2025, 10, 31, 12, 51, 20, 467, DateTimeKind.Utc).AddTicks(2695), null, "Turkish translation for Navigation.Orders", true, "Navigation.Orders", 1, 0, null, null, "Siparişler" },
                    { 92, "Navigation", new DateTime(2025, 10, 31, 12, 51, 20, 467, DateTimeKind.Utc).AddTicks(2696), null, "Turkish translation for Navigation.Users", true, "Navigation.Users", 1, 0, null, null, "Kullanıcılar" },
                    { 93, "Navigation", new DateTime(2025, 10, 31, 12, 51, 20, 467, DateTimeKind.Utc).AddTicks(2696), null, "Turkish translation for Navigation.ManageUsers", true, "Navigation.ManageUsers", 1, 0, null, null, "Kullanıcı Yönetimi" },
                    { 94, "Navigation", new DateTime(2025, 10, 31, 12, 51, 20, 467, DateTimeKind.Utc).AddTicks(2697), null, "Turkish translation for Navigation.ManageRoles", true, "Navigation.ManageRoles", 1, 0, null, null, "Rol Yönetimi" },
                    { 95, "Navigation", new DateTime(2025, 10, 31, 12, 51, 20, 467, DateTimeKind.Utc).AddTicks(2698), null, "Turkish translation for Navigation.ManagePermissions", true, "Navigation.ManagePermissions", 1, 0, null, null, "İzin Yönetimi" },
                    { 96, "Navigation", new DateTime(2025, 10, 31, 12, 51, 20, 467, DateTimeKind.Utc).AddTicks(2699), null, "Turkish translation for Navigation.Analytics", true, "Navigation.Analytics", 1, 0, null, null, "Analitik" },
                    { 97, "Navigation", new DateTime(2025, 10, 31, 12, 51, 20, 467, DateTimeKind.Utc).AddTicks(2699), null, "Turkish translation for Navigation.Settings", true, "Navigation.Settings", 1, 0, null, null, "Ayarlar" },
                    { 98, "Navigation", new DateTime(2025, 10, 31, 12, 51, 20, 467, DateTimeKind.Utc).AddTicks(2700), null, "Turkish translation for Navigation.GeneralSettings", true, "Navigation.GeneralSettings", 1, 0, null, null, "Genel Ayarlar" },
                    { 99, "Navigation", new DateTime(2025, 10, 31, 12, 51, 20, 467, DateTimeKind.Utc).AddTicks(2701), null, "Turkish translation for Navigation.Countries", true, "Navigation.Countries", 1, 0, null, null, "Ülkeler" },
                    { 100, "Navigation", new DateTime(2025, 10, 31, 12, 51, 20, 467, DateTimeKind.Utc).AddTicks(2702), null, "Turkish translation for Navigation.Languages", true, "Navigation.Languages", 1, 0, null, null, "Diller" },
                    { 101, "Navigation", new DateTime(2025, 10, 31, 12, 51, 20, 467, DateTimeKind.Utc).AddTicks(2739), null, "Turkish translation for Navigation.Profile", true, "Navigation.Profile", 1, 0, null, null, "Profil" },
                    { 102, "Navigation", new DateTime(2025, 10, 31, 12, 51, 20, 467, DateTimeKind.Utc).AddTicks(2741), null, "Turkish translation for Navigation.Help", true, "Navigation.Help", 1, 0, null, null, "Yardım" },
                    { 103, "Navigation", new DateTime(2025, 10, 31, 12, 51, 20, 467, DateTimeKind.Utc).AddTicks(2741), null, "Turkish translation for Navigation.Logout", true, "Navigation.Logout", 1, 0, null, null, "Çıkış" },
                    { 104, "Language", new DateTime(2025, 10, 31, 12, 51, 20, 467, DateTimeKind.Utc).AddTicks(2744), null, "Turkish translation for Language.English", true, "Language.English", 1, 0, null, null, "İngilizce" },
                    { 105, "Language", new DateTime(2025, 10, 31, 12, 51, 20, 467, DateTimeKind.Utc).AddTicks(2745), null, "Turkish translation for Language.Turkish", true, "Language.Turkish", 1, 0, null, null, "Türkçe" },
                    { 106, "Dashboard", new DateTime(2025, 10, 31, 12, 51, 20, 467, DateTimeKind.Utc).AddTicks(2747), null, "Turkish translation for Dashboard.Title", true, "Dashboard.Title", 1, 0, null, null, "Dashboard" },
                    { 107, "Dashboard", new DateTime(2025, 10, 31, 12, 51, 20, 467, DateTimeKind.Utc).AddTicks(2748), null, "Turkish translation for Dashboard.WelcomeMessage", true, "Dashboard.WelcomeMessage", 1, 0, null, null, "Hoş geldin! CMS analitiklerin ve son aktivitelerin özeti burada." },
                    { 108, "Dashboard", new DateTime(2025, 10, 31, 12, 51, 20, 467, DateTimeKind.Utc).AddTicks(2749), null, "Turkish translation for Dashboard.Last7Days", true, "Dashboard.Last7Days", 1, 0, null, null, "Son 7 gün" },
                    { 109, "Dashboard", new DateTime(2025, 10, 31, 12, 51, 20, 467, DateTimeKind.Utc).AddTicks(2750), null, "Turkish translation for Dashboard.Last30Days", true, "Dashboard.Last30Days", 1, 0, null, null, "Son 30 gün" },
                    { 110, "Dashboard", new DateTime(2025, 10, 31, 12, 51, 20, 467, DateTimeKind.Utc).AddTicks(2751), null, "Turkish translation for Dashboard.Last90Days", true, "Dashboard.Last90Days", 1, 0, null, null, "Son 90 gün" },
                    { 111, "Dashboard", new DateTime(2025, 10, 31, 12, 51, 20, 467, DateTimeKind.Utc).AddTicks(2752), null, "Turkish translation for Dashboard.TotalUsers", true, "Dashboard.TotalUsers", 1, 0, null, null, "Toplam Kullanıcı" },
                    { 112, "Dashboard", new DateTime(2025, 10, 31, 12, 51, 20, 467, DateTimeKind.Utc).AddTicks(2752), null, "Turkish translation for Dashboard.TotalRevenue", true, "Dashboard.TotalRevenue", 1, 0, null, null, "Toplam Gelir" },
                    { 113, "Dashboard", new DateTime(2025, 10, 31, 12, 51, 20, 467, DateTimeKind.Utc).AddTicks(2753), null, "Turkish translation for Dashboard.Products", true, "Dashboard.Products", 1, 0, null, null, "Ürünler" },
                    { 114, "Dashboard", new DateTime(2025, 10, 31, 12, 51, 20, 467, DateTimeKind.Utc).AddTicks(2754), null, "Turkish translation for Dashboard.SupportTickets", true, "Dashboard.SupportTickets", 1, 0, null, null, "Destek Biletleri" },
                    { 115, "Dashboard", new DateTime(2025, 10, 31, 12, 51, 20, 467, DateTimeKind.Utc).AddTicks(2755), null, "Turkish translation for Dashboard.FromLastMonth", true, "Dashboard.FromLastMonth", 1, 0, null, null, "geçen aydan" },
                    { 116, "Dashboard", new DateTime(2025, 10, 31, 12, 51, 20, 467, DateTimeKind.Utc).AddTicks(2755), null, "Turkish translation for Dashboard.SalesOverview", true, "Dashboard.SalesOverview", 1, 0, null, null, "Satış Genel Bakış" },
                    { 117, "Dashboard", new DateTime(2025, 10, 31, 12, 51, 20, 467, DateTimeKind.Utc).AddTicks(2756), null, "Turkish translation for Dashboard.Monthly", true, "Dashboard.Monthly", 1, 0, null, null, "Aylık" },
                    { 118, "Dashboard", new DateTime(2025, 10, 31, 12, 51, 20, 467, DateTimeKind.Utc).AddTicks(2757), null, "Turkish translation for Dashboard.ChartVisualization", true, "Dashboard.ChartVisualization", 1, 0, null, null, "Grafik görselleştirmesi burada olacak" },
                    { 119, "Dashboard", new DateTime(2025, 10, 31, 12, 51, 20, 467, DateTimeKind.Utc).AddTicks(2758), null, "Turkish translation for Dashboard.ThisYear", true, "Dashboard.ThisYear", 1, 0, null, null, "Bu Yıl" },
                    { 120, "Dashboard", new DateTime(2025, 10, 31, 12, 51, 20, 467, DateTimeKind.Utc).AddTicks(2759), null, "Turkish translation for Dashboard.LastYear", true, "Dashboard.LastYear", 1, 0, null, null, "Geçen Yıl" },
                    { 121, "Dashboard", new DateTime(2025, 10, 31, 12, 51, 20, 467, DateTimeKind.Utc).AddTicks(2759), null, "Turkish translation for Dashboard.RecentActivities", true, "Dashboard.RecentActivities", 1, 0, null, null, "Son Aktiviteler" },
                    { 122, "Dashboard", new DateTime(2025, 10, 31, 12, 51, 20, 467, DateTimeKind.Utc).AddTicks(2760), null, "Turkish translation for Dashboard.TopProducts", true, "Dashboard.TopProducts", 1, 0, null, null, "En İyi Ürünler" },
                    { 123, "Dashboard", new DateTime(2025, 10, 31, 12, 51, 20, 467, DateTimeKind.Utc).AddTicks(2761), null, "Turkish translation for Dashboard.Product", true, "Dashboard.Product", 1, 0, null, null, "Ürün" },
                    { 124, "Dashboard", new DateTime(2025, 10, 31, 12, 51, 20, 467, DateTimeKind.Utc).AddTicks(2762), null, "Turkish translation for Dashboard.Category", true, "Dashboard.Category", 1, 0, null, null, "Kategori" },
                    { 125, "Dashboard", new DateTime(2025, 10, 31, 12, 51, 20, 467, DateTimeKind.Utc).AddTicks(2762), null, "Turkish translation for Dashboard.Sales", true, "Dashboard.Sales", 1, 0, null, null, "Satışlar" },
                    { 126, "Dashboard", new DateTime(2025, 10, 31, 12, 51, 20, 467, DateTimeKind.Utc).AddTicks(2763), null, "Turkish translation for Dashboard.Status", true, "Dashboard.Status", 1, 0, null, null, "Durum" },
                    { 127, "Dashboard", new DateTime(2025, 10, 31, 12, 51, 20, 467, DateTimeKind.Utc).AddTicks(2764), null, "Turkish translation for Dashboard.LatestOrders", true, "Dashboard.LatestOrders", 1, 0, null, null, "Son Siparişler" },
                    { 128, "Dashboard", new DateTime(2025, 10, 31, 12, 51, 20, 467, DateTimeKind.Utc).AddTicks(2765), null, "Turkish translation for Dashboard.Today", true, "Dashboard.Today", 1, 0, null, null, "Bugün" },
                    { 129, "Dashboard", new DateTime(2025, 10, 31, 12, 51, 20, 467, DateTimeKind.Utc).AddTicks(2766), null, "Turkish translation for Dashboard.Yesterday", true, "Dashboard.Yesterday", 1, 0, null, null, "Dün" },
                    { 130, "Dashboard", new DateTime(2025, 10, 31, 12, 51, 20, 467, DateTimeKind.Utc).AddTicks(2794), null, "Turkish translation for Dashboard.OrderId", true, "Dashboard.OrderId", 1, 0, null, null, "Sipariş ID" },
                    { 131, "Dashboard", new DateTime(2025, 10, 31, 12, 51, 20, 467, DateTimeKind.Utc).AddTicks(2795), null, "Turkish translation for Dashboard.Customer", true, "Dashboard.Customer", 1, 0, null, null, "Müşteri" },
                    { 132, "Dashboard", new DateTime(2025, 10, 31, 12, 51, 20, 467, DateTimeKind.Utc).AddTicks(2796), null, "Turkish translation for Dashboard.Date", true, "Dashboard.Date", 1, 0, null, null, "Tarih" },
                    { 133, "Dashboard", new DateTime(2025, 10, 31, 12, 51, 20, 467, DateTimeKind.Utc).AddTicks(2797), null, "Turkish translation for Dashboard.Amount", true, "Dashboard.Amount", 1, 0, null, null, "Tutar" },
                    { 134, "Common", new DateTime(2025, 10, 31, 12, 51, 20, 467, DateTimeKind.Utc).AddTicks(2799), null, "English translation for Common.Save", true, "Common.Save", 2, 0, null, null, "Save" },
                    { 135, "Common", new DateTime(2025, 10, 31, 12, 51, 20, 467, DateTimeKind.Utc).AddTicks(2800), null, "English translation for Common.Cancel", true, "Common.Cancel", 2, 0, null, null, "Cancel" },
                    { 136, "Common", new DateTime(2025, 10, 31, 12, 51, 20, 467, DateTimeKind.Utc).AddTicks(2801), null, "English translation for Common.Delete", true, "Common.Delete", 2, 0, null, null, "Delete" },
                    { 137, "Common", new DateTime(2025, 10, 31, 12, 51, 20, 467, DateTimeKind.Utc).AddTicks(2802), null, "English translation for Common.Edit", true, "Common.Edit", 2, 0, null, null, "Edit" },
                    { 138, "Common", new DateTime(2025, 10, 31, 12, 51, 20, 467, DateTimeKind.Utc).AddTicks(2802), null, "English translation for Common.Add", true, "Common.Add", 2, 0, null, null, "Add" },
                    { 139, "Common", new DateTime(2025, 10, 31, 12, 51, 20, 467, DateTimeKind.Utc).AddTicks(2803), null, "English translation for Common.Update", true, "Common.Update", 2, 0, null, null, "Update" },
                    { 140, "Common", new DateTime(2025, 10, 31, 12, 51, 20, 467, DateTimeKind.Utc).AddTicks(2804), null, "English translation for Common.Create", true, "Common.Create", 2, 0, null, null, "Create" },
                    { 141, "Common", new DateTime(2025, 10, 31, 12, 51, 20, 467, DateTimeKind.Utc).AddTicks(2805), null, "English translation for Common.Remove", true, "Common.Remove", 2, 0, null, null, "Remove" },
                    { 142, "Common", new DateTime(2025, 10, 31, 12, 51, 20, 467, DateTimeKind.Utc).AddTicks(2806), null, "English translation for Common.Search", true, "Common.Search", 2, 0, null, null, "Search" },
                    { 143, "Common", new DateTime(2025, 10, 31, 12, 51, 20, 467, DateTimeKind.Utc).AddTicks(2807), null, "English translation for Common.Filter", true, "Common.Filter", 2, 0, null, null, "Filter" },
                    { 144, "Common", new DateTime(2025, 10, 31, 12, 51, 20, 467, DateTimeKind.Utc).AddTicks(2808), null, "English translation for Common.Export", true, "Common.Export", 2, 0, null, null, "Export" },
                    { 145, "Common", new DateTime(2025, 10, 31, 12, 51, 20, 467, DateTimeKind.Utc).AddTicks(2808), null, "English translation for Common.Import", true, "Common.Import", 2, 0, null, null, "Import" },
                    { 146, "Common", new DateTime(2025, 10, 31, 12, 51, 20, 467, DateTimeKind.Utc).AddTicks(2809), null, "English translation for Common.Upload", true, "Common.Upload", 2, 0, null, null, "Upload" },
                    { 147, "Common", new DateTime(2025, 10, 31, 12, 51, 20, 467, DateTimeKind.Utc).AddTicks(2810), null, "English translation for Common.Download", true, "Common.Download", 2, 0, null, null, "Download" },
                    { 148, "Common", new DateTime(2025, 10, 31, 12, 51, 20, 467, DateTimeKind.Utc).AddTicks(2811), null, "English translation for Common.Preview", true, "Common.Preview", 2, 0, null, null, "Preview" },
                    { 149, "Common", new DateTime(2025, 10, 31, 12, 51, 20, 467, DateTimeKind.Utc).AddTicks(2812), null, "English translation for Common.Publish", true, "Common.Publish", 2, 0, null, null, "Publish" },
                    { 150, "Common", new DateTime(2025, 10, 31, 12, 51, 20, 467, DateTimeKind.Utc).AddTicks(2813), null, "English translation for Common.Draft", true, "Common.Draft", 2, 0, null, null, "Draft" },
                    { 151, "Common", new DateTime(2025, 10, 31, 12, 51, 20, 467, DateTimeKind.Utc).AddTicks(2814), null, "English translation for Common.Active", true, "Common.Active", 2, 0, null, null, "Active" },
                    { 152, "Common", new DateTime(2025, 10, 31, 12, 51, 20, 467, DateTimeKind.Utc).AddTicks(2814), null, "English translation for Common.Inactive", true, "Common.Inactive", 2, 0, null, null, "Inactive" },
                    { 153, "Common", new DateTime(2025, 10, 31, 12, 51, 20, 467, DateTimeKind.Utc).AddTicks(2815), null, "English translation for Common.Yes", true, "Common.Yes", 2, 0, null, null, "Yes" },
                    { 154, "Common", new DateTime(2025, 10, 31, 12, 51, 20, 467, DateTimeKind.Utc).AddTicks(2816), null, "English translation for Common.No", true, "Common.No", 2, 0, null, null, "No" },
                    { 155, "Common", new DateTime(2025, 10, 31, 12, 51, 20, 467, DateTimeKind.Utc).AddTicks(2817), null, "English translation for Common.OK", true, "Common.OK", 2, 0, null, null, "OK" },
                    { 156, "Common", new DateTime(2025, 10, 31, 12, 51, 20, 467, DateTimeKind.Utc).AddTicks(2818), null, "English translation for Common.Close", true, "Common.Close", 2, 0, null, null, "Close" },
                    { 157, "Common", new DateTime(2025, 10, 31, 12, 51, 20, 467, DateTimeKind.Utc).AddTicks(2818), null, "English translation for Common.Back", true, "Common.Back", 2, 0, null, null, "Back" },
                    { 158, "Common", new DateTime(2025, 10, 31, 12, 51, 20, 467, DateTimeKind.Utc).AddTicks(2819), null, "English translation for Common.Next", true, "Common.Next", 2, 0, null, null, "Next" },
                    { 159, "Common", new DateTime(2025, 10, 31, 12, 51, 20, 467, DateTimeKind.Utc).AddTicks(2820), null, "English translation for Common.Previous", true, "Common.Previous", 2, 0, null, null, "Previous" },
                    { 160, "Common", new DateTime(2025, 10, 31, 12, 51, 20, 467, DateTimeKind.Utc).AddTicks(2821), null, "English translation for Common.Loading", true, "Common.Loading", 2, 0, null, null, "Loading..." },
                    { 161, "Common", new DateTime(2025, 10, 31, 12, 51, 20, 467, DateTimeKind.Utc).AddTicks(2822), null, "English translation for Common.Success", true, "Common.Success", 2, 0, null, null, "Success" },
                    { 162, "Common", new DateTime(2025, 10, 31, 12, 51, 20, 467, DateTimeKind.Utc).AddTicks(2822), null, "English translation for Common.Error", true, "Common.Error", 2, 0, null, null, "Error" },
                    { 163, "Common", new DateTime(2025, 10, 31, 12, 51, 20, 467, DateTimeKind.Utc).AddTicks(2823), null, "English translation for Common.Warning", true, "Common.Warning", 2, 0, null, null, "Warning" },
                    { 164, "Common", new DateTime(2025, 10, 31, 12, 51, 20, 467, DateTimeKind.Utc).AddTicks(2824), null, "English translation for Common.Info", true, "Common.Info", 2, 0, null, null, "Info" },
                    { 165, "Common", new DateTime(2025, 10, 31, 12, 51, 20, 467, DateTimeKind.Utc).AddTicks(2846), null, "English translation for Common.Refresh", true, "Common.Refresh", 2, 0, null, null, "Refresh" },
                    { 166, "Common", new DateTime(2025, 10, 31, 12, 51, 20, 467, DateTimeKind.Utc).AddTicks(2847), null, "English translation for Common.Settings", true, "Common.Settings", 2, 0, null, null, "Settings" },
                    { 167, "Common", new DateTime(2025, 10, 31, 12, 51, 20, 467, DateTimeKind.Utc).AddTicks(2848), null, "English translation for Common.ViewAll", true, "Common.ViewAll", 2, 0, null, null, "View All" },
                    { 168, "Page", new DateTime(2025, 10, 31, 12, 51, 20, 467, DateTimeKind.Utc).AddTicks(2851), null, "English translation for Page.Title", true, "Page.Title", 2, 0, null, null, "Page Title" },
                    { 169, "Page", new DateTime(2025, 10, 31, 12, 51, 20, 467, DateTimeKind.Utc).AddTicks(2852), null, "English translation for Page.Content", true, "Page.Content", 2, 0, null, null, "Page Content" },
                    { 170, "Page", new DateTime(2025, 10, 31, 12, 51, 20, 467, DateTimeKind.Utc).AddTicks(2852), null, "English translation for Page.Description", true, "Page.Description", 2, 0, null, null, "Page Description" },
                    { 171, "Page", new DateTime(2025, 10, 31, 12, 51, 20, 467, DateTimeKind.Utc).AddTicks(2853), null, "English translation for Page.Keywords", true, "Page.Keywords", 2, 0, null, null, "Keywords" },
                    { 172, "Page", new DateTime(2025, 10, 31, 12, 51, 20, 467, DateTimeKind.Utc).AddTicks(2854), null, "English translation for Page.Author", true, "Page.Author", 2, 0, null, null, "Author" },
                    { 173, "Page", new DateTime(2025, 10, 31, 12, 51, 20, 467, DateTimeKind.Utc).AddTicks(2855), null, "English translation for Page.CreatedAt", true, "Page.CreatedAt", 2, 0, null, null, "Created At" },
                    { 174, "Page", new DateTime(2025, 10, 31, 12, 51, 20, 467, DateTimeKind.Utc).AddTicks(2856), null, "English translation for Page.UpdatedAt", true, "Page.UpdatedAt", 2, 0, null, null, "Updated At" },
                    { 175, "Page", new DateTime(2025, 10, 31, 12, 51, 20, 467, DateTimeKind.Utc).AddTicks(2856), null, "English translation for Page.Status", true, "Page.Status", 2, 0, null, null, "Status" },
                    { 176, "Page", new DateTime(2025, 10, 31, 12, 51, 20, 467, DateTimeKind.Utc).AddTicks(2857), null, "English translation for Page.Type", true, "Page.Type", 2, 0, null, null, "Page Type" },
                    { 177, "Page", new DateTime(2025, 10, 31, 12, 51, 20, 467, DateTimeKind.Utc).AddTicks(2858), null, "English translation for Page.Layout", true, "Page.Layout", 2, 0, null, null, "Layout" },
                    { 178, "Page", new DateTime(2025, 10, 31, 12, 51, 20, 467, DateTimeKind.Utc).AddTicks(2859), null, "English translation for Page.Template", true, "Page.Template", 2, 0, null, null, "Template" },
                    { 179, "Page", new DateTime(2025, 10, 31, 12, 51, 20, 467, DateTimeKind.Utc).AddTicks(2860), null, "English translation for Page.SEO", true, "Page.SEO", 2, 0, null, null, "SEO Settings" },
                    { 180, "Page", new DateTime(2025, 10, 31, 12, 51, 20, 467, DateTimeKind.Utc).AddTicks(2860), null, "English translation for Page.Sections", true, "Page.Sections", 2, 0, null, null, "Sections" },
                    { 181, "Page", new DateTime(2025, 10, 31, 12, 51, 20, 467, DateTimeKind.Utc).AddTicks(2861), null, "English translation for Page.Items", true, "Page.Items", 2, 0, null, null, "Items" },
                    { 182, "Page", new DateTime(2025, 10, 31, 12, 51, 20, 467, DateTimeKind.Utc).AddTicks(2862), null, "English translation for Page.Fields", true, "Page.Fields", 2, 0, null, null, "Fields" },
                    { 183, "Section", new DateTime(2025, 10, 31, 12, 51, 20, 467, DateTimeKind.Utc).AddTicks(2864), null, "English translation for Section.Name", true, "Section.Name", 2, 0, null, null, "Section Name" },
                    { 184, "Section", new DateTime(2025, 10, 31, 12, 51, 20, 467, DateTimeKind.Utc).AddTicks(2865), null, "English translation for Section.Type", true, "Section.Type", 2, 0, null, null, "Section Type" },
                    { 185, "Section", new DateTime(2025, 10, 31, 12, 51, 20, 467, DateTimeKind.Utc).AddTicks(2866), null, "English translation for Section.Key", true, "Section.Key", 2, 0, null, null, "Section Key" },
                    { 186, "Section", new DateTime(2025, 10, 31, 12, 51, 20, 467, DateTimeKind.Utc).AddTicks(2867), null, "English translation for Section.Order", true, "Section.Order", 2, 0, null, null, "Order" },
                    { 187, "Section", new DateTime(2025, 10, 31, 12, 51, 20, 467, DateTimeKind.Utc).AddTicks(2906), null, "English translation for Section.Settings", true, "Section.Settings", 2, 0, null, null, "Settings" },
                    { 188, "Section", new DateTime(2025, 10, 31, 12, 51, 20, 467, DateTimeKind.Utc).AddTicks(2907), null, "English translation for Section.Items", true, "Section.Items", 2, 0, null, null, "Items" },
                    { 189, "Section", new DateTime(2025, 10, 31, 12, 51, 20, 467, DateTimeKind.Utc).AddTicks(2908), null, "English translation for Section.AddItem", true, "Section.AddItem", 2, 0, null, null, "Add Item" },
                    { 190, "Section", new DateTime(2025, 10, 31, 12, 51, 20, 467, DateTimeKind.Utc).AddTicks(2909), null, "English translation for Section.EditItems", true, "Section.EditItems", 2, 0, null, null, "Edit Items" },
                    { 191, "Section", new DateTime(2025, 10, 31, 12, 51, 20, 467, DateTimeKind.Utc).AddTicks(2909), null, "English translation for Section.Duplicate", true, "Section.Duplicate", 2, 0, null, null, "Duplicate" },
                    { 192, "Section", new DateTime(2025, 10, 31, 12, 51, 20, 467, DateTimeKind.Utc).AddTicks(2910), null, "English translation for Section.Remove", true, "Section.Remove", 2, 0, null, null, "Remove" },
                    { 193, "Section", new DateTime(2025, 10, 31, 12, 51, 20, 467, DateTimeKind.Utc).AddTicks(2911), null, "English translation for Section.Hero", true, "Section.Hero", 2, 0, null, null, "Hero Section" },
                    { 194, "Section", new DateTime(2025, 10, 31, 12, 51, 20, 467, DateTimeKind.Utc).AddTicks(2912), null, "English translation for Section.Navbar", true, "Section.Navbar", 2, 0, null, null, "Navigation" },
                    { 195, "Section", new DateTime(2025, 10, 31, 12, 51, 20, 467, DateTimeKind.Utc).AddTicks(2913), null, "English translation for Section.Footer", true, "Section.Footer", 2, 0, null, null, "Footer" },
                    { 196, "Section", new DateTime(2025, 10, 31, 12, 51, 20, 467, DateTimeKind.Utc).AddTicks(2913), null, "English translation for Section.Content", true, "Section.Content", 2, 0, null, null, "Content" },
                    { 197, "Section", new DateTime(2025, 10, 31, 12, 51, 20, 467, DateTimeKind.Utc).AddTicks(2914), null, "English translation for Section.Gallery", true, "Section.Gallery", 2, 0, null, null, "Gallery" },
                    { 198, "Section", new DateTime(2025, 10, 31, 12, 51, 20, 467, DateTimeKind.Utc).AddTicks(2915), null, "English translation for Section.Contact", true, "Section.Contact", 2, 0, null, null, "Contact" },
                    { 199, "Validation", new DateTime(2025, 10, 31, 12, 51, 20, 467, DateTimeKind.Utc).AddTicks(2918), null, "English translation for Validation.Required", true, "Validation.Required", 2, 0, null, null, "This field is required" },
                    { 200, "Validation", new DateTime(2025, 10, 31, 12, 51, 20, 467, DateTimeKind.Utc).AddTicks(2919), null, "English translation for Validation.Email", true, "Validation.Email", 2, 0, null, null, "Please enter a valid email address" },
                    { 201, "Validation", new DateTime(2025, 10, 31, 12, 51, 20, 467, DateTimeKind.Utc).AddTicks(2919), null, "English translation for Validation.MinLength", true, "Validation.MinLength", 2, 0, null, null, "Must be at least {0} characters" },
                    { 202, "Validation", new DateTime(2025, 10, 31, 12, 51, 20, 467, DateTimeKind.Utc).AddTicks(2957), null, "English translation for Validation.MaxLength", true, "Validation.MaxLength", 2, 0, null, null, "Must be at most {0} characters" },
                    { 203, "Validation", new DateTime(2025, 10, 31, 12, 51, 20, 467, DateTimeKind.Utc).AddTicks(2958), null, "English translation for Validation.Range", true, "Validation.Range", 2, 0, null, null, "Must be between {0} and {1}" },
                    { 204, "Validation", new DateTime(2025, 10, 31, 12, 51, 20, 467, DateTimeKind.Utc).AddTicks(2959), null, "English translation for Validation.Numeric", true, "Validation.Numeric", 2, 0, null, null, "Please enter a numeric value" },
                    { 205, "Validation", new DateTime(2025, 10, 31, 12, 51, 20, 467, DateTimeKind.Utc).AddTicks(2960), null, "English translation for Validation.Date", true, "Validation.Date", 2, 0, null, null, "Please enter a valid date" },
                    { 206, "Validation", new DateTime(2025, 10, 31, 12, 51, 20, 467, DateTimeKind.Utc).AddTicks(2961), null, "English translation for Validation.Url", true, "Validation.Url", 2, 0, null, null, "Please enter a valid URL" },
                    { 207, "Validation", new DateTime(2025, 10, 31, 12, 51, 20, 467, DateTimeKind.Utc).AddTicks(2962), null, "English translation for Validation.Phone", true, "Validation.Phone", 2, 0, null, null, "Please enter a valid phone number" },
                    { 208, "Validation", new DateTime(2025, 10, 31, 12, 51, 20, 467, DateTimeKind.Utc).AddTicks(2963), null, "English translation for Validation.Password", true, "Validation.Password", 2, 0, null, null, "Password must be at least 8 characters" },
                    { 209, "Navigation", new DateTime(2025, 10, 31, 12, 51, 20, 467, DateTimeKind.Utc).AddTicks(2965), null, "English translation for Navigation.Dashboard", true, "Navigation.Dashboard", 2, 0, null, null, "Dashboard" },
                    { 210, "Navigation", new DateTime(2025, 10, 31, 12, 51, 20, 467, DateTimeKind.Utc).AddTicks(2966), null, "English translation for Navigation.Announcements", true, "Navigation.Announcements", 2, 0, null, null, "Announcements" },
                    { 211, "Navigation", new DateTime(2025, 10, 31, 12, 51, 20, 467, DateTimeKind.Utc).AddTicks(2967), null, "English translation for Navigation.Campaigns", true, "Navigation.Campaigns", 2, 0, null, null, "Campaigns" },
                    { 212, "Navigation", new DateTime(2025, 10, 31, 12, 51, 20, 467, DateTimeKind.Utc).AddTicks(2968), null, "English translation for Navigation.Content", true, "Navigation.Content", 2, 0, null, null, "Content" },
                    { 213, "Navigation", new DateTime(2025, 10, 31, 12, 51, 20, 467, DateTimeKind.Utc).AddTicks(2969), null, "English translation for Navigation.Pages", true, "Navigation.Pages", 2, 0, null, null, "Pages" },
                    { 214, "Navigation", new DateTime(2025, 10, 31, 12, 51, 20, 467, DateTimeKind.Utc).AddTicks(2970), null, "English translation for Navigation.Sections", true, "Navigation.Sections", 2, 0, null, null, "Sections" },
                    { 215, "Navigation", new DateTime(2025, 10, 31, 12, 51, 20, 467, DateTimeKind.Utc).AddTicks(2971), null, "English translation for Navigation.Layouts", true, "Navigation.Layouts", 2, 0, null, null, "Layouts" },
                    { 216, "Navigation", new DateTime(2025, 10, 31, 12, 51, 20, 467, DateTimeKind.Utc).AddTicks(2971), null, "English translation for Navigation.WebUrlManagement", true, "Navigation.WebUrlManagement", 2, 0, null, null, "Web URL Management" },
                    { 217, "Navigation", new DateTime(2025, 10, 31, 12, 51, 20, 467, DateTimeKind.Utc).AddTicks(2972), null, "English translation for Navigation.News", true, "Navigation.News", 2, 0, null, null, "News" },
                    { 218, "Navigation", new DateTime(2025, 10, 31, 12, 51, 20, 467, DateTimeKind.Utc).AddTicks(2973), null, "English translation for Navigation.Blog", true, "Navigation.Blog", 2, 0, null, null, "Blog" },
                    { 219, "Navigation", new DateTime(2025, 10, 31, 12, 51, 20, 467, DateTimeKind.Utc).AddTicks(2974), null, "English translation for Navigation.Templates", true, "Navigation.Templates", 2, 0, null, null, "Templates" },
                    { 220, "Navigation", new DateTime(2025, 10, 31, 12, 51, 20, 467, DateTimeKind.Utc).AddTicks(2974), null, "English translation for Navigation.SectionItems", true, "Navigation.SectionItems", 2, 0, null, null, "Section Items" },
                    { 221, "Navigation", new DateTime(2025, 10, 31, 12, 51, 20, 467, DateTimeKind.Utc).AddTicks(2975), null, "English translation for Navigation.ECommerce", true, "Navigation.ECommerce", 2, 0, null, null, "E-Commerce" },
                    { 222, "Navigation", new DateTime(2025, 10, 31, 12, 51, 20, 467, DateTimeKind.Utc).AddTicks(2976), null, "English translation for Navigation.Products", true, "Navigation.Products", 2, 0, null, null, "Products" },
                    { 223, "Navigation", new DateTime(2025, 10, 31, 12, 51, 20, 467, DateTimeKind.Utc).AddTicks(2977), null, "English translation for Navigation.Categories", true, "Navigation.Categories", 2, 0, null, null, "Categories" },
                    { 224, "Navigation", new DateTime(2025, 10, 31, 12, 51, 20, 467, DateTimeKind.Utc).AddTicks(2977), null, "English translation for Navigation.Orders", true, "Navigation.Orders", 2, 0, null, null, "Orders" },
                    { 225, "Navigation", new DateTime(2025, 10, 31, 12, 51, 20, 467, DateTimeKind.Utc).AddTicks(2978), null, "English translation for Navigation.Users", true, "Navigation.Users", 2, 0, null, null, "Users" },
                    { 226, "Navigation", new DateTime(2025, 10, 31, 12, 51, 20, 467, DateTimeKind.Utc).AddTicks(2979), null, "English translation for Navigation.ManageUsers", true, "Navigation.ManageUsers", 2, 0, null, null, "Manage Users" },
                    { 227, "Navigation", new DateTime(2025, 10, 31, 12, 51, 20, 467, DateTimeKind.Utc).AddTicks(2980), null, "English translation for Navigation.ManageRoles", true, "Navigation.ManageRoles", 2, 0, null, null, "Manage Roles" },
                    { 228, "Navigation", new DateTime(2025, 10, 31, 12, 51, 20, 467, DateTimeKind.Utc).AddTicks(2981), null, "English translation for Navigation.ManagePermissions", true, "Navigation.ManagePermissions", 2, 0, null, null, "Manage Permissions" },
                    { 229, "Navigation", new DateTime(2025, 10, 31, 12, 51, 20, 467, DateTimeKind.Utc).AddTicks(2982), null, "English translation for Navigation.Analytics", true, "Navigation.Analytics", 2, 0, null, null, "Analytics" },
                    { 230, "Navigation", new DateTime(2025, 10, 31, 12, 51, 20, 467, DateTimeKind.Utc).AddTicks(2982), null, "English translation for Navigation.Settings", true, "Navigation.Settings", 2, 0, null, null, "Settings" },
                    { 231, "Navigation", new DateTime(2025, 10, 31, 12, 51, 20, 467, DateTimeKind.Utc).AddTicks(2983), null, "English translation for Navigation.GeneralSettings", true, "Navigation.GeneralSettings", 2, 0, null, null, "General Settings" },
                    { 232, "Navigation", new DateTime(2025, 10, 31, 12, 51, 20, 467, DateTimeKind.Utc).AddTicks(2984), null, "English translation for Navigation.Countries", true, "Navigation.Countries", 2, 0, null, null, "Countries" },
                    { 233, "Navigation", new DateTime(2025, 10, 31, 12, 51, 20, 467, DateTimeKind.Utc).AddTicks(2985), null, "English translation for Navigation.Languages", true, "Navigation.Languages", 2, 0, null, null, "Languages" },
                    { 234, "Navigation", new DateTime(2025, 10, 31, 12, 51, 20, 467, DateTimeKind.Utc).AddTicks(2985), null, "English translation for Navigation.Profile", true, "Navigation.Profile", 2, 0, null, null, "Profile" },
                    { 235, "Navigation", new DateTime(2025, 10, 31, 12, 51, 20, 467, DateTimeKind.Utc).AddTicks(2986), null, "English translation for Navigation.Help", true, "Navigation.Help", 2, 0, null, null, "Help" },
                    { 236, "Navigation", new DateTime(2025, 10, 31, 12, 51, 20, 467, DateTimeKind.Utc).AddTicks(2987), null, "English translation for Navigation.Logout", true, "Navigation.Logout", 2, 0, null, null, "Logout" },
                    { 237, "Language", new DateTime(2025, 10, 31, 12, 51, 20, 467, DateTimeKind.Utc).AddTicks(3011), null, "English translation for Language.English", true, "Language.English", 2, 0, null, null, "English" },
                    { 238, "Language", new DateTime(2025, 10, 31, 12, 51, 20, 467, DateTimeKind.Utc).AddTicks(3012), null, "English translation for Language.Turkish", true, "Language.Turkish", 2, 0, null, null, "Turkish" },
                    { 239, "Dashboard", new DateTime(2025, 10, 31, 12, 51, 20, 467, DateTimeKind.Utc).AddTicks(3015), null, "English translation for Dashboard.Title", true, "Dashboard.Title", 2, 0, null, null, "Dashboard" },
                    { 240, "Dashboard", new DateTime(2025, 10, 31, 12, 51, 20, 467, DateTimeKind.Utc).AddTicks(3016), null, "English translation for Dashboard.WelcomeMessage", true, "Dashboard.WelcomeMessage", 2, 0, null, null, "Welcome back! Here's a summary of your CMS analytics and recent activity." },
                    { 241, "Dashboard", new DateTime(2025, 10, 31, 12, 51, 20, 467, DateTimeKind.Utc).AddTicks(3017), null, "English translation for Dashboard.Last7Days", true, "Dashboard.Last7Days", 2, 0, null, null, "Last 7 days" },
                    { 242, "Dashboard", new DateTime(2025, 10, 31, 12, 51, 20, 467, DateTimeKind.Utc).AddTicks(3017), null, "English translation for Dashboard.Last30Days", true, "Dashboard.Last30Days", 2, 0, null, null, "Last 30 days" },
                    { 243, "Dashboard", new DateTime(2025, 10, 31, 12, 51, 20, 467, DateTimeKind.Utc).AddTicks(3018), null, "English translation for Dashboard.Last90Days", true, "Dashboard.Last90Days", 2, 0, null, null, "Last 90 days" },
                    { 244, "Dashboard", new DateTime(2025, 10, 31, 12, 51, 20, 467, DateTimeKind.Utc).AddTicks(3019), null, "English translation for Dashboard.TotalUsers", true, "Dashboard.TotalUsers", 2, 0, null, null, "Total Users" },
                    { 245, "Dashboard", new DateTime(2025, 10, 31, 12, 51, 20, 467, DateTimeKind.Utc).AddTicks(3020), null, "English translation for Dashboard.TotalRevenue", true, "Dashboard.TotalRevenue", 2, 0, null, null, "Total Revenue" },
                    { 246, "Dashboard", new DateTime(2025, 10, 31, 12, 51, 20, 467, DateTimeKind.Utc).AddTicks(3021), null, "English translation for Dashboard.Products", true, "Dashboard.Products", 2, 0, null, null, "Products" },
                    { 247, "Dashboard", new DateTime(2025, 10, 31, 12, 51, 20, 467, DateTimeKind.Utc).AddTicks(3021), null, "English translation for Dashboard.SupportTickets", true, "Dashboard.SupportTickets", 2, 0, null, null, "Support Tickets" },
                    { 248, "Dashboard", new DateTime(2025, 10, 31, 12, 51, 20, 467, DateTimeKind.Utc).AddTicks(3022), null, "English translation for Dashboard.FromLastMonth", true, "Dashboard.FromLastMonth", 2, 0, null, null, "from last month" },
                    { 249, "Dashboard", new DateTime(2025, 10, 31, 12, 51, 20, 467, DateTimeKind.Utc).AddTicks(3023), null, "English translation for Dashboard.SalesOverview", true, "Dashboard.SalesOverview", 2, 0, null, null, "Sales Overview" },
                    { 250, "Dashboard", new DateTime(2025, 10, 31, 12, 51, 20, 467, DateTimeKind.Utc).AddTicks(3023), null, "English translation for Dashboard.Monthly", true, "Dashboard.Monthly", 2, 0, null, null, "Monthly" },
                    { 251, "Dashboard", new DateTime(2025, 10, 31, 12, 51, 20, 467, DateTimeKind.Utc).AddTicks(3024), null, "English translation for Dashboard.ChartVisualization", true, "Dashboard.ChartVisualization", 2, 0, null, null, "Chart visualization goes here" },
                    { 252, "Dashboard", new DateTime(2025, 10, 31, 12, 51, 20, 467, DateTimeKind.Utc).AddTicks(3025), null, "English translation for Dashboard.ThisYear", true, "Dashboard.ThisYear", 2, 0, null, null, "This Year" },
                    { 253, "Dashboard", new DateTime(2025, 10, 31, 12, 51, 20, 467, DateTimeKind.Utc).AddTicks(3026), null, "English translation for Dashboard.LastYear", true, "Dashboard.LastYear", 2, 0, null, null, "Last Year" },
                    { 254, "Dashboard", new DateTime(2025, 10, 31, 12, 51, 20, 467, DateTimeKind.Utc).AddTicks(3027), null, "English translation for Dashboard.RecentActivities", true, "Dashboard.RecentActivities", 2, 0, null, null, "Recent Activities" },
                    { 255, "Dashboard", new DateTime(2025, 10, 31, 12, 51, 20, 467, DateTimeKind.Utc).AddTicks(3028), null, "English translation for Dashboard.TopProducts", true, "Dashboard.TopProducts", 2, 0, null, null, "Top Products" },
                    { 256, "Dashboard", new DateTime(2025, 10, 31, 12, 51, 20, 467, DateTimeKind.Utc).AddTicks(3029), null, "English translation for Dashboard.Product", true, "Dashboard.Product", 2, 0, null, null, "Product" },
                    { 257, "Dashboard", new DateTime(2025, 10, 31, 12, 51, 20, 467, DateTimeKind.Utc).AddTicks(3029), null, "English translation for Dashboard.Category", true, "Dashboard.Category", 2, 0, null, null, "Category" },
                    { 258, "Dashboard", new DateTime(2025, 10, 31, 12, 51, 20, 467, DateTimeKind.Utc).AddTicks(3054), null, "English translation for Dashboard.Sales", true, "Dashboard.Sales", 2, 0, null, null, "Sales" },
                    { 259, "Dashboard", new DateTime(2025, 10, 31, 12, 51, 20, 467, DateTimeKind.Utc).AddTicks(3055), null, "English translation for Dashboard.Status", true, "Dashboard.Status", 2, 0, null, null, "Status" },
                    { 260, "Dashboard", new DateTime(2025, 10, 31, 12, 51, 20, 467, DateTimeKind.Utc).AddTicks(3056), null, "English translation for Dashboard.LatestOrders", true, "Dashboard.LatestOrders", 2, 0, null, null, "Latest Orders" },
                    { 261, "Dashboard", new DateTime(2025, 10, 31, 12, 51, 20, 467, DateTimeKind.Utc).AddTicks(3057), null, "English translation for Dashboard.Today", true, "Dashboard.Today", 2, 0, null, null, "Today" },
                    { 262, "Dashboard", new DateTime(2025, 10, 31, 12, 51, 20, 467, DateTimeKind.Utc).AddTicks(3058), null, "English translation for Dashboard.Yesterday", true, "Dashboard.Yesterday", 2, 0, null, null, "Yesterday" },
                    { 263, "Dashboard", new DateTime(2025, 10, 31, 12, 51, 20, 467, DateTimeKind.Utc).AddTicks(3059), null, "English translation for Dashboard.OrderId", true, "Dashboard.OrderId", 2, 0, null, null, "Order ID" },
                    { 264, "Dashboard", new DateTime(2025, 10, 31, 12, 51, 20, 467, DateTimeKind.Utc).AddTicks(3060), null, "English translation for Dashboard.Customer", true, "Dashboard.Customer", 2, 0, null, null, "Customer" },
                    { 265, "Dashboard", new DateTime(2025, 10, 31, 12, 51, 20, 467, DateTimeKind.Utc).AddTicks(3061), null, "English translation for Dashboard.Date", true, "Dashboard.Date", 2, 0, null, null, "Date" },
                    { 266, "Dashboard", new DateTime(2025, 10, 31, 12, 51, 20, 467, DateTimeKind.Utc).AddTicks(3062), null, "English translation for Dashboard.Amount", true, "Dashboard.Amount", 2, 0, null, null, "Amount" }
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
                columns: new[] { "Id", "Code", "ContentId", "CreatedAt", "CreatedBy", "Description", "LayoutId", "Name", "PageSEOParameterId", "PageType", "ParentPageId", "Slug", "Status", "UpdatedAt", "UpdatedBy" },
                values: new object[,]
                {
                    { 1, "home", 1, new DateTime(2024, 1, 1, 10, 0, 0, 0, DateTimeKind.Unspecified), null, "Web sitesinin ana sayfası", null, "Ana Sayfa", null, 1, null, null, 1, null, null },
                    { 2, "blog", 2, new DateTime(2024, 1, 2, 10, 0, 0, 0, DateTimeKind.Unspecified), null, "Blog yazıları sayfası", null, "Blog", null, 8, null, null, 1, null, null },
                    { 3, "products", 3, new DateTime(2024, 1, 3, 10, 0, 0, 0, DateTimeKind.Unspecified), null, "Ürün katalog sayfası", null, "Ürünler", null, 4, null, null, 1, null, null },
                    { 9, "about", null, new DateTime(2024, 1, 9, 10, 0, 0, 0, DateTimeKind.Unspecified), null, "Şirket hakkında bilgi sayfası", null, "Hakkımızda", null, 2, 4, null, 1, null, null },
                    { 10, "contact", null, new DateTime(2024, 1, 10, 10, 0, 0, 0, DateTimeKind.Unspecified), null, "İletişim bilgileri ve form sayfası", null, "İletişim", null, 2, 4, null, 1, null, null }
                });

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
                table: "Pages",
                columns: new[] { "Id", "Code", "ContentId", "CreatedAt", "CreatedBy", "Description", "LayoutId", "Name", "PageSEOParameterId", "PageType", "ParentPageId", "Slug", "Status", "UpdatedAt", "UpdatedBy" },
                values: new object[,]
                {
                    { 5, "blog-teknoloji", null, new DateTime(2024, 1, 5, 10, 0, 0, 0, DateTimeKind.Unspecified), null, "Teknoloji ile ilgili blog yazıları", null, "Teknoloji", null, 5, 2, null, 1, null, null },
                    { 6, "blog-tasarim", null, new DateTime(2024, 1, 6, 10, 0, 0, 0, DateTimeKind.Unspecified), null, "Tasarım ile ilgili blog yazıları", null, "Tasarım", null, 5, 2, null, 1, null, null },
                    { 7, "products-elektronik", null, new DateTime(2024, 1, 7, 10, 0, 0, 0, DateTimeKind.Unspecified), null, "Elektronik ürünler kategorisi", null, "Elektronik", null, 5, 3, null, 1, null, null },
                    { 8, "products-giyim", null, new DateTime(2024, 1, 8, 10, 0, 0, 0, DateTimeKind.Unspecified), null, "Giyim ürünleri kategorisi", null, "Giyim", null, 5, 3, null, 1, null, null }
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
                columns: new[] { "Id", "Code", "ContentId", "CreatedAt", "CreatedBy", "Description", "LayoutId", "Name", "PageSEOParameterId", "PageType", "ParentPageId", "Slug", "Status", "UpdatedAt", "UpdatedBy" },
                values: new object[,]
                {
                    { 11, "products-elektronik-bilgisayar", null, new DateTime(2024, 1, 11, 10, 0, 0, 0, DateTimeKind.Unspecified), null, "Bilgisayar ve aksesuarları", null, "Bilgisayar", null, 5, 7, null, 1, null, null },
                    { 12, "products-elektronik-telefon", null, new DateTime(2024, 1, 12, 10, 0, 0, 0, DateTimeKind.Unspecified), null, "Akıllı telefonlar ve aksesuarları", null, "Telefon", null, 5, 7, null, 1, null, null }
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
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AnnouncementTranslations");

            migrationBuilder.DropTable(
                name: "Countries");

            migrationBuilder.DropTable(
                name: "LayoutSections");

            migrationBuilder.DropTable(
                name: "LocalizationValues");

            migrationBuilder.DropTable(
                name: "PageSections");

            migrationBuilder.DropTable(
                name: "PageSEOParameters");

            migrationBuilder.DropTable(
                name: "PageTranslations");

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
                name: "Announcements");

            migrationBuilder.DropTable(
                name: "Continents");

            migrationBuilder.DropTable(
                name: "Pages");

            migrationBuilder.DropTable(
                name: "SectionItemFieldValues");

            migrationBuilder.DropTable(
                name: "Languages");

            migrationBuilder.DropTable(
                name: "Contents");

            migrationBuilder.DropTable(
                name: "Layouts");

            migrationBuilder.DropTable(
                name: "SectionItemFields");

            migrationBuilder.DropTable(
                name: "Sections");

            migrationBuilder.DropTable(
                name: "SectionItems");

            migrationBuilder.DropTable(
                name: "Templates");
        }
    }
}
