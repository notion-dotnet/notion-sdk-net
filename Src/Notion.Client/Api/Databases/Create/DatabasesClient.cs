using System;
using System.Threading;
using System.Threading.Tasks;
using static Notion.Client.ApiEndpoints;

namespace Notion.Client
{
    public sealed partial class DatabasesClient : IDatabasesClient
    {
        public async Task<Database> CreateAsync(
            DatabasesCreateRequest databasesCreateParameters,
            CancellationToken cancellationToken = default)
        {
            var body = (IDatabasesCreateBodyParameters)databasesCreateParameters;

            if (body.Parent == null)
            {
                throw new ArgumentNullException(nameof(body.Parent), "Parent cannot be null.");
            }

            return await _client.PostAsync<Database>(
                DatabasesApiUrls.Create,
                body,
                cancellationToken: cancellationToken
            );
        }
    }
}
