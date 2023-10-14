namespace Notion.Client
{
    public class BlockRetrieveChildrenRequest :
        IBlockRetrieveChildrenQueryParameters,
        IBlockRetrieveChildrenPathParameters
    {
        public string StartCursor { get; set; }

        public int? PageSize { get; set; }

        public string BlockId { get; set; }
    }
}
