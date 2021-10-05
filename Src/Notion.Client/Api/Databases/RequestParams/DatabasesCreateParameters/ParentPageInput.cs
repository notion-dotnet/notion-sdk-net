using Newtonsoft.Json;

namespace Notion.Client
{
    public class ParentPageInput : IPageParentInput
    {
        [JsonProperty("page_id")]
        public string PageId { get; set; }
    }
}
