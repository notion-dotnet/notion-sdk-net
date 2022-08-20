using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Notion.Client
{
    public class SelectOptionSchema
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("color")]
        [JsonConverter(typeof(StringEnumConverter))]
        public Color? Color { get; set; }
    }
}
