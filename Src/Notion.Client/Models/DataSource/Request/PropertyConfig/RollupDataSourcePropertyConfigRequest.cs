using System.Collections.Generic;
using Newtonsoft.Json;

namespace Notion.Client
{
    public class RollupDataSourcePropertyConfigRequest : DataSourcePropertyConfigRequest
    {
        [JsonProperty("type")]
        public override string Type => "rollup";

        [JsonProperty("rollup")]
        public RollupOptions Rollup { get; set; }

        public class RollupOptions
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

            /// <summary>
            /// Additional data for future compatibility
            /// If you encounter properties that are not yet supported, please open an issue on GitHub.
            /// </summary>
            [JsonExtensionData]
            public IDictionary<string, object> AdditionalData { get; set; }
        }
    }
}