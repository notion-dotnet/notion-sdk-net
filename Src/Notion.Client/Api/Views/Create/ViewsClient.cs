using System;
using System.Threading;
using System.Threading.Tasks;

namespace Notion.Client
{
    public sealed partial class ViewsClient
    {
        public async Task<View> CreateAsync(
            CreateViewRequest request,
            CancellationToken cancellationToken = default)
        {
            if (request == null)
            {
                throw new ArgumentNullException(nameof(request));
            }

            var endpoint = ApiEndpoints.ViewsApiUrls.Create();

            return await _restClient.PostAsync<View>(
                endpoint,
                request,
                cancellationToken: cancellationToken
            );
        }
    }
}
