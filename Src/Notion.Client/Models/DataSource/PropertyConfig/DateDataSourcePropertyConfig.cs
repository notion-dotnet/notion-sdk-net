using System.Collections.Generic;
using Newtonsoft.Json;

namespace Notion.Client
{
    public class DateDataSourcePropertyConfig : DataSourcePropertyConfig
    {
        public override string Type => DataSourcePropertyTypes.Date;

        [JsonProperty("date")]
        public Dictionary<string, object> Date { get; set; }
    }
}
