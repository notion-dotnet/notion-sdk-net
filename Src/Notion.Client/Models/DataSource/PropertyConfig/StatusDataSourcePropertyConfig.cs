using System.Collections.Generic;
using Newtonsoft.Json;

namespace Notion.Client
{
    public class StatusDataSourcePropertyConfig : DataSourcePropertyConfig
    {
        public override string Type => DataSourcePropertyTypes.Status;

        [JsonProperty("status")]
        public Dictionary<string, object> Status { get; set; }
    }
}
