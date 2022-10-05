using Newtonsoft.Json;

namespace Notion.Client
{
    public class UserOwner : IBotOwner
    {
        [JsonProperty("user")]
        public User User { get; set; }

        public string Type { get; set; }
    }
}
