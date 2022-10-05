using Newtonsoft.Json;

namespace Notion.Client
{
    public class ChildDatabaseBlock : Block, IColumnChildrenBlock, INonColumnBlock
    {
        [JsonProperty("child_database")]
        public Info ChildDatabase { get; set; }

        public override BlockType Type => BlockType.ChildDatabase;

        public class Info
        {
            [JsonProperty("title")]
            public string Title { get; set; }
        }
    }
}
