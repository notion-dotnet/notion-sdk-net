using Newtonsoft.Json;

namespace Notion.Client
{
    public class AudioBlock : Block
    {
        public override BlockType Type => BlockType.Audio;

        [JsonProperty("audio")]
        public FileObject Audio { get; set; }
    }
}
