using Newtonsoft.Json;

namespace Notion.Client
{
    public class RelationDataSourcePropertyConfig : DataSourcePropertyConfig
    {
        public override string Type => DataSourcePropertyTypes.Relation;

        [JsonProperty("relation")]
        public RelationInfo Relation { get; set; }
    }
}
