using Newtonsoft.Json;

namespace Notion.Client
{
    public class EmbedUpdateBlock : UpdateBlock, IUpdateBlock
    {
        [JsonProperty("embed")]
        public Data Embed { get; set; }

        public class Data
        {
            [JsonProperty("url")]
            public string Url { get; set; }
        }
    }
}
