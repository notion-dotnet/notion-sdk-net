using Newtonsoft.Json;

namespace Notion.Client
{
    public class AudioBlock : Block, IColumnChildrenBlock, INonColumnBlock
    {
        [JsonProperty("audio")]
        public FileObject Audio { get; set; }

        public override BlockType Type => BlockType.Audio;
    }
}
