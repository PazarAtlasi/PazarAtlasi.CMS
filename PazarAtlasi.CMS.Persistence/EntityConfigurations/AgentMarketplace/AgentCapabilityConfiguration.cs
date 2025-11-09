using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PazarAtlasi.CMS.Domain.Entities.AgentMarketplace;
using PazarAtlasi.CMS.Domain.Common;

namespace PazarAtlasi.CMS.Persistence.EntityConfigurations.AgentMarketplace
{
    public class AgentCapabilityConfiguration : IEntityTypeConfiguration<AgentCapability>
    {
        public void Configure(EntityTypeBuilder<AgentCapability> builder)
        {
            builder.ToTable("AgentCapabilities").HasKey(c => c.Id);

            builder.Property(c => c.Id).HasColumnName("Id").IsRequired();
            builder.Property(c => c.AgentId).HasColumnName("AgentId").IsRequired();
            builder.Property(c => c.Name).HasColumnName("Name").HasMaxLength(200).IsRequired();
            builder.Property(c => c.Description).HasColumnName("Description").HasMaxLength(500).IsRequired();
            builder.Property(c => c.IconClass).HasColumnName("IconClass").HasMaxLength(100).IsRequired();
            builder.Property(c => c.SortOrder).HasColumnName("SortOrder").HasDefaultValue(0);
            builder.Property(c => c.IsKeyFeature).HasColumnName("IsKeyFeature").HasDefaultValue(false);
            
            // Base Entity Properties
            builder.Property(c => c.CreatedAt).HasColumnName("CreatedAt").IsRequired();
            builder.Property(c => c.UpdatedAt).HasColumnName("UpdatedAt");
            builder.Property(c => c.IsDeleted).HasColumnName("IsDeleted").HasDefaultValue(false);
            builder.Property(c => c.Status).HasColumnName("Status").HasDefaultValue(Status.Active);
            builder.Property(c => c.CreatedBy).HasColumnName("CreatedBy");
            builder.Property(c => c.UpdatedBy).HasColumnName("UpdatedBy");

            // Relationships
            builder.HasOne(c => c.Agent)
                   .WithMany(a => a.Capabilities)
                   .HasForeignKey(c => c.AgentId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(c => c.Translations)
                   .WithOne(t => t.AgentCapability)
                   .HasForeignKey(t => t.AgentCapabilityId)
                   .OnDelete(DeleteBehavior.Cascade);

            // Indexes
            builder.HasIndex(c => c.AgentId).HasDatabaseName("IX_AgentCapabilities_AgentId");
            builder.HasIndex(c => c.IsKeyFeature).HasDatabaseName("IX_AgentCapabilities_IsKeyFeature");

            // Query Filter
            builder.HasQueryFilter(c => !c.IsDeleted);

            // Seed Data
            builder.HasData(
                // Monthly Report Generator Capabilities
                new AgentCapability
                {
                    Id = 1,
                    AgentId = 1,
                    Name = "Automated Data Collection",
                    Description = "Automatically collects data from multiple sources",
                    IconClass = "fas fa-database",
                    SortOrder = 1,
                    IsKeyFeature = true,
                    CreatedAt = new DateTime(2024, 11, 9, 10, 0, 0),
                    Status = Status.Active,
                    IsDeleted = false
                },
                new AgentCapability
                {
                    Id = 2,
                    AgentId = 1,
                    Name = "Visual Charts & Graphs",
                    Description = "Creates beautiful visualizations and charts",
                    IconClass = "fas fa-chart-pie",
                    SortOrder = 2,
                    IsKeyFeature = true,
                    CreatedAt = new DateTime(2024, 11, 9, 10, 0, 0),
                    Status = Status.Active,
                    IsDeleted = false
                },
                new AgentCapability
                {
                    Id = 3,
                    AgentId = 1,
                    Name = "PDF Export",
                    Description = "Exports reports in professional PDF format",
                    IconClass = "fas fa-file-pdf",
                    SortOrder = 3,
                    IsKeyFeature = false,
                    CreatedAt = new DateTime(2024, 11, 9, 10, 0, 0),
                    Status = Status.Active,
                    IsDeleted = false
                },
                // AI Call Center Assistant Capabilities
                new AgentCapability
                {
                    Id = 4,
                    AgentId = 2,
                    Name = "Natural Language Processing",
                    Description = "Understands and responds in natural language",
                    IconClass = "fas fa-comments",
                    SortOrder = 1,
                    IsKeyFeature = true,
                    CreatedAt = new DateTime(2024, 11, 9, 10, 0, 0),
                    Status = Status.Active,
                    IsDeleted = false
                },
                new AgentCapability
                {
                    Id = 5,
                    AgentId = 2,
                    Name = "Multi-language Support",
                    Description = "Supports multiple languages for global customers",
                    IconClass = "fas fa-globe",
                    SortOrder = 2,
                    IsKeyFeature = true,
                    CreatedAt = new DateTime(2024, 11, 9, 10, 0, 0),
                    Status = Status.Active,
                    IsDeleted = false
                },
                new AgentCapability
                {
                    Id = 6,
                    AgentId = 2,
                    Name = "CRM Integration",
                    Description = "Integrates with popular CRM systems",
                    IconClass = "fas fa-link",
                    SortOrder = 3,
                    IsKeyFeature = false,
                    CreatedAt = new DateTime(2024, 11, 9, 10, 0, 0),
                    Status = Status.Active,
                    IsDeleted = false
                },
                // Content Marketing Assistant Capabilities
                new AgentCapability
                {
                    Id = 7,
                    AgentId = 3,
                    Name = "AI Content Generation",
                    Description = "Creates engaging content using AI",
                    IconClass = "fas fa-magic",
                    SortOrder = 1,
                    IsKeyFeature = true,
                    CreatedAt = new DateTime(2024, 11, 9, 10, 0, 0),
                    Status = Status.Active,
                    IsDeleted = false
                },
                new AgentCapability
                {
                    Id = 8,
                    AgentId = 3,
                    Name = "Social Media Scheduling",
                    Description = "Schedules posts across social platforms",
                    IconClass = "fas fa-calendar-alt",
                    SortOrder = 2,
                    IsKeyFeature = true,
                    CreatedAt = new DateTime(2024, 11, 9, 10, 0, 0),
                    Status = Status.Active,
                    IsDeleted = false
                },
                new AgentCapability
                {
                    Id = 9,
                    AgentId = 3,
                    Name = "Brand Voice Consistency",
                    Description = "Maintains consistent brand voice across content",
                    IconClass = "fas fa-bullhorn",
                    SortOrder = 3,
                    IsKeyFeature = false,
                    CreatedAt = new DateTime(2024, 11, 9, 10, 0, 0),
                    Status = Status.Active,
                    IsDeleted = false
                }
            );
        }
    }
}
