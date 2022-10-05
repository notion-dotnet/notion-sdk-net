using Newtonsoft.Json;

namespace Notion.Client
{
    public class BlockParent : IPageParent, IDatabaseParent, IBlockParent, ICommentParent
    {
        /// <summary>
        ///     The ID of the block that the element belongs to.
        /// </summary>
        [JsonProperty("block_id")]
        public string BlockId { get; set; }

        /// <summary>
        ///     Always has a value "block_id"
        /// </summary>
        public ParentType Type { get; set; }
    }
}
