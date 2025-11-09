using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PazarAtlasi.CMS.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class identity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "OperationalClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    DisplayName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Description = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<int>(type: "int", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<int>(type: "int", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OperationalClaims", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<int>(type: "int", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<int>(type: "int", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    Gender = table.Column<short>(type: "smallint", nullable: true),
                    MotherName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    FatherName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    DepartmentId = table.Column<int>(type: "int", nullable: true),
                    BranchId = table.Column<int>(type: "int", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<int>(type: "int", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<int>(type: "int", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RoleOperationalClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<int>(type: "int", nullable: false),
                    OperationalClaimId = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<int>(type: "int", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<int>(type: "int", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoleOperationalClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RoleOperationalClaims_OperationalClaims_OperationalClaimId",
                        column: x => x.OperationalClaimId,
                        principalTable: "OperationalClaims",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RoleOperationalClaims_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserLogins",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    LogoutTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IpAddress = table.Column<string>(type: "nvarchar(45)", maxLength: 45, nullable: true),
                    UserAgent = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    IsSuccessful = table.Column<bool>(type: "bit", nullable: false),
                    FailureReason = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    SessionId = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    DeviceInfo = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    Location = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<int>(type: "int", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<int>(type: "int", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserLogins", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserLogins_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserRoles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    RoleId = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<int>(type: "int", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<int>(type: "int", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRoles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserRoles_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserRoles_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "DataSchemaFields",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 21, 36, 380, DateTimeKind.Utc).AddTicks(3461));

            migrationBuilder.UpdateData(
                table: "DataSchemaFields",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 21, 36, 380, DateTimeKind.Utc).AddTicks(3467));

            migrationBuilder.UpdateData(
                table: "DataSchemaFields",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 21, 36, 380, DateTimeKind.Utc).AddTicks(3471));

            migrationBuilder.UpdateData(
                table: "DataSchemaFields",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 21, 36, 380, DateTimeKind.Utc).AddTicks(3473));

            migrationBuilder.UpdateData(
                table: "DataSchemaFields",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 21, 36, 380, DateTimeKind.Utc).AddTicks(3476));

            migrationBuilder.UpdateData(
                table: "DataSchemaFields",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 21, 36, 380, DateTimeKind.Utc).AddTicks(3479));

            migrationBuilder.UpdateData(
                table: "DataSchemas",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 21, 36, 378, DateTimeKind.Utc).AddTicks(3398));

            migrationBuilder.UpdateData(
                table: "DataSchemas",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 21, 36, 378, DateTimeKind.Utc).AddTicks(3402));

            migrationBuilder.UpdateData(
                table: "DataSchemas",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 21, 36, 378, DateTimeKind.Utc).AddTicks(3404));

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 21, 36, 373, DateTimeKind.Utc).AddTicks(9520));

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 21, 36, 373, DateTimeKind.Utc).AddTicks(9524));

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 21, 36, 373, DateTimeKind.Utc).AddTicks(9527));

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 21, 36, 373, DateTimeKind.Utc).AddTicks(9528));

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 21, 36, 373, DateTimeKind.Utc).AddTicks(9530));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 21, 36, 374, DateTimeKind.Utc).AddTicks(5538));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 21, 36, 374, DateTimeKind.Utc).AddTicks(5567));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 21, 36, 374, DateTimeKind.Utc).AddTicks(5569));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 21, 36, 374, DateTimeKind.Utc).AddTicks(5570));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 21, 36, 374, DateTimeKind.Utc).AddTicks(5571));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 21, 36, 374, DateTimeKind.Utc).AddTicks(5573));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 21, 36, 374, DateTimeKind.Utc).AddTicks(5574));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 21, 36, 374, DateTimeKind.Utc).AddTicks(5575));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 21, 36, 374, DateTimeKind.Utc).AddTicks(5576));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 21, 36, 374, DateTimeKind.Utc).AddTicks(5578));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 21, 36, 374, DateTimeKind.Utc).AddTicks(5579));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 21, 36, 374, DateTimeKind.Utc).AddTicks(5579));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 21, 36, 374, DateTimeKind.Utc).AddTicks(5580));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 21, 36, 374, DateTimeKind.Utc).AddTicks(5581));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 21, 36, 374, DateTimeKind.Utc).AddTicks(5582));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 16,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 21, 36, 374, DateTimeKind.Utc).AddTicks(5590));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 17,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 21, 36, 374, DateTimeKind.Utc).AddTicks(5591));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 18,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 21, 36, 374, DateTimeKind.Utc).AddTicks(5593));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 19,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 21, 36, 374, DateTimeKind.Utc).AddTicks(5594));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 20,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 21, 36, 374, DateTimeKind.Utc).AddTicks(5594));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 21,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 21, 36, 374, DateTimeKind.Utc).AddTicks(5595));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 22,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 21, 36, 374, DateTimeKind.Utc).AddTicks(5597));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 23,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 21, 36, 374, DateTimeKind.Utc).AddTicks(5597));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 24,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 21, 36, 374, DateTimeKind.Utc).AddTicks(5598));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 25,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 21, 36, 374, DateTimeKind.Utc).AddTicks(5599));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 26,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 21, 36, 374, DateTimeKind.Utc).AddTicks(5600));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 27,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 21, 36, 374, DateTimeKind.Utc).AddTicks(5601));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 28,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 21, 36, 374, DateTimeKind.Utc).AddTicks(5602));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 29,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 21, 36, 374, DateTimeKind.Utc).AddTicks(5603));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 30,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 21, 36, 374, DateTimeKind.Utc).AddTicks(5640));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 31,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 21, 36, 374, DateTimeKind.Utc).AddTicks(5641));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 32,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 21, 36, 374, DateTimeKind.Utc).AddTicks(5641));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 33,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 21, 36, 374, DateTimeKind.Utc).AddTicks(5643));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 34,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 21, 36, 374, DateTimeKind.Utc).AddTicks(5644));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 35,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 21, 36, 374, DateTimeKind.Utc).AddTicks(5671));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 36,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 21, 36, 374, DateTimeKind.Utc).AddTicks(5672));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 37,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 21, 36, 374, DateTimeKind.Utc).AddTicks(5673));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 38,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 21, 36, 374, DateTimeKind.Utc).AddTicks(5674));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 39,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 21, 36, 374, DateTimeKind.Utc).AddTicks(5678));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 40,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 21, 36, 374, DateTimeKind.Utc).AddTicks(5679));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 41,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 21, 36, 374, DateTimeKind.Utc).AddTicks(5680));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 42,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 21, 36, 374, DateTimeKind.Utc).AddTicks(5682));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 43,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 21, 36, 374, DateTimeKind.Utc).AddTicks(5682));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 44,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 21, 36, 374, DateTimeKind.Utc).AddTicks(5683));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 45,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 21, 36, 374, DateTimeKind.Utc).AddTicks(5684));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 46,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 21, 36, 374, DateTimeKind.Utc).AddTicks(5685));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 47,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 21, 36, 374, DateTimeKind.Utc).AddTicks(5686));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 48,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 21, 36, 374, DateTimeKind.Utc).AddTicks(5687));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 49,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 21, 36, 374, DateTimeKind.Utc).AddTicks(5688));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 50,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 21, 36, 374, DateTimeKind.Utc).AddTicks(5689));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 51,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 21, 36, 374, DateTimeKind.Utc).AddTicks(5690));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 52,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 21, 36, 374, DateTimeKind.Utc).AddTicks(5691));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 53,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 21, 36, 374, DateTimeKind.Utc).AddTicks(5692));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 54,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 21, 36, 374, DateTimeKind.Utc).AddTicks(5694));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 55,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 21, 36, 374, DateTimeKind.Utc).AddTicks(5695));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 56,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 21, 36, 374, DateTimeKind.Utc).AddTicks(5696));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 57,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 21, 36, 374, DateTimeKind.Utc).AddTicks(5697));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 58,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 21, 36, 374, DateTimeKind.Utc).AddTicks(5698));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 59,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 21, 36, 374, DateTimeKind.Utc).AddTicks(5699));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 60,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 21, 36, 374, DateTimeKind.Utc).AddTicks(5700));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 61,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 21, 36, 374, DateTimeKind.Utc).AddTicks(5701));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 62,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 21, 36, 374, DateTimeKind.Utc).AddTicks(5702));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 63,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 21, 36, 374, DateTimeKind.Utc).AddTicks(5702));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 64,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 21, 36, 374, DateTimeKind.Utc).AddTicks(5703));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 65,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 21, 36, 374, DateTimeKind.Utc).AddTicks(5704));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 66,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 21, 36, 374, DateTimeKind.Utc).AddTicks(5706));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 67,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 21, 36, 374, DateTimeKind.Utc).AddTicks(5729));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 68,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 21, 36, 374, DateTimeKind.Utc).AddTicks(5730));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 69,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 21, 36, 374, DateTimeKind.Utc).AddTicks(5731));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 70,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 21, 36, 374, DateTimeKind.Utc).AddTicks(5734));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 71,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 21, 36, 374, DateTimeKind.Utc).AddTicks(5735));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 72,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 21, 36, 374, DateTimeKind.Utc).AddTicks(5736));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 73,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 21, 36, 374, DateTimeKind.Utc).AddTicks(5738));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 74,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 21, 36, 374, DateTimeKind.Utc).AddTicks(5739));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 75,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 21, 36, 374, DateTimeKind.Utc).AddTicks(5740));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 76,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 21, 36, 374, DateTimeKind.Utc).AddTicks(5741));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 77,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 21, 36, 374, DateTimeKind.Utc).AddTicks(5742));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 78,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 21, 36, 374, DateTimeKind.Utc).AddTicks(5742));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 79,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 21, 36, 374, DateTimeKind.Utc).AddTicks(5743));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 80,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 21, 36, 374, DateTimeKind.Utc).AddTicks(5746));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 81,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 21, 36, 374, DateTimeKind.Utc).AddTicks(5747));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 82,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 21, 36, 374, DateTimeKind.Utc).AddTicks(5748));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 83,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 21, 36, 374, DateTimeKind.Utc).AddTicks(5749));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 84,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 21, 36, 374, DateTimeKind.Utc).AddTicks(5750));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 85,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 21, 36, 374, DateTimeKind.Utc).AddTicks(5751));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 86,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 21, 36, 374, DateTimeKind.Utc).AddTicks(5752));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 87,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 21, 36, 374, DateTimeKind.Utc).AddTicks(5754));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 88,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 21, 36, 374, DateTimeKind.Utc).AddTicks(5755));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 89,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 21, 36, 374, DateTimeKind.Utc).AddTicks(5756));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 90,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 21, 36, 374, DateTimeKind.Utc).AddTicks(5757));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 91,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 21, 36, 374, DateTimeKind.Utc).AddTicks(5758));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 92,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 21, 36, 374, DateTimeKind.Utc).AddTicks(5759));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 93,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 21, 36, 374, DateTimeKind.Utc).AddTicks(5759));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 94,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 21, 36, 374, DateTimeKind.Utc).AddTicks(5760));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 95,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 21, 36, 374, DateTimeKind.Utc).AddTicks(5761));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 96,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 21, 36, 374, DateTimeKind.Utc).AddTicks(5762));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 97,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 21, 36, 374, DateTimeKind.Utc).AddTicks(5763));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 98,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 21, 36, 374, DateTimeKind.Utc).AddTicks(5764));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 99,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 21, 36, 374, DateTimeKind.Utc).AddTicks(5765));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 100,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 21, 36, 374, DateTimeKind.Utc).AddTicks(5766));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 101,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 21, 36, 374, DateTimeKind.Utc).AddTicks(5767));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 102,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 21, 36, 374, DateTimeKind.Utc).AddTicks(5768));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 103,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 21, 36, 374, DateTimeKind.Utc).AddTicks(5785));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 104,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 21, 36, 374, DateTimeKind.Utc).AddTicks(5786));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 105,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 21, 36, 374, DateTimeKind.Utc).AddTicks(5787));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 106,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 21, 36, 374, DateTimeKind.Utc).AddTicks(5788));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 107,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 21, 36, 374, DateTimeKind.Utc).AddTicks(5789));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 108,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 21, 36, 374, DateTimeKind.Utc).AddTicks(5790));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 109,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 21, 36, 374, DateTimeKind.Utc).AddTicks(5793));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 110,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 21, 36, 374, DateTimeKind.Utc).AddTicks(5794));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 111,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 21, 36, 374, DateTimeKind.Utc).AddTicks(5797));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 112,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 21, 36, 374, DateTimeKind.Utc).AddTicks(5798));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 113,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 21, 36, 374, DateTimeKind.Utc).AddTicks(5799));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 114,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 21, 36, 374, DateTimeKind.Utc).AddTicks(5800));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 115,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 21, 36, 374, DateTimeKind.Utc).AddTicks(5801));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 116,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 21, 36, 374, DateTimeKind.Utc).AddTicks(5802));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 117,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 21, 36, 374, DateTimeKind.Utc).AddTicks(5803));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 118,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 21, 36, 374, DateTimeKind.Utc).AddTicks(5805));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 119,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 21, 36, 374, DateTimeKind.Utc).AddTicks(5806));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 120,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 21, 36, 374, DateTimeKind.Utc).AddTicks(5807));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 121,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 21, 36, 374, DateTimeKind.Utc).AddTicks(5808));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 122,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 21, 36, 374, DateTimeKind.Utc).AddTicks(5809));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 123,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 21, 36, 374, DateTimeKind.Utc).AddTicks(5810));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 124,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 21, 36, 374, DateTimeKind.Utc).AddTicks(5811));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 125,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 21, 36, 374, DateTimeKind.Utc).AddTicks(5812));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 126,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 21, 36, 374, DateTimeKind.Utc).AddTicks(5813));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 127,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 21, 36, 374, DateTimeKind.Utc).AddTicks(5814));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 128,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 21, 36, 374, DateTimeKind.Utc).AddTicks(5815));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 129,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 21, 36, 374, DateTimeKind.Utc).AddTicks(5815));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 130,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 21, 36, 374, DateTimeKind.Utc).AddTicks(5853));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 131,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 21, 36, 374, DateTimeKind.Utc).AddTicks(5854));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 132,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 21, 36, 374, DateTimeKind.Utc).AddTicks(5855));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 133,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 21, 36, 374, DateTimeKind.Utc).AddTicks(5856));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 134,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 21, 36, 374, DateTimeKind.Utc).AddTicks(5856));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 135,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 21, 36, 374, DateTimeKind.Utc).AddTicks(5857));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 136,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 21, 36, 374, DateTimeKind.Utc).AddTicks(5858));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 137,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 21, 36, 374, DateTimeKind.Utc).AddTicks(5859));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 138,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 21, 36, 374, DateTimeKind.Utc).AddTicks(5860));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 139,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 21, 36, 374, DateTimeKind.Utc).AddTicks(5863));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 140,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 21, 36, 374, DateTimeKind.Utc).AddTicks(5864));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 141,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 21, 36, 374, DateTimeKind.Utc).AddTicks(5865));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 142,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 21, 36, 374, DateTimeKind.Utc).AddTicks(5866));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 143,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 21, 36, 374, DateTimeKind.Utc).AddTicks(5867));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 144,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 21, 36, 374, DateTimeKind.Utc).AddTicks(5868));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 145,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 21, 36, 374, DateTimeKind.Utc).AddTicks(5869));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 146,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 21, 36, 374, DateTimeKind.Utc).AddTicks(5870));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 147,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 21, 36, 374, DateTimeKind.Utc).AddTicks(5871));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 148,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 21, 36, 374, DateTimeKind.Utc).AddTicks(5872));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 149,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 21, 36, 374, DateTimeKind.Utc).AddTicks(5873));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 150,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 21, 36, 374, DateTimeKind.Utc).AddTicks(5874));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 151,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 21, 36, 374, DateTimeKind.Utc).AddTicks(5875));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 152,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 21, 36, 374, DateTimeKind.Utc).AddTicks(5877));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 153,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 21, 36, 374, DateTimeKind.Utc).AddTicks(5878));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 154,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 21, 36, 374, DateTimeKind.Utc).AddTicks(5879));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 155,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 21, 36, 374, DateTimeKind.Utc).AddTicks(5880));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 156,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 21, 36, 374, DateTimeKind.Utc).AddTicks(5880));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 157,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 21, 36, 374, DateTimeKind.Utc).AddTicks(5881));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 158,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 21, 36, 374, DateTimeKind.Utc).AddTicks(5882));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 159,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 21, 36, 374, DateTimeKind.Utc).AddTicks(5883));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 160,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 21, 36, 374, DateTimeKind.Utc).AddTicks(5884));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 161,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 21, 36, 374, DateTimeKind.Utc).AddTicks(5885));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 162,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 21, 36, 374, DateTimeKind.Utc).AddTicks(5915));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 163,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 21, 36, 374, DateTimeKind.Utc).AddTicks(5916));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 164,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 21, 36, 374, DateTimeKind.Utc).AddTicks(5920));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 165,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 21, 36, 374, DateTimeKind.Utc).AddTicks(5921));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 166,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 21, 36, 374, DateTimeKind.Utc).AddTicks(5922));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 167,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 21, 36, 374, DateTimeKind.Utc).AddTicks(5923));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 168,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 21, 36, 374, DateTimeKind.Utc).AddTicks(5924));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 169,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 21, 36, 374, DateTimeKind.Utc).AddTicks(5925));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 170,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 21, 36, 374, DateTimeKind.Utc).AddTicks(5926));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 171,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 21, 36, 374, DateTimeKind.Utc).AddTicks(5927));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 172,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 21, 36, 374, DateTimeKind.Utc).AddTicks(5928));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 173,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 21, 36, 374, DateTimeKind.Utc).AddTicks(5929));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 174,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 21, 36, 374, DateTimeKind.Utc).AddTicks(5930));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 175,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 21, 36, 374, DateTimeKind.Utc).AddTicks(5931));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 176,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 21, 36, 374, DateTimeKind.Utc).AddTicks(5932));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 177,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 21, 36, 374, DateTimeKind.Utc).AddTicks(5933));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 178,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 21, 36, 374, DateTimeKind.Utc).AddTicks(5934));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 179,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 21, 36, 374, DateTimeKind.Utc).AddTicks(5935));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 180,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 21, 36, 374, DateTimeKind.Utc).AddTicks(5935));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 181,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 21, 36, 374, DateTimeKind.Utc).AddTicks(5936));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 182,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 21, 36, 374, DateTimeKind.Utc).AddTicks(5937));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 183,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 21, 36, 374, DateTimeKind.Utc).AddTicks(5938));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 184,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 21, 36, 374, DateTimeKind.Utc).AddTicks(5939));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 185,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 21, 36, 374, DateTimeKind.Utc).AddTicks(5940));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 186,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 21, 36, 374, DateTimeKind.Utc).AddTicks(5941));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 187,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 21, 36, 374, DateTimeKind.Utc).AddTicks(5942));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 188,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 21, 36, 374, DateTimeKind.Utc).AddTicks(5942));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 189,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 21, 36, 374, DateTimeKind.Utc).AddTicks(5943));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 190,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 21, 36, 374, DateTimeKind.Utc).AddTicks(5944));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 191,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 21, 36, 374, DateTimeKind.Utc).AddTicks(5945));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 192,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 21, 36, 374, DateTimeKind.Utc).AddTicks(5946));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 193,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 21, 36, 374, DateTimeKind.Utc).AddTicks(5947));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 194,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 21, 36, 374, DateTimeKind.Utc).AddTicks(5947));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 195,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 21, 36, 374, DateTimeKind.Utc).AddTicks(5948));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 196,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 21, 36, 374, DateTimeKind.Utc).AddTicks(5949));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 197,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 21, 36, 374, DateTimeKind.Utc).AddTicks(5950));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 198,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 21, 36, 374, DateTimeKind.Utc).AddTicks(5951));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 199,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 21, 36, 374, DateTimeKind.Utc).AddTicks(5952));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 200,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 21, 36, 374, DateTimeKind.Utc).AddTicks(5979));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 201,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 21, 36, 374, DateTimeKind.Utc).AddTicks(5980));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 202,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 21, 36, 374, DateTimeKind.Utc).AddTicks(5983));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 203,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 21, 36, 374, DateTimeKind.Utc).AddTicks(5984));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 204,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 21, 36, 374, DateTimeKind.Utc).AddTicks(5985));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 205,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 21, 36, 374, DateTimeKind.Utc).AddTicks(5986));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 206,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 21, 36, 374, DateTimeKind.Utc).AddTicks(5987));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 207,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 21, 36, 374, DateTimeKind.Utc).AddTicks(5988));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 208,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 21, 36, 374, DateTimeKind.Utc).AddTicks(5989));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 209,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 21, 36, 374, DateTimeKind.Utc).AddTicks(5990));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 210,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 21, 36, 374, DateTimeKind.Utc).AddTicks(5991));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 211,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 21, 36, 374, DateTimeKind.Utc).AddTicks(5991));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 212,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 21, 36, 374, DateTimeKind.Utc).AddTicks(5992));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 213,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 21, 36, 374, DateTimeKind.Utc).AddTicks(5993));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 214,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 21, 36, 374, DateTimeKind.Utc).AddTicks(5994));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 215,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 21, 36, 374, DateTimeKind.Utc).AddTicks(5995));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 216,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 21, 36, 374, DateTimeKind.Utc).AddTicks(5996));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 217,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 21, 36, 374, DateTimeKind.Utc).AddTicks(5998));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 218,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 21, 36, 374, DateTimeKind.Utc).AddTicks(6000));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 219,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 21, 36, 374, DateTimeKind.Utc).AddTicks(6000));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 220,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 21, 36, 374, DateTimeKind.Utc).AddTicks(6001));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 221,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 21, 36, 374, DateTimeKind.Utc).AddTicks(6003));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 222,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 21, 36, 374, DateTimeKind.Utc).AddTicks(6004));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 223,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 21, 36, 374, DateTimeKind.Utc).AddTicks(6005));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 224,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 21, 36, 374, DateTimeKind.Utc).AddTicks(6005));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 225,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 21, 36, 374, DateTimeKind.Utc).AddTicks(6006));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 226,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 21, 36, 374, DateTimeKind.Utc).AddTicks(6007));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 227,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 21, 36, 374, DateTimeKind.Utc).AddTicks(6008));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 228,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 21, 36, 374, DateTimeKind.Utc).AddTicks(6009));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 229,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 21, 36, 374, DateTimeKind.Utc).AddTicks(6010));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 230,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 21, 36, 374, DateTimeKind.Utc).AddTicks(6011));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 231,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 21, 36, 374, DateTimeKind.Utc).AddTicks(6012));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 232,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 21, 36, 374, DateTimeKind.Utc).AddTicks(6013));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 233,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 21, 36, 374, DateTimeKind.Utc).AddTicks(6015));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 234,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 21, 36, 374, DateTimeKind.Utc).AddTicks(6017));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 235,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 21, 36, 374, DateTimeKind.Utc).AddTicks(6018));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 236,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 21, 36, 374, DateTimeKind.Utc).AddTicks(6019));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 237,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 21, 36, 374, DateTimeKind.Utc).AddTicks(6041));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 238,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 21, 36, 374, DateTimeKind.Utc).AddTicks(6042));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 239,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 21, 36, 374, DateTimeKind.Utc).AddTicks(6043));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 240,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 21, 36, 374, DateTimeKind.Utc).AddTicks(6044));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 241,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 21, 36, 374, DateTimeKind.Utc).AddTicks(6045));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 242,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 21, 36, 374, DateTimeKind.Utc).AddTicks(6046));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 243,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 21, 36, 374, DateTimeKind.Utc).AddTicks(6049));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 244,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 21, 36, 374, DateTimeKind.Utc).AddTicks(6051));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 245,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 21, 36, 374, DateTimeKind.Utc).AddTicks(6052));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 246,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 21, 36, 374, DateTimeKind.Utc).AddTicks(6053));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 247,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 21, 36, 374, DateTimeKind.Utc).AddTicks(6053));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 248,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 21, 36, 374, DateTimeKind.Utc).AddTicks(6055));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 249,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 21, 36, 374, DateTimeKind.Utc).AddTicks(6056));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 250,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 21, 36, 374, DateTimeKind.Utc).AddTicks(6057));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 251,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 21, 36, 374, DateTimeKind.Utc).AddTicks(6058));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 252,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 21, 36, 374, DateTimeKind.Utc).AddTicks(6058));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 253,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 21, 36, 374, DateTimeKind.Utc).AddTicks(6059));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 254,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 21, 36, 374, DateTimeKind.Utc).AddTicks(6060));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 255,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 21, 36, 374, DateTimeKind.Utc).AddTicks(6061));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 256,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 21, 36, 374, DateTimeKind.Utc).AddTicks(6062));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 257,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 21, 36, 374, DateTimeKind.Utc).AddTicks(6063));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 258,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 21, 36, 374, DateTimeKind.Utc).AddTicks(6086));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 259,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 21, 36, 374, DateTimeKind.Utc).AddTicks(6087));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 260,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 21, 36, 374, DateTimeKind.Utc).AddTicks(6088));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 261,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 21, 36, 374, DateTimeKind.Utc).AddTicks(6089));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 262,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 21, 36, 374, DateTimeKind.Utc).AddTicks(6090));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 263,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 21, 36, 374, DateTimeKind.Utc).AddTicks(6091));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 264,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 21, 36, 374, DateTimeKind.Utc).AddTicks(6092));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 265,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 21, 36, 374, DateTimeKind.Utc).AddTicks(6093));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 266,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 21, 36, 374, DateTimeKind.Utc).AddTicks(6094));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 267,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 21, 36, 374, DateTimeKind.Utc).AddTicks(6094));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 268,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 21, 36, 374, DateTimeKind.Utc).AddTicks(6095));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 269,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 21, 36, 374, DateTimeKind.Utc).AddTicks(6096));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 270,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 21, 36, 374, DateTimeKind.Utc).AddTicks(6097));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 271,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 21, 36, 374, DateTimeKind.Utc).AddTicks(6098));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 272,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 21, 36, 374, DateTimeKind.Utc).AddTicks(6101));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 273,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 21, 36, 374, DateTimeKind.Utc).AddTicks(6102));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 274,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 21, 36, 374, DateTimeKind.Utc).AddTicks(6105));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 275,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 21, 36, 374, DateTimeKind.Utc).AddTicks(6106));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 276,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 21, 36, 374, DateTimeKind.Utc).AddTicks(6107));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 277,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 21, 36, 374, DateTimeKind.Utc).AddTicks(6108));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 278,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 21, 36, 374, DateTimeKind.Utc).AddTicks(6109));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 279,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 21, 36, 374, DateTimeKind.Utc).AddTicks(6110));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 280,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 21, 36, 374, DateTimeKind.Utc).AddTicks(6111));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 281,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 21, 36, 374, DateTimeKind.Utc).AddTicks(6112));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 282,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 21, 36, 374, DateTimeKind.Utc).AddTicks(6113));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 283,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 21, 36, 374, DateTimeKind.Utc).AddTicks(6114));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 284,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 21, 36, 374, DateTimeKind.Utc).AddTicks(6115));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 285,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 21, 36, 374, DateTimeKind.Utc).AddTicks(6116));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 286,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 21, 36, 374, DateTimeKind.Utc).AddTicks(6116));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 287,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 21, 36, 374, DateTimeKind.Utc).AddTicks(6117));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 288,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 21, 36, 374, DateTimeKind.Utc).AddTicks(6118));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 289,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 21, 36, 374, DateTimeKind.Utc).AddTicks(6119));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 290,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 21, 36, 374, DateTimeKind.Utc).AddTicks(6142));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 291,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 21, 36, 374, DateTimeKind.Utc).AddTicks(6143));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 292,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 21, 36, 374, DateTimeKind.Utc).AddTicks(6144));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 293,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 21, 36, 374, DateTimeKind.Utc).AddTicks(6145));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 294,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 21, 36, 374, DateTimeKind.Utc).AddTicks(6146));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 295,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 21, 36, 374, DateTimeKind.Utc).AddTicks(6147));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 296,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 21, 36, 374, DateTimeKind.Utc).AddTicks(6147));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 297,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 21, 36, 374, DateTimeKind.Utc).AddTicks(6148));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 298,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 21, 36, 374, DateTimeKind.Utc).AddTicks(6149));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 299,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 21, 36, 374, DateTimeKind.Utc).AddTicks(6150));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 300,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 21, 36, 374, DateTimeKind.Utc).AddTicks(6151));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 301,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 21, 36, 374, DateTimeKind.Utc).AddTicks(6152));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 302,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 21, 36, 374, DateTimeKind.Utc).AddTicks(6154));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 303,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 21, 36, 374, DateTimeKind.Utc).AddTicks(6156));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 304,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 21, 36, 374, DateTimeKind.Utc).AddTicks(6157));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 305,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 21, 36, 374, DateTimeKind.Utc).AddTicks(6158));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 306,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 21, 36, 374, DateTimeKind.Utc).AddTicks(6158));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 307,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 21, 36, 374, DateTimeKind.Utc).AddTicks(6159));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 308,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 21, 36, 374, DateTimeKind.Utc).AddTicks(6160));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 309,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 21, 36, 374, DateTimeKind.Utc).AddTicks(6162));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 310,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 21, 36, 374, DateTimeKind.Utc).AddTicks(6163));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 311,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 21, 36, 374, DateTimeKind.Utc).AddTicks(6164));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 312,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 21, 36, 374, DateTimeKind.Utc).AddTicks(6164));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 313,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 21, 36, 374, DateTimeKind.Utc).AddTicks(6165));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 314,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 21, 36, 374, DateTimeKind.Utc).AddTicks(6166));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 315,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 21, 36, 374, DateTimeKind.Utc).AddTicks(6167));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 316,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 21, 36, 374, DateTimeKind.Utc).AddTicks(6168));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 317,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 21, 36, 374, DateTimeKind.Utc).AddTicks(6169));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 318,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 21, 36, 374, DateTimeKind.Utc).AddTicks(6170));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 319,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 21, 36, 374, DateTimeKind.Utc).AddTicks(6171));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 320,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 21, 36, 374, DateTimeKind.Utc).AddTicks(6172));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 321,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 21, 36, 374, DateTimeKind.Utc).AddTicks(6173));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 322,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 21, 36, 374, DateTimeKind.Utc).AddTicks(6174));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 323,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 21, 36, 374, DateTimeKind.Utc).AddTicks(6175));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 324,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 21, 36, 374, DateTimeKind.Utc).AddTicks(6196));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 325,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 21, 36, 374, DateTimeKind.Utc).AddTicks(6197));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 326,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 21, 36, 374, DateTimeKind.Utc).AddTicks(6198));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 327,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 21, 36, 374, DateTimeKind.Utc).AddTicks(6233));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 328,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 21, 36, 374, DateTimeKind.Utc).AddTicks(6235));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 329,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 21, 36, 374, DateTimeKind.Utc).AddTicks(6235));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 330,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 21, 36, 374, DateTimeKind.Utc).AddTicks(6236));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 331,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 21, 36, 374, DateTimeKind.Utc).AddTicks(6237));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 332,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 21, 36, 374, DateTimeKind.Utc).AddTicks(6238));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 333,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 21, 36, 374, DateTimeKind.Utc).AddTicks(6239));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 334,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 21, 36, 374, DateTimeKind.Utc).AddTicks(6240));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 335,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 21, 36, 374, DateTimeKind.Utc).AddTicks(6241));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 336,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 21, 36, 374, DateTimeKind.Utc).AddTicks(6242));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 337,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 21, 36, 374, DateTimeKind.Utc).AddTicks(6242));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 338,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 21, 36, 374, DateTimeKind.Utc).AddTicks(6243));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 339,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 21, 36, 374, DateTimeKind.Utc).AddTicks(6244));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 340,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 21, 36, 374, DateTimeKind.Utc).AddTicks(6245));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 341,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 21, 36, 374, DateTimeKind.Utc).AddTicks(6260));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 342,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 21, 36, 374, DateTimeKind.Utc).AddTicks(6261));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 343,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 21, 36, 374, DateTimeKind.Utc).AddTicks(6262));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 344,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 21, 36, 374, DateTimeKind.Utc).AddTicks(6263));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 345,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 21, 36, 374, DateTimeKind.Utc).AddTicks(6264));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 346,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 21, 36, 374, DateTimeKind.Utc).AddTicks(6265));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 347,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 21, 36, 374, DateTimeKind.Utc).AddTicks(6266));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 348,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 21, 36, 374, DateTimeKind.Utc).AddTicks(6267));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 349,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 21, 36, 374, DateTimeKind.Utc).AddTicks(6268));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 350,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 21, 36, 374, DateTimeKind.Utc).AddTicks(6268));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 351,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 21, 36, 374, DateTimeKind.Utc).AddTicks(6270));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 352,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 21, 36, 374, DateTimeKind.Utc).AddTicks(6270));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 353,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 21, 36, 374, DateTimeKind.Utc).AddTicks(6271));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 354,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 21, 36, 374, DateTimeKind.Utc).AddTicks(6272));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 355,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 21, 36, 374, DateTimeKind.Utc).AddTicks(6273));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 356,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 21, 36, 374, DateTimeKind.Utc).AddTicks(6274));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 357,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 21, 36, 374, DateTimeKind.Utc).AddTicks(6275));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 358,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 21, 36, 374, DateTimeKind.Utc).AddTicks(6276));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 359,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 21, 36, 374, DateTimeKind.Utc).AddTicks(6277));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 360,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 21, 36, 374, DateTimeKind.Utc).AddTicks(6278));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 361,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 21, 36, 374, DateTimeKind.Utc).AddTicks(6281));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 362,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 21, 36, 374, DateTimeKind.Utc).AddTicks(6282));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 363,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 21, 36, 374, DateTimeKind.Utc).AddTicks(6283));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 364,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 21, 36, 374, DateTimeKind.Utc).AddTicks(6284));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 365,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 21, 36, 374, DateTimeKind.Utc).AddTicks(6285));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 366,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 21, 36, 374, DateTimeKind.Utc).AddTicks(6286));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 367,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 21, 36, 374, DateTimeKind.Utc).AddTicks(6287));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 368,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 21, 36, 374, DateTimeKind.Utc).AddTicks(6287));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 369,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 21, 36, 374, DateTimeKind.Utc).AddTicks(6288));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 370,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 21, 36, 374, DateTimeKind.Utc).AddTicks(6289));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 371,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 21, 36, 374, DateTimeKind.Utc).AddTicks(6290));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 372,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 21, 36, 374, DateTimeKind.Utc).AddTicks(6291));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 373,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 21, 36, 374, DateTimeKind.Utc).AddTicks(6292));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 374,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 21, 36, 374, DateTimeKind.Utc).AddTicks(6293));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 375,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 21, 36, 374, DateTimeKind.Utc).AddTicks(6294));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 376,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 21, 36, 374, DateTimeKind.Utc).AddTicks(6323));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 377,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 21, 36, 374, DateTimeKind.Utc).AddTicks(6324));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 378,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 21, 36, 374, DateTimeKind.Utc).AddTicks(6324));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 379,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 21, 36, 374, DateTimeKind.Utc).AddTicks(6325));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 380,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 21, 36, 374, DateTimeKind.Utc).AddTicks(6326));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 381,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 21, 36, 374, DateTimeKind.Utc).AddTicks(6327));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 382,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 21, 36, 374, DateTimeKind.Utc).AddTicks(6328));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 383,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 21, 36, 374, DateTimeKind.Utc).AddTicks(6329));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 384,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 21, 36, 374, DateTimeKind.Utc).AddTicks(6330));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 385,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 21, 36, 374, DateTimeKind.Utc).AddTicks(6331));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 386,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 21, 36, 374, DateTimeKind.Utc).AddTicks(6332));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 387,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 21, 36, 374, DateTimeKind.Utc).AddTicks(6333));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 388,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 21, 36, 374, DateTimeKind.Utc).AddTicks(6334));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 389,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 21, 36, 374, DateTimeKind.Utc).AddTicks(6335));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 390,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 21, 36, 374, DateTimeKind.Utc).AddTicks(6336));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 391,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 21, 36, 374, DateTimeKind.Utc).AddTicks(6337));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 392,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 21, 36, 374, DateTimeKind.Utc).AddTicks(6338));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 393,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 21, 36, 374, DateTimeKind.Utc).AddTicks(6339));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 394,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 21, 36, 374, DateTimeKind.Utc).AddTicks(6340));

            migrationBuilder.UpdateData(
                table: "OptionTranslations",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 21, 36, 386, DateTimeKind.Utc).AddTicks(2298));

            migrationBuilder.UpdateData(
                table: "OptionTranslations",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 21, 36, 386, DateTimeKind.Utc).AddTicks(2301));

            migrationBuilder.UpdateData(
                table: "OptionTranslations",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 21, 36, 386, DateTimeKind.Utc).AddTicks(2302));

            migrationBuilder.UpdateData(
                table: "OptionTranslations",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 21, 36, 386, DateTimeKind.Utc).AddTicks(2304));

            migrationBuilder.UpdateData(
                table: "OptionTranslations",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 21, 36, 386, DateTimeKind.Utc).AddTicks(2305));

            migrationBuilder.UpdateData(
                table: "OptionTranslations",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 21, 36, 386, DateTimeKind.Utc).AddTicks(2307));

            migrationBuilder.UpdateData(
                table: "OptionTranslations",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 21, 36, 386, DateTimeKind.Utc).AddTicks(2308));

            migrationBuilder.UpdateData(
                table: "OptionTranslations",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 21, 36, 386, DateTimeKind.Utc).AddTicks(2309));

            migrationBuilder.UpdateData(
                table: "OptionTranslations",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 21, 36, 386, DateTimeKind.Utc).AddTicks(2311));

            migrationBuilder.UpdateData(
                table: "OptionTranslations",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 21, 36, 386, DateTimeKind.Utc).AddTicks(2312));

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 21, 36, 385, DateTimeKind.Utc).AddTicks(5377));

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 21, 36, 385, DateTimeKind.Utc).AddTicks(5383));

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 21, 36, 385, DateTimeKind.Utc).AddTicks(5385));

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 21, 36, 385, DateTimeKind.Utc).AddTicks(5387));

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 21, 36, 385, DateTimeKind.Utc).AddTicks(5389));

            migrationBuilder.UpdateData(
                table: "ProductOptions",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 21, 36, 388, DateTimeKind.Utc).AddTicks(8970));

            migrationBuilder.UpdateData(
                table: "ProductOptions",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 21, 36, 388, DateTimeKind.Utc).AddTicks(8973));

            migrationBuilder.UpdateData(
                table: "ProductOptions",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 21, 36, 388, DateTimeKind.Utc).AddTicks(8975));

            migrationBuilder.UpdateData(
                table: "ProductOptions",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 21, 36, 388, DateTimeKind.Utc).AddTicks(8980));

            migrationBuilder.UpdateData(
                table: "ProductOptions",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 21, 36, 388, DateTimeKind.Utc).AddTicks(8982));

            migrationBuilder.UpdateData(
                table: "ProductOptions",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 21, 36, 388, DateTimeKind.Utc).AddTicks(8984));

            migrationBuilder.UpdateData(
                table: "ProductOptions",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 21, 36, 388, DateTimeKind.Utc).AddTicks(8986));

            migrationBuilder.UpdateData(
                table: "ProductOptions",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 21, 36, 388, DateTimeKind.Utc).AddTicks(8988));

            migrationBuilder.UpdateData(
                table: "ProductOptions",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 21, 36, 388, DateTimeKind.Utc).AddTicks(8990));

            migrationBuilder.UpdateData(
                table: "ProductOptions",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 21, 36, 388, DateTimeKind.Utc).AddTicks(8992));

            migrationBuilder.UpdateData(
                table: "ProductOptions",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 21, 36, 388, DateTimeKind.Utc).AddTicks(8993));

            migrationBuilder.UpdateData(
                table: "ProductOptions",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 21, 36, 388, DateTimeKind.Utc).AddTicks(8995));

            migrationBuilder.UpdateData(
                table: "ProductOptions",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 21, 36, 388, DateTimeKind.Utc).AddTicks(8997));

            migrationBuilder.UpdateData(
                table: "ProductOptions",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 21, 36, 388, DateTimeKind.Utc).AddTicks(8999));

            migrationBuilder.UpdateData(
                table: "ProductOptions",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 21, 36, 388, DateTimeKind.Utc).AddTicks(9008));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 21, 36, 387, DateTimeKind.Utc).AddTicks(5237));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 21, 36, 387, DateTimeKind.Utc).AddTicks(5241));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 21, 36, 387, DateTimeKind.Utc).AddTicks(5245));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 21, 36, 387, DateTimeKind.Utc).AddTicks(5248));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 21, 36, 387, DateTimeKind.Utc).AddTicks(5250));

            migrationBuilder.UpdateData(
                table: "Trademarks",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 21, 36, 390, DateTimeKind.Utc).AddTicks(7661));

            migrationBuilder.UpdateData(
                table: "Trademarks",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 21, 36, 390, DateTimeKind.Utc).AddTicks(7696));

            migrationBuilder.UpdateData(
                table: "Trademarks",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 21, 36, 390, DateTimeKind.Utc).AddTicks(7699));

            migrationBuilder.UpdateData(
                table: "Trademarks",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 21, 36, 390, DateTimeKind.Utc).AddTicks(7701));

            migrationBuilder.UpdateData(
                table: "Trademarks",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 21, 36, 390, DateTimeKind.Utc).AddTicks(7703));

            migrationBuilder.UpdateData(
                table: "Variants",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 21, 36, 392, DateTimeKind.Utc).AddTicks(5278));

            migrationBuilder.UpdateData(
                table: "Variants",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 21, 36, 392, DateTimeKind.Utc).AddTicks(5282));

            migrationBuilder.UpdateData(
                table: "Variants",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 21, 36, 392, DateTimeKind.Utc).AddTicks(5284));

            migrationBuilder.UpdateData(
                table: "Variants",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 21, 36, 392, DateTimeKind.Utc).AddTicks(5286));

            migrationBuilder.UpdateData(
                table: "Variants",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 21, 36, 392, DateTimeKind.Utc).AddTicks(5288));

            migrationBuilder.UpdateData(
                table: "Variants",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 21, 36, 392, DateTimeKind.Utc).AddTicks(5290));

            migrationBuilder.UpdateData(
                table: "Variants",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 21, 36, 392, DateTimeKind.Utc).AddTicks(5291));

            migrationBuilder.UpdateData(
                table: "Variants",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 21, 36, 392, DateTimeKind.Utc).AddTicks(5293));

            migrationBuilder.UpdateData(
                table: "Variants",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 21, 36, 392, DateTimeKind.Utc).AddTicks(5295));

            migrationBuilder.CreateIndex(
                name: "IX_RoleOperationalClaims_OperationalClaimId",
                table: "RoleOperationalClaims",
                column: "OperationalClaimId");

            migrationBuilder.CreateIndex(
                name: "IX_RoleOperationalClaims_RoleId",
                table: "RoleOperationalClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_UserLogins_UserId",
                table: "UserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserRoles_RoleId",
                table: "UserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_UserRoles_UserId",
                table: "UserRoles",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RoleOperationalClaims");

            migrationBuilder.DropTable(
                name: "UserLogins");

            migrationBuilder.DropTable(
                name: "UserRoles");

            migrationBuilder.DropTable(
                name: "OperationalClaims");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.UpdateData(
                table: "DataSchemaFields",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 7, 16, 2, 17, 727, DateTimeKind.Utc).AddTicks(5926));

            migrationBuilder.UpdateData(
                table: "DataSchemaFields",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 7, 16, 2, 17, 727, DateTimeKind.Utc).AddTicks(5932));

            migrationBuilder.UpdateData(
                table: "DataSchemaFields",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 7, 16, 2, 17, 727, DateTimeKind.Utc).AddTicks(5935));

            migrationBuilder.UpdateData(
                table: "DataSchemaFields",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 7, 16, 2, 17, 727, DateTimeKind.Utc).AddTicks(5939));

            migrationBuilder.UpdateData(
                table: "DataSchemaFields",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 7, 16, 2, 17, 727, DateTimeKind.Utc).AddTicks(5942));

            migrationBuilder.UpdateData(
                table: "DataSchemaFields",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 7, 16, 2, 17, 727, DateTimeKind.Utc).AddTicks(5945));

            migrationBuilder.UpdateData(
                table: "DataSchemas",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 7, 16, 2, 17, 725, DateTimeKind.Utc).AddTicks(7236));

            migrationBuilder.UpdateData(
                table: "DataSchemas",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 7, 16, 2, 17, 725, DateTimeKind.Utc).AddTicks(7240));

            migrationBuilder.UpdateData(
                table: "DataSchemas",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 7, 16, 2, 17, 725, DateTimeKind.Utc).AddTicks(7243));

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 7, 16, 2, 17, 720, DateTimeKind.Utc).AddTicks(1558));

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 7, 16, 2, 17, 720, DateTimeKind.Utc).AddTicks(1563));

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 7, 16, 2, 17, 720, DateTimeKind.Utc).AddTicks(1565));

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 7, 16, 2, 17, 720, DateTimeKind.Utc).AddTicks(1567));

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 7, 16, 2, 17, 720, DateTimeKind.Utc).AddTicks(1569));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 7, 16, 2, 17, 720, DateTimeKind.Utc).AddTicks(8712));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 7, 16, 2, 17, 720, DateTimeKind.Utc).AddTicks(8718));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 7, 16, 2, 17, 720, DateTimeKind.Utc).AddTicks(8721));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 7, 16, 2, 17, 720, DateTimeKind.Utc).AddTicks(8722));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 7, 16, 2, 17, 720, DateTimeKind.Utc).AddTicks(8724));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 7, 16, 2, 17, 720, DateTimeKind.Utc).AddTicks(8727));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 7, 16, 2, 17, 720, DateTimeKind.Utc).AddTicks(8728));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 7, 16, 2, 17, 720, DateTimeKind.Utc).AddTicks(8729));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 7, 16, 2, 17, 720, DateTimeKind.Utc).AddTicks(8730));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 7, 16, 2, 17, 720, DateTimeKind.Utc).AddTicks(8732));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 7, 16, 2, 17, 720, DateTimeKind.Utc).AddTicks(8733));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 7, 16, 2, 17, 720, DateTimeKind.Utc).AddTicks(8734));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 7, 16, 2, 17, 720, DateTimeKind.Utc).AddTicks(8735));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 7, 16, 2, 17, 720, DateTimeKind.Utc).AddTicks(8736));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 7, 16, 2, 17, 720, DateTimeKind.Utc).AddTicks(8737));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 16,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 7, 16, 2, 17, 720, DateTimeKind.Utc).AddTicks(8739));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 17,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 7, 16, 2, 17, 720, DateTimeKind.Utc).AddTicks(8740));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 18,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 7, 16, 2, 17, 720, DateTimeKind.Utc).AddTicks(8741));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 19,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 7, 16, 2, 17, 720, DateTimeKind.Utc).AddTicks(8742));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 20,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 7, 16, 2, 17, 720, DateTimeKind.Utc).AddTicks(8776));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 21,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 7, 16, 2, 17, 720, DateTimeKind.Utc).AddTicks(8784));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 22,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 7, 16, 2, 17, 720, DateTimeKind.Utc).AddTicks(8785));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 23,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 7, 16, 2, 17, 720, DateTimeKind.Utc).AddTicks(8786));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 24,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 7, 16, 2, 17, 720, DateTimeKind.Utc).AddTicks(8787));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 25,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 7, 16, 2, 17, 720, DateTimeKind.Utc).AddTicks(8788));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 26,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 7, 16, 2, 17, 720, DateTimeKind.Utc).AddTicks(8789));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 27,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 7, 16, 2, 17, 720, DateTimeKind.Utc).AddTicks(8790));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 28,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 7, 16, 2, 17, 720, DateTimeKind.Utc).AddTicks(8791));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 29,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 7, 16, 2, 17, 720, DateTimeKind.Utc).AddTicks(8792));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 30,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 7, 16, 2, 17, 720, DateTimeKind.Utc).AddTicks(8802));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 31,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 7, 16, 2, 17, 720, DateTimeKind.Utc).AddTicks(8803));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 32,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 7, 16, 2, 17, 720, DateTimeKind.Utc).AddTicks(8804));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 33,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 7, 16, 2, 17, 720, DateTimeKind.Utc).AddTicks(8805));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 34,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 7, 16, 2, 17, 720, DateTimeKind.Utc).AddTicks(8807));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 35,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 7, 16, 2, 17, 720, DateTimeKind.Utc).AddTicks(8808));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 36,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 7, 16, 2, 17, 720, DateTimeKind.Utc).AddTicks(8809));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 37,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 7, 16, 2, 17, 720, DateTimeKind.Utc).AddTicks(8810));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 38,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 7, 16, 2, 17, 720, DateTimeKind.Utc).AddTicks(8811));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 39,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 7, 16, 2, 17, 720, DateTimeKind.Utc).AddTicks(8815));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 40,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 7, 16, 2, 17, 720, DateTimeKind.Utc).AddTicks(8816));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 41,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 7, 16, 2, 17, 720, DateTimeKind.Utc).AddTicks(8817));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 42,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 7, 16, 2, 17, 720, DateTimeKind.Utc).AddTicks(8818));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 43,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 7, 16, 2, 17, 720, DateTimeKind.Utc).AddTicks(8819));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 44,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 7, 16, 2, 17, 720, DateTimeKind.Utc).AddTicks(8821));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 45,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 7, 16, 2, 17, 720, DateTimeKind.Utc).AddTicks(8823));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 46,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 7, 16, 2, 17, 720, DateTimeKind.Utc).AddTicks(8824));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 47,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 7, 16, 2, 17, 720, DateTimeKind.Utc).AddTicks(8825));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 48,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 7, 16, 2, 17, 720, DateTimeKind.Utc).AddTicks(8826));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 49,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 7, 16, 2, 17, 720, DateTimeKind.Utc).AddTicks(8827));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 50,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 7, 16, 2, 17, 720, DateTimeKind.Utc).AddTicks(8828));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 51,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 7, 16, 2, 17, 720, DateTimeKind.Utc).AddTicks(8829));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 52,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 7, 16, 2, 17, 720, DateTimeKind.Utc).AddTicks(8830));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 53,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 7, 16, 2, 17, 720, DateTimeKind.Utc).AddTicks(8831));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 54,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 7, 16, 2, 17, 720, DateTimeKind.Utc).AddTicks(8834));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 55,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 7, 16, 2, 17, 720, DateTimeKind.Utc).AddTicks(8859));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 56,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 7, 16, 2, 17, 720, DateTimeKind.Utc).AddTicks(8860));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 57,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 7, 16, 2, 17, 720, DateTimeKind.Utc).AddTicks(8861));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 58,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 7, 16, 2, 17, 720, DateTimeKind.Utc).AddTicks(8862));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 59,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 7, 16, 2, 17, 720, DateTimeKind.Utc).AddTicks(8863));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 60,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 7, 16, 2, 17, 720, DateTimeKind.Utc).AddTicks(8864));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 61,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 7, 16, 2, 17, 720, DateTimeKind.Utc).AddTicks(8865));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 62,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 7, 16, 2, 17, 720, DateTimeKind.Utc).AddTicks(8867));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 63,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 7, 16, 2, 17, 720, DateTimeKind.Utc).AddTicks(8868));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 64,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 7, 16, 2, 17, 720, DateTimeKind.Utc).AddTicks(8869));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 65,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 7, 16, 2, 17, 720, DateTimeKind.Utc).AddTicks(8870));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 66,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 7, 16, 2, 17, 720, DateTimeKind.Utc).AddTicks(8872));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 67,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 7, 16, 2, 17, 720, DateTimeKind.Utc).AddTicks(8873));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 68,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 7, 16, 2, 17, 720, DateTimeKind.Utc).AddTicks(8874));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 69,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 7, 16, 2, 17, 720, DateTimeKind.Utc).AddTicks(8875));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 70,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 7, 16, 2, 17, 720, DateTimeKind.Utc).AddTicks(8878));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 71,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 7, 16, 2, 17, 720, DateTimeKind.Utc).AddTicks(8880));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 72,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 7, 16, 2, 17, 720, DateTimeKind.Utc).AddTicks(8881));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 73,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 7, 16, 2, 17, 720, DateTimeKind.Utc).AddTicks(8882));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 74,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 7, 16, 2, 17, 720, DateTimeKind.Utc).AddTicks(8884));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 75,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 7, 16, 2, 17, 720, DateTimeKind.Utc).AddTicks(8885));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 76,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 7, 16, 2, 17, 720, DateTimeKind.Utc).AddTicks(8886));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 77,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 7, 16, 2, 17, 720, DateTimeKind.Utc).AddTicks(8887));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 78,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 7, 16, 2, 17, 720, DateTimeKind.Utc).AddTicks(8888));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 79,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 7, 16, 2, 17, 720, DateTimeKind.Utc).AddTicks(8889));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 80,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 7, 16, 2, 17, 720, DateTimeKind.Utc).AddTicks(8893));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 81,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 7, 16, 2, 17, 720, DateTimeKind.Utc).AddTicks(8895));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 82,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 7, 16, 2, 17, 720, DateTimeKind.Utc).AddTicks(8896));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 83,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 7, 16, 2, 17, 720, DateTimeKind.Utc).AddTicks(8897));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 84,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 7, 16, 2, 17, 720, DateTimeKind.Utc).AddTicks(8898));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 85,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 7, 16, 2, 17, 720, DateTimeKind.Utc).AddTicks(8900));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 86,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 7, 16, 2, 17, 720, DateTimeKind.Utc).AddTicks(8901));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 87,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 7, 16, 2, 17, 720, DateTimeKind.Utc).AddTicks(8932));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 88,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 7, 16, 2, 17, 720, DateTimeKind.Utc).AddTicks(8933));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 89,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 7, 16, 2, 17, 720, DateTimeKind.Utc).AddTicks(8934));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 90,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 7, 16, 2, 17, 720, DateTimeKind.Utc).AddTicks(8935));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 91,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 7, 16, 2, 17, 720, DateTimeKind.Utc).AddTicks(8937));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 92,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 7, 16, 2, 17, 720, DateTimeKind.Utc).AddTicks(8938));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 93,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 7, 16, 2, 17, 720, DateTimeKind.Utc).AddTicks(8939));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 94,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 7, 16, 2, 17, 720, DateTimeKind.Utc).AddTicks(8940));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 95,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 7, 16, 2, 17, 720, DateTimeKind.Utc).AddTicks(8941));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 96,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 7, 16, 2, 17, 720, DateTimeKind.Utc).AddTicks(8942));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 97,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 7, 16, 2, 17, 720, DateTimeKind.Utc).AddTicks(8943));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 98,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 7, 16, 2, 17, 720, DateTimeKind.Utc).AddTicks(8944));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 99,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 7, 16, 2, 17, 720, DateTimeKind.Utc).AddTicks(8945));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 100,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 7, 16, 2, 17, 720, DateTimeKind.Utc).AddTicks(8946));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 101,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 7, 16, 2, 17, 720, DateTimeKind.Utc).AddTicks(8947));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 102,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 7, 16, 2, 17, 720, DateTimeKind.Utc).AddTicks(8948));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 103,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 7, 16, 2, 17, 720, DateTimeKind.Utc).AddTicks(8949));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 104,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 7, 16, 2, 17, 720, DateTimeKind.Utc).AddTicks(8950));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 105,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 7, 16, 2, 17, 720, DateTimeKind.Utc).AddTicks(8951));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 106,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 7, 16, 2, 17, 720, DateTimeKind.Utc).AddTicks(8953));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 107,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 7, 16, 2, 17, 720, DateTimeKind.Utc).AddTicks(8954));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 108,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 7, 16, 2, 17, 720, DateTimeKind.Utc).AddTicks(8955));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 109,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 7, 16, 2, 17, 720, DateTimeKind.Utc).AddTicks(8958));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 110,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 7, 16, 2, 17, 720, DateTimeKind.Utc).AddTicks(8960));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 111,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 7, 16, 2, 17, 720, DateTimeKind.Utc).AddTicks(8963));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 112,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 7, 16, 2, 17, 720, DateTimeKind.Utc).AddTicks(8965));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 113,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 7, 16, 2, 17, 720, DateTimeKind.Utc).AddTicks(8966));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 114,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 7, 16, 2, 17, 720, DateTimeKind.Utc).AddTicks(8967));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 115,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 7, 16, 2, 17, 720, DateTimeKind.Utc).AddTicks(8968));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 116,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 7, 16, 2, 17, 720, DateTimeKind.Utc).AddTicks(8969));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 117,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 7, 16, 2, 17, 720, DateTimeKind.Utc).AddTicks(8970));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 118,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 7, 16, 2, 17, 720, DateTimeKind.Utc).AddTicks(8971));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 119,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 7, 16, 2, 17, 720, DateTimeKind.Utc).AddTicks(8972));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 120,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 7, 16, 2, 17, 720, DateTimeKind.Utc).AddTicks(8973));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 121,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 7, 16, 2, 17, 720, DateTimeKind.Utc).AddTicks(8974));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 122,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 7, 16, 2, 17, 720, DateTimeKind.Utc).AddTicks(9000));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 123,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 7, 16, 2, 17, 720, DateTimeKind.Utc).AddTicks(9001));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 124,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 7, 16, 2, 17, 720, DateTimeKind.Utc).AddTicks(9002));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 125,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 7, 16, 2, 17, 720, DateTimeKind.Utc).AddTicks(9003));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 126,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 7, 16, 2, 17, 720, DateTimeKind.Utc).AddTicks(9004));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 127,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 7, 16, 2, 17, 720, DateTimeKind.Utc).AddTicks(9005));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 128,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 7, 16, 2, 17, 720, DateTimeKind.Utc).AddTicks(9007));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 129,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 7, 16, 2, 17, 720, DateTimeKind.Utc).AddTicks(9008));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 130,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 7, 16, 2, 17, 720, DateTimeKind.Utc).AddTicks(9010));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 131,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 7, 16, 2, 17, 720, DateTimeKind.Utc).AddTicks(9011));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 132,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 7, 16, 2, 17, 720, DateTimeKind.Utc).AddTicks(9013));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 133,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 7, 16, 2, 17, 720, DateTimeKind.Utc).AddTicks(9014));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 134,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 7, 16, 2, 17, 720, DateTimeKind.Utc).AddTicks(9015));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 135,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 7, 16, 2, 17, 720, DateTimeKind.Utc).AddTicks(9016));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 136,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 7, 16, 2, 17, 720, DateTimeKind.Utc).AddTicks(9017));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 137,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 7, 16, 2, 17, 720, DateTimeKind.Utc).AddTicks(9018));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 138,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 7, 16, 2, 17, 720, DateTimeKind.Utc).AddTicks(9019));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 139,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 7, 16, 2, 17, 720, DateTimeKind.Utc).AddTicks(9022));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 140,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 7, 16, 2, 17, 720, DateTimeKind.Utc).AddTicks(9024));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 141,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 7, 16, 2, 17, 720, DateTimeKind.Utc).AddTicks(9025));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 142,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 7, 16, 2, 17, 720, DateTimeKind.Utc).AddTicks(9026));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 143,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 7, 16, 2, 17, 720, DateTimeKind.Utc).AddTicks(9027));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 144,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 7, 16, 2, 17, 720, DateTimeKind.Utc).AddTicks(9029));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 145,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 7, 16, 2, 17, 720, DateTimeKind.Utc).AddTicks(9030));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 146,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 7, 16, 2, 17, 720, DateTimeKind.Utc).AddTicks(9031));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 147,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 7, 16, 2, 17, 720, DateTimeKind.Utc).AddTicks(9032));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 148,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 7, 16, 2, 17, 720, DateTimeKind.Utc).AddTicks(9058));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 149,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 7, 16, 2, 17, 720, DateTimeKind.Utc).AddTicks(9059));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 150,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 7, 16, 2, 17, 720, DateTimeKind.Utc).AddTicks(9060));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 151,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 7, 16, 2, 17, 720, DateTimeKind.Utc).AddTicks(9061));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 152,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 7, 16, 2, 17, 720, DateTimeKind.Utc).AddTicks(9063));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 153,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 7, 16, 2, 17, 720, DateTimeKind.Utc).AddTicks(9064));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 154,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 7, 16, 2, 17, 720, DateTimeKind.Utc).AddTicks(9065));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 155,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 7, 16, 2, 17, 720, DateTimeKind.Utc).AddTicks(9067));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 156,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 7, 16, 2, 17, 720, DateTimeKind.Utc).AddTicks(9068));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 157,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 7, 16, 2, 17, 720, DateTimeKind.Utc).AddTicks(9069));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 158,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 7, 16, 2, 17, 720, DateTimeKind.Utc).AddTicks(9070));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 159,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 7, 16, 2, 17, 720, DateTimeKind.Utc).AddTicks(9071));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 160,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 7, 16, 2, 17, 720, DateTimeKind.Utc).AddTicks(9072));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 161,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 7, 16, 2, 17, 720, DateTimeKind.Utc).AddTicks(9073));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 162,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 7, 16, 2, 17, 720, DateTimeKind.Utc).AddTicks(9074));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 163,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 7, 16, 2, 17, 720, DateTimeKind.Utc).AddTicks(9075));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 164,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 7, 16, 2, 17, 720, DateTimeKind.Utc).AddTicks(9079));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 165,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 7, 16, 2, 17, 720, DateTimeKind.Utc).AddTicks(9080));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 166,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 7, 16, 2, 17, 720, DateTimeKind.Utc).AddTicks(9082));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 167,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 7, 16, 2, 17, 720, DateTimeKind.Utc).AddTicks(9083));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 168,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 7, 16, 2, 17, 720, DateTimeKind.Utc).AddTicks(9084));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 169,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 7, 16, 2, 17, 720, DateTimeKind.Utc).AddTicks(9085));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 170,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 7, 16, 2, 17, 720, DateTimeKind.Utc).AddTicks(9086));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 171,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 7, 16, 2, 17, 720, DateTimeKind.Utc).AddTicks(9087));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 172,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 7, 16, 2, 17, 720, DateTimeKind.Utc).AddTicks(9088));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 173,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 7, 16, 2, 17, 720, DateTimeKind.Utc).AddTicks(9089));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 174,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 7, 16, 2, 17, 720, DateTimeKind.Utc).AddTicks(9090));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 175,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 7, 16, 2, 17, 720, DateTimeKind.Utc).AddTicks(9091));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 176,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 7, 16, 2, 17, 720, DateTimeKind.Utc).AddTicks(9092));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 177,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 7, 16, 2, 17, 720, DateTimeKind.Utc).AddTicks(9093));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 178,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 7, 16, 2, 17, 720, DateTimeKind.Utc).AddTicks(9094));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 179,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 7, 16, 2, 17, 720, DateTimeKind.Utc).AddTicks(9095));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 180,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 7, 16, 2, 17, 720, DateTimeKind.Utc).AddTicks(9096));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 181,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 7, 16, 2, 17, 720, DateTimeKind.Utc).AddTicks(9097));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 182,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 7, 16, 2, 17, 720, DateTimeKind.Utc).AddTicks(9098));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 183,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 7, 16, 2, 17, 720, DateTimeKind.Utc).AddTicks(9099));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 184,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 7, 16, 2, 17, 720, DateTimeKind.Utc).AddTicks(9133));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 185,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 7, 16, 2, 17, 720, DateTimeKind.Utc).AddTicks(9134));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 186,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 7, 16, 2, 17, 720, DateTimeKind.Utc).AddTicks(9135));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 187,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 7, 16, 2, 17, 720, DateTimeKind.Utc).AddTicks(9136));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 188,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 7, 16, 2, 17, 720, DateTimeKind.Utc).AddTicks(9137));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 189,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 7, 16, 2, 17, 720, DateTimeKind.Utc).AddTicks(9138));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 190,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 7, 16, 2, 17, 720, DateTimeKind.Utc).AddTicks(9139));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 191,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 7, 16, 2, 17, 720, DateTimeKind.Utc).AddTicks(9140));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 192,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 7, 16, 2, 17, 720, DateTimeKind.Utc).AddTicks(9141));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 193,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 7, 16, 2, 17, 720, DateTimeKind.Utc).AddTicks(9142));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 194,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 7, 16, 2, 17, 720, DateTimeKind.Utc).AddTicks(9143));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 195,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 7, 16, 2, 17, 720, DateTimeKind.Utc).AddTicks(9144));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 196,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 7, 16, 2, 17, 720, DateTimeKind.Utc).AddTicks(9145));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 197,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 7, 16, 2, 17, 720, DateTimeKind.Utc).AddTicks(9146));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 198,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 7, 16, 2, 17, 720, DateTimeKind.Utc).AddTicks(9147));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 199,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 7, 16, 2, 17, 720, DateTimeKind.Utc).AddTicks(9148));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 200,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 7, 16, 2, 17, 720, DateTimeKind.Utc).AddTicks(9149));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 201,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 7, 16, 2, 17, 720, DateTimeKind.Utc).AddTicks(9150));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 202,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 7, 16, 2, 17, 720, DateTimeKind.Utc).AddTicks(9154));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 203,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 7, 16, 2, 17, 720, DateTimeKind.Utc).AddTicks(9155));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 204,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 7, 16, 2, 17, 720, DateTimeKind.Utc).AddTicks(9156));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 205,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 7, 16, 2, 17, 720, DateTimeKind.Utc).AddTicks(9157));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 206,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 7, 16, 2, 17, 720, DateTimeKind.Utc).AddTicks(9158));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 207,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 7, 16, 2, 17, 720, DateTimeKind.Utc).AddTicks(9159));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 208,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 7, 16, 2, 17, 720, DateTimeKind.Utc).AddTicks(9160));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 209,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 7, 16, 2, 17, 720, DateTimeKind.Utc).AddTicks(9161));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 210,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 7, 16, 2, 17, 720, DateTimeKind.Utc).AddTicks(9162));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 211,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 7, 16, 2, 17, 720, DateTimeKind.Utc).AddTicks(9164));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 212,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 7, 16, 2, 17, 720, DateTimeKind.Utc).AddTicks(9165));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 213,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 7, 16, 2, 17, 720, DateTimeKind.Utc).AddTicks(9166));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 214,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 7, 16, 2, 17, 720, DateTimeKind.Utc).AddTicks(9167));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 215,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 7, 16, 2, 17, 720, DateTimeKind.Utc).AddTicks(9168));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 216,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 7, 16, 2, 17, 720, DateTimeKind.Utc).AddTicks(9169));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 217,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 7, 16, 2, 17, 720, DateTimeKind.Utc).AddTicks(9172));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 218,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 7, 16, 2, 17, 720, DateTimeKind.Utc).AddTicks(9174));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 219,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 7, 16, 2, 17, 720, DateTimeKind.Utc).AddTicks(9175));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 220,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 7, 16, 2, 17, 720, DateTimeKind.Utc).AddTicks(9176));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 221,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 7, 16, 2, 17, 720, DateTimeKind.Utc).AddTicks(9198));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 222,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 7, 16, 2, 17, 720, DateTimeKind.Utc).AddTicks(9200));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 223,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 7, 16, 2, 17, 720, DateTimeKind.Utc).AddTicks(9201));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 224,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 7, 16, 2, 17, 720, DateTimeKind.Utc).AddTicks(9203));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 225,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 7, 16, 2, 17, 720, DateTimeKind.Utc).AddTicks(9204));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 226,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 7, 16, 2, 17, 720, DateTimeKind.Utc).AddTicks(9205));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 227,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 7, 16, 2, 17, 720, DateTimeKind.Utc).AddTicks(9206));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 228,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 7, 16, 2, 17, 720, DateTimeKind.Utc).AddTicks(9207));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 229,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 7, 16, 2, 17, 720, DateTimeKind.Utc).AddTicks(9208));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 230,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 7, 16, 2, 17, 720, DateTimeKind.Utc).AddTicks(9209));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 231,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 7, 16, 2, 17, 720, DateTimeKind.Utc).AddTicks(9211));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 232,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 7, 16, 2, 17, 720, DateTimeKind.Utc).AddTicks(9212));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 233,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 7, 16, 2, 17, 720, DateTimeKind.Utc).AddTicks(9215));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 234,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 7, 16, 2, 17, 720, DateTimeKind.Utc).AddTicks(9217));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 235,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 7, 16, 2, 17, 720, DateTimeKind.Utc).AddTicks(9218));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 236,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 7, 16, 2, 17, 720, DateTimeKind.Utc).AddTicks(9219));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 237,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 7, 16, 2, 17, 720, DateTimeKind.Utc).AddTicks(9221));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 238,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 7, 16, 2, 17, 720, DateTimeKind.Utc).AddTicks(9222));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 239,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 7, 16, 2, 17, 720, DateTimeKind.Utc).AddTicks(9223));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 240,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 7, 16, 2, 17, 720, DateTimeKind.Utc).AddTicks(9224));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 241,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 7, 16, 2, 17, 720, DateTimeKind.Utc).AddTicks(9225));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 242,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 7, 16, 2, 17, 720, DateTimeKind.Utc).AddTicks(9226));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 243,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 7, 16, 2, 17, 720, DateTimeKind.Utc).AddTicks(9229));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 244,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 7, 16, 2, 17, 720, DateTimeKind.Utc).AddTicks(9231));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 245,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 7, 16, 2, 17, 720, DateTimeKind.Utc).AddTicks(9232));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 246,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 7, 16, 2, 17, 720, DateTimeKind.Utc).AddTicks(9234));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 247,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 7, 16, 2, 17, 720, DateTimeKind.Utc).AddTicks(9235));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 248,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 7, 16, 2, 17, 720, DateTimeKind.Utc).AddTicks(9236));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 249,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 7, 16, 2, 17, 720, DateTimeKind.Utc).AddTicks(9237));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 250,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 7, 16, 2, 17, 720, DateTimeKind.Utc).AddTicks(9239));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 251,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 7, 16, 2, 17, 720, DateTimeKind.Utc).AddTicks(9240));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 252,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 7, 16, 2, 17, 720, DateTimeKind.Utc).AddTicks(9241));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 253,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 7, 16, 2, 17, 720, DateTimeKind.Utc).AddTicks(9242));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 254,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 7, 16, 2, 17, 720, DateTimeKind.Utc).AddTicks(9243));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 255,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 7, 16, 2, 17, 720, DateTimeKind.Utc).AddTicks(9244));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 256,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 7, 16, 2, 17, 720, DateTimeKind.Utc).AddTicks(9279));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 257,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 7, 16, 2, 17, 720, DateTimeKind.Utc).AddTicks(9280));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 258,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 7, 16, 2, 17, 720, DateTimeKind.Utc).AddTicks(9283));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 259,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 7, 16, 2, 17, 720, DateTimeKind.Utc).AddTicks(9284));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 260,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 7, 16, 2, 17, 720, DateTimeKind.Utc).AddTicks(9285));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 261,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 7, 16, 2, 17, 720, DateTimeKind.Utc).AddTicks(9286));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 262,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 7, 16, 2, 17, 720, DateTimeKind.Utc).AddTicks(9287));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 263,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 7, 16, 2, 17, 720, DateTimeKind.Utc).AddTicks(9288));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 264,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 7, 16, 2, 17, 720, DateTimeKind.Utc).AddTicks(9289));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 265,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 7, 16, 2, 17, 720, DateTimeKind.Utc).AddTicks(9291));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 266,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 7, 16, 2, 17, 720, DateTimeKind.Utc).AddTicks(9292));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 267,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 7, 16, 2, 17, 720, DateTimeKind.Utc).AddTicks(9293));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 268,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 7, 16, 2, 17, 720, DateTimeKind.Utc).AddTicks(9294));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 269,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 7, 16, 2, 17, 720, DateTimeKind.Utc).AddTicks(9295));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 270,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 7, 16, 2, 17, 720, DateTimeKind.Utc).AddTicks(9296));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 271,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 7, 16, 2, 17, 720, DateTimeKind.Utc).AddTicks(9297));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 272,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 7, 16, 2, 17, 720, DateTimeKind.Utc).AddTicks(9300));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 273,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 7, 16, 2, 17, 720, DateTimeKind.Utc).AddTicks(9302));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 274,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 7, 16, 2, 17, 720, DateTimeKind.Utc).AddTicks(9341));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 275,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 7, 16, 2, 17, 720, DateTimeKind.Utc).AddTicks(9343));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 276,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 7, 16, 2, 17, 720, DateTimeKind.Utc).AddTicks(9344));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 277,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 7, 16, 2, 17, 720, DateTimeKind.Utc).AddTicks(9345));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 278,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 7, 16, 2, 17, 720, DateTimeKind.Utc).AddTicks(9346));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 279,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 7, 16, 2, 17, 720, DateTimeKind.Utc).AddTicks(9347));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 280,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 7, 16, 2, 17, 720, DateTimeKind.Utc).AddTicks(9348));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 281,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 7, 16, 2, 17, 720, DateTimeKind.Utc).AddTicks(9350));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 282,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 7, 16, 2, 17, 720, DateTimeKind.Utc).AddTicks(9351));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 283,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 7, 16, 2, 17, 720, DateTimeKind.Utc).AddTicks(9352));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 284,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 7, 16, 2, 17, 720, DateTimeKind.Utc).AddTicks(9353));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 285,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 7, 16, 2, 17, 720, DateTimeKind.Utc).AddTicks(9354));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 286,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 7, 16, 2, 17, 720, DateTimeKind.Utc).AddTicks(9355));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 287,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 7, 16, 2, 17, 720, DateTimeKind.Utc).AddTicks(9356));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 288,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 7, 16, 2, 17, 720, DateTimeKind.Utc).AddTicks(9357));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 289,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 7, 16, 2, 17, 720, DateTimeKind.Utc).AddTicks(9359));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 290,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 7, 16, 2, 17, 720, DateTimeKind.Utc).AddTicks(9360));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 291,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 7, 16, 2, 17, 720, DateTimeKind.Utc).AddTicks(9361));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 292,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 7, 16, 2, 17, 720, DateTimeKind.Utc).AddTicks(9362));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 293,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 7, 16, 2, 17, 720, DateTimeKind.Utc).AddTicks(9363));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 294,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 7, 16, 2, 17, 720, DateTimeKind.Utc).AddTicks(9364));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 295,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 7, 16, 2, 17, 720, DateTimeKind.Utc).AddTicks(9365));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 296,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 7, 16, 2, 17, 720, DateTimeKind.Utc).AddTicks(9366));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 297,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 7, 16, 2, 17, 720, DateTimeKind.Utc).AddTicks(9367));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 298,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 7, 16, 2, 17, 720, DateTimeKind.Utc).AddTicks(9368));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 299,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 7, 16, 2, 17, 720, DateTimeKind.Utc).AddTicks(9369));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 300,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 7, 16, 2, 17, 720, DateTimeKind.Utc).AddTicks(9370));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 301,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 7, 16, 2, 17, 720, DateTimeKind.Utc).AddTicks(9372));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 302,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 7, 16, 2, 17, 720, DateTimeKind.Utc).AddTicks(9375));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 303,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 7, 16, 2, 17, 720, DateTimeKind.Utc).AddTicks(9376));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 304,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 7, 16, 2, 17, 720, DateTimeKind.Utc).AddTicks(9378));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 305,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 7, 16, 2, 17, 720, DateTimeKind.Utc).AddTicks(9379));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 306,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 7, 16, 2, 17, 720, DateTimeKind.Utc).AddTicks(9380));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 307,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 7, 16, 2, 17, 720, DateTimeKind.Utc).AddTicks(9381));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 308,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 7, 16, 2, 17, 720, DateTimeKind.Utc).AddTicks(9382));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 309,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 7, 16, 2, 17, 720, DateTimeKind.Utc).AddTicks(9409));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 310,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 7, 16, 2, 17, 720, DateTimeKind.Utc).AddTicks(9411));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 311,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 7, 16, 2, 17, 720, DateTimeKind.Utc).AddTicks(9412));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 312,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 7, 16, 2, 17, 720, DateTimeKind.Utc).AddTicks(9413));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 313,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 7, 16, 2, 17, 720, DateTimeKind.Utc).AddTicks(9414));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 314,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 7, 16, 2, 17, 720, DateTimeKind.Utc).AddTicks(9415));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 315,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 7, 16, 2, 17, 720, DateTimeKind.Utc).AddTicks(9417));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 316,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 7, 16, 2, 17, 720, DateTimeKind.Utc).AddTicks(9418));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 317,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 7, 16, 2, 17, 720, DateTimeKind.Utc).AddTicks(9419));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 318,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 7, 16, 2, 17, 720, DateTimeKind.Utc).AddTicks(9420));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 319,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 7, 16, 2, 17, 720, DateTimeKind.Utc).AddTicks(9421));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 320,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 7, 16, 2, 17, 720, DateTimeKind.Utc).AddTicks(9423));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 321,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 7, 16, 2, 17, 720, DateTimeKind.Utc).AddTicks(9424));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 322,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 7, 16, 2, 17, 720, DateTimeKind.Utc).AddTicks(9425));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 323,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 7, 16, 2, 17, 720, DateTimeKind.Utc).AddTicks(9426));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 324,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 7, 16, 2, 17, 720, DateTimeKind.Utc).AddTicks(9428));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 325,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 7, 16, 2, 17, 720, DateTimeKind.Utc).AddTicks(9429));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 326,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 7, 16, 2, 17, 720, DateTimeKind.Utc).AddTicks(9430));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 327,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 7, 16, 2, 17, 720, DateTimeKind.Utc).AddTicks(9498));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 328,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 7, 16, 2, 17, 720, DateTimeKind.Utc).AddTicks(9500));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 329,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 7, 16, 2, 17, 720, DateTimeKind.Utc).AddTicks(9501));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 330,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 7, 16, 2, 17, 720, DateTimeKind.Utc).AddTicks(9503));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 331,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 7, 16, 2, 17, 720, DateTimeKind.Utc).AddTicks(9504));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 332,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 7, 16, 2, 17, 720, DateTimeKind.Utc).AddTicks(9505));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 333,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 7, 16, 2, 17, 720, DateTimeKind.Utc).AddTicks(9506));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 334,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 7, 16, 2, 17, 720, DateTimeKind.Utc).AddTicks(9507));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 335,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 7, 16, 2, 17, 720, DateTimeKind.Utc).AddTicks(9508));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 336,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 7, 16, 2, 17, 720, DateTimeKind.Utc).AddTicks(9509));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 337,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 7, 16, 2, 17, 720, DateTimeKind.Utc).AddTicks(9510));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 338,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 7, 16, 2, 17, 720, DateTimeKind.Utc).AddTicks(9511));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 339,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 7, 16, 2, 17, 720, DateTimeKind.Utc).AddTicks(9512));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 340,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 7, 16, 2, 17, 720, DateTimeKind.Utc).AddTicks(9513));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 341,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 7, 16, 2, 17, 720, DateTimeKind.Utc).AddTicks(9514));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 342,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 7, 16, 2, 17, 720, DateTimeKind.Utc).AddTicks(9515));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 343,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 7, 16, 2, 17, 720, DateTimeKind.Utc).AddTicks(9517));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 344,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 7, 16, 2, 17, 720, DateTimeKind.Utc).AddTicks(9518));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 345,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 7, 16, 2, 17, 720, DateTimeKind.Utc).AddTicks(9519));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 346,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 7, 16, 2, 17, 720, DateTimeKind.Utc).AddTicks(9520));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 347,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 7, 16, 2, 17, 720, DateTimeKind.Utc).AddTicks(9521));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 348,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 7, 16, 2, 17, 720, DateTimeKind.Utc).AddTicks(9522));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 349,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 7, 16, 2, 17, 720, DateTimeKind.Utc).AddTicks(9523));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 350,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 7, 16, 2, 17, 720, DateTimeKind.Utc).AddTicks(9524));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 351,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 7, 16, 2, 17, 720, DateTimeKind.Utc).AddTicks(9525));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 352,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 7, 16, 2, 17, 720, DateTimeKind.Utc).AddTicks(9526));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 353,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 7, 16, 2, 17, 720, DateTimeKind.Utc).AddTicks(9527));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 354,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 7, 16, 2, 17, 720, DateTimeKind.Utc).AddTicks(9528));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 355,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 7, 16, 2, 17, 720, DateTimeKind.Utc).AddTicks(9529));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 356,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 7, 16, 2, 17, 720, DateTimeKind.Utc).AddTicks(9530));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 357,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 7, 16, 2, 17, 720, DateTimeKind.Utc).AddTicks(9531));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 358,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 7, 16, 2, 17, 720, DateTimeKind.Utc).AddTicks(9533));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 359,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 7, 16, 2, 17, 720, DateTimeKind.Utc).AddTicks(9534));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 360,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 7, 16, 2, 17, 720, DateTimeKind.Utc).AddTicks(9535));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 361,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 7, 16, 2, 17, 720, DateTimeKind.Utc).AddTicks(9562));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 362,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 7, 16, 2, 17, 720, DateTimeKind.Utc).AddTicks(9564));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 363,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 7, 16, 2, 17, 720, DateTimeKind.Utc).AddTicks(9565));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 364,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 7, 16, 2, 17, 720, DateTimeKind.Utc).AddTicks(9567));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 365,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 7, 16, 2, 17, 720, DateTimeKind.Utc).AddTicks(9568));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 366,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 7, 16, 2, 17, 720, DateTimeKind.Utc).AddTicks(9569));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 367,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 7, 16, 2, 17, 720, DateTimeKind.Utc).AddTicks(9570));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 368,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 7, 16, 2, 17, 720, DateTimeKind.Utc).AddTicks(9571));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 369,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 7, 16, 2, 17, 720, DateTimeKind.Utc).AddTicks(9572));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 370,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 7, 16, 2, 17, 720, DateTimeKind.Utc).AddTicks(9573));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 371,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 7, 16, 2, 17, 720, DateTimeKind.Utc).AddTicks(9574));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 372,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 7, 16, 2, 17, 720, DateTimeKind.Utc).AddTicks(9575));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 373,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 7, 16, 2, 17, 720, DateTimeKind.Utc).AddTicks(9577));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 374,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 7, 16, 2, 17, 720, DateTimeKind.Utc).AddTicks(9578));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 375,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 7, 16, 2, 17, 720, DateTimeKind.Utc).AddTicks(9579));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 376,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 7, 16, 2, 17, 720, DateTimeKind.Utc).AddTicks(9580));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 377,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 7, 16, 2, 17, 720, DateTimeKind.Utc).AddTicks(9581));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 378,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 7, 16, 2, 17, 720, DateTimeKind.Utc).AddTicks(9582));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 379,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 7, 16, 2, 17, 720, DateTimeKind.Utc).AddTicks(9583));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 380,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 7, 16, 2, 17, 720, DateTimeKind.Utc).AddTicks(9584));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 381,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 7, 16, 2, 17, 720, DateTimeKind.Utc).AddTicks(9585));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 382,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 7, 16, 2, 17, 720, DateTimeKind.Utc).AddTicks(9586));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 383,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 7, 16, 2, 17, 720, DateTimeKind.Utc).AddTicks(9587));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 384,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 7, 16, 2, 17, 720, DateTimeKind.Utc).AddTicks(9588));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 385,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 7, 16, 2, 17, 720, DateTimeKind.Utc).AddTicks(9589));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 386,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 7, 16, 2, 17, 720, DateTimeKind.Utc).AddTicks(9590));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 387,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 7, 16, 2, 17, 720, DateTimeKind.Utc).AddTicks(9591));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 388,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 7, 16, 2, 17, 720, DateTimeKind.Utc).AddTicks(9592));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 389,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 7, 16, 2, 17, 720, DateTimeKind.Utc).AddTicks(9594));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 390,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 7, 16, 2, 17, 720, DateTimeKind.Utc).AddTicks(9595));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 391,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 7, 16, 2, 17, 720, DateTimeKind.Utc).AddTicks(9596));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 392,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 7, 16, 2, 17, 720, DateTimeKind.Utc).AddTicks(9597));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 393,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 7, 16, 2, 17, 720, DateTimeKind.Utc).AddTicks(9599));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 394,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 7, 16, 2, 17, 720, DateTimeKind.Utc).AddTicks(9600));

            migrationBuilder.UpdateData(
                table: "OptionTranslations",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 7, 16, 2, 17, 733, DateTimeKind.Utc).AddTicks(297));

            migrationBuilder.UpdateData(
                table: "OptionTranslations",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 7, 16, 2, 17, 733, DateTimeKind.Utc).AddTicks(300));

            migrationBuilder.UpdateData(
                table: "OptionTranslations",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 7, 16, 2, 17, 733, DateTimeKind.Utc).AddTicks(302));

            migrationBuilder.UpdateData(
                table: "OptionTranslations",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 7, 16, 2, 17, 733, DateTimeKind.Utc).AddTicks(304));

            migrationBuilder.UpdateData(
                table: "OptionTranslations",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 7, 16, 2, 17, 733, DateTimeKind.Utc).AddTicks(305));

            migrationBuilder.UpdateData(
                table: "OptionTranslations",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 7, 16, 2, 17, 733, DateTimeKind.Utc).AddTicks(307));

            migrationBuilder.UpdateData(
                table: "OptionTranslations",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 7, 16, 2, 17, 733, DateTimeKind.Utc).AddTicks(308));

            migrationBuilder.UpdateData(
                table: "OptionTranslations",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 7, 16, 2, 17, 733, DateTimeKind.Utc).AddTicks(310));

            migrationBuilder.UpdateData(
                table: "OptionTranslations",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 7, 16, 2, 17, 733, DateTimeKind.Utc).AddTicks(311));

            migrationBuilder.UpdateData(
                table: "OptionTranslations",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 7, 16, 2, 17, 733, DateTimeKind.Utc).AddTicks(313));

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 7, 16, 2, 17, 732, DateTimeKind.Utc).AddTicks(2020));

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 7, 16, 2, 17, 732, DateTimeKind.Utc).AddTicks(2024));

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 7, 16, 2, 17, 732, DateTimeKind.Utc).AddTicks(2027));

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 7, 16, 2, 17, 732, DateTimeKind.Utc).AddTicks(2029));

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 7, 16, 2, 17, 732, DateTimeKind.Utc).AddTicks(2031));

            migrationBuilder.UpdateData(
                table: "ProductOptions",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 7, 16, 2, 17, 736, DateTimeKind.Utc).AddTicks(1645));

            migrationBuilder.UpdateData(
                table: "ProductOptions",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 7, 16, 2, 17, 736, DateTimeKind.Utc).AddTicks(1649));

            migrationBuilder.UpdateData(
                table: "ProductOptions",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 7, 16, 2, 17, 736, DateTimeKind.Utc).AddTicks(1652));

            migrationBuilder.UpdateData(
                table: "ProductOptions",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 7, 16, 2, 17, 736, DateTimeKind.Utc).AddTicks(1657));

            migrationBuilder.UpdateData(
                table: "ProductOptions",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 7, 16, 2, 17, 736, DateTimeKind.Utc).AddTicks(1660));

            migrationBuilder.UpdateData(
                table: "ProductOptions",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 7, 16, 2, 17, 736, DateTimeKind.Utc).AddTicks(1662));

            migrationBuilder.UpdateData(
                table: "ProductOptions",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 7, 16, 2, 17, 736, DateTimeKind.Utc).AddTicks(1664));

            migrationBuilder.UpdateData(
                table: "ProductOptions",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 7, 16, 2, 17, 736, DateTimeKind.Utc).AddTicks(1666));

            migrationBuilder.UpdateData(
                table: "ProductOptions",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 7, 16, 2, 17, 736, DateTimeKind.Utc).AddTicks(1668));

            migrationBuilder.UpdateData(
                table: "ProductOptions",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 7, 16, 2, 17, 736, DateTimeKind.Utc).AddTicks(1670));

            migrationBuilder.UpdateData(
                table: "ProductOptions",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 7, 16, 2, 17, 736, DateTimeKind.Utc).AddTicks(1672));

            migrationBuilder.UpdateData(
                table: "ProductOptions",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 7, 16, 2, 17, 736, DateTimeKind.Utc).AddTicks(1674));

            migrationBuilder.UpdateData(
                table: "ProductOptions",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 7, 16, 2, 17, 736, DateTimeKind.Utc).AddTicks(1676));

            migrationBuilder.UpdateData(
                table: "ProductOptions",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 7, 16, 2, 17, 736, DateTimeKind.Utc).AddTicks(1678));

            migrationBuilder.UpdateData(
                table: "ProductOptions",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 7, 16, 2, 17, 736, DateTimeKind.Utc).AddTicks(1685));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 7, 16, 2, 17, 734, DateTimeKind.Utc).AddTicks(5438));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 7, 16, 2, 17, 734, DateTimeKind.Utc).AddTicks(5443));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 7, 16, 2, 17, 734, DateTimeKind.Utc).AddTicks(5446));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 7, 16, 2, 17, 734, DateTimeKind.Utc).AddTicks(5450));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 7, 16, 2, 17, 734, DateTimeKind.Utc).AddTicks(5453));

            migrationBuilder.UpdateData(
                table: "Trademarks",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 7, 16, 2, 17, 737, DateTimeKind.Utc).AddTicks(8012));

            migrationBuilder.UpdateData(
                table: "Trademarks",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 7, 16, 2, 17, 737, DateTimeKind.Utc).AddTicks(8016));

            migrationBuilder.UpdateData(
                table: "Trademarks",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 7, 16, 2, 17, 737, DateTimeKind.Utc).AddTicks(8018));

            migrationBuilder.UpdateData(
                table: "Trademarks",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 7, 16, 2, 17, 737, DateTimeKind.Utc).AddTicks(8021));

            migrationBuilder.UpdateData(
                table: "Trademarks",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 7, 16, 2, 17, 737, DateTimeKind.Utc).AddTicks(8023));

            migrationBuilder.UpdateData(
                table: "Variants",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 7, 16, 2, 17, 740, DateTimeKind.Utc).AddTicks(1978));

            migrationBuilder.UpdateData(
                table: "Variants",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 7, 16, 2, 17, 740, DateTimeKind.Utc).AddTicks(1984));

            migrationBuilder.UpdateData(
                table: "Variants",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 7, 16, 2, 17, 740, DateTimeKind.Utc).AddTicks(1987));

            migrationBuilder.UpdateData(
                table: "Variants",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 7, 16, 2, 17, 740, DateTimeKind.Utc).AddTicks(1989));

            migrationBuilder.UpdateData(
                table: "Variants",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 7, 16, 2, 17, 740, DateTimeKind.Utc).AddTicks(1991));

            migrationBuilder.UpdateData(
                table: "Variants",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 7, 16, 2, 17, 740, DateTimeKind.Utc).AddTicks(1993));

            migrationBuilder.UpdateData(
                table: "Variants",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 7, 16, 2, 17, 740, DateTimeKind.Utc).AddTicks(1995));

            migrationBuilder.UpdateData(
                table: "Variants",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 7, 16, 2, 17, 740, DateTimeKind.Utc).AddTicks(2023));

            migrationBuilder.UpdateData(
                table: "Variants",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 7, 16, 2, 17, 740, DateTimeKind.Utc).AddTicks(2025));
        }
    }
}
