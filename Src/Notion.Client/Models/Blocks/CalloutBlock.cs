using System.Collections.Generic;
using Newtonsoft.Json;

namespace Notion.Client
{
    public class CalloutBlock : Block, IColumnChildrenBlock, INonColumnBlock
    {
        public override BlockType Type => BlockType.Callout;

        [JsonProperty("callout")]
        public Info Callout { get; set; }

        public class Info
        {
            [JsonProperty("text")]
            public IEnumerable<RichTextBase> Text { get; set; }

            [JsonProperty("icon")]
            public IPageIcon Icon { get; set; }

            [JsonProperty("children")]
            public IEnumerable<INonColumnBlock> Children { get; set; }
        }
    }
}
