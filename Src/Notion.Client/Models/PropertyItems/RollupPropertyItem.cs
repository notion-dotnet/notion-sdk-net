using Newtonsoft.Json;

namespace Notion.Client
{
    public class RollupPropertyItem : ListPropertyItem
    {
        public override string Type => "rollup";

        [JsonProperty("rollup")]
        public RollupValue Rollup { get; set; }
    }
}
