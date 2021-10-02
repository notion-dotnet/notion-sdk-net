using Newtonsoft.Json;

namespace Notion.Client
{
    public class ParagraphUpdateBlock : IUpdateBlock
    {
        [JsonProperty("paragraph")]
        public TextContentUpdate Paragraph { get; set; }
    }
}
