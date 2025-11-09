using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PazarAtlasi.CMS.Domain.Entities.AgentMarketplace;
using PazarAtlasi.CMS.Domain.Common;

namespace PazarAtlasi.CMS.Persistence.EntityConfigurations.AgentMarketplace
{
    public class AgentIntegrationLogConfiguration : IEntityTypeConfiguration<AgentIntegrationLog>
    {
        public void Configure(EntityTypeBuilder<AgentIntegrationLog> builder)
        {
            builder.ToTable("AgentIntegrationLogs").HasKey(l => l.Id);

            builder.Property(l => l.Id).HasColumnName("Id").IsRequired();
            builder.Property(l => l.AgentIntegrationId).HasColumnName("AgentIntegrationId").IsRequired();
            builder.Property(l => l.AgentSubscriptionId).HasColumnName("AgentSubscriptionId");
            builder.Property(l => l.ExecutionTime).HasColumnName("ExecutionTime").IsRequired();
            builder.Property(l => l.Status).HasColumnName("Status").IsRequired();
            builder.Property(l => l.InputData).HasColumnName("InputData").HasColumnType("nvarchar(max)");
            builder.Property(l => l.OutputData).HasColumnName("OutputData").HasColumnType("nvarchar(max)");
            builder.Property(l => l.ErrorMessage).HasColumnName("ErrorMessage").HasColumnType("nvarchar(max)");
            builder.Property(l => l.ExecutionDurationMs).HasColumnName("ExecutionDurationMs").HasDefaultValue(0);
            builder.Property(l => l.ExecutionCost).HasColumnName("ExecutionCost").HasColumnType("decimal(18,4)");
            
            // Base Entity Properties
            builder.Property(l => l.CreatedAt).HasColumnName("CreatedAt").IsRequired();
            builder.Property(l => l.UpdatedAt).HasColumnName("UpdatedAt");
            builder.Property(l => l.IsDeleted).HasColumnName("IsDeleted").HasDefaultValue(false);
            builder.Property(l => l.CreatedBy).HasColumnName("CreatedBy");
            builder.Property(l => l.UpdatedBy).HasColumnName("UpdatedBy");

            // Relationships
            builder.HasOne(l => l.Integration)
                   .WithMany(i => i.Logs)
                   .HasForeignKey(l => l.AgentIntegrationId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(l => l.Subscription)
                   .WithMany()
                   .HasForeignKey(l => l.AgentSubscriptionId)
                   .OnDelete(DeleteBehavior.NoAction);

            // Indexes
            builder.HasIndex(l => l.AgentIntegrationId).HasDatabaseName("IX_AgentIntegrationLogs_AgentIntegrationId");
            builder.HasIndex(l => l.ExecutionTime).HasDatabaseName("IX_AgentIntegrationLogs_ExecutionTime");
            builder.HasIndex(l => l.Status).HasDatabaseName("IX_AgentIntegrationLogs_Status");
            builder.HasIndex(l => new { l.AgentIntegrationId, l.ExecutionTime }).HasDatabaseName("IX_AgentIntegrationLogs_Integration_Time");

            // Query Filter
            builder.HasQueryFilter(l => !l.IsDeleted);
        }
    }
}
