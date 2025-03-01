using Newtonsoft.Json;

namespace Notion.Client
{
    public class CustomEmojiObject : IPageIcon
    {
        [JsonProperty("type")]
        public virtual string Type { get; set; }
        
        [JsonProperty("custom_emoji")]
        public Info Emoji { get; set; }

        public class Info
        {
            [JsonProperty("id")]
            public string Id { get; set; }

            [JsonProperty("name")]
            public string Name { get; set; }

            [JsonProperty("url")]
            public string Url { get; set; }
        }
    }
}
