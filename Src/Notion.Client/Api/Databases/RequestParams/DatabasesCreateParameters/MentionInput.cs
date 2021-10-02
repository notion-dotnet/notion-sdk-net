using Newtonsoft.Json;

namespace Notion.Client
{
    public class MentionInput
    {
        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("user")]
        public Person User { get; set; }

        [JsonProperty("page")]
        public ObjectId Page { get; set; }

        [JsonProperty("database")]
        public ObjectId Database { get; set; }

        [JsonProperty("date")]
        public DatePropertyValue Date { get; set; }
    }
}
