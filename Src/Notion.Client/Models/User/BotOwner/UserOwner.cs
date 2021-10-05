using Newtonsoft.Json;

namespace Notion.Client
{
    public class UserOwner : IBotOwner
    {
        public string Type { get; set; }

        [JsonProperty("user")]
        public User User { get; set; }
    }
}
