using System.Threading;
using System.Threading.Tasks;
using Notion.Client.List.Request;

namespace Notion.Client
{
    public interface IUsersClient
    {
        /// <summary>
        ///     Retrieves a User using the ID specified.
        /// </summary>
        /// <param name="userId">Identifier for a Notion user</param>
        /// <returns>
        ///     <see cref="User" />
        /// </returns>
        Task<User> RetrieveAsync(string userId, CancellationToken cancellationToken = default);

        /// <summary>
        ///     Returns a paginated list of Users for the workspace.
        ///     The response may contain fewer than page_size of results.
        /// </summary>
        /// <returns>
        ///     <see cref="PaginatedList{User}" />
        /// </returns>
        Task<PaginatedList<User>> ListAsync(CancellationToken cancellationToken = default);

        Task<PaginatedList<User>> ListAsync(
            ListUsersParameters listUsersParameters,
            CancellationToken cancellationToken = default
        );

        /// <summary>
        ///     Retrieves the bot User associated with the API token provided in the authorization header.
        /// </summary>
        /// <returns>
        ///     <see cref="User" /> object of type bot having an owner field with information about the person who authorized
        ///     the integration.
        /// </returns>
        Task<User> MeAsync(CancellationToken cancellationToken = default);
    }
}
