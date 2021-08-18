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

        Task<Block> UpdateAsync(string blockId, IUpdateBlock updateBlock);

        Task<PaginatedList<Block>> RetrieveChildrenAsync(string blockId, BlocksRetrieveChildrenParameters parameters = null);
        Task<Block> AppendChildrenAsync(string blockId, BlocksAppendChildrenParameters parameters = null);
    }
}
