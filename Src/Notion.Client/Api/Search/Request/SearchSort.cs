using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Notion.Client
{
    public class SearchSort
    {
        /// <summary>
        /// Supported direction values are "ascending" and "descending".
        /// </summary>
        [JsonProperty("direction")]
        [JsonConverter(typeof(StringEnumConverter))]
        public SearchDirection Direction { get; set; }

        /// <summary>
        /// The only supported timestamp value is "last_edited_time".
        /// </summary>
        [JsonProperty("timestamp")]
        public string Timestamp { get; set; }
    }
}
