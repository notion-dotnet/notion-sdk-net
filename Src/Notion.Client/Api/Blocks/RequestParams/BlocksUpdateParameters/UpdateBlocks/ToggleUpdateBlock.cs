using Newtonsoft.Json;

namespace Notion.Client
{
    public class ToggleUpdateBlock : UpdateBlock, IUpdateBlock
    {
        [JsonProperty("toggle")]
        public TextContentUpdate Toggle { get; set; }
    }
}
