using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Notion.Client
{
    public sealed partial class ViewsClient
    {
        public async Task<PaginatedList<PageReference>> GetQueryResultsAsync(
            GetViewQueryResultsRequest request,
            CancellationToken cancellationToken = default)
        {
            if (request == null)
            {
                throw new ArgumentNullException(nameof(request));
            }

            if (string.IsNullOrWhiteSpace(request.ViewId))
            {
                throw new ArgumentException("ViewId cannot be null or empty.", nameof(request.ViewId));
            }

            if (string.IsNullOrWhiteSpace(request.QueryId))
            {
                throw new ArgumentException("QueryId cannot be null or empty.", nameof(request.QueryId));
            }

            var endpoint = ApiEndpoints.ViewsApiUrls.GetQueryResults(request.ViewId, request.QueryId);

            var queryParams = new Dictionary<string, string>();

            if (!string.IsNullOrEmpty(request.StartCursor))
            {
                queryParams["start_cursor"] = request.StartCursor;
            }

            if (request.PageSize.HasValue)
            {
                queryParams["page_size"] = request.PageSize.Value.ToString();
            }

            return await _restClient.GetAsync<PaginatedList<PageReference>>(
                endpoint,
                queryParams: queryParams,
                cancellationToken: cancellationToken
            );
        }
    }
}
