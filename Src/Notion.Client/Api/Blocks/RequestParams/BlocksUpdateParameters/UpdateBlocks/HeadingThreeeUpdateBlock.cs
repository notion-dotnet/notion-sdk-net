using System.Collections.Generic;
using Newtonsoft.Json;

namespace Notion.Client
{
    public class HeadingThreeeUpdateBlock : UpdateBlock, IUpdateBlock
    {
        [JsonProperty("heading_3")]
        public Info Heading_3 { get; set; }

        public class Info
        {
            [JsonProperty("rich_text")]
            public IEnumerable<RichTextBaseInput> RichText { get; set; }
        }
    }
}
