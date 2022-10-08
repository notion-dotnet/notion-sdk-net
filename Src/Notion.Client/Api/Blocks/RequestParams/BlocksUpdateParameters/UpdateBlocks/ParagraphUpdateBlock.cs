using System.Collections.Generic;
using Newtonsoft.Json;

namespace Notion.Client
{
    public class ParagraphUpdateBlock : UpdateBlock
    {
        [JsonProperty("paragraph")]
        public Info Paragraph { get; set; }

        public class Info
        {
            [JsonProperty("rich_text")]
            public IEnumerable<RichTextBaseInput> RichText { get; set; }
        }
    }
}
