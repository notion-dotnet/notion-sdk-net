using Newtonsoft.Json;

namespace Notion.Client
{
    public class LinkToPageBlockRequest : BlockObjectRequest, IColumnChildrenBlockRequest, INonColumnBlockRequest
    {
        [JsonProperty("link_to_page")]
        public ILinkToPage LinkToPage { get; set; }

        public override BlockType Type => BlockType.LinkToPage;
    }
}
