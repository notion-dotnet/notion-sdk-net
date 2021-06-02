using System.Collections.Generic;

namespace Notion.Client
{
    public class ToggleBlock : BlockBase
    {
        public override BlockType Type => BlockType.Toggle;

        public Info Toggle { get; set; }

        public class Info
        {
            public IEnumerable<RichTextBase> Text { get; set; }
            public IEnumerable<BlockBase> Children { get; set; }
        }
    }
}