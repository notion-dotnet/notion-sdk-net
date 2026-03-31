namespace Notion.Client
{
    public class RetrieveCommentsRequest : IRetrieveCommentsQueryParameters
    {
        public string BlockId { get; set; }

        public string StartCursor { get; set; }

        public int? PageSize { get; set; }
    }
}
