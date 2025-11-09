using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PazarAtlasi.CMS.Domain.Entities.AgentMarketplace;
using PazarAtlasi.CMS.Domain.Common;

namespace PazarAtlasi.CMS.Persistence.EntityConfigurations.AgentMarketplace
{
    public class AgentPricingTranslationConfiguration : IEntityTypeConfiguration<AgentPricingTranslation>
    {
        public void Configure(EntityTypeBuilder<AgentPricingTranslation> builder)
        {
            builder.ToTable("AgentPricingTranslations").HasKey(t => t.Id);

            builder.Property(t => t.Id).HasColumnName("Id").IsRequired();
            builder.Property(t => t.AgentPricingId).HasColumnName("AgentPricingId").IsRequired();
            builder.Property(t => t.LanguageId).HasColumnName("LanguageId").IsRequired();
            builder.Property(t => t.Description).HasColumnName("Description").HasMaxLength(500).IsRequired();
            builder.Property(t => t.Features).HasColumnName("Features").HasColumnType("nvarchar(max)");
            
            // Base Entity Properties
            builder.Property(t => t.CreatedAt).HasColumnName("CreatedAt").IsRequired();
            builder.Property(t => t.UpdatedAt).HasColumnName("UpdatedAt");
            builder.Property(t => t.IsDeleted).HasColumnName("IsDeleted").HasDefaultValue(false);
            builder.Property(t => t.Status).HasColumnName("Status").HasDefaultValue(Status.Active);
            builder.Property(t => t.CreatedBy).HasColumnName("CreatedBy");
            builder.Property(t => t.UpdatedBy).HasColumnName("UpdatedBy");

            // Relationships
            builder.HasOne(t => t.AgentPricing)
                   .WithMany(p => p.Translations)
                   .HasForeignKey(t => t.AgentPricingId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(t => t.Language)
                   .WithMany()
                   .HasForeignKey(t => t.LanguageId)
                   .OnDelete(DeleteBehavior.Cascade);

            // Indexes
            builder.HasIndex(t => t.AgentPricingId).HasDatabaseName("IX_AgentPricingTranslations_AgentPricingId");
            builder.HasIndex(t => t.LanguageId).HasDatabaseName("IX_AgentPricingTranslations_LanguageId");
            builder.HasIndex(t => new { t.AgentPricingId, t.LanguageId }).HasDatabaseName("IX_AgentPricingTranslations_Pricing_Language").IsUnique();

            // Query Filter
            builder.HasQueryFilter(t => !t.IsDeleted);
        }
    }
}
