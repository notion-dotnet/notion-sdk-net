using Newtonsoft.Json;

namespace Notion.Client
{
    public class ToggleUpdateBlock : IUpdateBlock
    {
        [JsonProperty("toggle")]
        public TextContentUpdate Toggle { get; set; }
    }
}
