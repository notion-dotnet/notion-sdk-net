using Newtonsoft.Json;

namespace Notion.Client
{
    public class NumberedListItemUpdateBlock : IUpdateBlock
    {
        [JsonProperty("numbered_list_item")]
        public TextContentUpdate NumberedListItem { get; set; }
    }
}
