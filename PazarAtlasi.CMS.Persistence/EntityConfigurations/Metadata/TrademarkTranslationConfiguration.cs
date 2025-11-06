using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PazarAtlasi.CMS.Domain.Entities.Metadata;

namespace PazarAtlasi.CMS.Persistence.EntityConfigurations.Metadata
{
    public class TrademarkTranslationConfiguration : IEntityTypeConfiguration<TrademarkTranslation>
    {
        public void Configure(EntityTypeBuilder<TrademarkTranslation> builder)
        {
            // Table name and primary key
            builder.ToTable("TrademarkTranslations").HasKey(tt => tt.Id);

            // Properties
            builder.Property(tt => tt.Id).HasColumnName("Id").IsRequired();
            builder.Property(tt => tt.TrademarkId).HasColumnName("TrademarkId").IsRequired();
            builder.Property(tt => tt.LanguageId).HasColumnName("LanguageId").IsRequired();
            builder.Property(tt => tt.Name).HasColumnName("Name").IsRequired().HasMaxLength(255);
            builder.Property(tt => tt.ShortDescription).HasColumnName("ShortDescription").HasMaxLength(500);
            builder.Property(tt => tt.LongDescription).HasColumnName("LongDescription").HasMaxLength(2000);
            builder.Property(tt => tt.Status).HasColumnName("Status").HasDefaultValue(Domain.Common.Status.Active);
            builder.Property(tt => tt.CreatedAt).HasColumnName("CreatedAt").IsRequired();
            builder.Property(tt => tt.UpdatedAt).HasColumnName("UpdatedAt");
            builder.Property(tt => tt.IsDeleted).HasColumnName("IsDeleted").HasDefaultValue(false);

            // Relationships
            builder.HasOne(tt => tt.Trademark)
                   .WithMany(t => t.Translations)
                   .HasForeignKey(tt => tt.TrademarkId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(tt => tt.Language)
                   .WithMany()
                   .HasForeignKey(tt => tt.LanguageId)
                   .OnDelete(DeleteBehavior.Restrict);

            // Indexes
            builder.HasIndex(tt => new { tt.TrademarkId, tt.LanguageId })
                   .HasDatabaseName("IX_TrademarkTranslations_TrademarkId_LanguageId")
                   .IsUnique();

            // Query Filter (Soft Delete)
            builder.HasQueryFilter(tt => !tt.IsDeleted);
        }
    }
}