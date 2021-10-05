using Newtonsoft.Json;

namespace Notion.Client
{
    public class DatabaseParentInput : IPageParentInput
    {
        [JsonProperty("database_id")]
        public string DatabaseId { get; set; }
    }
}
