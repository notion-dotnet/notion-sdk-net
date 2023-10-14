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
        /// <param name="cancellationToken"></param>
        /// <returns>
        ///     <see cref="ListUsersResponse" />
        /// </returns>
        Task<ListUsersResponse> ListAsync(CancellationToken cancellationToken = default);

        /// <summary>
        ///     Returns a paginated list of Users for the workspace.
        ///     The response may contain fewer than page_size of results.
        /// </summary>
        /// <param name="listUsersRequest"></param>
        /// <param name="cancellationToken"></param>
        /// <returns>
        ///      <see cref="ListUsersResponse" />
        /// </returns>
        Task<ListUsersResponse> ListAsync(
            ListUsersRequest listUsersRequest,
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
