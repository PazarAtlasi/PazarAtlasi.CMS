namespace PazarAtlasi.CMS.Application.Models
{
    /// <summary>
    /// Standard pagination request object
    /// </summary>
    public class PageRequest
    {
        /// <summary>
        /// Page index (0-based)
        /// </summary>
        public int PageIndex { get; set; } = 0;

        /// <summary>
        /// Page size
        /// </summary>
        public int PageSize { get; set; } = 10;
    }
}