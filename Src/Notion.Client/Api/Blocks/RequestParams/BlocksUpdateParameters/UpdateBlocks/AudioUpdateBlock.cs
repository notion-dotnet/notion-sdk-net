using Newtonsoft.Json;

namespace Notion.Client
{
    public class AudioUpdateBlock : UpdateBlock, IUpdateBlock
    {
        [JsonProperty("audio")]
        public IFileObjectInput Audio { get; set; }
    }
}
