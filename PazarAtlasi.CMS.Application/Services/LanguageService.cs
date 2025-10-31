using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using PazarAtlasi.CMS.Application.Constants;
using PazarAtlasi.CMS.Application.Interfaces.Infrastructure;
using PazarAtlasi.CMS.Application.Interfaces.Services;
using PazarAtlasi.CMS.Application.Models.Localization;
using PazarAtlasi.CMS.Persistence.Context;

namespace PazarAtlasi.CMS.Application.Services
{
    public class LanguageService : ILanguageService
    {
        private readonly PazarAtlasiDbContext _context;
        private readonly ICacheService _cacheService;
        private readonly ILogger<LanguageService> _logger;
        private string _currentLanguage = LanguageList.DefaultLang;

        private const string CACHE_KEY = "LocalizationValues";
        private const string CACHE_GROUP_KEY = "Localization";

        public LanguageService(
            PazarAtlasiDbContext context,
            ICacheService cacheService,
            ILogger<LanguageService> logger)
        {
            _context = context;
            _cacheService = cacheService;
            _logger = logger;
        }

        public string GetLangValue(string key)
        {
            return GetLangValue(key, _currentLanguage);
        }

        public string GetLangValue(string key, string lang)
        {
            try
            {
                var cacheValue = _cacheService.GetAsync<List<LanguageValueItem>>(CACHE_KEY).Result;
                
                if (cacheValue == null)
                {
                    var all = GetAll();
                    _cacheService.SetWithGroupAsync(CACHE_KEY, all, CACHE_GROUP_KEY, TimeSpan.FromHours(24)).Wait();
                    cacheValue = all;
                }

                if (cacheValue == null)
                {
                    _logger.LogWarning($"Localization cache is null for key: {key}");
                    return key;
                }

                var langVal = cacheValue.FirstOrDefault(m => m.LangKey == key && m.LangCode == lang);
                
                if (langVal == null)
                {
                    _logger.LogWarning($"Localization value not found - Key: {key}, Lang: {lang}");
                    return key;
                }

                return langVal.LangVal ?? key;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error getting localization value - Key: {key}, Lang: {lang}");
                return key;
            }
        }

        public async Task<string> GetLangValueAsync(string key, CancellationToken cancellationToken = default)
        {
            return await GetLangValueAsync(key, _currentLanguage, cancellationToken);
        }

        public async Task<string> GetLangValueAsync(string key, string lang, CancellationToken cancellationToken = default)
        {
            try
            {
                var cacheValue = await _cacheService.GetAsync<List<LanguageValueItem>>(CACHE_KEY, cancellationToken);
                
                if (cacheValue == null)
                {
                    var all = await GetAllAsync(cancellationToken);
                    await _cacheService.SetWithGroupAsync(CACHE_KEY, all, CACHE_GROUP_KEY, TimeSpan.FromHours(24), cancellationToken);
                    cacheValue = all;
                }

                if (cacheValue == null)
                {
                    _logger.LogWarning($"Localization cache is null for key: {key}");
                    return key;
                }

                var langVal = cacheValue.FirstOrDefault(m => m.LangKey == key && m.LangCode == lang);
                
                if (langVal == null)
                {
                    _logger.LogWarning($"Localization value not found - Key: {key}, Lang: {lang}");
                    return key;
                }

                return langVal.LangVal ?? key;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error getting localization value async - Key: {key}, Lang: {lang}");
                return key;
            }
        }

        public List<LanguageValueItem> Search(string searchKey)
        {
            try
            {
                var results = _context.LocalizationValues
                    .Include(lv => lv.Language)
                    .Where(lv => lv.Key.Contains(searchKey) && !lv.IsDeleted && lv.IsActive)
                    .Select(lv => new LanguageValueItem
                    {
                        Id = lv.Id,
                        LangKey = lv.Key,
                        LangVal = lv.Value,
                        LangDescription = lv.Description,
                        LangCode = lv.Language.Code,
                        Category = lv.Category,
                        IsActive = lv.IsActive
                    })
                    .ToList();

                _logger.LogDebug($"Search completed - SearchKey: {searchKey}, Results: {results.Count}");
                return results;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error searching localization values - SearchKey: {searchKey}");
                return new List<LanguageValueItem>();
            }
        }

