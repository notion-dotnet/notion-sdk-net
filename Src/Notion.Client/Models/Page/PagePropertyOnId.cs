using Newtonsoft.Json;

namespace Notion.Client
{
    public class PagePropertyOnId
    {
        [JsonProperty("id")]
        public string Id { get; set; }
    }
}
