using Newtonsoft.Json;

namespace Notion.Client
{
    public class CustomEmojiObject : IPageIcon
    {
        [JsonProperty("custom_emoji")]
        public CustomEmoji CustomEmoji { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }
    }
}
