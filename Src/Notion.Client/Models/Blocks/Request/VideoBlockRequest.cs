using Newtonsoft.Json;

namespace Notion.Client
{
    public class VideoBlockRequest : BlockObjectRequest, IColumnChildrenBlockRequest, INonColumnBlockRequest
    {
        [JsonProperty("video")]
        public FileObject Video { get; set; }

        public override BlockType Type => BlockType.Video;
    }
}
