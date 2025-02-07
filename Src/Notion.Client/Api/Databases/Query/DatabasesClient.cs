using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Notion.Client
{
    public sealed partial class DatabasesClient
    {
        public async Task<DatabaseQueryResponse> QueryAsync(
            string databaseId,
            DatabasesQueryParameters databasesQueryParameters, CancellationToken cancellationToken = default)
        {
            var body = (IDatabaseQueryBodyParameters)databasesQueryParameters;
            var queryParameters = (IDatabaseQueryQueryParameters)databasesQueryParameters;

            var queryParams = queryParameters.FilterProperties?
                .Select(x => new KeyValuePair<string, string>("filter_properties", x));

            return await _client.PostAsync<DatabaseQueryResponse>(
                ApiEndpoints.DatabasesApiUrls.Query(databaseId),
                body,
                queryParams,
                cancellationToken: cancellationToken
            );
        }
    }
}
