using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PazarAtlasi.CMS.Application.Interfaces.Services;
using PazarAtlasi.CMS.Application.Models.Localization;
using PazarAtlasi.CMS.Application.Constants;
using System.Text.Json;

namespace PazarAtlasi.CMS.Controllers
{
    public class LocalizationController : Controller
    {
        private readonly ILanguageService _languageService;
        private readonly ILogger<LocalizationController> _logger;

        public LocalizationController(
            ILanguageService languageService,
            ILogger<LocalizationController> logger)
        {
            _languageService = languageService;
            _logger = logger;
        }

        /// <summary>
        /// Localization management page
        /// </summary>
        public async Task<IActionResult> Index(string? search = null, int page = 1, int pageSize = 50)
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

                // Group by key for better display
                var groupedItems = items
                    .GroupBy(item => item.LangKey)
                    .Skip((page - 1) * pageSize)
                    .Take(pageSize)
                    .ToList();

                ViewBag.Search = search;
                ViewBag.Page = page;
                ViewBag.PageSize = pageSize;
                ViewBag.TotalKeys = items.GroupBy(i => i.LangKey).Count();
                ViewBag.SupportedLanguages = LanguageList.SupportedLanguages;

                return View(groupedItems);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error loading localization index");
                TempData["ErrorMessage"] = "Error loading localization data.";
                return View(new List<IGrouping<string, LanguageValueItem>>());
            }
        }

        /// <summary>
        /// Add new localization key
        /// </summary>
        [HttpGet]
        public IActionResult Add()
        {
            ViewBag.SupportedLanguages = LanguageList.SupportedLanguages;
            return View();
        }

        /// <summary>
        /// Add new localization key - POST
        /// </summary>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Add(string key, string description, string category, Dictionary<string, string> values)
        {
            try
            {
                if (string.IsNullOrEmpty(key))
                {
                    TempData["ErrorMessage"] = "Key is required.";
                    ViewBag.SupportedLanguages = LanguageList.SupportedLanguages;
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
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    TempData["ErrorMessage"] = "Error adding localization key or key already exists.";
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error adding localization key: {key}");
                TempData["ErrorMessage"] = "An error occurred while adding the localization key.";
            }

            ViewBag.SupportedLanguages = LanguageList.SupportedLanguages;
            return View();
        }

        /// <summary>
        /// Edit localization key
        /// </summary>
        [HttpGet]
        public async Task<IActionResult> Edit(string key)
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
                
                return View(keyValues);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error loading localization key for edit: {key}");
                TempData["ErrorMessage"] = "Error loading localization key.";
                return RedirectToAction(nameof(Index));
            }
        }

        /// <summary>
        /// Edit localization key - POST
        /// </summary>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string key, Dictionary<string, string> values)
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
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    TempData["ErrorMessage"] = "Error updating localization key.";
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error updating localization key: {key}");
                TempData["ErrorMessage"] = "An error occurred while updating the localization key.";
            }

            return RedirectToAction(nameof(Edit), new { key });
        }

        /// <summary>
        /// Delete localization key
        /// </summary>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(string key)
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
                _logger.LogError(ex, $"Error deleting localization key: {key}");
                return Json(new { success = false, message = "An error occurred while deleting the localization key." });
            }
        }

        /// <summary>
        /// Get localization value via AJAX
        /// </summary>
        [HttpGet]
        public async Task<IActionResult> GetValue(string key, string? language = null)
        {
            try
            {
                var value = string.IsNullOrEmpty(language) 
                    ? await _languageService.GetLangValueAsync(key)
                    : await _languageService.GetLangValueAsync(key, language);

                return Json(new { success = true, value });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error getting localization value: {key}");
                return Json(new { success = false, message = "Error getting localization value." });
            }
        }

        /// <summary>
        /// Get language dictionary for JavaScript
        /// </summary>
        [HttpGet]
        public async Task<IActionResult> GetDictionary(string? language = null)
        {
            try
            {
                var currentLanguage = language ?? _languageService.GetCurrentLanguage();
                var dictionary = await _languageService.GetLanguageDictionaryAsync(currentLanguage);

                return Json(new { success = true, dictionary, language = currentLanguage });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error getting language dictionary: {language}");
                return Json(new { success = false, message = "Error getting language dictionary." });
            }
        }

        /// <summary>
        /// Refresh localization cache
        /// </summary>
        [HttpPost]
        public async Task<IActionResult> RefreshCache()
        {
            try
            {
                await _languageService.RefreshCacheAsync();
                return Json(new { success = true, message = "Cache refreshed successfully." });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error refreshing localization cache");
                return Json(new { success = false, message = "Error refreshing cache." });
            }
        }

        /// <summary>
        /// Set current language
        /// </summary>
        [HttpPost]
        public IActionResult SetLanguage(string language, string? returnUrl = null)
        {
            try
            {
                if (LanguageList.SupportedLanguages.ContainsKey(language))
                {
                    _languageService.SetCurrentLanguage(language);
                    
                    // Set language cookie
                    Response.Cookies.Append("language", language, new CookieOptions
                    {
                        Expires = DateTimeOffset.UtcNow.AddYears(1),
                        HttpOnly = false,
                        Secure = Request.IsHttps,
                        SameSite = SameSiteMode.Lax,
                        Path = "/"
                    });

                    TempData["SuccessMessage"] = $"Language changed to {LanguageList.SupportedLanguages[language]}.";
                }
                else
                {
                    TempData["ErrorMessage"] = "Invalid language selection.";
                }

                if (!string.IsNullOrEmpty(returnUrl) && Url.IsLocalUrl(returnUrl))
                {
                    return Redirect(returnUrl);
                }

                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error setting language: {language}");
                TempData["ErrorMessage"] = "Error changing language.";
                return RedirectToAction(nameof(Index));
            }
        }

        /// <summary>
        /// Export localization data
        /// </summary>
        [HttpGet]
        public async Task<IActionResult> Export(string? language = null)
        {
            try
            {
                Dictionary<string, string> data;

                if (!string.IsNullOrEmpty(language))
                {
                    data = await _languageService.GetLanguageDictionaryAsync(language);
                }
                else
                {
                    var allData = await _languageService.GetAllAsync();
                    data = allData.ToDictionary(item => $"{item.LangKey}_{item.LangCode}", item => item.LangVal);
                }

                var json = JsonSerializer.Serialize(data, new JsonSerializerOptions
                {
                    WriteIndented = true,
                    Encoder = System.Text.Encodings.Web.JavaScriptEncoder.UnsafeRelaxedJsonEscaping
                });

                var fileName = string.IsNullOrEmpty(language) 
                    ? "localization_all.json" 
                    : $"localization_{language}.json";

                return File(System.Text.Encoding.UTF8.GetBytes(json), "application/json", fileName);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error exporting localization data: {language}");
                TempData["ErrorMessage"] = "Error exporting localization data.";
                return RedirectToAction(nameof(Index));
            }
        }
    }
}