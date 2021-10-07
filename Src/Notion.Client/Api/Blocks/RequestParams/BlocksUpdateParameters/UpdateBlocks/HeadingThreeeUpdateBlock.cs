using Newtonsoft.Json;

namespace Notion.Client
{
    public class HeadingThreeeUpdateBlock : UpdateBlock, IUpdateBlock
    {
        [JsonProperty("heading_3")]
        public TextContentUpdate Heading_3 { get; set; }
    }
}
