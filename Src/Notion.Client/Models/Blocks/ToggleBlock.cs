using System.Collections.Generic;

namespace Notion.Client
{
    public class ToggleBlock : Block
    {
        public override BlockType Type => BlockType.Toggle;

        public Info Toggle { get; set; }

        public class Info
        {
            public IEnumerable<RichTextBase> Text { get; set; }
            public IEnumerable<Block> Children { get; set; }
        }
    }
}
