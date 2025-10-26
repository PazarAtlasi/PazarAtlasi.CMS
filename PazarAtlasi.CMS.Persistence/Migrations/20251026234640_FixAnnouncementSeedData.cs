using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PazarAtlasi.CMS.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class FixAnnouncementSeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Announcements",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "PublishEnd", "PublishStart" },
                values: new object[] { new DateTime(2024, 10, 27, 10, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 11, 27, 10, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 10, 27, 10, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Announcements",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "PublishEnd", "PublishStart" },
                values: new object[] { new DateTime(2024, 10, 22, 10, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 11, 6, 10, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 10, 22, 10, 0, 0, 0, DateTimeKind.Unspecified) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Announcements",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "PublishEnd", "PublishStart" },
                values: new object[] { new DateTime(2025, 10, 26, 23, 45, 48, 699, DateTimeKind.Utc).AddTicks(2221), new DateTime(2025, 11, 25, 23, 45, 48, 699, DateTimeKind.Utc).AddTicks(1816), new DateTime(2025, 10, 26, 23, 45, 48, 699, DateTimeKind.Utc).AddTicks(1653) });

            migrationBuilder.UpdateData(
                table: "Announcements",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "PublishEnd", "PublishStart" },
                values: new object[] { new DateTime(2025, 10, 21, 23, 45, 48, 699, DateTimeKind.Utc).AddTicks(2568), new DateTime(2025, 11, 5, 23, 45, 48, 699, DateTimeKind.Utc).AddTicks(2567), new DateTime(2025, 10, 21, 23, 45, 48, 699, DateTimeKind.Utc).AddTicks(2563) });
        }
    }
}
