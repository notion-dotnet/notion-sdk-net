using Newtonsoft.Json;

namespace Notion.Client
{
    public class Person
    {
        [JsonProperty("email")]
        public string Email { get; set; }
    }
}
