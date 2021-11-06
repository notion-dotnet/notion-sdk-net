using Newtonsoft.Json;

namespace Notion.Client
{
    public class TableOfContentsBlock : Block
    {
        public override BlockType Type => BlockType.TableOfContents;

        [JsonProperty("table_of_contents")]
        public Data TableOfContents { get; set; }

        public class Data
        {
        }
    }
}
