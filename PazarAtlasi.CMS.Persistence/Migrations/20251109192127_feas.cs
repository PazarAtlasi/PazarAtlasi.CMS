using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PazarAtlasi.CMS.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class feas : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "TotalCost",
                table: "AgentSubscriptions",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<string>(
                name: "Features",
                table: "AgentPricings",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "AgentCapabilities",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "AgentCapabilities",
                keyColumn: "Id",
                keyValue: 1,
                column: "IsActive",
                value: true);

            migrationBuilder.UpdateData(
                table: "AgentCapabilities",
                keyColumn: "Id",
                keyValue: 2,
                column: "IsActive",
                value: true);

            migrationBuilder.UpdateData(
                table: "AgentCapabilities",
                keyColumn: "Id",
                keyValue: 3,
                column: "IsActive",
                value: true);

            migrationBuilder.UpdateData(
                table: "AgentCapabilities",
                keyColumn: "Id",
                keyValue: 4,
                column: "IsActive",
                value: true);

            migrationBuilder.UpdateData(
                table: "AgentCapabilities",
                keyColumn: "Id",
                keyValue: 5,
                column: "IsActive",
                value: true);

            migrationBuilder.UpdateData(
                table: "AgentCapabilities",
                keyColumn: "Id",
                keyValue: 6,
                column: "IsActive",
                value: true);

            migrationBuilder.UpdateData(
                table: "AgentCapabilities",
                keyColumn: "Id",
                keyValue: 7,
                column: "IsActive",
                value: true);

            migrationBuilder.UpdateData(
                table: "AgentCapabilities",
                keyColumn: "Id",
                keyValue: 8,
                column: "IsActive",
                value: true);

            migrationBuilder.UpdateData(
                table: "AgentCapabilities",
                keyColumn: "Id",
                keyValue: 9,
                column: "IsActive",
                value: true);

            migrationBuilder.UpdateData(
                table: "AgentPricings",
                keyColumn: "Id",
                keyValue: 1,
                column: "Features",
                value: null);

            migrationBuilder.UpdateData(
                table: "AgentPricings",
                keyColumn: "Id",
                keyValue: 2,
                column: "Features",
                value: null);

            migrationBuilder.UpdateData(
                table: "AgentPricings",
                keyColumn: "Id",
                keyValue: 3,
                column: "Features",
                value: null);

            migrationBuilder.UpdateData(
                table: "AgentPricings",
                keyColumn: "Id",
                keyValue: 4,
                column: "Features",
                value: null);

            migrationBuilder.UpdateData(
                table: "AgentPricings",
                keyColumn: "Id",
                keyValue: 5,
                column: "Features",
                value: null);

            migrationBuilder.UpdateData(
                table: "DataSchemaFields",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 19, 21, 21, 871, DateTimeKind.Utc).AddTicks(1344));

            migrationBuilder.UpdateData(
                table: "DataSchemaFields",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 19, 21, 21, 871, DateTimeKind.Utc).AddTicks(1349));

            migrationBuilder.UpdateData(
                table: "DataSchemaFields",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 19, 21, 21, 871, DateTimeKind.Utc).AddTicks(1352));

            migrationBuilder.UpdateData(
                table: "DataSchemaFields",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 19, 21, 21, 871, DateTimeKind.Utc).AddTicks(1355));

            migrationBuilder.UpdateData(
                table: "DataSchemaFields",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 19, 21, 21, 871, DateTimeKind.Utc).AddTicks(1358));

            migrationBuilder.UpdateData(
                table: "DataSchemaFields",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 19, 21, 21, 871, DateTimeKind.Utc).AddTicks(1361));

            migrationBuilder.UpdateData(
                table: "DataSchemas",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 19, 21, 21, 869, DateTimeKind.Utc).AddTicks(5356));

            migrationBuilder.UpdateData(
                table: "DataSchemas",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 19, 21, 21, 869, DateTimeKind.Utc).AddTicks(5360));

            migrationBuilder.UpdateData(
                table: "DataSchemas",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 19, 21, 21, 869, DateTimeKind.Utc).AddTicks(5363));

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 19, 21, 21, 864, DateTimeKind.Utc).AddTicks(7841));

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 19, 21, 21, 864, DateTimeKind.Utc).AddTicks(7845));

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 19, 21, 21, 864, DateTimeKind.Utc).AddTicks(7848));

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 19, 21, 21, 864, DateTimeKind.Utc).AddTicks(7850));

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 19, 21, 21, 864, DateTimeKind.Utc).AddTicks(7852));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 19, 21, 21, 865, DateTimeKind.Utc).AddTicks(4629));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 19, 21, 21, 865, DateTimeKind.Utc).AddTicks(4634));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 19, 21, 21, 865, DateTimeKind.Utc).AddTicks(4636));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 19, 21, 21, 865, DateTimeKind.Utc).AddTicks(4637));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 19, 21, 21, 865, DateTimeKind.Utc).AddTicks(4638));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 19, 21, 21, 865, DateTimeKind.Utc).AddTicks(4640));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 19, 21, 21, 865, DateTimeKind.Utc).AddTicks(4641));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 19, 21, 21, 865, DateTimeKind.Utc).AddTicks(4642));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 19, 21, 21, 865, DateTimeKind.Utc).AddTicks(4643));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 19, 21, 21, 865, DateTimeKind.Utc).AddTicks(4645));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 19, 21, 21, 865, DateTimeKind.Utc).AddTicks(4645));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 19, 21, 21, 865, DateTimeKind.Utc).AddTicks(4646));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 19, 21, 21, 865, DateTimeKind.Utc).AddTicks(4647));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 19, 21, 21, 865, DateTimeKind.Utc).AddTicks(4648));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 19, 21, 21, 865, DateTimeKind.Utc).AddTicks(4649));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 16,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 19, 21, 21, 865, DateTimeKind.Utc).AddTicks(4655));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 17,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 19, 21, 21, 865, DateTimeKind.Utc).AddTicks(4656));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 18,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 19, 21, 21, 865, DateTimeKind.Utc).AddTicks(4657));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 19,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 19, 21, 21, 865, DateTimeKind.Utc).AddTicks(4658));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 20,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 19, 21, 21, 865, DateTimeKind.Utc).AddTicks(4659));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 21,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 19, 21, 21, 865, DateTimeKind.Utc).AddTicks(4661));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 22,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 19, 21, 21, 865, DateTimeKind.Utc).AddTicks(4662));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 23,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 19, 21, 21, 865, DateTimeKind.Utc).AddTicks(4663));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 24,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 19, 21, 21, 865, DateTimeKind.Utc).AddTicks(4664));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 25,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 19, 21, 21, 865, DateTimeKind.Utc).AddTicks(4665));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 26,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 19, 21, 21, 865, DateTimeKind.Utc).AddTicks(4665));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 27,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 19, 21, 21, 865, DateTimeKind.Utc).AddTicks(4666));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 28,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 19, 21, 21, 865, DateTimeKind.Utc).AddTicks(4667));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 29,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 19, 21, 21, 865, DateTimeKind.Utc).AddTicks(4668));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 30,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 19, 21, 21, 865, DateTimeKind.Utc).AddTicks(4685));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 31,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 19, 21, 21, 865, DateTimeKind.Utc).AddTicks(4686));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 32,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 19, 21, 21, 865, DateTimeKind.Utc).AddTicks(4687));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 33,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 19, 21, 21, 865, DateTimeKind.Utc).AddTicks(4688));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 34,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 19, 21, 21, 865, DateTimeKind.Utc).AddTicks(4690));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 35,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 19, 21, 21, 865, DateTimeKind.Utc).AddTicks(4691));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 36,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 19, 21, 21, 865, DateTimeKind.Utc).AddTicks(4691));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 37,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 19, 21, 21, 865, DateTimeKind.Utc).AddTicks(4692));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 38,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 19, 21, 21, 865, DateTimeKind.Utc).AddTicks(4693));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 39,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 19, 21, 21, 865, DateTimeKind.Utc).AddTicks(4697));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 40,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 19, 21, 21, 865, DateTimeKind.Utc).AddTicks(4698));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 41,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 19, 21, 21, 865, DateTimeKind.Utc).AddTicks(4700));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 42,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 19, 21, 21, 865, DateTimeKind.Utc).AddTicks(4701));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 43,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 19, 21, 21, 865, DateTimeKind.Utc).AddTicks(4701));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 44,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 19, 21, 21, 865, DateTimeKind.Utc).AddTicks(4702));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 45,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 19, 21, 21, 865, DateTimeKind.Utc).AddTicks(4703));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 46,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 19, 21, 21, 865, DateTimeKind.Utc).AddTicks(4704));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 47,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 19, 21, 21, 865, DateTimeKind.Utc).AddTicks(4705));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 48,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 19, 21, 21, 865, DateTimeKind.Utc).AddTicks(4706));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 49,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 19, 21, 21, 865, DateTimeKind.Utc).AddTicks(4707));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 50,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 19, 21, 21, 865, DateTimeKind.Utc).AddTicks(4708));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 51,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 19, 21, 21, 865, DateTimeKind.Utc).AddTicks(4708));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 52,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 19, 21, 21, 865, DateTimeKind.Utc).AddTicks(4709));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 53,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 19, 21, 21, 865, DateTimeKind.Utc).AddTicks(4710));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 54,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 19, 21, 21, 865, DateTimeKind.Utc).AddTicks(4712));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 55,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 19, 21, 21, 865, DateTimeKind.Utc).AddTicks(4714));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 56,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 19, 21, 21, 865, DateTimeKind.Utc).AddTicks(4714));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 57,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 19, 21, 21, 865, DateTimeKind.Utc).AddTicks(4715));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 58,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 19, 21, 21, 865, DateTimeKind.Utc).AddTicks(4716));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 59,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 19, 21, 21, 865, DateTimeKind.Utc).AddTicks(4717));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 60,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 19, 21, 21, 865, DateTimeKind.Utc).AddTicks(4718));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 61,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 19, 21, 21, 865, DateTimeKind.Utc).AddTicks(4719));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 62,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 19, 21, 21, 865, DateTimeKind.Utc).AddTicks(4719));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 63,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 19, 21, 21, 865, DateTimeKind.Utc).AddTicks(4720));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 64,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 19, 21, 21, 865, DateTimeKind.Utc).AddTicks(4721));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 65,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 19, 21, 21, 865, DateTimeKind.Utc).AddTicks(4726));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 66,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 19, 21, 21, 865, DateTimeKind.Utc).AddTicks(4727));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 67,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 19, 21, 21, 865, DateTimeKind.Utc).AddTicks(4728));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 68,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 19, 21, 21, 865, DateTimeKind.Utc).AddTicks(4729));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 69,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 19, 21, 21, 865, DateTimeKind.Utc).AddTicks(4730));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 70,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 19, 21, 21, 865, DateTimeKind.Utc).AddTicks(4733));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 71,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 19, 21, 21, 865, DateTimeKind.Utc).AddTicks(4735));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 72,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 19, 21, 21, 865, DateTimeKind.Utc).AddTicks(4736));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 73,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 19, 21, 21, 865, DateTimeKind.Utc).AddTicks(4736));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 74,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 19, 21, 21, 865, DateTimeKind.Utc).AddTicks(4737));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 75,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 19, 21, 21, 865, DateTimeKind.Utc).AddTicks(4738));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 76,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 19, 21, 21, 865, DateTimeKind.Utc).AddTicks(4739));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 77,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 19, 21, 21, 865, DateTimeKind.Utc).AddTicks(4739));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 78,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 19, 21, 21, 865, DateTimeKind.Utc).AddTicks(4740));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 79,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 19, 21, 21, 865, DateTimeKind.Utc).AddTicks(4741));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 80,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 19, 21, 21, 865, DateTimeKind.Utc).AddTicks(4744));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 81,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 19, 21, 21, 865, DateTimeKind.Utc).AddTicks(4745));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 82,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 19, 21, 21, 865, DateTimeKind.Utc).AddTicks(4746));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 83,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 19, 21, 21, 865, DateTimeKind.Utc).AddTicks(4746));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 84,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 19, 21, 21, 865, DateTimeKind.Utc).AddTicks(4747));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 85,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 19, 21, 21, 865, DateTimeKind.Utc).AddTicks(4748));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 86,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 19, 21, 21, 865, DateTimeKind.Utc).AddTicks(4749));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 87,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 19, 21, 21, 865, DateTimeKind.Utc).AddTicks(4750));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 88,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 19, 21, 21, 865, DateTimeKind.Utc).AddTicks(4751));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 89,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 19, 21, 21, 865, DateTimeKind.Utc).AddTicks(4752));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 90,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 19, 21, 21, 865, DateTimeKind.Utc).AddTicks(4753));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 91,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 19, 21, 21, 865, DateTimeKind.Utc).AddTicks(4754));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 92,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 19, 21, 21, 865, DateTimeKind.Utc).AddTicks(4754));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 93,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 19, 21, 21, 865, DateTimeKind.Utc).AddTicks(4755));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 94,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 19, 21, 21, 865, DateTimeKind.Utc).AddTicks(4756));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 95,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 19, 21, 21, 865, DateTimeKind.Utc).AddTicks(4757));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 96,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 19, 21, 21, 865, DateTimeKind.Utc).AddTicks(4762));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 97,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 19, 21, 21, 865, DateTimeKind.Utc).AddTicks(4763));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 98,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 19, 21, 21, 865, DateTimeKind.Utc).AddTicks(4764));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 99,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 19, 21, 21, 865, DateTimeKind.Utc).AddTicks(4765));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 100,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 19, 21, 21, 865, DateTimeKind.Utc).AddTicks(4766));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 101,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 19, 21, 21, 865, DateTimeKind.Utc).AddTicks(4767));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 102,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 19, 21, 21, 865, DateTimeKind.Utc).AddTicks(4768));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 103,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 19, 21, 21, 865, DateTimeKind.Utc).AddTicks(4768));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 104,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 19, 21, 21, 865, DateTimeKind.Utc).AddTicks(4769));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 105,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 19, 21, 21, 865, DateTimeKind.Utc).AddTicks(4770));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 106,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 19, 21, 21, 865, DateTimeKind.Utc).AddTicks(4771));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 107,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 19, 21, 21, 865, DateTimeKind.Utc).AddTicks(4772));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 108,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 19, 21, 21, 865, DateTimeKind.Utc).AddTicks(4772));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 109,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 19, 21, 21, 865, DateTimeKind.Utc).AddTicks(4775));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 110,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 19, 21, 21, 865, DateTimeKind.Utc).AddTicks(4776));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 111,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 19, 21, 21, 865, DateTimeKind.Utc).AddTicks(4779));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 112,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 19, 21, 21, 865, DateTimeKind.Utc).AddTicks(4780));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 113,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 19, 21, 21, 865, DateTimeKind.Utc).AddTicks(4781));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 114,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 19, 21, 21, 865, DateTimeKind.Utc).AddTicks(4782));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 115,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 19, 21, 21, 865, DateTimeKind.Utc).AddTicks(4783));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 116,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 19, 21, 21, 865, DateTimeKind.Utc).AddTicks(4784));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 117,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 19, 21, 21, 865, DateTimeKind.Utc).AddTicks(4785));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 118,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 19, 21, 21, 865, DateTimeKind.Utc).AddTicks(4786));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 119,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 19, 21, 21, 865, DateTimeKind.Utc).AddTicks(4787));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 120,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 19, 21, 21, 865, DateTimeKind.Utc).AddTicks(4787));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 121,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 19, 21, 21, 865, DateTimeKind.Utc).AddTicks(4788));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 122,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 19, 21, 21, 865, DateTimeKind.Utc).AddTicks(4789));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 123,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 19, 21, 21, 865, DateTimeKind.Utc).AddTicks(4790));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 124,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 19, 21, 21, 865, DateTimeKind.Utc).AddTicks(4791));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 125,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 19, 21, 21, 865, DateTimeKind.Utc).AddTicks(4792));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 126,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 19, 21, 21, 865, DateTimeKind.Utc).AddTicks(4793));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 127,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 19, 21, 21, 865, DateTimeKind.Utc).AddTicks(4793));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 128,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 19, 21, 21, 865, DateTimeKind.Utc).AddTicks(4794));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 129,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 19, 21, 21, 865, DateTimeKind.Utc).AddTicks(4795));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 130,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 19, 21, 21, 865, DateTimeKind.Utc).AddTicks(4806));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 131,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 19, 21, 21, 865, DateTimeKind.Utc).AddTicks(4807));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 132,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 19, 21, 21, 865, DateTimeKind.Utc).AddTicks(4808));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 133,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 19, 21, 21, 865, DateTimeKind.Utc).AddTicks(4809));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 134,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 19, 21, 21, 865, DateTimeKind.Utc).AddTicks(4809));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 135,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 19, 21, 21, 865, DateTimeKind.Utc).AddTicks(4810));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 136,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 19, 21, 21, 865, DateTimeKind.Utc).AddTicks(4811));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 137,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 19, 21, 21, 865, DateTimeKind.Utc).AddTicks(4812));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 138,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 19, 21, 21, 865, DateTimeKind.Utc).AddTicks(4813));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 139,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 19, 21, 21, 865, DateTimeKind.Utc).AddTicks(4815));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 140,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 19, 21, 21, 865, DateTimeKind.Utc).AddTicks(4817));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 141,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 19, 21, 21, 865, DateTimeKind.Utc).AddTicks(4817));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 142,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 19, 21, 21, 865, DateTimeKind.Utc).AddTicks(4818));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 143,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 19, 21, 21, 865, DateTimeKind.Utc).AddTicks(4819));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 144,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 19, 21, 21, 865, DateTimeKind.Utc).AddTicks(4820));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 145,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 19, 21, 21, 865, DateTimeKind.Utc).AddTicks(4821));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 146,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 19, 21, 21, 865, DateTimeKind.Utc).AddTicks(4822));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 147,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 19, 21, 21, 865, DateTimeKind.Utc).AddTicks(4823));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 148,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 19, 21, 21, 865, DateTimeKind.Utc).AddTicks(4824));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 149,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 19, 21, 21, 865, DateTimeKind.Utc).AddTicks(4825));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 150,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 19, 21, 21, 865, DateTimeKind.Utc).AddTicks(4826));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 151,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 19, 21, 21, 865, DateTimeKind.Utc).AddTicks(4826));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 152,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 19, 21, 21, 865, DateTimeKind.Utc).AddTicks(4827));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 153,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 19, 21, 21, 865, DateTimeKind.Utc).AddTicks(4828));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 154,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 19, 21, 21, 865, DateTimeKind.Utc).AddTicks(4829));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 155,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 19, 21, 21, 865, DateTimeKind.Utc).AddTicks(4830));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 156,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 19, 21, 21, 865, DateTimeKind.Utc).AddTicks(4831));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 157,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 19, 21, 21, 865, DateTimeKind.Utc).AddTicks(4837));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 158,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 19, 21, 21, 865, DateTimeKind.Utc).AddTicks(4838));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 159,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 19, 21, 21, 865, DateTimeKind.Utc).AddTicks(4839));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 160,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 19, 21, 21, 865, DateTimeKind.Utc).AddTicks(4840));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 161,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 19, 21, 21, 865, DateTimeKind.Utc).AddTicks(4841));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 162,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 19, 21, 21, 865, DateTimeKind.Utc).AddTicks(4842));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 163,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 19, 21, 21, 865, DateTimeKind.Utc).AddTicks(4843));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 164,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 19, 21, 21, 865, DateTimeKind.Utc).AddTicks(4845));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 165,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 19, 21, 21, 865, DateTimeKind.Utc).AddTicks(4846));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 166,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 19, 21, 21, 865, DateTimeKind.Utc).AddTicks(4847));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 167,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 19, 21, 21, 865, DateTimeKind.Utc).AddTicks(4848));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 168,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 19, 21, 21, 865, DateTimeKind.Utc).AddTicks(4849));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 169,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 19, 21, 21, 865, DateTimeKind.Utc).AddTicks(4850));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 170,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 19, 21, 21, 865, DateTimeKind.Utc).AddTicks(4850));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 171,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 19, 21, 21, 865, DateTimeKind.Utc).AddTicks(4851));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 172,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 19, 21, 21, 865, DateTimeKind.Utc).AddTicks(4852));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 173,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 19, 21, 21, 865, DateTimeKind.Utc).AddTicks(4853));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 174,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 19, 21, 21, 865, DateTimeKind.Utc).AddTicks(4853));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 175,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 19, 21, 21, 865, DateTimeKind.Utc).AddTicks(4854));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 176,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 19, 21, 21, 865, DateTimeKind.Utc).AddTicks(4855));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 177,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 19, 21, 21, 865, DateTimeKind.Utc).AddTicks(4856));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 178,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 19, 21, 21, 865, DateTimeKind.Utc).AddTicks(4857));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 179,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 19, 21, 21, 865, DateTimeKind.Utc).AddTicks(4857));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 180,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 19, 21, 21, 865, DateTimeKind.Utc).AddTicks(4858));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 181,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 19, 21, 21, 865, DateTimeKind.Utc).AddTicks(4859));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 182,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 19, 21, 21, 865, DateTimeKind.Utc).AddTicks(4860));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 183,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 19, 21, 21, 865, DateTimeKind.Utc).AddTicks(4860));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 184,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 19, 21, 21, 865, DateTimeKind.Utc).AddTicks(4861));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 185,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 19, 21, 21, 865, DateTimeKind.Utc).AddTicks(4862));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 186,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 19, 21, 21, 865, DateTimeKind.Utc).AddTicks(4863));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 187,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 19, 21, 21, 865, DateTimeKind.Utc).AddTicks(4863));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 188,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 19, 21, 21, 865, DateTimeKind.Utc).AddTicks(4864));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 189,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 19, 21, 21, 865, DateTimeKind.Utc).AddTicks(4865));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 190,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 19, 21, 21, 865, DateTimeKind.Utc).AddTicks(4866));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 191,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 19, 21, 21, 865, DateTimeKind.Utc).AddTicks(4866));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 192,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 19, 21, 21, 865, DateTimeKind.Utc).AddTicks(4867));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 193,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 19, 21, 21, 865, DateTimeKind.Utc).AddTicks(4868));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 194,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 19, 21, 21, 865, DateTimeKind.Utc).AddTicks(4873));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 195,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 19, 21, 21, 865, DateTimeKind.Utc).AddTicks(4874));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 196,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 19, 21, 21, 865, DateTimeKind.Utc).AddTicks(4875));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 197,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 19, 21, 21, 865, DateTimeKind.Utc).AddTicks(4876));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 198,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 19, 21, 21, 865, DateTimeKind.Utc).AddTicks(4877));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 199,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 19, 21, 21, 865, DateTimeKind.Utc).AddTicks(4878));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 200,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 19, 21, 21, 865, DateTimeKind.Utc).AddTicks(4878));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 201,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 19, 21, 21, 865, DateTimeKind.Utc).AddTicks(4879));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 202,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 19, 21, 21, 865, DateTimeKind.Utc).AddTicks(4882));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 203,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 19, 21, 21, 865, DateTimeKind.Utc).AddTicks(4883));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 204,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 19, 21, 21, 865, DateTimeKind.Utc).AddTicks(4884));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 205,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 19, 21, 21, 865, DateTimeKind.Utc).AddTicks(4885));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 206,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 19, 21, 21, 865, DateTimeKind.Utc).AddTicks(4886));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 207,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 19, 21, 21, 865, DateTimeKind.Utc).AddTicks(4887));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 208,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 19, 21, 21, 865, DateTimeKind.Utc).AddTicks(4887));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 209,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 19, 21, 21, 865, DateTimeKind.Utc).AddTicks(4888));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 210,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 19, 21, 21, 865, DateTimeKind.Utc).AddTicks(4889));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 211,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 19, 21, 21, 865, DateTimeKind.Utc).AddTicks(4890));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 212,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 19, 21, 21, 865, DateTimeKind.Utc).AddTicks(4891));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 213,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 19, 21, 21, 865, DateTimeKind.Utc).AddTicks(4892));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 214,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 19, 21, 21, 865, DateTimeKind.Utc).AddTicks(4892));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 215,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 19, 21, 21, 865, DateTimeKind.Utc).AddTicks(4893));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 216,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 19, 21, 21, 865, DateTimeKind.Utc).AddTicks(4894));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 217,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 19, 21, 21, 865, DateTimeKind.Utc).AddTicks(4897));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 218,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 19, 21, 21, 865, DateTimeKind.Utc).AddTicks(4898));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 219,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 19, 21, 21, 865, DateTimeKind.Utc).AddTicks(4899));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 220,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 19, 21, 21, 865, DateTimeKind.Utc).AddTicks(4899));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 221,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 19, 21, 21, 865, DateTimeKind.Utc).AddTicks(4900));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 222,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 19, 21, 21, 865, DateTimeKind.Utc).AddTicks(4901));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 223,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 19, 21, 21, 865, DateTimeKind.Utc).AddTicks(4902));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 224,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 19, 21, 21, 865, DateTimeKind.Utc).AddTicks(4903));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 225,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 19, 21, 21, 865, DateTimeKind.Utc).AddTicks(4904));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 226,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 19, 21, 21, 865, DateTimeKind.Utc).AddTicks(4905));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 227,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 19, 21, 21, 865, DateTimeKind.Utc).AddTicks(4906));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 228,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 19, 21, 21, 865, DateTimeKind.Utc).AddTicks(4907));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 229,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 19, 21, 21, 865, DateTimeKind.Utc).AddTicks(4907));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 230,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 19, 21, 21, 865, DateTimeKind.Utc).AddTicks(4908));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 231,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 19, 21, 21, 865, DateTimeKind.Utc).AddTicks(4913));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 232,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 19, 21, 21, 865, DateTimeKind.Utc).AddTicks(4914));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 233,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 19, 21, 21, 865, DateTimeKind.Utc).AddTicks(4917));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 234,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 19, 21, 21, 865, DateTimeKind.Utc).AddTicks(4918));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 235,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 19, 21, 21, 865, DateTimeKind.Utc).AddTicks(4919));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 236,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 19, 21, 21, 865, DateTimeKind.Utc).AddTicks(4920));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 237,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 19, 21, 21, 865, DateTimeKind.Utc).AddTicks(4921));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 238,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 19, 21, 21, 865, DateTimeKind.Utc).AddTicks(4922));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 239,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 19, 21, 21, 865, DateTimeKind.Utc).AddTicks(4923));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 240,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 19, 21, 21, 865, DateTimeKind.Utc).AddTicks(4923));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 241,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 19, 21, 21, 865, DateTimeKind.Utc).AddTicks(4924));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 242,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 19, 21, 21, 865, DateTimeKind.Utc).AddTicks(4925));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 243,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 19, 21, 21, 865, DateTimeKind.Utc).AddTicks(4928));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 244,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 19, 21, 21, 865, DateTimeKind.Utc).AddTicks(4929));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 245,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 19, 21, 21, 865, DateTimeKind.Utc).AddTicks(4930));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 246,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 19, 21, 21, 865, DateTimeKind.Utc).AddTicks(4931));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 247,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 19, 21, 21, 865, DateTimeKind.Utc).AddTicks(4931));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 248,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 19, 21, 21, 865, DateTimeKind.Utc).AddTicks(4932));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 249,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 19, 21, 21, 865, DateTimeKind.Utc).AddTicks(4933));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 250,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 19, 21, 21, 865, DateTimeKind.Utc).AddTicks(4934));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 251,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 19, 21, 21, 865, DateTimeKind.Utc).AddTicks(4935));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 252,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 19, 21, 21, 865, DateTimeKind.Utc).AddTicks(4935));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 253,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 19, 21, 21, 865, DateTimeKind.Utc).AddTicks(4936));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 254,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 19, 21, 21, 865, DateTimeKind.Utc).AddTicks(4937));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 255,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 19, 21, 21, 865, DateTimeKind.Utc).AddTicks(4938));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 256,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 19, 21, 21, 865, DateTimeKind.Utc).AddTicks(4939));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 257,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 19, 21, 21, 865, DateTimeKind.Utc).AddTicks(4939));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 258,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 19, 21, 21, 865, DateTimeKind.Utc).AddTicks(4947));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 259,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 19, 21, 21, 865, DateTimeKind.Utc).AddTicks(4948));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 260,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 19, 21, 21, 865, DateTimeKind.Utc).AddTicks(4949));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 261,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 19, 21, 21, 865, DateTimeKind.Utc).AddTicks(4950));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 262,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 19, 21, 21, 865, DateTimeKind.Utc).AddTicks(4951));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 263,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 19, 21, 21, 865, DateTimeKind.Utc).AddTicks(4951));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 264,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 19, 21, 21, 865, DateTimeKind.Utc).AddTicks(4952));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 265,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 19, 21, 21, 865, DateTimeKind.Utc).AddTicks(4953));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 266,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 19, 21, 21, 865, DateTimeKind.Utc).AddTicks(4954));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 267,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 19, 21, 21, 865, DateTimeKind.Utc).AddTicks(4954));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 268,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 19, 21, 21, 865, DateTimeKind.Utc).AddTicks(4955));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 269,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 19, 21, 21, 865, DateTimeKind.Utc).AddTicks(4956));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 270,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 19, 21, 21, 865, DateTimeKind.Utc).AddTicks(4957));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 271,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 19, 21, 21, 865, DateTimeKind.Utc).AddTicks(4958));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 272,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 19, 21, 21, 865, DateTimeKind.Utc).AddTicks(4960));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 273,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 19, 21, 21, 865, DateTimeKind.Utc).AddTicks(4962));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 274,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 19, 21, 21, 865, DateTimeKind.Utc).AddTicks(4964));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 275,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 19, 21, 21, 865, DateTimeKind.Utc).AddTicks(4965));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 276,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 19, 21, 21, 865, DateTimeKind.Utc).AddTicks(4966));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 277,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 19, 21, 21, 865, DateTimeKind.Utc).AddTicks(4967));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 278,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 19, 21, 21, 865, DateTimeKind.Utc).AddTicks(4971));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 279,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 19, 21, 21, 865, DateTimeKind.Utc).AddTicks(4972));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 280,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 19, 21, 21, 865, DateTimeKind.Utc).AddTicks(4973));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 281,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 19, 21, 21, 865, DateTimeKind.Utc).AddTicks(4974));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 282,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 19, 21, 21, 865, DateTimeKind.Utc).AddTicks(4976));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 283,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 19, 21, 21, 865, DateTimeKind.Utc).AddTicks(4977));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 284,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 19, 21, 21, 865, DateTimeKind.Utc).AddTicks(4984));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 285,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 19, 21, 21, 865, DateTimeKind.Utc).AddTicks(4986));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 286,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 19, 21, 21, 865, DateTimeKind.Utc).AddTicks(4988));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 287,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 19, 21, 21, 865, DateTimeKind.Utc).AddTicks(4989));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 288,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 19, 21, 21, 865, DateTimeKind.Utc).AddTicks(4990));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 289,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 19, 21, 21, 865, DateTimeKind.Utc).AddTicks(4991));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 290,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 19, 21, 21, 865, DateTimeKind.Utc).AddTicks(4992));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 291,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 19, 21, 21, 865, DateTimeKind.Utc).AddTicks(4994));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 292,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 19, 21, 21, 865, DateTimeKind.Utc).AddTicks(4995));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 293,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 19, 21, 21, 865, DateTimeKind.Utc).AddTicks(4996));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 294,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 19, 21, 21, 865, DateTimeKind.Utc).AddTicks(4998));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 295,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 19, 21, 21, 865, DateTimeKind.Utc).AddTicks(4999));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 296,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 19, 21, 21, 865, DateTimeKind.Utc).AddTicks(5000));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 297,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 19, 21, 21, 865, DateTimeKind.Utc).AddTicks(5001));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 298,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 19, 21, 21, 865, DateTimeKind.Utc).AddTicks(5003));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 299,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 19, 21, 21, 865, DateTimeKind.Utc).AddTicks(5004));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 300,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 19, 21, 21, 865, DateTimeKind.Utc).AddTicks(5005));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 301,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 19, 21, 21, 865, DateTimeKind.Utc).AddTicks(5007));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 302,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 19, 21, 21, 865, DateTimeKind.Utc).AddTicks(5010));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 303,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 19, 21, 21, 865, DateTimeKind.Utc).AddTicks(5012));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 304,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 19, 21, 21, 865, DateTimeKind.Utc).AddTicks(5014));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 305,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 19, 21, 21, 865, DateTimeKind.Utc).AddTicks(5015));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 306,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 19, 21, 21, 865, DateTimeKind.Utc).AddTicks(5016));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 307,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 19, 21, 21, 865, DateTimeKind.Utc).AddTicks(5017));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 308,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 19, 21, 21, 865, DateTimeKind.Utc).AddTicks(5018));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 309,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 19, 21, 21, 865, DateTimeKind.Utc).AddTicks(5020));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 310,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 19, 21, 21, 865, DateTimeKind.Utc).AddTicks(5021));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 311,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 19, 21, 21, 865, DateTimeKind.Utc).AddTicks(5022));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 312,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 19, 21, 21, 865, DateTimeKind.Utc).AddTicks(5024));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 313,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 19, 21, 21, 865, DateTimeKind.Utc).AddTicks(5025));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 314,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 19, 21, 21, 865, DateTimeKind.Utc).AddTicks(5026));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 315,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 19, 21, 21, 865, DateTimeKind.Utc).AddTicks(5028));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 316,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 19, 21, 21, 865, DateTimeKind.Utc).AddTicks(5029));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 317,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 19, 21, 21, 865, DateTimeKind.Utc).AddTicks(5030));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 318,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 19, 21, 21, 865, DateTimeKind.Utc).AddTicks(5031));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 319,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 19, 21, 21, 865, DateTimeKind.Utc).AddTicks(5038));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 320,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 19, 21, 21, 865, DateTimeKind.Utc).AddTicks(5039));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 321,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 19, 21, 21, 865, DateTimeKind.Utc).AddTicks(5040));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 322,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 19, 21, 21, 865, DateTimeKind.Utc).AddTicks(5042));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 323,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 19, 21, 21, 865, DateTimeKind.Utc).AddTicks(5043));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 324,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 19, 21, 21, 865, DateTimeKind.Utc).AddTicks(5044));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 325,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 19, 21, 21, 865, DateTimeKind.Utc).AddTicks(5045));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 326,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 19, 21, 21, 865, DateTimeKind.Utc).AddTicks(5047));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 327,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 19, 21, 21, 865, DateTimeKind.Utc).AddTicks(5100));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 328,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 19, 21, 21, 865, DateTimeKind.Utc).AddTicks(5102));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 329,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 19, 21, 21, 865, DateTimeKind.Utc).AddTicks(5103));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 330,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 19, 21, 21, 865, DateTimeKind.Utc).AddTicks(5105));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 331,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 19, 21, 21, 865, DateTimeKind.Utc).AddTicks(5106));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 332,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 19, 21, 21, 865, DateTimeKind.Utc).AddTicks(5107));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 333,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 19, 21, 21, 865, DateTimeKind.Utc).AddTicks(5108));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 334,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 19, 21, 21, 865, DateTimeKind.Utc).AddTicks(5109));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 335,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 19, 21, 21, 865, DateTimeKind.Utc).AddTicks(5110));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 336,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 19, 21, 21, 865, DateTimeKind.Utc).AddTicks(5117));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 337,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 19, 21, 21, 865, DateTimeKind.Utc).AddTicks(5119));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 338,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 19, 21, 21, 865, DateTimeKind.Utc).AddTicks(5120));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 339,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 19, 21, 21, 865, DateTimeKind.Utc).AddTicks(5121));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 340,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 19, 21, 21, 865, DateTimeKind.Utc).AddTicks(5122));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 341,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 19, 21, 21, 865, DateTimeKind.Utc).AddTicks(5123));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 342,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 19, 21, 21, 865, DateTimeKind.Utc).AddTicks(5124));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 343,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 19, 21, 21, 865, DateTimeKind.Utc).AddTicks(5125));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 344,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 19, 21, 21, 865, DateTimeKind.Utc).AddTicks(5126));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 345,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 19, 21, 21, 865, DateTimeKind.Utc).AddTicks(5127));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 346,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 19, 21, 21, 865, DateTimeKind.Utc).AddTicks(5128));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 347,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 19, 21, 21, 865, DateTimeKind.Utc).AddTicks(5129));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 348,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 19, 21, 21, 865, DateTimeKind.Utc).AddTicks(5131));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 349,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 19, 21, 21, 865, DateTimeKind.Utc).AddTicks(5132));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 350,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 19, 21, 21, 865, DateTimeKind.Utc).AddTicks(5133));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 351,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 19, 21, 21, 865, DateTimeKind.Utc).AddTicks(5134));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 352,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 19, 21, 21, 865, DateTimeKind.Utc).AddTicks(5135));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 353,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 19, 21, 21, 865, DateTimeKind.Utc).AddTicks(5136));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 354,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 19, 21, 21, 865, DateTimeKind.Utc).AddTicks(5138));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 355,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 19, 21, 21, 865, DateTimeKind.Utc).AddTicks(5139));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 356,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 19, 21, 21, 865, DateTimeKind.Utc).AddTicks(5140));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 357,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 19, 21, 21, 865, DateTimeKind.Utc).AddTicks(5141));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 358,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 19, 21, 21, 865, DateTimeKind.Utc).AddTicks(5142));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 359,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 19, 21, 21, 865, DateTimeKind.Utc).AddTicks(5143));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 360,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 19, 21, 21, 865, DateTimeKind.Utc).AddTicks(5145));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 361,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 19, 21, 21, 865, DateTimeKind.Utc).AddTicks(5148));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 362,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 19, 21, 21, 865, DateTimeKind.Utc).AddTicks(5149));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 363,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 19, 21, 21, 865, DateTimeKind.Utc).AddTicks(5150));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 364,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 19, 21, 21, 865, DateTimeKind.Utc).AddTicks(5151));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 365,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 19, 21, 21, 865, DateTimeKind.Utc).AddTicks(5152));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 366,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 19, 21, 21, 865, DateTimeKind.Utc).AddTicks(5153));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 367,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 19, 21, 21, 865, DateTimeKind.Utc).AddTicks(5155));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 368,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 19, 21, 21, 865, DateTimeKind.Utc).AddTicks(5156));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 369,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 19, 21, 21, 865, DateTimeKind.Utc).AddTicks(5157));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 370,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 19, 21, 21, 865, DateTimeKind.Utc).AddTicks(5158));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 371,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 19, 21, 21, 865, DateTimeKind.Utc).AddTicks(5165));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 372,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 19, 21, 21, 865, DateTimeKind.Utc).AddTicks(5166));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 373,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 19, 21, 21, 865, DateTimeKind.Utc).AddTicks(5168));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 374,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 19, 21, 21, 865, DateTimeKind.Utc).AddTicks(5169));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 375,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 19, 21, 21, 865, DateTimeKind.Utc).AddTicks(5170));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 376,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 19, 21, 21, 865, DateTimeKind.Utc).AddTicks(5171));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 377,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 19, 21, 21, 865, DateTimeKind.Utc).AddTicks(5173));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 378,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 19, 21, 21, 865, DateTimeKind.Utc).AddTicks(5174));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 379,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 19, 21, 21, 865, DateTimeKind.Utc).AddTicks(5175));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 380,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 19, 21, 21, 865, DateTimeKind.Utc).AddTicks(5176));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 381,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 19, 21, 21, 865, DateTimeKind.Utc).AddTicks(5177));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 382,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 19, 21, 21, 865, DateTimeKind.Utc).AddTicks(5178));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 383,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 19, 21, 21, 865, DateTimeKind.Utc).AddTicks(5178));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 384,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 19, 21, 21, 865, DateTimeKind.Utc).AddTicks(5180));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 385,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 19, 21, 21, 865, DateTimeKind.Utc).AddTicks(5181));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 386,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 19, 21, 21, 865, DateTimeKind.Utc).AddTicks(5182));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 387,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 19, 21, 21, 865, DateTimeKind.Utc).AddTicks(5183));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 388,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 19, 21, 21, 865, DateTimeKind.Utc).AddTicks(5184));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 389,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 19, 21, 21, 865, DateTimeKind.Utc).AddTicks(5185));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 390,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 19, 21, 21, 865, DateTimeKind.Utc).AddTicks(5186));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 391,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 19, 21, 21, 865, DateTimeKind.Utc).AddTicks(5187));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 392,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 19, 21, 21, 865, DateTimeKind.Utc).AddTicks(5188));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 393,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 19, 21, 21, 865, DateTimeKind.Utc).AddTicks(5189));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 394,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 19, 21, 21, 865, DateTimeKind.Utc).AddTicks(5191));

            migrationBuilder.UpdateData(
                table: "OptionTranslations",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 19, 21, 21, 876, DateTimeKind.Utc).AddTicks(5734));

            migrationBuilder.UpdateData(
                table: "OptionTranslations",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 19, 21, 21, 876, DateTimeKind.Utc).AddTicks(5737));

            migrationBuilder.UpdateData(
                table: "OptionTranslations",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 19, 21, 21, 876, DateTimeKind.Utc).AddTicks(5738));

            migrationBuilder.UpdateData(
                table: "OptionTranslations",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 19, 21, 21, 876, DateTimeKind.Utc).AddTicks(5740));

            migrationBuilder.UpdateData(
                table: "OptionTranslations",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 19, 21, 21, 876, DateTimeKind.Utc).AddTicks(5741));

            migrationBuilder.UpdateData(
                table: "OptionTranslations",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 19, 21, 21, 876, DateTimeKind.Utc).AddTicks(5743));

            migrationBuilder.UpdateData(
                table: "OptionTranslations",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 19, 21, 21, 876, DateTimeKind.Utc).AddTicks(5744));

            migrationBuilder.UpdateData(
                table: "OptionTranslations",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 19, 21, 21, 876, DateTimeKind.Utc).AddTicks(5746));

            migrationBuilder.UpdateData(
                table: "OptionTranslations",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 19, 21, 21, 876, DateTimeKind.Utc).AddTicks(5747));

            migrationBuilder.UpdateData(
                table: "OptionTranslations",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 19, 21, 21, 876, DateTimeKind.Utc).AddTicks(5749));

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 19, 21, 21, 875, DateTimeKind.Utc).AddTicks(7367));

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 19, 21, 21, 875, DateTimeKind.Utc).AddTicks(7372));

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 19, 21, 21, 875, DateTimeKind.Utc).AddTicks(7374));

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 19, 21, 21, 875, DateTimeKind.Utc).AddTicks(7376));

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 19, 21, 21, 875, DateTimeKind.Utc).AddTicks(7377));

            migrationBuilder.UpdateData(
                table: "ProductOptions",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 19, 21, 21, 880, DateTimeKind.Utc).AddTicks(7412));

            migrationBuilder.UpdateData(
                table: "ProductOptions",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 19, 21, 21, 880, DateTimeKind.Utc).AddTicks(7416));

            migrationBuilder.UpdateData(
                table: "ProductOptions",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 19, 21, 21, 880, DateTimeKind.Utc).AddTicks(7418));

            migrationBuilder.UpdateData(
                table: "ProductOptions",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 19, 21, 21, 880, DateTimeKind.Utc).AddTicks(7423));

            migrationBuilder.UpdateData(
                table: "ProductOptions",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 19, 21, 21, 880, DateTimeKind.Utc).AddTicks(7426));

            migrationBuilder.UpdateData(
                table: "ProductOptions",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 19, 21, 21, 880, DateTimeKind.Utc).AddTicks(7428));

            migrationBuilder.UpdateData(
                table: "ProductOptions",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 19, 21, 21, 880, DateTimeKind.Utc).AddTicks(7431));

            migrationBuilder.UpdateData(
                table: "ProductOptions",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 19, 21, 21, 880, DateTimeKind.Utc).AddTicks(7433));

            migrationBuilder.UpdateData(
                table: "ProductOptions",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 19, 21, 21, 880, DateTimeKind.Utc).AddTicks(7435));

            migrationBuilder.UpdateData(
                table: "ProductOptions",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 19, 21, 21, 880, DateTimeKind.Utc).AddTicks(7437));

            migrationBuilder.UpdateData(
                table: "ProductOptions",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 19, 21, 21, 880, DateTimeKind.Utc).AddTicks(7440));

            migrationBuilder.UpdateData(
                table: "ProductOptions",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 19, 21, 21, 880, DateTimeKind.Utc).AddTicks(7442));

            migrationBuilder.UpdateData(
                table: "ProductOptions",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 19, 21, 21, 880, DateTimeKind.Utc).AddTicks(7444));

            migrationBuilder.UpdateData(
                table: "ProductOptions",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 19, 21, 21, 880, DateTimeKind.Utc).AddTicks(7446));

            migrationBuilder.UpdateData(
                table: "ProductOptions",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 19, 21, 21, 880, DateTimeKind.Utc).AddTicks(7463));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 19, 21, 21, 878, DateTimeKind.Utc).AddTicks(3438));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 19, 21, 21, 878, DateTimeKind.Utc).AddTicks(3444));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 19, 21, 21, 878, DateTimeKind.Utc).AddTicks(3448));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 19, 21, 21, 878, DateTimeKind.Utc).AddTicks(3452));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 19, 21, 21, 878, DateTimeKind.Utc).AddTicks(3455));

            migrationBuilder.UpdateData(
                table: "Trademarks",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 19, 21, 21, 882, DateTimeKind.Utc).AddTicks(5775));

            migrationBuilder.UpdateData(
                table: "Trademarks",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 19, 21, 21, 882, DateTimeKind.Utc).AddTicks(5778));

            migrationBuilder.UpdateData(
                table: "Trademarks",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 19, 21, 21, 882, DateTimeKind.Utc).AddTicks(5780));

            migrationBuilder.UpdateData(
                table: "Trademarks",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 19, 21, 21, 882, DateTimeKind.Utc).AddTicks(5782));

            migrationBuilder.UpdateData(
                table: "Trademarks",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 19, 21, 21, 882, DateTimeKind.Utc).AddTicks(5784));

            migrationBuilder.UpdateData(
                table: "Variants",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 19, 21, 21, 884, DateTimeKind.Utc).AddTicks(9804));

            migrationBuilder.UpdateData(
                table: "Variants",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 19, 21, 21, 884, DateTimeKind.Utc).AddTicks(9808));

            migrationBuilder.UpdateData(
                table: "Variants",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 19, 21, 21, 884, DateTimeKind.Utc).AddTicks(9810));

            migrationBuilder.UpdateData(
                table: "Variants",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 19, 21, 21, 884, DateTimeKind.Utc).AddTicks(9812));

            migrationBuilder.UpdateData(
                table: "Variants",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 19, 21, 21, 884, DateTimeKind.Utc).AddTicks(9814));

            migrationBuilder.UpdateData(
                table: "Variants",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 19, 21, 21, 884, DateTimeKind.Utc).AddTicks(9816));

            migrationBuilder.UpdateData(
                table: "Variants",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 19, 21, 21, 884, DateTimeKind.Utc).AddTicks(9818));

            migrationBuilder.UpdateData(
                table: "Variants",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 19, 21, 21, 884, DateTimeKind.Utc).AddTicks(9819));

            migrationBuilder.UpdateData(
                table: "Variants",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 19, 21, 21, 884, DateTimeKind.Utc).AddTicks(9821));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TotalCost",
                table: "AgentSubscriptions");

            migrationBuilder.DropColumn(
                name: "Features",
                table: "AgentPricings");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "AgentCapabilities");

            migrationBuilder.UpdateData(
                table: "DataSchemaFields",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 30, 52, 618, DateTimeKind.Utc).AddTicks(5439));

            migrationBuilder.UpdateData(
                table: "DataSchemaFields",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 30, 52, 618, DateTimeKind.Utc).AddTicks(5443));

            migrationBuilder.UpdateData(
                table: "DataSchemaFields",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 30, 52, 618, DateTimeKind.Utc).AddTicks(5446));

            migrationBuilder.UpdateData(
                table: "DataSchemaFields",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 30, 52, 618, DateTimeKind.Utc).AddTicks(5449));

            migrationBuilder.UpdateData(
                table: "DataSchemaFields",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 30, 52, 618, DateTimeKind.Utc).AddTicks(5452));

            migrationBuilder.UpdateData(
                table: "DataSchemaFields",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 30, 52, 618, DateTimeKind.Utc).AddTicks(5455));

            migrationBuilder.UpdateData(
                table: "DataSchemas",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 30, 52, 616, DateTimeKind.Utc).AddTicks(7471));

            migrationBuilder.UpdateData(
                table: "DataSchemas",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 30, 52, 616, DateTimeKind.Utc).AddTicks(7474));

            migrationBuilder.UpdateData(
                table: "DataSchemas",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 30, 52, 616, DateTimeKind.Utc).AddTicks(7477));

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 30, 52, 611, DateTimeKind.Utc).AddTicks(996));

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 30, 52, 611, DateTimeKind.Utc).AddTicks(1001));

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 30, 52, 611, DateTimeKind.Utc).AddTicks(1003));

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 30, 52, 611, DateTimeKind.Utc).AddTicks(1005));

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 30, 52, 611, DateTimeKind.Utc).AddTicks(1006));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 30, 52, 611, DateTimeKind.Utc).AddTicks(8528));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 30, 52, 611, DateTimeKind.Utc).AddTicks(8534));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 30, 52, 611, DateTimeKind.Utc).AddTicks(8535));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 30, 52, 611, DateTimeKind.Utc).AddTicks(8536));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 30, 52, 611, DateTimeKind.Utc).AddTicks(8537));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 30, 52, 611, DateTimeKind.Utc).AddTicks(8539));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 30, 52, 611, DateTimeKind.Utc).AddTicks(8540));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 30, 52, 611, DateTimeKind.Utc).AddTicks(8541));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 30, 52, 611, DateTimeKind.Utc).AddTicks(8542));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 30, 52, 611, DateTimeKind.Utc).AddTicks(8544));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 30, 52, 611, DateTimeKind.Utc).AddTicks(8545));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 30, 52, 611, DateTimeKind.Utc).AddTicks(8546));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 30, 52, 611, DateTimeKind.Utc).AddTicks(8547));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 30, 52, 611, DateTimeKind.Utc).AddTicks(8548));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 30, 52, 611, DateTimeKind.Utc).AddTicks(8548));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 16,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 30, 52, 611, DateTimeKind.Utc).AddTicks(8549));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 17,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 30, 52, 611, DateTimeKind.Utc).AddTicks(8550));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 18,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 30, 52, 611, DateTimeKind.Utc).AddTicks(8565));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 19,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 30, 52, 611, DateTimeKind.Utc).AddTicks(8566));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 20,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 30, 52, 611, DateTimeKind.Utc).AddTicks(8567));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 21,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 30, 52, 611, DateTimeKind.Utc).AddTicks(8568));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 22,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 30, 52, 611, DateTimeKind.Utc).AddTicks(8569));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 23,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 30, 52, 611, DateTimeKind.Utc).AddTicks(8570));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 24,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 30, 52, 611, DateTimeKind.Utc).AddTicks(8571));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 25,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 30, 52, 611, DateTimeKind.Utc).AddTicks(8572));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 26,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 30, 52, 611, DateTimeKind.Utc).AddTicks(8572));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 27,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 30, 52, 611, DateTimeKind.Utc).AddTicks(8573));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 28,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 30, 52, 611, DateTimeKind.Utc).AddTicks(8574));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 29,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 30, 52, 611, DateTimeKind.Utc).AddTicks(8575));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 30,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 30, 52, 611, DateTimeKind.Utc).AddTicks(8586));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 31,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 30, 52, 611, DateTimeKind.Utc).AddTicks(8587));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 32,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 30, 52, 611, DateTimeKind.Utc).AddTicks(8588));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 33,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 30, 52, 611, DateTimeKind.Utc).AddTicks(8590));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 34,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 30, 52, 611, DateTimeKind.Utc).AddTicks(8592));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 35,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 30, 52, 611, DateTimeKind.Utc).AddTicks(8592));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 36,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 30, 52, 611, DateTimeKind.Utc).AddTicks(8593));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 37,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 30, 52, 611, DateTimeKind.Utc).AddTicks(8594));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 38,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 30, 52, 611, DateTimeKind.Utc).AddTicks(8595));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 39,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 30, 52, 611, DateTimeKind.Utc).AddTicks(8599));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 40,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 30, 52, 611, DateTimeKind.Utc).AddTicks(8600));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 41,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 30, 52, 611, DateTimeKind.Utc).AddTicks(8601));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 42,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 30, 52, 611, DateTimeKind.Utc).AddTicks(8602));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 43,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 30, 52, 611, DateTimeKind.Utc).AddTicks(8603));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 44,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 30, 52, 611, DateTimeKind.Utc).AddTicks(8604));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 45,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 30, 52, 611, DateTimeKind.Utc).AddTicks(8605));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 46,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 30, 52, 611, DateTimeKind.Utc).AddTicks(8606));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 47,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 30, 52, 611, DateTimeKind.Utc).AddTicks(8607));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 48,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 30, 52, 611, DateTimeKind.Utc).AddTicks(8608));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 49,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 30, 52, 611, DateTimeKind.Utc).AddTicks(8608));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 50,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 30, 52, 611, DateTimeKind.Utc).AddTicks(8610));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 51,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 30, 52, 611, DateTimeKind.Utc).AddTicks(8610));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 52,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 30, 52, 611, DateTimeKind.Utc).AddTicks(8617));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 53,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 30, 52, 611, DateTimeKind.Utc).AddTicks(8618));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 54,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 30, 52, 611, DateTimeKind.Utc).AddTicks(8621));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 55,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 30, 52, 611, DateTimeKind.Utc).AddTicks(8622));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 56,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 30, 52, 611, DateTimeKind.Utc).AddTicks(8623));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 57,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 30, 52, 611, DateTimeKind.Utc).AddTicks(8624));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 58,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 30, 52, 611, DateTimeKind.Utc).AddTicks(8625));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 59,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 30, 52, 611, DateTimeKind.Utc).AddTicks(8625));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 60,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 30, 52, 611, DateTimeKind.Utc).AddTicks(8626));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 61,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 30, 52, 611, DateTimeKind.Utc).AddTicks(8627));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 62,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 30, 52, 611, DateTimeKind.Utc).AddTicks(8628));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 63,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 30, 52, 611, DateTimeKind.Utc).AddTicks(8629));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 64,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 30, 52, 611, DateTimeKind.Utc).AddTicks(8630));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 65,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 30, 52, 611, DateTimeKind.Utc).AddTicks(8631));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 66,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 30, 52, 611, DateTimeKind.Utc).AddTicks(8632));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 67,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 30, 52, 611, DateTimeKind.Utc).AddTicks(8633));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 68,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 30, 52, 611, DateTimeKind.Utc).AddTicks(8634));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 69,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 30, 52, 611, DateTimeKind.Utc).AddTicks(8635));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 70,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 30, 52, 611, DateTimeKind.Utc).AddTicks(8637));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 71,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 30, 52, 611, DateTimeKind.Utc).AddTicks(8639));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 72,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 30, 52, 611, DateTimeKind.Utc).AddTicks(8640));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 73,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 30, 52, 611, DateTimeKind.Utc).AddTicks(8640));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 74,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 30, 52, 611, DateTimeKind.Utc).AddTicks(8642));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 75,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 30, 52, 611, DateTimeKind.Utc).AddTicks(8642));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 76,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 30, 52, 611, DateTimeKind.Utc).AddTicks(8643));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 77,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 30, 52, 611, DateTimeKind.Utc).AddTicks(8644));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 78,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 30, 52, 611, DateTimeKind.Utc).AddTicks(8645));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 79,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 30, 52, 611, DateTimeKind.Utc).AddTicks(8646));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 80,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 30, 52, 611, DateTimeKind.Utc).AddTicks(8648));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 81,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 30, 52, 611, DateTimeKind.Utc).AddTicks(8650));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 82,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 30, 52, 611, DateTimeKind.Utc).AddTicks(8651));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 83,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 30, 52, 611, DateTimeKind.Utc).AddTicks(8652));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 84,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 30, 52, 611, DateTimeKind.Utc).AddTicks(8662));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 85,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 30, 52, 611, DateTimeKind.Utc).AddTicks(8663));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 86,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 30, 52, 611, DateTimeKind.Utc).AddTicks(8663));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 87,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 30, 52, 611, DateTimeKind.Utc).AddTicks(8664));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 88,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 30, 52, 611, DateTimeKind.Utc).AddTicks(8665));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 89,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 30, 52, 611, DateTimeKind.Utc).AddTicks(8666));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 90,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 30, 52, 611, DateTimeKind.Utc).AddTicks(8667));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 91,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 30, 52, 611, DateTimeKind.Utc).AddTicks(8668));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 92,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 30, 52, 611, DateTimeKind.Utc).AddTicks(8669));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 93,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 30, 52, 611, DateTimeKind.Utc).AddTicks(8670));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 94,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 30, 52, 611, DateTimeKind.Utc).AddTicks(8671));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 95,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 30, 52, 611, DateTimeKind.Utc).AddTicks(8672));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 96,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 30, 52, 611, DateTimeKind.Utc).AddTicks(8673));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 97,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 30, 52, 611, DateTimeKind.Utc).AddTicks(8674));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 98,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 30, 52, 611, DateTimeKind.Utc).AddTicks(8674));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 99,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 30, 52, 611, DateTimeKind.Utc).AddTicks(8675));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 100,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 30, 52, 611, DateTimeKind.Utc).AddTicks(8676));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 101,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 30, 52, 611, DateTimeKind.Utc).AddTicks(8677));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 102,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 30, 52, 611, DateTimeKind.Utc).AddTicks(8678));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 103,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 30, 52, 611, DateTimeKind.Utc).AddTicks(8679));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 104,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 30, 52, 611, DateTimeKind.Utc).AddTicks(8679));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 105,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 30, 52, 611, DateTimeKind.Utc).AddTicks(8680));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 106,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 30, 52, 611, DateTimeKind.Utc).AddTicks(8681));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 107,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 30, 52, 611, DateTimeKind.Utc).AddTicks(8682));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 108,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 30, 52, 611, DateTimeKind.Utc).AddTicks(8683));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 109,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 30, 52, 611, DateTimeKind.Utc).AddTicks(8685));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 110,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 30, 52, 611, DateTimeKind.Utc).AddTicks(8686));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 111,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 30, 52, 611, DateTimeKind.Utc).AddTicks(8689));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 112,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 30, 52, 611, DateTimeKind.Utc).AddTicks(8691));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 113,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 30, 52, 611, DateTimeKind.Utc).AddTicks(8691));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 114,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 30, 52, 611, DateTimeKind.Utc).AddTicks(8692));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 115,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 30, 52, 611, DateTimeKind.Utc).AddTicks(8693));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 116,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 30, 52, 611, DateTimeKind.Utc).AddTicks(8694));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 117,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 30, 52, 611, DateTimeKind.Utc).AddTicks(8695));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 118,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 30, 52, 611, DateTimeKind.Utc).AddTicks(8696));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 119,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 30, 52, 611, DateTimeKind.Utc).AddTicks(8702));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 120,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 30, 52, 611, DateTimeKind.Utc).AddTicks(8703));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 121,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 30, 52, 611, DateTimeKind.Utc).AddTicks(8704));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 122,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 30, 52, 611, DateTimeKind.Utc).AddTicks(8705));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 123,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 30, 52, 611, DateTimeKind.Utc).AddTicks(8705));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 124,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 30, 52, 611, DateTimeKind.Utc).AddTicks(8706));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 125,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 30, 52, 611, DateTimeKind.Utc).AddTicks(8707));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 126,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 30, 52, 611, DateTimeKind.Utc).AddTicks(8708));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 127,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 30, 52, 611, DateTimeKind.Utc).AddTicks(8709));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 128,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 30, 52, 611, DateTimeKind.Utc).AddTicks(8710));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 129,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 30, 52, 611, DateTimeKind.Utc).AddTicks(8711));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 130,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 30, 52, 611, DateTimeKind.Utc).AddTicks(8713));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 131,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 30, 52, 611, DateTimeKind.Utc).AddTicks(8714));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 132,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 30, 52, 611, DateTimeKind.Utc).AddTicks(8714));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 133,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 30, 52, 611, DateTimeKind.Utc).AddTicks(8715));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 134,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 30, 52, 611, DateTimeKind.Utc).AddTicks(8716));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 135,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 30, 52, 611, DateTimeKind.Utc).AddTicks(8717));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 136,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 30, 52, 611, DateTimeKind.Utc).AddTicks(8718));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 137,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 30, 52, 611, DateTimeKind.Utc).AddTicks(8719));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 138,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 30, 52, 611, DateTimeKind.Utc).AddTicks(8720));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 139,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 30, 52, 611, DateTimeKind.Utc).AddTicks(8722));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 140,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 30, 52, 611, DateTimeKind.Utc).AddTicks(8724));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 141,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 30, 52, 611, DateTimeKind.Utc).AddTicks(8725));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 142,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 30, 52, 611, DateTimeKind.Utc).AddTicks(8726));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 143,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 30, 52, 611, DateTimeKind.Utc).AddTicks(8726));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 144,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 30, 52, 611, DateTimeKind.Utc).AddTicks(8727));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 145,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 30, 52, 611, DateTimeKind.Utc).AddTicks(8728));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 146,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 30, 52, 611, DateTimeKind.Utc).AddTicks(8735));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 147,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 30, 52, 611, DateTimeKind.Utc).AddTicks(8736));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 148,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 30, 52, 611, DateTimeKind.Utc).AddTicks(8737));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 149,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 30, 52, 611, DateTimeKind.Utc).AddTicks(8738));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 150,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 30, 52, 611, DateTimeKind.Utc).AddTicks(8739));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 151,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 30, 52, 611, DateTimeKind.Utc).AddTicks(8740));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 152,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 30, 52, 611, DateTimeKind.Utc).AddTicks(8741));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 153,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 30, 52, 611, DateTimeKind.Utc).AddTicks(8742));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 154,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 30, 52, 611, DateTimeKind.Utc).AddTicks(8743));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 155,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 30, 52, 611, DateTimeKind.Utc).AddTicks(8744));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 156,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 30, 52, 611, DateTimeKind.Utc).AddTicks(8744));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 157,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 30, 52, 611, DateTimeKind.Utc).AddTicks(8745));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 158,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 30, 52, 611, DateTimeKind.Utc).AddTicks(8746));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 159,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 30, 52, 611, DateTimeKind.Utc).AddTicks(8747));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 160,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 30, 52, 611, DateTimeKind.Utc).AddTicks(8748));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 161,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 30, 52, 611, DateTimeKind.Utc).AddTicks(8749));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 162,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 30, 52, 611, DateTimeKind.Utc).AddTicks(8750));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 163,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 30, 52, 611, DateTimeKind.Utc).AddTicks(8751));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 164,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 30, 52, 611, DateTimeKind.Utc).AddTicks(8753));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 165,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 30, 52, 611, DateTimeKind.Utc).AddTicks(8755));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 166,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 30, 52, 611, DateTimeKind.Utc).AddTicks(8755));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 167,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 30, 52, 611, DateTimeKind.Utc).AddTicks(8756));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 168,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 30, 52, 611, DateTimeKind.Utc).AddTicks(8757));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 169,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 30, 52, 611, DateTimeKind.Utc).AddTicks(8758));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 170,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 30, 52, 611, DateTimeKind.Utc).AddTicks(8759));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 171,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 30, 52, 611, DateTimeKind.Utc).AddTicks(8760));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 172,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 30, 52, 611, DateTimeKind.Utc).AddTicks(8761));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 173,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 30, 52, 611, DateTimeKind.Utc).AddTicks(8761));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 174,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 30, 52, 611, DateTimeKind.Utc).AddTicks(8762));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 175,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 30, 52, 611, DateTimeKind.Utc).AddTicks(8763));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 176,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 30, 52, 611, DateTimeKind.Utc).AddTicks(8764));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 177,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 30, 52, 611, DateTimeKind.Utc).AddTicks(8765));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 178,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 30, 52, 611, DateTimeKind.Utc).AddTicks(8766));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 179,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 30, 52, 611, DateTimeKind.Utc).AddTicks(8766));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 180,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 30, 52, 611, DateTimeKind.Utc).AddTicks(8767));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 181,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 30, 52, 611, DateTimeKind.Utc).AddTicks(8773));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 182,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 30, 52, 611, DateTimeKind.Utc).AddTicks(8774));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 183,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 30, 52, 611, DateTimeKind.Utc).AddTicks(8775));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 184,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 30, 52, 611, DateTimeKind.Utc).AddTicks(8776));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 185,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 30, 52, 611, DateTimeKind.Utc).AddTicks(8777));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 186,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 30, 52, 611, DateTimeKind.Utc).AddTicks(8778));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 187,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 30, 52, 611, DateTimeKind.Utc).AddTicks(8778));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 188,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 30, 52, 611, DateTimeKind.Utc).AddTicks(8779));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 189,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 30, 52, 611, DateTimeKind.Utc).AddTicks(8780));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 190,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 30, 52, 611, DateTimeKind.Utc).AddTicks(8781));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 191,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 30, 52, 611, DateTimeKind.Utc).AddTicks(8782));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 192,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 30, 52, 611, DateTimeKind.Utc).AddTicks(8783));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 193,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 30, 52, 611, DateTimeKind.Utc).AddTicks(8783));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 194,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 30, 52, 611, DateTimeKind.Utc).AddTicks(8784));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 195,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 30, 52, 611, DateTimeKind.Utc).AddTicks(8785));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 196,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 30, 52, 611, DateTimeKind.Utc).AddTicks(8786));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 197,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 30, 52, 611, DateTimeKind.Utc).AddTicks(8786));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 198,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 30, 52, 611, DateTimeKind.Utc).AddTicks(8787));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 199,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 30, 52, 611, DateTimeKind.Utc).AddTicks(8788));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 200,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 30, 52, 611, DateTimeKind.Utc).AddTicks(8789));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 201,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 30, 52, 611, DateTimeKind.Utc).AddTicks(8790));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 202,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 30, 52, 611, DateTimeKind.Utc).AddTicks(8792));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 203,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 30, 52, 611, DateTimeKind.Utc).AddTicks(8794));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 204,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 30, 52, 611, DateTimeKind.Utc).AddTicks(8794));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 205,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 30, 52, 611, DateTimeKind.Utc).AddTicks(8795));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 206,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 30, 52, 611, DateTimeKind.Utc).AddTicks(8796));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 207,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 30, 52, 611, DateTimeKind.Utc).AddTicks(8797));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 208,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 30, 52, 611, DateTimeKind.Utc).AddTicks(8798));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 209,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 30, 52, 611, DateTimeKind.Utc).AddTicks(8799));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 210,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 30, 52, 611, DateTimeKind.Utc).AddTicks(8800));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 211,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 30, 52, 611, DateTimeKind.Utc).AddTicks(8800));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 212,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 30, 52, 611, DateTimeKind.Utc).AddTicks(8801));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 213,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 30, 52, 611, DateTimeKind.Utc).AddTicks(8802));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 214,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 30, 52, 611, DateTimeKind.Utc).AddTicks(8803));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 215,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 30, 52, 611, DateTimeKind.Utc).AddTicks(8804));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 216,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 30, 52, 611, DateTimeKind.Utc).AddTicks(8805));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 217,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 30, 52, 611, DateTimeKind.Utc).AddTicks(8807));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 218,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 30, 52, 611, DateTimeKind.Utc).AddTicks(8809));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 219,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 30, 52, 611, DateTimeKind.Utc).AddTicks(8815));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 220,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 30, 52, 611, DateTimeKind.Utc).AddTicks(8816));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 221,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 30, 52, 611, DateTimeKind.Utc).AddTicks(8817));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 222,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 30, 52, 611, DateTimeKind.Utc).AddTicks(8818));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 223,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 30, 52, 611, DateTimeKind.Utc).AddTicks(8819));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 224,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 30, 52, 611, DateTimeKind.Utc).AddTicks(8820));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 225,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 30, 52, 611, DateTimeKind.Utc).AddTicks(8821));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 226,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 30, 52, 611, DateTimeKind.Utc).AddTicks(8821));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 227,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 30, 52, 611, DateTimeKind.Utc).AddTicks(8822));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 228,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 30, 52, 611, DateTimeKind.Utc).AddTicks(8823));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 229,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 30, 52, 611, DateTimeKind.Utc).AddTicks(8824));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 230,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 30, 52, 611, DateTimeKind.Utc).AddTicks(8825));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 231,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 30, 52, 611, DateTimeKind.Utc).AddTicks(8825));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 232,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 30, 52, 611, DateTimeKind.Utc).AddTicks(8826));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 233,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 30, 52, 611, DateTimeKind.Utc).AddTicks(8829));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 234,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 30, 52, 611, DateTimeKind.Utc).AddTicks(8830));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 235,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 30, 52, 611, DateTimeKind.Utc).AddTicks(8831));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 236,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 30, 52, 611, DateTimeKind.Utc).AddTicks(8832));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 237,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 30, 52, 611, DateTimeKind.Utc).AddTicks(8833));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 238,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 30, 52, 611, DateTimeKind.Utc).AddTicks(8833));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 239,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 30, 52, 611, DateTimeKind.Utc).AddTicks(8834));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 240,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 30, 52, 611, DateTimeKind.Utc).AddTicks(8835));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 241,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 30, 52, 611, DateTimeKind.Utc).AddTicks(8836));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 242,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 30, 52, 611, DateTimeKind.Utc).AddTicks(8837));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 243,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 30, 52, 611, DateTimeKind.Utc).AddTicks(8840));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 244,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 30, 52, 611, DateTimeKind.Utc).AddTicks(8841));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 245,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 30, 52, 611, DateTimeKind.Utc).AddTicks(8842));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 246,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 30, 52, 611, DateTimeKind.Utc).AddTicks(8842));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 247,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 30, 52, 611, DateTimeKind.Utc).AddTicks(8843));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 248,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 30, 52, 611, DateTimeKind.Utc).AddTicks(8844));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 249,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 30, 52, 611, DateTimeKind.Utc).AddTicks(8845));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 250,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 30, 52, 611, DateTimeKind.Utc).AddTicks(8846));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 251,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 30, 52, 611, DateTimeKind.Utc).AddTicks(8847));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 252,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 30, 52, 611, DateTimeKind.Utc).AddTicks(8847));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 253,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 30, 52, 611, DateTimeKind.Utc).AddTicks(8848));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 254,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 30, 52, 611, DateTimeKind.Utc).AddTicks(8849));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 255,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 30, 52, 611, DateTimeKind.Utc).AddTicks(8859));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 256,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 30, 52, 611, DateTimeKind.Utc).AddTicks(8860));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 257,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 30, 52, 611, DateTimeKind.Utc).AddTicks(8861));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 258,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 30, 52, 611, DateTimeKind.Utc).AddTicks(8863));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 259,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 30, 52, 611, DateTimeKind.Utc).AddTicks(8864));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 260,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 30, 52, 611, DateTimeKind.Utc).AddTicks(8865));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 261,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 30, 52, 611, DateTimeKind.Utc).AddTicks(8865));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 262,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 30, 52, 611, DateTimeKind.Utc).AddTicks(8867));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 263,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 30, 52, 611, DateTimeKind.Utc).AddTicks(8867));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 264,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 30, 52, 611, DateTimeKind.Utc).AddTicks(8868));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 265,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 30, 52, 611, DateTimeKind.Utc).AddTicks(8869));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 266,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 30, 52, 611, DateTimeKind.Utc).AddTicks(8870));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 267,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 30, 52, 611, DateTimeKind.Utc).AddTicks(8871));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 268,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 30, 52, 611, DateTimeKind.Utc).AddTicks(8871));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 269,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 30, 52, 611, DateTimeKind.Utc).AddTicks(8872));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 270,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 30, 52, 611, DateTimeKind.Utc).AddTicks(8873));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 271,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 30, 52, 611, DateTimeKind.Utc).AddTicks(8874));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 272,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 30, 52, 611, DateTimeKind.Utc).AddTicks(8886));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 273,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 30, 52, 611, DateTimeKind.Utc).AddTicks(8887));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 274,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 30, 52, 611, DateTimeKind.Utc).AddTicks(8890));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 275,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 30, 52, 611, DateTimeKind.Utc).AddTicks(8891));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 276,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 30, 52, 611, DateTimeKind.Utc).AddTicks(8892));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 277,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 30, 52, 611, DateTimeKind.Utc).AddTicks(8893));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 278,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 30, 52, 611, DateTimeKind.Utc).AddTicks(8894));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 279,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 30, 52, 611, DateTimeKind.Utc).AddTicks(8895));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 280,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 30, 52, 611, DateTimeKind.Utc).AddTicks(8896));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 281,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 30, 52, 611, DateTimeKind.Utc).AddTicks(8896));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 282,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 30, 52, 611, DateTimeKind.Utc).AddTicks(8897));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 283,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 30, 52, 611, DateTimeKind.Utc).AddTicks(8898));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 284,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 30, 52, 611, DateTimeKind.Utc).AddTicks(8899));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 285,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 30, 52, 611, DateTimeKind.Utc).AddTicks(8900));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 286,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 30, 52, 611, DateTimeKind.Utc).AddTicks(8901));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 287,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 30, 52, 611, DateTimeKind.Utc).AddTicks(8902));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 288,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 30, 52, 611, DateTimeKind.Utc).AddTicks(8903));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 289,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 30, 52, 611, DateTimeKind.Utc).AddTicks(8904));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 290,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 30, 52, 611, DateTimeKind.Utc).AddTicks(8905));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 291,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 30, 52, 611, DateTimeKind.Utc).AddTicks(8905));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 292,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 30, 52, 611, DateTimeKind.Utc).AddTicks(8906));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 293,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 30, 52, 611, DateTimeKind.Utc).AddTicks(8907));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 294,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 30, 52, 611, DateTimeKind.Utc).AddTicks(8908));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 295,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 30, 52, 611, DateTimeKind.Utc).AddTicks(8909));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 296,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 30, 52, 611, DateTimeKind.Utc).AddTicks(8910));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 297,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 30, 52, 611, DateTimeKind.Utc).AddTicks(8911));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 298,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 30, 52, 611, DateTimeKind.Utc).AddTicks(8911));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 299,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 30, 52, 611, DateTimeKind.Utc).AddTicks(8912));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 300,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 30, 52, 611, DateTimeKind.Utc).AddTicks(8913));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 301,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 30, 52, 611, DateTimeKind.Utc).AddTicks(8914));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 302,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 30, 52, 611, DateTimeKind.Utc).AddTicks(8917));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 303,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 30, 52, 611, DateTimeKind.Utc).AddTicks(8918));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 304,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 30, 52, 611, DateTimeKind.Utc).AddTicks(8919));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 305,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 30, 52, 611, DateTimeKind.Utc).AddTicks(8919));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 306,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 30, 52, 611, DateTimeKind.Utc).AddTicks(8920));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 307,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 30, 52, 611, DateTimeKind.Utc).AddTicks(8927));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 308,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 30, 52, 611, DateTimeKind.Utc).AddTicks(8927));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 309,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 30, 52, 611, DateTimeKind.Utc).AddTicks(8928));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 310,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 30, 52, 611, DateTimeKind.Utc).AddTicks(8929));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 311,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 30, 52, 611, DateTimeKind.Utc).AddTicks(8930));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 312,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 30, 52, 611, DateTimeKind.Utc).AddTicks(8931));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 313,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 30, 52, 611, DateTimeKind.Utc).AddTicks(8932));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 314,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 30, 52, 611, DateTimeKind.Utc).AddTicks(8933));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 315,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 30, 52, 611, DateTimeKind.Utc).AddTicks(8934));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 316,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 30, 52, 611, DateTimeKind.Utc).AddTicks(8935));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 317,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 30, 52, 611, DateTimeKind.Utc).AddTicks(8936));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 318,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 30, 52, 611, DateTimeKind.Utc).AddTicks(8937));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 319,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 30, 52, 611, DateTimeKind.Utc).AddTicks(8938));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 320,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 30, 52, 611, DateTimeKind.Utc).AddTicks(8939));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 321,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 30, 52, 611, DateTimeKind.Utc).AddTicks(8940));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 322,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 30, 52, 611, DateTimeKind.Utc).AddTicks(8940));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 323,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 30, 52, 611, DateTimeKind.Utc).AddTicks(8941));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 324,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 30, 52, 611, DateTimeKind.Utc).AddTicks(8942));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 325,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 30, 52, 611, DateTimeKind.Utc).AddTicks(8943));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 326,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 30, 52, 611, DateTimeKind.Utc).AddTicks(8944));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 327,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 30, 52, 611, DateTimeKind.Utc).AddTicks(8981));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 328,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 30, 52, 611, DateTimeKind.Utc).AddTicks(8982));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 329,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 30, 52, 611, DateTimeKind.Utc).AddTicks(8983));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 330,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 30, 52, 611, DateTimeKind.Utc).AddTicks(8984));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 331,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 30, 52, 611, DateTimeKind.Utc).AddTicks(8985));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 332,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 30, 52, 611, DateTimeKind.Utc).AddTicks(8986));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 333,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 30, 52, 611, DateTimeKind.Utc).AddTicks(8987));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 334,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 30, 52, 611, DateTimeKind.Utc).AddTicks(8988));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 335,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 30, 52, 611, DateTimeKind.Utc).AddTicks(8989));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 336,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 30, 52, 611, DateTimeKind.Utc).AddTicks(8989));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 337,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 30, 52, 611, DateTimeKind.Utc).AddTicks(8990));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 338,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 30, 52, 611, DateTimeKind.Utc).AddTicks(8991));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 339,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 30, 52, 611, DateTimeKind.Utc).AddTicks(8992));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 340,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 30, 52, 611, DateTimeKind.Utc).AddTicks(8993));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 341,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 30, 52, 611, DateTimeKind.Utc).AddTicks(8994));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 342,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 30, 52, 611, DateTimeKind.Utc).AddTicks(8995));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 343,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 30, 52, 611, DateTimeKind.Utc).AddTicks(8996));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 344,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 30, 52, 611, DateTimeKind.Utc).AddTicks(8997));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 345,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 30, 52, 611, DateTimeKind.Utc).AddTicks(8997));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 346,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 30, 52, 611, DateTimeKind.Utc).AddTicks(8998));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 347,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 30, 52, 611, DateTimeKind.Utc).AddTicks(8999));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 348,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 30, 52, 611, DateTimeKind.Utc).AddTicks(9000));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 349,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 30, 52, 611, DateTimeKind.Utc).AddTicks(9001));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 350,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 30, 52, 611, DateTimeKind.Utc).AddTicks(9002));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 351,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 30, 52, 611, DateTimeKind.Utc).AddTicks(9002));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 352,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 30, 52, 611, DateTimeKind.Utc).AddTicks(9003));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 353,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 30, 52, 611, DateTimeKind.Utc).AddTicks(9004));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 354,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 30, 52, 611, DateTimeKind.Utc).AddTicks(9005));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 355,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 30, 52, 611, DateTimeKind.Utc).AddTicks(9006));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 356,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 30, 52, 611, DateTimeKind.Utc).AddTicks(9007));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 357,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 30, 52, 611, DateTimeKind.Utc).AddTicks(9008));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 358,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 30, 52, 611, DateTimeKind.Utc).AddTicks(9008));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 359,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 30, 52, 611, DateTimeKind.Utc).AddTicks(9015));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 360,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 30, 52, 611, DateTimeKind.Utc).AddTicks(9016));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 361,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 30, 52, 611, DateTimeKind.Utc).AddTicks(9019));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 362,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 30, 52, 611, DateTimeKind.Utc).AddTicks(9020));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 363,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 30, 52, 611, DateTimeKind.Utc).AddTicks(9021));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 364,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 30, 52, 611, DateTimeKind.Utc).AddTicks(9022));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 365,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 30, 52, 611, DateTimeKind.Utc).AddTicks(9023));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 366,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 30, 52, 611, DateTimeKind.Utc).AddTicks(9024));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 367,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 30, 52, 611, DateTimeKind.Utc).AddTicks(9025));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 368,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 30, 52, 611, DateTimeKind.Utc).AddTicks(9026));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 369,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 30, 52, 611, DateTimeKind.Utc).AddTicks(9026));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 370,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 30, 52, 611, DateTimeKind.Utc).AddTicks(9027));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 371,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 30, 52, 611, DateTimeKind.Utc).AddTicks(9028));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 372,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 30, 52, 611, DateTimeKind.Utc).AddTicks(9029));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 373,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 30, 52, 611, DateTimeKind.Utc).AddTicks(9030));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 374,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 30, 52, 611, DateTimeKind.Utc).AddTicks(9031));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 375,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 30, 52, 611, DateTimeKind.Utc).AddTicks(9032));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 376,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 30, 52, 611, DateTimeKind.Utc).AddTicks(9033));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 377,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 30, 52, 611, DateTimeKind.Utc).AddTicks(9033));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 378,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 30, 52, 611, DateTimeKind.Utc).AddTicks(9034));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 379,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 30, 52, 611, DateTimeKind.Utc).AddTicks(9035));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 380,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 30, 52, 611, DateTimeKind.Utc).AddTicks(9036));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 381,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 30, 52, 611, DateTimeKind.Utc).AddTicks(9037));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 382,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 30, 52, 611, DateTimeKind.Utc).AddTicks(9038));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 383,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 30, 52, 611, DateTimeKind.Utc).AddTicks(9039));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 384,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 30, 52, 611, DateTimeKind.Utc).AddTicks(9039));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 385,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 30, 52, 611, DateTimeKind.Utc).AddTicks(9040));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 386,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 30, 52, 611, DateTimeKind.Utc).AddTicks(9041));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 387,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 30, 52, 611, DateTimeKind.Utc).AddTicks(9042));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 388,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 30, 52, 611, DateTimeKind.Utc).AddTicks(9043));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 389,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 30, 52, 611, DateTimeKind.Utc).AddTicks(9044));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 390,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 30, 52, 611, DateTimeKind.Utc).AddTicks(9045));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 391,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 30, 52, 611, DateTimeKind.Utc).AddTicks(9045));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 392,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 30, 52, 611, DateTimeKind.Utc).AddTicks(9047));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 393,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 30, 52, 611, DateTimeKind.Utc).AddTicks(9047));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 394,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 30, 52, 611, DateTimeKind.Utc).AddTicks(9048));

            migrationBuilder.UpdateData(
                table: "OptionTranslations",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 30, 52, 624, DateTimeKind.Utc).AddTicks(3607));

            migrationBuilder.UpdateData(
                table: "OptionTranslations",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 30, 52, 624, DateTimeKind.Utc).AddTicks(3609));

            migrationBuilder.UpdateData(
                table: "OptionTranslations",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 30, 52, 624, DateTimeKind.Utc).AddTicks(3619));

            migrationBuilder.UpdateData(
                table: "OptionTranslations",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 30, 52, 624, DateTimeKind.Utc).AddTicks(3620));

            migrationBuilder.UpdateData(
                table: "OptionTranslations",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 30, 52, 624, DateTimeKind.Utc).AddTicks(3622));

            migrationBuilder.UpdateData(
                table: "OptionTranslations",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 30, 52, 624, DateTimeKind.Utc).AddTicks(3623));

            migrationBuilder.UpdateData(
                table: "OptionTranslations",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 30, 52, 624, DateTimeKind.Utc).AddTicks(3625));

            migrationBuilder.UpdateData(
                table: "OptionTranslations",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 30, 52, 624, DateTimeKind.Utc).AddTicks(3626));

            migrationBuilder.UpdateData(
                table: "OptionTranslations",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 30, 52, 624, DateTimeKind.Utc).AddTicks(3627));

            migrationBuilder.UpdateData(
                table: "OptionTranslations",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 30, 52, 624, DateTimeKind.Utc).AddTicks(3629));

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 30, 52, 623, DateTimeKind.Utc).AddTicks(6356));

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 30, 52, 623, DateTimeKind.Utc).AddTicks(6359));

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 30, 52, 623, DateTimeKind.Utc).AddTicks(6362));

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 30, 52, 623, DateTimeKind.Utc).AddTicks(6364));

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 30, 52, 623, DateTimeKind.Utc).AddTicks(6366));

            migrationBuilder.UpdateData(
                table: "ProductOptions",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 30, 52, 627, DateTimeKind.Utc).AddTicks(8371));

            migrationBuilder.UpdateData(
                table: "ProductOptions",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 30, 52, 627, DateTimeKind.Utc).AddTicks(8374));

            migrationBuilder.UpdateData(
                table: "ProductOptions",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 30, 52, 627, DateTimeKind.Utc).AddTicks(8377));

            migrationBuilder.UpdateData(
                table: "ProductOptions",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 30, 52, 627, DateTimeKind.Utc).AddTicks(8382));

            migrationBuilder.UpdateData(
                table: "ProductOptions",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 30, 52, 627, DateTimeKind.Utc).AddTicks(8384));

            migrationBuilder.UpdateData(
                table: "ProductOptions",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 30, 52, 627, DateTimeKind.Utc).AddTicks(8386));

            migrationBuilder.UpdateData(
                table: "ProductOptions",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 30, 52, 627, DateTimeKind.Utc).AddTicks(8388));

            migrationBuilder.UpdateData(
                table: "ProductOptions",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 30, 52, 627, DateTimeKind.Utc).AddTicks(8390));

            migrationBuilder.UpdateData(
                table: "ProductOptions",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 30, 52, 627, DateTimeKind.Utc).AddTicks(8392));

            migrationBuilder.UpdateData(
                table: "ProductOptions",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 30, 52, 627, DateTimeKind.Utc).AddTicks(8394));

            migrationBuilder.UpdateData(
                table: "ProductOptions",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 30, 52, 627, DateTimeKind.Utc).AddTicks(8396));

            migrationBuilder.UpdateData(
                table: "ProductOptions",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 30, 52, 627, DateTimeKind.Utc).AddTicks(8397));

            migrationBuilder.UpdateData(
                table: "ProductOptions",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 30, 52, 627, DateTimeKind.Utc).AddTicks(8399));

            migrationBuilder.UpdateData(
                table: "ProductOptions",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 30, 52, 627, DateTimeKind.Utc).AddTicks(8401));

            migrationBuilder.UpdateData(
                table: "ProductOptions",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 30, 52, 627, DateTimeKind.Utc).AddTicks(8416));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 30, 52, 625, DateTimeKind.Utc).AddTicks(9463));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 30, 52, 625, DateTimeKind.Utc).AddTicks(9468));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 30, 52, 625, DateTimeKind.Utc).AddTicks(9471));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 30, 52, 625, DateTimeKind.Utc).AddTicks(9474));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 30, 52, 625, DateTimeKind.Utc).AddTicks(9477));

            migrationBuilder.UpdateData(
                table: "Trademarks",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 30, 52, 629, DateTimeKind.Utc).AddTicks(7101));

            migrationBuilder.UpdateData(
                table: "Trademarks",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 30, 52, 629, DateTimeKind.Utc).AddTicks(7105));

            migrationBuilder.UpdateData(
                table: "Trademarks",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 30, 52, 629, DateTimeKind.Utc).AddTicks(7107));

            migrationBuilder.UpdateData(
                table: "Trademarks",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 30, 52, 629, DateTimeKind.Utc).AddTicks(7109));

            migrationBuilder.UpdateData(
                table: "Trademarks",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 30, 52, 629, DateTimeKind.Utc).AddTicks(7111));

            migrationBuilder.UpdateData(
                table: "Variants",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 30, 52, 631, DateTimeKind.Utc).AddTicks(6772));

            migrationBuilder.UpdateData(
                table: "Variants",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 30, 52, 631, DateTimeKind.Utc).AddTicks(6775));

            migrationBuilder.UpdateData(
                table: "Variants",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 30, 52, 631, DateTimeKind.Utc).AddTicks(6777));

            migrationBuilder.UpdateData(
                table: "Variants",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 30, 52, 631, DateTimeKind.Utc).AddTicks(6779));

            migrationBuilder.UpdateData(
                table: "Variants",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 30, 52, 631, DateTimeKind.Utc).AddTicks(6781));

            migrationBuilder.UpdateData(
                table: "Variants",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 30, 52, 631, DateTimeKind.Utc).AddTicks(6782));

            migrationBuilder.UpdateData(
                table: "Variants",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 30, 52, 631, DateTimeKind.Utc).AddTicks(6784));

            migrationBuilder.UpdateData(
                table: "Variants",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 30, 52, 631, DateTimeKind.Utc).AddTicks(6785));

            migrationBuilder.UpdateData(
                table: "Variants",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 16, 30, 52, 631, DateTimeKind.Utc).AddTicks(6786));
        }
    }
}
