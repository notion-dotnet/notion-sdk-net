using System.Collections.Generic;
using Newtonsoft.Json;

namespace Notion.Client
{
    public class QuoteBlock : Block
    {
        public override BlockType Type => BlockType.Quote;

        [JsonProperty("quote")]
        public Info Quote { get; set; }

        public class Info
        {
            [JsonProperty("text")]
            public IEnumerable<RichTextBaseInput> Text { get; set; }

            [JsonProperty("children")]
            public IEnumerable<Block> Children { get; set; }
        }
    }
}
