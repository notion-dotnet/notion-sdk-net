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
            [JsonProperty("text")]
            public IEnumerable<RichTextBase> Text { get; set; }

            [JsonProperty("children")]
            public IEnumerable<INonColumnBlock> Children { get; set; }
        }
    }
}
