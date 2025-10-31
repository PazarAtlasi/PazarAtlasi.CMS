using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PazarAtlasi.CMS.Persistence.Context;
using PazarAtlasi.CMS.Domain.Common;
using PazarAtlasi.CMS.Models.ViewModels;
using PazarAtlasi.CMS.Application.Interfaces.Services;
using PazarAtlasi.CMS.Application.Models.Localization;
using PazarAtlasi.CMS.Application.Constants;

namespace PazarAtlasi.CMS.Controllers
{
    public class SettingsController : Controller
    {
        private readonly PazarAtlasiDbContext _context;
        private readonly ILanguageService _languageService;

        public SettingsController(PazarAtlasiDbContext context, ILanguageService languageService)
        {
            _context = context;
            _languageService = languageService;
        }

        public IActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// Countries list page
        /// </summary>
        public async Task<IActionResult> Countries(int page = 1, int pageSize = 20)
        {
            var totalCount = await _context.Countries.CountAsync(c => !c.IsDeleted);

            var countries = await _context.Countries
                .Include(c => c.Continent)
                .Where(c => !c.IsDeleted)
                .OrderBy(c => c.SortOrder)
                .ThenBy(c => c.Name)
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .Select(c => new CountryViewModel
                {
                    Id = c.Id,
                    Name = c.Name,
                    Code = c.Code,
                    IsActive = c.IsActive,
                    SortOrder = c.SortOrder,
                    ContinentId = c.ContinentId,
                    ContinentName = c.Continent != null ? c.Continent.Name : null,
                    IsPopular = c.IsPopular,
                    CreatedAt = c.CreatedAt,
                    UpdatedAt = c.UpdatedAt
                })
                .ToListAsync();

            // Get continents for filter
            var continents = await _context.Continents
                .Where(c => !c.IsDeleted && c.IsActive)
                .OrderBy(c => c.SortOrder)
                .Select(c => new ContinentViewModel
                {
                    Id = c.Id,
                    Name = c.Name,
                    Code = c.Code,
                    IsActive = c.IsActive,
                    SortOrder = c.SortOrder,
                    CountryCount = c.Countries.Count(co => !co.IsDeleted),
                    CreatedAt = c.CreatedAt,
                    UpdatedAt = c.UpdatedAt
                })
                .ToListAsync();

            // Get popular countries
            var popularCountries = await _context.Countries
                .Include(c => c.Continent)
                .Where(c => !c.IsDeleted && c.IsPopular && c.IsActive)
                .OrderBy(c => c.Name)
                .Select(c => new CountryViewModel
                {
                    Id = c.Id,
                    Name = c.Name,
                    Code = c.Code,
                    IsActive = c.IsActive,
                    SortOrder = c.SortOrder,
                    ContinentId = c.ContinentId,
                    ContinentName = c.Continent != null ? c.Continent.Name : null,
                    IsPopular = c.IsPopular,
                    CreatedAt = c.CreatedAt,
                    UpdatedAt = c.UpdatedAt
                })
                .ToListAsync();

            var model = new CountryListViewModel
            {
                Countries = countries,
                Continents = continents,
                PopularCountries = popularCountries,
                TotalCount = totalCount,
                PageNumber = page,
                PageSize = pageSize
            };

            return View(model);
        }

        /// <summary>
        /// Languages list page
        /// </summary>
        public async Task<IActionResult> Languages(int page = 1, int pageSize = 20)
        {
            var totalCount = await _context.Languages.CountAsync(l => !l.IsDeleted);

            var languages = await _context.Languages
                .Where(l => !l.IsDeleted)
                .OrderByDescending(l => l.IsDefault)
                .ThenBy(l => l.Name)
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .Select(l => new LanguageViewModel
                {
                    Id = l.Id,
                    Name = l.Name,
                    Code = l.Code,
                    IsDefault = l.IsDefault,
                    CreatedAt = l.CreatedAt,
                    UpdatedAt = l.UpdatedAt
                })
                .ToListAsync();

            var model = new LanguageListViewModel
            {
                Languages = languages,
                TotalCount = totalCount,
                PageNumber = page,
                PageSize = pageSize
            };

            return View(model);
        }

