using System.Collections.Generic;
using JsonSubTypes;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Notion.Client
{
    [JsonConverter(typeof(JsonSubtypes), "type")]
    [JsonSubtypes.KnownSubTypeAttribute(typeof(SinglePropertyRelationInfo), "single_property")]
    [JsonSubtypes.KnownSubTypeAttribute(typeof(DualPropertyRelationInfo), "dual_property")]
    public abstract class RelationInfo
    {
        [JsonProperty("database_id")]
        public string DatabaseId { get; set; }

        [JsonProperty("data_source_id")]
        public string DataSourceId { get; set; }

        [JsonProperty("type")]
        [JsonConverter(typeof(StringEnumConverter))]
        public virtual string Type { get; set; }

        [JsonExtensionData]
        public IDictionary<string, object> AdditionalData { get; set; }
    }
}
