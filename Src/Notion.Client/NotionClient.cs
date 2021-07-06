namespace Notion.Client
{
    public interface INotionClient
    {
        IUsersClient Users { get; }
        IDatabasesClient Databases { get; }
        IPagesClient Pages { get; }
        IBlocksClient Blocks { get; }
    }

    public class NotionClient : INotionClient
    {
        public NotionClient(ClientOptions options)
        {
            var restClient = new RestClient(options);
            Users = new UsersClient(restClient);
            Databases = new DatabasesClient(restClient);
            Pages = new PagesClient(restClient);
            Blocks = new BlocksClient(restClient);
        }

        public IUsersClient Users { get; }
        public IDatabasesClient Databases { get; }
        public IPagesClient Pages { get; }
        public IBlocksClient Blocks { get; }
    }
}
