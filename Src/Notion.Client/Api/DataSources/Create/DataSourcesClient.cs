using System;
using System.Threading;
using System.Threading.Tasks;

namespace Notion.Client
{
    public sealed partial class DataSourcesClient
    {
        public async Task<DataSource> CreateAsync(
            CreateDataSourceRequest request,
            CancellationToken cancellationToken = default)
        {
            var endpoint = ApiEndpoints.DataSourcesApiUrls.CreateDataSource();

            if (request == null)
            {
                throw new ArgumentNullException(nameof(request));
            }

            ICreateDataSourceBodyParameters body = request;

            if (body.Parent == null)
            {
                throw new ArgumentNullException(nameof(body.Parent), "Parent property cannot be null.");
            }

            if (body.Parent is DatabaseParentRequest dbParentRequest)
            {
                if (string.IsNullOrWhiteSpace(dbParentRequest.DatabaseId))
                {
                    throw new ArgumentException("DatabaseId in Parent cannot be null or empty when Parent is of type DatabaseParentRequest.", nameof(request.Parent));
                }
            }

            if (body.Properties == null)
            {
                throw new ArgumentException("Properties cannot be null or empty.", nameof(body.Properties));
            }

            return await _restClient.PostAsync<DataSource>(
                endpoint,
                body,
                cancellationToken: cancellationToken
            );
        }
    }
}
