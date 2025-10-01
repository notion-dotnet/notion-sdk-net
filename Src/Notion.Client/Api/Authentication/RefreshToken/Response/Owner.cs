using Newtonsoft.Json;

namespace Notion.Client
{
    public class Owner
    {
        [JsonProperty("workspace")]
        public bool Workspace { get; set; }
    }
}
