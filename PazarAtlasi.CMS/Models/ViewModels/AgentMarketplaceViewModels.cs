using PazarAtlasi.CMS.Domain.Entities.AgentMarketplace;
using PazarAtlasi.CMS.Domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace PazarAtlasi.CMS.Models.ViewModels
{
    // Agent Marketplace Index sayfası için ViewModel
    public class AgentMarketplaceIndexViewModel
    {
        public List<AgentCardViewModel> Agents { get; set; } = new List<AgentCardViewModel>();
        public List<AgentCategoryViewModel> Categories { get; set; } = new List<AgentCategoryViewModel>();
        public List<AgentTypeViewModel> Types { get; set; } = new List<AgentTypeViewModel>();
        public AgentMarketplaceFilterViewModel Filter { get; set; } = new AgentMarketplaceFilterViewModel();
        public int TotalCount { get; set; }
        public int PageSize { get; set; } = 12;
        public int CurrentPage { get; set; } = 1;
        public int TotalPages => (int)Math.Ceiling((double)TotalCount / PageSize);
    }

    // Agent kartları için ViewModel
    public class AgentCardViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string IconClass { get; set; } = string.Empty;
        public string? ImageUrl { get; set; }
        public AgentType Type { get; set; }
        public AgentCategory Category { get; set; }
        public bool IsFeatured { get; set; }
        public bool IsActive { get; set; }
        public List<AgentCapabilityViewModel> TopCapabilities { get; set; } = new List<AgentCapabilityViewModel>();
        public List<AgentPricingViewModel> Pricings { get; set; } = new List<AgentPricingViewModel>();
        public decimal? StartingPrice { get; set; }
        public string? StartingPriceCurrency { get; set; }
    }

    // Agent detay sayfası için ViewModel
    public class AgentDetailsViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string DetailedDescription { get; set; } = string.Empty;
        public string IconClass { get; set; } = string.Empty;
        public string? ImageUrl { get; set; }
        public AgentType Type { get; set; }
        public AgentCategory Category { get; set; }
        public AgentExecutionType ExecutionType { get; set; }
        public bool IsActive { get; set; }
        public bool IsFeatured { get; set; }
        public string Version { get; set; } = string.Empty;
        
        public List<AgentCapabilityViewModel> Capabilities { get; set; } = new List<AgentCapabilityViewModel>();
        public List<AgentPricingViewModel> Pricings { get; set; } = new List<AgentPricingViewModel>();
        public List<AgentIntegrationViewModel> Integrations { get; set; } = new List<AgentIntegrationViewModel>();
        
        // User subscription info (if logged in)
        public AgentSubscriptionViewModel? UserSubscription { get; set; }
        public bool CanTest { get; set; }
    }

    // Agent oluşturma/düzenleme için ViewModel
    public class AgentCreateEditViewModel
    {
        public int Id { get; set; }
        
        [Required(ErrorMessage = "Agent name is required")]
        [StringLength(200, ErrorMessage = "Name cannot exceed 200 characters")]
        public string Name { get; set; } = string.Empty;
        
        [Required(ErrorMessage = "Description is required")]
        [StringLength(500, ErrorMessage = "Description cannot exceed 500 characters")]
        public string Description { get; set; } = string.Empty;
        
        [StringLength(2000, ErrorMessage = "Detailed description cannot exceed 2000 characters")]
        public string? DetailedDescription { get; set; } = string.Empty;
        
        [Required(ErrorMessage = "Agent type is required")]
        public AgentType Type { get; set; }
        
        [Required(ErrorMessage = "Agent category is required")]
        public AgentCategory Category { get; set; }
        
        [Required(ErrorMessage = "Execution type is required")]
        public AgentExecutionType ExecutionType { get; set; }
        
        [StringLength(100, ErrorMessage = "Icon class cannot exceed 100 characters")]
        public string IconClass { get; set; } = "fas fa-robot";
        
        public string? ImageUrl { get; set; }
        public bool IsActive { get; set; } = true;
        public bool IsFeatured { get; set; } = false;
        public bool IsPublic { get; set; } = true;
        public int SortOrder { get; set; } = 0;
        public string Version { get; set; } = "1.0.0";
        
        // Capabilities
        public List<AgentCapabilityCreateEditViewModel> Capabilities { get; set; } = new List<AgentCapabilityCreateEditViewModel>();
        
        // Pricings
        public List<AgentPricingCreateEditViewModel> Pricings { get; set; } = new List<AgentPricingCreateEditViewModel>();
        
        // Integrations
        public List<AgentIntegrationCreateEditViewModel> Integrations { get; set; } = new List<AgentIntegrationCreateEditViewModel>();
        
        // For dropdowns
        public List<AgentTypeViewModel> AvailableAgentTypes { get; set; } = new List<AgentTypeViewModel>();
        public List<AgentCategoryViewModel> AvailableAgentCategories { get; set; } = new List<AgentCategoryViewModel>();
        public List<AgentExecutionTypeViewModel> AvailableExecutionTypes { get; set; } = new List<AgentExecutionTypeViewModel>();
        public List<IntegrationTypeViewModel> AvailableIntegrationTypes { get; set; } = new List<IntegrationTypeViewModel>();
        public List<IntegrationTriggerViewModel> AvailableIntegrationTriggers { get; set; } = new List<IntegrationTriggerViewModel>();
        
        // For backward compatibility
        public List<AgentTypeViewModel> AvailableTypes => AvailableAgentTypes;
        public List<AgentCategoryViewModel> AvailableCategories => AvailableAgentCategories;
    }

    // Agent Capability ViewModel
    public class AgentCapabilityViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string IconClass { get; set; } = string.Empty;
        public bool IsKeyFeature { get; set; }
        public int SortOrder { get; set; }
    }

    // Agent Pricing ViewModel
    public class AgentPricingViewModel
    {
        public int Id { get; set; }
        public PricingType Type { get; set; }
        public decimal Price { get; set; }
        public string Currency { get; set; } = "USD";
        public int? UsageLimit { get; set; }
        public bool IsDefault { get; set; }
        public string Description { get; set; } = string.Empty;
        public string Features { get; set; } = string.Empty;
        public int SortOrder { get; set; }
        public string TypeDisplayName => GetPricingTypeDisplayName(Type);
        public string FormattedPrice => $"{Price:F2} {Currency}";
        
        private string GetPricingTypeDisplayName(PricingType type)
        {
            return type switch
            {
                PricingType.Monthly => "Monthly",
                PricingType.PerUse => "Per Use",
                PricingType.PerAgent => "Per Agent",
                PricingType.OneTime => "One Time",
                _ => type.ToString()
            };
        }
    }

    // Agent Integration ViewModel
    public class AgentIntegrationViewModel
    {
        public int Id { get; set; }
        public IntegrationType Type { get; set; }
        public string Name { get; set; } = string.Empty;
        public string ConfigurationJson { get; set; } = "{}";
        public IntegrationTrigger TriggerType { get; set; }
        public int Priority { get; set; }
        public bool IsActive { get; set; }
        public string? Metadata { get; set; }
        public string TypeDisplayName => GetIntegrationTypeDisplayName(Type);
        
        private string GetIntegrationTypeDisplayName(IntegrationType type)
        {
            return type switch
            {
                IntegrationType.N8n => "N8n Workflow",
                IntegrationType.CustomAPI => "Custom API",
                IntegrationType.Webhook => "Webhook",
                IntegrationType.Internal => "Internal Service",
                _ => type.ToString()
            };
        }
    }

    // Agent Subscription ViewModel
    public class AgentSubscriptionViewModel
    {
        public int Id { get; set; }
        public int AgentId { get; set; }
        public string AgentName { get; set; } = string.Empty;
        public string UserId { get; set; } = string.Empty;
        public AgentPricingViewModel Pricing { get; set; } = new AgentPricingViewModel();
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public SubscriptionStatus Status { get; set; }
        public int CurrentUsage { get; set; }
        public int? UsageLimit { get; set; }
        public int AgentCount { get; set; }
        public decimal TotalCost { get; set; }
        public DateTime? NextBillingDate { get; set; }
        public string StatusDisplayName => GetStatusDisplayName(Status);
        public bool IsActive => Status == SubscriptionStatus.Active;
        public bool HasUsageLimit => UsageLimit.HasValue;
        public double UsagePercentage => HasUsageLimit ? (double)CurrentUsage / UsageLimit.Value * 100 : 0;
        
        private string GetStatusDisplayName(SubscriptionStatus status)
        {
            return status switch
            {
                SubscriptionStatus.Active => "Active",
                SubscriptionStatus.Expired => "Expired",
                SubscriptionStatus.Cancelled => "Cancelled",
                SubscriptionStatus.Suspended => "Suspended",
                _ => status.ToString()
            };
        }
    }

    // Filter ViewModel
    public class AgentMarketplaceFilterViewModel
    {
        public string? SearchTerm { get; set; }
        public AgentCategory? Category { get; set; }
        public AgentType? Type { get; set; }
        public PricingType? PricingType { get; set; }
        public bool? IsFeatured { get; set; }
        public string? SortBy { get; set; } = "name";
        public string? SortDirection { get; set; } = "asc";
    }

    // Enum ViewModels for dropdowns
    public class AgentTypeViewModel
    {
        public AgentType Value { get; set; }
        public string DisplayName { get; set; } = string.Empty;
    }

    public class AgentCategoryViewModel
    {
        public AgentCategory Value { get; set; }
        public string DisplayName { get; set; } = string.Empty;
    }

    public class AgentExecutionTypeViewModel
    {
        public AgentExecutionType Value { get; set; }
        public string DisplayName { get; set; } = string.Empty;
    }

    public class IntegrationTypeViewModel
    {
        public IntegrationType Value { get; set; }
        public string DisplayName { get; set; } = string.Empty;
    }

    public class IntegrationTriggerViewModel
    {
        public IntegrationTrigger Value { get; set; }
        public string DisplayName { get; set; } = string.Empty;
    }

    // My Subscriptions ViewModel
    public class MySubscriptionsViewModel
    {
        public List<AgentSubscriptionViewModel> ActiveSubscriptions { get; set; } = new List<AgentSubscriptionViewModel>();
        public List<AgentSubscriptionViewModel> ExpiredSubscriptions { get; set; } = new List<AgentSubscriptionViewModel>();
        public decimal TotalMonthlyCost { get; set; }
        public int TotalUsageThisMonth { get; set; }
    }

    // Usage Logs ViewModel
    public class UsageLogsViewModel
    {
        public List<AgentUsageLogViewModel> UsageLogs { get; set; } = new List<AgentUsageLogViewModel>();
        public int TotalCount { get; set; }
        public int PageSize { get; set; } = 20;
        public int CurrentPage { get; set; } = 1;
        public int TotalPages => (int)Math.Ceiling((double)TotalCount / PageSize);
        public UsageLogsFilterViewModel Filter { get; set; } = new UsageLogsFilterViewModel();
    }

    public class AgentUsageLogViewModel
    {
        public int Id { get; set; }
        public string AgentName { get; set; } = string.Empty;
        public DateTime ExecutionTime { get; set; }
        public AgentExecutionStatus Status { get; set; }
        public int ExecutionDurationMs { get; set; }
        public decimal? Cost { get; set; }
        public string? ErrorMessage { get; set; }
        public bool HasError => !string.IsNullOrEmpty(ErrorMessage);
        public string StatusDisplayName => GetStatusDisplayName(Status);
        public string FormattedDuration => $"{ExecutionDurationMs}ms";
        
        private string GetStatusDisplayName(AgentExecutionStatus status)
        {
            return status switch
            {
                AgentExecutionStatus.Success => "Success",
                AgentExecutionStatus.Failed => "Failed",
                AgentExecutionStatus.Timeout => "Timeout",
                AgentExecutionStatus.Cancelled => "Cancelled",
                _ => status.ToString()
            };
        }
    }

    public class UsageLogsFilterViewModel
    {
        public int? AgentId { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public AgentExecutionStatus? Status { get; set; }
    }

    // Manage Agents ViewModel
    public class ManageAgentsViewModel
    {
        public List<AgentManageViewModel> Agents { get; set; } = new List<AgentManageViewModel>();
        public int TotalCount { get; set; }
        public int PageSize { get; set; } = 10;
        public int CurrentPage { get; set; } = 1;
        public int TotalPages => (int)Math.Ceiling((double)TotalCount / PageSize);
        public ManageAgentsFilterViewModel Filter { get; set; } = new ManageAgentsFilterViewModel();
    }

    public class AgentManageViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public AgentType Type { get; set; }
        public AgentCategory Category { get; set; }
        public bool IsActive { get; set; }
        public bool IsFeatured { get; set; }
        public int SubscriptionCount { get; set; }
        public int UsageCount { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
    }

    public class ManageAgentsFilterViewModel
    {
        public string? SearchTerm { get; set; }
        public AgentCategory? Category { get; set; }
        public AgentType? Type { get; set; }
        public bool? IsActive { get; set; }
        public bool? IsFeatured { get; set; }
    }

    // Analytics ViewModel
    public class AgentAnalyticsViewModel
    {
        public AgentAnalyticsOverviewViewModel Overview { get; set; } = new AgentAnalyticsOverviewViewModel();
        public List<AgentAnalyticsItemViewModel> TopAgents { get; set; } = new List<AgentAnalyticsItemViewModel>();
        public List<AgentUsageChartDataViewModel> UsageChartData { get; set; } = new List<AgentUsageChartDataViewModel>();
        public List<AgentRevenueChartDataViewModel> RevenueChartData { get; set; } = new List<AgentRevenueChartDataViewModel>();
    }

    public class AgentAnalyticsOverviewViewModel
    {
        public int TotalAgents { get; set; }
        public int ActiveSubscriptions { get; set; }
        public int TotalExecutions { get; set; }
        public decimal TotalRevenue { get; set; }
        public decimal AverageExecutionTime { get; set; }
        public double SuccessRate { get; set; }
    }

    public class AgentAnalyticsItemViewModel
    {
        public int AgentId { get; set; }
        public string AgentName { get; set; } = string.Empty;
        public int ExecutionCount { get; set; }
        public decimal Revenue { get; set; }
        public double SuccessRate { get; set; }
    }

    public class AgentUsageChartDataViewModel
    {
        public DateTime Date { get; set; }
        public int ExecutionCount { get; set; }
        public int SuccessCount { get; set; }
        public int FailureCount { get; set; }
    }

    public class AgentRevenueChartDataViewModel
    {
        public DateTime Date { get; set; }
        public decimal Revenue { get; set; }
        public int SubscriptionCount { get; set; }
    }

    // Test Agent ViewModel
    public class TestAgentViewModel
    {
        public int AgentId { get; set; }
        public string AgentName { get; set; } = string.Empty;
        public string InputData { get; set; } = "{}";
    }

    public class TestAgentResultViewModel
    {
        public bool Success { get; set; }
        public string? Data { get; set; }
        public string? ErrorMessage { get; set; }
        public int ExecutionDurationMs { get; set; }
        public DateTime ExecutionTime { get; set; }
        public int? ExecutionId { get; set; }
    }


    public class AgentPricingCreateEditViewModel
    {
        public int Id { get; set; }
        
        [Required(ErrorMessage = "Pricing name is required")]
        [StringLength(100, ErrorMessage = "Name cannot exceed 100 characters")]
        public string Name { get; set; } = string.Empty;
        
        [Required(ErrorMessage = "Pricing type is required")]
        public PricingType Type { get; set; }
        
        [Required(ErrorMessage = "Price is required")]
        [Range(0, double.MaxValue, ErrorMessage = "Price must be non-negative")]
        public decimal Price { get; set; }
        
        [Required(ErrorMessage = "Currency is required")]
        [StringLength(3, MinimumLength = 3, ErrorMessage = "Currency must be 3 characters")]
        public string Currency { get; set; } = "USD";
        
        [Range(1, int.MaxValue, ErrorMessage = "Usage limit must be greater than 0")]
        public int? UsageLimit { get; set; }
        
        [StringLength(1000, ErrorMessage = "Features cannot exceed 1000 characters")]
        public string Features { get; set; } = string.Empty;
        
        [StringLength(500, ErrorMessage = "Description cannot exceed 500 characters")]
        public string Description { get; set; } = string.Empty;
        
        public int SortOrder { get; set; } = 0;
        public bool IsDefault { get; set; } = false;
        public bool IsActive { get; set; } = true;
    }

    // Create/Edit ViewModels for form binding
    public class AgentCapabilityCreateEditViewModel
    {
        public int Id { get; set; }
        
        [Required(ErrorMessage = "Capability name is required")]
        [StringLength(200, ErrorMessage = "Name cannot exceed 200 characters")]
        public string Name { get; set; } = string.Empty;
        
        [StringLength(500, ErrorMessage = "Description cannot exceed 500 characters")]
        public string Description { get; set; } = string.Empty;
        
        [StringLength(100, ErrorMessage = "Icon class cannot exceed 100 characters")]
        public string IconClass { get; set; } = string.Empty;
        
        public bool IsActive { get; set; } = true;
        public bool IsKeyFeature { get; set; } = false;
        public int SortOrder { get; set; } = 0;
    }

    public class AgentIntegrationCreateEditViewModel
    {
        public int Id { get; set; }
        
        [Required(ErrorMessage = "Integration name is required")]
        [StringLength(200, ErrorMessage = "Name cannot exceed 200 characters")]
        public string Name { get; set; } = string.Empty;
        
        [Required(ErrorMessage = "Integration type is required")]
        public IntegrationType Type { get; set; }
        
        [Required(ErrorMessage = "Trigger type is required")]
        public IntegrationTrigger TriggerType { get; set; }
        
        public int Priority { get; set; } = 0;
        public bool IsActive { get; set; } = true;
        
        [StringLength(4000, ErrorMessage = "Configuration JSON cannot exceed 4000 characters")]
        public string ConfigurationJson { get; set; } = "{}";
        
        [StringLength(2000, ErrorMessage = "Metadata cannot exceed 2000 characters")]
        public string Metadata { get; set; } = string.Empty;
    }
}
