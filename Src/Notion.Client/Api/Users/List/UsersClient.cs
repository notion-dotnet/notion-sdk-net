using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Notion.Client.List.Request;

namespace Notion.Client
{
    public partial class UsersClient
    {
        public async Task<ListUsersResponse> ListAsync(CancellationToken cancellationToken = default)
        {
            return await _client.GetAsync<ListUsersResponse>(
                ApiEndpoints.UsersApiUrls.List(),
                cancellationToken: cancellationToken
            );
        }

        public async Task<ListUsersResponse> ListAsync(
            ListUsersRequest listUsersRequest,
            CancellationToken cancellationToken = default
        )
        {
            var queryParameters = (IListUsersQueryParameters)listUsersRequest;

            var queryParams = new Dictionary<string, string>
            {
                { "start_cursor", queryParameters?.StartCursor },
                { "page_size", queryParameters?.PageSize?.ToString() }
            };

            return await _client.GetAsync<ListUsersResponse>(
                ApiEndpoints.UsersApiUrls.List(),
                queryParams,
                cancellationToken: cancellationToken
            );
        }
    }
}
