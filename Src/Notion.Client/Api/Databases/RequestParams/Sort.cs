using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Notion.Client
{
    public class Sort
    {
        public string Property { get; set; }

        [JsonConverter(typeof(StringEnumConverter))]
        public Timestamp Timestamp { get; set; }

        [JsonConverter(typeof(StringEnumConverter))]
        public Direction Direction { get; set; }
    }
}
