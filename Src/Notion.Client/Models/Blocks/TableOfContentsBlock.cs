using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

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
            [JsonConverter(typeof(StringEnumConverter))]
            public Color? Color { get; set; }
        }
    }
}
