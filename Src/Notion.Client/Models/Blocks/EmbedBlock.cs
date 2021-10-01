using Newtonsoft.Json;

namespace Notion.Client
{
    public class EmbedBlock : Block
    {
        public override BlockType Type => BlockType.Embed;

        [JsonProperty("embed")]
        public Info Embed { get; set; }

        public class Info
        {
            [JsonProperty("url")]
            public string Url { get; set; }
        }
    }
}
