using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PazarAtlasi.CMS.Persistence.Context;
using PazarAtlasi.CMS.Domain.Entities.Metadata;
using PazarAtlasi.CMS.Models.ViewModels;

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
        /// Categories list page
        /// </summary>
        public async Task<IActionResult> Categories(int page = 1, int pageSize = 50)
        {
            var query = _context.Set<Category>()
                .Include(c => c.ParentCategory)
                .AsQueryable();

            var totalCount = await query.CountAsync();
            
            var categories = await query
                .OrderBy(c => c.ParentCategoryId ?? 0)
                .ThenBy(c => c.SortOrder)
                .ThenBy(c => c.Name)
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            var categoryViewModels = BuildCategoryHierarchy(categories.Select(c => new CategoryListViewModel
            {
                Id = c.Id,
                Name = c.Name,
                Code = c.Code,
                Description = c.Description,
                SortOrder = c.SortOrder,
                Status = c.Status,
                CreatedAt = c.CreatedAt,
                UpdatedAt = c.UpdatedAt,
                ParentCategoryId = c.ParentCategoryId,
                ParentCategoryName = c.ParentCategory?.Name,
                ProductsCount = 0, // TODO: Add actual count
                HasChildren = categories.Any(child => child.ParentCategoryId == c.Id)
            }).ToList());

            var flattenedCategories = new List<CategoryListViewModel>();
            FlattenCategoryHierarchy(categoryViewModels, flattenedCategories, 0);

            var model = new CategoryViewModel
            {
                Categories = flattenedCategories,
                TotalCount = totalCount,
                PageNumber = page,
                PageSize = pageSize
            };

            return View(model);
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

        private List<CategoryListViewModel> BuildCategoryHierarchy(List<CategoryListViewModel> categories)
        {
            var rootCategories = categories.Where(c => c.ParentCategoryId == null).ToList();
            
            foreach (var category in rootCategories)
            {
                category.ChildCategories = GetChildCategories(categories, category.Id);
            }
            
            return rootCategories;
        }

        private List<CategoryListViewModel> GetChildCategories(List<CategoryListViewModel> allCategories, int parentId)
        {
            var children = allCategories.Where(c => c.ParentCategoryId == parentId).ToList();
            
            foreach (var child in children)
            {
                child.ChildCategories = GetChildCategories(allCategories, child.Id);
            }
            
            return children;
        }

        private void FlattenCategoryHierarchy(List<CategoryListViewModel> categories, List<CategoryListViewModel> flattened, int level)
        {
            foreach (var category in categories)
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