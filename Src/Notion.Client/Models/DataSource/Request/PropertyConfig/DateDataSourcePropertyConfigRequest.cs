using System.Collections.Generic;
using Newtonsoft.Json;

namespace Notion.Client
{
    public class DateDataSourcePropertyConfigRequest : DataSourcePropertyConfigRequest
    {
        [JsonProperty("type")]
        public override string Type => "date";

        [JsonProperty("date")]
        public IDictionary<string, object> Date { get; set; }
    }
}