using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Notion.Client
{
    public class SearchSort
    {
        [JsonProperty("direction")]
        [JsonConverter(typeof(StringEnumConverter))]
        public SearchDirection Direction { get; set; }

        [JsonProperty("timestamp")]
        public string Timestamp { get; set; }
    }
}
