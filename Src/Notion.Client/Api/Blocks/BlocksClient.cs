using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using static Notion.Client.ApiEndpoints;

namespace Notion.Client
{
    public class BlocksClient : IBlocksClient
    {
        private readonly IRestClient _client;

        public BlocksClient(IRestClient client)
        {
            _client = client;
        }

        public async Task<PaginatedList<IBlock>> RetrieveChildrenAsync(
            string blockId,
            BlocksRetrieveChildrenParameters parameters = null, CancellationToken cancellationToken = default)
        {
            if (string.IsNullOrWhiteSpace(blockId))
            {
                throw new ArgumentNullException(nameof(blockId));
            }

            var url = BlocksApiUrls.RetrieveChildren(blockId);

            var queryParameters = (IBlocksRetrieveChildrenQueryParameters)parameters;

            var queryParams = new Dictionary<string, string>
            {
                { "start_cursor", queryParameters?.StartCursor },
                { "page_size", queryParameters?.PageSize?.ToString() }
            };

            return await _client.GetAsync<PaginatedList<IBlock>>(url, queryParams, cancellationToken: cancellationToken);
        }

        public async Task<PaginatedList<IBlock>> AppendChildrenAsync(
            string blockId,
            BlocksAppendChildrenParameters parameters = null, CancellationToken cancellationToken = default)
        {
            if (string.IsNullOrWhiteSpace(blockId))
            {
                throw new ArgumentNullException(nameof(blockId));
            }

            var url = BlocksApiUrls.AppendChildren(blockId);

            var body = (IBlocksAppendChildrenBodyParameters)parameters;

            return await _client.PatchAsync<PaginatedList<IBlock>>(url, body, cancellationToken: cancellationToken);
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
