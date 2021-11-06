using Newtonsoft.Json;

namespace Notion.Client
{
    public class CreatedByPropertyItem : SimplePropertyItem
    {
        public override string Type => "created_by";

        [JsonProperty("created_by")]
        public User CreatedBy { get; set; }
    }
}
