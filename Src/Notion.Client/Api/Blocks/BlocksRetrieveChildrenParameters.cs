namespace Notion.Client
{
    public interface IBlocksRetrieveChildrenQueryParameters : IPaginationParameters
    {
    }

    public class BlocksRetrieveChildrenParameters : IBlocksRetrieveChildrenQueryParameters
    {
        public string StartCursor { get; set; }
        public string PageSize { get; set; }
    }
}