using System.Collections.Generic;
using Newtonsoft.Json;

namespace Notion.Client
{
    public class CreatedTimeDataSourcePropertyConfigRequest : DataSourcePropertyConfigRequest
    {
        [JsonProperty("type")]
        public override string Type => "created_time";

        [JsonProperty("created_time")]
        public IDictionary<string, object> CreatedTime { get; set; }
    }
}