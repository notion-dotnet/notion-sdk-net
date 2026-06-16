using System;
using System.Threading;
using System.Threading.Tasks;

namespace Notion.Client
{
    public sealed partial class ViewsClient
    {
        public async Task<View> DeleteAsync(
            string viewId,
            CancellationToken cancellationToken = default)
        {
            if (string.IsNullOrWhiteSpace(viewId))
            {
                throw new ArgumentException("viewId cannot be null or empty.", nameof(viewId));
            }

            var endpoint = ApiEndpoints.ViewsApiUrls.Delete(viewId);

            return await _restClient.DeleteAsync<View>(endpoint, cancellationToken: cancellationToken);
        }
    }
}
