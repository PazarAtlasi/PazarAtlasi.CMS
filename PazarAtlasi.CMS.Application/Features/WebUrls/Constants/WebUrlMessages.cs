namespace PazarAtlasi.CMS.Application.Features.WebUrls.Constants
{
    public static class WebUrlMessages
    {
        // Success messages
        public const string WebUrlCreated = "Web URL created successfully.";
        public const string WebUrlUpdated = "Web URL updated successfully.";
        public const string WebUrlDeleted = "Web URL deleted successfully.";

        // Error messages
        public const string WebUrlNotFound = "Web URL not found.";
        public const string SlugAlreadyExists = "A web URL with this slug already exists.";
        public const string TargetUrlRequired = "Target URL is required.";
        public const string SlugRequired = "Slug is required.";
        public const string InvalidSlugFormat = "Invalid slug format. Slug should contain only lowercase letters, numbers, and hyphens.";

        // Validation messages
        public const string SlugTooLong = "Slug cannot be longer than 100 characters.";
        public const string TargetUrlTooLong = "Target URL cannot be longer than 500 characters.";
        public const string NolesTooLong = "Notes cannot be longer than 500 characters.";
    }
}