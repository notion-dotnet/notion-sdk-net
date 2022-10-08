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

        public async Task<Database> RetrieveAsync(string databaseId)
        {
            return await _client.GetAsync<Database>(DatabasesApiUrls.Retrieve(databaseId));
        }

        public async Task<PaginatedList<Page>> QueryAsync(
            string databaseId,
            DatabasesQueryParameters databasesQueryParameters)
        {
            var body = (IDatabaseQueryBodyParameters)databasesQueryParameters;

            return await _client.PostAsync<PaginatedList<Page>>(DatabasesApiUrls.Query(databaseId), body);
        }

        public async Task<Database> CreateAsync(DatabasesCreateParameters databasesCreateParameters)
        {
            var body = (IDatabasesCreateBodyParameters)databasesCreateParameters;

            return await _client.PostAsync<Database>(DatabasesApiUrls.Create, body);
        }

        public async Task<Database> UpdateAsync(string databaseId, DatabasesUpdateParameters databasesUpdateParameters)
        {
            var body = (IDatabasesUpdateBodyParameters)databasesUpdateParameters;

            return await _client.PatchAsync<Database>(DatabasesApiUrls.Update(databaseId), body);
        }
    }
}
