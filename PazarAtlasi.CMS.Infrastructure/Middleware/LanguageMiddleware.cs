using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using PazarAtlasi.CMS.Application.Extensions;
using PazarAtlasi.CMS.Application.Interfaces.Services;

namespace PazarAtlasi.CMS.Infrastructure.Middleware
{
    public class LanguageMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<LanguageMiddleware> _logger;

        public LanguageMiddleware(RequestDelegate next, ILogger<LanguageMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context, ILanguageService languageService)
        {
            try
            {
                // Get language from context (query, header, cookie, or default)
                var language = LocalizationExtensions.GetLanguageFromContext(context);
                
                // Set current language in the service
                languageService.SetCurrentLanguage(language);

                // Set language cookie if it's different from current cookie
                var currentCookie = context.Request.Cookies["language"];
                if (currentCookie != language)
                {
                    context.Response.Cookies.Append("language", language, new CookieOptions
                    {
                        Expires = DateTimeOffset.UtcNow.AddYears(1),
                        HttpOnly = false, // Allow JavaScript access for client-side language switching
                        Secure = context.Request.IsHttps,
                        SameSite = SameSiteMode.Lax,
                        Path = "/"
                    });
                }

                // Add language to response headers for debugging
                context.Response.Headers.Add("X-Current-Language", language);

                _logger.LogDebug($"Language set to: {language} for request: {context.Request.Path}");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error in LanguageMiddleware");
                // Continue with default language on error
            }

            await _next(context);
        }
    }

    public static class LanguageMiddlewareExtensions
    {
        public static IApplicationBuilder UseLanguageMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<LanguageMiddleware>();
        }
    }
}