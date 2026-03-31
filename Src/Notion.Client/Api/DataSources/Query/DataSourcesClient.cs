using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Notion.Client
{
    public sealed partial class DataSourcesClient
    {
        public async Task<QueryDataSourceResponse> QueryAsync(
            QueryDataSourceRequest request,
            CancellationToken cancellationToken = default)
        {
            IQueryDataSourcePathParameters pathParameters = request;

            if (pathParameters == null)
            {
                throw new ArgumentNullException(nameof(request), "Request cannot be null and must implement IQueryDataSourcePathParameters.");
            }

            if (pathParameters.DataSourceId == null)
            {
                throw new ArgumentNullException(
                    nameof(pathParameters.DataSourceId),
                    "DataSourceId cannot be null. Ensure the request implements IQueryDataSourcePathParameters and has DataSourceId set."
                );
            }

            IQueryDataSourceBodyParameters body = request;

            if (body == null)
            {
                throw new ArgumentNullException(nameof(request), "Request must implement IQueryDataSourceBodyParameters.");
            }

            var path = ApiEndpoints.DataSourcesApiUrls.Query(pathParameters);

            var queryParameters = request as IQueryDataSourceQueryParameters;
            var queryParams = queryParameters.FilterProperties?
                .Select(x => new KeyValuePair<string, string>("filter_properties", x));

            // Create a clean body request with only the properties that should be serialized
            var bodyRequest = QueryDataSourceBodyRequest.FromRequest(request);

            return await _restClient.PostAsync<QueryDataSourceResponse>(
                path,
                bodyRequest,
                queryParams,
                cancellationToken: cancellationToken
            );
        }
    }
}