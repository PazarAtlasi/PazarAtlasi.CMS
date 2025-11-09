using PazarAtlasi.CMS.Domain.Common;
using PazarAtlasi.CMS.Domain.Enums;

namespace PazarAtlasi.CMS.Domain.Entities.AgentMarketplace
{
    /// <summary>
    /// Junction table for agent integrations (n8n, custom APIs, webhooks, etc.)
    /// This allows flexible integration configurations without modifying the main Agent entity
    /// </summary>
    public class AgentIntegration : Entity<int>
    {
        public int AgentId { get; set; }
        
        /// <summary>
        /// Type of integration (N8n, CustomAPI, Webhook, Internal, etc.)
        /// </summary>
        public IntegrationType Type { get; set; }
        
        /// <summary>
        /// Integration name/identifier
        /// </summary>
        public string Name { get; set; } = string.Empty;
        
        /// <summary>
        /// JSON configuration for this integration
        /// For n8n: {"workflowId": "123", "webhookUrl": "...", "apiKey": "..."}
        /// For custom API: {"endpoint": "...", "method": "POST", "headers": {...}}
        /// </summary>
        public string ConfigurationJson { get; set; } = "{}";
        
        /// <summary>
        /// Whether this integration is currently active
        /// </summary>
        public bool IsActive { get; set; } = true;
        
        /// <summary>
        /// Priority order for multiple integrations
        /// </summary>
        public int Priority { get; set; } = 0;
        
        /// <summary>
        /// When this integration should be triggered
        /// </summary>
        public IntegrationTrigger TriggerType { get; set; }
        
        /// <summary>
        /// Additional metadata for the integration
        /// </summary>
        public string? Metadata { get; set; }
        
        // Navigation Properties
        public virtual Agent Agent { get; set; } = null!;
        public virtual ICollection<AgentIntegrationLog> Logs { get; set; } = new List<AgentIntegrationLog>();
        public virtual ICollection<AgentIntegrationTranslation> Translations { get; set; } = new List<AgentIntegrationTranslation>();
    }
}
