using Newtonsoft.Json;

namespace Notion.Client
{
    public class LinkPreviewBlock : Block, IColumnChildrenBlock, INonColumnBlock
    {
        public override BlockType Type => BlockType.LinkPreview;

        [JsonProperty("link_preview")] public Data LinkPreview { get; set; }

        public class Data
        {
            [JsonProperty("url")] public string Url { get; set; }
        }
    }
}
