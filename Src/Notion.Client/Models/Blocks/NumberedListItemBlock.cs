using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

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
            [JsonConverter(typeof(StringEnumConverter))]
            public Color? Color { get; set; }

            [JsonProperty("children")]
            public IEnumerable<INonColumnBlock> Children { get; set; }
        }
    }
}
