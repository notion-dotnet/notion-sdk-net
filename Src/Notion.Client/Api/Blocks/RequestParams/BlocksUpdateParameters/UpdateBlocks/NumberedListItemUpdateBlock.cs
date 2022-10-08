using System.Collections.Generic;
using Newtonsoft.Json;

namespace Notion.Client
{
    public class NumberedListItemUpdateBlock : UpdateBlock
    {
        [JsonProperty("numbered_list_item")]
        public Info NumberedListItem { get; set; }

        public class Info
        {
            [JsonProperty("rich_text")]
            public IEnumerable<RichTextBaseInput> RichText { get; set; }
        }
    }
}
