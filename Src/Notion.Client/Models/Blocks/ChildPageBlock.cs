using Newtonsoft.Json;

namespace Notion.Client
{
    public class ChildPageBlock : Block
    {
        public override BlockType Type => BlockType.ChildPage;

        [JsonProperty("child_page")]
        public Info ChildPage { get; set; }

        public class Info
        {
            public string Title { get; set; }
        }
    }
}