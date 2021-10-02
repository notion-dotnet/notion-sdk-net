using System.Collections.Generic;
using Newtonsoft.Json;

namespace Notion.Client
{
    public class NumberedListItemBlock : Block
    {
        public override BlockType Type => BlockType.NumberedListItem;

        [JsonProperty("numbered_list_item")]
        public Info NumberedListItem { get; set; }

        public class Info
        {
            [JsonProperty("text")]
            public IEnumerable<RichTextBase> Text { get; set; }

            [JsonProperty("children")]
            public IEnumerable<Block> Children { get; set; }
        }
    }
}
