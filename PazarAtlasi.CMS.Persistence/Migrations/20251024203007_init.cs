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
                    Name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    TemplateType = table.Column<int>(type: "int", nullable: false),
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
                name: "Pages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ContentId = table.Column<int>(type: "int", nullable: true),
                    PageSEOParameterId = table.Column<int>(type: "int", nullable: true),
                    LayoutId = table.Column<int>(type: "int", nullable: true),
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
                name: "SectionItemSettings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TemplateId = table.Column<int>(type: "int", nullable: false),
                    ConfigurationKey = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    ItemType = table.Column<int>(type: "int", nullable: false),
                    AllowDynamicSectionItems = table.Column<bool>(type: "bit", nullable: false),
                    SortOrder = table.Column<int>(type: "int", nullable: false, defaultValue: 0),
                    ParentSettingId = table.Column<int>(type: "int", nullable: true),
                    TemplateId1 = table.Column<int>(type: "int", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<int>(type: "int", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<int>(type: "int", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    Status = table.Column<int>(type: "int", nullable: false, defaultValue: 1)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SectionItemSettings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SectionItemSettings_SectionItemSettings_ParentSettingId",
                        column: x => x.ParentSettingId,
                        principalTable: "SectionItemSettings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SectionItemSettings_Templates_TemplateId",
                        column: x => x.TemplateId,
                        principalTable: "Templates",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SectionItemSettings_Templates_TemplateId1",
                        column: x => x.TemplateId1,
                        principalTable: "Templates",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "SectionItemTypeTemplate",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SectionItemType = table.Column<int>(type: "int", nullable: false),
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
                    table.PrimaryKey("PK_SectionItemTypeTemplate", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SectionItemTypeTemplate_Templates_TemplateId",
                        column: x => x.TemplateId,
                        principalTable: "Templates",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
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
                name: "SectionItemFieldSettings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SectionItemSettingId = table.Column<int>(type: "int", nullable: false),
                    FieldKey = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Type = table.Column<int>(type: "int", nullable: false),
                    Required = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    MaxLength = table.Column<int>(type: "int", nullable: false, defaultValue: 0),
                    Placeholder = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    DefaultValue = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    IsTranslatable = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    OptionsJson = table.Column<string>(type: "nvarchar(max)", nullable: true),
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
                    table.PrimaryKey("PK_SectionItemFieldSettings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SectionItemFieldSettings_SectionItemSettings_SectionItemSettingId",
                        column: x => x.SectionItemSettingId,
                        principalTable: "SectionItemSettings",
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
                    ParentSectionItemId = table.Column<int>(type: "int", nullable: true),
                    SectionItemSettingId = table.Column<int>(type: "int", nullable: false),
                    Type = table.Column<int>(type: "int", nullable: false, defaultValue: 0),
                    MediaType = table.Column<int>(type: "int", nullable: false, defaultValue: 0),
                    LinkedPageId = table.Column<int>(type: "int", nullable: true),
                    SortOrder = table.Column<int>(type: "int", nullable: false, defaultValue: 0),
                    SectionItemSettingId1 = table.Column<int>(type: "int", nullable: true),
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
                        name: "FK_SectionItems_SectionItemSettings_SectionItemSettingId1",
                        column: x => x.SectionItemSettingId1,
                        principalTable: "SectionItemSettings",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_SectionItems_SectionItems_ParentSectionItemId",
                        column: x => x.ParentSectionItemId,
                        principalTable: "SectionItems",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_SectionItems_Sections_SectionId",
                        column: x => x.SectionId,
                        principalTable: "Sections",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SectionItems_Templates_SectionItemSettingId",
                        column: x => x.SectionItemSettingId,
                        principalTable: "Templates",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SectionItemSettingTranslations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SectionItemSettingId = table.Column<int>(type: "int", nullable: false),
                    LanguageId = table.Column<int>(type: "int", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
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
                    table.PrimaryKey("PK_SectionItemSettingTranslations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SectionItemSettingTranslations_Languages_LanguageId",
                        column: x => x.LanguageId,
                        principalTable: "Languages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SectionItemSettingTranslations_SectionItemSettings_SectionItemSettingId",
                        column: x => x.SectionItemSettingId,
                        principalTable: "SectionItemSettings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SectionItemFieldSettingTranslations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SectionItemFieldSettingId = table.Column<int>(type: "int", nullable: false),
                    LanguageId = table.Column<int>(type: "int", nullable: false),
                    Label = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
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
                    table.PrimaryKey("PK_SectionItemFieldSettingTranslations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SectionItemFieldSettingTranslations_Languages_LanguageId",
                        column: x => x.LanguageId,
                        principalTable: "Languages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SectionItemFieldSettingTranslations_SectionItemFieldSettings_SectionItemFieldSettingId",
                        column: x => x.SectionItemFieldSettingId,
                        principalTable: "SectionItemFieldSettings",
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
                columns: new[] { "Id", "Code", "ContentId", "CreatedAt", "CreatedBy", "Description", "LayoutId", "Name", "PageSEOParameterId", "PageType", "Slug", "Status", "UpdatedAt", "UpdatedBy" },
                values: new object[,]
                {
                    { 4, "about", null, new DateTime(2024, 1, 4, 10, 0, 0, 0, DateTimeKind.Unspecified), null, "Şirket hakkında bilgi sayfası", null, "Hakkımızda", null, 2, null, 1, null, null },
                    { 5, "contact", null, new DateTime(2024, 1, 5, 10, 0, 0, 0, DateTimeKind.Unspecified), null, "İletişim bilgileri ve form sayfası", null, "İletişim", null, 2, null, 1, null, null }
                });

            migrationBuilder.InsertData(
                table: "Sections",
                columns: new[] { "Id", "Attributes", "Configure", "CreatedAt", "CreatedBy", "SortOrder", "Status", "Type", "UpdatedAt", "UpdatedBy" },
                values: new object[,]
                {
                    { 1, "{\"backgroundImage\": \"hero-bg.jpg\", \"height\": \"500px\"}", "{\"showButton\": true, \"buttonText\": \"Keşfet\"}", new DateTime(2024, 1, 1, 10, 0, 0, 0, DateTimeKind.Unspecified), null, 1, 1, 3, null, null },
                    { 2, "{\"columns\": 3}", "{\"maxItems\": 6, \"showMore\": true, \"showPrices\": true}", new DateTime(2024, 1, 1, 10, 0, 0, 0, DateTimeKind.Unspecified), null, 2, 1, 6, null, null },
                    { 3, "{\"backgroundColor\": \"#f8f9fa\"}", "{\"showPrivacyText\": true}", new DateTime(2024, 1, 1, 10, 0, 0, 0, DateTimeKind.Unspecified), null, 3, 1, 7, null, null },
                    { 4, "{}", "{\"showSearchBox\": true,\"showBreadcrumbs\": true}", new DateTime(2024, 1, 2, 10, 0, 0, 0, DateTimeKind.Unspecified), null, 1, 1, 2, null, null },
                    { 5, "{}", "{\"showExcerpt\": true, \"showAuthor\": true, \"showDate\": true,\"postsPerPage\": 10}", new DateTime(2024, 1, 2, 10, 0, 0, 0, DateTimeKind.Unspecified), null, 2, 1, 12, null, null },
                    { 6, "{\"columns\": 4}", "{\"productsPerPage\": 20, \"showSorting\": true, \"showFilters\": true}", new DateTime(2024, 1, 3, 10, 0, 0, 0, DateTimeKind.Unspecified), null, 1, 1, 4, null, null }
                });

            migrationBuilder.InsertData(
                table: "Templates",
                columns: new[] { "Id", "ConfigurationSchema", "CreatedAt", "CreatedBy", "Description", "IsActive", "IsDeleted", "Name", "SortOrder", "Status", "TemplateKey", "TemplateType", "UpdatedAt", "UpdatedBy" },
                values: new object[,]
                {
                    { 1, "{\"type\":\"object\",\"properties\":{\"backgroundColor\":{\"type\":\"string\",\"default\":\"#ffffff\"},\"textColor\":{\"type\":\"string\",\"default\":\"#333333\"},\"showLogo\":{\"type\":\"boolean\",\"default\":true},\"logoPosition\":{\"type\":\"string\",\"enum\":[\"left\",\"center\",\"right\"],\"default\":\"left\"}}}", new DateTime(2024, 10, 14, 10, 0, 0, 0, DateTimeKind.Unspecified), null, "A simple horizontal navigation bar with basic menu items", true, false, "Simple Navbar", 1, 0, "navbar-simple", 1, null, null },
                    { 2, "{\"type\":\"object\",\"properties\":{\"backgroundColor\":{\"type\":\"string\",\"default\":\"#1a1a1a\"},\"textColor\":{\"type\":\"string\",\"default\":\"#ffffff\"},\"showLogo\":{\"type\":\"boolean\",\"default\":true},\"logoPosition\":{\"type\":\"string\",\"enum\":[\"left\",\"center\",\"right\"],\"default\":\"left\"},\"megaMenuColumns\":{\"type\":\"integer\",\"minimum\":2,\"maximum\":4,\"default\":3},\"showDescriptions\":{\"type\":\"boolean\",\"default\":true},\"showImages\":{\"type\":\"boolean\",\"default\":true}}}", new DateTime(2024, 10, 14, 10, 0, 0, 0, DateTimeKind.Unspecified), null, "Advanced navbar with dropdown mega menus and rich content", true, false, "Mega Menu Navbar", 2, 0, "navbar-megamenu", 11, null, null },
                    { 3, "{\"type\":\"object\",\"properties\":{\"backgroundColor\":{\"type\":\"string\",\"default\":\"#2d3748\"},\"textColor\":{\"type\":\"string\",\"default\":\"#ffffff\"},\"showLogo\":{\"type\":\"boolean\",\"default\":true},\"logoPosition\":{\"type\":\"string\",\"enum\":[\"left\",\"center\",\"right\"],\"default\":\"left\"},\"tabStyle\":{\"type\":\"string\",\"enum\":[\"pills\",\"underline\",\"background\"],\"default\":\"pills\"},\"showIcons\":{\"type\":\"boolean\",\"default\":true},\"animationDuration\":{\"type\":\"integer\",\"minimum\":100,\"maximum\":1000,\"default\":300}}}", new DateTime(2024, 10, 14, 10, 0, 0, 0, DateTimeKind.Unspecified), null, "Navbar with tabbed service navigation and interactive content", true, false, "Service Tabs Navbar", 3, 0, "navbar-servicetabs", 10, null, null },
                    { 4, "{\"type\":\"object\",\"properties\":{\"backgroundColor\":{\"type\":\"string\",\"default\":\"#4a5568\"},\"textColor\":{\"type\":\"string\",\"default\":\"#ffffff\"},\"showLogo\":{\"type\":\"boolean\",\"default\":true},\"logoPosition\":{\"type\":\"string\",\"enum\":[\"left\",\"center\",\"right\"],\"default\":\"left\"},\"categoryStyle\":{\"type\":\"string\",\"enum\":[\"sidebar\",\"dropdown\",\"tabs\"],\"default\":\"sidebar\"},\"showCategoryIcons\":{\"type\":\"boolean\",\"default\":true},\"itemsPerCategory\":{\"type\":\"integer\",\"minimum\":2,\"maximum\":8,\"default\":4}}}", new DateTime(2024, 10, 14, 10, 0, 0, 0, DateTimeKind.Unspecified), null, "Navbar with categorized menu items and filtered content display", true, false, "Categorized Navbar", 4, 0, "navbar-categorized", 6, null, null },
                    { 5, "{\"type\":\"object\",\"properties\":{\"backgroundColor\":{\"type\":\"string\",\"default\":\"#ffffff\"},\"textColor\":{\"type\":\"string\",\"default\":\"#333333\"},\"padding\":{\"type\":\"string\",\"enum\":[\"small\",\"medium\",\"large\"],\"default\":\"medium\"}}}", new DateTime(2024, 10, 14, 10, 0, 0, 0, DateTimeKind.Unspecified), null, "Standard template for any section type", true, false, "Default Template", 5, 0, "default", 1, null, null },
                    { 6, "{\"type\":\"object\",\"properties\":{\"direction\":{\"type\":\"string\",\"enum\":[\"horizontal\",\"vertical\"],\"default\":\"vertical\"},\"spacing\":{\"type\":\"string\",\"enum\":[\"small\",\"medium\",\"large\"],\"default\":\"medium\"},\"showNumbers\":{\"type\":\"boolean\",\"default\":false}}}", new DateTime(2024, 10, 14, 10, 0, 0, 0, DateTimeKind.Unspecified), null, "Items displayed in sequential order", true, false, "Sequential Layout", 6, 0, "sequential", 2, null, null },
                    { 7, "{\"type\":\"object\",\"properties\":{\"columns\":{\"type\":\"integer\",\"minimum\":1,\"maximum\":6,\"default\":3},\"gap\":{\"type\":\"string\",\"enum\":[\"small\",\"medium\",\"large\"],\"default\":\"medium\"},\"showImages\":{\"type\":\"boolean\",\"default\":true},\"showExcerpts\":{\"type\":\"boolean\",\"default\":true}}}", new DateTime(2024, 10, 14, 10, 0, 0, 0, DateTimeKind.Unspecified), null, "Content displayed in a responsive grid layout", true, false, "Grid Layout", 7, 0, "grid", 3, null, null },
                    { 8, "{\"type\":\"object\",\"properties\":{\"columns\":{\"type\":\"integer\",\"minimum\":2,\"maximum\":5,\"default\":3},\"gap\":{\"type\":\"string\",\"enum\":[\"small\",\"medium\",\"large\"],\"default\":\"medium\"},\"showImages\":{\"type\":\"boolean\",\"default\":true},\"imageAspectRatio\":{\"type\":\"string\",\"enum\":[\"auto\",\"square\",\"landscape\",\"portrait\"],\"default\":\"auto\"}}}", new DateTime(2024, 10, 14, 10, 0, 0, 0, DateTimeKind.Unspecified), null, "Pinterest-style masonry layout for varied content sizes", true, false, "Masonry Layout", 8, 0, "masonry", 4, null, null },
                    { 9, "{\"type\":\"object\",\"properties\":{\"autoPlay\":{\"type\":\"boolean\",\"default\":true},\"interval\":{\"type\":\"integer\",\"minimum\":2000,\"maximum\":10000,\"default\":5000},\"showIndicators\":{\"type\":\"boolean\",\"default\":true},\"showArrows\":{\"type\":\"boolean\",\"default\":true},\"transitionEffect\":{\"type\":\"string\",\"enum\":[\"fade\",\"slide\",\"zoom\"],\"default\":\"slide\"}}}", new DateTime(2024, 10, 14, 10, 0, 0, 0, DateTimeKind.Unspecified), null, "Sliding carousel with navigation controls", true, false, "Carousel", 9, 0, "carousel", 5, null, null },
                    { 10, "{\"type\":\"object\",\"properties\":{\"showIcons\":{\"type\":\"boolean\",\"default\":true},\"iconPosition\":{\"type\":\"string\",\"enum\":[\"left\",\"right\"],\"default\":\"left\"},\"spacing\":{\"type\":\"string\",\"enum\":[\"compact\",\"comfortable\",\"spacious\"],\"default\":\"comfortable\"},\"showDividers\":{\"type\":\"boolean\",\"default\":false}}}", new DateTime(2024, 10, 14, 10, 0, 0, 0, DateTimeKind.Unspecified), null, "Simple list layout with optional icons", true, false, "List Layout", 10, 0, "list", 6, null, null },
                    { 11, "{\"type\":\"object\",\"properties\":{\"alignment\":{\"type\":\"string\",\"enum\":[\"left\",\"center\",\"right\"],\"default\":\"center\"},\"showImage\":{\"type\":\"boolean\",\"default\":true},\"imageSize\":{\"type\":\"string\",\"enum\":[\"small\",\"medium\",\"large\"],\"default\":\"medium\"},\"showDescription\":{\"type\":\"boolean\",\"default\":true}}}", new DateTime(2024, 10, 14, 10, 0, 0, 0, DateTimeKind.Unspecified), null, "Display single item with focus", true, false, "Single Item", 11, 0, "single-item", 7, null, null },
                    { 12, "{\"type\":\"object\",\"properties\":{\"itemsPerRow\":{\"type\":\"integer\",\"minimum\":2,\"maximum\":6,\"default\":3},\"showTitles\":{\"type\":\"boolean\",\"default\":true},\"showDescriptions\":{\"type\":\"boolean\",\"default\":true},\"equalHeight\":{\"type\":\"boolean\",\"default\":true}}}", new DateTime(2024, 10, 14, 10, 0, 0, 0, DateTimeKind.Unspecified), null, "Display multiple items in organized layout", true, false, "Multi Item", 12, 0, "multi-item", 8, null, null },
                    { 13, "{\"type\":\"object\",\"properties\":{\"allowMultiple\":{\"type\":\"boolean\",\"default\":false},\"defaultOpen\":{\"type\":\"integer\",\"minimum\":0,\"default\":0},\"showIcons\":{\"type\":\"boolean\",\"default\":true},\"animationDuration\":{\"type\":\"integer\",\"minimum\":100,\"maximum\":1000,\"default\":300}}}", new DateTime(2024, 10, 14, 10, 0, 0, 0, DateTimeKind.Unspecified), null, "Collapsible accordion layout", true, false, "Accordion", 13, 0, "accordion", 9, null, null },
                    { 14, "{\"type\":\"object\",\"properties\":{\"tabPosition\":{\"type\":\"string\",\"enum\":[\"top\",\"bottom\",\"left\",\"right\"],\"default\":\"top\"},\"tabStyle\":{\"type\":\"string\",\"enum\":[\"pills\",\"underline\",\"background\"],\"default\":\"underline\"},\"showIcons\":{\"type\":\"boolean\",\"default\":false},\"defaultTab\":{\"type\":\"integer\",\"minimum\":0,\"default\":0}}}", new DateTime(2024, 10, 14, 10, 0, 0, 0, DateTimeKind.Unspecified), null, "Tabbed content layout", true, false, "Tabs", 14, 0, "tabs", 10, null, null }
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
                table: "PageTranslations",
                columns: new[] { "Id", "CreatedAt", "CreatedBy", "LanguageId", "PageId", "Status", "UpdatedAt", "UpdatedBy", "Value" },
                values: new object[,]
                {
                    { 7, new DateTime(2024, 1, 4, 10, 0, 0, 0, DateTimeKind.Unspecified), null, 1, 4, 1, null, null, "Hakkımızda" },
                    { 8, new DateTime(2024, 1, 4, 10, 0, 0, 0, DateTimeKind.Unspecified), null, 2, 4, 1, null, null, "About Us" }
                });

            migrationBuilder.InsertData(
                table: "Pages",
                columns: new[] { "Id", "Code", "ContentId", "CreatedAt", "CreatedBy", "Description", "LayoutId", "Name", "PageSEOParameterId", "PageType", "Slug", "Status", "UpdatedAt", "UpdatedBy" },
                values: new object[,]
                {
                    { 1, "home", 1, new DateTime(2024, 1, 1, 10, 0, 0, 0, DateTimeKind.Unspecified), null, "Web sitesinin ana sayfası", null, "Ana Sayfa", null, 1, null, 1, null, null },
                    { 2, "blog", 2, new DateTime(2024, 1, 2, 10, 0, 0, 0, DateTimeKind.Unspecified), null, "Blog yazıları sayfası", null, "Blog", null, 8, null, 1, null, null },
                    { 3, "products", 3, new DateTime(2024, 1, 3, 10, 0, 0, 0, DateTimeKind.Unspecified), null, "Ürün katalog sayfası", null, "Ürünler", null, 3, null, 1, null, null }
                });

            migrationBuilder.InsertData(
                table: "SectionItemSettings",
                columns: new[] { "Id", "AllowDynamicSectionItems", "ConfigurationKey", "CreatedAt", "CreatedBy", "ItemType", "ParentSettingId", "SortOrder", "Status", "TemplateId", "TemplateId1", "UpdatedAt", "UpdatedBy" },
                values: new object[,]
                {
                    { 1, false, "logo", new DateTime(2024, 10, 21, 10, 0, 0, 0, DateTimeKind.Unspecified), null, 1, null, 1, 1, 1, null, null, null },
                    { 2, true, "menu", new DateTime(2024, 10, 21, 10, 0, 0, 0, DateTimeKind.Unspecified), null, 21, null, 2, 1, 1, null, null, null },
                    { 10, true, "slide", new DateTime(2024, 10, 21, 10, 0, 0, 0, DateTimeKind.Unspecified), null, 10, null, 4, 1, 9, null, null, null },
                    { 20, true, "content-item", new DateTime(2024, 10, 21, 10, 0, 0, 0, DateTimeKind.Unspecified), null, 6, null, 5, 1, 5, null, null, null },
                    { 30, true, "mega-menu-category", new DateTime(2024, 10, 21, 10, 0, 0, 0, DateTimeKind.Unspecified), null, 21, null, 6, 1, 2, null, null, null },
                    { 40, true, "service-tab", new DateTime(2024, 10, 21, 10, 0, 0, 0, DateTimeKind.Unspecified), null, 21, null, 8, 1, 3, null, null, null },
                    { 50, true, "category", new DateTime(2024, 10, 21, 10, 0, 0, 0, DateTimeKind.Unspecified), null, 21, null, 9, 1, 4, null, null, null },
                    { 60, true, "step", new DateTime(2024, 10, 21, 10, 0, 0, 0, DateTimeKind.Unspecified), null, 6, null, 11, 1, 6, null, null, null },
                    { 70, true, "grid-item", new DateTime(2024, 10, 21, 10, 0, 0, 0, DateTimeKind.Unspecified), null, 6, null, 12, 1, 7, null, null, null },
                    { 80, true, "masonry-image", new DateTime(2024, 10, 21, 10, 0, 0, 0, DateTimeKind.Unspecified), null, 10, null, 13, 1, 8, null, null, null },
                    { 90, true, "list-item", new DateTime(2024, 10, 21, 10, 0, 0, 0, DateTimeKind.Unspecified), null, 6, null, 14, 1, 10, null, null, null },
                    { 101, false, "single-item", new DateTime(2024, 10, 21, 10, 0, 0, 0, DateTimeKind.Unspecified), null, 6, null, 15, 1, 11, null, null, null },
                    { 110, true, "multi-item", new DateTime(2024, 10, 21, 10, 0, 0, 0, DateTimeKind.Unspecified), null, 6, null, 16, 1, 12, null, null, null },
                    { 120, true, "panel", new DateTime(2024, 10, 21, 10, 0, 0, 0, DateTimeKind.Unspecified), null, 6, null, 17, 1, 13, null, null, null },
                    { 130, true, "tab", new DateTime(2024, 10, 21, 10, 0, 0, 0, DateTimeKind.Unspecified), null, 6, null, 18, 1, 14, null, null, null }
                });

            migrationBuilder.InsertData(
                table: "SectionItems",
                columns: new[] { "Id", "CreatedAt", "CreatedBy", "LinkedPageId", "ParentSectionItemId", "SectionId", "SectionItemSettingId1", "SortOrder", "Status", "SectionItemSettingId", "Type", "UpdatedAt", "UpdatedBy" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 1, 1, 10, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, 1, null, 1, 1, 1, 6, null, null },
                    { 2, new DateTime(2024, 1, 1, 10, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, 1, null, 2, 1, 1, 9, null, null },
                    { 3, new DateTime(2024, 1, 1, 10, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, 1, null, 3, 1, 1, 5, null, null },
                    { 4, new DateTime(2024, 1, 1, 10, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, 2, null, 1, 1, 1, 10, null, null },
                    { 5, new DateTime(2024, 1, 1, 10, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, 2, null, 2, 1, 1, 10, null, null },
                    { 6, new DateTime(2024, 1, 1, 10, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, 2, null, 3, 1, 1, 10, null, null },
                    { 7, new DateTime(2024, 1, 1, 10, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, 3, null, 1, 1, 1, 6, null, null },
                    { 8, new DateTime(2024, 1, 1, 10, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, 3, null, 2, 1, 1, 15, null, null },
                    { 9, new DateTime(2024, 1, 2, 10, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, 4, null, 1, 1, 1, 6, null, null },
                    { 10, new DateTime(2024, 1, 2, 10, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, 4, null, 2, 1, 1, 18, null, null }
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
                table: "SectionItemFieldSettings",
                columns: new[] { "Id", "CreatedAt", "CreatedBy", "DefaultValue", "FieldKey", "OptionsJson", "Placeholder", "Required", "SectionItemSettingId", "SortOrder", "Status", "Type", "UpdatedAt", "UpdatedBy" },
                values: new object[] { 1, new DateTime(2024, 10, 21, 10, 0, 0, 0, DateTimeKind.Unspecified), null, null, "image", null, null, true, 1, 1, 1, 11, null, null });

            migrationBuilder.InsertData(
                table: "SectionItemFieldSettings",
                columns: new[] { "Id", "CreatedAt", "CreatedBy", "DefaultValue", "FieldKey", "IsTranslatable", "MaxLength", "OptionsJson", "Placeholder", "SectionItemSettingId", "SortOrder", "Status", "Type", "UpdatedAt", "UpdatedBy" },
                values: new object[] { 2, new DateTime(2024, 10, 21, 10, 0, 0, 0, DateTimeKind.Unspecified), null, null, "altText", true, 100, null, "Logo alt text", 1, 2, 1, 1, null, null });

            migrationBuilder.InsertData(
                table: "SectionItemFieldSettings",
                columns: new[] { "Id", "CreatedAt", "CreatedBy", "DefaultValue", "FieldKey", "MaxLength", "OptionsJson", "Placeholder", "SectionItemSettingId", "SortOrder", "Status", "Type", "UpdatedAt", "UpdatedBy" },
                values: new object[] { 3, new DateTime(2024, 10, 21, 10, 0, 0, 0, DateTimeKind.Unspecified), null, "/", "url", 500, null, "/", 1, 3, 1, 13, null, null });

            migrationBuilder.InsertData(
                table: "SectionItemFieldSettings",
                columns: new[] { "Id", "CreatedAt", "CreatedBy", "DefaultValue", "FieldKey", "IsTranslatable", "MaxLength", "OptionsJson", "Placeholder", "Required", "SectionItemSettingId", "SortOrder", "Status", "Type", "UpdatedAt", "UpdatedBy" },
                values: new object[] { 4, new DateTime(2024, 10, 21, 10, 0, 0, 0, DateTimeKind.Unspecified), null, null, "title", true, 50, null, "e.g., Products, Services", true, 2, 1, 1, 2, null, null });

            migrationBuilder.InsertData(
                table: "SectionItemFieldSettings",
                columns: new[] { "Id", "CreatedAt", "CreatedBy", "DefaultValue", "FieldKey", "MaxLength", "OptionsJson", "Placeholder", "SectionItemSettingId", "SortOrder", "Status", "Type", "UpdatedAt", "UpdatedBy" },
                values: new object[] { 5, new DateTime(2024, 10, 21, 10, 0, 0, 0, DateTimeKind.Unspecified), null, null, "icon", 50, null, "fa fa-bars", 2, 2, 1, 1, null, null });

            migrationBuilder.InsertData(
                table: "SectionItemFieldSettings",
                columns: new[] { "Id", "CreatedAt", "CreatedBy", "DefaultValue", "FieldKey", "OptionsJson", "Placeholder", "Required", "SectionItemSettingId", "SortOrder", "Status", "Type", "UpdatedAt", "UpdatedBy" },
                values: new object[] { 100, new DateTime(2024, 10, 21, 10, 0, 0, 0, DateTimeKind.Unspecified), null, null, "image", null, null, true, 10, 1, 1, 11, null, null });

            migrationBuilder.InsertData(
                table: "SectionItemFieldSettings",
                columns: new[] { "Id", "CreatedAt", "CreatedBy", "DefaultValue", "FieldKey", "IsTranslatable", "MaxLength", "OptionsJson", "Placeholder", "SectionItemSettingId", "SortOrder", "Status", "Type", "UpdatedAt", "UpdatedBy" },
                values: new object[,]
                {
                    { 101, new DateTime(2024, 10, 21, 10, 0, 0, 0, DateTimeKind.Unspecified), null, null, "title", true, 100, null, null, 10, 2, 1, 2, null, null },
                    { 102, new DateTime(2024, 10, 21, 10, 0, 0, 0, DateTimeKind.Unspecified), null, null, "description", true, 300, null, null, 10, 3, 1, 3, null, null },
                    { 103, new DateTime(2024, 10, 21, 10, 0, 0, 0, DateTimeKind.Unspecified), null, null, "buttonText", true, 50, null, null, 10, 4, 1, 1, null, null }
                });

            migrationBuilder.InsertData(
                table: "SectionItemFieldSettings",
                columns: new[] { "Id", "CreatedAt", "CreatedBy", "DefaultValue", "FieldKey", "MaxLength", "OptionsJson", "Placeholder", "SectionItemSettingId", "SortOrder", "Status", "Type", "UpdatedAt", "UpdatedBy" },
                values: new object[] { 104, new DateTime(2024, 10, 21, 10, 0, 0, 0, DateTimeKind.Unspecified), null, null, "buttonUrl", 500, null, null, 10, 5, 1, 13, null, null });

            migrationBuilder.InsertData(
                table: "SectionItemFieldSettings",
                columns: new[] { "Id", "CreatedAt", "CreatedBy", "DefaultValue", "FieldKey", "IsTranslatable", "MaxLength", "OptionsJson", "Placeholder", "Required", "SectionItemSettingId", "SortOrder", "Status", "Type", "UpdatedAt", "UpdatedBy" },
                values: new object[] { 200, new DateTime(2024, 10, 21, 10, 0, 0, 0, DateTimeKind.Unspecified), null, null, "title", true, 100, null, null, true, 20, 1, 1, 2, null, null });

            migrationBuilder.InsertData(
                table: "SectionItemFieldSettings",
                columns: new[] { "Id", "CreatedAt", "CreatedBy", "DefaultValue", "FieldKey", "IsTranslatable", "MaxLength", "OptionsJson", "Placeholder", "SectionItemSettingId", "SortOrder", "Status", "Type", "UpdatedAt", "UpdatedBy" },
                values: new object[] { 201, new DateTime(2024, 10, 21, 10, 0, 0, 0, DateTimeKind.Unspecified), null, null, "description", true, 500, null, null, 20, 2, 1, 3, null, null });

            migrationBuilder.InsertData(
                table: "SectionItemFieldSettings",
                columns: new[] { "Id", "CreatedAt", "CreatedBy", "DefaultValue", "FieldKey", "IsTranslatable", "MaxLength", "OptionsJson", "Placeholder", "Required", "SectionItemSettingId", "SortOrder", "Status", "Type", "UpdatedAt", "UpdatedBy" },
                values: new object[] { 300, new DateTime(2024, 10, 21, 10, 0, 0, 0, DateTimeKind.Unspecified), null, null, "title", true, 50, null, "e.g., Products, Services", true, 30, 1, 1, 2, null, null });

            migrationBuilder.InsertData(
                table: "SectionItemFieldSettings",
                columns: new[] { "Id", "CreatedAt", "CreatedBy", "DefaultValue", "FieldKey", "MaxLength", "OptionsJson", "Placeholder", "SectionItemSettingId", "SortOrder", "Status", "Type", "UpdatedAt", "UpdatedBy" },
                values: new object[] { 301, new DateTime(2024, 10, 21, 10, 0, 0, 0, DateTimeKind.Unspecified), null, null, "icon", 50, null, "fa fa-cube", 30, 2, 1, 1, null, null });

            migrationBuilder.InsertData(
                table: "SectionItemFieldSettings",
                columns: new[] { "Id", "CreatedAt", "CreatedBy", "DefaultValue", "FieldKey", "IsTranslatable", "MaxLength", "OptionsJson", "Placeholder", "SectionItemSettingId", "SortOrder", "Status", "Type", "UpdatedAt", "UpdatedBy" },
                values: new object[] { 302, new DateTime(2024, 10, 21, 10, 0, 0, 0, DateTimeKind.Unspecified), null, null, "description", true, 200, null, null, 30, 3, 1, 3, null, null });

            migrationBuilder.InsertData(
                table: "SectionItemFieldSettings",
                columns: new[] { "Id", "CreatedAt", "CreatedBy", "DefaultValue", "FieldKey", "IsTranslatable", "MaxLength", "OptionsJson", "Placeholder", "Required", "SectionItemSettingId", "SortOrder", "Status", "Type", "UpdatedAt", "UpdatedBy" },
                values: new object[] { 400, new DateTime(2024, 10, 21, 10, 0, 0, 0, DateTimeKind.Unspecified), null, null, "title", true, 50, null, null, true, 40, 1, 1, 2, null, null });

            migrationBuilder.InsertData(
                table: "SectionItemFieldSettings",
                columns: new[] { "Id", "CreatedAt", "CreatedBy", "DefaultValue", "FieldKey", "MaxLength", "OptionsJson", "Placeholder", "SectionItemSettingId", "SortOrder", "Status", "Type", "UpdatedAt", "UpdatedBy" },
                values: new object[] { 401, new DateTime(2024, 10, 21, 10, 0, 0, 0, DateTimeKind.Unspecified), null, null, "icon", 50, null, "fa fa-cog", 40, 2, 1, 1, null, null });

            migrationBuilder.InsertData(
                table: "SectionItemFieldSettings",
                columns: new[] { "Id", "CreatedAt", "CreatedBy", "DefaultValue", "FieldKey", "IsTranslatable", "MaxLength", "OptionsJson", "Placeholder", "SectionItemSettingId", "SortOrder", "Status", "Type", "UpdatedAt", "UpdatedBy" },
                values: new object[] { 402, new DateTime(2024, 10, 21, 10, 0, 0, 0, DateTimeKind.Unspecified), null, null, "description", true, 300, null, null, 40, 3, 1, 3, null, null });

            migrationBuilder.InsertData(
                table: "SectionItemFieldSettings",
                columns: new[] { "Id", "CreatedAt", "CreatedBy", "DefaultValue", "FieldKey", "MaxLength", "OptionsJson", "Placeholder", "SectionItemSettingId", "SortOrder", "Status", "Type", "UpdatedAt", "UpdatedBy" },
                values: new object[] { 403, new DateTime(2024, 10, 21, 10, 0, 0, 0, DateTimeKind.Unspecified), null, null, "url", 500, null, null, 40, 4, 1, 13, null, null });

            migrationBuilder.InsertData(
                table: "SectionItemFieldSettings",
                columns: new[] { "Id", "CreatedAt", "CreatedBy", "DefaultValue", "FieldKey", "IsTranslatable", "MaxLength", "OptionsJson", "Placeholder", "Required", "SectionItemSettingId", "SortOrder", "Status", "Type", "UpdatedAt", "UpdatedBy" },
                values: new object[] { 500, new DateTime(2024, 10, 21, 10, 0, 0, 0, DateTimeKind.Unspecified), null, null, "title", true, 50, null, null, true, 50, 1, 1, 2, null, null });

            migrationBuilder.InsertData(
                table: "SectionItemFieldSettings",
                columns: new[] { "Id", "CreatedAt", "CreatedBy", "DefaultValue", "FieldKey", "MaxLength", "OptionsJson", "Placeholder", "SectionItemSettingId", "SortOrder", "Status", "Type", "UpdatedAt", "UpdatedBy" },
                values: new object[] { 501, new DateTime(2024, 10, 21, 10, 0, 0, 0, DateTimeKind.Unspecified), null, null, "icon", 50, null, "fa fa-tag", 50, 2, 1, 1, null, null });

            migrationBuilder.InsertData(
                table: "SectionItemFieldSettings",
                columns: new[] { "Id", "CreatedAt", "CreatedBy", "DefaultValue", "FieldKey", "IsTranslatable", "MaxLength", "OptionsJson", "Placeholder", "Required", "SectionItemSettingId", "SortOrder", "Status", "Type", "UpdatedAt", "UpdatedBy" },
                values: new object[] { 600, new DateTime(2024, 10, 21, 10, 0, 0, 0, DateTimeKind.Unspecified), null, null, "title", true, 100, null, null, true, 60, 1, 1, 2, null, null });

            migrationBuilder.InsertData(
                table: "SectionItemFieldSettings",
                columns: new[] { "Id", "CreatedAt", "CreatedBy", "DefaultValue", "FieldKey", "IsTranslatable", "MaxLength", "OptionsJson", "Placeholder", "SectionItemSettingId", "SortOrder", "Status", "Type", "UpdatedAt", "UpdatedBy" },
                values: new object[] { 601, new DateTime(2024, 10, 21, 10, 0, 0, 0, DateTimeKind.Unspecified), null, null, "description", true, 300, null, null, 60, 2, 1, 3, null, null });

            migrationBuilder.InsertData(
                table: "SectionItemFieldSettings",
                columns: new[] { "Id", "CreatedAt", "CreatedBy", "DefaultValue", "FieldKey", "MaxLength", "OptionsJson", "Placeholder", "SectionItemSettingId", "SortOrder", "Status", "Type", "UpdatedAt", "UpdatedBy" },
                values: new object[] { 602, new DateTime(2024, 10, 21, 10, 0, 0, 0, DateTimeKind.Unspecified), null, null, "icon", 50, null, "fa fa-check", 60, 3, 1, 1, null, null });

            migrationBuilder.InsertData(
                table: "SectionItemFieldSettings",
                columns: new[] { "Id", "CreatedAt", "CreatedBy", "DefaultValue", "FieldKey", "OptionsJson", "Placeholder", "Required", "SectionItemSettingId", "SortOrder", "Status", "Type", "UpdatedAt", "UpdatedBy" },
                values: new object[] { 700, new DateTime(2024, 10, 21, 10, 0, 0, 0, DateTimeKind.Unspecified), null, null, "image", null, null, true, 70, 1, 1, 11, null, null });

            migrationBuilder.InsertData(
                table: "SectionItemFieldSettings",
                columns: new[] { "Id", "CreatedAt", "CreatedBy", "DefaultValue", "FieldKey", "IsTranslatable", "MaxLength", "OptionsJson", "Placeholder", "Required", "SectionItemSettingId", "SortOrder", "Status", "Type", "UpdatedAt", "UpdatedBy" },
                values: new object[] { 701, new DateTime(2024, 10, 21, 10, 0, 0, 0, DateTimeKind.Unspecified), null, null, "title", true, 100, null, null, true, 70, 2, 1, 2, null, null });

            migrationBuilder.InsertData(
                table: "SectionItemFieldSettings",
                columns: new[] { "Id", "CreatedAt", "CreatedBy", "DefaultValue", "FieldKey", "IsTranslatable", "MaxLength", "OptionsJson", "Placeholder", "SectionItemSettingId", "SortOrder", "Status", "Type", "UpdatedAt", "UpdatedBy" },
                values: new object[] { 702, new DateTime(2024, 10, 21, 10, 0, 0, 0, DateTimeKind.Unspecified), null, null, "description", true, 200, null, null, 70, 3, 1, 3, null, null });

            migrationBuilder.InsertData(
                table: "SectionItemFieldSettings",
                columns: new[] { "Id", "CreatedAt", "CreatedBy", "DefaultValue", "FieldKey", "MaxLength", "OptionsJson", "Placeholder", "SectionItemSettingId", "SortOrder", "Status", "Type", "UpdatedAt", "UpdatedBy" },
                values: new object[] { 703, new DateTime(2024, 10, 21, 10, 0, 0, 0, DateTimeKind.Unspecified), null, null, "url", 500, null, null, 70, 4, 1, 13, null, null });

            migrationBuilder.InsertData(
                table: "SectionItemFieldSettings",
                columns: new[] { "Id", "CreatedAt", "CreatedBy", "DefaultValue", "FieldKey", "OptionsJson", "Placeholder", "Required", "SectionItemSettingId", "SortOrder", "Status", "Type", "UpdatedAt", "UpdatedBy" },
                values: new object[] { 800, new DateTime(2024, 10, 21, 10, 0, 0, 0, DateTimeKind.Unspecified), null, null, "image", null, null, true, 80, 1, 1, 11, null, null });

            migrationBuilder.InsertData(
                table: "SectionItemFieldSettings",
                columns: new[] { "Id", "CreatedAt", "CreatedBy", "DefaultValue", "FieldKey", "IsTranslatable", "MaxLength", "OptionsJson", "Placeholder", "SectionItemSettingId", "SortOrder", "Status", "Type", "UpdatedAt", "UpdatedBy" },
                values: new object[,]
                {
                    { 801, new DateTime(2024, 10, 21, 10, 0, 0, 0, DateTimeKind.Unspecified), null, null, "altText", true, 100, null, null, 80, 2, 1, 1, null, null },
                    { 802, new DateTime(2024, 10, 21, 10, 0, 0, 0, DateTimeKind.Unspecified), null, null, "caption", true, 200, null, null, 80, 3, 1, 1, null, null }
                });

            migrationBuilder.InsertData(
                table: "SectionItemFieldSettings",
                columns: new[] { "Id", "CreatedAt", "CreatedBy", "DefaultValue", "FieldKey", "MaxLength", "OptionsJson", "Placeholder", "SectionItemSettingId", "SortOrder", "Status", "Type", "UpdatedAt", "UpdatedBy" },
                values: new object[] { 803, new DateTime(2024, 10, 21, 10, 0, 0, 0, DateTimeKind.Unspecified), null, null, "linkUrl", 500, null, null, 80, 4, 1, 13, null, null });

            migrationBuilder.InsertData(
                table: "SectionItemFieldSettings",
                columns: new[] { "Id", "CreatedAt", "CreatedBy", "DefaultValue", "FieldKey", "IsTranslatable", "MaxLength", "OptionsJson", "Placeholder", "Required", "SectionItemSettingId", "SortOrder", "Status", "Type", "UpdatedAt", "UpdatedBy" },
                values: new object[] { 900, new DateTime(2024, 10, 21, 10, 0, 0, 0, DateTimeKind.Unspecified), null, null, "title", true, 100, null, null, true, 90, 1, 1, 2, null, null });

            migrationBuilder.InsertData(
                table: "SectionItemFieldSettings",
                columns: new[] { "Id", "CreatedAt", "CreatedBy", "DefaultValue", "FieldKey", "IsTranslatable", "MaxLength", "OptionsJson", "Placeholder", "SectionItemSettingId", "SortOrder", "Status", "Type", "UpdatedAt", "UpdatedBy" },
                values: new object[] { 901, new DateTime(2024, 10, 21, 10, 0, 0, 0, DateTimeKind.Unspecified), null, null, "description", true, 300, null, null, 90, 2, 1, 3, null, null });

            migrationBuilder.InsertData(
                table: "SectionItemFieldSettings",
                columns: new[] { "Id", "CreatedAt", "CreatedBy", "DefaultValue", "FieldKey", "MaxLength", "OptionsJson", "Placeholder", "SectionItemSettingId", "SortOrder", "Status", "Type", "UpdatedAt", "UpdatedBy" },
                values: new object[] { 902, new DateTime(2024, 10, 21, 10, 0, 0, 0, DateTimeKind.Unspecified), null, null, "icon", 50, null, "fa fa-check", 90, 3, 1, 1, null, null });

            migrationBuilder.InsertData(
                table: "SectionItemFieldSettings",
                columns: new[] { "Id", "CreatedAt", "CreatedBy", "DefaultValue", "FieldKey", "OptionsJson", "Placeholder", "SectionItemSettingId", "SortOrder", "Status", "Type", "UpdatedAt", "UpdatedBy" },
                values: new object[] { 1010, new DateTime(2024, 10, 21, 10, 0, 0, 0, DateTimeKind.Unspecified), null, null, "image", null, null, 101, 1, 1, 11, null, null });

            migrationBuilder.InsertData(
                table: "SectionItemFieldSettings",
                columns: new[] { "Id", "CreatedAt", "CreatedBy", "DefaultValue", "FieldKey", "IsTranslatable", "MaxLength", "OptionsJson", "Placeholder", "Required", "SectionItemSettingId", "SortOrder", "Status", "Type", "UpdatedAt", "UpdatedBy" },
                values: new object[] { 1011, new DateTime(2024, 10, 21, 10, 0, 0, 0, DateTimeKind.Unspecified), null, null, "title", true, 100, null, null, true, 101, 2, 1, 2, null, null });

            migrationBuilder.InsertData(
                table: "SectionItemFieldSettings",
                columns: new[] { "Id", "CreatedAt", "CreatedBy", "DefaultValue", "FieldKey", "IsTranslatable", "MaxLength", "OptionsJson", "Placeholder", "SectionItemSettingId", "SortOrder", "Status", "Type", "UpdatedAt", "UpdatedBy" },
                values: new object[,]
                {
                    { 1012, new DateTime(2024, 10, 21, 10, 0, 0, 0, DateTimeKind.Unspecified), null, null, "subtitle", true, 100, null, null, 101, 3, 1, 1, null, null },
                    { 1013, new DateTime(2024, 10, 21, 10, 0, 0, 0, DateTimeKind.Unspecified), null, null, "description", true, 500, null, null, 101, 4, 1, 3, null, null },
                    { 1014, new DateTime(2024, 10, 21, 10, 0, 0, 0, DateTimeKind.Unspecified), null, null, "buttonText", true, 50, null, null, 101, 5, 1, 1, null, null }
                });

            migrationBuilder.InsertData(
                table: "SectionItemFieldSettings",
                columns: new[] { "Id", "CreatedAt", "CreatedBy", "DefaultValue", "FieldKey", "MaxLength", "OptionsJson", "Placeholder", "SectionItemSettingId", "SortOrder", "Status", "Type", "UpdatedAt", "UpdatedBy" },
                values: new object[] { 1015, new DateTime(2024, 10, 21, 10, 0, 0, 0, DateTimeKind.Unspecified), null, null, "buttonUrl", 500, null, null, 101, 6, 1, 13, null, null });

            migrationBuilder.InsertData(
                table: "SectionItemFieldSettings",
                columns: new[] { "Id", "CreatedAt", "CreatedBy", "DefaultValue", "FieldKey", "OptionsJson", "Placeholder", "SectionItemSettingId", "SortOrder", "Status", "Type", "UpdatedAt", "UpdatedBy" },
                values: new object[] { 1100, new DateTime(2024, 10, 21, 10, 0, 0, 0, DateTimeKind.Unspecified), null, null, "image", null, null, 110, 1, 1, 11, null, null });

            migrationBuilder.InsertData(
                table: "SectionItemFieldSettings",
                columns: new[] { "Id", "CreatedAt", "CreatedBy", "DefaultValue", "FieldKey", "IsTranslatable", "MaxLength", "OptionsJson", "Placeholder", "Required", "SectionItemSettingId", "SortOrder", "Status", "Type", "UpdatedAt", "UpdatedBy" },
                values: new object[] { 1101, new DateTime(2024, 10, 21, 10, 0, 0, 0, DateTimeKind.Unspecified), null, null, "title", true, 100, null, null, true, 110, 2, 1, 2, null, null });

            migrationBuilder.InsertData(
                table: "SectionItemFieldSettings",
                columns: new[] { "Id", "CreatedAt", "CreatedBy", "DefaultValue", "FieldKey", "IsTranslatable", "MaxLength", "OptionsJson", "Placeholder", "SectionItemSettingId", "SortOrder", "Status", "Type", "UpdatedAt", "UpdatedBy" },
                values: new object[] { 1102, new DateTime(2024, 10, 21, 10, 0, 0, 0, DateTimeKind.Unspecified), null, null, "description", true, 300, null, null, 110, 3, 1, 3, null, null });

            migrationBuilder.InsertData(
                table: "SectionItemFieldSettings",
                columns: new[] { "Id", "CreatedAt", "CreatedBy", "DefaultValue", "FieldKey", "MaxLength", "OptionsJson", "Placeholder", "SectionItemSettingId", "SortOrder", "Status", "Type", "UpdatedAt", "UpdatedBy" },
                values: new object[] { 1103, new DateTime(2024, 10, 21, 10, 0, 0, 0, DateTimeKind.Unspecified), null, null, "url", 500, null, null, 110, 4, 1, 13, null, null });

            migrationBuilder.InsertData(
                table: "SectionItemFieldSettings",
                columns: new[] { "Id", "CreatedAt", "CreatedBy", "DefaultValue", "FieldKey", "IsTranslatable", "MaxLength", "OptionsJson", "Placeholder", "Required", "SectionItemSettingId", "SortOrder", "Status", "Type", "UpdatedAt", "UpdatedBy" },
                values: new object[,]
                {
                    { 1200, new DateTime(2024, 10, 21, 10, 0, 0, 0, DateTimeKind.Unspecified), null, null, "title", true, 100, null, null, true, 120, 1, 1, 2, null, null },
                    { 1201, new DateTime(2024, 10, 21, 10, 0, 0, 0, DateTimeKind.Unspecified), null, null, "content", true, 1000, null, null, true, 120, 2, 1, 4, null, null }
                });

            migrationBuilder.InsertData(
                table: "SectionItemFieldSettings",
                columns: new[] { "Id", "CreatedAt", "CreatedBy", "DefaultValue", "FieldKey", "OptionsJson", "Placeholder", "SectionItemSettingId", "SortOrder", "Status", "Type", "UpdatedAt", "UpdatedBy" },
                values: new object[] { 1202, new DateTime(2024, 10, 21, 10, 0, 0, 0, DateTimeKind.Unspecified), null, "false", "isOpen", null, null, 120, 3, 1, 5, null, null });

            migrationBuilder.InsertData(
                table: "SectionItemFieldSettings",
                columns: new[] { "Id", "CreatedAt", "CreatedBy", "DefaultValue", "FieldKey", "IsTranslatable", "MaxLength", "OptionsJson", "Placeholder", "Required", "SectionItemSettingId", "SortOrder", "Status", "Type", "UpdatedAt", "UpdatedBy" },
                values: new object[] { 1300, new DateTime(2024, 10, 21, 10, 0, 0, 0, DateTimeKind.Unspecified), null, null, "title", true, 50, null, null, true, 130, 1, 1, 2, null, null });

            migrationBuilder.InsertData(
                table: "SectionItemFieldSettings",
                columns: new[] { "Id", "CreatedAt", "CreatedBy", "DefaultValue", "FieldKey", "MaxLength", "OptionsJson", "Placeholder", "SectionItemSettingId", "SortOrder", "Status", "Type", "UpdatedAt", "UpdatedBy" },
                values: new object[] { 1301, new DateTime(2024, 10, 21, 10, 0, 0, 0, DateTimeKind.Unspecified), null, null, "icon", 50, null, "fa fa-info", 130, 2, 1, 1, null, null });

            migrationBuilder.InsertData(
                table: "SectionItemFieldSettings",
                columns: new[] { "Id", "CreatedAt", "CreatedBy", "DefaultValue", "FieldKey", "IsTranslatable", "MaxLength", "OptionsJson", "Placeholder", "Required", "SectionItemSettingId", "SortOrder", "Status", "Type", "UpdatedAt", "UpdatedBy" },
                values: new object[] { 1302, new DateTime(2024, 10, 21, 10, 0, 0, 0, DateTimeKind.Unspecified), null, null, "content", true, 1000, null, null, true, 130, 3, 1, 4, null, null });

            migrationBuilder.InsertData(
                table: "SectionItemSettingTranslations",
                columns: new[] { "Id", "CreatedAt", "CreatedBy", "Description", "LanguageId", "SectionItemSettingId", "Status", "Title", "UpdatedAt", "UpdatedBy" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 10, 21, 10, 0, 0, 0, DateTimeKind.Unspecified), null, "Web sitesi logosu", 1, 1, 1, "Logo", null, null },
                    { 2, new DateTime(2024, 10, 21, 10, 0, 0, 0, DateTimeKind.Unspecified), null, "Website Logo", 2, 1, 1, "Logo", null, null },
                    { 3, new DateTime(2024, 10, 21, 10, 0, 0, 0, DateTimeKind.Unspecified), null, "Navigasyon menü öğeleri", 1, 2, 1, "Menü Öğeleri", null, null },
                    { 4, new DateTime(2024, 10, 21, 10, 0, 0, 0, DateTimeKind.Unspecified), null, "Navigation menu items", 2, 2, 1, "Menu Items", null, null },
                    { 10, new DateTime(2024, 10, 21, 10, 0, 0, 0, DateTimeKind.Unspecified), null, "Carousel slaytı", 1, 10, 1, "Slayt", null, null },
                    { 11, new DateTime(2024, 10, 21, 10, 0, 0, 0, DateTimeKind.Unspecified), null, "Carousel slide", 2, 10, 1, "Slide", null, null },
                    { 20, new DateTime(2024, 10, 21, 10, 0, 0, 0, DateTimeKind.Unspecified), null, "Genel içerik öğesi", 1, 20, 1, "İçerik Öğesi", null, null },
                    { 21, new DateTime(2024, 10, 21, 10, 0, 0, 0, DateTimeKind.Unspecified), null, "General content item", 2, 20, 1, "Content Item", null, null },
                    { 300, new DateTime(2024, 10, 21, 10, 0, 0, 0, DateTimeKind.Unspecified), null, "Geniş açılır menü kategorisi", 1, 30, 1, "Mega Menü Kategorisi", null, null },
                    { 301, new DateTime(2024, 10, 21, 10, 0, 0, 0, DateTimeKind.Unspecified), null, "Large dropdown menu category", 2, 30, 1, "Mega Menu Category", null, null },
                    { 400, new DateTime(2024, 10, 21, 10, 0, 0, 0, DateTimeKind.Unspecified), null, "Hizmet navigasyon sekmesi", 1, 40, 1, "Hizmet Sekmesi", null, null },
                    { 401, new DateTime(2024, 10, 21, 10, 0, 0, 0, DateTimeKind.Unspecified), null, "Service navigation tab", 2, 40, 1, "Service Tab", null, null },
                    { 500, new DateTime(2024, 10, 21, 10, 0, 0, 0, DateTimeKind.Unspecified), null, "Menü kategorisi", 1, 50, 1, "Kategori", null, null },
                    { 501, new DateTime(2024, 10, 21, 10, 0, 0, 0, DateTimeKind.Unspecified), null, "Menu category", 2, 50, 1, "Category", null, null },
                    { 600, new DateTime(2024, 10, 21, 10, 0, 0, 0, DateTimeKind.Unspecified), null, "Sıralı adım öğesi", 1, 60, 1, "Adım", null, null },
                    { 601, new DateTime(2024, 10, 21, 10, 0, 0, 0, DateTimeKind.Unspecified), null, "Sequential step item", 2, 60, 1, "Step", null, null },
                    { 700, new DateTime(2024, 10, 21, 10, 0, 0, 0, DateTimeKind.Unspecified), null, "Izgara düzeninde öğe", 1, 70, 1, "Grid Öğesi", null, null },
                    { 701, new DateTime(2024, 10, 21, 10, 0, 0, 0, DateTimeKind.Unspecified), null, "Grid layout item", 2, 70, 1, "Grid Item", null, null },
                    { 800, new DateTime(2024, 10, 21, 10, 0, 0, 0, DateTimeKind.Unspecified), null, "Masonry galeri resmi", 1, 80, 1, "Masonry Resim", null, null },
                    { 801, new DateTime(2024, 10, 21, 10, 0, 0, 0, DateTimeKind.Unspecified), null, "Masonry gallery image", 2, 80, 1, "Masonry Image", null, null },
                    { 900, new DateTime(2024, 10, 21, 10, 0, 0, 0, DateTimeKind.Unspecified), null, "Liste öğesi", 1, 90, 1, "Liste Öğesi", null, null },
                    { 901, new DateTime(2024, 10, 21, 10, 0, 0, 0, DateTimeKind.Unspecified), null, "List item", 2, 90, 1, "List Item", null, null },
                    { 1010, new DateTime(2024, 10, 21, 10, 0, 0, 0, DateTimeKind.Unspecified), null, "Öne çıkan tek öğe", 1, 101, 1, "Tekli Öğe", null, null },
                    { 1011, new DateTime(2024, 10, 21, 10, 0, 0, 0, DateTimeKind.Unspecified), null, "Featured single item", 2, 101, 1, "Single Item", null, null },
                    { 1100, new DateTime(2024, 10, 21, 10, 0, 0, 0, DateTimeKind.Unspecified), null, "Çoklu içerik öğesi", 1, 110, 1, "Çoklu Öğe", null, null },
                    { 1101, new DateTime(2024, 10, 21, 10, 0, 0, 0, DateTimeKind.Unspecified), null, "Multiple content item", 2, 110, 1, "Multi Item", null, null },
                    { 1200, new DateTime(2024, 10, 21, 10, 0, 0, 0, DateTimeKind.Unspecified), null, "Genişletilebilir panel", 1, 120, 1, "Akordeon Paneli", null, null },
                    { 1201, new DateTime(2024, 10, 21, 10, 0, 0, 0, DateTimeKind.Unspecified), null, "Expandable panel", 2, 120, 1, "Accordion Panel", null, null },
                    { 1300, new DateTime(2024, 10, 21, 10, 0, 0, 0, DateTimeKind.Unspecified), null, "İçerik sekmesi", 1, 130, 1, "Sekme", null, null },
                    { 1301, new DateTime(2024, 10, 21, 10, 0, 0, 0, DateTimeKind.Unspecified), null, "Content tab", 2, 130, 1, "Tab", null, null }
                });

            migrationBuilder.InsertData(
                table: "SectionItemSettings",
                columns: new[] { "Id", "AllowDynamicSectionItems", "ConfigurationKey", "CreatedAt", "CreatedBy", "ItemType", "ParentSettingId", "SortOrder", "Status", "TemplateId", "TemplateId1", "UpdatedAt", "UpdatedBy" },
                values: new object[,]
                {
                    { 3, true, "dropdown-link", new DateTime(2024, 10, 21, 10, 0, 0, 0, DateTimeKind.Unspecified), null, 7, 2, 3, 1, 1, null, null, null },
                    { 31, true, "mega-menu-link", new DateTime(2024, 10, 21, 10, 0, 0, 0, DateTimeKind.Unspecified), null, 7, 30, 7, 1, 2, null, null, null },
                    { 51, true, "category-item", new DateTime(2024, 10, 21, 10, 0, 0, 0, DateTimeKind.Unspecified), null, 7, 50, 10, 1, 4, null, null, null }
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

            migrationBuilder.InsertData(
                table: "SectionItemFieldSettingTranslations",
                columns: new[] { "Id", "CreatedAt", "CreatedBy", "Description", "Label", "LanguageId", "SectionItemFieldSettingId", "Status", "UpdatedAt", "UpdatedBy" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 10, 21, 10, 0, 0, 0, DateTimeKind.Unspecified), null, "Logo resminizi yükleyin", "Logo Resmi", 1, 1, 1, null, null },
                    { 2, new DateTime(2024, 10, 21, 10, 0, 0, 0, DateTimeKind.Unspecified), null, "Upload your logo image", "Logo Image", 2, 1, 1, null, null },
                    { 3, new DateTime(2024, 10, 21, 10, 0, 0, 0, DateTimeKind.Unspecified), null, "Alternative text for accessibility", "Alt Text", 2, 2, 1, null, null },
                    { 4, new DateTime(2024, 10, 21, 10, 0, 0, 0, DateTimeKind.Unspecified), null, "Erişilebilirlik için alternatif metin", "Alternatif Metin", 1, 2, 1, null, null },
                    { 5, new DateTime(2024, 10, 21, 10, 0, 0, 0, DateTimeKind.Unspecified), null, "Where logo should link to", "Link URL", 2, 3, 1, null, null },
                    { 6, new DateTime(2024, 10, 21, 10, 0, 0, 0, DateTimeKind.Unspecified), null, "Logonun yönlendireceği adres", "Bağlantı URL", 1, 3, 1, null, null },
                    { 7, new DateTime(2024, 10, 21, 10, 0, 0, 0, DateTimeKind.Unspecified), null, "Title of the menu item", "Menu Title", 2, 4, 1, null, null },
                    { 8, new DateTime(2024, 10, 21, 10, 0, 0, 0, DateTimeKind.Unspecified), null, "Menü öğesinin başlığı", "Menü Başlığı", 1, 4, 1, null, null },
                    { 9, new DateTime(2024, 10, 21, 10, 0, 0, 0, DateTimeKind.Unspecified), null, "FontAwesome icon class", "Icon (Optional)", 2, 5, 1, null, null },
                    { 10, new DateTime(2024, 10, 21, 10, 0, 0, 0, DateTimeKind.Unspecified), null, "FontAwesome ikon sınıfı", "İkon (Opsiyonel)", 1, 5, 1, null, null },
                    { 100, new DateTime(2024, 10, 21, 10, 0, 0, 0, DateTimeKind.Unspecified), null, "Slayt için resim", "Slayt Resmi", 1, 100, 1, null, null },
                    { 101, new DateTime(2024, 10, 21, 10, 0, 0, 0, DateTimeKind.Unspecified), null, "Image for the slide", "Slide Image", 2, 100, 1, null, null },
                    { 102, new DateTime(2024, 10, 21, 10, 0, 0, 0, DateTimeKind.Unspecified), null, "Slayt başlığı", "Slayt Başlığı", 1, 101, 1, null, null },
                    { 103, new DateTime(2024, 10, 21, 10, 0, 0, 0, DateTimeKind.Unspecified), null, "Title for the slide", "Slide Title", 2, 101, 1, null, null },
                    { 104, new DateTime(2024, 10, 21, 10, 0, 0, 0, DateTimeKind.Unspecified), null, "Slayt açıklaması", "Slayt Açıklaması", 1, 102, 1, null, null },
                    { 105, new DateTime(2024, 10, 21, 10, 0, 0, 0, DateTimeKind.Unspecified), null, "Description for the slide", "Slide Description", 2, 102, 1, null, null },
                    { 106, new DateTime(2024, 10, 21, 10, 0, 0, 0, DateTimeKind.Unspecified), null, "Buton metni", "Buton Metni", 1, 103, 1, null, null },
                    { 107, new DateTime(2024, 10, 21, 10, 0, 0, 0, DateTimeKind.Unspecified), null, "Text for the button", "Button Text", 2, 103, 1, null, null },
                    { 108, new DateTime(2024, 10, 21, 10, 0, 0, 0, DateTimeKind.Unspecified), null, "Butonun yönlendirileceği adres", "Buton URL", 1, 104, 1, null, null },
                    { 109, new DateTime(2024, 10, 21, 10, 0, 0, 0, DateTimeKind.Unspecified), null, "URL for the button", "Button URL", 2, 104, 1, null, null },
                    { 200, new DateTime(2024, 10, 21, 10, 0, 0, 0, DateTimeKind.Unspecified), null, "Öğe başlığı", "Başlık", 1, 200, 1, null, null },
                    { 201, new DateTime(2024, 10, 21, 10, 0, 0, 0, DateTimeKind.Unspecified), null, "Item title", "Title", 2, 200, 1, null, null },
                    { 202, new DateTime(2024, 10, 21, 10, 0, 0, 0, DateTimeKind.Unspecified), null, "Öğe açıklaması", "Açıklama", 1, 201, 1, null, null },
                    { 203, new DateTime(2024, 10, 21, 10, 0, 0, 0, DateTimeKind.Unspecified), null, "Item description", "Description", 2, 201, 1, null, null },
                    { 3000, new DateTime(2024, 10, 21, 10, 0, 0, 0, DateTimeKind.Unspecified), null, "Kategori başlığı", "Başlık", 1, 300, 1, null, null },
                    { 3001, new DateTime(2024, 10, 21, 10, 0, 0, 0, DateTimeKind.Unspecified), null, "Category title", "Title", 2, 300, 1, null, null },
                    { 3002, new DateTime(2024, 10, 21, 10, 0, 0, 0, DateTimeKind.Unspecified), null, "Kategori ikonu", "İkon", 1, 301, 1, null, null },
                    { 3003, new DateTime(2024, 10, 21, 10, 0, 0, 0, DateTimeKind.Unspecified), null, "Category icon", "Icon", 2, 301, 1, null, null },
                    { 3004, new DateTime(2024, 10, 21, 10, 0, 0, 0, DateTimeKind.Unspecified), null, "Kategori açıklaması", "Açıklama", 1, 302, 1, null, null },
                    { 3005, new DateTime(2024, 10, 21, 10, 0, 0, 0, DateTimeKind.Unspecified), null, "Category description", "Description", 2, 302, 1, null, null },
                    { 4000, new DateTime(2024, 10, 21, 10, 0, 0, 0, DateTimeKind.Unspecified), null, "Sekme başlığı", "Başlık", 1, 400, 1, null, null },
                    { 4001, new DateTime(2024, 10, 21, 10, 0, 0, 0, DateTimeKind.Unspecified), null, "Tab title", "Title", 2, 400, 1, null, null },
                    { 4002, new DateTime(2024, 10, 21, 10, 0, 0, 0, DateTimeKind.Unspecified), null, "Sekme ikonu", "İkon", 1, 401, 1, null, null },
                    { 4003, new DateTime(2024, 10, 21, 10, 0, 0, 0, DateTimeKind.Unspecified), null, "Tab icon", "Icon", 2, 401, 1, null, null },
                    { 4004, new DateTime(2024, 10, 21, 10, 0, 0, 0, DateTimeKind.Unspecified), null, "Sekme açıklaması", "Açıklama", 1, 402, 1, null, null },
                    { 4005, new DateTime(2024, 10, 21, 10, 0, 0, 0, DateTimeKind.Unspecified), null, "Tab description", "Description", 2, 402, 1, null, null },
                    { 4006, new DateTime(2024, 10, 21, 10, 0, 0, 0, DateTimeKind.Unspecified), null, "Sekme bağlantısı", "URL", 1, 403, 1, null, null },
                    { 4007, new DateTime(2024, 10, 21, 10, 0, 0, 0, DateTimeKind.Unspecified), null, "Tab link", "URL", 2, 403, 1, null, null },
                    { 5000, new DateTime(2024, 10, 21, 10, 0, 0, 0, DateTimeKind.Unspecified), null, "Kategori başlığı", "Başlık", 1, 500, 1, null, null },
                    { 5001, new DateTime(2024, 10, 21, 10, 0, 0, 0, DateTimeKind.Unspecified), null, "Category title", "Title", 2, 500, 1, null, null },
                    { 5002, new DateTime(2024, 10, 21, 10, 0, 0, 0, DateTimeKind.Unspecified), null, "Kategori ikonu", "İkon", 1, 501, 1, null, null },
                    { 5003, new DateTime(2024, 10, 21, 10, 0, 0, 0, DateTimeKind.Unspecified), null, "Category icon", "Icon", 2, 501, 1, null, null },
                    { 6000, new DateTime(2024, 10, 21, 10, 0, 0, 0, DateTimeKind.Unspecified), null, "Adım başlığı", "Başlık", 1, 600, 1, null, null },
                    { 6001, new DateTime(2024, 10, 21, 10, 0, 0, 0, DateTimeKind.Unspecified), null, "Step title", "Title", 2, 600, 1, null, null },
                    { 6002, new DateTime(2024, 10, 21, 10, 0, 0, 0, DateTimeKind.Unspecified), null, "Adım açıklaması", "Açıklama", 1, 601, 1, null, null },
                    { 6003, new DateTime(2024, 10, 21, 10, 0, 0, 0, DateTimeKind.Unspecified), null, "Step description", "Description", 2, 601, 1, null, null },
                    { 6004, new DateTime(2024, 10, 21, 10, 0, 0, 0, DateTimeKind.Unspecified), null, "Adım ikonu", "İkon", 1, 602, 1, null, null },
                    { 6005, new DateTime(2024, 10, 21, 10, 0, 0, 0, DateTimeKind.Unspecified), null, "Step icon", "Icon", 2, 602, 1, null, null },
                    { 7000, new DateTime(2024, 10, 21, 10, 0, 0, 0, DateTimeKind.Unspecified), null, "Grid resmi", "Resim", 1, 700, 1, null, null },
                    { 7001, new DateTime(2024, 10, 21, 10, 0, 0, 0, DateTimeKind.Unspecified), null, "Grid image", "Image", 2, 700, 1, null, null },
                    { 7002, new DateTime(2024, 10, 21, 10, 0, 0, 0, DateTimeKind.Unspecified), null, "Öğe başlığı", "Başlık", 1, 701, 1, null, null },
                    { 7003, new DateTime(2024, 10, 21, 10, 0, 0, 0, DateTimeKind.Unspecified), null, "Item title", "Title", 2, 701, 1, null, null },
                    { 7004, new DateTime(2024, 10, 21, 10, 0, 0, 0, DateTimeKind.Unspecified), null, "Öğe açıklaması", "Açıklama", 1, 702, 1, null, null },
                    { 7005, new DateTime(2024, 10, 21, 10, 0, 0, 0, DateTimeKind.Unspecified), null, "Item description", "Description", 2, 702, 1, null, null },
                    { 7006, new DateTime(2024, 10, 21, 10, 0, 0, 0, DateTimeKind.Unspecified), null, "Bağlantı adresi", "URL", 1, 703, 1, null, null },
                    { 7007, new DateTime(2024, 10, 21, 10, 0, 0, 0, DateTimeKind.Unspecified), null, "Link URL", "URL", 2, 703, 1, null, null },
                    { 8000, new DateTime(2024, 10, 21, 10, 0, 0, 0, DateTimeKind.Unspecified), null, "Galeri resmi", "Resim", 1, 800, 1, null, null },
                    { 8001, new DateTime(2024, 10, 21, 10, 0, 0, 0, DateTimeKind.Unspecified), null, "Gallery image", "Image", 2, 800, 1, null, null },
                    { 8002, new DateTime(2024, 10, 21, 10, 0, 0, 0, DateTimeKind.Unspecified), null, "Resim alt metni", "Alt Metni", 1, 801, 1, null, null },
                    { 8003, new DateTime(2024, 10, 21, 10, 0, 0, 0, DateTimeKind.Unspecified), null, "Image alt text", "Alt Text", 2, 801, 1, null, null },
                    { 8004, new DateTime(2024, 10, 21, 10, 0, 0, 0, DateTimeKind.Unspecified), null, "Resim başlığı", "Başlık", 1, 802, 1, null, null },
                    { 8005, new DateTime(2024, 10, 21, 10, 0, 0, 0, DateTimeKind.Unspecified), null, "Image caption", "Caption", 2, 802, 1, null, null },
                    { 8006, new DateTime(2024, 10, 21, 10, 0, 0, 0, DateTimeKind.Unspecified), null, "Resim bağlantısı", "Bağlantı", 1, 803, 1, null, null },
                    { 8007, new DateTime(2024, 10, 21, 10, 0, 0, 0, DateTimeKind.Unspecified), null, "Image link", "Link URL", 2, 803, 1, null, null },
                    { 9000, new DateTime(2024, 10, 21, 10, 0, 0, 0, DateTimeKind.Unspecified), null, "Liste öğesi başlığı", "Başlık", 1, 900, 1, null, null },
                    { 9001, new DateTime(2024, 10, 21, 10, 0, 0, 0, DateTimeKind.Unspecified), null, "List item title", "Title", 2, 900, 1, null, null },
                    { 9002, new DateTime(2024, 10, 21, 10, 0, 0, 0, DateTimeKind.Unspecified), null, "Liste öğesi açıklaması", "Açıklama", 1, 901, 1, null, null },
                    { 9003, new DateTime(2024, 10, 21, 10, 0, 0, 0, DateTimeKind.Unspecified), null, "List item description", "Description", 2, 901, 1, null, null },
                    { 9004, new DateTime(2024, 10, 21, 10, 0, 0, 0, DateTimeKind.Unspecified), null, "Liste ikonu", "İkon", 1, 902, 1, null, null },
                    { 9005, new DateTime(2024, 10, 21, 10, 0, 0, 0, DateTimeKind.Unspecified), null, "List icon", "Icon", 2, 902, 1, null, null },
                    { 10100, new DateTime(2024, 10, 21, 10, 0, 0, 0, DateTimeKind.Unspecified), null, "Öne çıkan resim", "Resim", 1, 1010, 1, null, null },
                    { 10101, new DateTime(2024, 10, 21, 10, 0, 0, 0, DateTimeKind.Unspecified), null, "Featured image", "Image", 2, 1010, 1, null, null },
                    { 10102, new DateTime(2024, 10, 21, 10, 0, 0, 0, DateTimeKind.Unspecified), null, "Ana başlık", "Başlık", 1, 1011, 1, null, null },
                    { 10103, new DateTime(2024, 10, 21, 10, 0, 0, 0, DateTimeKind.Unspecified), null, "Main title", "Title", 2, 1011, 1, null, null },
                    { 10104, new DateTime(2024, 10, 21, 10, 0, 0, 0, DateTimeKind.Unspecified), null, "İkincil başlık", "Alt Başlık", 1, 1012, 1, null, null },
                    { 10105, new DateTime(2024, 10, 21, 10, 0, 0, 0, DateTimeKind.Unspecified), null, "Secondary title", "Subtitle", 2, 1012, 1, null, null },
                    { 10106, new DateTime(2024, 10, 21, 10, 0, 0, 0, DateTimeKind.Unspecified), null, "Detaylı açıklama", "Açıklama", 1, 1013, 1, null, null },
                    { 10107, new DateTime(2024, 10, 21, 10, 0, 0, 0, DateTimeKind.Unspecified), null, "Detailed description", "Description", 2, 1013, 1, null, null },
                    { 10108, new DateTime(2024, 10, 21, 10, 0, 0, 0, DateTimeKind.Unspecified), null, "Aksiyon buton metni", "Buton Metni", 1, 1014, 1, null, null },
                    { 10109, new DateTime(2024, 10, 21, 10, 0, 0, 0, DateTimeKind.Unspecified), null, "Action button text", "Button Text", 2, 1014, 1, null, null },
                    { 10110, new DateTime(2024, 10, 21, 10, 0, 0, 0, DateTimeKind.Unspecified), null, "Buton bağlantısı", "Buton URL", 1, 1015, 1, null, null },
                    { 10111, new DateTime(2024, 10, 21, 10, 0, 0, 0, DateTimeKind.Unspecified), null, "Button link", "Button URL", 2, 1015, 1, null, null },
                    { 11000, new DateTime(2024, 10, 21, 10, 0, 0, 0, DateTimeKind.Unspecified), null, "Öğe resmi", "Resim", 1, 1100, 1, null, null },
                    { 11001, new DateTime(2024, 10, 21, 10, 0, 0, 0, DateTimeKind.Unspecified), null, "Item image", "Image", 2, 1100, 1, null, null },
                    { 11002, new DateTime(2024, 10, 21, 10, 0, 0, 0, DateTimeKind.Unspecified), null, "Öğe başlığı", "Başlık", 1, 1101, 1, null, null },
                    { 11003, new DateTime(2024, 10, 21, 10, 0, 0, 0, DateTimeKind.Unspecified), null, "Item title", "Title", 2, 1101, 1, null, null },
                    { 11004, new DateTime(2024, 10, 21, 10, 0, 0, 0, DateTimeKind.Unspecified), null, "Öğe açıklaması", "Açıklama", 1, 1102, 1, null, null },
                    { 11005, new DateTime(2024, 10, 21, 10, 0, 0, 0, DateTimeKind.Unspecified), null, "Item description", "Description", 2, 1102, 1, null, null },
                    { 11006, new DateTime(2024, 10, 21, 10, 0, 0, 0, DateTimeKind.Unspecified), null, "Öğe bağlantısı", "URL", 1, 1103, 1, null, null },
                    { 11007, new DateTime(2024, 10, 21, 10, 0, 0, 0, DateTimeKind.Unspecified), null, "Item link", "URL", 2, 1103, 1, null, null },
                    { 12000, new DateTime(2024, 10, 21, 10, 0, 0, 0, DateTimeKind.Unspecified), null, "Panel başlığı", "Başlık", 1, 1200, 1, null, null },
                    { 12001, new DateTime(2024, 10, 21, 10, 0, 0, 0, DateTimeKind.Unspecified), null, "Panel title", "Title", 2, 1200, 1, null, null },
                    { 12002, new DateTime(2024, 10, 21, 10, 0, 0, 0, DateTimeKind.Unspecified), null, "Panel içeriği", "İçerik", 1, 1201, 1, null, null },
                    { 12003, new DateTime(2024, 10, 21, 10, 0, 0, 0, DateTimeKind.Unspecified), null, "Panel content", "Content", 2, 1201, 1, null, null },
                    { 12004, new DateTime(2024, 10, 21, 10, 0, 0, 0, DateTimeKind.Unspecified), null, "Başlangıçta açık", "Açık Mı?", 1, 1202, 1, null, null },
                    { 12005, new DateTime(2024, 10, 21, 10, 0, 0, 0, DateTimeKind.Unspecified), null, "Initially open", "Is Open?", 2, 1202, 1, null, null },
                    { 13000, new DateTime(2024, 10, 21, 10, 0, 0, 0, DateTimeKind.Unspecified), null, "Sekme başlığı", "Başlık", 1, 1300, 1, null, null },
                    { 13001, new DateTime(2024, 10, 21, 10, 0, 0, 0, DateTimeKind.Unspecified), null, "Tab title", "Title", 2, 1300, 1, null, null },
                    { 13002, new DateTime(2024, 10, 21, 10, 0, 0, 0, DateTimeKind.Unspecified), null, "Sekme ikonu", "İkon", 1, 1301, 1, null, null },
                    { 13003, new DateTime(2024, 10, 21, 10, 0, 0, 0, DateTimeKind.Unspecified), null, "Tab icon", "Icon", 2, 1301, 1, null, null },
                    { 13004, new DateTime(2024, 10, 21, 10, 0, 0, 0, DateTimeKind.Unspecified), null, "Sekme içeriği", "İçerik", 1, 1302, 1, null, null },
                    { 13005, new DateTime(2024, 10, 21, 10, 0, 0, 0, DateTimeKind.Unspecified), null, "Tab content", "Content", 2, 1302, 1, null, null }
                });

            migrationBuilder.InsertData(
                table: "SectionItemFieldSettings",
                columns: new[] { "Id", "CreatedAt", "CreatedBy", "DefaultValue", "FieldKey", "IsTranslatable", "MaxLength", "OptionsJson", "Placeholder", "Required", "SectionItemSettingId", "SortOrder", "Status", "Type", "UpdatedAt", "UpdatedBy" },
                values: new object[] { 6, new DateTime(2024, 10, 21, 10, 0, 0, 0, DateTimeKind.Unspecified), null, null, "title", true, 50, null, "e.g., Home, About", true, 3, 1, 1, 2, null, null });

            migrationBuilder.InsertData(
                table: "SectionItemFieldSettings",
                columns: new[] { "Id", "CreatedAt", "CreatedBy", "DefaultValue", "FieldKey", "MaxLength", "OptionsJson", "Placeholder", "Required", "SectionItemSettingId", "SortOrder", "Status", "Type", "UpdatedAt", "UpdatedBy" },
                values: new object[] { 7, new DateTime(2024, 10, 21, 10, 0, 0, 0, DateTimeKind.Unspecified), null, null, "url", 500, null, "/page-url or https://example.com", true, 3, 2, 1, 13, null, null });

            migrationBuilder.InsertData(
                table: "SectionItemFieldSettings",
                columns: new[] { "Id", "CreatedAt", "CreatedBy", "DefaultValue", "FieldKey", "MaxLength", "OptionsJson", "Placeholder", "SectionItemSettingId", "SortOrder", "Status", "Type", "UpdatedAt", "UpdatedBy" },
                values: new object[] { 8, new DateTime(2024, 10, 21, 10, 0, 0, 0, DateTimeKind.Unspecified), null, null, "icon", 50, null, "fa fa-home", 3, 3, 1, 1, null, null });

            migrationBuilder.InsertData(
                table: "SectionItemFieldSettings",
                columns: new[] { "Id", "CreatedAt", "CreatedBy", "DefaultValue", "FieldKey", "OptionsJson", "Placeholder", "SectionItemSettingId", "SortOrder", "Status", "Type", "UpdatedAt", "UpdatedBy" },
                values: new object[] { 9, new DateTime(2024, 10, 21, 10, 0, 0, 0, DateTimeKind.Unspecified), null, "false", "openInNewTab", null, null, 3, 4, 1, 5, null, null });

            migrationBuilder.InsertData(
                table: "SectionItemFieldSettings",
                columns: new[] { "Id", "CreatedAt", "CreatedBy", "DefaultValue", "FieldKey", "IsTranslatable", "MaxLength", "OptionsJson", "Placeholder", "Required", "SectionItemSettingId", "SortOrder", "Status", "Type", "UpdatedAt", "UpdatedBy" },
                values: new object[] { 310, new DateTime(2024, 10, 21, 10, 0, 0, 0, DateTimeKind.Unspecified), null, null, "title", true, 50, null, null, true, 31, 1, 1, 2, null, null });

            migrationBuilder.InsertData(
                table: "SectionItemFieldSettings",
                columns: new[] { "Id", "CreatedAt", "CreatedBy", "DefaultValue", "FieldKey", "MaxLength", "OptionsJson", "Placeholder", "Required", "SectionItemSettingId", "SortOrder", "Status", "Type", "UpdatedAt", "UpdatedBy" },
                values: new object[] { 311, new DateTime(2024, 10, 21, 10, 0, 0, 0, DateTimeKind.Unspecified), null, null, "url", 500, null, null, true, 31, 2, 1, 13, null, null });

            migrationBuilder.InsertData(
                table: "SectionItemFieldSettings",
                columns: new[] { "Id", "CreatedAt", "CreatedBy", "DefaultValue", "FieldKey", "MaxLength", "OptionsJson", "Placeholder", "SectionItemSettingId", "SortOrder", "Status", "Type", "UpdatedAt", "UpdatedBy" },
                values: new object[] { 312, new DateTime(2024, 10, 21, 10, 0, 0, 0, DateTimeKind.Unspecified), null, null, "icon", 50, null, "fa fa-arrow-right", 31, 3, 1, 1, null, null });

            migrationBuilder.InsertData(
                table: "SectionItemFieldSettings",
                columns: new[] { "Id", "CreatedAt", "CreatedBy", "DefaultValue", "FieldKey", "IsTranslatable", "MaxLength", "OptionsJson", "Placeholder", "Required", "SectionItemSettingId", "SortOrder", "Status", "Type", "UpdatedAt", "UpdatedBy" },
                values: new object[] { 510, new DateTime(2024, 10, 21, 10, 0, 0, 0, DateTimeKind.Unspecified), null, null, "title", true, 50, null, null, true, 51, 1, 1, 2, null, null });

            migrationBuilder.InsertData(
                table: "SectionItemFieldSettings",
                columns: new[] { "Id", "CreatedAt", "CreatedBy", "DefaultValue", "FieldKey", "MaxLength", "OptionsJson", "Placeholder", "Required", "SectionItemSettingId", "SortOrder", "Status", "Type", "UpdatedAt", "UpdatedBy" },
                values: new object[] { 511, new DateTime(2024, 10, 21, 10, 0, 0, 0, DateTimeKind.Unspecified), null, null, "url", 500, null, null, true, 51, 2, 1, 13, null, null });

            migrationBuilder.InsertData(
                table: "SectionItemFieldSettings",
                columns: new[] { "Id", "CreatedAt", "CreatedBy", "DefaultValue", "FieldKey", "IsTranslatable", "MaxLength", "OptionsJson", "Placeholder", "SectionItemSettingId", "SortOrder", "Status", "Type", "UpdatedAt", "UpdatedBy" },
                values: new object[] { 512, new DateTime(2024, 10, 21, 10, 0, 0, 0, DateTimeKind.Unspecified), null, null, "badge", true, 20, null, "New, Hot, etc.", 51, 3, 1, 1, null, null });

            migrationBuilder.InsertData(
                table: "SectionItemSettingTranslations",
                columns: new[] { "Id", "CreatedAt", "CreatedBy", "Description", "LanguageId", "SectionItemSettingId", "Status", "Title", "UpdatedAt", "UpdatedBy" },
                values: new object[,]
                {
                    { 5, new DateTime(2024, 10, 21, 10, 0, 0, 0, DateTimeKind.Unspecified), null, "Açılır menüdeki bağlantı", 1, 3, 1, "Açılır Menü Linki", null, null },
                    { 6, new DateTime(2024, 10, 21, 10, 0, 0, 0, DateTimeKind.Unspecified), null, "Link in dropdown menu", 2, 3, 1, "Dropdown Link", null, null },
                    { 302, new DateTime(2024, 10, 21, 10, 0, 0, 0, DateTimeKind.Unspecified), null, "Kategori içindeki bağlantı", 1, 31, 1, "Mega Menü Linki", null, null },
                    { 303, new DateTime(2024, 10, 21, 10, 0, 0, 0, DateTimeKind.Unspecified), null, "Link within category", 2, 31, 1, "Mega Menu Link", null, null },
                    { 502, new DateTime(2024, 10, 21, 10, 0, 0, 0, DateTimeKind.Unspecified), null, "Kategori altındaki öğe", 1, 51, 1, "Kategori Öğesi", null, null },
                    { 503, new DateTime(2024, 10, 21, 10, 0, 0, 0, DateTimeKind.Unspecified), null, "Item under category", 2, 51, 1, "Category Item", null, null }
                });

            migrationBuilder.InsertData(
                table: "SectionItemFieldSettingTranslations",
                columns: new[] { "Id", "CreatedAt", "CreatedBy", "Description", "Label", "LanguageId", "SectionItemFieldSettingId", "Status", "UpdatedAt", "UpdatedBy" },
                values: new object[,]
                {
                    { 11, new DateTime(2024, 10, 21, 10, 0, 0, 0, DateTimeKind.Unspecified), null, "Text for the navigation link", "Link Text", 2, 6, 1, null, null },
                    { 12, new DateTime(2024, 10, 21, 10, 0, 0, 0, DateTimeKind.Unspecified), null, "Navigasyon linki için metin", "Link Metni", 1, 6, 1, null, null },
                    { 13, new DateTime(2024, 10, 21, 10, 0, 0, 0, DateTimeKind.Unspecified), null, "Link destination", "URL", 2, 7, 1, null, null },
                    { 14, new DateTime(2024, 10, 21, 10, 0, 0, 0, DateTimeKind.Unspecified), null, "Link hedefi", "URL", 1, 7, 1, null, null },
                    { 15, new DateTime(2024, 10, 21, 10, 0, 0, 0, DateTimeKind.Unspecified), null, "FontAwesome icon class", "Icon (Optional)", 2, 8, 1, null, null },
                    { 16, new DateTime(2024, 10, 21, 10, 0, 0, 0, DateTimeKind.Unspecified), null, "FontAwesome ikon sınıfı", "İkon (Opsiyonel)", 1, 8, 1, null, null },
                    { 17, new DateTime(2024, 10, 21, 10, 0, 0, 0, DateTimeKind.Unspecified), null, "Open link in new browser tab", "Open in New Tab", 2, 9, 1, null, null },
                    { 18, new DateTime(2024, 10, 21, 10, 0, 0, 0, DateTimeKind.Unspecified), null, "Linki yeni tarayıcı sekmesinde aç", "Yeni Sekmede Aç", 1, 9, 1, null, null },
                    { 3006, new DateTime(2024, 10, 21, 10, 0, 0, 0, DateTimeKind.Unspecified), null, "Link başlığı", "Başlık", 1, 310, 1, null, null },
                    { 3007, new DateTime(2024, 10, 21, 10, 0, 0, 0, DateTimeKind.Unspecified), null, "Link title", "Title", 2, 310, 1, null, null },
                    { 3008, new DateTime(2024, 10, 21, 10, 0, 0, 0, DateTimeKind.Unspecified), null, "Link adresi", "URL", 1, 311, 1, null, null },
                    { 3009, new DateTime(2024, 10, 21, 10, 0, 0, 0, DateTimeKind.Unspecified), null, "Link address", "URL", 2, 311, 1, null, null },
                    { 3010, new DateTime(2024, 10, 21, 10, 0, 0, 0, DateTimeKind.Unspecified), null, "Link ikonu", "İkon", 1, 312, 1, null, null },
                    { 3011, new DateTime(2024, 10, 21, 10, 0, 0, 0, DateTimeKind.Unspecified), null, "Link icon", "Icon", 2, 312, 1, null, null },
                    { 5004, new DateTime(2024, 10, 21, 10, 0, 0, 0, DateTimeKind.Unspecified), null, "Öğe başlığı", "Başlık", 1, 510, 1, null, null },
                    { 5005, new DateTime(2024, 10, 21, 10, 0, 0, 0, DateTimeKind.Unspecified), null, "Item title", "Title", 2, 510, 1, null, null },
                    { 5006, new DateTime(2024, 10, 21, 10, 0, 0, 0, DateTimeKind.Unspecified), null, "Öğe adresi", "URL", 1, 511, 1, null, null },
                    { 5007, new DateTime(2024, 10, 21, 10, 0, 0, 0, DateTimeKind.Unspecified), null, "Item URL", "URL", 2, 511, 1, null, null },
                    { 5008, new DateTime(2024, 10, 21, 10, 0, 0, 0, DateTimeKind.Unspecified), null, "Öğe rozeti", "Rozet", 1, 512, 1, null, null },
                    { 5009, new DateTime(2024, 10, 21, 10, 0, 0, 0, DateTimeKind.Unspecified), null, "Item badge", "Badge", 2, 512, 1, null, null }
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
                name: "IX_SectionItemFields_SectionItemId",
                table: "SectionItemFields",
                column: "SectionItemId");

            migrationBuilder.CreateIndex(
                name: "IX_SectionItemFieldSettings_SettingId_FieldKey",
                table: "SectionItemFieldSettings",
                columns: new[] { "SectionItemSettingId", "FieldKey" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_SectionItemFieldSettings_SettingId_SortOrder",
                table: "SectionItemFieldSettings",
                columns: new[] { "SectionItemSettingId", "SortOrder" });

            migrationBuilder.CreateIndex(
                name: "IX_SectionItemFieldSettings_Type",
                table: "SectionItemFieldSettings",
                column: "Type");

            migrationBuilder.CreateIndex(
                name: "IX_SectionItemFieldSettingTranslations_FieldSettingId_LanguageId",
                table: "SectionItemFieldSettingTranslations",
                columns: new[] { "SectionItemFieldSettingId", "LanguageId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_SectionItemFieldSettingTranslations_LanguageId",
                table: "SectionItemFieldSettingTranslations",
                column: "LanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_SectionItemFieldTranslations_LanguageId",
                table: "SectionItemFieldTranslations",
                column: "LanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_SectionItemFieldTranslations_SectionItemFieldId",
                table: "SectionItemFieldTranslations",
                column: "SectionItemFieldId");

            migrationBuilder.CreateIndex(
                name: "IX_SectionItems_ParentSectionItemId",
                table: "SectionItems",
                column: "ParentSectionItemId");

            migrationBuilder.CreateIndex(
                name: "IX_SectionItems_SectionId_SortOrder",
                table: "SectionItems",
                columns: new[] { "SectionId", "SortOrder" });

            migrationBuilder.CreateIndex(
                name: "IX_SectionItems_SectionItemSettingId1",
                table: "SectionItems",
                column: "SectionItemSettingId1");

            migrationBuilder.CreateIndex(
                name: "IX_SectionItems_TemplateId",
                table: "SectionItems",
                column: "SectionItemSettingId");

            migrationBuilder.CreateIndex(
                name: "IX_SectionItems_Type",
                table: "SectionItems",
                column: "Type");

            migrationBuilder.CreateIndex(
                name: "IX_SectionItemSettings_ItemType",
                table: "SectionItemSettings",
                column: "ItemType");

            migrationBuilder.CreateIndex(
                name: "IX_SectionItemSettings_ParentSettingId",
                table: "SectionItemSettings",
                column: "ParentSettingId");

            migrationBuilder.CreateIndex(
                name: "IX_SectionItemSettings_TemplateId_ConfigurationKey",
                table: "SectionItemSettings",
                columns: new[] { "TemplateId", "ConfigurationKey" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_SectionItemSettings_TemplateId1",
                table: "SectionItemSettings",
                column: "TemplateId1",
                unique: true,
                filter: "[TemplateId1] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_SectionItemSettingTranslations_LanguageId",
                table: "SectionItemSettingTranslations",
                column: "LanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_SectionItemSettingTranslations_SettingId_LanguageId",
                table: "SectionItemSettingTranslations",
                columns: new[] { "SectionItemSettingId", "LanguageId" },
                unique: true);

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
                name: "IX_SectionItemTypeTemplate_SectionItemType_TemplateId",
                table: "SectionItemTypeTemplate",
                columns: new[] { "SectionItemType", "TemplateId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_SectionItemTypeTemplate_TemplateId",
                table: "SectionItemTypeTemplate",
                column: "TemplateId");

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
                name: "IX_Templates_TemplateType_IsActive",
                table: "Templates",
                columns: new[] { "TemplateType", "IsActive" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LayoutSections");

            migrationBuilder.DropTable(
                name: "PageSections");

            migrationBuilder.DropTable(
                name: "PageSEOParameters");

            migrationBuilder.DropTable(
                name: "PageTranslations");

            migrationBuilder.DropTable(
                name: "SectionItemFieldSettingTranslations");

            migrationBuilder.DropTable(
                name: "SectionItemFieldTranslations");

            migrationBuilder.DropTable(
                name: "SectionItemSettingTranslations");

            migrationBuilder.DropTable(
                name: "SectionItemTranslations");

            migrationBuilder.DropTable(
                name: "SectionItemTypeTemplate");

            migrationBuilder.DropTable(
                name: "SectionTranslations");

            migrationBuilder.DropTable(
                name: "SectionTypeTemplates");

            migrationBuilder.DropTable(
                name: "Pages");

            migrationBuilder.DropTable(
                name: "SectionItemFieldSettings");

            migrationBuilder.DropTable(
                name: "SectionItemFields");

            migrationBuilder.DropTable(
                name: "Languages");

            migrationBuilder.DropTable(
                name: "Contents");

            migrationBuilder.DropTable(
                name: "Layouts");

            migrationBuilder.DropTable(
                name: "SectionItems");

            migrationBuilder.DropTable(
                name: "SectionItemSettings");

            migrationBuilder.DropTable(
                name: "Sections");

            migrationBuilder.DropTable(
                name: "Templates");
        }
    }
}
