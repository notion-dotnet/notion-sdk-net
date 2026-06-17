using System.Collections.Generic;
using Newtonsoft.Json;

namespace Notion.Client
{
    public class NumberedListItemBlock : Block, IColumnChildrenBlock, INonColumnBlock
    {
        [JsonProperty("numbered_list_item")]
        public Info NumberedListItem { get; set; }

        public override BlockType Type => BlockType.NumberedListItem;

        public class Info
        {
            [JsonProperty("rich_text")]
            public IEnumerable<RichTextBase> RichText { get; set; }

            [JsonProperty("color")]
            public Color? Color { get; set; }

            [JsonProperty("children")]
            public IEnumerable<INonColumnBlock> Children { get; set; }

            [JsonProperty("list_start_index")]
            public int? ListStartIndex { get; set; }

            [JsonProperty("list_format")]
            public NumberedListFormat? ListFormat { get; set; }
        }
    }
}
