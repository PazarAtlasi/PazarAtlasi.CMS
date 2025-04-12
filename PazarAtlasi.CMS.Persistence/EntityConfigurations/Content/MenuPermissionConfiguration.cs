using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PazarAtlasi.CMS.Domain.Entities.Content;

namespace PazarAtlasi.CMS.Persistence.EntityConfigurations.Content
{
    public class MenuPermissionConfiguration : IEntityTypeConfiguration<MenuPermission>
    {
        public void Configure(EntityTypeBuilder<MenuPermission> builder)
        {
            builder.ToTable("MenuPermissions");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.RoleId)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(x => x.HasAccess)
                .IsRequired()
                .HasDefaultValue(true);

            builder.HasOne(x => x.MenuItem)
                .WithMany(x => x.MenuPermissions)
                .HasForeignKey(x => x.MenuItemId)
                .OnDelete(DeleteBehavior.Cascade);

            // Create a unique index on MenuItemId and RoleId
            builder.HasIndex(x => new { x.MenuItemId, x.RoleId })
                .IsUnique()
                .HasFilter("IsDeleted = 0");
        }
    }
} 