namespace Notion.Client
{
    public class DatabasesListParameters : IDatabasesListQueryParmaters
    {
        public string StartCursor { get; set; }
        public string PageSize { get; set; }
    }
}
