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
    public class RoleOperationalClaimConfiguration : IEntityTypeConfiguration<RoleOperationalClaim>
    {
        public void Configure(EntityTypeBuilder<RoleOperationalClaim> builder)
        {
            builder.ToTable("RoleOperationalClaims").HasKey(roc => roc.Id);

            builder.Property(roc => roc.Id).HasColumnName("Id").IsRequired();
            builder.Property(roc => roc.RoleId).HasColumnName("RoleId").IsRequired();
            builder.Property(roc => roc.OperationalClaimId).HasColumnName("OperationalClaimId").IsRequired();

            builder.HasOne(roc => roc.Role)
                   .WithMany(r => r.RoleOperationalClaims)
                   .HasForeignKey(roc => roc.RoleId);

            builder.HasOne(roc => roc.OperationalClaim)
                   .WithMany(r => r.RoleOperationalClaims)
                   .HasForeignKey(roc => roc.OperationalClaimId);

            builder.HasQueryFilter(roc => !roc.IsDeleted);

            // Seed data for RoleOperationalClaims
            var currentDateTime = DateTime.Now;
        }
    }
}
