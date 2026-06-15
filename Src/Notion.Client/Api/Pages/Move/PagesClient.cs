using System;
using System.Threading;
using System.Threading.Tasks;

namespace Notion.Client
{
    public partial class PagesClient
    {
        public async Task<Page> MoveAsync(
            MovePageRequest request,
            CancellationToken cancellationToken = default
        )
        {
            if (request is null)
            {
                throw new ArgumentNullException(nameof(request));
            }

            var url = ApiEndpoints.PagesApiUrls.Move(request.PageId);

            var body = MovePageBodyParameters.FromRequest(request);

            return await _client.PatchAsync<Page>(url, body, cancellationToken: cancellationToken);
        }
    }
}
