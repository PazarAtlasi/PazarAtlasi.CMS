using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace PazarAtlasi.CMS.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class innhsa : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "SectionItems",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Description", "Type" },
                values: new object[] { "Homepage menu with quick access links", 26 });

            migrationBuilder.UpdateData(
                table: "SectionItems",
                keyColumn: "Id",
                keyValue: 3,
                column: "Type",
                value: 26);

            migrationBuilder.UpdateData(
                table: "SectionItems",
                keyColumn: "Id",
                keyValue: 4,
                column: "Type",
                value: 26);

            migrationBuilder.UpdateData(
                table: "SectionItems",
                keyColumn: "Id",
                keyValue: 5,
                column: "Type",
                value: 26);

            migrationBuilder.UpdateData(
                table: "SectionItems",
                keyColumn: "Id",
                keyValue: 6,
                column: "Type",
                value: 26);

            migrationBuilder.UpdateData(
                table: "SectionItems",
                keyColumn: "Id",
                keyValue: 16,
                column: "Type",
                value: 6);

            migrationBuilder.UpdateData(
                table: "SectionItems",
                keyColumn: "Id",
                keyValue: 17,
                column: "Type",
                value: 6);

            migrationBuilder.UpdateData(
                table: "SectionItems",
                keyColumn: "Id",
                keyValue: 18,
                column: "Type",
                value: 6);

            migrationBuilder.UpdateData(
                table: "SectionItems",
                keyColumn: "Id",
                keyValue: 19,
                column: "Type",
                value: 6);

            migrationBuilder.UpdateData(
                table: "SectionItems",
                keyColumn: "Id",
                keyValue: 20,
                column: "Type",
                value: 7);

            migrationBuilder.InsertData(
                table: "SectionItems",
                columns: new[] { "Id", "AllowRemove", "AllowReorder", "CreatedAt", "CreatedBy", "Description", "IconClass", "LinkedPageId", "ParentSectionItemId", "SectionId", "SortOrder", "Status", "TemplateId", "Title", "Type", "UpdatedAt", "UpdatedBy" },
                values: new object[,]
                {
                    { 21, true, true, new DateTime(2024, 10, 14, 10, 0, 0, 0, DateTimeKind.Unspecified), null, "Latest product arrivals and new releases", "fas fa-star", null, 2, 1, 1, 1, 2, "Yeni Ürünler", 26, null, null },
                    { 22, true, true, new DateTime(2024, 10, 14, 10, 0, 0, 0, DateTimeKind.Unspecified), null, "Most popular product categories", "fas fa-fire", null, 2, 1, 2, 1, 2, "Popüler Kategoriler", 26, null, null },
                    { 23, true, true, new DateTime(2024, 10, 14, 10, 0, 0, 0, DateTimeKind.Unspecified), null, "Current promotions and special offers", "fas fa-percentage", null, 2, 1, 3, 1, 2, "Kampanyalar", 26, null, null },
                    { 24, true, true, new DateTime(2024, 10, 14, 10, 0, 0, 0, DateTimeKind.Unspecified), null, "Customer reviews and testimonials", "fas fa-comments", null, 2, 1, 4, 1, 2, "Müşteri Yorumları", 26, null, null }
                });

            migrationBuilder.InsertData(
                table: "SectionItemFieldValues",
                columns: new[] { "Id", "CreatedAt", "CreatedBy", "JsonValue", "SectionItemFieldId", "SectionItemId", "Status", "UpdatedAt", "UpdatedBy", "Value" },
                values: new object[,]
                {
                    { 39, new DateTime(2024, 10, 14, 10, 0, 0, 0, DateTimeKind.Unspecified), null, null, 3, 21, 0, null, null, "Yeni Ürünler" },
                    { 40, new DateTime(2024, 10, 14, 10, 0, 0, 0, DateTimeKind.Unspecified), null, null, 4, 21, 0, null, null, "/products/new" },
                    { 41, new DateTime(2024, 10, 14, 10, 0, 0, 0, DateTimeKind.Unspecified), null, null, 5, 21, 0, null, null, "fas fa-star" },
                    { 42, new DateTime(2024, 10, 14, 10, 0, 0, 0, DateTimeKind.Unspecified), null, null, 6, 21, 0, null, null, "En yeni ürün koleksiyonları" },
                    { 43, new DateTime(2024, 10, 14, 10, 0, 0, 0, DateTimeKind.Unspecified), null, null, 9, 21, 0, null, null, "YENİ" },
                    { 44, new DateTime(2024, 10, 14, 10, 0, 0, 0, DateTimeKind.Unspecified), null, null, 10, 21, 0, null, null, "primary" },
                    { 45, new DateTime(2024, 10, 14, 10, 0, 0, 0, DateTimeKind.Unspecified), null, null, 3, 22, 0, null, null, "Popüler Kategoriler" },
                    { 46, new DateTime(2024, 10, 14, 10, 0, 0, 0, DateTimeKind.Unspecified), null, null, 4, 22, 0, null, null, "/categories/popular" },
                    { 47, new DateTime(2024, 10, 14, 10, 0, 0, 0, DateTimeKind.Unspecified), null, null, 5, 22, 0, null, null, "fas fa-fire" },
                    { 48, new DateTime(2024, 10, 14, 10, 0, 0, 0, DateTimeKind.Unspecified), null, null, 6, 22, 0, null, null, "En popüler ürün kategorileri" },
                    { 49, new DateTime(2024, 10, 14, 10, 0, 0, 0, DateTimeKind.Unspecified), null, null, 3, 23, 0, null, null, "Kampanyalar" },
                    { 50, new DateTime(2024, 10, 14, 10, 0, 0, 0, DateTimeKind.Unspecified), null, null, 4, 23, 0, null, null, "/campaigns" },
                    { 51, new DateTime(2024, 10, 14, 10, 0, 0, 0, DateTimeKind.Unspecified), null, null, 5, 23, 0, null, null, "fas fa-percentage" },
                    { 52, new DateTime(2024, 10, 14, 10, 0, 0, 0, DateTimeKind.Unspecified), null, null, 6, 23, 0, null, null, "Güncel kampanya ve fırsatlar" }
                });

            migrationBuilder.InsertData(
                table: "SectionItems",
                columns: new[] { "Id", "AllowRemove", "AllowReorder", "CreatedAt", "CreatedBy", "Description", "IconClass", "LinkedPageId", "ParentSectionItemId", "SectionId", "SortOrder", "Status", "TemplateId", "Title", "Type", "UpdatedAt", "UpdatedBy" },
                values: new object[,]
                {
                    { 25, true, true, new DateTime(2024, 10, 14, 10, 0, 0, 0, DateTimeKind.Unspecified), null, "Best selling products across all categories", "fas fa-trophy", null, 22, 1, 1, 1, 2, "En Çok Satan", 4, null, null },
                    { 26, true, true, new DateTime(2024, 10, 14, 10, 0, 0, 0, DateTimeKind.Unspecified), null, "Trending products and viral items", "fas fa-trending-up", null, 22, 1, 2, 1, 2, "Trend Ürünler", 4, null, null },
                    { 27, true, true, new DateTime(2024, 10, 14, 10, 0, 0, 0, DateTimeKind.Unspecified), null, "Editor's choice and curated collections", "fas fa-heart", null, 22, 1, 3, 1, 2, "Editörün Seçimi", 4, null, null },
                    { 28, true, true, new DateTime(2024, 10, 14, 10, 0, 0, 0, DateTimeKind.Unspecified), null, "Limited time flash sales with huge discounts", "fas fa-bolt", null, 23, 1, 1, 1, 2, "Flash Sale", 5, null, null },
                    { 29, true, true, new DateTime(2024, 10, 14, 10, 0, 0, 0, DateTimeKind.Unspecified), null, "Seasonal discounts and clearance sales", "fas fa-snowflake", null, 23, 1, 2, 1, 2, "Sezon İndirimi", 5, null, null },
                    { 30, true, true, new DateTime(2024, 10, 14, 10, 0, 0, 0, DateTimeKind.Unspecified), null, "Free shipping campaigns and offers", "fas fa-shipping-fast", null, 23, 1, 3, 1, 2, "Ücretsiz Kargo", 5, null, null }
                });

            migrationBuilder.InsertData(
                table: "SectionItemFieldValueTranslations",
                columns: new[] { "Id", "CreatedAt", "CreatedBy", "JsonValue", "LanguageId", "SectionItemFieldValueId", "Status", "UpdatedAt", "UpdatedBy", "Value" },
                values: new object[,]
                {
                    { 33, new DateTime(2024, 10, 14, 10, 0, 0, 0, DateTimeKind.Unspecified), null, null, 1, 39, 0, null, null, "Yeni Ürünler" },
                    { 34, new DateTime(2024, 10, 14, 10, 0, 0, 0, DateTimeKind.Unspecified), null, null, 2, 39, 0, null, null, "New Products" },
                    { 35, new DateTime(2024, 10, 14, 10, 0, 0, 0, DateTimeKind.Unspecified), null, null, 1, 42, 0, null, null, "En yeni ürün koleksiyonları" },
                    { 36, new DateTime(2024, 10, 14, 10, 0, 0, 0, DateTimeKind.Unspecified), null, null, 2, 42, 0, null, null, "Latest product collections" },
                    { 37, new DateTime(2024, 10, 14, 10, 0, 0, 0, DateTimeKind.Unspecified), null, null, 1, 43, 0, null, null, "YENİ" },
                    { 38, new DateTime(2024, 10, 14, 10, 0, 0, 0, DateTimeKind.Unspecified), null, null, 2, 43, 0, null, null, "NEW" },
                    { 39, new DateTime(2024, 10, 14, 10, 0, 0, 0, DateTimeKind.Unspecified), null, null, 1, 45, 0, null, null, "Popüler Kategoriler" },
                    { 40, new DateTime(2024, 10, 14, 10, 0, 0, 0, DateTimeKind.Unspecified), null, null, 2, 45, 0, null, null, "Popular Categories" },
                    { 41, new DateTime(2024, 10, 14, 10, 0, 0, 0, DateTimeKind.Unspecified), null, null, 1, 48, 0, null, null, "En popüler ürün kategorileri" },
                    { 42, new DateTime(2024, 10, 14, 10, 0, 0, 0, DateTimeKind.Unspecified), null, null, 2, 48, 0, null, null, "Most popular product categories" },
                    { 43, new DateTime(2024, 10, 14, 10, 0, 0, 0, DateTimeKind.Unspecified), null, null, 1, 49, 0, null, null, "Kampanyalar" },
                    { 44, new DateTime(2024, 10, 14, 10, 0, 0, 0, DateTimeKind.Unspecified), null, null, 2, 49, 0, null, null, "Campaigns" },
                    { 45, new DateTime(2024, 10, 14, 10, 0, 0, 0, DateTimeKind.Unspecified), null, null, 1, 52, 0, null, null, "Güncel kampanya ve fırsatlar" },
                    { 46, new DateTime(2024, 10, 14, 10, 0, 0, 0, DateTimeKind.Unspecified), null, null, 2, 52, 0, null, null, "Current campaigns and opportunities" }
                });

            migrationBuilder.InsertData(
                table: "SectionItemFieldValues",
                columns: new[] { "Id", "CreatedAt", "CreatedBy", "JsonValue", "SectionItemFieldId", "SectionItemId", "Status", "UpdatedAt", "UpdatedBy", "Value" },
                values: new object[,]
                {
                    { 53, new DateTime(2024, 10, 14, 10, 0, 0, 0, DateTimeKind.Unspecified), null, null, 3, 25, 0, null, null, "En Çok Satan" },
                    { 54, new DateTime(2024, 10, 14, 10, 0, 0, 0, DateTimeKind.Unspecified), null, null, 4, 25, 0, null, null, "/products/bestsellers" },
                    { 55, new DateTime(2024, 10, 14, 10, 0, 0, 0, DateTimeKind.Unspecified), null, null, 5, 25, 0, null, null, "fas fa-trophy" },
                    { 56, new DateTime(2024, 10, 14, 10, 0, 0, 0, DateTimeKind.Unspecified), null, null, 3, 28, 0, null, null, "Flash Sale" },
                    { 57, new DateTime(2024, 10, 14, 10, 0, 0, 0, DateTimeKind.Unspecified), null, null, 4, 28, 0, null, null, "/flash-sale" },
                    { 58, new DateTime(2024, 10, 14, 10, 0, 0, 0, DateTimeKind.Unspecified), null, null, 5, 28, 0, null, null, "fas fa-bolt" },
                    { 59, new DateTime(2024, 10, 14, 10, 0, 0, 0, DateTimeKind.Unspecified), null, null, 6, 28, 0, null, null, "Sınırlı süre büyük indirimler" },
                    { 60, new DateTime(2024, 10, 14, 10, 0, 0, 0, DateTimeKind.Unspecified), null, null, 9, 28, 0, null, null, "FLASH" },
                    { 61, new DateTime(2024, 10, 14, 10, 0, 0, 0, DateTimeKind.Unspecified), null, null, 10, 28, 0, null, null, "warning" }
                });

            migrationBuilder.InsertData(
                table: "SectionItemFieldValueTranslations",
                columns: new[] { "Id", "CreatedAt", "CreatedBy", "JsonValue", "LanguageId", "SectionItemFieldValueId", "Status", "UpdatedAt", "UpdatedBy", "Value" },
                values: new object[,]
                {
                    { 47, new DateTime(2024, 10, 14, 10, 0, 0, 0, DateTimeKind.Unspecified), null, null, 1, 53, 0, null, null, "En Çok Satan" },
                    { 48, new DateTime(2024, 10, 14, 10, 0, 0, 0, DateTimeKind.Unspecified), null, null, 2, 53, 0, null, null, "Best Sellers" },
                    { 49, new DateTime(2024, 10, 14, 10, 0, 0, 0, DateTimeKind.Unspecified), null, null, 1, 56, 0, null, null, "Flash Sale" },
                    { 50, new DateTime(2024, 10, 14, 10, 0, 0, 0, DateTimeKind.Unspecified), null, null, 2, 56, 0, null, null, "Flash Sale" },
                    { 51, new DateTime(2024, 10, 14, 10, 0, 0, 0, DateTimeKind.Unspecified), null, null, 1, 59, 0, null, null, "Sınırlı süre büyük indirimler" },
                    { 52, new DateTime(2024, 10, 14, 10, 0, 0, 0, DateTimeKind.Unspecified), null, null, 2, 59, 0, null, null, "Limited time huge discounts" },
                    { 53, new DateTime(2024, 10, 14, 10, 0, 0, 0, DateTimeKind.Unspecified), null, null, 1, 60, 0, null, null, "FLASH" },
                    { 54, new DateTime(2024, 10, 14, 10, 0, 0, 0, DateTimeKind.Unspecified), null, null, 2, 60, 0, null, null, "FLASH" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "SectionItemFieldValueTranslations",
                keyColumn: "Id",
                keyValue: 33);

            migrationBuilder.DeleteData(
                table: "SectionItemFieldValueTranslations",
                keyColumn: "Id",
                keyValue: 34);

            migrationBuilder.DeleteData(
                table: "SectionItemFieldValueTranslations",
                keyColumn: "Id",
                keyValue: 35);

            migrationBuilder.DeleteData(
                table: "SectionItemFieldValueTranslations",
                keyColumn: "Id",
                keyValue: 36);

            migrationBuilder.DeleteData(
                table: "SectionItemFieldValueTranslations",
                keyColumn: "Id",
                keyValue: 37);

            migrationBuilder.DeleteData(
                table: "SectionItemFieldValueTranslations",
                keyColumn: "Id",
                keyValue: 38);

            migrationBuilder.DeleteData(
                table: "SectionItemFieldValueTranslations",
                keyColumn: "Id",
                keyValue: 39);

            migrationBuilder.DeleteData(
                table: "SectionItemFieldValueTranslations",
                keyColumn: "Id",
                keyValue: 40);

            migrationBuilder.DeleteData(
                table: "SectionItemFieldValueTranslations",
                keyColumn: "Id",
                keyValue: 41);

            migrationBuilder.DeleteData(
                table: "SectionItemFieldValueTranslations",
                keyColumn: "Id",
                keyValue: 42);

            migrationBuilder.DeleteData(
                table: "SectionItemFieldValueTranslations",
                keyColumn: "Id",
                keyValue: 43);

            migrationBuilder.DeleteData(
                table: "SectionItemFieldValueTranslations",
                keyColumn: "Id",
                keyValue: 44);

            migrationBuilder.DeleteData(
                table: "SectionItemFieldValueTranslations",
                keyColumn: "Id",
                keyValue: 45);

            migrationBuilder.DeleteData(
                table: "SectionItemFieldValueTranslations",
                keyColumn: "Id",
                keyValue: 46);

            migrationBuilder.DeleteData(
                table: "SectionItemFieldValueTranslations",
                keyColumn: "Id",
                keyValue: 47);

            migrationBuilder.DeleteData(
                table: "SectionItemFieldValueTranslations",
                keyColumn: "Id",
                keyValue: 48);

            migrationBuilder.DeleteData(
                table: "SectionItemFieldValueTranslations",
                keyColumn: "Id",
                keyValue: 49);

            migrationBuilder.DeleteData(
                table: "SectionItemFieldValueTranslations",
                keyColumn: "Id",
                keyValue: 50);

            migrationBuilder.DeleteData(
                table: "SectionItemFieldValueTranslations",
                keyColumn: "Id",
                keyValue: 51);

            migrationBuilder.DeleteData(
                table: "SectionItemFieldValueTranslations",
                keyColumn: "Id",
                keyValue: 52);

            migrationBuilder.DeleteData(
                table: "SectionItemFieldValueTranslations",
                keyColumn: "Id",
                keyValue: 53);

            migrationBuilder.DeleteData(
                table: "SectionItemFieldValueTranslations",
                keyColumn: "Id",
                keyValue: 54);

            migrationBuilder.DeleteData(
                table: "SectionItemFieldValues",
                keyColumn: "Id",
                keyValue: 40);

            migrationBuilder.DeleteData(
                table: "SectionItemFieldValues",
                keyColumn: "Id",
                keyValue: 41);

            migrationBuilder.DeleteData(
                table: "SectionItemFieldValues",
                keyColumn: "Id",
                keyValue: 44);

            migrationBuilder.DeleteData(
                table: "SectionItemFieldValues",
                keyColumn: "Id",
                keyValue: 46);

            migrationBuilder.DeleteData(
                table: "SectionItemFieldValues",
                keyColumn: "Id",
                keyValue: 47);

            migrationBuilder.DeleteData(
                table: "SectionItemFieldValues",
                keyColumn: "Id",
                keyValue: 50);

            migrationBuilder.DeleteData(
                table: "SectionItemFieldValues",
                keyColumn: "Id",
                keyValue: 51);

            migrationBuilder.DeleteData(
                table: "SectionItemFieldValues",
                keyColumn: "Id",
                keyValue: 54);

            migrationBuilder.DeleteData(
                table: "SectionItemFieldValues",
                keyColumn: "Id",
                keyValue: 55);

            migrationBuilder.DeleteData(
                table: "SectionItemFieldValues",
                keyColumn: "Id",
                keyValue: 57);

            migrationBuilder.DeleteData(
                table: "SectionItemFieldValues",
                keyColumn: "Id",
                keyValue: 58);

            migrationBuilder.DeleteData(
                table: "SectionItemFieldValues",
                keyColumn: "Id",
                keyValue: 61);

            migrationBuilder.DeleteData(
                table: "SectionItems",
                keyColumn: "Id",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "SectionItems",
                keyColumn: "Id",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "SectionItems",
                keyColumn: "Id",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "SectionItems",
                keyColumn: "Id",
                keyValue: 29);

            migrationBuilder.DeleteData(
                table: "SectionItems",
                keyColumn: "Id",
                keyValue: 30);

            migrationBuilder.DeleteData(
                table: "SectionItemFieldValues",
                keyColumn: "Id",
                keyValue: 39);

            migrationBuilder.DeleteData(
                table: "SectionItemFieldValues",
                keyColumn: "Id",
                keyValue: 42);

            migrationBuilder.DeleteData(
                table: "SectionItemFieldValues",
                keyColumn: "Id",
                keyValue: 43);

            migrationBuilder.DeleteData(
                table: "SectionItemFieldValues",
                keyColumn: "Id",
                keyValue: 45);

            migrationBuilder.DeleteData(
                table: "SectionItemFieldValues",
                keyColumn: "Id",
                keyValue: 48);

            migrationBuilder.DeleteData(
                table: "SectionItemFieldValues",
                keyColumn: "Id",
                keyValue: 49);

            migrationBuilder.DeleteData(
                table: "SectionItemFieldValues",
                keyColumn: "Id",
                keyValue: 52);

            migrationBuilder.DeleteData(
                table: "SectionItemFieldValues",
                keyColumn: "Id",
                keyValue: 53);

            migrationBuilder.DeleteData(
                table: "SectionItemFieldValues",
                keyColumn: "Id",
                keyValue: 56);

            migrationBuilder.DeleteData(
                table: "SectionItemFieldValues",
                keyColumn: "Id",
                keyValue: 59);

            migrationBuilder.DeleteData(
                table: "SectionItemFieldValues",
                keyColumn: "Id",
                keyValue: 60);

            migrationBuilder.DeleteData(
                table: "SectionItems",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "SectionItems",
                keyColumn: "Id",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "SectionItems",
                keyColumn: "Id",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "SectionItems",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "SectionItems",
                keyColumn: "Id",
                keyValue: 23);

            migrationBuilder.UpdateData(
                table: "SectionItems",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Description", "Type" },
                values: new object[] { "Homepage menu item", 24 });

            migrationBuilder.UpdateData(
                table: "SectionItems",
                keyColumn: "Id",
                keyValue: 3,
                column: "Type",
                value: 24);

            migrationBuilder.UpdateData(
                table: "SectionItems",
                keyColumn: "Id",
                keyValue: 4,
                column: "Type",
                value: 24);

            migrationBuilder.UpdateData(
                table: "SectionItems",
                keyColumn: "Id",
                keyValue: 5,
                column: "Type",
                value: 24);

            migrationBuilder.UpdateData(
                table: "SectionItems",
                keyColumn: "Id",
                keyValue: 6,
                column: "Type",
                value: 24);

            migrationBuilder.UpdateData(
                table: "SectionItems",
                keyColumn: "Id",
                keyValue: 16,
                column: "Type",
                value: 4);

            migrationBuilder.UpdateData(
                table: "SectionItems",
                keyColumn: "Id",
                keyValue: 17,
                column: "Type",
                value: 4);

            migrationBuilder.UpdateData(
                table: "SectionItems",
                keyColumn: "Id",
                keyValue: 18,
                column: "Type",
                value: 4);

            migrationBuilder.UpdateData(
                table: "SectionItems",
                keyColumn: "Id",
                keyValue: 19,
                column: "Type",
                value: 4);

            migrationBuilder.UpdateData(
                table: "SectionItems",
                keyColumn: "Id",
                keyValue: 20,
                column: "Type",
                value: 5);
        }
    }
}
