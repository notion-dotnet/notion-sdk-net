using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Notion.Client
{
    public sealed partial class DataSourcesClient
    {
        public async Task<ListDataSourceTemplatesResponse> ListDataSourceTemplatesAsync(
            ListDataSourceTemplatesRequest request,
            CancellationToken cancellationToken = default)
        {
            if (request == null)
            {
                throw new ArgumentNullException(nameof(request));
            }

            if (string.IsNullOrWhiteSpace(request.DataSourceId))
            {
                throw new ArgumentException("DataSourceId cannot be null or empty.", nameof(request.DataSourceId));
            }

            IListDataSourceTemplatesPathParameters pathParameters = request;

            var endpoint = ApiEndpoints.DataSourcesApiUrls.ListDataSourceTemplates(pathParameters);

            IListDataSourceTemplatesQueryParameters queryParameters = request;

            var queryParams = new Dictionary<string, string>()
            {
                { "name", queryParameters.Name },
                { "start_cursor", queryParameters.StartCursor },
                { "page_size", queryParameters.PageSize?.ToString() }
            };

            return await _restClient.GetAsync<ListDataSourceTemplatesResponse>(
                endpoint,
                queryParams: queryParams,
                cancellationToken: cancellationToken
            );
        }
    }
}
