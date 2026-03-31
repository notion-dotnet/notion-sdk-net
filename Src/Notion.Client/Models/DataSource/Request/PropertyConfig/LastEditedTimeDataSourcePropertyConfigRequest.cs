using System.Collections.Generic;
using Newtonsoft.Json;

namespace Notion.Client
{
    public class LastEditedTimeDataSourcePropertyConfigRequest : DataSourcePropertyConfigRequest
    {
        [JsonProperty("type")]
        public override string Type => "last_edited_time";

        [JsonProperty("last_edited_time")]
        public IDictionary<string, object> LastEditedTime { get; set; }
    }
}