        public async Task<List<LanguageValueItem>> SearchAsync(string searchKey, CancellationToken cancellationToken = default)
        {
            try
            {
                var results = await _context.LocalizationValues
                    .Include(lv => lv.Language)
                    .Where(lv => lv.Key.Contains(searchKey) && !lv.IsDeleted && lv.IsActive)
                    .Select(lv => new LanguageValueItem
                    {
                        Id = lv.Id,
                        LangKey = lv.Key,
                        LangVal = lv.Value,
                        LangDescription = lv.Description,
                        LangCode = lv.Language.Code,
                        Category = lv.Category,
                        IsActive = lv.IsActive
                    })
                    .ToListAsync(cancellationToken);

                _logger.LogDebug($"Search completed async - SearchKey: {searchKey}, Results: {results.Count}");
                return results;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error searching localization values async - SearchKey: {searchKey}");
                return new List<LanguageValueItem>();
            }
        }

        public List<LanguageValueItem> GetAll()
        {
            try
            {
                var results = _context.LocalizationValues
                    .Include(lv => lv.Language)
                    .Where(lv => !lv.IsDeleted && lv.IsActive)
                    .Select(lv => new LanguageValueItem
                    {
                        Id = lv.Id,
                        LangKey = lv.Key,
                        LangVal = lv.Value,
                        LangDescription = lv.Description,
                        LangCode = lv.Language.Code,
                        Category = lv.Category,
                        IsActive = lv.IsActive
                    })
                    .ToList();

                _logger.LogDebug($"GetAll completed - Total: {results.Count}");
                return results;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error getting all localization values");
                return new List<LanguageValueItem>();
            }
        }

        public async Task<List<LanguageValueItem>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            try
            {
                var results = await _context.LocalizationValues
                    .Include(lv => lv.Language)
                    .Where(lv => !lv.IsDeleted && lv.IsActive)
                    .Select(lv => new LanguageValueItem
                    {
                        Id = lv.Id,
                        LangKey = lv.Key,
                        LangVal = lv.Value,
                        LangDescription = lv.Description,
                        LangCode = lv.Language.Code,
                        Category = lv.Category,
                        IsActive = lv.IsActive
                    })
                    .ToListAsync(cancellationToken);

                _logger.LogDebug($"GetAll completed async - Total: {results.Count}");
                return results;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error getting all localization values async");
                return new List<LanguageValueItem>();
            }
        }

        public bool AddLangValue(string key, string value, string desc, string lang = LanguageList.DefaultLang)
        {
            try
            {
                // Get language by code
                var language = _context.Languages.FirstOrDefault(l => l.Code == lang && !l.IsDeleted);
                if (language == null)
                {
                    _logger.LogWarning($"Language not found: {lang}");
                    return false;
                }

                // Check if key already exists for this language
                var existingValue = _context.LocalizationValues
                    .FirstOrDefault(lv => lv.Key == key && lv.LanguageId == language.Id && !lv.IsDeleted);

                if (existingValue != null)
                {
                    _logger.LogWarning($"Localization key already exists - Key: {key}, Lang: {lang}");
                    return false;
                }

                var localizationValue = new Domain.Entities.Localization.LocalizationValue
                {
                    LanguageId = language.Id,
                    Key = key,
                    Value = value,
                    Description = desc,
                    IsActive = true,
                    CreatedAt = DateTime.UtcNow
                };

                _context.LocalizationValues.Add(localizationValue);
                var result = _context.SaveChanges() > 0;

                if (result)
                {
                    // Clear cache
                    _cacheService.RemoveGroupAsync(CACHE_GROUP_KEY).Wait();
                    _logger.LogInformation($"Added localization value - Key: {key}, Lang: {lang}");
                }

                return result;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error adding localization value - Key: {key}, Lang: {lang}");
                return false;
            }
        }

        public async Task<bool> AddLangValueAsync(string key, string value, string desc, string lang = LanguageList.DefaultLang, CancellationToken cancellationToken = default)
        {
            try
            {
                // Get language by code
                var language = await _context.Languages
                    .FirstOrDefaultAsync(l => l.Code == lang && !l.IsDeleted, cancellationToken);
                
                if (language == null)
                {
                    _logger.LogWarning($"Language not found: {lang}");
                    return false;
                }

                // Check if key already exists for this language
                var existingValue = await _context.LocalizationValues
                    .FirstOrDefaultAsync(lv => lv.Key == key && lv.LanguageId == language.Id && !lv.IsDeleted, cancellationToken);

                if (existingValue != null)
                {
                    _logger.LogWarning($"Localization key already exists - Key: {key}, Lang: {lang}");
                    return false;
                }

                var localizationValue = new Domain.Entities.Localization.LocalizationValue
                {
                    LanguageId = language.Id,
                    Key = key,
                    Value = value,
                    Description = desc,
                    IsActive = true,
                    CreatedAt = DateTime.UtcNow
                };

                _context.LocalizationValues.Add(localizationValue);
                var result = await _context.SaveChangesAsync(cancellationToken) > 0;

                if (result)
                {
                    // Clear cache
                    await _cacheService.RemoveGroupAsync(CACHE_GROUP_KEY, cancellationToken);
                    _logger.LogInformation($"Added localization value async - Key: {key}, Lang: {lang}");
                }

                return result;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error adding localization value async - Key: {key}, Lang: {lang}");
                return false;
            }
        }

