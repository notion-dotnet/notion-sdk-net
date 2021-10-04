namespace Notion.Client
{
    public interface INotionClient
    {
        IUsersClient Users { get; }
        IDatabasesClient Databases { get; }
        IPagesClient Pages { get; }
        ISearchClient Search { get; }
        IBlocksClient Blocks { get; }
        IRestClient RestClient { get; }
    }

    public class NotionClient : INotionClient
    {
        public NotionClient(ClientOptions options)
        {
            RestClient = new RestClient(options);
            Users = new UsersClient(RestClient);
            Databases = new DatabasesClient(RestClient);
            Pages = new PagesClient(RestClient);
            Search = new SearchClient(RestClient);
            Blocks = new BlocksClient(RestClient);
        }

        public IUsersClient Users { get; }
        public IDatabasesClient Databases { get; }
        public IPagesClient Pages { get; }
        public ISearchClient Search { get; }
        public IBlocksClient Blocks { get; }
        public IRestClient RestClient { get; }
    }
}
