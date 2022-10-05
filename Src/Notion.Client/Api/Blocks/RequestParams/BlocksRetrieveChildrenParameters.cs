namespace Notion.Client
{
    public class BlocksRetrieveChildrenParameters : IBlocksRetrieveChildrenQueryParameters
    {
        public string StartCursor { get; set; }

        public int? PageSize { get; set; }
    }
}
