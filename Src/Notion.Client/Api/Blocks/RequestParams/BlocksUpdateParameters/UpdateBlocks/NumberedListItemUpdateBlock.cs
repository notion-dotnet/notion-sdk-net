using Newtonsoft.Json;

namespace Notion.Client
{
    public class NumberedListItemUpdateBlock : UpdateBlock, IUpdateBlock
    {
        [JsonProperty("numbered_list_item")]
        public TextContentUpdate NumberedListItem { get; set; }
    }
}
