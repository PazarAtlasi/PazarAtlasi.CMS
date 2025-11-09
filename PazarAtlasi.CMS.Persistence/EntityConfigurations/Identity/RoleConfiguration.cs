using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PazarAtlasi.CMS.Domain.Entities.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PazarAtlasi.CMS.Persistence.EntityConfigurations.Identity
{
    public class RoleConfiguration : IEntityTypeConfiguration<Role>
    {
        public void Configure(EntityTypeBuilder<Role> builder)
        {
            builder.ToTable("Roles").HasKey(r => r.Id);

            builder.Property(r => r.Id).HasColumnName("Id").IsRequired();
            builder.Property(r => r.Name).HasColumnName("Name").HasMaxLength(255).IsRequired();
            builder.Property(r => r.Description).HasColumnName("Description").HasMaxLength(1000);
            builder.Property(r => r.NormalizedName).HasColumnName("NormalizedName").HasMaxLength(255);

            builder.HasMany(afs => afs.RoleOperationalClaims)
                   .WithOne(af => af.Role);

            builder.HasQueryFilter(r => !r.IsDeleted);

            // Seed data
            var currentDateTime = DateTime.Now;
        }
    }
}
