using System.Collections.Generic;
using Newtonsoft.Json;

namespace Notion.Client
{
    public class LastEditedTimeDataSourcePropertyConfig : DataSourcePropertyConfig
    {
        public override string Type => DataSourcePropertyTypes.LastEditedTime;

        [JsonProperty("last_edited_time")]
        public Dictionary<string, object> LastEditedTime { get; set; }
    }
}
