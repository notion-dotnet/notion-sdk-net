using Newtonsoft.Json;

namespace Notion.Client
{
    public class DatabaseParent : IPageParent
    {
        public ParentType Type { get; set; }

        [JsonProperty("database_id")]
        public string DatabaseId { get; set; }
    }
}
