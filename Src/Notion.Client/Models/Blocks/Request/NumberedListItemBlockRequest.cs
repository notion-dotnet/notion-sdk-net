using System.Collections.Generic;
using Newtonsoft.Json;

namespace Notion.Client
{
    public class NumberedListItemBlockRequest : BlockObjectRequest, IColumnChildrenBlockRequest, INonColumnBlockRequest
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
            public IEnumerable<INonColumnBlockRequest> Children { get; set; }
        }
    }
}
