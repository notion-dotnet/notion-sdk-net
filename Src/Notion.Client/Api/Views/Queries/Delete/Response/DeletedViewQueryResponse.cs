using Newtonsoft.Json;

namespace Notion.Client
{
    public class DeletedViewQueryResponse
    {
        [JsonProperty("object")]
        public string Object { get; set; }

        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("deleted")]
        public bool Deleted { get; set; }
    }
}
