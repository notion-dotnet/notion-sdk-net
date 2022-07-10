using System.Collections.Generic;
using Newtonsoft.Json;

namespace Notion.Client
{
    public class HeadingTwoBlock : Block, IColumnChildrenBlock, INonColumnBlock
    {
        public override BlockType Type => BlockType.Heading_2;

        [JsonProperty("heading_2")]
        public Info Heading_2 { get; set; }

        public override bool HasChildren => false;

        public class Info
        {
            [JsonProperty("rich_text")]
            public IEnumerable<RichTextBase> RichText { get; set; }
        }
    }
}
