using Newtonsoft.Json;

namespace Notion.Client
{
    public class TableOfContentsBlock : Block, IColumnChildrenBlock, INonColumnBlock
    {
        public override BlockType Type => BlockType.TableOfContents;

        [JsonProperty("table_of_contents")]
        public Data TableOfContents { get; set; }

        public class Data
        {
        }
    }
}
