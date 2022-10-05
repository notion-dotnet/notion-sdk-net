using Newtonsoft.Json;

namespace Notion.Client
{
    public class DividerBlock : Block, IColumnChildrenBlock, INonColumnBlock
    {
        [JsonProperty("divider")]
        public Data Divider { get; set; }

        public override BlockType Type => BlockType.Divider;

        public class Data
        {
        }
    }
}
