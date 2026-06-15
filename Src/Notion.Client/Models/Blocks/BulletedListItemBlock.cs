using System.Collections.Generic;
using Newtonsoft.Json;

namespace Notion.Client
{
    public class BulletedListItemBlock : Block, IColumnChildrenBlock, INonColumnBlock
    {
        [JsonProperty("bulleted_list_item")]
        public Info BulletedListItem { get; set; }

        public override BlockType Type => BlockType.BulletedListItem;

        public class Info
        {
            [JsonProperty("rich_text")]
            public IEnumerable<RichTextBase> RichText { get; set; }

            [JsonProperty("color")]
            public Color? Color { get; set; }

            [JsonProperty("children")]
            public IEnumerable<INonColumnBlock> Children { get; set; }
        }
    }
}
