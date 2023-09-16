using System.Threading;
using System.Threading.Tasks;
using static Notion.Client.ApiEndpoints;

namespace Notion.Client
{
    public class DatabasesClient : IDatabasesClient
    {
        private readonly IRestClient _client;

        public DatabasesClient(IRestClient client)
        {
            _client = client;
        }

        public async Task<Database> RetrieveAsync(string databaseId, CancellationToken cancellationToken = default)
        {
            return await _client.GetAsync<Database>(DatabasesApiUrls.Retrieve(databaseId), cancellationToken: cancellationToken);
        }

        public async Task<PaginatedList<Page>> QueryAsync(
            string databaseId,
            DatabasesQueryParameters databasesQueryParameters, CancellationToken cancellationToken = default)
        {
            var body = (IDatabaseQueryBodyParameters)databasesQueryParameters;

            return await _client.PostAsync<PaginatedList<Page>>(DatabasesApiUrls.Query(databaseId), body, cancellationToken: cancellationToken);
        }

        public async Task<Database> CreateAsync(DatabasesCreateParameters databasesCreateParameters, CancellationToken cancellationToken = default)
        {
            var body = (IDatabasesCreateBodyParameters)databasesCreateParameters;

            return await _client.PostAsync<Database>(DatabasesApiUrls.Create, body, cancellationToken: cancellationToken);
        }

        public async Task<Database> UpdateAsync(string databaseId, DatabasesUpdateParameters databasesUpdateParameters, CancellationToken cancellationToken = default)
        {
            var body = (IDatabasesUpdateBodyParameters)databasesUpdateParameters;

            return await _client.PatchAsync<Database>(DatabasesApiUrls.Update(databaseId), body, cancellationToken: cancellationToken);
        }
    }
}
