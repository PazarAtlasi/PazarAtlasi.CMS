using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PazarAtlasi.CMS.Persistence.Context;
using PazarAtlasi.CMS.Domain.Entities.Metadata;
using PazarAtlasi.CMS.Models.ViewModels;
using PazarAtlasi.CMS.Domain.Common;
using PazarAtlasi.CMS.Domain.Enums;
using System.Text.Json;

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

        /// <summary>
        /// Variant edit page - GET
        /// </summary>
        [HttpGet]
        public async Task<IActionResult> EditVariant(int id)
        {
            var variant = await _context.Variants
                .Include(v => v.Product)
                .Include(v => v.Translations)
                .FirstOrDefaultAsync(v => v.Id == id);

            if (variant == null)
            {
                return NotFound();
            }

            return View(variant);
        }

        /// <summary>
        /// Variant edit - POST
        /// </summary>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditVariant(int id, Variant variant)
        {
            if (id != variant.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(variant);
                    await _context.SaveChangesAsync();
                    TempData["SuccessMessage"] = "Variant updated successfully.";
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VariantExists(variant.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Variants));
            }
            return View(variant);
        }

        /// <summary>
        /// Variant delete
        /// </summary>
        [HttpPost]
        public async Task<IActionResult> DeleteVariant(int id)
        {
            var variant = await _context.Variants.FindAsync(id);
            if (variant != null)
            {
                variant.IsDeleted = true;
                await _context.SaveChangesAsync();
                TempData["SuccessMessage"] = "Variant deleted successfully.";
            }

            return RedirectToAction(nameof(Variants));
        }

        private bool VariantExists(int id)
        {
            return _context.Variants.Any(e => e.Id == id);
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

        #region DataSchemas

        /// <summary>
        /// DataSchemas list page
        /// </summary>
        public async Task<IActionResult> DataSchemas(int page = 1, int pageSize = 20)
        {
            var query = _context.DataSchemas
                .Include(ds => ds.Fields)
                .Include(ds => ds.ProductDataSchemas)
                .AsQueryable();

            var totalCount = await query.CountAsync();
            
            var dataSchemas = await query
                .OrderBy(ds => ds.SortOrder)
                .ThenBy(ds => ds.Name)
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            var dataSchemaViewModels = dataSchemas.Select(ds => new DataSchemaListViewModel
            {
                Id = ds.Id,
                Name = ds.Name,
                Key = ds.Key,
                Description = ds.Description,
                FieldsCount = ds.Fields.Count,
                ProductsCount = ds.ProductDataSchemas.Count,
                IsActive = ds.IsActive,
                Status = ds.Status,
                CreatedAt = ds.CreatedAt,
                UpdatedAt = ds.UpdatedAt
            }).ToList();

            var model = new DataSchemaListResponse
            {
                DataSchemas = dataSchemaViewModels,
                TotalCount = totalCount,
                PageNumber = page,
                PageSize = pageSize
            };

            return View(model);
        }

        /// <summary>
        /// DataSchema create page - GET
        /// </summary>
        [HttpGet]
        public async Task<IActionResult> CreateDataSchema()
        {
            // Get available languages
            var languages = await _context.Languages
                .Where(l => !l.IsDeleted && l.IsActive)
                .OrderByDescending(l => l.IsDefault)
                .ThenBy(l => l.SortOrder)
                .ThenBy(l => l.Name)
                .ToListAsync();

            var model = new DataSchemaCreateViewModel
            {
                IsActive = true,
                Status = Status.Active,
                AvailableLanguages = languages.Select(l => new LanguageViewModel
                {
                    Id = l.Id,
                    Name = l.Name,
                    Code = l.Code,
                    IsDefault = l.IsDefault,
                    IsActive = l.IsActive
                }).ToList(),
                Translations = languages.Select(l => new DataSchemaTranslationCreateViewModel
                {
                    LanguageId = l.Id,
                    LanguageName = l.Name,
                    LanguageCode = l.Code,
                    IsDefault = l.IsDefault
                }).ToList()
            };

            return View(model);
        }

        /// <summary>
        /// DataSchema create - POST
        /// </summary>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateDataSchema(DataSchemaCreateViewModel model)
        {
            if (ModelState.IsValid)
            {
                // Check if key already exists
                var existingSchema = await _context.DataSchemas
                    .FirstOrDefaultAsync(ds => ds.Key == model.Key && !ds.IsDeleted);

                if (existingSchema != null)
                {
                    ModelState.AddModelError("Key", "A schema with this key already exists.");
                    await ReloadDataSchemaCreateModel(model);
                    return View(model);
                }

                var dataSchema = new DataSchema
                {
                    Name = model.Name,
                    Key = model.Key,
                    Description = model.Description,
                    Configuration = model.Configuration ?? "{}",
                    SortOrder = model.SortOrder,
                    IsActive = model.IsActive,
                    Status = model.Status,
                    CreatedAt = DateTime.UtcNow
                };

                _context.DataSchemas.Add(dataSchema);
                await _context.SaveChangesAsync();

                // Add translations
                if (model.Translations != null && model.Translations.Any())
                {
                    var translations = model.Translations
                        .Where(t => !string.IsNullOrWhiteSpace(t.Name))
                        .Select(t => new DataSchemaTranslation
                        {
                            DataSchemaId = dataSchema.Id,
                            LanguageId = t.LanguageId,
                            Name = t.Name,
                            Description = t.Description,
                            CreatedAt = DateTime.UtcNow
                        }).ToList();

                    if (translations.Any())
                    {
                        _context.DataSchemaTranslations.AddRange(translations);
                        await _context.SaveChangesAsync();
                    }
                }

                // Add fields
                if (model.Fields != null && model.Fields.Any())
                {
                    var fields = model.Fields.Select((field, index) => new DataSchemaField
                    {
                        DataSchemaId = dataSchema.Id,
                        FieldKey = field.FieldKey,
                        FieldName = field.FieldName,
                        Description = field.Description,
                        Type = field.Type,
                        IsRequired = field.IsRequired,
                        IsTranslatable = field.IsTranslatable,
                        ShowInListing = field.ShowInListing,
                        ShowInDetails = field.ShowInDetails,
                        IsFilterable = field.IsFilterable,
                        IsSortable = field.IsSortable,
                        DefaultValue = field.DefaultValue,
                        Placeholder = field.Placeholder,
                        OptionsJson = field.OptionsJson,
                        ValidationRules = field.ValidationRules,
                        Unit = field.Unit,
                        SortOrder = field.SortOrder > 0 ? field.SortOrder : index + 1,
                        IsActive = field.IsActive,
                        Status = Status.Active,
                        CreatedAt = DateTime.UtcNow
                    }).ToList();

                    _context.DataSchemaFields.AddRange(fields);
                    await _context.SaveChangesAsync();

                    // Add field translations
                    foreach (var field in model.Fields.Where(f => f.Translations != null && f.Translations.Any()))
                    {
                        var fieldEntity = fields.FirstOrDefault(f => f.FieldKey == field.FieldKey);
                        if (fieldEntity != null)
                        {
                            var fieldTranslations = field.Translations
                                .Where(t => !string.IsNullOrWhiteSpace(t.FieldName))
                                .Select(t => new DataSchemaFieldTranslation
                                {
                                    DataSchemaFieldId = fieldEntity.Id,
                                    LanguageId = t.LanguageId,
                                    FieldName = t.FieldName,
                                    Description = t.Description,
                                    Placeholder = t.Placeholder,
                                    Unit = t.Unit,
                                    OptionsJson = t.OptionsJson,
                                    CreatedAt = DateTime.UtcNow
                                }).ToList();

                            if (fieldTranslations.Any())
                            {
                                _context.DataSchemaFieldTranslations.AddRange(fieldTranslations);
                            }
                        }
                    }

                    await _context.SaveChangesAsync();
                }

                TempData["SuccessMessage"] = "Data schema created successfully.";
                return RedirectToAction(nameof(DataSchemas));
            }

            await ReloadDataSchemaCreateModel(model);
            return View(model);
        }

        /// <summary>
        /// DataSchema edit page - GET
        /// </summary>
        [HttpGet]
        public async Task<IActionResult> EditDataSchema(int id)
        {
            var dataSchema = await _context.DataSchemas
                .Include(ds => ds.Fields.OrderBy(f => f.SortOrder))
                    .ThenInclude(f => f.Translations)
                        .ThenInclude(t => t.Language)
                .Include(ds => ds.Translations)
                    .ThenInclude(t => t.Language)
                .FirstOrDefaultAsync(ds => ds.Id == id);

            if (dataSchema == null)
            {
                return NotFound();
            }

            // Get available languages
            var languages = await _context.Languages
                .Where(l => !l.IsDeleted && l.IsActive)
                .OrderByDescending(l => l.IsDefault)
                .ThenBy(l => l.SortOrder)
                .ThenBy(l => l.Name)
                .ToListAsync();

            var model = new DataSchemaEditViewModel
            {
                Id = dataSchema.Id,
                Name = dataSchema.Name,
                Key = dataSchema.Key,
                Description = dataSchema.Description,
                Configuration = dataSchema.Configuration,
                SortOrder = dataSchema.SortOrder,
                IsActive = dataSchema.IsActive,
                Status = dataSchema.Status,
                CreatedAt = dataSchema.CreatedAt,
                UpdatedAt = dataSchema.UpdatedAt,
                AvailableLanguages = languages.Select(l => new LanguageViewModel
                {
                    Id = l.Id,
                    Name = l.Name,
                    Code = l.Code,
                    IsDefault = l.IsDefault,
                    IsActive = l.IsActive
                }).ToList(),
                Translations = dataSchema.Translations.Select(t => new DataSchemaTranslationCreateViewModel
                {
                    LanguageId = t.LanguageId,
                    LanguageName = t.Language?.Name ?? "",
                    LanguageCode = t.Language?.Code ?? "",
                    IsDefault = t.Language?.IsDefault ?? false,
                    Name = t.Name,
                    Description = t.Description,
                }).ToList(),
                Fields = dataSchema.Fields.Select(f => new DataSchemaFieldCreateViewModel
                {
                    DataSchemaId = f.DataSchemaId,
                    FieldKey = f.FieldKey,
                    FieldName = f.FieldName,
                    Description = f.Description,
                    Type = f.Type,
                    IsRequired = f.IsRequired,
                    IsTranslatable = f.IsTranslatable,
                    ShowInListing = f.ShowInListing,
                    ShowInDetails = f.ShowInDetails,
                    IsFilterable = f.IsFilterable,
                    IsSortable = f.IsSortable,
                    DefaultValue = f.DefaultValue,
                    Placeholder = f.Placeholder,
                    OptionsJson = f.OptionsJson,
                    ValidationRules = f.ValidationRules,
                    Unit = f.Unit,
                    SortOrder = f.SortOrder,
                    IsActive = f.IsActive,
                    Translations = f.Translations.Select(ft => new DataSchemaFieldTranslationCreateViewModel
                    {
                        LanguageId = ft.LanguageId,
                        LanguageName = ft.Language?.Name ?? "",
                        LanguageCode = ft.Language?.Code ?? "",
                        IsDefault = ft.Language?.IsDefault ?? false,
                        FieldName = ft.FieldName,
                        Description = ft.Description,
                        Placeholder = ft.Placeholder,
                        Unit = ft.Unit,
                        OptionsJson = ft.OptionsJson
                    }).ToList()
                }).ToList()
            };

            // Ensure all languages have translations (fill missing ones)
            foreach (var language in languages)
            {
                if (!model.Translations.Any(t => t.LanguageId == language.Id))
                {
                    model.Translations.Add(new DataSchemaTranslationCreateViewModel
                    {
                        LanguageId = language.Id,
                        LanguageName = language.Name,
                        LanguageCode = language.Code,
                        IsDefault = language.IsDefault
                    });
                }

                foreach (var field in model.Fields)
                {
                    if (!field.Translations.Any(t => t.LanguageId == language.Id))
                    {
                        field.Translations.Add(new DataSchemaFieldTranslationCreateViewModel
                        {
                            LanguageId = language.Id,
                            LanguageName = language.Name,
                            LanguageCode = language.Code,
                            IsDefault = language.IsDefault
                        });
                    }
                }
            }

            return View(model);
        }

        /// <summary>
        /// DataSchema edit - POST
        /// </summary>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditDataSchema(int id, DataSchemaEditViewModel model)
        {
            if (id != model.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var dataSchema = await _context.DataSchemas
                        .Include(ds => ds.Translations)
                        .Include(ds => ds.Fields)
                            .ThenInclude(f => f.Translations)
                        .FirstOrDefaultAsync(ds => ds.Id == id);

                    if (dataSchema == null)
                    {
                        return NotFound();
                    }

                    // Update basic properties
                    dataSchema.Name = model.Name;
                    dataSchema.Description = model.Description;
                    dataSchema.Configuration = model.Configuration;
                    dataSchema.SortOrder = model.SortOrder;
                    dataSchema.IsActive = model.IsActive;
                    dataSchema.Status = model.Status;
                    dataSchema.UpdatedAt = DateTime.UtcNow;

                    // Update translations
                    if (model.Translations != null && model.Translations.Any())
                    {
                        // Remove existing translations
                        _context.DataSchemaTranslations.RemoveRange(dataSchema.Translations);

                        // Add new translations
                        var newTranslations = model.Translations
                            .Where(t => !string.IsNullOrWhiteSpace(t.Name))
                            .Select(t => new DataSchemaTranslation
                            {
                                DataSchemaId = dataSchema.Id,
                                LanguageId = t.LanguageId,
                                Name = t.Name,
                                Description = t.Description,
                                CreatedAt = DateTime.UtcNow
                            }).ToList();

                        if (newTranslations.Any())
                        {
                            _context.DataSchemaTranslations.AddRange(newTranslations);
                        }
                    }

                    await _context.SaveChangesAsync();
                    TempData["SuccessMessage"] = "Data schema updated successfully.";
                    return RedirectToAction(nameof(DataSchemas));
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DataSchemaExists(model.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
            }

            await ReloadDataSchemaCreateModel(model);
            return View(model);
        }

        private bool DataSchemaExists(int id)
        {
            return _context.DataSchemas.Any(e => e.Id == id);
        }

        /// <summary>
        /// DataSchema details page
        /// </summary>
        [HttpGet]
        public async Task<IActionResult> DataSchemaDetails(int id)
        {
            var dataSchema = await _context.DataSchemas
                .Include(ds => ds.Fields.OrderBy(f => f.SortOrder))
                    .ThenInclude(f => f.Translations)
                        .ThenInclude(t => t.Language)
                .Include(ds => ds.Translations)
                    .ThenInclude(t => t.Language)
                .Include(ds => ds.ProductDataSchemas)
                    .ThenInclude(pds => pds.Product)
                .FirstOrDefaultAsync(ds => ds.Id == id);

            if (dataSchema == null)
            {
                return NotFound();
            }

            var model = new DataSchemaDetailsViewModel
            {
                Id = dataSchema.Id,
                Name = dataSchema.Name,
                Key = dataSchema.Key,
                Description = dataSchema.Description,
                Configuration = dataSchema.Configuration,
                SortOrder = dataSchema.SortOrder,
                IsActive = dataSchema.IsActive,
                Status = dataSchema.Status,
                CreatedAt = dataSchema.CreatedAt,
                UpdatedAt = dataSchema.UpdatedAt,
                Fields = dataSchema.Fields.Select(f => new DataSchemaFieldDetailsViewModel
                {
                    Id = f.Id,
                    DataSchemaId = f.DataSchemaId,
                    FieldKey = f.FieldKey,
                    FieldName = f.FieldName,
                    Description = f.Description,
                    Type = f.Type,
                    IsRequired = f.IsRequired,
                    IsTranslatable = f.IsTranslatable,
                    ShowInListing = f.ShowInListing,
                    ShowInDetails = f.ShowInDetails,
                    IsFilterable = f.IsFilterable,
                    IsSortable = f.IsSortable,
                    DefaultValue = f.DefaultValue,
                    Placeholder = f.Placeholder,
                    OptionsJson = f.OptionsJson,
                    ValidationRules = f.ValidationRules,
                    Unit = f.Unit,
                    SortOrder = f.SortOrder,
                    IsActive = f.IsActive,
                    Status = f.Status,
                    CreatedAt = f.CreatedAt,
                    UpdatedAt = f.UpdatedAt,
                    Translations = f.Translations.Select(ft => new DataSchemaFieldTranslationViewModel
                    {
                        Id = ft.Id,
                        DataSchemaFieldId = ft.DataSchemaFieldId,
                        LanguageId = ft.LanguageId,
                        LanguageName = ft.Language?.Name ?? "",
                        LanguageCode = ft.Language?.Code ?? "",
                        IsDefault = ft.Language?.IsDefault ?? false,
                        FieldName = ft.FieldName,
                        Description = ft.Description,
                        Placeholder = ft.Placeholder,
                        Unit = ft.Unit,
                        OptionsJson = ft.OptionsJson
                    }).ToList()
                }).ToList(),
                Translations = dataSchema.Translations.Select(t => new DataSchemaTranslationViewModel
                {
                    Id = t.Id,
                    DataSchemaId = t.DataSchemaId,
                    LanguageId = t.LanguageId,
                    LanguageName = t.Language?.Name ?? "",
                    LanguageCode = t.Language?.Code ?? "",
                    IsDefault = t.Language?.IsDefault ?? false,
                    Name = t.Name,
                    Description = t.Description,
                }).ToList(),
                Products = dataSchema.ProductDataSchemas.Select(pds => new ProductDataSchemaViewModel
                {
                    Id = pds.Id,
                    ProductId = pds.ProductId,
                    ProductName = pds.Product.Name,
                    SchemaId = pds.SchemaId,
                    SchemaName = dataSchema.Name,
                    SchemaKey = dataSchema.Key,
                    IsPrimary = pds.IsPrimary,
                    SortOrder = pds.SortOrder,
                    Configuration = pds.Configuration,
                    IsActive = pds.IsActive,
                    Status = pds.Status,
                    CreatedAt = pds.CreatedAt,
                    UpdatedAt = pds.UpdatedAt
                }).ToList()
            };

            return View(model);
        }

        /// <summary>
        /// Delete DataSchema
        /// </summary>
        [HttpPost]
        public async Task<IActionResult> DeleteDataSchema(int id)
        {
            var dataSchema = await _context.DataSchemas
                .Include(ds => ds.ProductDataSchemas)
                .FirstOrDefaultAsync(ds => ds.Id == id);

            if (dataSchema == null)
            {
                return Json(new { success = false, message = "Schema not found." });
            }

            // Check if schema is being used by products
            if (dataSchema.ProductDataSchemas.Any())
            {
                return Json(new { success = false, message = $"Cannot delete schema. It is being used by {dataSchema.ProductDataSchemas.Count} product(s)." });
            }

            dataSchema.IsDeleted = true;
            await _context.SaveChangesAsync();

            TempData["SuccessMessage"] = "Data schema deleted successfully.";
            return Json(new { success = true, message = "Schema deleted successfully." });
        }

        /// <summary>
        /// Get field types for dropdown
        /// </summary>
        [HttpGet]
        public IActionResult GetFieldTypes()
        {
            var fieldTypes = Enum.GetValues<DataSchemaFieldType>()
                .Where(ft => ft != DataSchemaFieldType.None)
                .Select(ft => new DataSchemaFieldTypeViewModel
                {
                    Value = ft,
                    Name = GetFieldTypeDisplayName(ft),
                    Description = GetFieldTypeDescription(ft)
                })
                .OrderBy(ft => ft.Name)
                .ToList();

            return Json(new { success = true, fieldTypes });
        }

        /// <summary>
        /// Get available schemas for product creation
        /// </summary>
        [HttpGet]
        public async Task<IActionResult> GetAvailableSchemas()
        {
            try
            {
                var schemas = await _context.DataSchemas
                    .Include(ds => ds.Fields)
                    .Where(ds => ds.IsActive && !ds.IsDeleted)
                    .OrderBy(ds => ds.SortOrder)
                    .ThenBy(ds => ds.Name)
                    .Select(ds => new
                    {
                        id = ds.Id,
                        name = ds.Name,
                        key = ds.Key,
                        description = ds.Description,
                        fieldsCount = ds.Fields.Count(f => f.IsActive)
                    })
                    .ToListAsync();

                return Json(new { success = true, schemas });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = "An error occurred: " + ex.Message });
            }
        }

        /// <summary>
        /// Get schema fields for product form
        /// </summary>
        [HttpGet]
        public async Task<IActionResult> GetSchemaFields(int schemaId)
        {
            try
            {
                var fields = await _context.DataSchemaFields
                    .Include(f => f.Translations)
                        .ThenInclude(t => t.Language)
                    .Where(f => f.DataSchemaId == schemaId && f.IsActive && !f.IsDeleted)
                    .OrderBy(f => f.SortOrder)
                    .ThenBy(f => f.FieldName)
                    .Select(f => new
                    {
                        id = f.Id,
                        fieldKey = f.FieldKey,
                        fieldName = f.FieldName,
                        description = f.Description,
                        type = f.Type.ToString(),
                        isRequired = f.IsRequired,
                        isTranslatable = f.IsTranslatable,
                        showInListing = f.ShowInListing,
                        showInDetails = f.ShowInDetails,
                        isFilterable = f.IsFilterable,
                        isSortable = f.IsSortable,
                        defaultValue = f.DefaultValue,
                        placeholder = f.Placeholder,
                        optionsJson = f.OptionsJson,
                        validationRules = f.ValidationRules,
                        unit = f.Unit,
                        sortOrder = f.SortOrder,
                        translations = f.Translations.Select(t => new
                        {
                            languageId = t.LanguageId,
                            languageName = t.Language.Name,
                            languageCode = t.Language.Code,
                            fieldName = t.FieldName,
                            description = t.Description,
                            placeholder = t.Placeholder,
                            unit = t.Unit
                        }).ToList()
                    })
                    .ToListAsync();

                return Json(new { success = true, fields });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = "An error occurred: " + ex.Message });
            }
        }

        /// <summary>
        /// Create product with schema data
        /// </summary>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateProductWithSchema(ProductCreateViewModel model)
        {
            if (!ModelState.IsValid)
            {
                await ReloadProductCreateModel(model);
                return View(model);
            }

            try
            {
                // Create product
                var product = new Product
                {
                    Name = model.Name,
                    Code = model.Code,
                    IntegrationCode = model.IntegrationCode,
                    ShortDescription = model.ShortDescription,
                    LongDescription = model.LongDescription,
                    Unit = model.Unit,
                    Type = model.Type,
                    TaxRate = model.TaxRate,
                    ParentId = model.ParentId,
                    Status = Status.Active,
                    CreatedAt = DateTime.UtcNow
                };

                _context.Products.Add(product);
                await _context.SaveChangesAsync();

                // Add product-schema relationships
                if (model.SelectedDataSchemaIds != null && model.SelectedDataSchemaIds.Any())
                {
                    var productDataSchemas = model.SelectedDataSchemaIds.Select((schemaId, index) => new ProductDataSchema
                    {
                        ProductId = product.Id,
                        SchemaId = schemaId,
                        IsPrimary = index == 0, // First schema is primary
                        SortOrder = index + 1,
                        IsActive = true,
                        CreatedAt = DateTime.UtcNow
                    }).ToList();

                    _context.ProductDataSchemas.AddRange(productDataSchemas);
                    await _context.SaveChangesAsync();
                }

                // Add field values
                if (model.FieldValues != null && model.FieldValues.Any())
                {
                    var fieldValues = model.FieldValues.Select(fv => new DataSchemaFieldValue
                    {
                        ProductId = product.Id,
                        SchemaId = fv.SchemaId,
                        FieldId = fv.FieldId,
                        Value = fv.Value ?? string.Empty,
                        JsonValue = fv.JsonValue,
                        NumericValue = fv.NumericValue,
                        BooleanValue = fv.BooleanValue,
                        DateValue = fv.DateValue,
                        SortOrder = fv.SortOrder,
                        CreatedAt = DateTime.UtcNow
                    }).ToList();

                    _context.DataSchemaFieldValues.AddRange(fieldValues);

                    // Add field value translations
                    foreach (var fieldValue in model.FieldValues.Where(fv => fv.Translations != null && fv.Translations.Any()))
                    {
                        var fieldValueEntity = fieldValues.FirstOrDefault(fv => fv.FieldId == fieldValue.FieldId && fv.SchemaId == fieldValue.SchemaId);
                        if (fieldValueEntity != null)
                        {
                            var translations = fieldValue.Translations
                                .Where(t => !string.IsNullOrWhiteSpace(t.Value))
                                .Select(t => new DataSchemaFieldValueTranslation
                                {
                                    DataSchemaFieldValueId = fieldValueEntity.Id,
                                    LanguageId = t.LanguageId,
                                    Value = t.Value,
                                    JsonValue = t.JsonValue,
                                    CreatedAt = DateTime.UtcNow
                                }).ToList();

                            if (translations.Any())
                            {
                                _context.DataSchemaFieldValueTranslations.AddRange(translations);
                            }
                        }
                    }

                    await _context.SaveChangesAsync();
                }

                TempData["SuccessMessage"] = "Product created successfully with schema data.";
                return RedirectToAction(nameof(Products));
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "An error occurred while creating the product: " + ex.Message);
                await ReloadProductCreateModel(model);
                return View(model);
            }
        }

        /// <summary>
        /// Product create with schema page - GET
        /// </summary>
        [HttpGet]
        public async Task<IActionResult> CreateProductWithSchema()
        {
            var model = new ProductCreateViewModel
            {
                Type = ProductType.Simple,
                TaxRate = 18 // Default tax rate
            };

            await ReloadProductCreateModel(model);
            return View(model);
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

        private async Task ReloadDataSchemaCreateModel(DataSchemaCreateViewModel model)
        {
            var languages = await _context.Languages
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

            if (!model.Translations.Any())
            {
                model.Translations = languages.Select(l => new DataSchemaTranslationCreateViewModel
                {
                    LanguageId = l.Id,
                    LanguageName = l.Name,
                    LanguageCode = l.Code,
                    IsDefault = l.IsDefault
                }).ToList();
            }
        }

        private async Task<List<CategoryListViewModel>> GetAvailableParentCategories()
        {
            return await _context.Set<Category>()
                .Where(c => !c.IsDeleted)
                .OrderBy(c => c.Name)
                .Select(c => new CategoryListViewModel
                {
                    Id = c.Id,
                    Name = c.Name,
                    Code = c.Code
                })
                .ToListAsync();
        }

        private async Task ReloadProductCreateModel(ProductCreateViewModel model)
        {
            // Load available parent products
            model.AvailableParentProducts = await _context.Products
                .Where(p => !p.IsDeleted)
                .OrderBy(p => p.Name)
                .Select(p => new ProductListViewModel
                {
                    Id = p.Id,
                    Name = p.Name,
                    Code = p.Code
                })
                .ToListAsync();

            // Load available data schemas
            model.AvailableDataSchemas = await _context.DataSchemas
                .Where(ds => ds.IsActive && !ds.IsDeleted)
                .OrderBy(ds => ds.SortOrder)
                .ThenBy(ds => ds.Name)
                .Select(ds => new DataSchemaListViewModel
                {
                    Id = ds.Id,
                    Name = ds.Name,
                    Key = ds.Key,
                    Description = ds.Description,
                    FieldsCount = ds.Fields.Count(f => f.IsActive),
                    IsActive = ds.IsActive
                })
                .ToListAsync();
        }

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

        private static string GetFieldTypeDescription(DataSchemaFieldType type)
        {
            return type switch
            {
                DataSchemaFieldType.Text => "Single line text input",
                DataSchemaFieldType.TextArea => "Multi-line text area",
                DataSchemaFieldType.Number => "Numeric input (integer or decimal)",
                DataSchemaFieldType.Boolean => "Boolean checkbox (true/false)",
                DataSchemaFieldType.Date => "Date picker",
                DataSchemaFieldType.DateTime => "Date and time picker",
                DataSchemaFieldType.Email => "Email input with validation",
                DataSchemaFieldType.Url => "URL input with validation",
                DataSchemaFieldType.Phone => "Phone number input",
                DataSchemaFieldType.Color => "Color picker",
                DataSchemaFieldType.File => "Single file upload",
                DataSchemaFieldType.Image => "Image upload with preview",
                DataSchemaFieldType.Video => "Video upload",
                DataSchemaFieldType.Select => "Dropdown select (single selection)",
                DataSchemaFieldType.MultiSelect => "Multi-select dropdown",
                DataSchemaFieldType.Radio => "Radio buttons (single selection)",
                DataSchemaFieldType.Checkbox => "Checkboxes (multiple selections)",
                DataSchemaFieldType.Range => "Range slider for numeric values",
                DataSchemaFieldType.RichText => "Rich text editor (HTML)",
                DataSchemaFieldType.Json => "JSON data input",
                DataSchemaFieldType.Tags => "Tags input (comma-separated values)",
                DataSchemaFieldType.Rating => "Rating input (stars, numbers)",
                DataSchemaFieldType.Currency => "Currency input with symbol",
                DataSchemaFieldType.Percentage => "Percentage input",
                DataSchemaFieldType.Dimensions => "Dimensions input (width x height x depth)",
                DataSchemaFieldType.Weight => "Weight input with unit",
                DataSchemaFieldType.Temperature => "Temperature input with unit",
                DataSchemaFieldType.Custom => "Custom field type (requires special handling)",
                _ => "Unknown field type"
            };
        }

        #endregion
    }
}