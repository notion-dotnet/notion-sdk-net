using Newtonsoft.Json;

namespace Notion.Client
{
    public class ImageUpdateBlock : UpdateBlock
    {
        [JsonProperty("image")]
        public IFileObjectInput Image { get; set; }
    }
}
