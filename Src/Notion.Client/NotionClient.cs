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
        public NotionClient(
            RestClient restClient,
            UsersClient users,
            DatabasesClient databases,
            PagesClient pages,
            SearchClient search,
            BlocksClient blocks)
        {
            RestClient = restClient;
            Users = users;
            Databases = databases;
            Pages = pages;
            Search = search;
            Blocks = blocks;
        }

        public IUsersClient Users { get; }
        public IDatabasesClient Databases { get; }
        public IPagesClient Pages { get; }
        public ISearchClient Search { get; }
        public IBlocksClient Blocks { get; }
        public IRestClient RestClient { get; }
    }
}
