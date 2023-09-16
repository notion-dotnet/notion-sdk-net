using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Notion.Client.List.Request;

namespace Notion.Client
{
    public partial class UsersClient
    {
        public async Task<PaginatedList<User>> ListAsync(
            ListUsersParameters listUsersParameters,
            CancellationToken cancellationToken = default
        )
        {
            var queryParameters = (IListUsersQueryParameters)listUsersParameters;

            var queryParams = new Dictionary<string, string>
            {
                { "start_cursor", queryParameters?.StartCursor },
                { "page_size", queryParameters?.PageSize?.ToString() }
            };

            return await _client.GetAsync<PaginatedList<User>>(
                ApiEndpoints.UsersApiUrls.List(),
                queryParams,
                cancellationToken: cancellationToken
            );
        }
    }
}
