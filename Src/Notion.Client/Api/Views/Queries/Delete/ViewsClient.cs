using System;
using System.Threading;
using System.Threading.Tasks;

namespace Notion.Client
{
    public sealed partial class ViewsClient
    {
        public async Task<DeletedViewQueryResponse> DeleteQueryAsync(
            DeleteViewQueryRequest request,
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

            var endpoint = ApiEndpoints.ViewsApiUrls.DeleteQuery(request.ViewId, request.QueryId);

            return await _restClient.DeleteAsync<DeletedViewQueryResponse>(endpoint, cancellationToken: cancellationToken);
        }
    }
}
