using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PazarAtlasi.CMS.Domain.Entities.AgentMarketplace;
using PazarAtlasi.CMS.Domain.Common;

namespace PazarAtlasi.CMS.Persistence.EntityConfigurations.AgentMarketplace
{
    public class AgentIntegrationTranslationConfiguration : IEntityTypeConfiguration<AgentIntegrationTranslation>
    {
        public void Configure(EntityTypeBuilder<AgentIntegrationTranslation> builder)
        {
            builder.ToTable("AgentIntegrationTranslations").HasKey(t => t.Id);

            builder.Property(t => t.Id).HasColumnName("Id").IsRequired();
            builder.Property(t => t.AgentIntegrationId).HasColumnName("AgentIntegrationId").IsRequired();
            builder.Property(t => t.LanguageId).HasColumnName("LanguageId").IsRequired();
            builder.Property(t => t.Name).HasColumnName("Name").HasMaxLength(200).IsRequired();
            builder.Property(t => t.Description).HasColumnName("Description").HasMaxLength(500);
            
            // Base Entity Properties
            builder.Property(t => t.CreatedAt).HasColumnName("CreatedAt").IsRequired();
            builder.Property(t => t.UpdatedAt).HasColumnName("UpdatedAt");
            builder.Property(t => t.IsDeleted).HasColumnName("IsDeleted").HasDefaultValue(false);
            builder.Property(t => t.Status).HasColumnName("Status").HasDefaultValue(Status.Active);
            builder.Property(t => t.CreatedBy).HasColumnName("CreatedBy");
            builder.Property(t => t.UpdatedBy).HasColumnName("UpdatedBy");

            // Relationships
            builder.HasOne(t => t.AgentIntegration)
                   .WithMany(i => i.Translations)
                   .HasForeignKey(t => t.AgentIntegrationId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(t => t.Language)
                   .WithMany()
                   .HasForeignKey(t => t.LanguageId)
                   .OnDelete(DeleteBehavior.Cascade);

            // Indexes
            builder.HasIndex(t => t.AgentIntegrationId).HasDatabaseName("IX_AgentIntegrationTranslations_AgentIntegrationId");
            builder.HasIndex(t => t.LanguageId).HasDatabaseName("IX_AgentIntegrationTranslations_LanguageId");
            builder.HasIndex(t => new { t.AgentIntegrationId, t.LanguageId }).HasDatabaseName("IX_AgentIntegrationTranslations_Integration_Language").IsUnique();

            // Query Filter
            builder.HasQueryFilter(t => !t.IsDeleted);
        }
    }
}
