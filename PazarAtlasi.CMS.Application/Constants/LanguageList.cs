namespace PazarAtlasi.CMS.Application.Constants
{
    public static class LanguageList
    {
        public const string DefaultLang = "tr-TR";
        public const string English = "en-US";
        public const string Turkish = "tr-TR";
        public const string German = "de-DE";
        public const string French = "fr-FR";
        public const string Spanish = "es-ES";
        public const string Italian = "it-IT";
        public const string Russian = "ru-RU";
        public const string Arabic = "ar-SA";
        
        public static readonly Dictionary<string, string> SupportedLanguages = new()
        {
            { Turkish, "Türkçe" },
            { English, "English" },
            { German, "Deutsch" },
            { French, "Français" },
            { Spanish, "Español" },
            { Italian, "Italiano" },
            { Russian, "Русский" },
            { Arabic, "العربية" }
        };
    }
}