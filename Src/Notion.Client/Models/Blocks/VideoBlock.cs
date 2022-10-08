using Newtonsoft.Json;

namespace Notion.Client
{
    public class VideoBlock : Block, IColumnChildrenBlock, INonColumnBlock
    {
        [JsonProperty("video")]
        public FileObject Video { get; set; }

        public override BlockType Type => BlockType.Video;
    }
}
