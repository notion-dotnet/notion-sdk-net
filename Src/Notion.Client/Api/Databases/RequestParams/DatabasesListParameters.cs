namespace Notion.Client
{
    public class DatabasesListParameters : IDatabasesListQueryParmaters
    {
        public string StartCursor { get; set; }

        public int? PageSize { get; set; }
    }
}
