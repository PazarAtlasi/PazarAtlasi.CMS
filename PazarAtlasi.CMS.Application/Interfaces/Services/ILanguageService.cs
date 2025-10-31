using PazarAtlasi.CMS.Application.Constants;
using PazarAtlasi.CMS.Application.Models.Localization;

namespace PazarAtlasi.CMS.Application.Interfaces.Services
{
    public interface ILanguageService
    {
        string GetLangValue(string key);

        string GetLangValue(string key, string lang);

        Task<string> GetLangValueAsync(string key, CancellationToken cancellationToken = default);

        Task<string> GetLangValueAsync(string key, string lang, CancellationToken cancellationToken = default);
        
        List<LanguageValueItem> Search(string searchKey);

        Task<List<LanguageValueItem>> SearchAsync(string searchKey, CancellationToken cancellationToken = default);
        
        List<LanguageValueItem> GetAll();

        Task<List<LanguageValueItem>> GetAllAsync(CancellationToken cancellationToken = default);
        
        bool AddLangValue(string key, string value, string desc, string lang = LanguageList.DefaultLang);

        Task<bool> AddLangValueAsync(string key, string value, string desc, string lang = LanguageList.DefaultLang, CancellationToken cancellationToken = default);
        
        List<LanguageValueItem> GetKeyValues(string key);

        Task<List<LanguageValueItem>> GetKeyValuesAsync(string key, CancellationToken cancellationToken = default);
        
        bool UpdateLangValue(string key, string value, string lang);

        Task<bool> UpdateLangValueAsync(string key, string value, string lang, CancellationToken cancellationToken = default);
        
        bool DeleteLangValue(string key, string lang);

        Task<bool> DeleteLangValueAsync(string key, string lang, CancellationToken cancellationToken = default);
        
        void SetCurrentLanguage(string languageCode);

        string GetCurrentLanguage();
        
        Task RefreshCacheAsync(CancellationToken cancellationToken = default);

        Task<Dictionary<string, string>> GetLanguageDictionaryAsync(string languageCode, CancellationToken cancellationToken = default);
    }
}