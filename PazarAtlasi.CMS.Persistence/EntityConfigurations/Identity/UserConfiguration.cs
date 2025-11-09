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
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("Users").HasKey(u => u.Id);

            builder.Property(u => u.Id).HasColumnName("Id").IsRequired();
            builder.Property(u => u.FirstName).HasColumnName("FirstName").HasMaxLength(50).IsRequired();
            builder.Property(u => u.LastName).HasColumnName("LastName").HasMaxLength(50).IsRequired();
            builder.Property(u => u.Email).HasColumnName("Email").HasMaxLength(100).IsRequired();
            builder.Property(u => u.PasswordHash).HasColumnName("PasswordHash").HasMaxLength(500).IsRequired();
            builder.Property(u => u.PhoneNumber).HasColumnName("PhoneNumber").HasMaxLength(20);
            builder.Property(u => u.Gender).HasColumnName("Gender");
            builder.Property(u => u.MotherName).HasColumnName("MotherName").HasMaxLength(50);
            builder.Property(u => u.FatherName).HasColumnName("FatherName").HasMaxLength(50).IsRequired();

            builder.HasQueryFilter(u => !u.IsDeleted);

            // Seed data for Users
            var currentDateTime = DateTime.Now;
        }
    }
}
