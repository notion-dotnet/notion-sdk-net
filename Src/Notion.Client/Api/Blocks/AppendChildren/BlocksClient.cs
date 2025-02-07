using System;
using System.Threading;
using System.Threading.Tasks;

namespace Notion.Client
{
    public sealed partial class BlocksClient
    {
        public async Task<AppendChildrenResponse> AppendChildrenAsync(
            BlockAppendChildrenRequest request,
            CancellationToken cancellationToken = default)
        {
            if (string.IsNullOrWhiteSpace(request.BlockId))
            {
                throw new ArgumentNullException(nameof(request.BlockId));
            }

            var url = ApiEndpoints.BlocksApiUrls.AppendChildren(request.BlockId);

            var body = new BlockAppendChildrenBodyParameters(request);

            return await _client.PatchAsync<AppendChildrenResponse>(url, body, cancellationToken: cancellationToken);
        }
    }
}
