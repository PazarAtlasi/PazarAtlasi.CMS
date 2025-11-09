using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PazarAtlasi.CMS.Domain.Common;
using PazarAtlasi.CMS.Domain.Entities.Announcement;
using PazarAtlasi.CMS.Domain.Entities.Content;
using PazarAtlasi.CMS.Domain.Entities.Localization;
using PazarAtlasi.CMS.Domain.Entities.Metadata;
using PazarAtlasi.CMS.Domain.Entities.AgentMarketplace;

namespace PazarAtlasi.CMS.Persistence.Context
{
    public class PazarAtlasiDbContext : DbContext
    {
        public PazarAtlasiDbContext(DbContextOptions<PazarAtlasiDbContext> options)
            : base(options)
        {
        }

        public DbSet<Content> Contents { get; set; }

        public DbSet<ContentSlugs> ContentSlugs { get; set; }

        public DbSet<Language> Languages { get; set; }

        public DbSet<Country> Countries { get; set; }

        public DbSet<Continent> Continents { get; set; }

        public DbSet<Layout> Layouts { get; set; }

        public DbSet<LayoutSection> LayoutSections { get; set; }

        public DbSet<Page> Pages { get; set; }

        public DbSet<PageSection> PageSections { get; set; }

        public DbSet<PageTranslation> PageTranslations { get; set; }

        public DbSet<Section> Sections { get; set; }
        
        public DbSet<SectionItem> SectionItems { get; set; }

        public DbSet<SectionItemField> SectionItemFields { get; set; }

        public DbSet<SectionItemFieldTranslation> SectionItemFieldTranslations { get; set; }

        public DbSet<SectionItemFieldValue> SectionItemFieldValues { get; set; }

        public DbSet<SectionItemFieldValueTranslation> SectionItemFieldValueTranslations { get; set; }

        public DbSet<SectionItemTranslation> SectionItemTranslations { get; set; }

        public DbSet<SectionItemValue> SectionItemValues { get; set; }
        
        public DbSet<SectionTranslation> SectionTranslations { get; set; }

        public DbSet<SectionTypeTemplate> SectionTypeTemplates { get; set; }

        public DbSet<Template> Templates { get; set; }

        public DbSet<TemplateTranslation> TemplateTranslations { get; set; }

        public DbSet<Announcement> Announcements { get; set; }

        public DbSet<AnnouncementTranslation> AnnouncementTranslations { get; set; }

        // Localization
        public DbSet<LocalizationValue> LocalizationValues { get; set; }

        // Metadata - Product Management
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductTranslation> ProductTranslations { get; set; }
        public DbSet<Variant> Variants { get; set; }
        public DbSet<VariantTranslation> VariantTranslations { get; set; }
        public DbSet<Trademark> Trademarks { get; set; }
        public DbSet<TrademarkTranslation> TrademarkTranslations { get; set; }
        public DbSet<CategoryProduct> CategoryProducts { get; set; }
        public DbSet<TrademarkProduct> TrademarkProducts { get; set; }
        public DbSet<Option> Options { get; set; }
        public DbSet<OptionTranslation> OptionTranslations { get; set; }
        public DbSet<ProductOption> ProductOptions { get; set; }

        // Data Schema System
        public DbSet<DataSchema> DataSchemas { get; set; }
        public DbSet<DataSchemaField> DataSchemaFields { get; set; }
        public DbSet<DataSchemaFieldValue> DataSchemaFieldValues { get; set; }
        public DbSet<ProductDataSchema> ProductDataSchemas { get; set; }
        public DbSet<DataSchemaTranslation> DataSchemaTranslations { get; set; }
        public DbSet<DataSchemaFieldTranslation> DataSchemaFieldTranslations { get; set; }
        public DbSet<DataSchemaFieldValueTranslation> DataSchemaFieldValueTranslations { get; set; }

        // Agent Marketplace
        public DbSet<Agent> Agents { get; set; }
        public DbSet<AgentTranslation> AgentTranslations { get; set; }
        public DbSet<AgentPricing> AgentPricings { get; set; }
        public DbSet<AgentPricingTranslation> AgentPricingTranslations { get; set; }
        public DbSet<AgentCapability> AgentCapabilities { get; set; }
        public DbSet<AgentCapabilityTranslation> AgentCapabilityTranslations { get; set; }
        public DbSet<AgentSubscription> AgentSubscriptions { get; set; }
        public DbSet<AgentIntegration> AgentIntegrations { get; set; }
        public DbSet<AgentIntegrationTranslation> AgentIntegrationTranslations { get; set; }
        public DbSet<AgentUsageLog> AgentUsageLogs { get; set; }
        public DbSet<AgentIntegrationLog> AgentIntegrationLogs { get; set; }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            var now = DateTime.UtcNow;

            foreach (var entry in ChangeTracker.Entries<Entity<int>>())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.CreatedAt = now;
                        entry.Entity.CreatedBy = 1; // Will be replaced with actual user
                        break;
                    case EntityState.Modified:
                        entry.Entity.UpdatedAt = now;
                        entry.Entity.UpdatedBy = 1; // Will be replaced with actual user
                        break;
                }
            }

            return await base.SaveChangesAsync(cancellationToken);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Apply entity configurations
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(PazarAtlasiDbContext).Assembly);
        }
    }
}