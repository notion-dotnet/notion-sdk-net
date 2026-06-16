using System.Collections.Generic;
using Newtonsoft.Json;

namespace Notion.Client
{
    public class CreateViewRequest
    {
        [JsonProperty("data_source_id")]
        public string DataSourceId { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("type")]
        public ViewType Type { get; set; }

        [JsonProperty("database_id")]
        public string DatabaseId { get; set; }

        [JsonProperty("filter")]
        public object Filter { get; set; }

        [JsonProperty("sorts")]
        public IEnumerable<ViewSort> Sorts { get; set; }

        [JsonProperty("configuration")]
        public ViewConfiguration Configuration { get; set; }
    }
}
