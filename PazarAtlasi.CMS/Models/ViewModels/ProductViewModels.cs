using PazarAtlasi.CMS.Domain.Common;

namespace PazarAtlasi.CMS.Models.ViewModels
{
    #region Product ViewModels

    public class ProductListResponse
    {
        public List<ProductListViewModel> Products { get; set; } = new List<ProductListViewModel>();
        public int TotalCount { get; set; }
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public int TotalPages => (int)Math.Ceiling((double)TotalCount / PageSize);
        public bool HasPreviousPage => PageNumber > 1;
        public bool HasNextPage => PageNumber < TotalPages;
    }

    public class ProductListViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Code { get; set; } = string.Empty;
        public string IntegrationCode { get; set; } = string.Empty;
        public string ShortDescription { get; set; } = string.Empty;
        public string Unit { get; set; } = string.Empty;
        public ProductType Type { get; set; }
        public string TypeName => Type.ToString();
        public decimal TaxRate { get; set; }
        public Status Status { get; set; }
        public string StatusName => Status.ToString();
        public string StatusBadgeClass => Status switch
        {
            Status.Active => "bg-green-100 text-green-800",
            Status.Draft => "bg-yellow-100 text-yellow-800",
            Status.Pending => "bg-blue-100 text-blue-800",
            Status.Archived => "bg-gray-100 text-gray-800",
            _ => "bg-red-100 text-red-800"
        };
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public int? ParentId { get; set; }
        public string? ParentProductName { get; set; }
        public int VariantsCount { get; set; }
        public int CategoriesCount { get; set; }
        public int TrademarksCount { get; set; }
        public bool HasChildren { get; set; }
        public List<ProductListViewModel> ChildProducts { get; set; } = new List<ProductListViewModel>();
        public int Level { get; set; } = 0;
        public string IndentClass => Level > 0 ? $"pl-{Level * 4}" : "";
        public string HierarchyIcon => HasChildren ? "fas fa-folder" : "fas fa-cube";
    }

    public class ProductDetailsViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Code { get; set; } = string.Empty;
        public string IntegrationCode { get; set; } = string.Empty;
        public string ShortDescription { get; set; } = string.Empty;
        public string LongDescription { get; set; } = string.Empty;
        public string Unit { get; set; } = string.Empty;
        public ProductType Type { get; set; }
        public decimal TaxRate { get; set; }
        public Status Status { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public int? ParentId { get; set; }
        public string? ParentProductName { get; set; }
        public List<VariantListViewModel> Variants { get; set; } = new List<VariantListViewModel>();
        public List<CategoryViewModel> Categories { get; set; } = new List<CategoryViewModel>();
        public List<TrademarkViewModel> Trademarks { get; set; } = new List<TrademarkViewModel>();
        public List<ProductTranslationViewModel> Translations { get; set; } = new List<ProductTranslationViewModel>();
        
        // Data Schema Properties
        public List<ProductDataSchemaViewModel> DataSchemas { get; set; } = new List<ProductDataSchemaViewModel>();
        public List<DataSchemaFieldValueEditViewModel> FieldValues { get; set; } = new List<DataSchemaFieldValueEditViewModel>();
        public List<DataSchemaListViewModel> AvailableDataSchemas { get; set; } = new List<DataSchemaListViewModel>();
    }

    public class ProductCreateViewModel
    {
        public string Name { get; set; } = string.Empty;
        public string Code { get; set; } = string.Empty;
        public string IntegrationCode { get; set; } = string.Empty;
        public string ShortDescription { get; set; } = string.Empty;
        public string LongDescription { get; set; } = string.Empty;
        public string Unit { get; set; } = string.Empty;
        public ProductType Type { get; set; } = ProductType.Simple;
        public decimal TaxRate { get; set; } = 0;
        public int? ParentId { get; set; }
        public List<ProductListViewModel> AvailableParentProducts { get; set; } = new List<ProductListViewModel>();
        
        // Data Schema Properties
        public List<DataSchemaListViewModel> AvailableDataSchemas { get; set; } = new List<DataSchemaListViewModel>();
        public List<int> SelectedDataSchemaIds { get; set; } = new List<int>();
        public List<DataSchemaFieldValueCreateViewModel> FieldValues { get; set; } = new List<DataSchemaFieldValueCreateViewModel>();
    }

    public class ProductEditViewModel : ProductCreateViewModel
    {
        public int Id { get; set; }
        public Status Status { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public List<ProductTranslationViewModel> Translations { get; set; } = new List<ProductTranslationViewModel>();
        
        // Data Schema Properties
        public List<ProductDataSchemaViewModel> DataSchemas { get; set; } = new List<ProductDataSchemaViewModel>();
        public List<DataSchemaFieldValueViewModel> FieldValues { get; set; } = new List<DataSchemaFieldValueViewModel>();
    }

    public class ProductTranslationViewModel
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public int LanguageId { get; set; }
        public string LanguageName { get; set; } = string.Empty;
        public string LanguageCode { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string ShortDescription { get; set; } = string.Empty;
        public string LongDescription { get; set; } = string.Empty;
    }

    #endregion

    #region Variant ViewModels

    public class VariantListResponse
    {
        public List<VariantListViewModel> Variants { get; set; } = new List<VariantListViewModel>();
        public int TotalCount { get; set; }
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public int TotalPages => (int)Math.Ceiling((double)TotalCount / PageSize);
        public bool HasPreviousPage => PageNumber > 1;
        public bool HasNextPage => PageNumber < TotalPages;
    }

    public class VariantListViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Code { get; set; } = string.Empty;
        public string IntegrationCode { get; set; } = string.Empty;
        public string ShortDescription { get; set; } = string.Empty;
        public Status Status { get; set; }
        public string StatusName => Status.ToString();
        public string StatusBadgeClass => Status switch
        {
            Status.Active => "bg-green-100 text-green-800",
            Status.Draft => "bg-yellow-100 text-yellow-800",
            Status.Pending => "bg-blue-100 text-blue-800",
            Status.Archived => "bg-gray-100 text-gray-800",
            _ => "bg-red-100 text-red-800"
        };
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public int ProductId { get; set; }
        public string ProductName { get; set; } = string.Empty;
        public string ProductCode { get; set; } = string.Empty;
    }

    public class VariantCreateViewModel
    {
        public string Name { get; set; } = string.Empty;
        public string Code { get; set; } = string.Empty;
        public string IntegrationCode { get; set; } = string.Empty;
        public string ShortDescription { get; set; } = string.Empty;
        public string LongDescription { get; set; } = string.Empty;
        public int ProductId { get; set; }
        public List<ProductListViewModel> AvailableProducts { get; set; } = new List<ProductListViewModel>();
    }

    public class VariantEditViewModel : VariantCreateViewModel
    {
        public int Id { get; set; }
        public Status Status { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public List<VariantTranslationViewModel> Translations { get; set; } = new List<VariantTranslationViewModel>();
    }

    public class VariantTranslationViewModel
    {
        public int Id { get; set; }
        public int VariantId { get; set; }
        public int LanguageId { get; set; }
        public string LanguageName { get; set; } = string.Empty;
        public string LanguageCode { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string ShortDescription { get; set; } = string.Empty;
        public string LongDescription { get; set; } = string.Empty;
    }

    #endregion

    #region Trademark ViewModels

    public class TrademarkListResponse
    {
        public List<TrademarkListViewModel> Trademarks { get; set; } = new List<TrademarkListViewModel>();
        public int TotalCount { get; set; }
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public int TotalPages => (int)Math.Ceiling((double)TotalCount / PageSize);
        public bool HasPreviousPage => PageNumber > 1;
        public bool HasNextPage => PageNumber < TotalPages;
    }

    public class TrademarkListViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Code { get; set; } = string.Empty;
        public string IntegrationCode { get; set; } = string.Empty;
        public string ShortDescription { get; set; } = string.Empty;
        public int SortOrder { get; set; }
        public Status Status { get; set; }
        public string StatusName => Status.ToString();
        public string StatusBadgeClass => Status switch
        {
            Status.Active => "bg-green-100 text-green-800",
            Status.Draft => "bg-yellow-100 text-yellow-800",
            Status.Pending => "bg-blue-100 text-blue-800",
            Status.Archived => "bg-gray-100 text-gray-800",
            _ => "bg-red-100 text-red-800"
        };
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public int? ParentId { get; set; }
        public string? ParentTrademarkName { get; set; }
        public int ProductsCount { get; set; }
        public bool HasChildren { get; set; }
        public List<TrademarkListViewModel> ChildTrademarks { get; set; } = new List<TrademarkListViewModel>();
        public int Level { get; set; } = 0;
        public string IndentClass => Level > 0 ? $"pl-{Level * 4}" : "";
        public string HierarchyIcon => HasChildren ? "fas fa-folder" : "fas fa-trademark";
    }

    public class TrademarkCreateViewModel
    {
        public string Name { get; set; } = string.Empty;
        public string Code { get; set; } = string.Empty;
        public string IntegrationCode { get; set; } = string.Empty;
        public string ShortDescription { get; set; } = string.Empty;
        public string LongDescription { get; set; } = string.Empty;
        public int SortOrder { get; set; } = 0;
        public int? ParentId { get; set; }
        public List<TrademarkListViewModel> AvailableParentTrademarks { get; set; } = new List<TrademarkListViewModel>();
    }

    public class TrademarkEditViewModel : TrademarkCreateViewModel
    {
        public int Id { get; set; }
        public Status Status { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public List<TrademarkTranslationViewModel> Translations { get; set; } = new List<TrademarkTranslationViewModel>();
    }

    public class TrademarkTranslationViewModel
    {
        public int Id { get; set; }
        public int TrademarkId { get; set; }
        public int LanguageId { get; set; }
        public string LanguageName { get; set; } = string.Empty;
        public string LanguageCode { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string ShortDescription { get; set; } = string.Empty;
        public string LongDescription { get; set; } = string.Empty;
    }

    #endregion

    #region Category ViewModels

    public class CategoryViewModel
    {
        public List<CategoryListViewModel> Categories { get; set; } = new List<CategoryListViewModel>();
        public int TotalCount { get; set; }
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public int TotalPages => (int)Math.Ceiling((double)TotalCount / PageSize);
        public bool HasPreviousPage => PageNumber > 1;
        public bool HasNextPage => PageNumber < TotalPages;
    }

    public class CategoryListViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Code { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public int SortOrder { get; set; }
        public Status Status { get; set; }
        public string StatusName => Status.ToString();
        public string StatusBadgeClass => Status switch
        {
            Status.Active => "bg-green-100 text-green-800",
            Status.Draft => "bg-yellow-100 text-yellow-800",
            Status.Pending => "bg-blue-100 text-blue-800",
            Status.Archived => "bg-gray-100 text-gray-800",
            _ => "bg-red-100 text-red-800"
        };
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public int? ParentCategoryId { get; set; }
        public string? ParentCategoryName { get; set; }
        public int ProductsCount { get; set; }
        public bool HasChildren { get; set; }
        public List<CategoryListViewModel> ChildCategories { get; set; } = new List<CategoryListViewModel>();
        public int Level { get; set; } = 0;
        public string IndentClass => Level > 0 ? $"pl-{Level * 4}" : "";
        public string HierarchyIcon => HasChildren ? "fas fa-folder" : "fas fa-tag";
    }

    public class CategoryCreateViewModel
    {
        public string Name { get; set; } = string.Empty;
        public string Code { get; set; } = string.Empty;
        public string? IntegrationCode { get; set; }
        public int SortOrder { get; set; } = 0;
        public int? ParentCategoryId { get; set; }
        public string? ParentCategoryName { get; set; }
        public List<CategoryListViewModel> AvailableParentCategories { get; set; } = new List<CategoryListViewModel>();
        public List<LanguageViewModel> AvailableLanguages { get; set; } = new List<LanguageViewModel>();
        public List<CategoryTranslationCreateViewModel> Translations { get; set; } = new List<CategoryTranslationCreateViewModel>();
    }

    public class CategoryEditViewModel : CategoryCreateViewModel
    {
        public int Id { get; set; }
        public Status Status { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public List<CategoryTranslationViewModel> Translations { get; set; } = new List<CategoryTranslationViewModel>();
    }

    public class CategoryTranslationViewModel
    {
        public int Id { get; set; }
        public int CategoryId { get; set; }
        public int LanguageId { get; set; }
        public string LanguageName { get; set; } = string.Empty;
        public string LanguageCode { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string? ShortDescription { get; set; }
        public string? LongDescription { get; set; }
        public bool IsDefault { get; set; }
    }

    public class CategoryTranslationCreateViewModel
    {
        public int LanguageId { get; set; }
        public string LanguageName { get; set; } = string.Empty;
        public string LanguageCode { get; set; } = string.Empty;
        public bool IsDefault { get; set; }
        public string Name { get; set; } = string.Empty;
        public string? ShortDescription { get; set; }
        public string? LongDescription { get; set; }
    }

    #endregion

    #region Shared ViewModels

    public class TrademarkViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Code { get; set; } = string.Empty;
    }

    #endregion
}