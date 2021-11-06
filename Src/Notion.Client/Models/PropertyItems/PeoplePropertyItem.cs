using Newtonsoft.Json;

namespace Notion.Client
{
    public class PeoplePropertyItem : SimplePropertyItem
    {
        public override string Type => "people";

        [JsonProperty("people")]
        public User People { get; set; }
    }
}
