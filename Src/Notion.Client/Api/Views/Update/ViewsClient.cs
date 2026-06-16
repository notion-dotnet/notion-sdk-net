using System;
using System.Threading;
using System.Threading.Tasks;

namespace Notion.Client
{
    public sealed partial class ViewsClient
    {
        public async Task<View> UpdateAsync(
            UpdateViewRequest request,
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

            var endpoint = ApiEndpoints.ViewsApiUrls.Update(request.ViewId);

            return await _restClient.PatchAsync<View>(
                endpoint,
                request,
                cancellationToken: cancellationToken
            );
        }
    }
}
