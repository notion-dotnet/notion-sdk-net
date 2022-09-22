using Newtonsoft.Json;

namespace Notion.Client
{
    public class LinkPreviewBlock : Block, IColumnChildrenBlock, INonColumnBlock
    {
        public override BlockType Type => BlockType.LinkPreview;

        [JsonProperty("archived")]
        public bool Archived { get; set; }

        public class Info {
            [JsonProperty("url")]
            public string Url { get; set; }
        }
    }
}
