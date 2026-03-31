using System.Collections.Generic;
using System.Threading.Tasks;

namespace Notion.Client
{
    public sealed partial class FileUploadsClient
    {
        public async Task<ListFileUploadsResponse> ListAsync(
            ListFileUploadsRequest request,
            System.Threading.CancellationToken cancellationToken = default)
        {
            IListFileUploadsQueryParameters queryParameters = request;

            var queryParams = new Dictionary<string, string>
            {
                { "page_size", queryParameters.PageSize?.ToString() },
                { "start_cursor", queryParameters.StartCursor },
                { "status", queryParameters.Status }
            };

            return await _restClient.GetAsync<ListFileUploadsResponse>(
                ApiEndpoints.FileUploadsApiUrls.List,
                queryParams: queryParams,
                cancellationToken: cancellationToken
            );
        }
    }
}
