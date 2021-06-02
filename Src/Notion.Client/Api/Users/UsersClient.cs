using System.Threading.Tasks;
using static Notion.Client.ApiEndpoints;

namespace Notion.Client
{
    public class UsersClient : IUsersClient
    {
        private readonly IRestClient _client;

        public UsersClient(IRestClient client)
        {
            _client = client;
        }

        public async Task<User> RetrieveAsync(string userId)
        {
            return await _client.GetAsync<User>(UsersApiUrls.Retrieve(userId));
        }

        public async Task<PaginatedList<User>> ListAsync()
        {
            return await _client.GetAsync<PaginatedList<User>>(UsersApiUrls.List());
        }
    }
}
