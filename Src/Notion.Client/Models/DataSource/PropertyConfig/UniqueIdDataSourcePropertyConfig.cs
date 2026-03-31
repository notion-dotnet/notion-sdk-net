using System.Collections.Generic;
using Newtonsoft.Json;

namespace Notion.Client
{
    public class UniqueIdDataSourcePropertyConfig : DataSourcePropertyConfig
    {
        public override string Type => DataSourcePropertyTypes.UniqueId;

        [JsonProperty("unique_id")]
        public Dictionary<string, object> UniqueId { get; set; }
    }
}
