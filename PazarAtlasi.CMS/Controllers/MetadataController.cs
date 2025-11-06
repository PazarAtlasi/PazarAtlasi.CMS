using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PazarAtlasi.CMS.Persistence.Context;
using PazarAtlasi.CMS.Domain.Entities.Metadata;
using PazarAtlasi.CMS.Models.ViewModels;
using PazarAtlasi.CMS.Domain.Common;

namespace PazarAtlasi.CMS.Controllers
{
    public class MetadataController : Controller
    {
        private readonly PazarAtlasiDbContext _context;

        public MetadataController(PazarAtlasiDbContext context)
        {
            _context = context;
        }

        #region Products

        /// <summary>
        /// Products list page
        /// </summary>
        public async Task<IActionResult> Products(int page = 1, int pageSize = 50)
        {
            var query = _context.Products
                .Include(p => p.ParentProduct)
                .Include(p => p.Variants)
                .Include(p => p.CategoryProducts)
                .Include(p => p.TrademarkProducts)
                .AsQueryable();

            var totalCount = await query.CountAsync();
            
            var products = await query
                .OrderBy(p => p.ParentId ?? 0)
                .ThenBy(p => p.Name)
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            var productViewModels = BuildProductHierarchy(products.Select(p => new ProductListViewModel
            {
                Id = p.Id,
                Name = p.Name,
                Code = p.Code,
                IntegrationCode = p.IntegrationCode,
                ShortDescription = p.ShortDescription,
                Unit = p.Unit,
                Type = p.Type,
                TaxRate = p.TaxRate,
                Status = p.Status,
                CreatedAt = p.CreatedAt,
                UpdatedAt = p.UpdatedAt,
                ParentId = p.ParentId,
                ParentProductName = p.ParentProduct?.Name,
                VariantsCount = p.Variants.Count,
                CategoriesCount = p.CategoryProducts.Count,
                TrademarksCount = p.TrademarkProducts.Count,
                HasChildren = products.Any(child => child.ParentId == p.Id)
            }).ToList());

            var flattenedProducts = new List<ProductListViewModel>();
            FlattenProductHierarchy(productViewModels, flattenedProducts, 0);

            var model = new ProductListResponse
            {
                Products = flattenedProducts,
                TotalCount = totalCount,
                PageNumber = page,
                PageSize = pageSize
            };

            return View(model);
        }

        /// <summary>
        /// Product create page - GET
        /// </summary>
        [HttpGet]
        public IActionResult CreateProduct()
        {
            return View();
        }

        /// <summary>
        /// Product create - POST
        /// </summary>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateProduct(Product product)
        {
            if (ModelState.IsValid)
            {
                _context.Products.Add(product);
                await _context.SaveChangesAsync();
                TempData["SuccessMessage"] = "Product created successfully.";
                return RedirectToAction(nameof(Products));
            }

            return View(product);
        }

        /// <summary>
        /// Product edit page - GET
        /// </summary>
        [HttpGet]
        public async Task<IActionResult> EditProduct(int id)
        {
            var product = await _context.Products
                .Include(p => p.Translations)
                .FirstOrDefaultAsync(p => p.Id == id);

            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        /// <summary>
        /// Product edit - POST
        /// </summary>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditProduct(int id, Product product)
        {
            if (id != product.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(product);
                    await _context.SaveChangesAsync();
                    TempData["SuccessMessage"] = "Product updated successfully.";
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProductExists(product.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Products));
            }
            return View(product);
        }

        /// <summary>
        /// Product delete
        /// </summary>
        [HttpPost]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            var product = await _context.Products.FindAsync(id);
            if (product != null)
            {
                product.IsDeleted = true;
                await _context.SaveChangesAsync();
                TempData["SuccessMessage"] = "Product deleted successfully.";
            }

            return RedirectToAction(nameof(Products));
        }

        private bool ProductExists(int id)
        {
            return _context.Products.Any(e => e.Id == id);
        }

        #endregion

        #region Variants

