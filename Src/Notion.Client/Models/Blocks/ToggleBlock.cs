using System.Collections.Generic;
using Newtonsoft.Json;

namespace Notion.Client
{
    public class ToggleBlock : Block
    {
        public override BlockType Type => BlockType.Toggle;

        [JsonProperty("toggle")]
        public Info Toggle { get; set; }

        public class Info
        {
            [JsonProperty("text")]
            public IEnumerable<RichTextBase> Text { get; set; }

            [JsonProperty("children")]
            public IEnumerable<Block> Children { get; set; }
        }
    }
}
