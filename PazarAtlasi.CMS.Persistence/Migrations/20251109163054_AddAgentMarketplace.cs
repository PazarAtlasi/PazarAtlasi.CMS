using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace PazarAtlasi.CMS.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AddAgentMarketplace : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Agents",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    DetailedDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Type = table.Column<int>(type: "int", nullable: false, defaultValue: 1),
                    Category = table.Column<int>(type: "int", nullable: false, defaultValue: 1),
                    IconClass = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    ExecutionType = table.Column<int>(type: "int", nullable: false, defaultValue: 2),
                    SortOrder = table.Column<int>(type: "int", nullable: false, defaultValue: 0),
                    IsFeatured = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    Version = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false, defaultValue: "1.0.0"),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<int>(type: "int", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<int>(type: "int", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    Status = table.Column<int>(type: "int", nullable: false, defaultValue: 0)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Agents", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AgentCapabilities",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AgentId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    IconClass = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    SortOrder = table.Column<int>(type: "int", nullable: false, defaultValue: 0),
                    IsKeyFeature = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<int>(type: "int", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<int>(type: "int", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    Status = table.Column<int>(type: "int", nullable: false, defaultValue: 1)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AgentCapabilities", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AgentCapabilities_Agents_AgentId",
                        column: x => x.AgentId,
                        principalTable: "Agents",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AgentIntegrations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AgentId = table.Column<int>(type: "int", nullable: false),
                    Type = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    ConfigurationJson = table.Column<string>(type: "nvarchar(max)", nullable: false, defaultValue: "{}"),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    Priority = table.Column<int>(type: "int", nullable: false, defaultValue: 0),
                    TriggerType = table.Column<int>(type: "int", nullable: false),
                    Metadata = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<int>(type: "int", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<int>(type: "int", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    Status = table.Column<int>(type: "int", nullable: false, defaultValue: 1)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AgentIntegrations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AgentIntegrations_Agents_AgentId",
                        column: x => x.AgentId,
                        principalTable: "Agents",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AgentPricings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AgentId = table.Column<int>(type: "int", nullable: false),
                    Type = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Currency = table.Column<string>(type: "nvarchar(3)", maxLength: 3, nullable: false, defaultValue: "USD"),
                    UsageLimit = table.Column<int>(type: "int", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    IsDefault = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
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
                    table.PrimaryKey("PK_AgentPricings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AgentPricings_Agents_AgentId",
                        column: x => x.AgentId,
                        principalTable: "Agents",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AgentTranslations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AgentId = table.Column<int>(type: "int", nullable: false),
                    LanguageId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    DetailedDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<int>(type: "int", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<int>(type: "int", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    Status = table.Column<int>(type: "int", nullable: false, defaultValue: 1)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AgentTranslations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AgentTranslations_Agents_AgentId",
                        column: x => x.AgentId,
                        principalTable: "Agents",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AgentTranslations_Languages_LanguageId",
                        column: x => x.LanguageId,
                        principalTable: "Languages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AgentCapabilityTranslations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AgentCapabilityId = table.Column<int>(type: "int", nullable: false),
                    LanguageId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<int>(type: "int", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<int>(type: "int", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    Status = table.Column<int>(type: "int", nullable: false, defaultValue: 1)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AgentCapabilityTranslations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AgentCapabilityTranslations_AgentCapabilities_AgentCapabilityId",
                        column: x => x.AgentCapabilityId,
                        principalTable: "AgentCapabilities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AgentCapabilityTranslations_Languages_LanguageId",
                        column: x => x.LanguageId,
                        principalTable: "Languages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AgentIntegrationTranslations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AgentIntegrationId = table.Column<int>(type: "int", nullable: false),
                    LanguageId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<int>(type: "int", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<int>(type: "int", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    Status = table.Column<int>(type: "int", nullable: false, defaultValue: 1)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AgentIntegrationTranslations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AgentIntegrationTranslations_AgentIntegrations_AgentIntegrationId",
                        column: x => x.AgentIntegrationId,
                        principalTable: "AgentIntegrations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AgentIntegrationTranslations_Languages_LanguageId",
                        column: x => x.LanguageId,
                        principalTable: "Languages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AgentPricingTranslations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AgentPricingId = table.Column<int>(type: "int", nullable: false),
                    LanguageId = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    Features = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<int>(type: "int", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<int>(type: "int", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    Status = table.Column<int>(type: "int", nullable: false, defaultValue: 1)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AgentPricingTranslations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AgentPricingTranslations_AgentPricings_AgentPricingId",
                        column: x => x.AgentPricingId,
                        principalTable: "AgentPricings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AgentPricingTranslations_Languages_LanguageId",
                        column: x => x.LanguageId,
                        principalTable: "Languages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AgentSubscriptions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AgentId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    AgentPricingId = table.Column<int>(type: "int", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: false, defaultValue: 1),
                    AgentCount = table.Column<int>(type: "int", nullable: true),
                    CurrentUsage = table.Column<int>(type: "int", nullable: false, defaultValue: 0),
                    LastUsageReset = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NextBillingDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastBilledAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    ConfigurationJson = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<int>(type: "int", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<int>(type: "int", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AgentSubscriptions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AgentSubscriptions_AgentPricings_AgentPricingId",
                        column: x => x.AgentPricingId,
                        principalTable: "AgentPricings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AgentSubscriptions_Agents_AgentId",
                        column: x => x.AgentId,
                        principalTable: "Agents",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AgentSubscriptions_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AgentIntegrationLogs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AgentIntegrationId = table.Column<int>(type: "int", nullable: false),
                    AgentSubscriptionId = table.Column<int>(type: "int", nullable: true),
                    ExecutionTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    InputData = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OutputData = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ErrorMessage = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ExecutionDurationMs = table.Column<int>(type: "int", nullable: false, defaultValue: 0),
                    ExecutionCost = table.Column<decimal>(type: "decimal(18,4)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<int>(type: "int", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<int>(type: "int", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AgentIntegrationLogs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AgentIntegrationLogs_AgentIntegrations_AgentIntegrationId",
                        column: x => x.AgentIntegrationId,
                        principalTable: "AgentIntegrations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AgentIntegrationLogs_AgentSubscriptions_AgentSubscriptionId",
                        column: x => x.AgentSubscriptionId,
                        principalTable: "AgentSubscriptions",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "AgentUsageLogs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AgentSubscriptionId = table.Column<int>(type: "int", nullable: false),
                    ExecutionTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    InputData = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OutputData = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ErrorMessage = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ExecutionDurationMs = table.Column<int>(type: "int", nullable: false, defaultValue: 0),
                    Cost = table.Column<decimal>(type: "decimal(18,4)", nullable: true),
                    AgentIntegrationId = table.Column<int>(type: "int", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<int>(type: "int", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<int>(type: "int", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AgentUsageLogs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AgentUsageLogs_AgentIntegrations_AgentIntegrationId",
                        column: x => x.AgentIntegrationId,
                        principalTable: "AgentIntegrations",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_AgentUsageLogs_AgentSubscriptions_AgentSubscriptionId",
                        column: x => x.AgentSubscriptionId,
                        principalTable: "AgentSubscriptions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Agents",
                columns: new[] { "Id", "Category", "CreatedAt", "CreatedBy", "Description", "DetailedDescription", "ExecutionType", "IconClass", "ImageUrl", "IsActive", "IsFeatured", "Name", "SortOrder", "Status", "Type", "UpdatedAt", "UpdatedBy", "Version" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2024, 11, 9, 10, 0, 0, 0, DateTimeKind.Unspecified), null, "Automatically generates comprehensive monthly business reports", "This agent analyzes your business data and generates detailed monthly reports including sales metrics, customer insights, and performance indicators. Perfect for keeping stakeholders informed with minimal effort.", 3, "fas fa-chart-line", null, true, true, "Monthly Report Generator", 1, 1, 1, null, null, "1.0.0" },
                    { 2, 5, new DateTime(2024, 11, 9, 10, 0, 0, 0, DateTimeKind.Unspecified), null, "Intelligent call center agent for customer support", "Advanced AI-powered call center agent that can handle customer inquiries, process orders, and provide technical support. Integrates with your existing CRM and knowledge base for seamless customer service.", 2, "fas fa-headset", null, true, true, "AI Call Center Assistant", 2, 1, 2, null, null, "1.2.0" }
                });

            migrationBuilder.InsertData(
                table: "Agents",
                columns: new[] { "Id", "Category", "CreatedAt", "CreatedBy", "Description", "DetailedDescription", "ExecutionType", "IconClass", "ImageUrl", "IsActive", "Name", "SortOrder", "Status", "Type", "UpdatedAt", "UpdatedBy", "Version" },
                values: new object[] { 3, 3, new DateTime(2024, 11, 9, 10, 0, 0, 0, DateTimeKind.Unspecified), null, "Creates and schedules marketing content across platforms", "This agent helps create engaging marketing content, schedules social media posts, and manages your content calendar. It can generate blog posts, social media content, and email campaigns based on your brand guidelines.", 1, "fas fa-pen-fancy", null, true, "Content Marketing Assistant", 3, 1, 8, null, null, "1.1.0" });

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

            migrationBuilder.InsertData(
                table: "AgentCapabilities",
                columns: new[] { "Id", "AgentId", "CreatedAt", "CreatedBy", "Description", "IconClass", "IsKeyFeature", "Name", "SortOrder", "Status", "UpdatedAt", "UpdatedBy" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2024, 11, 9, 10, 0, 0, 0, DateTimeKind.Unspecified), null, "Automatically collects data from multiple sources", "fas fa-database", true, "Automated Data Collection", 1, 1, null, null },
                    { 2, 1, new DateTime(2024, 11, 9, 10, 0, 0, 0, DateTimeKind.Unspecified), null, "Creates beautiful visualizations and charts", "fas fa-chart-pie", true, "Visual Charts & Graphs", 2, 1, null, null }
                });

            migrationBuilder.InsertData(
                table: "AgentCapabilities",
                columns: new[] { "Id", "AgentId", "CreatedAt", "CreatedBy", "Description", "IconClass", "Name", "SortOrder", "Status", "UpdatedAt", "UpdatedBy" },
                values: new object[] { 3, 1, new DateTime(2024, 11, 9, 10, 0, 0, 0, DateTimeKind.Unspecified), null, "Exports reports in professional PDF format", "fas fa-file-pdf", "PDF Export", 3, 1, null, null });

            migrationBuilder.InsertData(
                table: "AgentCapabilities",
                columns: new[] { "Id", "AgentId", "CreatedAt", "CreatedBy", "Description", "IconClass", "IsKeyFeature", "Name", "SortOrder", "Status", "UpdatedAt", "UpdatedBy" },
                values: new object[,]
                {
                    { 4, 2, new DateTime(2024, 11, 9, 10, 0, 0, 0, DateTimeKind.Unspecified), null, "Understands and responds in natural language", "fas fa-comments", true, "Natural Language Processing", 1, 1, null, null },
                    { 5, 2, new DateTime(2024, 11, 9, 10, 0, 0, 0, DateTimeKind.Unspecified), null, "Supports multiple languages for global customers", "fas fa-globe", true, "Multi-language Support", 2, 1, null, null }
                });

            migrationBuilder.InsertData(
                table: "AgentCapabilities",
                columns: new[] { "Id", "AgentId", "CreatedAt", "CreatedBy", "Description", "IconClass", "Name", "SortOrder", "Status", "UpdatedAt", "UpdatedBy" },
                values: new object[] { 6, 2, new DateTime(2024, 11, 9, 10, 0, 0, 0, DateTimeKind.Unspecified), null, "Integrates with popular CRM systems", "fas fa-link", "CRM Integration", 3, 1, null, null });

            migrationBuilder.InsertData(
                table: "AgentCapabilities",
                columns: new[] { "Id", "AgentId", "CreatedAt", "CreatedBy", "Description", "IconClass", "IsKeyFeature", "Name", "SortOrder", "Status", "UpdatedAt", "UpdatedBy" },
                values: new object[,]
                {
                    { 7, 3, new DateTime(2024, 11, 9, 10, 0, 0, 0, DateTimeKind.Unspecified), null, "Creates engaging content using AI", "fas fa-magic", true, "AI Content Generation", 1, 1, null, null },
                    { 8, 3, new DateTime(2024, 11, 9, 10, 0, 0, 0, DateTimeKind.Unspecified), null, "Schedules posts across social platforms", "fas fa-calendar-alt", true, "Social Media Scheduling", 2, 1, null, null }
                });

            migrationBuilder.InsertData(
                table: "AgentCapabilities",
                columns: new[] { "Id", "AgentId", "CreatedAt", "CreatedBy", "Description", "IconClass", "Name", "SortOrder", "Status", "UpdatedAt", "UpdatedBy" },
                values: new object[] { 9, 3, new DateTime(2024, 11, 9, 10, 0, 0, 0, DateTimeKind.Unspecified), null, "Maintains consistent brand voice across content", "fas fa-bullhorn", "Brand Voice Consistency", 3, 1, null, null });

            migrationBuilder.InsertData(
                table: "AgentIntegrations",
                columns: new[] { "Id", "AgentId", "ConfigurationJson", "CreatedAt", "CreatedBy", "IsActive", "Metadata", "Name", "Priority", "Status", "TriggerType", "Type", "UpdatedAt", "UpdatedBy" },
                values: new object[,]
                {
                    { 1, 1, "{\"workflowId\":\"report_generator_001\",\"webhookUrl\":\"https://n8n.example.com/webhook/monthly-report\",\"timeout\":30000,\"retryCount\":3}", new DateTime(2024, 11, 9, 10, 0, 0, 0, DateTimeKind.Unspecified), null, true, "{\"schedule\":\"0 0 1 * *\",\"timezone\":\"UTC\"}", "Monthly Report Workflow", 1, 1, 3, 1, null, null },
                    { 2, 2, "{\"endpoint\":\"https://api.callcenter.example.com/process\",\"method\":\"POST\",\"timeout\":15000,\"headers\":{\"Content-Type\":\"application/json\",\"Authorization\":\"Bearer token\"}}", new DateTime(2024, 11, 9, 10, 0, 0, 0, DateTimeKind.Unspecified), null, true, null, "Call Center API", 1, 1, 2, 2, null, null },
                    { 3, 3, "{\"workflowId\":\"content_generator_001\",\"webhookUrl\":\"https://n8n.example.com/webhook/content-gen\",\"timeout\":45000,\"retryCount\":2}", new DateTime(2024, 11, 9, 10, 0, 0, 0, DateTimeKind.Unspecified), null, true, "{\"contentTypes\":[\"blog\",\"social\",\"email\"],\"languages\":[\"en\",\"tr\"]}", "Content Generation Workflow", 1, 1, 4, 1, null, null }
                });

            migrationBuilder.InsertData(
                table: "AgentPricings",
                columns: new[] { "Id", "AgentId", "CreatedAt", "CreatedBy", "Currency", "Description", "IsActive", "IsDefault", "Price", "SortOrder", "Status", "Type", "UpdatedAt", "UpdatedBy", "UsageLimit" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2024, 11, 9, 10, 0, 0, 0, DateTimeKind.Unspecified), null, "USD", "Monthly subscription with unlimited reports", true, true, 4.00m, 1, 1, 1, null, null, null },
                    { 2, 2, new DateTime(2024, 11, 9, 10, 0, 0, 0, DateTimeKind.Unspecified), null, "USD", "Per agent pricing for call center assistants", true, true, 15.00m, 1, 1, 3, null, null, null }
                });

            migrationBuilder.InsertData(
                table: "AgentPricings",
                columns: new[] { "Id", "AgentId", "CreatedAt", "CreatedBy", "Currency", "Description", "IsActive", "Price", "SortOrder", "Status", "Type", "UpdatedAt", "UpdatedBy", "UsageLimit" },
                values: new object[] { 3, 2, new DateTime(2024, 11, 9, 10, 0, 0, 0, DateTimeKind.Unspecified), null, "USD", "Pay per call/interaction", true, 0.50m, 2, 1, 2, null, null, null });

            migrationBuilder.InsertData(
                table: "AgentPricings",
                columns: new[] { "Id", "AgentId", "CreatedAt", "CreatedBy", "Currency", "Description", "IsActive", "IsDefault", "Price", "SortOrder", "Status", "Type", "UpdatedAt", "UpdatedBy", "UsageLimit" },
                values: new object[] { 4, 3, new DateTime(2024, 11, 9, 10, 0, 0, 0, DateTimeKind.Unspecified), null, "USD", "Monthly subscription with 100 content pieces", true, true, 25.00m, 1, 1, 1, null, null, 100 });

            migrationBuilder.InsertData(
                table: "AgentPricings",
                columns: new[] { "Id", "AgentId", "CreatedAt", "CreatedBy", "Currency", "Description", "IsActive", "Price", "SortOrder", "Status", "Type", "UpdatedAt", "UpdatedBy", "UsageLimit" },
                values: new object[] { 5, 3, new DateTime(2024, 11, 9, 10, 0, 0, 0, DateTimeKind.Unspecified), null, "USD", "Pay per content piece generated", true, 0.30m, 2, 1, 2, null, null, null });

            migrationBuilder.CreateIndex(
                name: "IX_AgentCapabilities_AgentId",
                table: "AgentCapabilities",
                column: "AgentId");

            migrationBuilder.CreateIndex(
                name: "IX_AgentCapabilities_IsKeyFeature",
                table: "AgentCapabilities",
                column: "IsKeyFeature");

            migrationBuilder.CreateIndex(
                name: "IX_AgentCapabilityTranslations_AgentCapabilityId",
                table: "AgentCapabilityTranslations",
                column: "AgentCapabilityId");

            migrationBuilder.CreateIndex(
                name: "IX_AgentCapabilityTranslations_Capability_Language",
                table: "AgentCapabilityTranslations",
                columns: new[] { "AgentCapabilityId", "LanguageId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AgentCapabilityTranslations_LanguageId",
                table: "AgentCapabilityTranslations",
                column: "LanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_AgentIntegrationLogs_AgentIntegrationId",
                table: "AgentIntegrationLogs",
                column: "AgentIntegrationId");

            migrationBuilder.CreateIndex(
                name: "IX_AgentIntegrationLogs_AgentSubscriptionId",
                table: "AgentIntegrationLogs",
                column: "AgentSubscriptionId");

            migrationBuilder.CreateIndex(
                name: "IX_AgentIntegrationLogs_ExecutionTime",
                table: "AgentIntegrationLogs",
                column: "ExecutionTime");

            migrationBuilder.CreateIndex(
                name: "IX_AgentIntegrationLogs_Integration_Time",
                table: "AgentIntegrationLogs",
                columns: new[] { "AgentIntegrationId", "ExecutionTime" });

            migrationBuilder.CreateIndex(
                name: "IX_AgentIntegrationLogs_Status",
                table: "AgentIntegrationLogs",
                column: "Status");

            migrationBuilder.CreateIndex(
                name: "IX_AgentIntegrations_AgentId",
                table: "AgentIntegrations",
                column: "AgentId");

            migrationBuilder.CreateIndex(
                name: "IX_AgentIntegrations_AgentId_Priority",
                table: "AgentIntegrations",
                columns: new[] { "AgentId", "Priority" });

            migrationBuilder.CreateIndex(
                name: "IX_AgentIntegrations_IsActive",
                table: "AgentIntegrations",
                column: "IsActive");

            migrationBuilder.CreateIndex(
                name: "IX_AgentIntegrations_Type",
                table: "AgentIntegrations",
                column: "Type");

            migrationBuilder.CreateIndex(
                name: "IX_AgentIntegrationTranslations_AgentIntegrationId",
                table: "AgentIntegrationTranslations",
                column: "AgentIntegrationId");

            migrationBuilder.CreateIndex(
                name: "IX_AgentIntegrationTranslations_Integration_Language",
                table: "AgentIntegrationTranslations",
                columns: new[] { "AgentIntegrationId", "LanguageId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AgentIntegrationTranslations_LanguageId",
                table: "AgentIntegrationTranslations",
                column: "LanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_AgentPricings_AgentId",
                table: "AgentPricings",
                column: "AgentId");

            migrationBuilder.CreateIndex(
                name: "IX_AgentPricings_AgentId_IsDefault",
                table: "AgentPricings",
                columns: new[] { "AgentId", "IsDefault" });

            migrationBuilder.CreateIndex(
                name: "IX_AgentPricings_IsDefault",
                table: "AgentPricings",
                column: "IsDefault");

            migrationBuilder.CreateIndex(
                name: "IX_AgentPricings_Type",
                table: "AgentPricings",
                column: "Type");

            migrationBuilder.CreateIndex(
                name: "IX_AgentPricingTranslations_AgentPricingId",
                table: "AgentPricingTranslations",
                column: "AgentPricingId");

            migrationBuilder.CreateIndex(
                name: "IX_AgentPricingTranslations_LanguageId",
                table: "AgentPricingTranslations",
                column: "LanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_AgentPricingTranslations_Pricing_Language",
                table: "AgentPricingTranslations",
                columns: new[] { "AgentPricingId", "LanguageId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Agents_Category",
                table: "Agents",
                column: "Category");

            migrationBuilder.CreateIndex(
                name: "IX_Agents_IsActive",
                table: "Agents",
                column: "IsActive");

            migrationBuilder.CreateIndex(
                name: "IX_Agents_IsFeatured",
                table: "Agents",
                column: "IsFeatured");

            migrationBuilder.CreateIndex(
                name: "IX_Agents_Type",
                table: "Agents",
                column: "Type");

            migrationBuilder.CreateIndex(
                name: "IX_Agents_Type_Category",
                table: "Agents",
                columns: new[] { "Type", "Category" });

            migrationBuilder.CreateIndex(
                name: "IX_AgentSubscriptions_AgentId",
                table: "AgentSubscriptions",
                column: "AgentId");

            migrationBuilder.CreateIndex(
                name: "IX_AgentSubscriptions_AgentPricingId",
                table: "AgentSubscriptions",
                column: "AgentPricingId");

            migrationBuilder.CreateIndex(
                name: "IX_AgentSubscriptions_NextBillingDate",
                table: "AgentSubscriptions",
                column: "NextBillingDate");

            migrationBuilder.CreateIndex(
                name: "IX_AgentSubscriptions_Status",
                table: "AgentSubscriptions",
                column: "Status");

            migrationBuilder.CreateIndex(
                name: "IX_AgentSubscriptions_UserId",
                table: "AgentSubscriptions",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AgentSubscriptions_UserId_AgentId",
                table: "AgentSubscriptions",
                columns: new[] { "UserId", "AgentId" });

            migrationBuilder.CreateIndex(
                name: "IX_AgentTranslations_AgentId",
                table: "AgentTranslations",
                column: "AgentId");

            migrationBuilder.CreateIndex(
                name: "IX_AgentTranslations_AgentId_LanguageId",
                table: "AgentTranslations",
                columns: new[] { "AgentId", "LanguageId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AgentTranslations_LanguageId",
                table: "AgentTranslations",
                column: "LanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_AgentUsageLogs_AgentIntegrationId",
                table: "AgentUsageLogs",
                column: "AgentIntegrationId");

            migrationBuilder.CreateIndex(
                name: "IX_AgentUsageLogs_AgentSubscriptionId",
                table: "AgentUsageLogs",
                column: "AgentSubscriptionId");

            migrationBuilder.CreateIndex(
                name: "IX_AgentUsageLogs_ExecutionTime",
                table: "AgentUsageLogs",
                column: "ExecutionTime");

            migrationBuilder.CreateIndex(
                name: "IX_AgentUsageLogs_Status",
                table: "AgentUsageLogs",
                column: "Status");

            migrationBuilder.CreateIndex(
                name: "IX_AgentUsageLogs_Subscription_Time",
                table: "AgentUsageLogs",
                columns: new[] { "AgentSubscriptionId", "ExecutionTime" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AgentCapabilityTranslations");

            migrationBuilder.DropTable(
                name: "AgentIntegrationLogs");

            migrationBuilder.DropTable(
                name: "AgentIntegrationTranslations");

            migrationBuilder.DropTable(
                name: "AgentPricingTranslations");

            migrationBuilder.DropTable(
                name: "AgentTranslations");

            migrationBuilder.DropTable(
                name: "AgentUsageLogs");

            migrationBuilder.DropTable(
                name: "AgentCapabilities");

            migrationBuilder.DropTable(
                name: "AgentIntegrations");

            migrationBuilder.DropTable(
                name: "AgentSubscriptions");

            migrationBuilder.DropTable(
                name: "AgentPricings");

            migrationBuilder.DropTable(
                name: "Agents");

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
        }
    }
}
