namespace Notion.Client
{
    public sealed partial class DataSourcesClient : IDataSourcesClient
    {
        private readonly IRestClient _restClient;

        public DataSourcesClient(IRestClient restClient)
        {
            _restClient = restClient;
        }
    }
}
