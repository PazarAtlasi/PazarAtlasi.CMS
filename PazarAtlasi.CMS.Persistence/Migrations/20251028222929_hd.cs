using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PazarAtlasi.CMS.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class hd : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AcceptedFileTypes",
                table: "SectionItemFields",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "MaxFileSize",
                table: "SectionItemFields",
                type: "bigint",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "SectionItemFields",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "AcceptedFileTypes", "MaxFileSize" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "SectionItemFields",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "AcceptedFileTypes", "MaxFileSize" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "SectionItemFields",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "AcceptedFileTypes", "MaxFileSize" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "SectionItemFields",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "AcceptedFileTypes", "MaxFileSize" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "SectionItemFields",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "AcceptedFileTypes", "MaxFileSize" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "SectionItemFields",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "AcceptedFileTypes", "MaxFileSize" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "SectionItemFields",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "AcceptedFileTypes", "MaxFileSize" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "SectionItemFields",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "AcceptedFileTypes", "MaxFileSize" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "SectionItemFields",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "AcceptedFileTypes", "MaxFileSize" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "SectionItemFields",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "AcceptedFileTypes", "MaxFileSize" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "SectionItemFields",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "AcceptedFileTypes", "MaxFileSize" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "SectionItemFields",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "AcceptedFileTypes", "MaxFileSize" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "SectionItemFields",
                keyColumn: "Id",
                keyValue: 13,
                columns: new[] { "AcceptedFileTypes", "MaxFileSize" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "SectionItemFields",
                keyColumn: "Id",
                keyValue: 14,
                columns: new[] { "AcceptedFileTypes", "MaxFileSize" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "SectionItemFields",
                keyColumn: "Id",
                keyValue: 15,
                columns: new[] { "AcceptedFileTypes", "MaxFileSize" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "SectionItemFields",
                keyColumn: "Id",
                keyValue: 16,
                columns: new[] { "AcceptedFileTypes", "MaxFileSize" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "SectionItemFields",
                keyColumn: "Id",
                keyValue: 17,
                columns: new[] { "AcceptedFileTypes", "MaxFileSize" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "SectionItemFields",
                keyColumn: "Id",
                keyValue: 18,
                columns: new[] { "AcceptedFileTypes", "MaxFileSize" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "SectionItemFields",
                keyColumn: "Id",
                keyValue: 19,
                columns: new[] { "AcceptedFileTypes", "MaxFileSize" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "SectionItemFields",
                keyColumn: "Id",
                keyValue: 20,
                columns: new[] { "AcceptedFileTypes", "MaxFileSize" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "SectionItemFields",
                keyColumn: "Id",
                keyValue: 21,
                columns: new[] { "AcceptedFileTypes", "MaxFileSize" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "SectionItemFields",
                keyColumn: "Id",
                keyValue: 22,
                columns: new[] { "AcceptedFileTypes", "MaxFileSize" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "SectionItemFields",
                keyColumn: "Id",
                keyValue: 23,
                columns: new[] { "AcceptedFileTypes", "MaxFileSize" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "SectionItemFields",
                keyColumn: "Id",
                keyValue: 24,
                columns: new[] { "AcceptedFileTypes", "MaxFileSize" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "SectionItemFields",
                keyColumn: "Id",
                keyValue: 25,
                columns: new[] { "AcceptedFileTypes", "MaxFileSize" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "SectionItemFields",
                keyColumn: "Id",
                keyValue: 26,
                columns: new[] { "AcceptedFileTypes", "MaxFileSize" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "SectionItemFields",
                keyColumn: "Id",
                keyValue: 27,
                columns: new[] { "AcceptedFileTypes", "MaxFileSize" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "SectionItemFields",
                keyColumn: "Id",
                keyValue: 28,
                columns: new[] { "AcceptedFileTypes", "MaxFileSize" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "SectionItemFields",
                keyColumn: "Id",
                keyValue: 29,
                columns: new[] { "AcceptedFileTypes", "MaxFileSize" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "SectionItemFields",
                keyColumn: "Id",
                keyValue: 30,
                columns: new[] { "AcceptedFileTypes", "MaxFileSize" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "SectionItemFields",
                keyColumn: "Id",
                keyValue: 31,
                columns: new[] { "AcceptedFileTypes", "MaxFileSize" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "SectionItemFields",
                keyColumn: "Id",
                keyValue: 32,
                columns: new[] { "AcceptedFileTypes", "MaxFileSize" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "SectionItemFields",
                keyColumn: "Id",
                keyValue: 33,
                columns: new[] { "AcceptedFileTypes", "MaxFileSize" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "SectionItemFields",
                keyColumn: "Id",
                keyValue: 34,
                columns: new[] { "AcceptedFileTypes", "MaxFileSize" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "SectionItemFields",
                keyColumn: "Id",
                keyValue: 35,
                columns: new[] { "AcceptedFileTypes", "MaxFileSize" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "SectionItemFields",
                keyColumn: "Id",
                keyValue: 36,
                columns: new[] { "AcceptedFileTypes", "MaxFileSize" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "SectionItemFields",
                keyColumn: "Id",
                keyValue: 37,
                columns: new[] { "AcceptedFileTypes", "MaxFileSize" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "SectionItemFields",
                keyColumn: "Id",
                keyValue: 38,
                columns: new[] { "AcceptedFileTypes", "MaxFileSize" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "SectionItemFields",
                keyColumn: "Id",
                keyValue: 39,
                columns: new[] { "AcceptedFileTypes", "MaxFileSize" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "SectionItemFields",
                keyColumn: "Id",
                keyValue: 40,
                columns: new[] { "AcceptedFileTypes", "MaxFileSize" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "SectionItemFields",
                keyColumn: "Id",
                keyValue: 41,
                columns: new[] { "AcceptedFileTypes", "MaxFileSize" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "SectionItemFields",
                keyColumn: "Id",
                keyValue: 42,
                columns: new[] { "AcceptedFileTypes", "MaxFileSize" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "SectionItemFields",
                keyColumn: "Id",
                keyValue: 43,
                columns: new[] { "AcceptedFileTypes", "MaxFileSize" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "SectionItemFields",
                keyColumn: "Id",
                keyValue: 44,
                columns: new[] { "AcceptedFileTypes", "MaxFileSize" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "SectionItemFields",
                keyColumn: "Id",
                keyValue: 45,
                columns: new[] { "AcceptedFileTypes", "MaxFileSize" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "SectionItemFields",
                keyColumn: "Id",
                keyValue: 46,
                columns: new[] { "AcceptedFileTypes", "MaxFileSize" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "SectionItemFields",
                keyColumn: "Id",
                keyValue: 47,
                columns: new[] { "AcceptedFileTypes", "MaxFileSize" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "SectionItemFields",
                keyColumn: "Id",
                keyValue: 48,
                columns: new[] { "AcceptedFileTypes", "MaxFileSize" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "SectionItemFields",
                keyColumn: "Id",
                keyValue: 49,
                columns: new[] { "AcceptedFileTypes", "MaxFileSize" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "SectionItemFields",
                keyColumn: "Id",
                keyValue: 50,
                columns: new[] { "AcceptedFileTypes", "MaxFileSize" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "SectionItemFields",
                keyColumn: "Id",
                keyValue: 51,
                columns: new[] { "AcceptedFileTypes", "MaxFileSize" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "SectionItemFields",
                keyColumn: "Id",
                keyValue: 52,
                columns: new[] { "AcceptedFileTypes", "MaxFileSize" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "SectionItemFields",
                keyColumn: "Id",
                keyValue: 53,
                columns: new[] { "AcceptedFileTypes", "MaxFileSize" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "SectionItemFields",
                keyColumn: "Id",
                keyValue: 54,
                columns: new[] { "AcceptedFileTypes", "MaxFileSize" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "SectionItemFields",
                keyColumn: "Id",
                keyValue: 55,
                columns: new[] { "AcceptedFileTypes", "MaxFileSize" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "SectionItemFields",
                keyColumn: "Id",
                keyValue: 56,
                columns: new[] { "AcceptedFileTypes", "MaxFileSize" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "SectionItemFields",
                keyColumn: "Id",
                keyValue: 57,
                columns: new[] { "AcceptedFileTypes", "MaxFileSize" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "SectionItemFields",
                keyColumn: "Id",
                keyValue: 58,
                columns: new[] { "AcceptedFileTypes", "MaxFileSize" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "SectionItemFields",
                keyColumn: "Id",
                keyValue: 59,
                columns: new[] { "AcceptedFileTypes", "MaxFileSize" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "SectionItemFields",
                keyColumn: "Id",
                keyValue: 60,
                columns: new[] { "AcceptedFileTypes", "MaxFileSize" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "SectionItemFields",
                keyColumn: "Id",
                keyValue: 61,
                columns: new[] { "AcceptedFileTypes", "MaxFileSize" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "SectionItemFields",
                keyColumn: "Id",
                keyValue: 62,
                columns: new[] { "AcceptedFileTypes", "MaxFileSize" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "SectionItemFields",
                keyColumn: "Id",
                keyValue: 63,
                columns: new[] { "AcceptedFileTypes", "MaxFileSize" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "SectionItemFields",
                keyColumn: "Id",
                keyValue: 64,
                columns: new[] { "AcceptedFileTypes", "MaxFileSize" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "SectionItemFields",
                keyColumn: "Id",
                keyValue: 65,
                columns: new[] { "AcceptedFileTypes", "MaxFileSize" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "SectionItemFields",
                keyColumn: "Id",
                keyValue: 66,
                columns: new[] { "AcceptedFileTypes", "MaxFileSize" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "SectionItemFields",
                keyColumn: "Id",
                keyValue: 67,
                columns: new[] { "AcceptedFileTypes", "MaxFileSize" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "SectionItemFields",
                keyColumn: "Id",
                keyValue: 68,
                columns: new[] { "AcceptedFileTypes", "MaxFileSize" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "SectionItemFields",
                keyColumn: "Id",
                keyValue: 69,
                columns: new[] { "AcceptedFileTypes", "MaxFileSize" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "SectionItemFields",
                keyColumn: "Id",
                keyValue: 70,
                columns: new[] { "AcceptedFileTypes", "MaxFileSize" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "SectionItemFields",
                keyColumn: "Id",
                keyValue: 71,
                columns: new[] { "AcceptedFileTypes", "MaxFileSize" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "SectionItemFields",
                keyColumn: "Id",
                keyValue: 72,
                columns: new[] { "AcceptedFileTypes", "MaxFileSize" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "SectionItemFields",
                keyColumn: "Id",
                keyValue: 73,
                columns: new[] { "AcceptedFileTypes", "MaxFileSize" },
                values: new object[] { null, null });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AcceptedFileTypes",
                table: "SectionItemFields");

            migrationBuilder.DropColumn(
                name: "MaxFileSize",
                table: "SectionItemFields");
        }
    }
}
