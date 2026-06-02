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

            if (!string.IsNullOrWhiteSpace(request.After) && request.Position != null)
            {
                throw new ArgumentException("After and Position cannot both be specified.", nameof(request.Position));
            }

            var url = ApiEndpoints.BlocksApiUrls.AppendChildren(request.BlockId);

            var body = new BlockAppendChildrenBodyParameters(request);

            return await _client.PatchAsync<AppendChildrenResponse>(url, body, cancellationToken: cancellationToken);
        }
    }
}
