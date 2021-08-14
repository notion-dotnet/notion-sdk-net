using Newtonsoft.Json;

namespace Notion.Client
{
    public class PageParent : IPageParent, IDatabaseParent
    {
        [JsonProperty("page_id")]
        public string PageId { get; set; }
        public ParentType Type { get; set; }
    }
}
