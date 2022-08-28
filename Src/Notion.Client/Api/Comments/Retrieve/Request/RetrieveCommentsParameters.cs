namespace Notion.Client
{
    public class RetrieveCommentsParameters : IRetrieveCommentsQueryParameters
    {
        public string BlockId { get; set; }
        public string StartCursor { get; set; }
        public int? PageSize { get; set; }
    }
}
