using Newtonsoft.Json;

namespace Notion.Client
{
    public class BulletedListItemUpdateBlock : UpdateBlock, IUpdateBlock
    {
        [JsonProperty("bulleted_list_item")]
        public TextContentUpdate BulletedListItem { get; set; }
    }
}
