using System.Collections.Generic;
using Newtonsoft.Json;

namespace Notion.Client
{
    public class HeadingOneUpdateBlock : UpdateBlock, IUpdateBlock
    {
        [JsonProperty("heading_1")]
        public Info Heading_1 { get; set; }

        public class Info
        {
            [JsonProperty("rich_text")]
            public IEnumerable<RichTextBaseInput> RichText { get; set; }
        }
    }
}
