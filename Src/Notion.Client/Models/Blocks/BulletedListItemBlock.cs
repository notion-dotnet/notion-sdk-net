using System.Collections.Generic;
using Newtonsoft.Json;

namespace Notion.Client
{
    public class BulletedListItemBlock : Block
    {
        public override BlockType Type => BlockType.BulletedListItem;

        [JsonProperty("bulleted_list_item")]
        public Info BulletedListItem { get; set; }

        public class Info
        {
            public IEnumerable<RichTextBase> Text { get; set; }
            public IEnumerable<Block> Children { get; set; }
        }
    }
}
