using Newtonsoft.Json;

namespace Notion.Client
{
    public class DatabaseParent : Parent
    {
        [JsonProperty("database_id")]
        public string DatabaseId { get; set; }
    }
}
