using System.Collections.Generic;
using Newtonsoft.Json;

namespace Notion.Client
{
    public class NumberedListItemBlock : BlockBase
    {
        public override BlockType Type => BlockType.NumberedListItem;

        [JsonProperty("numbered_list_item")]
        public Info NumberedListItem { get; set; }

        public class Info
        {
            public IEnumerable<RichTextBase> Text { get; set; }
            public IEnumerable<BlockBase> Children { get; set; }
        }
    }
}