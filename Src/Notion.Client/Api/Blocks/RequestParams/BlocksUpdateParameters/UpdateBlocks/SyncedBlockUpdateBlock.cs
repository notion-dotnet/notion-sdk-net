using Newtonsoft.Json;

namespace Notion.Client
{
    public class SyncedBlockUpdateBlock : UpdateBlock, IUpdateBlock
    {
        [JsonProperty("synced_block")]
        public Data SyncedBlock { get; set; }

        public class Data
        {
            [JsonProperty("synced_from")]
            public SyncedFromBlockId SyncedFrom { get; set; }

            public class SyncedFromBlockId
            {
                [JsonProperty("block_id")]
                public string BlockId { get; set; }
            }
        }
    }
}
