using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace PazarAtlasi.CMS.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AddAnnouncementEntity : Migration
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
                    CreatedByName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
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

            migrationBuilder.InsertData(
                table: "Announcements",
                columns: new[] { "Id", "Content", "CoverImage", "CreatedAt", "CreatedBy", "CreatedByName", "PublishEnd", "PublishStart", "Status", "Summary", "Title", "UpdatedAt", "UpdatedBy" },
                values: new object[,]
                {
                    { 1, "<p>Yeni duyuru sistemimize hoş geldiniz. Bu sistem ile önemli duyurularınızı kolayca yönetebilirsiniz.</p>", null, new DateTime(2025, 10, 26, 23, 45, 48, 699, DateTimeKind.Utc).AddTicks(2221), null, "Sistem Yöneticisi", new DateTime(2025, 11, 25, 23, 45, 48, 699, DateTimeKind.Utc).AddTicks(1816), new DateTime(2025, 10, 26, 23, 45, 48, 699, DateTimeKind.Utc).AddTicks(1653), 1, "Yeni duyuru sistemi tanıtımı", "Hoş Geldiniz!", null, null },
                    { 2, "<p>Sistemimizde planlı bakım çalışması yapılacaktır. Bakım sırasında hizmetlerimizde kısa süreli kesintiler yaşanabilir.</p><p>Bakım tarihi: <strong>15 Kasım 2024, 02:00-04:00</strong></p>", null, new DateTime(2025, 10, 21, 23, 45, 48, 699, DateTimeKind.Utc).AddTicks(2568), null, "Teknik Ekip", new DateTime(2025, 11, 5, 23, 45, 48, 699, DateTimeKind.Utc).AddTicks(2567), new DateTime(2025, 10, 21, 23, 45, 48, 699, DateTimeKind.Utc).AddTicks(2563), 1, "Planlı sistem bakımı hakkında bilgilendirme", "Sistem Bakımı Duyurusu", null, null }
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
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Announcements");
        }
    }
}
