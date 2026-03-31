using System.Collections.Generic;
using Newtonsoft.Json;

namespace Notion.Client
{
    public interface IPaginationParameters
    {
        /// <summary>
        /// If supplied, this endpoint will return a page of results starting after the cursor provided. 
        /// If not supplied, this endpoint will return the first page of results.
        /// </summary>
        [JsonProperty("start_cursor")]
        string StartCursor { get; set; }

        /// <summary>
        /// The number of items from the full list desired in the response.
        /// </summary>
        [JsonProperty("page_size")]
        int? PageSize { get; set; }
    }

    public class PaginatedList<T>
    {
        [JsonProperty("object")]
        public const string Object = "list";

        [JsonProperty("results")]
        public List<T> Results { get; set; }

        [JsonProperty("has_more")]
        public bool HasMore { get; set; }

        [JsonProperty("next_cursor")]
        public string NextCursor { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }
    }
}
