using System.Collections.Generic;
using Newtonsoft.Json;

namespace Notion.Client
{
    public class RollupDataSourcePropertyConfig : DataSourcePropertyConfig
    {
        public override string Type => DataSourcePropertyTypes.Rollup;

        [JsonProperty("rollup")]
        public RollupResponse Rollup { get; set; }
    }

    public class RollupResponse
    {
        [JsonProperty("relation_property_name")]
        public string RelationPropertyName { get; set; }

        [JsonProperty("relation_property_id")]
        public string RelationPropertyId { get; set; }

        [JsonProperty("rollup_property_name")]
        public string RollupPropertyName { get; set; }

        [JsonProperty("rollup_property_id")]
        public string RollupPropertyId { get; set; }

        [JsonProperty("function")]
        public string Function { get; set; }

        [JsonExtensionData]
        public IDictionary<string, object> AdditionalData { get; set; }
    }
}
