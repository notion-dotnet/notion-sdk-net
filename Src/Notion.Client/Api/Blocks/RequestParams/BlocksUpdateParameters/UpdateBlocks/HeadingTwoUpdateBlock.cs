using System.Collections.Generic;
using Newtonsoft.Json;

namespace Notion.Client
{
    public class HeadingTwoUpdateBlock : UpdateBlock, IUpdateBlock
    {
        [JsonProperty("heading_2")]
        public Info Heading_2 { get; set; }

        public class Info
        {
            [JsonProperty("rich_text")]
            public IEnumerable<RichTextBaseInput> RichText { get; set; }
        }
    }
}
