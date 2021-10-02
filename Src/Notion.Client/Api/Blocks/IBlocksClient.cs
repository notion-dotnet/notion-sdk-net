using System.Threading.Tasks;

namespace Notion.Client
{
    public interface IBlocksClient
    {
        /// <summary>
        /// Retrieves a Block object using the ID specified.
        /// </summary>
        /// <param name="blockId"></param>
        /// <returns>Block</returns>
        Task<Block> RetrieveAsync(string blockId);

        /// <summary>
        /// Updates the content for the specified block_id based on the block type.
        /// </summary>
        /// <param name="blockId"></param>
        /// <param name="updateBlock"></param>
        /// <returns>Block</returns>
        Task<Block> UpdateAsync(string blockId, IUpdateBlock updateBlock);

        Task<PaginatedList<Block>> RetrieveChildrenAsync(string blockId, BlocksRetrieveChildrenParameters parameters = null);

        /// <summary>
        /// Creates and appends new children blocks to the parent block_id specified.
        /// </summary>
        /// <param name="blockId">Identifier for a block</param>
        /// <param name="parameters"></param>
        /// <returns>A paginated list of newly created first level children block objects.</returns>
        Task<PaginatedList<Block>> AppendChildrenAsync(string blockId, BlocksAppendChildrenParameters parameters = null);

        /// <summary>
        /// Sets a Block object, including page blocks, to archived: true using the ID specified.
        /// </summary>
        /// <param name="blockId">Identifier for a Notion block</param>
        Task DeleteAsync(string blockId);
    }
}
