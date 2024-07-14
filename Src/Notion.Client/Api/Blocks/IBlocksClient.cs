using System.Threading;
using System.Threading.Tasks;

namespace Notion.Client
{
    public interface IBlocksClient
    {
        /// <summary>
        ///     Retrieves a Block object using the ID specified.
        /// </summary>
        /// <param name="blockId"></param>
        /// <returns>Block</returns>
        Task<IBlock> RetrieveAsync(string blockId, CancellationToken cancellationToken = default);

        /// <summary>
        ///     Updates the content for the specified block_id based on the block type.
        /// </summary>
        /// <param name="blockId"></param>
        /// <param name="updateBlock"></param>
        /// <returns>Block</returns>
        Task<IBlock> UpdateAsync(string blockId, IUpdateBlock updateBlock,
            CancellationToken cancellationToken = default);

        /// <summary>
        ///     Returns a paginated array of child block objects contained in the block using the ID specified.
        ///     <br/>
        ///     In order to receive a complete representation of a block, you may need to recursively retrieve the
        ///     block children of child blocks.
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<RetrieveChildrenResponse> RetrieveChildrenAsync(
            BlockRetrieveChildrenRequest request,
            CancellationToken cancellationToken = default
        );

        /// <summary>
        ///     Creates and appends new children blocks to the parent block_id specified.
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns>A paginated list of newly created first level children block objects.</returns>
        Task<AppendChildrenResponse> AppendChildrenAsync(
            BlockAppendChildrenRequest request,
            CancellationToken cancellationToken = default
        );

        /// <summary>
        ///     Moves a Block object, including page blocks, to the trash: true using the ID specified.
        /// </summary>
        /// <param name="blockId">Identifier for a Notion block</param>
        Task DeleteAsync(string blockId, CancellationToken cancellationToken = default);
    }
}
