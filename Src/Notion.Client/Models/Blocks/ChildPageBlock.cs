using Newtonsoft.Json;

namespace Notion.Client
{
    public class ChildPageBlock : Block, IColumnChildrenBlock, INonColumnBlock
    {
        [JsonProperty("child_page")]
        public Info ChildPage { get; set; }

        public override BlockType Type => BlockType.ChildPage;

        public class Info
        {
            [JsonProperty("title")]
            public string Title { get; set; }
        }
    }
}
