using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Notion.Client
{
    public class Sort
    {
        [JsonProperty("property")]
        public string Property { get; set; }

        [JsonProperty("timestamp")]
        [JsonConverter(typeof(StringEnumConverter))]
        public Timestamp Timestamp { get; set; }

        [JsonProperty("direction")]
        [JsonConverter(typeof(StringEnumConverter))]
        public Direction Direction { get; set; }
    }
}
