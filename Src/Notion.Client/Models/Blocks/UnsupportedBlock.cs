using Newtonsoft.Json;

namespace Notion.Client
{
    public class UnsupportedBlock : Block, IColumnChildrenBlock, INonColumnBlock
    {
        public override BlockType Type => BlockType.Unsupported;

        [JsonProperty("unsupported")]
        public UnsupportedBlockResponse Unsupported { get; set; }
    }

    public class UnsupportedBlockResponse
    {
        [JsonProperty("block_type")]
        public string BlockType { get; set; }
    }
}
