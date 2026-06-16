using Newtonsoft.Json;

namespace Notion.Client
{
    public class ViewSort
    {
        [JsonProperty("property")]
        public string Property { get; set; }

        [JsonProperty("timestamp")]
        public string Timestamp { get; set; }

        [JsonProperty("direction")]
        public string Direction { get; set; }
    }
}
