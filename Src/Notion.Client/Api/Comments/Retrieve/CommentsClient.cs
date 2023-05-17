using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Threading;
using System.Threading.Tasks;

namespace Notion.Client
{
    public partial class CommentsClient
    {
        [SuppressMessage("ReSharper", "UnusedMember.Global")]
        public async Task<RetrieveCommentsResponse> RetrieveAsync(RetrieveCommentsParameters parameters, CancellationToken cancellationToken = default)
        {
            var qp = (IRetrieveCommentsQueryParameters)parameters;

            var queryParams = new Dictionary<string, string>
            {
                { "block_id", qp.BlockId },
                { "start_cursor", qp.StartCursor },
                { "page_size", qp.PageSize.ToString() }
            };

            return await _client.GetAsync<RetrieveCommentsResponse>(
                ApiEndpoints.CommentsApiUrls.Retrieve(),
                queryParams,
                cancellationToken: cancellationToken
            );
        }
    }
}
