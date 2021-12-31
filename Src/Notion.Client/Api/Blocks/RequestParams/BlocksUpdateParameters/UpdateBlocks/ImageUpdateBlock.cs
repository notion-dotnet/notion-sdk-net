using Newtonsoft.Json;

namespace Notion.Client
{
    public class ImageUpdateBlock : UpdateBlock, IUpdateBlock
    {
        [JsonProperty("image")]
        public IFileObjectInput Image { get; set; }
    }
}
