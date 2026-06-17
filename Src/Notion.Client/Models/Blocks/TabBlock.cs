using Newtonsoft.Json;

namespace Notion.Client
{
    public class TabBlock : Block, IColumnChildrenBlock, INonColumnBlock
    {
        public override BlockType Type => BlockType.Tab;

        [JsonProperty("tab")]
        public Data Tab { get; set; }

        public class Data
        {
        }
    }
}
