using Newtonsoft.Json;

namespace Notion.Client
{
    public class AudioBlockRequest : BlockObjectRequest, IColumnChildrenBlockRequest, INonColumnBlockRequest
    {
        [JsonProperty("audio")]
        public FileObject Audio { get; set; }

        public override BlockType Type => BlockType.Audio;
    }
}
