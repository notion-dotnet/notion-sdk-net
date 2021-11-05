using Newtonsoft.Json;

namespace Notion.Client
{
    public class EmailPropertyItem : SimplePropertyItem
    {
        public override string Type => "email";

        [JsonProperty("email")]
        public string Email { get; set; }
    }
}
