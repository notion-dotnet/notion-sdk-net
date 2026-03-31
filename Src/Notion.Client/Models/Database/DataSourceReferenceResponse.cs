using Newtonsoft.Json;

namespace Notion.Client
{
    public class DataSourceReferenceResponse
    {
        [JsonProperty("id")]
        public string DataSourceId { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }
    }
}
