using Newtonsoft.Json;

namespace Notion.Client
{
    public class RelationUpdatePropertySchema : UpdatePropertySchema
    {
        [JsonProperty("relation")]
        public RelationData Relation { get; set; }
    }
}
