using Newtonsoft.Json;

namespace Notion.Client
{
    public class EmbedUpdateBlock : UpdateBlock
    {
        [JsonProperty("embed")]
        public Info Embed { get; set; }

        public class Info
        {
            [JsonProperty("url")]
            public string Url { get; set; }
        }
    }
}
