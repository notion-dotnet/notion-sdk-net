using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Notion.Client
{
    public sealed partial class BlocksClient
    {
        public async Task<RetrieveChildrenResponse> RetrieveChildrenAsync(
            BlockRetrieveChildrenRequest request,
            CancellationToken cancellationToken = default)
        {
            if (string.IsNullOrWhiteSpace(request.BlockId))
            {
                throw new ArgumentNullException(nameof(request.BlockId));
            }

            var url = ApiEndpoints.BlocksApiUrls.RetrieveChildren(request.BlockId);

            var queryParameters = (IBlockRetrieveChildrenQueryParameters)request;

            var queryParams = new Dictionary<string, string>
            {
                { "start_cursor", queryParameters?.StartCursor },
                { "page_size", queryParameters?.PageSize?.ToString() }
            };

            return await _client.GetAsync<RetrieveChildrenResponse>(
                url,
                queryParams,
                cancellationToken: cancellationToken
            );
        }
    }
}
