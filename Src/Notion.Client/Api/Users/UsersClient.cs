using System.Threading;
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

        public async Task<User> RetrieveAsync(string userId, CancellationToken cancellationToken = default)
        {
            return await _client.GetAsync<User>(UsersApiUrls.Retrieve(userId), cancellationToken: cancellationToken);
        }

        public async Task<PaginatedList<User>> ListAsync(CancellationToken cancellationToken = default)
        {
            return await _client.GetAsync<PaginatedList<User>>(UsersApiUrls.List(), cancellationToken: cancellationToken);
        }

        /// <summary>
        ///     Retrieves the bot User associated with the API token provided in the authorization header.
        /// </summary>
        /// <returns>
        ///     User object of type bot having an owner field with information about the person who authorized the
        ///     integration.
        /// </returns>
        public async Task<User> MeAsync(CancellationToken cancellationToken = default)
        {
            return await _client.GetAsync<User>(UsersApiUrls.Me(), cancellationToken: cancellationToken);
        }
    }
}
