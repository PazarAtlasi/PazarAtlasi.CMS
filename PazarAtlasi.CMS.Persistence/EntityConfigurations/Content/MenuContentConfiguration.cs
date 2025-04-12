using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PazarAtlasi.CMS.Domain.Entities.Content;

namespace PazarAtlasi.CMS.Persistence.EntityConfigurations.Content
{
    public class MenuContentConfiguration : IEntityTypeConfiguration<MenuContent>
    {
        public void Configure(EntityTypeBuilder<MenuContent> builder)
        {
            builder.ToTable("MenuContents");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.ContentJson)
                .IsRequired()
                .HasColumnType("nvarchar(max)");

            builder.HasOne(x => x.MenuItem)
                .WithMany(x => x.MenuContents)
                .HasForeignKey(x => x.MenuItemId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
} 