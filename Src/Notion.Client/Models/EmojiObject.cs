using Newtonsoft.Json;

namespace Notion.Client
{
    public class EmojiObject : IPageIcon
    {
        [JsonProperty("emoji")]
        public string Emoji { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }
    }
}
