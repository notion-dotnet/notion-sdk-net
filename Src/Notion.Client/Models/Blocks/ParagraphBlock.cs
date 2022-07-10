using System.Collections.Generic;
using Newtonsoft.Json;

namespace Notion.Client
{
    public class ParagraphBlock : Block, IColumnChildrenBlock, INonColumnBlock
    {
        public override BlockType Type => BlockType.Paragraph;

        [JsonProperty("paragraph")]
        public Info Paragraph { get; set; }

        public class Info
        {
            [JsonProperty("rich_text")]
            public IEnumerable<RichTextBase> RichText { get; set; }

            [JsonProperty("children")]
            public IEnumerable<INonColumnBlock> Children { get; set; }
        }
    }
}