        /// <summary>
        /// Toggle country active status
        /// </summary>
        [HttpPost]
        public async Task<IActionResult> ToggleCountryStatus(int id)
        {
            try
            {
                var country = await _context.Countries.FindAsync(id);
                if (country == null)
                {
                    return Json(new { success = false, message = "Country not found." });
                }

                country.IsActive = !country.IsActive;
                country.UpdatedAt = DateTime.UtcNow;

                await _context.SaveChangesAsync();

                return Json(new { 
                    success = true, 
                    message = $"Country {(country.IsActive ? "activated" : "deactivated")} successfully.",
                    isActive = country.IsActive
                });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = "An error occurred while updating country status." });
            }
        }

        /// <summary>
        /// Set default language
        /// </summary>
        [HttpPost]
        public async Task<IActionResult> SetDefaultLanguage(int id)
        {
            try
            {
                // Remove default from all languages
                var allLanguages = await _context.Languages.Where(l => !l.IsDeleted).ToListAsync();
                foreach (var lang in allLanguages)
                {
                    lang.IsDefault = false;
                }

                // Set new default
                var language = allLanguages.FirstOrDefault(l => l.Id == id);
                if (language == null)
                {
                    return Json(new { success = false, message = "Language not found." });
                }

                language.IsDefault = true;
                language.UpdatedAt = DateTime.UtcNow;

                await _context.SaveChangesAsync();

                return Json(new { 
                    success = true, 
                    message = $"{language.Name} set as default language successfully."
                });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = "An error occurred while setting default language." });
            }
        }

        /// <summary>
        /// Localization management page
        /// </summary>
        public async Task<IActionResult> Localization(string? search = null, string? category = null, int page = 1, int pageSize = 20)
        {
            try
            {
                List<LanguageValueItem> items;

                if (!string.IsNullOrEmpty(search))
                {
                    items = await _languageService.SearchAsync(search);
                }
                else
                {
                    items = await _languageService.GetAllAsync();
                }

                // Filter by category if specified
                if (!string.IsNullOrEmpty(category))
                {
                    items = items.Where(i => i.Category?.Equals(category, StringComparison.OrdinalIgnoreCase) == true).ToList();
                }

                // Group by key for better display
                var groupedItems = items
                    .GroupBy(item => item.LangKey)
                    .OrderBy(g => g.Key)
                    .Skip((page - 1) * pageSize)
                    .Take(pageSize)
                    .ToList();

                // Get categories for filter
                var categories = items
                    .Where(i => !string.IsNullOrEmpty(i.Category))
                    .Select(i => i.Category!)
                    .Distinct()
                    .OrderBy(c => c)
                    .ToList();

                ViewBag.Search = search;
                ViewBag.Category = category;
                ViewBag.Categories = categories;
                ViewBag.Page = page;
                ViewBag.PageSize = pageSize;
                ViewBag.TotalKeys = items.GroupBy(i => i.LangKey).Count();
                ViewBag.SupportedLanguages = LanguageList.SupportedLanguages;

                return View(groupedItems);
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = "Error loading localization data.";
                return View(new List<IGrouping<string, LanguageValueItem>>());
            }
        }

        /// <summary>
        /// Add new localization key
        /// </summary>
        [HttpGet]
        public IActionResult AddLocalization()
        {
            ViewBag.SupportedLanguages = LanguageList.SupportedLanguages;
            
            // Get categories for dropdown
            var categories = new List<string> { "Common", "Navigation", "Page", "Section", "Dashboard", "Validation", "Language" };
            ViewBag.Categories = categories;
            
            return View();
        }

        /// <summary>
        /// Add new localization key - POST
        /// </summary>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddLocalization(string key, string description, string category, Dictionary<string, string> values)
        {
            try
            {
                if (string.IsNullOrEmpty(key))
                {
                    TempData["ErrorMessage"] = "Key is required.";
                    ViewBag.SupportedLanguages = LanguageList.SupportedLanguages;
                    ViewBag.Categories = new List<string> { "Common", "Navigation", "Page", "Section", "Dashboard", "Validation", "Language" };
                    return View();
                }

                var success = true;
                var addedCount = 0;

                foreach (var languageCode in LanguageList.SupportedLanguages.Keys)
                {
                    var value = values.ContainsKey(languageCode) ? values[languageCode] : string.Empty;
                    
                    if (!string.IsNullOrEmpty(value))
                    {
                        var result = await _languageService.AddLangValueAsync(key, value, description, languageCode);
                        if (result)
                        {
                            addedCount++;
                        }
                        else
                        {
                            success = false;
                        }
                    }
                }

                if (success && addedCount > 0)
                {
                    TempData["SuccessMessage"] = $"Localization key '{key}' added successfully for {addedCount} language(s).";
                    return RedirectToAction(nameof(Localization));
                }
                else
                {
                    TempData["ErrorMessage"] = "Error adding localization key or key already exists.";
                }
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = "An error occurred while adding the localization key.";
            }

            ViewBag.SupportedLanguages = LanguageList.SupportedLanguages;
            ViewBag.Categories = new List<string> { "Common", "Navigation", "Page", "Section", "Dashboard", "Validation", "Language" };
            return View();
        }

        /// <summary>
        /// Edit localization key
        /// </summary>
        [HttpGet]
        public async Task<IActionResult> EditLocalization(string key)
        {
            try
            {
                if (string.IsNullOrEmpty(key))
                {
                    return NotFound();
                }

                var keyValues = await _languageService.GetKeyValuesAsync(key);
                
                if (!keyValues.Any())
                {
                    return NotFound();
                }

                ViewBag.Key = key;
                ViewBag.SupportedLanguages = LanguageList.SupportedLanguages;
                ViewBag.Categories = new List<string> { "Common", "Navigation", "Page", "Section", "Dashboard", "Validation", "Language" };
                
                return View(keyValues);
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = "Error loading localization key.";
                return RedirectToAction(nameof(Localization));
            }
        }

        /// <summary>
        /// Edit localization key - POST
        /// </summary>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditLocalization(string key, string description, string category, Dictionary<string, string> values)
        {
            try
            {
                if (string.IsNullOrEmpty(key))
                {
                    return NotFound();
                }

                var success = true;
                var updatedCount = 0;

                foreach (var kvp in values)
                {
                    var languageCode = kvp.Key;
                    var value = kvp.Value;

                    if (!string.IsNullOrEmpty(value))
                    {
                        var result = await _languageService.UpdateLangValueAsync(key, value, languageCode);
                        if (result)
                        {
                            updatedCount++;
                        }
                        else
                        {
                            success = false;
                        }
                    }
                }

                if (success && updatedCount > 0)
                {
                    TempData["SuccessMessage"] = $"Localization key '{key}' updated successfully for {updatedCount} language(s).";
                    return RedirectToAction(nameof(Localization));
                }
                else
                {
                    TempData["ErrorMessage"] = "Error updating localization key.";
                }
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = "An error occurred while updating the localization key.";
            }

            return RedirectToAction(nameof(EditLocalization), new { key });
        }

        /// <summary>
        /// Delete localization key
        /// </summary>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteLocalization(string key)
        {
            try
            {
                if (string.IsNullOrEmpty(key))
                {
                    return Json(new { success = false, message = "Key is required." });
                }

                var success = true;
                var deletedCount = 0;

                foreach (var languageCode in LanguageList.SupportedLanguages.Keys)
                {
                    var result = await _languageService.DeleteLangValueAsync(key, languageCode);
                    if (result)
                    {
                        deletedCount++;
                    }
                    else
                    {
                        success = false;
                    }
                }

                if (success && deletedCount > 0)
                {
                    return Json(new { success = true, message = $"Localization key '{key}' deleted successfully." });
                }
                else
                {
                    return Json(new { success = false, message = "Error deleting localization key." });
                }
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = "An error occurred while deleting the localization key." });
            }
        }

        /// <summary>
        /// Refresh localization cache
        /// </summary>
        [HttpPost]
        public async Task<IActionResult> RefreshLocalizationCache()
        {
            try
            {
                await _languageService.RefreshCacheAsync();
                return Json(new { success = true, message = "Cache refreshed successfully." });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = "Error refreshing cache." });
            }
        }
    }
}