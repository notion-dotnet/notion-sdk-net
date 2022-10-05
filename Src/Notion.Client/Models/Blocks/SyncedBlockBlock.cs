using System.Collections.Generic;
using Newtonsoft.Json;

namespace Notion.Client
{
    public class SyncedBlockBlock : Block, IColumnChildrenBlock, INonColumnBlock
    {
        [JsonProperty("synced_block")]
        public Data SyncedBlock { get; set; }

        public override BlockType Type => BlockType.SyncedBlock;

        public class Data
        {
            [JsonProperty("synced_from")]
            public SyncedFromBlockId SyncedFrom { get; set; }

            [JsonProperty("children")]
            public IEnumerable<ISyncedBlockChildren> Children { get; set; }

            public class SyncedFromBlockId
            {
                [JsonProperty("type")]
                public string Type { get; set; }

                [JsonProperty("block_id")]
                public string BlockId { get; set; }
            }
        }
    }
}
