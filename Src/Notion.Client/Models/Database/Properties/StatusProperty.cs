using Newtonsoft.Json;

namespace Notion.Client
{
    public class StatusProperty : Property
    {
        public override PropertyType Type => PropertyType.Status;

        [JsonProperty("status")]
        public StatusConfig Status { get; set; }
    }
}
