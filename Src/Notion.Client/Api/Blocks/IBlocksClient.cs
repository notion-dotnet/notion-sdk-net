using System.Threading.Tasks;

namespace Notion.Client
{
    public interface IBlocksClient
    {
        Task<PaginatedList<Block>> RetrieveChildrenAsync(string blockId, BlocksRetrieveChildrenParameters parameters = null);
        Task<Block> AppendChildrenAsync(string blockId, BlocksAppendChildrenParameters parameters = null);
    }
}
