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
    public class UserLoginConfiguration : IEntityTypeConfiguration<UserLogin>
    {
        public void Configure(EntityTypeBuilder<UserLogin> builder)
        {
            builder.ToTable("UserLogins");

            builder.HasKey(ul => ul.Id);

            builder.Property(ul => ul.UserId)
                .IsRequired();

            builder.Property(ul => ul.LogoutTime);

            builder.Property(ul => ul.IpAddress)
                .HasMaxLength(45);

            builder.Property(ul => ul.UserAgent)
                .HasMaxLength(500);

            builder.Property(ul => ul.IsSuccessful)
                .IsRequired();

            builder.Property(ul => ul.FailureReason)
                .HasMaxLength(200);

            builder.Property(ul => ul.SessionId)
                .HasMaxLength(100);

            builder.Property(ul => ul.DeviceInfo)
                .HasMaxLength(200);

            builder.Property(ul => ul.Location)
                .HasMaxLength(100);

            builder.Property(ul => ul.Status)
                .IsRequired();

            // Relationships
            builder.HasOne(ul => ul.User)
                .WithMany(u => u.UserLogins)
                .HasForeignKey(ul => ul.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasQueryFilter(ul => !ul.IsDeleted);
        }
    }
}
