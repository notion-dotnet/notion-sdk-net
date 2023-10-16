using Newtonsoft.Json;

namespace Notion.Client
{
    public class LinkPreviewBlockRequest : BlockObjectRequest, IColumnChildrenBlockRequest, INonColumnBlockRequest
    {
        [JsonProperty("link_preview")]
        public Data LinkPreview { get; set; }

        public override BlockType Type => BlockType.LinkPreview;

        public class Data
        {
            [JsonProperty("url")]
            public string Url { get; set; }
        }
    }
}
