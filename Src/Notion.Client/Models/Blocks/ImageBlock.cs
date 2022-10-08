using Newtonsoft.Json;

namespace Notion.Client
{
    public class ImageBlock : Block, IColumnChildrenBlock, INonColumnBlock
    {
        [JsonProperty("image")]
        public FileObject Image { get; set; }

        public override BlockType Type => BlockType.Image;
    }
}
