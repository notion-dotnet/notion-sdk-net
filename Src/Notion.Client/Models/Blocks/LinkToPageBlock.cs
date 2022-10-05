using Newtonsoft.Json;

namespace Notion.Client
{
    public class LinkToPageBlock : Block, IColumnChildrenBlock, INonColumnBlock
    {
        [JsonProperty("link_to_page")]
        public IPageParent LinkToPage { get; set; }

        public override BlockType Type => BlockType.LinkToPage;
    }
}
