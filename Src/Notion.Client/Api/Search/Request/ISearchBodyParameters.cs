using Newtonsoft.Json;

namespace Notion.Client
{
    public interface ISearchBodyParameters : IPaginationParameters
    {
        /// <summary>
        /// The text that the API compares page and data_source titles against.
        /// </summary>
        [JsonProperty("query")]
        string Query { get; set; }

        /// <summary>
        /// A set of criteria, direction and timestamp keys, that orders the results. 
        /// The only supported timestamp value is "last_edited_time". Supported direction values are "ascending" and "descending". 
        /// If sort is not provided, then the most recently edited results are returned first.
        /// </summary>
        [JsonProperty("sort")]
        SearchSort Sort { get; set; }

        /// <summary>
        /// A set of criteria, value and property keys, that limits the results to either only pages or only data_sources.
        /// Possible value values are "page" or "data_source". The only supported property value is "object".
        /// </summary>
        [JsonProperty("filter")]
        SearchFilter Filter { get; set; }
    }
}
