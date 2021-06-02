using System.Collections.Generic;

namespace Notion.Client
{
    public class ParagraphBlock : BlockBase
    {
        public override BlockType Type => BlockType.Paragraph;

        public Info Paragraph { get; set; }

        public class Info
        {
            public IEnumerable<RichTextBase> Text { get; set; }
            public IEnumerable<BlockBase> Children { get; set; }
        }
    }
}