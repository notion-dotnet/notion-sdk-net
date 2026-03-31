namespace Notion.Client
{
    public class ListDataSourceTemplatesRequest : IListDataSourceTemplatesPathParameters, IListDataSourceTemplatesQueryParameters
    {
        public string DataSourceId { get; set; }
        public string Name { get; set; }
        public string StartCursor { get; set; }
        public int? PageSize { get; set; }
    }
}
