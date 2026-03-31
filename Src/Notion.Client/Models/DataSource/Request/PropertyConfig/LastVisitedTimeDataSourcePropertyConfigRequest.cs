using System.Collections.Generic;
using Newtonsoft.Json;

namespace Notion.Client
{
    public class LastVisitedTimeDataSourcePropertyConfigRequest : DataSourcePropertyConfigRequest
    {
        [JsonProperty("type")]
        public override string Type => "last_visited_time";

        [JsonProperty("last_visited_time")]
        public IDictionary<string, object> LastVisitedTime { get; set; }
    }
}