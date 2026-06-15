using Newtonsoft.Json;

namespace Notion.Client
{
    public class PageReference
    {
        [JsonProperty("object")]
        public string Object { get; set; }

        [JsonProperty("id")]
        public string Id { get; set; }
    }
}
