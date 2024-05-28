using Newtonsoft.Json;

namespace Notion.Client
{
    public class ImageBlockRequest : BlockObjectRequest, IColumnChildrenBlockRequest, INonColumnBlockRequest
    {
        [JsonProperty("image")]
        public FileObject Image { get; set; }

        public override BlockType Type => BlockType.Image;
    }
}
