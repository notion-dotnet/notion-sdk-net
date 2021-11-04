using Newtonsoft.Json;

namespace Notion.Client
{
    public class DividerBlock : Block
    {
        public override BlockType Type => BlockType.Divider;

        [JsonProperty("divider")]
        public Data Divider { get; set; }

        public class Data
        {
        }
    }
}
