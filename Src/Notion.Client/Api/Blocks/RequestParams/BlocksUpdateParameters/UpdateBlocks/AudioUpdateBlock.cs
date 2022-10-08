using Newtonsoft.Json;

namespace Notion.Client
{
    public class AudioUpdateBlock : UpdateBlock
    {
        [JsonProperty("audio")]
        public IFileObjectInput Audio { get; set; }
    }
}
