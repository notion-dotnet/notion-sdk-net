using Newtonsoft.Json;

namespace Notion.Client
{
    public class LinkToPageBlock : Block, IColumnChildrenBlock, INonColumnBlock
    {
        public override BlockType Type => BlockType.LinkToPage;

        [JsonProperty("link_to_page")]
        public IPageParent LinkToPage { get; set; }
    }
}
