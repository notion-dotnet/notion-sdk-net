using System.Threading.Tasks;

namespace Notion.Client
{
    public interface IUsersClient
    {
        Task<User> RetrieveAsync(string userId);
        Task<PaginatedList<User>> ListAsync();

        /// <summary>
        /// Retrieves the bot User associated with the API token provided in the authorization header.
        /// </summary>
        /// <returns>User object of type bot having an owner field with information about the person who authorized the integration.</returns>
        Task<User> MeAsync();
    }
}
