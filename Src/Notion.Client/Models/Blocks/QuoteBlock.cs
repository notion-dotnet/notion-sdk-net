using System.Collections.Generic;
using Newtonsoft.Json;

namespace Notion.Client
{
    public class QuoteBlock : Block, IColumnChildrenBlock, INonColumnBlock
    {
        [JsonProperty("quote")]
        public Info Quote { get; set; }

        public override BlockType Type => BlockType.Quote;

        public class Info
        {
            [JsonProperty("rich_text")]
            public IEnumerable<RichTextBase> RichText { get; set; }

            [JsonProperty("color")]
            public Color? Color { get; set; }

            [JsonProperty("children")]
            public IEnumerable<INonColumnBlock> Children { get; set; }
        }
    }
}
