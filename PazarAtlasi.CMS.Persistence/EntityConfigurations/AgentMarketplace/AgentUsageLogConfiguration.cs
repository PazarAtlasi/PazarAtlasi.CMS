using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PazarAtlasi.CMS.Domain.Entities.AgentMarketplace;
using PazarAtlasi.CMS.Domain.Common;

namespace PazarAtlasi.CMS.Persistence.EntityConfigurations.AgentMarketplace
{
    public class AgentUsageLogConfiguration : IEntityTypeConfiguration<AgentUsageLog>
    {
        public void Configure(EntityTypeBuilder<AgentUsageLog> builder)
        {
            builder.ToTable("AgentUsageLogs").HasKey(u => u.Id);

            builder.Property(u => u.Id).HasColumnName("Id").IsRequired();
            builder.Property(u => u.AgentSubscriptionId).HasColumnName("AgentSubscriptionId").IsRequired();
            builder.Property(u => u.ExecutionTime).HasColumnName("ExecutionTime").IsRequired();
            builder.Property(u => u.Status).HasColumnName("Status").IsRequired();
            builder.Property(u => u.InputData).HasColumnName("InputData").HasColumnType("nvarchar(max)");
            builder.Property(u => u.OutputData).HasColumnName("OutputData").HasColumnType("nvarchar(max)");
            builder.Property(u => u.ErrorMessage).HasColumnName("ErrorMessage").HasColumnType("nvarchar(max)");
            builder.Property(u => u.ExecutionDurationMs).HasColumnName("ExecutionDurationMs").HasDefaultValue(0);
            builder.Property(u => u.Cost).HasColumnName("Cost").HasColumnType("decimal(18,4)");
            builder.Property(u => u.AgentIntegrationId).HasColumnName("AgentIntegrationId");
            
            // Base Entity Properties
            builder.Property(u => u.CreatedAt).HasColumnName("CreatedAt").IsRequired();
            builder.Property(u => u.UpdatedAt).HasColumnName("UpdatedAt");
            builder.Property(u => u.IsDeleted).HasColumnName("IsDeleted").HasDefaultValue(false);
            builder.Property(u => u.CreatedBy).HasColumnName("CreatedBy");
            builder.Property(u => u.UpdatedBy).HasColumnName("UpdatedBy");

            // Relationships
            builder.HasOne(u => u.Subscription)
                   .WithMany(s => s.UsageLogs)
                   .HasForeignKey(u => u.AgentSubscriptionId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(u => u.Integration)
                   .WithMany()
                   .HasForeignKey(u => u.AgentIntegrationId)
                   .OnDelete(DeleteBehavior.NoAction);

            // Indexes
            builder.HasIndex(u => u.AgentSubscriptionId).HasDatabaseName("IX_AgentUsageLogs_AgentSubscriptionId");
            builder.HasIndex(u => u.ExecutionTime).HasDatabaseName("IX_AgentUsageLogs_ExecutionTime");
            builder.HasIndex(u => u.Status).HasDatabaseName("IX_AgentUsageLogs_Status");
            builder.HasIndex(u => new { u.AgentSubscriptionId, u.ExecutionTime }).HasDatabaseName("IX_AgentUsageLogs_Subscription_Time");

            // Query Filter
            builder.HasQueryFilter(u => !u.IsDeleted);
        }
    }
}
