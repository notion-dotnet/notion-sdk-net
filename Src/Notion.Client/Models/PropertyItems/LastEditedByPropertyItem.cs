using Newtonsoft.Json;

namespace Notion.Client
{
    public class LastEditedByPropertyItem : SimplePropertyItem
    {
        public override string Type => "last_edited_by";

        [JsonProperty("last_edited_by")]
        public User LastEditedBy { get; set; }
    }
}
