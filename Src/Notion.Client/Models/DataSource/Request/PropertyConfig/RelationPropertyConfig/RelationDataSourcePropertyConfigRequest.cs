using Newtonsoft.Json;

namespace Notion.Client
{
    public class RelationDataSourcePropertyConfigRequest : DataSourcePropertyConfigRequest
    {
        [JsonProperty("type")]
        public override string Type => "relation";

        [JsonProperty("relation")]
        public IRelationInfoRequest Relation { get; set; }
    }
}