        /// <summary>
        /// Variants list page
        /// </summary>
        public async Task<IActionResult> Variants(int page = 1, int pageSize = 50)
        {
            var query = _context.Variants
                .Include(v => v.Product)
                .AsQueryable();

            var totalCount = await query.CountAsync();
            
            var variants = await query
                .OrderBy(v => v.Product.Name)
                .ThenBy(v => v.Name)
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            var variantViewModels = variants.Select(v => new VariantListViewModel
            {
                Id = v.Id,
                Name = v.Name,
                Code = v.Code,
                IntegrationCode = v.IntegrationCode,
                ShortDescription = v.ShortDescription,
                Status = v.Status,
                CreatedAt = v.CreatedAt,
                UpdatedAt = v.UpdatedAt,
                ProductId = v.ProductId,
                ProductName = v.Product.Name,
                ProductCode = v.Product.Code
            }).ToList();

            var model = new VariantListResponse
            {
                Variants = variantViewModels,
                TotalCount = totalCount,
                PageNumber = page,
                PageSize = pageSize
            };

            return View(model);
        }

        /// <summary>
        /// Variant create page - GET
        /// </summary>
        [HttpGet]
        public async Task<IActionResult> CreateVariant()
        {
            ViewBag.Products = await _context.Products.ToListAsync();
            return View();
        }

        /// <summary>
        /// Variant create - POST
        /// </summary>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateVariant(Variant variant)
        {
            if (ModelState.IsValid)
            {
                _context.Variants.Add(variant);
                await _context.SaveChangesAsync();
                TempData["SuccessMessage"] = "Variant created successfully.";
                return RedirectToAction(nameof(Variants));
            }

            ViewBag.Products = await _context.Products.ToListAsync();
            return View(variant);
        }

        #endregion

        #region Categories

        /// <summary>
        /// Categories list page with hierarchical structure
        /// </summary>
        public async Task<IActionResult> Categories(int page = 1, int pageSize = 50)
        {
            // Get all categories with parent information for hierarchy building
            var allCategories = await _context.Set<Category>()
                .Include(c => c.ParentCategory)
                .Include(c => c.CategoryProducts)
                .Include(c => c.Translations.Where(t => t.LanguageId == 1)) // Default language (Turkish)
                .OrderBy(c => c.ParentCategoryId ?? 0) // Root categories first
                .ThenBy(c => c.SortOrder)
                .ThenBy(c => c.Name)
                .ToListAsync();

            var categoryViewModels = allCategories.Select(c => new CategoryListViewModel
            {
                Id = c.Id,
                Name = c.Translations.FirstOrDefault()?.Name ?? c.Name,
                Code = c.Code,
                SortOrder = c.SortOrder,
                Status = c.Status,
                CreatedAt = c.CreatedAt,
                UpdatedAt = c.UpdatedAt,
                ParentCategoryId = c.ParentCategoryId,
                ParentCategoryName = c.ParentCategory?.Name,
                ProductsCount = c.CategoryProducts.Count,
                HasChildren = allCategories.Any(child => child.ParentCategoryId == c.Id)
            }).ToList();

            // Build hierarchical structure
            var hierarchicalCategories = BuildCategoryHierarchy(categoryViewModels);

            // Flatten for display with proper levels
            var flattenedCategories = new List<CategoryListViewModel>();
            FlattenCategoryHierarchy(hierarchicalCategories, flattenedCategories, 0);

            // Apply pagination to flattened list
            var totalCount = flattenedCategories.Count;
            var paginatedCategories = flattenedCategories
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToList();

            var model = new CategoryViewModel
            {
                Categories = paginatedCategories,
                TotalCount = totalCount,
                PageNumber = page,
                PageSize = pageSize
            };

            return View(model);
        }

        /// <summary>
        /// Category create page - GET
        /// </summary>
        [HttpGet]
        public async Task<IActionResult> CreateCategory(int? parentId = null)
        {
            var model = new CategoryCreateViewModel();
            
            if (parentId.HasValue)
            {
                var parentCategory = await _context.Set<Category>()
                    .FirstOrDefaultAsync(c => c.Id == parentId.Value);
                
                if (parentCategory != null)
                {
                    model.ParentCategoryId = parentId;
                    model.ParentCategoryName = parentCategory.Name;
                }
            }

            // Get available parent categories for dropdown
            model.AvailableParentCategories = await GetAvailableParentCategories();
            
            // Get available languages
            var languages = await _context.Set<Language>()
                .Where(l => !l.IsDeleted && l.IsActive)
                .OrderByDescending(l => l.IsDefault)
                .ThenBy(l => l.SortOrder)
                .ThenBy(l => l.Name)
                .ToListAsync();

            model.AvailableLanguages = languages.Select(l => new LanguageViewModel
            {
                Id = l.Id,
                Name = l.Name,
                Code = l.Code,
                IsDefault = l.IsDefault,
                IsActive = l.IsActive
            }).ToList();

            // Initialize translations for all languages
            model.Translations = languages.Select(l => new CategoryTranslationCreateViewModel
            {
                LanguageId = l.Id,
                LanguageName = l.Name,
                LanguageCode = l.Code,
                IsDefault = l.IsDefault
            }).ToList();
            
            return View(model);
        }

