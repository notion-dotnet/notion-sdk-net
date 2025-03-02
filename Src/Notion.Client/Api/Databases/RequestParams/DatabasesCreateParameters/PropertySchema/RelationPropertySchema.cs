using Newtonsoft.Json;

namespace Notion.Client
{
    public class RelationPropertySchema : IPropertySchema
    {
        [JsonProperty("relation")]
        public RelationData Relation { get; set; }
    }
}
