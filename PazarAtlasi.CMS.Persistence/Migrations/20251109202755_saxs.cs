using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PazarAtlasi.CMS.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class saxs : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsPublic",
                table: "Agents",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "AgentPricings",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "AgentPricings",
                keyColumn: "Id",
                keyValue: 1,
                column: "Name",
                value: "");

            migrationBuilder.UpdateData(
                table: "AgentPricings",
                keyColumn: "Id",
                keyValue: 2,
                column: "Name",
                value: "");

            migrationBuilder.UpdateData(
                table: "AgentPricings",
                keyColumn: "Id",
                keyValue: 3,
                column: "Name",
                value: "");

            migrationBuilder.UpdateData(
                table: "AgentPricings",
                keyColumn: "Id",
                keyValue: 4,
                column: "Name",
                value: "");

            migrationBuilder.UpdateData(
                table: "AgentPricings",
                keyColumn: "Id",
                keyValue: 5,
                column: "Name",
                value: "");

            migrationBuilder.UpdateData(
                table: "Agents",
                keyColumn: "Id",
                keyValue: 1,
                column: "IsPublic",
                value: true);

            migrationBuilder.UpdateData(
                table: "Agents",
                keyColumn: "Id",
                keyValue: 2,
                column: "IsPublic",
                value: true);

            migrationBuilder.UpdateData(
                table: "Agents",
                keyColumn: "Id",
                keyValue: 3,
                column: "IsPublic",
                value: true);

            migrationBuilder.UpdateData(
                table: "DataSchemaFields",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 43, DateTimeKind.Utc).AddTicks(9597));

            migrationBuilder.UpdateData(
                table: "DataSchemaFields",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 43, DateTimeKind.Utc).AddTicks(9602));

            migrationBuilder.UpdateData(
                table: "DataSchemaFields",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 43, DateTimeKind.Utc).AddTicks(9606));

            migrationBuilder.UpdateData(
                table: "DataSchemaFields",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 43, DateTimeKind.Utc).AddTicks(9609));

            migrationBuilder.UpdateData(
                table: "DataSchemaFields",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 43, DateTimeKind.Utc).AddTicks(9613));

            migrationBuilder.UpdateData(
                table: "DataSchemaFields",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 43, DateTimeKind.Utc).AddTicks(9616));

            migrationBuilder.UpdateData(
                table: "DataSchemas",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 42, DateTimeKind.Utc).AddTicks(2033));

            migrationBuilder.UpdateData(
                table: "DataSchemas",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 42, DateTimeKind.Utc).AddTicks(2037));

            migrationBuilder.UpdateData(
                table: "DataSchemas",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 42, DateTimeKind.Utc).AddTicks(2040));

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 36, DateTimeKind.Utc).AddTicks(5464));

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 36, DateTimeKind.Utc).AddTicks(5468));

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 36, DateTimeKind.Utc).AddTicks(5471));

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 36, DateTimeKind.Utc).AddTicks(5473));

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 36, DateTimeKind.Utc).AddTicks(5476));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 37, DateTimeKind.Utc).AddTicks(4346));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 37, DateTimeKind.Utc).AddTicks(4351));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 37, DateTimeKind.Utc).AddTicks(4353));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 37, DateTimeKind.Utc).AddTicks(4354));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 37, DateTimeKind.Utc).AddTicks(4356));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 37, DateTimeKind.Utc).AddTicks(4358));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 37, DateTimeKind.Utc).AddTicks(4359));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 37, DateTimeKind.Utc).AddTicks(4361));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 37, DateTimeKind.Utc).AddTicks(4362));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 37, DateTimeKind.Utc).AddTicks(4364));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 37, DateTimeKind.Utc).AddTicks(4365));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 37, DateTimeKind.Utc).AddTicks(4366));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 37, DateTimeKind.Utc).AddTicks(4367));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 37, DateTimeKind.Utc).AddTicks(4368));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 37, DateTimeKind.Utc).AddTicks(4369));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 16,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 37, DateTimeKind.Utc).AddTicks(4380));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 17,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 37, DateTimeKind.Utc).AddTicks(4381));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 18,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 37, DateTimeKind.Utc).AddTicks(4383));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 19,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 37, DateTimeKind.Utc).AddTicks(4384));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 20,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 37, DateTimeKind.Utc).AddTicks(4385));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 21,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 37, DateTimeKind.Utc).AddTicks(4386));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 22,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 37, DateTimeKind.Utc).AddTicks(4387));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 23,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 37, DateTimeKind.Utc).AddTicks(4388));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 24,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 37, DateTimeKind.Utc).AddTicks(4389));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 25,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 37, DateTimeKind.Utc).AddTicks(4390));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 26,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 37, DateTimeKind.Utc).AddTicks(4391));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 27,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 37, DateTimeKind.Utc).AddTicks(4392));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 28,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 37, DateTimeKind.Utc).AddTicks(4393));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 29,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 37, DateTimeKind.Utc).AddTicks(4394));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 30,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 37, DateTimeKind.Utc).AddTicks(4410));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 31,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 37, DateTimeKind.Utc).AddTicks(4412));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 32,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 37, DateTimeKind.Utc).AddTicks(4412));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 33,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 37, DateTimeKind.Utc).AddTicks(4413));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 34,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 37, DateTimeKind.Utc).AddTicks(4415));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 35,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 37, DateTimeKind.Utc).AddTicks(4417));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 36,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 37, DateTimeKind.Utc).AddTicks(4418));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 37,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 37, DateTimeKind.Utc).AddTicks(4419));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 38,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 37, DateTimeKind.Utc).AddTicks(4420));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 39,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 37, DateTimeKind.Utc).AddTicks(4424));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 40,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 37, DateTimeKind.Utc).AddTicks(4425));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 41,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 37, DateTimeKind.Utc).AddTicks(4426));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 42,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 37, DateTimeKind.Utc).AddTicks(4427));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 43,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 37, DateTimeKind.Utc).AddTicks(4428));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 44,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 37, DateTimeKind.Utc).AddTicks(4429));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 45,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 37, DateTimeKind.Utc).AddTicks(4430));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 46,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 37, DateTimeKind.Utc).AddTicks(4431));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 47,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 37, DateTimeKind.Utc).AddTicks(4432));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 48,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 37, DateTimeKind.Utc).AddTicks(4433));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 49,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 37, DateTimeKind.Utc).AddTicks(4439));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 50,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 37, DateTimeKind.Utc).AddTicks(4440));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 51,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 37, DateTimeKind.Utc).AddTicks(4441));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 52,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 37, DateTimeKind.Utc).AddTicks(4442));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 53,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 37, DateTimeKind.Utc).AddTicks(4443));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 54,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 37, DateTimeKind.Utc).AddTicks(4445));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 55,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 37, DateTimeKind.Utc).AddTicks(4447));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 56,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 37, DateTimeKind.Utc).AddTicks(4447));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 57,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 37, DateTimeKind.Utc).AddTicks(4448));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 58,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 37, DateTimeKind.Utc).AddTicks(4449));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 59,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 37, DateTimeKind.Utc).AddTicks(4450));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 60,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 37, DateTimeKind.Utc).AddTicks(4451));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 61,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 37, DateTimeKind.Utc).AddTicks(4452));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 62,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 37, DateTimeKind.Utc).AddTicks(4453));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 63,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 37, DateTimeKind.Utc).AddTicks(4454));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 64,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 37, DateTimeKind.Utc).AddTicks(4455));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 65,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 37, DateTimeKind.Utc).AddTicks(4456));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 66,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 37, DateTimeKind.Utc).AddTicks(4458));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 67,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 37, DateTimeKind.Utc).AddTicks(4459));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 68,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 37, DateTimeKind.Utc).AddTicks(4460));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 69,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 37, DateTimeKind.Utc).AddTicks(4461));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 70,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 37, DateTimeKind.Utc).AddTicks(4464));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 71,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 37, DateTimeKind.Utc).AddTicks(4465));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 72,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 37, DateTimeKind.Utc).AddTicks(4466));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 73,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 37, DateTimeKind.Utc).AddTicks(4467));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 74,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 37, DateTimeKind.Utc).AddTicks(4469));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 75,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 37, DateTimeKind.Utc).AddTicks(4470));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 76,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 37, DateTimeKind.Utc).AddTicks(4470));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 77,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 37, DateTimeKind.Utc).AddTicks(4471));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 78,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 37, DateTimeKind.Utc).AddTicks(4472));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 79,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 37, DateTimeKind.Utc).AddTicks(4473));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 80,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 37, DateTimeKind.Utc).AddTicks(4476));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 81,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 37, DateTimeKind.Utc).AddTicks(4486));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 82,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 37, DateTimeKind.Utc).AddTicks(4487));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 83,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 37, DateTimeKind.Utc).AddTicks(4488));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 84,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 37, DateTimeKind.Utc).AddTicks(4489));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 85,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 37, DateTimeKind.Utc).AddTicks(4490));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 86,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 37, DateTimeKind.Utc).AddTicks(4492));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 87,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 37, DateTimeKind.Utc).AddTicks(4493));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 88,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 37, DateTimeKind.Utc).AddTicks(4494));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 89,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 37, DateTimeKind.Utc).AddTicks(4495));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 90,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 37, DateTimeKind.Utc).AddTicks(4496));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 91,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 37, DateTimeKind.Utc).AddTicks(4497));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 92,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 37, DateTimeKind.Utc).AddTicks(4498));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 93,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 37, DateTimeKind.Utc).AddTicks(4499));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 94,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 37, DateTimeKind.Utc).AddTicks(4500));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 95,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 37, DateTimeKind.Utc).AddTicks(4501));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 96,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 37, DateTimeKind.Utc).AddTicks(4502));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 97,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 37, DateTimeKind.Utc).AddTicks(4503));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 98,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 37, DateTimeKind.Utc).AddTicks(4504));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 99,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 37, DateTimeKind.Utc).AddTicks(4505));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 100,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 37, DateTimeKind.Utc).AddTicks(4506));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 101,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 37, DateTimeKind.Utc).AddTicks(4507));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 102,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 37, DateTimeKind.Utc).AddTicks(4508));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 103,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 37, DateTimeKind.Utc).AddTicks(4509));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 104,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 37, DateTimeKind.Utc).AddTicks(4510));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 105,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 37, DateTimeKind.Utc).AddTicks(4511));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 106,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 37, DateTimeKind.Utc).AddTicks(4512));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 107,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 37, DateTimeKind.Utc).AddTicks(4513));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 108,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 37, DateTimeKind.Utc).AddTicks(4514));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 109,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 37, DateTimeKind.Utc).AddTicks(4517));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 110,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 37, DateTimeKind.Utc).AddTicks(4518));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 111,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 37, DateTimeKind.Utc).AddTicks(4521));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 112,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 37, DateTimeKind.Utc).AddTicks(4522));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 113,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 37, DateTimeKind.Utc).AddTicks(4524));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 114,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 37, DateTimeKind.Utc).AddTicks(4525));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 115,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 37, DateTimeKind.Utc).AddTicks(4526));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 116,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 37, DateTimeKind.Utc).AddTicks(4527));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 117,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 37, DateTimeKind.Utc).AddTicks(4532));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 118,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 37, DateTimeKind.Utc).AddTicks(4533));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 119,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 37, DateTimeKind.Utc).AddTicks(4534));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 120,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 37, DateTimeKind.Utc).AddTicks(4535));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 121,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 37, DateTimeKind.Utc).AddTicks(4536));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 122,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 37, DateTimeKind.Utc).AddTicks(4537));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 123,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 37, DateTimeKind.Utc).AddTicks(4538));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 124,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 37, DateTimeKind.Utc).AddTicks(4539));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 125,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 37, DateTimeKind.Utc).AddTicks(4539));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 126,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 37, DateTimeKind.Utc).AddTicks(4540));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 127,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 37, DateTimeKind.Utc).AddTicks(4541));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 128,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 37, DateTimeKind.Utc).AddTicks(4542));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 129,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 37, DateTimeKind.Utc).AddTicks(4543));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 130,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 37, DateTimeKind.Utc).AddTicks(4545));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 131,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 37, DateTimeKind.Utc).AddTicks(4546));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 132,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 37, DateTimeKind.Utc).AddTicks(4547));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 133,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 37, DateTimeKind.Utc).AddTicks(4548));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 134,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 37, DateTimeKind.Utc).AddTicks(4549));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 135,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 37, DateTimeKind.Utc).AddTicks(4550));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 136,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 37, DateTimeKind.Utc).AddTicks(4551));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 137,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 37, DateTimeKind.Utc).AddTicks(4552));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 138,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 37, DateTimeKind.Utc).AddTicks(4553));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 139,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 37, DateTimeKind.Utc).AddTicks(4556));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 140,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 37, DateTimeKind.Utc).AddTicks(4557));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 141,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 37, DateTimeKind.Utc).AddTicks(4559));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 142,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 37, DateTimeKind.Utc).AddTicks(4560));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 143,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 37, DateTimeKind.Utc).AddTicks(4565));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 144,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 37, DateTimeKind.Utc).AddTicks(4566));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 145,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 37, DateTimeKind.Utc).AddTicks(4567));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 146,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 37, DateTimeKind.Utc).AddTicks(4569));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 147,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 37, DateTimeKind.Utc).AddTicks(4570));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 148,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 37, DateTimeKind.Utc).AddTicks(4571));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 149,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 37, DateTimeKind.Utc).AddTicks(4572));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 150,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 37, DateTimeKind.Utc).AddTicks(4573));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 151,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 37, DateTimeKind.Utc).AddTicks(4574));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 152,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 37, DateTimeKind.Utc).AddTicks(4575));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 153,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 37, DateTimeKind.Utc).AddTicks(4576));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 154,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 37, DateTimeKind.Utc).AddTicks(4577));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 155,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 37, DateTimeKind.Utc).AddTicks(4578));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 156,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 37, DateTimeKind.Utc).AddTicks(4579));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 157,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 37, DateTimeKind.Utc).AddTicks(4580));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 158,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 37, DateTimeKind.Utc).AddTicks(4581));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 159,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 37, DateTimeKind.Utc).AddTicks(4582));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 160,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 37, DateTimeKind.Utc).AddTicks(4583));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 161,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 37, DateTimeKind.Utc).AddTicks(4584));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 162,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 37, DateTimeKind.Utc).AddTicks(4585));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 163,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 37, DateTimeKind.Utc).AddTicks(4586));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 164,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 37, DateTimeKind.Utc).AddTicks(4588));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 165,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 37, DateTimeKind.Utc).AddTicks(4590));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 166,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 37, DateTimeKind.Utc).AddTicks(4591));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 167,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 37, DateTimeKind.Utc).AddTicks(4592));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 168,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 37, DateTimeKind.Utc).AddTicks(4593));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 169,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 37, DateTimeKind.Utc).AddTicks(4594));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 170,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 37, DateTimeKind.Utc).AddTicks(4595));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 171,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 37, DateTimeKind.Utc).AddTicks(4595));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 172,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 37, DateTimeKind.Utc).AddTicks(4596));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 173,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 37, DateTimeKind.Utc).AddTicks(4597));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 174,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 37, DateTimeKind.Utc).AddTicks(4598));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 175,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 37, DateTimeKind.Utc).AddTicks(4599));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 176,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 37, DateTimeKind.Utc).AddTicks(4600));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 177,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 37, DateTimeKind.Utc).AddTicks(4601));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 178,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 37, DateTimeKind.Utc).AddTicks(4607));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 179,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 37, DateTimeKind.Utc).AddTicks(4608));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 180,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 37, DateTimeKind.Utc).AddTicks(4609));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 181,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 37, DateTimeKind.Utc).AddTicks(4610));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 182,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 37, DateTimeKind.Utc).AddTicks(4611));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 183,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 37, DateTimeKind.Utc).AddTicks(4612));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 184,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 37, DateTimeKind.Utc).AddTicks(4613));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 185,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 37, DateTimeKind.Utc).AddTicks(4614));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 186,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 37, DateTimeKind.Utc).AddTicks(4615));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 187,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 37, DateTimeKind.Utc).AddTicks(4615));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 188,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 37, DateTimeKind.Utc).AddTicks(4616));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 189,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 37, DateTimeKind.Utc).AddTicks(4617));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 190,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 37, DateTimeKind.Utc).AddTicks(4618));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 191,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 37, DateTimeKind.Utc).AddTicks(4619));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 192,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 37, DateTimeKind.Utc).AddTicks(4620));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 193,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 37, DateTimeKind.Utc).AddTicks(4621));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 194,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 37, DateTimeKind.Utc).AddTicks(4622));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 195,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 37, DateTimeKind.Utc).AddTicks(4623));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 196,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 37, DateTimeKind.Utc).AddTicks(4624));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 197,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 37, DateTimeKind.Utc).AddTicks(4625));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 198,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 37, DateTimeKind.Utc).AddTicks(4626));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 199,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 37, DateTimeKind.Utc).AddTicks(4626));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 200,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 37, DateTimeKind.Utc).AddTicks(4627));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 201,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 37, DateTimeKind.Utc).AddTicks(4628));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 202,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 37, DateTimeKind.Utc).AddTicks(4631));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 203,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 37, DateTimeKind.Utc).AddTicks(4633));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 204,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 37, DateTimeKind.Utc).AddTicks(4633));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 205,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 37, DateTimeKind.Utc).AddTicks(4635));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 206,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 37, DateTimeKind.Utc).AddTicks(4636));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 207,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 37, DateTimeKind.Utc).AddTicks(4636));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 208,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 37, DateTimeKind.Utc).AddTicks(4637));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 209,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 37, DateTimeKind.Utc).AddTicks(4638));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 210,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 37, DateTimeKind.Utc).AddTicks(4639));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 211,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 37, DateTimeKind.Utc).AddTicks(4641));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 212,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 37, DateTimeKind.Utc).AddTicks(4641));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 213,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 37, DateTimeKind.Utc).AddTicks(4642));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 214,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 37, DateTimeKind.Utc).AddTicks(4643));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 215,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 37, DateTimeKind.Utc).AddTicks(4644));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 216,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 37, DateTimeKind.Utc).AddTicks(4650));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 217,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 37, DateTimeKind.Utc).AddTicks(4653));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 218,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 37, DateTimeKind.Utc).AddTicks(4655));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 219,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 37, DateTimeKind.Utc).AddTicks(4656));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 220,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 37, DateTimeKind.Utc).AddTicks(4657));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 221,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 37, DateTimeKind.Utc).AddTicks(4658));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 222,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 37, DateTimeKind.Utc).AddTicks(4659));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 223,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 37, DateTimeKind.Utc).AddTicks(4660));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 224,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 37, DateTimeKind.Utc).AddTicks(4661));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 225,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 37, DateTimeKind.Utc).AddTicks(4662));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 226,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 37, DateTimeKind.Utc).AddTicks(4663));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 227,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 37, DateTimeKind.Utc).AddTicks(4664));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 228,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 37, DateTimeKind.Utc).AddTicks(4664));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 229,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 37, DateTimeKind.Utc).AddTicks(4665));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 230,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 37, DateTimeKind.Utc).AddTicks(4666));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 231,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 37, DateTimeKind.Utc).AddTicks(4667));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 232,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 37, DateTimeKind.Utc).AddTicks(4668));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 233,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 37, DateTimeKind.Utc).AddTicks(4672));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 234,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 37, DateTimeKind.Utc).AddTicks(4673));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 235,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 37, DateTimeKind.Utc).AddTicks(4674));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 236,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 37, DateTimeKind.Utc).AddTicks(4675));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 237,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 37, DateTimeKind.Utc).AddTicks(4676));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 238,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 37, DateTimeKind.Utc).AddTicks(4677));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 239,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 37, DateTimeKind.Utc).AddTicks(4678));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 240,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 37, DateTimeKind.Utc).AddTicks(4679));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 241,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 37, DateTimeKind.Utc).AddTicks(4680));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 242,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 37, DateTimeKind.Utc).AddTicks(4681));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 243,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 37, DateTimeKind.Utc).AddTicks(4684));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 244,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 37, DateTimeKind.Utc).AddTicks(4686));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 245,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 37, DateTimeKind.Utc).AddTicks(4687));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 246,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 37, DateTimeKind.Utc).AddTicks(4688));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 247,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 37, DateTimeKind.Utc).AddTicks(4689));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 248,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 37, DateTimeKind.Utc).AddTicks(4690));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 249,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 37, DateTimeKind.Utc).AddTicks(4691));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 250,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 37, DateTimeKind.Utc).AddTicks(4692));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 251,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 37, DateTimeKind.Utc).AddTicks(4693));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 252,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 37, DateTimeKind.Utc).AddTicks(4699));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 253,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 37, DateTimeKind.Utc).AddTicks(4700));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 254,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 37, DateTimeKind.Utc).AddTicks(4701));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 255,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 37, DateTimeKind.Utc).AddTicks(4702));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 256,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 37, DateTimeKind.Utc).AddTicks(4703));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 257,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 37, DateTimeKind.Utc).AddTicks(4703));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 258,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 37, DateTimeKind.Utc).AddTicks(4706));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 259,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 37, DateTimeKind.Utc).AddTicks(4707));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 260,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 37, DateTimeKind.Utc).AddTicks(4707));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 261,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 37, DateTimeKind.Utc).AddTicks(4708));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 262,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 37, DateTimeKind.Utc).AddTicks(4709));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 263,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 37, DateTimeKind.Utc).AddTicks(4710));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 264,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 37, DateTimeKind.Utc).AddTicks(4711));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 265,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 37, DateTimeKind.Utc).AddTicks(4712));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 266,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 37, DateTimeKind.Utc).AddTicks(4713));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 267,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 37, DateTimeKind.Utc).AddTicks(4714));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 268,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 37, DateTimeKind.Utc).AddTicks(4715));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 269,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 37, DateTimeKind.Utc).AddTicks(4721));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 270,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 37, DateTimeKind.Utc).AddTicks(4722));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 271,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 37, DateTimeKind.Utc).AddTicks(4723));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 272,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 37, DateTimeKind.Utc).AddTicks(4726));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 273,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 37, DateTimeKind.Utc).AddTicks(4728));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 274,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 37, DateTimeKind.Utc).AddTicks(4731));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 275,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 37, DateTimeKind.Utc).AddTicks(4732));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 276,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 37, DateTimeKind.Utc).AddTicks(4734));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 277,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 37, DateTimeKind.Utc).AddTicks(4735));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 278,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 37, DateTimeKind.Utc).AddTicks(4735));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 279,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 37, DateTimeKind.Utc).AddTicks(4737));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 280,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 37, DateTimeKind.Utc).AddTicks(4738));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 281,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 37, DateTimeKind.Utc).AddTicks(4738));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 282,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 37, DateTimeKind.Utc).AddTicks(4739));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 283,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 37, DateTimeKind.Utc).AddTicks(4740));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 284,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 37, DateTimeKind.Utc).AddTicks(4742));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 285,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 37, DateTimeKind.Utc).AddTicks(4743));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 286,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 37, DateTimeKind.Utc).AddTicks(4744));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 287,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 37, DateTimeKind.Utc).AddTicks(4745));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 288,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 37, DateTimeKind.Utc).AddTicks(4746));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 289,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 37, DateTimeKind.Utc).AddTicks(4748));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 290,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 37, DateTimeKind.Utc).AddTicks(4748));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 291,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 37, DateTimeKind.Utc).AddTicks(4749));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 292,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 37, DateTimeKind.Utc).AddTicks(4750));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 293,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 37, DateTimeKind.Utc).AddTicks(4752));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 294,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 37, DateTimeKind.Utc).AddTicks(4752));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 295,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 37, DateTimeKind.Utc).AddTicks(4753));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 296,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 37, DateTimeKind.Utc).AddTicks(4754));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 297,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 37, DateTimeKind.Utc).AddTicks(4755));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 298,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 37, DateTimeKind.Utc).AddTicks(4756));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 299,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 37, DateTimeKind.Utc).AddTicks(4757));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 300,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 37, DateTimeKind.Utc).AddTicks(4758));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 301,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 37, DateTimeKind.Utc).AddTicks(4759));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 302,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 37, DateTimeKind.Utc).AddTicks(4762));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 303,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 37, DateTimeKind.Utc).AddTicks(4764));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 304,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 37, DateTimeKind.Utc).AddTicks(4765));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 305,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 37, DateTimeKind.Utc).AddTicks(4770));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 306,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 37, DateTimeKind.Utc).AddTicks(4771));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 307,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 37, DateTimeKind.Utc).AddTicks(4772));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 308,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 37, DateTimeKind.Utc).AddTicks(4773));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 309,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 37, DateTimeKind.Utc).AddTicks(4774));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 310,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 37, DateTimeKind.Utc).AddTicks(4775));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 311,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 37, DateTimeKind.Utc).AddTicks(4776));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 312,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 37, DateTimeKind.Utc).AddTicks(4777));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 313,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 37, DateTimeKind.Utc).AddTicks(4778));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 314,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 37, DateTimeKind.Utc).AddTicks(4779));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 315,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 37, DateTimeKind.Utc).AddTicks(4780));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 316,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 37, DateTimeKind.Utc).AddTicks(4781));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 317,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 37, DateTimeKind.Utc).AddTicks(4782));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 318,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 37, DateTimeKind.Utc).AddTicks(4783));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 319,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 37, DateTimeKind.Utc).AddTicks(4784));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 320,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 37, DateTimeKind.Utc).AddTicks(4785));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 321,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 37, DateTimeKind.Utc).AddTicks(4786));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 322,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 37, DateTimeKind.Utc).AddTicks(4786));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 323,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 37, DateTimeKind.Utc).AddTicks(4787));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 324,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 37, DateTimeKind.Utc).AddTicks(4788));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 325,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 37, DateTimeKind.Utc).AddTicks(4789));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 326,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 37, DateTimeKind.Utc).AddTicks(4790));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 327,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 37, DateTimeKind.Utc).AddTicks(4836));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 328,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 37, DateTimeKind.Utc).AddTicks(4838));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 329,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 37, DateTimeKind.Utc).AddTicks(4839));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 330,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 37, DateTimeKind.Utc).AddTicks(4840));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 331,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 37, DateTimeKind.Utc).AddTicks(4841));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 332,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 37, DateTimeKind.Utc).AddTicks(4842));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 333,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 37, DateTimeKind.Utc).AddTicks(4843));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 334,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 37, DateTimeKind.Utc).AddTicks(4843));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 335,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 37, DateTimeKind.Utc).AddTicks(4845));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 336,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 37, DateTimeKind.Utc).AddTicks(4846));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 337,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 37, DateTimeKind.Utc).AddTicks(4847));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 338,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 37, DateTimeKind.Utc).AddTicks(4848));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 339,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 37, DateTimeKind.Utc).AddTicks(4849));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 340,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 37, DateTimeKind.Utc).AddTicks(4850));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 341,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 37, DateTimeKind.Utc).AddTicks(4851));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 342,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 37, DateTimeKind.Utc).AddTicks(4852));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 343,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 37, DateTimeKind.Utc).AddTicks(4853));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 344,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 37, DateTimeKind.Utc).AddTicks(4853));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 345,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 37, DateTimeKind.Utc).AddTicks(4854));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 346,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 37, DateTimeKind.Utc).AddTicks(4855));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 347,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 37, DateTimeKind.Utc).AddTicks(4856));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 348,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 37, DateTimeKind.Utc).AddTicks(4857));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 349,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 37, DateTimeKind.Utc).AddTicks(4858));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 350,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 37, DateTimeKind.Utc).AddTicks(4859));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 351,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 37, DateTimeKind.Utc).AddTicks(4860));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 352,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 37, DateTimeKind.Utc).AddTicks(4861));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 353,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 37, DateTimeKind.Utc).AddTicks(4862));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 354,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 37, DateTimeKind.Utc).AddTicks(4863));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 355,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 37, DateTimeKind.Utc).AddTicks(4863));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 356,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 37, DateTimeKind.Utc).AddTicks(4864));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 357,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 37, DateTimeKind.Utc).AddTicks(4869));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 358,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 37, DateTimeKind.Utc).AddTicks(4870));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 359,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 37, DateTimeKind.Utc).AddTicks(4871));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 360,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 37, DateTimeKind.Utc).AddTicks(4872));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 361,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 37, DateTimeKind.Utc).AddTicks(4875));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 362,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 37, DateTimeKind.Utc).AddTicks(4876));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 363,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 37, DateTimeKind.Utc).AddTicks(4878));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 364,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 37, DateTimeKind.Utc).AddTicks(4879));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 365,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 37, DateTimeKind.Utc).AddTicks(4880));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 366,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 37, DateTimeKind.Utc).AddTicks(4881));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 367,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 37, DateTimeKind.Utc).AddTicks(4882));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 368,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 37, DateTimeKind.Utc).AddTicks(4883));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 369,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 37, DateTimeKind.Utc).AddTicks(4884));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 370,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 37, DateTimeKind.Utc).AddTicks(4885));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 371,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 37, DateTimeKind.Utc).AddTicks(4886));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 372,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 37, DateTimeKind.Utc).AddTicks(4887));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 373,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 37, DateTimeKind.Utc).AddTicks(4888));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 374,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 37, DateTimeKind.Utc).AddTicks(4889));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 375,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 37, DateTimeKind.Utc).AddTicks(4890));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 376,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 37, DateTimeKind.Utc).AddTicks(4891));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 377,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 37, DateTimeKind.Utc).AddTicks(4892));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 378,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 37, DateTimeKind.Utc).AddTicks(4893));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 379,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 37, DateTimeKind.Utc).AddTicks(4894));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 380,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 37, DateTimeKind.Utc).AddTicks(4895));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 381,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 37, DateTimeKind.Utc).AddTicks(4896));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 382,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 37, DateTimeKind.Utc).AddTicks(4897));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 383,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 37, DateTimeKind.Utc).AddTicks(4898));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 384,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 37, DateTimeKind.Utc).AddTicks(4899));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 385,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 37, DateTimeKind.Utc).AddTicks(4900));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 386,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 37, DateTimeKind.Utc).AddTicks(4900));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 387,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 37, DateTimeKind.Utc).AddTicks(4901));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 388,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 37, DateTimeKind.Utc).AddTicks(4902));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 389,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 37, DateTimeKind.Utc).AddTicks(4903));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 390,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 37, DateTimeKind.Utc).AddTicks(4904));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 391,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 37, DateTimeKind.Utc).AddTicks(4905));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 392,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 37, DateTimeKind.Utc).AddTicks(4906));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 393,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 37, DateTimeKind.Utc).AddTicks(4912));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 394,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 37, DateTimeKind.Utc).AddTicks(4914));

            migrationBuilder.UpdateData(
                table: "OptionTranslations",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 49, DateTimeKind.Utc).AddTicks(7419));

            migrationBuilder.UpdateData(
                table: "OptionTranslations",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 49, DateTimeKind.Utc).AddTicks(7421));

            migrationBuilder.UpdateData(
                table: "OptionTranslations",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 49, DateTimeKind.Utc).AddTicks(7423));

            migrationBuilder.UpdateData(
                table: "OptionTranslations",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 49, DateTimeKind.Utc).AddTicks(7425));

            migrationBuilder.UpdateData(
                table: "OptionTranslations",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 49, DateTimeKind.Utc).AddTicks(7427));

            migrationBuilder.UpdateData(
                table: "OptionTranslations",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 49, DateTimeKind.Utc).AddTicks(7428));

            migrationBuilder.UpdateData(
                table: "OptionTranslations",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 49, DateTimeKind.Utc).AddTicks(7430));

            migrationBuilder.UpdateData(
                table: "OptionTranslations",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 49, DateTimeKind.Utc).AddTicks(7432));

            migrationBuilder.UpdateData(
                table: "OptionTranslations",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 49, DateTimeKind.Utc).AddTicks(7433));

            migrationBuilder.UpdateData(
                table: "OptionTranslations",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 49, DateTimeKind.Utc).AddTicks(7435));

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 49, DateTimeKind.Utc).AddTicks(197));

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 49, DateTimeKind.Utc).AddTicks(201));

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 49, DateTimeKind.Utc).AddTicks(204));

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 49, DateTimeKind.Utc).AddTicks(206));

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 49, DateTimeKind.Utc).AddTicks(209));

            migrationBuilder.UpdateData(
                table: "ProductOptions",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 53, DateTimeKind.Utc).AddTicks(2446));

            migrationBuilder.UpdateData(
                table: "ProductOptions",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 53, DateTimeKind.Utc).AddTicks(2449));

            migrationBuilder.UpdateData(
                table: "ProductOptions",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 53, DateTimeKind.Utc).AddTicks(2452));

            migrationBuilder.UpdateData(
                table: "ProductOptions",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 53, DateTimeKind.Utc).AddTicks(2457));

            migrationBuilder.UpdateData(
                table: "ProductOptions",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 53, DateTimeKind.Utc).AddTicks(2460));

            migrationBuilder.UpdateData(
                table: "ProductOptions",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 53, DateTimeKind.Utc).AddTicks(2470));

            migrationBuilder.UpdateData(
                table: "ProductOptions",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 53, DateTimeKind.Utc).AddTicks(2472));

            migrationBuilder.UpdateData(
                table: "ProductOptions",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 53, DateTimeKind.Utc).AddTicks(2474));

            migrationBuilder.UpdateData(
                table: "ProductOptions",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 53, DateTimeKind.Utc).AddTicks(2476));

            migrationBuilder.UpdateData(
                table: "ProductOptions",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 53, DateTimeKind.Utc).AddTicks(2478));

            migrationBuilder.UpdateData(
                table: "ProductOptions",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 53, DateTimeKind.Utc).AddTicks(2480));

            migrationBuilder.UpdateData(
                table: "ProductOptions",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 53, DateTimeKind.Utc).AddTicks(2482));

            migrationBuilder.UpdateData(
                table: "ProductOptions",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 53, DateTimeKind.Utc).AddTicks(2484));

            migrationBuilder.UpdateData(
                table: "ProductOptions",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 53, DateTimeKind.Utc).AddTicks(2486));

            migrationBuilder.UpdateData(
                table: "ProductOptions",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 53, DateTimeKind.Utc).AddTicks(2494));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 51, DateTimeKind.Utc).AddTicks(4851));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 51, DateTimeKind.Utc).AddTicks(4864));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 51, DateTimeKind.Utc).AddTicks(4867));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 51, DateTimeKind.Utc).AddTicks(4871));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 51, DateTimeKind.Utc).AddTicks(4874));

            migrationBuilder.UpdateData(
                table: "Trademarks",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 54, DateTimeKind.Utc).AddTicks(9484));

            migrationBuilder.UpdateData(
                table: "Trademarks",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 54, DateTimeKind.Utc).AddTicks(9489));

            migrationBuilder.UpdateData(
                table: "Trademarks",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 54, DateTimeKind.Utc).AddTicks(9492));

            migrationBuilder.UpdateData(
                table: "Trademarks",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 54, DateTimeKind.Utc).AddTicks(9495));

            migrationBuilder.UpdateData(
                table: "Trademarks",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 54, DateTimeKind.Utc).AddTicks(9497));

            migrationBuilder.UpdateData(
                table: "Variants",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 56, DateTimeKind.Utc).AddTicks(9386));

            migrationBuilder.UpdateData(
                table: "Variants",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 56, DateTimeKind.Utc).AddTicks(9390));

            migrationBuilder.UpdateData(
                table: "Variants",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 56, DateTimeKind.Utc).AddTicks(9392));

            migrationBuilder.UpdateData(
                table: "Variants",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 56, DateTimeKind.Utc).AddTicks(9395));

            migrationBuilder.UpdateData(
                table: "Variants",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 56, DateTimeKind.Utc).AddTicks(9397));

            migrationBuilder.UpdateData(
                table: "Variants",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 56, DateTimeKind.Utc).AddTicks(9399));

            migrationBuilder.UpdateData(
                table: "Variants",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 56, DateTimeKind.Utc).AddTicks(9401));

            migrationBuilder.UpdateData(
                table: "Variants",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 56, DateTimeKind.Utc).AddTicks(9403));

            migrationBuilder.UpdateData(
                table: "Variants",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 27, 50, 56, DateTimeKind.Utc).AddTicks(9405));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsPublic",
                table: "Agents");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "AgentPricings");

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
    }
}
