namespace Notion.Client
{
    public class ListViewsRequest
    {
        public string DatabaseId { get; set; }
        public string DataSourceId { get; set; }
        public string StartCursor { get; set; }
        public int? PageSize { get; set; }
    }
}
