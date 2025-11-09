namespace PazarAtlasi.CMS.Domain.Enums
{
    /// <summary>
    /// Types of agents available in the marketplace
    /// </summary>
    public enum AgentType
    {
        Reporting = 1,
        CallCenter = 2,
        DataProcessing = 3,
        Integration = 4,
        Analytics = 5,
        Automation = 6,
        Communication = 7,
        ContentGeneration = 8,
        CustomerService = 9,
        Marketing = 10
    }

    /// <summary>
    /// Categories for organizing agents
    /// </summary>
    public enum AgentCategory
    {
        Business = 1,
        Technical = 2,
        Marketing = 3,
        Sales = 4,
        Support = 5,
        Analytics = 6,
        Communication = 7,
        Content = 8,
        Automation = 9,
        Integration = 10
    }

    /// <summary>
    /// Pricing models for agents
    /// </summary>
    public enum PricingType
    {
        Monthly = 1,      // $4/month
        PerUse = 2,       // Per usage/execution
        PerAgent = 3,     // Per agent count (like call center agents)
        OneTime = 4,      // One-time purchase
        Annual = 5,       // Annual subscription
        Custom = 6        // Custom pricing
    }

    /// <summary>
    /// How agents execute
    /// </summary>
    public enum AgentExecutionType
    {
        Background = 1,   // Continuously running
        OnDemand = 2,     // Triggered when needed
        Scheduled = 3,    // Runs on schedule
        EventDriven = 4   // Triggered by events
    }

    /// <summary>
    /// Subscription status
    /// </summary>
    public enum SubscriptionStatus
    {
        Active = 1,
        Paused = 2,
        Cancelled = 3,
        Expired = 4,
        PendingActivation = 5,
        Suspended = 6
    }

    /// <summary>
    /// Agent execution status
    /// </summary>
    public enum AgentExecutionStatus
    {
        Success = 1,
        Failed = 2,
        Timeout = 3,
        Cancelled = 4,
        InProgress = 5,
        Queued = 6
    }

    /// <summary>
    /// Integration types
    /// </summary>
    public enum IntegrationType
    {
        N8n = 1,           // n8n workflow integration
        CustomAPI = 2,     // Custom REST API
        Webhook = 3,       // Webhook endpoint
        Internal = 4,      // Internal C# method
        Database = 5,      // Direct database operation
        Queue = 6,         // Message queue (RabbitMQ, etc.)
        Email = 7,         // Email service
        SMS = 8,           // SMS service
        FileSystem = 9,    // File system operations
        GraphQL = 10,      // GraphQL API
        SOAP = 11,         // SOAP web service
        FTP = 12          // FTP/SFTP operations
    }

    /// <summary>
    /// When integrations should be triggered
    /// </summary>
    public enum IntegrationTrigger
    {
        OnSubscription = 1,    // When user subscribes
        OnDemand = 2,          // When manually triggered
        Scheduled = 3,         // On schedule (cron-like)
        Background = 4,        // Continuous background process
        OnEvent = 5,           // On specific system events
        OnWebhook = 6,         // On webhook call
        OnDataChange = 7,      // When data changes
        OnUserAction = 8       // When user performs specific action
    }

    /// <summary>
    /// Integration execution status
    /// </summary>
    public enum IntegrationExecutionStatus
    {
        Success = 1,
        Failed = 2,
        Timeout = 3,
        Cancelled = 4,
        InProgress = 5,
        Retrying = 6,
        PartialSuccess = 7
    }
}
