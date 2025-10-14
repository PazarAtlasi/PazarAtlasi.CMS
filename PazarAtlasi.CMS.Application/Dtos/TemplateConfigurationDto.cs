namespace PazarAtlasi.CMS.Application.Dtos
{
    /// <summary>
    /// Template configuration that defines how section items should be rendered
    /// </summary>
    public class TemplateConfigurationDto
    {
        public int TemplateId { get; set; }
        public string TemplateName { get; set; } = string.Empty;
        public string TemplateKey { get; set; } = string.Empty;

        /// <summary>
        /// Section item configuration for this template
        /// </summary>
        public SectionItemConfiguration ItemConfiguration { get; set; } = new();
    }

    /// <summary>
    /// Defines how section items should be configured for a template
    /// </summary>
    public class SectionItemConfiguration
    {
        /// <summary>
        /// Minimum number of items required
        /// </summary>
        public int MinItems { get; set; } = 0;

        /// <summary>
        /// Maximum number of items allowed (null = unlimited)
        /// </summary>
        public int? MaxItems { get; set; }

        /// <summary>
        /// Default number of items to create
        /// </summary>
        public int DefaultItems { get; set; } = 0;

        /// <summary>
        /// Whether user can add/remove items dynamically
        /// </summary>
        public bool AllowDynamicItems { get; set; } = true;

        /// <summary>
        /// Item type for all items in this template
        /// </summary>
        public string ItemType { get; set; } = "Text"; // Text, Image, Link, Video, etc.

        /// <summary>
        /// Media type if item type is media-based
        /// </summary>
        public string? MediaType { get; set; } // Image, Video, Audio, etc.

        /// <summary>
        /// Fields that should be shown for each item
        /// </summary>
        public List<SectionItemField> Fields { get; set; } = new();

        /// <summary>
        /// UI rendering hints
        /// </summary>
        public ItemUIConfiguration UIConfiguration { get; set; } = new();
    }

    /// <summary>
    /// Defines a field in section item
    /// </summary>
    public class SectionItemField
    {
        public string Name { get; set; } = string.Empty;
        public string Label { get; set; } = string.Empty;
        public string Type { get; set; } = "text"; // text, textarea, url, image, video, select, checkbox
        public bool Required { get; set; } = false;
        public string? Placeholder { get; set; }
        public int? MaxLength { get; set; }
        public List<string>? Options { get; set; } // For select fields
        public string? DefaultValue { get; set; }
    }

    /// <summary>
    /// UI rendering configuration
    /// </summary>
    public class ItemUIConfiguration
    {
        public string Layout { get; set; } = "grid"; // grid, list, carousel
        public int Columns { get; set; } = 3;
        public bool ShowPreview { get; set; } = true;
        public bool ShowReorder { get; set; } = true;
        public string AddButtonText { get; set; } = "Add Item";
        public string? IconClass { get; set; }
    }
}
