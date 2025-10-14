using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace PazarAtlasi.CMS.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class saasf : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "SectionTemplates",
                columns: new[] { "Id", "CreatedAt", "CreatedBy", "CustomConfiguration", "IsDeleted", "SectionId", "SectionType", "Status", "TemplateId", "UpdatedAt", "UpdatedBy" },
                values: new object[,]
                {
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
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "SectionTemplates",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "SectionTemplates",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "SectionTemplates",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "SectionTemplates",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "SectionTemplates",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "SectionTemplates",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "SectionTemplates",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "SectionTemplates",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "SectionTemplates",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "SectionTemplates",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "SectionTemplates",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "SectionTemplates",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "SectionTemplates",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "SectionTemplates",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "SectionTemplates",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "SectionTemplates",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "SectionTemplates",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "SectionTemplates",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "SectionTemplates",
                keyColumn: "Id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "SectionTemplates",
                keyColumn: "Id",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "SectionTemplates",
                keyColumn: "Id",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "SectionTemplates",
                keyColumn: "Id",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "SectionTemplates",
                keyColumn: "Id",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "SectionTemplates",
                keyColumn: "Id",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "SectionTemplates",
                keyColumn: "Id",
                keyValue: 29);

            migrationBuilder.DeleteData(
                table: "SectionTemplates",
                keyColumn: "Id",
                keyValue: 30);

            migrationBuilder.DeleteData(
                table: "SectionTemplates",
                keyColumn: "Id",
                keyValue: 31);

            migrationBuilder.DeleteData(
                table: "SectionTemplates",
                keyColumn: "Id",
                keyValue: 32);

            migrationBuilder.DeleteData(
                table: "SectionTemplates",
                keyColumn: "Id",
                keyValue: 33);

            migrationBuilder.DeleteData(
                table: "SectionTemplates",
                keyColumn: "Id",
                keyValue: 34);

            migrationBuilder.DeleteData(
                table: "SectionTemplates",
                keyColumn: "Id",
                keyValue: 35);

            migrationBuilder.DeleteData(
                table: "SectionTemplates",
                keyColumn: "Id",
                keyValue: 36);

            migrationBuilder.DeleteData(
                table: "SectionTemplates",
                keyColumn: "Id",
                keyValue: 37);

            migrationBuilder.DeleteData(
                table: "SectionTemplates",
                keyColumn: "Id",
                keyValue: 38);

            migrationBuilder.DeleteData(
                table: "SectionTemplates",
                keyColumn: "Id",
                keyValue: 39);

            migrationBuilder.DeleteData(
                table: "SectionTemplates",
                keyColumn: "Id",
                keyValue: 40);

            migrationBuilder.DeleteData(
                table: "SectionTemplates",
                keyColumn: "Id",
                keyValue: 41);

            migrationBuilder.DeleteData(
                table: "SectionTemplates",
                keyColumn: "Id",
                keyValue: 42);

            migrationBuilder.DeleteData(
                table: "SectionTemplates",
                keyColumn: "Id",
                keyValue: 43);

            migrationBuilder.DeleteData(
                table: "SectionTemplates",
                keyColumn: "Id",
                keyValue: 44);

            migrationBuilder.DeleteData(
                table: "SectionTemplates",
                keyColumn: "Id",
                keyValue: 45);

            migrationBuilder.DeleteData(
                table: "SectionTemplates",
                keyColumn: "Id",
                keyValue: 46);

            migrationBuilder.DeleteData(
                table: "SectionTemplates",
                keyColumn: "Id",
                keyValue: 47);

            migrationBuilder.DeleteData(
                table: "SectionTemplates",
                keyColumn: "Id",
                keyValue: 48);

            migrationBuilder.DeleteData(
                table: "SectionTemplates",
                keyColumn: "Id",
                keyValue: 49);

            migrationBuilder.DeleteData(
                table: "SectionTemplates",
                keyColumn: "Id",
                keyValue: 50);

            migrationBuilder.DeleteData(
                table: "SectionTemplates",
                keyColumn: "Id",
                keyValue: 51);

            migrationBuilder.DeleteData(
                table: "SectionTemplates",
                keyColumn: "Id",
                keyValue: 52);

            migrationBuilder.DeleteData(
                table: "SectionTemplates",
                keyColumn: "Id",
                keyValue: 53);

            migrationBuilder.DeleteData(
                table: "SectionTemplates",
                keyColumn: "Id",
                keyValue: 54);

            migrationBuilder.DeleteData(
                table: "SectionTemplates",
                keyColumn: "Id",
                keyValue: 55);

            migrationBuilder.DeleteData(
                table: "SectionTemplates",
                keyColumn: "Id",
                keyValue: 56);

            migrationBuilder.DeleteData(
                table: "SectionTemplates",
                keyColumn: "Id",
                keyValue: 57);

            migrationBuilder.DeleteData(
                table: "SectionTemplates",
                keyColumn: "Id",
                keyValue: 58);

            migrationBuilder.DeleteData(
                table: "SectionTemplates",
                keyColumn: "Id",
                keyValue: 59);

            migrationBuilder.DeleteData(
                table: "SectionTemplates",
                keyColumn: "Id",
                keyValue: 60);

            migrationBuilder.DeleteData(
                table: "SectionTemplates",
                keyColumn: "Id",
                keyValue: 61);

            migrationBuilder.DeleteData(
                table: "SectionTemplates",
                keyColumn: "Id",
                keyValue: 62);

            migrationBuilder.DeleteData(
                table: "SectionTemplates",
                keyColumn: "Id",
                keyValue: 63);

            migrationBuilder.DeleteData(
                table: "SectionTemplates",
                keyColumn: "Id",
                keyValue: 64);

            migrationBuilder.DeleteData(
                table: "SectionTemplates",
                keyColumn: "Id",
                keyValue: 65);

            migrationBuilder.DeleteData(
                table: "SectionTemplates",
                keyColumn: "Id",
                keyValue: 66);

            migrationBuilder.DeleteData(
                table: "SectionTemplates",
                keyColumn: "Id",
                keyValue: 67);

            migrationBuilder.DeleteData(
                table: "SectionTemplates",
                keyColumn: "Id",
                keyValue: 68);

            migrationBuilder.DeleteData(
                table: "SectionTemplates",
                keyColumn: "Id",
                keyValue: 69);

            migrationBuilder.DeleteData(
                table: "SectionTemplates",
                keyColumn: "Id",
                keyValue: 70);

            migrationBuilder.DeleteData(
                table: "SectionTemplates",
                keyColumn: "Id",
                keyValue: 71);

            migrationBuilder.DeleteData(
                table: "SectionTemplates",
                keyColumn: "Id",
                keyValue: 72);

            migrationBuilder.DeleteData(
                table: "SectionTemplates",
                keyColumn: "Id",
                keyValue: 73);

            migrationBuilder.DeleteData(
                table: "SectionTemplates",
                keyColumn: "Id",
                keyValue: 74);

            migrationBuilder.DeleteData(
                table: "SectionTemplates",
                keyColumn: "Id",
                keyValue: 75);

            migrationBuilder.DeleteData(
                table: "SectionTemplates",
                keyColumn: "Id",
                keyValue: 76);

            migrationBuilder.DeleteData(
                table: "SectionTemplates",
                keyColumn: "Id",
                keyValue: 77);

            migrationBuilder.DeleteData(
                table: "SectionTemplates",
                keyColumn: "Id",
                keyValue: 78);

            migrationBuilder.DeleteData(
                table: "SectionTemplates",
                keyColumn: "Id",
                keyValue: 79);

            migrationBuilder.DeleteData(
                table: "SectionTemplates",
                keyColumn: "Id",
                keyValue: 80);

            migrationBuilder.DeleteData(
                table: "SectionTemplates",
                keyColumn: "Id",
                keyValue: 81);

            migrationBuilder.DeleteData(
                table: "SectionTemplates",
                keyColumn: "Id",
                keyValue: 82);

            migrationBuilder.DeleteData(
                table: "SectionTemplates",
                keyColumn: "Id",
                keyValue: 83);

            migrationBuilder.DeleteData(
                table: "SectionTemplates",
                keyColumn: "Id",
                keyValue: 84);

            migrationBuilder.DeleteData(
                table: "SectionTemplates",
                keyColumn: "Id",
                keyValue: 85);

            migrationBuilder.DeleteData(
                table: "SectionTemplates",
                keyColumn: "Id",
                keyValue: 86);

            migrationBuilder.DeleteData(
                table: "SectionTemplates",
                keyColumn: "Id",
                keyValue: 87);

            migrationBuilder.DeleteData(
                table: "SectionTemplates",
                keyColumn: "Id",
                keyValue: 88);

            migrationBuilder.DeleteData(
                table: "SectionTemplates",
                keyColumn: "Id",
                keyValue: 89);

            migrationBuilder.DeleteData(
                table: "SectionTemplates",
                keyColumn: "Id",
                keyValue: 90);

            migrationBuilder.DeleteData(
                table: "SectionTemplates",
                keyColumn: "Id",
                keyValue: 91);

            migrationBuilder.DeleteData(
                table: "SectionTemplates",
                keyColumn: "Id",
                keyValue: 92);

            migrationBuilder.DeleteData(
                table: "SectionTemplates",
                keyColumn: "Id",
                keyValue: 93);

            migrationBuilder.DeleteData(
                table: "SectionTemplates",
                keyColumn: "Id",
                keyValue: 94);

            migrationBuilder.DeleteData(
                table: "SectionTemplates",
                keyColumn: "Id",
                keyValue: 95);

            migrationBuilder.DeleteData(
                table: "SectionTemplates",
                keyColumn: "Id",
                keyValue: 96);

            migrationBuilder.DeleteData(
                table: "SectionTemplates",
                keyColumn: "Id",
                keyValue: 97);

            migrationBuilder.DeleteData(
                table: "SectionTemplates",
                keyColumn: "Id",
                keyValue: 98);

            migrationBuilder.DeleteData(
                table: "SectionTemplates",
                keyColumn: "Id",
                keyValue: 99);

            migrationBuilder.DeleteData(
                table: "SectionTemplates",
                keyColumn: "Id",
                keyValue: 100);

            migrationBuilder.DeleteData(
                table: "SectionTemplates",
                keyColumn: "Id",
                keyValue: 101);

            migrationBuilder.DeleteData(
                table: "SectionTemplates",
                keyColumn: "Id",
                keyValue: 102);

            migrationBuilder.DeleteData(
                table: "SectionTemplates",
                keyColumn: "Id",
                keyValue: 103);

            migrationBuilder.DeleteData(
                table: "SectionTemplates",
                keyColumn: "Id",
                keyValue: 104);

            migrationBuilder.DeleteData(
                table: "SectionTemplates",
                keyColumn: "Id",
                keyValue: 105);

            migrationBuilder.DeleteData(
                table: "SectionTemplates",
                keyColumn: "Id",
                keyValue: 106);

            migrationBuilder.DeleteData(
                table: "SectionTemplates",
                keyColumn: "Id",
                keyValue: 107);

            migrationBuilder.DeleteData(
                table: "SectionTemplates",
                keyColumn: "Id",
                keyValue: 108);

            migrationBuilder.DeleteData(
                table: "SectionTemplates",
                keyColumn: "Id",
                keyValue: 109);

            migrationBuilder.DeleteData(
                table: "SectionTemplates",
                keyColumn: "Id",
                keyValue: 110);

            migrationBuilder.DeleteData(
                table: "SectionTemplates",
                keyColumn: "Id",
                keyValue: 111);

            migrationBuilder.DeleteData(
                table: "SectionTemplates",
                keyColumn: "Id",
                keyValue: 112);

            migrationBuilder.DeleteData(
                table: "SectionTemplates",
                keyColumn: "Id",
                keyValue: 113);

            migrationBuilder.DeleteData(
                table: "SectionTemplates",
                keyColumn: "Id",
                keyValue: 114);

            migrationBuilder.DeleteData(
                table: "SectionTemplates",
                keyColumn: "Id",
                keyValue: 115);

            migrationBuilder.DeleteData(
                table: "SectionTemplates",
                keyColumn: "Id",
                keyValue: 116);

            migrationBuilder.DeleteData(
                table: "SectionTemplates",
                keyColumn: "Id",
                keyValue: 117);

            migrationBuilder.DeleteData(
                table: "SectionTemplates",
                keyColumn: "Id",
                keyValue: 118);

            migrationBuilder.DeleteData(
                table: "SectionTemplates",
                keyColumn: "Id",
                keyValue: 119);

            migrationBuilder.DeleteData(
                table: "SectionTemplates",
                keyColumn: "Id",
                keyValue: 120);

            migrationBuilder.DeleteData(
                table: "SectionTemplates",
                keyColumn: "Id",
                keyValue: 121);

            migrationBuilder.DeleteData(
                table: "SectionTemplates",
                keyColumn: "Id",
                keyValue: 122);

            migrationBuilder.DeleteData(
                table: "SectionTemplates",
                keyColumn: "Id",
                keyValue: 123);

            migrationBuilder.DeleteData(
                table: "SectionTemplates",
                keyColumn: "Id",
                keyValue: 124);

            migrationBuilder.DeleteData(
                table: "SectionTemplates",
                keyColumn: "Id",
                keyValue: 125);

            migrationBuilder.DeleteData(
                table: "SectionTemplates",
                keyColumn: "Id",
                keyValue: 126);

            migrationBuilder.DeleteData(
                table: "SectionTemplates",
                keyColumn: "Id",
                keyValue: 127);

            migrationBuilder.DeleteData(
                table: "SectionTemplates",
                keyColumn: "Id",
                keyValue: 128);

            migrationBuilder.DeleteData(
                table: "SectionTemplates",
                keyColumn: "Id",
                keyValue: 129);

            migrationBuilder.DeleteData(
                table: "SectionTemplates",
                keyColumn: "Id",
                keyValue: 130);

            migrationBuilder.DeleteData(
                table: "SectionTemplates",
                keyColumn: "Id",
                keyValue: 131);

            migrationBuilder.DeleteData(
                table: "SectionTemplates",
                keyColumn: "Id",
                keyValue: 132);

            migrationBuilder.DeleteData(
                table: "SectionTemplates",
                keyColumn: "Id",
                keyValue: 133);

            migrationBuilder.DeleteData(
                table: "SectionTemplates",
                keyColumn: "Id",
                keyValue: 134);

            migrationBuilder.DeleteData(
                table: "SectionTemplates",
                keyColumn: "Id",
                keyValue: 135);

            migrationBuilder.DeleteData(
                table: "SectionTemplates",
                keyColumn: "Id",
                keyValue: 136);

            migrationBuilder.DeleteData(
                table: "SectionTemplates",
                keyColumn: "Id",
                keyValue: 137);

            migrationBuilder.DeleteData(
                table: "SectionTemplates",
                keyColumn: "Id",
                keyValue: 138);

            migrationBuilder.DeleteData(
                table: "SectionTemplates",
                keyColumn: "Id",
                keyValue: 139);

            migrationBuilder.DeleteData(
                table: "SectionTemplates",
                keyColumn: "Id",
                keyValue: 140);

            migrationBuilder.DeleteData(
                table: "SectionTemplates",
                keyColumn: "Id",
                keyValue: 141);

            migrationBuilder.DeleteData(
                table: "SectionTemplates",
                keyColumn: "Id",
                keyValue: 142);

            migrationBuilder.DeleteData(
                table: "SectionTemplates",
                keyColumn: "Id",
                keyValue: 143);

            migrationBuilder.DeleteData(
                table: "SectionTemplates",
                keyColumn: "Id",
                keyValue: 144);

            migrationBuilder.DeleteData(
                table: "SectionTemplates",
                keyColumn: "Id",
                keyValue: 145);

            migrationBuilder.DeleteData(
                table: "SectionTemplates",
                keyColumn: "Id",
                keyValue: 146);

            migrationBuilder.DeleteData(
                table: "SectionTemplates",
                keyColumn: "Id",
                keyValue: 147);

            migrationBuilder.DeleteData(
                table: "SectionTemplates",
                keyColumn: "Id",
                keyValue: 148);

            migrationBuilder.DeleteData(
                table: "SectionTemplates",
                keyColumn: "Id",
                keyValue: 149);

            migrationBuilder.DeleteData(
                table: "SectionTemplates",
                keyColumn: "Id",
                keyValue: 150);

            migrationBuilder.DeleteData(
                table: "SectionTemplates",
                keyColumn: "Id",
                keyValue: 151);

            migrationBuilder.DeleteData(
                table: "SectionTemplates",
                keyColumn: "Id",
                keyValue: 152);

            migrationBuilder.DeleteData(
                table: "SectionTemplates",
                keyColumn: "Id",
                keyValue: 153);

            migrationBuilder.DeleteData(
                table: "SectionTemplates",
                keyColumn: "Id",
                keyValue: 154);

            migrationBuilder.DeleteData(
                table: "SectionTemplates",
                keyColumn: "Id",
                keyValue: 155);

            migrationBuilder.DeleteData(
                table: "SectionTemplates",
                keyColumn: "Id",
                keyValue: 156);

            migrationBuilder.DeleteData(
                table: "SectionTemplates",
                keyColumn: "Id",
                keyValue: 157);

            migrationBuilder.DeleteData(
                table: "SectionTemplates",
                keyColumn: "Id",
                keyValue: 158);

            migrationBuilder.DeleteData(
                table: "SectionTemplates",
                keyColumn: "Id",
                keyValue: 159);

            migrationBuilder.DeleteData(
                table: "SectionTemplates",
                keyColumn: "Id",
                keyValue: 160);

            migrationBuilder.DeleteData(
                table: "SectionTemplates",
                keyColumn: "Id",
                keyValue: 161);

            migrationBuilder.DeleteData(
                table: "SectionTemplates",
                keyColumn: "Id",
                keyValue: 162);

            migrationBuilder.DeleteData(
                table: "SectionTemplates",
                keyColumn: "Id",
                keyValue: 163);

            migrationBuilder.DeleteData(
                table: "SectionTemplates",
                keyColumn: "Id",
                keyValue: 164);

            migrationBuilder.DeleteData(
                table: "SectionTemplates",
                keyColumn: "Id",
                keyValue: 165);

            migrationBuilder.DeleteData(
                table: "SectionTemplates",
                keyColumn: "Id",
                keyValue: 166);

            migrationBuilder.DeleteData(
                table: "SectionTemplates",
                keyColumn: "Id",
                keyValue: 167);

            migrationBuilder.DeleteData(
                table: "SectionTemplates",
                keyColumn: "Id",
                keyValue: 168);

            migrationBuilder.DeleteData(
                table: "SectionTemplates",
                keyColumn: "Id",
                keyValue: 169);

            migrationBuilder.DeleteData(
                table: "SectionTemplates",
                keyColumn: "Id",
                keyValue: 170);

            migrationBuilder.DeleteData(
                table: "SectionTemplates",
                keyColumn: "Id",
                keyValue: 171);

            migrationBuilder.DeleteData(
                table: "SectionTemplates",
                keyColumn: "Id",
                keyValue: 172);

            migrationBuilder.DeleteData(
                table: "SectionTemplates",
                keyColumn: "Id",
                keyValue: 173);

            migrationBuilder.DeleteData(
                table: "SectionTemplates",
                keyColumn: "Id",
                keyValue: 174);

            migrationBuilder.DeleteData(
                table: "SectionTemplates",
                keyColumn: "Id",
                keyValue: 175);

            migrationBuilder.DeleteData(
                table: "SectionTemplates",
                keyColumn: "Id",
                keyValue: 176);

            migrationBuilder.DeleteData(
                table: "SectionTemplates",
                keyColumn: "Id",
                keyValue: 177);

            migrationBuilder.DeleteData(
                table: "SectionTemplates",
                keyColumn: "Id",
                keyValue: 178);

            migrationBuilder.DeleteData(
                table: "SectionTemplates",
                keyColumn: "Id",
                keyValue: 179);

            migrationBuilder.DeleteData(
                table: "SectionTemplates",
                keyColumn: "Id",
                keyValue: 180);

            migrationBuilder.DeleteData(
                table: "SectionTemplates",
                keyColumn: "Id",
                keyValue: 181);

            migrationBuilder.DeleteData(
                table: "SectionTemplates",
                keyColumn: "Id",
                keyValue: 182);

            migrationBuilder.DeleteData(
                table: "SectionTemplates",
                keyColumn: "Id",
                keyValue: 183);

            migrationBuilder.DeleteData(
                table: "SectionTemplates",
                keyColumn: "Id",
                keyValue: 184);

            migrationBuilder.DeleteData(
                table: "SectionTemplates",
                keyColumn: "Id",
                keyValue: 185);

            migrationBuilder.DeleteData(
                table: "SectionTemplates",
                keyColumn: "Id",
                keyValue: 186);

            migrationBuilder.DeleteData(
                table: "SectionTemplates",
                keyColumn: "Id",
                keyValue: 187);

            migrationBuilder.DeleteData(
                table: "SectionTemplates",
                keyColumn: "Id",
                keyValue: 188);

            migrationBuilder.DeleteData(
                table: "SectionTemplates",
                keyColumn: "Id",
                keyValue: 189);

            migrationBuilder.DeleteData(
                table: "SectionTemplates",
                keyColumn: "Id",
                keyValue: 190);

            migrationBuilder.DeleteData(
                table: "SectionTemplates",
                keyColumn: "Id",
                keyValue: 191);

            migrationBuilder.DeleteData(
                table: "SectionTemplates",
                keyColumn: "Id",
                keyValue: 192);

            migrationBuilder.DeleteData(
                table: "SectionTemplates",
                keyColumn: "Id",
                keyValue: 193);

            migrationBuilder.DeleteData(
                table: "SectionTemplates",
                keyColumn: "Id",
                keyValue: 194);

            migrationBuilder.DeleteData(
                table: "SectionTemplates",
                keyColumn: "Id",
                keyValue: 195);

            migrationBuilder.DeleteData(
                table: "SectionTemplates",
                keyColumn: "Id",
                keyValue: 196);

            migrationBuilder.DeleteData(
                table: "SectionTemplates",
                keyColumn: "Id",
                keyValue: 197);

            migrationBuilder.DeleteData(
                table: "SectionTemplates",
                keyColumn: "Id",
                keyValue: 198);

            migrationBuilder.DeleteData(
                table: "SectionTemplates",
                keyColumn: "Id",
                keyValue: 199);

            migrationBuilder.DeleteData(
                table: "SectionTemplates",
                keyColumn: "Id",
                keyValue: 200);

            migrationBuilder.DeleteData(
                table: "SectionTemplates",
                keyColumn: "Id",
                keyValue: 201);

            migrationBuilder.DeleteData(
                table: "SectionTemplates",
                keyColumn: "Id",
                keyValue: 202);

            migrationBuilder.DeleteData(
                table: "SectionTemplates",
                keyColumn: "Id",
                keyValue: 203);

            migrationBuilder.DeleteData(
                table: "SectionTemplates",
                keyColumn: "Id",
                keyValue: 204);

            migrationBuilder.DeleteData(
                table: "SectionTemplates",
                keyColumn: "Id",
                keyValue: 205);

            migrationBuilder.DeleteData(
                table: "SectionTemplates",
                keyColumn: "Id",
                keyValue: 206);

            migrationBuilder.DeleteData(
                table: "SectionTemplates",
                keyColumn: "Id",
                keyValue: 207);

            migrationBuilder.DeleteData(
                table: "SectionTemplates",
                keyColumn: "Id",
                keyValue: 208);

            migrationBuilder.DeleteData(
                table: "SectionTemplates",
                keyColumn: "Id",
                keyValue: 209);

            migrationBuilder.DeleteData(
                table: "SectionTemplates",
                keyColumn: "Id",
                keyValue: 210);

            migrationBuilder.DeleteData(
                table: "SectionTemplates",
                keyColumn: "Id",
                keyValue: 211);

            migrationBuilder.DeleteData(
                table: "SectionTemplates",
                keyColumn: "Id",
                keyValue: 212);

            migrationBuilder.DeleteData(
                table: "SectionTemplates",
                keyColumn: "Id",
                keyValue: 213);

            migrationBuilder.DeleteData(
                table: "SectionTemplates",
                keyColumn: "Id",
                keyValue: 214);

            migrationBuilder.DeleteData(
                table: "SectionTemplates",
                keyColumn: "Id",
                keyValue: 215);

            migrationBuilder.DeleteData(
                table: "SectionTemplates",
                keyColumn: "Id",
                keyValue: 216);

            migrationBuilder.DeleteData(
                table: "SectionTemplates",
                keyColumn: "Id",
                keyValue: 217);

            migrationBuilder.DeleteData(
                table: "SectionTemplates",
                keyColumn: "Id",
                keyValue: 218);

            migrationBuilder.DeleteData(
                table: "SectionTemplates",
                keyColumn: "Id",
                keyValue: 219);

            migrationBuilder.DeleteData(
                table: "SectionTemplates",
                keyColumn: "Id",
                keyValue: 220);

            migrationBuilder.DeleteData(
                table: "SectionTemplates",
                keyColumn: "Id",
                keyValue: 221);

            migrationBuilder.DeleteData(
                table: "SectionTemplates",
                keyColumn: "Id",
                keyValue: 222);

            migrationBuilder.DeleteData(
                table: "SectionTemplates",
                keyColumn: "Id",
                keyValue: 223);

            migrationBuilder.DeleteData(
                table: "SectionTemplates",
                keyColumn: "Id",
                keyValue: 224);

            migrationBuilder.DeleteData(
                table: "SectionTemplates",
                keyColumn: "Id",
                keyValue: 225);

            migrationBuilder.DeleteData(
                table: "SectionTemplates",
                keyColumn: "Id",
                keyValue: 226);

            migrationBuilder.DeleteData(
                table: "SectionTemplates",
                keyColumn: "Id",
                keyValue: 227);

            migrationBuilder.DeleteData(
                table: "SectionTemplates",
                keyColumn: "Id",
                keyValue: 228);

            migrationBuilder.DeleteData(
                table: "SectionTemplates",
                keyColumn: "Id",
                keyValue: 229);

            migrationBuilder.DeleteData(
                table: "SectionTemplates",
                keyColumn: "Id",
                keyValue: 230);

            migrationBuilder.DeleteData(
                table: "SectionTemplates",
                keyColumn: "Id",
                keyValue: 231);

            migrationBuilder.DeleteData(
                table: "SectionTemplates",
                keyColumn: "Id",
                keyValue: 232);

            migrationBuilder.DeleteData(
                table: "SectionTemplates",
                keyColumn: "Id",
                keyValue: 233);

            migrationBuilder.DeleteData(
                table: "SectionTemplates",
                keyColumn: "Id",
                keyValue: 234);
        }
    }
}
