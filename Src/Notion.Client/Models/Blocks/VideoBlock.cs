using Newtonsoft.Json;

namespace Notion.Client
{
    public class VideoBlock : Block, IColumnChildrenBlock, INonColumnBlock
    {
        public override BlockType Type => BlockType.Video;

        [JsonProperty("video")]
        public FileObject Video { get; set; }
    }
}
