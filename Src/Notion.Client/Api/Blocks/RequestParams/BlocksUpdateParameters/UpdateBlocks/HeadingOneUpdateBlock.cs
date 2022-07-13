using Newtonsoft.Json;

namespace Notion.Client
{
    public class HeadingOneUpdateBlock : UpdateBlock, IUpdateBlock
    {
        [JsonProperty("heading_1")]
        public TextContentUpdate Heading_1 { get; set; }
    }
}
