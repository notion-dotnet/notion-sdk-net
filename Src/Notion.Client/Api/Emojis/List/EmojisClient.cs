using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Notion.Client
{
    public sealed partial class EmojisClient
    {
        public async Task<ListEmojisResponse> ListAsync(
            ListEmojisRequest request,
            CancellationToken cancellationToken = default)
        {
            IListEmojisQueryParameters queryParameters = request;

            var queryParams = new Dictionary<string, string>
            {
                { "start_cursor", queryParameters.StartCursor },
                { "page_size", queryParameters.PageSize?.ToString() }
            };

            return await _restClient.GetAsync<ListEmojisResponse>(
                ApiEndpoints.EmojisApiUrls.List,
                queryParams: queryParams,
                cancellationToken: cancellationToken
            );
        }
    }
}
