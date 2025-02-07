using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using static Notion.Client.ApiEndpoints;

namespace Notion.Client
{
    public sealed partial class BlocksClient : IBlocksClient
    {
        private readonly IRestClient _client;

        public BlocksClient(IRestClient client)
        {
            _client = client;
        }

        public async Task<IBlock> RetrieveAsync(string blockId, CancellationToken cancellationToken = default)
        {
            if (string.IsNullOrWhiteSpace(blockId))
            {
                throw new ArgumentNullException(nameof(blockId));
            }

            var url = BlocksApiUrls.Retrieve(blockId);

            return await _client.GetAsync<IBlock>(url, cancellationToken: cancellationToken);
        }

        public async Task<IBlock> UpdateAsync(string blockId, IUpdateBlock updateBlock, CancellationToken cancellationToken = default)
        {
            if (string.IsNullOrWhiteSpace(blockId))
            {
                throw new ArgumentNullException(nameof(blockId));
            }

            var url = BlocksApiUrls.Update(blockId);

            return await _client.PatchAsync<IBlock>(url, updateBlock, cancellationToken: cancellationToken);
        }

        public async Task DeleteAsync(string blockId, CancellationToken cancellationToken = default)
        {
            if (string.IsNullOrWhiteSpace(blockId))
            {
                throw new ArgumentNullException(nameof(blockId));
            }

            var url = BlocksApiUrls.Delete(blockId);

            await _client.DeleteAsync(url, cancellationToken: cancellationToken);
        }
    }
}
