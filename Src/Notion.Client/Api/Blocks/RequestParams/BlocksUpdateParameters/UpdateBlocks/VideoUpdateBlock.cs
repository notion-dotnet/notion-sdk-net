using Newtonsoft.Json;

namespace Notion.Client
{
    public class VideoUpdateBlock : UpdateBlock
    {
        [JsonProperty("video")]
        public IFileObjectInput Video { get; set; }
    }
}
