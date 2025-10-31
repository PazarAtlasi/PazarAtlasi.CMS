using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.DependencyInjection;
using PazarAtlasi.CMS.Application.Interfaces.Services;

namespace PazarAtlasi.CMS.Helpers
{
    public static class LocalizationHelper
    {
        /// <summary>
        /// Get localized string in Razor views
        /// Usage: @LocalizationHelper.L(ViewContext.HttpContext.RequestServices, "Common.Save")
        /// </summary>
        public static string L(IServiceProvider serviceProvider, string key)
        {
            var languageService = serviceProvider.GetRequiredService<ILanguageService>();
            return languageService.GetLangValue(key);
        }

        /// <summary>
        /// Get localized string with specific language in Razor views
        /// </summary>
        public static string L(IServiceProvider serviceProvider, string key, string language)
        {
            var languageService = serviceProvider.GetRequiredService<ILanguageService>();
            return languageService.GetLangValue(key, language);
        }

        /// <summary>
        /// Format localized string with parameters in Razor views
        /// </summary>
        public static string LFormat(IServiceProvider serviceProvider, string key, params object[] args)
        {
            var languageService = serviceProvider.GetRequiredService<ILanguageService>();
            var template = languageService.GetLangValue(key);
            
            try
            {
                return string.Format(template, args);
            }
            catch (FormatException)
            {
                return $"{template} [{string.Join(", ", args)}]";
            }
        }

        /// <summary>
        /// Get current language code
        /// </summary>
        public static string GetCurrentLanguage(IServiceProvider serviceProvider)
        {
            var languageService = serviceProvider.GetRequiredService<ILanguageService>();
            return languageService.GetCurrentLanguage();
        }

        /// <summary>
        /// Check if a localization key exists
        /// </summary>
        public static bool HasKey(IServiceProvider serviceProvider, string key)
        {
            var languageService = serviceProvider.GetRequiredService<ILanguageService>();
            var value = languageService.GetLangValue(key);
            return value != key; // If value equals key, it means the key doesn't exist
        }

        /// <summary>
        /// Get localized string or return fallback if key doesn't exist
        /// </summary>
        public static string LOrDefault(IServiceProvider serviceProvider, string key, string fallback)
        {
            var languageService = serviceProvider.GetRequiredService<ILanguageService>();
            var value = languageService.GetLangValue(key);
            return value != key ? value : fallback;
        }
    }

    /// <summary>
    /// HTML Helper extensions for localization
    /// </summary>
    public static class HtmlLocalizationExtensions
    {
        /// <summary>
        /// Render localized text in HTML helper
        /// Usage: @Html.L("Common.Save")
        /// </summary>
        public static string L(this IHtmlHelper htmlHelper, string key)
        {
            return LocalizationHelper.L(htmlHelper.ViewContext.HttpContext.RequestServices, key);
        }

        /// <summary>
        /// Render localized text with specific language
        /// </summary>
        public static string L(this IHtmlHelper htmlHelper, string key, string language)
        {
            return LocalizationHelper.L(htmlHelper.ViewContext.HttpContext.RequestServices, key, language);
        }

        /// <summary>
        /// Render formatted localized text
        /// </summary>
        public static string LFormat(this IHtmlHelper htmlHelper, string key, params object[] args)
        {
            return LocalizationHelper.LFormat(htmlHelper.ViewContext.HttpContext.RequestServices, key, args);
        }

        /// <summary>
        /// Render localized text or fallback
        /// </summary>
        public static string LOrDefault(this IHtmlHelper htmlHelper, string key, string fallback)
        {
            return LocalizationHelper.LOrDefault(htmlHelper.ViewContext.HttpContext.RequestServices, key, fallback);
        }

        /// <summary>
        /// Get current language code
        /// </summary>
        public static string GetCurrentLanguage(this IHtmlHelper htmlHelper)
        {
            return LocalizationHelper.GetCurrentLanguage(htmlHelper.ViewContext.HttpContext.RequestServices);
        }

        /// <summary>
        /// Check if localization key exists
        /// </summary>
        public static bool HasKey(this IHtmlHelper htmlHelper, string key)
        {
            return LocalizationHelper.HasKey(htmlHelper.ViewContext.HttpContext.RequestServices, key);
        }
    }
}