namespace Notion.Client
{
    public class GetViewQueryResultsRequest
    {
        public string ViewId { get; set; }
        public string QueryId { get; set; }
        public string StartCursor { get; set; }
        public int? PageSize { get; set; }
    }
}
