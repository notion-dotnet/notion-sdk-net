using System;
using System.Threading;
using System.Threading.Tasks;
using static Notion.Client.ApiEndpoints;

namespace Notion.Client
{
    public sealed partial class DatabasesClient
    {
        public async Task<Database> UpdateAsync(DatabasesUpdateRequest databasesUpdateRequest, CancellationToken cancellationToken = default)
        {
            IDatabasesUpdateBodyParameters body = databasesUpdateRequest;

            if (body == null)
            {
                throw new ArgumentNullException(nameof(databasesUpdateRequest));
            }

            if (string.IsNullOrEmpty(databasesUpdateRequest.DatabaseId))
            {
                throw new ArgumentNullException(nameof(databasesUpdateRequest.DatabaseId));
            }

            var path = DatabasesApiUrls.Update(databasesUpdateRequest.DatabaseId);

            return await _client.PatchAsync<Database>(
                path,
                body,
                cancellationToken: cancellationToken
            );
        }
    }
}