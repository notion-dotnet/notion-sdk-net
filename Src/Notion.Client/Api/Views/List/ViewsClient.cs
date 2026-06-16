using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Notion.Client
{
    public sealed partial class ViewsClient
    {
        public async Task<PaginatedList<View>> ListAsync(
            ListViewsRequest request,
            CancellationToken cancellationToken = default)
        {
            if (request == null)
            {
                throw new ArgumentNullException(nameof(request));
            }

            var endpoint = ApiEndpoints.ViewsApiUrls.List();

            var queryParams = new Dictionary<string, string>();

            if (!string.IsNullOrEmpty(request.DatabaseId))
            {
                queryParams["database_id"] = request.DatabaseId;
            }

            if (!string.IsNullOrEmpty(request.DataSourceId))
            {
                queryParams["data_source_id"] = request.DataSourceId;
            }

            if (!string.IsNullOrEmpty(request.StartCursor))
            {
                queryParams["start_cursor"] = request.StartCursor;
            }

            if (request.PageSize.HasValue)
            {
                queryParams["page_size"] = request.PageSize.Value.ToString();
            }

            return await _restClient.GetAsync<PaginatedList<View>>(
                endpoint,
                queryParams: queryParams,
                cancellationToken: cancellationToken
            );
        }
    }
}
