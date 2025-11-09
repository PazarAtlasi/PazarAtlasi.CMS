using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PazarAtlasi.CMS.Domain.Entities.AgentMarketplace;
using PazarAtlasi.CMS.Domain.Common;
using PazarAtlasi.CMS.Domain.Enums;

namespace PazarAtlasi.CMS.Persistence.EntityConfigurations.AgentMarketplace
{
    public class AgentConfiguration : IEntityTypeConfiguration<Agent>
    {
        public void Configure(EntityTypeBuilder<Agent> builder)
        {
            builder.ToTable("Agents").HasKey(a => a.Id);

            builder.Property(a => a.Id).HasColumnName("Id").IsRequired();
            builder.Property(a => a.Name).HasColumnName("Name").HasMaxLength(200).IsRequired();
            builder.Property(a => a.Description).HasColumnName("Description").HasMaxLength(500).IsRequired();
            builder.Property(a => a.DetailedDescription).HasColumnName("DetailedDescription").HasColumnType("nvarchar(max)").IsRequired();
            builder.Property(a => a.Type).HasColumnName("Type").HasDefaultValue(AgentType.Reporting);
            builder.Property(a => a.Category).HasColumnName("Category").HasDefaultValue(AgentCategory.Business);
            builder.Property(a => a.IconClass).HasColumnName("IconClass").HasMaxLength(100).IsRequired();
            builder.Property(a => a.ImageUrl).HasColumnName("ImageUrl").HasMaxLength(500);
            builder.Property(a => a.IsActive).HasColumnName("IsActive").HasDefaultValue(true);
            builder.Property(a => a.ExecutionType).HasColumnName("ExecutionType").HasDefaultValue(AgentExecutionType.OnDemand);
            builder.Property(a => a.SortOrder).HasColumnName("SortOrder").HasDefaultValue(0);
            builder.Property(a => a.IsFeatured).HasColumnName("IsFeatured").HasDefaultValue(false);
            builder.Property(a => a.Version).HasColumnName("Version").HasMaxLength(20).HasDefaultValue("1.0.0");
            
            // Base Entity Properties
            builder.Property(a => a.CreatedAt).HasColumnName("CreatedAt").IsRequired();
            builder.Property(a => a.UpdatedAt).HasColumnName("UpdatedAt");
            builder.Property(a => a.IsDeleted).HasColumnName("IsDeleted").HasDefaultValue(false);
            builder.Property(a => a.Status).HasColumnName("Status").HasDefaultValue(Status.Draft);
            builder.Property(a => a.CreatedBy).HasColumnName("CreatedBy");
            builder.Property(a => a.UpdatedBy).HasColumnName("UpdatedBy");

            // Relationships
            builder.HasMany(a => a.Pricings)
                   .WithOne(p => p.Agent)
                   .HasForeignKey(p => p.AgentId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(a => a.Capabilities)
                   .WithOne(c => c.Agent)
                   .HasForeignKey(c => c.AgentId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(a => a.Subscriptions)
                   .WithOne(s => s.Agent)
                   .HasForeignKey(s => s.AgentId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(a => a.Integrations)
                   .WithOne(i => i.Agent)
                   .HasForeignKey(i => i.AgentId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(a => a.Translations)
                   .WithOne(t => t.Agent)
                   .HasForeignKey(t => t.AgentId)
                   .OnDelete(DeleteBehavior.Cascade);

            // Indexes
            builder.HasIndex(a => a.Type).HasDatabaseName("IX_Agents_Type");
            builder.HasIndex(a => a.Category).HasDatabaseName("IX_Agents_Category");
            builder.HasIndex(a => a.IsActive).HasDatabaseName("IX_Agents_IsActive");
            builder.HasIndex(a => a.IsFeatured).HasDatabaseName("IX_Agents_IsFeatured");
            builder.HasIndex(a => new { a.Type, a.Category }).HasDatabaseName("IX_Agents_Type_Category");

            // Query Filter
            builder.HasQueryFilter(a => !a.IsDeleted);

            // Seed Data
            builder.HasData(
                new Agent
                {
                    Id = 1,
                    Name = "Monthly Report Generator",
                    Description = "Automatically generates comprehensive monthly business reports",
                    DetailedDescription = "This agent analyzes your business data and generates detailed monthly reports including sales metrics, customer insights, and performance indicators. Perfect for keeping stakeholders informed with minimal effort.",
                    Type = AgentType.Reporting,
                    Category = AgentCategory.Business,
                    IconClass = "fas fa-chart-line",
                    ExecutionType = AgentExecutionType.Scheduled,
                    IsActive = true,
                    IsFeatured = true,
                    SortOrder = 1,
                    Version = "1.0.0",
                    CreatedAt = new DateTime(2024, 11, 9, 10, 0, 0),
                    Status = Status.Active,
                    IsDeleted = false
                },
                new Agent
                {
                    Id = 2,
                    Name = "AI Call Center Assistant",
                    Description = "Intelligent call center agent for customer support",
                    DetailedDescription = "Advanced AI-powered call center agent that can handle customer inquiries, process orders, and provide technical support. Integrates with your existing CRM and knowledge base for seamless customer service.",
                    Type = AgentType.CallCenter,
                    Category = AgentCategory.Support,
                    IconClass = "fas fa-headset",
                    ExecutionType = AgentExecutionType.OnDemand,
                    IsActive = true,
                    IsFeatured = true,
                    SortOrder = 2,
                    Version = "1.2.0",
                    CreatedAt = new DateTime(2024, 11, 9, 10, 0, 0),
                    Status = Status.Active,
                    IsDeleted = false
                },
                new Agent
                {
                    Id = 3,
                    Name = "Content Marketing Assistant",
                    Description = "Creates and schedules marketing content across platforms",
                    DetailedDescription = "This agent helps create engaging marketing content, schedules social media posts, and manages your content calendar. It can generate blog posts, social media content, and email campaigns based on your brand guidelines.",
                    Type = AgentType.ContentGeneration,
                    Category = AgentCategory.Marketing,
                    IconClass = "fas fa-pen-fancy",
                    ExecutionType = AgentExecutionType.Background,
                    IsActive = true,
                    IsFeatured = false,
                    SortOrder = 3,
                    Version = "1.1.0",
                    CreatedAt = new DateTime(2024, 11, 9, 10, 0, 0),
                    Status = Status.Active,
                    IsDeleted = false
                }
            );
        }
    }
}
