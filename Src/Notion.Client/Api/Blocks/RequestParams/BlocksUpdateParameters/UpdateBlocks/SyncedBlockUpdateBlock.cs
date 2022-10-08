using Newtonsoft.Json;

namespace Notion.Client
{
    public class SyncedBlockUpdateBlock : UpdateBlock
    {
        [JsonProperty("synced_block")]
        public Info SyncedBlock { get; set; }

        public class Info
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
