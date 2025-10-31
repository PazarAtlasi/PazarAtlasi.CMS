using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using PazarAtlasi.CMS.Application.Constants;
using PazarAtlasi.CMS.Application.Interfaces.Services;

namespace PazarAtlasi.CMS.Application.Extensions
{
    public static class LocalizationExtensions
    {
        /// <summary>
        /// Get localized value for the given key
        /// </summary>
        public static string L(this IServiceProvider serviceProvider, string key)
        {
            var languageService = serviceProvider.GetRequiredService<ILanguageService>();
            return languageService.GetLangValue(key);
        }

        /// <summary>
        /// Get localized value for the given key and language
        /// </summary>
        public static string L(this IServiceProvider serviceProvider, string key, string language)
        {
            var languageService = serviceProvider.GetRequiredService<ILanguageService>();
            return languageService.GetLangValue(key, language);
        }

        /// <summary>
        /// Get localized value async for the given key
        /// </summary>
        public static async Task<string> LAsync(this IServiceProvider serviceProvider, string key, CancellationToken cancellationToken = default)
        {
            var languageService = serviceProvider.GetRequiredService<ILanguageService>();
            return await languageService.GetLangValueAsync(key, cancellationToken);
        }

        /// <summary>
        /// Get localized value async for the given key and language
        /// </summary>
        public static async Task<string> LAsync(this IServiceProvider serviceProvider, string key, string language, CancellationToken cancellationToken = default)
        {
            var languageService = serviceProvider.GetRequiredService<ILanguageService>();
            return await languageService.GetLangValueAsync(key, language, cancellationToken);
        }

        /// <summary>
        /// Set current language from HTTP context
        /// </summary>
        public static void SetLanguageFromContext(this ILanguageService languageService, HttpContext httpContext)
        {
            var language = GetLanguageFromContext(httpContext);
            languageService.SetCurrentLanguage(language);
        }

        /// <summary>
        /// Get language from HTTP context (query, header, cookie, or default)
        /// </summary>
        public static string GetLanguageFromContext(HttpContext httpContext)
        {
            // 1. Check query parameter
            if (httpContext.Request.Query.ContainsKey("lang"))
            {
                var queryLang = httpContext.Request.Query["lang"].ToString();
                if (IsValidLanguage(queryLang))
                {
                    return queryLang;
                }
            }

            // 2. Check Accept-Language header
            var acceptLanguage = httpContext.Request.Headers["Accept-Language"].ToString();
            if (!string.IsNullOrEmpty(acceptLanguage))
            {
                var preferredLanguage = ParseAcceptLanguageHeader(acceptLanguage);
                if (IsValidLanguage(preferredLanguage))
                {
                    return preferredLanguage;
                }
            }

            // 3. Check cookie
            if (httpContext.Request.Cookies.ContainsKey("language"))
            {
                var cookieLang = httpContext.Request.Cookies["language"];
                if (IsValidLanguage(cookieLang))
                {
                    return cookieLang!;
                }
            }

            // 4. Return default language
            return LanguageList.DefaultLang;
        }

        /// <summary>
        /// Check if language code is valid/supported
        /// </summary>
        public static bool IsValidLanguage(string? languageCode)
        {
            if (string.IsNullOrEmpty(languageCode))
                return false;

            return LanguageList.SupportedLanguages.ContainsKey(languageCode);
        }

        /// <summary>
        /// Parse Accept-Language header and return the most preferred supported language
        /// </summary>
        public static string ParseAcceptLanguageHeader(string acceptLanguageHeader)
        {
            if (string.IsNullOrEmpty(acceptLanguageHeader))
                return LanguageList.DefaultLang;

            var languages = acceptLanguageHeader
                .Split(',')
                .Select(lang => lang.Trim().Split(';')[0].Trim())
                .Where(lang => !string.IsNullOrEmpty(lang));

            foreach (var language in languages)
            {
                // Try exact match first
                if (LanguageList.SupportedLanguages.ContainsKey(language))
                {
                    return language;
                }

                // Try culture match (e.g., "en" matches "en-US")
                var matchingCulture = LanguageList.SupportedLanguages.Keys
                    .FirstOrDefault(supported => supported.StartsWith(language + "-"));
                
                if (matchingCulture != null)
                {
                    return matchingCulture;
                }
            }

            return LanguageList.DefaultLang;
        }

        /// <summary>
        /// Get language display name
        /// </summary>
        public static string GetLanguageDisplayName(string languageCode)
        {
            return LanguageList.SupportedLanguages.TryGetValue(languageCode, out var displayName) 
                ? displayName 
                : languageCode;
        }

        /// <summary>
        /// Get all supported languages as key-value pairs
        /// </summary>
        public static Dictionary<string, string> GetSupportedLanguages()
        {
            return LanguageList.SupportedLanguages;
        }

        /// <summary>
        /// Format localized string with parameters
        /// </summary>
        public static string LFormat(this IServiceProvider serviceProvider, string key, params object[] args)
        {
            var languageService = serviceProvider.GetRequiredService<ILanguageService>();
            var template = languageService.GetLangValue(key);
            
            try
            {
                return string.Format(template, args);
            }
            catch (FormatException)
            {
                // If formatting fails, return the template with args appended
                return $"{template} [{string.Join(", ", args)}]";
            }
        }

        /// <summary>
        /// Format localized string with parameters async
        /// </summary>
        public static async Task<string> LFormatAsync(this IServiceProvider serviceProvider, string key, CancellationToken cancellationToken = default, params object[] args)
        {
            var languageService = serviceProvider.GetRequiredService<ILanguageService>();
            var template = await languageService.GetLangValueAsync(key, cancellationToken);
            
            try
            {
                return string.Format(template, args);
            }
            catch (FormatException)
            {
                // If formatting fails, return the template with args appended
                return $"{template} [{string.Join(", ", args)}]";
            }
        }
    }
}