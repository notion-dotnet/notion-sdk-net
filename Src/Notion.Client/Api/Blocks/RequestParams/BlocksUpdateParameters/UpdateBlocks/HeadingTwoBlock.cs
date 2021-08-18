using Newtonsoft.Json;

namespace Notion.Client
{
    public class HeadingTwoUpdateBlock : IUpdateBlock
    {
        [JsonProperty("heading_2")]
        public TextContentUpdate Heading_2 { get; set; }
    }
}
