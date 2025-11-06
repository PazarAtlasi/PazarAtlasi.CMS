using PazarAtlasi.CMS.Domain.Common;
using PazarAtlasi.CMS.Domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace PazarAtlasi.CMS.Models.ViewModels
{
    #region Data Schema ViewModels

    public class DataSchemaListViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Key { get; set; } = string.Empty;
        public string? Description { get; set; }
        public string? Category { get; set; }
        public int FieldsCount { get; set; }
        public int ProductsCount { get; set; }
        public bool IsActive { get; set; }
        public Status Status { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }

    public class DataSchemaCreateViewModel
    {
        [Required(ErrorMessage = "Schema name is required")]
        [StringLength(200, ErrorMessage = "Schema name cannot exceed 200 characters")]
        public string Name { get; set; } = string.Empty;

        [Required(ErrorMessage = "Schema key is required")]
        [StringLength(100, ErrorMessage = "Schema key cannot exceed 100 characters")]
        [RegularExpression(@"^[a-z0-9-_]+$", ErrorMessage = "Schema key can only contain lowercase letters, numbers, hyphens and underscores")]
        public string Key { get; set; } = string.Empty;

        [StringLength(1000, ErrorMessage = "Description cannot exceed 1000 characters")]
        public string? Description { get; set; }

        [StringLength(100, ErrorMessage = "Category cannot exceed 100 characters")]
        public string? Category { get; set; }

        public string? Configuration { get; set; }

        public int SortOrder { get; set; } = 0;

        public bool IsActive { get; set; } = true;

        public Status Status { get; set; } = Status.Active;

        public List<DataSchemaFieldCreateViewModel> Fields { get; set; } = new List<DataSchemaFieldCreateViewModel>();

        public List<DataSchemaTranslationCreateViewModel> Translations { get; set; } = new List<DataSchemaTranslationCreateViewModel>();

        public List<LanguageViewModel> AvailableLanguages { get; set; } = new List<LanguageViewModel>();
    }

    public class DataSchemaEditViewModel : DataSchemaCreateViewModel
    {
        public int Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }

    public class DataSchemaDetailsViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Key { get; set; } = string.Empty;
        public string? Description { get; set; }
        public string? Category { get; set; }
        public string? Configuration { get; set; }
        public int SortOrder { get; set; }
        public bool IsActive { get; set; }
        public Status Status { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }

        public List<DataSchemaFieldDetailsViewModel> Fields { get; set; } = new List<DataSchemaFieldDetailsViewModel>();
        public List<DataSchemaTranslationViewModel> Translations { get; set; } = new List<DataSchemaTranslationViewModel>();
        public List<ProductDataSchemaViewModel> Products { get; set; } = new List<ProductDataSchemaViewModel>();
    }

    #endregion

    #region Data Schema Field ViewModels

    public class DataSchemaFieldCreateViewModel
    {
        public int DataSchemaId { get; set; }

        [Required(ErrorMessage = "Field key is required")]
        [StringLength(100, ErrorMessage = "Field key cannot exceed 100 characters")]
        [RegularExpression(@"^[a-z0-9_]+$", ErrorMessage = "Field key can only contain lowercase letters, numbers and underscores")]
        public string FieldKey { get; set; } = string.Empty;

        [Required(ErrorMessage = "Field name is required")]
        [StringLength(200, ErrorMessage = "Field name cannot exceed 200 characters")]
        public string FieldName { get; set; } = string.Empty;

        [StringLength(500, ErrorMessage = "Description cannot exceed 500 characters")]
        public string? Description { get; set; }

        public DataSchemaFieldType Type { get; set; } = DataSchemaFieldType.Text;

        public bool IsRequired { get; set; } = false;
        public bool IsTranslatable { get; set; } = false;
        public bool ShowInListing { get; set; } = true;
        public bool ShowInDetails { get; set; } = true;
        public bool IsFilterable { get; set; } = false;
        public bool IsSortable { get; set; } = false;

        [StringLength(500, ErrorMessage = "Default value cannot exceed 500 characters")]
        public string? DefaultValue { get; set; }

        [StringLength(200, ErrorMessage = "Placeholder cannot exceed 200 characters")]
        public string? Placeholder { get; set; }

        public string? OptionsJson { get; set; }
        public string? ValidationRules { get; set; }

        [StringLength(50, ErrorMessage = "Unit cannot exceed 50 characters")]
        public string? Unit { get; set; }

        public int SortOrder { get; set; } = 0;
        public bool IsActive { get; set; } = true;

        public List<DataSchemaFieldTranslationCreateViewModel> Translations { get; set; } = new List<DataSchemaFieldTranslationCreateViewModel>();
    }

    public class DataSchemaFieldEditViewModel : DataSchemaFieldCreateViewModel
    {
        public int Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }

    public class DataSchemaFieldDetailsViewModel
    {
        public int Id { get; set; }
        public int DataSchemaId { get; set; }
        public string FieldKey { get; set; } = string.Empty;
        public string FieldName { get; set; } = string.Empty;
        public string? Description { get; set; }
        public DataSchemaFieldType Type { get; set; }
        public string TypeDisplayName => GetFieldTypeDisplayName(Type);
        public bool IsRequired { get; set; }
        public bool IsTranslatable { get; set; }
        public bool ShowInListing { get; set; }
        public bool ShowInDetails { get; set; }
        public bool IsFilterable { get; set; }
        public bool IsSortable { get; set; }
        public string? DefaultValue { get; set; }
        public string? Placeholder { get; set; }
        public string? OptionsJson { get; set; }
        public string? ValidationRules { get; set; }
        public string? Unit { get; set; }
        public int SortOrder { get; set; }
        public bool IsActive { get; set; }
        public Status Status { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }

        public List<DataSchemaFieldTranslationViewModel> Translations { get; set; } = new List<DataSchemaFieldTranslationViewModel>();

        private static string GetFieldTypeDisplayName(DataSchemaFieldType type)
        {
            return type switch
            {
                DataSchemaFieldType.Text => "Text",
                DataSchemaFieldType.TextArea => "Text Area",
                DataSchemaFieldType.Number => "Number",
                DataSchemaFieldType.Boolean => "Boolean",
                DataSchemaFieldType.Date => "Date",
                DataSchemaFieldType.DateTime => "Date Time",
                DataSchemaFieldType.Email => "Email",
                DataSchemaFieldType.Url => "URL",
                DataSchemaFieldType.Phone => "Phone",
                DataSchemaFieldType.Color => "Color",
                DataSchemaFieldType.File => "File",
                DataSchemaFieldType.Image => "Image",
                DataSchemaFieldType.Video => "Video",
                DataSchemaFieldType.Select => "Select",
                DataSchemaFieldType.MultiSelect => "Multi Select",
                DataSchemaFieldType.Radio => "Radio",
                DataSchemaFieldType.Checkbox => "Checkbox",
                DataSchemaFieldType.Range => "Range",
                DataSchemaFieldType.RichText => "Rich Text",
                DataSchemaFieldType.Json => "JSON",
                DataSchemaFieldType.Tags => "Tags",
                DataSchemaFieldType.Rating => "Rating",
                DataSchemaFieldType.Currency => "Currency",
                DataSchemaFieldType.Percentage => "Percentage",
                DataSchemaFieldType.Dimensions => "Dimensions",
                DataSchemaFieldType.Weight => "Weight",
                DataSchemaFieldType.Temperature => "Temperature",
                DataSchemaFieldType.Custom => "Custom",
                _ => "Unknown"
            };
        }
    }

    #endregion

    #region Data Schema Field Value ViewModels

    public class DataSchemaFieldValueCreateViewModel
    {
        public int ProductId { get; set; }
        public int SchemaId { get; set; }
        public int FieldId { get; set; }
        public string Value { get; set; } = string.Empty;
        public string? JsonValue { get; set; }
        public decimal? NumericValue { get; set; }
        public bool? BooleanValue { get; set; }
        public DateTime? DateValue { get; set; }
        public int SortOrder { get; set; } = 0;

        public List<DataSchemaFieldValueTranslationCreateViewModel> Translations { get; set; } = new List<DataSchemaFieldValueTranslationCreateViewModel>();
    }

    public class DataSchemaFieldValueEditViewModel : DataSchemaFieldValueCreateViewModel
    {
        public int Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }

    public class DataSchemaFieldValueViewModel
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public int SchemaId { get; set; }
        public int FieldId { get; set; }
        public string FieldKey { get; set; } = string.Empty;
        public string FieldName { get; set; } = string.Empty;
        public DataSchemaFieldType FieldType { get; set; }
        public string Value { get; set; } = string.Empty;
        public string? JsonValue { get; set; }
        public decimal? NumericValue { get; set; }
        public bool? BooleanValue { get; set; }
        public DateTime? DateValue { get; set; }
        public string? Unit { get; set; }
        public int SortOrder { get; set; }

        public List<DataSchemaFieldValueTranslationViewModel> Translations { get; set; } = new List<DataSchemaFieldValueTranslationViewModel>();
    }

    #endregion

    #region Product Data Schema ViewModels

    public class ProductDataSchemaCreateViewModel
    {
        public int ProductId { get; set; }
        public int SchemaId { get; set; }
        public bool IsPrimary { get; set; } = false;
        public int SortOrder { get; set; } = 0;
        public string? Configuration { get; set; }
        public bool IsActive { get; set; } = true;
    }

    public class ProductDataSchemaViewModel
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public string ProductName { get; set; } = string.Empty;
        public int SchemaId { get; set; }
        public string SchemaName { get; set; } = string.Empty;
        public string SchemaKey { get; set; } = string.Empty;
        public bool IsPrimary { get; set; }
        public int SortOrder { get; set; }
        public string? Configuration { get; set; }
        public bool IsActive { get; set; }
        public Status Status { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }

    #endregion

    #region Translation ViewModels

    public class DataSchemaTranslationCreateViewModel
    {
        public int LanguageId { get; set; }
        public string LanguageName { get; set; } = string.Empty;
        public string LanguageCode { get; set; } = string.Empty;
        public bool IsDefault { get; set; }
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; }
        public string? Category { get; set; }
    }

    public class DataSchemaTranslationViewModel : DataSchemaTranslationCreateViewModel
    {
        public int Id { get; set; }
        public int DataSchemaId { get; set; }
    }

    public class DataSchemaFieldTranslationCreateViewModel
    {
        public int LanguageId { get; set; }
        public string LanguageName { get; set; } = string.Empty;
        public string LanguageCode { get; set; } = string.Empty;
        public bool IsDefault { get; set; }
        public string FieldName { get; set; } = string.Empty;
        public string? Description { get; set; }
        public string? Placeholder { get; set; }
        public string? Unit { get; set; }
        public string? OptionsJson { get; set; }
    }

    public class DataSchemaFieldTranslationViewModel : DataSchemaFieldTranslationCreateViewModel
    {
        public int Id { get; set; }
        public int DataSchemaFieldId { get; set; }
    }

    public class DataSchemaFieldValueTranslationCreateViewModel
    {
        public int LanguageId { get; set; }
        public string LanguageName { get; set; } = string.Empty;
        public string LanguageCode { get; set; } = string.Empty;
        public bool IsDefault { get; set; }
        public string Value { get; set; } = string.Empty;
        public string? JsonValue { get; set; }
    }

    public class DataSchemaFieldValueTranslationViewModel : DataSchemaFieldValueTranslationCreateViewModel
    {
        public int Id { get; set; }
        public int DataSchemaFieldValueId { get; set; }
    }

    #endregion

    #region Response ViewModels

    public class DataSchemaListResponse
    {
        public List<DataSchemaListViewModel> DataSchemas { get; set; } = new List<DataSchemaListViewModel>();
        public int TotalCount { get; set; }
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public int TotalPages => (int)Math.Ceiling((double)TotalCount / PageSize);
        public bool HasPreviousPage => PageNumber > 1;
        public bool HasNextPage => PageNumber < TotalPages;
    }

    #endregion

    #region Helper ViewModels

    public class DataSchemaFieldTypeViewModel
    {
        public DataSchemaFieldType Value { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public bool IsSelected { get; set; }
    }

    public class ProductSpecificationViewModel
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; } = string.Empty;
        public List<DataSchemaSpecificationGroupViewModel> SpecificationGroups { get; set; } = new List<DataSchemaSpecificationGroupViewModel>();
    }

    public class DataSchemaSpecificationGroupViewModel
    {
        public int SchemaId { get; set; }
        public string SchemaName { get; set; } = string.Empty;
        public string SchemaKey { get; set; } = string.Empty;
        public bool IsPrimary { get; set; }
        public List<DataSchemaFieldValueViewModel> Fields { get; set; } = new List<DataSchemaFieldValueViewModel>();
    }

    #endregion
}