        /// <summary>
        /// Category create - POST
        /// </summary>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateCategory(CategoryCreateViewModel model)
        {
            if (ModelState.IsValid)
            {
                var category = new Category
                {
                    Name = model.Name,
                    Code = model.Code,
                    IntegrationCode = model.IntegrationCode,
                    SortOrder = model.SortOrder,
                    ParentCategoryId = model.ParentCategoryId,
                    Status = Status.Active,
                    CreatedAt = DateTime.UtcNow
                };

                _context.Set<Category>().Add(category);
                await _context.SaveChangesAsync();

                // Add translations
                if (model.Translations != null && model.Translations.Any())
                {
                    var translations = model.Translations
                        .Where(t => !string.IsNullOrWhiteSpace(t.Name) || !string.IsNullOrWhiteSpace(t.ShortDescription) || !string.IsNullOrWhiteSpace(t.LongDescription))
                        .Select(t => new CategoryTranslation
                        {
                            CategoryId = category.Id,
                            LanguageId = t.LanguageId,
                            Name = t.Name ?? string.Empty,
                            ShortDescription = t.ShortDescription,
                            LongDescription = t.LongDescription,
                            CreatedAt = DateTime.UtcNow,
                            IsDeleted = false
                        }).ToList();

                    if (translations.Any())
                    {
                        _context.Set<CategoryTranslation>().AddRange(translations);
                        await _context.SaveChangesAsync();
                    }
                }
                
                TempData["SuccessMessage"] = "Category created successfully.";
                return RedirectToAction(nameof(Categories));
            }

            // Reload data for validation errors
            model.AvailableParentCategories = await GetAvailableParentCategories();
            
            // Reload languages if not already loaded
            if (!model.AvailableLanguages.Any())
            {
                var languages = await _context.Set<Language>()
                    .Where(l => !l.IsDeleted && l.IsActive)
                    .OrderByDescending(l => l.IsDefault)
                    .ThenBy(l => l.SortOrder)
                    .ThenBy(l => l.Name)
                    .ToListAsync();

                model.AvailableLanguages = languages.Select(l => new LanguageViewModel
                {
                    Id = l.Id,
                    Name = l.Name,
                    Code = l.Code,
                    IsDefault = l.IsDefault,
                    IsActive = l.IsActive
                }).ToList();
            }
            
            return View(model);
        }

        /// <summary>
        /// Category edit page - GET
        /// </summary>
        [HttpGet]
        public async Task<IActionResult> EditCategory(int id)
        {
            var category = await _context.Set<Category>()
                .Include(c => c.Translations)
                    .ThenInclude(t => t.Language)
                .Include(c => c.ParentCategory)
                .FirstOrDefaultAsync(c => c.Id == id);

            if (category == null)
            {
                return NotFound();
            }

            // Get available languages
            var languages = await _context.Set<Language>()
                .Where(l => !l.IsDeleted && l.IsActive)
                .OrderByDescending(l => l.IsDefault)
                .ThenBy(l => l.SortOrder)
                .ThenBy(l => l.Name)
                .ToListAsync();

            var model = new CategoryEditViewModel
            {
                Id = category.Id,
                Name = category.Name,
                Code = category.Code,
                IntegrationCode = category.IntegrationCode,
                SortOrder = category.SortOrder,
                ParentCategoryId = category.ParentCategoryId,
                ParentCategoryName = category.ParentCategory?.Name,
                Status = category.Status,
                CreatedAt = category.CreatedAt,
                UpdatedAt = category.UpdatedAt,
                AvailableLanguages = languages.Select(l => new LanguageViewModel
                {
                    Id = l.Id,
                    Name = l.Name,
                    Code = l.Code,
                    IsDefault = l.IsDefault,
                    IsActive = l.IsActive
                }).ToList(),
                Translations = category.Translations.Select(t => new CategoryTranslationViewModel
                {
                    Id = t.Id,
                    CategoryId = t.CategoryId,
                    LanguageId = t.LanguageId,
                    LanguageName = t.Language?.Name ?? "",
                    LanguageCode = t.Language?.Code ?? "",
                    Name = t.Name,
                    ShortDescription = t.ShortDescription,
                    LongDescription = t.LongDescription
                }).ToList()
            };

            // Initialize translations for languages that don't have translations yet
            model.Translations = languages.Select(l => 
            {
                var existingTranslation = model.Translations.FirstOrDefault(t => t.LanguageId == l.Id);
                return new CategoryTranslationViewModel
                {
                    LanguageId = l.Id,
                    LanguageName = l.Name,
                    LanguageCode = l.Code,
                    IsDefault = l.IsDefault,
                    Name = existingTranslation?.Name ?? "",
                    ShortDescription = existingTranslation?.ShortDescription,
                    LongDescription = existingTranslation?.LongDescription
                };
            }).ToList();

            model.AvailableParentCategories = await GetAvailableParentCategories(id);
            return View(model);
        }

