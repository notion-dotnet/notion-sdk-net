using Newtonsoft.Json;

namespace Notion.Client
{
    public class Bot
    {
        [JsonProperty("owner")]
        public IBotOwner Owner { get; set; }
    }
}
