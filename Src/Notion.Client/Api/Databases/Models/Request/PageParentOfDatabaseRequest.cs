using Newtonsoft.Json;

namespace Notion.Client
{
    public class PageParentOfDatabaseRequest : IParentOfDatabaseRequest
    {
        [JsonProperty("type")]
        public string Type => "page_id";

        [JsonProperty("page_id")]
        public string PageId { get; set; }
    }
}
