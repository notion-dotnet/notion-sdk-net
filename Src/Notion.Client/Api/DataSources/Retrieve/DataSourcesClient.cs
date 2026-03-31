using System;
using System.Threading;
using System.Threading.Tasks;

namespace Notion.Client
{
    public sealed partial class DataSourcesClient
    {
        public async Task<DataSource> RetrieveAsync(
            RetrieveDataSourceRequest request,
            CancellationToken cancellationToken = default)
        {
            IRetrieveDataSourcePathParameters pathParameters = request;

            if (pathParameters == null)
            {
                throw new ArgumentNullException(nameof(pathParameters));
            }

            if (string.IsNullOrWhiteSpace(pathParameters.DataSourceId))
            {
                throw new ArgumentException("DataSourceId cannot be null or empty.", nameof(pathParameters.DataSourceId));
            }

            var endpoint = ApiEndpoints.DataSourcesApiUrls.Retrieve(pathParameters);

            return await _restClient.GetAsync<DataSource>(endpoint, cancellationToken: cancellationToken);
        }
    }
}