        /// <summary>
        /// Category edit - POST
        /// </summary>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditCategory(int id, CategoryEditViewModel model)
        {
            if (id != model.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var category = await _context.Set<Category>()
                        .FirstOrDefaultAsync(c => c.Id == id);

                    if (category == null)
                    {
                        return NotFound();
                    }

                    category.Name = model.Name;
                    category.Code = model.Code;
                    category.IntegrationCode = model.IntegrationCode;
                    category.SortOrder = model.SortOrder;
                    category.ParentCategoryId = model.ParentCategoryId;
                    category.Status = model.Status;
                    category.UpdatedAt = DateTime.UtcNow;

                    // Update translations
                    if (model.Translations != null && model.Translations.Any())
                    {
                        // Remove existing translations
                        var existingTranslations = await _context.Set<CategoryTranslation>()
                            .Where(t => t.CategoryId == category.Id)
                            .ToListAsync();
                        _context.Set<CategoryTranslation>().RemoveRange(existingTranslations);

                        // Add new translations
                        var newTranslations = model.Translations
                            .Where(t => !string.IsNullOrWhiteSpace(t.Name) || !string.IsNullOrWhiteSpace(t.ShortDescription) || !string.IsNullOrWhiteSpace(t.LongDescription))
                            .Select(t => new CategoryTranslation
                            {
                                CategoryId = category.Id,
                                LanguageId = t.LanguageId,
                                Name = t.Name ?? string.Empty,
                                ShortDescription = t.ShortDescription,
                                LongDescription = t.LongDescription,
                                CreatedAt = DateTime.UtcNow,
                                IsDeleted = false
                            }).ToList();

                        if (newTranslations.Any())
                        {
                            _context.Set<CategoryTranslation>().AddRange(newTranslations);
                        }
                    }

                    await _context.SaveChangesAsync();
                    TempData["SuccessMessage"] = "Category updated successfully.";
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CategoryExists(model.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Categories));
            }
            
            // Reload data for validation errors
            model.AvailableParentCategories = await GetAvailableParentCategories(id);
            
            // Reload languages if not already loaded
            if (!model.AvailableLanguages.Any())
            {
                var languages = await _context.Set<Language>()
                    .Where(l => !l.IsDeleted && l.IsActive)
                    .OrderByDescending(l => l.IsDefault)
                    .ThenBy(l => l.SortOrder)
                    .ThenBy(l => l.Name)
                    .ToListAsync();

                model.AvailableLanguages = languages.Select(l => new LanguageViewModel
                {
                    Id = l.Id,
                    Name = l.Name,
                    Code = l.Code,
                    IsDefault = l.IsDefault,
                    IsActive = l.IsActive
                }).ToList();
            }
            
