using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace PazarAtlasi.CMS.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class RefactorSectionItemFields : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SectionItemFields_SectionItems_SectionItemId",
                table: "SectionItemFields");

            migrationBuilder.DropForeignKey(
                name: "FK_SectionItems_SectionItemSettings_SectionItemSettingId1",
                table: "SectionItems");

            migrationBuilder.DropForeignKey(
                name: "FK_SectionItems_Templates_SectionItemSettingId",
                table: "SectionItems");

            migrationBuilder.DropTable(
                name: "SectionItemFieldSettingTranslations");

            migrationBuilder.DropTable(
                name: "SectionItemFieldTranslations");

            migrationBuilder.DropTable(
                name: "SectionItemSettingTranslations");

            migrationBuilder.DropTable(
                name: "SectionItemFieldSettings");

            migrationBuilder.DropTable(
                name: "SectionItemSettings");

            migrationBuilder.DropIndex(
                name: "IX_SectionItems_SectionItemSettingId1",
                table: "SectionItems");

            migrationBuilder.DropIndex(
                name: "IX_SectionItemFields_SectionItemId",
                table: "SectionItemFields");

            migrationBuilder.DropColumn(
                name: "SectionItemSettingId1",
                table: "SectionItems");

            migrationBuilder.RenameColumn(
                name: "SectionItemSettingId",
                table: "SectionItems",
                newName: "TemplateId");

            migrationBuilder.RenameColumn(
                name: "SectionItemId",
                table: "SectionItemFields",
                newName: "Type");

            migrationBuilder.RenameColumn(
                name: "FieldValue",
                table: "SectionItemFields",
                newName: "OptionsJson");

            migrationBuilder.RenameColumn(
                name: "FieldType",
                table: "SectionItemFields",
                newName: "SortOrder");

            migrationBuilder.AlterColumn<int>(
                name: "TemplateId",
                table: "SectionItems",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<bool>(
                name: "AllowRemove",
                table: "SectionItems",
                type: "bit",
                nullable: false,
                defaultValue: true);

            migrationBuilder.AddColumn<bool>(
                name: "AllowReorder",
                table: "SectionItems",
                type: "bit",
                nullable: false,
                defaultValue: true);

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "SectionItems",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "IconClass",
                table: "SectionItems",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Title",
                table: "SectionItems",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Status",
                table: "SectionItemFields",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldDefaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "DefaultValue",
                table: "SectionItemFields",
                type: "nvarchar(1000)",
                maxLength: 1000,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FieldName",
                table: "SectionItemFields",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<bool>(
                name: "IsTranslatable",
                table: "SectionItemFields",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "MaxLength",
                table: "SectionItemFields",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Placeholder",
                table: "SectionItemFields",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Required",
                table: "SectionItemFields",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "TemplateId",
                table: "SectionItemFields",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TemplateId1",
                table: "SectionItemFields",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "SectionItemFieldValues",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
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
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
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

            migrationBuilder.UpdateData(
                table: "SectionItems",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "AllowRemove", "AllowReorder", "Description", "IconClass", "Title" },
                values: new object[] { true, true, "Main hero section title", "fas fa-heading", "Hero Title" });

            migrationBuilder.UpdateData(
                table: "SectionItems",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "AllowRemove", "AllowReorder", "Description", "IconClass", "Title" },
                values: new object[] { true, true, "Hero section description text", "fas fa-paragraph", "Hero Description" });

            migrationBuilder.UpdateData(
                table: "SectionItems",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "AllowRemove", "AllowReorder", "Description", "IconClass", "Title" },
                values: new object[] { true, true, null, null, null });

            migrationBuilder.UpdateData(
                table: "SectionItems",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "AllowRemove", "AllowReorder", "Description", "IconClass", "Title" },
                values: new object[] { true, true, null, null, null });

            migrationBuilder.UpdateData(
                table: "SectionItems",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "AllowRemove", "AllowReorder", "Description", "IconClass", "Title" },
                values: new object[] { true, true, null, null, null });

            migrationBuilder.UpdateData(
                table: "SectionItems",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "AllowRemove", "AllowReorder", "Description", "IconClass", "Title" },
                values: new object[] { true, true, null, null, null });

            migrationBuilder.UpdateData(
                table: "SectionItems",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "AllowRemove", "AllowReorder", "Description", "IconClass", "Title" },
                values: new object[] { true, true, null, null, null });

            migrationBuilder.UpdateData(
                table: "SectionItems",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "AllowRemove", "AllowReorder", "Description", "IconClass", "Title" },
                values: new object[] { true, true, null, null, null });

            migrationBuilder.UpdateData(
                table: "SectionItems",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "AllowRemove", "AllowReorder", "Description", "IconClass", "Title" },
                values: new object[] { true, true, null, null, null });

            migrationBuilder.UpdateData(
                table: "SectionItems",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "AllowRemove", "AllowReorder", "Description", "IconClass", "Title" },
                values: new object[] { true, true, null, null, null });

            migrationBuilder.CreateIndex(
                name: "IX_SectionItemFields_FieldKey",
                table: "SectionItemFields",
                column: "FieldKey");

            migrationBuilder.CreateIndex(
                name: "IX_SectionItemFields_SortOrder",
                table: "SectionItemFields",
                column: "SortOrder");

            migrationBuilder.CreateIndex(
                name: "IX_SectionItemFields_TemplateId_FieldKey",
                table: "SectionItemFields",
                columns: new[] { "TemplateId", "FieldKey" });

            migrationBuilder.CreateIndex(
                name: "IX_SectionItemFields_TemplateId1",
                table: "SectionItemFields",
                column: "TemplateId1");

            migrationBuilder.CreateIndex(
                name: "IX_SectionItemFieldValues_FieldId",
                table: "SectionItemFieldValues",
                column: "SectionItemFieldId");

            migrationBuilder.CreateIndex(
                name: "IX_SectionItemFieldValues_SectionItemId_FieldId",
                table: "SectionItemFieldValues",
                columns: new[] { "SectionItemId", "SectionItemFieldId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_SectionItemFieldValueTranslations_LanguageId",
                table: "SectionItemFieldValueTranslations",
                column: "LanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_SectionItemFieldValueTranslations_ValueId_LanguageId",
                table: "SectionItemFieldValueTranslations",
                columns: new[] { "SectionItemFieldValueId", "LanguageId" },
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_SectionItemFields_Templates_TemplateId",
                table: "SectionItemFields",
                column: "TemplateId",
                principalTable: "Templates",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_SectionItemFields_Templates_TemplateId1",
                table: "SectionItemFields",
                column: "TemplateId1",
                principalTable: "Templates",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_SectionItems_Templates_TemplateId",
                table: "SectionItems",
                column: "TemplateId",
                principalTable: "Templates",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SectionItemFields_Templates_TemplateId",
                table: "SectionItemFields");

            migrationBuilder.DropForeignKey(
                name: "FK_SectionItemFields_Templates_TemplateId1",
                table: "SectionItemFields");

            migrationBuilder.DropForeignKey(
                name: "FK_SectionItems_Templates_TemplateId",
                table: "SectionItems");

            migrationBuilder.DropTable(
                name: "SectionItemFieldValueTranslations");

            migrationBuilder.DropTable(
                name: "SectionItemFieldValues");

            migrationBuilder.DropIndex(
                name: "IX_SectionItemFields_FieldKey",
                table: "SectionItemFields");

            migrationBuilder.DropIndex(
                name: "IX_SectionItemFields_SortOrder",
                table: "SectionItemFields");

            migrationBuilder.DropIndex(
                name: "IX_SectionItemFields_TemplateId_FieldKey",
                table: "SectionItemFields");

            migrationBuilder.DropIndex(
                name: "IX_SectionItemFields_TemplateId1",
                table: "SectionItemFields");

            migrationBuilder.DropColumn(
                name: "AllowRemove",
                table: "SectionItems");

            migrationBuilder.DropColumn(
                name: "AllowReorder",
                table: "SectionItems");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "SectionItems");

            migrationBuilder.DropColumn(
                name: "IconClass",
                table: "SectionItems");

            migrationBuilder.DropColumn(
                name: "Title",
                table: "SectionItems");

            migrationBuilder.DropColumn(
                name: "DefaultValue",
                table: "SectionItemFields");

            migrationBuilder.DropColumn(
                name: "FieldName",
                table: "SectionItemFields");

            migrationBuilder.DropColumn(
                name: "IsTranslatable",
                table: "SectionItemFields");

            migrationBuilder.DropColumn(
                name: "MaxLength",
                table: "SectionItemFields");

            migrationBuilder.DropColumn(
                name: "Placeholder",
                table: "SectionItemFields");

            migrationBuilder.DropColumn(
                name: "Required",
                table: "SectionItemFields");

            migrationBuilder.DropColumn(
                name: "TemplateId",
                table: "SectionItemFields");

            migrationBuilder.DropColumn(
                name: "TemplateId1",
                table: "SectionItemFields");

            migrationBuilder.RenameColumn(
                name: "TemplateId",
                table: "SectionItems",
                newName: "SectionItemSettingId");

            migrationBuilder.RenameColumn(
                name: "Type",
                table: "SectionItemFields",
                newName: "SectionItemId");

            migrationBuilder.RenameColumn(
                name: "SortOrder",
                table: "SectionItemFields",
                newName: "FieldType");

            migrationBuilder.RenameColumn(
                name: "OptionsJson",
                table: "SectionItemFields",
                newName: "FieldValue");

            migrationBuilder.AlterColumn<int>(
                name: "SectionItemSettingId",
                table: "SectionItems",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SectionItemSettingId1",
                table: "SectionItems",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Status",
                table: "SectionItemFields",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateTable(
                name: "SectionItemFieldTranslations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LanguageId = table.Column<int>(type: "int", nullable: false),
                    SectionItemFieldId = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<int>(type: "int", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<int>(type: "int", nullable: true)
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

            migrationBuilder.CreateTable(
                name: "SectionItemSettings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ParentSettingId = table.Column<int>(type: "int", nullable: true),
                    TemplateId = table.Column<int>(type: "int", nullable: false),
                    AllowDynamicSectionItems = table.Column<bool>(type: "bit", nullable: false),
                    ConfigurationKey = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<int>(type: "int", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    ItemType = table.Column<int>(type: "int", nullable: false),
                    SortOrder = table.Column<int>(type: "int", nullable: false, defaultValue: 0),
                    Status = table.Column<int>(type: "int", nullable: false, defaultValue: 1),
                    TemplateId1 = table.Column<int>(type: "int", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<int>(type: "int", nullable: true)
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
                name: "SectionItemFieldSettings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SectionItemSettingId = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<int>(type: "int", nullable: true),
                    DefaultValue = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    FieldKey = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    IsTranslatable = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    MaxLength = table.Column<int>(type: "int", nullable: false, defaultValue: 0),
                    OptionsJson = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Placeholder = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Required = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    SortOrder = table.Column<int>(type: "int", nullable: false, defaultValue: 0),
                    Status = table.Column<int>(type: "int", nullable: false, defaultValue: 1),
                    Type = table.Column<int>(type: "int", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<int>(type: "int", nullable: true)
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
                    LanguageId = table.Column<int>(type: "int", nullable: false),
                    SectionItemSettingId = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<int>(type: "int", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    Status = table.Column<int>(type: "int", nullable: false, defaultValue: 1),
                    Title = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<int>(type: "int", nullable: true)
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
                    LanguageId = table.Column<int>(type: "int", nullable: false),
                    SectionItemFieldSettingId = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<int>(type: "int", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    Label = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false, defaultValue: 1),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<int>(type: "int", nullable: true)
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

            migrationBuilder.UpdateData(
                table: "SectionItems",
                keyColumn: "Id",
                keyValue: 1,
                column: "SectionItemSettingId1",
                value: null);

            migrationBuilder.UpdateData(
                table: "SectionItems",
                keyColumn: "Id",
                keyValue: 2,
                column: "SectionItemSettingId1",
                value: null);

            migrationBuilder.UpdateData(
                table: "SectionItems",
                keyColumn: "Id",
                keyValue: 3,
                column: "SectionItemSettingId1",
                value: null);

            migrationBuilder.UpdateData(
                table: "SectionItems",
                keyColumn: "Id",
                keyValue: 4,
                column: "SectionItemSettingId1",
                value: null);

            migrationBuilder.UpdateData(
                table: "SectionItems",
                keyColumn: "Id",
                keyValue: 5,
                column: "SectionItemSettingId1",
                value: null);

            migrationBuilder.UpdateData(
                table: "SectionItems",
                keyColumn: "Id",
                keyValue: 6,
                column: "SectionItemSettingId1",
                value: null);

            migrationBuilder.UpdateData(
                table: "SectionItems",
                keyColumn: "Id",
                keyValue: 7,
                column: "SectionItemSettingId1",
                value: null);

            migrationBuilder.UpdateData(
                table: "SectionItems",
                keyColumn: "Id",
                keyValue: 8,
                column: "SectionItemSettingId1",
                value: null);

            migrationBuilder.UpdateData(
                table: "SectionItems",
                keyColumn: "Id",
                keyValue: 9,
                column: "SectionItemSettingId1",
                value: null);

            migrationBuilder.UpdateData(
                table: "SectionItems",
                keyColumn: "Id",
                keyValue: 10,
                column: "SectionItemSettingId1",
                value: null);

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
                name: "IX_SectionItems_SectionItemSettingId1",
                table: "SectionItems",
                column: "SectionItemSettingId1");

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

            migrationBuilder.AddForeignKey(
                name: "FK_SectionItemFields_SectionItems_SectionItemId",
                table: "SectionItemFields",
                column: "SectionItemId",
                principalTable: "SectionItems",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SectionItems_SectionItemSettings_SectionItemSettingId1",
                table: "SectionItems",
                column: "SectionItemSettingId1",
                principalTable: "SectionItemSettings",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_SectionItems_Templates_SectionItemSettingId",
                table: "SectionItems",
                column: "SectionItemSettingId",
                principalTable: "Templates",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