        public List<LanguageValueItem> GetKeyValues(string key)
        {
            try
            {
                var results = _context.LocalizationValues
                    .Include(lv => lv.Language)
                    .Where(lv => lv.Key == key && !lv.IsDeleted && lv.IsActive)
                    .Select(lv => new LanguageValueItem
                    {
                        Id = lv.Id,
                        LangKey = lv.Key,
                        LangVal = lv.Value,
                        LangDescription = lv.Description,
                        LangCode = lv.Language.Code,
                        Category = lv.Category,
                        IsActive = lv.IsActive
                    })
                    .ToList();

                _logger.LogDebug($"GetKeyValues completed - Key: {key}, Results: {results.Count}");
                return results;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error getting key values - Key: {key}");
                return new List<LanguageValueItem>();
            }
        }

        public async Task<List<LanguageValueItem>> GetKeyValuesAsync(string key, CancellationToken cancellationToken = default)
        {
            try
            {
                var results = await _context.LocalizationValues
                    .Include(lv => lv.Language)
                    .Where(lv => lv.Key == key && !lv.IsDeleted && lv.IsActive)
                    .Select(lv => new LanguageValueItem
                    {
                        Id = lv.Id,
                        LangKey = lv.Key,
                        LangVal = lv.Value,
                        LangDescription = lv.Description,
                        LangCode = lv.Language.Code,
                        Category = lv.Category,
                        IsActive = lv.IsActive
                    })
                    .ToListAsync(cancellationToken);

                _logger.LogDebug($"GetKeyValues completed async - Key: {key}, Results: {results.Count}");
                return results;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error getting key values async - Key: {key}");
                return new List<LanguageValueItem>();
            }
        }

        public bool UpdateLangValue(string key, string value, string lang)
        {
            try
            {
                var language = _context.Languages.FirstOrDefault(l => l.Code == lang && !l.IsDeleted);
                if (language == null)
                {
                    _logger.LogWarning($"Language not found: {lang}");
                    return false;
                }

                var localizationValue = _context.LocalizationValues
                    .FirstOrDefault(lv => lv.Key == key && lv.LanguageId == language.Id && !lv.IsDeleted);

                if (localizationValue == null)
                {
                    _logger.LogWarning($"Localization value not found - Key: {key}, Lang: {lang}");
                    return false;
                }

                localizationValue.Value = value;
                localizationValue.UpdatedAt = DateTime.UtcNow;

                var result = _context.SaveChanges() > 0;

                if (result)
                {
                    // Clear cache
                    _cacheService.RemoveGroupAsync(CACHE_GROUP_KEY).Wait();
                    _logger.LogInformation($"Updated localization value - Key: {key}, Lang: {lang}");
                }

                return result;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error updating localization value - Key: {key}, Lang: {lang}");
                return false;
            }
        }

        public async Task<bool> UpdateLangValueAsync(string key, string value, string lang, CancellationToken cancellationToken = default)
        {
            try
            {
                var language = await _context.Languages
                    .FirstOrDefaultAsync(l => l.Code == lang && !l.IsDeleted, cancellationToken);
                
                if (language == null)
                {
                    _logger.LogWarning($"Language not found: {lang}");
                    return false;
                }

                var localizationValue = await _context.LocalizationValues
                    .FirstOrDefaultAsync(lv => lv.Key == key && lv.LanguageId == language.Id && !lv.IsDeleted, cancellationToken);

                if (localizationValue == null)
                {
                    _logger.LogWarning($"Localization value not found - Key: {key}, Lang: {lang}");
                    return false;
                }

                localizationValue.Value = value;
                localizationValue.UpdatedAt = DateTime.UtcNow;

                var result = await _context.SaveChangesAsync(cancellationToken) > 0;

                if (result)
                {
                    // Clear cache
                    await _cacheService.RemoveGroupAsync(CACHE_GROUP_KEY, cancellationToken);
                    _logger.LogInformation($"Updated localization value async - Key: {key}, Lang: {lang}");
                }

                return result;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error updating localization value async - Key: {key}, Lang: {lang}");
                return false;
            }
        }

