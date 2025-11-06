using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace PazarAtlasi.CMS.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class fieelds : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DataSchemas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Key = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    Category = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Configuration = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SortOrder = table.Column<int>(type: "int", nullable: false, defaultValue: 0),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<int>(type: "int", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<int>(type: "int", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    Status = table.Column<int>(type: "int", nullable: false, defaultValue: 1)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DataSchemas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DataSchemaFields",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DataSchemaId = table.Column<int>(type: "int", nullable: false),
                    FieldKey = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    FieldName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Type = table.Column<int>(type: "int", nullable: false, defaultValue: 1),
                    IsRequired = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    IsTranslatable = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    ShowInListing = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    ShowInDetails = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    IsFilterable = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    IsSortable = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    DefaultValue = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Placeholder = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    OptionsJson = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ValidationRules = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Unit = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    SortOrder = table.Column<int>(type: "int", nullable: false, defaultValue: 0),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<int>(type: "int", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<int>(type: "int", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    Status = table.Column<int>(type: "int", nullable: false, defaultValue: 1)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DataSchemaFields", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DataSchemaFields_DataSchemas_DataSchemaId",
                        column: x => x.DataSchemaId,
                        principalTable: "DataSchemas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DataSchemaTranslations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DataSchemaId = table.Column<int>(type: "int", nullable: false),
                    LanguageId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    Category = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<int>(type: "int", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<int>(type: "int", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    Status = table.Column<int>(type: "int", nullable: false, defaultValue: 1)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DataSchemaTranslations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DataSchemaTranslations_DataSchemas_DataSchemaId",
                        column: x => x.DataSchemaId,
                        principalTable: "DataSchemas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DataSchemaTranslations_Languages_LanguageId",
                        column: x => x.LanguageId,
                        principalTable: "Languages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ProductDataSchemas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    SchemaId = table.Column<int>(type: "int", nullable: false),
                    IsPrimary = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    SortOrder = table.Column<int>(type: "int", nullable: false, defaultValue: 0),
                    Configuration = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<int>(type: "int", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<int>(type: "int", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    Status = table.Column<int>(type: "int", nullable: false, defaultValue: 1)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductDataSchemas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductDataSchemas_DataSchemas_SchemaId",
                        column: x => x.SchemaId,
                        principalTable: "DataSchemas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductDataSchemas_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DataSchemaFieldTranslations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DataSchemaFieldId = table.Column<int>(type: "int", nullable: false),
                    LanguageId = table.Column<int>(type: "int", nullable: false),
                    FieldName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Placeholder = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    Unit = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    OptionsJson = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<int>(type: "int", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<int>(type: "int", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    Status = table.Column<int>(type: "int", nullable: false, defaultValue: 1)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DataSchemaFieldTranslations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DataSchemaFieldTranslations_DataSchemaFields_DataSchemaFieldId",
                        column: x => x.DataSchemaFieldId,
                        principalTable: "DataSchemaFields",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DataSchemaFieldTranslations_Languages_LanguageId",
                        column: x => x.LanguageId,
                        principalTable: "Languages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DataSchemaFieldValues",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    SchemaId = table.Column<int>(type: "int", nullable: false),
                    FieldId = table.Column<int>(type: "int", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: false),
                    JsonValue = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NumericValue = table.Column<decimal>(type: "decimal(18,4)", nullable: true),
                    BooleanValue = table.Column<bool>(type: "bit", nullable: true),
                    DateValue = table.Column<DateTime>(type: "datetime2", nullable: true),
                    SortOrder = table.Column<int>(type: "int", nullable: false, defaultValue: 0),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<int>(type: "int", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<int>(type: "int", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    Status = table.Column<int>(type: "int", nullable: false, defaultValue: 1)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DataSchemaFieldValues", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DataSchemaFieldValues_DataSchemaFields_FieldId",
                        column: x => x.FieldId,
                        principalTable: "DataSchemaFields",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DataSchemaFieldValues_DataSchemas_SchemaId",
                        column: x => x.SchemaId,
                        principalTable: "DataSchemas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DataSchemaFieldValues_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DataSchemaFieldValueTranslations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DataSchemaFieldValueId = table.Column<int>(type: "int", nullable: false),
                    LanguageId = table.Column<int>(type: "int", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: false),
                    JsonValue = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<int>(type: "int", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<int>(type: "int", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    Status = table.Column<int>(type: "int", nullable: false, defaultValue: 1)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DataSchemaFieldValueTranslations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DataSchemaFieldValueTranslations_DataSchemaFieldValues_DataSchemaFieldValueId",
                        column: x => x.DataSchemaFieldValueId,
                        principalTable: "DataSchemaFieldValues",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DataSchemaFieldValueTranslations_Languages_LanguageId",
                        column: x => x.LanguageId,
                        principalTable: "Languages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "DataSchemas",
                columns: new[] { "Id", "Category", "Configuration", "CreatedAt", "CreatedBy", "Description", "IsActive", "Key", "Name", "SortOrder", "Status", "UpdatedAt", "UpdatedBy" },
                values: new object[,]
                {
                    { 1, "Electronics", "{}", new DateTime(2025, 11, 6, 22, 16, 46, 135, DateTimeKind.Utc).AddTicks(4791), null, "General specifications for electronic products", true, "electronics-specs", "Electronics Specifications", 1, 1, null, null },
                    { 2, "Electronics", "{}", new DateTime(2025, 11, 6, 22, 16, 46, 135, DateTimeKind.Utc).AddTicks(4796), null, "Detailed specifications for smartphones", true, "smartphone-specs", "Smartphone Specifications", 2, 1, null, null },
                    { 3, "Electronics", "{}", new DateTime(2025, 11, 6, 22, 16, 46, 135, DateTimeKind.Utc).AddTicks(4799), null, "Detailed specifications for laptops", true, "laptop-specs", "Laptop Specifications", 3, 1, null, null }
                });

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 22, 16, 46, 130, DateTimeKind.Utc).AddTicks(7858));

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 22, 16, 46, 130, DateTimeKind.Utc).AddTicks(7862));

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 22, 16, 46, 130, DateTimeKind.Utc).AddTicks(7864));

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 22, 16, 46, 130, DateTimeKind.Utc).AddTicks(7866));

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 22, 16, 46, 130, DateTimeKind.Utc).AddTicks(7868));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 22, 16, 46, 131, DateTimeKind.Utc).AddTicks(4368));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 22, 16, 46, 131, DateTimeKind.Utc).AddTicks(4373));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 22, 16, 46, 131, DateTimeKind.Utc).AddTicks(4374));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 22, 16, 46, 131, DateTimeKind.Utc).AddTicks(4375));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 22, 16, 46, 131, DateTimeKind.Utc).AddTicks(4376));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 22, 16, 46, 131, DateTimeKind.Utc).AddTicks(4378));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 22, 16, 46, 131, DateTimeKind.Utc).AddTicks(4380));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 22, 16, 46, 131, DateTimeKind.Utc).AddTicks(4381));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 22, 16, 46, 131, DateTimeKind.Utc).AddTicks(4382));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 22, 16, 46, 131, DateTimeKind.Utc).AddTicks(4384));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 22, 16, 46, 131, DateTimeKind.Utc).AddTicks(4385));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 22, 16, 46, 131, DateTimeKind.Utc).AddTicks(4386));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 22, 16, 46, 131, DateTimeKind.Utc).AddTicks(4386));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 22, 16, 46, 131, DateTimeKind.Utc).AddTicks(4387));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 22, 16, 46, 131, DateTimeKind.Utc).AddTicks(4389));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 16,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 22, 16, 46, 131, DateTimeKind.Utc).AddTicks(4390));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 17,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 22, 16, 46, 131, DateTimeKind.Utc).AddTicks(4391));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 18,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 22, 16, 46, 131, DateTimeKind.Utc).AddTicks(4392));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 19,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 22, 16, 46, 131, DateTimeKind.Utc).AddTicks(4393));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 20,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 22, 16, 46, 131, DateTimeKind.Utc).AddTicks(4395));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 21,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 22, 16, 46, 131, DateTimeKind.Utc).AddTicks(4401));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 22,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 22, 16, 46, 131, DateTimeKind.Utc).AddTicks(4402));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 23,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 22, 16, 46, 131, DateTimeKind.Utc).AddTicks(4403));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 24,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 22, 16, 46, 131, DateTimeKind.Utc).AddTicks(4404));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 25,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 22, 16, 46, 131, DateTimeKind.Utc).AddTicks(4405));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 26,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 22, 16, 46, 131, DateTimeKind.Utc).AddTicks(4406));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 27,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 22, 16, 46, 131, DateTimeKind.Utc).AddTicks(4406));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 28,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 22, 16, 46, 131, DateTimeKind.Utc).AddTicks(4407));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 29,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 22, 16, 46, 131, DateTimeKind.Utc).AddTicks(4408));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 30,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 22, 16, 46, 131, DateTimeKind.Utc).AddTicks(4417));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 31,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 22, 16, 46, 131, DateTimeKind.Utc).AddTicks(4418));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 32,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 22, 16, 46, 131, DateTimeKind.Utc).AddTicks(4419));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 33,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 22, 16, 46, 131, DateTimeKind.Utc).AddTicks(4420));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 34,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 22, 16, 46, 131, DateTimeKind.Utc).AddTicks(4469));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 35,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 22, 16, 46, 131, DateTimeKind.Utc).AddTicks(4470));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 36,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 22, 16, 46, 131, DateTimeKind.Utc).AddTicks(4471));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 37,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 22, 16, 46, 131, DateTimeKind.Utc).AddTicks(4472));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 38,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 22, 16, 46, 131, DateTimeKind.Utc).AddTicks(4473));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 39,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 22, 16, 46, 131, DateTimeKind.Utc).AddTicks(4476));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 40,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 22, 16, 46, 131, DateTimeKind.Utc).AddTicks(4478));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 41,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 22, 16, 46, 131, DateTimeKind.Utc).AddTicks(4479));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 42,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 22, 16, 46, 131, DateTimeKind.Utc).AddTicks(4480));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 43,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 22, 16, 46, 131, DateTimeKind.Utc).AddTicks(4481));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 44,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 22, 16, 46, 131, DateTimeKind.Utc).AddTicks(4482));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 45,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 22, 16, 46, 131, DateTimeKind.Utc).AddTicks(4483));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 46,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 22, 16, 46, 131, DateTimeKind.Utc).AddTicks(4484));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 47,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 22, 16, 46, 131, DateTimeKind.Utc).AddTicks(4485));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 48,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 22, 16, 46, 131, DateTimeKind.Utc).AddTicks(4486));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 49,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 22, 16, 46, 131, DateTimeKind.Utc).AddTicks(4487));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 50,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 22, 16, 46, 131, DateTimeKind.Utc).AddTicks(4488));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 51,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 22, 16, 46, 131, DateTimeKind.Utc).AddTicks(4488));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 52,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 22, 16, 46, 131, DateTimeKind.Utc).AddTicks(4489));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 53,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 22, 16, 46, 131, DateTimeKind.Utc).AddTicks(4490));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 54,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 22, 16, 46, 131, DateTimeKind.Utc).AddTicks(4493));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 55,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 22, 16, 46, 131, DateTimeKind.Utc).AddTicks(4494));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 56,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 22, 16, 46, 131, DateTimeKind.Utc).AddTicks(4495));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 57,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 22, 16, 46, 131, DateTimeKind.Utc).AddTicks(4496));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 58,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 22, 16, 46, 131, DateTimeKind.Utc).AddTicks(4497));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 59,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 22, 16, 46, 131, DateTimeKind.Utc).AddTicks(4498));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 60,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 22, 16, 46, 131, DateTimeKind.Utc).AddTicks(4498));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 61,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 22, 16, 46, 131, DateTimeKind.Utc).AddTicks(4499));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 62,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 22, 16, 46, 131, DateTimeKind.Utc).AddTicks(4500));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 63,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 22, 16, 46, 131, DateTimeKind.Utc).AddTicks(4501));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 64,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 22, 16, 46, 131, DateTimeKind.Utc).AddTicks(4502));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 65,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 22, 16, 46, 131, DateTimeKind.Utc).AddTicks(4503));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 66,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 22, 16, 46, 131, DateTimeKind.Utc).AddTicks(4567));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 67,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 22, 16, 46, 131, DateTimeKind.Utc).AddTicks(4568));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 68,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 22, 16, 46, 131, DateTimeKind.Utc).AddTicks(4569));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 69,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 22, 16, 46, 131, DateTimeKind.Utc).AddTicks(4570));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 70,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 22, 16, 46, 131, DateTimeKind.Utc).AddTicks(4573));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 71,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 22, 16, 46, 131, DateTimeKind.Utc).AddTicks(4574));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 72,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 22, 16, 46, 131, DateTimeKind.Utc).AddTicks(4575));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 73,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 22, 16, 46, 131, DateTimeKind.Utc).AddTicks(4576));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 74,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 22, 16, 46, 131, DateTimeKind.Utc).AddTicks(4578));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 75,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 22, 16, 46, 131, DateTimeKind.Utc).AddTicks(4579));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 76,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 22, 16, 46, 131, DateTimeKind.Utc).AddTicks(4580));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 77,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 22, 16, 46, 131, DateTimeKind.Utc).AddTicks(4581));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 78,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 22, 16, 46, 131, DateTimeKind.Utc).AddTicks(4582));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 79,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 22, 16, 46, 131, DateTimeKind.Utc).AddTicks(4583));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 80,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 22, 16, 46, 131, DateTimeKind.Utc).AddTicks(4585));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 81,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 22, 16, 46, 131, DateTimeKind.Utc).AddTicks(4587));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 82,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 22, 16, 46, 131, DateTimeKind.Utc).AddTicks(4588));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 83,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 22, 16, 46, 131, DateTimeKind.Utc).AddTicks(4589));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 84,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 22, 16, 46, 131, DateTimeKind.Utc).AddTicks(4590));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 85,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 22, 16, 46, 131, DateTimeKind.Utc).AddTicks(4591));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 86,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 22, 16, 46, 131, DateTimeKind.Utc).AddTicks(4592));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 87,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 22, 16, 46, 131, DateTimeKind.Utc).AddTicks(4593));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 88,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 22, 16, 46, 131, DateTimeKind.Utc).AddTicks(4594));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 89,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 22, 16, 46, 131, DateTimeKind.Utc).AddTicks(4595));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 90,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 22, 16, 46, 131, DateTimeKind.Utc).AddTicks(4596));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 91,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 22, 16, 46, 131, DateTimeKind.Utc).AddTicks(4597));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 92,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 22, 16, 46, 131, DateTimeKind.Utc).AddTicks(4598));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 93,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 22, 16, 46, 131, DateTimeKind.Utc).AddTicks(4599));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 94,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 22, 16, 46, 131, DateTimeKind.Utc).AddTicks(4600));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 95,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 22, 16, 46, 131, DateTimeKind.Utc).AddTicks(4601));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 96,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 22, 16, 46, 131, DateTimeKind.Utc).AddTicks(4602));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 97,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 22, 16, 46, 131, DateTimeKind.Utc).AddTicks(4627));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 98,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 22, 16, 46, 131, DateTimeKind.Utc).AddTicks(4628));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 99,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 22, 16, 46, 131, DateTimeKind.Utc).AddTicks(4629));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 100,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 22, 16, 46, 131, DateTimeKind.Utc).AddTicks(4630));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 101,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 22, 16, 46, 131, DateTimeKind.Utc).AddTicks(4631));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 102,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 22, 16, 46, 131, DateTimeKind.Utc).AddTicks(4631));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 103,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 22, 16, 46, 131, DateTimeKind.Utc).AddTicks(4633));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 104,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 22, 16, 46, 131, DateTimeKind.Utc).AddTicks(4634));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 105,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 22, 16, 46, 131, DateTimeKind.Utc).AddTicks(4635));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 106,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 22, 16, 46, 131, DateTimeKind.Utc).AddTicks(4636));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 107,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 22, 16, 46, 131, DateTimeKind.Utc).AddTicks(4636));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 108,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 22, 16, 46, 131, DateTimeKind.Utc).AddTicks(4637));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 109,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 22, 16, 46, 131, DateTimeKind.Utc).AddTicks(4640));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 110,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 22, 16, 46, 131, DateTimeKind.Utc).AddTicks(4641));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 111,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 22, 16, 46, 131, DateTimeKind.Utc).AddTicks(4644));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 112,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 22, 16, 46, 131, DateTimeKind.Utc).AddTicks(4646));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 113,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 22, 16, 46, 131, DateTimeKind.Utc).AddTicks(4647));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 114,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 22, 16, 46, 131, DateTimeKind.Utc).AddTicks(4648));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 115,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 22, 16, 46, 131, DateTimeKind.Utc).AddTicks(4649));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 116,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 22, 16, 46, 131, DateTimeKind.Utc).AddTicks(4650));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 117,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 22, 16, 46, 131, DateTimeKind.Utc).AddTicks(4651));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 118,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 22, 16, 46, 131, DateTimeKind.Utc).AddTicks(4652));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 119,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 22, 16, 46, 131, DateTimeKind.Utc).AddTicks(4653));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 120,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 22, 16, 46, 131, DateTimeKind.Utc).AddTicks(4653));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 121,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 22, 16, 46, 131, DateTimeKind.Utc).AddTicks(4654));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 122,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 22, 16, 46, 131, DateTimeKind.Utc).AddTicks(4655));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 123,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 22, 16, 46, 131, DateTimeKind.Utc).AddTicks(4656));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 124,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 22, 16, 46, 131, DateTimeKind.Utc).AddTicks(4657));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 125,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 22, 16, 46, 131, DateTimeKind.Utc).AddTicks(4658));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 126,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 22, 16, 46, 131, DateTimeKind.Utc).AddTicks(4659));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 127,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 22, 16, 46, 131, DateTimeKind.Utc).AddTicks(4660));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 128,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 22, 16, 46, 131, DateTimeKind.Utc).AddTicks(4662));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 129,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 22, 16, 46, 131, DateTimeKind.Utc).AddTicks(4663));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 130,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 22, 16, 46, 131, DateTimeKind.Utc).AddTicks(4679));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 131,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 22, 16, 46, 131, DateTimeKind.Utc).AddTicks(4681));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 132,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 22, 16, 46, 131, DateTimeKind.Utc).AddTicks(4682));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 133,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 22, 16, 46, 131, DateTimeKind.Utc).AddTicks(4683));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 134,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 22, 16, 46, 131, DateTimeKind.Utc).AddTicks(4685));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 135,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 22, 16, 46, 131, DateTimeKind.Utc).AddTicks(4685));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 136,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 22, 16, 46, 131, DateTimeKind.Utc).AddTicks(4686));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 137,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 22, 16, 46, 131, DateTimeKind.Utc).AddTicks(4687));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 138,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 22, 16, 46, 131, DateTimeKind.Utc).AddTicks(4688));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 139,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 22, 16, 46, 131, DateTimeKind.Utc).AddTicks(4691));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 140,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 22, 16, 46, 131, DateTimeKind.Utc).AddTicks(4692));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 141,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 22, 16, 46, 131, DateTimeKind.Utc).AddTicks(4693));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 142,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 22, 16, 46, 131, DateTimeKind.Utc).AddTicks(4695));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 143,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 22, 16, 46, 131, DateTimeKind.Utc).AddTicks(4696));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 144,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 22, 16, 46, 131, DateTimeKind.Utc).AddTicks(4697));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 145,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 22, 16, 46, 131, DateTimeKind.Utc).AddTicks(4698));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 146,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 22, 16, 46, 131, DateTimeKind.Utc).AddTicks(4699));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 147,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 22, 16, 46, 131, DateTimeKind.Utc).AddTicks(4700));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 148,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 22, 16, 46, 131, DateTimeKind.Utc).AddTicks(4701));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 149,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 22, 16, 46, 131, DateTimeKind.Utc).AddTicks(4702));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 150,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 22, 16, 46, 131, DateTimeKind.Utc).AddTicks(4703));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 151,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 22, 16, 46, 131, DateTimeKind.Utc).AddTicks(4704));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 152,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 22, 16, 46, 131, DateTimeKind.Utc).AddTicks(4705));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 153,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 22, 16, 46, 131, DateTimeKind.Utc).AddTicks(4706));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 154,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 22, 16, 46, 131, DateTimeKind.Utc).AddTicks(4707));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 155,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 22, 16, 46, 131, DateTimeKind.Utc).AddTicks(4708));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 156,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 22, 16, 46, 131, DateTimeKind.Utc).AddTicks(4739));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 157,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 22, 16, 46, 131, DateTimeKind.Utc).AddTicks(4740));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 158,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 22, 16, 46, 131, DateTimeKind.Utc).AddTicks(4741));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 159,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 22, 16, 46, 131, DateTimeKind.Utc).AddTicks(4742));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 160,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 22, 16, 46, 131, DateTimeKind.Utc).AddTicks(4743));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 161,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 22, 16, 46, 131, DateTimeKind.Utc).AddTicks(4744));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 162,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 22, 16, 46, 131, DateTimeKind.Utc).AddTicks(4745));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 163,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 22, 16, 46, 131, DateTimeKind.Utc).AddTicks(4745));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 164,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 22, 16, 46, 131, DateTimeKind.Utc).AddTicks(4748));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 165,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 22, 16, 46, 131, DateTimeKind.Utc).AddTicks(4750));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 166,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 22, 16, 46, 131, DateTimeKind.Utc).AddTicks(4751));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 167,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 22, 16, 46, 131, DateTimeKind.Utc).AddTicks(4751));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 168,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 22, 16, 46, 131, DateTimeKind.Utc).AddTicks(4752));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 169,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 22, 16, 46, 131, DateTimeKind.Utc).AddTicks(4753));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 170,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 22, 16, 46, 131, DateTimeKind.Utc).AddTicks(4754));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 171,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 22, 16, 46, 131, DateTimeKind.Utc).AddTicks(4755));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 172,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 22, 16, 46, 131, DateTimeKind.Utc).AddTicks(4756));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 173,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 22, 16, 46, 131, DateTimeKind.Utc).AddTicks(4757));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 174,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 22, 16, 46, 131, DateTimeKind.Utc).AddTicks(4757));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 175,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 22, 16, 46, 131, DateTimeKind.Utc).AddTicks(4758));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 176,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 22, 16, 46, 131, DateTimeKind.Utc).AddTicks(4759));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 177,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 22, 16, 46, 131, DateTimeKind.Utc).AddTicks(4760));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 178,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 22, 16, 46, 131, DateTimeKind.Utc).AddTicks(4761));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 179,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 22, 16, 46, 131, DateTimeKind.Utc).AddTicks(4762));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 180,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 22, 16, 46, 131, DateTimeKind.Utc).AddTicks(4763));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 181,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 22, 16, 46, 131, DateTimeKind.Utc).AddTicks(4764));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 182,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 22, 16, 46, 131, DateTimeKind.Utc).AddTicks(4765));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 183,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 22, 16, 46, 131, DateTimeKind.Utc).AddTicks(4766));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 184,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 22, 16, 46, 131, DateTimeKind.Utc).AddTicks(4767));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 185,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 22, 16, 46, 131, DateTimeKind.Utc).AddTicks(4768));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 186,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 22, 16, 46, 131, DateTimeKind.Utc).AddTicks(4769));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 187,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 22, 16, 46, 131, DateTimeKind.Utc).AddTicks(4770));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 188,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 22, 16, 46, 131, DateTimeKind.Utc).AddTicks(4770));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 189,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 22, 16, 46, 131, DateTimeKind.Utc).AddTicks(4771));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 190,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 22, 16, 46, 131, DateTimeKind.Utc).AddTicks(4772));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 191,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 22, 16, 46, 131, DateTimeKind.Utc).AddTicks(4773));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 192,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 22, 16, 46, 131, DateTimeKind.Utc).AddTicks(4774));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 193,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 22, 16, 46, 131, DateTimeKind.Utc).AddTicks(4804));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 194,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 22, 16, 46, 131, DateTimeKind.Utc).AddTicks(4805));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 195,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 22, 16, 46, 131, DateTimeKind.Utc).AddTicks(4806));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 196,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 22, 16, 46, 131, DateTimeKind.Utc).AddTicks(4807));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 197,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 22, 16, 46, 131, DateTimeKind.Utc).AddTicks(4808));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 198,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 22, 16, 46, 131, DateTimeKind.Utc).AddTicks(4809));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 199,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 22, 16, 46, 131, DateTimeKind.Utc).AddTicks(4809));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 200,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 22, 16, 46, 131, DateTimeKind.Utc).AddTicks(4810));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 201,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 22, 16, 46, 131, DateTimeKind.Utc).AddTicks(4812));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 202,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 22, 16, 46, 131, DateTimeKind.Utc).AddTicks(4814));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 203,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 22, 16, 46, 131, DateTimeKind.Utc).AddTicks(4816));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 204,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 22, 16, 46, 131, DateTimeKind.Utc).AddTicks(4817));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 205,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 22, 16, 46, 131, DateTimeKind.Utc).AddTicks(4818));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 206,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 22, 16, 46, 131, DateTimeKind.Utc).AddTicks(4818));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 207,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 22, 16, 46, 131, DateTimeKind.Utc).AddTicks(4819));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 208,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 22, 16, 46, 131, DateTimeKind.Utc).AddTicks(4820));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 209,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 22, 16, 46, 131, DateTimeKind.Utc).AddTicks(4821));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 210,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 22, 16, 46, 131, DateTimeKind.Utc).AddTicks(4822));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 211,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 22, 16, 46, 131, DateTimeKind.Utc).AddTicks(4823));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 212,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 22, 16, 46, 131, DateTimeKind.Utc).AddTicks(4824));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 213,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 22, 16, 46, 131, DateTimeKind.Utc).AddTicks(4825));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 214,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 22, 16, 46, 131, DateTimeKind.Utc).AddTicks(4826));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 215,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 22, 16, 46, 131, DateTimeKind.Utc).AddTicks(4827));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 216,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 22, 16, 46, 131, DateTimeKind.Utc).AddTicks(4828));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 217,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 22, 16, 46, 131, DateTimeKind.Utc).AddTicks(4831));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 218,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 22, 16, 46, 131, DateTimeKind.Utc).AddTicks(4832));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 219,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 22, 16, 46, 131, DateTimeKind.Utc).AddTicks(4833));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 220,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 22, 16, 46, 131, DateTimeKind.Utc).AddTicks(4834));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 221,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 22, 16, 46, 131, DateTimeKind.Utc).AddTicks(4834));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 222,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 22, 16, 46, 131, DateTimeKind.Utc).AddTicks(4835));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 223,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 22, 16, 46, 131, DateTimeKind.Utc).AddTicks(4836));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 224,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 22, 16, 46, 131, DateTimeKind.Utc).AddTicks(4838));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 225,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 22, 16, 46, 131, DateTimeKind.Utc).AddTicks(4838));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 226,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 22, 16, 46, 131, DateTimeKind.Utc).AddTicks(4839));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 227,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 22, 16, 46, 131, DateTimeKind.Utc).AddTicks(4840));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 228,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 22, 16, 46, 131, DateTimeKind.Utc).AddTicks(4841));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 229,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 22, 16, 46, 131, DateTimeKind.Utc).AddTicks(4842));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 230,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 22, 16, 46, 131, DateTimeKind.Utc).AddTicks(4884));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 231,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 22, 16, 46, 131, DateTimeKind.Utc).AddTicks(4885));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 232,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 22, 16, 46, 131, DateTimeKind.Utc).AddTicks(4886));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 233,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 22, 16, 46, 131, DateTimeKind.Utc).AddTicks(4889));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 234,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 22, 16, 46, 131, DateTimeKind.Utc).AddTicks(4890));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 235,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 22, 16, 46, 131, DateTimeKind.Utc).AddTicks(4891));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 236,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 22, 16, 46, 131, DateTimeKind.Utc).AddTicks(4892));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 237,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 22, 16, 46, 131, DateTimeKind.Utc).AddTicks(4893));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 238,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 22, 16, 46, 131, DateTimeKind.Utc).AddTicks(4894));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 239,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 22, 16, 46, 131, DateTimeKind.Utc).AddTicks(4895));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 240,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 22, 16, 46, 131, DateTimeKind.Utc).AddTicks(4896));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 241,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 22, 16, 46, 131, DateTimeKind.Utc).AddTicks(4897));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 242,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 22, 16, 46, 131, DateTimeKind.Utc).AddTicks(4898));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 243,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 22, 16, 46, 131, DateTimeKind.Utc).AddTicks(4900));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 244,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 22, 16, 46, 131, DateTimeKind.Utc).AddTicks(4902));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 245,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 22, 16, 46, 131, DateTimeKind.Utc).AddTicks(4903));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 246,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 22, 16, 46, 131, DateTimeKind.Utc).AddTicks(4904));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 247,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 22, 16, 46, 131, DateTimeKind.Utc).AddTicks(4905));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 248,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 22, 16, 46, 131, DateTimeKind.Utc).AddTicks(4905));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 249,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 22, 16, 46, 131, DateTimeKind.Utc).AddTicks(4906));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 250,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 22, 16, 46, 131, DateTimeKind.Utc).AddTicks(4907));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 251,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 22, 16, 46, 131, DateTimeKind.Utc).AddTicks(4908));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 252,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 22, 16, 46, 131, DateTimeKind.Utc).AddTicks(4909));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 253,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 22, 16, 46, 131, DateTimeKind.Utc).AddTicks(4910));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 254,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 22, 16, 46, 131, DateTimeKind.Utc).AddTicks(4911));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 255,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 22, 16, 46, 131, DateTimeKind.Utc).AddTicks(4912));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 256,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 22, 16, 46, 131, DateTimeKind.Utc).AddTicks(4913));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 257,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 22, 16, 46, 131, DateTimeKind.Utc).AddTicks(4913));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 258,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 22, 16, 46, 131, DateTimeKind.Utc).AddTicks(4954));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 259,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 22, 16, 46, 131, DateTimeKind.Utc).AddTicks(4956));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 260,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 22, 16, 46, 131, DateTimeKind.Utc).AddTicks(4957));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 261,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 22, 16, 46, 131, DateTimeKind.Utc).AddTicks(4958));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 262,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 22, 16, 46, 131, DateTimeKind.Utc).AddTicks(4959));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 263,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 22, 16, 46, 131, DateTimeKind.Utc).AddTicks(4960));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 264,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 22, 16, 46, 131, DateTimeKind.Utc).AddTicks(4961));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 265,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 22, 16, 46, 131, DateTimeKind.Utc).AddTicks(4962));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 266,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 22, 16, 46, 131, DateTimeKind.Utc).AddTicks(4962));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 267,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 22, 16, 46, 131, DateTimeKind.Utc).AddTicks(4963));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 268,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 22, 16, 46, 131, DateTimeKind.Utc).AddTicks(4964));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 269,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 22, 16, 46, 131, DateTimeKind.Utc).AddTicks(4965));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 270,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 22, 16, 46, 131, DateTimeKind.Utc).AddTicks(4966));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 271,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 22, 16, 46, 131, DateTimeKind.Utc).AddTicks(4967));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 272,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 22, 16, 46, 131, DateTimeKind.Utc).AddTicks(4970));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 273,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 22, 16, 46, 131, DateTimeKind.Utc).AddTicks(4971));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 274,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 22, 16, 46, 131, DateTimeKind.Utc).AddTicks(4973));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 275,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 22, 16, 46, 131, DateTimeKind.Utc).AddTicks(4975));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 276,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 22, 16, 46, 131, DateTimeKind.Utc).AddTicks(4976));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 277,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 22, 16, 46, 131, DateTimeKind.Utc).AddTicks(4977));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 278,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 22, 16, 46, 131, DateTimeKind.Utc).AddTicks(4978));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 279,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 22, 16, 46, 131, DateTimeKind.Utc).AddTicks(4979));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 280,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 22, 16, 46, 131, DateTimeKind.Utc).AddTicks(4979));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 281,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 22, 16, 46, 131, DateTimeKind.Utc).AddTicks(4980));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 282,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 22, 16, 46, 131, DateTimeKind.Utc).AddTicks(4981));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 283,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 22, 16, 46, 131, DateTimeKind.Utc).AddTicks(5002));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 284,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 22, 16, 46, 131, DateTimeKind.Utc).AddTicks(5004));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 285,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 22, 16, 46, 131, DateTimeKind.Utc).AddTicks(5005));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 286,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 22, 16, 46, 131, DateTimeKind.Utc).AddTicks(5006));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 287,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 22, 16, 46, 131, DateTimeKind.Utc).AddTicks(5007));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 288,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 22, 16, 46, 131, DateTimeKind.Utc).AddTicks(5008));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 289,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 22, 16, 46, 131, DateTimeKind.Utc).AddTicks(5009));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 290,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 22, 16, 46, 131, DateTimeKind.Utc).AddTicks(5009));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 291,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 22, 16, 46, 131, DateTimeKind.Utc).AddTicks(5010));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 292,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 22, 16, 46, 131, DateTimeKind.Utc).AddTicks(5011));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 293,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 22, 16, 46, 131, DateTimeKind.Utc).AddTicks(5012));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 294,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 22, 16, 46, 131, DateTimeKind.Utc).AddTicks(5013));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 295,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 22, 16, 46, 131, DateTimeKind.Utc).AddTicks(5014));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 296,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 22, 16, 46, 131, DateTimeKind.Utc).AddTicks(5015));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 297,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 22, 16, 46, 131, DateTimeKind.Utc).AddTicks(5016));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 298,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 22, 16, 46, 131, DateTimeKind.Utc).AddTicks(5017));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 299,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 22, 16, 46, 131, DateTimeKind.Utc).AddTicks(5018));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 300,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 22, 16, 46, 131, DateTimeKind.Utc).AddTicks(5019));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 301,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 22, 16, 46, 131, DateTimeKind.Utc).AddTicks(5019));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 302,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 22, 16, 46, 131, DateTimeKind.Utc).AddTicks(5022));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 303,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 22, 16, 46, 131, DateTimeKind.Utc).AddTicks(5024));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 304,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 22, 16, 46, 131, DateTimeKind.Utc).AddTicks(5025));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 305,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 22, 16, 46, 131, DateTimeKind.Utc).AddTicks(5025));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 306,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 22, 16, 46, 131, DateTimeKind.Utc).AddTicks(5026));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 307,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 22, 16, 46, 131, DateTimeKind.Utc).AddTicks(5027));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 308,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 22, 16, 46, 131, DateTimeKind.Utc).AddTicks(5028));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 309,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 22, 16, 46, 131, DateTimeKind.Utc).AddTicks(5029));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 310,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 22, 16, 46, 131, DateTimeKind.Utc).AddTicks(5030));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 311,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 22, 16, 46, 131, DateTimeKind.Utc).AddTicks(5031));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 312,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 22, 16, 46, 131, DateTimeKind.Utc).AddTicks(5032));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 313,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 22, 16, 46, 131, DateTimeKind.Utc).AddTicks(5033));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 314,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 22, 16, 46, 131, DateTimeKind.Utc).AddTicks(5034));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 315,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 22, 16, 46, 131, DateTimeKind.Utc).AddTicks(5035));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 316,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 22, 16, 46, 131, DateTimeKind.Utc).AddTicks(5036));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 317,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 22, 16, 46, 131, DateTimeKind.Utc).AddTicks(5037));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 318,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 22, 16, 46, 131, DateTimeKind.Utc).AddTicks(5059));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 319,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 22, 16, 46, 131, DateTimeKind.Utc).AddTicks(5060));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 320,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 22, 16, 46, 131, DateTimeKind.Utc).AddTicks(5061));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 321,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 22, 16, 46, 131, DateTimeKind.Utc).AddTicks(5062));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 322,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 22, 16, 46, 131, DateTimeKind.Utc).AddTicks(5062));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 323,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 22, 16, 46, 131, DateTimeKind.Utc).AddTicks(5064));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 324,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 22, 16, 46, 131, DateTimeKind.Utc).AddTicks(5065));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 325,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 22, 16, 46, 131, DateTimeKind.Utc).AddTicks(5065));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 326,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 22, 16, 46, 131, DateTimeKind.Utc).AddTicks(5066));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 327,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 22, 16, 46, 131, DateTimeKind.Utc).AddTicks(5103));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 328,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 22, 16, 46, 131, DateTimeKind.Utc).AddTicks(5104));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 329,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 22, 16, 46, 131, DateTimeKind.Utc).AddTicks(5105));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 330,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 22, 16, 46, 131, DateTimeKind.Utc).AddTicks(5106));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 331,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 22, 16, 46, 131, DateTimeKind.Utc).AddTicks(5107));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 332,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 22, 16, 46, 131, DateTimeKind.Utc).AddTicks(5108));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 333,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 22, 16, 46, 131, DateTimeKind.Utc).AddTicks(5109));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 334,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 22, 16, 46, 131, DateTimeKind.Utc).AddTicks(5110));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 335,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 22, 16, 46, 131, DateTimeKind.Utc).AddTicks(5149));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 336,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 22, 16, 46, 131, DateTimeKind.Utc).AddTicks(5150));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 337,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 22, 16, 46, 131, DateTimeKind.Utc).AddTicks(5151));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 338,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 22, 16, 46, 131, DateTimeKind.Utc).AddTicks(5153));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 339,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 22, 16, 46, 131, DateTimeKind.Utc).AddTicks(5154));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 340,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 22, 16, 46, 131, DateTimeKind.Utc).AddTicks(5155));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 341,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 22, 16, 46, 131, DateTimeKind.Utc).AddTicks(5156));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 342,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 22, 16, 46, 131, DateTimeKind.Utc).AddTicks(5157));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 343,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 22, 16, 46, 131, DateTimeKind.Utc).AddTicks(5158));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 344,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 22, 16, 46, 131, DateTimeKind.Utc).AddTicks(5158));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 345,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 22, 16, 46, 131, DateTimeKind.Utc).AddTicks(5159));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 346,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 22, 16, 46, 131, DateTimeKind.Utc).AddTicks(5160));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 347,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 22, 16, 46, 131, DateTimeKind.Utc).AddTicks(5161));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 348,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 22, 16, 46, 131, DateTimeKind.Utc).AddTicks(5162));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 349,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 22, 16, 46, 131, DateTimeKind.Utc).AddTicks(5163));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 350,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 22, 16, 46, 131, DateTimeKind.Utc).AddTicks(5164));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 351,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 22, 16, 46, 131, DateTimeKind.Utc).AddTicks(5165));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 352,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 22, 16, 46, 131, DateTimeKind.Utc).AddTicks(5165));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 353,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 22, 16, 46, 131, DateTimeKind.Utc).AddTicks(5166));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 354,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 22, 16, 46, 131, DateTimeKind.Utc).AddTicks(5167));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 355,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 22, 16, 46, 131, DateTimeKind.Utc).AddTicks(5168));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 356,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 22, 16, 46, 131, DateTimeKind.Utc).AddTicks(5169));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 357,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 22, 16, 46, 131, DateTimeKind.Utc).AddTicks(5170));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 358,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 22, 16, 46, 131, DateTimeKind.Utc).AddTicks(5171));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 359,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 22, 16, 46, 131, DateTimeKind.Utc).AddTicks(5172));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 360,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 22, 16, 46, 131, DateTimeKind.Utc).AddTicks(5173));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 361,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 22, 16, 46, 131, DateTimeKind.Utc).AddTicks(5175));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 362,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 22, 16, 46, 131, DateTimeKind.Utc).AddTicks(5177));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 363,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 22, 16, 46, 131, DateTimeKind.Utc).AddTicks(5178));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 364,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 22, 16, 46, 131, DateTimeKind.Utc).AddTicks(5178));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 365,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 22, 16, 46, 131, DateTimeKind.Utc).AddTicks(5179));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 366,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 22, 16, 46, 131, DateTimeKind.Utc).AddTicks(5180));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 367,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 22, 16, 46, 131, DateTimeKind.Utc).AddTicks(5181));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 368,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 22, 16, 46, 131, DateTimeKind.Utc).AddTicks(5182));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 369,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 22, 16, 46, 131, DateTimeKind.Utc).AddTicks(5183));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 370,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 22, 16, 46, 131, DateTimeKind.Utc).AddTicks(5184));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 371,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 22, 16, 46, 131, DateTimeKind.Utc).AddTicks(5215));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 372,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 22, 16, 46, 131, DateTimeKind.Utc).AddTicks(5216));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 373,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 22, 16, 46, 131, DateTimeKind.Utc).AddTicks(5216));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 374,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 22, 16, 46, 131, DateTimeKind.Utc).AddTicks(5217));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 375,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 22, 16, 46, 131, DateTimeKind.Utc).AddTicks(5218));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 376,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 22, 16, 46, 131, DateTimeKind.Utc).AddTicks(5219));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 377,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 22, 16, 46, 131, DateTimeKind.Utc).AddTicks(5220));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 378,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 22, 16, 46, 131, DateTimeKind.Utc).AddTicks(5221));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 379,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 22, 16, 46, 131, DateTimeKind.Utc).AddTicks(5222));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 380,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 22, 16, 46, 131, DateTimeKind.Utc).AddTicks(5223));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 381,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 22, 16, 46, 131, DateTimeKind.Utc).AddTicks(5223));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 382,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 22, 16, 46, 131, DateTimeKind.Utc).AddTicks(5224));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 383,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 22, 16, 46, 131, DateTimeKind.Utc).AddTicks(5225));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 384,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 22, 16, 46, 131, DateTimeKind.Utc).AddTicks(5226));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 385,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 22, 16, 46, 131, DateTimeKind.Utc).AddTicks(5227));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 386,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 22, 16, 46, 131, DateTimeKind.Utc).AddTicks(5228));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 387,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 22, 16, 46, 131, DateTimeKind.Utc).AddTicks(5229));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 388,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 22, 16, 46, 131, DateTimeKind.Utc).AddTicks(5230));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 389,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 22, 16, 46, 131, DateTimeKind.Utc).AddTicks(5231));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 390,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 22, 16, 46, 131, DateTimeKind.Utc).AddTicks(5232));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 391,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 22, 16, 46, 131, DateTimeKind.Utc).AddTicks(5233));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 392,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 22, 16, 46, 131, DateTimeKind.Utc).AddTicks(5234));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 393,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 22, 16, 46, 131, DateTimeKind.Utc).AddTicks(5235));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 394,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 22, 16, 46, 131, DateTimeKind.Utc).AddTicks(5236));

            migrationBuilder.UpdateData(
                table: "OptionTranslations",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 22, 16, 46, 141, DateTimeKind.Utc).AddTicks(3184));

            migrationBuilder.UpdateData(
                table: "OptionTranslations",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 22, 16, 46, 141, DateTimeKind.Utc).AddTicks(3187));

            migrationBuilder.UpdateData(
                table: "OptionTranslations",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 22, 16, 46, 141, DateTimeKind.Utc).AddTicks(3189));

            migrationBuilder.UpdateData(
                table: "OptionTranslations",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 22, 16, 46, 141, DateTimeKind.Utc).AddTicks(3190));

            migrationBuilder.UpdateData(
                table: "OptionTranslations",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 22, 16, 46, 141, DateTimeKind.Utc).AddTicks(3192));

            migrationBuilder.UpdateData(
                table: "OptionTranslations",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 22, 16, 46, 141, DateTimeKind.Utc).AddTicks(3193));

            migrationBuilder.UpdateData(
                table: "OptionTranslations",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 22, 16, 46, 141, DateTimeKind.Utc).AddTicks(3194));

            migrationBuilder.UpdateData(
                table: "OptionTranslations",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 22, 16, 46, 141, DateTimeKind.Utc).AddTicks(3195));

            migrationBuilder.UpdateData(
                table: "OptionTranslations",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 22, 16, 46, 141, DateTimeKind.Utc).AddTicks(3197));

            migrationBuilder.UpdateData(
                table: "OptionTranslations",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 22, 16, 46, 141, DateTimeKind.Utc).AddTicks(3198));

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 22, 16, 46, 140, DateTimeKind.Utc).AddTicks(6963));

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 22, 16, 46, 140, DateTimeKind.Utc).AddTicks(6967));

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 22, 16, 46, 140, DateTimeKind.Utc).AddTicks(6969));

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 22, 16, 46, 140, DateTimeKind.Utc).AddTicks(6971));

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 22, 16, 46, 140, DateTimeKind.Utc).AddTicks(6973));

            migrationBuilder.UpdateData(
                table: "ProductOptions",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 22, 16, 46, 144, DateTimeKind.Utc).AddTicks(2135));

            migrationBuilder.UpdateData(
                table: "ProductOptions",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 22, 16, 46, 144, DateTimeKind.Utc).AddTicks(2139));

            migrationBuilder.UpdateData(
                table: "ProductOptions",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 22, 16, 46, 144, DateTimeKind.Utc).AddTicks(2141));

            migrationBuilder.UpdateData(
                table: "ProductOptions",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 22, 16, 46, 144, DateTimeKind.Utc).AddTicks(2145));

            migrationBuilder.UpdateData(
                table: "ProductOptions",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 22, 16, 46, 144, DateTimeKind.Utc).AddTicks(2147));

            migrationBuilder.UpdateData(
                table: "ProductOptions",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 22, 16, 46, 144, DateTimeKind.Utc).AddTicks(2149));

            migrationBuilder.UpdateData(
                table: "ProductOptions",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 22, 16, 46, 144, DateTimeKind.Utc).AddTicks(2151));

            migrationBuilder.UpdateData(
                table: "ProductOptions",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 22, 16, 46, 144, DateTimeKind.Utc).AddTicks(2152));

            migrationBuilder.UpdateData(
                table: "ProductOptions",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 22, 16, 46, 144, DateTimeKind.Utc).AddTicks(2154));

            migrationBuilder.UpdateData(
                table: "ProductOptions",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 22, 16, 46, 144, DateTimeKind.Utc).AddTicks(2156));

            migrationBuilder.UpdateData(
                table: "ProductOptions",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 22, 16, 46, 144, DateTimeKind.Utc).AddTicks(2158));

            migrationBuilder.UpdateData(
                table: "ProductOptions",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 22, 16, 46, 144, DateTimeKind.Utc).AddTicks(2160));

            migrationBuilder.UpdateData(
                table: "ProductOptions",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 22, 16, 46, 144, DateTimeKind.Utc).AddTicks(2161));

            migrationBuilder.UpdateData(
                table: "ProductOptions",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 22, 16, 46, 144, DateTimeKind.Utc).AddTicks(2163));

            migrationBuilder.UpdateData(
                table: "ProductOptions",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 22, 16, 46, 144, DateTimeKind.Utc).AddTicks(2178));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 22, 16, 46, 142, DateTimeKind.Utc).AddTicks(5958));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 22, 16, 46, 142, DateTimeKind.Utc).AddTicks(5962));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 22, 16, 46, 142, DateTimeKind.Utc).AddTicks(5966));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 22, 16, 46, 142, DateTimeKind.Utc).AddTicks(5969));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 22, 16, 46, 142, DateTimeKind.Utc).AddTicks(5972));

            migrationBuilder.UpdateData(
                table: "Trademarks",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 22, 16, 46, 145, DateTimeKind.Utc).AddTicks(6655));

            migrationBuilder.UpdateData(
                table: "Trademarks",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 22, 16, 46, 145, DateTimeKind.Utc).AddTicks(6658));

            migrationBuilder.UpdateData(
                table: "Trademarks",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 22, 16, 46, 145, DateTimeKind.Utc).AddTicks(6661));

            migrationBuilder.UpdateData(
                table: "Trademarks",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 22, 16, 46, 145, DateTimeKind.Utc).AddTicks(6692));

            migrationBuilder.UpdateData(
                table: "Trademarks",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 22, 16, 46, 145, DateTimeKind.Utc).AddTicks(6695));

            migrationBuilder.UpdateData(
                table: "Variants",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 22, 16, 46, 147, DateTimeKind.Utc).AddTicks(3868));

            migrationBuilder.UpdateData(
                table: "Variants",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 22, 16, 46, 147, DateTimeKind.Utc).AddTicks(3871));

            migrationBuilder.UpdateData(
                table: "Variants",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 22, 16, 46, 147, DateTimeKind.Utc).AddTicks(3873));

            migrationBuilder.UpdateData(
                table: "Variants",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 22, 16, 46, 147, DateTimeKind.Utc).AddTicks(3875));

            migrationBuilder.UpdateData(
                table: "Variants",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 22, 16, 46, 147, DateTimeKind.Utc).AddTicks(3877));

            migrationBuilder.UpdateData(
                table: "Variants",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 22, 16, 46, 147, DateTimeKind.Utc).AddTicks(3878));

            migrationBuilder.UpdateData(
                table: "Variants",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 22, 16, 46, 147, DateTimeKind.Utc).AddTicks(3880));

            migrationBuilder.UpdateData(
                table: "Variants",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 22, 16, 46, 147, DateTimeKind.Utc).AddTicks(3882));

            migrationBuilder.UpdateData(
                table: "Variants",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 22, 16, 46, 147, DateTimeKind.Utc).AddTicks(3883));

            migrationBuilder.InsertData(
                table: "DataSchemaFields",
                columns: new[] { "Id", "CreatedAt", "CreatedBy", "DataSchemaId", "DefaultValue", "Description", "FieldKey", "FieldName", "IsActive", "IsFilterable", "IsRequired", "IsSortable", "OptionsJson", "Placeholder", "ShowInDetails", "ShowInListing", "SortOrder", "Status", "Type", "Unit", "UpdatedAt", "UpdatedBy", "ValidationRules" },
                values: new object[,]
                {
                    { 1, new DateTime(2025, 11, 6, 22, 16, 46, 136, DateTimeKind.Utc).AddTicks(9411), null, 2, null, "Internal storage capacity", "storage_gb", "Storage", true, true, true, true, "[{\"value\":\"64\",\"label\":\"64 GB\"},{\"value\":\"128\",\"label\":\"128 GB\"},{\"value\":\"256\",\"label\":\"256 GB\"},{\"value\":\"512\",\"label\":\"512 GB\"},{\"value\":\"1024\",\"label\":\"1 TB\"}]", null, true, true, 1, 1, 14, "GB", null, null, null },
                    { 2, new DateTime(2025, 11, 6, 22, 16, 46, 136, DateTimeKind.Utc).AddTicks(9416), null, 2, null, "Display screen size", "screen_size", "Screen Size", true, true, true, true, null, null, true, true, 2, 1, 3, "inches", null, null, "{\"min\":3.0,\"max\":10.0,\"step\":0.1}" }
                });

            migrationBuilder.InsertData(
                table: "DataSchemaFields",
                columns: new[] { "Id", "CreatedAt", "CreatedBy", "DataSchemaId", "DefaultValue", "Description", "FieldKey", "FieldName", "IsActive", "IsFilterable", "OptionsJson", "Placeholder", "ShowInDetails", "ShowInListing", "SortOrder", "Status", "Type", "Unit", "UpdatedAt", "UpdatedBy", "ValidationRules" },
                values: new object[] { 3, new DateTime(2025, 11, 6, 22, 16, 46, 136, DateTimeKind.Utc).AddTicks(9419), null, 2, null, "Display technology type", "screen_type", "Screen Type", true, true, "[{\"value\":\"LCD\",\"label\":\"LCD\"},{\"value\":\"OLED\",\"label\":\"OLED\"},{\"value\":\"AMOLED\",\"label\":\"AMOLED\"},{\"value\":\"Super AMOLED\",\"label\":\"Super AMOLED\"},{\"value\":\"IPS\",\"label\":\"IPS\"}]", null, true, true, 3, 1, 14, null, null, null, null });

            migrationBuilder.InsertData(
                table: "DataSchemaFields",
                columns: new[] { "Id", "CreatedAt", "CreatedBy", "DataSchemaId", "DefaultValue", "Description", "FieldKey", "FieldName", "IsActive", "IsFilterable", "IsSortable", "OptionsJson", "Placeholder", "ShowInDetails", "SortOrder", "Status", "Type", "Unit", "UpdatedAt", "UpdatedBy", "ValidationRules" },
                values: new object[] { 4, new DateTime(2025, 11, 6, 22, 16, 46, 136, DateTimeKind.Utc).AddTicks(9423), null, 2, null, "Maximum screen brightness", "brightness", "Brightness", true, true, true, null, null, true, 4, 1, 3, "nits", null, null, "{\"min\":100,\"max\":3000}" });

            migrationBuilder.InsertData(
                table: "DataSchemaFields",
                columns: new[] { "Id", "CreatedAt", "CreatedBy", "DataSchemaId", "DefaultValue", "Description", "FieldKey", "FieldName", "IsActive", "IsFilterable", "IsRequired", "IsSortable", "OptionsJson", "Placeholder", "ShowInDetails", "ShowInListing", "SortOrder", "Status", "Type", "Unit", "UpdatedAt", "UpdatedBy", "ValidationRules" },
                values: new object[] { 5, new DateTime(2025, 11, 6, 22, 16, 46, 136, DateTimeKind.Utc).AddTicks(9426), null, 2, null, "Random Access Memory", "ram_gb", "RAM", true, true, true, true, "[{\"value\":\"2\",\"label\":\"2 GB\"},{\"value\":\"3\",\"label\":\"3 GB\"},{\"value\":\"4\",\"label\":\"4 GB\"},{\"value\":\"6\",\"label\":\"6 GB\"},{\"value\":\"8\",\"label\":\"8 GB\"},{\"value\":\"12\",\"label\":\"12 GB\"},{\"value\":\"16\",\"label\":\"16 GB\"}]", null, true, true, 5, 1, 14, "GB", null, null, null });

            migrationBuilder.InsertData(
                table: "DataSchemaFields",
                columns: new[] { "Id", "CreatedAt", "CreatedBy", "DataSchemaId", "DefaultValue", "Description", "FieldKey", "FieldName", "IsActive", "IsFilterable", "IsSortable", "OptionsJson", "Placeholder", "ShowInDetails", "ShowInListing", "SortOrder", "Status", "Type", "Unit", "UpdatedAt", "UpdatedBy", "ValidationRules" },
                values: new object[] { 6, new DateTime(2025, 11, 6, 22, 16, 46, 136, DateTimeKind.Utc).AddTicks(9428), null, 2, null, "Battery capacity in mAh", "battery_mah", "Battery Capacity", true, true, true, null, null, true, true, 6, 1, 3, "mAh", null, null, "{\"min\":1000,\"max\":10000}" });

            migrationBuilder.CreateIndex(
                name: "IX_DataSchemaFields_FieldName",
                table: "DataSchemaFields",
                column: "FieldName");

            migrationBuilder.CreateIndex(
                name: "IX_DataSchemaFields_IsActive",
                table: "DataSchemaFields",
                column: "IsActive");

            migrationBuilder.CreateIndex(
                name: "IX_DataSchemaFields_IsFilterable",
                table: "DataSchemaFields",
                column: "IsFilterable");

            migrationBuilder.CreateIndex(
                name: "IX_DataSchemaFields_IsSortable",
                table: "DataSchemaFields",
                column: "IsSortable");

            migrationBuilder.CreateIndex(
                name: "IX_DataSchemaFields_SchemaId_FieldKey",
                table: "DataSchemaFields",
                columns: new[] { "DataSchemaId", "FieldKey" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_DataSchemaFields_SortOrder",
                table: "DataSchemaFields",
                column: "SortOrder");

            migrationBuilder.CreateIndex(
                name: "IX_DataSchemaFields_Type",
                table: "DataSchemaFields",
                column: "Type");

            migrationBuilder.CreateIndex(
                name: "IX_DataSchemaFieldTranslations_DataSchemaFieldId",
                table: "DataSchemaFieldTranslations",
                column: "DataSchemaFieldId");

            migrationBuilder.CreateIndex(
                name: "IX_DataSchemaFieldTranslations_Field_Language",
                table: "DataSchemaFieldTranslations",
                columns: new[] { "DataSchemaFieldId", "LanguageId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_DataSchemaFieldTranslations_LanguageId",
                table: "DataSchemaFieldTranslations",
                column: "LanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_DataSchemaFieldValues_BooleanValue",
                table: "DataSchemaFieldValues",
                column: "BooleanValue");

            migrationBuilder.CreateIndex(
                name: "IX_DataSchemaFieldValues_DateValue",
                table: "DataSchemaFieldValues",
                column: "DateValue");

            migrationBuilder.CreateIndex(
                name: "IX_DataSchemaFieldValues_FieldId",
                table: "DataSchemaFieldValues",
                column: "FieldId");

            migrationBuilder.CreateIndex(
                name: "IX_DataSchemaFieldValues_NumericValue",
                table: "DataSchemaFieldValues",
                column: "NumericValue");

            migrationBuilder.CreateIndex(
                name: "IX_DataSchemaFieldValues_Product_Schema_Field",
                table: "DataSchemaFieldValues",
                columns: new[] { "ProductId", "SchemaId", "FieldId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_DataSchemaFieldValues_ProductId",
                table: "DataSchemaFieldValues",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_DataSchemaFieldValues_SchemaId",
                table: "DataSchemaFieldValues",
                column: "SchemaId");

            migrationBuilder.CreateIndex(
                name: "IX_DataSchemaFieldValues_SortOrder",
                table: "DataSchemaFieldValues",
                column: "SortOrder");

            migrationBuilder.CreateIndex(
                name: "IX_DataSchemaFieldValueTranslations_DataSchemaFieldValueId",
                table: "DataSchemaFieldValueTranslations",
                column: "DataSchemaFieldValueId");

            migrationBuilder.CreateIndex(
                name: "IX_DataSchemaFieldValueTranslations_LanguageId",
                table: "DataSchemaFieldValueTranslations",
                column: "LanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_DataSchemaFieldValueTranslations_Value_Language",
                table: "DataSchemaFieldValueTranslations",
                columns: new[] { "DataSchemaFieldValueId", "LanguageId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_DataSchemas_Category",
                table: "DataSchemas",
                column: "Category");

            migrationBuilder.CreateIndex(
                name: "IX_DataSchemas_IsActive",
                table: "DataSchemas",
                column: "IsActive");

            migrationBuilder.CreateIndex(
                name: "IX_DataSchemas_Key",
                table: "DataSchemas",
                column: "Key",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_DataSchemas_Name",
                table: "DataSchemas",
                column: "Name");

            migrationBuilder.CreateIndex(
                name: "IX_DataSchemas_SortOrder",
                table: "DataSchemas",
                column: "SortOrder");

            migrationBuilder.CreateIndex(
                name: "IX_DataSchemas_Status",
                table: "DataSchemas",
                column: "Status");

            migrationBuilder.CreateIndex(
                name: "IX_DataSchemaTranslations_DataSchemaId",
                table: "DataSchemaTranslations",
                column: "DataSchemaId");

            migrationBuilder.CreateIndex(
                name: "IX_DataSchemaTranslations_LanguageId",
                table: "DataSchemaTranslations",
                column: "LanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_DataSchemaTranslations_Schema_Language",
                table: "DataSchemaTranslations",
                columns: new[] { "DataSchemaId", "LanguageId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ProductDataSchemas_IsActive",
                table: "ProductDataSchemas",
                column: "IsActive");

            migrationBuilder.CreateIndex(
                name: "IX_ProductDataSchemas_IsPrimary",
                table: "ProductDataSchemas",
                column: "IsPrimary");

            migrationBuilder.CreateIndex(
                name: "IX_ProductDataSchemas_Product_Schema",
                table: "ProductDataSchemas",
                columns: new[] { "ProductId", "SchemaId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ProductDataSchemas_ProductId",
                table: "ProductDataSchemas",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductDataSchemas_SchemaId",
                table: "ProductDataSchemas",
                column: "SchemaId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductDataSchemas_SortOrder",
                table: "ProductDataSchemas",
                column: "SortOrder");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DataSchemaFieldTranslations");

            migrationBuilder.DropTable(
                name: "DataSchemaFieldValueTranslations");

            migrationBuilder.DropTable(
                name: "DataSchemaTranslations");

            migrationBuilder.DropTable(
                name: "ProductDataSchemas");

            migrationBuilder.DropTable(
                name: "DataSchemaFieldValues");

            migrationBuilder.DropTable(
                name: "DataSchemaFields");

            migrationBuilder.DropTable(
                name: "DataSchemas");

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 21, 56, 18, 428, DateTimeKind.Utc).AddTicks(8129));

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 21, 56, 18, 428, DateTimeKind.Utc).AddTicks(8135));

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 21, 56, 18, 428, DateTimeKind.Utc).AddTicks(8138));

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 21, 56, 18, 428, DateTimeKind.Utc).AddTicks(8140));

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 21, 56, 18, 428, DateTimeKind.Utc).AddTicks(8142));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 21, 56, 18, 429, DateTimeKind.Utc).AddTicks(6585));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 21, 56, 18, 429, DateTimeKind.Utc).AddTicks(6592));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 21, 56, 18, 429, DateTimeKind.Utc).AddTicks(6593));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 21, 56, 18, 429, DateTimeKind.Utc).AddTicks(6643));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 21, 56, 18, 429, DateTimeKind.Utc).AddTicks(6645));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 21, 56, 18, 429, DateTimeKind.Utc).AddTicks(6649));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 21, 56, 18, 429, DateTimeKind.Utc).AddTicks(6650));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 21, 56, 18, 429, DateTimeKind.Utc).AddTicks(6651));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 21, 56, 18, 429, DateTimeKind.Utc).AddTicks(6652));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 21, 56, 18, 429, DateTimeKind.Utc).AddTicks(6653));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 21, 56, 18, 429, DateTimeKind.Utc).AddTicks(6655));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 21, 56, 18, 429, DateTimeKind.Utc).AddTicks(6656));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 21, 56, 18, 429, DateTimeKind.Utc).AddTicks(6656));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 21, 56, 18, 429, DateTimeKind.Utc).AddTicks(6657));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 21, 56, 18, 429, DateTimeKind.Utc).AddTicks(6658));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 16,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 21, 56, 18, 429, DateTimeKind.Utc).AddTicks(6659));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 17,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 21, 56, 18, 429, DateTimeKind.Utc).AddTicks(6660));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 18,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 21, 56, 18, 429, DateTimeKind.Utc).AddTicks(6661));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 19,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 21, 56, 18, 429, DateTimeKind.Utc).AddTicks(6662));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 20,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 21, 56, 18, 429, DateTimeKind.Utc).AddTicks(6663));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 21,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 21, 56, 18, 429, DateTimeKind.Utc).AddTicks(6671));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 22,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 21, 56, 18, 429, DateTimeKind.Utc).AddTicks(6672));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 23,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 21, 56, 18, 429, DateTimeKind.Utc).AddTicks(6673));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 24,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 21, 56, 18, 429, DateTimeKind.Utc).AddTicks(6674));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 25,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 21, 56, 18, 429, DateTimeKind.Utc).AddTicks(6674));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 26,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 21, 56, 18, 429, DateTimeKind.Utc).AddTicks(6676));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 27,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 21, 56, 18, 429, DateTimeKind.Utc).AddTicks(6677));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 28,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 21, 56, 18, 429, DateTimeKind.Utc).AddTicks(6677));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 29,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 21, 56, 18, 429, DateTimeKind.Utc).AddTicks(6678));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 30,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 21, 56, 18, 429, DateTimeKind.Utc).AddTicks(6689));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 31,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 21, 56, 18, 429, DateTimeKind.Utc).AddTicks(6690));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 32,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 21, 56, 18, 429, DateTimeKind.Utc).AddTicks(6691));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 33,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 21, 56, 18, 429, DateTimeKind.Utc).AddTicks(6692));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 34,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 21, 56, 18, 429, DateTimeKind.Utc).AddTicks(6694));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 35,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 21, 56, 18, 429, DateTimeKind.Utc).AddTicks(6694));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 36,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 21, 56, 18, 429, DateTimeKind.Utc).AddTicks(6695));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 37,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 21, 56, 18, 429, DateTimeKind.Utc).AddTicks(6718));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 38,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 21, 56, 18, 429, DateTimeKind.Utc).AddTicks(6719));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 39,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 21, 56, 18, 429, DateTimeKind.Utc).AddTicks(6722));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 40,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 21, 56, 18, 429, DateTimeKind.Utc).AddTicks(6724));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 41,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 21, 56, 18, 429, DateTimeKind.Utc).AddTicks(6725));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 42,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 21, 56, 18, 429, DateTimeKind.Utc).AddTicks(6726));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 43,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 21, 56, 18, 429, DateTimeKind.Utc).AddTicks(6727));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 44,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 21, 56, 18, 429, DateTimeKind.Utc).AddTicks(6728));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 45,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 21, 56, 18, 429, DateTimeKind.Utc).AddTicks(6729));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 46,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 21, 56, 18, 429, DateTimeKind.Utc).AddTicks(6730));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 47,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 21, 56, 18, 429, DateTimeKind.Utc).AddTicks(6731));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 48,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 21, 56, 18, 429, DateTimeKind.Utc).AddTicks(6731));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 49,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 21, 56, 18, 429, DateTimeKind.Utc).AddTicks(6732));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 50,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 21, 56, 18, 429, DateTimeKind.Utc).AddTicks(6733));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 51,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 21, 56, 18, 429, DateTimeKind.Utc).AddTicks(6734));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 52,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 21, 56, 18, 429, DateTimeKind.Utc).AddTicks(6735));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 53,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 21, 56, 18, 429, DateTimeKind.Utc).AddTicks(6736));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 54,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 21, 56, 18, 429, DateTimeKind.Utc).AddTicks(6738));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 55,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 21, 56, 18, 429, DateTimeKind.Utc).AddTicks(6739));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 56,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 21, 56, 18, 429, DateTimeKind.Utc).AddTicks(6740));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 57,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 21, 56, 18, 429, DateTimeKind.Utc).AddTicks(6741));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 58,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 21, 56, 18, 429, DateTimeKind.Utc).AddTicks(6742));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 59,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 21, 56, 18, 429, DateTimeKind.Utc).AddTicks(6743));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 60,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 21, 56, 18, 429, DateTimeKind.Utc).AddTicks(6744));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 61,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 21, 56, 18, 429, DateTimeKind.Utc).AddTicks(6745));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 62,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 21, 56, 18, 429, DateTimeKind.Utc).AddTicks(6746));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 63,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 21, 56, 18, 429, DateTimeKind.Utc).AddTicks(6746));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 64,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 21, 56, 18, 429, DateTimeKind.Utc).AddTicks(6747));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 65,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 21, 56, 18, 429, DateTimeKind.Utc).AddTicks(6748));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 66,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 21, 56, 18, 429, DateTimeKind.Utc).AddTicks(6750));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 67,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 21, 56, 18, 429, DateTimeKind.Utc).AddTicks(6751));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 68,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 21, 56, 18, 429, DateTimeKind.Utc).AddTicks(6752));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 69,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 21, 56, 18, 429, DateTimeKind.Utc).AddTicks(6813));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 70,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 21, 56, 18, 429, DateTimeKind.Utc).AddTicks(6817));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 71,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 21, 56, 18, 429, DateTimeKind.Utc).AddTicks(6818));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 72,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 21, 56, 18, 429, DateTimeKind.Utc).AddTicks(6819));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 73,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 21, 56, 18, 429, DateTimeKind.Utc).AddTicks(6820));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 74,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 21, 56, 18, 429, DateTimeKind.Utc).AddTicks(6821));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 75,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 21, 56, 18, 429, DateTimeKind.Utc).AddTicks(6822));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 76,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 21, 56, 18, 429, DateTimeKind.Utc).AddTicks(6823));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 77,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 21, 56, 18, 429, DateTimeKind.Utc).AddTicks(6824));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 78,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 21, 56, 18, 429, DateTimeKind.Utc).AddTicks(6824));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 79,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 21, 56, 18, 429, DateTimeKind.Utc).AddTicks(6825));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 80,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 21, 56, 18, 429, DateTimeKind.Utc).AddTicks(6828));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 81,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 21, 56, 18, 429, DateTimeKind.Utc).AddTicks(6829));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 82,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 21, 56, 18, 429, DateTimeKind.Utc).AddTicks(6830));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 83,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 21, 56, 18, 429, DateTimeKind.Utc).AddTicks(6831));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 84,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 21, 56, 18, 429, DateTimeKind.Utc).AddTicks(6831));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 85,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 21, 56, 18, 429, DateTimeKind.Utc).AddTicks(6832));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 86,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 21, 56, 18, 429, DateTimeKind.Utc).AddTicks(6833));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 87,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 21, 56, 18, 429, DateTimeKind.Utc).AddTicks(6834));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 88,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 21, 56, 18, 429, DateTimeKind.Utc).AddTicks(6835));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 89,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 21, 56, 18, 429, DateTimeKind.Utc).AddTicks(6836));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 90,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 21, 56, 18, 429, DateTimeKind.Utc).AddTicks(6837));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 91,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 21, 56, 18, 429, DateTimeKind.Utc).AddTicks(6838));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 92,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 21, 56, 18, 429, DateTimeKind.Utc).AddTicks(6839));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 93,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 21, 56, 18, 429, DateTimeKind.Utc).AddTicks(6840));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 94,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 21, 56, 18, 429, DateTimeKind.Utc).AddTicks(6841));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 95,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 21, 56, 18, 429, DateTimeKind.Utc).AddTicks(6842));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 96,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 21, 56, 18, 429, DateTimeKind.Utc).AddTicks(6843));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 97,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 21, 56, 18, 429, DateTimeKind.Utc).AddTicks(6844));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 98,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 21, 56, 18, 429, DateTimeKind.Utc).AddTicks(6845));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 99,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 21, 56, 18, 429, DateTimeKind.Utc).AddTicks(6845));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 100,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 21, 56, 18, 429, DateTimeKind.Utc).AddTicks(6846));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 101,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 21, 56, 18, 429, DateTimeKind.Utc).AddTicks(6847));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 102,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 21, 56, 18, 429, DateTimeKind.Utc).AddTicks(6848));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 103,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 21, 56, 18, 429, DateTimeKind.Utc).AddTicks(6849));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 104,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 21, 56, 18, 429, DateTimeKind.Utc).AddTicks(6850));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 105,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 21, 56, 18, 429, DateTimeKind.Utc).AddTicks(6891));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 106,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 21, 56, 18, 429, DateTimeKind.Utc).AddTicks(6892));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 107,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 21, 56, 18, 429, DateTimeKind.Utc).AddTicks(6893));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 108,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 21, 56, 18, 429, DateTimeKind.Utc).AddTicks(6894));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 109,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 21, 56, 18, 429, DateTimeKind.Utc).AddTicks(6896));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 110,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 21, 56, 18, 429, DateTimeKind.Utc).AddTicks(6898));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 111,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 21, 56, 18, 429, DateTimeKind.Utc).AddTicks(6900));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 112,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 21, 56, 18, 429, DateTimeKind.Utc).AddTicks(6902));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 113,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 21, 56, 18, 429, DateTimeKind.Utc).AddTicks(6903));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 114,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 21, 56, 18, 429, DateTimeKind.Utc).AddTicks(6904));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 115,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 21, 56, 18, 429, DateTimeKind.Utc).AddTicks(6904));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 116,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 21, 56, 18, 429, DateTimeKind.Utc).AddTicks(6905));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 117,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 21, 56, 18, 429, DateTimeKind.Utc).AddTicks(6906));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 118,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 21, 56, 18, 429, DateTimeKind.Utc).AddTicks(6907));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 119,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 21, 56, 18, 429, DateTimeKind.Utc).AddTicks(6908));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 120,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 21, 56, 18, 429, DateTimeKind.Utc).AddTicks(6909));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 121,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 21, 56, 18, 429, DateTimeKind.Utc).AddTicks(6910));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 122,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 21, 56, 18, 429, DateTimeKind.Utc).AddTicks(6910));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 123,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 21, 56, 18, 429, DateTimeKind.Utc).AddTicks(6911));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 124,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 21, 56, 18, 429, DateTimeKind.Utc).AddTicks(6912));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 125,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 21, 56, 18, 429, DateTimeKind.Utc).AddTicks(6913));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 126,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 21, 56, 18, 429, DateTimeKind.Utc).AddTicks(6914));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 127,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 21, 56, 18, 429, DateTimeKind.Utc).AddTicks(6915));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 128,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 21, 56, 18, 429, DateTimeKind.Utc).AddTicks(6916));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 129,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 21, 56, 18, 429, DateTimeKind.Utc).AddTicks(6917));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 130,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 21, 56, 18, 429, DateTimeKind.Utc).AddTicks(6919));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 131,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 21, 56, 18, 429, DateTimeKind.Utc).AddTicks(6951));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 132,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 21, 56, 18, 429, DateTimeKind.Utc).AddTicks(6952));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 133,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 21, 56, 18, 429, DateTimeKind.Utc).AddTicks(6954));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 134,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 21, 56, 18, 429, DateTimeKind.Utc).AddTicks(6954));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 135,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 21, 56, 18, 429, DateTimeKind.Utc).AddTicks(6955));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 136,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 21, 56, 18, 429, DateTimeKind.Utc).AddTicks(6956));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 137,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 21, 56, 18, 429, DateTimeKind.Utc).AddTicks(6957));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 138,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 21, 56, 18, 429, DateTimeKind.Utc).AddTicks(6958));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 139,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 21, 56, 18, 429, DateTimeKind.Utc).AddTicks(6961));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 140,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 21, 56, 18, 429, DateTimeKind.Utc).AddTicks(6962));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 141,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 21, 56, 18, 429, DateTimeKind.Utc).AddTicks(6963));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 142,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 21, 56, 18, 429, DateTimeKind.Utc).AddTicks(6964));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 143,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 21, 56, 18, 429, DateTimeKind.Utc).AddTicks(6965));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 144,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 21, 56, 18, 429, DateTimeKind.Utc).AddTicks(6966));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 145,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 21, 56, 18, 429, DateTimeKind.Utc).AddTicks(6967));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 146,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 21, 56, 18, 429, DateTimeKind.Utc).AddTicks(6968));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 147,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 21, 56, 18, 429, DateTimeKind.Utc).AddTicks(6969));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 148,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 21, 56, 18, 429, DateTimeKind.Utc).AddTicks(6970));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 149,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 21, 56, 18, 429, DateTimeKind.Utc).AddTicks(6970));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 150,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 21, 56, 18, 429, DateTimeKind.Utc).AddTicks(6971));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 151,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 21, 56, 18, 429, DateTimeKind.Utc).AddTicks(6972));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 152,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 21, 56, 18, 429, DateTimeKind.Utc).AddTicks(6973));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 153,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 21, 56, 18, 429, DateTimeKind.Utc).AddTicks(6974));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 154,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 21, 56, 18, 429, DateTimeKind.Utc).AddTicks(6975));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 155,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 21, 56, 18, 429, DateTimeKind.Utc).AddTicks(6976));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 156,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 21, 56, 18, 429, DateTimeKind.Utc).AddTicks(6977));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 157,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 21, 56, 18, 429, DateTimeKind.Utc).AddTicks(6978));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 158,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 21, 56, 18, 429, DateTimeKind.Utc).AddTicks(6978));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 159,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 21, 56, 18, 429, DateTimeKind.Utc).AddTicks(6979));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 160,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 21, 56, 18, 429, DateTimeKind.Utc).AddTicks(6980));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 161,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 21, 56, 18, 429, DateTimeKind.Utc).AddTicks(6981));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 162,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 21, 56, 18, 429, DateTimeKind.Utc).AddTicks(6982));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 163,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 21, 56, 18, 429, DateTimeKind.Utc).AddTicks(6983));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 164,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 21, 56, 18, 429, DateTimeKind.Utc).AddTicks(7063));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 165,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 21, 56, 18, 429, DateTimeKind.Utc).AddTicks(7066));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 166,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 21, 56, 18, 429, DateTimeKind.Utc).AddTicks(7067));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 167,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 21, 56, 18, 429, DateTimeKind.Utc).AddTicks(7068));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 168,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 21, 56, 18, 429, DateTimeKind.Utc).AddTicks(7068));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 169,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 21, 56, 18, 429, DateTimeKind.Utc).AddTicks(7070));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 170,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 21, 56, 18, 429, DateTimeKind.Utc).AddTicks(7070));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 171,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 21, 56, 18, 429, DateTimeKind.Utc).AddTicks(7071));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 172,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 21, 56, 18, 429, DateTimeKind.Utc).AddTicks(7072));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 173,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 21, 56, 18, 429, DateTimeKind.Utc).AddTicks(7073));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 174,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 21, 56, 18, 429, DateTimeKind.Utc).AddTicks(7073));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 175,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 21, 56, 18, 429, DateTimeKind.Utc).AddTicks(7074));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 176,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 21, 56, 18, 429, DateTimeKind.Utc).AddTicks(7075));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 177,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 21, 56, 18, 429, DateTimeKind.Utc).AddTicks(7076));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 178,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 21, 56, 18, 429, DateTimeKind.Utc).AddTicks(7077));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 179,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 21, 56, 18, 429, DateTimeKind.Utc).AddTicks(7078));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 180,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 21, 56, 18, 429, DateTimeKind.Utc).AddTicks(7079));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 181,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 21, 56, 18, 429, DateTimeKind.Utc).AddTicks(7079));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 182,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 21, 56, 18, 429, DateTimeKind.Utc).AddTicks(7080));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 183,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 21, 56, 18, 429, DateTimeKind.Utc).AddTicks(7081));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 184,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 21, 56, 18, 429, DateTimeKind.Utc).AddTicks(7082));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 185,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 21, 56, 18, 429, DateTimeKind.Utc).AddTicks(7083));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 186,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 21, 56, 18, 429, DateTimeKind.Utc).AddTicks(7084));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 187,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 21, 56, 18, 429, DateTimeKind.Utc).AddTicks(7085));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 188,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 21, 56, 18, 429, DateTimeKind.Utc).AddTicks(7086));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 189,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 21, 56, 18, 429, DateTimeKind.Utc).AddTicks(7086));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 190,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 21, 56, 18, 429, DateTimeKind.Utc).AddTicks(7087));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 191,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 21, 56, 18, 429, DateTimeKind.Utc).AddTicks(7088));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 192,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 21, 56, 18, 429, DateTimeKind.Utc).AddTicks(7089));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 193,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 21, 56, 18, 429, DateTimeKind.Utc).AddTicks(7090));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 194,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 21, 56, 18, 429, DateTimeKind.Utc).AddTicks(7090));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 195,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 21, 56, 18, 429, DateTimeKind.Utc).AddTicks(7091));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 196,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 21, 56, 18, 429, DateTimeKind.Utc).AddTicks(7092));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 197,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 21, 56, 18, 429, DateTimeKind.Utc).AddTicks(7093));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 198,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 21, 56, 18, 429, DateTimeKind.Utc).AddTicks(7093));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 199,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 21, 56, 18, 429, DateTimeKind.Utc).AddTicks(7095));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 200,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 21, 56, 18, 429, DateTimeKind.Utc).AddTicks(7095));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 201,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 21, 56, 18, 429, DateTimeKind.Utc).AddTicks(7096));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 202,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 21, 56, 18, 429, DateTimeKind.Utc).AddTicks(7185));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 203,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 21, 56, 18, 429, DateTimeKind.Utc).AddTicks(7187));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 204,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 21, 56, 18, 429, DateTimeKind.Utc).AddTicks(7188));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 205,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 21, 56, 18, 429, DateTimeKind.Utc).AddTicks(7189));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 206,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 21, 56, 18, 429, DateTimeKind.Utc).AddTicks(7190));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 207,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 21, 56, 18, 429, DateTimeKind.Utc).AddTicks(7191));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 208,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 21, 56, 18, 429, DateTimeKind.Utc).AddTicks(7192));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 209,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 21, 56, 18, 429, DateTimeKind.Utc).AddTicks(7192));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 210,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 21, 56, 18, 429, DateTimeKind.Utc).AddTicks(7193));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 211,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 21, 56, 18, 429, DateTimeKind.Utc).AddTicks(7194));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 212,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 21, 56, 18, 429, DateTimeKind.Utc).AddTicks(7195));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 213,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 21, 56, 18, 429, DateTimeKind.Utc).AddTicks(7196));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 214,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 21, 56, 18, 429, DateTimeKind.Utc).AddTicks(7196));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 215,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 21, 56, 18, 429, DateTimeKind.Utc).AddTicks(7197));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 216,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 21, 56, 18, 429, DateTimeKind.Utc).AddTicks(7198));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 217,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 21, 56, 18, 429, DateTimeKind.Utc).AddTicks(7201));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 218,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 21, 56, 18, 429, DateTimeKind.Utc).AddTicks(7202));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 219,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 21, 56, 18, 429, DateTimeKind.Utc).AddTicks(7203));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 220,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 21, 56, 18, 429, DateTimeKind.Utc).AddTicks(7204));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 221,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 21, 56, 18, 429, DateTimeKind.Utc).AddTicks(7204));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 222,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 21, 56, 18, 429, DateTimeKind.Utc).AddTicks(7205));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 223,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 21, 56, 18, 429, DateTimeKind.Utc).AddTicks(7206));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 224,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 21, 56, 18, 429, DateTimeKind.Utc).AddTicks(7207));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 225,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 21, 56, 18, 429, DateTimeKind.Utc).AddTicks(7208));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 226,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 21, 56, 18, 429, DateTimeKind.Utc).AddTicks(7209));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 227,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 21, 56, 18, 429, DateTimeKind.Utc).AddTicks(7209));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 228,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 21, 56, 18, 429, DateTimeKind.Utc).AddTicks(7210));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 229,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 21, 56, 18, 429, DateTimeKind.Utc).AddTicks(7211));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 230,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 21, 56, 18, 429, DateTimeKind.Utc).AddTicks(7212));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 231,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 21, 56, 18, 429, DateTimeKind.Utc).AddTicks(7213));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 232,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 21, 56, 18, 429, DateTimeKind.Utc).AddTicks(7214));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 233,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 21, 56, 18, 429, DateTimeKind.Utc).AddTicks(7216));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 234,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 21, 56, 18, 429, DateTimeKind.Utc).AddTicks(7217));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 235,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 21, 56, 18, 429, DateTimeKind.Utc).AddTicks(7218));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 236,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 21, 56, 18, 429, DateTimeKind.Utc).AddTicks(7219));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 237,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 21, 56, 18, 429, DateTimeKind.Utc).AddTicks(7220));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 238,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 21, 56, 18, 429, DateTimeKind.Utc).AddTicks(7221));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 239,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 21, 56, 18, 429, DateTimeKind.Utc).AddTicks(7281));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 240,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 21, 56, 18, 429, DateTimeKind.Utc).AddTicks(7282));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 241,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 21, 56, 18, 429, DateTimeKind.Utc).AddTicks(7282));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 242,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 21, 56, 18, 429, DateTimeKind.Utc).AddTicks(7283));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 243,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 21, 56, 18, 429, DateTimeKind.Utc).AddTicks(7286));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 244,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 21, 56, 18, 429, DateTimeKind.Utc).AddTicks(7287));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 245,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 21, 56, 18, 429, DateTimeKind.Utc).AddTicks(7289));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 246,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 21, 56, 18, 429, DateTimeKind.Utc).AddTicks(7289));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 247,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 21, 56, 18, 429, DateTimeKind.Utc).AddTicks(7290));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 248,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 21, 56, 18, 429, DateTimeKind.Utc).AddTicks(7291));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 249,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 21, 56, 18, 429, DateTimeKind.Utc).AddTicks(7292));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 250,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 21, 56, 18, 429, DateTimeKind.Utc).AddTicks(7293));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 251,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 21, 56, 18, 429, DateTimeKind.Utc).AddTicks(7294));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 252,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 21, 56, 18, 429, DateTimeKind.Utc).AddTicks(7295));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 253,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 21, 56, 18, 429, DateTimeKind.Utc).AddTicks(7296));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 254,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 21, 56, 18, 429, DateTimeKind.Utc).AddTicks(7297));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 255,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 21, 56, 18, 429, DateTimeKind.Utc).AddTicks(7297));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 256,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 21, 56, 18, 429, DateTimeKind.Utc).AddTicks(7298));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 257,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 21, 56, 18, 429, DateTimeKind.Utc).AddTicks(7299));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 258,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 21, 56, 18, 429, DateTimeKind.Utc).AddTicks(7356));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 259,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 21, 56, 18, 429, DateTimeKind.Utc).AddTicks(7358));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 260,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 21, 56, 18, 429, DateTimeKind.Utc).AddTicks(7358));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 261,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 21, 56, 18, 429, DateTimeKind.Utc).AddTicks(7359));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 262,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 21, 56, 18, 429, DateTimeKind.Utc).AddTicks(7360));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 263,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 21, 56, 18, 429, DateTimeKind.Utc).AddTicks(7361));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 264,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 21, 56, 18, 429, DateTimeKind.Utc).AddTicks(7362));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 265,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 21, 56, 18, 429, DateTimeKind.Utc).AddTicks(7363));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 266,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 21, 56, 18, 429, DateTimeKind.Utc).AddTicks(7364));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 267,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 21, 56, 18, 429, DateTimeKind.Utc).AddTicks(7364));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 268,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 21, 56, 18, 429, DateTimeKind.Utc).AddTicks(7365));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 269,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 21, 56, 18, 429, DateTimeKind.Utc).AddTicks(7366));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 270,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 21, 56, 18, 429, DateTimeKind.Utc).AddTicks(7367));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 271,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 21, 56, 18, 429, DateTimeKind.Utc).AddTicks(7368));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 272,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 21, 56, 18, 429, DateTimeKind.Utc).AddTicks(7370));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 273,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 21, 56, 18, 429, DateTimeKind.Utc).AddTicks(7371));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 274,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 21, 56, 18, 429, DateTimeKind.Utc).AddTicks(7374));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 275,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 21, 56, 18, 429, DateTimeKind.Utc).AddTicks(7375));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 276,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 21, 56, 18, 429, DateTimeKind.Utc).AddTicks(7376));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 277,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 21, 56, 18, 429, DateTimeKind.Utc).AddTicks(7377));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 278,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 21, 56, 18, 429, DateTimeKind.Utc).AddTicks(7378));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 279,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 21, 56, 18, 429, DateTimeKind.Utc).AddTicks(7379));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 280,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 21, 56, 18, 429, DateTimeKind.Utc).AddTicks(7380));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 281,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 21, 56, 18, 429, DateTimeKind.Utc).AddTicks(7381));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 282,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 21, 56, 18, 429, DateTimeKind.Utc).AddTicks(7382));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 283,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 21, 56, 18, 429, DateTimeKind.Utc).AddTicks(7382));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 284,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 21, 56, 18, 429, DateTimeKind.Utc).AddTicks(7383));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 285,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 21, 56, 18, 429, DateTimeKind.Utc).AddTicks(7384));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 286,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 21, 56, 18, 429, DateTimeKind.Utc).AddTicks(7385));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 287,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 21, 56, 18, 429, DateTimeKind.Utc).AddTicks(7386));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 288,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 21, 56, 18, 429, DateTimeKind.Utc).AddTicks(7386));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 289,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 21, 56, 18, 429, DateTimeKind.Utc).AddTicks(7387));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 290,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 21, 56, 18, 429, DateTimeKind.Utc).AddTicks(7388));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 291,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 21, 56, 18, 429, DateTimeKind.Utc).AddTicks(7409));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 292,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 21, 56, 18, 429, DateTimeKind.Utc).AddTicks(7410));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 293,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 21, 56, 18, 429, DateTimeKind.Utc).AddTicks(7411));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 294,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 21, 56, 18, 429, DateTimeKind.Utc).AddTicks(7411));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 295,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 21, 56, 18, 429, DateTimeKind.Utc).AddTicks(7412));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 296,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 21, 56, 18, 429, DateTimeKind.Utc).AddTicks(7413));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 297,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 21, 56, 18, 429, DateTimeKind.Utc).AddTicks(7414));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 298,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 21, 56, 18, 429, DateTimeKind.Utc).AddTicks(7415));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 299,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 21, 56, 18, 429, DateTimeKind.Utc).AddTicks(7416));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 300,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 21, 56, 18, 429, DateTimeKind.Utc).AddTicks(7416));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 301,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 21, 56, 18, 429, DateTimeKind.Utc).AddTicks(7417));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 302,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 21, 56, 18, 429, DateTimeKind.Utc).AddTicks(7420));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 303,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 21, 56, 18, 429, DateTimeKind.Utc).AddTicks(7421));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 304,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 21, 56, 18, 429, DateTimeKind.Utc).AddTicks(7422));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 305,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 21, 56, 18, 429, DateTimeKind.Utc).AddTicks(7423));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 306,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 21, 56, 18, 429, DateTimeKind.Utc).AddTicks(7424));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 307,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 21, 56, 18, 429, DateTimeKind.Utc).AddTicks(7425));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 308,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 21, 56, 18, 429, DateTimeKind.Utc).AddTicks(7426));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 309,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 21, 56, 18, 429, DateTimeKind.Utc).AddTicks(7426));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 310,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 21, 56, 18, 429, DateTimeKind.Utc).AddTicks(7427));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 311,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 21, 56, 18, 429, DateTimeKind.Utc).AddTicks(7428));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 312,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 21, 56, 18, 429, DateTimeKind.Utc).AddTicks(7429));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 313,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 21, 56, 18, 429, DateTimeKind.Utc).AddTicks(7430));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 314,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 21, 56, 18, 429, DateTimeKind.Utc).AddTicks(7431));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 315,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 21, 56, 18, 429, DateTimeKind.Utc).AddTicks(7431));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 316,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 21, 56, 18, 429, DateTimeKind.Utc).AddTicks(7432));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 317,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 21, 56, 18, 429, DateTimeKind.Utc).AddTicks(7433));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 318,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 21, 56, 18, 429, DateTimeKind.Utc).AddTicks(7434));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 319,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 21, 56, 18, 429, DateTimeKind.Utc).AddTicks(7435));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 320,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 21, 56, 18, 429, DateTimeKind.Utc).AddTicks(7436));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 321,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 21, 56, 18, 429, DateTimeKind.Utc).AddTicks(7436));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 322,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 21, 56, 18, 429, DateTimeKind.Utc).AddTicks(7437));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 323,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 21, 56, 18, 429, DateTimeKind.Utc).AddTicks(7438));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 324,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 21, 56, 18, 429, DateTimeKind.Utc).AddTicks(7439));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 325,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 21, 56, 18, 429, DateTimeKind.Utc).AddTicks(7440));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 326,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 21, 56, 18, 429, DateTimeKind.Utc).AddTicks(7462));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 327,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 21, 56, 18, 429, DateTimeKind.Utc).AddTicks(7495));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 328,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 21, 56, 18, 429, DateTimeKind.Utc).AddTicks(7497));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 329,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 21, 56, 18, 429, DateTimeKind.Utc).AddTicks(7497));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 330,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 21, 56, 18, 429, DateTimeKind.Utc).AddTicks(7498));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 331,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 21, 56, 18, 429, DateTimeKind.Utc).AddTicks(7499));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 332,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 21, 56, 18, 429, DateTimeKind.Utc).AddTicks(7500));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 333,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 21, 56, 18, 429, DateTimeKind.Utc).AddTicks(7501));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 334,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 21, 56, 18, 429, DateTimeKind.Utc).AddTicks(7502));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 335,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 21, 56, 18, 429, DateTimeKind.Utc).AddTicks(7503));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 336,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 21, 56, 18, 429, DateTimeKind.Utc).AddTicks(7503));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 337,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 21, 56, 18, 429, DateTimeKind.Utc).AddTicks(7504));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 338,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 21, 56, 18, 429, DateTimeKind.Utc).AddTicks(7505));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 339,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 21, 56, 18, 429, DateTimeKind.Utc).AddTicks(7506));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 340,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 21, 56, 18, 429, DateTimeKind.Utc).AddTicks(7507));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 341,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 21, 56, 18, 429, DateTimeKind.Utc).AddTicks(7508));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 342,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 21, 56, 18, 429, DateTimeKind.Utc).AddTicks(7509));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 343,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 21, 56, 18, 429, DateTimeKind.Utc).AddTicks(7532));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 344,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 21, 56, 18, 429, DateTimeKind.Utc).AddTicks(7533));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 345,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 21, 56, 18, 429, DateTimeKind.Utc).AddTicks(7533));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 346,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 21, 56, 18, 429, DateTimeKind.Utc).AddTicks(7534));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 347,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 21, 56, 18, 429, DateTimeKind.Utc).AddTicks(7535));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 348,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 21, 56, 18, 429, DateTimeKind.Utc).AddTicks(7536));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 349,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 21, 56, 18, 429, DateTimeKind.Utc).AddTicks(7537));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 350,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 21, 56, 18, 429, DateTimeKind.Utc).AddTicks(7537));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 351,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 21, 56, 18, 429, DateTimeKind.Utc).AddTicks(7538));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 352,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 21, 56, 18, 429, DateTimeKind.Utc).AddTicks(7539));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 353,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 21, 56, 18, 429, DateTimeKind.Utc).AddTicks(7540));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 354,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 21, 56, 18, 429, DateTimeKind.Utc).AddTicks(7541));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 355,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 21, 56, 18, 429, DateTimeKind.Utc).AddTicks(7542));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 356,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 21, 56, 18, 429, DateTimeKind.Utc).AddTicks(7542));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 357,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 21, 56, 18, 429, DateTimeKind.Utc).AddTicks(7543));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 358,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 21, 56, 18, 429, DateTimeKind.Utc).AddTicks(7544));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 359,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 21, 56, 18, 429, DateTimeKind.Utc).AddTicks(7545));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 360,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 21, 56, 18, 429, DateTimeKind.Utc).AddTicks(7546));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 361,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 21, 56, 18, 429, DateTimeKind.Utc).AddTicks(7549));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 362,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 21, 56, 18, 429, DateTimeKind.Utc).AddTicks(7550));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 363,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 21, 56, 18, 429, DateTimeKind.Utc).AddTicks(7551));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 364,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 21, 56, 18, 429, DateTimeKind.Utc).AddTicks(7551));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 365,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 21, 56, 18, 429, DateTimeKind.Utc).AddTicks(7552));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 366,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 21, 56, 18, 429, DateTimeKind.Utc).AddTicks(7553));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 367,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 21, 56, 18, 429, DateTimeKind.Utc).AddTicks(7554));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 368,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 21, 56, 18, 429, DateTimeKind.Utc).AddTicks(7555));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 369,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 21, 56, 18, 429, DateTimeKind.Utc).AddTicks(7556));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 370,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 21, 56, 18, 429, DateTimeKind.Utc).AddTicks(7556));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 371,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 21, 56, 18, 429, DateTimeKind.Utc).AddTicks(7557));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 372,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 21, 56, 18, 429, DateTimeKind.Utc).AddTicks(7558));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 373,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 21, 56, 18, 429, DateTimeKind.Utc).AddTicks(7559));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 374,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 21, 56, 18, 429, DateTimeKind.Utc).AddTicks(7560));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 375,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 21, 56, 18, 429, DateTimeKind.Utc).AddTicks(7561));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 376,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 21, 56, 18, 429, DateTimeKind.Utc).AddTicks(7561));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 377,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 21, 56, 18, 429, DateTimeKind.Utc).AddTicks(7562));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 378,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 21, 56, 18, 429, DateTimeKind.Utc).AddTicks(7563));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 379,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 21, 56, 18, 429, DateTimeKind.Utc).AddTicks(7577));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 380,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 21, 56, 18, 429, DateTimeKind.Utc).AddTicks(7578));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 381,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 21, 56, 18, 429, DateTimeKind.Utc).AddTicks(7579));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 382,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 21, 56, 18, 429, DateTimeKind.Utc).AddTicks(7579));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 383,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 21, 56, 18, 429, DateTimeKind.Utc).AddTicks(7580));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 384,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 21, 56, 18, 429, DateTimeKind.Utc).AddTicks(7581));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 385,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 21, 56, 18, 429, DateTimeKind.Utc).AddTicks(7582));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 386,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 21, 56, 18, 429, DateTimeKind.Utc).AddTicks(7583));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 387,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 21, 56, 18, 429, DateTimeKind.Utc).AddTicks(7584));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 388,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 21, 56, 18, 429, DateTimeKind.Utc).AddTicks(7585));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 389,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 21, 56, 18, 429, DateTimeKind.Utc).AddTicks(7585));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 390,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 21, 56, 18, 429, DateTimeKind.Utc).AddTicks(7586));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 391,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 21, 56, 18, 429, DateTimeKind.Utc).AddTicks(7587));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 392,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 21, 56, 18, 429, DateTimeKind.Utc).AddTicks(7588));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 393,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 21, 56, 18, 429, DateTimeKind.Utc).AddTicks(7589));

            migrationBuilder.UpdateData(
                table: "LocalizationValues",
                keyColumn: "Id",
                keyValue: 394,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 21, 56, 18, 429, DateTimeKind.Utc).AddTicks(7589));

            migrationBuilder.UpdateData(
                table: "OptionTranslations",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 21, 56, 18, 434, DateTimeKind.Utc).AddTicks(5079));

            migrationBuilder.UpdateData(
                table: "OptionTranslations",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 21, 56, 18, 434, DateTimeKind.Utc).AddTicks(5083));

            migrationBuilder.UpdateData(
                table: "OptionTranslations",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 21, 56, 18, 434, DateTimeKind.Utc).AddTicks(5085));

            migrationBuilder.UpdateData(
                table: "OptionTranslations",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 21, 56, 18, 434, DateTimeKind.Utc).AddTicks(5086));

            migrationBuilder.UpdateData(
                table: "OptionTranslations",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 21, 56, 18, 434, DateTimeKind.Utc).AddTicks(5088));

            migrationBuilder.UpdateData(
                table: "OptionTranslations",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 21, 56, 18, 434, DateTimeKind.Utc).AddTicks(5089));

            migrationBuilder.UpdateData(
                table: "OptionTranslations",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 21, 56, 18, 434, DateTimeKind.Utc).AddTicks(5090));

            migrationBuilder.UpdateData(
                table: "OptionTranslations",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 21, 56, 18, 434, DateTimeKind.Utc).AddTicks(5091));

            migrationBuilder.UpdateData(
                table: "OptionTranslations",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 21, 56, 18, 434, DateTimeKind.Utc).AddTicks(5093));

            migrationBuilder.UpdateData(
                table: "OptionTranslations",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 21, 56, 18, 434, DateTimeKind.Utc).AddTicks(5094));

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 21, 56, 18, 433, DateTimeKind.Utc).AddTicks(7418));

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 21, 56, 18, 433, DateTimeKind.Utc).AddTicks(7422));

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 21, 56, 18, 433, DateTimeKind.Utc).AddTicks(7425));

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 21, 56, 18, 433, DateTimeKind.Utc).AddTicks(7427));

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 21, 56, 18, 433, DateTimeKind.Utc).AddTicks(7428));

            migrationBuilder.UpdateData(
                table: "ProductOptions",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 21, 56, 18, 436, DateTimeKind.Utc).AddTicks(7606));

            migrationBuilder.UpdateData(
                table: "ProductOptions",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 21, 56, 18, 436, DateTimeKind.Utc).AddTicks(7609));

            migrationBuilder.UpdateData(
                table: "ProductOptions",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 21, 56, 18, 436, DateTimeKind.Utc).AddTicks(7611));

            migrationBuilder.UpdateData(
                table: "ProductOptions",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 21, 56, 18, 436, DateTimeKind.Utc).AddTicks(7615));

            migrationBuilder.UpdateData(
                table: "ProductOptions",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 21, 56, 18, 436, DateTimeKind.Utc).AddTicks(7617));

            migrationBuilder.UpdateData(
                table: "ProductOptions",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 21, 56, 18, 436, DateTimeKind.Utc).AddTicks(7619));

            migrationBuilder.UpdateData(
                table: "ProductOptions",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 21, 56, 18, 436, DateTimeKind.Utc).AddTicks(7621));

            migrationBuilder.UpdateData(
                table: "ProductOptions",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 21, 56, 18, 436, DateTimeKind.Utc).AddTicks(7623));

            migrationBuilder.UpdateData(
                table: "ProductOptions",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 21, 56, 18, 436, DateTimeKind.Utc).AddTicks(7625));

            migrationBuilder.UpdateData(
                table: "ProductOptions",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 21, 56, 18, 436, DateTimeKind.Utc).AddTicks(7626));

            migrationBuilder.UpdateData(
                table: "ProductOptions",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 21, 56, 18, 436, DateTimeKind.Utc).AddTicks(7628));

            migrationBuilder.UpdateData(
                table: "ProductOptions",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 21, 56, 18, 436, DateTimeKind.Utc).AddTicks(7630));

            migrationBuilder.UpdateData(
                table: "ProductOptions",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 21, 56, 18, 436, DateTimeKind.Utc).AddTicks(7631));

            migrationBuilder.UpdateData(
                table: "ProductOptions",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 21, 56, 18, 436, DateTimeKind.Utc).AddTicks(7633));

            migrationBuilder.UpdateData(
                table: "ProductOptions",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 21, 56, 18, 436, DateTimeKind.Utc).AddTicks(7640));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 21, 56, 18, 435, DateTimeKind.Utc).AddTicks(9397));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 21, 56, 18, 435, DateTimeKind.Utc).AddTicks(9402));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 21, 56, 18, 435, DateTimeKind.Utc).AddTicks(9405));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 21, 56, 18, 435, DateTimeKind.Utc).AddTicks(9407));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 21, 56, 18, 435, DateTimeKind.Utc).AddTicks(9410));

            migrationBuilder.UpdateData(
                table: "Trademarks",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 21, 56, 18, 438, DateTimeKind.Utc).AddTicks(5167));

            migrationBuilder.UpdateData(
                table: "Trademarks",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 21, 56, 18, 438, DateTimeKind.Utc).AddTicks(5171));

            migrationBuilder.UpdateData(
                table: "Trademarks",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 21, 56, 18, 438, DateTimeKind.Utc).AddTicks(5173));

            migrationBuilder.UpdateData(
                table: "Trademarks",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 21, 56, 18, 438, DateTimeKind.Utc).AddTicks(5176));

            migrationBuilder.UpdateData(
                table: "Trademarks",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 21, 56, 18, 438, DateTimeKind.Utc).AddTicks(5178));

            migrationBuilder.UpdateData(
                table: "Variants",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 21, 56, 18, 440, DateTimeKind.Utc).AddTicks(7153));

            migrationBuilder.UpdateData(
                table: "Variants",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 21, 56, 18, 440, DateTimeKind.Utc).AddTicks(7156));

            migrationBuilder.UpdateData(
                table: "Variants",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 21, 56, 18, 440, DateTimeKind.Utc).AddTicks(7159));

            migrationBuilder.UpdateData(
                table: "Variants",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 21, 56, 18, 440, DateTimeKind.Utc).AddTicks(7160));

            migrationBuilder.UpdateData(
                table: "Variants",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 21, 56, 18, 440, DateTimeKind.Utc).AddTicks(7162));

            migrationBuilder.UpdateData(
                table: "Variants",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 21, 56, 18, 440, DateTimeKind.Utc).AddTicks(7164));

            migrationBuilder.UpdateData(
                table: "Variants",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 21, 56, 18, 440, DateTimeKind.Utc).AddTicks(7166));

            migrationBuilder.UpdateData(
                table: "Variants",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 21, 56, 18, 440, DateTimeKind.Utc).AddTicks(7168));

            migrationBuilder.UpdateData(
                table: "Variants",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 21, 56, 18, 440, DateTimeKind.Utc).AddTicks(7169));
        }
    }
}
