using Newtonsoft.Json;

namespace Notion.Client
{
    public class VideoUpdateBlock : UpdateBlock, IUpdateBlock
    {
        [JsonProperty("video")]
        public IFileObjectInput Video { get; set; }
    }
}
