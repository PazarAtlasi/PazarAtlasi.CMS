using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PazarAtlasi.CMS.Domain.Entities.AgentMarketplace;
using PazarAtlasi.CMS.Domain.Common;

namespace PazarAtlasi.CMS.Persistence.EntityConfigurations.AgentMarketplace
{
    public class AgentCapabilityTranslationConfiguration : IEntityTypeConfiguration<AgentCapabilityTranslation>
    {
        public void Configure(EntityTypeBuilder<AgentCapabilityTranslation> builder)
        {
            builder.ToTable("AgentCapabilityTranslations").HasKey(t => t.Id);

            builder.Property(t => t.Id).HasColumnName("Id").IsRequired();
            builder.Property(t => t.AgentCapabilityId).HasColumnName("AgentCapabilityId").IsRequired();
            builder.Property(t => t.LanguageId).HasColumnName("LanguageId").IsRequired();
            builder.Property(t => t.Name).HasColumnName("Name").HasMaxLength(200).IsRequired();
            builder.Property(t => t.Description).HasColumnName("Description").HasMaxLength(500).IsRequired();
            
            // Base Entity Properties
            builder.Property(t => t.CreatedAt).HasColumnName("CreatedAt").IsRequired();
            builder.Property(t => t.UpdatedAt).HasColumnName("UpdatedAt");
            builder.Property(t => t.IsDeleted).HasColumnName("IsDeleted").HasDefaultValue(false);
            builder.Property(t => t.Status).HasColumnName("Status").HasDefaultValue(Status.Active);
            builder.Property(t => t.CreatedBy).HasColumnName("CreatedBy");
            builder.Property(t => t.UpdatedBy).HasColumnName("UpdatedBy");

            // Relationships
            builder.HasOne(t => t.AgentCapability)
                   .WithMany(c => c.Translations)
                   .HasForeignKey(t => t.AgentCapabilityId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(t => t.Language)
                   .WithMany()
                   .HasForeignKey(t => t.LanguageId)
                   .OnDelete(DeleteBehavior.Cascade);

            // Indexes
            builder.HasIndex(t => t.AgentCapabilityId).HasDatabaseName("IX_AgentCapabilityTranslations_AgentCapabilityId");
            builder.HasIndex(t => t.LanguageId).HasDatabaseName("IX_AgentCapabilityTranslations_LanguageId");
            builder.HasIndex(t => new { t.AgentCapabilityId, t.LanguageId }).HasDatabaseName("IX_AgentCapabilityTranslations_Capability_Language").IsUnique();

            // Query Filter
            builder.HasQueryFilter(t => !t.IsDeleted);
        }
    }
}
