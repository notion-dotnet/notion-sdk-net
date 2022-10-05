using Newtonsoft.Json;

namespace Notion.Client
{
    public class User : IObject
    {
        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("avatar_url")]
        public string AvatarUrl { get; set; }

        [JsonProperty("person")]
        public Person Person { get; set; }

        [JsonProperty("bot")]
        public Bot Bot { get; set; }

        public ObjectType Object => ObjectType.User;

        public string Id { get; set; }
    }
}
