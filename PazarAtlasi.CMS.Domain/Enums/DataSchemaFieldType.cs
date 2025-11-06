namespace PazarAtlasi.CMS.Domain.Enums
{
    /// <summary>
    /// Types of data schema fields for product specifications
    /// </summary>
    public enum DataSchemaFieldType
    {
        /// <summary>
        /// Default/unspecified type
        /// </summary>
        None = 0,

        /// <summary>
        /// Single line text input
        /// </summary>
        Text = 1,

        /// <summary>
        /// Multi-line text area
        /// </summary>
        TextArea = 2,

        /// <summary>
        /// Numeric input (integer or decimal)
        /// </summary>
        Number = 3,

        /// <summary>
        /// Boolean checkbox (true/false)
        /// </summary>
        Boolean = 4,

        /// <summary>
        /// Date picker
        /// </summary>
        Date = 5,

        /// <summary>
        /// Date and time picker
        /// </summary>
        DateTime = 6,

        /// <summary>
        /// Email input with validation
        /// </summary>
        Email = 7,

        /// <summary>
        /// URL input with validation
        /// </summary>
        Url = 8,

        /// <summary>
        /// Phone number input
        /// </summary>
        Phone = 9,

        /// <summary>
        /// Color picker
        /// </summary>
        Color = 10,

        /// <summary>
        /// Single file upload
        /// </summary>
        File = 11,

        /// <summary>
        /// Image upload with preview
        /// </summary>
        Image = 12,

        /// <summary>
        /// Video upload
        /// </summary>
        Video = 13,

        /// <summary>
        /// Dropdown select (single selection)
        /// </summary>
        Select = 14,

        /// <summary>
        /// Multi-select dropdown (multiple selections)
        /// </summary>
        MultiSelect = 15,

        /// <summary>
        /// Radio buttons (single selection)
        /// </summary>
        Radio = 16,

        /// <summary>
        /// Checkboxes (multiple selections)
        /// </summary>
        Checkbox = 17,

        /// <summary>
        /// Range slider for numeric values
        /// </summary>
        Range = 18,

        /// <summary>
        /// Rich text editor (HTML)
        /// </summary>
        RichText = 19,

        /// <summary>
        /// JSON data input
        /// </summary>
        Json = 20,

        /// <summary>
        /// Tags input (comma-separated values)
        /// </summary>
        Tags = 21,

        /// <summary>
        /// Rating input (stars, numbers)
        /// </summary>
        Rating = 22,

        /// <summary>
        /// Currency input with symbol
        /// </summary>
        Currency = 23,

        /// <summary>
        /// Percentage input
        /// </summary>
        Percentage = 24,

        /// <summary>
        /// Dimensions input (width x height x depth)
        /// </summary>
        Dimensions = 25,

        /// <summary>
        /// Weight input with unit
        /// </summary>
        Weight = 26,

        /// <summary>
        /// Temperature input with unit
        /// </summary>
        Temperature = 27,

        /// <summary>
        /// Custom field type (requires special handling)
        /// </summary>
        Custom = 99
    }
}