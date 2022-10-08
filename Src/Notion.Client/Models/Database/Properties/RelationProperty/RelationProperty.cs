using Newtonsoft.Json;

namespace Notion.Client
{
    public class RelationProperty : Property
    {
        public override PropertyType Type => PropertyType.Relation;

        [JsonProperty("relation")]
        public RelationData Relation { get; set; }
    }
}
