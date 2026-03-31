using System;
using System.Threading;
using System.Threading.Tasks;

namespace Notion.Client
{
    public sealed partial class DataSourcesClient
    {
        public async Task<DataSource> UpdateAsync(
            UpdateDataSourceRequest request,
            CancellationToken cancellationToken = default)
        {
            if (request == null)
            {
                throw new ArgumentNullException(nameof(request));
            }

            if (request.DataSourceId == null)
            {
                throw new ArgumentNullException(nameof(request.DataSourceId));
            }

            var path = ApiEndpoints.DataSourcesApiUrls.Update(request);

            // Create a clean body request with only the properties that should be serialized
            var bodyRequest = UpdateDataSourceBodyRequest.FromRequest(request);

            return await _restClient.PatchAsync<DataSource>(
                path,
                bodyRequest,
                cancellationToken: cancellationToken
            );
        }
    }
}
