using System;
using System.Threading.Tasks;

namespace Notion.Client
{
    public interface IUsersClient
    {
        Task<PaginatedList<User>> ListAsync();
    }

    public class UsersClient : IUsersClient
    {
        private readonly IRestClient _client;

        public UsersClient(IRestClient client)
        {
            _client = client;
        }

        public async Task<PaginatedList<User>> ListAsync()
        {
            try
            {
                return await _client.GetAsync<PaginatedList<User>>("users");
            }
            catch (Exception e)
            {
                return null;
            }
        }
    }
}
