namespace Notion.Client
{
    public interface IQueryDataSourcePathParameters
    {
        /// <summary>
        /// The ID of the data source to query.
        /// </summary>
        string DataSourceId { get; set; }
    }
}
