using Newtonsoft.Json;

namespace Notion.Client
{
    public class UniqueIdPropertyItem : SimplePropertyItem
    {
        public override string Type => "unique_id";

        [JsonProperty("unique_id")]
        public UniqueIdValue UniqueId { get; set; }
    }
}
