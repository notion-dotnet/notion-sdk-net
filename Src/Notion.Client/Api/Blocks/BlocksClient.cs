using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using static Notion.Client.ApiEndpoints;

namespace Notion.Client
{
    public interface IBlocksClient
    {
        Task<PaginatedList<BlockBase>> RetrieveChildrenAsync(string blockId, BlocksRetrieveChildrenParameters parameters = null);
        Task<BlockBase> AppendChildrenAsync(string blockId, BlocksAppendChildrenParameters parameters = null);
    }

    public class BlocksClient : IBlocksClient
    {
        private readonly IRestClient _client;

        public BlocksClient(IRestClient client)
        {
            _client = client;
        }

        public async Task<PaginatedList<BlockBase>> RetrieveChildrenAsync(string blockId, BlocksRetrieveChildrenParameters parameters = null)
        {
            if (string.IsNullOrWhiteSpace(blockId))
            {
                throw new ArgumentNullException(nameof(blockId));
            }

            var url = BlocksApiUrls.RetrieveChildren(blockId);

            var queryParameters = (IBlocksRetrieveChildrenQueryParameters)parameters;

            var queryParams = new Dictionary<string, string>()
            {
                { "start_cursor", queryParameters?.StartCursor?.ToString() },
                { "page_size", queryParameters?.PageSize?.ToString() }
            };

            return await _client.GetAsync<PaginatedList<BlockBase>>(url, queryParams);
        }

        public async Task<BlockBase> AppendChildrenAsync(string blockId, BlocksAppendChildrenParameters parameters = null)
        {
            if (string.IsNullOrWhiteSpace(blockId))
            {
                throw new ArgumentNullException(nameof(blockId));
            }

            var url = BlocksApiUrls.AppendChildren(blockId);

            var body = (IBlocksAppendChildrenBodyParameters)parameters;

            return await _client.PatchAsync<BlockBase>(url, body);
        }
    }
}