using System.Collections.Generic;
using Newtonsoft.Json;

namespace Notion.Client
{
    public class BulletedListItemBlock : Block, IColumnChildrenBlock, INonColumnBlock
    {
        public override BlockType Type => BlockType.BulletedListItem;

        [JsonProperty("bulleted_list_item")]
        public Info BulletedListItem { get; set; }

        public class Info
        {
            [JsonProperty("rich_text")]
            public IEnumerable<RichTextBase> RichText { get; set; }

            [JsonProperty("children")]
            public IEnumerable<INonColumnBlock> Children { get; set; }
        }
    }
}
