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
    public class UserRoleConfiguration : IEntityTypeConfiguration<UserRole>
    {
        public void Configure(EntityTypeBuilder<UserRole> builder)
        {
            builder.ToTable("UserRoles").HasKey(ur => ur.Id);

            builder.Property(ur => ur.Id).HasColumnName("Id").IsRequired();
            builder.Property(ur => ur.UserId).HasColumnName("UserId").IsRequired();
            builder.Property(ur => ur.RoleId).HasColumnName("RoleId").IsRequired();

            builder.HasOne(ur => ur.User)
                   .WithMany(u => u.UserRoles)
                   .HasForeignKey(ur => ur.UserId);

            builder.HasOne(ur => ur.Role)
                   .WithMany(r => r.UserRoles)
                   .HasForeignKey(ur => ur.RoleId);

            builder.HasQueryFilter(ur => !ur.IsDeleted);

            // Seed data for UserRoles
            var currentDateTime = DateTime.Now;
        }
    }
}
