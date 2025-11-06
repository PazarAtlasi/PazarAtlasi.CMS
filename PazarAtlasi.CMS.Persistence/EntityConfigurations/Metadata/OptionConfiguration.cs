using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PazarAtlasi.CMS.Domain.Entities.Metadata;

namespace PazarAtlasi.CMS.Persistence.EntityConfigurations.Metadata
{
    public class OptionConfiguration : IEntityTypeConfiguration<Option>
    {
        public void Configure(EntityTypeBuilder<Option> builder)
        {
            // Table name and primary key
            builder.ToTable("Options").HasKey(o => o.Id);

            // Properties
            builder.Property(o => o.Id).HasColumnName("Id").IsRequired();
            builder.Property(o => o.ParentId).HasColumnName("ParentId");
            builder.Property(o => o.Name).HasColumnName("Name").IsRequired().HasMaxLength(255);
            builder.Property(o => o.Code).HasColumnName("Code").IsRequired().HasMaxLength(100);
            builder.Property(o => o.IntegrationCode).HasColumnName("IntegrationCode").HasMaxLength(100);
            builder.Property(o => o.ShortDescription).HasColumnName("ShortDescription").HasMaxLength(500);
            builder.Property(o => o.LongDescription).HasColumnName("LongDescription").HasMaxLength(2000);
            builder.Property(o => o.Type).HasColumnName("Type").HasDefaultValue(Domain.Common.OptionType.Text);
            builder.Property(o => o.DefaultValue).HasColumnName("DefaultValue").HasMaxLength(500);
            builder.Property(o => o.IsRequired).HasColumnName("IsRequired").HasDefaultValue(false);
            builder.Property(o => o.AllowMultipleSelection).HasColumnName("AllowMultipleSelection").HasDefaultValue(false);
            builder.Property(o => o.SortOrder).HasColumnName("SortOrder").HasDefaultValue(0);
            builder.Property(o => o.Status).HasColumnName("Status").HasDefaultValue(Domain.Common.Status.Active);
            builder.Property(o => o.CreatedAt).HasColumnName("CreatedAt").IsRequired();
            builder.Property(o => o.UpdatedAt).HasColumnName("UpdatedAt");
            builder.Property(o => o.IsDeleted).HasColumnName("IsDeleted").HasDefaultValue(false);

            // Relationships
            builder.HasOne(o => o.ParentOption)
                   .WithMany(o => o.ChildOptions)
                   .HasForeignKey(o => o.ParentId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(o => o.Translations)
                   .WithOne(ot => ot.Option)
                   .HasForeignKey(ot => ot.OptionId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(o => o.ProductOptions)
                   .WithOne(po => po.Option)
                   .HasForeignKey(po => po.OptionId)
                   .OnDelete(DeleteBehavior.Cascade);

            // Indexes
            builder.HasIndex(o => o.Code).HasDatabaseName("IX_Options_Code").IsUnique();
            builder.HasIndex(o => o.IntegrationCode).HasDatabaseName("IX_Options_IntegrationCode");
            builder.HasIndex(o => o.Type).HasDatabaseName("IX_Options_Type");
            builder.HasIndex(o => o.Status).HasDatabaseName("IX_Options_Status");
            builder.HasIndex(o => o.ParentId).HasDatabaseName("IX_Options_ParentId");
            builder.HasIndex(o => o.SortOrder).HasDatabaseName("IX_Options_SortOrder");

            // Query Filter (Soft Delete)
            builder.HasQueryFilter(o => !o.IsDeleted);

            // Seed Data
            builder.HasData(
                new Option { Id = 1, Name = "Color", Code = "color", Type = Domain.Common.OptionType.Color, SortOrder = 1, Status = Domain.Common.Status.Active, CreatedAt = DateTime.UtcNow, IsDeleted = false },
                new Option { Id = 2, Name = "Size", Code = "size", Type = Domain.Common.OptionType.Size, SortOrder = 2, Status = Domain.Common.Status.Active, CreatedAt = DateTime.UtcNow, IsDeleted = false },
                new Option { Id = 3, Name = "Material", Code = "material", Type = Domain.Common.OptionType.Material, SortOrder = 3, Status = Domain.Common.Status.Active, CreatedAt = DateTime.UtcNow, IsDeleted = false },
                new Option { Id = 4, Name = "Weight", Code = "weight", Type = Domain.Common.OptionType.Number, SortOrder = 4, Status = Domain.Common.Status.Active, CreatedAt = DateTime.UtcNow, IsDeleted = false },
                new Option { Id = 5, Name = "Warranty", Code = "warranty", Type = Domain.Common.OptionType.Dropdown, SortOrder = 5, Status = Domain.Common.Status.Active, CreatedAt = DateTime.UtcNow, IsDeleted = false }
            );
        }
    }
}