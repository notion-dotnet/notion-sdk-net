using System.Collections.Generic;
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

        public async Task<PaginatedList<Database>> ListAsync(DatabasesListParameters databasesListParameters = null)
        {
            var databasesListQueryParmaters = (IDatabasesListQueryParmaters)databasesListParameters;

            var queryParams = new Dictionary<string, string>()
            {
                { "start_cursor", databasesListQueryParmaters?.StartCursor },
                { "page_size", databasesListQueryParmaters?.PageSize }
            };

            return await _client.GetAsync<PaginatedList<Database>>(DatabasesApiUrls.List(), queryParams);
        }

        public async Task<PaginatedList<RetrievedPage>> QueryAsync(string databaseId, DatabasesQueryParameters databasesQueryParameters)
        {
            var body = (IDatabaseQueryBodyParameters)databasesQueryParameters;

            return await _client.PostAsync<PaginatedList<RetrievedPage>>(DatabasesApiUrls.Query(databaseId), body);
        }
    }
}