            return View(model);
        }

        /// <summary>
        /// Category delete
        /// </summary>
        [HttpPost]
        public async Task<IActionResult> DeleteCategory(int id)
        {
            var category = await _context.Set<Category>()
                .Include(c => c.ChildCategories)
                .Include(c => c.CategoryProducts)
                .FirstOrDefaultAsync(c => c.Id == id);
                
            if (category != null)
            {
                // Check if category has children or products
                if (category.ChildCategories.Any())
                {
                    TempData["ErrorMessage"] = "Cannot delete category with child categories.";
                    return RedirectToAction(nameof(Categories));
                }

                if (category.CategoryProducts.Any())
                {
                    TempData["ErrorMessage"] = "Cannot delete category with associated products.";
                    return RedirectToAction(nameof(Categories));
                }

                category.IsDeleted = true;
                category.UpdatedAt = DateTime.UtcNow;
                await _context.SaveChangesAsync();
                TempData["SuccessMessage"] = "Category deleted successfully.";
            }

            return RedirectToAction(nameof(Categories));
        }

        private bool CategoryExists(int id)
        {
            return _context.Set<Category>().Any(e => e.Id == id);
        }

        private async Task<List<CategoryListViewModel>> GetAvailableParentCategories(int? excludeId = null)
        {
            var query = _context.Set<Category>()
                .Where(c => c.Status == Status.Active);

            if (excludeId.HasValue)
            {
                query = query.Where(c => c.Id != excludeId.Value);
            }

            var categories = await query
                .OrderBy(c => c.ParentCategoryId ?? 0)
                .ThenBy(c => c.SortOrder)
                .ThenBy(c => c.Name)
                .Select(c => new CategoryListViewModel
                {
                    Id = c.Id,
                    Name = c.Name,
                    Code = c.Code,
                    ParentCategoryId = c.ParentCategoryId,
                    Level = 0 // Will be calculated in BuildCategoryHierarchy
                })
                .ToListAsync();

            var hierarchicalCategories = BuildCategoryHierarchy(categories);
            var flattenedCategories = new List<CategoryListViewModel>();
            FlattenCategoryHierarchy(hierarchicalCategories, flattenedCategories, 0);

            return flattenedCategories;
        }

        #endregion

        #region Trademarks

        /// <summary>
        /// Trademarks list page
        /// </summary>
        public async Task<IActionResult> Trademarks(int page = 1, int pageSize = 50)
        {
            var query = _context.Trademarks
                .Include(t => t.ParentTrademark)
                .Include(t => t.TrademarkProducts)
                .AsQueryable();

            var totalCount = await query.CountAsync();
            
            var trademarks = await query
                .OrderBy(t => t.ParentId ?? 0)
                .ThenBy(t => t.SortOrder)
                .ThenBy(t => t.Name)
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            var trademarkViewModels = BuildTrademarkHierarchy(trademarks.Select(t => new TrademarkListViewModel
            {
                Id = t.Id,
                Name = t.Name,
                Code = t.Code,
                IntegrationCode = t.IntegrationCode,
                ShortDescription = t.ShortDescription,
                SortOrder = t.SortOrder,
                Status = t.Status,
                CreatedAt = t.CreatedAt,
                UpdatedAt = t.UpdatedAt,
                ParentId = t.ParentId,
                ParentTrademarkName = t.ParentTrademark?.Name,
                ProductsCount = t.TrademarkProducts.Count,
                HasChildren = trademarks.Any(child => child.ParentId == t.Id)
            }).ToList());

            var flattenedTrademarks = new List<TrademarkListViewModel>();
            FlattenTrademarkHierarchy(trademarkViewModels, flattenedTrademarks, 0);

            var model = new TrademarkListResponse
            {
                Trademarks = flattenedTrademarks,
                TotalCount = totalCount,
                PageNumber = page,
                PageSize = pageSize
            };

            return View(model);
        }

        /// <summary>
        /// Trademark create page - GET
        /// </summary>
        [HttpGet]
        public IActionResult CreateTrademark()
        {
            return View();
        }

        /// <summary>
        /// Trademark create - POST
        /// </summary>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateTrademark(Trademark trademark)
        {
            if (ModelState.IsValid)
            {
                _context.Trademarks.Add(trademark);
                await _context.SaveChangesAsync();
                TempData["SuccessMessage"] = "Trademark created successfully.";
                return RedirectToAction(nameof(Trademarks));
            }

            return View(trademark);
        }

        /// <summary>
        /// Trademark edit page - GET
        /// </summary>
        [HttpGet]
        public async Task<IActionResult> EditTrademark(int id)
        {
            var trademark = await _context.Trademarks
                .Include(t => t.Translations)
                .FirstOrDefaultAsync(t => t.Id == id);

            if (trademark == null)
            {
                return NotFound();
            }

            return View(trademark);
        }

        /// <summary>
        /// Trademark edit - POST
        /// </summary>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditTrademark(int id, Trademark trademark)
        {
            if (id != trademark.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(trademark);
                    await _context.SaveChangesAsync();
                    TempData["SuccessMessage"] = "Trademark updated successfully.";
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TrademarkExists(trademark.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Trademarks));
            }
            return View(trademark);
        }

        /// <summary>
        /// Trademark delete
        /// </summary>
        [HttpPost]
        public async Task<IActionResult> DeleteTrademark(int id)
        {
            var trademark = await _context.Trademarks.FindAsync(id);
            if (trademark != null)
            {
                trademark.IsDeleted = true;
                await _context.SaveChangesAsync();
                TempData["SuccessMessage"] = "Trademark deleted successfully.";
            }

            return RedirectToAction(nameof(Trademarks));
        }

        private bool TrademarkExists(int id)
        {
            return _context.Trademarks.Any(e => e.Id == id);
        }

        #endregion

        #region Helper Methods

        private List<ProductListViewModel> BuildProductHierarchy(List<ProductListViewModel> products)
        {
            var rootProducts = products.Where(p => p.ParentId == null).ToList();
            
            foreach (var product in rootProducts)
            {
                product.ChildProducts = GetChildProducts(products, product.Id);
            }
            
            return rootProducts;
        }

        private List<ProductListViewModel> GetChildProducts(List<ProductListViewModel> allProducts, int parentId)
        {
            var children = allProducts.Where(p => p.ParentId == parentId).ToList();
            
            foreach (var child in children)
            {
                child.ChildProducts = GetChildProducts(allProducts, child.Id);
            }
            
            return children;
        }

        private void FlattenProductHierarchy(List<ProductListViewModel> products, List<ProductListViewModel> flattened, int level)
        {
            foreach (var product in products)
            {
                product.Level = level;
                flattened.Add(product);
                
                if (product.ChildProducts.Any())
                {
                    FlattenProductHierarchy(product.ChildProducts, flattened, level + 1);
                }
            }
        }

        private List<CategoryListViewModel> BuildCategoryHierarchy(List<CategoryListViewModel> allCategories)
        {
            var categoryDictionary = allCategories.ToDictionary(c => c.Id);
            var rootCategories = new List<CategoryListViewModel>();

            foreach (var category in allCategories)
            {
                if (category.ParentCategoryId.HasValue && categoryDictionary.ContainsKey(category.ParentCategoryId.Value))
                {
                    var parent = categoryDictionary[category.ParentCategoryId.Value];
                    parent.ChildCategories.Add(category);
                    parent.HasChildren = true;
                }
                else
                {
                    rootCategories.Add(category);
                }
            }

            return rootCategories.OrderBy(c => c.SortOrder).ThenBy(c => c.Name).ToList();
        }

        private void FlattenCategoryHierarchy(List<CategoryListViewModel> categories, List<CategoryListViewModel> flattened, int level)
        {
            foreach (var category in categories.OrderBy(c => c.SortOrder).ThenBy(c => c.Name))
            {
                category.Level = level;
                flattened.Add(category);
                
                if (category.ChildCategories.Any())
                {
                    FlattenCategoryHierarchy(category.ChildCategories, flattened, level + 1);
                }
            }
        }

        private List<TrademarkListViewModel> BuildTrademarkHierarchy(List<TrademarkListViewModel> trademarks)
        {
            var rootTrademarks = trademarks.Where(t => t.ParentId == null).ToList();
            
            foreach (var trademark in rootTrademarks)
            {
                trademark.ChildTrademarks = GetChildTrademarks(trademarks, trademark.Id);
            }
            
            return rootTrademarks;
        }

        private List<TrademarkListViewModel> GetChildTrademarks(List<TrademarkListViewModel> allTrademarks, int parentId)
        {
            var children = allTrademarks.Where(t => t.ParentId == parentId).ToList();
            
            foreach (var child in children)
            {
                child.ChildTrademarks = GetChildTrademarks(allTrademarks, child.Id);
            }
            
            return children;
        }

        private void FlattenTrademarkHierarchy(List<TrademarkListViewModel> trademarks, List<TrademarkListViewModel> flattened, int level)
        {
            foreach (var trademark in trademarks)
            {
                trademark.Level = level;
                flattened.Add(trademark);
                
                if (trademark.ChildTrademarks.Any())
                {
                    FlattenTrademarkHierarchy(trademark.ChildTrademarks, flattened, level + 1);
                }
            }
        }

        #endregion
    }
}