        public bool DeleteLangValue(string key, string lang)
        {
            try
            {
                var language = _context.Languages.FirstOrDefault(l => l.Code == lang && !l.IsDeleted);
                if (language == null)
                {
                    _logger.LogWarning($"Language not found: {lang}");
                    return false;
                }

                var localizationValue = _context.LocalizationValues
                    .FirstOrDefault(lv => lv.Key == key && lv.LanguageId == language.Id && !lv.IsDeleted);

                if (localizationValue == null)
                {
                    _logger.LogWarning($"Localization value not found - Key: {key}, Lang: {lang}");
                    return false;
                }

                localizationValue.IsDeleted = true;
                localizationValue.UpdatedAt = DateTime.UtcNow;

                var result = _context.SaveChanges() > 0;

                if (result)
                {
                    // Clear cache
                    _cacheService.RemoveGroupAsync(CACHE_GROUP_KEY).Wait();
                    _logger.LogInformation($"Deleted localization value - Key: {key}, Lang: {lang}");
                }

                return result;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error deleting localization value - Key: {key}, Lang: {lang}");
                return false;
            }
        }

        public async Task<bool> DeleteLangValueAsync(string key, string lang, CancellationToken cancellationToken = default)
        {
            try
            {
                var language = await _context.Languages
                    .FirstOrDefaultAsync(l => l.Code == lang && !l.IsDeleted, cancellationToken);
                
                if (language == null)
                {
                    _logger.LogWarning($"Language not found: {lang}");
                    return false;
                }

                var localizationValue = await _context.LocalizationValues
                    .FirstOrDefaultAsync(lv => lv.Key == key && lv.LanguageId == language.Id && !lv.IsDeleted, cancellationToken);

                if (localizationValue == null)
                {
                    _logger.LogWarning($"Localization value not found - Key: {key}, Lang: {lang}");
                    return false;
                }

                localizationValue.IsDeleted = true;
                localizationValue.UpdatedAt = DateTime.UtcNow;

                var result = await _context.SaveChangesAsync(cancellationToken) > 0;

                if (result)
                {
                    // Clear cache
                    await _cacheService.RemoveGroupAsync(CACHE_GROUP_KEY, cancellationToken);
                    _logger.LogInformation($"Deleted localization value async - Key: {key}, Lang: {lang}");
                }

                return result;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error deleting localization value async - Key: {key}, Lang: {lang}");
                return false;
            }
        }

        public void SetCurrentLanguage(string languageCode)
        {
            _currentLanguage = languageCode;
            _logger.LogDebug($"Current language set to: {languageCode}");
        }

        public string GetCurrentLanguage()
        {
            return _currentLanguage;
        }

        public async Task RefreshCacheAsync(CancellationToken cancellationToken = default)
        {
            try
            {
                await _cacheService.RemoveGroupAsync(CACHE_GROUP_KEY, cancellationToken);
                var all = await GetAllAsync(cancellationToken);
                await _cacheService.SetWithGroupAsync(CACHE_KEY, all, CACHE_GROUP_KEY, TimeSpan.FromHours(24), cancellationToken);
                
                _logger.LogInformation("Localization cache refreshed successfully");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error refreshing localization cache");
            }
        }

        public async Task<Dictionary<string, string>> GetLanguageDictionaryAsync(string languageCode, CancellationToken cancellationToken = default)
        {
            try
            {
                var cacheKey = $"LanguageDictionary_{languageCode}";
                var cachedDictionary = await _cacheService.GetAsync<Dictionary<string, string>>(cacheKey, cancellationToken);
                
                if (cachedDictionary != null)
                {
                    return cachedDictionary;
                }

                var language = await _context.Languages
                    .FirstOrDefaultAsync(l => l.Code == languageCode && !l.IsDeleted, cancellationToken);
                
                if (language == null)
                {
                    _logger.LogWarning($"Language not found: {languageCode}");
                    return new Dictionary<string, string>();
                }

                var dictionary = await _context.LocalizationValues
                    .Where(lv => lv.LanguageId == language.Id && !lv.IsDeleted && lv.IsActive)
                    .ToDictionaryAsync(lv => lv.Key, lv => lv.Value, cancellationToken);

                await _cacheService.SetWithGroupAsync(cacheKey, dictionary, CACHE_GROUP_KEY, TimeSpan.FromHours(12), cancellationToken);
                
                _logger.LogDebug($"Language dictionary loaded - Lang: {languageCode}, Keys: {dictionary.Count}");
                return dictionary;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error getting language dictionary - Lang: {languageCode}");
                return new Dictionary<string, string>();
            }
        }
    }
}