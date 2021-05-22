namespace Notion.Client
{
    public class NotionClient : INotionClient
    {
        public NotionClient(ClientOptions options)
        {
            Users = new UsersClient(new RestClient(options));
        }

        public string AuthToken { get; }
        public IUsersClient Users { get; }
    }

    public interface INotionClient
    {
        string AuthToken { get; }
        IUsersClient Users { get; }
    }
}
