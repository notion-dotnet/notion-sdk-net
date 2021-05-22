using System;
using System.Threading.Tasks;

namespace Notion.Client
{
    public interface IUsersClient
    {
        Task<User> RetrieveAsync(string userId);
        Task<PaginatedList<User>> ListAsync();
    }

    public class UsersClient : IUsersClient
    {
        private readonly IRestClient _client;

        public UsersClient(IRestClient client)
        {
            _client = client;
        }

        public async Task<User> RetrieveAsync(string userId)
        {
            try
            {
                return await _client.GetAsync<User>($"users/{userId}");
            }
            catch (Exception e)
            {
                return null;
            }
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
