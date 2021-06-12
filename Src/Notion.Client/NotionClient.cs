namespace Notion.Client
{
    public interface INotionClient
    {
        IUsersClient Users { get; }
        IDatabasesClient Databases { get; }
        ISearchClient Search { get; }
    }

    public class NotionClient : INotionClient
    {
        public NotionClient(ClientOptions options)
        {
            var restClient = new RestClient(options);
            Users = new UsersClient(restClient);
            Databases = new DatabasesClient(restClient);
            Search = new SearchClient(restClient);
        }

        public IUsersClient Users { get; }
        public IDatabasesClient Databases { get; }
        public ISearchClient Search { get; }
    }
}
