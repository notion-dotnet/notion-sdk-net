using Newtonsoft.Json;

namespace Notion.Client
{
    public class LinkToPageUpdateBlock : UpdateBlock
    {
        [JsonProperty("link_to_page")]
        public IPageParentInput LinkToPage { get; set; }
    }
}
