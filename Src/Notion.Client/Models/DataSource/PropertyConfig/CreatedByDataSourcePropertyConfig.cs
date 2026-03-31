using System.Collections.Generic;
using Newtonsoft.Json;

namespace Notion.Client
{
    public class CreatedByDataSourcePropertyConfig : DataSourcePropertyConfig
    {
        public override string Type => DataSourcePropertyTypes.CreatedBy;

        [JsonProperty("created_by")]
        public Dictionary<string, object> CreatedBy { get; set; }
    }
}
