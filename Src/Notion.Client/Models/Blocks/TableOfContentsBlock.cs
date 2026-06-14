using Newtonsoft.Json;

namespace Notion.Client
{
    public class TableOfContentsBlock : Block, IColumnChildrenBlock, INonColumnBlock
    {
        [JsonProperty("table_of_contents")]
        public Data TableOfContents { get; set; }

        public override BlockType Type => BlockType.TableOfContents;

        public class Data
        {
            [JsonProperty("color")]
            public Color? Color { get; set; }
        }
    }
}
