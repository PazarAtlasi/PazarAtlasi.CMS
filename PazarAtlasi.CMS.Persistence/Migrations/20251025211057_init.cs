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
                name: "SectionItemFields",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SectionItemId = table.Column<int>(type: "int", nullable: false),
                    FieldKey = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    FieldName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Type = table.Column<int>(type: "int", nullable: false),
                    Required = table.Column<bool>(type: "bit", nullable: false),
                    MaxLength = table.Column<int>(type: "int", nullable: true),
                    Placeholder = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    DefaultValue = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    IsTranslatable = table.Column<bool>(type: "bit", nullable: false),
                    OptionsJson = table.Column<string>(type: "nvarchar(max)", nullable: true),
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
                table: "SectionItems",
                columns: new[] { "Id", "AllowRemove", "AllowReorder", "CreatedAt", "CreatedBy", "Description", "IconClass", "Key", "ParentSectionItemId", "SortOrder", "Status", "TemplateId", "Title", "Type", "UpdatedAt", "UpdatedBy" },
                values: new object[,]
                {
                    { 1, true, true, new DateTime(2024, 10, 25, 10, 0, 0, 0, DateTimeKind.Unspecified), null, "About us mega menu", "fas fa-info-circle", "navbar.about", null, 1, 1, 2, "About", 26, null, null },
                    { 12, true, true, new DateTime(2024, 10, 25, 10, 0, 0, 0, DateTimeKind.Unspecified), null, "Services menu with tabs", "fas fa-cogs", null, null, 2, 1, 3, "Services", 26, null, null },
                    { 43, true, true, new DateTime(2024, 10, 25, 10, 0, 0, 0, DateTimeKind.Unspecified), null, "Solutions menu", "fas fa-lightbulb", null, null, 3, 1, 4, "Solutions", 26, null, null },
                    { 69, true, true, new DateTime(2024, 10, 25, 10, 0, 0, 0, DateTimeKind.Unspecified), null, "Blog mega menu", "fas fa-blog", null, null, 4, 1, 2, "Blog", 26, null, null },
                    { 79, true, true, new DateTime(2024, 10, 25, 10, 0, 0, 0, DateTimeKind.Unspecified), null, "Career opportunities", "fas fa-briefcase", null, null, 5, 1, 1, "Careers", 12, null, null },
                    { 80, true, true, new DateTime(2024, 10, 25, 10, 0, 0, 0, DateTimeKind.Unspecified), null, "Data center status", "fas fa-server", null, null, 6, 1, 1, "Data Center", 12, null, null },
                    { 81, true, true, new DateTime(2024, 10, 25, 10, 0, 0, 0, DateTimeKind.Unspecified), null, "Contact information", "fas fa-envelope", null, null, 7, 1, 1, "Contact", 8, null, null },
                    { 84, true, true, new DateTime(2024, 10, 25, 10, 0, 0, 0, DateTimeKind.Unspecified), null, "Customer references", "fas fa-handshake", null, null, 8, 1, 1, "References", 12, null, null }
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
                table: "SectionItemFields",
                columns: new[] { "Id", "CreatedAt", "CreatedBy", "DefaultValue", "FieldKey", "FieldName", "IsTranslatable", "MaxLength", "OptionsJson", "Placeholder", "Required", "SectionItemId", "SortOrder", "Status", "Type", "UpdatedAt", "UpdatedBy" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 10, 25, 10, 0, 0, 0, DateTimeKind.Unspecified), null, null, "label", "label", true, 100, null, "Enter menu label", true, 1, 1, 0, 1, null, null },
                    { 2, new DateTime(2024, 10, 25, 10, 0, 0, 0, DateTimeKind.Unspecified), null, "#", "type", "TYPE", false, null, null, "Menu type.", false, 1, 2, 0, 1, null, null }
                });

            migrationBuilder.InsertData(
                table: "SectionItemTranslations",
                columns: new[] { "Id", "CreatedAt", "CreatedBy", "Description", "LanguageId", "Name", "SectionItemId", "Status", "Title", "UpdatedAt", "UpdatedBy" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 1, 1, 10, 0, 0, 0, DateTimeKind.Unspecified), null, "En kaliteli ürünleri keşfedin", 1, "Hoş Geldiniz", 1, 1, "Pazar Atlası'na Hoş Geldiniz", null, null },
                    { 2, new DateTime(2024, 1, 1, 10, 0, 0, 0, DateTimeKind.Unspecified), null, "Discover the highest quality products", 2, "Welcome", 1, 1, "Welcome to Pazar Atlası", null, null }
                });

            migrationBuilder.InsertData(
                table: "SectionItems",
                columns: new[] { "Id", "AllowRemove", "AllowReorder", "CreatedAt", "CreatedBy", "Description", "IconClass", "Key", "ParentSectionItemId", "SortOrder", "Status", "TemplateId", "Title", "Type", "UpdatedAt", "UpdatedBy" },
                values: new object[,]
                {
                    { 2, true, true, new DateTime(2024, 10, 25, 10, 0, 0, 0, DateTimeKind.Unspecified), null, "Content", "fas fa-building", "navbar.content", 1, 1, 1, 2, "content", 11, null, null },
                    { 8, true, true, new DateTime(2024, 10, 25, 10, 0, 0, 0, DateTimeKind.Unspecified), null, "Company features", "fas fa-star", null, 1, 3, 1, 2, "Features", 7, null, null },
                    { 13, true, true, new DateTime(2024, 10, 25, 10, 0, 0, 0, DateTimeKind.Unspecified), null, "Managed services", "fas fa-server", null, 12, 1, 1, 3, "Managed", 6, null, null },
                    { 14, true, true, new DateTime(2024, 10, 25, 10, 0, 0, 0, DateTimeKind.Unspecified), null, "Cloud services", "fas fa-cloud", null, 12, 2, 1, 3, "Cloud", 6, null, null },
                    { 15, true, true, new DateTime(2024, 10, 25, 10, 0, 0, 0, DateTimeKind.Unspecified), null, "Security services", "fas fa-shield-alt", null, 12, 3, 1, 3, "Security", 6, null, null },
                    { 16, true, true, new DateTime(2024, 10, 25, 10, 0, 0, 0, DateTimeKind.Unspecified), null, "Database services", "fas fa-database", null, 12, 4, 1, 3, "Database", 6, null, null },
                    { 17, true, true, new DateTime(2024, 10, 25, 10, 0, 0, 0, DateTimeKind.Unspecified), null, "Monitoring services", "fas fa-chart-line", null, 12, 5, 1, 3, "Monitoring", 6, null, null },
                    { 18, true, true, new DateTime(2024, 10, 25, 10, 0, 0, 0, DateTimeKind.Unspecified), null, "Premium services", "fas fa-crown", null, 12, 6, 1, 3, "Premium", 6, null, null },
                    { 44, true, true, new DateTime(2024, 10, 25, 10, 0, 0, 0, DateTimeKind.Unspecified), null, "Software solutions", "fas fa-code", null, 43, 1, 1, 4, "Software", 2, null, null },
                    { 45, true, true, new DateTime(2024, 10, 25, 10, 0, 0, 0, DateTimeKind.Unspecified), null, "DevOps solutions", "fas fa-server", null, 43, 2, 1, 4, "DevOps", 2, null, null },
                    { 46, true, true, new DateTime(2024, 10, 25, 10, 0, 0, 0, DateTimeKind.Unspecified), null, "Hosting solutions", "fas fa-database", null, 43, 3, 1, 4, "Hosting", 2, null, null },
                    { 47, true, true, new DateTime(2024, 10, 25, 10, 0, 0, 0, DateTimeKind.Unspecified), null, "Cloud solutions", "fas fa-cloud", null, 43, 4, 1, 4, "Cloud", 2, null, null },
                    { 48, true, true, new DateTime(2024, 10, 25, 10, 0, 0, 0, DateTimeKind.Unspecified), null, "Security solutions", "fas fa-shield-alt", null, 43, 5, 1, 4, "Security", 2, null, null },
                    { 70, true, true, new DateTime(2024, 10, 25, 10, 0, 0, 0, DateTimeKind.Unspecified), null, "Blog description", "fas fa-info", null, 69, 1, 1, 2, "Description", 11, null, null },
                    { 71, true, true, new DateTime(2024, 10, 25, 10, 0, 0, 0, DateTimeKind.Unspecified), null, "Blog categories", "fas fa-tags", null, 69, 2, 1, 2, "Categories", 9, null, null },
                    { 76, true, true, new DateTime(2024, 10, 25, 10, 0, 0, 0, DateTimeKind.Unspecified), null, "Featured blog posts", "fas fa-star", null, 69, 3, 1, 2, "Featured Posts", 7, null, null },
                    { 82, true, true, new DateTime(2024, 10, 25, 10, 0, 0, 0, DateTimeKind.Unspecified), null, "Email contact", "fas fa-envelope", null, 81, 1, 1, 2, "Email", 11, null, null },
                    { 83, true, true, new DateTime(2024, 10, 25, 10, 0, 0, 0, DateTimeKind.Unspecified), null, "Office address", "fas fa-map-marker-alt", null, 81, 2, 1, 2, "Address", 11, null, null }
                });

            migrationBuilder.InsertData(
                table: "SectionItemFieldTranslations",
                columns: new[] { "Id", "CreatedAt", "CreatedBy", "Description", "Label", "LanguageId", "Placeholder", "SectionItemFieldId", "Status", "UpdatedAt", "UpdatedBy" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 10, 25, 10, 0, 0, 0, DateTimeKind.Unspecified), null, "Label açıklaması.", "Label çevirisi giriniz.", 1, "Label giriniz.", 1, 0, null, null },
                    { 2, new DateTime(2024, 10, 25, 10, 0, 0, 0, DateTimeKind.Unspecified), null, "Menu title", "Title", 2, "Enter menu title", 1, 0, null, null },
                    { 3, new DateTime(2024, 10, 25, 10, 0, 0, 0, DateTimeKind.Unspecified), null, "Menü URL'si", "URL", 1, "URL girin (dropdown'lar için opsiyonel)", 2, 0, null, null },
                    { 4, new DateTime(2024, 10, 25, 10, 0, 0, 0, DateTimeKind.Unspecified), null, "Menu URL", "URL", 2, "Enter URL (optional for dropdowns)", 2, 0, null, null }
                });

            migrationBuilder.InsertData(
                table: "SectionItemFields",
                columns: new[] { "Id", "CreatedAt", "CreatedBy", "DefaultValue", "FieldKey", "FieldName", "IsTranslatable", "MaxLength", "OptionsJson", "Placeholder", "Required", "SectionItemId", "SortOrder", "Status", "Type", "UpdatedAt", "UpdatedBy" },
                values: new object[,]
                {
                    { 12, new DateTime(2024, 10, 25, 10, 0, 0, 0, DateTimeKind.Unspecified), null, null, "tab_label", "Tab Label", true, 50, null, "Enter tab label", true, 13, 1, 0, 1, null, null },
                    { 13, new DateTime(2024, 10, 25, 10, 0, 0, 0, DateTimeKind.Unspecified), null, null, "tab_icon", "Tab Icon", false, 50, null, "Enter icon class", false, 13, 2, 0, 1, null, null },
                    { 14, new DateTime(2024, 10, 25, 10, 0, 0, 0, DateTimeKind.Unspecified), null, "false", "is_premium", "Is Premium", false, null, null, null, false, 18, 3, 0, 5, null, null },
                    { 18, new DateTime(2024, 10, 25, 10, 0, 0, 0, DateTimeKind.Unspecified), null, null, "category_label", "Category Label", true, 50, null, "Enter category label", true, 44, 1, 0, 1, null, null },
                    { 19, new DateTime(2024, 10, 25, 10, 0, 0, 0, DateTimeKind.Unspecified), null, null, "category_icon", "Category Icon", false, 50, null, "Enter icon class", false, 44, 2, 0, 1, null, null },
                    { 20, new DateTime(2024, 10, 25, 10, 0, 0, 0, DateTimeKind.Unspecified), null, "blue", "category_color", "Category Color", false, null, "[\"blue\", \"indigo\", \"purple\", \"green\", \"red\", \"yellow\"]", null, false, 44, 3, 0, 15, null, null }
                });

            migrationBuilder.InsertData(
                table: "SectionItemTranslations",
                columns: new[] { "Id", "CreatedAt", "CreatedBy", "Description", "LanguageId", "Name", "SectionItemId", "Status", "Title", "UpdatedAt", "UpdatedBy" },
                values: new object[,]
                {
                    { 3, new DateTime(2024, 1, 1, 10, 0, 0, 0, DateTimeKind.Unspecified), null, "Binlerce ürün arasından size en uygun olanları bulun. Hızlı teslimat, güvenli ödeme ve mükemmel müşteri hizmetiyle yanınızdayız.", 1, "Alt Başlık", 2, 1, "Kalite ve Güvenin Adresi", null, null },
                    { 4, new DateTime(2024, 1, 1, 10, 0, 0, 0, DateTimeKind.Unspecified), null, "Find the most suitable products for you among thousands of products. We are with you with fast delivery, secure payment and excellent customer service.", 2, "Subtitle", 2, 1, "Address of Quality and Trust", null, null }
                });

            migrationBuilder.InsertData(
                table: "SectionItems",
                columns: new[] { "Id", "AllowRemove", "AllowReorder", "CreatedAt", "CreatedBy", "Description", "IconClass", "Key", "ParentSectionItemId", "SortOrder", "Status", "TemplateId", "Title", "Type", "UpdatedAt", "UpdatedBy" },
                values: new object[,]
                {
                    { 3, true, true, new DateTime(2024, 10, 25, 10, 0, 0, 0, DateTimeKind.Unspecified), null, "description", "fas fa-link", "navbar.description", 2, 2, 1, 2, "description", 9, null, null },
                    { 4, true, true, new DateTime(2024, 10, 25, 10, 0, 0, 0, DateTimeKind.Unspecified), null, null, "fas fa-bullseye", "navbar.quicklinks", 2, 1, 1, 2, "quick links", 12, null, null },
                    { 6, true, true, new DateTime(2024, 10, 25, 10, 0, 0, 0, DateTimeKind.Unspecified), null, null, "fas fa-briefcase", null, 2, 3, 1, 2, "features", 12, null, null },
                    { 9, true, true, new DateTime(2024, 10, 25, 10, 0, 0, 0, DateTimeKind.Unspecified), null, "Years of experience", "fas fa-calendar-alt", null, 8, 1, 1, 2, "Experience", 7, null, null },
                    { 10, true, true, new DateTime(2024, 10, 25, 10, 0, 0, 0, DateTimeKind.Unspecified), null, "Professional team", "fas fa-certificate", null, 8, 2, 1, 2, "Certified Team", 7, null, null },
                    { 11, true, true, new DateTime(2024, 10, 25, 10, 0, 0, 0, DateTimeKind.Unspecified), null, "Successful projects", "fas fa-project-diagram", null, 8, 3, 1, 2, "Projects", 7, null, null },
                    { 19, true, true, new DateTime(2024, 10, 25, 10, 0, 0, 0, DateTimeKind.Unspecified), null, "Multi-cloud management", "fas fa-cloud", null, 13, 1, 1, 2, "Multi-Cloud", 6, null, null },
                    { 20, true, true, new DateTime(2024, 10, 25, 10, 0, 0, 0, DateTimeKind.Unspecified), null, "Hybrid cloud solutions", "fas fa-sync-alt", null, 13, 2, 1, 2, "Hybrid Cloud", 6, null, null },
                    { 21, true, true, new DateTime(2024, 10, 25, 10, 0, 0, 0, DateTimeKind.Unspecified), null, "24/7 monitoring", "fas fa-desktop", null, 13, 3, 1, 2, "Monitoring", 6, null, null },
                    { 22, true, true, new DateTime(2024, 10, 25, 10, 0, 0, 0, DateTimeKind.Unspecified), null, "Container orchestration", "fas fa-cube", null, 13, 4, 1, 2, "Container", 6, null, null },
                    { 23, true, true, new DateTime(2024, 10, 25, 10, 0, 0, 0, DateTimeKind.Unspecified), null, "Public cloud infrastructure", "fas fa-globe", null, 14, 1, 1, 2, "Public Cloud", 6, null, null },
                    { 24, true, true, new DateTime(2024, 10, 25, 10, 0, 0, 0, DateTimeKind.Unspecified), null, "Cloud migration", "fas fa-sync-alt", null, 14, 2, 1, 2, "Migration", 6, null, null },
                    { 25, true, true, new DateTime(2024, 10, 25, 10, 0, 0, 0, DateTimeKind.Unspecified), null, "Cost optimization", "fas fa-chart-pie", null, 14, 3, 1, 2, "Optimization", 6, null, null },
                    { 26, true, true, new DateTime(2024, 10, 25, 10, 0, 0, 0, DateTimeKind.Unspecified), null, "Cloud consulting", "fas fa-cloud", null, 14, 4, 1, 2, "Consulting", 6, null, null },
                    { 27, true, true, new DateTime(2024, 10, 25, 10, 0, 0, 0, DateTimeKind.Unspecified), null, "Cloud security solutions", "fas fa-shield-alt", null, 15, 1, 1, 2, "Cloud Security", 6, null, null },
                    { 28, true, true, new DateTime(2024, 10, 25, 10, 0, 0, 0, DateTimeKind.Unspecified), null, "Zero trust architecture", "fas fa-shield-alt", null, 15, 2, 1, 2, "Zero Trust", 6, null, null },
                    { 29, true, true, new DateTime(2024, 10, 25, 10, 0, 0, 0, DateTimeKind.Unspecified), null, "Managed security services", "fas fa-shield-alt", null, 15, 3, 1, 2, "Managed Security", 6, null, null },
                    { 30, true, true, new DateTime(2024, 10, 25, 10, 0, 0, 0, DateTimeKind.Unspecified), null, "Data protection services", "fas fa-lock", null, 15, 4, 1, 2, "Data Protection", 6, null, null },
                    { 31, true, true, new DateTime(2024, 10, 25, 10, 0, 0, 0, DateTimeKind.Unspecified), null, "Database management", "fas fa-database", null, 16, 1, 1, 2, "Database Management", 6, null, null },
                    { 32, true, true, new DateTime(2024, 10, 25, 10, 0, 0, 0, DateTimeKind.Unspecified), null, "Data migration services", "fas fa-sync-alt", null, 16, 2, 1, 2, "Data Migration", 6, null, null },
                    { 33, true, true, new DateTime(2024, 10, 25, 10, 0, 0, 0, DateTimeKind.Unspecified), null, "Performance optimization", "fas fa-tachometer-alt", null, 16, 3, 1, 2, "Performance", 6, null, null },
                    { 34, true, true, new DateTime(2024, 10, 25, 10, 0, 0, 0, DateTimeKind.Unspecified), null, "Backup and recovery", "fas fa-save", null, 16, 4, 1, 2, "Backup & Recovery", 6, null, null },
                    { 35, true, true, new DateTime(2024, 10, 25, 10, 0, 0, 0, DateTimeKind.Unspecified), null, "Performance monitoring", "fas fa-chart-line", null, 17, 1, 1, 2, "Performance Monitoring", 6, null, null },
                    { 36, true, true, new DateTime(2024, 10, 25, 10, 0, 0, 0, DateTimeKind.Unspecified), null, "System health monitoring", "fas fa-heartbeat", null, 17, 2, 1, 2, "System Health", 6, null, null },
                    { 37, true, true, new DateTime(2024, 10, 25, 10, 0, 0, 0, DateTimeKind.Unspecified), null, "Cost optimization", "fas fa-chart-pie", null, 17, 3, 1, 2, "Cost Optimization", 6, null, null },
                    { 38, true, true, new DateTime(2024, 10, 25, 10, 0, 0, 0, DateTimeKind.Unspecified), null, "Capacity planning", "fas fa-chart-area", null, 17, 4, 1, 2, "Capacity Planning", 6, null, null },
                    { 39, true, true, new DateTime(2024, 10, 25, 10, 0, 0, 0, DateTimeKind.Unspecified), null, "Premium consulting", "fas fa-crown", null, 18, 1, 1, 2, "Premium Consulting", 6, null, null },
                    { 40, true, true, new DateTime(2024, 10, 25, 10, 0, 0, 0, DateTimeKind.Unspecified), null, "CTO as a service", "fas fa-user-tie", null, 18, 2, 1, 2, "CTO as Service", 6, null, null },
                    { 41, true, true, new DateTime(2024, 10, 25, 10, 0, 0, 0, DateTimeKind.Unspecified), null, "Digital transformation", "fas fa-sync-alt", null, 18, 3, 1, 2, "Digital Transformation", 6, null, null },
                    { 42, true, true, new DateTime(2024, 10, 25, 10, 0, 0, 0, DateTimeKind.Unspecified), null, "Strategic planning", "fas fa-chess", null, 18, 4, 1, 2, "Strategic Planning", 6, null, null },
                    { 49, true, true, new DateTime(2024, 10, 25, 10, 0, 0, 0, DateTimeKind.Unspecified), null, "Custom software development", "fas fa-laptop-code", null, 44, 1, 1, 2, "Custom Development", 6, null, null },
                    { 50, true, true, new DateTime(2024, 10, 25, 10, 0, 0, 0, DateTimeKind.Unspecified), null, "Web application development", "fas fa-globe", null, 44, 2, 1, 2, "Web Applications", 6, null, null },
                    { 51, true, true, new DateTime(2024, 10, 25, 10, 0, 0, 0, DateTimeKind.Unspecified), null, "Mobile app development", "fas fa-mobile-alt", null, 44, 3, 1, 2, "Mobile Applications", 6, null, null },
                    { 52, true, true, new DateTime(2024, 10, 25, 10, 0, 0, 0, DateTimeKind.Unspecified), null, "API development services", "fas fa-plug", null, 44, 4, 1, 2, "API Development", 6, null, null },
                    { 53, true, true, new DateTime(2024, 10, 25, 10, 0, 0, 0, DateTimeKind.Unspecified), null, "CI/CD pipelines", "fas fa-code-branch", null, 45, 1, 1, 2, "CI/CD", 6, null, null },
                    { 54, true, true, new DateTime(2024, 10, 25, 10, 0, 0, 0, DateTimeKind.Unspecified), null, "Kubernetes management", "fas fa-dharmachakra", null, 45, 2, 1, 2, "Kubernetes", 6, null, null },
                    { 55, true, true, new DateTime(2024, 10, 25, 10, 0, 0, 0, DateTimeKind.Unspecified), null, "IaC solutions", "fas fa-file-code", null, 45, 3, 1, 2, "Infrastructure as Code", 6, null, null },
                    { 56, true, true, new DateTime(2024, 10, 25, 10, 0, 0, 0, DateTimeKind.Unspecified), null, "DevOps monitoring", "fas fa-chart-line", null, 45, 4, 1, 2, "Monitoring", 6, null, null },
                    { 57, true, true, new DateTime(2024, 10, 25, 10, 0, 0, 0, DateTimeKind.Unspecified), null, "VPS hosting services", "fas fa-server", null, 46, 1, 1, 2, "VPS Hosting", 6, null, null },
                    { 58, true, true, new DateTime(2024, 10, 25, 10, 0, 0, 0, DateTimeKind.Unspecified), null, "Database hosting", "fas fa-database", null, 46, 2, 1, 2, "Database Hosting", 6, null, null },
                    { 59, true, true, new DateTime(2024, 10, 25, 10, 0, 0, 0, DateTimeKind.Unspecified), null, "Disaster recovery", "fas fa-life-ring", null, 46, 3, 1, 2, "Disaster Recovery", 6, null, null },
                    { 60, true, true, new DateTime(2024, 10, 25, 10, 0, 0, 0, DateTimeKind.Unspecified), null, "Web hosting services", "fas fa-globe", null, 46, 4, 1, 2, "Web Hosting", 6, null, null },
                    { 61, true, true, new DateTime(2024, 10, 25, 10, 0, 0, 0, DateTimeKind.Unspecified), null, "Microsoft Azure solutions", "fab fa-microsoft", null, 47, 1, 1, 2, "Azure", 6, null, null },
                    { 62, true, true, new DateTime(2024, 10, 25, 10, 0, 0, 0, DateTimeKind.Unspecified), null, "Amazon Web Services", "fab fa-aws", null, 47, 2, 1, 2, "AWS", 6, null, null },
                    { 63, true, true, new DateTime(2024, 10, 25, 10, 0, 0, 0, DateTimeKind.Unspecified), null, "Cloud migration", "fas fa-sync-alt", null, 47, 3, 1, 2, "Migration", 6, null, null },
                    { 64, true, true, new DateTime(2024, 10, 25, 10, 0, 0, 0, DateTimeKind.Unspecified), null, "Cloud optimization", "fas fa-chart-pie", null, 47, 4, 1, 2, "Optimization", 6, null, null },
                    { 65, true, true, new DateTime(2024, 10, 25, 10, 0, 0, 0, DateTimeKind.Unspecified), null, "Network security", "fas fa-network-wired", null, 48, 1, 1, 2, "Network Security", 6, null, null },
                    { 66, true, true, new DateTime(2024, 10, 25, 10, 0, 0, 0, DateTimeKind.Unspecified), null, "Application security", "fas fa-shield-alt", null, 48, 2, 1, 2, "Application Security", 6, null, null },
                    { 67, true, true, new DateTime(2024, 10, 25, 10, 0, 0, 0, DateTimeKind.Unspecified), null, "Data security", "fas fa-lock", null, 48, 3, 1, 2, "Data Security", 6, null, null },
                    { 68, true, true, new DateTime(2024, 10, 25, 10, 0, 0, 0, DateTimeKind.Unspecified), null, "Security auditing", "fas fa-search", null, 48, 4, 1, 2, "Security Audit", 6, null, null },
                    { 72, true, true, new DateTime(2024, 10, 25, 10, 0, 0, 0, DateTimeKind.Unspecified), null, null, "fas fa-cloud", null, 71, 1, 1, 2, "Cloud Trends", 12, null, null },
                    { 73, true, true, new DateTime(2024, 10, 25, 10, 0, 0, 0, DateTimeKind.Unspecified), null, null, "fas fa-cogs", null, 71, 2, 1, 2, "DevOps Practices", 12, null, null },
                    { 74, true, true, new DateTime(2024, 10, 25, 10, 0, 0, 0, DateTimeKind.Unspecified), null, null, "fas fa-lightbulb", null, 71, 3, 1, 2, "Software Innovation", 12, null, null },
                    { 75, true, true, new DateTime(2024, 10, 25, 10, 0, 0, 0, DateTimeKind.Unspecified), null, null, "fas fa-user-tie", null, 71, 4, 1, 2, "Tech Leadership", 12, null, null },
                    { 77, true, true, new DateTime(2024, 10, 25, 10, 0, 0, 0, DateTimeKind.Unspecified), null, "Best practices guide", "fas fa-dharmachakra", null, 76, 1, 1, 2, "Kubernetes Guide", 27, null, null },
                    { 78, true, true, new DateTime(2024, 10, 25, 10, 0, 0, 0, DateTimeKind.Unspecified), null, "Migration strategies", "fab fa-microsoft", null, 76, 2, 1, 2, "Azure Migration", 27, null, null }
                });

            migrationBuilder.InsertData(
                table: "SectionItemFieldTranslations",
                columns: new[] { "Id", "CreatedAt", "CreatedBy", "Description", "Label", "LanguageId", "Placeholder", "SectionItemFieldId", "Status", "UpdatedAt", "UpdatedBy" },
                values: new object[,]
                {
                    { 25, new DateTime(2024, 10, 25, 10, 0, 0, 0, DateTimeKind.Unspecified), null, "Servis sekmesi etiketi", "Sekme Etiketi", 1, "Sekme etiketini girin", 12, 0, null, null },
                    { 26, new DateTime(2024, 10, 25, 10, 0, 0, 0, DateTimeKind.Unspecified), null, "Service tab label", "Tab Label", 2, "Enter tab label", 12, 0, null, null },
                    { 27, new DateTime(2024, 10, 25, 10, 0, 0, 0, DateTimeKind.Unspecified), null, "Sekme ikon sınıfı", "Sekme İkonu", 1, "İkon sınıfını girin", 13, 0, null, null },
                    { 28, new DateTime(2024, 10, 25, 10, 0, 0, 0, DateTimeKind.Unspecified), null, "Tab icon class", "Tab Icon", 2, "Enter icon class", 13, 0, null, null },
                    { 29, new DateTime(2024, 10, 25, 10, 0, 0, 0, DateTimeKind.Unspecified), null, "Premium servis işareti", "Premium mi?", 1, "Premium olarak işaretle", 14, 0, null, null },
                    { 30, new DateTime(2024, 10, 25, 10, 0, 0, 0, DateTimeKind.Unspecified), null, "Premium service marker", "Is Premium", 2, "Mark as premium", 14, 0, null, null }
                });

            migrationBuilder.InsertData(
                table: "SectionItemFields",
                columns: new[] { "Id", "CreatedAt", "CreatedBy", "DefaultValue", "FieldKey", "FieldName", "IsTranslatable", "MaxLength", "OptionsJson", "Placeholder", "Required", "SectionItemId", "SortOrder", "Status", "Type", "UpdatedAt", "UpdatedBy" },
                values: new object[,]
                {
                    { 3, new DateTime(2024, 10, 25, 10, 0, 0, 0, DateTimeKind.Unspecified), null, null, "description_title", "Description Title", true, 200, null, "Enter description title", true, 3, 1, 0, 1, null, null },
                    { 4, new DateTime(2024, 10, 25, 10, 0, 0, 0, DateTimeKind.Unspecified), null, null, "description_text", "Description Text", true, 500, null, "Enter description text", true, 3, 2, 0, 2, null, null },
                    { 5, new DateTime(2024, 10, 25, 10, 0, 0, 0, DateTimeKind.Unspecified), null, null, "link_text", "Link Text", true, 50, null, "Enter link text", false, 3, 3, 0, 1, null, null },
                    { 6, new DateTime(2024, 10, 25, 10, 0, 0, 0, DateTimeKind.Unspecified), null, "#", "link_url", "Link URL", false, null, null, "Enter link URL", false, 3, 4, 0, 13, null, null },
                    { 7, new DateTime(2024, 10, 25, 10, 0, 0, 0, DateTimeKind.Unspecified), null, null, "quicklinks.title", "Quicklink Title", true, 100, null, "Enter section title", true, 4, 1, 0, 1, null, null },
                    { 15, new DateTime(2024, 10, 25, 10, 0, 0, 0, DateTimeKind.Unspecified), null, null, "service_title", "Service Title", true, 100, null, "Enter service title", true, 19, 1, 0, 1, null, null },
                    { 16, new DateTime(2024, 10, 25, 10, 0, 0, 0, DateTimeKind.Unspecified), null, null, "service_description", "Service Description", true, 300, null, "Enter service description", true, 19, 2, 0, 2, null, null },
                    { 17, new DateTime(2024, 10, 25, 10, 0, 0, 0, DateTimeKind.Unspecified), null, null, "service_icon", "Service Icon", false, 50, null, "Enter icon class", false, 19, 3, 0, 1, null, null }
                });

            migrationBuilder.InsertData(
                table: "SectionItemTranslations",
                columns: new[] { "Id", "CreatedAt", "CreatedBy", "Description", "LanguageId", "Name", "SectionItemId", "Status", "Title", "UpdatedAt", "UpdatedBy" },
                values: new object[,]
                {
                    { 5, new DateTime(2024, 1, 1, 10, 0, 0, 0, DateTimeKind.Unspecified), null, "Tüm ürünleri görüntülemek için tıklayın", 1, "Keşfet", 3, 1, "Ürünleri Keşfet", null, null },
                    { 6, new DateTime(2024, 1, 1, 10, 0, 0, 0, DateTimeKind.Unspecified), null, "Click to view all products", 2, "Explore", 3, 1, "Explore Products", null, null },
                    { 7, new DateTime(2024, 1, 1, 10, 0, 0, 0, DateTimeKind.Unspecified), null, "Yüksek performanslı, şık tasarımlı laptop", 1, "Öne Çıkan Ürün 1", 4, 1, "Premium Laptop", null, null },
                    { 8, new DateTime(2024, 1, 1, 10, 0, 0, 0, DateTimeKind.Unspecified), null, "High performance, stylish design laptop", 2, "Featured Product 1", 4, 1, "Premium Laptop", null, null },
                    { 11, new DateTime(2024, 1, 2, 10, 0, 0, 0, DateTimeKind.Unspecified), null, "En güncel haberler ve makaleler", 1, "Blog", 9, 1, "Blog Yazıları", null, null },
                    { 12, new DateTime(2024, 1, 2, 10, 0, 0, 0, DateTimeKind.Unspecified), null, "Latest news and articles", 2, "Blog", 9, 1, "Blog Posts", null, null }
                });

            migrationBuilder.InsertData(
                table: "SectionItems",
                columns: new[] { "Id", "AllowRemove", "AllowReorder", "CreatedAt", "CreatedBy", "Description", "IconClass", "Key", "ParentSectionItemId", "SortOrder", "Status", "TemplateId", "Title", "Type", "UpdatedAt", "UpdatedBy" },
                values: new object[,]
                {
                    { 5, true, true, new DateTime(2024, 10, 25, 10, 0, 0, 0, DateTimeKind.Unspecified), null, null, "fas fa-users", null, 4, 2, 1, 2, "Team", 12, null, null },
                    { 7, true, true, new DateTime(2024, 10, 25, 10, 0, 0, 0, DateTimeKind.Unspecified), null, null, "fas fa-newspaper", null, 3, 4, 1, 2, "Press", 12, null, null }
                });

            migrationBuilder.InsertData(
                table: "SectionItemFieldTranslations",
                columns: new[] { "Id", "CreatedAt", "CreatedBy", "Description", "Label", "LanguageId", "Placeholder", "SectionItemFieldId", "Status", "UpdatedAt", "UpdatedBy" },
                values: new object[,]
                {
                    { 5, new DateTime(2024, 10, 25, 10, 0, 0, 0, DateTimeKind.Unspecified), null, "Açıklama bölümü başlığı", "Açıklama Başlığı", 1, "Açıklama başlığını girin", 3, 0, null, null },
                    { 6, new DateTime(2024, 10, 25, 10, 0, 0, 0, DateTimeKind.Unspecified), null, "Description section title", "Description Title", 2, "Enter description title", 3, 0, null, null },
                    { 7, new DateTime(2024, 10, 25, 10, 0, 0, 0, DateTimeKind.Unspecified), null, "Açıklama içeriği", "Açıklama Metni", 1, "Açıklama metnini girin", 4, 0, null, null },
                    { 8, new DateTime(2024, 10, 25, 10, 0, 0, 0, DateTimeKind.Unspecified), null, "Description content", "Description Text", 2, "Enter description text", 4, 0, null, null },
                    { 9, new DateTime(2024, 10, 25, 10, 0, 0, 0, DateTimeKind.Unspecified), null, "Link buton metni", "Link Metni", 1, "Link metnini girin", 5, 0, null, null },
                    { 10, new DateTime(2024, 10, 25, 10, 0, 0, 0, DateTimeKind.Unspecified), null, "Link button text", "Link Text", 2, "Enter link text", 5, 0, null, null },
                    { 11, new DateTime(2024, 10, 25, 10, 0, 0, 0, DateTimeKind.Unspecified), null, "Link hedef URL'si", "Link URL'si", 1, "Link URL'sini girin", 6, 0, null, null },
                    { 12, new DateTime(2024, 10, 25, 10, 0, 0, 0, DateTimeKind.Unspecified), null, "Link target URL", "Link URL", 2, "Enter link URL", 6, 0, null, null },
                    { 13, new DateTime(2024, 10, 25, 10, 0, 0, 0, DateTimeKind.Unspecified), null, "Bölüm başlığı", "Bölüm Başlığı", 1, "Bölüm başlığını girin", 7, 0, null, null },
                    { 14, new DateTime(2024, 10, 25, 10, 0, 0, 0, DateTimeKind.Unspecified), null, "Section title", "Section Title", 2, "Enter section title", 7, 0, null, null },
                    { 31, new DateTime(2024, 10, 25, 10, 0, 0, 0, DateTimeKind.Unspecified), null, "Servis öğesi başlığı", "Servis Başlığı", 1, "Servis başlığını girin", 15, 0, null, null },
                    { 32, new DateTime(2024, 10, 25, 10, 0, 0, 0, DateTimeKind.Unspecified), null, "Service item title", "Service Title", 2, "Enter service title", 15, 0, null, null },
                    { 33, new DateTime(2024, 10, 25, 10, 0, 0, 0, DateTimeKind.Unspecified), null, "Servis öğesi açıklaması", "Servis Açıklaması", 1, "Servis açıklamasını girin", 16, 0, null, null },
                    { 34, new DateTime(2024, 10, 25, 10, 0, 0, 0, DateTimeKind.Unspecified), null, "Service item description", "Service Description", 2, "Enter service description", 16, 0, null, null },
                    { 35, new DateTime(2024, 10, 25, 10, 0, 0, 0, DateTimeKind.Unspecified), null, "Servis ikon sınıfı", "Servis İkonu", 1, "İkon sınıfını girin", 17, 0, null, null },
                    { 36, new DateTime(2024, 10, 25, 10, 0, 0, 0, DateTimeKind.Unspecified), null, "Service icon class", "Service Icon", 2, "Enter icon class", 17, 0, null, null }
                });

            migrationBuilder.InsertData(
                table: "SectionItemFields",
                columns: new[] { "Id", "CreatedAt", "CreatedBy", "DefaultValue", "FieldKey", "FieldName", "IsTranslatable", "MaxLength", "OptionsJson", "Placeholder", "Required", "SectionItemId", "SortOrder", "Status", "Type", "UpdatedAt", "UpdatedBy" },
                values: new object[,]
                {
                    { 8, new DateTime(2024, 10, 25, 10, 0, 0, 0, DateTimeKind.Unspecified), null, null, "quicklink.links.missionVision.text", "Link Text", true, 100, null, "Enter link text", true, 5, 1, 0, 1, null, null },
                    { 9, new DateTime(2024, 10, 25, 10, 0, 0, 0, DateTimeKind.Unspecified), null, null, "quicklink.links.missionVision.link", "Link URL", false, null, null, "Enter link URL", true, 5, 2, 0, 13, null, null },
                    { 10, new DateTime(2024, 10, 25, 10, 0, 0, 0, DateTimeKind.Unspecified), null, null, "quicklink.links.team.text", "Feature Title", true, 100, null, "Enter feature title", true, 5, 1, 0, 1, null, null },
                    { 11, new DateTime(2024, 10, 25, 10, 0, 0, 0, DateTimeKind.Unspecified), null, null, "quicklink.links.missionVision.link", "Feature Description", true, 300, null, "mission vision", true, 5, 2, 0, 13, null, null }
                });

            migrationBuilder.InsertData(
                table: "SectionItemTranslations",
                columns: new[] { "Id", "CreatedAt", "CreatedBy", "Description", "LanguageId", "Name", "SectionItemId", "Status", "Title", "UpdatedAt", "UpdatedBy" },
                values: new object[,]
                {
                    { 9, new DateTime(2024, 1, 1, 10, 0, 0, 0, DateTimeKind.Unspecified), null, "Yeni ürünler ve kampanyalardan haberdar olmak için e-posta listemize katılın", 1, "Bülten", 7, 1, "Haberdar Olun", null, null },
                    { 10, new DateTime(2024, 1, 1, 10, 0, 0, 0, DateTimeKind.Unspecified), null, "Join our email list to stay informed about new products and campaigns", 2, "Newsletter", 7, 1, "Stay Informed", null, null }
                });

            migrationBuilder.InsertData(
                table: "SectionItemFieldTranslations",
                columns: new[] { "Id", "CreatedAt", "CreatedBy", "Description", "Label", "LanguageId", "Placeholder", "SectionItemFieldId", "Status", "UpdatedAt", "UpdatedBy" },
                values: new object[,]
                {
                    { 15, new DateTime(2024, 10, 25, 10, 0, 0, 0, DateTimeKind.Unspecified), null, "Link öğesi metni", "Link Metni", 1, "Link metnini girin", 8, 0, null, null },
                    { 16, new DateTime(2024, 10, 25, 10, 0, 0, 0, DateTimeKind.Unspecified), null, "Link item text", "Link Text", 2, "Enter link text", 8, 0, null, null },
                    { 17, new DateTime(2024, 10, 25, 10, 0, 0, 0, DateTimeKind.Unspecified), null, "Link hedef adresi", "Link URL'si", 1, "Link URL'sini girin", 9, 0, null, null },
                    { 18, new DateTime(2024, 10, 25, 10, 0, 0, 0, DateTimeKind.Unspecified), null, "Link target address", "Link URL", 2, "Enter link URL", 9, 0, null, null },
                    { 19, new DateTime(2024, 10, 25, 10, 0, 0, 0, DateTimeKind.Unspecified), null, "Özellik kartı başlığı", "Özellik Başlığı", 1, "Özellik başlığını girin", 10, 0, null, null },
                    { 20, new DateTime(2024, 10, 25, 10, 0, 0, 0, DateTimeKind.Unspecified), null, "Feature card title", "Feature Title", 2, "Enter feature title", 10, 0, null, null },
                    { 21, new DateTime(2024, 10, 25, 10, 0, 0, 0, DateTimeKind.Unspecified), null, "Özellik kartı açıklaması", "Özellik Açıklaması", 1, "Özellik açıklamasını girin", 11, 0, null, null },
                    { 22, new DateTime(2024, 10, 25, 10, 0, 0, 0, DateTimeKind.Unspecified), null, "Feature card description", "Feature Description", 2, "Enter feature description", 11, 0, null, null }
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
                name: "SectionItemFieldTranslations");

            migrationBuilder.DropTable(
                name: "SectionItemFieldValueTranslations");

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
