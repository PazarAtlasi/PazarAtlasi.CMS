using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace PazarAtlasi.CMS.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AddAdditionalTemplateSeeds : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "SectionItemSettings",
                columns: new[] { "Id", "AllowDynamicSectionItems", "ConfigurationKey", "CreatedAt", "CreatedBy", "DefaultItemCount", "ItemType", "MaxItems", "MinItems", "ParentSettingId", "Status", "TemplateId", "UIConfigurationJson", "UpdatedAt", "UpdatedBy" },
                values: new object[,]
                {
                    { 10, true, "slide", new DateTime(2024, 10, 21, 10, 0, 0, 0, DateTimeKind.Unspecified), null, 5, 10, 10, 3, null, 1, 9, "{\"Layout\":\"grid\",\"Columns\":3,\"ShowPreview\":true,\"ShowReorder\":true,\"AddButtonText\":\"Add Slide\",\"IconClass\":\"fa-images\"}", null, null },
                    { 20, true, "content-item", new DateTime(2024, 10, 21, 10, 0, 0, 0, DateTimeKind.Unspecified), null, 3, 6, null, 1, null, 1, 5, "{\"Layout\":\"list\",\"ShowPreview\":true,\"ShowReorder\":true,\"AddButtonText\":\"Add Item\",\"IconClass\":\"fa-file-alt\"}", null, null }
                });

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
                table: "SectionItemSettingTranslations",
                columns: new[] { "Id", "CreatedAt", "CreatedBy", "Description", "LanguageId", "SectionItemSettingId", "Status", "Title", "UpdatedAt", "UpdatedBy" },
                values: new object[,]
                {
                    { 10, new DateTime(2024, 10, 21, 10, 0, 0, 0, DateTimeKind.Unspecified), null, "Carousel slaytı", 1, 10, 1, "Slayt", null, null },
                    { 11, new DateTime(2024, 10, 21, 10, 0, 0, 0, DateTimeKind.Unspecified), null, "Carousel slide", 2, 10, 1, "Slide", null, null },
                    { 20, new DateTime(2024, 10, 21, 10, 0, 0, 0, DateTimeKind.Unspecified), null, "Genel içerik öğesi", 1, 20, 1, "İçerik Öğesi", null, null },
                    { 21, new DateTime(2024, 10, 21, 10, 0, 0, 0, DateTimeKind.Unspecified), null, "General content item", 2, 20, 1, "Content Item", null, null }
                });

            migrationBuilder.InsertData(
                table: "SectionItemFieldSettingTranslations",
                columns: new[] { "Id", "CreatedAt", "CreatedBy", "Description", "Label", "LanguageId", "SectionItemFieldSettingId", "Status", "UpdatedAt", "UpdatedBy" },
                values: new object[,]
                {
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
                    { 203, new DateTime(2024, 10, 21, 10, 0, 0, 0, DateTimeKind.Unspecified), null, "Item description", "Description", 2, 201, 1, null, null }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "SectionItemFieldSettingTranslations",
                keyColumn: "Id",
                keyValue: 100);

            migrationBuilder.DeleteData(
                table: "SectionItemFieldSettingTranslations",
                keyColumn: "Id",
                keyValue: 101);

            migrationBuilder.DeleteData(
                table: "SectionItemFieldSettingTranslations",
                keyColumn: "Id",
                keyValue: 102);

            migrationBuilder.DeleteData(
                table: "SectionItemFieldSettingTranslations",
                keyColumn: "Id",
                keyValue: 103);

            migrationBuilder.DeleteData(
                table: "SectionItemFieldSettingTranslations",
                keyColumn: "Id",
                keyValue: 104);

            migrationBuilder.DeleteData(
                table: "SectionItemFieldSettingTranslations",
                keyColumn: "Id",
                keyValue: 105);

            migrationBuilder.DeleteData(
                table: "SectionItemFieldSettingTranslations",
                keyColumn: "Id",
                keyValue: 106);

            migrationBuilder.DeleteData(
                table: "SectionItemFieldSettingTranslations",
                keyColumn: "Id",
                keyValue: 107);

            migrationBuilder.DeleteData(
                table: "SectionItemFieldSettingTranslations",
                keyColumn: "Id",
                keyValue: 108);

            migrationBuilder.DeleteData(
                table: "SectionItemFieldSettingTranslations",
                keyColumn: "Id",
                keyValue: 109);

            migrationBuilder.DeleteData(
                table: "SectionItemFieldSettingTranslations",
                keyColumn: "Id",
                keyValue: 200);

            migrationBuilder.DeleteData(
                table: "SectionItemFieldSettingTranslations",
                keyColumn: "Id",
                keyValue: 201);

            migrationBuilder.DeleteData(
                table: "SectionItemFieldSettingTranslations",
                keyColumn: "Id",
                keyValue: 202);

            migrationBuilder.DeleteData(
                table: "SectionItemFieldSettingTranslations",
                keyColumn: "Id",
                keyValue: 203);

            migrationBuilder.DeleteData(
                table: "SectionItemSettingTranslations",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "SectionItemSettingTranslations",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "SectionItemSettingTranslations",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "SectionItemSettingTranslations",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "SectionItemFieldSettings",
                keyColumn: "Id",
                keyValue: 100);

            migrationBuilder.DeleteData(
                table: "SectionItemFieldSettings",
                keyColumn: "Id",
                keyValue: 101);

            migrationBuilder.DeleteData(
                table: "SectionItemFieldSettings",
                keyColumn: "Id",
                keyValue: 102);

            migrationBuilder.DeleteData(
                table: "SectionItemFieldSettings",
                keyColumn: "Id",
                keyValue: 103);

            migrationBuilder.DeleteData(
                table: "SectionItemFieldSettings",
                keyColumn: "Id",
                keyValue: 104);

            migrationBuilder.DeleteData(
                table: "SectionItemFieldSettings",
                keyColumn: "Id",
                keyValue: 200);

            migrationBuilder.DeleteData(
                table: "SectionItemFieldSettings",
                keyColumn: "Id",
                keyValue: 201);

            migrationBuilder.DeleteData(
                table: "SectionItemSettings",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "SectionItemSettings",
                keyColumn: "Id",
                keyValue: 20);
        }
    }
}
