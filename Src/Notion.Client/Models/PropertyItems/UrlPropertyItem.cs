using Newtonsoft.Json;

namespace Notion.Client
{
    public class UrlPropertyItem : SimplePropertyItem
    {
        public override string Type => "url";

        [JsonProperty("url")]
        public string Url { get; set; }
    }
}
