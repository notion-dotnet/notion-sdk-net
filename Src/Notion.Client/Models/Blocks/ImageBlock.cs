using Newtonsoft.Json;

namespace Notion.Client
{
    public class ImageBlock : Block
    {
        public override BlockType Type => BlockType.Image;

        [JsonProperty("image")]
        public FileObject Image { get; set; }
    }
}
