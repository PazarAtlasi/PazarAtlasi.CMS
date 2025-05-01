using System.Collections.Generic;

namespace PazarAtlasi.Core.Application.Responses
{
    /// <summary>
    /// Standard response for paginated lists
    /// </summary>
    /// <typeparam name="T">Type of the items in the list</typeparam>
    public class GetListResponse<T> where T : class
    {
        /// <summary>
        /// List of items
        /// </summary>
        public List<T> Items { get; set; }

        /// <summary>
        /// Total count of items
        /// </summary>
        public int Count { get; set; }

        /// <summary>
        /// Page index
        /// </summary>
        public int PageIndex { get; set; }

        /// <summary>
        /// Page size
        /// </summary>
        public int PageSize { get; set; }

        /// <summary>
        /// Constructor
        /// </summary>
        public GetListResponse()
        {
            Items = new List<T>();
        }
    }
}