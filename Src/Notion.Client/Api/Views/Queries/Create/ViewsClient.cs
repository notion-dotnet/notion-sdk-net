using System;
using System.Threading;
using System.Threading.Tasks;

namespace Notion.Client
{
    public sealed partial class ViewsClient
    {
        public async Task<ViewQueryResponse> CreateQueryAsync(
            CreateViewQueryRequest request,
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

            var endpoint = ApiEndpoints.ViewsApiUrls.CreateQuery(request.ViewId);

            return await _restClient.PostAsync<ViewQueryResponse>(
                endpoint,
                request,
                cancellationToken: cancellationToken
            );
        }
    }
}
