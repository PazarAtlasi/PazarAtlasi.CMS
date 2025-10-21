using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace PazarAtlasi.CMS.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AddSectionItemSettingEntities : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SectionItemSettingId",
                table: "SectionItems",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "SectionItemSettings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TemplateId = table.Column<int>(type: "int", nullable: false),
                    ConfigurationKey = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    ItemType = table.Column<int>(type: "int", nullable: false),
                    MinItems = table.Column<int>(type: "int", nullable: false, defaultValue: 0),
                    MaxItems = table.Column<int>(type: "int", nullable: true),
                    DefaultItemCount = table.Column<int>(type: "int", nullable: false, defaultValue: 1),
                    AllowDynamicSectionItems = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    UIConfigurationJson = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ParentSettingId = table.Column<int>(type: "int", nullable: true),
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

            migrationBuilder.InsertData(
                table: "SectionItemSettings",
                columns: new[] { "Id", "ConfigurationKey", "CreatedAt", "CreatedBy", "DefaultItemCount", "ItemType", "MaxItems", "MinItems", "ParentSettingId", "Status", "TemplateId", "UIConfigurationJson", "UpdatedAt", "UpdatedBy" },
                values: new object[] { 1, "logo", new DateTime(2024, 10, 21, 10, 0, 0, 0, DateTimeKind.Unspecified), null, 1, 1, 1, 1, null, 1, 1, "{\"Layout\":\"list\",\"ShowPreview\":true,\"ShowReorder\":false,\"IconClass\":\"fa-image\"}", null, null });

            migrationBuilder.InsertData(
                table: "SectionItemSettings",
                columns: new[] { "Id", "AllowDynamicSectionItems", "ConfigurationKey", "CreatedAt", "CreatedBy", "DefaultItemCount", "ItemType", "MaxItems", "MinItems", "ParentSettingId", "Status", "TemplateId", "UIConfigurationJson", "UpdatedAt", "UpdatedBy" },
                values: new object[] { 2, true, "menu", new DateTime(2024, 10, 21, 10, 0, 0, 0, DateTimeKind.Unspecified), null, 3, 21, 8, 3, null, 1, 1, "{\"Layout\":\"list\",\"ShowPreview\":true,\"ShowReorder\":true,\"AddButtonText\":\"Add Menu Item\",\"IconClass\":\"fa-bars\"}", null, null });

            migrationBuilder.UpdateData(
                table: "SectionItems",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "SectionItemSettingId", "Type" },
                values: new object[] { 1, 6 });

            migrationBuilder.UpdateData(
                table: "SectionItems",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "SectionItemSettingId", "Type" },
                values: new object[] { 1, 9 });

            migrationBuilder.UpdateData(
                table: "SectionItems",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "SectionItemSettingId", "Type" },
                values: new object[] { 1, 5 });

            migrationBuilder.UpdateData(
                table: "SectionItems",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "SectionItemSettingId", "Type" },
                values: new object[] { 1, 10 });

            migrationBuilder.UpdateData(
                table: "SectionItems",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "SectionItemSettingId", "Type" },
                values: new object[] { 1, 10 });

            migrationBuilder.UpdateData(
                table: "SectionItems",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "SectionItemSettingId", "Type" },
                values: new object[] { 1, 10 });

            migrationBuilder.UpdateData(
                table: "SectionItems",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "SectionItemSettingId", "Type" },
                values: new object[] { 1, 6 });

            migrationBuilder.UpdateData(
                table: "SectionItems",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "SectionItemSettingId", "Type" },
                values: new object[] { 1, 15 });

            migrationBuilder.UpdateData(
                table: "SectionItems",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "SectionItemSettingId", "Type" },
                values: new object[] { 1, 6 });

            migrationBuilder.UpdateData(
                table: "SectionItems",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "SectionItemSettingId", "Type" },
                values: new object[] { 1, 18 });

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
                table: "SectionItemSettingTranslations",
                columns: new[] { "Id", "CreatedAt", "CreatedBy", "Description", "LanguageId", "SectionItemSettingId", "Status", "Title", "UpdatedAt", "UpdatedBy" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 10, 21, 10, 0, 0, 0, DateTimeKind.Unspecified), null, "Web sitesi logosu", 1, 1, 1, "Logo", null, null },
                    { 2, new DateTime(2024, 10, 21, 10, 0, 0, 0, DateTimeKind.Unspecified), null, "Website Logo", 2, 1, 1, "Logo", null, null },
                    { 3, new DateTime(2024, 10, 21, 10, 0, 0, 0, DateTimeKind.Unspecified), null, "Navigasyon menü öğeleri", 1, 2, 1, "Menü Öğeleri", null, null },
                    { 4, new DateTime(2024, 10, 21, 10, 0, 0, 0, DateTimeKind.Unspecified), null, "Navigation menu items", 2, 2, 1, "Menu Items", null, null }
                });

            migrationBuilder.InsertData(
                table: "SectionItemSettings",
                columns: new[] { "Id", "AllowDynamicSectionItems", "ConfigurationKey", "CreatedAt", "CreatedBy", "DefaultItemCount", "ItemType", "MaxItems", "MinItems", "ParentSettingId", "Status", "TemplateId", "UIConfigurationJson", "UpdatedAt", "UpdatedBy" },
                values: new object[] { 3, true, "dropdown-link", new DateTime(2024, 10, 21, 10, 0, 0, 0, DateTimeKind.Unspecified), null, 3, 7, 10, 1, 2, 1, 1, "{\"Layout\":\"list\",\"ShowPreview\":true,\"ShowReorder\":true,\"AddButtonText\":\"Add Dropdown Link\",\"IconClass\":\"fa-link\"}", null, null });

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
                    { 10, new DateTime(2024, 10, 21, 10, 0, 0, 0, DateTimeKind.Unspecified), null, "FontAwesome ikon sınıfı", "İkon (Opsiyonel)", 1, 5, 1, null, null }
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
                table: "SectionItemSettingTranslations",
                columns: new[] { "Id", "CreatedAt", "CreatedBy", "Description", "LanguageId", "SectionItemSettingId", "Status", "Title", "UpdatedAt", "UpdatedBy" },
                values: new object[,]
                {
                    { 5, new DateTime(2024, 10, 21, 10, 0, 0, 0, DateTimeKind.Unspecified), null, "Açılır menüdeki bağlantı", 1, 3, 1, "Açılır Menü Linki", null, null },
                    { 6, new DateTime(2024, 10, 21, 10, 0, 0, 0, DateTimeKind.Unspecified), null, "Link in dropdown menu", 2, 3, 1, "Dropdown Link", null, null }
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
                    { 18, new DateTime(2024, 10, 21, 10, 0, 0, 0, DateTimeKind.Unspecified), null, "Linki yeni tarayıcı sekmesinde aç", "Yeni Sekmede Aç", 1, 9, 1, null, null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_SectionItems_SectionItemSettingId",
                table: "SectionItems",
                column: "SectionItemSettingId");

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
                name: "IX_SectionItemSettingTranslations_LanguageId",
                table: "SectionItemSettingTranslations",
                column: "LanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_SectionItemSettingTranslations_SettingId_LanguageId",
                table: "SectionItemSettingTranslations",
                columns: new[] { "SectionItemSettingId", "LanguageId" },
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

            migrationBuilder.AddForeignKey(
                name: "FK_SectionItems_SectionItemSettings_SectionItemSettingId",
                table: "SectionItems",
                column: "SectionItemSettingId",
                principalTable: "SectionItemSettings",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SectionItems_SectionItemSettings_SectionItemSettingId",
                table: "SectionItems");

            migrationBuilder.DropTable(
                name: "SectionItemFieldSettingTranslations");

            migrationBuilder.DropTable(
                name: "SectionItemSettingTranslations");

            migrationBuilder.DropTable(
                name: "SectionItemTypeTemplate");

            migrationBuilder.DropTable(
                name: "SectionItemFieldSettings");

            migrationBuilder.DropTable(
                name: "SectionItemSettings");

            migrationBuilder.DropIndex(
                name: "IX_SectionItems_SectionItemSettingId",
                table: "SectionItems");

            migrationBuilder.DropColumn(
                name: "SectionItemSettingId",
                table: "SectionItems");

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
                keyValue: 4,
                column: "Type",
                value: 9);

            migrationBuilder.UpdateData(
                table: "SectionItems",
                keyColumn: "Id",
                keyValue: 5,
                column: "Type",
                value: 9);

            migrationBuilder.UpdateData(
                table: "SectionItems",
                keyColumn: "Id",
                keyValue: 6,
                column: "Type",
                value: 9);

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
        }
    }
}
