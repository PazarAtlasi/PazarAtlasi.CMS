using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PazarAtlasi.CMS.Domain.Entities.Content;

namespace PazarAtlasi.CMS.Persistence.EntityConfigurations.Content
{
    public class MenuItemIconConfiguration : IEntityTypeConfiguration<MenuItemIcon>
    {
        public void Configure(EntityTypeBuilder<MenuItemIcon> builder)
        {
            builder.ToTable("MenuItemIcons");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.IconPosition)
                .IsRequired()
                .HasMaxLength(50)
                .HasDefaultValue("left");

            builder.HasOne(x => x.MenuItem)
                .WithMany(x => x.MenuItemIcons)
                .HasForeignKey(x => x.MenuItemId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(x => x.Icon)
                .WithMany(x => x.MenuItemIcons)
                .HasForeignKey(x => x.IconId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
} 