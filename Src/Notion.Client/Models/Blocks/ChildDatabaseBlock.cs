using Newtonsoft.Json;

namespace Notion.Client
{
    public class ChildDatabaseBlock : Block
    {
        public override BlockType Type => BlockType.ChildDatabase;

        [JsonProperty("child_database")]
        public Info ChildDatabase { get; set; }

        public class Info
        {
            [JsonProperty("title")]
            public string Title { get; set; }
        }
    }
}
