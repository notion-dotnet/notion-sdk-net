using Newtonsoft.Json;

namespace Notion.Client
{
    public class StatusPropertyItem : SimplePropertyItem
    {
        public override string Type => "status";

        [JsonProperty("status")]
        public SelectOption Status { get; set; }
    }
}
