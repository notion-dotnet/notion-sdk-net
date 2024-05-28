using Newtonsoft.Json;

namespace Notion.Client
{
    public class ChildDatabaseBlockRequest : BlockObjectRequest, IColumnChildrenBlockRequest, INonColumnBlockRequest
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
