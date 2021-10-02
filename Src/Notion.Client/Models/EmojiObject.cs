using Newtonsoft.Json;

namespace Notion.Client
{
    public class EmojiObject : IPageIcon
    {
        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("emoji")]
        public string Emoji { get; set; }
    }
}
