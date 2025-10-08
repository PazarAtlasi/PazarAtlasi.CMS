using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PazarAtlasi.CMS.Domain.Common;

namespace PazarAtlasi.CMS.Persistence.Context
{
    public class PazarAtlasiDbContext : DbContext
    {
        public PazarAtlasiDbContext(DbContextOptions<PazarAtlasiDbContext> options)
            : base(options)
        {
        }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            var now = DateTime.UtcNow;

            foreach (var entry in ChangeTracker.Entries<Entity>())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.CreatedAt = now;
                        entry.Entity.CreatedBy = "system"; // Will be replaced with actual user
                        break;
                    case EntityState.Modified:
                        entry.Entity.UpdatedAt = now;
                        entry.Entity.UpdatedBy = "system"; // Will be replaced with actual user
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