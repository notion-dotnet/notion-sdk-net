namespace Notion.Client
{
    public class NotionClient : INotionClient
    {
        public NotionClient(string authToken)
        {
            AuthToken = authToken;
            Users = new UsersClient(new RestClient(authToken));
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
