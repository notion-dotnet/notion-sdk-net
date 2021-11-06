using Newtonsoft.Json;

namespace Notion.Client
{
    public class SelectPropertyItem : SimplePropertyItem
    {
        public override string Type => "select";

        [JsonProperty("select")]
        public SelectOption Select { get; set; }
    }
}
