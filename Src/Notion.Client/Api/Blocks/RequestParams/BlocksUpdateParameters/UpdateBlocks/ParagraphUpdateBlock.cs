using Newtonsoft.Json;

namespace Notion.Client
{
    public class ParagraphUpdateBlock : UpdateBlock, IUpdateBlock
    {
        [JsonProperty("paragraph")]
        public TextContentUpdate Paragraph { get; set; }
    }
}
