using System.Collections.Generic;
using Newtonsoft.Json;

namespace Notion.Client
{
    public class CreatedByDataSourcePropertyConfigRequest : DataSourcePropertyConfigRequest
    {
        [JsonProperty("type")]
        public override string Type => "created_by";

        [JsonProperty("created_by")]
        public IDictionary<string, object> CreatedBy { get; set; }
    }
}