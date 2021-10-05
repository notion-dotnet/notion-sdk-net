using Newtonsoft.Json;

namespace Notion.Client
{
    public class HeadingThreeeUpdateBlock : IUpdateBlock
    {
        [JsonProperty("heading_3")]
        public TextContentUpdate Heading_3 { get; set; }
    }
}
