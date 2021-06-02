namespace Notion.Client
{
    public class BlocksRetrieveChildrenParameters : IBlocksRetrieveChildrenQueryParameters
    {
        public string StartCursor { get; set; }
        public string PageSize { get; set; }
    }
}
