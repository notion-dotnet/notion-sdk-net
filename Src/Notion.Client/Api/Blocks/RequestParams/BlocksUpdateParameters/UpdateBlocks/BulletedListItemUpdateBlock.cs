using System.Collections.Generic;
using Newtonsoft.Json;

namespace Notion.Client
{
    public class BulletedListItemUpdateBlock : UpdateBlock
    {
        [JsonProperty("bulleted_list_item")]
        public Info BulletedListItem { get; set; }

        public class Info
        {
            [JsonProperty("rich_text")]
            public IEnumerable<RichTextBaseInput> RichText { get; set; }
        }
    }
}
