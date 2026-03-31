using Newtonsoft.Json;

namespace Notion.Client
{
    public class LinkDatabaseToPage : ILinkToPage
    {
        [JsonProperty("type")]
        public string Type => "database_id";

        [JsonProperty("database_id")]
        public string DatabaseId { get; set; }
    }
}
