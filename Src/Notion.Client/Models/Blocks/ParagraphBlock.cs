using System.Collections.Generic;

namespace Notion.Client
{
    public class ParagraphBlock : Block
    {
        public override BlockType Type => BlockType.Paragraph;

        public Info Paragraph { get; set; }

        public class Info
        {
            public IEnumerable<RichTextBase> Text { get; set; }
            public IEnumerable<Block> Children { get; set; }
        }
    }
}