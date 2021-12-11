using Newtonsoft.Json;

namespace Notion.Client
{
    public class ChildPageBlock : Block, IColumnChildrenBlock, INonColumnBlock
    {
        public override BlockType Type => BlockType.ChildPage;

        [JsonProperty("child_page")]
        public Info ChildPage { get; set; }

        public class Info
        {
            [JsonProperty("title")]
            public string Title { get; set; }
        }
    }
}
