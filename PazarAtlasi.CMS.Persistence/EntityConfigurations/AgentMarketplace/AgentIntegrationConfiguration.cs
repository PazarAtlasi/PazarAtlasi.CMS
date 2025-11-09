using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PazarAtlasi.CMS.Domain.Entities.AgentMarketplace;
using PazarAtlasi.CMS.Domain.Common;
using PazarAtlasi.CMS.Domain.Enums;

namespace PazarAtlasi.CMS.Persistence.EntityConfigurations.AgentMarketplace
{
    public class AgentIntegrationConfiguration : IEntityTypeConfiguration<AgentIntegration>
    {
        public void Configure(EntityTypeBuilder<AgentIntegration> builder)
        {
            builder.ToTable("AgentIntegrations").HasKey(i => i.Id);

            builder.Property(i => i.Id).HasColumnName("Id").IsRequired();
            builder.Property(i => i.AgentId).HasColumnName("AgentId").IsRequired();
            builder.Property(i => i.Type).HasColumnName("Type").IsRequired();
            builder.Property(i => i.Name).HasColumnName("Name").HasMaxLength(200).IsRequired();
            builder.Property(i => i.ConfigurationJson).HasColumnName("ConfigurationJson").HasColumnType("nvarchar(max)").HasDefaultValue("{}");
            builder.Property(i => i.IsActive).HasColumnName("IsActive").HasDefaultValue(true);
            builder.Property(i => i.Priority).HasColumnName("Priority").HasDefaultValue(0);
            builder.Property(i => i.TriggerType).HasColumnName("TriggerType").IsRequired();
            builder.Property(i => i.Metadata).HasColumnName("Metadata").HasColumnType("nvarchar(max)");
            
            // Base Entity Properties
            builder.Property(i => i.CreatedAt).HasColumnName("CreatedAt").IsRequired();
            builder.Property(i => i.UpdatedAt).HasColumnName("UpdatedAt");
            builder.Property(i => i.IsDeleted).HasColumnName("IsDeleted").HasDefaultValue(false);
            builder.Property(i => i.Status).HasColumnName("Status").HasDefaultValue(Status.Active);
            builder.Property(i => i.CreatedBy).HasColumnName("CreatedBy");
            builder.Property(i => i.UpdatedBy).HasColumnName("UpdatedBy");

            // Relationships
            builder.HasOne(i => i.Agent)
                   .WithMany(a => a.Integrations)
                   .HasForeignKey(i => i.AgentId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(i => i.Logs)
                   .WithOne(l => l.Integration)
                   .HasForeignKey(l => l.AgentIntegrationId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(i => i.Translations)
                   .WithOne(t => t.AgentIntegration)
                   .HasForeignKey(t => t.AgentIntegrationId)
                   .OnDelete(DeleteBehavior.Cascade);

            // Indexes
            builder.HasIndex(i => i.AgentId).HasDatabaseName("IX_AgentIntegrations_AgentId");
            builder.HasIndex(i => i.Type).HasDatabaseName("IX_AgentIntegrations_Type");
            builder.HasIndex(i => i.IsActive).HasDatabaseName("IX_AgentIntegrations_IsActive");
            builder.HasIndex(i => new { i.AgentId, i.Priority }).HasDatabaseName("IX_AgentIntegrations_AgentId_Priority");

            // Query Filter
            builder.HasQueryFilter(i => !i.IsDeleted);

            // Seed Data
            builder.HasData(
                // Monthly Report Generator - n8n Integration
                new AgentIntegration
                {
                    Id = 1,
                    AgentId = 1,
                    Type = IntegrationType.N8n,
                    Name = "Monthly Report Workflow",
                    ConfigurationJson = "{\"workflowId\":\"report_generator_001\",\"webhookUrl\":\"https://n8n.example.com/webhook/monthly-report\",\"timeout\":30000,\"retryCount\":3}",
                    IsActive = true,
                    Priority = 1,
                    TriggerType = IntegrationTrigger.Scheduled,
                    Metadata = "{\"schedule\":\"0 0 1 * *\",\"timezone\":\"UTC\"}",
                    CreatedAt = new DateTime(2024, 11, 9, 10, 0, 0),
                    Status = Status.Active,
                    IsDeleted = false
                },
                // AI Call Center Assistant - Custom API Integration
                new AgentIntegration
                {
                    Id = 2,
                    AgentId = 2,
                    Type = IntegrationType.CustomAPI,
                    Name = "Call Center API",
                    ConfigurationJson = "{\"endpoint\":\"https://api.callcenter.example.com/process\",\"method\":\"POST\",\"timeout\":15000,\"headers\":{\"Content-Type\":\"application/json\",\"Authorization\":\"Bearer token\"}}",
                    IsActive = true,
                    Priority = 1,
                    TriggerType = IntegrationTrigger.OnDemand,
                    CreatedAt = new DateTime(2024, 11, 9, 10, 0, 0),
                    Status = Status.Active,
                    IsDeleted = false
                },
                // Content Marketing Assistant - n8n Integration
                new AgentIntegration
                {
                    Id = 3,
                    AgentId = 3,
                    Type = IntegrationType.N8n,
                    Name = "Content Generation Workflow",
                    ConfigurationJson = "{\"workflowId\":\"content_generator_001\",\"webhookUrl\":\"https://n8n.example.com/webhook/content-gen\",\"timeout\":45000,\"retryCount\":2}",
                    IsActive = true,
                    Priority = 1,
                    TriggerType = IntegrationTrigger.Background,
                    Metadata = "{\"contentTypes\":[\"blog\",\"social\",\"email\"],\"languages\":[\"en\",\"tr\"]}",
                    CreatedAt = new DateTime(2024, 11, 9, 10, 0, 0),
                    Status = Status.Active,
                    IsDeleted = false
                }
            );
        }
    }
}
