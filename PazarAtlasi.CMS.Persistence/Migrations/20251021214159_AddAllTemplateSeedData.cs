using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace PazarAtlasi.CMS.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AddAllTemplateSeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "SectionItemSettings",
                columns: new[] { "Id", "AllowDynamicSectionItems", "ConfigurationKey", "CreatedAt", "CreatedBy", "DefaultItemCount", "ItemType", "MaxItems", "MinItems", "ParentSettingId", "Status", "TemplateId", "UIConfigurationJson", "UpdatedAt", "UpdatedBy" },
                values: new object[,]
                {
                    { 30, true, "mega-menu-category", new DateTime(2024, 10, 21, 10, 0, 0, 0, DateTimeKind.Unspecified), null, 3, 21, 6, 3, null, 1, 2, "{\"Layout\":\"grid\",\"Columns\":2,\"ShowPreview\":true,\"ShowReorder\":true,\"AddButtonText\":\"Add Category\",\"IconClass\":\"fa-th-large\"}", null, null },
                    { 40, true, "service-tab", new DateTime(2024, 10, 21, 10, 0, 0, 0, DateTimeKind.Unspecified), null, 4, 21, 6, 3, null, 1, 3, "{\"Layout\":\"list\",\"ShowPreview\":true,\"ShowReorder\":true,\"AddButtonText\":\"Add Tab\",\"IconClass\":\"fa-folder-open\"}", null, null },
                    { 50, true, "category", new DateTime(2024, 10, 21, 10, 0, 0, 0, DateTimeKind.Unspecified), null, 3, 21, 8, 3, null, 1, 4, "{\"Layout\":\"list\",\"ShowPreview\":true,\"ShowReorder\":true,\"AddButtonText\":\"Add Category\",\"IconClass\":\"fa-tags\"}", null, null },
                    { 60, true, "step", new DateTime(2024, 10, 21, 10, 0, 0, 0, DateTimeKind.Unspecified), null, 4, 6, 10, 2, null, 1, 6, "{\"Layout\":\"list\",\"ShowPreview\":true,\"ShowReorder\":true,\"AddButtonText\":\"Add Step\",\"IconClass\":\"fa-list-ol\"}", null, null },
                    { 70, true, "grid-item", new DateTime(2024, 10, 21, 10, 0, 0, 0, DateTimeKind.Unspecified), null, 6, 6, 12, 3, null, 1, 7, "{\"Layout\":\"grid\",\"Columns\":3,\"ShowPreview\":true,\"ShowReorder\":true,\"AddButtonText\":\"Add Grid Item\",\"IconClass\":\"fa-th\"}", null, null },
                    { 80, true, "masonry-image", new DateTime(2024, 10, 21, 10, 0, 0, 0, DateTimeKind.Unspecified), null, 8, 10, 20, 4, null, 1, 8, "{\"Layout\":\"grid\",\"Columns\":4,\"ShowPreview\":true,\"ShowReorder\":true,\"AddButtonText\":\"Add Image\",\"IconClass\":\"fa-images\"}", null, null },
                    { 90, true, "list-item", new DateTime(2024, 10, 21, 10, 0, 0, 0, DateTimeKind.Unspecified), null, 5, 6, 15, 3, null, 1, 10, "{\"Layout\":\"list\",\"ShowPreview\":true,\"ShowReorder\":true,\"AddButtonText\":\"Add List Item\",\"IconClass\":\"fa-list\"}", null, null }
                });

            migrationBuilder.InsertData(
                table: "SectionItemSettings",
                columns: new[] { "Id", "ConfigurationKey", "CreatedAt", "CreatedBy", "DefaultItemCount", "ItemType", "MaxItems", "MinItems", "ParentSettingId", "Status", "TemplateId", "UIConfigurationJson", "UpdatedAt", "UpdatedBy" },
                values: new object[] { 101, "single-item", new DateTime(2024, 10, 21, 10, 0, 0, 0, DateTimeKind.Unspecified), null, 1, 6, 1, 1, null, 1, 11, "{\"Layout\":\"list\",\"ShowPreview\":true,\"ShowReorder\":false,\"AddButtonText\":\"\",\"IconClass\":\"fa-star\"}", null, null });

            migrationBuilder.InsertData(
                table: "SectionItemSettings",
                columns: new[] { "Id", "AllowDynamicSectionItems", "ConfigurationKey", "CreatedAt", "CreatedBy", "DefaultItemCount", "ItemType", "MaxItems", "MinItems", "ParentSettingId", "Status", "TemplateId", "UIConfigurationJson", "UpdatedAt", "UpdatedBy" },
                values: new object[,]
                {
                    { 110, true, "multi-item", new DateTime(2024, 10, 21, 10, 0, 0, 0, DateTimeKind.Unspecified), null, 4, 6, 8, 2, null, 1, 12, "{\"Layout\":\"grid\",\"Columns\":2,\"ShowPreview\":true,\"ShowReorder\":true,\"AddButtonText\":\"Add Item\",\"IconClass\":\"fa-th-large\"}", null, null },
                    { 120, true, "panel", new DateTime(2024, 10, 21, 10, 0, 0, 0, DateTimeKind.Unspecified), null, 5, 6, 10, 3, null, 1, 13, "{\"Layout\":\"list\",\"ShowPreview\":true,\"ShowReorder\":true,\"AddButtonText\":\"Add Panel\",\"IconClass\":\"fa-bars\"}", null, null },
                    { 130, true, "tab", new DateTime(2024, 10, 21, 10, 0, 0, 0, DateTimeKind.Unspecified), null, 4, 6, 8, 2, null, 1, 14, "{\"Layout\":\"list\",\"ShowPreview\":true,\"ShowReorder\":true,\"AddButtonText\":\"Add Tab\",\"IconClass\":\"fa-folder\"}", null, null }
                });

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
                columns: new[] { "Id", "AllowDynamicSectionItems", "ConfigurationKey", "CreatedAt", "CreatedBy", "DefaultItemCount", "ItemType", "MaxItems", "MinItems", "ParentSettingId", "Status", "TemplateId", "UIConfigurationJson", "UpdatedAt", "UpdatedBy" },
                values: new object[,]
                {
                    { 31, true, "mega-menu-link", new DateTime(2024, 10, 21, 10, 0, 0, 0, DateTimeKind.Unspecified), null, 3, 7, 15, 2, 30, 1, 2, "{\"Layout\":\"list\",\"ShowPreview\":true,\"ShowReorder\":true,\"AddButtonText\":\"Add Link\",\"IconClass\":\"fa-link\"}", null, null },
                    { 51, true, "category-item", new DateTime(2024, 10, 21, 10, 0, 0, 0, DateTimeKind.Unspecified), null, 3, 7, 12, 1, 50, 1, 4, "{\"Layout\":\"list\",\"ShowPreview\":true,\"ShowReorder\":true,\"AddButtonText\":\"Add Item\",\"IconClass\":\"fa-link\"}", null, null }
                });

            migrationBuilder.InsertData(
                table: "SectionItemFieldSettingTranslations",
                columns: new[] { "Id", "CreatedAt", "CreatedBy", "Description", "Label", "LanguageId", "SectionItemFieldSettingId", "Status", "UpdatedAt", "UpdatedBy" },
                values: new object[,]
                {
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
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "SectionItemFieldSettingTranslations",
                keyColumn: "Id",
                keyValue: 3000);

            migrationBuilder.DeleteData(
                table: "SectionItemFieldSettingTranslations",
                keyColumn: "Id",
                keyValue: 3001);

            migrationBuilder.DeleteData(
                table: "SectionItemFieldSettingTranslations",
                keyColumn: "Id",
                keyValue: 3002);

            migrationBuilder.DeleteData(
                table: "SectionItemFieldSettingTranslations",
                keyColumn: "Id",
                keyValue: 3003);

            migrationBuilder.DeleteData(
                table: "SectionItemFieldSettingTranslations",
                keyColumn: "Id",
                keyValue: 3004);

            migrationBuilder.DeleteData(
                table: "SectionItemFieldSettingTranslations",
                keyColumn: "Id",
                keyValue: 3005);

            migrationBuilder.DeleteData(
                table: "SectionItemFieldSettingTranslations",
                keyColumn: "Id",
                keyValue: 3006);

            migrationBuilder.DeleteData(
                table: "SectionItemFieldSettingTranslations",
                keyColumn: "Id",
                keyValue: 3007);

            migrationBuilder.DeleteData(
                table: "SectionItemFieldSettingTranslations",
                keyColumn: "Id",
                keyValue: 3008);

            migrationBuilder.DeleteData(
                table: "SectionItemFieldSettingTranslations",
                keyColumn: "Id",
                keyValue: 3009);

            migrationBuilder.DeleteData(
                table: "SectionItemFieldSettingTranslations",
                keyColumn: "Id",
                keyValue: 3010);

            migrationBuilder.DeleteData(
                table: "SectionItemFieldSettingTranslations",
                keyColumn: "Id",
                keyValue: 3011);

            migrationBuilder.DeleteData(
                table: "SectionItemFieldSettingTranslations",
                keyColumn: "Id",
                keyValue: 4000);

            migrationBuilder.DeleteData(
                table: "SectionItemFieldSettingTranslations",
                keyColumn: "Id",
                keyValue: 4001);

            migrationBuilder.DeleteData(
                table: "SectionItemFieldSettingTranslations",
                keyColumn: "Id",
                keyValue: 4002);

            migrationBuilder.DeleteData(
                table: "SectionItemFieldSettingTranslations",
                keyColumn: "Id",
                keyValue: 4003);

            migrationBuilder.DeleteData(
                table: "SectionItemFieldSettingTranslations",
                keyColumn: "Id",
                keyValue: 4004);

            migrationBuilder.DeleteData(
                table: "SectionItemFieldSettingTranslations",
                keyColumn: "Id",
                keyValue: 4005);

            migrationBuilder.DeleteData(
                table: "SectionItemFieldSettingTranslations",
                keyColumn: "Id",
                keyValue: 4006);

            migrationBuilder.DeleteData(
                table: "SectionItemFieldSettingTranslations",
                keyColumn: "Id",
                keyValue: 4007);

            migrationBuilder.DeleteData(
                table: "SectionItemFieldSettingTranslations",
                keyColumn: "Id",
                keyValue: 5000);

            migrationBuilder.DeleteData(
                table: "SectionItemFieldSettingTranslations",
                keyColumn: "Id",
                keyValue: 5001);

            migrationBuilder.DeleteData(
                table: "SectionItemFieldSettingTranslations",
                keyColumn: "Id",
                keyValue: 5002);

            migrationBuilder.DeleteData(
                table: "SectionItemFieldSettingTranslations",
                keyColumn: "Id",
                keyValue: 5003);

            migrationBuilder.DeleteData(
                table: "SectionItemFieldSettingTranslations",
                keyColumn: "Id",
                keyValue: 5004);

            migrationBuilder.DeleteData(
                table: "SectionItemFieldSettingTranslations",
                keyColumn: "Id",
                keyValue: 5005);

            migrationBuilder.DeleteData(
                table: "SectionItemFieldSettingTranslations",
                keyColumn: "Id",
                keyValue: 5006);

            migrationBuilder.DeleteData(
                table: "SectionItemFieldSettingTranslations",
                keyColumn: "Id",
                keyValue: 5007);

            migrationBuilder.DeleteData(
                table: "SectionItemFieldSettingTranslations",
                keyColumn: "Id",
                keyValue: 5008);

            migrationBuilder.DeleteData(
                table: "SectionItemFieldSettingTranslations",
                keyColumn: "Id",
                keyValue: 5009);

            migrationBuilder.DeleteData(
                table: "SectionItemFieldSettingTranslations",
                keyColumn: "Id",
                keyValue: 6000);

            migrationBuilder.DeleteData(
                table: "SectionItemFieldSettingTranslations",
                keyColumn: "Id",
                keyValue: 6001);

            migrationBuilder.DeleteData(
                table: "SectionItemFieldSettingTranslations",
                keyColumn: "Id",
                keyValue: 6002);

            migrationBuilder.DeleteData(
                table: "SectionItemFieldSettingTranslations",
                keyColumn: "Id",
                keyValue: 6003);

            migrationBuilder.DeleteData(
                table: "SectionItemFieldSettingTranslations",
                keyColumn: "Id",
                keyValue: 6004);

            migrationBuilder.DeleteData(
                table: "SectionItemFieldSettingTranslations",
                keyColumn: "Id",
                keyValue: 6005);

            migrationBuilder.DeleteData(
                table: "SectionItemFieldSettingTranslations",
                keyColumn: "Id",
                keyValue: 7000);

            migrationBuilder.DeleteData(
                table: "SectionItemFieldSettingTranslations",
                keyColumn: "Id",
                keyValue: 7001);

            migrationBuilder.DeleteData(
                table: "SectionItemFieldSettingTranslations",
                keyColumn: "Id",
                keyValue: 7002);

            migrationBuilder.DeleteData(
                table: "SectionItemFieldSettingTranslations",
                keyColumn: "Id",
                keyValue: 7003);

            migrationBuilder.DeleteData(
                table: "SectionItemFieldSettingTranslations",
                keyColumn: "Id",
                keyValue: 7004);

            migrationBuilder.DeleteData(
                table: "SectionItemFieldSettingTranslations",
                keyColumn: "Id",
                keyValue: 7005);

            migrationBuilder.DeleteData(
                table: "SectionItemFieldSettingTranslations",
                keyColumn: "Id",
                keyValue: 7006);

            migrationBuilder.DeleteData(
                table: "SectionItemFieldSettingTranslations",
                keyColumn: "Id",
                keyValue: 7007);

            migrationBuilder.DeleteData(
                table: "SectionItemFieldSettingTranslations",
                keyColumn: "Id",
                keyValue: 8000);

            migrationBuilder.DeleteData(
                table: "SectionItemFieldSettingTranslations",
                keyColumn: "Id",
                keyValue: 8001);

            migrationBuilder.DeleteData(
                table: "SectionItemFieldSettingTranslations",
                keyColumn: "Id",
                keyValue: 8002);

            migrationBuilder.DeleteData(
                table: "SectionItemFieldSettingTranslations",
                keyColumn: "Id",
                keyValue: 8003);

            migrationBuilder.DeleteData(
                table: "SectionItemFieldSettingTranslations",
                keyColumn: "Id",
                keyValue: 8004);

            migrationBuilder.DeleteData(
                table: "SectionItemFieldSettingTranslations",
                keyColumn: "Id",
                keyValue: 8005);

            migrationBuilder.DeleteData(
                table: "SectionItemFieldSettingTranslations",
                keyColumn: "Id",
                keyValue: 8006);

            migrationBuilder.DeleteData(
                table: "SectionItemFieldSettingTranslations",
                keyColumn: "Id",
                keyValue: 8007);

            migrationBuilder.DeleteData(
                table: "SectionItemFieldSettingTranslations",
                keyColumn: "Id",
                keyValue: 9000);

            migrationBuilder.DeleteData(
                table: "SectionItemFieldSettingTranslations",
                keyColumn: "Id",
                keyValue: 9001);

            migrationBuilder.DeleteData(
                table: "SectionItemFieldSettingTranslations",
                keyColumn: "Id",
                keyValue: 9002);

            migrationBuilder.DeleteData(
                table: "SectionItemFieldSettingTranslations",
                keyColumn: "Id",
                keyValue: 9003);

            migrationBuilder.DeleteData(
                table: "SectionItemFieldSettingTranslations",
                keyColumn: "Id",
                keyValue: 9004);

            migrationBuilder.DeleteData(
                table: "SectionItemFieldSettingTranslations",
                keyColumn: "Id",
                keyValue: 9005);

            migrationBuilder.DeleteData(
                table: "SectionItemFieldSettingTranslations",
                keyColumn: "Id",
                keyValue: 10100);

            migrationBuilder.DeleteData(
                table: "SectionItemFieldSettingTranslations",
                keyColumn: "Id",
                keyValue: 10101);

            migrationBuilder.DeleteData(
                table: "SectionItemFieldSettingTranslations",
                keyColumn: "Id",
                keyValue: 10102);

            migrationBuilder.DeleteData(
                table: "SectionItemFieldSettingTranslations",
                keyColumn: "Id",
                keyValue: 10103);

            migrationBuilder.DeleteData(
                table: "SectionItemFieldSettingTranslations",
                keyColumn: "Id",
                keyValue: 10104);

            migrationBuilder.DeleteData(
                table: "SectionItemFieldSettingTranslations",
                keyColumn: "Id",
                keyValue: 10105);

            migrationBuilder.DeleteData(
                table: "SectionItemFieldSettingTranslations",
                keyColumn: "Id",
                keyValue: 10106);

            migrationBuilder.DeleteData(
                table: "SectionItemFieldSettingTranslations",
                keyColumn: "Id",
                keyValue: 10107);

            migrationBuilder.DeleteData(
                table: "SectionItemFieldSettingTranslations",
                keyColumn: "Id",
                keyValue: 10108);

            migrationBuilder.DeleteData(
                table: "SectionItemFieldSettingTranslations",
                keyColumn: "Id",
                keyValue: 10109);

            migrationBuilder.DeleteData(
                table: "SectionItemFieldSettingTranslations",
                keyColumn: "Id",
                keyValue: 10110);

            migrationBuilder.DeleteData(
                table: "SectionItemFieldSettingTranslations",
                keyColumn: "Id",
                keyValue: 10111);

            migrationBuilder.DeleteData(
                table: "SectionItemFieldSettingTranslations",
                keyColumn: "Id",
                keyValue: 11000);

            migrationBuilder.DeleteData(
                table: "SectionItemFieldSettingTranslations",
                keyColumn: "Id",
                keyValue: 11001);

            migrationBuilder.DeleteData(
                table: "SectionItemFieldSettingTranslations",
                keyColumn: "Id",
                keyValue: 11002);

            migrationBuilder.DeleteData(
                table: "SectionItemFieldSettingTranslations",
                keyColumn: "Id",
                keyValue: 11003);

            migrationBuilder.DeleteData(
                table: "SectionItemFieldSettingTranslations",
                keyColumn: "Id",
                keyValue: 11004);

            migrationBuilder.DeleteData(
                table: "SectionItemFieldSettingTranslations",
                keyColumn: "Id",
                keyValue: 11005);

            migrationBuilder.DeleteData(
                table: "SectionItemFieldSettingTranslations",
                keyColumn: "Id",
                keyValue: 11006);

            migrationBuilder.DeleteData(
                table: "SectionItemFieldSettingTranslations",
                keyColumn: "Id",
                keyValue: 11007);

            migrationBuilder.DeleteData(
                table: "SectionItemFieldSettingTranslations",
                keyColumn: "Id",
                keyValue: 12000);

            migrationBuilder.DeleteData(
                table: "SectionItemFieldSettingTranslations",
                keyColumn: "Id",
                keyValue: 12001);

            migrationBuilder.DeleteData(
                table: "SectionItemFieldSettingTranslations",
                keyColumn: "Id",
                keyValue: 12002);

            migrationBuilder.DeleteData(
                table: "SectionItemFieldSettingTranslations",
                keyColumn: "Id",
                keyValue: 12003);

            migrationBuilder.DeleteData(
                table: "SectionItemFieldSettingTranslations",
                keyColumn: "Id",
                keyValue: 12004);

            migrationBuilder.DeleteData(
                table: "SectionItemFieldSettingTranslations",
                keyColumn: "Id",
                keyValue: 12005);

            migrationBuilder.DeleteData(
                table: "SectionItemFieldSettingTranslations",
                keyColumn: "Id",
                keyValue: 13000);

            migrationBuilder.DeleteData(
                table: "SectionItemFieldSettingTranslations",
                keyColumn: "Id",
                keyValue: 13001);

            migrationBuilder.DeleteData(
                table: "SectionItemFieldSettingTranslations",
                keyColumn: "Id",
                keyValue: 13002);

            migrationBuilder.DeleteData(
                table: "SectionItemFieldSettingTranslations",
                keyColumn: "Id",
                keyValue: 13003);

            migrationBuilder.DeleteData(
                table: "SectionItemFieldSettingTranslations",
                keyColumn: "Id",
                keyValue: 13004);

            migrationBuilder.DeleteData(
                table: "SectionItemFieldSettingTranslations",
                keyColumn: "Id",
                keyValue: 13005);

            migrationBuilder.DeleteData(
                table: "SectionItemSettingTranslations",
                keyColumn: "Id",
                keyValue: 300);

            migrationBuilder.DeleteData(
                table: "SectionItemSettingTranslations",
                keyColumn: "Id",
                keyValue: 301);

            migrationBuilder.DeleteData(
                table: "SectionItemSettingTranslations",
                keyColumn: "Id",
                keyValue: 302);

            migrationBuilder.DeleteData(
                table: "SectionItemSettingTranslations",
                keyColumn: "Id",
                keyValue: 303);

            migrationBuilder.DeleteData(
                table: "SectionItemSettingTranslations",
                keyColumn: "Id",
                keyValue: 400);

            migrationBuilder.DeleteData(
                table: "SectionItemSettingTranslations",
                keyColumn: "Id",
                keyValue: 401);

            migrationBuilder.DeleteData(
                table: "SectionItemSettingTranslations",
                keyColumn: "Id",
                keyValue: 500);

            migrationBuilder.DeleteData(
                table: "SectionItemSettingTranslations",
                keyColumn: "Id",
                keyValue: 501);

            migrationBuilder.DeleteData(
                table: "SectionItemSettingTranslations",
                keyColumn: "Id",
                keyValue: 502);

            migrationBuilder.DeleteData(
                table: "SectionItemSettingTranslations",
                keyColumn: "Id",
                keyValue: 503);

            migrationBuilder.DeleteData(
                table: "SectionItemSettingTranslations",
                keyColumn: "Id",
                keyValue: 600);

            migrationBuilder.DeleteData(
                table: "SectionItemSettingTranslations",
                keyColumn: "Id",
                keyValue: 601);

            migrationBuilder.DeleteData(
                table: "SectionItemSettingTranslations",
                keyColumn: "Id",
                keyValue: 700);

            migrationBuilder.DeleteData(
                table: "SectionItemSettingTranslations",
                keyColumn: "Id",
                keyValue: 701);

            migrationBuilder.DeleteData(
                table: "SectionItemSettingTranslations",
                keyColumn: "Id",
                keyValue: 800);

            migrationBuilder.DeleteData(
                table: "SectionItemSettingTranslations",
                keyColumn: "Id",
                keyValue: 801);

            migrationBuilder.DeleteData(
                table: "SectionItemSettingTranslations",
                keyColumn: "Id",
                keyValue: 900);

            migrationBuilder.DeleteData(
                table: "SectionItemSettingTranslations",
                keyColumn: "Id",
                keyValue: 901);

            migrationBuilder.DeleteData(
                table: "SectionItemSettingTranslations",
                keyColumn: "Id",
                keyValue: 1010);

            migrationBuilder.DeleteData(
                table: "SectionItemSettingTranslations",
                keyColumn: "Id",
                keyValue: 1011);

            migrationBuilder.DeleteData(
                table: "SectionItemSettingTranslations",
                keyColumn: "Id",
                keyValue: 1100);

            migrationBuilder.DeleteData(
                table: "SectionItemSettingTranslations",
                keyColumn: "Id",
                keyValue: 1101);

            migrationBuilder.DeleteData(
                table: "SectionItemSettingTranslations",
                keyColumn: "Id",
                keyValue: 1200);

            migrationBuilder.DeleteData(
                table: "SectionItemSettingTranslations",
                keyColumn: "Id",
                keyValue: 1201);

            migrationBuilder.DeleteData(
                table: "SectionItemSettingTranslations",
                keyColumn: "Id",
                keyValue: 1300);

            migrationBuilder.DeleteData(
                table: "SectionItemSettingTranslations",
                keyColumn: "Id",
                keyValue: 1301);

            migrationBuilder.DeleteData(
                table: "SectionItemFieldSettings",
                keyColumn: "Id",
                keyValue: 300);

            migrationBuilder.DeleteData(
                table: "SectionItemFieldSettings",
                keyColumn: "Id",
                keyValue: 301);

            migrationBuilder.DeleteData(
                table: "SectionItemFieldSettings",
                keyColumn: "Id",
                keyValue: 302);

            migrationBuilder.DeleteData(
                table: "SectionItemFieldSettings",
                keyColumn: "Id",
                keyValue: 310);

            migrationBuilder.DeleteData(
                table: "SectionItemFieldSettings",
                keyColumn: "Id",
                keyValue: 311);

            migrationBuilder.DeleteData(
                table: "SectionItemFieldSettings",
                keyColumn: "Id",
                keyValue: 312);

            migrationBuilder.DeleteData(
                table: "SectionItemFieldSettings",
                keyColumn: "Id",
                keyValue: 400);

            migrationBuilder.DeleteData(
                table: "SectionItemFieldSettings",
                keyColumn: "Id",
                keyValue: 401);

            migrationBuilder.DeleteData(
                table: "SectionItemFieldSettings",
                keyColumn: "Id",
                keyValue: 402);

            migrationBuilder.DeleteData(
                table: "SectionItemFieldSettings",
                keyColumn: "Id",
                keyValue: 403);

            migrationBuilder.DeleteData(
                table: "SectionItemFieldSettings",
                keyColumn: "Id",
                keyValue: 500);

            migrationBuilder.DeleteData(
                table: "SectionItemFieldSettings",
                keyColumn: "Id",
                keyValue: 501);

            migrationBuilder.DeleteData(
                table: "SectionItemFieldSettings",
                keyColumn: "Id",
                keyValue: 510);

            migrationBuilder.DeleteData(
                table: "SectionItemFieldSettings",
                keyColumn: "Id",
                keyValue: 511);

            migrationBuilder.DeleteData(
                table: "SectionItemFieldSettings",
                keyColumn: "Id",
                keyValue: 512);

            migrationBuilder.DeleteData(
                table: "SectionItemFieldSettings",
                keyColumn: "Id",
                keyValue: 600);

            migrationBuilder.DeleteData(
                table: "SectionItemFieldSettings",
                keyColumn: "Id",
                keyValue: 601);

            migrationBuilder.DeleteData(
                table: "SectionItemFieldSettings",
                keyColumn: "Id",
                keyValue: 602);

            migrationBuilder.DeleteData(
                table: "SectionItemFieldSettings",
                keyColumn: "Id",
                keyValue: 700);

            migrationBuilder.DeleteData(
                table: "SectionItemFieldSettings",
                keyColumn: "Id",
                keyValue: 701);

            migrationBuilder.DeleteData(
                table: "SectionItemFieldSettings",
                keyColumn: "Id",
                keyValue: 702);

            migrationBuilder.DeleteData(
                table: "SectionItemFieldSettings",
                keyColumn: "Id",
                keyValue: 703);

            migrationBuilder.DeleteData(
                table: "SectionItemFieldSettings",
                keyColumn: "Id",
                keyValue: 800);

            migrationBuilder.DeleteData(
                table: "SectionItemFieldSettings",
                keyColumn: "Id",
                keyValue: 801);

            migrationBuilder.DeleteData(
                table: "SectionItemFieldSettings",
                keyColumn: "Id",
                keyValue: 802);

            migrationBuilder.DeleteData(
                table: "SectionItemFieldSettings",
                keyColumn: "Id",
                keyValue: 803);

            migrationBuilder.DeleteData(
                table: "SectionItemFieldSettings",
                keyColumn: "Id",
                keyValue: 900);

            migrationBuilder.DeleteData(
                table: "SectionItemFieldSettings",
                keyColumn: "Id",
                keyValue: 901);

            migrationBuilder.DeleteData(
                table: "SectionItemFieldSettings",
                keyColumn: "Id",
                keyValue: 902);

            migrationBuilder.DeleteData(
                table: "SectionItemFieldSettings",
                keyColumn: "Id",
                keyValue: 1010);

            migrationBuilder.DeleteData(
                table: "SectionItemFieldSettings",
                keyColumn: "Id",
                keyValue: 1011);

            migrationBuilder.DeleteData(
                table: "SectionItemFieldSettings",
                keyColumn: "Id",
                keyValue: 1012);

            migrationBuilder.DeleteData(
                table: "SectionItemFieldSettings",
                keyColumn: "Id",
                keyValue: 1013);

            migrationBuilder.DeleteData(
                table: "SectionItemFieldSettings",
                keyColumn: "Id",
                keyValue: 1014);

            migrationBuilder.DeleteData(
                table: "SectionItemFieldSettings",
                keyColumn: "Id",
                keyValue: 1015);

            migrationBuilder.DeleteData(
                table: "SectionItemFieldSettings",
                keyColumn: "Id",
                keyValue: 1100);

            migrationBuilder.DeleteData(
                table: "SectionItemFieldSettings",
                keyColumn: "Id",
                keyValue: 1101);

            migrationBuilder.DeleteData(
                table: "SectionItemFieldSettings",
                keyColumn: "Id",
                keyValue: 1102);

            migrationBuilder.DeleteData(
                table: "SectionItemFieldSettings",
                keyColumn: "Id",
                keyValue: 1103);

            migrationBuilder.DeleteData(
                table: "SectionItemFieldSettings",
                keyColumn: "Id",
                keyValue: 1200);

            migrationBuilder.DeleteData(
                table: "SectionItemFieldSettings",
                keyColumn: "Id",
                keyValue: 1201);

            migrationBuilder.DeleteData(
                table: "SectionItemFieldSettings",
                keyColumn: "Id",
                keyValue: 1202);

            migrationBuilder.DeleteData(
                table: "SectionItemFieldSettings",
                keyColumn: "Id",
                keyValue: 1300);

            migrationBuilder.DeleteData(
                table: "SectionItemFieldSettings",
                keyColumn: "Id",
                keyValue: 1301);

            migrationBuilder.DeleteData(
                table: "SectionItemFieldSettings",
                keyColumn: "Id",
                keyValue: 1302);

            migrationBuilder.DeleteData(
                table: "SectionItemSettings",
                keyColumn: "Id",
                keyValue: 31);

            migrationBuilder.DeleteData(
                table: "SectionItemSettings",
                keyColumn: "Id",
                keyValue: 40);

            migrationBuilder.DeleteData(
                table: "SectionItemSettings",
                keyColumn: "Id",
                keyValue: 51);

            migrationBuilder.DeleteData(
                table: "SectionItemSettings",
                keyColumn: "Id",
                keyValue: 60);

            migrationBuilder.DeleteData(
                table: "SectionItemSettings",
                keyColumn: "Id",
                keyValue: 70);

            migrationBuilder.DeleteData(
                table: "SectionItemSettings",
                keyColumn: "Id",
                keyValue: 80);

            migrationBuilder.DeleteData(
                table: "SectionItemSettings",
                keyColumn: "Id",
                keyValue: 90);

            migrationBuilder.DeleteData(
                table: "SectionItemSettings",
                keyColumn: "Id",
                keyValue: 101);

            migrationBuilder.DeleteData(
                table: "SectionItemSettings",
                keyColumn: "Id",
                keyValue: 110);

            migrationBuilder.DeleteData(
                table: "SectionItemSettings",
                keyColumn: "Id",
                keyValue: 120);

            migrationBuilder.DeleteData(
                table: "SectionItemSettings",
                keyColumn: "Id",
                keyValue: 130);

            migrationBuilder.DeleteData(
                table: "SectionItemSettings",
                keyColumn: "Id",
                keyValue: 30);

            migrationBuilder.DeleteData(
                table: "SectionItemSettings",
                keyColumn: "Id",
                keyValue: 50);
        }
    }
}
