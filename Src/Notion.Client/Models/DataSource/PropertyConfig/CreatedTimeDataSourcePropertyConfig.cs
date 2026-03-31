using System.Collections.Generic;
using Newtonsoft.Json;

namespace Notion.Client
{
    public class CreatedTimeDataSourcePropertyConfig : DataSourcePropertyConfig
    {
        public override string Type => DataSourcePropertyTypes.CreatedTime;

        [JsonProperty("created_time")]
        public Dictionary<string, object> CreatedTime { get; set; }
    }
}
