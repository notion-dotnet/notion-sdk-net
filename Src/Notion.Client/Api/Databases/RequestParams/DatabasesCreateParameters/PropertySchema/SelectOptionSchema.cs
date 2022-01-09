using Newtonsoft.Json;

namespace Notion.Client
{
    public class SelectOptionSchema
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("color")]
        public string Color { get; set; }
    }
}
