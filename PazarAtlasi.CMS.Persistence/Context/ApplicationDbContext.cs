using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PazarAtlasi.CMS.Domain.Common;
using PazarAtlasi.CMS.Domain.Entities.Announcement;
using PazarAtlasi.CMS.Domain.Entities.Content;

namespace PazarAtlasi.CMS.Persistence.Context
{
    public class PazarAtlasiDbContext : DbContext
    {
        public PazarAtlasiDbContext(DbContextOptions<PazarAtlasiDbContext> options)
            : base(options)
        {
        }

        public DbSet<Content> Contents { get; set; }

        public DbSet<Language> Languages { get; set; }

        public DbSet<Layout> Layouts { get; set; }

        public DbSet<LayoutSection> LayoutSections { get; set; }

        public DbSet<Page> Pages { get; set; }

        public DbSet<PageSection> PageSections { get; set; }

        public DbSet<PageSEOParameter> PageSEOParameters { get; set; }

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