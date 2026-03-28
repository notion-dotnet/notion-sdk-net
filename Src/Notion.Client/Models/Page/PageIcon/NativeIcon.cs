using Newtonsoft.Json;

namespace Notion.Client
{
    public class NativeIcon
    {
        [JsonProperty("color")]
        public string Color { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }
    }

    public class NativeIconObject : IPageIcon
    {
        [JsonProperty("icon")]
        public NativeIcon Icon { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }
    }
}
