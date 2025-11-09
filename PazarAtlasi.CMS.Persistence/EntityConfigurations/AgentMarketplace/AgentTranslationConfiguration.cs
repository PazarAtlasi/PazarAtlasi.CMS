using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PazarAtlasi.CMS.Domain.Entities.AgentMarketplace;
using PazarAtlasi.CMS.Domain.Common;

namespace PazarAtlasi.CMS.Persistence.EntityConfigurations.AgentMarketplace
{
    public class AgentTranslationConfiguration : IEntityTypeConfiguration<AgentTranslation>
    {
        public void Configure(EntityTypeBuilder<AgentTranslation> builder)
        {
            builder.ToTable("AgentTranslations").HasKey(t => t.Id);

            builder.Property(t => t.Id).HasColumnName("Id").IsRequired();
            builder.Property(t => t.AgentId).HasColumnName("AgentId").IsRequired();
            builder.Property(t => t.LanguageId).HasColumnName("LanguageId").IsRequired();
            builder.Property(t => t.Name).HasColumnName("Name").HasMaxLength(200).IsRequired();
            builder.Property(t => t.Description).HasColumnName("Description").HasMaxLength(500).IsRequired();
            builder.Property(t => t.DetailedDescription).HasColumnName("DetailedDescription").HasColumnType("nvarchar(max)").IsRequired();
            
            // Base Entity Properties
            builder.Property(t => t.CreatedAt).HasColumnName("CreatedAt").IsRequired();
            builder.Property(t => t.UpdatedAt).HasColumnName("UpdatedAt");
            builder.Property(t => t.IsDeleted).HasColumnName("IsDeleted").HasDefaultValue(false);
            builder.Property(t => t.Status).HasColumnName("Status").HasDefaultValue(Status.Active);
            builder.Property(t => t.CreatedBy).HasColumnName("CreatedBy");
            builder.Property(t => t.UpdatedBy).HasColumnName("UpdatedBy");

            // Relationships
            builder.HasOne(t => t.Agent)
                   .WithMany(a => a.Translations)
                   .HasForeignKey(t => t.AgentId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(t => t.Language)
                   .WithMany()
                   .HasForeignKey(t => t.LanguageId)
                   .OnDelete(DeleteBehavior.Cascade);

            // Indexes
            builder.HasIndex(t => t.AgentId).HasDatabaseName("IX_AgentTranslations_AgentId");
            builder.HasIndex(t => t.LanguageId).HasDatabaseName("IX_AgentTranslations_LanguageId");
            builder.HasIndex(t => new { t.AgentId, t.LanguageId }).HasDatabaseName("IX_AgentTranslations_AgentId_LanguageId").IsUnique();

            // Query Filter
            builder.HasQueryFilter(t => !t.IsDeleted);
        }
    }
}
