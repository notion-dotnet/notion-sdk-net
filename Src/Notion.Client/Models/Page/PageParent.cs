using Newtonsoft.Json;

namespace Notion.Client
{
    public class PageParent : Parent
    {
        [JsonProperty("page_id")]
        public string PageId { get; set; }
    }
}