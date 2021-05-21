using Newtonsoft.Json;

namespace Notion.Client
{
    public class User
    {
        public string Object => "user";
        public string Id { get; set; }
        public string Type { get; set; }
        public string Name { get; set; }

        [JsonProperty("avatar_url")]
        public string AvatarUrl { get; set; }

        public Person Person { get; set; }
        public Bot Bot { get; set; }
    }

    public class Person
    {
        public string Email { get; set; }
    }

    public class Bot
    {

    }
}
