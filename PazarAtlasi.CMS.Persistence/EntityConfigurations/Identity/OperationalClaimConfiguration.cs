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
    public class OperationalClaimConfiguration : IEntityTypeConfiguration<OperationalClaim>
    {
        public void Configure(EntityTypeBuilder<OperationalClaim> builder)
        {
            builder.ToTable("OperationalClaims").HasKey(oc => oc.Id);

            builder.Property(oc => oc.Id).HasColumnName("Id").IsRequired();
            builder.Property(oc => oc.Name).HasColumnName("Name").HasMaxLength(255).IsRequired();
            builder.Property(oc => oc.DisplayName).HasColumnName("DisplayName").HasMaxLength(255);
            builder.Property(oc => oc.Description).HasColumnName("Description").HasMaxLength(1000);

            builder.HasMany(oc => oc.RoleOperationalClaims)
                   .WithOne(roc => roc.OperationalClaim);

            builder.HasQueryFilter(oc => !oc.IsDeleted);

            // Seed data for OperationalClaims
            var currentDateTime = DateTime.Now;
        }
    }
}
