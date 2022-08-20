using JsonSubTypes;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Notion.Client
{
    [JsonConverter(typeof(JsonSubtypes), "type")]
    [JsonSubtypes.KnownSubType(typeof(SinglePropertyRelation), RelationType.Single)]
    [JsonSubtypes.KnownSubType(typeof(DualPropertyRelation), RelationType.Dual)]
    public abstract class RelationData
    {
        [JsonProperty("database_id")]
        public string DatabaseId { get; set; }

        [JsonProperty("type")]
        [JsonConverter(typeof(StringEnumConverter))]
        public virtual RelationType Type { get; set; }
    }
}
