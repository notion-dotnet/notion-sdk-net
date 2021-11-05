using Newtonsoft.Json;

namespace Notion.Client
{
    public class RelationPropertyItem : SimplePropertyItem
    {
        public override string Type => "relation";

        [JsonProperty("relation")]
        public ObjectId Relation { get; set; }
    }
}
