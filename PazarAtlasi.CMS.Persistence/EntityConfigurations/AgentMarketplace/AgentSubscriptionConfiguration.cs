using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PazarAtlasi.CMS.Domain.Entities.AgentMarketplace;
using PazarAtlasi.CMS.Domain.Common;
using PazarAtlasi.CMS.Domain.Enums;

namespace PazarAtlasi.CMS.Persistence.EntityConfigurations.AgentMarketplace
{
    public class AgentSubscriptionConfiguration : IEntityTypeConfiguration<AgentSubscription>
    {
        public void Configure(EntityTypeBuilder<AgentSubscription> builder)
        {
            builder.ToTable("AgentSubscriptions").HasKey(s => s.Id);

            builder.Property(s => s.Id).HasColumnName("Id").IsRequired();
            builder.Property(s => s.AgentId).HasColumnName("AgentId").IsRequired();
            builder.Property(s => s.UserId).HasColumnName("UserId").IsRequired();
            builder.Property(s => s.AgentPricingId).HasColumnName("AgentPricingId").IsRequired();
            builder.Property(s => s.StartDate).HasColumnName("StartDate").IsRequired();
            builder.Property(s => s.EndDate).HasColumnName("EndDate");
            builder.Property(s => s.Status).HasColumnName("Status").HasDefaultValue(SubscriptionStatus.Active);
            builder.Property(s => s.AgentCount).HasColumnName("AgentCount");
            builder.Property(s => s.CurrentUsage).HasColumnName("CurrentUsage").HasDefaultValue(0);
            builder.Property(s => s.LastUsageReset).HasColumnName("LastUsageReset").IsRequired();
            builder.Property(s => s.NextBillingDate).HasColumnName("NextBillingDate");
            builder.Property(s => s.LastBilledAmount).HasColumnName("LastBilledAmount").HasColumnType("decimal(18,2)");
            builder.Property(s => s.ConfigurationJson).HasColumnName("ConfigurationJson").HasColumnType("nvarchar(max)");
            
            // Base Entity Properties
            builder.Property(s => s.CreatedAt).HasColumnName("CreatedAt").IsRequired();
            builder.Property(s => s.UpdatedAt).HasColumnName("UpdatedAt");
            builder.Property(s => s.IsDeleted).HasColumnName("IsDeleted").HasDefaultValue(false);
            builder.Property(s => s.CreatedBy).HasColumnName("CreatedBy");
            builder.Property(s => s.UpdatedBy).HasColumnName("UpdatedBy");

            // Relationships
            builder.HasOne(s => s.Agent)
                   .WithMany(a => a.Subscriptions)
                   .HasForeignKey(s => s.AgentId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(s => s.User)
                   .WithMany()
                   .HasForeignKey(s => s.UserId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(s => s.Pricing)
                   .WithMany(p => p.Subscriptions)
                   .HasForeignKey(s => s.AgentPricingId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(s => s.UsageLogs)
                   .WithOne(u => u.Subscription)
                   .HasForeignKey(u => u.AgentSubscriptionId)
                   .OnDelete(DeleteBehavior.Cascade);

            // Indexes
            builder.HasIndex(s => s.AgentId).HasDatabaseName("IX_AgentSubscriptions_AgentId");
            builder.HasIndex(s => s.UserId).HasDatabaseName("IX_AgentSubscriptions_UserId");
            builder.HasIndex(s => s.Status).HasDatabaseName("IX_AgentSubscriptions_Status");
            builder.HasIndex(s => s.NextBillingDate).HasDatabaseName("IX_AgentSubscriptions_NextBillingDate");
            builder.HasIndex(s => new { s.UserId, s.AgentId }).HasDatabaseName("IX_AgentSubscriptions_UserId_AgentId");

            // Query Filter
            builder.HasQueryFilter(s => !s.IsDeleted);
        }
    }
}
