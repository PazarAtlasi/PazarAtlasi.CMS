using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PazarAtlasi.CMS.Domain.Entities.AgentMarketplace;
using PazarAtlasi.CMS.Domain.Common;
using PazarAtlasi.CMS.Domain.Enums;

namespace PazarAtlasi.CMS.Persistence.EntityConfigurations.AgentMarketplace
{
    public class AgentPricingConfiguration : IEntityTypeConfiguration<AgentPricing>
    {
        public void Configure(EntityTypeBuilder<AgentPricing> builder)
        {
            builder.ToTable("AgentPricings").HasKey(p => p.Id);

            builder.Property(p => p.Id).HasColumnName("Id").IsRequired();
            builder.Property(p => p.AgentId).HasColumnName("AgentId").IsRequired();
            builder.Property(p => p.Type).HasColumnName("Type").IsRequired();
            builder.Property(p => p.Price).HasColumnName("Price").HasColumnType("decimal(18,2)").IsRequired();
            builder.Property(p => p.Currency).HasColumnName("Currency").HasMaxLength(3).HasDefaultValue("USD");
            builder.Property(p => p.UsageLimit).HasColumnName("UsageLimit");
            builder.Property(p => p.Description).HasColumnName("Description").HasMaxLength(500);
            builder.Property(p => p.IsDefault).HasColumnName("IsDefault").HasDefaultValue(false);
            builder.Property(p => p.IsActive).HasColumnName("IsActive").HasDefaultValue(true);
            builder.Property(p => p.SortOrder).HasColumnName("SortOrder").HasDefaultValue(0);
            
            // Base Entity Properties
            builder.Property(p => p.CreatedAt).HasColumnName("CreatedAt").IsRequired();
            builder.Property(p => p.UpdatedAt).HasColumnName("UpdatedAt");
            builder.Property(p => p.IsDeleted).HasColumnName("IsDeleted").HasDefaultValue(false);
            builder.Property(p => p.Status).HasColumnName("Status").HasDefaultValue(Status.Active);
            builder.Property(p => p.CreatedBy).HasColumnName("CreatedBy");
            builder.Property(p => p.UpdatedBy).HasColumnName("UpdatedBy");

            // Relationships
            builder.HasOne(p => p.Agent)
                   .WithMany(a => a.Pricings)
                   .HasForeignKey(p => p.AgentId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(p => p.Subscriptions)
                   .WithOne(s => s.Pricing)
                   .HasForeignKey(s => s.AgentPricingId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(p => p.Translations)
                   .WithOne(t => t.AgentPricing)
                   .HasForeignKey(t => t.AgentPricingId)
                   .OnDelete(DeleteBehavior.Cascade);

            // Indexes
            builder.HasIndex(p => p.AgentId).HasDatabaseName("IX_AgentPricings_AgentId");
            builder.HasIndex(p => p.Type).HasDatabaseName("IX_AgentPricings_Type");
            builder.HasIndex(p => p.IsDefault).HasDatabaseName("IX_AgentPricings_IsDefault");
            builder.HasIndex(p => new { p.AgentId, p.IsDefault }).HasDatabaseName("IX_AgentPricings_AgentId_IsDefault");

            // Query Filter
            builder.HasQueryFilter(p => !p.IsDeleted);

            // Seed Data
            builder.HasData(
                // Monthly Report Generator Pricing
                new AgentPricing
                {
                    Id = 1,
                    AgentId = 1,
                    Type = PricingType.Monthly,
                    Price = 4.00m,
                    Currency = "USD",
                    UsageLimit = null, // Unlimited
                    Description = "Monthly subscription with unlimited reports",
                    IsDefault = true,
                    IsActive = true,
                    SortOrder = 1,
                    CreatedAt = new DateTime(2024, 11, 9, 10, 0, 0),
                    Status = Status.Active,
                    IsDeleted = false
                },
                // AI Call Center Assistant Pricing
                new AgentPricing
                {
                    Id = 2,
                    AgentId = 2,
                    Type = PricingType.PerAgent,
                    Price = 15.00m,
                    Currency = "USD",
                    UsageLimit = null,
                    Description = "Per agent pricing for call center assistants",
                    IsDefault = true,
                    IsActive = true,
                    SortOrder = 1,
                    CreatedAt = new DateTime(2024, 11, 9, 10, 0, 0),
                    Status = Status.Active,
                    IsDeleted = false
                },
                new AgentPricing
                {
                    Id = 3,
                    AgentId = 2,
                    Type = PricingType.PerUse,
                    Price = 0.50m,
                    Currency = "USD",
                    UsageLimit = null,
                    Description = "Pay per call/interaction",
                    IsDefault = false,
                    IsActive = true,
                    SortOrder = 2,
                    CreatedAt = new DateTime(2024, 11, 9, 10, 0, 0),
                    Status = Status.Active,
                    IsDeleted = false
                },
                // Content Marketing Assistant Pricing
                new AgentPricing
                {
                    Id = 4,
                    AgentId = 3,
                    Type = PricingType.Monthly,
                    Price = 25.00m,
                    Currency = "USD",
                    UsageLimit = 100, // 100 content pieces per month
                    Description = "Monthly subscription with 100 content pieces",
                    IsDefault = true,
                    IsActive = true,
                    SortOrder = 1,
                    CreatedAt = new DateTime(2024, 11, 9, 10, 0, 0),
                    Status = Status.Active,
                    IsDeleted = false
                },
                new AgentPricing
                {
                    Id = 5,
                    AgentId = 3,
                    Type = PricingType.PerUse,
                    Price = 0.30m,
                    Currency = "USD",
                    UsageLimit = null,
                    Description = "Pay per content piece generated",
                    IsDefault = false,
                    IsActive = true,
                    SortOrder = 2,
                    CreatedAt = new DateTime(2024, 11, 9, 10, 0, 0),
                    Status = Status.Active,
                    IsDeleted = false
                }
            );
        }
    }
}
