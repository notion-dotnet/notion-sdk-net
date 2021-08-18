using Newtonsoft.Json;

namespace Notion.Client
{
    public class ParentPageInput
    {
        [JsonProperty("page_id")]
        public string PageId { get; set; }
    }
}
